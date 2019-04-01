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
using Crownwood.Magic.Docking;
using Crownwood.Magic.Common;
using System.IO;
using Trasen.jqg.Print.Interface;
using Trasen.jqg.Print;
using grproLib;
using ts_zyhs_yzgl;
using System.Text;
namespace ts_zyhs_yzzc
{
    /// <summary>
    /// Form2 的摘要说明。
    /// </summary>
    public class frmYZZC : System.Windows.Forms.Form
    {
        private BaseFunc myFunc;

        /// <summary>
        /// 停检验医嘱时，是否提示相应执行科室已经停止 0=否 1=是
        /// </summary>
        private SystemCfg cfg7154 = new SystemCfg(7154);
        private string sPaint = "";
        private int max_len0 = 0, max_len1 = 0, max_len2 = 0;//最长的医嘱长度,最长的医嘱长度(有数量单位的),最长的数量单位长度	
        private Guid old_BinID = Guid.Empty;
        private long old_BabyID = 0;
        private int Kind = 0;    // 0新医嘱  1未转抄  2已转炒  3未核对   4已核对  5未查对  6已查对 
        DataTable outTb = new DataTable();
        DockingManager _dockingManager;
        // 床号 住院号 姓名 日期 时间 医生 类型 医嘱内容 次 转抄护士 核对护士 执行科室 类别 USAGE
        /// <summary>
        /// 住院是否启用费用确认（除医技项目外）
        /// </summary>
        private SystemCfg cfg7212 = new SystemCfg(7212);

        private System.Windows.Forms.Panel panel上;
        private System.Windows.Forms.Panel panel下;
        private System.Windows.Forms.Button bt退出;
        private 病人信息.PatientInfo patientInfo1;
        private 价格信息.PriceInfo priceInfo1;
        private System.Windows.Forms.Button btOpenModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel医嘱;
        private System.Windows.Forms.RadioButton rb所有病人;
        private System.Windows.Forms.RadioButton rb选定病人;
        private System.Windows.Forms.Button bt反选;
        private System.Windows.Forms.Button bt全选;
        private System.Windows.Forms.Button bt显示切换;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.Button bt查询;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button bt转抄;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DataGridEx myDataGrid3;
        private DataGridTableStyle dataGridTableStyle2;
        private Panel panel病人;
        private Button bt反选1;
        private Button bt全选1;
        private DataGridEx dataGridEx1;
        private DataGridTableStyle dataGridTableStyle3;
        private Button btnMsg;
        private Button btn_yzdy;
        private IContainer components;
        SystemCfg cfg7048 = new SystemCfg(7048);
        SystemCfg cfg7169 = new SystemCfg(7169);
        private Button btnRefuse;
        private UcShowCard ucShowCard1;
        private Label label3;
        /// <summary>
        /// 皮试医嘱转抄时是否更改皮试药品医嘱开始时间 0=否 1=是
        /// </summary>
        private SystemCfg cfg7165 = new SystemCfg(7165);
        public frmYZZC(string _formText, int _kind)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            Kind = _kind;
            this.Text = _formText;


            myFunc = new BaseFunc();

