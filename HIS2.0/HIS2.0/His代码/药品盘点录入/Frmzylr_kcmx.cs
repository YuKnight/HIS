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
using Aspose.Cells;
using System.Data.SqlClient;

namespace ts_yp_pdlr
{
    /// <summary>
    /// Frmyprk 的摘要说明。
    /// </summary>
    public class Frmzylr_kcmx : System.Windows.Forms.Form
    {
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn col序号;
        private System.Windows.Forms.DataGridTextBoxColumn col规格;
        private System.Windows.Forms.DataGridTextBoxColumn col厂家;
        private System.Windows.Forms.DataGridTextBoxColumn col批号;
        private System.Windows.Forms.DataGridTextBoxColumn col帐面数量;
        private System.Windows.Forms.DataGridTextBoxColumn col帐面金额;
      
        private System.Windows.Forms.DataGridTextBoxColumn col盘存数量;
        private System.Windows.Forms.DataGridTextBoxColumn col盘存金额;
        private System.Windows.Forms.DataGridTextBoxColumn col盈亏数量;
        private System.Windows.Forms.DataGridTextBoxColumn col盈亏金额;
        private System.Windows.Forms.DataGridTextBoxColumn col货号;
        private System.Windows.Forms.DataGridTextBoxColumn col单位;
        private System.Windows.Forms.DataGridTextBoxColumn colcjid;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.DataGridTextBoxColumn col批发价;
        private System.Windows.Forms.DataGridTextBoxColumn col零售价;
        private System.Windows.Forms.DataGridTextBoxColumn col批发金额;
        private System.Windows.Forms.DataGridTextBoxColumn colkcid;
        private myDataGrid.myDataGrid myDataGrid3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
        private System.Windows.Forms.DataGridTextBoxColumn colid;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn44;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn45;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn46;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn47;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label dtprq;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtbz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldjh;
        private System.Windows.Forms.Label lbldjhH;
        private System.Windows.Forms.Button butLoadData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblzmje;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblzmsl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblpcje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtypsl;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbllsj;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblpfj;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbdw;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblhh;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblypmc;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblcj;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblgg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtypdm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button butnext;
        private System.Windows.Forms.Button butmrzc;
        private System.Windows.Forms.Button butmodif;
        private System.Windows.Forms.Button butdel;
        private System.Windows.Forms.Button butadd;
        private System.Windows.Forms.TextBox txtdwcx;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butprintkb;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Button butnew;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private myDataGrid.myDataGrid myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private System.Windows.Forms.Button butprintlpyp;
        private System.Windows.Forms.Button butclose1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn48;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn49;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn50;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn51;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn52;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn53;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn54;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn55;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn56;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn57;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn58;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn59;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn60;
        private System.Windows.Forms.DataGridTextBoxColumn col库位;
        private System.Windows.Forms.DataGridTextBoxColumn col描述;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblshdjh;
        private System.Windows.Forms.CheckBox chkdw;
        private System.Windows.Forms.CheckBox chkgl;
        private System.Windows.Forms.TextBox txtph;
        private System.Windows.Forms.CheckBox chkprintlp;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.Button butsavemb;
        private System.Windows.Forms.Label lblpm;
        private System.Windows.Forms.DataGridTextBoxColumn col品名;
        private System.Windows.Forms.DataGridTextBoxColumn col商品名;
        private YpConfig ss;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lbljhj;
        private System.Windows.Forms.DataGridTextBoxColumn col进价;
        private System.Windows.Forms.Button butjy;
        private DataGridBoolColumn dataGridBoolColumn1;
        private System.Windows.Forms.ComboBox cmbck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butmrwl;
        private DataGridTextBoxColumn coldwbl;
        private DataGridTextBoxColumn colkwid;

        private bool btjhj = false;
        private DataGridTextBoxColumn dataGridTextBoxColumn1;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.CheckBox chkDxDwLr;
        private DataGridTextBoxColumn col大数量;
        private DataGridTextBoxColumn col小数量;
        private DataGridTextBoxColumn col盘存数量2;
        private DataGridTextBoxColumn col大单位;
        private DataGridTextBoxColumn col发药机库存;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btn_ImportKfj;//是否调进货价

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frmzylr_kcmx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.MdiParent = _mdiParent;

            //初始化列表myDataGrid1、myDataGrid2、myDataGrid3
            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
            FunBase.CsDataGrid(this.myDataGrid2, this.myDataGrid2.TableStyles[0], "Tb1");
            FunBase.CsDataGrid(this.myDataGrid3, this.myDataGrid3.TableStyles[0], "Tb2");

