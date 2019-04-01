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

namespace ts_yk_ck
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class Frmtitle : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.Button butnew;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button butsh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.CheckBox chkdjsj;
        private System.Windows.Forms.TextBox txtdjh;
        private System.Windows.Forms.CheckBox chkdjh;
        private System.Windows.Forms.TextBox txtghdw;
        private System.Windows.Forms.CheckBox chkghdw;
        private System.Windows.Forms.RadioButton rdo2;
        private System.Windows.Forms.RadioButton rdo1;
        private System.Windows.Forms.Button butref;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
        private System.Windows.Forms.Button butdel;
        private MenuTag _menuTag;
        private string _chineseName;
        private System.Windows.Forms.DataGridTextBoxColumn 领药科室;
        private System.Windows.Forms.DataGridTextBoxColumn 申领单号;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private ComboBox cmbck;
        private Label label3;
        private DataGridTextBoxColumn dataGridTextBoxColumn22;
        private DataGridTextBoxColumn dataGridTextBoxColumn23;
        private DataGridTextBoxColumn dataGridTextBoxColumn24;
        private Button butexcel;
        private DataGridTextBoxColumn 接收状态;
        private RadioButton rdocgrk;
        private DataGridTableStyle dataGridTableStyle3;
        private DataGridTextBoxColumn dataGridTextBoxColumn25;
        private DataGridTextBoxColumn dataGridTextBoxColumn26;
        private DataGridTextBoxColumn dataGridTextBoxColumn27;
        private DataGridTextBoxColumn dataGridTextBoxColumn28;
        private DataGridTextBoxColumn dataGridTextBoxColumn29;
        private DataGridTextBoxColumn dataGridTextBoxColumn30;
        private DataGridTextBoxColumn dataGridTextBoxColumn31;
        private DataGridTextBoxColumn dataGridTextBoxColumn32;
        private DataGridTextBoxColumn dataGridTextBoxColumn33;
        private DataGridTextBoxColumn dataGridTextBoxColumn34;
        private DataGridTextBoxColumn dataGridTextBoxColumn35;
        private DataGridTextBoxColumn dataGridTextBoxColumn36;
        private DataGridTextBoxColumn dataGridTextBoxColumn37;
        private DataGridTextBoxColumn dataGridTextBoxColumn38;
        private DataGridTextBoxColumn dataGridTextBoxColumn39;
        private DataGridTextBoxColumn dataGridTextBoxColumn40;
        private DataGridTextBoxColumn dataGridTextBoxColumn41;
        private RadioButton rdoLsbc;
        private Form _mdiParent;

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        /// <param name="menuTag">菜单对象	</param>
        /// <param name="chineseName">菜单中文名</param>
        /// <param name="mdiParent">当前窗口父对象</param>
        public Frmtitle(MenuTag menuTag, string chineseName, Form mdiParent)
        {

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;


            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            this.Text = _chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";

            Yp.AddcmbCk(true, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.领药科室 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.申领单号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.接收状态 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.butexcel = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butsh = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.butnew = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdocgrk = new System.Windows.Forms.RadioButton();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.chkdjsj = new System.Windows.Forms.CheckBox();
            this.txtdjh = new System.Windows.Forms.TextBox();
            this.chkdjh = new System.Windows.Forms.CheckBox();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.chkghdw = new System.Windows.Forms.CheckBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.butref = new System.Windows.Forms.Button();
            this.rdoLsbc = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 485);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.myDataGrid1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 72);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(832, 357);
            this.panel5.TabIndex = 3;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(832, 357);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1,
            this.dataGridTableStyle2,
            this.dataGridTableStyle3});
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.myDataGrid1_Navigate);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.领药科室,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.申领单号,
            this.接收状态});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "仓库名称";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.Width = 75;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "打印";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.ReadOnly = true;
            this.dataGridTextBoxColumn24.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "单据号";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "单据日期";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 85;
            // 
            // 领药科室
            // 
            this.领药科室.Format = "";
            this.领药科室.FormatInfo = null;
            this.领药科室.HeaderText = "领药科室";
            this.领药科室.NullText = "";
            this.领药科室.ReadOnly = true;
            this.领药科室.Width = 125;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "进货金额";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 65;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "批发金额";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 65;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "零售金额";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 65;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "登记时间";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 125;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "登记员";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "审核时间";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 0;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "审核员";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 0;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "备注";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "id";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // 申领单号
            // 
            this.申领单号.Format = "";
            this.申领单号.FormatInfo = null;
            this.申领单号.HeaderText = "申领单号";
            this.申领单号.NullText = "";
            this.申领单号.ReadOnly = true;
            this.申领单号.Width = 0;
            // 
            // 接收状态
            // 
            this.接收状态.Format = "";
            this.接收状态.FormatInfo = null;
            this.接收状态.HeaderText = "接收状态";
            this.接收状态.NullText = "";
            this.接收状态.Width = 120;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "序号";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 50;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "仓库名称";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.Width = 75;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "申领单号";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "申领科室";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 125;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "申领时间";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 130;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "申领人";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "备注";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 250;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "id";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.Width = 0;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "单据号";
            this.dataGridTextBoxColumn20.Width = 0;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "deptid";
            this.dataGridTextBoxColumn21.Width = 0;
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30,
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn32,
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn40,
            this.dataGridTextBoxColumn41});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "序号";
            this.dataGridTextBoxColumn25.Width = 40;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "仓库名称";
            this.dataGridTextBoxColumn38.Width = 70;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "打印";
            this.dataGridTextBoxColumn26.Width = 40;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "单据号";
            this.dataGridTextBoxColumn37.Width = 60;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "单据日期";
            this.dataGridTextBoxColumn27.Width = 70;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "供货单位";
            this.dataGridTextBoxColumn28.Width = 150;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "业务员";
            this.dataGridTextBoxColumn29.Width = 60;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "进货金额";
            this.dataGridTextBoxColumn30.Width = 65;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "批发金额";
            this.dataGridTextBoxColumn31.Width = 65;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "零售金额";
            this.dataGridTextBoxColumn32.Width = 65;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "登记时间";
            this.dataGridTextBoxColumn33.Width = 90;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "登记员";
            this.dataGridTextBoxColumn34.Width = 60;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "审核时间";
            this.dataGridTextBoxColumn35.Width = 90;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "审核员";
            this.dataGridTextBoxColumn36.Width = 60;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "备注";
            this.dataGridTextBoxColumn39.Width = 75;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.HeaderText = "deptid";
            this.dataGridTextBoxColumn40.Width = 0;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "id";
            this.dataGridTextBoxColumn41.Width = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.butexcel);
            this.panel4.Controls.Add(this.butdel);
            this.panel4.Controls.Add(this.butclose);
            this.panel4.Controls.Add(this.butsh);
            this.panel4.Controls.Add(this.statusBar1);
            this.panel4.Controls.Add(this.butnew);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 429);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(832, 56);
            this.panel4.TabIndex = 2;
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(119, 6);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(104, 24);
            this.butexcel.TabIndex = 7;
            this.butexcel.Text = "导出(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // butdel
            // 
            this.butdel.Location = new System.Drawing.Point(480, 6);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(88, 24);
            this.butdel.TabIndex = 4;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(576, 6);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 3;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butsh
            // 
            this.butsh.Location = new System.Drawing.Point(384, 6);
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size(88, 24);
            this.butsh.TabIndex = 2;
            this.butsh.Text = "查看(&H)";
            this.butsh.Click += new System.EventHandler(this.butsh_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 32);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(832, 24);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 200;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 1000;
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(288, 6);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 0;
            this.butnew.Text = "新单据(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(832, 72);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.rdoLsbc);
            this.panel2.Controls.Add(this.rdocgrk);
            this.panel2.Controls.Add(this.cmbck);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtp2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp1);
            this.panel2.Controls.Add(this.chkdjsj);
            this.panel2.Controls.Add(this.txtdjh);
            this.panel2.Controls.Add(this.chkdjh);
            this.panel2.Controls.Add(this.txtghdw);
            this.panel2.Controls.Add(this.chkghdw);
            this.panel2.Controls.Add(this.rdo2);
            this.panel2.Controls.Add(this.rdo1);
            this.panel2.Controls.Add(this.butref);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 72);
            this.panel2.TabIndex = 3;
            // 
            // rdocgrk
            // 
            this.rdocgrk.Location = new System.Drawing.Point(24, 49);
            this.rdocgrk.Name = "rdocgrk";
            this.rdocgrk.Size = new System.Drawing.Size(120, 22);
            this.rdocgrk.TabIndex = 2;
            this.rdocgrk.Text = "查询采购入库单";
            this.rdocgrk.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(316, 12);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(112, 20);
            this.cmbck.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(261, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "仓库名称";
            // 
            // dtp2
            // 
            this.dtp2.Enabled = false;
            this.dtp2.Location = new System.Drawing.Point(556, 38);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(110, 21);
            this.dtp2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(533, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Enabled = false;
            this.dtp1.Location = new System.Drawing.Point(419, 38);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(111, 21);
            this.dtp1.TabIndex = 2;
            // 
            // chkdjsj
            // 
            this.chkdjsj.Location = new System.Drawing.Point(346, 37);
            this.chkdjsj.Name = "chkdjsj";
            this.chkdjsj.Size = new System.Drawing.Size(80, 22);
            this.chkdjsj.TabIndex = 8;
            this.chkdjsj.Text = "登记时间";
            this.chkdjsj.CheckedChanged += new System.EventHandler(this.chkshdh_CheckedChanged);
            // 
            // txtdjh
            // 
            this.txtdjh.Enabled = false;
            this.txtdjh.Location = new System.Drawing.Point(206, 39);
            this.txtdjh.Name = "txtdjh";
            this.txtdjh.Size = new System.Drawing.Size(112, 21);
            this.txtdjh.TabIndex = 1;
            // 
            // chkdjh
            // 
            this.chkdjh.Location = new System.Drawing.Point(150, 39);
            this.chkdjh.Name = "chkdjh";
            this.chkdjh.Size = new System.Drawing.Size(73, 22);
            this.chkdjh.TabIndex = 6;
            this.chkdjh.Text = "单据号";
            this.chkdjh.CheckedChanged += new System.EventHandler(this.chkshdh_CheckedChanged);
            // 
            // txtghdw
            // 
            this.txtghdw.Enabled = false;
            this.txtghdw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtghdw.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtghdw.Location = new System.Drawing.Point(529, 10);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(170, 21);
            this.txtghdw.TabIndex = 0;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // chkghdw
            // 
            this.chkghdw.Location = new System.Drawing.Point(457, 10);
            this.chkghdw.Name = "chkghdw";
            this.chkghdw.Size = new System.Drawing.Size(130, 22);
            this.chkghdw.TabIndex = 2;
            this.chkghdw.Text = "往来科室";
            this.chkghdw.CheckedChanged += new System.EventHandler(this.chkshdh_CheckedChanged);
            // 
            // rdo2
            // 
            this.rdo2.Location = new System.Drawing.Point(24, 26);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(72, 22);
            this.rdo2.TabIndex = 1;
            this.rdo2.Text = "已审核";
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(24, 4);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(88, 22);
            this.rdo1.TabIndex = 0;
            this.rdo1.Text = "申请领药单";
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // butref
            // 
            this.butref.Location = new System.Drawing.Point(690, 36);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(88, 24);
            this.butref.TabIndex = 4;
            this.butref.Text = "刷新(&R)";
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // rdoLsbc
            // 
            this.rdoLsbc.Location = new System.Drawing.Point(119, 4);
            this.rdoLsbc.Name = "rdoLsbc";
            this.rdoLsbc.Size = new System.Drawing.Size(88, 22);
            this.rdoLsbc.TabIndex = 26;
            this.rdoLsbc.Text = "临时保存";
            this.rdoLsbc.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // Frmtitle
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(832, 485);
            this.Controls.Add(this.panel1);
            this.Name = "Frmtitle";
            this.Text = "药品出库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmtitle_Load);
            this.Activated += new System.EventHandler(this.Frmtitle_Activated);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void butnew_Click(object sender, System.EventArgs e)
        {
            DataTable tb = new DataTable();
            if (this.rdo2.Checked == true) tb = (DataTable)this.myDataGrid1.DataSource;
            Frmypck f = new Frmypck(_menuTag, _chineseName, _mdiParent, tb, this.rdo1.Checked);
            Point point = new Point(160, 75);
            f.Location = point;
            f.MdiParent = _mdiParent;
            f._isLsbc = true;//Modify By Tany 2015-12-23
            f.Show();
        }

        private void chkshdh_CheckedChanged(object sender, System.EventArgs e)
        {
            this.txtghdw.Enabled = chkghdw.Checked == true ? true : false;
            this.txtdjh.Enabled = chkdjh.Checked == true ? true : false;
            this.dtp1.Enabled = chkdjsj.Checked == true ? true : false;
            this.dtp2.Enabled = chkdjsj.Checked == true ? true : false;
        }

        private void Frmtitle_Load(object sender, System.EventArgs e)
        {
            this.dtp1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            CsMydataGrid(0);
            FunctionControlEnable(_menuTag.Function_Name.Trim());
            butexcel.Visible = false;
        }

        private void FunctionControlEnable(string functionName)
        {
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_jzcfck" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_cfbl" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_jzcfck_cx" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_cfbl_cx")
            {
                this.chkghdw.Visible = false;
                this.txtghdw.Visible = false;
                this.领药科室.Width = 0;
                this.申领单号.Width = 0;
            }


            if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_qtly" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_jzcfck" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_cfbl" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_wyylyd"
                || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_qtly_cx" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_jzcfck_cx" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_cfbl_cx" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_wyylyd_cx"
                || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_dck" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_dck_cx")
            {
                this.rdo2.Checked = true;
                this.rdo1.Visible = false;
                this.rdo2.Visible = false;
                this.rdoLsbc.Visible = false;//Modify By Tany 2015-12-28
                this.申领单号.Width = 0;
            }

            if (_menuTag.Function_Name == "Fun_ts_yk_ypck_cx" || _menuTag.Function_Name == "Fun_ts_yk_ypck_qtly_cx"
                || _menuTag.Function_Name == "Fun_ts_yk_ypck_jzcfck_cx" || _menuTag.Function_Name == "Fun_ts_yk_ypck_cfbl_cx"
                || _menuTag.Function_Name == "Fun_ts_yk_ypck_wyylyd_cx" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_dck_cx")
            {
                butnew.Visible = false;
            }

            if (_menuTag.Function_Name == "Fun_ts_yk_ypck")
                rdocgrk.Visible = true;
            else
                rdocgrk.Visible = false;
        }
        private void CsMydataGrid(int shbz)
        {
            this.myDataGrid1.DataSource = null;
            if (shbz == 1)
            {
                //初始化
                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
                this.chkghdw.Text = "往来科室";
            }
            if (shbz == 0)
            {
                //初始化
                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[1], "myTb");
                this.chkghdw.Text = "申请科室";
            }
            if (shbz == 2)
            {
                //初始化
                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[2], "myTb_cg");
                this.chkghdw.Text = "供商单位";
            }
            //Add By Tany 2015-12-23
            if (shbz == 3)
            {
                //初始化
                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "tmpTb");
                this.chkghdw.Text = "往来科室";
            }
        }
        private void butref_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (chkghdw.Checked == false && chkdjh.Checked == false && chkdjsj.Checked == false && rdo2.Checked == true)
                {
                    MessageBox.Show("查询的记录范围太大，请重新选择查询条件");
                    return;
                }
                if (txtghdw.Text.Trim() == "" && txtghdw.Enabled == true) { MessageBox.Show("请输入科室"); return; }
                if (txtdjh.Text.Trim() == "" && txtdjh.Enabled == true) { MessageBox.Show("请输入单据号"); return; }

                ParameterEx[] parameters = new ParameterEx[11];
                parameters[0].Text = "@ywlx";
                parameters[0].Value = _menuTag.FunctionTag.Trim();
                parameters[1].Text = "@wldw";
                parameters[1].Value = this.chkghdw.Checked == true ? Convert.ToInt32(this.txtghdw.Tag) : 0;
                parameters[2].Text = "@dtp1";
                parameters[2].Value = chkdjsj.Checked == true ? dtp1.Value.ToShortDateString() : "";
                parameters[3].Text = "@dtp2";
                parameters[3].Value = chkdjsj.Checked == true ? dtp2.Value.ToShortDateString() : "";
                parameters[4].Text = "@djh";
                parameters[4].Value = chkdjh.Checked == true ? Convert.ToInt64(Convertor.IsNull(txtdjh.Text, "0")) : 0;
                parameters[5].Text = "@fph";
                parameters[5].Value = "";
                parameters[6].Text = "@shdh";
                parameters[6].Value = "";
                parameters[7].Text = "@shbz";
                int shbz = 0;
                if (rdo2.Checked == true) shbz = 1;
                if (rdocgrk.Checked == true) shbz = 2;
                if (rdoLsbc.Checked == true) shbz = 3;
                parameters[7].Value = shbz;
                parameters[8].Text = "@deptid";
                parameters[8].Value = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                parameters[9].Text = "@functionname";
                parameters[9].Value = _menuTag.Function_Name;
                parameters[10].Text = "@p_deptid";
                parameters[10].Value = InstanceForm.BCurrentDept.DeptId;
                DataTable tb = InstanceForm.BDatabase.GetDataTable("sp_yk_selectDj", parameters, 30);
                FunBase.AddRowtNo(tb);
                if (this.rdo1.Checked == true) tb.TableName = "myTb";
                if (this.rdo2.Checked == true) tb.TableName = "Tb";
                if (this.rdocgrk.Checked == true) tb.TableName = "myTb_cg";
                if (this.rdoLsbc.Checked == true) tb.TableName = "tmpTb";
                this.myDataGrid1.DataSource = tb;

                if (rdo1.Checked == true)
                    FunBase.myGridSelect(this.myDataGrid1, this.myDataGrid1.TableStyles[1].GridColumnStyles);
                if (rdo2.Checked == true || rdoLsbc.Checked == true)
                    FunBase.myGridSelect(this.myDataGrid1, this.myDataGrid1.TableStyles[0].GridColumnStyles);
                if (rdocgrk.Checked == true)
                    FunBase.myGridSelect(this.myDataGrid1, this.myDataGrid1.TableStyles[2].GridColumnStyles);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butclose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void butsh_Click(object sender, System.EventArgs e)
        {
            try
            {
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (tb.Rows.Count == 0)
                    return;
                Frmypck f = new Frmypck(_menuTag, _chineseName, _mdiParent, tb, this.rdo1.Checked);
                Point point = new Point(160, 75);
                f.Location = point;
                f.MdiParent = _mdiParent;
                if (rdoLsbc.Checked)
                {
                    f._isLsbc = true;//Modify By Tany 2015-12-23
                }
                else
                {
                    f._isLsbc = false;//Modify By Tany 2015-12-23
                }
                f.Show();
                if (this.rdo2.Checked == true)
                {
                    f._Sqdh = 0;
                    f.FillDj(new Guid(tb.Rows[nrow]["id"].ToString()), this.rdo2.Checked);
                }
                if (this.rdo1.Checked == true)
                {   //药房申请领药单
                    f._Sqdh = Convert.ToInt64(tb.Rows[nrow]["申领单号"]);
                    f.FillDj_Rksq(new Guid(tb.Rows[nrow]["id"].ToString()), Convert.ToInt32(tb.Rows[nrow]["deptid"]), tb.Rows[nrow]["仓库名称"].ToString());
                }
                if (this.rdocgrk.Checked == true)
                {
                    //直接拿采购入库单 进行出库
                    f.FillDj_CGD(new Guid(tb.Rows[nrow]["id"].ToString()), Convert.ToInt32(tb.Rows[nrow]["deptid"]), tb.Rows[nrow]["仓库名称"].ToString());
                }
                //Add By Tany 2015-12-23
                if (this.rdoLsbc.Checked == true)
                {
                    f._Sqdh = 0;
                    f.FillDj_Temp(new Guid(tb.Rows[nrow]["id"].ToString()));
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        private void rdo2_CheckedChanged(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
            int shbz = 0;
            if (rdo2.Checked == true) shbz = 1;
            if (rdocgrk.Checked == true) shbz = 2;
            if (rdoLsbc.Checked == true) shbz = 3;//Modify By Tany 2015-12-23
            CsMydataGrid(shbz);
            this.dataGridTableStyle2.ForeColor = System.Drawing.Color.Black;
            this.dataGridTableStyle1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
            this.dataGridTableStyle3.ForeColor = System.Drawing.Color.Black;
            this.chkdjsj.Checked = (this.rdo1.Checked || this.rdoLsbc.Checked) == true ? false : true;//Modify By Tany 2015-12-23 临时保存
            this.butdel.Enabled = (this.rdo1.Checked || this.rdoLsbc.Checked) == true ? true : false;//Modify By Tany 2015-12-23 临时保存
            this.butref_Click(sender, e);

            butexcel.Visible = this.rdo2.Checked == true ? true : false;
        }

        private void Frmtitle_Activated(object sender, System.EventArgs e)
        {
            if (rdo1.Checked == true) this.butref_Click(sender, e);

        }

        private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            butsh_Click(sender, e);
        }

        //输入框控制事件
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "") { control.Text = ""; control.Tag = "0"; }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { }
            else { return; }

            try
            {

                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 0:
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        if (rdocgrk.Checked == false)
                            Yp.frmShowCard_funName(sender, ShowCardType.单据往来科室, _menuTag.Function_Name, point, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                        else
                            Yp.frmShowCard(sender, ShowCardType.供货单位, 0, point, 0, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);
        }

        private void butdel_Click(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = Convert.ToInt32(this.myDataGrid1.CurrentCell.RowNumber);
            if (nrow > tb.Rows.Count - 1) return;
            if (MessageBox.Show("您确定要删除第" + Convert.ToString((nrow + 1)) + "行这个单据吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            this.butdel.Enabled = false;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                //Modify By Tany 2015-12-23 只有临时保存的和药房申领的可以删除
                if (rdoLsbc.Checked)
                {
                    Guid gdjid = new Guid(tb.Rows[nrow]["id"].ToString());
                    if (gdjid != Guid.Empty)
                    {
                        string ssql_temp = string.Format("delete yk_djmx_temp where djid='{0}'", gdjid);
                        InstanceForm.BDatabase.DoCommand(ssql_temp);
                        ssql_temp = string.Format("delete yk_dj_temp where id='{0}'", gdjid);
                        InstanceForm.BDatabase.DoCommand(ssql_temp);
                    }
                }
                else if (rdo1.Checked)
                {
                    YF_RKSQ_RKSQMX.DeleteDj(new Guid(tb.Rows[nrow]["id"].ToString()), InstanceForm.BDatabase);
                }

                InstanceForm.BDatabase.CommitTransaction();

                this.butdel.Enabled = true;

                MessageBox.Show("删除成功");
                this.butref_Click(sender, e);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butdel.Enabled = true;
                MessageBox.Show(err.Message);

            }
        }

        private void myDataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
        {

        }


        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;

                // 创建Excel对象                    --LeeWenjie    2006-11-29
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
                int RowCount = tb.Rows.Count;
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = _chineseName + "一览表";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        objData[0, colIndex++] = myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; j++)
                    {
                        if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width > 0)
                        {
                            if (myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText == "品名" || myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText == "商品名" || myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText == "规格")
                                objData[i + 1, colIndex++] = "'" + tb.Rows[i][j].ToString().Trim();
                            else
                                objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString().Trim();
                        }
                    }
                    Application.DoEvents();
                }

                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
