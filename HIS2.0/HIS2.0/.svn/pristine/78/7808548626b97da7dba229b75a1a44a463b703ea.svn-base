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
namespace ts_yf_cx
{
    /// <summary>
    /// Frmkccx 的摘要说明。
    /// </summary>
    public class Frmqykccx : System.Windows.Forms.Form
    {
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
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
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
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.ComboBox cmbyplx;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox4;
        private myDataGrid.myDataGrid myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.TextBox txtdm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private System.Windows.Forms.DataGridTextBoxColumn 商品名;
        private YpConfig ss;
        private DataGridBoolColumn dataGridBoolColumn1;
        private ComboBox cmbjgbm;
        private Label label6;
        private Button butexcel;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frmqykccx(MenuTag menuTag, string chineseName, Form mdiParent)
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
            ss = new YpConfig(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase);
            if (ss.网络内容显示商品名 == true)
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
            this.butexcel = new System.Windows.Forms.Button();
            this.cmbjgbm = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butcx = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butexcel);
            this.groupBox1.Controls.Add(this.cmbjgbm);
            this.groupBox1.Controls.Add(this.label6);
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
            this.groupBox1.Size = new System.Drawing.Size(928, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(777, 56);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(72, 32);
            this.butexcel.TabIndex = 67;
            this.butexcel.Text = "导出(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // cmbjgbm
            // 
            this.cmbjgbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjgbm.FormattingEnabled = true;
            this.cmbjgbm.Location = new System.Drawing.Point(495, 29);
            this.cmbjgbm.Name = "cmbjgbm";
            this.cmbjgbm.Size = new System.Drawing.Size(110, 20);
            this.cmbjgbm.TabIndex = 65;
            this.cmbjgbm.SelectedIndexChanged += new System.EventHandler(this.cmbjgbm_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(457, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 66;
            this.label6.Text = "院区";
            // 
            // txtdm
            // 
            this.txtdm.Location = new System.Drawing.Point(495, 62);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(110, 21);
            this.txtdm.TabIndex = 35;
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdm_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(439, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "代码查询";
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.Enabled = false;
            this.cmbyplx.Location = new System.Drawing.Point(104, 17);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(144, 20);
            this.cmbyplx.TabIndex = 31;
            this.cmbyplx.SelectedIndexChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(712, 56);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(64, 32);
            this.butprint.TabIndex = 30;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(851, 56);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(64, 32);
            this.butquit.TabIndex = 29;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butcx
            // 
            this.butcx.Location = new System.Drawing.Point(648, 56);
            this.butcx.Name = "butcx";
            this.butcx.Size = new System.Drawing.Size(64, 32);
            this.butcx.TabIndex = 28;
            this.butcx.Text = "查询(&V)";
            this.butcx.Click += new System.EventHandler(this.butcx_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkqjy);
            this.groupBox3.Controls.Add(this.chkqkcwl);
            this.groupBox3.Location = new System.Drawing.Point(264, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 79);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选项";
            // 
            // chkqjy
            // 
            this.chkqjy.Location = new System.Drawing.Point(16, 40);
            this.chkqjy.Name = "chkqjy";
            this.chkqjy.Size = new System.Drawing.Size(104, 24);
            this.chkqjy.TabIndex = 29;
            this.chkqjy.Text = "仅禁用的药品";
            this.chkqjy.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // chkqkcwl
            // 
            this.chkqkcwl.Location = new System.Drawing.Point(16, 16);
            this.chkqkcwl.Name = "chkqkcwl";
            this.chkqkcwl.Size = new System.Drawing.Size(128, 24);
            this.chkqkcwl.TabIndex = 28;
            this.chkqkcwl.Text = "仅库存为零的药品";
            this.chkqkcwl.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // cmbjx
            // 
            this.cmbjx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjx.Enabled = false;
            this.cmbjx.Location = new System.Drawing.Point(104, 64);
            this.cmbjx.Name = "cmbjx";
            this.cmbjx.Size = new System.Drawing.Size(144, 20);
            this.cmbjx.TabIndex = 22;
            this.cmbjx.DropDown += new System.EventHandler(this.cmbjx_DropDown);
            // 
            // chkjx
            // 
            this.chkjx.Enabled = false;
            this.chkjx.Location = new System.Drawing.Point(16, 62);
            this.chkjx.Name = "chkjx";
            this.chkjx.Size = new System.Drawing.Size(88, 24);
            this.chkjx.TabIndex = 23;
            this.chkjx.Text = "药品剂型";
            this.chkjx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // cmbypzlx
            // 
            this.cmbypzlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbypzlx.Enabled = false;
            this.cmbypzlx.Location = new System.Drawing.Point(104, 40);
            this.cmbypzlx.Name = "cmbypzlx";
            this.cmbypzlx.Size = new System.Drawing.Size(144, 20);
            this.cmbypzlx.TabIndex = 19;
            this.cmbypzlx.DropDown += new System.EventHandler(this.cmbypzlx_DropDown);
            // 
            // chkyplx
            // 
            this.chkyplx.Location = new System.Drawing.Point(16, 16);
            this.chkyplx.Name = "chkyplx";
            this.chkyplx.Size = new System.Drawing.Size(88, 24);
            this.chkyplx.TabIndex = 20;
            this.chkyplx.Text = "药品类型";
            this.chkyplx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // chkypzlx
            // 
            this.chkypzlx.Enabled = false;
            this.chkypzlx.Location = new System.Drawing.Point(16, 39);
            this.chkypzlx.Name = "chkypzlx";
            this.chkypzlx.Size = new System.Drawing.Size(88, 23);
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
            this.myDataGrid1.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(634, 393);
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
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn15});
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
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "批发价";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "零售价";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "总库存";
            this.dataGridTextBoxColumn8.Width = 65;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "单位";
            this.dataGridTextBoxColumn9.Width = 30;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "批发金额";
            this.dataGridTextBoxColumn10.Width = 0;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "零售金额";
            this.dataGridTextBoxColumn11.Width = 65;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "货号";
            this.dataGridTextBoxColumn5.Width = 55;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "cjid";
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 509);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(928, 24);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(640, 413);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "全院总库存";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(640, 96);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 413);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.myDataGrid2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(643, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 413);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "各科室分布情况";
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(279, 393);
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridBoolColumn1});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            this.dataGridTableStyle2.RowHeadersVisible = false;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "科室";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 90;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "数量";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 65;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "单位";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 30;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.AllowNull = false;
            this.dataGridBoolColumn1.FalseValue = ((short)(0));
            this.dataGridBoolColumn1.HeaderText = "禁用";
            this.dataGridBoolColumn1.NullText = "0";
            this.dataGridBoolColumn1.NullValue = ((short)(0));
            this.dataGridBoolColumn1.TrueValue = ((short)(1));
            this.dataGridBoolColumn1.Width = 40;
            // 
            // Frmqykccx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(928, 533);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmqykccx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "全院库存查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmkccx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
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
               // DataTable tb = new DataTable("Tb");
                string ssql = "select * from (select 0 序号,yppm 品名,ypspm 商品名,ypgg 规格,s_sccj 厂家,pfj 批发价,lsj 零售价," +
                        " cast(sum(kcl/dwbl) as decimal(12,3)) 总库存,dbo.fun_yp_ypdw(ypdw) 单位,cast(sum(pfj*kcl/dwbl) as decimal(18,2)) 批发金额," +
                        " cast(sum(lsj*kcl/dwbl) as decimal(14,2)) 零售金额,shh 货号,cjid from " +
                        " vi_yp_kcmx a where deptid<>0  ";
                if (chkyplx.Checked == true && Convertor.IsNull(cmbyplx.SelectedValue, "") != "0") ssql = ssql + " and yplx=" + Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")) + " ";
                if (chkypzlx.Checked == true) ssql = ssql + " and ypzlx=" + Convert.ToInt32(Convertor.IsNull(cmbypzlx.SelectedValue, "0")) + " ";
                if (chkjx.Checked == true) ssql = ssql + " and ypjx=" + Convert.ToInt32(Convertor.IsNull(cmbjx.SelectedValue, "0")) + " ";

                if (Convert.ToInt32(cmbjgbm.SelectedValue) > 0)
                    ssql = ssql + " and jgbm=" + Convert.ToInt64(cmbjgbm.SelectedValue) + " ";

                if (chkqjy.Checked == true)
                {
                    ssql = ssql + " and  bdelete_kc=1";
                }

                if (chkqkcwl.Checked == false && chkqjy.Checked == false)
                {
                    ssql = ssql + " and  (( kcl<>0 ))";
                }

                if (txtdm.Text.Trim() != "")
                {
                    ssql = ssql + " and ggid in(select ggid from yp_ypbm where Upper(pym) like '" + txtdm.Text.Trim().ToUpper() + "%' or Upper(wbm) like '" + txtdm.Text.Trim().ToUpper() + "%'" +
                        " or Upper(szm) like '" + txtdm.Text.Trim().ToUpper() + "%' or ypbm like '%" + txtdm.Text.Trim() + "%')";
                }

                ssql = ssql + " group by yppm,ypspm,ypgg,s_sccj,pfj,lsj,ypdw,shh,cjid ) a";

                if (chkqkcwl.Checked == true)
                {
                    ssql = ssql + " where  总库存=0 ";
                }

                ssql = ssql + " order by 货号";
                //tb = InstanceForm.BDatabase.GetDataTable(ssql);

                ParameterEx[] parameters = new ParameterEx[1];
                parameters[0].Value = ssql;
                parameters[0].Text = "@SSQL";
                //tb = InstanceForm.BDatabase.GetDataTable("SP_YP_EXECSQL", parameters, 30);

                DataView dv = InstanceForm.BDatabase.GetDataTable("SP_YP_EXECSQL", parameters, 30).DefaultView;
                FunBase.AddRowtNo(dv.Table);
                dv.Table.TableName = "Tb";
                myDataGrid1.DataSource = dv;

                //tb.TableName = "Tb";
                //this.myDataGrid1.DataSource = tb;
                //this.myDataGrid1.TableStyles[0].MappingName = "Tb";

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
            DataTable Tb = new DataTable();
            Tb.TableName = "Tb";
            for (int i = 0; i <= this.myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
            {
                if (this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString() == "System.Windows.Forms.DataGridBoolColumn")
                    Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText, Type.GetType("System.Int16"));
                else
                    Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText, Type.GetType("System.String"));

                this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName = this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
                this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText = "";
            }
            this.myDataGrid1.DataSource = Tb;
            this.myDataGrid1.TableStyles[0].MappingName = "Tb";


            DataTable Tb1 = new DataTable();
            Tb1.TableName = "Tb1";
            for (int i = 0; i <= this.myDataGrid2.TableStyles[0].GridColumnStyles.Count - 1; i++)
            {
                if (this.myDataGrid2.TableStyles[0].GridColumnStyles[i].GetType().ToString() == "System.Windows.Forms.DataGridBoolColumn")
                    Tb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText, Type.GetType("System.Int16"));
                else
                    Tb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText, Type.GetType("System.String"));

                this.myDataGrid2.TableStyles[0].GridColumnStyles[i].MappingName = this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText;
                this.myDataGrid2.TableStyles[0].GridColumnStyles[i].NullText = "";
            }
            this.myDataGrid2.DataSource = Tb1;
            this.myDataGrid2.TableStyles[0].MappingName = "Tb1";



            Yp.AddCmbYplx(true, InstanceForm.BCurrentDept.DeptId, this.cmbyplx, InstanceForm.BDatabase);

            Department dept = new Department(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
            ts_mz_class.FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);

            if (dept.Jgbm == 1000)
            {
                cmbjgbm.SelectedValue = "0";
            }
            else
            {
                cmbjgbm.SelectedValue = dept.Jgbm;
                cmbjgbm.Enabled = false;
            }
        }

        private void cmbypzlx_DropDown(object sender, System.EventArgs e)
        {
            Yp.AddCmbYpzlx(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")), this.cmbypzlx, InstanceForm.BDatabase);
            Yp.AddcmbYpjx(Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")), this.cmbjx,InstanceForm.BDatabase);
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
            try
            {
                string yplx = chkyplx.Checked == true ? Convertor.IsNull(cmbyplx.Text, "全部") : "全部";
                string ypzlx = chkypzlx.Checked == true ? Convertor.IsNull(cmbypzlx.Text, "全部") : "全部";
                string ypjx = chkjx.Checked == true ? Convertor.IsNull(cmbjx.Text, "全部") : "全部";

                DataView dv = (DataView)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset1 Dset = new ts_Yk_ReportView.Dataset1();
                DataRow myrow;
                for (int i = 0; i <= dv.Table.Rows.Count - 1; i++)
                {
                    myrow = Dset.库存情况表.NewRow();
                    myrow["xh"] = Convert.ToInt32(dv[i]["序号"]);
                    myrow["ypspm"] = Convert.ToString(dv[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(dv[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(dv[i]["厂家"]);
                    myrow["pfj"] = Convert.ToString(dv[i]["批发价"]);
                    myrow["lsj"] = Convert.ToString(dv[i]["零售价"]);
                    myrow["kcl"] = Convert.ToString(dv[i]["总库存"]);
                    myrow["ypdw"] = Convert.ToString(dv[i]["单位"]);
                    myrow["pfje"] = Convert.ToString(dv[i]["批发金额"]);
                    myrow["lsje"] = Convert.ToString(dv[i]["零售金额"]);
                    myrow["shh"] = Convert.ToString(dv[i]["货号"]);
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
                parameters[3].Value = TrasenFrame.Classes.Constant.HospitalName + "全院药品库存情况";
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.库存情况表, Constant.ApplicationDirectory + "\\Report\\YK_库存情况表.rpt", parameters);
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

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {

            DataView dv = (DataView)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow > dv.Table.Rows.Count - 1) return;
            DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;
            tbmx.Rows.Clear();

            //string ssql="select dbo.fun_getdeptname(deptid) 科室,cast(sum(kcl/dwbl) as decimal(15,3)) 数量,dbo.fun_yp_ypdw(ypdw) 单位,cast(bdelete_kc as smallint) 禁用 from (select * from vi_yf_kcmx union select * from vi_yk_kcmx) a where cjid="+Convert.ToInt32(tb.Rows[nrow]["cjid"])+
            //        " group by deptid,ypdw,bdelete_kc";
            string ssql = "select dbo.fun_getdeptname(deptid) 科室,cast(sum(kcl/dwbl) as decimal(15,3)) 数量,dbo.fun_yp_ypdw(ypdw) 单位,cast(bdelete_kc as smallint) 禁用 from vi_yp_kcmx a where cjid=" + Convert.ToInt32(dv[nrow]["cjid"]) + "";
            if (Convert.ToInt32(cmbjgbm.SelectedValue) > 0)
                ssql = ssql + " and jgbm=" + Convert.ToInt64(cmbjgbm.SelectedValue) + " ";
            ssql = ssql + " group by deptid,ypdw,bdelete_kc";
            //tbmx=InstanceForm.BDatabase.GetDataTable(ssql);

            ParameterEx[] parameters = new ParameterEx[1];
            parameters[0].Value = ssql;
            parameters[0].Text = "@SSQL";
            tbmx = InstanceForm.BDatabase.GetDataTable("SP_YP_EXECSQL", parameters, 30);

            tbmx.TableName = "Tb1";
            this.myDataGrid2.DataSource = tbmx;
            this.myDataGrid2.TableStyles[0].MappingName = "Tb1";

        }

        private void cmbjx_DropDown(object sender, System.EventArgs e)
        {
            Yp.AddcmbYpjx(Convert.ToInt32(cmbyplx.SelectedValue), cmbjx, InstanceForm.BDatabase);
        }

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbjgbm.SelectedValue.ToString() != "0")
                InstanceForm.BDatabase = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(cmbjgbm.SelectedValue));

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

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
                bz = bz + "";
                string swhere = " 库存金额 " + dv.Table.Compute("sum(零售金额)","").ToString();
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
                            objData[i + 1, colIndex++] = "" +dv[i][j].ToString().Trim();
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







    }
}
