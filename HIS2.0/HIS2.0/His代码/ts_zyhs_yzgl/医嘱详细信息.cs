using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TrasenHIS.BLL;
using ts_ybznsh_interface;


namespace ts_zyhs_yzgl
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class frmYZXX : System.Windows.Forms.Form
    {
        //自定义变量
        private BaseFunc myFunc;
        public long Group_ID = 0, nType = 0, MNGType = 0, MNGType2 = 0;
        public Guid OrderID = Guid.Empty;
        public string sTitle = "";
        public bool isSSMZ = false;
        public bool isCX = false;//查询
        public bool isUNCZ = false;//不允许操作
        private SystemCfg cfg7159 = new SystemCfg(7159);//add by zouchihua 2013-8-23
        private SystemCfg cfg7191 = new SystemCfg(7191); //add by zouchihua 2014-4-4  7026开启时.已经进入暂存的药品冲正是否自动删除该消息
        private SystemCfg cfg7192 = new SystemCfg(7192);//add by zouchihua 2014-4-7  7053开启时，医技项目退费不自动冲正的执行科室
        private SystemCfg cfg7207 = new SystemCfg(7207);//yaokx 2014-06-27
        private SystemCfg cfg7211 = new SystemCfg(7211);
        private SystemCfg cfg7214 = new SystemCfg(7214);//临时医嘱是否允许冲数量

        public SystemCfg _cfg6227 = new SystemCfg(6227);//不允许护士转打包时间 【如果不开启则维护为空 如开启则按照格式维护如(20:00)】
        public SystemCfg _cfg6228 = new SystemCfg(6228);//不允许护士转打包时间的时长【默认格式“HH$mm”】

        /// <summary>
        /// add by zouchihua 2014-08-1  住院是否启用项目费用确认（除医技项目外）
        /// </summary>
        private SystemCfg cfg7212 = new SystemCfg(7212);
        //特殊治疗
        public bool isTSZL = false;
        //口服药统领分类代码
        string tlfl = "";//(new SystemCfg(7048)).Config.Trim();
        //拆零口服药是否允许退费
        bool _isclkfyty = true;//(new SystemCfg(7054)).Config.Trim() == "0" ? false : true;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.Label lb5;
        private System.Windows.Forms.Label lb6;
        private System.Windows.Forms.Label lb17;
        private System.Windows.Forms.Label lb18;
        private System.Windows.Forms.Label lb19;
        private System.Windows.Forms.Label lb20;
        private System.Windows.Forms.Label lb21;
        private System.Windows.Forms.Label lb22;
        private System.Windows.Forms.Label lb23;
        private System.Windows.Forms.Label lb24;
        private System.Windows.Forms.Label lb25;
        private System.Windows.Forms.Button bt冲正;
        private System.Windows.Forms.Button bt退出;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lb11;
        private System.Windows.Forms.Label lb10;
        private System.Windows.Forms.Label lb9;
        private System.Windows.Forms.Label lb8;
        private System.Windows.Forms.Label lb7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lb16;
        private System.Windows.Forms.Label lb15;
        private System.Windows.Forms.Label lb14;
        private System.Windows.Forms.Label lb13;
        private System.Windows.Forms.Label lb12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lb27;
        private System.Windows.Forms.Label lb26;
        private System.Windows.Forms.Label lb28;
        private System.Windows.Forms.Label lb29;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb每条医嘱;
        private System.Windows.Forms.RadioButton rb每组医嘱;
        private System.Windows.Forms.Button bt反选;
        private System.Windows.Forms.Button bt全选;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbLX;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button bt取消冲正;
        private System.Windows.Forms.CheckBox cb显示已删除费用;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private TrasenClasses.GeneralControls.DataGridEx dataGridEx1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbCharge;
        private System.Windows.Forms.RadioButton rbUncharge;
        private System.ComponentModel.IContainer components;
        private Button button2;
        private RadioButton rbsl;
        private RadioButton rbcs;
        private Label label28;
        private Label lblZfbl;
        private ToolTip toolTip2;
        private Label lblUnEnableCz;
        private Button btnZdb;
        private Button button3;
        public bool zczyz_notfy = false;

        //Modify By Tany 2015-12-29 把住院号变成全局变量，在load里面赋值
        string _inpatientNo = "";
        string _yblx = "";
        string _xzlx = "";

        public frmYZXX()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            myFunc = new BaseFunc();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbLX = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lb25 = new System.Windows.Forms.Label();
            this.lb24 = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.lb23 = new System.Windows.Forms.Label();
            this.lb22 = new System.Windows.Forms.Label();
            this.lb21 = new System.Windows.Forms.Label();
            this.lb20 = new System.Windows.Forms.Label();
            this.lb19 = new System.Windows.Forms.Label();
            this.lb18 = new System.Windows.Forms.Label();
            this.lb17 = new System.Windows.Forms.Label();
            this.lb6 = new System.Windows.Forms.Label();
            this.lb5 = new System.Windows.Forms.Label();
            this.lb4 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.bt冲正 = new System.Windows.Forms.Button();
            this.bt退出 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbsl = new System.Windows.Forms.RadioButton();
            this.rbcs = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bt取消冲正 = new System.Windows.Forms.Button();
            this.lb26 = new System.Windows.Forms.Label();
            this.lb27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lb11 = new System.Windows.Forms.Label();
            this.lb10 = new System.Windows.Forms.Label();
            this.lb9 = new System.Windows.Forms.Label();
            this.lb8 = new System.Windows.Forms.Label();
            this.lb7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnZdb = new System.Windows.Forms.Button();
            this.lb28 = new System.Windows.Forms.Label();
            this.lb29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lb16 = new System.Windows.Forms.Label();
            this.lb15 = new System.Windows.Forms.Label();
            this.lb14 = new System.Windows.Forms.Label();
            this.lb13 = new System.Windows.Forms.Label();
            this.lb12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.cb显示已删除费用 = new System.Windows.Forms.CheckBox();
            this.rb每条医嘱 = new System.Windows.Forms.RadioButton();
            this.rb每组医嘱 = new System.Windows.Forms.RadioButton();
            this.bt反选 = new System.Windows.Forms.Button();
            this.bt全选 = new System.Windows.Forms.Button();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridEx1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbUncharge = new System.Windows.Forms.RadioButton();
            this.rbCharge = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.lblZfbl = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.lblUnEnableCz = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "医嘱类型：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(508, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "录入科室：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "医嘱内容：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(8, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "数量：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(120, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "单位：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(304, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 13;
            this.label14.Text = "频率：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(228, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 16);
            this.label15.TabIndex = 14;
            this.label15.Text = "剂数：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(532, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 16);
            this.label16.TabIndex = 15;
            this.label16.Text = "用法：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(208, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 16);
            this.label18.TabIndex = 17;
            this.label18.Text = "录入时间：";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(404, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 16);
            this.label19.TabIndex = 18;
            this.label19.Text = "录入人：";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(396, 56);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 19;
            this.label20.Text = "滴速：";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(508, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 16);
            this.label21.TabIndex = 20;
            this.label21.Text = "执行科室：";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbLX);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.lb25);
            this.groupBox1.Controls.Add(this.lb24);
            this.groupBox1.Controls.Add(this.lb23);
            this.groupBox1.Controls.Add(this.lb22);
            this.groupBox1.Controls.Add(this.lb21);
            this.groupBox1.Controls.Add(this.lb20);
            this.groupBox1.Controls.Add(this.lb19);
            this.groupBox1.Controls.Add(this.lb18);
            this.groupBox1.Controls.Add(this.lb17);
            this.groupBox1.Controls.Add(this.lb6);
            this.groupBox1.Controls.Add(this.lb5);
            this.groupBox1.Controls.Add(this.lb4);
            this.groupBox1.Controls.Add(this.lb1);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(4, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 76);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // lbLX
            // 
            this.lbLX.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLX.Location = new System.Drawing.Point(356, 36);
            this.lbLX.Name = "lbLX";
            this.lbLX.Size = new System.Drawing.Size(32, 16);
            this.lbLX.TabIndex = 50;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(308, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 16);
            this.label22.TabIndex = 49;
            this.label22.Text = "类型：";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb25
            // 
            this.lb25.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb25.Location = new System.Drawing.Point(456, 56);
            this.lb25.Name = "lb25";
            this.lb25.Size = new System.Drawing.Size(72, 16);
            this.lb25.TabIndex = 48;
            // 
            // lb24
            // 
            this.lb24.ContextMenu = this.contextMenu1;
            this.lb24.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb24.Location = new System.Drawing.Point(580, 56);
            this.lb24.Name = "lb24";
            this.lb24.Size = new System.Drawing.Size(128, 16);
            this.lb24.TabIndex = 47;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "增加草药煎药费";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // lb23
            // 
            this.lb23.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb23.Location = new System.Drawing.Point(352, 56);
            this.lb23.Name = "lb23";
            this.lb23.Size = new System.Drawing.Size(48, 16);
            this.lb23.TabIndex = 46;
            // 
            // lb22
            // 
            this.lb22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb22.Location = new System.Drawing.Point(276, 56);
            this.lb22.Name = "lb22";
            this.lb22.Size = new System.Drawing.Size(28, 16);
            this.lb22.TabIndex = 45;
            // 
            // lb21
            // 
            this.lb21.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb21.Location = new System.Drawing.Point(168, 56);
            this.lb21.Name = "lb21";
            this.lb21.Size = new System.Drawing.Size(52, 16);
            this.lb21.TabIndex = 44;
            // 
            // lb20
            // 
            this.lb20.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb20.Location = new System.Drawing.Point(72, 56);
            this.lb20.Name = "lb20";
            this.lb20.Size = new System.Drawing.Size(48, 16);
            this.lb20.TabIndex = 43;
            // 
            // lb19
            // 
            this.lb19.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb19.Location = new System.Drawing.Point(460, 36);
            this.lb19.Name = "lb19";
            this.lb19.Size = new System.Drawing.Size(40, 16);
            this.lb19.TabIndex = 42;
            // 
            // lb18
            // 
            this.lb18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb18.Location = new System.Drawing.Point(576, 36);
            this.lb18.Name = "lb18";
            this.lb18.Size = new System.Drawing.Size(132, 16);
            this.lb18.TabIndex = 41;
            // 
            // lb17
            // 
            this.lb17.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb17.Location = new System.Drawing.Point(76, 36);
            this.lb17.Name = "lb17";
            this.lb17.Size = new System.Drawing.Size(228, 16);
            this.lb17.TabIndex = 40;
            // 
            // lb6
            // 
            this.lb6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb6.Location = new System.Drawing.Point(460, 16);
            this.lb6.Name = "lb6";
            this.lb6.Size = new System.Drawing.Size(48, 16);
            this.lb6.TabIndex = 29;
            // 
            // lb5
            // 
            this.lb5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb5.Location = new System.Drawing.Point(576, 16);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(132, 16);
            this.lb5.TabIndex = 28;
            // 
            // lb4
            // 
            this.lb4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb4.Location = new System.Drawing.Point(274, 16);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(124, 16);
            this.lb4.TabIndex = 27;
            // 
            // lb1
            // 
            this.lb1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb1.Location = new System.Drawing.Point(76, 16);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(132, 16);
            this.lb1.TabIndex = 24;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(392, 36);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 16);
            this.label25.TabIndex = 21;
            this.label25.Text = "执行次数：";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bt冲正
            // 
            this.bt冲正.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt冲正.Enabled = false;
            this.bt冲正.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt冲正.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt冲正.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt冲正.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt冲正.ImageIndex = 4;
            this.bt冲正.Location = new System.Drawing.Point(907, 24);
            this.bt冲正.Name = "bt冲正";
            this.bt冲正.Size = new System.Drawing.Size(97, 24);
            this.bt冲正.TabIndex = 57;
            this.bt冲正.Text = "冲正(&C)";
            this.bt冲正.Click += new System.EventHandler(this.bt冲正_Click);
            // 
            // bt退出
            // 
            this.bt退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt退出.ImageIndex = 4;
            this.bt退出.Location = new System.Drawing.Point(907, 52);
            this.bt退出.Name = "bt退出";
            this.bt退出.Size = new System.Drawing.Size(97, 24);
            this.bt退出.TabIndex = 55;
            this.bt退出.Text = "退出(&E)";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rbsl);
            this.groupBox4.Controls.Add(this.rbcs);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(724, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 76);
            this.groupBox4.TabIndex = 58;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "请输入冲正次数 ";
            // 
            // rbsl
            // 
            this.rbsl.AutoSize = true;
            this.rbsl.Location = new System.Drawing.Point(113, 46);
            this.rbsl.Name = "rbsl";
            this.rbsl.Size = new System.Drawing.Size(47, 16);
            this.rbsl.TabIndex = 63;
            this.rbsl.Text = "数量";
            this.rbsl.UseVisualStyleBackColor = true;
            this.rbsl.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbcs
            // 
            this.rbcs.AutoSize = true;
            this.rbcs.Checked = true;
            this.rbcs.ForeColor = System.Drawing.Color.Maroon;
            this.rbcs.Location = new System.Drawing.Point(112, 15);
            this.rbcs.Name = "rbcs";
            this.rbcs.Size = new System.Drawing.Size(47, 16);
            this.rbcs.TabIndex = 62;
            this.rbcs.TabStop = true;
            this.rbcs.Text = "次数";
            this.rbcs.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(90, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 16);
            this.label17.TabIndex = 61;
            this.label17.Text = "次";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(40, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 16);
            this.label10.TabIndex = 60;
            this.label10.Text = "组";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(8, 44);
            this.textBox1.MaxLength = 0;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 26);
            this.textBox1.TabIndex = 58;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 59;
            this.label8.Text = "选定每   医嘱冲正 ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 4;
            this.button1.Location = new System.Drawing.Point(896, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 68);
            this.button1.TabIndex = 59;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.bt取消冲正);
            this.groupBox5.Controls.Add(this.lb26);
            this.groupBox5.Controls.Add(this.lb27);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.lb11);
            this.groupBox5.Controls.Add(this.lb10);
            this.groupBox5.Controls.Add(this.lb9);
            this.groupBox5.Controls.Add(this.lb8);
            this.groupBox5.Controls.Add(this.lb7);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Location = new System.Drawing.Point(4, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1012, 40);
            this.groupBox5.TabIndex = 60;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "医嘱开始信息";
            // 
            // bt取消冲正
            // 
            this.bt取消冲正.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt取消冲正.Enabled = false;
            this.bt取消冲正.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt取消冲正.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt取消冲正.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt取消冲正.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt取消冲正.ImageIndex = 4;
            this.bt取消冲正.Location = new System.Drawing.Point(852, 0);
            this.bt取消冲正.Name = "bt取消冲正";
            this.bt取消冲正.Size = new System.Drawing.Size(66, 38);
            this.bt取消冲正.TabIndex = 89;
            this.bt取消冲正.Text = "取消冲正(&Q)";
            this.bt取消冲正.Visible = false;
            this.bt取消冲正.Click += new System.EventHandler(this.bt取消冲正_Click);
            // 
            // lb26
            // 
            this.lb26.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb26.Location = new System.Drawing.Point(720, 20);
            this.lb26.Name = "lb26";
            this.lb26.Size = new System.Drawing.Size(62, 16);
            this.lb26.TabIndex = 49;
            // 
            // lb27
            // 
            this.lb27.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb27.Location = new System.Drawing.Point(784, 20);
            this.lb27.Name = "lb27";
            this.lb27.Size = new System.Drawing.Size(124, 16);
            this.lb27.TabIndex = 48;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(612, 20);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(104, 16);
            this.label26.TabIndex = 46;
            this.label26.Text = "核对护士与时间：";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb11
            // 
            this.lb11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb11.Location = new System.Drawing.Point(960, 20);
            this.lb11.Name = "lb11";
            this.lb11.Size = new System.Drawing.Size(44, 16);
            this.lb11.TabIndex = 44;
            // 
            // lb10
            // 
            this.lb10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb10.Location = new System.Drawing.Point(420, 20);
            this.lb10.Name = "lb10";
            this.lb10.Size = new System.Drawing.Size(62, 16);
            this.lb10.TabIndex = 43;
            // 
            // lb9
            // 
            this.lb9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb9.Location = new System.Drawing.Point(488, 20);
            this.lb9.Name = "lb9";
            this.lb9.Size = new System.Drawing.Size(124, 16);
            this.lb9.TabIndex = 42;
            // 
            // lb8
            // 
            this.lb8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb8.Location = new System.Drawing.Point(258, 20);
            this.lb8.Name = "lb8";
            this.lb8.Size = new System.Drawing.Size(56, 16);
            this.lb8.TabIndex = 41;
            // 
            // lb7
            // 
            this.lb7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb7.Location = new System.Drawing.Point(74, 20);
            this.lb7.Name = "lb7";
            this.lb7.Size = new System.Drawing.Size(124, 16);
            this.lb7.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "开始时间：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(182, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "下嘱医生：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(316, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "转抄护士与时间：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(912, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 16);
            this.label23.TabIndex = 39;
            this.label23.Text = "首次：";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.btnZdb);
            this.groupBox6.Controls.Add(this.lb28);
            this.groupBox6.Controls.Add(this.lb29);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.lb16);
            this.groupBox6.Controls.Add(this.lb15);
            this.groupBox6.Controls.Add(this.lb14);
            this.groupBox6.Controls.Add(this.lb13);
            this.groupBox6.Controls.Add(this.lb12);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(4, 132);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1012, 40);
            this.groupBox6.TabIndex = 61;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "医嘱停止信息";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 4;
            this.button3.Location = new System.Drawing.Point(867, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 38);
            this.button3.TabIndex = 91;
            this.button3.Text = "取消打包(&R)";
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnZdb
            // 
            this.btnZdb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZdb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZdb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZdb.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnZdb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZdb.ImageIndex = 4;
            this.btnZdb.Location = new System.Drawing.Point(814, 2);
            this.btnZdb.Name = "btnZdb";
            this.btnZdb.Size = new System.Drawing.Size(51, 38);
            this.btnZdb.TabIndex = 90;
            this.btnZdb.Text = "转打包(&P)";
            this.btnZdb.Click += new System.EventHandler(this.btnZdb_Click);
            // 
            // lb28
            // 
            this.lb28.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb28.Location = new System.Drawing.Point(720, 20);
            this.lb28.Name = "lb28";
            this.lb28.Size = new System.Drawing.Size(62, 16);
            this.lb28.TabIndex = 52;
            // 
            // lb29
            // 
            this.lb29.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb29.Location = new System.Drawing.Point(784, 20);
            this.lb29.Name = "lb29";
            this.lb29.Size = new System.Drawing.Size(124, 16);
            this.lb29.TabIndex = 51;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(612, 20);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(104, 16);
            this.label27.TabIndex = 50;
            this.label27.Text = "核对护士与时间：";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb16
            // 
            this.lb16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb16.Location = new System.Drawing.Point(960, 20);
            this.lb16.Name = "lb16";
            this.lb16.Size = new System.Drawing.Size(44, 16);
            this.lb16.TabIndex = 49;
            // 
            // lb15
            // 
            this.lb15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb15.Location = new System.Drawing.Point(420, 20);
            this.lb15.Name = "lb15";
            this.lb15.Size = new System.Drawing.Size(62, 16);
            this.lb15.TabIndex = 48;
            // 
            // lb14
            // 
            this.lb14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb14.Location = new System.Drawing.Point(488, 20);
            this.lb14.Name = "lb14";
            this.lb14.Size = new System.Drawing.Size(124, 16);
            this.lb14.TabIndex = 47;
            // 
            // lb13
            // 
            this.lb13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb13.Location = new System.Drawing.Point(258, 20);
            this.lb13.Name = "lb13";
            this.lb13.Size = new System.Drawing.Size(56, 16);
            this.lb13.TabIndex = 46;
            // 
            // lb12
            // 
            this.lb12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb12.Location = new System.Drawing.Point(74, 20);
            this.lb12.Name = "lb12";
            this.lb12.Size = new System.Drawing.Size(124, 16);
            this.lb12.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "停止时间：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(912, 20);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 16);
            this.label24.TabIndex = 44;
            this.label24.Text = "末次：";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(182, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 41;
            this.label7.Text = "停嘱医生：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(310, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 16);
            this.label11.TabIndex = 43;
            this.label11.Text = "转抄护士与时间：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 732);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1008, 8);
            this.progressBar1.TabIndex = 87;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cb显示已删除费用);
            this.panel1.Controls.Add(this.rb每条医嘱);
            this.panel1.Controls.Add(this.rb每组医嘱);
            this.panel1.Controls.Add(this.bt反选);
            this.panel1.Controls.Add(this.bt全选);
            this.panel1.Controls.Add(this.myDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 518);
            this.panel1.TabIndex = 88;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(899, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 93;
            this.button2.Text = "取消负药品费用";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cb显示已删除费用
            // 
            this.cb显示已删除费用.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cb显示已删除费用.Checked = true;
            this.cb显示已删除费用.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb显示已删除费用.Location = new System.Drawing.Point(464, 4);
            this.cb显示已删除费用.Name = "cb显示已删除费用";
            this.cb显示已删除费用.Size = new System.Drawing.Size(112, 16);
            this.cb显示已删除费用.TabIndex = 92;
            this.cb显示已删除费用.Text = "显示已删除费用";
            this.cb显示已删除费用.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cb显示已删除费用.UseVisualStyleBackColor = false;
            this.cb显示已删除费用.CheckedChanged += new System.EventHandler(this.cb显示已删除费用_CheckedChanged);
            // 
            // rb每条医嘱
            // 
            this.rb每条医嘱.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb每条医嘱.Enabled = false;
            this.rb每条医嘱.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb每条医嘱.Location = new System.Drawing.Point(660, 3);
            this.rb每条医嘱.Name = "rb每条医嘱";
            this.rb每条医嘱.Size = new System.Drawing.Size(72, 18);
            this.rb每条医嘱.TabIndex = 91;
            this.rb每条医嘱.Text = "每条医嘱";
            this.rb每条医嘱.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rb每条医嘱.UseVisualStyleBackColor = false;
            this.rb每条医嘱.Click += new System.EventHandler(this.rb每条医嘱_Click);
            // 
            // rb每组医嘱
            // 
            this.rb每组医嘱.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb每组医嘱.Checked = true;
            this.rb每组医嘱.Enabled = false;
            this.rb每组医嘱.Location = new System.Drawing.Point(580, 3);
            this.rb每组医嘱.Name = "rb每组医嘱";
            this.rb每组医嘱.Size = new System.Drawing.Size(72, 18);
            this.rb每组医嘱.TabIndex = 90;
            this.rb每组医嘱.TabStop = true;
            this.rb每组医嘱.Text = "每组医嘱";
            this.rb每组医嘱.UseVisualStyleBackColor = false;
            this.rb每组医嘱.Click += new System.EventHandler(this.rb每组医嘱_Click);
            // 
            // bt反选
            // 
            this.bt反选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt反选.Enabled = false;
            this.bt反选.Location = new System.Drawing.Point(828, 1);
            this.bt反选.Name = "bt反选";
            this.bt反选.Size = new System.Drawing.Size(56, 20);
            this.bt反选.TabIndex = 89;
            this.bt反选.Text = "反选(&F)";
            this.bt反选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt反选.UseVisualStyleBackColor = false;
            this.bt反选.Click += new System.EventHandler(this.bt反选_Click);
            // 
            // bt全选
            // 
            this.bt全选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt全选.Enabled = false;
            this.bt全选.Location = new System.Drawing.Point(756, 1);
            this.bt全选.Name = "bt全选";
            this.bt全选.Size = new System.Drawing.Size(56, 20);
            this.bt全选.TabIndex = 88;
            this.bt全选.Text = "全选(&A)";
            this.bt全选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt全选.UseVisualStyleBackColor = false;
            this.bt全选.Click += new System.EventHandler(this.bt全选_Click);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "费用明细";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Enabled = false;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(1004, 518);
            this.myDataGrid1.TabIndex = 87;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.toolTip1.SetToolTip(this.myDataGrid1, "灰色     =   费用被删除 \n黑色     =   未记账  未完成  未冲账 \n黑红色 =   未记账  未完成    冲账  \n浅蓝色 =   已记账 " +
                    " 未完成  未冲账  \n浅红色 =   已记账  未完成    冲账  \n蓝色     =   已记账  已完成  未冲账  \n红色     =   已记账  " +
                    "已完成    冲账  \n绿色     =   已结算  \n");
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridEx1
            // 
            this.dataGridEx1.AllowSorting = false;
            this.dataGridEx1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridEx1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridEx1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridEx1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridEx1.CaptionText = "费用汇总";
            this.dataGridEx1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridEx1.DataMember = "";
            this.dataGridEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEx1.Enabled = false;
            this.dataGridEx1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridEx1.Name = "dataGridEx1";
            this.dataGridEx1.ReadOnly = true;
            this.dataGridEx1.Size = new System.Drawing.Size(1004, 518);
            this.dataGridEx1.TabIndex = 88;
            this.dataGridEx1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dataGridEx1;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 100000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 178);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 544);
            this.tabControl1.TabIndex = 90;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1004, 518);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "费用明细";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1004, 518);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "费用汇总";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbUncharge);
            this.panel2.Controls.Add(this.rbCharge);
            this.panel2.Controls.Add(this.rbAll);
            this.panel2.Controls.Add(this.dataGridEx1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 518);
            this.panel2.TabIndex = 0;
            // 
            // rbUncharge
            // 
            this.rbUncharge.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbUncharge.Location = new System.Drawing.Point(672, 3);
            this.rbUncharge.Name = "rbUncharge";
            this.rbUncharge.Size = new System.Drawing.Size(72, 18);
            this.rbUncharge.TabIndex = 93;
            this.rbUncharge.Text = "未记帐";
            this.rbUncharge.UseVisualStyleBackColor = false;
            this.rbUncharge.Click += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // rbCharge
            // 
            this.rbCharge.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbCharge.Location = new System.Drawing.Point(592, 3);
            this.rbCharge.Name = "rbCharge";
            this.rbCharge.Size = new System.Drawing.Size(72, 18);
            this.rbCharge.TabIndex = 92;
            this.rbCharge.Text = "已记帐";
            this.rbCharge.UseVisualStyleBackColor = false;
            this.rbCharge.Click += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // rbAll
            // 
            this.rbAll.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(522, 3);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(72, 18);
            this.rbAll.TabIndex = 91;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部";
            this.rbAll.UseVisualStyleBackColor = false;
            this.rbAll.Click += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(149, 176);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 18);
            this.label28.TabIndex = 91;
            this.label28.Text = "自付比例：";
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblZfbl
            // 
            this.lblZfbl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZfbl.ForeColor = System.Drawing.Color.Red;
            this.lblZfbl.Location = new System.Drawing.Point(252, 176);
            this.lblZfbl.Name = "lblZfbl";
            this.lblZfbl.Size = new System.Drawing.Size(150, 18);
            this.lblZfbl.TabIndex = 92;
            // 
            // toolTip2
            // 
            this.toolTip2.AutoPopDelay = 100000;
            this.toolTip2.InitialDelay = 500;
            this.toolTip2.ReshowDelay = 100;
            // 
            // lblUnEnableCz
            // 
            this.lblUnEnableCz.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUnEnableCz.Location = new System.Drawing.Point(426, 175);
            this.lblUnEnableCz.Name = "lblUnEnableCz";
            this.lblUnEnableCz.Size = new System.Drawing.Size(578, 23);
            this.lblUnEnableCz.TabIndex = 93;
            // 
            // frmYZXX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1016, 725);
            this.Controls.Add(this.lblUnEnableCz);
            this.Controls.Add(this.lblZfbl);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.bt冲正);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.bt退出);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Name = "frmYZXX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详细信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZXX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmYZXX_Load(object sender, System.EventArgs e)
        {
            //参数关闭或者长期医嘱，账单就不能冲数量
            if (cfg7214.Config.Trim() != "1" ||
                (this.MNGType == 0 || this.MNGType == 2)
                )
            {
                this.rbsl.Visible = false;
                this.rbcs.Visible = false;
            }
            else
            {
                this.rbsl.Visible = true;
                this.rbcs.Visible = true;
            }
            if (cfg7211.Config.Trim() == "1")
                this.button2.Visible = true;
            if (FrmMdiMain.CurrentUser.IsAdministrator
                || (myFunc.IsHSZ(FrmMdiMain.CurrentUser.EmployeeId) && new SystemCfg(7082).Config == "1"))//Modify By Tany 2010-12-28 7082是否允许护士长取消冲正 0=不是 1=是
            {
                bt取消冲正.Visible = true;
            }
            else
            {
                bt取消冲正.Visible = false;
            }
            //7090是否允许冲正费用 0=不是 1=是 Add By tany 2011-06-17
            if (new SystemCfg(7090).Config == "0")
            {
                isUNCZ = true;
            }
            //7092是否允许冲正药品费用 0=不是 1=是 Add By tany 2011-06-20
            else if ((nType == 1 || nType == 2 || nType == 3) && new SystemCfg(7092).Config == "0")
            {
                isUNCZ = true;
            }
            //7093是否允许冲正项目费用 0=不是 1=是 Add By tany 2011-06-20
            else if (nType != 1 && nType != 2 && nType != 3 && new SystemCfg(7093).Config == "0")
            {
                isUNCZ = true;
            }
            Cursor.Current = PubStaticFun.WaitCursor();

            //显示基本信息
            string sSql = @"SELECT     
						CASE A.MNGTYPE WHEN 0 THEN '长期医嘱' 
						WHEN 1 THEN '临时医嘱' WHEN 5 THEN '临时医嘱' 
						WHEN 2 THEN '长期账单' ELSE '临时账单' END AS MNGTYPE,    
						CASE A.STATUS_FLAG WHEN 1 THEN '未转抄' 
						WHEN 2 THEN '已转抄' WHEN 3 THEN '未停止转抄' 
						WHEN 4 THEN '已停止转抄' WHEN 5 THEN '已完成' END STATUS_FLAG,    
						A.ORDER_ID,    A.BOOK_DATE,    b.name AS OPER_DEPT, 
						c.name AS OPER_NAME,     A.ORDER_BDATE,  
						d.name  AS BDOC_NAME, A.AUDITING_DATE,    
						e.name AS AUDIT_NAME, A.AUDITING_DATE1, 
						f.name AS AUDIT_NAME1,A.FIRST_TIMES,    
						A.ORDER_EDATE,  g.name AS EDOC_NAME, 
						A.ORDER_EUDATE,     h.name  AS EUSER_NAME, 
						A.ORDER_EUDATE1,i.name AS EUSER_NAME1,A.TERMINAL_TIMES,    
						A.ORDER_CONTEXT, k.name  AS EXEC_DEPT, J.EXEC_NUM,    
						A.NUM,A.UNIT,A.DOSAGE,A.FREQUENCY,ltrim(rtrim(A.ORDER_USAGE)) ";
            if (nType == 3)
            {
                sSql += @" + case when zd.order_id is not null then '[代煎]' else '[自煎]' end ";
            }
            //Modify By Tany 2014-12-30 增加zfbl显示
            sSql += @"as ORDER_USAGE,A.DROPSPER,A.HOITEM_ID,(isnull(a.zfbl,1)*100) zfbl FROM ZY_ORDERRECORD A  
						left join jc_dept_property b on a.dept_id=b.dept_id
						left join jc_employee_property c on a.OPERATOR=c.employee_id
						left join jc_employee_property d on a.ORDER_DOC=d.employee_id
						left join jc_employee_property e on a.AUDITING_USER=e.employee_id
						left join jc_employee_property f on a.AUDITING_USER1=f.employee_id
						left join jc_employee_property g on a.ORDER_EDOC=g.employee_id
						left join jc_employee_property h on a.ORDER_EUSER=h.employee_id
						left join jc_employee_property i on a.ORDER_EUSER1=i.employee_id
						left join jc_dept_property k on a.EXEC_DEPT=k.dept_id";

            if (this.nType != 3)
            {
                sSql += " , (SELECT COUNT(*) AS EXEC_NUM FROM ZY_ORDEREXEC WHERE isanalyzed<>0 and ORDER_ID='" + this.OrderID + "' ) J  WHERE A.ORDER_ID='" + this.OrderID + "'";
            }
            else
            {
                //中草药
                sSql += " left join (SELECT order_id,COUNT(order_id) AS EXEC_NUM FROM ZY_ORDEREXEC WHERE isanalyzed<>0 and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " group by order_id) J on A.Order_ID=j.Order_ID " +
                    "   left join zy_decoct zd on a.inpatient_id=zd.inpatient_id and a.group_id=zd.group_id " +
                    "   where a.delete_bit=0 and a.group_id=" + this.Group_ID + " and a.ntype=3" +
                    "         and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID;
            }

            DataTable myTempTb = FrmMdiMain.Database.GetDataTable(sSql);
            if (myTempTb.Rows.Count == 0) return;

            this.lb1.Text = myTempTb.Rows[0]["MNGTYPE"].ToString().Trim() + "(" + myTempTb.Rows[0]["STATUS_FLAG"].ToString().Trim() + ")";
            if (this.nType != 3)
            {
                this.lb17.Text = myTempTb.Rows[0]["ORDER_CONTEXT"].ToString().Trim();
            }
            else
            {
                this.lb17.Text = "中草药处方(" + myTempTb.Rows[0]["ORDER_CONTEXT"].ToString().Trim() + "等)";
            }
            this.lb4.Text = myTempTb.Rows[0]["BOOK_DATE"].ToString().Trim();
            this.lb5.Text = myTempTb.Rows[0]["OPER_DEPT"].ToString().Trim();
            this.lb6.Text = myTempTb.Rows[0]["OPER_NAME"].ToString().Trim();
            this.lb7.Text = myTempTb.Rows[0]["ORDER_BDATE"].ToString().Trim();
            this.lb8.Text = myTempTb.Rows[0]["BDOC_NAME"].ToString().Trim();
            this.lb9.Text = myTempTb.Rows[0]["AUDITING_DATE"].ToString().Trim();
            this.lb10.Text = myTempTb.Rows[0]["AUDIT_NAME"].ToString().Trim();
            this.lb27.Text = myTempTb.Rows[0]["AUDITING_DATE1"].ToString().Trim();
            this.lb26.Text = myTempTb.Rows[0]["AUDIT_NAME1"].ToString().Trim();
            this.lb11.Text = myTempTb.Rows[0]["FIRST_TIMES"].ToString().Trim();
            this.lb18.Text = myTempTb.Rows[0]["EXEC_DEPT"].ToString().Trim();
            this.lb19.Text = myTempTb.Rows[0]["EXEC_NUM"].ToString().Trim();
            this.lb20.Text = myTempTb.Rows[0]["NUM"].ToString().Trim();
            this.lb21.Text = myTempTb.Rows[0]["UNIT"].ToString().Trim();
            this.lb22.Text = myTempTb.Rows[0]["DOSAGE"].ToString().Trim();
            this.lb23.Text = myTempTb.Rows[0]["FREQUENCY"].ToString().Trim();
            this.lb24.Text = myTempTb.Rows[0]["ORDER_USAGE"].ToString().Trim();
            this.lb25.Text = myTempTb.Rows[0]["DROPSPER"].ToString().Trim();
            this.lbLX.Text = GetOrderTypeName(nType);

            //Add By Tany 2014-12-30
            int zfbl = Convert.ToInt32(myTempTb.Rows[0]["zfbl"]);
            this.lblZfbl.Text = zfbl + "%";
            if (zfbl == 0)
            {
                label28.ForeColor = Color.Green;
                lblZfbl.ForeColor = Color.Green;
            }
            else if (zfbl == 100)
            {
                label28.ForeColor = Color.Red;
                lblZfbl.ForeColor = Color.Red;
            }
            else
            {
                label28.ForeColor = Color.Blue;
                lblZfbl.ForeColor = Color.Blue;
            }

            if (this.MNGType == 0 || this.MNGType == 2)
            {
                this.groupBox6.Enabled = true;
                this.lb12.Text = myTempTb.Rows[0]["ORDER_EDATE"].ToString().Trim();
                this.lb13.Text = myTempTb.Rows[0]["EDOC_NAME"].ToString().Trim();
                this.lb14.Text = myTempTb.Rows[0]["ORDER_EUDATE"].ToString().Trim();
                this.lb15.Text = myTempTb.Rows[0]["EUSER_NAME"].ToString().Trim();
                this.lb28.Text = myTempTb.Rows[0]["ORDER_EUDATE1"].ToString().Trim();
                this.lb29.Text = myTempTb.Rows[0]["EUSER_NAME1"].ToString().Trim();
                this.lb16.Text = myTempTb.Rows[0]["TERMINAL_TIMES"].ToString().Trim();
            }

            if (this.lb19.Text.ToString().Trim() != "" && this.lb19.Text.ToString().Trim() != "0")
            {
                this.groupBox4.Enabled = true;
                this.bt冲正.Enabled = true;
                this.bt取消冲正.Enabled = true;
                this.rb每条医嘱.Enabled = true;
                this.rb每组医嘱.Enabled = true;
                this.bt全选.Enabled = true;
                this.bt反选.Enabled = true;
                this.myDataGrid1.Enabled = true;

                this.ShowData();

                this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
                string[] GrdMappingName ={"选", "医嘱日期","频次","内容","规格","数量","单位","次数","剂数","单价","金额",
										 "发送信息","执行科室","记账信息","发药信息","记账类型","charge_bit", "finish_bit","delete_bit",
                                         "Order_ID","ID","EXECDEPT_ID","dept_br","dept_id","item_code","day1","day2","发送护士","记账员",
                                         "基数药","isJZ","jz_flag","DISCHARGE_BIT","名称","iskdksly","xmly",//36
                                         "发药单号",
                    "药品批次","药品批号",
                    "发药时间","发药人","领药科室","领药类型","操作人","操作时间","type","statitem_code","转打包","PRESCRIPTION_ID"
                    //,"zfbl"
                };//名称是给汇总用的//Add By Tany 2010-12-15 增加statitem_code
                int[] GrdWidth ={ 2, 10, 4, 24, 10, 6, 6, 4, 4, 8, 8, 12, 10, 12, 12, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8,
                    8,8
                    ,15, 8, 10, 8, 8, 15, 0, 0, 6 , 0};
                int[] Alignment ={ 0, 0, 0, 0, 0, 2, 1, 2, 2, 2, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2,
                    2,2
                    ,0, 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.InitGridYZ(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);
                PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);//去掉网格

                this.dataGridEx1.TableStyles[0].GridColumnStyles.Clear();
                string[] GrdMappingName1 ={ "名称", "规格", "数量", "单位", "单价", "金额" };
                int[] GrdWidth1 ={ 40, 16, 12, 6, 16, 16 };
                int[] Alignment1 ={ 0, 0, 2, 1, 2, 2, 2 };
                int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0 };
                myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.dataGridEx1);
                PubStaticFun.ModifyDataGridStyle(dataGridEx1, 0);
            }
            this.Text = this.sTitle;
            //add by zouchihua 2013-9-11 如果是不是药品，那么就不允许冲正
            if (this.zczyz_notfy && !(nType == 1 || nType == 2 || nType == 3))
                isUNCZ = true;
            if (isCX || isUNCZ)
            {
                this.groupBox4.Enabled = false;
                this.textBox1.Enabled = false;
                this.bt冲正.Enabled = false;
                this.bt取消冲正.Enabled = false;
                this.rb每条医嘱.Enabled = false;
                this.rb每组医嘱.Enabled = false;
                this.bt全选.Enabled = false;
                this.bt反选.Enabled = false;
                //				this.myDataGrid1.Enabled=false;
            }
            //不能取消冲正 add by zouchihua
            if (zczyz_notfy)
                this.bt取消冲正.Enabled = false;
            //口服药统领分类代码
            tlfl = (new SystemCfg(7048)).Config.Trim();
            //拆零口服药是否允许退费
            //7054参数改为可以填写病人住院号，来单独开启是否允许冲减 Modify By Tany 2015-06-04
            string cfg7054 = (new SystemCfg(7054)).Config.Trim();
            //_isclkfyty = (new SystemCfg(7054)).Config.Trim() == "0" ? false : true;

            string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from ZY_INPATIENT where INPATIENT_ID ='{0}' ", ClassStatic.Current_BinID.ToString());

            DataTable dtInp = InstanceForm.BDatabase.GetDataTable(ssql);

            if (dtInp == null || dtInp.Rows.Count <= 0)
                throw new Exception("未找到该住院号的病人信息\r");

            _xzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
            _yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
            _inpatientNo = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
            if (cfg7054 == "1" || cfg7054.Contains(Convert.ToInt64(_inpatientNo).ToString()))
            {
                _isclkfyty = true;
            }
            else
            {
                _isclkfyty = false;
            }

            Cursor.Current = Cursors.Default;
        }

        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            //myDataGrid.TableStyles[0].AllowSorting=false; //不允许排序

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                    //myBoolCol.tool
                    //this.toolTip2
                    //myBoolCol.too
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //用色彩区分医嘱的状态 
            int ChargeCol = 16;	 //charge_bit列

            //删除标志
            if (Convert.ToInt16(this.myDataGrid1[e.Row, ChargeCol + 2]) == 1)
            {
                e.ForeColor = Color.Gray;  //灰色
                e.BackColor = Color.White;
                return;
            }

            int iCZ = this.myDataGrid1[e.Row, ChargeCol - 1].ToString().Trim() == "冲帐费用" ? 1 : 0; //1代表冲账
            int iCharge = Convert.ToInt16(this.myDataGrid1[e.Row, ChargeCol]);			//1代表已记账
            int iFinish = Convert.ToInt16(this.myDataGrid1[e.Row, ChargeCol + 1]) == 1 ? 1 : 0;	//1代表已完成（已发药） (2是非基数药冲正时还没产生药品消息的中间过度标志)
            int iDisCharge = Convert.ToInt16(this.myDataGrid1[e.Row, 31]);			//1代表已结算


            if (iCharge == 0 && iFinish == 0 && iCZ == 0) e.ForeColor = Color.Black;		//未记账  未完成  未冲账  黑
            if (iCharge == 0 && iFinish == 0 && iCZ == 1) e.ForeColor = Color.DarkRed;	//未记账  未完成    冲账  黑红			}
            if (iCharge == 1 && iFinish == 0 && iCZ == 0) e.ForeColor = Color.RoyalBlue;  //已记账  未完成  未冲账  浅蓝
            if (iCharge == 1 && iFinish == 0 && iCZ == 1) e.ForeColor = Color.LightCoral; //已记账  未完成    冲账  浅红
            if (iCharge == 1 && iFinish == 1 && iCZ == 0) e.ForeColor = Color.Blue;		//已记账  已完成  未冲账  蓝
            if (iCharge == 1 && iFinish == 1 && iCZ == 1) e.ForeColor = Color.Red;		//已记账  已完成    冲账  红

            if (iDisCharge == 1) e.ForeColor = Color.Green; //已经结算

            if (this.myDataGrid1[e.Row, 0].ToString() == "True")
                e.BackColor = Color.GreenYellow;
            else
                e.BackColor = Color.White;
        }


        private void ShowData()
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            # region 屏蔽 2009-06-08 Tany
            //string tmpSql = "";
            //if (cb显示已删除费用.Checked == false)
            //{
            //    tmpSql = " and a.delete_bit=0 ";
            //}

            ////药品和诊疗项目分开取数据，药品的内容取医嘱表，诊疗项目的内容取收费项目表
            ////Modify By Tany at 2004-10-08 加入mngtype=5的判断
            ////Modify By Tany at 2004-10-31 重新优化写SQL语句
            ////Modify By Tany at 2005-05-20 加入医嘱表jz_flag字段，如果jz_flag=1的话表示直接计费，可以直接冲费
            //string sSql = "  SELECT DBO.FUN_GETDATE(EXECDATE) 医嘱日期, " +
            //            "  ltrim(rtrim(内容)) + case when a.tlfs=1 then  '【缺药】' else '' end + case when a.delete_bit=1 then  '【已删除】' else '' end + case when c2 is not null then ltrim(rtrim(c2)) else '' end as 内容,规格, " +
            //            "         case when a.cz_flag in (2,3) then a.num else a.NUM/a.isanalyzed end  数量,a.UNIT 单位," +
            //            "         case when a.cz_flag in (2,3) then 1 else a.isanalyzed end 次数,a.DOSAGE 剂数,a.RETAIL_PRICE 单价,a.ACVALUE 金额, " +
            //            "         convert(varchar,datepart(mm,a.BOOK_DATE)) 发送信息,b.name 执行科室, " +
            //            "         convert(varchar,datepart(mm,a.charge_date)) 记账信息,dbo.FUN_ZY_SEEKFeeTypeName(a.cz_flag) 记账类型, " +
            //            "         a.charge_bit,a.finish_bit,a.delete_bit,a.Order_ID,ID,a.EXECDEPT_ID,a.dept_br,a.dept_id,a.item_code , " +
            //            "         convert(varchar,datepart(dd,a.BOOK_DATE)) day1,convert(varchar,datepart(dd,a.charge_date)) day2 ," +
            //            "         c.name 发送护士,d.name 记账员,a.isJSY 基数药,b.isJZ,a.jz_flag,a.DISCHARGE_BIT,ltrim(rtrim(内容)) as 名称," +
            //            "         convert(varchar,datepart(mm,a.fy_date)) 发药信息,convert(varchar,datepart(dd,a.fy_date)) day3,e.name 发药员,fy_bit" +
            //            "   FROM (SELECT C.EXECDATE,E.ITEM_NAME 内容, E.ITEM_DESCRIBE 规格,           " +
            //            "                A.NUM,A.UNIT,C.isanalyzed ,A.DOSAGE,A.RETAIL_PRICE,A.ACVALUE,            " +
            //            "                C.EXEUSER,C.BOOK_DATE,A.EXECDEPT_ID,A.charge_user,A.charge_date,cz_flag," +
            //            "                D.Order_ID,A.ID,A.charge_bit,A.finish_bit,D.BOOK_DATE BOOK_DATE1,a.type,d.dept_br,d.dept_id,'' item_code,0 isJSY,a.delete_bit,D.jz_flag,A.DISCHARGE_BIT,a.c2,a.tlfs,fy_bit,fy_user,fy_date " +    //费用没有item_code
            //            "         FROM (select a.ID, prescription_id,orderexec_id, HSITEM_ID, NUM, UNIT, DOSAGE, RETAIL_PRICE,ACVALUE, EXECDEPT_ID, " +
            //            "         charge_user, charge_date, cz_flag, charge_bit,finish_bit, delete_bit,DISCHARGE_BIT,type,c2,tlfs,fy_bit,fy_user,fy_date from ZY_FEE_SPECI a inner join jc_stat_item c on a.statitem_code=c.code " +
            //            "         where c.itemtype<>1 AND inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + ") A ," +
            //            "         jc_HSITEMDICTION E , ZY_ORDEREXEC C ," +
            //            "         (select Order_ID, BOOK_DATE, dept_br,dept_id, item_code,jz_flag from ZY_ORDERRECORD where group_id=" + this.Group_ID + " and (mngtype=" + this.MNGType + " or mngtype=" + this.MNGType2 + ")" +
            //            "         and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + ") D " +
            //            "         WHERE a.orderexec_id=c.id and c.Order_ID=D.Order_ID  and A.HSITEM_ID=E.ITEM_ID  " + tmpSql + " and a.jgbm=e.jgbm " +
            //            "         union all " +
            //            "         SELECT C.EXECDATE,D.ORDER_CONTEXT, D.ORDER_SPEC ,   " +
            //            "                A.NUM,A.UNIT,C.isanalyzed ,A.DOSAGE,A.RETAIL_PRICE,A.ACVALUE,   " +
            //            "                C.EXEUSER,C.BOOK_DATE,A.EXECDEPT_ID,A.charge_user,A.charge_date,cz_flag," +
            //            "                D.Order_ID,A.ID,A.charge_bit,A.finish_bit,D.BOOK_DATE  ,a.type ,d.dept_br,d.dept_id,d.item_code, " +
            //            "                a.isJSY,a.delete_bit,D.jz_flag,A.DISCHARGE_BIT,a.c2,a.tlfs,fy_bit,fy_user,fy_date " +
            //            "         FROM (select a.ID, prescription_id,orderexec_id, HSITEM_ID, NUM, UNIT, DOSAGE, RETAIL_PRICE,ACVALUE, EXECDEPT_ID, " +
            //            "               charge_user, charge_date, cz_flag, charge_bit,finish_bit, delete_bit,DISCHARGE_BIT,type,c2,case when k.cjid is null then 0 else 1 end isJSY,tlfs,fy_bit,fy_user,fy_date from ZY_FEE_SPECI a " +
            //            "               inner join jc_stat_item c on a.statitem_code=c.code " +
            //            "               left join YF_KCMX k on a.cjid=k.cjid and a.execdept_id=k.deptid and k.bdelete=0 and k.deptid=" + InstanceForm.BCurrentDept.WardDeptId +
            //            "         where c.itemtype=1 AND inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + ") A ," +
            //            "         ZY_ORDEREXEC C ," +
            //            "        (select Order_ID,ORDER_CONTEXT,ORDER_SPEC, BOOK_DATE, dept_br,dept_id, item_code,jz_flag from ZY_ORDERRECORD where group_id=" + this.Group_ID +
            //            "         and (mngtype=" + this.MNGType + " or mngtype=" + this.MNGType2 + ")" +
            //            "         and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + ") D " +
            //            "         WHERE a.orderexec_id=c.id and c.Order_ID=D.Order_ID " + tmpSql + " ) a " +
            //            "   left join jc_dept_property b on a.EXECDEPT_ID=b.dept_id " +
            //            "   left join jc_employee_property c on a.EXEUSER=c.employee_id " +
            //            "   left join jc_employee_property d on a.charge_user=d.employee_id " +
            //            "   left join jc_employee_property e on a.fy_user=e.employee_id " +
            //            "   ORDER BY EXECDATE,type,BOOK_DATE1,cz_flag";
            #endregion

            int _deletebit = -1;
            if (cb显示已删除费用.Checked == false)
            {
                _deletebit = 0;
            }

            DataTable myTb = myFunc.ZYHS_ORDERS_SELECTFEE(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, Group_ID, FrmMdiMain.CurrentDept.WardDeptId, MNGType, MNGType2, _deletebit);

            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "选";

            col.DefaultValue = false;
            myTb.Columns.Add(col);

            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            if (myTb.Rows.Count != 0)
            {
                for (int i = myTb.Rows.Count - 1; i >= 0; i--)
                {
                    myTb.Rows[i]["数量"] = string.Format("{0:F2}", myTb.Rows[i]["数量"]);
                    if (myTb.Rows[i]["发送信息"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["发送信息"] = myTb.Rows[i]["发送信息"].ToString().Trim() + "-" + myTb.Rows[i]["day1"].ToString().Trim() + " " + myTb.Rows[i]["发送护士"].ToString().Trim();
                    }
                    if (myTb.Rows[i]["记账信息"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["记账信息"] = myTb.Rows[i]["记账信息"].ToString().Trim() + "-" + myTb.Rows[i]["day2"].ToString().Trim() + " " + myTb.Rows[i]["记账员"].ToString().Trim();
                    }
                    if (myTb.Rows[i]["发药信息"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["发药信息"] = myTb.Rows[i]["发药信息"].ToString().Trim() + "-" + myTb.Rows[i]["day3"].ToString().Trim() + " " + myTb.Rows[i]["发药员"].ToString().Trim();
                    }
                }
            }

            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);

            Cursor.Current = Cursors.Default;
        }

        //是否可以冲账
        private bool isEnableCZ(int nrow)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            string sql = "";
            DataTable tb = new DataTable();
            string strShow = "";

            //冲账费用不可冲
            //冲账费用可以被删除，所以可以被选择 Modify by Tany 2005-09-21
            //			if(myTb.Rows[nrow]["记账类型"].ToString()=="冲帐费用" ) 
            //			{
            //				return false;
            //			}

            //删除的费用不能选择
            if (myTb.Rows[nrow]["delete_bit"].ToString().Trim() == "1")
            {
                return false;
            }

            int jz_flag = 0;
            jz_flag = myTb.Rows[nrow]["jz_flag"].ToString().Trim() == "" ? 0 : Convert.ToInt32(myTb.Rows[nrow]["jz_flag"]);

            long DeptId = isSSMZ || isTSZL ? FrmMdiMain.CurrentDept.DeptId : ClassStatic.Current_DeptID;
            if (!zczyz_notfy)//add by zouchihua 2013-9-11 出区病人冲正
            {
                //Add By Tany 2006-01-18 
                //如果是手术麻醉，只能冲自己科室开的
                if ((isSSMZ || isTSZL) && Convert.ToInt64(myTb.Rows[nrow]["dept_id"]) != DeptId)
                {
                    //不是本科室的费用不可冲
                    strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + "不是本科室的费用不可冲";
                    DoOperate(strShow);
                    return false;
                }
                else if (Convert.ToInt64(myTb.Rows[nrow]["dept_id"]) != DeptId) //Add By Tany 2010-07-13 如果不是手术麻醉，那么判断参数7068是否允许冲正其他科室开立的医嘱 0=不是 1=是
                {
                    if (new SystemCfg(7068).Config == "0")
                    {
                        //如果开单科室是本科室，那么可以允许冲正
                        sql = "select * from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "' and dept_id=" + myTb.Rows[nrow]["dept_id"].ToString().Trim();
                        tb = FrmMdiMain.Database.GetDataTable(sql);
                        if (tb == null || tb.Rows.Count == 0)
                        {
                            //add by zouchihua 如果是会诊申请 2012-01-14
                            string hzsql = "select Apply_type  from ZY_ORDERRECORD where Apply_type=4 and order_id='" + myTb.Rows[nrow]["order_id"].ToString() + "'";
                            DataTable tbb = FrmMdiMain.Database.GetDataTable(hzsql);
                            if (tbb == null || tbb.Rows.Count == 0)
                            {

                                strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + "不是本科室的费用不可冲";
                                DoOperate(strShow);
                                return false;
                            }
                        }
                    }
                }
            }

            //是本科室的费用但执行地点不是本科室且不是立即记账的诊疗项目不能冲
            //普通药品都可以冲
            //冲正药品未记账发药可以取消冲
            if (myTb.Rows[nrow]["xmly"].ToString().Trim() == "2" && jz_flag != 1 //jz_flag=1表示直接收费 Modify By Tany 2005-05-20
                && Convert.ToInt64(myTb.Rows[nrow]["EXECDEPT_ID"]) != DeptId
                && Convert.ToInt32(myTb.Rows[nrow]["isJZ"]) != 1
                && nType == 5
                && Convert.ToInt32(myTb.Rows[nrow]["charge_bit"]) != 1 //Modify By Tany 2010-11-22 如果医技项目被确费，可以直接冲正，没有被确费，只能打未执行
                )
            {

                strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + " 非本科室执行且不是立即记账的诊疗项目，不能冲账";
                DoOperate(strShow);
                return false;
            }

            //如果已经结算则不能冲账
            //Add By Tany 2005-05-23
            if (myTb.Rows[nrow]["DISCHARGE_BIT"].ToString().Trim() == "1")
            {
                //MessageBox.Show("该费用已经结算，不能冲账！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + "该费用已经结算，不能冲账";
                DoOperate(strShow);
                return false;
            }
            //			}
            //拆零口服药是否允许冲正
            if (tlfl != "" && !_isclkfyty && tlfl.IndexOf(myTb.Rows[nrow]["tlfl"].ToString().Trim()) >= 0 && Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) > 1)
            {
                try
                {
                    //如果是整数 ，并且恰好是整包装，那么就可以冲掉  add by zouchihua 2014-4-14
                    if (
                        Convert.ToInt32(myTb.Rows[nrow]["数量"]) / Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) > 0
                        &&
                        (
                        System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(Convert.ToInt32(myTb.Rows[nrow]["数量"]) / Convert.ToInt32(myTb.Rows[nrow]["unitrate"])), @"^[+-]?\d+$")
                        &&
                         Convert.ToInt32(myTb.Rows[nrow]["数量"]) % Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) == 0

                        )

                        )
                    {

                    }
                    else
                    {
                        //Modify by jchl  已记账的拆零口服药不允许冲正
                        if (Convert.ToInt32(myTb.Rows[nrow]["charge_bit"]) == 1)
                        {
                            strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + "已记账的拆零口服药，不能冲账";
                            DoOperate(strShow);
                            return false;
                        }
                        //strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + "拆零口服药，不能冲账";
                        //DoOperate(strShow);
                        //return false;
                    }
                }
                catch { return false; }
            }

            if (!isSSMZ && !isTSZL)
            {

                if (zczyz_notfy)
                    return true;
                //如果是本科室开的账单可以删除   add by zouchihua 2013-8-23
                sql = "select * from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "' and dept_id=" + myTb.Rows[nrow]["dept_id"].ToString().Trim();
                DataTable tbtemp = FrmMdiMain.Database.GetDataTable(sql);
                if (cfg7159.Config.Trim() == "1" && lb1.Text.IndexOf("账单") >= 0 && tbtemp.Rows.Count > 0)
                    return true;
                //病人不是本科室的费用不可冲
                //放在最后判断，避免查询过多
                sql = "select * from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "' and dept_id=" + myTb.Rows[nrow]["dept_br"].ToString().Trim();
                tb = FrmMdiMain.Database.GetDataTable(sql);
                if (tb == null || tb.Rows.Count == 0)
                {
                    //如果开单科室是本科室，并且是开单科室领药，那么可以允许冲正
                    sql = "select * from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "' and dept_id=" + myTb.Rows[nrow]["dept_id"].ToString().Trim();
                    tb = FrmMdiMain.Database.GetDataTable(sql);
                    if (tb == null || tb.Rows.Count == 0 || myTb.Rows[nrow]["iskdksly"].ToString().Trim() != "1")
                    {

                        strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + " 非开单科室领药，不能冲账";
                        DoOperate(strShow);
                        return false;
                    }
                }
            }

            try
            {
                string strPvsScan = Convertor.IsNull(myTb.Rows[nrow]["is_PvsScn"], "0");
                if (!CanOrderRecCz(strPvsScan))
                {
                    strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + "  该组静配药品已经配药，不允许冲减或转打包";


                    DoOperate(strShow);

                    //this.toolTip2.InitialDelay = 1000000;
                    //this.toolTip2.Active = false;
                    return false;
                }
            }
            catch
            {
                return false;
            }

            try
            {
                //STATITEM_CODE/PRESCRIPTION_ID【已上传中草药不允许冲正】:Modify by jchl 2015-11-04
                if (myTb.Rows[nrow]["STATITEM_CODE"].ToString().Trim() == "03")
                {
                    string empNo = myTb.Rows[nrow]["PRESCRIPTION_ID"].ToString().Trim();
                    //如果本处方草药已经上传
                    sql = string.Format(@"select count(1) as Num from yf_zcyfy_sc where JSSJH='{0}' and del_bit=0", empNo);
                    int iSc = Convert.ToInt32(FrmMdiMain.Database.GetDataResult(sql).ToString());

                    if (iSc > 0)
                    {
                        strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + "  该组中药处方已经上传至【天济】，不允许冲减";

                        DoOperate(strShow);
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            //测试临时屏蔽
            //Modify By Tany 2015-12-29 增加验证老系统费用是否存在，不存在不允许冲
            TrasenHIS.BLL.Judgeorder jg = new Judgeorder(FrmMdiMain.Database);
            if (Convert.ToInt32(myTb.Rows[nrow]["charge_bit"]) == 1 && !jg.CheckFeeStatus(_inpatientNo, myTb.Rows[nrow]["id"].ToString()))
            {
                strShow = myTb.Rows[nrow]["医嘱日期"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + " 该条费用在老系统可能已经中途结算，不允许冲减";
                DoOperate(strShow);
                return false;
            }


            //Modify by jchl 2016-12-28-----------------------------------------
            //年底大调价,医保病人不允许跨年冲正2016记账费用   
            if (_yblx.Trim().Equals("1"))
            {
                DateTime serDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                int ServerYear = serDate.Year;// PubStaticFun.GetDateFromGuid(PubStaticFun.NewGuid()).Year

                DateTime.TryParse(myTb.Rows[nrow]["BOOK_DATE"].ToString(), out serDate);//已记账的已记账时间   未记账的已当前时间
                DateTime ChargeDate = serDate;
                int ChargeYear = ChargeDate.Year;

                //2017年以后的服务器时间不能冲正2016的记账费用
                if (ServerYear == 2017 && ChargeYear == 2016)
                {
                    strShow = myTb.Rows[nrow]["BOOK_DATE"].ToString() + "  " + myTb.Rows[nrow]["内容"].ToString() + " ：年底大调价,根据医院的统一部署安排，医保病人不允许跨年冲正2016记产生的费用";
                    DoOperate(strShow);
                    return false;
                }
            }

            //所有药品和执行地点是本科室的诊疗项目可以冲
            return true;
        }

        /// <summary>
        /// add by jchl(不允许冲正原因)
        /// </summary>
        /// <param name="strResult"></param>
        private void DoOperate(string strResult)
        {
            lblUnEnableCz.Text = strResult;

            this.toolTip2.Active = true;
            this.toolTip2.InitialDelay = 100;
            this.toolTip2.SetToolTip(lblUnEnableCz, strResult);
            this.toolTip2.Show(strResult, lblUnEnableCz, 1000);

            //this.toolTip2.Active = true;
            //this.toolTip2.InitialDelay = 100;
            //this.toolTip2.Show(strResult, lblUnEnableCz);
            //toolTip2.
        }

        private void myDataGrid1_Click(object sender, System.EventArgs e)
        {
            //控制BOOL列
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            //非"选"字段
            //			if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim()!="选") return;
            if (nrow > myTb.Rows.Count - 1) return;

            //冲帐费用不可选
            if (this.isEnableCZ(nrow) == false)
            {
                myTb.Rows[nrow]["选"] = false; ;
                this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);
                this.myDataGrid1.DataSource = myTb;
                return;
            }

            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;

            //Modify by jchl Pivas冲正改造（每条医嘱当做每组医嘱   每组医嘱加入pivas序号判断）
            bool isPvsDpt = IsPvsDept(myTb.Rows[nrow]["EXECDEPT_ID"].ToString().Trim());
            if (this.rb每组医嘱.Checked || isPvsDpt)
            {
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["医嘱日期"].ToString().Trim() == myTb.Rows[nrow]["医嘱日期"].ToString().Trim()
                        && myTb.Rows[i]["记账类型"].ToString().Trim() == myTb.Rows[nrow]["记账类型"].ToString().Trim()
                        && myTb.Rows[i]["频次"].ToString().Trim() == myTb.Rows[nrow]["频次"].ToString().Trim()
                        && this.isEnableCZ(i) == true)
                    {
                        this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                        myTb.Rows[i]["选"] = isResult;
                        //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                    }
                    //if (isPvsDpt)
                    //{
                    //}
                    //else
                    //{
                    //    if (myTb.Rows[i]["医嘱日期"].ToString().Trim() == myTb.Rows[nrow]["医嘱日期"].ToString().Trim()
                    //        && myTb.Rows[i]["记账类型"].ToString().Trim() == myTb.Rows[nrow]["记账类型"].ToString().Trim()
                    //        && this.isEnableCZ(i) == true)
                    //    {
                    //        this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    //        myTb.Rows[i]["选"] = isResult;
                    //        //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                    //    }
                    //}
                }
            }

            this.myDataGrid1.DataSource = myTb;

        }


        private void rb每组医嘱_Click(object sender, System.EventArgs e)
        {
            this.label10.Text = "组";
        }

        private void rb每条医嘱_Click(object sender, System.EventArgs e)
        {
            this.label10.Text = "条";
        }


        private void bt全选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["记账类型"].ToString() != "冲帐费用" && this.isEnableCZ(i) == true)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = true;
                }
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt反选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["记账类型"].ToString() != "冲帐费用" && this.isEnableCZ(i) == true)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                }
            }
            this.myDataGrid1.DataSource = myTb;
        }


        private void bt冲正_Click(object sender, System.EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show(this, "对不起，请输入冲正次数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            if (Convert.ToDecimal(this.textBox1.Text.Trim()) <= 0)
            {
                MessageBox.Show(this, "对不起，冲正次数必须大于零，请重新输入正确的冲正次数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            if (Convert.ToDecimal(this.textBox1.Text.Trim()) != Convert.ToInt32(Convert.ToDecimal(this.textBox1.Text.Trim())))
            {
                MessageBox.Show(this, "对不起，冲正只能输入正整数，请重新输入正确的冲正次数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }



            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            string sSql = "", sSql1 = "", sSql2 = "";

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count < 1) return;

            if (this.rb每组医嘱.Checked)
            {
                if (MessageBox.Show(this, "确认选择的每组医嘱冲正" + this.textBox1.Text.Trim() + "次吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }
            else
            {
                if (MessageBox.Show(this, "确认选择的每条医嘱冲正" + this.textBox1.Text.Trim() + "次吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
                f1.Close();
            }
            bool isHSZ = myFunc.IsHSZ(FrmMdiMain.CurrentUser.EmployeeId);

            //			if(isSSMZ==false)
            //			{
            //modify by zouchihua 2011-10-28 //手术麻醉和特殊治疗也做护士站参数判断
            if (!isSSMZ && !isTSZL && isHSZ == false)    // 护士长
            {
                //是否只有护士长能够冲正费用 Add By Tany 2007-09-12
                if ((new SystemCfg(7033)).Config == "是")
                {
                    MessageBox.Show("对不起，只有护士长能够冲正费用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if ((new SystemCfg(19005)).Config == "1" && !isHSZ && isSSMZ)
            {
                //是否只有护士长能够冲正费用 Add By Tany 2007-09-12
                MessageBox.Show("对不起，只有护士长能够冲正费用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //			}



            Cursor.Current = PubStaticFun.WaitCursor();

            try
            {
                #region 安全性判断
                //安全性判断放在身份验证后面，以免出现同时操作时间差，重复冲费
                //Modify By Tany 2005-03-26
                int iSelectRows = 0;

                //Modify By Tany 2010-05-04 冲正的价格计算重新设定，先计算单次冲正的四舍五入，然后再乘以冲正次数
                decimal czcs = Convert.ToDecimal(this.textBox1.Text);
                //add by zouchihua 20134-8-21 只有临时医嘱才可以冲正数量，冲正次数为1
                if (rbsl.Checked)
                    czcs = 1;
                //Modify By Tany 2010-12-12
                decimal _bctfje = 0;

                //Modify by Tany 2010-12-21
                //7073是否使用冲正额度管理 0=不是 1=是
                string _cfg7073 = new SystemCfg(7073).Config;
                //7074冲正费用累计额度（超过此额度将进行相关控制，0=不控制）
                string _cfg7074 = new SystemCfg(7074).Config;
                //7075超过冲正额度控制方式 0=仅提示 1=强制控制 2=允许申请，需第三方确认
                string _cfg7075 = new SystemCfg(7075).Config;
                //7076冲正额度管理是否管理药品数据 0=不是 1=是
                string _cfg7076 = new SystemCfg(7076).Config;
                //7077冲正额度管理是否管理医技数据 0=不是 1=是
                string _cfg7077 = new SystemCfg(7077).Config;
                //7078冲正额度管理不控制的统计大项目代码，如有多个大项目代码，请用逗号（,）分隔，留空表示全部控制
                string _cfg7078 = new SystemCfg(7078).Config;
                //7080冲正额度管理是否仅针对病人当前科室（转科后不计算前科的冲账金额） 0=不是 1=是
                string _cfg7080 = new SystemCfg(7080).Config;

                //Add By tany 2015-05-12
                //7805单条费用冲正金额限制（0=不限制 大于0则超过此数额后限制，参数受限于7073、7075）
                string _cfg7805 = new SystemCfg(7805).Config;

                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["选"].ToString() == "True")
                    {
                        if (myTb.Rows[i]["记账类型"].ToString() == "冲帐费用")
                        {
                            MessageBox.Show(this, "对不起，第" + (i + 1) + "行是冲正记录，不能再冲正，请选择非冲正记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myTb.Rows[i]["选"] = false;
                            return;
                        }
                        //Add by zouchihua2011-11-19  增加判断，结算费用不能冲账
                        string czstr = "select *  from zy_fee_speci where delete_bit=0 and DISCHARGE_BIT=1 and id='" + myTb.Rows[i]["ID"].ToString() + "'";
                        DataTable tmtable = FrmMdiMain.Database.GetDataTable(czstr);
                        if (tmtable.Rows.Count > 0)
                        {
                            MessageBox.Show(this, "对不起，第" + (i + 1) + "行是已经结算，不能再冲正，请重新选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myTb.Rows[i]["选"] = false;
                            return;
                        }

                        if (tlfl != "" && !_isclkfyty && tlfl.IndexOf(myTb.Rows[i]["tlfl"].ToString().Trim()) >= 0 && Convert.ToInt32(myTb.Rows[i]["unitrate"]) > 1)
                        {

                            try
                            {
                                //如果是整数 ，并且恰好是整包装，那么就可以冲掉  add by zouchihua 2014-4-14
                                if (
                                    Convert.ToInt32(myTb.Rows[nrow]["数量"]) / Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) > 0
                                    &&
                                    (
                                    System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(Convert.ToInt32(myTb.Rows[nrow]["数量"]) / Convert.ToInt32(myTb.Rows[nrow]["unitrate"])), @"^[+-]?\d+$")
                                    &&
                                     Convert.ToInt32(myTb.Rows[nrow]["数量"]) % Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) == 0

                                    )

                                    )
                                {

                                }
                                else
                                {
                                    //Modify by jchl  已记账的拆零口服药不允许冲正
                                    if (Convert.ToInt32(myTb.Rows[nrow]["charge_bit"]) == 1)
                                    {
                                        MessageBox.Show(this, "对不起，第" + (i + 1) + "行是已记账的拆零的口服药，不能冲正，请重新选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        myTb.Rows[i]["选"] = false;
                                        return;
                                    }
                                    //MessageBox.Show(this, "对不起，第" + (i + 1) + "行是拆零的口服药，不能冲正，请重新选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //myTb.Rows[i]["选"] = false;
                                    //return;
                                }
                            }
                            catch
                            {
                                MessageBox.Show(this, "对不起，第" + (i + 1) + "行是拆零的口服药，不能冲正，请重新选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                myTb.Rows[i]["选"] = false;
                                return;
                            }




                        }
                        decimal num_cz = Convert.ToDecimal(myTb.Rows[i]["数量"]) * czcs;
                        if (this.rbsl.Checked)//add by zouchihua2013-8-21 如果是选择冲正数量
                            num_cz = Convert.ToDecimal(this.textBox1.Text);
                        decimal num_total = Convert.ToDecimal(myTb.Rows[i]["数量"]) * Convert.ToDecimal(myTb.Rows[i]["次数"]);
                        sSql = "select sum(num) as num  from zy_fee_speci where delete_bit=0 and (id='" + myTb.Rows[i]["ID"].ToString() + "' or cz_id='" + myTb.Rows[i]["ID"].ToString() + "')";
                        DataTable myTempTb = FrmMdiMain.Database.GetDataTable(sSql);
                        if (myTempTb.Rows.Count != 0)
                        {
                            if (myTempTb.Rows[0]["num"].ToString() == "")
                            {
                                if (num_cz > num_total)
                                {
                                    MessageBox.Show(this, "对不起，第" + (i + 1) + "行冲正" + (this.rbsl.Checked == false ? "次数" : "数量") + "偏大！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.myDataGrid1.CurrentRowIndex = i;
                                    this.ShowData();
                                    return;
                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(myTempTb.Rows[0]["num"]) == 0)
                                {
                                    MessageBox.Show(this, "对不起，第" + (i + 1) + "行费用已经全部冲正！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.myDataGrid1.CurrentRowIndex = i;
                                    this.ShowData();
                                    return;
                                }
                                if ((Convert.ToDecimal(myTempTb.Rows[0]["num"]) - num_cz) < 0)
                                {
                                    MessageBox.Show(this, "对不起，第" + (i + 1) + "行冲正" + (this.rbsl.Checked == false ? "次数" : "数量") + "偏大！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.myDataGrid1.CurrentRowIndex = i;
                                    this.ShowData();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (myTempTb.Rows[0]["num"].ToString() == "")
                            {
                                if (num_cz > num_total)
                                {
                                    MessageBox.Show(this, "对不起，第" + (i + 1) + "行冲正" + (this.rbsl.Checked == false ? "次数" : "数量") + "偏大！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.myDataGrid1.CurrentRowIndex = i;
                                    this.ShowData();
                                    return;
                                }
                            }
                        }
                        iSelectRows += 1;

                        //Modify By Tany 2010-12-21 根据条件判断该次被控制的费用
                        if (myTb.Rows[i]["内容"].ToString().IndexOf("【系统自动冲正】") >= 0
                            || (myTb.Rows[i]["xmly"].ToString().Trim() == "1" && _cfg7076 == "0")
                            || (nType == 5 && _cfg7077 == "0")
                            || (_cfg7078.IndexOf(myTb.Rows[i]["statitem_code"].ToString().Trim()) >= 0))
                        {
                            _bctfje += 0;//num_cz * Convert.ToDecimal(myTb.Rows[i]["单价"]) * Convert.ToDecimal(myTb.Rows[i]["剂数"]);
                        }
                        else
                        {
                            _bctfje += num_cz * Convert.ToDecimal(myTb.Rows[i]["单价"]) * Convert.ToDecimal(myTb.Rows[i]["剂数"]);
                        }
                    }
                }

                if (iSelectRows == 0)
                {
                    MessageBox.Show(this, "对不起，没有选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                //Modify By Tany 2010-12-12 冲正的额度管理
                //已经冲正的费用总额
                decimal _czfee = 0;
                //是否强制不允许冲正
                bool _isUnjz = false;
                //7073是否使用冲正额度管理 0=不是 1=是
                if (_cfg7073 == "1")
                {
                    #region 累计额度控制
                    //7074冲正费用累计额度（超过此额度将进行相关控制，0=不控制）
                    decimal _czed = Convert.ToDecimal(_cfg7074);
                    if (_czed > 0)
                    {
                        //7075超过冲正额度控制方式 0=仅提示 1=强制控制 2=允许申请，需第三方确认
                        int _kzfs = Convert.ToInt16(_cfg7075);

                        string sql = "";
                        string _tj = "";
                        string _join = "";
                        //7080冲正额度管理是否仅针对病人当前科室（转科后不计算前科的冲账金额） 0=不是 1=是
                        if (_cfg7080 == "1")
                        {
                            if (isSSMZ)
                            {
                                _tj += " and a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + " ";
                            }
                            else
                            {
                                _tj += " and a.dept_br in (select dept_id from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "') and a.dept_id not in (select deptid from ss_dept) ";
                            }
                        }
                        //7076冲正额度管理是否管理药品数据 0=不是 1=是
                        if (_cfg7076 == "0")
                        {
                            _tj += " and a.xmly<>1 ";
                        }
                        //7078冲正额度管理不控制的统计大项目代码，如有多个大项目代码，请用逗号（,）分隔，留空表示全部控制
                        string _tjdx = _cfg7078;
                        if (_tjdx != "")
                        {
                            _tj += " and a.statitem_code not in (" + _tjdx + ") ";
                        }
                        //系统自动冲正不属于判断范畴
                        _tj += " and isnull(a.bz,'')<>'【系统自动冲正】' ";
                        //7077冲正额度管理是否管理医技数据 0=不是 1=是
                        if (_cfg7077 == "0")
                        {
                            _join += " inner join zy_orderrecord b on a.order_id=b.order_id and b.ntype<>5 ";
                        }

                        sql = "select sum(a.acvalue) from zy_fee_speci a " + _join + " where a.delete_bit=0 and a.cz_flag=2 and a.inpatient_id='" + ClassStatic.Current_BinID + "'" + _tj;
                        _czfee = Convert.ToDecimal(Convertor.IsNull(FrmMdiMain.Database.GetDataResult(sql), "0"));

                        if ((Math.Abs(_czfee) + Math.Abs(_bctfje) >= _czed) && _bctfje != 0)//Modify By Tany 2015-05-27 如果本次退费金额为0，也就是不在受控范围内的话，不需要提示
                        {
                            if (_kzfs == 2)
                            {
                                if (MessageBox.Show("该病人累计受控制冲账金额为：" + Math.Abs(_czfee).ToString("0.00") + "元\n本次受控制冲账金额为：" + Math.Abs(_bctfje).ToString("0.00") + "元\n系统允许冲账的额度为：" + _czed.ToString("0.00") + "元\n\n如果一定要冲账，将需要相关科室进行确认，是否继续操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    _isUnjz = true;
                                }
                            }
                            else if (_kzfs == 1)
                            {
                                MessageBox.Show("该病人累计受控制冲账金额为：" + Math.Abs(_czfee).ToString("0.00") + "元\n本次受控制冲账金额为：" + Math.Abs(_bctfje).ToString("0.00") + "元\n系统允许冲账的额度为：" + _czed.ToString("0.00") + "元\n\n不允许继续操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                if (MessageBox.Show("该病人累计受控制冲账金额为：" + Math.Abs(_czfee).ToString("0.00") + "元\n本次受控制冲账金额为：" + Math.Abs(_bctfje).ToString("0.00") + "元\n系统允许冲账的额度为：" + _czed.ToString("0.00") + "元\n\n是否继续操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    #endregion
                }

                this.progressBar1.Maximum = iSelectRows;
                this.progressBar1.Value = 0;

                string ward_id = "";
                string ward_deptid = "";
                string nFeeID = "";

                decimal tfje = 0;
                #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                if (rtnSql[0] != "0")
                {
                    MessageBox.Show("由于跨院转科或者特殊治疗，该病人记录已经冻结不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int BrJgbm = Convert.ToInt32(rtnSql[1]);
                #endregion
                //Modify by tany 2011-03-16 7053医技项目退费是否需要确认 0=不是 1=是
                SystemCfg cfg7053 = new SystemCfg(7053);
                SystemCfg cfg7113 = new SystemCfg(7113);
                long DeptId = isSSMZ || isTSZL ? FrmMdiMain.CurrentDept.DeptId : ClassStatic.Current_DeptID;
                //add by zouchihua 获得医嘱id
                string order_id = "";
                Guid newFeeId;//Add By Tany 2015-05-27 用于新产生的费用ID，因为要写多张表
                string sql_yf = "select  drugstore_id  from  JC_DEPT_DRUGSTORE where dept_id=" + InstanceForm.BCurrentDept.DeptId.ToString();
                DataTable dt_yf_dept = InstanceForm.BDatabase.GetDataTable(sql_yf);
                bool truedrugstore = false;


                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ID"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                    {
                        newFeeId = PubStaticFun.NewGuid();
                        //已进仓是否允许冲减  0：不允许 1：允许
                        SystemCfg cfg7603 = new SystemCfg(7603);
                        if (cfg7603.Config.Trim().Equals("0"))
                        {
                            string strValid = string.Format(@"select count(1) as Num from  zy_fee_speci A where id='{0}' and is_PvsScn=1 and 
                                                                exists(select 1 from JC_DEPT_DRUGSTORE t where A.EXECDEPT_ID=T.DRUGSTORE_ID AND is_PvsRel=1)",
                                                            myTb.Rows[i]["ID"].ToString().Trim());

                            string num = FrmMdiMain.Database.GetDataResult(strValid).ToString().Trim();
                            int iNum = int.Parse(num);

                            if (iNum > 0)
                            {
                                MessageBox.Show("对不起，该药单已经被静配中心扫描，不允许冲正！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                myDataGrid1.CurrentCell = new DataGridCell(i, 0);//选择列
                                myDataGrid1_Click(sender, e);
                                return;
                            }
                        }

                        order_id = myTb.Rows[i]["order_id"].ToString().Trim();
                        //add by zouchihua 2013-2-6 增加了医保结算控制
                        try
                        {
                            string ss = "select * from  zy_fee_speci  where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "' and  isnull(YBJS_BIT,0)=1 ";
                            DataTable tb = FrmMdiMain.Database.GetDataTable(ss);
                            if (tb.Rows.Count > 0)
                            {
                                MessageBox.Show("对不起，该费用已经医保结算，不允许冲正！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                myDataGrid1.CurrentCell = new DataGridCell(i, 0);//选择列
                                myDataGrid1_Click(sender, e);
                                return;
                            }
                        }
                        catch { }
                        //add by zouchihua 2012-9-20 如果是医技项目，并且已经签收不允许冲正
                        if (nType == 5)
                        {
                            string sql = "select BQSBZ from YJ_ZYSQ where YZID='" + myTb.Rows[i]["order_id"].ToString().Trim() + "'  and yzxmid   in (select yzid from JC_ASSAY)";//只有检验的作控制
                            DataTable tmptb = FrmMdiMain.Database.GetDataTable(sql);
                            if (tmptb.Rows.Count > 0)
                            {
                                if (tmptb.Rows[0]["BQSBZ"].ToString() == "1")
                                {
                                    MessageBox.Show("对不起，该项目已经签收，不允许冲正！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    myDataGrid1.CurrentCell = new DataGridCell(i, 0);//选择列
                                    myDataGrid1_Click(sender, e);
                                    return;
                                }
                            }
                            //扣费漏费控制 add by zouchihua 2013-5-30
                            try
                            {
                                string feestr = "select * from zy_fee_speci a left join YJ_ZYSQ b on a.ORDEREXEC_ID=b.ZXID where tcid>0 and id='" + myTb.Rows[i]["id"].ToString().Trim() + "'";
                                DataTable tbfee = FrmMdiMain.Database.GetDataTable(feestr);
                                string sql1 = "";
                                if (tbfee.Rows.Count > 0)
                                {
                                    //如果是套餐
                                    sql1 = "select * from hix_check where check_flag=1 and patientCheck_id=tf_'" + tbfee.Rows[0]["PRESCRIPTION_ID"].ToString() + "'";
                                }
                                else
                                    sql1 = "select * from hix_check  where check_flag=1 and patientCheck_id=tf_'" + tbfee.Rows[0]["YJSQID"].ToString() + "'";
                                DataTable tbtfpd = FrmMdiMain.Database.GetDataTable(sql1);
                                if (tbtfpd.Rows.Count > 0)
                                {
                                    MessageBox.Show("该费用已经在机器上做了, 不允许退费，你联系管理员");
                                    return;
                                }

                            }
                            catch
                            {

                            }
                        }
                        bool sfxyqr = false;//非医技项目退费是否需要确认
                        //add by zouchihua 2012-4-13 护士站是否允许冲正医技项目 0=是,1=不是
                        if (nType == 5 && cfg7113.Config.Trim() == "1" && Convert.ToInt64(myTb.Rows[i]["execdept_id"]) != DeptId)
                        {
                            MessageBox.Show("对不起，系统不允许护士冲正医技项目！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            myDataGrid1.CurrentCell = new DataGridCell(i, 0);//选择列
                            myDataGrid1_Click(sender, e);
                            return;
                        }

                        //是否只有护士长能够冲正已发药的费用 Add By Tany 2007-10-27
                        if ((new SystemCfg(7039)).Config == "是" && Convert.ToInt16(myTb.Rows[i]["fy_bit"]) == 1 && !isHSZ)
                        {
                            MessageBox.Show("对不起，第 " + Convert.ToString(i + 1) + " 行记录已经发药，只有护士长能够冲正！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            myDataGrid1.CurrentCell = new DataGridCell(i, 0);//选择列
                            myDataGrid1_Click(sender, e);
                            return;
                        }

                        if (ward_id == "" || ward_deptid == "")
                        {
                            ward_id = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select ward_id from zy_orderrecord where order_id ='" + myTb.Rows[i]["order_id"].ToString() + "'"), "");
                            ward_deptid = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select dept_id from jc_ward where ward_id ='" + ward_id + "'"), "");
                        }

                        decimal num_cz = Convert.ToDecimal(myTb.Rows[i]["数量"]) * czcs;
                        //      if (this.rbsl.Checked)//add by zouchihua2013-8-21 如果是选择冲正数量
                        if (this.rbsl.Checked)//add by zouchihua2013-8-21 如果是选择冲正数量
                            num_cz = Convert.ToDecimal(this.textBox1.Text);
                        //SQL分成药品和非药品主要是区分dosage，非药品忽视dosage

                        if (myTb.Rows[i]["xmly"].ToString().Trim() != "1")
                        {



                            if (
                                //如果开单科室和病人所在科室与执行科室都不相同 Modify By Tany 2009-11-16
                                    myTb.Rows[i]["DEPT_BR"].ToString().Trim() != myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim()
                                    && myTb.Rows[i]["DEPT_ID"].ToString().Trim() != myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim()
                                    && nType == 5
                                    && cfg7053.Config == "1"
                                )
                            {
                                //add by zouchihua 2014-4-7  7053开启时(为1时)，不受控制的执行科室，多个用逗号隔开
                                string cfgvalues = ("," + cfg7192.Config.Trim() + ",");
                                if (cfgvalues.Contains("," + myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim() + ","))
                                {
                                    sSql1 = "charge_bit,charge_date,charge_user )";
                                    sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                                }
                                else
                                {
                                    //如果是医技并且需要确费
                                    sSql1 = "charge_bit )";
                                    sSql2 = "0 ";
                                }
                            }
                            else
                            {


                                if (cfg7212.Config.Trim() == "1")
                                {
                                    //如果开单科室和病人所在科室与执行科室都不相同
                                    if (nType != 5 && myTb.Rows[i]["DEPT_BR"].ToString().Trim() != myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim()
                                    && myTb.Rows[i]["DEPT_ID"].ToString().Trim() != myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim())
                                    {
                                        string czyz = @"select HOITEM_ID from ZY_ORDERRECORD
                                                                a join JC_HOITEMDICTION  b on a.HOITEM_ID=b.ORDER_ID
                                                                where a.XMLY=2 and (isbks=1 or isryks=1) and  a.order_id='" + myTb.Rows[i]["order_id"].ToString() + @"'";
                                        DataTable tb_ksdep = FrmMdiMain.Database.GetDataTable(czyz);
                                        if (tb_ksdep.Rows.Count > 0)
                                        {
                                            //说明是需要他科室确认
                                            sSql1 = "charge_bit )";
                                            sSql2 = "0 ";
                                            sfxyqr = true;
                                        }
                                        else
                                        {
                                            //非药品需要确认负费用
                                            //非药品，记账标志和完成标志都是1
                                            sSql1 = "charge_bit,charge_date,charge_user )";
                                            sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                                        }
                                    }
                                    else
                                    {
                                        //非药品需要确认负费用
                                        //非药品，记账标志和完成标志都是1
                                        sSql1 = "charge_bit,charge_date,charge_user )";
                                        sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                                    }

                                }
                                else
                                {
                                    //非药品需要确认负费用
                                    //非药品，记账标志和完成标志都是1
                                    sSql1 = "charge_bit,charge_date,charge_user )";
                                    sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                                }

                            }

                            //Modify By Tany 2010-12-12 如果强制不允许记账，那么记账标志为0
                            //7078冲正额度管理不控制的统计大项目代码，如有多个大项目代码，请用逗号（,）分隔，留空表示全部控制
                            if (_isUnjz && _cfg7078.IndexOf(myTb.Rows[i]["statitem_code"].ToString().Trim()) < 0)
                            {
                                //Modify By Tany 2010-12-15 7077冲正额度管理是否管理医技数据 0=不是 1=是
                                if (nType != 5 || (nType == 5 && _cfg7077 == "1"))
                                {
                                    sSql1 = "charge_bit )";
                                    sSql2 = "0";
                                }
                            }

                            //Modify By Tany 2015-05-12
                            #region 单条金额限制
                            if (_cfg7073 == "1")
                            {
                                //冲正额度开启后，看看是否开启了单条冲正金额
                                if (Convertor.IsNumeric(_cfg7805) && Convert.ToDecimal(_cfg7805) > 0)
                                {
                                    decimal jexz = Convert.ToDecimal(_cfg7805);
                                    decimal dtje = num_cz * Convert.ToDecimal(myTb.Rows[i]["单价"]) * Convert.ToDecimal(myTb.Rows[i]["剂数"]);
                                    if (jexz < dtje)
                                    {
                                        if (_cfg7075 == "2")
                                        {
                                            if (MessageBox.Show("第" + (i + 1) + "行费用冲账金额为：" + dtje.ToString("0.00") + "元\n系统允许冲账的额度为小于：" + jexz.ToString("0.00") + "元\n\n如果一定要冲账，将需要相关科室进行确认，是否继续操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            {
                                                myTb.Rows[i]["选"] = false;
                                                return;
                                            }
                                            else
                                            {
                                                sSql1 = "charge_bit )";
                                                sSql2 = "0";
                                            }
                                        }
                                        else if (_cfg7075 == "1")
                                        {
                                            MessageBox.Show("第" + (i + 1) + "行费用冲账金额为：" + dtje.ToString("0.00") + "元\n系统允许冲账的额度为小于：" + jexz.ToString("0.00") + "元\n\n不允许继续操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            myTb.Rows[i]["选"] = false;
                                            return;
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("第" + (i + 1) + "行费用冲账金额为：" + dtje.ToString("0.00") + "元\n系统允许冲账的额度为小于：" + jexz.ToString("0.00") + "元\n\n是否继续操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            {
                                                myTb.Rows[i]["选"] = false;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion

                            sSql = "INSERT INTO ZY_FEE_SPECI" +
                                " (id,jgbm,Order_id,prescription_id,orderexec_id,presc_date,book_date,book_user,presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                                " cost_price, retail_Price, agio, EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                                " CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT, " +
                                "num,sdValue,acValue,type,tlfs,gcys,pvs_xh,zfbl," +//增加pivas序号 Modify By Tany 2015-04-22  增加zfbl
                                sSql1 +
                                //Modify By Tany 2015-05-25 使用预先生成的费用ID DBO.FUN_GETGUID(NEWID(),GETDATE())
                                "SELECT '" + newFeeId + "',a.jgbm,Order_id,prescription_id,orderexec_id,presc_date,getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                                "cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                                "2,a.id,0,0," +
                                "-1*" + num_cz.ToString() + ",-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price)*" + czcs + ",-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price)*" + czcs + ",type,tlfs,gcys,pvs_xh,zfbl," +
                                sSql2 +
                                " from zy_fee_speci a where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                        }
                        else
                        {
                            for (int k = 0; k < dt_yf_dept.Rows.Count; k++)
                            {
                                if (myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim() == dt_yf_dept.Rows[k]["drugstore_id"].ToString())
                                {
                                    truedrugstore = true;
                                }
                            }
                            if (!truedrugstore)
                            {
                                MessageBox.Show("该条医嘱的执行科室不正确！");
                                return;
                            }
                            //基数药、直接记账的药直接记账
                            if (Convert.ToInt16(myTb.Rows[i]["基数药"]) == 1
                                || Convert.ToInt16(myTb.Rows[i]["jz_flag"]) == 1
                                || ((new SystemCfg(7025)).Config == "是"))// && Convert.ToInt16(myTb.Rows[i]["fy_bit"]) == 0 Modify by Tany 2009-11-07 改成冲正药品是否直接记账 -----冲正未发药药品是否直接记账
                            {
                                //基数药品、直接记账的药品，记账标志是1，完成标志是0 Modify By Tany 2004-10-08 
                                sSql1 = "charge_bit,charge_date,charge_user )";
                                sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                            }
                            else
                            {
                                //非基数药品，记账标志，完成标志都是0，CZ_YPFLAG=1
                                sSql1 = "charge_bit )";
                                sSql2 = "0";
                            }

                            //Modify By Tany 2010-01-12 冲正草药是否直接记账
                            if (nType == 3 && (new SystemCfg(7061)).Config == "0")
                            {
                                sSql1 = "charge_bit )";
                                sSql2 = "0";
                            }

                            //Modify By Tany 2010-12-12 如果强制不允许记账，那么记账标志为0
                            //Modify By Tany 2010-12-15 7076冲正额度管理是否管理药品数据 0=不是 1=是
                            if (_isUnjz && _cfg7076 == "1")
                            {
                                sSql1 = "charge_bit )";
                                sSql2 = "0";
                            }
                            string strbz = "";
                            //add by zouchihua 2012-12-18 暂存药如果发送到了暂存药房，冲正的话直接打上记账标记
                            SystemCfg cfg7117 = new SystemCfg(7117);
                            string execdeptid = cfg7117.Config.Trim();
                            if (Convert.ToInt16(myTb.Rows[i]["fy_bit"]) == 1 && myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim() == execdeptid)
                            {
                                sSql1 = "charge_bit,charge_date,charge_user,bz )";
                                sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + ",'暂存药自动记账'  ";
                                strbz = "暂存药自动记账";
                            }
                            //如果是出区后冲正，那么出区后冲正(不产生发药信息
                            if (zczyz_notfy)
                            {
                                sSql1 = "charge_bit,charge_date,charge_user,bz )";
                                sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + ",'出区后冲正(不产生发药信息)'";
                            }

                            //大输液处理
                            //if (myTb.Rows[i]["tlfl"].ToString().Trim().Equals("03"))
                            //{
                            //    //如果是pivas的话，还要额外判断 Modify By Tany 2015-06-03
                            //    bool isPvsDpt = IsPvsDept(myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim());
                            //    if (!isPvsDpt)
                            //    {
                            //        //不是pivas的直接记账，并且不发药
                            //        sSql1 = "charge_bit,charge_date,charge_user,FY_BIT )";
                            //        sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + ",5"; //Modify By Tany 2015-04-23 如果是大输液，看执行科室是否pivas，如果是pivas的话则需要发药
                            //    }
                            //    else
                            //    {
                            //        //如果是pivas的，则不记账，先写死，武汉中心医院
                            //        sSql1 = "charge_bit )";
                            //        sSql2 = "0";
                            //    }
                            //}

                            //大输液处理 Modify by jchl ：大输液药房直接发药
                            if (myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim().Equals("566") ||
                                myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim().Equals("672") ||
                                myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim().Equals("783"))
                            {
                                //不是pivas的直接记账，并且不发药
                                sSql1 = "charge_bit,charge_date,charge_user,FY_BIT )";
                                sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + ",5";
                            }

                            //Modify By Tany 2015-05-12
                            #region 单条金额限制
                            if (_cfg7073 == "1")
                            {
                                //冲正额度开启后，看看是否开启了单条冲正金额
                                if (Convertor.IsNumeric(_cfg7805) && Convert.ToDecimal(_cfg7805) > 0)
                                {
                                    decimal jexz = Convert.ToDecimal(_cfg7805);
                                    decimal dtje = num_cz * Convert.ToDecimal(myTb.Rows[i]["单价"]) * Convert.ToDecimal(myTb.Rows[i]["剂数"]);
                                    if (jexz < dtje)
                                    {
                                        if (_cfg7075 == "2")
                                        {
                                            if (MessageBox.Show("第" + (i + 1) + "行费用冲账金额为：" + dtje.ToString("0.00") + "元\n系统允许冲账的额度为小于：" + jexz.ToString("0.00") + "元\n\n如果一定要冲账，将需要相关科室进行确认，是否继续操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            {
                                                myTb.Rows[i]["选"] = false;
                                                return;
                                            }
                                            else
                                            {
                                                sSql1 = "charge_bit )";
                                                sSql2 = "0";
                                            }
                                        }
                                        else if (_cfg7075 == "1")
                                        {
                                            MessageBox.Show("第" + (i + 1) + "行费用冲账金额为：" + dtje.ToString("0.00") + "元\n系统允许冲账的额度为小于：" + jexz.ToString("0.00") + "元\n\n不允许继续操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            myTb.Rows[i]["选"] = false;
                                            return;
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("第" + (i + 1) + "行费用冲账金额为：" + dtje.ToString("0.00") + "元\n系统允许冲账的额度为小于：" + jexz.ToString("0.00") + "元\n\n是否继续操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            {
                                                myTb.Rows[i]["选"] = false;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion

                            sSql = "INSERT INTO ZY_FEE_SPECI" +
                                " (id,jgbm,Order_id,prescription_id,orderexec_id,presc_date,book_date,book_user,presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                                " cost_price, retail_Price, agio, EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                                " CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT, " +
                                "num,sdValue,acValue,type,tlfs,gcys,pvs_xh,zfbl," +//增加pivas序号 Modify By Tany 2015-04-22
                                sSql1 +
                                //Modify By Tany 2015-05-25 使用预先生成的费用ID DBO.FUN_GETGUID(NEWID(),GETDATE())
                                "SELECT '" + newFeeId + "',a.jgbm,Order_id,prescription_id,orderexec_id,presc_date,getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                                "cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                                "2,a.id,0,0," +
                                "-1*" + num_cz.ToString() + ",-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price*dosage)*" + czcs + ",-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price*dosage)*" + czcs + ",type,tlfs,gcys,pvs_xh,zfbl," + //Modify By Tany 2004-11-10 加入dosage，以前没有，有问题
                                sSql2 +
                                " from zy_fee_speci a where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                        }

                        FrmMdiMain.Database.BeginTransaction();
                        try
                        {
                            FrmMdiMain.Database.DoCommand(sSql);

                            //Add By Tany 2015-05-27 如果是符合需要冲账审核的数据，写入冲账费用表，冲账审核只提取这些数据
                            if (_isUnjz)
                            {
                                sSql = "insert into zy_czfee(feeid) values ('" + newFeeId + "')";
                                FrmMdiMain.Database.DoCommand(sSql);
                            }

                            //add by zouchihua 2012-2-21
                            #region 冲正减虚拟库存
                            try
                            {
                                if (!zczyz_notfy)
                                {
                                    string cfg6035 = new SystemCfg(6035).Config.Trim();
                                    if (cfg6035 == "1" && myTb.Rows[i]["xmly"].ToString().Trim() == "1")
                                    {
                                        myFunc.CzJxnkc(new Guid(myTb.Rows[i]["ID"].ToString().Trim()), czcs, Convert.ToDecimal(myTb.Rows[i]["数量"]));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            #endregion

                            //被冲标志
                            if (myTb.Rows[i]["记账类型"].ToString().Trim() != "被冲费用")
                            {
                                sSql = "update zy_fee_speci set cz_flag=1 where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                                FrmMdiMain.Database.DoCommand(sSql);
                                nFeeID += myTb.Rows[i]["ID"].ToString().Trim();
                            }

                            //Modify By Tany 2010-01-23 医技退费也需要循环，并且退费金额等于上次退费金额+这次的，适用于长期医嘱
                            if (nType == 5 && Convert.ToInt32(myTb.Rows[i]["TYPE"]) == 1)
                            {
                                tfje = num_cz * Convert.ToDecimal(myTb.Rows[i]["单价"]) * Convert.ToDecimal(myTb.Rows[i]["剂数"]);

                                if (tfje != 0)
                                {
                                    sSql = "update yj_zysq set btfbz=1,tfje=tfje+(-1*" + tfje + ") where yzid='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "' and zxid='" + new Guid(myTb.Rows[i]["orderexec_id"].ToString()) + "'";
                                    FrmMdiMain.Database.DoCommand(sSql);

                                    //Modify by Tany 2011-03-16 如果医技退费直接记账，还需要调用医技确认
                                    if (cfg7053.Config == "0")
                                    {
                                        Guid newYjqrid = Guid.Empty;
                                        int errCode = -1;
                                        string errMsg = "";
                                        Guid yjsqid = new Guid(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select yjsqid from yj_zysq where yzid='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "' and zxid='" + new Guid(myTb.Rows[i]["orderexec_id"].ToString()) + "'"), Guid.Empty.ToString()));
                                        DateTime nowTime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                                        //add by zouchihua 2011-12-18 yjsqid为空时跳过
                                        if (yjsqid != Guid.Empty)
                                        {
                                            ts_yj_class.yjqr.yj_zysq_qrjl(new Guid(myTb.Rows[i]["order_id"].ToString()),
                                               new Guid(myTb.Rows[i]["orderexec_id"].ToString()),
                                               yjsqid,
                                               -tfje,
                                               Convert.ToInt32(myTb.Rows[i]["dept_br"].ToString()),
                                               nowTime.ToString(),
                                               FrmMdiMain.CurrentUser.EmployeeId,
                                               0,
                                               nowTime.ToString(),
                                               0,
                                               "",
                                               out newYjqrid,
                                               out errCode,
                                               out errMsg,
                                               0,
                                               FrmMdiMain.Database);
                                            if (errCode != 0)
                                            {
                                                throw new Exception("医技项目冲正确认时出错：" + errMsg);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ////add by zouchihua 2014-4-7  7053开启时(为1时)，不受控制的执行科室，多个用逗号隔开
                                        string cfgvalues = ("," + cfg7192.Config.Trim() + ",");
                                        if (cfgvalues.Contains("," + myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim() + ","))
                                        {
                                            Guid newYjqrid = Guid.Empty;
                                            int errCode = -1;
                                            string errMsg = "";
                                            Guid yjsqid = new Guid(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select yjsqid from yj_zysq where yzid='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "' and zxid='" + new Guid(myTb.Rows[i]["orderexec_id"].ToString()) + "'"), Guid.Empty.ToString()));
                                            DateTime nowTime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                                            //add by zouchihua 2011-12-18 yjsqid为空时跳过
                                            if (yjsqid != Guid.Empty)
                                            {
                                                ts_yj_class.yjqr.yj_zysq_qrjl(new Guid(myTb.Rows[i]["order_id"].ToString()),
                                                   new Guid(myTb.Rows[i]["orderexec_id"].ToString()),
                                                   yjsqid,
                                                   -tfje,
                                                   Convert.ToInt32(myTb.Rows[i]["dept_br"].ToString()),
                                                   nowTime.ToString(),
                                                   FrmMdiMain.CurrentUser.EmployeeId,
                                                   0,
                                                   nowTime.ToString(),
                                                   0,
                                                   "",
                                                   out newYjqrid,
                                                   out errCode,
                                                   out errMsg,
                                                   0,
                                                   FrmMdiMain.Database);
                                                if (errCode != 0)
                                                {
                                                    throw new Exception("医技项目冲正确认时出错：" + errMsg);
                                                }
                                            }
                                        }
                                    }
                                }
                                else//Modify By Tany 2010-05-27
                                {
                                    throw new Exception("医技项目冲正金额为0，不允许冲正！");
                                }
                            }

                            FrmMdiMain.Database.CommitTransaction();
                        }
                        catch (Exception err)
                        {
                            FrmMdiMain.Database.RollbackTransaction();
                            MessageBox.Show(err.Message);
                            return;
                        }

                        //冲正未发药的消息是否自动删除该消息
                        //Modify By Tany 2005-12-06
                        #region 冲正未发药的消息是否自动删除该消息

                        if ((new SystemCfg(7026)).Config == "是" && nType != 5 && sfxyqr == false) //!(nType == 5 && (new SystemCfg(7053)).Config == "1") Modify By tany 2011-03-16 医技不管是不是需要确认，都不能删除
                        {
                            //Modify By Tany 2011-03-16 在此重新刷新费用记录的信息
                            sSql = "select * from zy_fee_speci where delete_bit=0 and id='" + myTb.Rows[i]["ID"].ToString() + "'";
                            DataTable tmpTb = FrmMdiMain.Database.GetDataTable(sSql);
                            if (tmpTb != null && tmpTb.Rows.Count > 0)
                            {
                                //如果没有发药 并且 没有医保上传 并且 (没有记账 或者 记账日期等于今天)
                                if (
                                    tmpTb.Rows[0]["fy_bit"].ToString() == "0" && tmpTb.Rows[0]["scbz"].ToString() == "0"
                                    &&
                                    (
                                    tmpTb.Rows[0]["charge_bit"].ToString() == "0"
                                    //|| (tmpTb.Rows[0]["charge_bit"].ToString() == "1" && Convert.ToDateTime(tmpTb.Rows[0]["charge_date"]).ToShortDateString() == DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToShortDateString())
                                    )
                                   )
                                {

                                    sSql = "select sum(num) as num  from zy_fee_speci where  delete_bit=0 and (id='" + myTb.Rows[i]["ID"].ToString() + "' or cz_id='" + myTb.Rows[i]["ID"].ToString() + "')";
                                    if (cfg7191.Config.Trim() == "1")
                                    {
                                        //如果是进入了暂存药的，不允许冲正自动删除
                                        sSql += " and TLFS<>9 ";
                                    }
                                    DataTable myTmpTb = FrmMdiMain.Database.GetDataTable(sSql);
                                    if (myTmpTb != null && myTmpTb.Rows.Count != 0)
                                    {
                                        if (myTmpTb.Rows[0]["num"].ToString().Trim() != "")
                                        {
                                            //如果已经全部冲正完毕
                                            if (Convert.ToDecimal(myTmpTb.Rows[0]["num"]) == 0)
                                            {
                                                //再看一下冲正的药品里面是否有已经发药的
                                                //Modify By tany 2011-03-16 或者有上传的
                                                sSql = "select fy_bit,scbz from zy_fee_speci where delete_bit=0 and cz_id='" + myTb.Rows[i]["ID"].ToString() + "'";
                                                DataTable myTmpTb1 = FrmMdiMain.Database.GetDataTable(sSql);
                                                bool isFinish = false;

                                                for (int k = 0; k < myTmpTb1.Rows.Count; k++)
                                                {
                                                    if (myTmpTb1.Rows[k]["fy_bit"].ToString() == "1"
                                                        || myTmpTb1.Rows[k]["scbz"].ToString() == "1")
                                                    {
                                                        isFinish = true;
                                                        break;
                                                    }
                                                }

                                                if (isFinish == false)
                                                {
                                                    string[] sql = new string[2];
                                                    sql[0] = "update zy_fee_speci set delete_bit=1,bz=isnull(bz,'')+'冲账删除' where fy_bit=0 and scbz=0 and id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                                                    sql[1] = "update zy_fee_speci set delete_bit=1,bz=isnull(bz,'')+'冲账删除' where fy_bit=0 and scbz=0 and cz_id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                                                    FrmMdiMain.Database.DoCommand(null, null, null, sql);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                        this.progressBar1.Value += 1;
                    }
                }

                #region"医保智审接口调用"

                bool CanAudit = ClsAuditCheck.CheckIsAuditCheck(ClassStatic.Current_BinID.ToString(), InstanceForm.BDatabase);//是否需要智审
                if (CanAudit)
                {
                    if (ClassStatic.Current_BabyID == 0)
                    {
                        string strMsg = "";
                        bool bSuc = DoVaildYbFee(myTb, MNGType, ClassStatic.Current_BinID, ClassStatic.Current_BabyID, out strMsg);
                        if (!bSuc)
                        {
                            //MessageBox.Show(strMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                #endregion

                if (nType == 1 || nType == 2)
                {
                    //医嘱发送（冲账）是否自动生成药品统领信息
                    //Modify By Tany 2005-11-05
                    if ((new SystemCfg(7047)).Config == "是")
                    {
                        //发送冲正药品统领消息
                        System.DateTime ExecDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);

                        string yfSql = "";
                        DataTable yfTb = new DataTable();

                        //冲正后执行药品统领
                        //如果开医嘱所在的病区不等于当前病区，则用医嘱所在病区，主要用于转科以前的医嘱 Modify By Tany 2005-03-16
                        if (ward_id.Trim() == FrmMdiMain.CurrentDept.WardId.Trim() || isSSMZ || isTSZL)
                        {
                            string strErrWard = "";
                            string strErrExeDept = "";
                            try
                            {
                                yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                                yfTb = FrmMdiMain.Database.GetDataTable(yfSql);

                                for (int i = 0; i < yfTb.Rows.Count; i++)
                                {
                                    strErrWard = FrmMdiMain.CurrentDept.WardId;
                                    strErrExeDept = yfTb.Rows[i]["execdept_id"].ToString().Trim();
                                    //新统领药品消息 Modify By Tany 2005-09-13
                                    myFunc.SendYPFY(0, 1, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                                    //新统领药品（退药） Add by zouchihua 2013-5-29 重新发送的也要重新生存
                                    myFunc.SendYPFY(2, 1, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                                }

                                ////Modify by zouchihua 增加病人所在病区 2013-7-17
                                DataTable tbtmb = FrmMdiMain.Database.GetDataTable(" SELECT WARD_ID FROM JC_WARD WHERE WARD_ID in (SELECT WARD_ID FROM JC_WARDRDEPT WHERE DEPT_ID=" + myTb.Rows[0]["DEPT_BR"].ToString() + " )");
                                if (tbtmb != null && tbtmb.Rows.Count > 0)
                                {
                                    for (int j = 0; j < tbtmb.Rows.Count; j++)
                                    {
                                        strErrWard = tbtmb.Rows[j]["WARD_ID"].ToString();
                                        strErrExeDept = yfTb.Rows[j]["execdept_id"].ToString().Trim();
                                        myFunc.SendYPFY(0, 1, tbtmb.Rows[j]["WARD_ID"].ToString(), FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[j]["execdept_id"]), FrmMdiMain.Jgbm);
                                        myFunc.SendYPFY(2, 1, tbtmb.Rows[j]["WARD_ID"].ToString(), FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[j]["execdept_id"]), FrmMdiMain.Jgbm);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                SystemLog _sysLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "统领超时",
                                    "病区：" + strErrWard + "  病区科室：" + (FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId) + " 操作人：" + FrmMdiMain.CurrentUser.EmployeeId + " 操作时间： " + ExecDate + "  执行科室：" + strErrExeDept,
                                    DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + System.Environment.MachineName, 39);

                                _sysLog.Save();

                                throw ex;
                            }
                        }
                        else
                        {
                            string strErrWard = "";
                            string strErrExeDept = "";
                            try
                            {
                                yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + ward_id + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                                yfTb = FrmMdiMain.Database.GetDataTable(yfSql);

                                for (int i = 0; i < yfTb.Rows.Count; i++)
                                {
                                    strErrWard = ward_id;
                                    strErrExeDept = yfTb.Rows[i]["execdept_id"].ToString().Trim();
                                    //新统领药品消息 Modify By Tany 2005-09-13
                                    myFunc.SendYPFY(0, 1, ward_id, Convert.ToInt64(ward_deptid) == 0 ? FrmMdiMain.CurrentDept.DeptId : Convert.ToInt64(ward_deptid), FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                                    //新统领药品（退药） Add by zouchihua 2013-5-29 重新发送的也要重新生存
                                    myFunc.SendYPFY(2, 1, ward_id, Convert.ToInt64(ward_deptid) == 0 ? FrmMdiMain.CurrentDept.DeptId : Convert.ToInt64(ward_deptid), FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                                }
                                ////Modify by zouchihua 增加病人所在病区 2013-7-17
                                DataTable tbtmb = FrmMdiMain.Database.GetDataTable(" SELECT WARD_ID FROM JC_WARD WHERE WARD_ID in (SELECT WARD_ID FROM JC_WARDRDEPT WHERE DEPT_ID=" + myTb.Rows[0]["DEPT_BR"].ToString() + " )");
                                if (tbtmb != null && tbtmb.Rows.Count > 0)
                                {
                                    for (int j = 0; j < tbtmb.Rows.Count; j++)
                                    {
                                        strErrWard = tbtmb.Rows[j]["WARD_ID"].ToString();
                                        strErrExeDept = yfTb.Rows[j]["execdept_id"].ToString().Trim();
                                        myFunc.SendYPFY(0, 1, tbtmb.Rows[j]["WARD_ID"].ToString(), FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[j]["execdept_id"]), FrmMdiMain.Jgbm);
                                        myFunc.SendYPFY(2, 1, tbtmb.Rows[j]["WARD_ID"].ToString(), FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[j]["execdept_id"]), FrmMdiMain.Jgbm);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                SystemLog _sysLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "统领超时",
                                    "病区：" + strErrWard + "  病区科室：" + (FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId) + " 操作人：" + FrmMdiMain.CurrentUser.EmployeeId + " 操作时间： " + ExecDate + "  执行科室：" + strErrExeDept,
                                    DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + System.Environment.MachineName, 39);

                                _sysLog.Save();

                                throw ex;
                            }
                        }
                    }
                }

                //Add By Tany 2005-02-21
                #region 大输液直接记费 暂时作废了
                //			if(PubStaticFun.GetSystemConfig(11004)=="是")
                //			{
                //				for(int i=0;i<=myTb.Rows.Count-1;i++)
                //				{
                //					//被选中
                //					if(myTb.Rows[i]["ID"].ToString().Trim()!="" && myTb.Rows[i]["选"].ToString()=="True" )
                //					{	
                //						//是药品
                //						if (!(myTb.Rows[i]["item_code"].ToString()=="" || myTb.Rows[i]["item_code"].ToString().Trim()=="-1"))
                //						{
                //							//非基数药
                //							if(Convert.ToInt16(myTb.Rows[i]["基数药"])==0)
                //							{
                //								string dsyStr = "Select b_dsy from YK_VYD where s_hh='"+myTb.Rows[i]["item_code"].ToString()+"'";
                //								DataTable dsyTb = InstanceForm.BDatabase.GetDataTable(dsyStr);
                //
                //								if(dsyTb!=null && dsyTb.Rows.Count>0)
                //								{
                //									//是大输液直接记帐
                //									if(Convert.ToInt32(dsyTb.Rows[0][0])==1)
                //									{
                //										sSql="update zy_fee_speci set charge_bit=1,charge_date=getdate(),charge_user="+InstanceForm.BCurrentUser.EmployeeId+
                //											" where cz_flag=2 and charge_bit=0 and CZ_ID="+myTb.Rows[i]["ID"].ToString().Trim()+
                //											"       and subcode='"+myTb.Rows[i]["item_code"].ToString()+"'";
                //										InstanceForm.BDatabase.DoCommand(sSql);
                //									}
                //								}
                //							}
                //						}
                //					}
                //				}
                //			}
                #endregion

                #region//add by zouchihua 2013-4-23 如果是临时医嘱，冲正后费用如果为0，那么直接打上未执行。一般这种情况不会是医技，所以不考虑操作医技表。也不会把费用删除掉
                if (this.lb1.Text.Trim().IndexOf("临时医嘱") >= 0 && new SystemCfg(7149).Config.Trim() == "1")
                {
                    string sql = "select SUM(ACVALUE) fee from ZY_FEE_SPECI where INPATIENT_ID='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + "  and DELETE_BIT=0 "
                               + "   and CHARGE_BIT=1 and ORDER_ID in(select a.ORDER_ID from ZY_ORDERRECORD a join ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID where a.ORDER_ID='" + order_id + "')   ";
                    decimal _fy = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sql), "0"));
                    if (_fy == 0)
                    {
                        //未执行
                        //写停止标志和未执行标志 
                        sql = "update zy_orderrecord set order_context='【取消】'+order_context,wzx_flag=" + InstanceForm.BCurrentUser.EmployeeId + ",status_flag=5 ,order_edate=getdate() , memo2='费用冲正【自动打上未执行】' " //Modify By Tany 2005-01-31 ,order_edate=getdate() //add by zouchihua 2012-6-15增加未执行的原因
                            + " where GROUP_ID in(select GROUP_ID from ZY_ORDERRECORD where ORDER_ID='" + order_id + "')   "

                            + "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                        FrmMdiMain.Database.DoCommand(sql);

                        sql = " update zy_orderexec  set REALEXEUSER='" + FrmMdiMain.CurrentUser.EmployeeId + "' where  order_id in ( select order_id from ZY_ORDERRECORD where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                             " and baby_id=" + ClassStatic.Current_BabyID + " and GROUP_ID in(select GROUP_ID from ZY_ORDERRECORD where ORDER_ID='" + order_id + "')  ) ";
                        FrmMdiMain.Database.DoCommand(sql);
                        #region//add by zouchihua 同时更新医嘱打印记录表 2013-4-23
                        //sSql = "  update ZY_LOGORDERPRT set order_context='【取消】'+order_context  " +
                        //   " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                        //    "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                        //  InstanceForm.BDatabase.DoCommand(sSql);
                        sql = "  update ZY_TMPORDERPRT set order_context='【取消】'+order_context  "
                            + " where GROUP_ID in(select GROUP_ID from ZY_ORDERRECORD where ORDER_ID='" + order_id + "')   "

                            + "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;//没有打印的情况下
                        InstanceForm.BDatabase.DoCommand(sql);

                        sSql = "  update ZY_TMPORDERPRT set    PRT_STATUS=4,memo='取消'  " +
                                 " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                  "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and PRT_STATUS not in(0,-1)";//打印的情况下
                        InstanceForm.BDatabase.DoCommand(sSql);
                        #endregion
                    }
                }
                #endregion
                //写日志 Add By Tany 2005-03-29
                SystemLog _systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医嘱冲正", "将fee_id=" + nFeeID + "的医嘱冲正", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                this.progressBar1.Value = 0;
            }
            catch (Exception err)
            {
                //SystemLog _sysLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医嘱冲正", "将fee_id=" + nFeeID + "的医嘱冲正", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + System.Environment.MachineName, 39);
                //_sysLog.Save();
                MessageBox.Show(err.Message);
            }
            Cursor.Current = Cursors.Default;

            this.ShowData();
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //只能输入数字
            if (e.KeyChar == 13) bt冲正.Focus();
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void bt取消冲正_Click(object sender, System.EventArgs e)
        {
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            string sSql = "";
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

            if (myTb == null) return;
            if (myTb.Rows.Count < 1) return;

            //Modify By Tany 2011-03-14 医技类的不允许取消冲正
            if (nType == 5)
            {
                MessageBox.Show("对不起，医技类的医嘱所产生的费用不允许取消冲正，请重新开立医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.rb每组医嘱.Checked)
            {
                if (MessageBox.Show(this, "确认将选择的每组医嘱取消冲正吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }
            else
            {
                if (MessageBox.Show(this, "确认将选择的每条医嘱取消冲正吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
                f1.Close();
            }
            bool isHSZ = myFunc.IsHSZ(FrmMdiMain.CurrentUser.EmployeeId);

            if (isHSZ == false)
            {
                //是否只有护士长能够冲正费用 Add By Tany 2007-09-12
                if ((new SystemCfg(7033)).Config == "是")
                {
                    MessageBox.Show("对不起，只有护士长能够取消冲正费用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            Cursor.Current = PubStaticFun.WaitCursor();

            #region 安全性判断
            //安全性判断放在身份验证后面，以免出现同时操作时间差，重复冲费
            //Modify By Tany 2005-03-26
            int iSelectRows = 0;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    if (myTb.Rows[i]["记账类型"].ToString() != "冲帐费用")
                    {
                        MessageBox.Show(this, "对不起，第" + (i + 1) + "行不是冲正记录，请选择冲正记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        myTb.Rows[i]["选"] = false;
                        return;
                    }
                    //add by zouchihua 2012-11-14 限制可以对同一条冲正记录进行多次‘取消冲账’
                    string sql = " select sum(num) num from ZY_FEE_SPECI where  ORDEREXEC_ID='" + myTb.Rows[i]["ORDEREXEC_ID"].ToString() + "'  and order_id='" + myTb.Rows[i]["order_ID"].ToString() + "'  and cz_flag in(2,3)";
                    DataTable temp = FrmMdiMain.Database.GetDataTable(sql);
                    if (temp.Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(temp.Rows[0]["num"].ToString()) >= 0)
                        {
                            MessageBox.Show(this, "对不起，第" + (i + 1) + "行已经取消冲正了，不允许再取消冲正！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myTb.Rows[i]["选"] = false;
                            return;
                        }
                    }
                    iSelectRows += 1;
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择冲正记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            this.progressBar1.Maximum = iSelectRows;
            this.progressBar1.Value = 0;

            string sFeeID = "";
            string ward_id = "";
            string ward_deptid = "";

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    if (ward_id == "" || ward_deptid == "")
                    {
                        ward_id = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select ward_id from zy_orderrecord where order_id ='" + myTb.Rows[i]["order_id"].ToString() + "'"), "");
                        ward_deptid = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select dept_id from jc_ward where ward_id ='" + ward_id + "'"), "");
                    }
                    try
                    {
                        InstanceForm.BDatabase.BeginTransaction();
                        //add by zouchihua 2012-2-21
                        #region 冲正减虚拟库存
                        try
                        {
                            string cfg6035 = new SystemCfg(6035).Config.Trim();
                            if (cfg6035 == "1" && myTb.Rows[i]["xmly"].ToString().Trim() == "1")
                            {
                                myFunc.CzJxnkc(new Guid(myTb.Rows[i]["ID"].ToString().Trim()), 0, Convert.ToDecimal(myTb.Rows[i]["数量"]));
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        #endregion

                        //不能简单的删除，必须新增一条正的
                        //Modify By Tany 2005-12-30
                        //					sSql="update zy_fee_speci set delete_bit=1 where id="+myTb.Rows[i]["ID"].ToString().Trim();
                        sSql = "INSERT INTO ZY_FEE_SPECI" +
                            " (id,jgbm,Order_id,prescription_id,orderexec_id,presc_date,book_date,book_user,presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                            " cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                            " CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT, " +
                            " num,sdValue,acValue,type,tlfs,gcys," +
                            " charge_bit,charge_date,charge_user,pvs_xh ) " +
                            " SELECT DBO.FUN_GETGUID(NEWID(),GETDATE())," + FrmMdiMain.Jgbm + ",Order_id,prescription_id,orderexec_id,presc_date,getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                            " cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                            " 3,DBO.FUN_GETEMPTYGUID(),0,0," +
                            //" -1*num,-1*num*retail_Price*dosage,-1*num*retail_Price*dosage,type,0,gcys," + 
                            " -1*num,-1*sdValue,-1*acValue,type,tlfs,gcys," + //Modify By Tany 2010-05-04 金额原来是什么就是什么
                            " 1,getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",pvs_xh" +//增加pivas序号 Modify By Tany 2015-04-22
                            " from zy_fee_speci a where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //					sSql="update zy_fee_speci set finish_bit=1 where id="+myTb.Rows[i]["ID"].ToString().Trim();
                        //					InstanceForm.BDatabase.DoCommand(sSql);	

                        sFeeID += myTb.Rows[i]["ID"].ToString().Trim() + ",";
                        InstanceForm.BDatabase.CommitTransaction();
                        #region 新的取消冲正不需要以下代码了
                        /*
					//Modify By Tany 2005-10-06
					//得到被冲的费用ID
					sSql="select cz_id from zy_fee_speci where id="+myTb.Rows[i]["ID"].ToString().Trim();
					long _czID=Convert.ToInt64(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql),"0"));

					//得到冲和被冲的数量总和
					sSql="select sum(num) as num  from zy_fee_speci where delete_bit=0 and (id="+_czID+" or cz_id="+_czID+")";
					decimal _totalNum=Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql),"0"));

					//得到被冲项目的原有数量
					sSql="select sum(num) as num  from zy_fee_speci where delete_bit=0 and id="+_czID;
					decimal _Num=Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql),"0"));

					//如果两个数量相等，表示所有的冲账被删除，所以要把被冲费用的标记改成正常标记，删除标记也要恢复
					if(_totalNum==_Num)
					{
						sSql="update zy_fee_speci set cz_flag=0,delete_bit=0 where id="+_czID;
						InstanceForm.BDatabase.DoCommand(sSql);
					}
					else
					{
						sSql="update zy_fee_speci set delete_bit=0 where id="+_czID;
						InstanceForm.BDatabase.DoCommand(sSql);
					}
					*/
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            #region"医保智审接口调用"

            bool CanAudit = ClsAuditCheck.CheckIsAuditCheck(ClassStatic.Current_BinID.ToString(), InstanceForm.BDatabase);//是否需要智审
            if (CanAudit)
            {
                if (ClassStatic.Current_BabyID == 0)
                {
                    string strMsg = "";
                    bool bSuc = DoVaildYbFee(myTb, MNGType, ClassStatic.Current_BinID, ClassStatic.Current_BabyID, out strMsg);
                    if (!bSuc)
                    {
                        MessageBox.Show(strMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            #endregion

            //写日志 Add By Tany 2005-03-29
            SystemLog _systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医嘱取消冲正", "将fee_id=" + sFeeID + "的医嘱取消冲正", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            if (nType == 1 || nType == 2)
            {
                //医嘱发送（冲账）是否自动生成药品统领信息
                //Modify By Tany 2005-11-05
                if ((new SystemCfg(7022)).Config == "是")
                {
                    //发送冲正药品统领消息
                    System.DateTime ExecDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);

                    string yfSql = "";
                    DataTable yfTb = new DataTable();

                    //冲正后执行药品统领
                    //如果开医嘱所在的病区不等于当前病区，则用医嘱所在病区，主要用于转科以前的医嘱 Modify By Tany 2005-03-16
                    if (ward_id.Trim() == FrmMdiMain.CurrentDept.WardId.Trim() || isSSMZ)
                    {
                        yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                            " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                        yfTb = FrmMdiMain.Database.GetDataTable(yfSql);

                        for (int i = 0; i < yfTb.Rows.Count; i++)
                        {
                            //新统领药品消息 Modify By Tany 2005-09-13
                            myFunc.SendYPFY(0, 0, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                        }
                    }
                    else
                    {
                        yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                            " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + ward_id + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                        yfTb = FrmMdiMain.Database.GetDataTable(yfSql);

                        for (int i = 0; i < yfTb.Rows.Count; i++)
                        {
                            //新统领药品消息 Modify By Tany 2005-09-13
                            myFunc.SendYPFY(0, 0, ward_id, Convert.ToInt64(ward_deptid) == 0 ? FrmMdiMain.CurrentDept.DeptId : Convert.ToInt64(ward_deptid), FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                        }
                    }
                }
            }

            this.progressBar1.Value = 0;

            Cursor.Current = Cursors.Default;

            this.ShowData();
        }

        private string GetOrderTypeName(long _nType)
        {
            string _typeName = "";

            switch (_nType)
            {
                case 0:
                    _typeName = "出院";
                    break;
                case 1:
                    _typeName = "西药";
                    break;
                case 2:
                    _typeName = "成药";
                    break;
                case 3:
                    _typeName = "草药";
                    break;
                case 4:
                    _typeName = "治疗";
                    break;
                case 5:
                    _typeName = "医技";
                    break;
                case 6:
                    _typeName = "手术";
                    break;
                case 7:
                    _typeName = "说明";
                    break;
                case 8:
                    _typeName = "护理";
                    break;
                case 9:
                    _typeName = "其他";
                    break;
            }

            return _typeName;
        }

        private void cb显示已删除费用_CheckedChanged(object sender, System.EventArgs e)
        {
            ShowData();
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            string sSql = "";
            string strSql = "";
            DataTable myTempTb = new DataTable();
            DataTable decoctTb = new DataTable();
            Guid n_id = Guid.Empty;
            string msg = "";
            int iYZH = 0;

            if (MessageBox.Show(this, "确认要增加草药煎药费吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            strSql = "select id,order_id from zy_decoct where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                " and group_id=" + Group_ID;
            decoctTb = FrmMdiMain.Database.GetDataTable(strSql);

            if (decoctTb.Rows.Count > 0)
            {
                n_id = new Guid(decoctTb.Rows[0][0].ToString().Trim());
            }
            else
            {
                n_id = PubStaticFun.NewGuid();
                strSql = "insert into zy_decoct(id,inpatient_id,order_id,group_id,jgbm) values ('" + n_id + "','" + ClassStatic.Current_BinID + "','" + Guid.Empty + "'," + Group_ID + "," + FrmMdiMain.Jgbm + ")";
                FrmMdiMain.Database.DoCommand(strSql);

                if (n_id == null || n_id == Guid.Empty)
                {
                    MessageBox.Show("插入ZY_DECOCT的id为空值，无法更新数据！");
                    return;
                }
            }

            //取煎药费
            sSql = @"Select a.order_id,a.order_name,a.order_unit,a.order_type,a.default_dept " +
            " from jc_hoitemdiction a " +
            " where a.order_id=" + new SystemCfg(7014).Config;
            myTempTb = FrmMdiMain.Database.GetDataTable(sSql);
            //如果没有设置煎药费代码，将不插入煎药费
            if (myTempTb.Rows.Count == 0 || myTempTb == null)
            {
                MessageBox.Show("没有设置煎药费代码，请手工输入煎药费！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                decimal v_hoitem_id = Convert.ToDecimal(myTempTb.Rows[0]["order_id"].ToString());
                string v_order_context = myTempTb.Rows[0]["order_name"].ToString().Trim();
                string v_unit = myTempTb.Rows[0]["order_unit"].ToString().Trim();
                int v_order_type = Convert.ToInt32(myTempTb.Rows[0]["order_type"].ToString().Trim());
                long v_exec_dept = 0;

                //如果没有执行科室，则是病人科室
                if (myTempTb.Rows[0]["default_dept"].ToString().Trim() == ""
                    || myTempTb.Rows[0]["default_dept"].ToString().Trim() == "0"
                    || myTempTb.Rows[0]["default_dept"].ToString().Trim() == "-1"
                    || myTempTb.Rows[0]["default_dept"].ToString().Trim() == "1")
                {
                    v_exec_dept = ClassStatic.Current_DeptID;//Convert.ToInt64(myTb.Rows[i]["dept_br"]);
                }
                else
                {
                    v_exec_dept = Convert.ToInt64(myTempTb.Rows[0]["default_dept"]);
                }

                //取组号
                sSql = @"select max(Group_Id) as YZH " +
                    "  from Zy_OrderRecord " +
                    " where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                    "       and baby_id=" + ClassStatic.Current_BabyID;
                myTempTb = FrmMdiMain.Database.GetDataTable(sSql);
                if (myTempTb.Rows[0]["YZH"].ToString().Trim() == "")
                {
                    iYZH = 0;
                }
                else
                {
                    iYZH = Convert.ToInt32(myTempTb.Rows[0]["YZH"]) + 1;
                }

                //				//生成数据访问对象
                //				RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
                //				database.Initialize("");
                //				database.Open();				
                //				//开始一个事物
                //				database.BeginTransaction();

                FrmMdiMain.Database.BeginTransaction();

                try
                {
                    Guid v_O_id = PubStaticFun.NewGuid();
                    //插入医嘱记录表
                    strSql = @"INSERT INTO ZY_ORDERRECORD( " +
                        "order_id,jgbm,INPATIENT_ID,Baby_ID,WARD_ID,DEPT_BR,DEPT_ID, " +
                        "MNGTYPE,ORDER_BDATE,GROUP_ID,NTYPE, " +
                        "HOITEM_ID,xmly,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_USAGE,FREQUENCY, " +
                        "EXEC_DEPT,FIRST_TIMES,STATUS_FLAG, " +
                        "AUDITING_USER,AUDITING_DATE,OPERATOR,BOOK_DATE,SERIAL_NO ) " +
                        "VALUES('" + v_O_id + "'," + FrmMdiMain.Jgbm + ", '" + ClassStatic.Current_BinID + "'," + ClassStatic.Current_BabyID +
                        ",'" + FrmMdiMain.CurrentDept.WardId + "'," + ClassStatic.Current_DeptID + "," + ClassStatic.Current_DeptID +
                        ",3,getdate()," + iYZH.ToString() + "," + v_order_type + "," +
                        v_hoitem_id + ",2,'" + v_order_context + "'," + lb22.Text + ",1,'" + v_unit + "','',''," +
                        v_exec_dept + ", 1,2," +
                        FrmMdiMain.CurrentUser.EmployeeId.ToString() + ",getdate() ," + FrmMdiMain.CurrentUser.EmployeeId.ToString() + ",getdate(),0)";

                    FrmMdiMain.Database.DoCommand(strSql);

                    if (v_O_id == null || v_O_id == Guid.Empty)
                    {
                        throw new Exception("没有生成Order_id，无法更新数据！");
                    }

                    strSql = "update zy_decoct set order_id='" + v_O_id + "' where id='" + n_id + "'";
                    FrmMdiMain.Database.DoCommand(strSql);

                    FrmMdiMain.Database.CommitTransaction();

                    MessageBox.Show("增加草药煎药费成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmYZXX_Load(null, null);
                }
                catch (Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();

                    //写错误日志 Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, Convert.ToInt32(FrmMdiMain.CurrentUser.EmployeeId), "程序错误", "医嘱转抄错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show("错误：将煎药费插入临时账单错误，请手工生成煎药费！\n系统：" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                //				finally
                //				{
                //					database.Close();
                //				}
            }
        }

        private void contextMenu1_Popup(object sender, System.EventArgs e)
        {
            if (cfg7207.Config == "0")
            {
                if (this.nType != 3 || lb24.Text.IndexOf("自煎") >= 0 || isCX || isUNCZ)
                {
                    menuItem1.Enabled = false;
                }
                else
                {
                    menuItem1.Enabled = true;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "费用汇总")
            {
                DataTable myTb = (DataTable)myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count < 1) return;

                DataTable myTb1 = myTb.Clone();

                string _tmp = "";

                if (rbAll.Checked)
                    _tmp = "";

                if (rbCharge.Checked)
                    _tmp = " and charge_bit=1";

                if (rbUncharge.Checked)
                    _tmp = " and charge_bit=0";


                DataRow[] drM = myTb.Select("delete_bit=0 " + _tmp);

                for (int i = 0; i < drM.Length; i++)
                {
                    DataRow myRow = myTb1.NewRow();
                    myRow.ItemArray = drM[i].ItemArray;
                    myRow["数量"] = Convert.ToDecimal(myRow["数量"]) * Convert.ToDecimal(myRow["次数"]) * Convert.ToDecimal(myRow["剂数"]);
                    myTb1.Rows.Add(myRow.ItemArray);
                }

                string[] GroupbyField ={ "名称", "单位", "单价" };
                string[] ComputeField ={ "数量", "金额" };
                string[] CField ={ "sum", "sum" };

                TsSet tsset = new TsSet();
                tsset.TsDataTable = myTb1;

                string[] GroupbyField1 ={ };
                string[] ComputeField1 ={ "金额" };
                string[] CField1 ={ "sum" };

                TsSet tsset1 = new TsSet();
                tsset1.TsDataTable = myTb1;

                //汇总每个统领分类
                DataTable tb = tsset.GroupTable(GroupbyField, ComputeField, CField, "", false);

                DataTable tb1 = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "", false);

                DataRow dr = tb.NewRow();
                dr["名称"] = "合计";
                dr["金额"] = tb1.Rows.Count > 0 ? tb1.Rows[0]["金额"] : 0;

                tb.Rows.Add(dr);

                dataGridEx1.DataSource = tb;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count < 1) return;
            bool zc = false;
            try
            {
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ID"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                    {
                        //如果满足条件
                        string sql = "select * from ZY_FEE_SPECI    where XMLY=1  and charge_bit=0 and DELETE_BIT=0 and CZ_FLAG in(2) and SCBZ=0 and FY_BIT=0 and id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                        DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                        if (tb.Rows.Count > 0)
                        {
                            FrmMdiMain.Database.DoCommand("   update ZY_FEE_SPECI set DELETE_BIT=1,BZ=isnull(BZ,'')+'手动取消删除' where  id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'");
                            FrmMdiMain.Database.DoCommand("   update ZY_FEE_SPECI set  cz_flag=0 where  id='" + tb.Rows[0]["cz_ID"].ToString().Trim() + "'");
                            zc = true;
                        }
                        else
                        {
                            MessageBox.Show("该操作只允许【没有发药】并且【没有医保上传】的退药记录");
                            this.ShowData();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                if (zc)
                    this.ShowData();
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbsl.Checked)
                label17.Text = "";
            else
                label17.Text = "次";
        }

        //add by jchl(7603=0参数和is_PvsScn=1 return false)
        private bool CanOrderRecCz(string isPvsScn)
        {
            SystemCfg cfg7603 = new SystemCfg(7603);

            //7603=0参数和is_PvsScn=1   不允许冲正
            if (cfg7603.Config.Trim().Equals("0") && isPvsScn.Trim().Equals("1"))
                return false;

            return true;
        }

        private bool IsPvsDept(string execDept)
        {
            try
            {
                string strSql = string.Format(@"select count(1) as NUM from JC_DEPT_DRUGSTORE where DRUGSTORE_ID='{0}' and is_PvsRel=1", execDept);

                string num = FrmMdiMain.Database.GetDataResult(strSql).ToString().Trim();
                int iNum = int.Parse(num);

                if (iNum > 0)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void btnZdb_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;


            string bdate = _cfg6227.Config.Trim();
            if (!string.IsNullOrEmpty(bdate))
            {
                bdate = DateTime.Now.ToString("yyyy-MM-dd") + " " + bdate;

                try
                {
                    string[] strs = _cfg6228.Config.Split('$');
                    int iHour = int.Parse(strs[0].Trim());
                    int iMin = int.Parse(strs[1].Trim());

                    DateTime kssBDate = DateTime.Parse(bdate);
                    DateTime kssEDate = kssBDate.AddHours(iHour).AddMinutes(iMin);

                    if (DateTime.Compare(kssBDate, DateTime.Now) < 0 && DateTime.Compare(kssEDate, DateTime.Now) > 0)
                    {
                        MessageBox.Show("根据静脉用药集中调配中心的要求，该时间段（" + kssBDate.ToShortTimeString() + "-" + kssEDate.ToShortTimeString() + "）不允许操作转打包", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch { }
            }

            string ss = "";
            bool bShowZdb = false;
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (myTb.Rows[i]["记账类型"].ToString().Trim().Equals("冲帐费用"))
                    {
                        ss += myTb.Rows[i]["医嘱日期"].ToString() + ":" + myTb.Rows[i]["内容"].ToString() + " , ";
                        bShowZdb = true;
                    }
                }
            }

            if (bShowZdb)
            {
                MessageBox.Show(ss + "\n 已经冲正的费用,不能进行转打包操作\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ShowData();
                return;
            }


            if (MessageBox.Show(this, "确认选择的每组医嘱转打包吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //ArrayList row = new ArrayList();
            //string ss = "";
            ////已经进仓扫描了不允许转打包操作
            //for (int i = 0; i < myTb.Rows.Count; i++)
            //{
            //    if (myTb.Rows[i]["选"].ToString() == "True")
            //    {
            //        string id = myTb.Rows[i]["ID"].ToString();
            //        string strSql = string.Format(@"select count(1) as Num from ZY_FEE_SPECI where ID='{0}' and is_PvsScn=1", id);

            //        string num = FrmMdiMain.Database.GetDataResult(strSql).ToString().Trim();
            //        int iNum = int.Parse(num);

            //        if (iNum > 0)
            //        {
            //            row.Add(i);
            //            ss += myTb.Rows[i]["医嘱日期"].ToString() + ":" + myTb.Rows[i]["内容"].ToString() + " , ";
            //            continue;
            //        }

            //        //
            //        strSql = string.Format(@"update ZY_FEE_SPECI set pvs_zdb=1 where id='{0}'", id);
            //        FrmMdiMain.Database.DoCommand(strSql);
            //    }
            //}

            //if (row.Count > 0)
            //{
            //    MessageBox.Show(ss + "\n 药单已经扫描进仓,不能转打包操作\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.ShowData();
            //    return;
            //}

            //MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Cursor.Current = Cursors.Default;

            //this.ShowData();

            DoSetZDB(myTb);
        }

        /// <summary>
        /// 取消转打包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;


            if (MessageBox.Show(this, "确认选择的每组医嘱 取消转打包 吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            ArrayList row = new ArrayList();
            string ss = "";
            //已经进仓扫描了不允许转打包操作
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    string id = myTb.Rows[i]["ID"].ToString();
                    string strSql = string.Format(@"select count(1) as Num from ZY_FEE_SPECI where ID='{0}' and is_PvsScn=1", id);

                    string num = FrmMdiMain.Database.GetDataResult(strSql).ToString().Trim();
                    int iNum = int.Parse(num);

                    if (iNum > 0)
                    {
                        row.Add(i);
                        ss += myTb.Rows[i]["医嘱日期"].ToString() + ":" + myTb.Rows[i]["内容"].ToString() + " , ";
                        continue;
                    }

                    //
                    strSql = string.Format(@"update ZY_FEE_SPECI set pvs_zdb=0 where id='{0}'", id);
                    FrmMdiMain.Database.DoCommand(strSql);
                }
            }

            if (row.Count > 0)
            {
                MessageBox.Show(ss + "\n 药单已经扫描进仓,不能 取消转打包 操作\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ShowData();
                return;
            }

            MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;

            this.ShowData();
        }

        private bool DoVaildYbFee(DataTable myTb, string BinID, out string strMsg)
        {
            BmiAuditClass class2 = new BmiAuditClass();
            ClsAuditCheck check = new ClsAuditCheck(FrmMdiMain.Database);
            strMsg = "";
            string str = "";

            string yblx = "";
            string ybzlx = "";
            string zyh = "";
            try
            {
                string inAGENCIES_ID = "";
                string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID ='{0}' ", BinID.ToString());
                try
                {
                    DataTable dtInp = InstanceForm.BDatabase.GetDataTable(ssql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("未找到该住院号的病人信息\r");

                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                    zyh = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
                    if (yblx.Equals("1"))
                    {
                        inAGENCIES_ID = "1";
                    }
                    else if (yblx.Equals("3") && ybzlx.Equals("55"))
                    {
                        inAGENCIES_ID = "2";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("未找到该住院号的病人信息\r" + ex.Message);
                }

                string str4;
                DataTable table = this.DoGetValidateFeeInfo(myTb);
                DataTable postFeeInfo = check.GetPostFeeInfo(table);
                decimal num = 0M;
                DataTable detailFeeInfo = check.GetDetailFeeInfo(postFeeInfo, yblx, ybzlx, out num);


                //string commandtext = string.Format("select INPATIENT_NO from ZY_INPATIENT where INPATIENT_ID='{0}'", BinID.ToString());
                //string str3 = FrmMdiMain.Database.GetDataResult(commandtext).ToString();


                DataTable table4 = ClsAuditCheck.RetAfSetMainInfo(BinID.ToString(), zyh, num, FrmMdiMain.Database);
                str = class2.ClaimAudit4Hospital_N(table4, detailFeeInfo);
                if (str.Equals("0") || str.Equals("2"))
                {
                    str4 = str.Equals("0") ? "医保智审：审核失败！" : "医保智审：调用步骤出错！";
                    throw new Exception(str4 + "\r\r请手动上传该病人费用到中公网！");
                }
                if (str.Equals("3"))
                {
                    str = class2.ClaimAudit4Hospital_S(table4, detailFeeInfo);
                    str4 = str.Equals("0") ? "医保智审：审核失败！" : "医保智审：调用步骤出错！";
                    if (str.Equals("0") || str.Equals("2"))
                    {
                        throw new Exception("数据保存成功,上传中公网数据成功！ \r\t 医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用,再手动上传该病人所有费用到中公网！");
                    }
                    bool flag = check.UpdateScbz(detailFeeInfo);
                    throw new Exception("数据保存成功,上传中公网数据成功," + (flag ? "成功更新本地标识" : "失败更新本地标识") + "！\r\t医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用！ \r\t请在 问题数据处理界面 重新查看该医嘱");
                }
                strMsg = "";
                if (!check.UpdateScbz(detailFeeInfo))
                {
                    throw new Exception("数据保存成功,上传中公网数据成功,失败更新本地标识！请手动上传该病人费用！");
                }
                return true;
            }
            catch (Exception exception)
            {
                strMsg = exception.Message;
                this.myFunc.SaveLog((long)FrmMdiMain.CurrentDept.DeptId, (long)FrmMdiMain.CurrentUser.EmployeeId, "医保智审上传数据错误", BinID.ToString() + "医保智审数据上传错误：" + exception.Message.ToString().Trim(), 1, 4);
                return false;
            }
        }

        private bool DoVaildYbFee(DataTable myTb, long MNGType, Guid BinID, long BabyId, out string strMsg)
        {
            BmiAuditClass class2 = new BmiAuditClass();
            ClsAuditCheck check = new ClsAuditCheck(FrmMdiMain.Database);
            strMsg = "";
            string str = "";

            string yblx = "";
            string ybzlx = "";
            string zyh = "";
            try
            {
                string inAGENCIES_ID = "";
                string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID ='{0}' ", BinID.ToString());
                try
                {
                    DataTable dtInp = InstanceForm.BDatabase.GetDataTable(ssql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("未找到该住院号的病人信息\r");

                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                    zyh = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
                    if (yblx.Equals("1"))
                    {
                        inAGENCIES_ID = "1";
                    }
                    else if (yblx.Equals("3") && ybzlx.Equals("55"))
                    {
                        inAGENCIES_ID = "2";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("未找到该住院号的病人信息\r" + ex.Message);
                }

                string str4;
                DataTable table = this.DoGetValidateFeeInfo(myTb);
                DataTable table2 = check.GetPostFeeInfo(table, (int)MNGType, 1, BinID, BabyId);
                decimal num = 0M;
                DataTable detailFeeInfo = check.GetDetailFeeInfo(table2, yblx, ybzlx, out num);

                //string commandtext = string.Format("select INPATIENT_NO from ZY_INPATIENT where INPATIENT_ID='{0}'", BinID.ToString());
                //string str3 = FrmMdiMain.Database.GetDataResult(commandtext).ToString();

                DataTable table4 = ClsAuditCheck.RetAfSetMainInfo(BinID.ToString(), zyh, num, FrmMdiMain.Database);
                str = class2.ClaimAudit4Hospital_N(table4, detailFeeInfo);
                if (str.Equals("0") || str.Equals("2"))
                {
                    //str4 = str.Equals("0") ? "医保智审：审核失败！" : "医保智审：调用步骤出错！";
                    //throw new Exception(str4 + " \r\t 请手动上传该病人费用到中公网！");
                    ///返回： 0：审核失败
                    //1：审核结果正常
                    //2：调用步骤出错
                    //3：审核结果有违规（取消）
                    //4：审核结果有违规（保存）；申明方法如下：
                    string err = (str.Equals("0") ? "医保智审【审核失败！】" : "医保智审【调用步骤出错！】");
                    err = err + "\r\r返回原因：" + class2.l_error_message;
                    throw new Exception(err + "\r\r请手动上传该病人费用到中公网！");
                }
                if (str.Equals("3"))
                {
                    str = class2.ClaimAudit4Hospital_S(table4, detailFeeInfo);
                    str4 = str.Equals("0") ? "医保智审【审核失败！】" : "医保智审【调用步骤出错！】";
                    if (str.Equals("0") || str.Equals("2"))
                    {
                        throw new Exception("数据保存成功,上传中公网数据成功！ \r\r 医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用,再手动上传该病人所有费用到中公网！");
                    }
                    bool flag = check.UpdateScbz(detailFeeInfo);
                    throw new Exception("数据保存成功,上传中公网数据成功," + (flag ? "成功更新本地标识" : "失败更新本地标识") + "！\r\r医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用！ \r\r请在 问题数据处理界面 重新查看该医嘱");
                }
                strMsg = "";
                if (!check.UpdateScbz(detailFeeInfo))
                {
                    throw new Exception("数据保存成功,上传中公网数据成功,失败更新本地标识！请手动上传该病人费用！");
                }
                return true;
            }
            catch (Exception exception)
            {
                strMsg = exception.Message;
                this.myFunc.SaveLog((long)FrmMdiMain.CurrentDept.DeptId, (long)FrmMdiMain.CurrentUser.EmployeeId, "医保智审上传数据错误", BinID.ToString() + "医保智审数据上传错误：" + exception.Message.ToString().Trim(), 1, 4);
                return false;
            }
        }

        private DataTable DoGetValidateFeeInfo(DataTable myTb)
        {
            try
            {
                DataTable table = myTb.Clone();
                for (int i = 0; i <= (myTb.Rows.Count - 1); i++)
                {
                    if ((myTb.Rows[i]["ID"].ToString().Trim() != "") && (myTb.Rows[i]["选"].ToString() == "True"))
                    {
                        table.ImportRow(myTb.Rows[i]);
                    }
                }
                return table;
            }
            catch
            {
                throw new Exception("输出有效的需要 进行医保智审的数据 的医嘱费用出错 ");
            }
        }

        private void DoSetZDB(DataTable myTb)
        {
            try
            {
                //写死pivas科室
                long pvsDept = 598;
                //写死pivas转到【住院药房(后湖)：359】
                long execYf = 359;
                int iSelectRows = 0;
                int msgType = 0;
                //DataTable myTb = new DataTable();
                string msg = "";
                string sMsg = "";
                string sSql = "";

                if (myTb == null || myTb.Rows.Count == 0)
                    return;

                #region 执行科室Pivas才能转打包
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["选"].ToString() == "True" && (!myTb.Rows[i]["EXECDEPT_ID"].ToString().Equals(pvsDept.ToString())))
                    {
                        MessageBox.Show(this, myTb.Rows[i]["名称"].ToString().Trim() + "：非静脉用药集中调配中心药房的药品不允许转打包！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                #endregion

                #region 是否已经记账【非记账费用才能转打包】
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["选"].ToString() == "True")
                    {
                        if (myTb.Rows[i]["CHARGE_BIT"].ToString().Equals("0"))
                        {
                            bool bRealCharged = false;

                            sSql = string.Format(@"select CHARGE_BIT from ZY_FEE_SPECI where id='{0}'", myTb.Rows[i]["id"].ToString());

                            string sChargeBit = InstanceForm.BDatabase.GetDataResult(sSql).ToString().Trim();
                            bRealCharged = !sChargeBit.Equals("0");

                            if (bRealCharged)
                            {
                                MessageBox.Show(this, myTb.Rows[i]["名称"].ToString().Trim() + "：已记账费用不允许转打包！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.ShowData();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, myTb.Rows[i]["名称"].ToString().Trim() + "：已记账费用不允许转打包！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                #endregion

                #region 是否选择消息
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["选"].ToString() == "True")
                    {
                        iSelectRows += 1;
                    }
                }

                if (iSelectRows == 0)
                {
                    MessageBox.Show(this, "对不起，没有选择消息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                msg = "是否需要将选定的药品转发到 ［住院药房(后湖)］ ？";

                if (MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                ////Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
                //if (new SystemCfg(7066).Config == "0")
                //{
                //    frmInPassword f1 = new frmInPassword();
                //    f1.ShowDialog();
                //    bool isHSZ = f1.isHSZ;
                //    if (f1.isLogin == false) return;
                //}

                Cursor.Current = PubStaticFun.WaitCursor();
                System.DateTime BookDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                #region 更改执行科室

                #region 判断 非统领分类非大输液药品 的有效性
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                    {
                        //Modify by jchl:2016-08-04  处理非统领分类非大输液 校验
                        if (!myTb.Rows[i]["tlfl"].ToString().Trim().Equals("03"))
                        {
                            sSql = "Select a.kcl yfkcl,b.num*a.dwbl/b.unitrate num,a.dwbl,b.unitrate from YF_KCMX a inner join zy_fee_speci b on a.cjid=b.xmid where a.bdelete=0 and b.id='" + myTb.Rows[i]["id"].ToString().Trim() + "' and a.deptid=" + execYf;
                            DataTable medTb = InstanceForm.BDatabase.GetDataTable(sSql);

                            if (medTb == null || medTb.Rows.Count == 0)
                            {
                                sMsg += " ⊙ " + myTb.Rows[i]["名称"].ToString().Trim() + "\n";
                            }
                            else if (Convert.ToInt32(medTb.Rows[0]["unitrate"]) > 1 && Convert.ToInt32(medTb.Rows[0]["unitrate"]) != Convert.ToInt32(medTb.Rows[0]["dwbl"]))//如果单位系数大于1（说明开的是小单位），并且不等于对方药房的单位比例，不允许发
                            {
                                sMsg += " ⊙ " + myTb.Rows[i]["名称"].ToString().Trim() + " [ 原药房与对应药房的拆零单位不相同 ]\n";
                            }
                            else if (Convert.ToDecimal(medTb.Rows[0]["num"]) > Convert.ToDecimal(medTb.Rows[0]["yfkcl"]))
                            {
                                sMsg += " ⊙ " + myTb.Rows[i]["名称"].ToString().Trim() + " [ 数量：" + medTb.Rows[0]["num"].ToString().Trim() + " ] 大于 [ 库存量：" + medTb.Rows[0]["yfkcl"].ToString().Trim() + "] \n";
                            }
                        }
                    }
                }

                if (sMsg.Trim() != "")
                {
                    MessageBox.Show("下列药品因为所更改的执行科室中没有该种药品或库存不够，将不能被发送，请重新选择后再发送！\n不能更改执行科室的药品包括：\n\n" + sMsg,
                        "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                InstanceForm.BDatabase.BeginTransaction();

                try
                {
                    //选中的医嘱
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                        {
                            if (Convert.ToDecimal(myTb.Rows[i]["数量"]) < 0)
                            {
                                msgType = 1;
                            }
                            else
                            {
                                msgType = 0;
                            }

                            if (!myTb.Rows[i]["tlfl"].ToString().Trim().Equals("03"))
                            {
                                sSql = "update zy_fee_speci set execdept_id=" + execYf + ",apply_id=DBO.FUN_GETEMPTYGUID(),tlfs=2,pvs_zdb=1  " +
                                    " where delete_bit=0 and fy_bit=0 and id ='" + myTb.Rows[i]["id"].ToString().Trim() + "'";
                                InstanceForm.BDatabase.DoCommand(sSql);

                                sSql = "update zy_prescription set execdept_id=" + execYf +
                                    " where id in (select prescription_id from zy_fee_speci " +
                                    " where id ='" + myTb.Rows[i]["id"].ToString().Trim() + "')";
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                            else
                            {
                                //大输液处理
                                long execDsyYf = 672;
                                string strDept = myTb.Rows[i]["DEPT_ID"].ToString().Trim();
                                int fyBit = 5;

                                sSql = string.Format(@"SELECT count(1) as Num FROM SS_DEPT where deptid='{0}'", strDept);
                                int iSsNum = int.Parse(InstanceForm.BDatabase.GetDataResult(sSql).ToString());
                                if (iSsNum > 0)
                                {
                                    fyBit = 0;//手术室大输液发药标志
                                }
                                else
                                {
                                    fyBit = 5;//非手术室开单的大输液发药标志
                                }

                                sSql = "update zy_fee_speci set execdept_id=" + execDsyYf + ",apply_id=DBO.FUN_GETEMPTYGUID(),tlfs=0,pvs_zdb=1 ,CHARGE_DATE=getdate(),CHARGE_BIT=1,FY_BIT=" + fyBit +
                                    " where delete_bit=0 and fy_bit=0 and id ='" + myTb.Rows[i]["id"].ToString().Trim() + "'";
                                InstanceForm.BDatabase.DoCommand(sSql);

                                sSql = "update zy_prescription set execdept_id=" + execDsyYf +
                                    " where id in (select prescription_id from zy_fee_speci " +
                                    " where id ='" + myTb.Rows[i]["id"].ToString().Trim() + "')";
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                        }
                    }

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();

                    //写错误日志 Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "重新发送药品更改执行科室错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                #endregion

                string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    //新统领药品（领药）消息 Modify By Tany 2005-09-13
                    myFunc.SendYPFY(2, 0, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, BookDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);

                    ////新统领药品（退药）消息 Modify By Tany 2005-09-13
                    //myFunc.SendYPFY(2, 1, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, BookDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                }

                //写日志 Add By Tany 2005-01-12
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "重新发送药品", "BookDate=" + BookDate.ToString(), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                Cursor.Current = Cursors.Default;
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.ShowData();
            }
            catch (Exception ex)
            {
                this.ShowData();
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