            Yp.AddcmbCk(false, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";

            this.chkDxDwLr.Visible = true;
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
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.col序号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col商品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col规格 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col厂家 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col批发价 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col批发金额 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col进价 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col零售价 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col批号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col库位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col帐面数量 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col帐面金额 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col发药机库存 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col大数量 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col小数量 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col盘存数量 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col单位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col盘存金额 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col盈亏数量 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col盈亏金额 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col货号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colcjid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colkcid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.coldwbl = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colkwid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col描述 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col盘存数量2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col大单位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.myDataGrid3 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
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
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn45 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn46 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn47 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDxDwLr = new System.Windows.Forms.CheckBox();
            this.butsavemb = new System.Windows.Forms.Button();
            this.butprintkb = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.butmrwl = new System.Windows.Forms.Button();
            this.butnext = new System.Windows.Forms.Button();
            this.butmrzc = new System.Windows.Forms.Button();
            this.butmodif = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butadd = new System.Windows.Forms.Button();
            this.txtdwcx = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.chkdw = new System.Windows.Forms.CheckBox();
            this.chkgl = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbljhj = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblpm = new System.Windows.Forms.Label();
            this.lblzmje = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblzmsl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblpcje = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtph = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtypsl = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lbllsj = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblpfj = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbdw = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblhh = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblypmc = new System.Windows.Forms.Label();
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtypdm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblshdjh = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtprq = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldjh = new System.Windows.Forms.Label();
            this.lbldjhH = new System.Windows.Forms.Label();
            this.butLoadData = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn48 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn49 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn50 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn51 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn52 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn53 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn54 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn55 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn56 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn57 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn58 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn59 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn60 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.butjy = new System.Windows.Forms.Button();
            this.chkprintlp = new System.Windows.Forms.CheckBox();
            this.butclose1 = new System.Windows.Forms.Button();
            this.butprintlpyp = new System.Windows.Forms.Button();
            this.btn_ImportKfj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(1020, 193);
            this.myDataGrid1.TabIndex = 60;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.myKeyDown += new myDataGrid.myDelegate(this.myDataGrid1_myKeyDown);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.col序号,
            this.col品名,
            this.col商品名,
            this.col规格,
            this.col厂家,
            this.col批发价,
            this.col批发金额,
            this.col进价,
            this.col零售价,
            this.col批号,
            this.col库位,
            this.col帐面数量,
            this.col帐面金额,
            this.col发药机库存,
            this.col大数量,
            this.col小数量,
            this.col盘存数量,
            this.col单位,
            this.col盘存金额,
            this.col盈亏数量,
            this.col盈亏金额,
            this.col货号,
            this.colcjid,
            this.colkcid,
            this.coldwbl,
            this.colkwid,
            this.colid,
            this.col描述,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.col盘存数量2,
            this.col大单位});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // col序号
            // 
            this.col序号.Format = "";
            this.col序号.FormatInfo = null;
            this.col序号.HeaderText = "序号";
            this.col序号.NullText = "";
            this.col序号.ReadOnly = true;
            this.col序号.Width = 40;
            // 
            // col品名
            // 
            this.col品名.Format = "";
            this.col品名.FormatInfo = null;
            this.col品名.HeaderText = "品名";
            this.col品名.NullText = "";
            this.col品名.ReadOnly = true;
            this.col品名.Width = 180;
            // 
            // col商品名
            // 
            this.col商品名.Format = "";
            this.col商品名.FormatInfo = null;
            this.col商品名.HeaderText = "商品名";
            this.col商品名.Width = 130;
            // 
            // col规格
            // 
            this.col规格.Format = "";
            this.col规格.FormatInfo = null;
            this.col规格.HeaderText = "规格";
            this.col规格.NullText = "";
            this.col规格.ReadOnly = true;
            this.col规格.Width = 120;
            // 
            // col厂家
            // 
            this.col厂家.Format = "";
            this.col厂家.FormatInfo = null;
            this.col厂家.HeaderText = "厂家";
            this.col厂家.NullText = "";
            this.col厂家.ReadOnly = true;
            this.col厂家.Width = 90;
            // 
            // col批发价
            // 
            this.col批发价.Format = "";
            this.col批发价.FormatInfo = null;
            this.col批发价.HeaderText = "批发价";
            this.col批发价.NullText = "";
            this.col批发价.ReadOnly = true;
            this.col批发价.Width = 0;
            // 
            // col批发金额
            // 
            this.col批发金额.Format = "";
            this.col批发金额.FormatInfo = null;
            this.col批发金额.HeaderText = "批发金额";
            this.col批发金额.NullText = "";
            this.col批发金额.ReadOnly = true;
            this.col批发金额.Width = 0;
            // 
            // col进价
            // 
            this.col进价.Format = "";
            this.col进价.FormatInfo = null;
            this.col进价.HeaderText = "进价";
            this.col进价.NullText = "";
            this.col进价.ReadOnly = true;
            this.col进价.Width = 0;
            // 
            // col零售价
            // 
            this.col零售价.Format = "";
            this.col零售价.FormatInfo = null;
            this.col零售价.HeaderText = "零售价";
            this.col零售价.NullText = "";
            this.col零售价.ReadOnly = true;
            this.col零售价.Width = 60;
            // 
            // col批号
            // 
            this.col批号.Format = "";
            this.col批号.FormatInfo = null;
            this.col批号.HeaderText = "批号";
            this.col批号.NullText = "";
            this.col批号.ReadOnly = true;
            this.col批号.Width = 0;
            // 
            // col库位
            // 
            this.col库位.Format = "";
            this.col库位.FormatInfo = null;
            this.col库位.HeaderText = "库位";
            this.col库位.NullText = "";
            this.col库位.ReadOnly = true;
            this.col库位.Width = 90;
            // 
            // col帐面数量
            // 
            this.col帐面数量.Format = "";
            this.col帐面数量.FormatInfo = null;
            this.col帐面数量.HeaderText = "帐面数量";
            this.col帐面数量.NullText = "";
            this.col帐面数量.ReadOnly = true;
            this.col帐面数量.Width = 80;
            // 
            // col帐面金额
            // 
            this.col帐面金额.Format = "";
            this.col帐面金额.FormatInfo = null;
            this.col帐面金额.HeaderText = "帐面金额";
            this.col帐面金额.NullText = "";
            this.col帐面金额.ReadOnly = true;
            this.col帐面金额.Width = 0;
            // 
            // col发药机库存
            // 
            this.col发药机库存.Format = "";
            this.col发药机库存.FormatInfo = null;
            this.col发药机库存.HeaderText = "发药机库存";
            this.col发药机库存.ReadOnly = true;
            this.col发药机库存.Width = 80;
            // 
            // col大数量
            // 
            this.col大数量.Format = "";
            this.col大数量.FormatInfo = null;
            this.col大数量.HeaderText = "大数量";
            this.col大数量.Width = 75;
            // 
            // col小数量
            // 
            this.col小数量.Format = "";
            this.col小数量.FormatInfo = null;
            this.col小数量.HeaderText = "小数量";
            this.col小数量.Width = 75;
            // 
            // col盘存数量
            // 
            this.col盘存数量.Format = "";
            this.col盘存数量.FormatInfo = null;
            this.col盘存数量.HeaderText = "盘存数量";
            this.col盘存数量.NullText = "";
            this.col盘存数量.Width = 80;
            // 
            // col单位
            // 
            this.col单位.Format = "";
            this.col单位.FormatInfo = null;
            this.col单位.HeaderText = "单位";
            this.col单位.NullText = "";
            this.col单位.ReadOnly = true;
            this.col单位.Width = 40;
            // 
            // col盘存金额
            // 
            this.col盘存金额.Format = "";
            this.col盘存金额.FormatInfo = null;
            this.col盘存金额.HeaderText = "盘存金额";
            this.col盘存金额.NullText = "";
            this.col盘存金额.Width = 0;
            // 
            // col盈亏数量
            // 
            this.col盈亏数量.Format = "";
            this.col盈亏数量.FormatInfo = null;
            this.col盈亏数量.HeaderText = "盈亏数量";
            this.col盈亏数量.NullText = "";
            this.col盈亏数量.ReadOnly = true;
            this.col盈亏数量.Width = 60;
            // 
            // col盈亏金额
            // 
            this.col盈亏金额.Format = "";
            this.col盈亏金额.FormatInfo = null;
            this.col盈亏金额.HeaderText = "盈亏金额";
            this.col盈亏金额.NullText = "";
            this.col盈亏金额.ReadOnly = true;
            this.col盈亏金额.Width = 0;
            // 
            // col货号
            // 
            this.col货号.Format = "";
            this.col货号.FormatInfo = null;
            this.col货号.HeaderText = "货号";
            this.col货号.NullText = "";
            this.col货号.ReadOnly = true;
            this.col货号.Width = 70;
            // 
            // colcjid
            // 
            this.colcjid.Format = "";
            this.colcjid.FormatInfo = null;
            this.colcjid.HeaderText = "CJID";
            this.colcjid.NullText = "";
            this.colcjid.ReadOnly = true;
            this.colcjid.Width = 0;
            // 
            // colkcid
            // 
            this.colkcid.Format = "";
            this.colkcid.FormatInfo = null;
            this.colkcid.HeaderText = "KCID";
            this.colkcid.NullText = "";
            this.colkcid.ReadOnly = true;
            this.colkcid.Width = 0;
            // 
            // coldwbl
            // 
            this.coldwbl.Format = "";
            this.coldwbl.FormatInfo = null;
            this.coldwbl.HeaderText = "DWBL";
            this.coldwbl.NullText = "";
            this.coldwbl.ReadOnly = true;
            this.coldwbl.Width = 0;
            // 
            // colkwid
            // 
            this.colkwid.Format = "";
            this.colkwid.FormatInfo = null;
            this.colkwid.HeaderText = "KWID";
            this.colkwid.NullText = "";
            this.colkwid.Width = 0;
            // 
            // colid
            // 
            this.colid.Format = "";
            this.colid.FormatInfo = null;
            this.colid.HeaderText = "ID";
            this.colid.NullText = "";
            this.colid.Width = 0;
            // 
            // col描述
            // 
            this.col描述.Format = "";
            this.col描述.FormatInfo = null;
            this.col描述.HeaderText = "描述";
            this.col描述.NullText = "";
            this.col描述.Width = 0;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "药品类型";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "剂型";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "帐面数量2";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 90;
            // 
            // col盘存数量2
            // 
            this.col盘存数量2.Format = "";
            this.col盘存数量2.FormatInfo = null;
            this.col盘存数量2.HeaderText = "盘存数量2";
            this.col盘存数量2.Width = 75;
            // 
            // col大单位
            // 
            this.col大单位.Format = "";
            this.col大单位.FormatInfo = null;
            this.col大单位.HeaderText = "大单位";
            this.col大单位.Width = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 592);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1034, 23);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 230;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 230;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 230;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 400;
            // 
            // myDataGrid3
            // 
            this.myDataGrid3.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid3.CaptionVisible = false;
            this.myDataGrid3.DataMember = "";
            this.myDataGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid3.Name = "myDataGrid3";
            this.myDataGrid3.Size = new System.Drawing.Size(1026, 112);
            this.myDataGrid3.TabIndex = 7;
            this.myDataGrid3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid3;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn26,
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
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn42,
            this.dataGridTextBoxColumn43,
            this.dataGridTextBoxColumn44,
            this.dataGridTextBoxColumn45,
            this.dataGridTextBoxColumn46,
            this.dataGridTextBoxColumn47});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "序号";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.ReadOnly = true;
            this.dataGridTextBoxColumn21.Width = 40;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "品名";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.ReadOnly = true;
            this.dataGridTextBoxColumn22.Width = 150;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "规格";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.ReadOnly = true;
            this.dataGridTextBoxColumn23.Width = 0;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "厂家";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.ReadOnly = true;
            this.dataGridTextBoxColumn24.Width = 0;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "批发价";
            this.dataGridTextBoxColumn25.NullText = "";
            this.dataGridTextBoxColumn25.ReadOnly = true;
            this.dataGridTextBoxColumn25.Width = 0;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "批发金额";
            this.dataGridTextBoxColumn26.NullText = "0";
            this.dataGridTextBoxColumn26.Width = 0;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "零售价";
            this.dataGridTextBoxColumn27.NullText = "0";
            this.dataGridTextBoxColumn27.ReadOnly = true;
            this.dataGridTextBoxColumn27.Width = 0;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "批号";
            this.dataGridTextBoxColumn28.NullText = "";
            this.dataGridTextBoxColumn28.ReadOnly = true;
            this.dataGridTextBoxColumn28.Width = 75;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "库位";
            this.dataGridTextBoxColumn29.NullText = "";
            this.dataGridTextBoxColumn29.ReadOnly = true;
            this.dataGridTextBoxColumn29.Width = 75;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "帐面数量";
            this.dataGridTextBoxColumn30.NullText = "0";
            this.dataGridTextBoxColumn30.ReadOnly = true;
            this.dataGridTextBoxColumn30.Width = 0;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "帐面金额";
            this.dataGridTextBoxColumn31.NullText = "0";
            this.dataGridTextBoxColumn31.ReadOnly = true;
            this.dataGridTextBoxColumn31.Width = 0;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "盘存数量";
            this.dataGridTextBoxColumn32.NullText = "";
            this.dataGridTextBoxColumn32.ReadOnly = true;
            this.dataGridTextBoxColumn32.Width = 80;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "单位";
            this.dataGridTextBoxColumn33.NullText = "";
            this.dataGridTextBoxColumn33.ReadOnly = true;
            this.dataGridTextBoxColumn33.Width = 30;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "盘存金额";
            this.dataGridTextBoxColumn34.NullText = "0";
            this.dataGridTextBoxColumn34.ReadOnly = true;
            this.dataGridTextBoxColumn34.Width = 0;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "盈亏数量";
            this.dataGridTextBoxColumn35.NullText = "0";
            this.dataGridTextBoxColumn35.ReadOnly = true;
            this.dataGridTextBoxColumn35.Width = 0;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "盈亏金额";
            this.dataGridTextBoxColumn36.NullText = "";
            this.dataGridTextBoxColumn36.ReadOnly = true;
            this.dataGridTextBoxColumn36.Width = 0;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "货号";
            this.dataGridTextBoxColumn37.NullText = "";
            this.dataGridTextBoxColumn37.ReadOnly = true;
            this.dataGridTextBoxColumn37.Width = 0;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "CJID";
            this.dataGridTextBoxColumn38.NullText = "0";
            this.dataGridTextBoxColumn38.ReadOnly = true;
            this.dataGridTextBoxColumn38.Width = 0;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "KCID";
            this.dataGridTextBoxColumn39.NullText = "0";
            this.dataGridTextBoxColumn39.ReadOnly = true;
            this.dataGridTextBoxColumn39.Width = 0;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "DWBL";
            this.dataGridTextBoxColumn42.NullText = "0";
            this.dataGridTextBoxColumn42.ReadOnly = true;
            this.dataGridTextBoxColumn42.Width = 0;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Format = "";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.HeaderText = "KWID";
            this.dataGridTextBoxColumn43.NullText = "0";
            this.dataGridTextBoxColumn43.ReadOnly = true;
            this.dataGridTextBoxColumn43.Width = 0;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.HeaderText = "ID";
            this.dataGridTextBoxColumn44.NullText = "0";
            this.dataGridTextBoxColumn44.ReadOnly = true;
            this.dataGridTextBoxColumn44.Width = 0;
            // 
            // dataGridTextBoxColumn45
            // 
            this.dataGridTextBoxColumn45.Format = "";
            this.dataGridTextBoxColumn45.FormatInfo = null;
            this.dataGridTextBoxColumn45.HeaderText = "登记员";
            this.dataGridTextBoxColumn45.NullText = "";
            this.dataGridTextBoxColumn45.ReadOnly = true;
            this.dataGridTextBoxColumn45.Width = 70;
            // 
            // dataGridTextBoxColumn46
            // 
            this.dataGridTextBoxColumn46.Format = "";
            this.dataGridTextBoxColumn46.FormatInfo = null;
            this.dataGridTextBoxColumn46.HeaderText = "登记时间";
            this.dataGridTextBoxColumn46.NullText = "";
            this.dataGridTextBoxColumn46.ReadOnly = true;
            this.dataGridTextBoxColumn46.Width = 130;
            // 
            // dataGridTextBoxColumn47
            // 
            this.dataGridTextBoxColumn47.Format = "";
            this.dataGridTextBoxColumn47.FormatInfo = null;
            this.dataGridTextBoxColumn47.HeaderText = "单据号";
            this.dataGridTextBoxColumn47.NullText = "";
            this.dataGridTextBoxColumn47.ReadOnly = true;
            this.dataGridTextBoxColumn47.Width = 60;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1034, 592);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1026, 563);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "盘点录入单";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1026, 246);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 193);
            this.panel2.TabIndex = 62;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkDxDwLr);
            this.panel1.Controls.Add(this.butsavemb);
            this.panel1.Controls.Add(this.butprintkb);
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnew);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 33);
            this.panel1.TabIndex = 61;
            // 
            // chkDxDwLr
            // 
            this.chkDxDwLr.AutoSize = true;
            this.chkDxDwLr.Location = new System.Drawing.Point(736, 10);
            this.chkDxDwLr.Name = "chkDxDwLr";
            this.chkDxDwLr.Size = new System.Drawing.Size(96, 16);
            this.chkDxDwLr.TabIndex = 74;
            this.chkDxDwLr.Text = "大小单位录入";
            this.chkDxDwLr.UseVisualStyleBackColor = true;
            this.chkDxDwLr.Visible = false;
            this.chkDxDwLr.CheckedChanged += new System.EventHandler(this.chkDxDwLr_CheckedChanged);
            // 
            // butsavemb
            // 
            this.butsavemb.Location = new System.Drawing.Point(176, 4);
            this.butsavemb.Name = "butsavemb";
            this.butsavemb.Size = new System.Drawing.Size(96, 24);
            this.butsavemb.TabIndex = 72;
            this.butsavemb.Text = "存为模板(&M)";
            this.butsavemb.Click += new System.EventHandler(this.butsavemb_Click);
            // 
            // butprintkb
            // 
            this.butprintkb.Location = new System.Drawing.Point(272, 3);
            this.butprintkb.Name = "butprintkb";
            this.butprintkb.Size = new System.Drawing.Size(96, 24);
            this.butprintkb.TabIndex = 70;
            this.butprintkb.Text = "打印空表(&M)";
            this.butprintkb.Click += new System.EventHandler(this.butprintKB_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(632, 3);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 68;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(544, 3);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 67;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(456, 3);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(88, 24);
            this.butsave.TabIndex = 66;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(368, 3);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 65;
            this.butnew.Text = "新单号(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(0, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 24);
            this.checkBox1.TabIndex = 71;
            this.checkBox1.Text = "隐藏盘点明细窗口";
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 443);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1026, 8);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 451);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1026, 112);
            this.panel3.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_ImportKfj);
            this.groupBox4.Controls.Add(this.btnImport);
            this.groupBox4.Controls.Add(this.butmrwl);
            this.groupBox4.Controls.Add(this.butnext);
            this.groupBox4.Controls.Add(this.butmrzc);
            this.groupBox4.Controls.Add(this.butmodif);
            this.groupBox4.Controls.Add(this.butdel);
            this.groupBox4.Controls.Add(this.butadd);
            this.groupBox4.Controls.Add(this.txtdwcx);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.chkdw);
            this.groupBox4.Controls.Add(this.chkgl);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1026, 40);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // btnImport
            // 
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnImport.Location = new System.Drawing.Point(820, 11);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(77, 23);
            this.btnImport.TabIndex = 87;
            this.btnImport.Text = "导入EXCEL";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // butmrwl
            // 
            this.butmrwl.Location = new System.Drawing.Point(10, 13);
            this.butmrwl.Name = "butmrwl";
            this.butmrwl.Size = new System.Drawing.Size(108, 23);
            this.butmrwl.TabIndex = 86;
            this.butmrwl.Text = "盘存数默认为零";
            this.butmrwl.Click += new System.EventHandler(this.butmrwl_Click);
            // 
            // butnext
            // 
            this.butnext.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butnext.Location = new System.Drawing.Point(324, 13);
            this.butnext.Name = "butnext";
            this.butnext.Size = new System.Drawing.Size(40, 20);
            this.butnext.TabIndex = 83;
            this.butnext.Text = "Next";
            this.butnext.Visible = false;
            this.butnext.Click += new System.EventHandler(this.butnext_Click);
            // 
            // butmrzc
            // 
            this.butmrzc.Location = new System.Drawing.Point(13, 49);
            this.butmrzc.Name = "butmrzc";
            this.butmrzc.Size = new System.Drawing.Size(67, 23);
            this.butmrzc.TabIndex = 82;
            this.butmrzc.Text = "盘点数默认为帐存数(&X)";
            this.butmrzc.Click += new System.EventHandler(this.butmrzc_Click);
            // 
            // butmodif
            // 
            this.butmodif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmodif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butmodif.Location = new System.Drawing.Point(760, 11);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(58, 23);
            this.butmodif.TabIndex = 6;
            this.butmodif.Text = "修改(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butdel.Location = new System.Drawing.Point(699, 11);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(59, 23);
            this.butdel.TabIndex = 78;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butadd.Location = new System.Drawing.Point(641, 11);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(56, 23);
            this.butadd.TabIndex = 5;
            this.butadd.Text = "添加(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // txtdwcx
            // 
            this.txtdwcx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtdwcx.ForeColor = System.Drawing.Color.Navy;
            this.txtdwcx.Location = new System.Drawing.Point(200, 13);
            this.txtdwcx.Name = "txtdwcx";
            this.txtdwcx.Size = new System.Drawing.Size(120, 21);
            this.txtdwcx.TabIndex = 80;
            this.txtdwcx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(148, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 81;
            this.label25.Text = "定位查询";
            // 
            // chkdw
            // 
            this.chkdw.Location = new System.Drawing.Point(536, 12);
            this.chkdw.Name = "chkdw";
            this.chkdw.Size = new System.Drawing.Size(104, 24);
            this.chkdw.TabIndex = 84;
            this.chkdw.Text = "允许选择单位";
            this.chkdw.CheckedChanged += new System.EventHandler(this.chkdw_CheckedChanged);
            // 
            // chkgl
            // 
            this.chkgl.Location = new System.Drawing.Point(370, 13);
            this.chkgl.Name = "chkgl";
            this.chkgl.Size = new System.Drawing.Size(175, 23);
            this.chkgl.TabIndex = 85;
            this.chkgl.Text = "录入药品时过虑已盘存药品";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbljhj);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.lblzmje);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblzmsl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblpcje);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtph);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtypsl);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lbllsj);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lblpfj);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cmbdw);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblhh);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblypmc);
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtypdm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1026, 88);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // lbljhj
            // 
            this.lbljhj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbljhj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbljhj.ForeColor = System.Drawing.Color.Navy;
            this.lbljhj.Location = new System.Drawing.Point(873, 13);
            this.lbljhj.Name = "lbljhj";
            this.lbljhj.Size = new System.Drawing.Size(96, 20);
            this.lbljhj.TabIndex = 77;
            this.lbljhj.Visible = false;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(841, 17);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 16);
            this.label31.TabIndex = 76;
            this.label31.Text = "进价";
            this.label31.Visible = false;
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(218, 12);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(152, 20);
            this.lblpm.TabIndex = 75;
            // 
            // lblzmje
            // 
            this.lblzmje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzmje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzmje.ForeColor = System.Drawing.Color.Navy;
            this.lblzmje.Location = new System.Drawing.Point(369, 62);
            this.lblzmje.Name = "lblzmje";
            this.lblzmje.Size = new System.Drawing.Size(128, 20);
            this.lblzmje.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(313, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 72;
            this.label8.Text = "帐面金额";
            // 
            // lblzmsl
            // 
            this.lblzmsl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzmsl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzmsl.ForeColor = System.Drawing.Color.Navy;
            this.lblzmsl.Location = new System.Drawing.Point(217, 62);
            this.lblzmsl.Name = "lblzmsl";
            this.lblzmsl.Size = new System.Drawing.Size(87, 20);
            this.lblzmsl.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(161, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "帐面数量";
            // 
            // lblpcje
            // 
            this.lblpcje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpcje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpcje.ForeColor = System.Drawing.Color.Navy;
            this.lblpcje.Location = new System.Drawing.Point(218, 39);
            this.lblpcje.Name = "lblpcje";
            this.lblpcje.Size = new System.Drawing.Size(88, 20);
            this.lblpcje.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(161, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 68;
            this.label7.Text = "盘存金额";
            // 
            // txtph
            // 
            this.txtph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtph.Location = new System.Drawing.Point(874, 40);
            this.txtph.Name = "txtph";
            this.txtph.ReadOnly = true;
            this.txtph.Size = new System.Drawing.Size(96, 21);
            this.txtph.TabIndex = 9;
            this.txtph.Visible = false;
            this.txtph.TextChanged += new System.EventHandler(this.txtph_TextChanged);
            this.txtph.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(836, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 65;
            this.label5.Text = "批 号";
            this.label5.Visible = false;
            // 
            // txtypsl
            // 
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.Location = new System.Drawing.Point(64, 37);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.Size = new System.Drawing.Size(88, 21);
            this.txtypsl.TabIndex = 3;
            this.txtypsl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtypsl_KeyUp);
            this.txtypsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtypsl_KeyPress);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 37);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 16);
            this.label26.TabIndex = 32;
            this.label26.Text = "盘存数量";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(371, 39);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(88, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(323, 39);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 16);
            this.label23.TabIndex = 28;
            this.label23.Text = "零售价";
            // 
            // lblpfj
            // 
            this.lblpfj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfj.ForeColor = System.Drawing.Color.Navy;
            this.lblpfj.Location = new System.Drawing.Point(873, 61);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(96, 20);
            this.lblpfj.TabIndex = 27;
            this.lblpfj.Visible = false;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(833, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 26;
            this.label20.Text = "批发价";
            this.label20.Visible = false;
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(64, 61);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(88, 20);
            this.cmbdw.TabIndex = 4;
            this.cmbdw.SelectedIndexChanged += new System.EventHandler(this.cmbdw_SelectedIndexChanged);
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbdw_KeyPress);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(28, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 15);
            this.label19.TabIndex = 24;
            this.label19.Text = "单位";
            // 
            // lblhh
            // 
            this.lblhh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhh.ForeColor = System.Drawing.Color.Navy;
            this.lblhh.Location = new System.Drawing.Point(507, 39);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(128, 20);
            this.lblhh.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(467, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 16);
            this.label18.TabIndex = 22;
            this.label18.Text = "货号";
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(370, 12);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(152, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(688, 12);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(128, 20);
            this.lblcj.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(648, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 16);
            this.label14.TabIndex = 18;
            this.label14.Text = "厂家";
            // 
            // lblgg
            // 
            this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgg.ForeColor = System.Drawing.Color.Navy;
            this.lblgg.Location = new System.Drawing.Point(560, 12);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(84, 20);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(528, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "规格";
            // 
            // txtypdm
            // 
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.Location = new System.Drawing.Point(64, 12);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(88, 21);
            this.txtypdm.TabIndex = 2;
            this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "药品代码";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(150, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 20;
            this.label16.Text = "品名/商品名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblshdjh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtprq);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbldjh);
            this.groupBox1.Controls.Add(this.lbldjhH);
            this.groupBox1.Controls.Add(this.butLoadData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1026, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(64, 11);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(112, 20);
            this.cmbck.TabIndex = 0;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 81;
            this.label2.Text = "仓库名称";
            // 
            // lblshdjh
            // 
            this.lblshdjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblshdjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblshdjh.ForeColor = System.Drawing.Color.Navy;
            this.lblshdjh.Location = new System.Drawing.Point(589, 12);
            this.lblshdjh.Name = "lblshdjh";
            this.lblshdjh.Size = new System.Drawing.Size(80, 20);
            this.lblshdjh.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(534, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 78;
            this.label6.Text = "审核单号";
            // 
            // dtprq
            // 
            this.dtprq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtprq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtprq.ForeColor = System.Drawing.Color.Navy;
            this.dtprq.Location = new System.Drawing.Point(243, 12);
            this.dtprq.Name = "dtprq";
            this.dtprq.Size = new System.Drawing.Size(152, 20);
            this.dtprq.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(190, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 76;
            this.label3.Text = "录入时间";
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(64, 36);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(605, 21);
            this.txtbz.TabIndex = 1;
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "备注";
            // 
            // lbldjh
            // 
            this.lbldjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjh.ForeColor = System.Drawing.Color.Navy;
            this.lbldjh.Location = new System.Drawing.Point(452, 12);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(80, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhH
            // 
            this.lbldjhH.Location = new System.Drawing.Point(398, 16);
            this.lbldjhH.Name = "lbldjhH";
            this.lbldjhH.Size = new System.Drawing.Size(64, 16);
            this.lbldjhH.TabIndex = 14;
            this.lbldjhH.Text = "录入单号";
            // 
            // butLoadData
            // 
            this.butLoadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLoadData.ForeColor = System.Drawing.Color.Blue;
            this.butLoadData.Location = new System.Drawing.Point(688, 20);
            this.butLoadData.Name = "butLoadData";
            this.butLoadData.Size = new System.Drawing.Size(112, 24);
            this.butLoadData.TabIndex = 75;
            this.butLoadData.Text = "提取数据(&W)";
            this.butLoadData.UseVisualStyleBackColor = false;
            this.butLoadData.Click += new System.EventHandler(this.butLoadData_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1026, 563);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "漏盘药品";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.myDataGrid2);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1026, 515);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
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
            this.myDataGrid2.Size = new System.Drawing.Size(1020, 495);
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.myDataGrid2.Click += new System.EventHandler(this.myDataGrid2_Click);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn48,
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn49,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn50,
            this.dataGridTextBoxColumn51,
            this.dataGridTextBoxColumn52,
            this.dataGridTextBoxColumn53,
            this.dataGridTextBoxColumn54,
            this.dataGridTextBoxColumn55,
            this.dataGridTextBoxColumn56,
            this.dataGridTextBoxColumn57,
            this.dataGridTextBoxColumn58,
            this.dataGridTextBoxColumn59,
            this.dataGridTextBoxColumn60});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.ReadOnly = true;
            // 
            // dataGridTextBoxColumn48
            // 
            this.dataGridTextBoxColumn48.Format = "";
            this.dataGridTextBoxColumn48.FormatInfo = null;
            this.dataGridTextBoxColumn48.HeaderText = "序号";
            this.dataGridTextBoxColumn48.Width = 35;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.AllowNull = false;
            this.dataGridBoolColumn1.FalseValue = ((short)(0));
            this.dataGridBoolColumn1.HeaderText = "选择";
            this.dataGridBoolColumn1.NullText = "";
            this.dataGridBoolColumn1.TrueValue = ((short)(1));
            this.dataGridBoolColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn49
            // 
            this.dataGridTextBoxColumn49.Format = "";
            this.dataGridTextBoxColumn49.FormatInfo = null;
            this.dataGridTextBoxColumn49.HeaderText = "品名";
            this.dataGridTextBoxColumn49.Width = 140;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "商品名";
            this.dataGridTextBoxColumn2.Width = 140;
            // 
            // dataGridTextBoxColumn50
            // 
            this.dataGridTextBoxColumn50.Format = "";
            this.dataGridTextBoxColumn50.FormatInfo = null;
            this.dataGridTextBoxColumn50.HeaderText = "规格";
            this.dataGridTextBoxColumn50.Width = 90;
            // 
            // dataGridTextBoxColumn51
            // 
            this.dataGridTextBoxColumn51.Format = "";
            this.dataGridTextBoxColumn51.FormatInfo = null;
            this.dataGridTextBoxColumn51.HeaderText = "厂家";
            this.dataGridTextBoxColumn51.Width = 90;
            // 
            // dataGridTextBoxColumn52
            // 
            this.dataGridTextBoxColumn52.Format = "";
            this.dataGridTextBoxColumn52.FormatInfo = null;
            this.dataGridTextBoxColumn52.HeaderText = "批发价";
            this.dataGridTextBoxColumn52.Width = 65;
            // 
            // dataGridTextBoxColumn53
            // 
            this.dataGridTextBoxColumn53.Format = "";
            this.dataGridTextBoxColumn53.FormatInfo = null;
            this.dataGridTextBoxColumn53.HeaderText = "零售价";
            this.dataGridTextBoxColumn53.Width = 65;
            // 
            // dataGridTextBoxColumn54
            // 
            this.dataGridTextBoxColumn54.Format = "";
            this.dataGridTextBoxColumn54.FormatInfo = null;
            this.dataGridTextBoxColumn54.HeaderText = "批号";
            this.dataGridTextBoxColumn54.Width = 65;
            // 
            // dataGridTextBoxColumn55
            // 
            this.dataGridTextBoxColumn55.Format = "";
            this.dataGridTextBoxColumn55.FormatInfo = null;
            this.dataGridTextBoxColumn55.HeaderText = "库位";
            this.dataGridTextBoxColumn55.Width = 65;
            // 
            // dataGridTextBoxColumn56
            // 
            this.dataGridTextBoxColumn56.Format = "";
            this.dataGridTextBoxColumn56.FormatInfo = null;
            this.dataGridTextBoxColumn56.HeaderText = "库存量";
            this.dataGridTextBoxColumn56.Width = 70;
            // 
            // dataGridTextBoxColumn57
            // 
            this.dataGridTextBoxColumn57.Format = "";
            this.dataGridTextBoxColumn57.FormatInfo = null;
            this.dataGridTextBoxColumn57.HeaderText = "单位";
            this.dataGridTextBoxColumn57.Width = 40;
            // 
            // dataGridTextBoxColumn58
            // 
            this.dataGridTextBoxColumn58.Format = "";
            this.dataGridTextBoxColumn58.FormatInfo = null;
            this.dataGridTextBoxColumn58.HeaderText = "货号";
            this.dataGridTextBoxColumn58.Width = 65;
            // 
            // dataGridTextBoxColumn59
            // 
            this.dataGridTextBoxColumn59.Format = "";
            this.dataGridTextBoxColumn59.FormatInfo = null;
            this.dataGridTextBoxColumn59.HeaderText = "cjid";
            this.dataGridTextBoxColumn59.Width = 0;
            // 
            // dataGridTextBoxColumn60
            // 
            this.dataGridTextBoxColumn60.Format = "";
            this.dataGridTextBoxColumn60.FormatInfo = null;
            this.dataGridTextBoxColumn60.HeaderText = "kcid";
            this.dataGridTextBoxColumn60.Width = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.butjy);
            this.groupBox5.Controls.Add(this.chkprintlp);
            this.groupBox5.Controls.Add(this.butclose1);
            this.groupBox5.Controls.Add(this.butprintlpyp);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(0, 515);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1026, 48);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "操作";
            // 
            // butjy
            // 
            this.butjy.Location = new System.Drawing.Point(31, 11);
            this.butjy.Name = "butjy";
            this.butjy.Size = new System.Drawing.Size(241, 32);
            this.butjy.TabIndex = 73;
            this.butjy.Text = "禁用以上选择的且库存为零的药品";
            this.butjy.Visible = false;
            this.butjy.Click += new System.EventHandler(this.butjy_Click);
            // 
            // chkprintlp
            // 
            this.chkprintlp.Location = new System.Drawing.Point(290, 16);
            this.chkprintlp.Name = "chkprintlp";
            this.chkprintlp.Size = new System.Drawing.Size(176, 24);
            this.chkprintlp.TabIndex = 72;
            this.chkprintlp.Text = "只打印库存数不为零的药品";
            // 
            // butclose1
            // 
            this.butclose1.Location = new System.Drawing.Point(616, 11);
            this.butclose1.Name = "butclose1";
            this.butclose1.Size = new System.Drawing.Size(104, 32);
            this.butclose1.TabIndex = 1;
            this.butclose1.Text = "退出(&Q)";
            this.butclose1.Click += new System.EventHandler(this.butclose1_Click);
            // 
            // butprintlpyp
            // 
            this.butprintlpyp.Location = new System.Drawing.Point(496, 11);
            this.butprintlpyp.Name = "butprintlpyp";
            this.butprintlpyp.Size = new System.Drawing.Size(104, 32);
            this.butprintlpyp.TabIndex = 0;
            this.butprintlpyp.Text = "打印(&P)";
            this.butprintlpyp.Click += new System.EventHandler(this.butprintlpyp_Click);
            // 
            // btn_ImportKfj
            // 
            this.btn_ImportKfj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ImportKfj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_ImportKfj.Location = new System.Drawing.Point(903, 12);
            this.btn_ImportKfj.Name = "btn_ImportKfj";
            this.btn_ImportKfj.Size = new System.Drawing.Size(117, 23);
            this.btn_ImportKfj.TabIndex = 88;
            this.btn_ImportKfj.Text = "导入快发机库存";
            this.btn_ImportKfj.Click += new System.EventHandler(this.btn_ImportKfj_Click);
            // 
            // Frmzylr_kcmx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1034, 615);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Frmzylr_kcmx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "盘点自由录入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmzylrMx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void FrmzylrMx_Load(object sender, System.EventArgs e)
        {

            //隐藏盘点明细窗口
            this.checkBox1.Checked = true;
            //this.库位.Width=0;


            SystemCfg cfg8056 = new SystemCfg(8056);//调进货价
            if (cfg8056.Config == "1")
            {
                btjhj = true;
            }

            //col帐面数量.Width 

            if (InstanceForm.BCurrentDept.DeptId != 207)
            {                
                btnImport.Visible = false;               
            }

            
            //后湖与南京路的才显示出来，从快发机导入盘点数据
            if (!("207,424").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
            {
                btn_ImportKfj.Visible = false;
            }

            if (!("207,424").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
            {
                col发药机库存.Width = 0;
            }
           
        }

        #region 界面控制事件
        // 回车跳至下一个文本
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                this.SelectNextControl(control, true, false, true, true);
            }
        }


        //初始化第一个组框
        private void csgroupbox1()
        {
            for (int i = 0; i <= this.groupBox1.Controls.Count - 1; i++)
            {
                if (this.groupBox1.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    this.groupBox1.Controls[i].Text = "";
                    this.groupBox1.Controls[i].Tag = "0";
                }
            }
            this.lbldjh.Text = "";
            this.lblshdjh.Text = "";
            this.groupBox1.Tag = null;
            this.dtprq.Text = "";
        }

        //初始化第二个组框
        private void csgroupbox2()
        {
            for (int i = 0; i <= this.groupBox2.Controls.Count - 1; i++)
            {
                if (this.groupBox2.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    this.groupBox2.Controls[i].Text = "";
                    this.groupBox2.Controls[i].Tag = "0";
                }
            }
            this.lblypmc.Text = "";
            this.lblypmc.Tag = "0";
            this.lblpm.Text = "";
            this.lblgg.Text = "";
            this.lblcj.Text = "";
            this.lblhh.Text = "";
            this.lblpfj.Text = "";
            this.lbllsj.Text = "";
            this.lblpfj.Tag = "";
            this.lbllsj.Tag = "";
            this.lblpcje.Text = "";
            this.lblzmsl.Text = "";
            this.lblzmje.Text = "";
            //			this.lblkw.Text="";
            //			this.lblkw.Tag="0";
            this.cmbdw.DataSource = null;

            this.lbljhj.Text = "";
            this.lbljhj.Tag = "";
            //this.txtypdm.Focus();
        }

        private void txtypsl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (this.chkdw.Checked == true)
                    cmbdw.Focus();
                else
                {
                    if (butadd.Enabled == true)
                        butadd.Focus();
                    else
                        butmodif.Focus();
                }
            }
        }

        private void cmbdw_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (butadd.Enabled == true)
                butadd.Focus();
            else
                butmodif.Focus();
        }

        //输入框控制事件
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {


            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "") { control.Text = ""; control.Tag = "0"; }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            { }
            else { return; }

            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            DataRow row;

            try
            {
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 2:
                        if (control.Text.Trim() == "") return;
                        GrdMappingName = new string[] { "kcid", "ggid", "cjid", "行号", "品名", "商品名", "库存量", "单位", "进价", "批号", "规格", "厂家", "批发价", "零售价", "货号", "dwbl" };
                        GrdWidth = new int[] { 0, 0, 0, 35, 120, 120, 65, 35, 0, 0, 90, 90, 0, 60, 60, 0 };
                        sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                        if (ss.是否允许对没有库存记录的药品进行盘存 == true)
                            ssql = @"select isnull(kcid,dbo.FUN_GETEMPTYGUID()) kcid,a.ggid,a.cjid,0 rowno,s_yppm,s_ypspm,kcl,coalesce(dbo.fun_yp_ypdw(zxdw),s_ypdw) s_zxdw,0 jhj,'' ypph,s_ypgg,s_sccj," +
                                @" pfj,lsj,shh,coalesce(dwbl,1) dwbl from yp_ypcjd a inner join yp_ypbm b on a.ggid=b.ggid 
                                      left join yf_pdtemp  c  on" +
                                " a.cjid=c.cjid and  c.shbz=0 and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (c.bdelete=0 or kcl<>0)" +
                                " where (a.bdelete=0 or c.kcl<>0) and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + ")";
                        //inner join yp_ypbm b on a.ggid=b.ggid
                        else
                            ssql = @"select isnull(kcid,dbo.FUN_GETEMPTYGUID()) kcid,a.ggid,a.cjid,0 rowno,s_yppm,s_ypspm,kcl,coalesce(dbo.fun_yp_ypdw(zxdw),s_ypdw) , 0 jhj,'' ypph,s_ypgg,s_sccj," +
                                @" pfj,lsj,shh,coalesce(dwbl,1) dwbl from yp_ypcjd a  inner join yp_ypbm b on a.ggid=b.ggid 
                                      inner join yf_pdtemp  c  on" +
                                " a.cjid=c.cjid and  c.shbz=0 and  deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (c.bdelete=0 or kcl<>0)" +
                                " where a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + ")";
                        //inner join yp_ypbm b on a.ggid=b.ggid
                        if (chkgl.Checked == true)
                            ssql = ssql + " and isnull(c.kcid,dbo.FUN_GETEMPTYGUID()) not in(select isnull(kcid,dbo.FUN_GETEMPTYGUID()) from yf_pdcs a,yf_pdcsmx   b where a.deptid=b.deptid and a.djh=b.djh and bdelete=0 and a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and shbz=0 )";


                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql);
                        f2.Location = point;
                        f2.Width = 750;
                        f2.Height = 300;
                        f2.ShowDialog(this);
                        row = f2.dataRow;
                        if (row != null)
                        {
                            this.csyp(row);
                            this.SelectNextControl((Control)sender, true, false, true, true);

                        }
                        break;
                    case 80:
                        if (control.Text.Trim() == "") return;
                        GrdMappingName = new string[] { "kcid", "ggid", "cjid", "行号", "品名", "商品名", "库存量", "单位", "进价", "批号", "规格", "厂家", "批发价", "零售价", "货号", "dwbl" };
                        GrdWidth = new int[] { 0, 0, 0, 35, 120, 120, 65, 35, 60, 60, 90, 90, 0, 60, 60, 0 };
                        sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                        if (ss.是否允许对没有库存记录的药品进行盘存 == true)
                            ssql = "select isnull(kcid,dbo.FUN_GETEMPTYGUID()) kcid,a.ggid,a.cjid,0 rowno,s_yppm,s_ypspm,kcl,coalesce(dbo.fun_yp_ypdw(zxdw),s_ypdw) s_zxdw,jhj,ypph,s_ypgg,s_sccj," +
                                " pfj,lsj,shh,coalesce(dwbl,1) dwbl from yp_ypcjd a inner join yp_ypbm b on a.ggid=b.ggid  left join yf_pdtemp c  on" +
                                " a.cjid=c.cjid and  c.shbz=0 and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (c.bdelete=0 or kcl<>0)" +
                                " where (a.bdelete=0 or c.kcl<>0) and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + ")";
                        else
                            ssql = "select isnull(kcid,dbo.FUN_GETEMPTYGUID()) kcid,a.ggid,a.cjid,0 rowno,s_yppm,s_ypspm,kcl,coalesce(dbo.fun_yp_ypdw(zxdw),s_ypdw) ,jhj,ypph,s_ypgg,s_sccj," +
                                " pfj,lsj,shh,coalesce(dwbl,1) dwbl from yp_ypcjd a inner join yp_ypbm b on a.ggid=b.ggid  inner join yf_pdtemp c  on" +
                                " a.cjid=c.cjid and  c.shbz=0 and  deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (c.bdelete=0 or kcl<>0)" +
                                " where a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + ")";

                        if (chkgl.Checked == true)
                            ssql = ssql + " and isnull(c.kcid,dbo.FUN_GETEMPTYGUID()) not in(select isnull(kcid,dbo.FUN_GETEMPTYGUID()) from yf_pdcs a,yf_pdcsmx b where a.deptid=b.deptid and a.djh=b.djh and bdelete=0 and a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and shbz=0 )";
                        TrasenFrame.Forms.Fshowcard f3 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql);
                        f3.Location = point;
                        f3.ShowDialog(this);
                        row = f3.dataRow;
                        if (row != null)
                        {
                            control.Text = row["s_yppm"].ToString();
                            control.Tag = row["cjid"].ToString();
                            int cjid = Convert.ToInt32(Convertor.IsNull(row["cjid"], "0"));
                            int nrow = 0;
                            FindRecord(cjid, nrow);

                        }
                        break;

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }


        }

        //数量输入事件
        private void txtypsl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                //if (Convertor.IsNumeric(txtypsl.Text)==false) txtypsl.Text="";
                if (txtypsl.Text.Trim() != "-" && txtypsl.Text.Trim() != ".")
                {
                    //decimal sumpcje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text,"0"));
                    decimal sumpcje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) / Convert.ToInt32(Convertor.IsNull(cmbdw.SelectedValue, "1"));
                    this.lblpcje.Text = sumpcje.ToString("0.00");
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("请输入正确的数字");
            }

        }

        //网格单元改变事件
        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            try
            {
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                this.csgroupbox2();
                if (nrow < tb.Rows.Count && tb.Rows.Count > 0)
                {
                    DataRow row = tb.Rows[nrow];
                    Getrow(row);
                    this.butadd.Enabled = false;
                }

                int cjid = 0;
                DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
                if (nrow < tb1.Rows.Count)
                {
                    cjid = Convert.ToInt32(tb1.Rows[nrow]["cjid"]);
                }

                if (this.checkBox1.Checked != true)
                    Selectpcmx(cjid);

                //(((System.Windows.Forms.DataGrid)(sender)).CurrentCell)
                this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

                //Modify by jchl
                //msg.
                DataTable dt = myDataGrid1.DataSource as DataTable;
                if (dt.Columns.Contains(col大数量.HeaderText) && dt.Columns.Contains(col小数量.HeaderText))
                {
                    dt.AcceptChanges();
                    string strName = myDataGrid1.TableStyles[0].GridColumnStyles[ncol].HeaderText;
                    if (strName.Trim().Equals(col盘存数量.HeaderText.Trim()))
                    {
                        DoCountPcSl(dt.Rows[nrow]);
                    } 
                }


                //string strName=(((System.Windows.Forms.DataGrid)(sender)).DataSource as DataTable).Columns[ncol].ColumnName;
                return;
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        //单位改变事件
        private void cmbdw_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cmbdw.SelectedIndex <= -1) return;
                if (cmbdw.SelectedValue.GetType().ToString() != "System.Int32") return;
                int dwbl = Convert.ToInt32(cmbdw.SelectedValue);

                //帐存数量
                decimal zmsl = Convert.ToDecimal(Convertor.IsNull(lblzmsl.Text, "0")) * dwbl / Convert.ToInt32(lblzmsl.Tag);
                this.lblzmsl.Text = zmsl.ToString("0.000");
                this.lblzmsl.Tag = dwbl.ToString();

                //盘存数量
                decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));

                //进价
                decimal jhj = Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Tag, "0")) / dwbl;
                jhj = Convert.ToDecimal(jhj.ToString("0.0000"));


                //批发价
                decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Tag, "0")) / dwbl;
                pfj = Convert.ToDecimal(pfj.ToString("0.0000"));

                //零售价
                decimal lsj = Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) / dwbl;
                lsj = Convert.ToDecimal(lsj.ToString("0.0000"));

                this.lblpfj.Text = pfj.ToString("0.0000");
                this.lbllsj.Text = lsj.ToString("0.0000");
                this.lbljhj.Text = jhj.ToString("0.0000");

                //盘存金额
                decimal pcje = Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) * ypsl / dwbl;
                this.lblpcje.Text = pcje.ToString("0.00");
                decimal zmje = Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) * zmsl / dwbl;
                this.lblzmje.Text = zmje.ToString("0.00");
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        //在网格内查找相关药品
        private void FindRecord(int cjid, int nrow)
        {
            int beginrow = nrow;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = beginrow; i <= tb.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(tb.Rows[i]["cjid"]) == cjid)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    for (int j = 0; j <= tb.Rows.Count - 1; j++)
                    {
                        this.myDataGrid1.UnSelect(j);
                    }

                    this.myDataGrid1.Select(i);
                    beginrow = i + 1;
                    if (beginrow != tb.Rows.Count)
                    {
                        this.butnext.Visible = true;
                        this.butnext.Tag = beginrow.ToString();
                    }
                    else
                    {
                        this.butnext.Visible = false;
                        this.butnext.Tag = "0";
                    }
                    return;

                }

                if (beginrow >= tb.Rows.Count - 1)
                {
                    this.butnext.Visible = false;
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.panel3.Visible = false;
            }
            else
            {
                this.panel3.Visible = true;
            }
        }

        private void chkdw_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkdw.Checked == true)
                cmbdw.TabIndex = 3;
            else
                cmbdw.TabIndex = 8;

        }

        #endregion

        #region 填充数据的过程
        //初始药品
        private void csyp(DataRow row)
        {
            try
            {
                this.csgroupbox2();
                this.lblypmc.Tag = row["cjid"].ToString();
                this.lblypmc.Text = row["s_ypspm"].ToString();
                this.lblpm.Text = row["s_yppm"].ToString();
                this.lblgg.Text = row["s_ypgg"].ToString();
                this.lblcj.Text = row["s_sccj"].ToString();
                this.lblhh.Text = row["shh"].ToString();

                this.lblpfj.Text = row["pfj"].ToString();
                this.lbllsj.Text = row["lsj"].ToString();
                this.lbljhj.Text = row["jhj"].ToString();

                this.lblpfj.Tag = row["pfj"].ToString();
                this.lbllsj.Tag = row["lsj"].ToString();
                this.lbljhj.Tag = row["jhj"].ToString();

                this.txtph.Text = Convert.ToString(row["ypph"]);
                this.txtph.Tag = row["kcid"].ToString();
                //				this.lblkw.Text="";
                //				this.lblkw.Tag="0";
                this.lblzmsl.Text = Convertor.IsNull(row["kcl"], "0");
                this.lblzmsl.Tag = row["dwbl"].ToString();
                Ypcj cj = new Ypcj(Convert.ToInt32(row["cjid"]), InstanceForm.BDatabase);
                Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), cj.GGID, Convert.ToInt32(row["cjid"]), this.cmbdw, InstanceForm.BDatabase);
                this.cmbdw.SelectedIndex = 0;
                if (this.checkBox1.Checked == false)
                    Selectpcmx(Convert.ToInt32(row["cjid"]));
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        //填充行
        private void Fillrow(System.Data.DataRow row)
        {
            if (Convert.ToInt32(this.lblypmc.Tag) == 0)
            {
                MessageBox.Show("没有可添加的药品");
                return;
            }

            if (new Guid(Convertor.IsNull(this.txtph.Tag, Guid.Empty.ToString())) == Guid.Empty)
            {
                if (MessageBox.Show("当前药品在库存中没有您确定要添加吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (row["序号"].ToString().Trim() == "") row["序号"] = tb.Rows.Count + 1;
            row["品名"] = this.lblpm.Text.Trim();
            row["商品名"] = this.lblypmc.Text.Trim();
            row["规格"] = this.lblgg.Text.Trim();
            row["厂家"] = this.lblcj.Text.Trim();
            row["批发价"] = this.lblpfj.Text.Trim();

            decimal sumpfje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
            row["批发金额"] = sumpfje.ToString("0.00");

            //row["进价"]=Convertor.IsNull(this.lbljhj.Text.Trim(),"0");
            row["零售价"] = this.lbllsj.Text.Trim();
            //row["批号"]=this.txtph.Text.Trim();

            //row["库位"]="";//this.lblkw.Text.Trim();
            row["帐面数量"] = Convertor.IsNull(this.lblzmsl.Text.Trim(), "0");

            Ypcj cj = new Ypcj(Convert.ToInt32(this.lblypmc.Tag.ToString()), InstanceForm.BDatabase);
            decimal sumZmje = Convert.ToDecimal(Convertor.IsNull(row["帐面数量"], "0")) * Convert.ToDecimal(cj.LSJ) / Convert.ToInt32(this.cmbdw.SelectedValue);
            //update code by pengy 2014-12-31
            //decimal sumzmje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(), "0"));
            row["帐面金额"] = sumZmje.ToString("0.00");

            row["盘存数量"] = Convertor.IsNull(this.txtypsl.Text.Trim(), "0");
            row["单位"] = this.cmbdw.Text.Trim();

            decimal sumpcje = Convert.ToDecimal(Convertor.IsNull(lblpcje.Text, "0"));
            row["盘存金额"] = sumpcje.ToString("0.00");

            decimal yksl = Convert.ToDecimal(Convertor.IsNull(row["盘存数量"], "0")) - Convert.ToDecimal(Convertor.IsNull(row["帐面数量"], "0"));
            row["盈亏数量"] = yksl.ToString("0.0");

            decimal ykje = Convert.ToDecimal(Convertor.IsNull(row["盈亏数量"], "0")) * Convert.ToDecimal(row["零售价"]);
            row["盈亏金额"] = ykje.ToString("0.00");

            row["货号"] = this.lblhh.Text.Trim();
            row["CJID"] = this.lblypmc.Tag.ToString();
            row["KCID"] = Convertor.IsNull(this.txtph.Tag, Guid.Empty.ToString());//new Guid(Convertor.IsNull(this.txtph.Tag,Guid.Empty.ToString())).ToString();
            row["DWBL"] = Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
            row["KWID"] = "0";//Convertor.IsNull(this.lblkw.Tag,"0");

            SortRowNO();
        }


        //求和金额
        private void Sumje()
        {
            try
            {
                decimal sumpfje = 0;
                decimal sumpcje = 0;
                decimal sumjhje = 0;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumpfje = sumpfje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面金额"], "0"));
                    sumpcje = sumpcje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存金额"], "0"));
                    //sumjhje=sumjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"))*Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存数量"],"0"));
                }
                this.statusBar1.Panels[0].Text = "帐存零售金额: " + sumpfje.ToString("0.00");
                this.statusBar1.Panels[1].Text = "盘存零售金额: " + sumpcje.ToString("0.00");
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        //获取一行
        private void Getrow(DataRow row)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(row["cjid"], "0"));
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
            this.lblpm.Text = row["品名"].ToString();
            this.lblypmc.Text = row["商品名"].ToString();
            this.lblypmc.Tag = row["CJID"].ToString();
            this.lblgg.Text = row["规格"].ToString();
            this.lblcj.Text = row["厂家"].ToString();
            this.lblpfj.Text = row["批发价"].ToString();
            this.lblpfj.Tag = ydcj.PFJ.ToString();

            this.lbljhj.Text = row["进价"].ToString();
            this.lbljhj.Tag = Convert.ToDecimal(Convertor.IsNull(row["进价"], "0")) * Convert.ToDecimal(Convertor.IsNull(row["dwbl"], "0"));
            this.lbllsj.Text = row["零售价"].ToString();
            this.lbllsj.Tag = ydcj.LSJ.ToString();


            this.txtph.Text = row["批号"].ToString();
            this.txtph.Tag = row["kcid"].ToString();

            //			this.lblkw.Text=row["库位"].ToString();
            //			this.lblkw.Tag=row["kwid"].ToString();
            this.lblzmsl.Text = row["帐面数量"].ToString();
            this.lblzmsl.Tag = row["dwbl"].ToString();
            this.lblzmje.Text = row["帐面金额"].ToString();
            this.txtypsl.Text = row["盘存数量"].ToString();
            Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
            this.cmbdw.Text = row["单位"].ToString();
            decimal pcje = Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) * Convert.ToDecimal(lbllsj.Tag) / Convert.ToInt32(Convertor.IsNull(cmbdw.SelectedValue, "1"));
            this.lblpcje.Text = pcje.ToString("0.00");
            this.lblhh.Text = row["货号"].ToString();

        }


        //重新排序行号
        private void SortRowNO()
        {
            DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb1.Rows.Count - 1; i++)
            {
                tb1.Rows[i]["序号"] = i + 1;
            }
        }


        //填充单据
        public void FillDj(Guid id, bool shbz)
        {
            try
            {
                chkDxDwLr.Checked = false;
                cmbck.Enabled = false;
                string ssql = "select * from yf_pdcs where id='" + id + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                cmbck.SelectedValue = tb.Rows[0]["deptid"].ToString();
                this.groupBox1.Tag = tb.Rows[0]["id"].ToString();
                this.txtbz.Text = tb.Rows[0]["bz"].ToString();
                long djh = Convert.ToInt64(tb.Rows[0]["djh"]);
                long shdjh = Convert.ToInt64(tb.Rows[0]["shdjh"]);
                this.lbldjh.Text = djh.ToString("00000000");
                if (shdjh > 0) this.lblshdjh.Text = shdjh.ToString("00000000");
                this.dtprq.Text = tb.Rows[0]["djrq"].ToString();

                ssql = @"select 0 序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,
                    dbo.fun_yp_sccj(b.sccj) 厂家,a.pfj 批发价,0.00 批发金额,0 进价,a.lsj 零售价,
                     null 批号,'' 库位," +
                    " zcsl 帐面数量,round(zcsl*a.lsj,2) 帐面金额,pcsl 盘存数量,s_ypdw 大单位,a.ypdw 单位," +
                    " round(pcsl*A.lsj,2) 盘存金额,(case when (pcsl-zcsl)<>0 then (pcsl-zcsl) else null end)   盈亏数量,0.00 盈亏金额 ,b.shh 货号," +
                    " a.cjid,kcid,ydwbl dwbl,0 kwid,a.id ,''  描述,dbo.fun_yp_yplx(yplx) 药品类型,s_ypjx 剂型," +
                    " (case when cast( (zcsl*c.dwbl/ydwbl) /c.dwbl as int)<>0 then cast(cast((zcsl*c.dwbl/ydwbl)/c.dwbl as bigint) AS varchar(50))+rtrim(s_ypdw) else '' end )+(case when (zcsl*c.dwbl/ydwbl)%c.dwbl<>0 then cast(cast((zcsl*c.dwbl/ydwbl)%c.dwbl AS float) as varchar(50))+dbo.fun_yp_ypdw(c.zxdw) else '' end )  帐面数量2, " +
                    " (case when cast( (PCSL*c.dwbl/ydwbl) /c.dwbl as int)<>0 then cast(cast((PCSL*c.dwbl/ydwbl)/c.dwbl as bigint) AS varchar(50))+rtrim(s_ypdw) else '' end )+(case when (PCSL*c.dwbl/ydwbl)%c.dwbl<>0 then cast(cast((PCSL*c.dwbl/ydwbl)%c.dwbl AS float) as varchar(50))+dbo.fun_yp_ypdw(c.zxdw) else '' end )  盘存数量2 " +
                    " from yf_pdcsmx_kcmx a inner join vi_yp_ypcd b  " +
                    " on a.cjid=b.cjid " +
                    " left join  yf_kcmx c on b.cjid=c.cjid and a.deptid=c.deptid " +
                    " where  djid='" + new Guid(tb.Rows[0]["id"].ToString()) + "' and a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " order by a.pxxh";
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                tbmx.TableName = "tbmx";
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";

                this.butLoadData.Enabled = false;
                this.butmrzc.Enabled = false;

                if (Convert.ToInt32(tb.Rows[0]["shbz"]) == 1)
                {
                    this.txtypdm.Enabled = false;
                    this.txtypsl.Enabled = false;
                    this.cmbdw.Enabled = false;
                    this.butsave.Enabled = false;
                    this.butadd.Enabled = false;
                    this.butdel.Enabled = false;
                    this.butmodif.Enabled = false;
                    this.myDataGrid1.ReadOnly = true;
                }

                this.butprint.Enabled = true;

                this.Sumje();
                SortRowNO();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }


        //添加模板
        public void AddMB(int mbid)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Value = Convert.ToInt32(mbid);
                parameters[0].Text = "@mbid";
                parameters[1].Value = Convert.ToInt32(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
                parameters[1].Text = "@deptid";

                parameters[2].Text = "bpcgl";
                parameters[2].Value = 1;
                parameters[3].Text = "@pcfs";
                parameters[3].Value = "0";

                DataTable tb = InstanceForm.BDatabase.GetDataTable("sp_yf_MBIMPORT", parameters, 30);
                FunBase.AddRowtNo(tb);
                tb.TableName = "Tb";
                this.myDataGrid1.DataSource = tb;
                this.myDataGrid1.TableStyles[0].MappingName = "Tb";
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }


        }


        //查找当前药品的相关盘存记录
        public void Selectpcmx(int cjid)
        {
            DataTable tbkc;
            if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == true)
                tbkc = Yp.Selectkc(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), cjid, "yk_kcmx", InstanceForm.BDatabase);
            else
                tbkc = Yp.Selectkc(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), cjid, "Yf_kcmx", InstanceForm.BDatabase);

            int xdwbl = 1;
            int zxdw = 0;
            if (tbkc.Rows.Count != 0)
            {
                xdwbl = Convert.ToInt32(tbkc.Rows[0]["dwbl"]);
                zxdw = Convert.ToInt32(tbkc.Rows[0]["zxdw"]);
            }

            DataTable tb = YF_PDCS_PDCSMX.Select_cjid_pdmx_kcmx(cjid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), Convert.ToInt64(Convertor.IsNull(lblshdjh.Text, "0")), InstanceForm.BDatabase);
            if (tb.Rows.Count > 0)
            {
                decimal sumsl = 0;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    int ydwbl = Convert.ToInt32(tb.Rows[i]["Ydwbl"]);
                    decimal pcsl = Convert.ToDecimal(tb.Rows[i]["盘存数量"]);
                    sumsl = sumsl + pcsl * (xdwbl / ydwbl);
                }
                DataRow row;
                row = tb.NewRow();
                row["序号"] = "总计";
                row["盘存数量"] = Convert.ToString(sumsl.ToString("0.000"));
                row["单位"] = Yp.SeekYpdw(zxdw, InstanceForm.BDatabase);
                if (row["单位"].ToString().Trim() == "") row["单位"] = tb.Rows[0]["单位"].ToString();
                tb.Rows.Add(row);
                tb.TableName = "tb";
                this.myDataGrid3.DataSource = tb;
                this.myDataGrid3.TableStyles[0].MappingName = "tb";
            }
        }

        //网格双击事件
        private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                int cjid = 0;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (nrow < tb.Rows.Count)
                {
                    cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
                }
                Selectpcmx(cjid);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }


        //添加漏盘药品 
        private void AddLpyp(long deptid)
        {
            string ssql = "select 0 序号,cast(1 as smallint) 选择,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格, s_sccj 厂家," +
                @" cast(round(b.pfj/a.dwbl,4) as decimal(15,4)) 批发价,cast(round(b.lsj/a.dwbl,4) as decimal(15,4)) 零售价,
                   '' 批号,'' 库位," +
                " kcl 库存量,dbo.fun_yp_ypdw(a.zxdw) 单位," +
                " b.shh 货号," +
                " a.cjid,null kcid from ";
            ssql = ssql + "(select  ggid,CJID,SUM(kcl) as kcl,DWBL,ZXDW from yf_pdtemp where deptid=" + deptid + " and pddh=" + Convert.ToInt64(Convertor.IsNull(lblshdjh.Text, "0")) + "  and ( bdelete=0 or kcl<>0) group by  ggid,CJID,dwbl,zxdw ) a  ";
            ssql = ssql + ",vi_yp_ypcd b " +
                " where a.cjid=b.cjid   and " +
                " a.cjid not in(select cjid from yf_pdcsmx_kcmx a,yf_pdcs b where a.djid=b.id and bdelete=0 and a.deptid=" + deptid + " and shdjh=" + Convert.ToInt64(Convertor.IsNull(lblshdjh.Text, "0")) + ") ";
            DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
            FunBase.AddRowtNo(tbmx);
            tbmx.TableName = "Tb2";
            this.myDataGrid2.DataSource = tbmx;
            this.myDataGrid2.TableStyles[0].MappingName = "Tb2";
        }
        #endregion

        #region 按钮事件
        //添加一行
        private void butadd_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataRow row = tb.NewRow();
                this.Fillrow(row);
                if (row["品名"].ToString().Trim() != "")
                {
                    cmbck.Enabled = false;
                    tb.Rows.Add(row);
                    this.Sumje();
                    //this.myDataGrid1.CurrentCell=new DataGridCell(tb.Rows.Count,2);
                    this.myDataGrid1.Select(tb.Rows.Count - 1);
                    this.myDataGrid1.CurrentCell = new DataGridCell(tb.Rows.Count - 1, 3);
                    this.csgroupbox2();
                    this.butadd.Enabled = true;
                    //this.butadd.Enabled=true;
                    this.txtypdm.Focus();
                    return;
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        //新单据
        private void butnew_Click(object sender, System.EventArgs e)
        {
            this.Close();
            Frmxd f = new Frmxd(_menuTag, _chineseName, _mdiParent);
            f.ShowDialog();

        }


        //保存事件
        private void butsave_Click(object sender, System.EventArgs e)
        {
            Guid djid = Guid.Empty;
            long djh = 0;
            int err_code = 0;
            string err_text = "";
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (tb.Rows.Count == 0) { MessageBox.Show("没有可保存的记录"); return; }

            if (MessageBox.Show("你确定你输入的盘存数量正确并保存吗?", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            this.butsave.Enabled = false;

            try
            {
                this.Cursor = PubStaticFun.WaitCursor(); ;

                InstanceForm.BDatabase.BeginTransaction();
                //产生单据号
                djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToInt64(Convertor.IsNull(this.lbldjh.Text, "0"));

                //保存单据表头
                YF_PDCS_PDCSMX.SaveDJ(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())),
                    djh,
                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                    sDate,
                    InstanceForm.BCurrentUser.EmployeeId,
                    0,
                    txtbz.Text.Trim(), out djid,
                    out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

                //如果没有成功，抛出异常
                if (err_code != 0) { throw new System.Exception(err_text); }

                //保存单据明细(明细库存)
                int pxxh = 0;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    pxxh += 1;
                    if (Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["cjid"], "0")) > 0)
                    {
                        if (Convertor.IsNumeric(Convertor.IsNull(tb.Rows[i]["盘存数量"], "0")) == false)
                        {
                            int nerr = i + 1;
                            throw new Exception("请在第" + nerr.ToString() + "行的盘存数量处输入数字");
                        }
                        DataRow row = tb.Rows[i];
                        YF_PDCS_PDCSMX.SaveDJMX_KCMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"].ToString(), Guid.Empty.ToString())),
                            djid,
                            djh,
                            Convert.ToInt32(row["cjid"]),
                            Convert.ToDecimal(Convertor.IsNull(row["批发价"], "0")),
                            Convert.ToDecimal(Convertor.IsNull(row["零售价"], "0")),
                            Convert.ToDecimal(Convertor.IsNull(row["帐面数量"], "0")),
                            Convert.ToDecimal(Convertor.IsNull(row["盘存数量"], "0")),
                            row["单位"].ToString(),
                            Convert.ToInt32(Convertor.IsNull(row["dwbl"], "1")),
                            new Guid(row["kcid"].ToString()),
                             Convert.ToInt64(Convertor.IsNull(cmbck.SelectedValue, "0")), pxxh,
                            out err_code, out err_text, InstanceForm.BDatabase);
                    }
                }

                //如果没有成功，抛出异常
                if (err_code != 0) { throw new System.Exception(err_text); }

                //提交事务
                InstanceForm.BDatabase.CommitTransaction();
                this.lbldjh.Text = djh.ToString("00000000");
                this.dtprq.Text = sDate.Trim();
                this.butadd.Enabled = false;
                this.butdel.Enabled = false;
                this.butmodif.Enabled = false;
                this.butprint.Enabled = true;
                this.butmrzc.Enabled = false;

                MessageBox.Show(err_text);
                FillDj(djid, false);
                this.butsave.Enabled = true;
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsave.Enabled = true;
                MessageBox.Show(err.Message);

            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }


        // 删除行
        private void butdel_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow >= tb.Rows.Count) return;
                if (MessageBox.Show("您确定要删除第" + Convert.ToString((nrow + 1)) + "行吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataRow datarow = tb.Rows[nrow];
                    Guid _id = new Guid(Convertor.IsNull(datarow["id"], Guid.Empty.ToString()));
                    Guid _djid = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));

                    if (_id == Guid.Empty)
                        tb.Rows.Remove(datarow);
                    else
                    {
                        string ssql = "select id from yf_pdcsmx_kcmx where djid='" + _djid + "'";
                        DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);

                        InstanceForm.BDatabase.BeginTransaction();

                        ssql = "delete from YF_PDCSMX_kcmx where id='" + _id + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);

                        if (tab.Rows.Count == 1)
                        {
                            ssql = "delete from YF_PDCS where id='" + _djid + "'";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }

                        InstanceForm.BDatabase.CommitTransaction();

                        tb.Rows.Remove(datarow);
                    }
                    this.Sumje();
                    this.csgroupbox2();
                    SortRowNO();
                }


                this.butadd.Enabled = true;
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        //退出
        private void butclose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void butclose1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        //修改按钮事件
        private void butmodif_Click(object sender, System.EventArgs e)
        {
            try
            {
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;
                DataRow row = tb.Rows[nrow];
                this.Fillrow(row);
                this.Sumje();
                this.butadd.Enabled = true;
                this.csgroupbox2();
                this.txtypdm.Focus();

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        //默认帐存数
        private void butmrzc_Click(object sender, System.EventArgs e)
        {
            //if (MessageBox.Show(this, "您确定要将盘存数默认为帐存数吗？", "确认", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2 )==DialogResult.No ) return;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                tb.Rows[i]["盘存数量"] = tb.Rows[i]["帐面数量"];
                Ypcj cj = new Ypcj(Convert.ToInt32(tb.Rows[i]["cjid"]), InstanceForm.BDatabase);
                decimal sumpcje = Convert.ToDecimal(tb.Rows[i]["盘存数量"]) * Convert.ToDecimal(cj.LSJ) / Convert.ToInt32(tb.Rows[i]["dwbl"]);
                tb.Rows[i]["盘存金额"] = sumpcje.ToString("0.00");
            }
        }
        //默认为零
        private void butmrwl_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                tb.Rows[i]["盘存数量"] = "0";
                tb.Rows[i]["盘存金额"] = "0.00";
            }
        }

        //打印
        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.药品盘点单.NewRow();
                    myrow["xh"] = Convert.ToInt32(tb.Rows[i]["序号"]);
                    if (ss.打印单据时单据显示商品名 == true)
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["商品名"]);
                    else
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                    myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"], "0"));
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"], "0"));
                    myrow["zcsl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面数量"], "0"));
                    myrow["zcje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面金额"], "0"));
                    myrow["pcsl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存数量"], "0"));
                    myrow["pcje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存金额"], "0"));
                    myrow["yksl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"], "0"));
                    //myrow["ypph"]=Convert.ToString(tb.Rows[i]["批号"]);
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                    myrow["kwmc"] = Convert.ToString(tb.Rows[i]["库位"]);

                    myrow["yplx"] = Convert.ToString(tb.Rows[i]["药品类型"]);
                    myrow["ypjx"] = Convert.ToString(tb.Rows[i]["剂型"]);

                    Dset.药品盘点单.Rows.Add(myrow);

                }

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from yf_pdcs where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();

                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "DJH";
                parameters[0].Value = this.lbldjh.Text;
                parameters[1].Text = "DJY";
                parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "RQ";
                parameters[2].Value = dtprq.Text.Trim();
                parameters[3].Text = "TITLETEXT";
                parameters[3].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")盘点录入单";
                parameters[4].Text = "BZ";
                parameters[4].Value = txtbz.Text.Trim();
                parameters[5].Text = "CKMC";
                parameters[5].Value = cmbck.Text.Trim();

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.药品盘点单, Constant.ApplicationDirectory + "\\Report\\YF_药品盘点录入单(总库存).rpt", parameters);
                if (f.LoadReportSuccess) f.Show(); else f.Dispose();
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

        //打印空表
        private void butprintKB_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset1 Dset = new ts_Yk_ReportView.Dataset1();
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.药品盘点单.NewRow();
                    myrow["xh"] = Convert.ToInt32(tb.Rows[i]["序号"]);
                    if (ss.打印单据时单据显示商品名 == true)
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["商品名"]);
                    else
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                    myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"], "0"));
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"], "0"));
                    myrow["zcsl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面数量"], "0"));
                    myrow["zcje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面金额"], "0"));


                    if (InstanceForm.BCurrentDept.DeptId == 207 || InstanceForm.BCurrentDept.DeptId == 424)
                    {
                        myrow["kfjkc"] = Convertor.IsNull(tb.Rows[i]["发药机库存"], "0");
                    }
                    myrow["pcsl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存数量"], "0"));
                    myrow["pcje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存金额"], "0"));
                    myrow["yksl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"], "0"));
                    //myrow["ypph"]=Convert.ToString(tb.Rows[i]["批号"]);
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                    myrow["kwmc"] = Convert.ToString(tb.Rows[i]["库位"]);
                    myrow["yplx"] = Convert.ToString(tb.Rows[i]["药品类型"]);
                    myrow["ypjx"] = Convert.ToString(tb.Rows[i]["剂型"]);
                    myrow["zcsl2"] = Convert.ToString(tb.Rows[i]["帐面数量2"]);
                    //myrow["pcsl2"] = tb.Rows[i]["盘存数量2"].ToString();
                    Dset.药品盘点单.Rows.Add(myrow);

                }
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "DJH";
                parameters[0].Value = this.lbldjh.Text;
                parameters[1].Text = "DJY";
                parameters[1].Value = InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "RQ";
                parameters[2].Value = dtprq.Text.Trim();
                parameters[3].Text = "TITLETEXT";
                parameters[3].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")盘点空表";
                parameters[4].Text = "BZ";
                parameters[4].Value = txtbz.Text.Trim();
                parameters[5].Text = "CKMC";
                parameters[5].Value = cmbck.Text.Trim();

                TrasenFrame.Forms.FrmReportView f = null;
                if (InstanceForm.BCurrentDept.DeptId == 207 || InstanceForm.BCurrentDept.DeptId == 424)
                {
                    f = new TrasenFrame.Forms.FrmReportView(Dset.药品盘点单, Constant.ApplicationDirectory + "\\Report\\YF_药品盘点空表单(总库存)快发.rpt", parameters);
                }
                else
                {
                    f = new TrasenFrame.Forms.FrmReportView(Dset.药品盘点单, Constant.ApplicationDirectory + "\\Report\\YF_药品盘点空表单(总库存).rpt", parameters);
                }
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
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


        private void butnext_Click(object sender, System.EventArgs e)
        {
            try
            {
                int cjid = Convert.ToInt32(Convertor.IsNull(this.txtdwcx.Tag, "0"));
                int nrow = Convert.ToInt32(Convertor.IsNull(this.butnext.Tag, "0"));
                FindRecord(cjid, nrow);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void butLoadData_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                FrmOptionData f = new FrmOptionData(_menuTag, _chineseName, _mdiParent);
                Point point = new Point(500, 75);
                f.Location = point;
                f.ShowDialog();
                if (f.ssql == "") return;

                cmbck.SelectedValue = f._Deptid.ToString();
                cmbck.Enabled = false;

                DataTable tb = InstanceForm.BDatabase.GetDataTable(f.ssql);
                FunBase.AddRowtNo(tb);
                tb.TableName = "tb";
                this.myDataGrid1.DataSource = tb;
                this.myDataGrid1.TableStyles[0].MappingName = "tb";

                

                ////if (f.chkmrz.Checked == true)
                ////    butmrwl_Click(sender, e);
                ////else
                ////    butmrzc_Click(sender, e);

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == this.tabPage2) AddLpyp(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        private void butprintlpyp_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                DataRow myrow;
                DataRow[] rows;
                if (this.chkprintlp.Checked == true)
                    rows = tb.Select("库存量<>'0'");
                else
                    rows = tb.Select("");

                for (int i = 0; i <= rows.Length - 1; i++)
                {

                    myrow = Dset.药品盘点单.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                    myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                    myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["批发价"], "0"));
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["零售价"], "0"));
                    myrow["zcsl"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["库存量"], "0"));
                    decimal zmje = Convert.ToDecimal(myrow["zcsl"]) * Convert.ToDecimal(myrow["lsj"]);
                    myrow["zcje"] = zmje.ToString("0.00");
                    myrow["pcsl"] = 0;
                    myrow["pcje"] = 0;
                    myrow["yksl"] = 0;
                    //myrow["ypph"]=Convert.ToString(rows[i]["批号"]);
                    myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                    myrow["kwmc"] = Convert.ToString(rows[i]["库位"]);
                    Dset.药品盘点单.Rows.Add(myrow);

                }
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "DJH";
                parameters[0].Value = this.lbldjh.Text;
                parameters[1].Text = "DJY";
                parameters[1].Value = InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "RQ";
                parameters[2].Value = dtprq.Text.Trim();
                parameters[3].Text = "TITLETEXT";
                parameters[3].Value = "漏盘药品表";
                parameters[4].Text = "BZ";
                parameters[4].Value = txtbz.Text.Trim();

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.药品盘点单, Constant.ApplicationDirectory + "\\Report\\YF_药品盘点空表单.rpt", parameters);
                if (f.LoadReportSuccess) f.Show(); else f.Dispose();
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

        private void butsavemb_Click(object sender, System.EventArgs e)
        {
            try
            {
                string mbmc = "";
                int mbid = 0;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;

                Frmxd2 f = new Frmxd2(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
                f.ShowDialog();
                if (f.mbid == -1) return;
                if (f.mbid == 0)
                {
                    TrasenFrame.Forms.DlgInputBox f1 = new TrasenFrame.Forms.DlgInputBox(mbmc, "请输入模板的名称", "输入名称");
                    f1.ShowDialog();
                    if (DlgInputBox.DlgResult == true)
                    {
                        mbmc = DlgInputBox.DlgValue;
                        mbid = 0;
                    }
                    else return;

                }
                else
                {
                    mbid = f.mbid;
                    mbmc = f.mbmc;

                }

                InstanceForm.BDatabase.BeginTransaction();
                int newmbid = 0;

                //删除模板明细
                YP_PDMB.DeleteMbmx(mbid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);

                //保存模板头
                YP_PDMB.SaveMb(mbid, mbmc, "", "", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(), InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(), InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), out newmbid, InstanceForm.BDatabase);
                if (newmbid == 0 && mbid == 0) { MessageBox.Show("模板ID为零，没有保存成功"); return; }
                if (mbid == 0 && newmbid != 0) { mbid = newmbid; }


                //保存模板明细
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["cjid"], "0")) > 0)
                        YP_PDMB.SaveMbmx(Convert.ToInt32(tb.Rows[i]["cjid"]), mbid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), tb.Rows[i]["描述"].ToString(), InstanceForm.BDatabase);
                }

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("保存成功");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InstanceForm.BDatabase.RollbackTransaction();
            }

        }

        private void myDataGrid2_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            int ncol = this.myDataGrid2.CurrentCell.ColumnNumber;
            if (this.myDataGrid2.TableStyles[0].GridColumnStyles[ncol].HeaderText == "选择")
                tb.Rows[nrow][ncol] = Convert.ToBoolean(tb.Rows[nrow][ncol]) == true ? false : true;
        }

        //禁用
        private void butjy_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            string ssql = "";
            int cjid = 0;
            long kcid = 0;
            decimal kcl = 0;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                for (int i = 0; i < tb.Rows.Count - 1; i++)
                {

                    cjid = Convert.ToInt32(tb.Rows[i]["cjid"]);
                    kcid = Convert.ToInt64(tb.Rows[i]["kcid"]);
                    kcl = Convert.ToDecimal(tb.Rows[i]["库存量"]);
                    if (kcl == 0)
                    {
                        //更新批号表
                        ssql = "update " + Yp.Seek_kcph_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) + " set bdelete=1 where cjid=" + cjid + " and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and id=" + kcid + "";
                        InstanceForm.BDatabase.DoCommand(ssql);

                        //更新盘点帐存
                        ssql = "update  yf_pdtemp set bdelete=1 where cjid=" + cjid + " and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and kcid=" + kcid + "";
                        InstanceForm.BDatabase.DoCommand(ssql);

                        //更新盘点帐存（明细库存）
                        ssql = "update  yf_pdtemp_kcmx set bdelete=1 where cjid=" + cjid + " and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and kcid=" + kcid + "";
                        InstanceForm.BDatabase.DoCommand(ssql);


                        //更新库存表
                        ssql = "select * from " + Yp.Seek_kcph_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) + " where  cjid=" + cjid + " and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and bdelete=0 ";
                        DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tab.Rows.Count == 0)
                        {
                            ssql = "update " + Yp.Seek_kcmx_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) + " set bdelete=1 where cjid=" + cjid + " and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + "";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }
                    }
                }

                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("操作成功");
                tabControl1_SelectedIndexChanged(sender, e);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message);
            }
        }

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbck.SelectedValue == null) return;
                if (cmbck.SelectedValue.ToString() == "System.Data.DataRowView") return;
                ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (tb != null) tb.Rows.Clear();
                //系统控制
                if (ss.网络内容显示商品名 == true)
                {
                    this.col商品名.Width = 130;
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["商品名"].Width = 140;
                }
                else
                {
                    this.col商品名.Width = 0;
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["商品名"].Width = 0;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtph_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 盘点录入开启大小单位辅助录入 add by jchl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkDxDwLr_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDxDwLr.Checked)
                {
                    //大单位列、小单位列、录入数量列显示
                    DataTable tb = myDataGrid1.DataSource as DataTable;
                    if (!tb.Columns.Contains(col大数量.HeaderText))
                    {
                        tb.Columns.Add(col大数量.HeaderText, typeof(string));
                    }
                    if (!tb.Columns.Contains(col小数量.HeaderText))
                    {
                        tb.Columns.Add(col小数量.HeaderText, typeof(string));
                    }
                    //if (!tb.Columns.Contains(col盘存数量2.HeaderText))
                    //{
                    //    tb.Columns.Add(col盘存数量2.HeaderText, typeof(string));
                    //}

                    col大数量.Width = 40;
                    col小数量.Width = 40;
                    col盘存数量2.Width = 65;
                    FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
                    tb.TableName = "tb";
                    this.myDataGrid1.DataSource = tb;
                    this.myDataGrid1.TableStyles[0].MappingName = "tb";
                }
                else
                {
                    //大单位列、小单位列、录入数量列隐藏
                    DataTable tb = myDataGrid1.DataSource as DataTable;
                    if (tb.Columns.Contains(col大数量.HeaderText))
                    {
                        tb.Columns.Remove(col大数量.HeaderText);
                    }
                    if (tb.Columns.Contains(col小数量.HeaderText))
                    {
                        tb.Columns.Remove(col小数量.HeaderText);
                    }
                    //if (tb.Columns.Contains(col盘存数量2.HeaderText))
                    //{
                    //    tb.Columns.Remove(col盘存数量2.HeaderText);
                    //}

                    col大数量.Width = 0;
                    col小数量.Width = 0;
                    //col盘存数量2.Width = 0;
                    FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
                    tb.TableName = "tb";
                    this.myDataGrid1.DataSource = tb;
                    this.myDataGrid1.TableStyles[0].MappingName = "tb";
                }
            }
            catch { MessageBox.Show("大小单位辅助录入出错！"); }
        }

        /// <summary>
        /// 通过大小单位计算盘存数量
        /// </summary>
        private void DoCountPcSl(DataRow dr)
        {

            //1、 二次校验大、小单位数量的数据合理性
            decimal dBig = 0.0M;
            decimal dSmall = 0.0M;
            string strBig = dr[col大数量.HeaderText] == DBNull.Value ? "" : dr[col大数量.HeaderText].ToString();
            string strSmall = dr[col小数量.HeaderText] == DBNull.Value ? "" : dr[col小数量.HeaderText].ToString();

            if (!string.IsNullOrEmpty(strBig))
            {
                if (!decimal.TryParse(strBig.Trim(), out dBig))
                {
                    dr[col大数量.HeaderText] = "";
                }
            }

            if (!string.IsNullOrEmpty(strSmall))
            {
                if (!decimal.TryParse(strSmall.Trim(), out dSmall))
                {
                    dr[col小数量.HeaderText] = "";
                }
            }

            //2、 校验dwbl未拆零，小单位默认0
            if (dr["DWBL"].ToString().Equals("1"))
            {
                if (!string.IsNullOrEmpty(strSmall))
                {
                    dr[col小数量.HeaderText] = "";
                }
            }


            //3、 计算盘存数据-盘存数据2
            try
            {
                decimal dDwbl = decimal.Parse(dr["DWBL"].ToString());
                decimal dBigCnt = dBig * dDwbl / 1;
                decimal dSmlCnt = dSmall * dDwbl / dDwbl;

                if (string.IsNullOrEmpty(strBig) && string.IsNullOrEmpty(strSmall))
                {
                    //dr["盘存数量"] = dBigCnt + dSmlCnt;
                }
                else
                {
                    dr["盘存数量"] = dBigCnt + dSmlCnt;
                }

                if (!string.IsNullOrEmpty(strBig))
                {
                    dr["盘存数量2"] = strBig.Trim() + dr["大单位"].ToString().Trim();
                }

                if ((!string.IsNullOrEmpty(strBig)) && (!string.IsNullOrEmpty(strSmall)))
                {
                    dr["盘存数量2"] = strBig.Trim() + dr["大单位"].ToString().Trim() + strSmall.Trim() + dr["单位"].ToString().Trim();
                }

                if (string.IsNullOrEmpty(strBig) && string.IsNullOrEmpty(strSmall))
                {
                    dr["盘存数量2"] = "";
                }
            }
            catch { }
        }

        private bool myDataGrid1_myKeyDown(ref Message msg, Keys keyData)
        {
            try
            {
                //msg.
                int iRow = myDataGrid1.CurrentCell.RowNumber;
                int iCol = myDataGrid1.CurrentCell.ColumnNumber;
                DataTable dt = myDataGrid1.DataSource as DataTable;
                string strName = myDataGrid1.TableStyles[0].GridColumnStyles[iCol].HeaderText;
                DataRow dr = dt.Rows[iRow];
                string strSl = dr[col大数量.HeaderText].ToString();

                string key = ((char)keyData.GetHashCode()).ToString();



                if (keyData.Equals(Keys.Enter) || keyData.Equals(Keys.Up) || keyData.Equals(Keys.Down) || keyData.Equals(Keys.Left) || keyData.Equals(Keys.Right) || keyData.Equals(Keys.Tab))
                {
                    dt.AcceptChanges();
                    if (!string.IsNullOrEmpty(dr[strName].ToString()))
                    {
                        decimal dMr = 0.0M;

                        string strInPut = dr[strName].ToString();//+ key;

                        if (strName.Trim().Equals(col大数量.HeaderText.Trim()) || strName.Trim().Equals(col小数量.HeaderText.Trim()))
                        {

                            if (!decimal.TryParse(strInPut.Trim(), out dMr))
                            {
                                MessageBox.Show(strName + " 只能输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dr[strName] = "";
                                dt.AcceptChanges();
                                myDataGrid1.CurrentCell = new DataGridCell(iRow, iCol);
                                return false;
                            }
                        }

                        if (strName.Trim().Equals(col小数量.HeaderText.Trim()))
                        {
                            string strDwbl = dr["dwbl"].ToString().Trim();//单位比例
                            if (strDwbl.Equals("1"))
                            {
                                dr[col小数量.HeaderText] = "";
                                dt.AcceptChanges();
                                MessageBox.Show(" 药品未拆零，不能输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }


                if (keyData.Equals(Keys.Enter))
                {

                    if (strName.Trim().Equals(col大数量.HeaderText.Trim()))
                    {
                        myDataGrid1.CurrentCell = new DataGridCell(iRow, iCol + 1);
                    }
                    else if (strName.Trim().Equals(col小数量.HeaderText.Trim()))
                    {
                        myDataGrid1.CurrentCell = new DataGridCell(iRow, iCol + 1);
                        //myDataGrid1.CurrentCell = new DataGridCell(iRow + 1, iCol - 1);
                    }
                    else if (strName.Trim().Equals(col盘存数量.HeaderText.Trim()))
                    {
                        //myDataGrid1.CurrentCell = new DataGridCell(iRow, iCol + 1);
                        myDataGrid1.CurrentCell = new DataGridCell(iRow + 1, iCol - 2);
                    }
                }

                //if ((strName == "大数量" || strName == "小数量") && Convertor.IsNumeric(key) == true)
                //{

                //    DoCountPcSl(dt.Rows[iRow]);
                //}

                return default(bool);
            }
            catch
            {
                return false;
            }
        }

        private void myDataGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            int sss = (int)e.KeyData;
        }

        /// <summary>
        /// 北院中导入快发机中EXCEL视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开(Open)";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            ofd.Filter = "excel2007 files (*.xlsx)|*.xlsx|excel2003 files (*.xls)|*.xls";       
            ofd.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true;  //验证路径有效性
            ofd.CheckPathExists = true; //验证文件有效性
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DataTable gridTable = myDataGrid1.DataSource as DataTable;
                    gridTable.BeginInit();
                    Workbook workbook = new Workbook();
                    workbook.Open(ofd.FileName);
                    Cells cells = workbook.Worksheets[0].Cells;
                    for (int i = 1; i < cells.MaxDataRow + 1; i++)
                    {                      
                        string YPPM = cells[i, 1].StringValue.Trim();
                        string YPGG = cells[i, 6].StringValue.Trim();
                        string S_SCCJ = cells[i, 10].StringValue.Trim();
                        int sl = int.Parse(cells[i, 3].StringValue.Trim());
                        string ypdw = cells[i, 7].StringValue.Trim();
                        int cjid = 0;
                        string sql = string.Format(@"select a.CJID from YP_YPCJD a inner join YP_YPGGD b on a.GGID = b.GGID where a.S_SCCJ = '{0}'
                                                     and b.YPPM = '{1}' and b.YPGG = '{2}'", S_SCCJ, YPPM, YPGG);
                        DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            cjid = int.Parse(tb.Rows[0][0].ToString().Trim());
                            DataRow[] resultRow = gridTable.Select(string.Format("  cjid = {0}", cjid));
                            if (resultRow != null && resultRow.Length > 0)
                            {
                                resultRow[0]["发药机库存"] = sl + ypdw;
                            }
                        }
                    }
                    gridTable.EndInit();
                    MessageBox.Show("导入成功");
                    //cells = workbook.Worksheets[0].Cells;
                    //System.Data.DataTable dataTable1 = cells.ExportDataTable(1, 0, cells.MaxDataRow, cells.MaxColumn, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        /// <summary>
        /// 导入快发机数据视图数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImportKfj_Click(object sender, EventArgs e)
        {
            /*
            if (!("207,424").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
            {
                btn_ImportKfj.Visible = false;
            }*/


            

            if (MessageBox.Show("是否从数据库中导入快发机库存数据？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {                  

                    DataTable gridTable = myDataGrid1.DataSource as DataTable;
                    gridTable.BeginInit();

                    if (gridTable.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        //此处可以单独建立，进行配置项目 hyd 快发机的实时库存视图
                        SqlConnection conn = null;
                        SqlCommand cmd = null;
                        if (("424").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                        {
                            //访问南京路的
                            conn = new SqlConnection("uid=Led;pwd=Led;server=192.168.0.44;database=Mis9whszxyybyDB");
                            cmd = new SqlCommand("select dispensary,drug_code,quantity,unit,drug_spec,firm_id,firm_name from HIS_CONSIS_STORAGE_CHKQTYVW ", conn);
                        }
                        if (("207").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                        {
                            //访问后湖的
                            conn = new SqlConnection("uid=Led;pwd=Led;server=192.168.100.171;database=Mis9whzxyyhhDB");
                            cmd = new SqlCommand("select dispensary,drug_code,quantity,unit,drug_spec,firm_id,firm_name from HIS_CONSIS_STORAGE_CHKQTYVW ", conn);
                        }

                       // SqlConnection conn = new SqlConnection("uid=Led;pwd=Led;server=192.168.0.44;database=Mis9whszxyybyDB");
                      //  SqlCommand cmd = new SqlCommand("select dispensary,drug_code,quantity,unit,drug_spec,firm_id,firm_name from HIS_CONSIS_STORAGE_CHKQTYVW ", conn);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string YPid = dt.Rows[i]["drug_code"].ToString();//药品id
                                string YPGG = dt.Rows[i]["drug_spec"].ToString();//药品规格
                                string S_SCCJ = dt.Rows[i]["firm_name"].ToString();//药品生产厂家
                                int sl = Convert.ToInt32(Convertor.IsNull(dt.Rows[i]["quantity"].ToString(), "0")); ;//药品库存最
                                string ypdw = dt.Rows[i]["unit"].ToString();//药品单位
                                int cjid = 0;
                                cjid = Convert.ToInt32(Convertor.IsNull(dt.Rows[i]["drug_code"].ToString(), "0")); ;//药品库存最

                                DataRow[] resultRow = gridTable.Select(string.Format("  cjid = {0}", cjid));
                                if (resultRow != null && resultRow.Length > 0)
                                {
                                    resultRow[0]["发药机库存"] = sl + ypdw;
                                }
                            }
                            gridTable.EndInit();
                            MessageBox.Show("导入快发机库存数据成功！");
                        }
                        else
                        {
                            MessageBox.Show("快发机视图中没有数据，请与快发机厂商管理员联系！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先提取数据，再进行导入操作！");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        
    }
}