            DockingPanel();
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
            this.panel上 = new System.Windows.Forms.Panel();
            this.panel病人 = new System.Windows.Forms.Panel();
            this.ucShowCard1 = new ts_zyhs_classes.UcShowCard();
            this.bt反选1 = new System.Windows.Forms.Button();
            this.bt全选1 = new System.Windows.Forms.Button();
            this.dataGridEx1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.panel医嘱 = new System.Windows.Forms.Panel();
            this.btn_yzdy = new System.Windows.Forms.Button();
            this.btnMsg = new System.Windows.Forms.Button();
            this.rb所有病人 = new System.Windows.Forms.RadioButton();
            this.rb选定病人 = new System.Windows.Forms.RadioButton();
            this.bt反选 = new System.Windows.Forms.Button();
            this.bt全选 = new System.Windows.Forms.Button();
            this.bt显示切换 = new System.Windows.Forms.Button();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel下 = new System.Windows.Forms.Panel();
            this.btnRefuse = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.patientInfo1 = new 病人信息.PatientInfo();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bt查询 = new System.Windows.Forms.Button();
            this.bt退出 = new System.Windows.Forms.Button();
            this.bt转抄 = new System.Windows.Forms.Button();
            this.btOpenModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.myDataGrid3 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.priceInfo1 = new 价格信息.PriceInfo();
            this.label3 = new System.Windows.Forms.Label();
            this.panel上.SuspendLayout();
            this.panel病人.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).BeginInit();
            this.panel医嘱.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel下.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel上
            // 
            this.panel上.Controls.Add(this.panel病人);
            this.panel上.Controls.Add(this.panel医嘱);
            this.panel上.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel上.Location = new System.Drawing.Point(0, 0);
            this.panel上.Name = "panel上";
            this.panel上.Size = new System.Drawing.Size(1008, 468);
            this.panel上.TabIndex = 1;
            // 
            // panel病人
            // 
            this.panel病人.Controls.Add(this.ucShowCard1);
            this.panel病人.Controls.Add(this.bt反选1);
            this.panel病人.Controls.Add(this.bt全选1);
            this.panel病人.Controls.Add(this.dataGridEx1);
            this.panel病人.Location = new System.Drawing.Point(82, 56);
            this.panel病人.Name = "panel病人";
            this.panel病人.Size = new System.Drawing.Size(206, 333);
            this.panel病人.TabIndex = 90;
            // 
            // ucShowCard1
            // 
            this.ucShowCard1.IType = 0;
            this.ucShowCard1.Key = "";
            this.ucShowCard1.Location = new System.Drawing.Point(5, 1);
            this.ucShowCard1.Name = "ucShowCard1";
            this.ucShowCard1.Row = null;
            this.ucShowCard1.Size = new System.Drawing.Size(113, 21);
            this.ucShowCard1.TabIndex = 88;
            this.ucShowCard1.Value = "";
            this.ucShowCard1.MyDelEvent += new ts_zyhs_classes.UcShowCard.MyDel(this.ucShowCard1_MyDelEvent);
            // 
            // bt反选1
            // 
            this.bt反选1.BackColor = System.Drawing.Color.PaleGreen;
            this.bt反选1.Location = new System.Drawing.Point(163, 1);
            this.bt反选1.Name = "bt反选1";
            this.bt反选1.Size = new System.Drawing.Size(37, 20);
            this.bt反选1.TabIndex = 85;
            this.bt反选1.Text = "反选";
            this.bt反选1.UseVisualStyleBackColor = false;
            this.bt反选1.Click += new System.EventHandler(this.bt反选1_Click);
            // 
            // bt全选1
            // 
            this.bt全选1.BackColor = System.Drawing.Color.PaleGreen;
            this.bt全选1.Location = new System.Drawing.Point(122, 1);
            this.bt全选1.Name = "bt全选1";
            this.bt全选1.Size = new System.Drawing.Size(37, 20);
            this.bt全选1.TabIndex = 84;
            this.bt全选1.Text = "全选";
            this.bt全选1.UseVisualStyleBackColor = false;
            this.bt全选1.Click += new System.EventHandler(this.bt全选1_Click);
            // 
            // dataGridEx1
            // 
            this.dataGridEx1.AllowSorting = false;
            this.dataGridEx1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridEx1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridEx1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridEx1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridEx1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridEx1.DataMember = "";
            this.dataGridEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEx1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridEx1.Name = "dataGridEx1";
            this.dataGridEx1.ReadOnly = true;
            this.dataGridEx1.RowHeaderWidth = 5;
            this.dataGridEx1.Size = new System.Drawing.Size(206, 333);
            this.dataGridEx1.TabIndex = 86;
            this.dataGridEx1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dataGridEx1.CurrentCellChanged += new System.EventHandler(this.dataGridEx1_CurrentCellChanged);
            this.dataGridEx1.Click += new System.EventHandler(this.dataGridEx1_Click);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AllowSorting = false;
            this.dataGridTableStyle3.DataGrid = this.dataGridEx1;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.RowHeaderWidth = 5;
            // 
            // panel医嘱
            // 
            this.panel医嘱.Controls.Add(this.label3);
            this.panel医嘱.Controls.Add(this.btn_yzdy);
            this.panel医嘱.Controls.Add(this.btnMsg);
            this.panel医嘱.Controls.Add(this.rb所有病人);
            this.panel医嘱.Controls.Add(this.rb选定病人);
            this.panel医嘱.Controls.Add(this.bt反选);
            this.panel医嘱.Controls.Add(this.bt全选);
            this.panel医嘱.Controls.Add(this.bt显示切换);
            this.panel医嘱.Controls.Add(this.myDataGrid1);
            this.panel医嘱.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel医嘱.Location = new System.Drawing.Point(0, 0);
            this.panel医嘱.Name = "panel医嘱";
            this.panel医嘱.Size = new System.Drawing.Size(1008, 468);
            this.panel医嘱.TabIndex = 1;
            // 
            // btn_yzdy
            // 
            this.btn_yzdy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_yzdy.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_yzdy.Location = new System.Drawing.Point(863, 1);
            this.btn_yzdy.Name = "btn_yzdy";
            this.btn_yzdy.Size = new System.Drawing.Size(86, 20);
            this.btn_yzdy.TabIndex = 81;
            this.btn_yzdy.Text = "医嘱打印";
            this.btn_yzdy.UseVisualStyleBackColor = false;
            this.btn_yzdy.Click += new System.EventHandler(this.btn_yzdy_Click);
            // 
            // btnMsg
            // 
            this.btnMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMsg.BackColor = System.Drawing.Color.PaleGreen;
            this.btnMsg.Location = new System.Drawing.Point(638, 1);
            this.btnMsg.Name = "btnMsg";
            this.btnMsg.Size = new System.Drawing.Size(86, 20);
            this.btnMsg.TabIndex = 83;
            this.btnMsg.Text = "通知医生(&M)";
            this.btnMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMsg.UseVisualStyleBackColor = false;
            this.btnMsg.Visible = false;
            this.btnMsg.Click += new System.EventHandler(this.btnMsg_Click);
            // 
            // rb所有病人
            // 
            this.rb所有病人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb所有病人.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb所有病人.Checked = true;
            this.rb所有病人.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb所有病人.Location = new System.Drawing.Point(559, 3);
            this.rb所有病人.Name = "rb所有病人";
            this.rb所有病人.Size = new System.Drawing.Size(72, 18);
            this.rb所有病人.TabIndex = 82;
            this.rb所有病人.TabStop = true;
            this.rb所有病人.Text = "所有病人";
            this.rb所有病人.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb所有病人.UseVisualStyleBackColor = false;
            // 
            // rb选定病人
            // 
            this.rb选定病人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb选定病人.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb选定病人.Location = new System.Drawing.Point(483, 3);
            this.rb选定病人.Name = "rb选定病人";
            this.rb选定病人.Size = new System.Drawing.Size(72, 18);
            this.rb选定病人.TabIndex = 81;
            this.rb选定病人.Text = "选定病人";
            this.rb选定病人.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb选定病人.UseVisualStyleBackColor = false;
            // 
            // bt反选
            // 
            this.bt反选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt反选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt反选.Location = new System.Drawing.Point(798, 1);
            this.bt反选.Name = "bt反选";
            this.bt反选.Size = new System.Drawing.Size(56, 20);
            this.bt反选.TabIndex = 80;
            this.bt反选.Text = "反选(&F)";
            this.bt反选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt反选.UseVisualStyleBackColor = false;
            this.bt反选.Click += new System.EventHandler(this.bt反选_Click);
            // 
            // bt全选
            // 
            this.bt全选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt全选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt全选.Location = new System.Drawing.Point(733, 1);
            this.bt全选.Name = "bt全选";
            this.bt全选.Size = new System.Drawing.Size(56, 20);
            this.bt全选.TabIndex = 79;
            this.bt全选.Text = "全选(&A)";
            this.bt全选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt全选.UseVisualStyleBackColor = false;
            this.bt全选.Click += new System.EventHandler(this.bt全选_Click);
            // 
            // bt显示切换
            // 
            this.bt显示切换.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt显示切换.BackColor = System.Drawing.Color.PaleGreen;
            this.bt显示切换.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt显示切换.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt显示切换.Location = new System.Drawing.Point(379, 1);
            this.bt显示切换.Name = "bt显示切换";
            this.bt显示切换.Size = new System.Drawing.Size(98, 20);
            this.bt显示切换.TabIndex = 69;
            this.bt显示切换.Text = "显示病人列表";
            this.bt显示切换.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt显示切换.UseVisualStyleBackColor = false;
            this.bt显示切换.Click += new System.EventHandler(this.bt显示切换_Click_1);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "未转抄医嘱（所有）";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(1008, 468);
            this.myDataGrid1.TabIndex = 25;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.myDataGrid1_Paint);
            this.myDataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myDataGrid1_MouseUp);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel下
            // 
            this.panel下.Controls.Add(this.btnRefuse);
            this.panel下.Controls.Add(this.patientInfo1);
            this.panel下.Controls.Add(this.progressBar1);
            this.panel下.Controls.Add(this.bt查询);
            this.panel下.Controls.Add(this.bt退出);
            this.panel下.Controls.Add(this.bt转抄);
            this.panel下.Controls.Add(this.btOpenModel);
            this.panel下.Controls.Add(this.groupBox1);
            this.panel下.Controls.Add(this.myDataGrid3);
            this.panel下.Controls.Add(this.priceInfo1);
            this.panel下.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel下.Location = new System.Drawing.Point(0, 468);
            this.panel下.Name = "panel下";
            this.panel下.Size = new System.Drawing.Size(1008, 124);
            this.panel下.TabIndex = 2;
            // 
            // btnRefuse
            // 
            this.btnRefuse.ContextMenu = this.contextMenu1;
            this.btnRefuse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefuse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefuse.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefuse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefuse.ImageIndex = 9;
            this.btnRefuse.Location = new System.Drawing.Point(887, 8);
            this.btnRefuse.Name = "btnRefuse";
            this.btnRefuse.Size = new System.Drawing.Size(58, 24);
            this.btnRefuse.TabIndex = 67;
            this.btnRefuse.Text = "拒绝(&R)";
            this.btnRefuse.Click += new System.EventHandler(this.btnRefuse_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem10,
            this.menuItem8,
            this.menuItem9});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "新医嘱";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "未转抄医嘱";
            this.menuItem3.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "已转抄医嘱";
            this.menuItem4.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "未核对医嘱";
            this.menuItem6.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 6;
            this.menuItem7.Text = "已核对医嘱";
            this.menuItem7.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 7;
            this.menuItem10.Text = "-";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 8;
            this.menuItem8.Text = "未查对医嘱";
            this.menuItem8.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 9;
            this.menuItem9.Text = "已查对医嘱";
            this.menuItem9.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo1.IsShow = true;
            this.patientInfo1.Location = new System.Drawing.Point(0, 0);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(460, 124);
            this.patientInfo1.TabIndex = 60;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(767, 112);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 8);
            this.progressBar1.TabIndex = 65;
            // 
            // bt查询
            // 
            this.bt查询.ContextMenu = this.contextMenu1;
            this.bt查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt查询.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt查询.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt查询.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt查询.ImageIndex = 9;
            this.bt查询.Location = new System.Drawing.Point(771, 8);
            this.bt查询.Name = "bt查询";
            this.bt查询.Size = new System.Drawing.Size(58, 24);
            this.bt查询.TabIndex = 64;
            this.bt查询.Text = "查询(&C)";
            this.bt查询.Click += new System.EventHandler(this.bt查询_Click);
            // 
            // bt退出
            // 
            this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt退出.ImageIndex = 4;
            this.bt退出.Location = new System.Drawing.Point(945, 8);
            this.bt退出.Name = "bt退出";
            this.bt退出.Size = new System.Drawing.Size(58, 24);
            this.bt退出.TabIndex = 63;
            this.bt退出.Text = "退出(&E)";
            this.bt退出.Click += new System.EventHandler(this.bt退出_Click);
            // 
            // bt转抄
            // 
            this.bt转抄.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt转抄.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt转抄.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt转抄.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt转抄.ImageIndex = 9;
            this.bt转抄.Location = new System.Drawing.Point(829, 8);
            this.bt转抄.Name = "bt转抄";
            this.bt转抄.Size = new System.Drawing.Size(58, 24);
            this.bt转抄.TabIndex = 62;
            this.bt转抄.Text = "转抄(&Z)";
            this.bt转抄.Click += new System.EventHandler(this.bt转抄_Click);
            // 
            // btOpenModel
            // 
            this.btOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenModel.Enabled = false;
            this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenModel.ImageIndex = 1;
            this.btOpenModel.Location = new System.Drawing.Point(767, 0);
            this.btOpenModel.Name = "btOpenModel";
            this.btOpenModel.Size = new System.Drawing.Size(240, 40);
            this.btOpenModel.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpBeginDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(767, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginDate.Enabled = false;
            this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginDate.Location = new System.Drawing.Point(64, 18);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(165, 21);
            this.dtpBeginDate.TabIndex = 10;
            this.dtpBeginDate.Value = new System.DateTime(2003, 9, 27, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(24, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "至：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "从：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(64, 42);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(165, 21);
            this.dtpEndDate.TabIndex = 7;
            this.dtpEndDate.Value = new System.DateTime(2003, 9, 27, 23, 59, 0, 0);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(8, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "按时间查询";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // myDataGrid3
            // 
            this.myDataGrid3.AllowSorting = false;
            this.myDataGrid3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid3.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid3.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid3.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.CaptionText = "项目明细";
            this.myDataGrid3.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid3.DataMember = "";
            this.myDataGrid3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.Location = new System.Drawing.Point(461, 0);
            this.myDataGrid3.Name = "myDataGrid3";
            this.myDataGrid3.ReadOnly = true;
            this.myDataGrid3.RowHeaderWidth = 20;
            this.myDataGrid3.Size = new System.Drawing.Size(304, 124);
            this.myDataGrid3.TabIndex = 66;
            this.myDataGrid3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid3.Visible = false;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid3;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // priceInfo1
            // 
            this.priceInfo1.Dv = null;
            this.priceInfo1.Location = new System.Drawing.Point(459, 0);
            this.priceInfo1.Name = "priceInfo1";
            this.priceInfo1.Order_context = null;
            this.priceInfo1.Size = new System.Drawing.Size(309, 128);
            this.priceInfo1.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(119, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 12);
            this.label3.TabIndex = 84;
            this.label3.Text = "√：审方通过×：审方不通过〇：未审方";
            // 
            // frmYZZC
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1008, 592);
            this.Controls.Add(this.panel上);
            this.Controls.Add(this.panel下);
            this.Name = "frmYZZC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZZC_Load_1);
            this.Activated += new System.EventHandler(this.frmYZZC_Load);
            this.panel上.ResumeLayout(false);
            this.panel病人.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).EndInit();
            this.panel医嘱.ResumeLayout(false);
            this.panel医嘱.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel下.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void DockingPanel()
        {
            _dockingManager = new DockingManager(this, VisualStyle.IDE);

            _dockingManager.InnerControl = panel上;
            _dockingManager.OuterControl = panel下;

            Content content = _dockingManager.Contents.Add(panel病人, "病人列表");

            WindowContent wc = _dockingManager.AddContentWithState(content, State.DockLeft) as WindowContent;

            content.CloseButton = false;
            content.HideButton = true;
            content.DisplaySize = panel病人.Size;
            content.AutoHideSize = panel病人.Size;

            _dockingManager.HideAllContents();
        }

        private void frmYZZC_Load(object sender, System.EventArgs e)
        {
            DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            //服务器当前系统日期
            this.dtpBeginDate.Value = Convert.ToDateTime(now.ToShortDateString() + " 00:00:00");
            this.dtpBeginDate.MinDate = Convert.ToDateTime("2004-7-1 00:00:00");
            this.dtpBeginDate.MaxDate = Convert.ToDateTime(now.ToShortDateString() + " 23:59:59");

            this.dtpEndDate.Value = Convert.ToDateTime(now.ToShortDateString() + " 23:59:59");
            this.dtpEndDate.MinDate = Convert.ToDateTime("2004-7-1 00:00:00");
            this.dtpEndDate.MaxDate = Convert.ToDateTime(now.ToShortDateString() + " 23:59:59");

            //Modify By Tany 2015-02-09 排完再按床号
            string sSql = string.Format(@"  SELECT BED_NO 床号,INPATIENT_NO 住院号,NAME 姓名,INPATIENT_ID,Baby_ID,DEPT_ID
                    FROM vi_zy_vInpatient_Bed WHERE  WARD_ID= '{0}' 
                    order by case when  isnumeric(BED_NO)=1 and SUBSTRING (BED_NO ,0,2)<>'+'   then 1  
                    when PATINDEX('%[吖-座]%',BED_NO)>0 then 2 when SUBSTRING (BED_NO ,0,2)='+' then 3  else  4   end
                    ,case when isnumeric(BED_NO)=1 then cast(bed_no as int) else 999999 end,BED_NO,baby_id", InstanceForm.BCurrentDept.WardId);
            myFunc.ShowGrid(1, sSql, this.dataGridEx1);

            this.dataGridEx1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName1 ={ "选", "床号", "住院号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID" };
            int[] GrdWidth1 ={ 2, 5, 0, 10, 0, 0, 0 };
            int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.dataGridEx1);
            //Modify by jchl
            DataTable dtSrc = dataGridEx1.DataSource as DataTable;
            DoInitCtr(GrdMappingName1, GrdMappingName1, new string[] { "床号", "住院号", "姓名" }, new int[] { 0, 60, 100, 80, 0, 0, 0 }, dtSrc);

            bt全选1_Click(null, null);

            this.Show_Data();
            int sfztwide = 0;
            int ischeck = 0;
            DataTable dt = new DataTable();
            string sql_sfkg = "select dictvalue1 from YHS_HOS_DICT where id=1";
            dt = InstanceForm.BDatabase.GetDataTable(sql_sfkg);
            if (dt.Rows[0]["dictvalue1"].ToString() == "1")
            {
                DataTable dt_dept = new DataTable();
                string sql_dept = "select IsCheck   from YHS_HOS_KESHI_SF where KESHI_CODE= " + InstanceForm.BCurrentDept.DeptId.ToString();
                dt_dept = InstanceForm.BDatabase.GetDataTable(sql_dept);
                if (dt_dept.Rows.Count > 0 && dt_dept.Rows[0]["IsCheck"].ToString() == "1")
                { ischeck = 1; }
            }
            if (ischeck == 1)
            {
                sfztwide = 2;
            }
            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={ "status_flag","Order_ID","Group_ID","Num","Unit","dwlx","Order_Usage","frequency","Dropsper","Dosage",
										"ntype","exec_dept","day1","second1","Inpatient_ID","Baby_ID","isMY","item_code","xmly",    
										"选","审","床号","住院号","姓名","日期","时间","医生","类型","医嘱内容","类别","次","执行科室","转抄护士","核对护士","查对护士",
										"护理级别","病重","病危","饮食","order_hl","order_bz","order_bw","order_ys","停","SERIAL_NO","mngtype",
                                        "AUDITING_USER","AUDITING_USER1","AUDITING_USER2","usage","ps_flag","ps_orderid","ps_user","hoitem_id"};
            int[] GrdWidth =     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, sfztwide, 5, 9, 6, 5, 5, 6, 4, 80, 4, 4, 10, 8, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.InitGridYZ(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);
        }


        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].AllowSorting = false; //不允许排序

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
            string TypeStr = sender.GetType().ToString();
            if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn"
                || sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn")
            {

                DataGridEx DataGrid = new DataGridEx();
                switch (TypeStr)
                {
                    case "TrasenClasses.GeneralControls.DataGridEnableBoolColumn":
                        {
                            DataGrid = (TrasenClasses.GeneralControls.DataGridEx)((((TrasenClasses.GeneralControls.DataGridEnableBoolColumn)sender).DataGridTableStyle).DataGrid);
                            break;
                        }
                    case "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn":
                        {
                            DataGrid = (TrasenClasses.GeneralControls.DataGridEx)((((TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn)sender).DataGridTableStyle).DataGrid);
                            break;
                        }
                }

                DataTable myTb = (DataTable)DataGrid.DataSource;
                if (myTb == null || myTb.Rows.Count == 0)
                    return;
                //用色彩区分医嘱的状态 
                int ColorCol = 0;		 //状态列
                int ntype = 10;		 //7是说明
                e.BackColor = Color.White;
                if (Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) > 1 && Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) < 5)   //已审核
                {
                    e.ForeColor = Color.Blue;
                }
                if (this.myDataGrid1[e.Row, ColorCol].ToString() == "5")   //已停止
                {
                    e.ForeColor = Color.Gray;
                }

                //临时医嘱用红色
                if (this.myDataGrid1[e.Row, 45].ToString() == "1" || this.myDataGrid1[e.Row, 45].ToString() == "5")
                {
                    e.ForeColor = Color.Red;
                }

                if (sender is DataGridEnableTextBoxColumn)
                {

                    DataGridEnableTextBoxColumn tb = sender as DataGridEnableTextBoxColumn;
                    if (tb.HeaderText.Trim().Equals("类别"))
                    {

                        //说明性医嘱字体黄色
                        if (this.myDataGrid1[e.Row, ntype].ToString() == "7")
                        {
                            //e.ForeColor = Color.Orange;
                            string _color = Convertor.IsNull("Orange", "");
                            if (_color != "")
                            {
                                Color cl = Color.FromName(_color);
                                //e.BackColor = Color.Orange;
                                if (cl.ToArgb() != 0)
                                {
                                    e.ForeColor = cl;
                                    // e.ForeColor = Color.White;
                                }
                            }
                        }
                    }
                }

                ////说明医嘱用棕色 //Add By tany 2011-06-19
                //if (this.myDataGrid1[e.Row, 28].ToString() == "说明")
                //{
                //    e.ForeColor = Color.Brown;
                //}

                //选择列
                if (this.myDataGrid1[e.Row, 19].ToString() == "True")
                {
                    e.BackColor = Color.GreenYellow;
                }
                else
                {
                    e.BackColor = Color.White;
                }
            }
        }


        private void checkBox1_Click(object sender, System.EventArgs e)
        {
            bool isChecked = this.checkBox1.Checked;
            this.label1.Enabled = isChecked;
            this.label2.Enabled = isChecked;
            this.dtpBeginDate.Enabled = isChecked;
            this.dtpEndDate.Enabled = isChecked;
        }


        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            MenuItem mn = (MenuItem)sender;
            string mnName = mn.Text.Trim();
            switch (mnName)
            {
                case "新医嘱":
                    this.Kind = 0;
                    break;
                case "未转抄医嘱":
                    this.Kind = 1;
                    break;
                case "已转抄医嘱":
                    this.Kind = 2;
                    break;
                case "未核对医嘱":
                    this.Kind = 3;
                    break;
                case "已核对医嘱":
                    this.Kind = 4;
                    break;
                case "未查对医嘱":
                    this.Kind = 5;
                    break;
                case "已查对医嘱":
                    this.Kind = 6;
                    break;
            }
            this.Show_Data();
        }

        private void Show_Data()
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            this.bt转抄.Enabled = false;
            switch (this.Kind)
            {
                case 0:
                    this.myDataGrid1.CaptionText = "新医嘱";
                    break;
                case 1:
                    this.myDataGrid1.CaptionText = "未转抄医嘱";
                    this.bt转抄.Text = "转抄(&Z)";
                    break;
                case 2:
                    this.myDataGrid1.CaptionText = "已转抄医嘱";
                    this.bt转抄.Text = "转抄(&Z)";
                    break;
                case 3:
                    this.myDataGrid1.CaptionText = "未核对医嘱";
                    this.bt转抄.Text = "核对(&Z)";
                    break;
                case 4:
                    this.myDataGrid1.CaptionText = "已核对医嘱";
                    this.bt转抄.Text = "核对(&Z)";
                    break;
                case 5:
                    this.myDataGrid1.CaptionText = "未查对医嘱";
                    this.bt转抄.Text = "查对(&Z)";
                    break;
                case 6:
                    this.myDataGrid1.CaptionText = "已查对医嘱";
                    this.bt转抄.Text = "查对(&Z)";
                    break;
            }
            this.Text = this.myDataGrid1.CaptionText;

            //this.dtpBeginDate.Value = Convert.ToDateTime(this.dtpBeginDate.Value.ToShortDateString() + " " + this.dtpBeginDate.Value.Hour + ":" + this.dtpBeginDate.Value.Minute + ":00");
            //this.dtpEndDate.Value = Convert.ToDateTime(this.dtpEndDate.Value.ToShortDateString() + " " + this.dtpEndDate.Value.Hour + ":" + this.dtpEndDate.Value.Minute + ":00");

            DataTable myTb = new DataTable();
            //增加病人列表，不支持整个病区搜索
            //Kind==1
            //Modify By Tany 2009-07-27
            if (1 == 2)
            {
                #region 整个病区搜索
                if (this.checkBox1.Checked)
                {
                    this.myDataGrid1.CaptionText = this.myDataGrid1.CaptionText + "（时间从：" + this.dtpBeginDate.Value.ToString() + " 至 " + this.dtpEndDate.Value.ToString() + "）";
                    myTb = myFunc.GetBinOrdrszc("", InstanceForm.BCurrentDept.WardId, Kind, 1, this.dtpBeginDate.Value, this.dtpEndDate.Value);
                }
                else
                {
                    this.myDataGrid1.CaptionText = this.myDataGrid1.CaptionText + "（所有）";
                    myTb = myFunc.GetBinOrdrszc("", InstanceForm.BCurrentDept.WardId, Kind, 0, this.dtpBeginDate.Value, this.dtpEndDate.Value);
                }
                #endregion
            }
            else
            {
                #region 单个病人搜索
                if (this.checkBox1.Checked)
                {
                    this.myDataGrid1.CaptionText = this.myDataGrid1.CaptionText + "（时间从：" + this.dtpBeginDate.Value.ToString() + " 至 " + this.dtpEndDate.Value.ToString() + "）";
                }
                else
                {
                    this.myDataGrid1.CaptionText = this.myDataGrid1.CaptionText + "（所有）";
                }

                DataTable patTb = (DataTable)dataGridEx1.DataSource;//InstanceForm.BDatabase.GetDataTable("select inpatient_id,baby_id from vi_zy_vinpatient_bed where ward_id='" + InstanceForm.BCurrentDept.WardId + "' order by bed_no");
                DataTable tmpTb = new DataTable();

                progressBar1.Maximum = patTb.Rows.Count;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;

                //循环病区病人
                for (int i = 0; i < patTb.Rows.Count; i++)
                {
                    if (patTb.Rows[i]["选"].ToString() == "True")
                    {
                        tmpTb.Clear();

                        if (this.checkBox1.Checked)
                        {
                            tmpTb = myFunc.GetBinOrdrszcInpatient("", InstanceForm.BCurrentDept.WardId, Kind, 1, this.dtpBeginDate.Value, this.dtpEndDate.Value, new Guid(patTb.Rows[i]["inpatient_id"].ToString()), Convert.ToInt64(patTb.Rows[i]["baby_id"].ToString()));
                        }
                        else
                        {
                            tmpTb = myFunc.GetBinOrdrszcInpatient("", InstanceForm.BCurrentDept.WardId, Kind, 0, this.dtpBeginDate.Value, this.dtpEndDate.Value, new Guid(patTb.Rows[i]["inpatient_id"].ToString()), Convert.ToInt64(patTb.Rows[i]["baby_id"].ToString()));
                        }

                        if (myTb == null || myTb.Columns.Count == 0)
                        {
                            myTb = tmpTb.Clone();
                        }

                        for (int j = 0; j < tmpTb.Rows.Count; j++)
                        {
                            myTb.Rows.Add(tmpTb.Rows[j].ItemArray);
                        }
                    }
                    progressBar1.Value += 1;
                }
                #endregion
            }
            #region //增加他科显示 未转抄和未核对 add by zouchihua 2014-8-16
            /*Modify By Tany 2015-04-15 武汉中心暂时不需要
            DataTable myTb_tk;
            if (Kind == 1)
            {
                //未核对
                myTb_tk = myFunc.GetBinOrdrszc("", InstanceForm.BCurrentDept.WardId, 1, 3, this.dtpBeginDate.Value, this.dtpEndDate.Value);
                for (int i = 0; i < myTb_tk.Rows.Count; i++)
                {
                    DataRow[] whd_row = myTb.Select("order_id='" + myTb_tk.Rows[i]["order_id"].ToString() + "'");
                    if (whd_row.Length <= 0)
                    {
                        myTb.Rows.Add(myTb_tk.Rows[i].ItemArray);
                    }
                }

            }
            if (Kind == 3)
            {

                //未转抄
                myTb_tk = myFunc.GetBinOrdrszc("", InstanceForm.BCurrentDept.WardId, 3, 3, this.dtpBeginDate.Value, this.dtpEndDate.Value);
                for (int i = 0; i < myTb_tk.Rows.Count; i++)
                {
                    DataRow[] whd_row = myTb.Select("order_id='" + myTb_tk.Rows[i]["order_id"].ToString() + "'");
                    if (whd_row.Length <= 0)
                    {
                        myTb.Rows.Add(myTb_tk.Rows[i].ItemArray);
                    }
                    //myTb.Rows.Add(myTb_tk.Rows[i].ItemArray);
                }
            }
            */
            #endregion
            outTb = myTb.Copy();

            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "选";
            col.DefaultValue = false;
            myTb.Columns.Add(col);

            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            CheckGrdData(myTb);
            this.myDataGrid1.DataSource = myTb;

            if (myTb.Rows.Count == 0)
            {
                this.old_BabyID = 0;
                this.bt转抄.Enabled = false;
            }
            else
            {
                if (this.Kind == 1 || this.Kind == 3 || this.Kind == 5) this.bt转抄.Enabled = true;
            }

            this.priceInfo1.ClearYpInfo();
            this.Show_Patient();
            myDataGrid3_Clear();

            progressBar1.Value = 0;
            Cursor.Current = Cursors.Default;
        }

        private void CheckGrdData(DataTable myTb)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0, iName = 0, iType = 0, iDoc = 0;                //记录上一个显示日期和时间、姓名,类型，医生的行号
            int l = 0, group_rows = 1;    //同组中的医嘱个数
            bool isShowDay = true;
            this.sPaint = "";

            #region 算出长度
            max_len0 = 0;
            max_len1 = 0;
            max_len2 = 0;
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sNum = this.GetNumUnit(myTb, i);
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                if (Convert.ToInt16(myTb.Rows[i]["停"]) == 1) l += 4;
                max_len0 = max_len0 > l ? max_len0 : l;
                if (sNum.Trim() != "")
                {
                    max_len1 = max_len1 > l ? max_len1 : l;
                    l = System.Text.Encoding.Default.GetByteCount(sNum);
                    max_len2 = max_len2 > l ? max_len2 : l;
                }
            }
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {

                #region 显示姓名
                if (i != 0)
                {
                    if (myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[iName]["Inpatient_ID"].ToString().Trim()
                        && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[iName]["Baby_ID"].ToString().Trim())
                    {
                        myTb.Rows[i]["床号"] = System.DBNull.Value;
                        myTb.Rows[i]["住院号"] = System.DBNull.Value;
                        myTb.Rows[i]["姓名"] = System.DBNull.Value;
                        isShowDay = false;
                    }
                    else
                    {
                        iName = i;
                        isShowDay = true;  //需要显示日期和时间
                    }
                }
                else isShowDay = true;
                #endregion

                #region 显示日期时间
                myTb.Rows[i]["日期"] = myFunc.getDate(myTb.Rows[i]["日期"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                myTb.Rows[i]["时间"] = myFunc.getTime(myTb.Rows[i]["时间"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["日期"].ToString().Trim() == myTb.Rows[iDay]["日期"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["日期"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }

                    if (myTb.Rows[i]["时间"].ToString().Trim() == myTb.Rows[iTime]["时间"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["时间"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }
                #endregion

                #region 显示医生
                if (i != 0)
                {
                    if (myTb.Rows[i]["医生"].ToString().Trim() == myTb.Rows[iDoc]["医生"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["医生"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDoc = i;
                    }
                }
                #endregion

                #region 显示类型
                if (i != 0)
                {
                    if (myTb.Rows[i]["类型"].ToString().Trim() == "临嘱")
                    {
                        myTb.Rows[i]["次"] = System.DBNull.Value;
                    }

                    if (myTb.Rows[i]["类型"].ToString().Trim() == myTb.Rows[iType]["类型"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["类型"] = System.DBNull.Value;
                    }
                    else
                    {
                        iType = i;
                    }
                }
                #endregion

                #region 显示医嘱内容

                //“医嘱内容”+= “医嘱内容”+“空格”+“数量单位”
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                if (Convert.ToInt16(myTb.Rows[i]["停"]) == 1) l += 4;
                sNum = this.GetNumUnit(myTb, i);
                if (sNum.Trim() != "") myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;
                else myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(/*max_len0-l*/5) + sNum;//Modify By Tany 2004-10-27

                //停医嘱的处理
                if (Convert.ToInt16(myTb.Rows[i]["停"]) == 1)
                {
                    if (Convert.ToInt16(myTb.Rows[i]["SERIAL_NO"]) == 0)
                    {
                        myTb.Rows[i]["医嘱内容"] = "停：" + myTb.Rows[i]["医嘱内容"].ToString();
                    }
                    else
                    {
                        myTb.Rows[i]["医嘱内容"] = "    " + myTb.Rows[i]["医嘱内容"].ToString();
                    }
                }

                //if  ( (i==myTb.Rows.Count-1) || (i!=myTb.Rows.Count-1 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i+1]["Group_id"].ToString().Trim() && myTb.Rows[i]["mngtype"].ToString().Trim() != myTb.Rows[i+1]["mngtype"].ToString().Trim() ))
                if ((i == myTb.Rows.Count - 1) ||
                       (i != myTb.Rows.Count - 1 &&
                          ((myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i + 1]["Group_id"].ToString().Trim()
                              && myTb.Rows[i]["mngtype"].ToString().Trim() == myTb.Rows[i + 1]["mngtype"].ToString().Trim()
                             )
                            ||
                            (myTb.Rows[i]["mngtype"].ToString().Trim() != myTb.Rows[i + 1]["mngtype"].ToString().Trim())
                           )
                    //如果病人ID或者婴儿ID不一样，则不是同一病人 Add By Tany 2010-03-20
                           || myTb.Rows[i]["inpatient_id"].ToString().Trim() != myTb.Rows[i + 1]["inpatient_id"].ToString().Trim()
                           || myTb.Rows[i]["baby_id"].ToString().Trim() != myTb.Rows[i + 1]["baby_id"].ToString().Trim()
                        )
                    )
                {
                    //如果是最后一行或本行和上一行的医嘱号不一致

                    //同组中第一条医嘱的“医嘱内容”+=“用法”+“滴速”+ “频率”+“剂数”
                    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["医嘱内容"].ToString().Trim());
                    myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);
                    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "")
                    {
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                    }
                    if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "")
                    {
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim();// +"滴/min";	
                    }
                    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "" && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "1"
                        //						&& ( Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 || 
                        //						(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD" ) )
                        )
                    {
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                    }
                    if (Convert.ToInt16(myTb.Rows[i - group_rows + 1]["Dosage"]) > 1)
                    {
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Dosage"].ToString().Trim() + "付";
                    }
                    int cd = 0;
                    //add by zouchihua 2012-6-23 增加天数
                    if ((myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "1" || myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "5") && myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() != ""
                        && int.Parse(myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim()) > 1
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                    {
                        cd = System.Text.Encoding.Default.GetByteCount(" " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "天");
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "天" + myFunc.Repeat_Space(6 - cd);
                    }
                    else
                    {
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(6 - cd);
                    }
                    int len = 0;
                    for (int x = 0; x < group_rows; x++)
                    {

                        #region//总量显示
                        if ((myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "1" || myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "5") && Convert.ToInt32(myTb.Rows[i - group_rows + 1 + x]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i - group_rows + 1 + x]["zsl"].ToString().Trim() != "")//如果是药品
                        {
                            string ssNum = "";

                            if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == Convert.ToInt64(myTb.Rows[i - group_rows + 1 + x]["zsl"]))
                            {
                                ssNum = String.Format("{0:F0}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                                if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == 0)
                                    ssNum = "";
                            }
                            else
                            {
                                ssNum = String.Format("{0:F3}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                            }
                            if (x == 0)
                            {
                                len = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["医嘱内容"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["医嘱内容"] += " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                            else
                            {
                                int blen = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["医嘱内容"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["医嘱内容"] += myFunc.Repeat_Space(len - blen) + " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                        }
                        #endregion
                    }

                    //总量显示
                    //if ((myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "1" || myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "5") && Convert.ToInt32(myTb.Rows[i - group_rows + 1]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i - group_rows + 1]["zsl"].ToString().Trim() != "")//如果是药品
                    //{
                    //    string ssNum = "";
                    //    if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1]["zsl"]) == Convert.ToInt64(myTb.Rows[i - group_rows + 1]["zsl"]))
                    //    {
                    //        ssNum = String.Format("{0:F0}", myTb.Rows[i]["zsl"]).Trim();
                    //        if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1]["zsl"]) == 0)
                    //            ssNum = "";
                    //    }
                    //    else
                    //    {
                    //        ssNum = String.Format("{0:F3}", myTb.Rows[i]["zsl"]).Trim();
                    //    }
                    //    myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + ssNum + myTb.Rows[i - group_rows + 1]["zsldw"].ToString().Trim();
                    //}

                    //如果一组中的医嘱个数大于1
                    if (group_rows != 1)
                    {
                        //[3i2]0 代表第三行是一组医嘱的最后一条，该组医嘱有两条医嘱，status_flag=0
                        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                    }
                    group_rows = 1;
                }
                else
                {
                    try
                    {
                        //如果不是第一行，且本行和下一行的医嘱号一致
                        myTb.Rows[i]["次"] = System.DBNull.Value;
                        if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows += 1;
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }



                #endregion
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private string GetNumUnit(DataTable myTb, int i)
        {
            string sNum = "";
            if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt32(myTb.Rows[i]["Num"]))
            {
                sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
            }
            else
            {
                sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
            }
            //Modify By Tany 2004-10-27
            if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "2" && myTb.Rows[i]["ntype"].ToString().Trim() != "3") || sNum == "0" || sNum == "")
                return "";
            else
                return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();
        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myDataGrid3_Clear();
            this.Show_Patient();

            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();
            if (ColumnName == "次")
            {
                //add by zouchihua 只有医嘱转抄的时候才可以选择末次和首次
                if (Kind != 1)
                    return;
                DataTable myTb = new DataTable();
                myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null || myTb.Rows.Count == 0) return;

                if (myTb.Rows[nrow]["次"].ToString().Trim() != "")
                {
                    this.addPlCmb(myTb.Rows[nrow]["frequency"].ToString().Trim());
                }
                else
                {
                    DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles["次"];
                    dgtb.TextBox.Controls.Clear();
                }
            }
        }

        private void myDataGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0)
            {
                this.priceInfo1.ClearYpInfo();
                return;
            }

            //如果是医嘱内容列
            if (ncol == 27)
            {
                //显示药品信息
                myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb.Rows.Count > 0)
                {
                    int myCJID = Convert.ToInt32(myTb.Rows[nrow]["hoitem_id"]);
                    double myNUM = 0;
                    //add by zouchihua 2012-6-22 如果临时医嘱，总量
                    if ((myTb.Rows[nrow]["mngtype"].ToString() == "1" || myTb.Rows[nrow]["mngtype"].ToString() == "5"))
                    {
                        if (myTb.Rows[nrow]["zsl"].ToString() != "")
                            myNUM = Convert.ToDouble(myTb.Rows[nrow]["zsl"]);
                        else
                            myNUM = Convert.ToDouble(myTb.Rows[nrow]["Num"]);
                    }
                    else
                        myNUM = Convert.ToDouble(myTb.Rows[nrow]["Num"]);

                    int myDWLX = Convert.ToInt32(myTb.Rows[nrow]["dwlx"]);
                    long myEXECDEPT = Convert.ToInt64(myTb.Rows[nrow]["exec_dept"]);
                    int myTYPE = Convert.ToInt32(myTb.Rows[nrow]["nType"]);
                    //有效性判断
                    if (myTYPE < 3 && myTYPE != 0)
                    {
                        this.priceInfo1.Visible = true;
                        this.myDataGrid3.Visible = false;
                        //Modify By tany 2011-04-12 获取病人医保类型
                        int yblx = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select yblx from zy_inpatient where inpatient_id='" + myTb.Rows[nrow]["inpatient_id"].ToString() + "'"));
                        this.priceInfo1.SetYpInfo(myCJID, myNUM, myDWLX, myEXECDEPT, yblx);
                    }
                    else
                    {
                        this.priceInfo1.Visible = false;
                        this.myDataGrid3.Visible = true;
                        this.priceInfo1.ClearYpInfo();
                        if (myTYPE != 3)
                        {
                            long HOitem_ID = Convert.ToInt64(Convertor.IsNull(myTb.Rows[nrow]["hoitem_id"].ToString(), "0"));
                            double num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["num"].ToString(), "0"));
                            string User_Name = myTb.Rows[nrow]["order_usage"].ToString();

                            //this.myDataGrid3.TableStyles.Clear();

                            DataTable myTbTemp = myFunc.SetItemInfo("", HOitem_ID, num, User_Name, (new Department(myEXECDEPT, InstanceForm.BDatabase)).Jgbm); //*js);
                            this.myDataGrid3.DataSource = myTbTemp;

                            string[] GrdMappingName4 ={ "id", "名称", "数量", "单位", "单价", "金额" };
                            int[] GrdWidth4 ={ 0, 15, 5, 4, 6, 8 };
                            int[] Alignment4 ={ 0, 0, 0, 0, 0, 0 };
                            int[] Readonly4 ={ 0, 0, 0, 0, 0, 0 };
                            myFunc.InitGrid(GrdMappingName4, GrdWidth4, Alignment4, Readonly4, this.myDataGrid3);

                            this.myDataGrid3.CaptionText = "项目明细";
                            this.myDataGrid3.Refresh();
                        }
                    }
                }
            }
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
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "选") return;
            if (nrow > myTb.Rows.Count - 1) return;

            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;
            //this.myDataGrid1.DataSource=myTb;
            //this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);	

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["Group_id"].ToString().Trim() == myTb.Rows[nrow]["Group_id"].ToString().Trim()
                    && myTb.Rows[i]["mngtype"].ToString().Trim() == myTb.Rows[nrow]["mngtype"].ToString().Trim()
                    && myTb.Rows[i]["停"].ToString().Trim() == myTb.Rows[nrow]["停"].ToString().Trim()
                    && myTb.Rows[i]["Inpatient_id"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_id"].ToString().Trim()
                    && myTb.Rows[i]["Baby_id"].ToString().Trim() == myTb.Rows[nrow]["Baby_id"].ToString().Trim()
                    && myTb.Rows[i]["选"].ToString() != isResult.ToString())
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["选"] = isResult;
                    //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                }
            }

            this.myDataGrid1.DataSource = myTb;

        }

        private void myDataGrid3_Clear()
        {
            DataTable myTb = (DataTable)this.myDataGrid3.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;
            this.myDataGrid3.CaptionText = "项目明细";
            myTb.Rows.Clear();
        }

        private void myDataGrid1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int i = 0;
            int yDelta = this.myDataGrid1.GetCellBounds(i, 0).Height + 1;
            int y = this.myDataGrid1.GetCellBounds(i, 0).Top + 2;

            int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
            int start_row = 0, start_point = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[this.myDataGrid1.DataSource, this.myDataGrid1.DataMember];

            while (y < this.myDataGrid1.Height - yDelta && i < cm.Count)
            {
                y += yDelta;

                //组线
                index_start = this.sPaint.IndexOf("[" + i.ToString() + "i", 0, this.sPaint.Trim().Length);
                if (index_start >= 0)
                {
                    index_i = index_start + i.ToString().Trim().Length + 1;
                    index_end = this.sPaint.IndexOf("]", index_i, this.sPaint.Trim().Length - index_i);
                    start_row = Convert.ToInt16(this.sPaint.Substring(index_i + 1, index_end - index_i - 1));
                    if (this.max_len1 == 0) start_point = 310 + (this.max_len0 + 4) * 6;
                    else start_point = 310 + (this.max_len1 + this.max_len2 + 4) * 6;
                    switch (this.sPaint.Substring(index_end + 1, 1))
                    {
                        case "1":  //未审核
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "5":  //已停止
                            e.Graphics.DrawLine(System.Drawing.Pens.Gray, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        default: //已审核
                            e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                    }
                }
                i++;
            }
        }


        private void Show_Patient()
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb.Rows.Count == 0)
            {
                this.old_BabyID = 0;
                this.patientInfo1.ClearInpatientInfo();
                return;
            }

            //得到病人基本信息
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            //if (this.old_BinID != Convert.ToInt64(this.myDataGrid1[nrow, 14]) || this.old_BabyID != Convert.ToInt64(this.myDataGrid1[nrow, 15]))
            if (this.old_BinID != new Guid(Convertor.IsNull(this.myDataGrid1[nrow, 14], Guid.Empty.ToString())) || this.old_BabyID != Convert.ToInt64(Convertor.IsNull(this.myDataGrid1[nrow, 15], "0")))
            {
                this.old_BinID = new Guid(this.myDataGrid1[nrow, 14].ToString());
                this.old_BabyID = Convert.ToInt32(this.myDataGrid1[nrow, 15]);
                this.patientInfo1.SetInpatientInfo(new Guid(myDataGrid1[nrow, 14].ToString()), Convert.ToInt64(myDataGrid1[nrow, 15]), Convert.ToInt32(this.myDataGrid1[nrow, 15]));
            }
        }


        private void bt显示切换_Click(object sender, System.EventArgs e)
        {
            if (this.panel医嘱.Height == 592)
            {
                this.panel医嘱.Height = 664;
            }
            else
            {
                this.panel医嘱.Height = 592;
            }
        }

        private void bt全选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;
            DataGridCell myCel = myDataGrid1.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb所有病人.Checked)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //新病人的行号	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["选"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["选"] = isTrue;
                    }
                    else isTrue = false;
                }
            }
            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.CurrentCell = myCel;
        }

        private void bt反选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;
            DataGridCell myCel = myDataGrid1.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb所有病人.Checked)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //新病人的行号	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["选"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (isTrue && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                    }
                }
            }
            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.CurrentCell = myCel;
        }

        private void bt查询_Click(object sender, System.EventArgs e)
        {
            this.Show_Data();
        }
        /// <summary>
        /// 更新执行科室
        /// </summary>
        private bool GxZxks(DataTable tb)
        {
            SelectTb(tb);
            tb.DefaultView.RowFilter = "convert(选, 'System.String')='True' and  XMLY=2";
            tb = tb.DefaultView.ToTable();
            if (tb.Rows.Count == 0)
                return true;
            Ts_ClinicalPath_Statistics.FrmZxksXg fxg = new Ts_ClinicalPath_Statistics.FrmZxksXg();
            fxg.tb = tb;
            fxg.ShowDialog();
            if (fxg.DialogResult == DialogResult.OK)
                return true;
            else
                return false;
        }
        private void SelectTb(DataTable tb)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i - j < tb.Rows.Count; i++)
            {
                if (tb.Rows[i - j]["床号"].ToString().Trim() == "")
                {
                    tb.Rows[i - j]["床号"] = tb.Rows[i - j - 1]["床号"];
                    tb.Rows[i - j]["住院号"] = tb.Rows[i - j - 1]["住院号"];
                    tb.Rows[i - j]["姓名"] = tb.Rows[i - j - 1]["姓名"];
                    tb.Rows[i - j]["日期"] = tb.Rows[i - j - 1]["日期"];
                    tb.Rows[i - j]["时间"] = tb.Rows[i - j - 1]["时间"];
                    tb.Rows[i - j]["医生"] = tb.Rows[i - j - 1]["医生"];
                    tb.Rows[i - j]["类型"] = tb.Rows[i - j - 1]["类型"];
                }
            }

            for (i = 0; i - j < tb.Rows.Count; i++)
            {
                try
                {

                    DataTable temptb = FrmMdiMain.Database.GetDataTable("select * from JC_HOITEMDICTION where (isbks=1 or isryks=1) and order_id=" + tb.Rows[i - j]["HOITEM_ID"] + "");
                    if (temptb.Rows.Count == 0)
                    {

                        tb.Rows.Remove(tb.Rows[i - j]);
                        j++;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }
        private void bt转抄_Click(object sender, System.EventArgs e)
        {
            //add by zouchihua 2013-8-27 采血管医嘱
            ArrayList orderlist = new ArrayList();
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            DataTable decoctTb = new DataTable();
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            string sSql = "", sSql1 = "", sSql2 = "", tmpSql = "";
            int i = 0, iSelectRows = 0;
            if (cfg7212.Config.Trim() == "1")
            {
                myTb.DefaultView.RowFilter = "";
                DataTable temptbb = myTb.DefaultView.ToTable();
                myTb.DefaultView.RowFilter = "";
                if (!GxZxks(temptbb)) return;

            }
            DataRow dr;
            DataTable jmcxTb = new DataTable();
            jmcxTb.Columns.Add("Inpatient_ID");
            jmcxTb.Columns.Add("Baby_ID");
            jmcxTb.Columns.Add("床号");
            jmcxTb.Columns.Add("住院号");
            jmcxTb.Columns.Add("姓名");
            jmcxTb.Columns.Add("日期");
            jmcxTb.Columns.Add("时间");
            jmcxTb.Columns.Add("医生");
            jmcxTb.Columns.Add("医嘱内容");
            jmcxTb.Columns.Add("采血费次数");
            jmcxTb.Columns.Add("采血管次数");
            jmcxTb.Columns.Add("dept_br");
            jmcxTb.Columns.Add("dept_id");
            #region 核对也和执行签名一样 可以输入他人工号和密码
            DateTime _execTime = new DateTime();
            long _employeeId = 0;
            if (this.Kind == 3 || this.Kind == 5)
            {
                frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
                frmET.ShowDialog();

                string zxrxm = "";
                if (frmET.DialogResult == DialogResult.OK)
                {
                    _execTime = frmET._execTime;
                    _employeeId = frmET._employeeId;
                }
            }
            #endregion
            #region 有效性判断
            SystemCfg cfg = new SystemCfg(7041);
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {

                //是否允许没有皮试结果的医嘱转抄 Add By Tany 2007-10-30
                #region
                if (cfg.Config != "是")
                {
                    //判断需要皮试的医嘱是否可以转抄
                    //停医嘱不用判断 Modify By Tany 2005-01-26
                    if (this.Kind == 1 && myTb.Rows[i]["选"].ToString() == "True"
                        && Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 0
                        && myTb.Rows[i]["Order_Usage"].ToString().Trim() != "皮试"
                        && myTb.Rows[i]["Order_Usage"].ToString().Trim().ToUpper() != "AST"
                        && Convert.ToInt16(myTb.Rows[i]["停"]) == 0)
                    {
                        Guid psOrderId = new Guid(myTb.Rows[i]["ps_orderid"].ToString());
                        string psStr = "select 1 from zy_orderrecord where order_id='" + psOrderId + "'";
                        DataTable psTb = InstanceForm.BDatabase.GetDataTable(psStr);

                        //只要找到了数据就说明结果是阳性，如果没有找到，再看是不是没有结果或没有对应医嘱
                        //说明：如果皮试是打上阴性，这条医嘱ps_flag=-1，将不会走上这一步
                        if (psTb != null && psTb.Rows.Count > 0)
                        {
                            if (AllowYxZc(myTb.Rows[i]["item_code"].ToString().Trim()) == false)
                            {
                                MessageBox.Show(this, "对不起，“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”的皮试结果是阳性，不允许转抄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                myDataGrid1.CurrentCell = new DataGridCell(i, 19);//选择列
                                myDataGrid1_Click(sender, e);
                                return;
                            }
                        }
                        else
                        {
                            psStr = "select count(*) num from zy_orderrecord where ps_orderid='" + new Guid(myTb.Rows[i]["ps_orderid"].ToString()) + "' and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim();
                            psTb = InstanceForm.BDatabase.GetDataTable(psStr);
                            if (psTb.Rows[0][0].ToString().Trim() == "1")
                            {
                                MessageBox.Show(this, "对不起，“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”没有对应的皮试医嘱，请医生重新开皮试医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                myDataGrid1.CurrentCell = new DataGridCell(i, 19);//选择列
                                myDataGrid1_Click(sender, e);
                                return;
                            }
                            MessageBox.Show(this, "对不起，“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”还没有皮试结果，不允许转抄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myDataGrid1.CurrentCell = new DataGridCell(i, 19);//选择列
                            myDataGrid1_Click(sender, e);
                            return;
                        }
                    }
                }
                #endregion

                #region 验证转抄核对人
                if (i == 0 || myTb.Rows[i]["Group_ID"].ToString().Trim() != myTb.Rows[i - 1]["Group_ID"].ToString().Trim()
                    || myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim())
                {
                    if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                    {
                        //核对时，是否需要增加判断记录的合法性，如执行科室，首次末次，药品的单位等等？
                        iSelectRows += 1;
                        if (this.Kind == 3 || this.Kind == 5)
                        {
                            if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == _employeeId.ToString().Trim()
                                || myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() == _employeeId.ToString().Trim()
                                || myTb.Rows[i]["AUDITING_USER2"].ToString().Trim() == _employeeId.ToString().Trim()
                                )
                            {
                                MessageBox.Show(this, "对不起，“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”的医嘱转抄、核对、查对护士不允许为同一人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == InstanceForm.BCurrentUser.EmployeeId.ToString().Trim()
                                || myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() == InstanceForm.BCurrentUser.EmployeeId.ToString().Trim()
                                || myTb.Rows[i]["AUDITING_USER2"].ToString().Trim() == InstanceForm.BCurrentUser.EmployeeId.ToString().Trim()
                                )
                            {
                                MessageBox.Show(this, "对不起，“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”的医嘱转抄、核对、查对护士不允许为同一人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
                #endregion

                //Add By Tany 2015-03-31 看看检验申请是不是有申请ID，如果没有则返回
                #region 验证医技是否有申请ID
                if (this.Kind == 1 && myTb.Rows[i]["选"].ToString() == "True"
                        && Convert.ToInt16(myTb.Rows[i]["ntype"]) == 5
                        && Convert.ToInt16(myTb.Rows[i]["停"]) == 0)
                {
                    Guid YjOrderId = new Guid(myTb.Rows[i]["order_id"].ToString());
                    string YjStr = "select * from zy_jy_print where order_id='" + YjOrderId + "' and delete_bit=0";
                    DataTable YjTb = InstanceForm.BDatabase.GetDataTable(YjStr);

                    //如果找到记录
                    if (YjTb != null && YjTb.Rows.Count > 0)
                    {
                        if (Convertor.IsNull(YjTb.Rows[0]["apply_no"], "") == "")
                        {
                            MessageBox.Show(this, "对不起，“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”的LIS申请号为空值不允许转抄，请通知医生取消医嘱重新开立！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myDataGrid1.CurrentCell = new DataGridCell(i, 19);//选择列
                            myDataGrid1_Click(sender, e);
                            return;
                        }
                    }
                }
                #endregion
            }
            #endregion

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(this, "确认开始“" + this.bt转抄.Text.Trim() + "”吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (this.Kind == 1 && new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return;
            }

            Cursor.Current = PubStaticFun.WaitCursor();


            this.progressBar1.Maximum = iSelectRows;
            this.progressBar1.Value = 0;

            //			//生成数据访问对象
            //			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
            //			database.Initialize("");
            //			database.Open();

            //
            bool sf_wtg = false;
            int ischeck = 0;
            DataTable dt = new DataTable();
            string sql_sfkg = "select dictvalue1 from YHS_HOS_DICT where id=1";
            dt = InstanceForm.BDatabase.GetDataTable(sql_sfkg);
            if (dt.Rows[0]["dictvalue1"].ToString() == "1")
            {
                DataTable dt_dept = new DataTable();
                string sql_dept = "select IsCheck   from YHS_HOS_KESHI_SF where KESHI_CODE= " + InstanceForm.BCurrentDept.DeptId.ToString();
                dt_dept = InstanceForm.BDatabase.GetDataTable(sql_dept);
                if (dt_dept.Rows.Count > 0 && dt_dept.Rows[0]["IsCheck"].ToString() == "1")
                { ischeck = 1; }
            }

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                {
                    //药慧士审方 add by chenli 2017-09-03
                    if (ischeck == 1)
                    {
                        if ((myTb.Rows[i]["类别"].ToString().Trim() == "西药" || myTb.Rows[i]["类别"].ToString().Trim() == "成药" || myTb.Rows[i]["类别"].ToString().Trim() == "草药") && myTb.Rows[i]["status_flag"].ToString().Trim() == "1" && myTb.Rows[i]["hoitem_id"].ToString().Trim()!="-1")
                        {
                            if (myTb.Rows[i]["审"].ToString().Trim() == "〇" || myTb.Rows[i]["审"].ToString().Trim() == "")
                            {
                                sf_wtg = true;
                                //MessageBox.Show(myTb.Rows[i]["姓名"].ToString().Trim() + "[" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "]" + "还未审方，请联系药房审方!");
                                //sf_wtg += myTb.Rows[i]["姓名"].ToString().Trim() + "[" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "]" + "还未审方，请联系药房审方!\r\n";
                                continue;
                            }
                            if (myTb.Rows[i]["审"].ToString().Trim() == "×")
                            {
                                sf_wtg = true;
                                //MessageBox.Show(myTb.Rows[i]["姓名"].ToString().Trim() + "[" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "]" + "审方未通过，请联系开单医生!");
                                //sf_wtg += myTb.Rows[i]["姓名"].ToString().Trim() + "[" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "]" + "审方未通过，请联系开单医生!\r\n";
                                continue;
                            }
                        }
                    }

                    //皮试医嘱转抄时更改皮试用法医嘱开始时间 add by zouchihua 2013-9-4
                    if (cfg7165.Config.Trim() == "1")
                    {
                        if (this.Kind == 1 && myTb.Rows[i]["选"].ToString() == "True"
                            && Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 0
                            && myTb.Rows[i]["Order_Usage"].ToString().Trim() == "皮试"
                            //&& myTb.Rows[i]["类型"].ToString().Trim().ToUpper() == "临嘱"
                            && Convert.ToInt16(myTb.Rows[i]["停"]) == 0)
                        {
                            string psorder_id = myTb.Rows[i]["ps_orderid"].ToString().Trim().ToUpper();
                            if (psorder_id != Guid.Empty.ToString() && psorder_id != "")
                            {
                                try
                                {
                                    string groupstr = " select GROUP_ID from ZY_ORDERRECORD  where order_id!='" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "' and  PS_ORDERID='" + psorder_id + "' and  inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'";
                                    DataTable grouptb = InstanceForm.BDatabase.GetDataTable(groupstr);
                                    if (grouptb.Rows.Count > 0)
                                    {
                                        InstanceForm.BDatabase.DoCommand("update ZY_ORDERRECORD set  ORDER_BDATE =getdate(),memo='医嘱转抄更改开始时间'+cast(ORDER_BDATE as varchar(36)) where  group_id=" + grouptb.Rows[0]["GROUP_ID"].ToString() + " and  inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'");
                                    }
                                }
                                catch { }
                            }
                        }

                        //更改皮试药时间

                        if (this.Kind == 1 && myTb.Rows[i]["选"].ToString() == "True"
                            //&& Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 0
                            && myTb.Rows[i]["Order_Usage"].ToString().Trim() != "皮试"
                            //&& myTb.Rows[i]["类型"].ToString().Trim().ToUpper() == "临嘱"
                            && int.Parse(myTb.Rows[i]["ntype"].ToString().Trim()) < 3
                            && Convert.ToInt16(myTb.Rows[i]["停"]) == 0)
                        {
                            string psorder_id = myTb.Rows[i]["ps_orderid"].ToString().Trim().ToUpper();
                            if (psorder_id != Guid.Empty.ToString() && psorder_id != "")
                            {
                                try
                                {
                                    string groupstr = " select GROUP_ID from ZY_ORDERRECORD  where order_id='" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "' and  PS_ORDERID='" + psorder_id + "' and  inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'";
                                    DataTable grouptb = InstanceForm.BDatabase.GetDataTable(groupstr);
                                    if (grouptb.Rows.Count > 0)
                                    {
                                        InstanceForm.BDatabase.DoCommand("update ZY_ORDERRECORD set  ORDER_BDATE =getdate(),memo='医嘱转抄更改开始时间'+cast(ORDER_BDATE as varchar(36)) where  group_id=" + grouptb.Rows[0]["GROUP_ID"].ToString() + " and  inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'");
                                    }
                                }
                                catch { }
                            }
                        }
                    }

                    #region 记录有多少条静脉采血 By Tany 2004-10-30
                    if (Kind == 1)
                    {
                        if (myTb.Rows[i]["usage"].ToString().Trim() == "静脉采血")
                        {
                            orderlist.Add(outTb.Rows[i]["ORDER_ID"]);
                            dr = jmcxTb.NewRow();
                            dr["Inpatient_ID"] = outTb.Rows[i]["Inpatient_ID"];
                            dr["Baby_ID"] = outTb.Rows[i]["Baby_ID"];
                            dr["床号"] = outTb.Rows[i]["床号"];
                            dr["住院号"] = outTb.Rows[i]["住院号"];
                            dr["姓名"] = outTb.Rows[i]["姓名"];
                            dr["日期"] = myFunc.getDate(outTb.Rows[i]["日期"].ToString().Trim(), outTb.Rows[i]["day1"].ToString().Trim());
                            dr["时间"] = myFunc.getTime(outTb.Rows[i]["时间"].ToString().Trim(), outTb.Rows[i]["second1"].ToString().Trim());
                            dr["医生"] = outTb.Rows[i]["医生"];
                            dr["医嘱内容"] = outTb.Rows[i]["医嘱内容"];
                            dr["采血费次数"] = "0";
                            dr["采血管次数"] = "0";
                            dr["dept_br"] = outTb.Rows[i]["dept_br"];
                            dr["dept_id"] = outTb.Rows[i]["dept_id"];
                            jmcxTb.Rows.Add(dr);
                        }
                    }
                    #endregion



                    if (!(i != 0 && myTb.Rows[i]["Group_ID"].ToString().Trim() == myTb.Rows[i - 1]["Group_ID"].ToString().Trim()
                        && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        //add by zouchihua 2012-2-21
                        #region 是否使用虚拟库存，转抄时。临时医嘱减虚拟库存，产期医嘱剪当天的虚拟库存
                        try
                        {
                            string cfg6035 = new SystemCfg(6035).Config.Trim();
                            if (cfg6035 == "1" && Convert.ToInt16(myTb.Rows[i]["停"]) == 0 && Kind == 1)//开医嘱转抄
                            {
                                myFunc.OprateXnkc(new Guid(myTb.Rows[i]["Inpatient_ID"].ToString().Trim()), long.Parse(myTb.Rows[i]["baby_id"].ToString().Trim()), Guid.Empty, int.Parse(myTb.Rows[i]["Group_ID"].ToString().Trim()), 0);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            continue;
                        }
                        #endregion

                        //add by zouchihua 2013-9-18 如果是长期医嘱，那么就改变根据开始时间改变首次和末次
                        if (cfg7169.Config.Trim() == "1" && myTb.Rows[i]["mngtype"].ToString().Trim() == "0" && myTb.Rows[i]["xmly"].ToString().Trim() == "1" && Kind == 1)
                        {

                            myFunc.ChangeFirtorLastTime(myTb.Rows[i]["Inpatient_ID"].ToString().Trim(), myTb.Rows[i]["Group_ID"].ToString().Trim(), Convert.ToInt16(myTb.Rows[i]["停"]), 0,
                                myTb.Rows[i]["FREQUENCY"].ToString().Trim(), cfg7048.Config.Trim());
                        }

                        #region 判断是不是有煎药费，如果有则加入一条煎药费临时账单
                        if (Kind == 1)
                        {
                            //add by zouchihua 2013-11-28 如果改变了剂数，也要改变
                            string strdosage = string.Format(@" select id from ZY_DECOCT a join ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID where a.inpatient_id='" + new Guid(myTb.Rows[i]["inpatient_id"].ToString().Trim()) + "'" +
                                " and a.group_id=" + Convert.ToDecimal(myTb.Rows[i]["group_id"].ToString().Trim()) + " and b.num!=" + Convert.ToDecimal(myTb.Rows[i]["dosage"].ToString().Trim()) + "");
                            DataTable tbdosageChange = InstanceForm.BDatabase.GetDataTable(strdosage);
                            if (tbdosageChange.Rows.Count > 0)
                            {
                                string update = string.Format(@"  update ZY_ORDERRECORD set NUM=" + Convert.ToDecimal(myTb.Rows[i]["dosage"].ToString().Trim()) + "  from  ZY_DECOCT a join ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID "
                                + "     where a.inpatient_id='" + new Guid(myTb.Rows[i]["inpatient_id"].ToString().Trim()) + "'" +
                                " and a.group_id=" + Convert.ToDecimal(myTb.Rows[i]["group_id"].ToString().Trim()));
                                InstanceForm.BDatabase.DoCommand(update);
                            }
                            //Add By Tany 2004-10-20
                            //-------------------------------------------------------------------------------------------------------------
                            Guid n_id = Guid.Empty;
                            string msg = "";
                            int iYZH = 0;
                            string strSql = "select id from zy_decoct where inpatient_id='" + new Guid(myTb.Rows[i]["inpatient_id"].ToString().Trim()) + "'" +
                                " and group_id=" + Convert.ToDecimal(myTb.Rows[i]["group_id"].ToString().Trim()) + " and (order_id is null or order_id=DBO.FUN_GETEMPTYGUID())";
                            decoctTb = InstanceForm.BDatabase.GetDataTable(strSql);



                            if (decoctTb.Rows.Count > 0)
                            {
                                n_id = new Guid(decoctTb.Rows[0][0].ToString().Trim());
                                //读取这组医嘱的内容
                                for (int j = 0; j <= myTb.Rows.Count - 1; j++)
                                {
                                    if (myTb.Rows[j]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[j]["选"].ToString() == "True")
                                    {
                                        if (myTb.Rows[j]["Group_ID"].ToString().Trim() == myTb.Rows[i]["Group_ID"].ToString().Trim() && myTb.Rows[j]["inpatient_id"].ToString().Trim() == myTb.Rows[i]["inpatient_id"].ToString().Trim())
                                        {
                                            msg += " " + myTb.Rows[j]["医嘱内容"].ToString().Trim() + "\n";
                                        }
                                    }
                                }


                                //不需要提问，直接收取 Modify By Tany 2005-08-03
                                if (MessageBox.Show("该组医嘱需要煎药，是否自动生成煎药费？\n该组医嘱包括：\n" + msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //取组号
                                    sSql = @"select max(Group_Id) as YZH " +
                                        "  from Zy_OrderRecord " +
                                        " where inpatient_id='" + myTb.Rows[i]["inpatient_id"].ToString().Trim() + "'" +
                                        "       and baby_id=" + Convert.ToDecimal(myTb.Rows[i]["baby_id"].ToString().Trim());//+
                                    //										"       and mngtype=3";
                                    DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                                    if (myTempTb.Rows[0]["YZH"].ToString().Trim() == "")
                                    {
                                        iYZH = 0;
                                    }
                                    else
                                    {
                                        iYZH = Convert.ToInt32(myTempTb.Rows[0]["YZH"]) + 1;
                                    }

                                    //取煎药费
                                    sSql = @"Select a.order_id,a.order_name,a.order_unit,a.order_type,a.default_dept " +
                                        " from jc_hoitemdiction a " +
                                        " where a.order_id=" + new SystemCfg(7014).Config;
                                    myTempTb.Clear();
                                    myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
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
                                            v_exec_dept = Convert.ToInt64(myTb.Rows[i]["dept_br"]);
                                        }
                                        else
                                        {
                                            v_exec_dept = Convert.ToInt64(myTempTb.Rows[0]["default_dept"]);
                                        }

                                        //										//开始一个事物
                                        //										database.BeginTransaction();

                                        InstanceForm.BDatabase.BeginTransaction();

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
                                                "VALUES( '" + v_O_id + "'," + FrmMdiMain.Jgbm + ",'" +
                                                myTb.Rows[i]["inpatient_id"].ToString().Trim() + "'," + Convert.ToDecimal(myTb.Rows[i]["baby_id"].ToString().Trim()) +
                                                ",'" + InstanceForm.BCurrentDept.WardId + "'," + Convert.ToDecimal(myTb.Rows[i]["dept_br"].ToString().Trim()) + "," + Convert.ToDecimal(myTb.Rows[i]["dept_id"].ToString().Trim()) +
                                                ",3,getdate()," + iYZH.ToString() + "," + v_order_type + "," +
                                                v_hoitem_id + ",2,'" + v_order_context + "'," + myTb.Rows[i]["dosage"] + ",1,'" + v_unit + "','',''," +
                                                v_exec_dept + ", 1,2," +
                                                InstanceForm.BCurrentUser.EmployeeId.ToString() + ",getdate() ," + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",getdate(),0)";

                                            InstanceForm.BDatabase.DoCommand(strSql);

                                            if (v_O_id == null || v_O_id == Guid.Empty)
                                            {
                                                throw new Exception("没有生成Order_id，无法更新数据！");
                                            }

                                            strSql = "update zy_decoct set order_id='" + v_O_id + "' where id='" + n_id + "'";
                                            InstanceForm.BDatabase.DoCommand(strSql);

                                            InstanceForm.BDatabase.CommitTransaction();

                                        }
                                        catch (Exception err)
                                        {
                                            InstanceForm.BDatabase.RollbackTransaction();

                                            //写错误日志 Add By Tany 2005-01-12
                                            SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "程序错误", "医嘱转抄错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                                            _systemErrLog.Save();
                                            _systemErrLog = null;

                                            MessageBox.Show("错误：将煎药费插入临时账单错误，请手工生成煎药费！\n系统：" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        int _isstopzc = 0;//add by zouchihua 2013-6-18 记录是否是停医嘱转抄
                        #region 更新数据
                        sSql = @"update zy_OrderRecord ";
                        switch (this.Kind)
                        {
                            case 1:
                                sSql += Convert.ToInt16(myTb.Rows[i]["停"]) == 0 ?
                                    //开医嘱转抄
                                    " set status_flag=2, Auditing_User=" + InstanceForm.BCurrentUser.EmployeeId + ",Auditing_Date=getdate()" :
                                    //停医嘱转抄
                                    " set status_flag=4, ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ",ORDER_EUDATE=getdate()";
                                tmpSql = " and status_flag in (1,3)";//Add By Tany 2005-01-20 开嘱和停嘱转抄要判断状态，看是不是已经被转抄过了	
                                if (Convert.ToInt16(myTb.Rows[i]["停"]) == 1)
                                    _isstopzc = 1;
                                break;
                            case 3:
                                //add by zouchihua  2014-4-16 核对也和执行签名一样 可以输入他人工号和密码
                                sSql += Convert.ToInt16(myTb.Rows[i]["停"]) == 0 ?
                                    //开医嘱核对
                                    " set Auditing_User1=" + _employeeId + ",Auditing_Date1='" + _execTime + "'" :
                                    //停医嘱核对
                                    " set ORDER_EUSER1=" + _employeeId + ",ORDER_EUDATE1='" + _execTime + "'";
                                break;
                            case 5:
                                //add by zouchihua  2014-4-16 核对也和执行签名一样 可以输入他人工号和密码
                                sSql += Convert.ToInt16(myTb.Rows[i]["停"]) == 0 ?
                                    //开医嘱查对
                                    " set Auditing_User2=" + InstanceForm.BCurrentUser.EmployeeId + ",Auditing_Date2=getdate()" :
                                    //停医嘱查对
                                    " set ORDER_EUSER2=" + InstanceForm.BCurrentUser.EmployeeId + ",ORDER_EUDATE2=getdate()";
                                break;
                        }
                        //Modify by zouchihua 2012-1-31  
                        if (myTb.Rows[i]["mngtype"].ToString().Trim() == "1")
                        {
                            sSql += " where delete_bit=0 and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and mngtype in(1,5 )  " +
                                "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim() + tmpSql;
                        }
                        else
                        {
                            sSql += " where delete_bit=0 and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                 "       and mngtype=" + myTb.Rows[i]["mngtype"].ToString().Trim() +
                                 "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                 "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim() + tmpSql;
                        }
                        try
                        {
                            InstanceForm.BDatabase.DoCommand(sSql);
                            try
                            {
                                //add by zouchihua 2013-6-18  医技科室怎家提示
                                if (cfg7154.Config.Trim() == "1" && _isstopzc == 1 && myTb.Rows[i]["ntype"].ToString().Trim() == "5")
                                {
                                    string sqltb = "select * from zy_orderrecord where order_id='" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "'";
                                    DataTable tbtb = FrmMdiMain.Database.GetDataTable(sqltb);
                                    string msg_wardid = "";
                                    long msg_deptid = long.Parse(myTb.Rows[i]["EXEC_DEPT"].ToString().Trim());
                                    long msg_empid = 0;
                                    string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                                    string msg_msg = FrmMdiMain.CurrentDept.DeptName + " 科室 " + myTb.Rows[i]["姓名"].ToString().Trim() + " 的";
                                    msg_msg += "【" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "】在时间" + tbtb.Rows[0]["ORDER_EDATE"].ToString() + "停止治疗\r\n";
                                    TrasenFrame.Classes.WorkStaticFun.SendMessage(false, SystemModule.住院护士站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
                                }

                            }
                            catch { }

                        }
                        catch (Exception err)
                        {
                            //写错误日志 Add By Tany 2005-01-12
                            SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "程序错误", "医嘱转抄错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                            _systemErrLog.Save();
                            _systemErrLog = null;

                            MessageBox.Show("错误：医嘱转抄时出错，请重新转抄！\n系统：" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        if (Kind == 1)
                        {
                            //加入对化验单的审核zy_jy_print
                            sSql = "update zy_jy_print set finish_bit=1 where delete_bit=0 and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "' and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim();

                            try
                            {
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                            catch (Exception err)
                            {
                                //写错误日志 Add By Tany 2005-01-12
                                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "程序错误", "化验单审核错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                                _systemErrLog.Save();
                                _systemErrLog = null;

                                MessageBox.Show("错误：化验单审核时出错！\n系统：" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }

                        this.progressBar1.Value += 1;
                        #endregion
                    }

                    #region 护理等信息，需要遍历查找 by tany
                    sSql1 = "";
                    tmpSql = "";
                    if (this.Kind == 1)
                    {
                        if (Convert.ToInt16(myTb.Rows[i]["停"]) == 0)
                        {
                            //开医嘱转抄
                            if (Convert.ToInt16(myTb.Rows[i]["护理级别"]) != 0)
                            {
                                sSql1 = "ORDER_HL='" + myTb.Rows[i]["Order_ID"].ToString() + "',ORDER_HL_SPEC='" + myTb.Rows[i]["医嘱内容"].ToString() + "',ORDER_TENDLEVEL=" + myTb.Rows[i]["护理级别"].ToString();
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["病重"]) != 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BZ='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["病危"]) != 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BW='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["饮食"]) != 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_YS='" + myTb.Rows[i]["Order_ID"].ToString() + "',ORDER_YS_SPEC='" + myTb.Rows[i]["医嘱内容"].ToString() + "'";
                            }

                        }
                        else
                        {
                            //停医嘱转抄
                            if (Convert.ToInt16(myTb.Rows[i]["护理级别"]) != 0 && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_hl"].ToString().Trim())
                            {
                                sSql1 = "ORDER_HL=null,ORDER_HL_SPEC='',ORDER_TENDLEVEL=0";
                                //Add By Tany 2005-01-12
                                //如果是停护理级别还要看和现在护理记录表里面的级别是不是一致
                                //主要是防止先开新护理，后停老护理的时候会把新护理记录清除
                                tmpSql = "order_tendlevel=" + myTb.Rows[i]["护理级别"].ToString().Trim() + " and";
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["病重"]) != 0 && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_bz"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BZ=null"; ;
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["病危"]) != 0 && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_bw"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BW=null";
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["饮食"]) != 0 && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_ys"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_YS=null,ORDER_YS_SPEC=''";
                            }
                        }
                        if (sSql1 != "")
                        {
                            sSql = "update zy_inpatient_hl set " + sSql1 + " where " + tmpSql +
                                " inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "' and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim();

                            try
                            {
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                            catch (Exception err)
                            {
                                //写错误日志 Add By Tany 2005-01-12
                                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "程序错误", "更新护理记录错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                                _systemErrLog.Save();
                                _systemErrLog = null;

                                MessageBox.Show("错误：更新护理记录时出错！\n系统：" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                    #endregion

                    //区域医疗相关 2011-07-24
                    try
                    {
                        string isUseQyyl = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("QYYL", "是否启用", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\QyylInterface.ini");
                        if (isUseQyyl == "1")
                        {
                            if (Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select grjkdah from yy_brxx a inner join zy_inpatient b on a.brxxid=b.patient_id where b.inpatient_id='" + myTb.Rows[i]["inpatient_id"].ToString() + "'"), "") != "")
                            {
                                string QyylType = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("QYYL", "类型", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\QyylInterface.ini");

                                ts_qyyl_interface.Iqyyl qyyl = ts_qyyl_interface.QyylFactory.Qyyl(QyylType);

                                if (Convert.ToInt16(myTb.Rows[i]["停"]) == 0)
                                {
                                    qyyl.SetZyyz(myTb.Rows[i]["order_id"].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if(sf_wtg)
            {
                MessageBox.Show("审方不通过的医嘱（X）和未审方的医嘱（O）不能转抄,\n请通知医生与住院药房的审方药师进行沟通");
            }

            //			database.Close();

            if (jmcxTb != null && jmcxTb.Rows.Count != 0)
            {
                frmJmcx fj = new frmJmcx();
                fj.inTb = jmcxTb;
                fj._orderlist = orderlist;//add by zouchihua 2013-8-27 医嘱id
                fj.ShowDialog();
                //fj.Dispose();
            }
            this.progressBar1.Value = 0;

            this.Show_Data();
        }

        private bool AllowYxZc(string YPHH)
        {
            //阳性是否允许转抄
            bool result = false;
            string YXYP = (new SystemCfg(7005)).Config;

            if (YXYP.IndexOf(YPHH.Trim()) >= 0)
                result = true;

            return result;
        }

        private void bt退出_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmYZZC_Load_1(object sender, EventArgs e)
        {
            //7096医嘱转抄默认选定病人还是全选病人 0=全选病人 1=选定病人
            if (new SystemCfg(7096).Config == "1")
            {
                rb选定病人.Checked = true;
            }
            else
            {
                rb所有病人.Checked = true;
            }
        }

        /// <summary>
        /// 增加频次选择
        /// </summary>
        /// <param name="pl">频率</param>
        private void addPlCmb(string pl)
        {
            int num = 1;
            if (pl.Trim() != "")
            {
                string sSql = "select * from JC_FREQUENCY where upper(name)=upper('" + pl.Trim() + "')";
                DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

                if (myTb.Rows.Count > 0)
                {
                    num = Convert.ToInt32(Convertor.IsNull(myTb.Rows[0]["execnum"], "1"));
                }
            }

            ComboBox cmb = new ComboBox();
            cmb.Items.Clear();
            for (int i = 0; i <= num; i++)
            {
                cmb.Items.Add(i);
            }

            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.Dock = DockStyle.Fill;
            cmb.Cursor = Cursors.Hand;
            cmb.DropDownWidth = 80;
            cmb.BackColor = Color.LightCyan;
            cmb.SelectionChangeCommitted += new EventHandler(cmbPl_SelectionChangeCommitted);
            DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles["次"];
            dgtb.TextBox.Controls.Clear();//必须先清空
            dgtb.TextBox.Controls.Add(cmb);
        }

        private void cmbPl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource; ;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            try
            {
                this.myDataGrid1[this.myDataGrid1.CurrentCell] = ((ComboBox)sender).Text.ToString().Trim();
                int num = Convert.ToInt32(((ComboBox)sender).Text);
                myTb.Rows[nrow]["次"] = num;

                string sql = "";
                if (Convert.ToInt32(myTb.Rows[nrow]["停"]) == 0)
                {
                    sql = "update zy_orderrecord set first_times=" + num + " where inpatient_id='" + myTb.Rows[nrow]["inpatient_id"].ToString() + "' and baby_id=" + myTb.Rows[nrow]["baby_id"].ToString() + " and mngtype=" + myTb.Rows[nrow]["mngtype"].ToString() + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString();
                }
                else if (Convert.ToInt32(myTb.Rows[nrow]["停"]) == 1)
                {
                    sql = "update zy_orderrecord set terminal_times=" + num + " where inpatient_id='" + myTb.Rows[nrow]["inpatient_id"].ToString() + "' and baby_id=" + myTb.Rows[nrow]["baby_id"].ToString() + " and mngtype=" + myTb.Rows[nrow]["mngtype"].ToString() + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString();
                }
                FrmMdiMain.Database.DoCommand(sql);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("选择次数错误！请重新选择。\n" + err.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridEx1_Click(object sender, EventArgs e)
        {
            myFunc.SelCol_Click(this.dataGridEx1);
        }

        private void dataGridEx1_CurrentCellChanged(object sender, EventArgs e)
        {
            myFunc.SelRow(this.dataGridEx1);
        }

        private void bt全选1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(0, this.dataGridEx1);
        }

        private void bt反选1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(1, this.dataGridEx1);
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {
            //DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            //if (myTb == null) return;
            //if (myTb.Rows.Count == 0) return;

            //Cursor.Current = PubStaticFun.WaitCursor();

            //for (i = 0; i <= myTb.Rows.Count - 1; i++)
            //{
            //    if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
            //    {

            //    }
            //}

            //Cursor.Current = Cursors.Default;
        }

        private void bt显示切换_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < _dockingManager.Contents.Count; i++)
            {
                if (_dockingManager.Contents[i].Visible)
                {
                    _dockingManager.HideContent(_dockingManager.Contents[i]);
                }
                else
                {
                    _dockingManager.ShowContent(_dockingManager.Contents[i]);
                }
            }
        }

        private void btn_yzdy_Click(object sender, EventArgs e)
        {
            DataTable dy_table = (DataTable)this.myDataGrid1.DataSource;
            if (dy_table.Rows.Count < 0)
            {
                MessageBox.Show("没有可以打印的医嘱");
                return;
            }
            string ID = "";
            int count = 0;
            string zyh = "";
            string ch = "";
            string xm = "";
            string rq = "";
            string sj = "";
            string ys = "";
            int lx = 0;
            DataTable dy_table_new = null;
            DataTable dyzytable = null;

            //  DataRow[] rows = dy_table.Select("选=true", "sort asc");
            DataRow[] rows = dy_table.Select("选=true", "");

            DataTable t = dy_table.Clone();
            t.Clear();
            foreach (DataRow row in rows)
            {
                t.ImportRow(row);
            }
            if (t.Rows.Count == 0)
                dy_table_new = dy_table;
            else
                dy_table_new = t;


            if (!dy_table_new.Columns.Contains("sort"))
            {
                dy_table_new.Columns.Add("sort", Type.GetType("System.Int32"));
            }
            for (int i = 0; i < dy_table_new.Rows.Count; i++)
            {
                if (dy_table_new.Rows[i]["INPATIENT_ID"].ToString() != ID)
                {
                    ID = dy_table_new.Rows[i]["INPATIENT_ID"].ToString();
                    zyh = dy_table_new.Rows[i]["住院号"].ToString();
                    ch = dy_table_new.Rows[i]["床号"].ToString();
                    xm = dy_table_new.Rows[i]["姓名"].ToString();
                    rq = dy_table_new.Rows[i]["日期"].ToString();
                    sj = dy_table_new.Rows[i]["时间"].ToString();
                    ys = dy_table_new.Rows[i]["医生"].ToString();
                    if (dy_table_new.Rows[i]["类型"].ToString() == "长嘱")
                        dy_table_new.Rows[i]["sort"] = 0;
                    else
                        dy_table_new.Rows[i]["sort"] = 1;
                    lx = Convert.ToInt32(dy_table_new.Rows[i]["sort"].ToString());
                }
                else
                {
                    if (dy_table_new.Rows[i]["INPATIENT_ID"].ToString() == ID && dy_table_new.Rows[i]["类型"].ToString() == "")
                        dy_table_new.Rows[i]["sort"] = lx;
                    if (dy_table_new.Rows[i]["INPATIENT_ID"].ToString() == ID && dy_table_new.Rows[i]["类型"].ToString() == "临嘱")
                    {
                        dy_table_new.Rows[i]["住院号"] = zyh;
                        dy_table_new.Rows[i]["床号"] = ch;
                        dy_table_new.Rows[i]["姓名"] = xm;
                        dy_table_new.Rows[i]["日期"] = rq;
                        dy_table_new.Rows[i]["时间"] = sj;
                        dy_table_new.Rows[i]["医生"] = ys;
                        dy_table_new.Rows[i]["sort"] = 1;
                        lx = 1;
                    }

                }
            }
            DataRow[] rows1 = dy_table_new.Select(" ", "sort asc");

            DataTable t1 = dy_table_new.Clone();
            t1.Clear();
            foreach (DataRow row in rows1)
            {
                t1.ImportRow(row);
            }
            dyzytable = t1;

            DateTime date = DateTime.Now;
            String strTime = date.GetDateTimeFormats('y')[0].ToString();//年月
            string url = Path.GetDirectoryName(Application.StartupPath);
            Trasen.jqg.Print.Interface.IPrinter printer = new Trasen.jqg.Print.ReportPrinter();
            printer.ReportTemplateFile = Application.StartupPath + "\\医嘱转抄报表.grf";
            Trasen.jqg.Print.Interface.IParameter[] par = new Trasen.jqg.Print.Interface.IParameter[1];
            par[0] = new Trasen.jqg.Print.ReportParameter("time", strTime);
            printer.PrintDataSource = dyzytable;
            printer.ReportParameters = par;
            printer.Preview();


        }

        /// <summary>
        /// 拒绝流程  add by jchl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefuse_Click(object sender, EventArgs e)
        {
            try
            {
                //1、发送状态1拒绝为保存状态0（长期、临时医嘱）     
                //2、医生停医嘱3状态拒绝为护士转抄状态2（长期医嘱）
                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count == 0) return;

                string sSql = "", sSql1 = "", sSql2 = "", tmpSql = "";
                int i = 0, iSelectRows = 0;
                if (cfg7212.Config.Trim() == "1")
                {
                    myTb.DefaultView.RowFilter = "";
                    DataTable temptbb = myTb.DefaultView.ToTable();
                    myTb.DefaultView.RowFilter = "";
                    if (!GxZxks(temptbb)) return;
                }
                DataRow dr;

                #region 有效性判断
                SystemCfg cfg = new SystemCfg(7041);
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["医嘱内容"].ToString().Trim().IndexOf("出院", 0) >= 0 || myTb.Rows[i]["医嘱内容"].ToString().Trim().IndexOf("转", 0) >= 0
                        || myTb.Rows[i]["医嘱内容"].ToString().Trim().IndexOf("病人死亡", 0) >= 0 || myTb.Rows[i]["医嘱内容"].ToString().Trim().IndexOf("术后医嘱", 0) >= 0 || myTb.Rows[i]["医嘱内容"].ToString().Trim().IndexOf("产后医嘱", 0) >= 0)
                    {
                        MessageBox.Show("对不起，转科、出院、死亡医嘱不能拒绝转抄，请联系医生直接删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (i == 0 || myTb.Rows[i]["Group_ID"].ToString().Trim() != myTb.Rows[i - 1]["Group_ID"].ToString().Trim()
                        || myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim())
                    {
                        if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                        {
                            if (!myTb.Rows[i]["status_flag"].ToString().Trim().Equals("1"))
                            {
                                MessageBox.Show("对不起，该医嘱" + myTb.Rows[i]["医嘱内容"].ToString() + "不允许操作,只有发送的医嘱才能拒绝！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            iSelectRows += 1;
                        }
                    }

                }
                #endregion

                if (iSelectRows == 0)
                {
                    MessageBox.Show(this, "对不起，没有需要拒绝的医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(this, "确认要拒绝转抄选择的医嘱吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
                if (this.Kind == 1 && new SystemCfg(7066).Config == "0")
                {
                    frmInPassword f1 = new frmInPassword();
                    f1.ShowDialog();
                    bool isHSZ = f1.isHSZ;
                    if (f1.isLogin == false) return;
                }

                Cursor.Current = PubStaticFun.WaitCursor();

                this.progressBar1.Maximum = iSelectRows;
                this.progressBar1.Value = 0;

                Hashtable hsDept = new Hashtable();
                Hashtable hsBed = new Hashtable();

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();

                    for (i = 0; i <= myTb.Rows.Count - 1; i++)
                    {
                        if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                        {
                            if (!(i != 0 && myTb.Rows[i]["Group_ID"].ToString().Trim() == myTb.Rows[i - 1]["Group_ID"].ToString().Trim()
                                && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                            {
                                //校验该医嘱是否已发送
                                string vSql = "select * from zy_OrderRecord where delete_bit=0 and group_id=" +
                                                myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                                 "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                                 "       and status_flag = 1 " +
                                                  "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim() + tmpSql;

                                //校验该组医嘱是否为发送状态
                                DataTable vTb = FrmMdiMain.Database.GetDataTable(vSql);

                                if (vTb.Rows.Count <= 0)
                                {
                                    InstanceForm.BDatabase.RollbackTransaction();
                                    this.progressBar1.Value = 0;
                                    return;
                                }

                                #region 事务

                                //插入拒绝记录到拒绝表
                                DataRow[] drGrps = myTb.Select("group_id='" + myTb.Rows[i]["group_id"].ToString().Trim() + "'");
                                foreach (DataRow drGrp in drGrps)
                                {
                                    string iSql = "insert into zy_jjyzzc(id,order_id,inpatient_id,status_flag,refuse_flag,refuse_context,refuse_No,refuse_name,refuse_time) values ('" +
                                        TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString() + "','" + drGrp["Order_ID"].ToString() + "','" + drGrp["inpatient_id"].ToString() + "',1,0,''," + InstanceForm.BCurrentUser.EmployeeId + ",'" + InstanceForm.BCurrentUser.Name + "','" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "')";
                                    InstanceForm.BDatabase.DoCommand(iSql);
                                }

                                //更新医嘱表至状态保存0
                                sSql = @"update zy_OrderRecord set status_flag=0 where delete_bit=0 and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                         "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                         "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim() + tmpSql;

                                InstanceForm.BDatabase.DoCommand(sSql);

                                if (!hsDept.ContainsKey(myTb.Rows[i]["dept_id"].ToString().Trim()))
                                {
                                    ArrayList al = new ArrayList();
                                    StringBuilder sb = new StringBuilder();

                                    al.Add(myTb.Rows[i]["Inpatient_ID"].ToString().Trim());
                                    sb.Append(myTb.Rows[i]["床号"].ToString().Trim() + "、");

                                    hsDept.Add(myTb.Rows[i]["dept_id"].ToString().Trim(), al);
                                    hsBed.Add(myTb.Rows[i]["dept_id"].ToString().Trim(), sb);
                                }
                                else
                                {
                                    ArrayList al = hsDept[myTb.Rows[i]["dept_id"].ToString().Trim()] as ArrayList;
                                    StringBuilder sb = hsBed[myTb.Rows[i]["dept_id"].ToString().Trim()] as StringBuilder;

                                    if (!al.Contains(myTb.Rows[i]["Inpatient_ID"].ToString().Trim()))
                                    {
                                        al.Add(myTb.Rows[i]["Inpatient_ID"].ToString().Trim());
                                        sb.Append(myTb.Rows[i]["床号"].ToString().Trim() + "、");
                                    }
                                }


                                this.progressBar1.Value += 1;
                                #endregion
                            }
                        }
                    }

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception ex)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    this.progressBar1.Value = 0;
                    MessageBox.Show("错误：医嘱转抄时出错，请重新转抄！\n系统：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                try
                {
                    try
                    {
                        //string sqltb = "select * from zy_orderrecord where order_id='" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "'";
                        //DataTable tbtb = FrmMdiMain.Database.GetDataTable(sqltb);
                        //string msg_wardid = "";
                        //long msg_deptid = long.Parse(myTb.Rows[i]["EXEC_DEPT"].ToString().Trim());
                        //long msg_empid = 0;
                        //string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                        //string msg_msg = FrmMdiMain.CurrentDept.DeptName + " 科室 " + myTb.Rows[i]["姓名"].ToString().Trim() + " 的";
                        //msg_msg += "【" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "】在时间" + tbtb.Rows[0]["ORDER_EDATE"].ToString() + "停止治疗\r\n";
                        //TrasenFrame.Classes.WorkStaticFun.SendMessage(false, SystemModule.住院护士站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
                        //add by zouchihua 2013-8-15
                        string jzyzxx = "";

                        if (hsDept.Count > 0)
                        {

                            foreach (DictionaryEntry de in hsDept)
                            {
                                string dept = de.Key.ToString();

                                StringBuilder sb = hsBed[dept] as StringBuilder;
                                sb.Remove(sb.Length - 1, 1);
                                jzyzxx = "有拒绝转抄的医嘱，请立即处理！\r\n" + sb.ToString() + " 床\r\n 拒绝人：" + InstanceForm.BCurrentUser.Name + jzyzxx;
                                MessageInfo msg = new MessageInfo();
                                msg.ReciveDeptId = Convert.ToInt32(dept);
                                //msg.ReciveStaffer = InstanceF;
                                msg.FontColor = Color.Red;
                                msg.ReciveSystem = null;
                                //msg.ReciveWardId = 0;// FrmMdiMain.CurrentDept.WardId;
                                msg.Summary = jzyzxx;
                                //msg.SendTime = DateManager.ServerDateTimeByDBType(InstanceForm._database);

                                //msg.AssemblyParameter = "1 2 3";
                                msg.AssemblyFuncationName = "Fun_Ts_zyys_main_1";
                                msg.AssemblyTag = "";
                                msg.AssemblyDLL = "Ts_zyys_main";
                                msg.AssemblyFormText = "住院医生主界面";
                                msg.IsMustRead = true;
                                WorkStaticFun.SendMessage(msg);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                catch (Exception err)
                {
                    //写错误日志 Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "程序错误", "医嘱转抄错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show("错误：医嘱转抄时出错，请重新转抄！\n系统：" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                this.progressBar1.Value = 0;

                this.Show_Data();
            }
            catch { }
        }

        private void ucShowCard1_MyDelEvent()
        {
            ucShowCard1.Value = ucShowCard1.Row["姓名"].ToString();
            ucShowCard1.Key = ucShowCard1.Row["INPATIENT_ID"].ToString();

            DataTable dt = dataGridEx1.DataSource as DataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return;

            dt.DefaultView.RowFilter = "INPATIENT_ID='" + ucShowCard1.Key + "'";
        }

        private void DoInitCtr(string[] headtext, string[] mappingname, string[] serchFileds, int[] cols, DataTable dtSrc)
        {
            ucShowCard1.Init(headtext, mappingname, serchFileds, cols, dtSrc);
        }
    }
}
