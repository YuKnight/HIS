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

namespace ts_yp_pd
{
	/// <summary>
	/// Frmyprk 的摘要说明。
	/// </summary>
	public class Frmpdsh_kcmx : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn col批号;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
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
		private System.Windows.Forms.TextBox txtbz;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbldjh;
		private System.Windows.Forms.Label lbldjhH;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblkw;
		private System.Windows.Forms.Label lblzmje;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblzmsl;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblpcje;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button butph;
		private System.Windows.Forms.TextBox txtph;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label31;
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
		private System.Windows.Forms.TextBox txtdwcx;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button butpkd;
		private System.Windows.Forms.Button butpyd;
		private System.Windows.Forms.Button butclose;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.GroupBox groupBox5;
		private myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn48;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn49;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn50;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn51;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn52;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn53;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn54;
		private System.Windows.Forms.DataGridTextBoxColumn c库位;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn56;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn57;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn58;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn59;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn60;
		private System.Windows.Forms.DataGridTextBoxColumn 库位;
		private System.Windows.Forms.CheckBox chkprint;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button butprintlp;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.CheckBox chkprintlp;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.DataGridTextBoxColumn 品名;
		private System.Windows.Forms.DataGridTextBoxColumn 商品名;
		private System.Windows.Forms.Label lblpm;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private YpConfig ss;
		private System.Windows.Forms.DataGridTextBoxColumn col进价;
		private System.Windows.Forms.DataGridTextBoxColumn col进货金额;
        private Label lblsdjh;
        private ComboBox cmbck;
        private Label label2;
        private Button butLoadData;

        private string pcfs = "0";//盘存方式 0-盘明细 1-盘批次
        private bool bpcgl = true;

