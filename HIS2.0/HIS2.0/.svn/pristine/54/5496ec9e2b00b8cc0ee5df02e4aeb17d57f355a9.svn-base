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
using TrasenFrame.Forms;
using Ts_zyys_public;

namespace ts_yf_cx
{
    /// <summary>
    /// Frmkccx 的摘要说明。
    /// </summary>
    public class Frmkccx : System.Windows.Forms.Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbypzlx;
        private System.Windows.Forms.CheckBox chkyplx;
        private System.Windows.Forms.CheckBox chkypzlx;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkjx;
        private System.Windows.Forms.CheckBox chkqkcwl;
        private System.Windows.Forms.CheckBox chkqjy;
        private System.Windows.Forms.ComboBox cmbjx;
        private System.Windows.Forms.Button butcx;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.ComboBox cmbyplx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdm;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
        private System.Windows.Forms.Panel panel2;
        private myDataGrid.myDataGrid myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn col_批号;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.TextBox cmbsccj;
        private System.Windows.Forms.CheckBox chksccj;
        private System.Windows.Forms.DataGridTextBoxColumn col_效期;
        private System.Windows.Forms.Button butjy;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
        private System.Windows.Forms.DataGridTextBoxColumn 商品名;
        private YpConfig s;
        private System.Windows.Forms.DataGridTextBoxColumn 零售金额;
        private System.Windows.Forms.DataGridTextBoxColumn 货号;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private ComboBox cmbyjks;
        private Label label6;
        private CheckBox chkqkcxyl;
        private CheckBox chkbwl;
        private ComboBox cmbsort;
        private Label label2;
        private DataGridTextBoxColumn dataGridTextBoxColumn11;
        private CheckBox chkykdw;
        private ComboBox cmblyfl;
        private CheckBox chklyfs;
        private Button butexcel;
        private DataGridTextBoxColumn dataGridTextBoxColumn20;
        private Button buttbxkc;
        private DataGridTextBoxColumn col_yppch;
        private bool bpcgl = false;

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frmkccx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
            if (s.网络内容显示商品名 == true)
                this.商品名.Width = 110;
            else
                this.商品名.Width = 0;


            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttbxkc = new System.Windows.Forms.Button();
            this.butexcel = new System.Windows.Forms.Button();
            this.chklyfs = new System.Windows.Forms.CheckBox();
            this.cmblyfl = new System.Windows.Forms.ComboBox();
            this.chkykdw = new System.Windows.Forms.CheckBox();
            this.cmbsort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butjy = new System.Windows.Forms.Button();
            this.cmbsccj = new System.Windows.Forms.TextBox();
            this.chksccj = new System.Windows.Forms.CheckBox();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butcx = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkbwl = new System.Windows.Forms.CheckBox();
            this.chkqkcxyl = new System.Windows.Forms.CheckBox();
            this.chkqjy = new System.Windows.Forms.CheckBox();
            this.chkqkcwl = new System.Windows.Forms.CheckBox();
            this.cmbjx = new System.Windows.Forms.ComboBox();
            this.chkjx = new System.Windows.Forms.CheckBox();
            this.cmbypzlx = new System.Windows.Forms.ComboBox();
            this.chkyplx = new System.Windows.Forms.CheckBox();
            this.chkypzlx = new System.Windows.Forms.CheckBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.零售金额 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.货号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_yppch = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_批号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_效期 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn2 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttbxkc);
            this.groupBox1.Controls.Add(this.butexcel);
            this.groupBox1.Controls.Add(this.chklyfs);
            this.groupBox1.Controls.Add(this.cmblyfl);
            this.groupBox1.Controls.Add(this.chkykdw);
            this.groupBox1.Controls.Add(this.cmbsort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.butjy);
            this.groupBox1.Controls.Add(this.cmbsccj);
            this.groupBox1.Controls.Add(this.chksccj);
            this.groupBox1.Controls.Add(this.txtdm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butcx);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cmbjx);
            this.groupBox1.Controls.Add(this.chkjx);
            this.groupBox1.Controls.Add(this.cmbypzlx);
            this.groupBox1.Controls.Add(this.chkyplx);
            this.groupBox1.Controls.Add(this.chkypzlx);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // buttbxkc
            // 
            this.buttbxkc.Location = new System.Drawing.Point(726, 74);
            this.buttbxkc.Name = "buttbxkc";
            this.buttbxkc.Size = new System.Drawing.Size(134, 25);
            this.buttbxkc.TabIndex = 50;
            this.buttbxkc.Text = "同步虚拟库存";
            this.buttbxkc.Click += new System.EventHandler(this.buttbxkc_Click);
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(714, 12);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(72, 28);
            this.butexcel.TabIndex = 49;
            this.butexcel.Text = "导出(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // chklyfs
            // 
            this.chklyfs.Location = new System.Drawing.Point(15, 118);
            this.chklyfs.Name = "chklyfs";
            this.chklyfs.Size = new System.Drawing.Size(88, 25);
            this.chklyfs.TabIndex = 48;
            this.chklyfs.Text = "领药方式";
            this.chklyfs.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // cmblyfl
            // 
            this.cmblyfl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblyfl.Enabled = false;
            this.cmblyfl.Location = new System.Drawing.Point(104, 123);
            this.cmblyfl.Name = "cmblyfl";
            this.cmblyfl.Size = new System.Drawing.Size(144, 20);
            this.cmblyfl.TabIndex = 47;
            // 
            // chkykdw
            // 
            this.chkykdw.Location = new System.Drawing.Point(738, 103);
            this.chkykdw.Name = "chkykdw";
            this.chkykdw.Size = new System.Drawing.Size(122, 24);
            this.chkykdw.TabIndex = 45;
            this.chkykdw.Text = "以药库单位查看";
            // 
            // cmbsort
            // 
            this.cmbsort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsort.Items.AddRange(new object[] {
            "货位号",
            "品名",
            "货号",
            "剂型"});
            this.cmbsort.Location = new System.Drawing.Point(564, 46);
            this.cmbsort.Name = "cmbsort";
            this.cmbsort.Size = new System.Drawing.Size(102, 20);
            this.cmbsort.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(534, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "排序";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(104, 22);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(144, 20);
            this.cmbyjks.TabIndex = 42;
            this.cmbyjks.SelectionChangeCommitted += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(35, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "药剂科室";
            // 
            // butjy
            // 
            this.butjy.Location = new System.Drawing.Point(726, 47);
            this.butjy.Name = "butjy";
            this.butjy.Size = new System.Drawing.Size(134, 25);
            this.butjy.TabIndex = 37;
            this.butjy.Text = "禁用库存为零的批号";
            this.butjy.Click += new System.EventHandler(this.butjy_Click);
            // 
            // cmbsccj
            // 
            this.cmbsccj.Enabled = false;
            this.cmbsccj.Location = new System.Drawing.Point(352, 20);
            this.cmbsccj.Name = "cmbsccj";
            this.cmbsccj.Size = new System.Drawing.Size(176, 21);
            this.cmbsccj.TabIndex = 35;
            this.cmbsccj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // chksccj
            // 
            this.chksccj.Location = new System.Drawing.Point(260, 20);
            this.chksccj.Name = "chksccj";
            this.chksccj.Size = new System.Drawing.Size(95, 24);
            this.chksccj.TabIndex = 36;
            this.chksccj.Text = "生产厂家";
            this.chksccj.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // txtdm
            // 
            this.txtdm.Location = new System.Drawing.Point(352, 47);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(176, 21);
            this.txtdm.TabIndex = 33;
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdm_KeyUp);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(283, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "代码查询";
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.Enabled = false;
            this.cmbyplx.Location = new System.Drawing.Point(104, 47);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(144, 20);
            this.cmbyplx.TabIndex = 31;
            this.cmbyplx.SelectedIndexChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(640, 12);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(72, 28);
            this.butprint.TabIndex = 30;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(788, 12);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(72, 28);
            this.butquit.TabIndex = 29;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butcx
            // 
            this.butcx.Location = new System.Drawing.Point(567, 12);
            this.butcx.Name = "butcx";
            this.butcx.Size = new System.Drawing.Size(72, 28);
            this.butcx.TabIndex = 28;
            this.butcx.Text = "查询(&V)";
            this.butcx.Click += new System.EventHandler(this.butcx_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkbwl);
            this.groupBox3.Controls.Add(this.chkqkcxyl);
            this.groupBox3.Controls.Add(this.chkqjy);
            this.groupBox3.Controls.Add(this.chkqkcwl);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(254, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 48);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选项";
            // 
            // chkbwl
            // 
            this.chkbwl.Location = new System.Drawing.Point(344, 15);
            this.chkbwl.Name = "chkbwl";
            this.chkbwl.Size = new System.Drawing.Size(123, 24);
            this.chkbwl.TabIndex = 32;
            this.chkbwl.Text = "库存不为零的药品";
            this.chkbwl.CheckedChanged += new System.EventHandler(this.chkbwl_CheckedChanged);
            // 
            // chkqkcxyl
            // 
            this.chkqkcxyl.Location = new System.Drawing.Point(134, 18);
            this.chkqkcxyl.Name = "chkqkcxyl";
            this.chkqkcxyl.Size = new System.Drawing.Size(104, 19);
            this.chkqkcxyl.TabIndex = 31;
            this.chkqkcxyl.Text = "仅库存小于零";
            this.chkqkcxyl.CheckedChanged += new System.EventHandler(this.chkqkcxyl_CheckedChanged);
            // 
            // chkqjy
            // 
            this.chkqjy.Location = new System.Drawing.Point(240, 15);
            this.chkqjy.Name = "chkqjy";
            this.chkqjy.Size = new System.Drawing.Size(104, 24);
            this.chkqjy.TabIndex = 29;
            this.chkqjy.Text = "仅禁用的药品";
            this.chkqjy.CheckedChanged += new System.EventHandler(this.chkqjy_CheckedChanged);
            // 
            // chkqkcwl
            // 
            this.chkqkcwl.Location = new System.Drawing.Point(8, 16);
            this.chkqkcwl.Name = "chkqkcwl";
            this.chkqkcwl.Size = new System.Drawing.Size(128, 24);
            this.chkqkcwl.TabIndex = 28;
            this.chkqkcwl.Text = "仅库存为零的药品";
            this.chkqkcwl.CheckedChanged += new System.EventHandler(this.chkqkcwl_CheckedChanged);
            // 
            // cmbjx
            // 
            this.cmbjx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjx.Enabled = false;
            this.cmbjx.Location = new System.Drawing.Point(104, 97);
            this.cmbjx.Name = "cmbjx";
            this.cmbjx.Size = new System.Drawing.Size(144, 20);
            this.cmbjx.TabIndex = 22;
            // 
            // chkjx
            // 
            this.chkjx.Enabled = false;
            this.chkjx.Location = new System.Drawing.Point(16, 95);
            this.chkjx.Name = "chkjx";
            this.chkjx.Size = new System.Drawing.Size(88, 25);
            this.chkjx.TabIndex = 23;
            this.chkjx.Text = "药品剂型";
            this.chkjx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // cmbypzlx
            // 
            this.cmbypzlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbypzlx.Enabled = false;
            this.cmbypzlx.Location = new System.Drawing.Point(104, 72);
            this.cmbypzlx.Name = "cmbypzlx";
            this.cmbypzlx.Size = new System.Drawing.Size(144, 20);
            this.cmbypzlx.TabIndex = 19;
            this.cmbypzlx.DropDown += new System.EventHandler(this.cmbypzlx_DropDown);
            // 
            // chkyplx
            // 
            this.chkyplx.Location = new System.Drawing.Point(16, 46);
            this.chkyplx.Name = "chkyplx";
            this.chkyplx.Size = new System.Drawing.Size(88, 24);
            this.chkyplx.TabIndex = 20;
            this.chkyplx.Text = "药品类型";
            this.chkyplx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // chkypzlx
            // 
            this.chkypzlx.Enabled = false;
            this.chkypzlx.Location = new System.Drawing.Point(16, 69);
            this.chkypzlx.Name = "chkypzlx";
            this.chkypzlx.Size = new System.Drawing.Size(88, 24);
            this.chkypzlx.TabIndex = 21;
            this.chkypzlx.Text = "药品子类型";
            this.chkypzlx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(407, 341);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.商品名,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.零售金额,
            this.货号,
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn10});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.Width = 110;
            // 
            // 商品名
            // 
            this.商品名.Format = "";
            this.商品名.FormatInfo = null;
            this.商品名.HeaderText = "商品名";
            this.商品名.Width = 110;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.Width = 80;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "零售价";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "虚库存量";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "库存量";
            this.dataGridTextBoxColumn8.Width = 65;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "单位";
            this.dataGridTextBoxColumn9.Width = 30;
            // 
            // 零售金额
            // 
            this.零售金额.Format = "";
            this.零售金额.FormatInfo = null;
            this.零售金额.HeaderText = "零售金额";
            this.零售金额.Width = 75;
            // 
            // 货号
            // 
            this.货号.Format = "";
            this.货号.FormatInfo = null;
            this.货号.HeaderText = "货号";
            this.货号.Width = 55;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.AllowNull = false;
            this.dataGridBoolColumn1.FalseValue = ((short)(0));
            this.dataGridBoolColumn1.HeaderText = "禁用";
            this.dataGridBoolColumn1.NullValue = ((short)(0));
            this.dataGridBoolColumn1.TrueValue = ((short)(1));
            this.dataGridBoolColumn1.Width = 35;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "cjid";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "货位号";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "批发价";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "批发金额";
            this.dataGridTextBoxColumn10.Width = 65;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 509);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(868, 24);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 150;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Text = "双击库存记录可禁用库存量为零的药品";
            this.statusBarPanel4.Width = 300;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.splitter1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(868, 361);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存情况";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 341);
            this.panel1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(410, 17);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 341);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(418, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 341);
            this.panel2.TabIndex = 2;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(447, 341);
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid2.DoubleClick += new System.EventHandler(this.myDataGrid2_DoubleClick);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5,
            this.col_yppch,
            this.col_批号,
            this.col_效期,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridBoolColumn2,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn19});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "进价";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // col_yppch
            // 
            this.col_yppch.Format = "";
            this.col_yppch.FormatInfo = null;
            this.col_yppch.HeaderText = "批次号";
            this.col_yppch.Width = 95;
            // 
            // col_批号
            // 
            this.col_批号.Format = "";
            this.col_批号.FormatInfo = null;
            this.col_批号.HeaderText = "批号";
            this.col_批号.Width = 60;
            // 
            // col_效期
            // 
            this.col_效期.Format = "";
            this.col_效期.FormatInfo = null;
            this.col_效期.HeaderText = "效期";
            this.col_效期.NullText = "";
            this.col_效期.Width = 75;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "库存量";
            this.dataGridTextBoxColumn13.Width = 60;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "单位";
            this.dataGridTextBoxColumn14.Width = 30;
            // 
            // dataGridBoolColumn2
            // 
            this.dataGridBoolColumn2.AllowNull = false;
            this.dataGridBoolColumn2.FalseValue = ((short)(0));
            this.dataGridBoolColumn2.HeaderText = "禁用";
            this.dataGridBoolColumn2.NullValue = ((short)(0));
            this.dataGridBoolColumn2.ReadOnly = true;
            this.dataGridBoolColumn2.TrueValue = ((short)(1));
            this.dataGridBoolColumn2.Width = 30;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "cjid";
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "id";
            this.dataGridTextBoxColumn17.Width = 0;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "备注";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.Width = 60;
            // 
            // Frmkccx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(868, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmkccx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "库存情况查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmkccx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void chkyplx_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbyplx.Enabled = chkyplx.Checked == true ? true : false;

            chkypzlx.Enabled = chkyplx.Checked == true ? true : false;
            cmbypzlx.Enabled = chkypzlx.Checked == true ? true : false;

            chkjx.Enabled = chkyplx.Checked == true ? true : false;
            cmbjx.Enabled = chkjx.Checked == true ? true : false;
            cmbsccj.Enabled = chksccj.Checked == true ? true : false;

            cmblyfl.Enabled = chklyfs.Checked == true ? true : false;

            if (chkyplx.Checked == false)
            {
                chkypzlx.Checked = false;
                chkjx.Checked = false;

            }
        }

        private void butcx_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;
                tbmx.Rows.Clear();

                //DataTable tb=new DataTable("Tb");
                string ssql = "";
                if (chkykdw.Checked == false)
                    ssql = "select 0  序号,yppm 品名,ypspm 商品名,ypgg 规格,s_sccj 厂家," +
                     " " +
                     " cast(round(lsj/dwbl,4) as float) 零售价,cast(xnkcl as float) 虚库存量," +
                     " cast(kcl as float) 库存量," +
                     " dbo.fun_yp_ypdw(zxdw) 单位," +
                     " " +
                     " cast(round(lsj*kcl/dwbl,2) as decimal(15,2)) 零售金额," +
                     " shh 货号,CAST(BDELETE_KC AS SMALLINT) 禁用,cjid,b.hwmc 货位号," +
                     "cast(round(pfj/dwbl,4) as float) 批发价,cast(round(pfj*kcl/dwbl,2) as decimal(18,2)) 批发金额 " +
                     " from vi_yf_kcmx a left join yp_hwsz b on a.ggid=b.ggid and a.deptid=b.deptid " +
                     " where a.deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + " ";
                else
                    ssql = "select 0  序号,yppm 品名,ypspm 商品名,ypgg 规格,s_sccj 厂家," +
                     " " +
                     " lsj 零售价,cast(round(xnkcl/dwbl,3) as float) 虚库存量," +
                     " cast(round(kcl/dwbl,3) as float) 库存量," +
                     " s_ypdw 单位," +
                     "" +
                     " cast(round(lsj*kcl/dwbl,2) as decimal(15,2)) 零售金额," +
                     " shh 货号,CAST(BDELETE_KC AS SMALLINT) 禁用,cjid,b.hwmc 货位号,  " +
                     "pfj 批发价, cast(round(pfj*kcl/dwbl,2) as decimal(18,2)) 批发金额 " +
                     " from vi_yf_kcmx a left join yp_hwsz b on a.ggid=b.ggid and a.deptid=b.deptid " +
                     " where a.deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + " ";

                if (chkyplx.Checked == true && Convertor.IsNull(cmbyplx.SelectedValue, "") != "0") ssql = ssql + " and yplx=" + Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")) + " ";
                if (chkypzlx.Checked == true) ssql = ssql + " and ypzlx=" + Convert.ToInt32(Convertor.IsNull(cmbypzlx.SelectedValue, "0")) + " ";
                if (chkjx.Checked == true) ssql = ssql + " and ypjx=" + Convert.ToInt32(Convertor.IsNull(cmbjx.SelectedValue, "0")) + " ";
                if (chksccj.Checked == true) ssql = ssql + " and sccj=" + Convert.ToInt32(Convertor.IsNull(cmbsccj.Tag, "0")) + " ";

                if (chkqkcwl.Checked == true)
                {
                    ssql = ssql + " and kcl=0 and bdelete_kc=0";
                }

                if (chkqkcxyl.Checked == true)
                {
                    ssql = ssql + " and kcl<0 ";
                }

                if (chkqjy.Checked == true)
                {
                    ssql = ssql + " and  bdelete_kc=1";
                }

                if (chkqkcwl.Checked == false && chkqjy.Checked == false && chkbwl.Checked == false)
                {
                    ssql = ssql + " and  (bdelete_kc=0 or kcl<>0 )";
                }

                if (chkbwl.Checked == true)
                {
                    ssql = ssql + " and  kcl<>0";
                }

                if (chklyfs.Checked == true)
                    ssql = ssql + " and tlfl='" + Convertor.IsNull(cmblyfl.SelectedValue, "") + "'";


                if (txtdm.Text.Trim() != "")
                {
                    ssql = ssql + " and ( a.ggid in(select ggid from yp_ypbm where upper(pym) like '" + txtdm.Text.Trim().ToUpper() + "%' or upper(wbm) like '" + txtdm.Text.Trim().ToUpper() + "%'" +
                        " or upper(szm) like '" + txtdm.Text.Trim().ToUpper() + "%' or ypbm like '%" + txtdm.Text.Trim() + "%') or shh like '%" + txtdm.Text.Trim() + "%')";
                }

                switch (cmbsort.SelectedIndex)
                {
                    case 0:
                        ssql = ssql + " order by hwmc,yplx,ypjx,a.ggid,a.cjid";
                        break;
                    case 1:
                        ssql = ssql + " order by yppm";
                        break;
                    case 2:
                        ssql = ssql + " order by shh";
                        break;
                    case 3:
                        ssql = ssql + " order by n_yplx,s_ypjx";
                        break;
                    default:
                        break;
                }




                //////tb=InstanceForm.BDatabase.GetDataTable(ssql);
                //////FunBase.AddRowtNo(tb);
                //////tb.TableName="Tb";
                //////this.myDataGrid1.DataSource=tb;
                //////this.myDataGrid1.TableStyles[0].MappingName="Tb";

                DataView dv = InstanceForm.BDatabase.GetDataTable(ssql, 60).DefaultView;
                FunBase.AddRowtNo(dv.Table);
                dv.Table.TableName = "Tb";
                //myDataGrid1.DataMember = "Tb";
                myDataGrid1.DataSource = dv;

                DataTable tb = dv.Table;
                decimal sumpfje = 0;
                decimal sumlsje = 0;
                decimal sumplce = 0;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                    sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                }
                sumplce = sumlsje - sumpfje;
                this.statusBar1.Panels[0].Text = "批发金额 " + sumpfje.ToString("0.00");
                this.statusBar1.Panels[1].Text = "零售金额 " + sumlsje.ToString("0.00");
                this.statusBar1.Panels[2].Text = "批零差额 " + sumplce.ToString("0.00");
            }
            catch (System.Exception err)
            {
                MessageBox.Show("对不起,发生错误" + err.Message);
            }
        }

        private void Frmkccx_Load(object sender, System.EventArgs e)
        {
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_cx_kccx") this.butjy.Visible = false;
            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");

            FunBase.CsDataGrid(this.myDataGrid2, this.myDataGrid2.TableStyles[0], "Tb1");

            if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_cx_kccx_noKc")
            {
                dataGridTextBoxColumn20.Width = 0;
                dataGridTextBoxColumn8.Width = 0;
                dataGridTextBoxColumn13.Width = 0;
                butprint.Visible = false;
            }

            Yp.AddcmbYjks(cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

            if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) != DeptType.未知)
            {
                cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                cmbyjks.Enabled = false;
            }

            Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), this.cmbyplx, InstanceForm.BDatabase);

            cmbsort.SelectedIndex = 0;

            Yp.Addcmbtlfl(cmblyfl, InstanceForm.BDatabase);
        }

        private void cmbypzlx_DropDown(object sender, System.EventArgs e)
        {
            Yp.AddCmbYpzlx(Convert.ToInt32(cmbyjks.SelectedValue), Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")), this.cmbypzlx, InstanceForm.BDatabase);
            Yp.AddcmbYpjx(Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")), this.cmbjx, InstanceForm.BDatabase);
        }

        private void cmbyplx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            cmbypzlx.DataSource = null;
            cmbjx.DataSource = null;
        }

        private void butquit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void butprint_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    string yplx=chkyplx.Checked==true?Convertor.IsNull(cmbyplx.Text,"全部"):"全部";
            //    string ypzlx=chkypzlx.Checked==true?Convertor.IsNull(cmbypzlx.Text,"全部"):"全部";
            //    string ypjx=chkjx.Checked==true?Convertor.IsNull(cmbjx.Text,"全部"):"全部";

            //    DataTable tb=(DataTable)this.myDataGrid1.DataSource;
            //    ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();

            //    DataRow myrow;
            //    for(int i=0;i<=tb.Rows.Count-1;i++)
            //    {
            //        myrow=Dset.库存情况表.NewRow();
            //        myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
            //        if (s.打印单据时单据显示商品名==true)
            //            myrow["ypspm"]=Convert.ToString(tb.Rows[i]["商品名"]);
            //        else
            //            myrow["ypspm"]=Convert.ToString(tb.Rows[i]["品名"]);
            //        myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
            //        myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
            //        myrow["pfj"]=Convert.ToString(tb.Rows[i]["批发价"]);
            //        myrow["lsj"]=Convert.ToString(tb.Rows[i]["零售价"]);
            //        myrow["kcl"]=Convert.ToString(tb.Rows[i]["库存量"]);
            //        myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
            //        myrow["pfje"]=Convert.ToString(tb.Rows[i]["批发金额"]);
            //        myrow["lsje"]=Convert.ToString(tb.Rows[i]["零售金额"]);
            //        myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
            //        myrow["hwh"] = Convert.ToString(tb.Rows[i]["货位号"]);
            //        Dset.库存情况表.Rows.Add(myrow);

            //    }

            //    ParameterEx[] parameters=new ParameterEx[4];
            //    parameters[0].Text="yplx";
            //    parameters[0].Value=yplx.Trim();
            //    parameters[1].Text="ypzlx";
            //    parameters[1].Value=ypzlx.Trim();
            //    parameters[2].Text="ypjx";
            //    parameters[2].Value=ypjx.Trim();
            //    parameters[3].Text="TITLETEXT";
            //    parameters[3].Value=TrasenFrame.Classes.Constant.HospitalName+"("+cmbyjks.Text.Trim()+")"+this.Text;


            //    TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.库存情况表,Constant.ApplicationDirectory+"\\Report\\YF_库存情况表.rpt",parameters);
            //    if (f.LoadReportSuccess) f.Show();else  f.Dispose();

            //}
            //catch(System.Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}

            try
            {
                string yplx = chkyplx.Checked == true ? Convertor.IsNull(cmbyplx.Text, "全部") : "全部";
                string ypzlx = chkypzlx.Checked == true ? Convertor.IsNull(cmbypzlx.Text, "全部") : "全部";
                string ypjx = chkjx.Checked == true ? Convertor.IsNull(cmbjx.Text, "全部") : "全部";

                DataView dv = (DataView)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

                DataRow myrow;
                for (int i = 0; i <= dv.Table.Rows.Count - 1; i++)
                {
                    myrow = Dset.库存情况表.NewRow();
                    myrow["xh"] = Convert.ToInt32(dv[i]["序号"]);
                    if (s.打印单据时单据显示商品名 == true)
                        myrow["ypspm"] = Convert.ToString(dv[i]["商品名"]);
                    else
                        myrow["ypspm"] = Convert.ToString(dv[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(dv[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(dv[i]["厂家"]);
                    myrow["pfj"] = Convert.ToString(dv[i]["批发价"]);
                    myrow["lsj"] = Convert.ToString(dv[i]["零售价"]);
                    myrow["kcl"] = Convert.ToString(dv[i]["库存量"]);
                    myrow["ypdw"] = Convert.ToString(dv[i]["单位"]);
                    myrow["pfje"] = Convert.ToString(dv[i]["批发金额"]);
                    myrow["lsje"] = Convert.ToString(dv[i]["零售金额"]);
                    myrow["shh"] = Convert.ToString(dv[i]["货号"]);
                    myrow["hwh"] = Convert.ToString(dv[i]["货位号"]);
                    Dset.库存情况表.Rows.Add(myrow);

                }

                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "yplx";
                parameters[0].Value = yplx.Trim();
                parameters[1].Text = "ypzlx";
                parameters[1].Value = ypzlx.Trim();
                parameters[2].Text = "ypjx";
                parameters[2].Value = ypjx.Trim();
                parameters[3].Text = "TITLETEXT";
                parameters[3].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + cmbyjks.Text.Trim() + ")" + this.Text;


                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.库存情况表, Constant.ApplicationDirectory + "\\Report\\YF_库存情况表.rpt", parameters);
                if (f.LoadReportSuccess) f.Show(); else f.Dispose();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtdm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyCode) == 13) this.butcx_Click(sender, e);
        }

        private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow > tb.Rows.Count - 1) return;
                int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);

                if (Convert.ToBoolean(tb.Rows[nrow]["禁用"]) == true)
                {
                    if (MessageBox.Show(this, "您要 [取消禁用] 当前这个库存药品吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    string ssql = "update Yf_kcmx set bdelete=0 where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + "";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    tb.Rows[nrow]["禁用"] = (short)0;
                }
                else
                {
                    //					if (Convert.ToDecimal(tb.Rows[nrow]["库存量"])!=0) {MessageBox.Show("库存不为零时不能禁用");return;}
                    if (MessageBox.Show(this, "您要 [禁用] 当前这个库存药品吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;

                    string ssql = "select *  from Yf_kcph where cjid=" + cjid + " and deptid=" + InstanceForm.BCurrentDept.DeptId + " and bdelete=0";
                    //					DataTable tbmx=DatabaseAccess.GetDataTable(DatabaseType.IbmDb2 ,ssql);
                    //					if (tbmx.Rows.Count!=0) {MessageBox.Show("对不起,这个药品的相关批号还有库存,不能禁用");return;}

                    ssql = "update Yf_kcmx set bdelete=1 where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + "";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    tb.Rows[nrow]["禁用"] = (short)1;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            try
            {
                DataView dv = (DataView)this.myDataGrid1.DataSource;
                DataTable tb = dv.Table;
                //DataTable tb=(DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow > tb.Rows.Count - 1) return;
                string ssql = "";
                if (chkykdw.Checked == false)
                    ssql = "select jhj 进价,yppch 批次号, ypph 批号,ypxq 效期,kcl 库存量,dbo.fun_yp_ypdw(zxdw) 单位,cast(BDELETE as smallint)  禁用,cjid,id,(case when ykbdelete=1 then '库存禁用' else ''end) 备注 from Yf_kcph where cjid=" + Convert.ToInt32(dv[nrow]["cjid"]) + " and deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + "";
                else
                    ssql = "select jhj*dwbl 进价, yppch 批次号,ypph 批号,ypxq 效期,cast(round(kcl/dwbl,3) as float) 库存量,s_ypdw 单位,cast(a.BDELETE as smallint)  禁用,a.cjid,id,(case when ykbdelete=1 then '库存禁用' else ''end) 备注 from Yf_kcph a,yp_ypcjd b  where a.cjid=b.cjid and a.cjid=" + Convert.ToInt32(dv[nrow]["cjid"]) + " and deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + "";

                ssql += " order by djsj desc,yppch desc ";
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                tbmx.TableName = "Tb1";
                this.myDataGrid2.DataSource = tbmx;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            try
            {
                Control control = (Control)sender;

                if (control.Text.Trim() == "")
                {
                    control.Text = "";
                    control.Tag = "0";
                }

                if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (control.Tag.ToString() == "0" || control.Tag.ToString() == "")))
                {
                }
                else
                {
                    return;
                }

                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 35://生产厂家
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard(sender, ShowCardType.厂家, 0, point, Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }



        private void myDataGrid2_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药房操作员
                && InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药库操作员)
                {
                    MessageBox.Show("非药房药库操作员不能执行该操作");
                    return;
                }

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_cx_kccx") return;
                DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                int nrow = this.myDataGrid2.CurrentCell.RowNumber;
                if (nrow > tb.Rows.Count - 1) return;
                int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
                Guid id = new Guid(tb.Rows[nrow]["id"].ToString());
                string bz = "";
                string sdate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                if (Convert.ToString(tb.Rows[nrow]["备注"]).Trim() != "")
                {
                    MessageBox.Show("药库禁用了此药品，只有药库人员才有权限更改此药品的禁用状态");
                    return;
                }

                if (Convert.ToBoolean(tb.Rows[nrow]["禁用"]) == true)
                {
                    if (MessageBox.Show(this, "您要 [取消禁用] 当前这个库存批号吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;

                    string ssql = "update Yf_kcph set bdelete=0 where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + " and id='" + id + "'";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    ssql = "update Yf_kcmx set bdelete=0 where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + "";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    tb.Rows[nrow]["禁用"] = (short)0;
                    bz = InstanceForm.BCurrentDept.DeptName + "取消禁用的批号为 [" + tb.Rows[nrow]["批号"].ToString() + "] 当时该批号库存为 " + tb.Rows[nrow]["库存量"] + tb.Rows[nrow]["单位"].ToString();
                }
                else
                {
                    if (MessageBox.Show(this, "您要 [禁用] 当前这个库存批号吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    string ssql = "update Yf_kcph set bdelete=1 where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + " and id='" + id + "'";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    bz = InstanceForm.BCurrentDept.DeptName + "禁用的批号为 [" + tb.Rows[nrow]["批号"].ToString() + "] 当时该批号库存为 " + tb.Rows[nrow]["库存量"] + tb.Rows[nrow]["单位"].ToString();
                    ssql = "select * from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + " and bdelete=0";
                    DataTable tbph = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tbph.Rows.Count == 0)
                    {
                        bz = "◆" + bz;
                        ssql = "update Yf_kcmx set bdelete=1 where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + "";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }
                    tb.Rows[nrow]["禁用"] = (short)1;
                }
                Yp.InsertLog("禁用药品", InstanceForm.BCurrentDept.DeptId, cjid, InstanceForm.BCurrentUser.EmployeeId, sdate, bz, InstanceForm.BDatabase);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }



        private void chkqkcwl_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkqkcwl.Checked == true)
            {
                this.chkqkcxyl.Checked = false;
                this.chkqjy.Checked = false;
                this.chkbwl.Checked = false;
            }

        }

        private void chkqjy_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkqjy.Checked == true)
            {
                this.chkqkcxyl.Checked = false;
                this.chkqkcwl.Checked = false;
                this.chkbwl.Checked = false;
            }
        }

        private void chkqkcxyl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkqkcxyl.Checked == true)
            {
                this.chkqjy.Checked = false;
                this.chkqkcwl.Checked = false;
                this.chkbwl.Checked = false;
            }
        }

        private void butjy_Click(object sender, System.EventArgs e)
        {
            if (InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药房操作员
            && InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药库操作员)
            {
                MessageBox.Show("非药房药库操作员不能执行该操作");
                return;
            }

            if (MessageBox.Show(this, "您要禁用当前所有库存批号为零的药品吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;



            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                string ssql = "update yf_kcph set bdelete=1 where id not in( " +
                    " select isnull((select top 1 id from yf_kcph where cjid=a.cjid and deptid=a.deptid order by kcl desc),dbo.FUN_GETEMPTYGUID()) " +
                    " from yf_kcph a where deptid=" + InstanceForm.BCurrentDept.DeptId +
                    ")  and deptid=" + InstanceForm.BCurrentDept.DeptId + " and kcl=0";
                InstanceForm.BDatabase.DoCommand(ssql);

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("更新成功");
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message);
            }
        }

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), this.cmbyplx, InstanceForm.BDatabase);
        }

        private void chkbwl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkbwl.Checked == true)
            {
                this.chkqjy.Checked = false;
                this.chkqkcwl.Checked = false;
                this.chkqkcxyl.Checked = false;
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                //  DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataView dv = (DataView)this.myDataGrid1.DataSource;

                // 创建Excel对象                  
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = dv.Table.Rows.Count;
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = this.Text;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                //查询条件
                string bz = "";
                bz = bz + "药剂科室:" + cmbyjks.Text.Trim() + "    库存金额:" + dv.Table.Compute("sum(零售金额)", "").ToString(); ;
                string swhere = "  " + bz;
                // 设置条件
                Excel.Range rangeT = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT = new object[1, 1];
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                objDataT[0, 0] = swhere;
                range.Value2 = objDataT;



                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        objData[0, colIndex++] = myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= dv.Table.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; j++)
                    {
                        if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width > 0)
                        {
                            objData[i + 1, colIndex++] = "" + dv[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void buttbxkc_Click(object sender, EventArgs e)
        {
            #region 权限确认
            try
            {

                string dlgvalue = DlgPW.Show();
                string pwStr = dlgvalue; //YS.Password;
                bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                if (!bOk)
                {
                    FrmMessageBox.Show("你没有通过权限确认，不能同步虚拟库存！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor = Cursors.Default;
                    return;
                }

                string ssql = "update yf_kcmx set xnkcl=kcl where deptid=" + InstanceForm.BCurrentDept.DeptId + " ";
                InstanceForm.BDatabase.DoCommand(ssql);

                string str = InstanceForm.BCurrentUser.Name + "于 " + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString() + " 同步了虚库存";
                SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "同频虚库存", str, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                systemLog.Save();
                systemLog = null;

                MessageBox.Show("同步成功!");

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
            bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);
            if (bpcgl)
            {
                col_yppch.Width = 100;
            }
            else
            {
                col_yppch.Width = 0;
            }
        }



    }
}