        private bool btjhj = false;//是否调进货价
           

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmpdsh_kcmx(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            //初始化列表
            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");

            FunBase.CsDataGrid(this.myDataGrid3, this.myDataGrid3.TableStyles[0], "Tb1");

            FunBase.CsDataGrid(this.myDataGrid2, this.myDataGrid2.TableStyles[0], "Tb2");

            Yp.AddcmbCk(false, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);


			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col批号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.库位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col进价 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col进货金额 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
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
            this.butpkd = new System.Windows.Forms.Button();
            this.butpyd = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.chkprint = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.butnext = new System.Windows.Forms.Button();
            this.lblkw = new System.Windows.Forms.Label();
            this.txtdwcx = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtph = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butph = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblpm = new System.Windows.Forms.Label();
            this.lblzmje = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblzmsl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblpcje = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.label16 = new System.Windows.Forms.Label();
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtypdm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butLoadData = new System.Windows.Forms.Button();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblsdjh = new System.Windows.Forms.Label();
            this.dtprq = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldjh = new System.Windows.Forms.Label();
            this.lbldjhH = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn48 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn49 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn50 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn51 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn52 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn53 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn54 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.c库位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn56 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn57 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn58 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn59 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn60 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkprintlp = new System.Windows.Forms.CheckBox();
            this.butquit = new System.Windows.Forms.Button();
            this.butprintlp = new System.Windows.Forms.Button();
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
            this.groupBox5.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.panel4.SuspendLayout();
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
            this.myDataGrid1.Size = new System.Drawing.Size(820, 208);
            this.myDataGrid1.TabIndex = 60;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.品名,
            this.商品名,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn16,
            this.col批号,
            this.库位,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.col进价,
            this.col进货金额,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumn40});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
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
            // 品名
            // 
            this.品名.Format = "";
            this.品名.FormatInfo = null;
            this.品名.HeaderText = "品名";
            this.品名.NullText = "";
            this.品名.ReadOnly = true;
            this.品名.Width = 130;
            // 
            // 商品名
            // 
            this.商品名.Format = "";
            this.商品名.FormatInfo = null;
            this.商品名.HeaderText = "商品名";
            this.商品名.NullText = "";
            this.商品名.Width = 130;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 90;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 90;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "批发价";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 60;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "批发金额";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 0;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "零售价";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 60;
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
            // 库位
            // 
            this.库位.Format = "";
            this.库位.FormatInfo = null;
            this.库位.HeaderText = "库位";
            this.库位.NullText = "";
            this.库位.ReadOnly = true;
            this.库位.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "帐面数量";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "帐面金额";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 70;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "盘存数量";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 60;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "单位";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 40;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "盘存金额";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 70;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "盈亏数量";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "盈亏金额";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 70;
            // 
            // col进价
            // 
            this.col进价.Format = "";
            this.col进价.FormatInfo = null;
            this.col进价.HeaderText = "进价";
            this.col进价.NullText = "";
            this.col进价.Width = 0;
            // 
            // col进货金额
            // 
            this.col进货金额.Format = "";
            this.col进货金额.FormatInfo = null;
            this.col进货金额.HeaderText = "进货金额";
            this.col进货金额.NullText = "";
            this.col进货金额.Width = 0;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "货号";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 60;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "CJID";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "KCID";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.ReadOnly = true;
            this.dataGridTextBoxColumn19.Width = 0;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "DWBL";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.ReadOnly = true;
            this.dataGridTextBoxColumn20.Width = 0;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "KWID";
            this.dataGridTextBoxColumn41.NullText = "";
            this.dataGridTextBoxColumn41.Width = 0;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.HeaderText = "ID";
            this.dataGridTextBoxColumn40.NullText = "";
            this.dataGridTextBoxColumn40.Width = 0;
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
            this.statusBar1.Size = new System.Drawing.Size(834, 23);
            this.statusBar1.TabIndex = 3;
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
            this.myDataGrid3.Size = new System.Drawing.Size(826, 112);
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
            this.dataGridTextBoxColumn22.Width = 0;
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
            this.tabControl1.Size = new System.Drawing.Size(834, 592);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(826, 563);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "盘点审核";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(826, 260);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(820, 208);
            this.panel2.TabIndex = 62;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butpkd);
            this.panel1.Controls.Add(this.butpyd);
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.chkprint);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 32);
            this.panel1.TabIndex = 61;
            // 
            // butpkd
            // 
            this.butpkd.Enabled = false;
            this.butpkd.Location = new System.Drawing.Point(608, 3);
            this.butpkd.Name = "butpkd";
            this.butpkd.Size = new System.Drawing.Size(112, 24);
            this.butpkd.TabIndex = 71;
            this.butpkd.Text = "打印盘亏单(&K)";
            this.butpkd.Click += new System.EventHandler(this.butpkd_Click);
            // 
            // butpyd
            // 
            this.butpyd.Enabled = false;
            this.butpyd.Location = new System.Drawing.Point(496, 3);
            this.butpyd.Name = "butpyd";
            this.butpyd.Size = new System.Drawing.Size(112, 24);
            this.butpyd.TabIndex = 70;
            this.butpyd.Text = "打印盘盈单(&Y)";
            this.butpyd.Click += new System.EventHandler(this.butpyd_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(721, 3);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 68;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(408, 3);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 67;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(320, 3);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(88, 24);
            this.butsave.TabIndex = 66;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // chkprint
            // 
            this.chkprint.Location = new System.Drawing.Point(128, 2);
            this.chkprint.Name = "chkprint";
            this.chkprint.Size = new System.Drawing.Size(200, 24);
            this.chkprint.TabIndex = 73;
            this.chkprint.Text = "打印过虑帐存盘存都为零的药品";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(8, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 24);
            this.checkBox1.TabIndex = 72;
            this.checkBox1.Text = "隐藏盘点明细窗口";
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 451);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(826, 112);
            this.panel3.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.butnext);
            this.groupBox4.Controls.Add(this.lblkw);
            this.groupBox4.Controls.Add(this.txtdwcx);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.txtph);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.butph);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(826, 40);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // butnext
            // 
            this.butnext.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butnext.Location = new System.Drawing.Point(448, 14);
            this.butnext.Name = "butnext";
            this.butnext.Size = new System.Drawing.Size(56, 20);
            this.butnext.TabIndex = 83;
            this.butnext.Text = "Next";
            this.butnext.Visible = false;
            this.butnext.Click += new System.EventHandler(this.butnext_Click);
            // 
            // lblkw
            // 
            this.lblkw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkw.ForeColor = System.Drawing.Color.Navy;
            this.lblkw.Location = new System.Drawing.Point(560, 12);
            this.lblkw.Name = "lblkw";
            this.lblkw.Size = new System.Drawing.Size(104, 20);
            this.lblkw.TabIndex = 74;
            this.lblkw.Visible = false;
            // 
            // txtdwcx
            // 
            this.txtdwcx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtdwcx.ForeColor = System.Drawing.Color.Navy;
            this.txtdwcx.Location = new System.Drawing.Point(64, 13);
            this.txtdwcx.Name = "txtdwcx";
            this.txtdwcx.Size = new System.Drawing.Size(440, 21);
            this.txtdwcx.TabIndex = 80;
            this.txtdwcx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 81;
            this.label25.Text = "定位查询";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(528, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 16);
            this.label31.TabIndex = 62;
            this.label31.Text = "库位";
            this.label31.Visible = false;
            // 
            // txtph
            // 
            this.txtph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtph.Location = new System.Drawing.Point(716, 10);
            this.txtph.Name = "txtph";
            this.txtph.ReadOnly = true;
            this.txtph.Size = new System.Drawing.Size(96, 21);
            this.txtph.TabIndex = 4;
            this.txtph.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(678, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 65;
            this.label5.Text = "批 号";
            this.label5.Visible = false;
            // 
            // butph
            // 
            this.butph.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butph.Location = new System.Drawing.Point(680, 16);
            this.butph.Name = "butph";
            this.butph.Size = new System.Drawing.Size(25, 20);
            this.butph.TabIndex = 67;
            this.butph.Text = "zzz";
            this.butph.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.lblzmje);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblzmsl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblpcje);
            this.groupBox2.Controls.Add(this.label7);
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
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtypdm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(826, 88);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(216, 11);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(192, 20);
            this.lblpm.TabIndex = 75;
            // 
            // lblzmje
            // 
            this.lblzmje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzmje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzmje.ForeColor = System.Drawing.Color.Navy;
            this.lblzmje.Location = new System.Drawing.Point(216, 36);
            this.lblzmje.Name = "lblzmje";
            this.lblzmje.Size = new System.Drawing.Size(104, 20);
            this.lblzmje.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(160, 39);
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
            this.lblzmsl.Location = new System.Drawing.Point(216, 61);
            this.lblzmsl.Name = "lblzmsl";
            this.lblzmsl.Size = new System.Drawing.Size(87, 20);
            this.lblzmsl.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(160, 64);
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
            this.lblpcje.Location = new System.Drawing.Point(385, 61);
            this.lblpcje.Name = "lblpcje";
            this.lblpcje.Size = new System.Drawing.Size(88, 20);
            this.lblpcje.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(328, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 68;
            this.label7.Text = "盘存金额";
            // 
            // txtypsl
            // 
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.Location = new System.Drawing.Point(64, 37);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.ReadOnly = true;
            this.txtypsl.Size = new System.Drawing.Size(80, 21);
            this.txtypsl.TabIndex = 2;
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
            this.lbllsj.Location = new System.Drawing.Point(383, 39);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(88, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(337, 39);
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
            this.lblpfj.Location = new System.Drawing.Point(530, 64);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(81, 20);
            this.lblpfj.TabIndex = 27;
            this.lblpfj.Visible = false;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(486, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 16);
            this.label20.TabIndex = 26;
            this.label20.Text = "批发价";
            this.label20.Visible = false;
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.Enabled = false;
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(64, 61);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(80, 20);
            this.cmbdw.TabIndex = 3;
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
            this.lblhh.Location = new System.Drawing.Point(530, 37);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(152, 20);
            this.lblhh.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(498, 40);
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
            this.lblypmc.Location = new System.Drawing.Point(408, 11);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(152, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(145, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 20;
            this.label16.Text = "品名/商品名";
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(728, 12);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(87, 20);
            this.lblcj.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(688, 13);
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
            this.lblgg.Location = new System.Drawing.Point(600, 12);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(84, 20);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(568, 13);
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
            this.txtypdm.ReadOnly = true;
            this.txtypdm.Size = new System.Drawing.Size(80, 21);
            this.txtypdm.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "药品代码";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butLoadData);
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblsdjh);
            this.groupBox1.Controls.Add(this.dtprq);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbldjh);
            this.groupBox1.Controls.Add(this.lbldjhH);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // butLoadData
            // 
            this.butLoadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLoadData.ForeColor = System.Drawing.Color.Blue;
            this.butLoadData.Location = new System.Drawing.Point(222, 10);
            this.butLoadData.Name = "butLoadData";
            this.butLoadData.Size = new System.Drawing.Size(143, 24);
            this.butLoadData.TabIndex = 76;
            this.butLoadData.Text = "提取盘存录入数据(&W)";
            this.butLoadData.UseVisualStyleBackColor = false;
            this.butLoadData.Click += new System.EventHandler(this.butLoadData_Click);
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(64, 12);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(153, 20);
            this.cmbck.TabIndex = 30;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "仓库名称";
            // 
            // lblsdjh
            // 
            this.lblsdjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsdjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsdjh.ForeColor = System.Drawing.Color.Navy;
            this.lblsdjh.Location = new System.Drawing.Point(728, 12);
            this.lblsdjh.Name = "lblsdjh";
            this.lblsdjh.Size = new System.Drawing.Size(84, 20);
            this.lblsdjh.TabIndex = 24;
            // 
            // dtprq
            // 
            this.dtprq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtprq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtprq.ForeColor = System.Drawing.Color.Navy;
            this.dtprq.Location = new System.Drawing.Point(432, 12);
            this.dtprq.Name = "dtprq";
            this.dtprq.Size = new System.Drawing.Size(152, 20);
            this.dtprq.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(371, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "审核时间";
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(64, 36);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(748, 21);
            this.txtbz.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 38);
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
            this.lbldjh.Location = new System.Drawing.Point(644, 12);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(82, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhH
            // 
            this.lbldjhH.Location = new System.Drawing.Point(590, 16);
            this.lbldjhH.Name = "lbldjhH";
            this.lbldjhH.Size = new System.Drawing.Size(64, 16);
            this.lbldjhH.TabIndex = 14;
            this.lbldjhH.Text = "审核单号";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(826, 563);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "漏盘药品";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel5);
            this.groupBox5.Controls.Add(this.panel4);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(826, 563);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.myDataGrid2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(820, 487);
            this.panel5.TabIndex = 2;
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
            this.myDataGrid2.Size = new System.Drawing.Size(820, 487);
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn48,
            this.dataGridTextBoxColumn49,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn50,
            this.dataGridTextBoxColumn51,
            this.dataGridTextBoxColumn52,
            this.dataGridTextBoxColumn53,
            this.dataGridTextBoxColumn54,
            this.c库位,
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
            this.dataGridTextBoxColumn48.NullText = "";
            this.dataGridTextBoxColumn48.Width = 35;
            // 
            // dataGridTextBoxColumn49
            // 
            this.dataGridTextBoxColumn49.Format = "";
            this.dataGridTextBoxColumn49.FormatInfo = null;
            this.dataGridTextBoxColumn49.HeaderText = "品名";
            this.dataGridTextBoxColumn49.NullText = "";
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
            this.dataGridTextBoxColumn50.NullText = "";
            this.dataGridTextBoxColumn50.Width = 90;
            // 
            // dataGridTextBoxColumn51
            // 
            this.dataGridTextBoxColumn51.Format = "";
            this.dataGridTextBoxColumn51.FormatInfo = null;
            this.dataGridTextBoxColumn51.HeaderText = "厂家";
            this.dataGridTextBoxColumn51.NullText = "";
            this.dataGridTextBoxColumn51.Width = 90;
            // 
            // dataGridTextBoxColumn52
            // 
            this.dataGridTextBoxColumn52.Format = "";
            this.dataGridTextBoxColumn52.FormatInfo = null;
            this.dataGridTextBoxColumn52.HeaderText = "批发价";
            this.dataGridTextBoxColumn52.NullText = "";
            this.dataGridTextBoxColumn52.Width = 65;
            // 
            // dataGridTextBoxColumn53
            // 
            this.dataGridTextBoxColumn53.Format = "";
            this.dataGridTextBoxColumn53.FormatInfo = null;
            this.dataGridTextBoxColumn53.HeaderText = "零售价";
            this.dataGridTextBoxColumn53.NullText = "";
            this.dataGridTextBoxColumn53.Width = 65;
            // 
            // dataGridTextBoxColumn54
            // 
            this.dataGridTextBoxColumn54.Format = "";
            this.dataGridTextBoxColumn54.FormatInfo = null;
            this.dataGridTextBoxColumn54.HeaderText = "批号";
            this.dataGridTextBoxColumn54.NullText = "";
            this.dataGridTextBoxColumn54.Width = 65;
            // 
            // c库位
            // 
            this.c库位.Format = "";
            this.c库位.FormatInfo = null;
            this.c库位.HeaderText = "库位";
            this.c库位.NullText = "";
            this.c库位.Width = 0;
            // 
            // dataGridTextBoxColumn56
            // 
            this.dataGridTextBoxColumn56.Format = "";
            this.dataGridTextBoxColumn56.FormatInfo = null;
            this.dataGridTextBoxColumn56.HeaderText = "库存量";
            this.dataGridTextBoxColumn56.NullText = "";
            this.dataGridTextBoxColumn56.Width = 70;
            // 
            // dataGridTextBoxColumn57
            // 
            this.dataGridTextBoxColumn57.Format = "";
            this.dataGridTextBoxColumn57.FormatInfo = null;
            this.dataGridTextBoxColumn57.HeaderText = "单位";
            this.dataGridTextBoxColumn57.NullText = "";
            this.dataGridTextBoxColumn57.Width = 40;
            // 
            // dataGridTextBoxColumn58
            // 
            this.dataGridTextBoxColumn58.Format = "";
            this.dataGridTextBoxColumn58.FormatInfo = null;
            this.dataGridTextBoxColumn58.HeaderText = "货号";
            this.dataGridTextBoxColumn58.NullText = "";
            this.dataGridTextBoxColumn58.Width = 65;
            // 
            // dataGridTextBoxColumn59
            // 
            this.dataGridTextBoxColumn59.Format = "";
            this.dataGridTextBoxColumn59.FormatInfo = null;
            this.dataGridTextBoxColumn59.HeaderText = "cjid";
            this.dataGridTextBoxColumn59.NullText = "";
            this.dataGridTextBoxColumn59.Width = 0;
            // 
            // dataGridTextBoxColumn60
            // 
            this.dataGridTextBoxColumn60.Format = "";
            this.dataGridTextBoxColumn60.FormatInfo = null;
            this.dataGridTextBoxColumn60.HeaderText = "kcid";
            this.dataGridTextBoxColumn60.NullText = "";
            this.dataGridTextBoxColumn60.Width = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkprintlp);
            this.panel4.Controls.Add(this.butquit);
            this.panel4.Controls.Add(this.butprintlp);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 504);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(820, 56);
            this.panel4.TabIndex = 1;
            // 
            // chkprintlp
            // 
            this.chkprintlp.Location = new System.Drawing.Point(232, 24);
            this.chkprintlp.Name = "chkprintlp";
            this.chkprintlp.Size = new System.Drawing.Size(176, 24);
            this.chkprintlp.TabIndex = 73;
            this.chkprintlp.Text = "只打印库存数不为零的药品";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(552, 16);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(104, 32);
            this.butquit.TabIndex = 1;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprintlp
            // 
            this.butprintlp.Location = new System.Drawing.Point(440, 16);
            this.butprintlp.Name = "butprintlp";
            this.butprintlp.Size = new System.Drawing.Size(104, 32);
            this.butprintlp.TabIndex = 0;
            this.butprintlp.Text = "打印(&P)";
            this.butprintlp.Click += new System.EventHandler(this.butprintlp_Click);
            // 
            // Frmpdsh_kcmx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(834, 615);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Frmpdsh_kcmx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盘点审核";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmzylr_Load);
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
            this.panel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		
		private void Frmzylr_Load(object sender, System.EventArgs e)
		{

			this.checkBox1.Checked=true;

            if (_menuTag.Function_Name == "Fun_ts_yp_pd_yf_cx" || _menuTag.Function_Name == "Fun_ts_yp_pd_cx")
            {
                butsave.Visible = false;
                butLoadData.Enabled = false;
            }

      
            SystemCfg cfg8056 = new SystemCfg(8056);//调进货价
            if (cfg8056.Config == "1")
            {
                btjhj = true;
            }

		}

	
		#region 界面控制事件


		//网格单元改变事件
		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				int ncol =this.myDataGrid1.CurrentCell.ColumnNumber ;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (nrow<tb.Rows.Count && tb.Rows.Count>0)
				{
					DataRow row=tb.Rows[nrow];
					Getrow(row);
				}

				int cjid=0;
				DataTable tb1=(DataTable)this.myDataGrid1.DataSource;
				if (nrow<tb1.Rows.Count)
				{
					cjid=Convert.ToInt32(tb1.Rows[nrow]["cjid"]);
				}
				Selectpcmx(cjid);


				this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);
				return ;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			
		}
		
		
		//在网格内查找相关药品
		public  void FindRecord(int cjid,int nrow)
		{
			int beginrow=nrow;
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			for(int i=beginrow;i<=tb.Rows.Count-1;i++)
			{
				if (Convert.ToInt32(tb.Rows[i]["cjid"])==cjid)
				{
					this.myDataGrid1.CurrentCell=new DataGridCell(i,0);
					for(int j=0;j<=tb.Rows.Count-1;j++)
					{
						this.myDataGrid1.UnSelect(j);
					}

					this.myDataGrid1.Select(i);
					beginrow=i+1;
					if (beginrow!=tb.Rows.Count) 
					{
						this.butnext.Visible=true;
						this.butnext.Tag=beginrow.ToString(); 
					}
					else
					{
						this.butnext.Visible=false;
						this.butnext.Tag="0";
					}
					return;

				}
				
				if (beginrow>=tb.Rows.Count-1)
				{
					this.butnext.Visible=false;
				}

			}
		}

		//输入框控制事件
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" ){control.Text="";control.Tag="0";}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)=="")))
			{}
			else{return;}

			string[] GrdMappingName;
			int[] GrdWidth;
			string[]sfield;
			string ssql="";
			DataRow row;
			
			try
			{
				Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
				switch(control.TabIndex)
				{
					case 80:
						if (control.Text.Trim()=="") return;
						GrdMappingName=new string[] {"ggid","cjid","行号","品名","规格","厂家","单位","批发价","零售价","货号"};
						GrdWidth=new int[] {0,0,50,200,100,100,40,60,60,70};
						sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
                        if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),InstanceForm.BDatabase) == true)
                            ssql = "select  distinct a.ggid,cjid,0 rowno,ypspm,ypgg,s_sccj sccj,dbo.fun_yp_ypdw(ypdw) ypdw,pfj,lsj,shh from vi_Yk_kcmx a,yp_ypbm b where a.ggid=b.ggid  and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + "  ";
						else
                            ssql = "select distinct a.ggid,cjid,0 rowno,ypspm,ypgg,s_sccj sccj,dbo.fun_yp_ypdw(ypdw) ypdw,pfj,lsj,shh from vi_Yf_kcmx a,yp_ypbm b where a.ggid=b.ggid  and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + "  ";
						TrasenFrame.Forms.Fshowcard f3=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,FilterType.拼音,control.Text.Trim(),ssql);
						f3.Location=point;
						f3.ShowDialog(this);
						row=f3.dataRow;
						if (row!=null) 
						{
							control.Text=row["ypspm"].ToString();
							control.Tag=row["cjid"].ToString();
							int cjid=Convert.ToInt32(Convertor.IsNull(row["cjid"],"0"));
							int nrow=0;
							FindRecord(cjid,nrow);
							
						}
						break;

				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}


		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();

                if (tabControl1.SelectedTab == this.tabPage2) AddLpyp(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}


		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox1.Checked==true)
			{
				this.panel3.Visible=false;
			}
			else
			{
				this.panel3.Visible=true;
			}
		}

		#endregion

		#region 填充数据的过程
		
		//求和金额
		private void Sumje()
		{
			decimal sumzcje=0;
			decimal sumpcje=0;
			decimal sumykje=0;
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			for( int i=0;i<=tb.Rows.Count-1;i++)
			{
				sumzcje=sumzcje+Convert.ToDecimal(tb.Rows[i]["帐面金额"]);
				sumpcje=sumpcje+Convert.ToDecimal(tb.Rows[i]["盘存金额"]);
			}
			sumykje=sumpcje-sumzcje;
			this.statusBar1.Panels[0].Text ="帐面金额: "+sumzcje.ToString("0.00");
			this.statusBar1.Panels[1].Text ="盘存金额: "+sumpcje.ToString("0.00");
			this.statusBar1.Panels[2].Text ="盈亏金额: "+sumykje.ToString("0.00");
		}


		//获取一行
		private void Getrow(DataRow row)
		{
			int cjid=Convert.ToInt32(Convertor.IsNull(row["cjid"],"0"));
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
			this.lblypmc.Text=row["商品名"].ToString();
			this.lblpm.Text=row["品名"].ToString();
			this.lblypmc.Tag=row["CJID"].ToString();
			this.lblgg.Text=row["规格"].ToString();
			this.lblcj.Text=row["厂家"].ToString();
			this.lblpfj.Text=row["批发价"].ToString();
			this.lblpfj.Tag=ydcj.PFJ.ToString();
			this.lbllsj.Text=row["零售价"].ToString();
			this.lbllsj.Tag=ydcj.LSJ.ToString();
			this.txtph.Text=row["批号"].ToString();
			this.txtph.Tag=row["kcid"].ToString();

            //this.lblkw.Text=row["库位"].ToString();
            //this.lblkw.Tag=row["kwid"].ToString();
			this.lblzmsl.Text=row["帐面数量"].ToString();
			this.lblzmje.Text=row["帐面金额"].ToString();
			this.txtypsl.Text=row["盘存数量"].ToString();
            Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
			this.cmbdw.Text=row["单位"].ToString();
			this.lblpcje.Text=row["盘存金额"].ToString();
			this.lblhh.Text=row["货号"].ToString();
			
		}


		//填充单据
		public void FillDj(Guid  id,bool shbz)
		{
			string ssql="select * from Yf_pd where id='"+id+"'";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count <= 0) return;

            butLoadData.Enabled = false;
            cmbck.Enabled = false;
            cmbck.SelectedValue = tb.Rows[0]["deptid"].ToString();

			this.groupBox1.Tag=tb.Rows[0]["id"].ToString();
			this.txtbz.Text=tb.Rows[0]["bz"].ToString();
			long djh=Convert.ToInt64(tb.Rows[0]["djh"]);
			this.lbldjh.Text=djh.ToString("00000000");

            ssql = "select sdjh from vi_yf_dj where ywlx='" + _menuTag.FunctionTag.Trim() + "' and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and djh=" + djh + "";
            DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
            this.lblsdjh.Text = tab.Rows.Count==0?"":tab.Rows[0]["sdjh"].ToString();

			this.dtprq.Text=tb.Rows[0]["djrq"].ToString();

			ssql=@"select CAST(0 AS CHAR(12)) 序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,s_sccj 厂家,a.pfj 批发价,0.00 批发金额,
                   a.lsj 零售价,'' 批号,'' 库位,"+
				" zcs 帐面数量,zclsje 帐面金额,pcs 盘存数量,a.ypdw 单位,"+
				" pclsje 盘存金额,(pcs-zcs) 盈亏数量,(pclsje-zclsje) 盈亏金额,0 进价,0 进货金额,b.shh 货号,"+
				" a.cjid,kcid,ydwbl dwbl,0,id from Yf_pdmx_kcmx a,vi_yp_ypcd b  where a.cjid=b.cjid and  djid='"+id+"'  order by a.pxxh";
			DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
			FunBase.AddRowtNo(tbmx);
			tbmx.TableName="tbmx";
			this.myDataGrid1.DataSource=tbmx;
			this.myDataGrid1.TableStyles[0].MappingName ="tbmx";
			
			this.butsave.Enabled=false;
			this.butprint.Enabled=true;
			this.butpyd.Enabled=true;
			this.butpkd.Enabled=true;
			
			//			this.butadd.Enabled=false;
			//			this.butdel.Enabled=false;
			//			this.butmodif.Enabled=false;	
			this.Sumje();

		}

		
		//查找当前药品的相关盘存记录
		public void Selectpcmx(int cjid)
		{
			string _tablename="";
            if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),InstanceForm.BDatabase) == true)
				_tablename=" yk_kcmx";
			else
				_tablename="yf_kcmx";

            DataTable tbkc = Yp.Selectkc(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), cjid, _tablename, InstanceForm.BDatabase);
			int xdwbl=1;
			int zxdw=0;
			if (tbkc.Rows.Count!=0)
			{
				xdwbl=Convert.ToInt32(tbkc.Rows[0]["dwbl"]);
				zxdw=Convert.ToInt32(tbkc.Rows[0]["zxdw"]);
			}

            DataTable tb = YF_PDCS_PDCSMX.Select_cjid_pdmx(cjid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), Convert.ToInt64(Convertor.IsNull(lbldjh.Text, "0")), InstanceForm.BDatabase);
			if (tb.Rows.Count>0) 
			{
				decimal sumsl=0;
				for (int i=0;i<=tb.Rows.Count-1;i++)
				{
					int ydwbl=Convert.ToInt32(tb.Rows[i]["Ydwbl"]);
					decimal pcsl=Convert.ToDecimal(tb.Rows[i]["盘存数量"]);
					sumsl=sumsl+pcsl*(xdwbl/ydwbl);
				}
				DataRow row;
				row=tb.NewRow()	;		
				row["序号"]="总计";
				row["盘存数量"]=Convert.ToString(sumsl.ToString("0.000"));
                row["单位"] = Yp.SeekYpdw(zxdw, InstanceForm.BDatabase);
				if (row["单位"].ToString().Trim()=="") row["单位"]=tb.Rows[0]["单位"].ToString();
				tb.Rows.Add(row);
				tb.TableName="tb";
				this.myDataGrid3.DataSource=tb;
				this.myDataGrid3.TableStyles[0].MappingName ="tb";
			}
		}
		
		//网格双击事件
		private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
//			int nrow=this.myDataGrid1.CurrentCell.RowNumber ;
//			int cjid=0;
//			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
//			if (nrow<tb.Rows.Count)
//			{
//				cjid=Convert.ToInt32(tb.Rows[nrow]["cjid"]);
//			}
//			Selectpcmx(cjid);

		}


		//提取数据
		public void Add_sum_pdcsmx()
		{
            DataTable tb = YF_PD_PDMX.Add_sum_pdcxmx_kcmx(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
			tb.TableName="tb";
			FunBase.AddRowtNo(tb);
			this.myDataGrid1.DataSource=tb;
			this.myDataGrid1.TableStyles[0].MappingName ="tb";
			this.Sumje();

		}

		//添加漏盘药品
		private void AddLpyp(long deptid)
        {
            #region
            //            string ssql = "select CAST(0 AS CHAR(12)) 序号,B.s_yppm 品名,b.s_ypspm 商品名,b.s_ypgg 规格,s_sccj 厂家," +
//                @" cast(round(b.pfj/a.dwbl,4) as decimal(15,4)) 批发价,cast(round(b.lsj/a.dwbl,4) as decimal(15,4)) 零售价,
//                null 批号,'' 库位," +
//                " kcl 库存量,dbo.fun_yp_ypdw(a.zxdw) 单位," +
//                " b.shh 货号," +
//                " a.cjid,kcid from YF_pdtemp a,yp_ypcjd b  where a.pddh=" + Convert.ToInt64(Convertor.IsNull(lbldjh.Text, "0")) + " and a.cjid=b.cjid and deptid=" + deptid +
//                " and (a.bdelete=0 or a.kcl<>0)  and kcid not in(select kcid from YF_pdcsmx_kcmx a,YF_pdcs b " +
//                " where a.deptid=b.deptid and a.djh=b.djh and bdelete=0 and a.deptid=" + deptid + " and shdjh=" + Convert.ToInt64(Convertor.IsNull(lbldjh.Text, "0")) + " ) ";
//            DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
//            FunBase.AddRowtNo(tbmx);
//            tbmx.TableName = "Tb2";
//            this.myDataGrid2.DataSource = tbmx;
            //            this.myDataGrid2.TableStyles[0].MappingName = "Tb2";
            #endregion
            string ssql = "select CAST(0 AS CHAR(12)) 序号,B.s_yppm 品名,b.s_ypspm 商品名,b.s_ypgg 规格,s_sccj 厂家," +
                @" cast(round(b.pfj/a.dwbl,4) as decimal(15,4)) 批发价,cast(round(b.lsj/a.dwbl,4) as decimal(15,4)) 零售价,
                null 批号,'' 库位," +
                " kcl 库存量,dbo.fun_yp_ypdw(a.zxdw) 单位," +
                " b.shh 货号," +
                //Modify by : jchl
                //" a.cjid,kcid from YF_pdtemp a,yp_ypcjd b  where a.pddh=" + Convert.ToInt64(Convertor.IsNull(lbldjh.Text, "0")) + " and a.cjid=b.cjid and deptid=" + deptid +
                //" and (a.bdelete=0 or a.kcl<>0)  and kcid not in(select kcid from YF_pdcsmx_kcmx a,YF_pdcs b " +
                //" where a.deptid=b.deptid and a.djh=b.djh and bdelete=0 and a.deptid=" + deptid + " and shdjh=" + Convert.ToInt64(Convertor.IsNull(lbldjh.Text, "0")) + " ) ";
                " a.cjid,kcid from yf_pdtemp_kcmx a,vi_yp_ypcd b  where a.pddh=" + Convert.ToInt64(Convertor.IsNull(lbldjh.Text, "0")) + " and a.cjid=b.cjid and deptid=" + deptid +
                " and (a.bdelete=0 or a.kcl<>0)  and not exists(select 1 from YF_pdcsmx_kcmx c,YF_pdcs b " +
                " where c.deptid=b.deptid and c.djh=b.djh and c.KCID=a.KCID and shdjh=" + Convert.ToInt64(Convertor.IsNull(lbldjh.Text, "0")) + " and bdelete=0 and c.deptid=" + deptid + " ) ";
            DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
            FunBase.AddRowtNo(tbmx);
            tbmx.TableName = "Tb2";
            this.myDataGrid2.DataSource = tbmx;
            this.myDataGrid2.TableStyles[0].MappingName = "Tb2";

        }

		#endregion
	
		#region 按钮事件

	
		//保存事件
		private void butsave_Click(object sender, System.EventArgs e)
        {
            #region 验证
            Guid PD_djid = Guid.Empty;
			long djh=0;
            string sdjh = "";
			Guid djid=Guid.Empty;
			int err_code=0;
			string err_text="";
			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			if (tb.Rows.Count==0) {MessageBox.Show("没有可保存的记录");return;}

            string Pd_shsj = "";
            string ssql = "select top 1 djsj from yf_pdtemp where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and shbz=0 ";
            DataTable tbtemp = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tbtemp.Rows.Count == 0) { MessageBox.Show("没有未审核的单据,请重新刷新数据"); return; }

            SystemCfg s = new SystemCfg(8014);
            if (s.Config == "1")
                Pd_shsj = tbtemp.Rows[0]["djsj"].ToString();
            else
                Pd_shsj = sDate;


            decimal sumsl = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(盘存数量)", ""), "0"));
            if (sumsl == 0)
            {
                Font font = new Font("黑体", 16);
                if (TrasenFrame.Forms.FrmMessageBox.Show("您没有输入任何盘存数,确定要保存吗?", font, Color.Red, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            }
            
			if(MessageBox.Show("在审核前请先检查是否有漏盘的药品,并且确保没有在办理其它业务.您确认要审核吗?","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
			{
				return;
            }
            #endregion

            this.butsave.Enabled=false;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                InstanceForm.BDatabase.BeginTransaction();

                //产生单据号
                djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToInt64(Convertor.IsNull(this.lbldjh.Text, "0"));
                sdjh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh_Str(_menuTag.FunctionTag, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToString(Convertor.IsNull(this.lblsdjh.Text, "0"));

                #region 保存单据表头
                YF_PD_PDMX.SaveDJ(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())),
                    _menuTag.FunctionTag.Trim(),
                    djh,
                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                    Convert.ToDateTime(Pd_shsj).ToShortDateString(),
                    InstanceForm.BCurrentUser.EmployeeId,
                    sDate,
                    txtbz.Text.Trim(),
                    0,
                    out djid,
                    out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

                if (err_code != 0) { throw new System.Exception(err_text); }
                #endregion
                PD_djid = djid;

                #region 保存单据明细
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    YF_PD_PDMX.SaveDJMX_KCMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"], Guid.Empty.ToString())),
                        djid,
                        Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                        Convert.ToInt32(tb.Rows[i]["cjid"]),
                        new Guid(Convertor.IsNull(tb.Rows[i]["KcID"], Guid.Empty.ToString())),
                        Convert.ToDecimal(tb.Rows[i]["盘存数量"]),
                        Convert.ToDecimal(tb.Rows[i]["帐面数量"]),
                        Convert.ToString(tb.Rows[i]["单位"]),
                        Convert.ToInt32(tb.Rows[i]["dwbl"]),
                        Convert.ToDecimal(tb.Rows[i]["批发价"]),
                        Convert.ToDecimal(tb.Rows[i]["零售价"]),
                        Convert.ToDecimal(tb.Rows[i]["批发价"]) * Convert.ToDecimal(tb.Rows[i]["盘存数量"]),
                        Convert.ToDecimal(tb.Rows[i]["批发金额"]),
                        Convert.ToDecimal(tb.Rows[i]["盘存金额"]),
                        Convert.ToDecimal(tb.Rows[i]["帐面金额"]),
                        Convert.ToInt32(tb.Rows[i]["序号"]),
                        out err_code, out err_text, InstanceForm.BDatabase);
                    if (err_code != 0) { throw new System.Exception(err_text); }
                }
                #endregion

                #region 插入YF_dj_djmx 表
                Guid _djid=Guid.Empty; //单据明细表中id
                YF_PD_PDMX.Insert_dj_djmx_kcmx(djid, InstanceForm.BDatabase,out _djid);
                if (err_code != 0) { throw new System.Exception(err_text); }
                #endregion

                #region 更新库存数
                if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == true)
                    Yk_dj_djmx.AddUpdateKcmx(_djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                else
                    YF_DJ_DJMX.AddUpdateKcmx(_djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                if (err_code != 0) { throw new System.Exception(err_text); }
                #endregion

                #region 审核单据
                if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == true)
                    Yk_dj_djmx.Shdj(_djid, Pd_shsj, InstanceForm.BDatabase);
                else
                    YF_DJ_DJMX.Shdj(_djid, Pd_shsj, InstanceForm.BDatabase);
                if (err_code != 0) { throw new System.Exception(err_text); }
                #endregion

                ssql = string.Format(" update yf_pd set zxdjid='{0}' where id='{1}'", _djid,PD_djid);
                if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
                {
                    throw new Exception("更新盘点头表执行单据id失败！");
                }

                #region 更新盘点初始表
                YF_PD_PDMX.Sh_pdtemp_kcmx(djh, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase,pcfs);
                #endregion

                //更新盘点参数状态
                //YF_PD_PDMX.UpdateConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),1);

                //提交事务
                InstanceForm.BDatabase.CommitTransaction();

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsave.Enabled = true;
                MessageBox.Show(err.Message);
                this.Cursor = Cursors.Arrow;
                return;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

			this.lbldjh.Text=djh.ToString("00000000");
            this.lblsdjh.Text = sdjh;
			this.butprint.Enabled=true;
			this.butpyd.Enabled=true;
			this.butpkd.Enabled=true;
            this.butLoadData.Enabled = false;
            this.cmbck.Enabled = false;
			MessageBox.Show(err_text);
            FillDj(PD_djid, true);

		}
	
		//退出
		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	
		private void butnext_Click(object sender, System.EventArgs e)
		{
			try
			{
				int cjid=Convert.ToInt32(Convertor.IsNull(this.txtdwcx.Tag,"0"));
				int nrow=Convert.ToInt32(Convertor.IsNull(this.butnext.Tag,"0"));
				FindRecord(cjid,nrow);
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				decimal pcjhje=0;
				decimal ykjhje=0;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (this.chkprint.Checked==true)
					{
						if ( Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面金额"],"0"))!=0 || Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存金额"],"0"))!=0)
						{
							myrow=Dset.药品盘点单.NewRow();
							myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
							if (ss.打印单据时单据显示商品名==true)
								myrow["ypmc"]=Convert.ToString(tb.Rows[i]["商品名"]);
							else
								myrow["ypmc"]=Convert.ToString(tb.Rows[i]["品名"]);
							myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
							myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
							myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
							myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"],"0"));
							myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"],"0"));
							myrow["zcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面数量"],"0"));
							myrow["zcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面金额"],"0"));
							myrow["pcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存数量"],"0"));
							myrow["pcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存金额"],"0"));
							myrow["yksl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"],"0"));
							myrow["ykje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏金额"],"0"));
							
							myrow["jhj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"));
							pcjhje=pcjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"],"0"));
							ykjhje=ykjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"))*Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"],"0"));
							
							myrow["ypph"]=Convert.ToString(tb.Rows[i]["批号"]);
							myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
							myrow["kwmc"]=Convert.ToString(tb.Rows[i]["库位"]);
							Dset.药品盘点单.Rows.Add(myrow);
						}
					}
					else
					{
							myrow=Dset.药品盘点单.NewRow();
							myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
							myrow["ypmc"]=Convert.ToString(tb.Rows[i]["品名"]);
							myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
							myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
							myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
							myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"],"0"));
							myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"],"0"));
							myrow["zcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面数量"],"0"));
							myrow["zcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面金额"],"0"));
							myrow["pcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存数量"],"0"));
							myrow["pcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存金额"],"0"));
							myrow["yksl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"],"0"));
							myrow["ykje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏金额"],"0"));
							
							myrow["jhj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"));
                            pcjhje = pcjhje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
							ykjhje=ykjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"))*Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"],"0"));

							myrow["ypph"]=Convert.ToString(tb.Rows[i]["批号"]);
							myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
							myrow["kwmc"]=Convert.ToString(tb.Rows[i]["库位"]);
							Dset.药品盘点单.Rows.Add(myrow);
					}

				}

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from yf_pd where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();

				ParameterEx[] parameters=new ParameterEx[9];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
                parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
				parameters[2].Text="RQ";
				parameters[2].Value=dtprq.Text.Trim();
				parameters[3].Text="TITLETEXT";
				parameters[3].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+this.Text;
				parameters[4].Text="BZ";
				parameters[4].Value=txtbz.Text.Trim();
				parameters[5].Text="swhere";
                parameters[5].Value = "盘点审核时间:" + dtprq.Text.Trim() + "     No." + lbldjh.Text.Trim() + "      备注:" + txtbz.Text.Trim() + "   " + lblsdjh.Text; 
				parameters[6].Text="YKJHJE";
				parameters[6].Value=Convert.ToDecimal(ykjhje.ToString("0.00"));
				parameters[7].Text="PCJHJE";
				parameters[7].Value=Convert.ToDecimal(pcjhje.ToString("0.00"));
                parameters[8].Text = "ckmc";
                parameters[8].Value = cmbck.Text.Trim();

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.药品盘点单,Constant.ApplicationDirectory+"\\Report\\YF_药品盘点单据.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();				
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}

		}


		private void butpyd_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				decimal pcjhje=0;
				decimal ykjhje=0;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (Convert.ToDecimal(tb.Rows[i]["盈亏数量"])>0)
					{
						myrow=Dset.药品盘点单.NewRow();
						myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
						if (ss.打印单据时单据显示商品名==true)
							myrow["ypmc"]=Convert.ToString(tb.Rows[i]["商品名"]);
						else
							myrow["ypmc"]=Convert.ToString(tb.Rows[i]["品名"]);
						myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
						myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
						myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
						myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"],"0"));
						myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"],"0"));
						myrow["zcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面数量"],"0"));
						myrow["zcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面金额"],"0"));
						myrow["pcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存数量"],"0"));
						myrow["pcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存金额"],"0"));
						myrow["yksl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"],"0"));
						myrow["ykje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏金额"],"0"));
						
						myrow["jhj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"));
						pcjhje=pcjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"],"0"));
						ykjhje=ykjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"))*Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"],"0"));

						myrow["ypph"]=Convert.ToString(tb.Rows[i]["批号"]);
						myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
						myrow["kwmc"]=Convert.ToString(tb.Rows[i]["库位"]);
						Dset.药品盘点单.Rows.Add(myrow);
					}

				}

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from yf_pd where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();

				ParameterEx[] parameters=new ParameterEx[9];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
                parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
				parameters[2].Text="RQ";
				parameters[2].Value=dtprq.Text.Trim();
				parameters[3].Text="TITLETEXT";
				parameters[3].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")药品盘盈单";
				parameters[4].Text="BZ";
				parameters[4].Value=txtbz.Text.Trim();
				parameters[5].Text="swhere";
                parameters[5].Value = "盘点审核时间:" + dtprq.Text.Trim() + "     No." + lbldjh.Text.Trim() + "      备注:" + txtbz.Text.Trim() + "   " + lblsdjh.Text; 
				parameters[6].Text="YKJHJE";
				parameters[6].Value=Convert.ToDecimal(ykjhje.ToString("0.00"));
				parameters[7].Text="PCJHJE";
				parameters[7].Value=Convert.ToDecimal(pcjhje.ToString("0.00"));
                parameters[8].Text = "ckmc";
                parameters[8].Value = cmbck.Text.Trim();

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.药品盘点单,Constant.ApplicationDirectory+"\\Report\\YF_药品盘点单据.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();				

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
			
		}


		private void butpkd_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				decimal pcjhje=0;
				decimal ykjhje=0;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (Convert.ToDecimal(tb.Rows[i]["盈亏数量"])<0)
					{
						myrow=Dset.药品盘点单.NewRow();
						myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
						if (ss.打印单据时单据显示商品名==true)
							myrow["ypmc"]=Convert.ToString(tb.Rows[i]["商品名"]);
						else
							myrow["ypmc"]=Convert.ToString(tb.Rows[i]["品名"]);
						myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
						myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
						myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
						myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"],"0"));
						myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"],"0"));
						myrow["zcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面数量"],"0"));
						myrow["zcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["帐面金额"],"0"));
						myrow["pcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存数量"],"0"));
						myrow["pcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盘存金额"],"0"));
						myrow["yksl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"],"0"));
						myrow["ykje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏金额"],"0"));

						myrow["jhj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"));
						pcjhje=pcjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"],"0"));
						ykjhje=ykjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"))*Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["盈亏数量"],"0"));

						myrow["ypph"]=Convert.ToString(tb.Rows[i]["批号"]);
						myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
						myrow["kwmc"]=Convert.ToString(tb.Rows[i]["库位"]);
						Dset.药品盘点单.Rows.Add(myrow);
					}

				}

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from yf_pd where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();

				ParameterEx[] parameters=new ParameterEx[9];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
                parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
				parameters[2].Text="RQ";
				parameters[2].Value=dtprq.Text.Trim();
				parameters[3].Text="TITLETEXT";
				parameters[3].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")药品盘亏单";
				parameters[4].Text="BZ";
				parameters[4].Value=txtbz.Text.Trim();
				parameters[5].Text="swhere";
                parameters[5].Value = "盘点审核时间:" + dtprq.Text.Trim() + "     No." + lbldjh.Text.Trim() + "      备注:" + txtbz.Text.Trim() + "   " + lblsdjh.Text; 
				parameters[6].Text="YKJHJE";
				parameters[6].Value=Convert.ToDecimal(ykjhje.ToString("0.00"));
				parameters[7].Text="PCJHJE";
				parameters[7].Value=Convert.ToDecimal(pcjhje.ToString("0.00"));
                parameters[8].Text = "ckmc";
                parameters[8].Value = cmbck.Text.Trim();

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.药品盘点单,Constant.ApplicationDirectory+"\\Report\\YF_药品盘点单据.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();				
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}

		}

		private void butprintlp_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				DataTable tb=(DataTable)this.myDataGrid2.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				DataRow[] rows;
				if (this.chkprintlp.Checked==true)
					rows=tb.Select("库存量<>'0'");
				else
					rows=tb.Select("");

				for(int i=0;i<=rows.Length-1;i++)
				{
					
					myrow=Dset.药品盘点单.NewRow();
					myrow["xh"]=Convert.ToInt32(rows[i]["序号"]);
					myrow["ypmc"]=Convert.ToString(rows[i]["品名"]);
					myrow["ypgg"]=Convert.ToString(rows[i]["规格"]);
					myrow["sccj"]=Convert.ToString(rows[i]["厂家"]);
					myrow["ypdw"]=Convert.ToString(rows[i]["单位"]);
					myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["批发价"],"0"));
					myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["零售价"],"0"));
					myrow["zcsl"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["库存量"],"0"));
					decimal zmje=Convert.ToDecimal(myrow["zcsl"])*Convert.ToDecimal(myrow["lsj"]);
					myrow["zcje"]=zmje.ToString("0.00");
					myrow["pcsl"]=0;
					myrow["pcje"]=0;
					myrow["yksl"]=0;
					myrow["ypph"]=Convert.ToString(rows[i]["批号"]);
					myrow["shh"]=Convert.ToString(rows[i]["货号"]);
					myrow["kwmc"]=Convert.ToString(rows[i]["库位"]);
					Dset.药品盘点单.Rows.Add(myrow);

				}
				ParameterEx[] parameters=new ParameterEx[5];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
				parameters[1].Value=InstanceForm.BCurrentUser.Name;
				parameters[2].Text="RQ";
				parameters[2].Value=dtprq.Text.Trim();
				parameters[3].Text="TITLETEXT";
				parameters[3].Value="漏盘药品表";
				parameters[4].Text="BZ";
				parameters[4].Value=txtbz.Text.Trim();

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.药品盘点单,Constant.ApplicationDirectory+"\\Report\\YF_药品盘点空表单.rpt",parameters);

				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}		
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		#endregion

        private void butLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.butLoadData.Enabled = false;
                Add_sum_pdcsmx();
                this.butLoadData.Enabled = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.butLoadData.Enabled = true;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbck.SelectedValue == null) return;
                if (cmbck.SelectedValue.ToString() == "System.Data.DataRowView") return;
                ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),InstanceForm.BDatabase);
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (tb != null) tb.Rows.Clear();

                if (ss.网络内容显示商品名 == true)
                {
                    this.myDataGrid1.TableStyles[0].GridColumnStyles["商品名"].Width = 130;
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["商品名"].Width = 140;
                }
                else
                {
                    this.myDataGrid1.TableStyles[0].GridColumnStyles["商品名"].Width = 0;
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["商品名"].Width = 0;
                }

                

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




		
	}
}
