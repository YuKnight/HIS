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

namespace ts_yk_cgrk
{
	/// <summary>
	/// Frmtitle 药品采购入库头表。
	/// </summary>
	public class Frmtitle_h : System.Windows.Forms.Form
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
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.Button butnew;
		private System.Windows.Forms.CheckBox chkshdh;
		private System.Windows.Forms.CheckBox chkdjsj;
        private System.Windows.Forms.CheckBox chkghdw;
		private System.Windows.Forms.Button butsh;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.RadioButton rdo2;
		private System.Windows.Forms.RadioButton rdo1;
		private System.Windows.Forms.Button butref;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.TextBox txtshdh;
		private System.Windows.Forms.TextBox txtfph;
		private System.Windows.Forms.TextBox txtghdw;
		private System.Windows.Forms.CheckBox chkfph;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.TextBox txtdjh;
		private System.Windows.Forms.CheckBox chkdjh;
		private Form _mdiParent;
		private MenuTag _menuTag;
        private ComboBox cmbck;
        private Label label3;
        private DataGridTextBoxColumn dataGridTextBoxColumn13;
        private Button butexcel;
        private DataGridTextBoxColumn col_付款金额;
        private Button btndel;
        private Button btnClose;
		private string _chineseName;
		
		/// <summary>
		/// 窗体构造函数
		/// </summary>
		/// <param name="menuTag">菜单对象	</param>
		/// <param name="chineseName">菜单中文名</param>
		/// <param name="mdiParent">当前窗口父对象</param>
		public Frmtitle_h(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;

            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
            Yp.AddcmbCk(true, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);

			this.Text=_chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";

		}

        public Frmtitle_h()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_付款金额 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btndel = new System.Windows.Forms.Button();
            this.butexcel = new System.Windows.Forms.Button();
            this.butsh = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.butnew = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdjh = new System.Windows.Forms.TextBox();
            this.chkdjh = new System.Windows.Forms.CheckBox();
            this.txtshdh = new System.Windows.Forms.TextBox();
            this.chkshdh = new System.Windows.Forms.CheckBox();
            this.txtfph = new System.Windows.Forms.TextBox();
            this.chkfph = new System.Windows.Forms.CheckBox();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.chkdjsj = new System.Windows.Forms.CheckBox();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.chkghdw = new System.Windows.Forms.CheckBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.butref = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid1 ) ).BeginInit();
            this.panel4.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel2 ) ).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.panel5 );
            this.panel1.Controls.Add( this.panel4 );
            this.panel1.Controls.Add( this.panel3 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 832 , 485 );
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add( this.myDataGrid1 );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point( 0 , 72 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 832 , 357 );
            this.panel5.TabIndex = 3;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point( 0 , 0 );
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size( 832 , 357 );
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange( new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1} );
            this.myDataGrid1.DoubleClick += new System.EventHandler( this.myDataGrid1_DoubleClick );
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler( this.myDataGrid1_CurrentCellChanged );
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange( new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.col_付款金额} );
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 35;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "仓库名称";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 75;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "打印";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "单据号";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 50;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "单据日期";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 60;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "供货单位";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 140;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "业务员";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 50;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "送货单号";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "进货金额";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.Width = 65;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "批发金额";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.Width = 0;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "零售金额";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.Width = 65;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "发票号";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "发票日期";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "登记时间";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 120;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "登记员";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 50;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "审核时间";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 120;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "审核员";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 50;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "备注";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 60;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "id";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // col_付款金额
            // 
            this.col_付款金额.Format = "";
            this.col_付款金额.FormatInfo = null;
            this.col_付款金额.HeaderText = "付款金额";
            this.col_付款金额.MappingName = "付款金额";
            this.col_付款金额.Width = 75;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.btnClose );
            this.panel4.Controls.Add( this.btndel );
            this.panel4.Controls.Add( this.butexcel );
            this.panel4.Controls.Add( this.butsh );
            this.panel4.Controls.Add( this.statusBar1 );
            this.panel4.Controls.Add( this.butnew );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point( 0 , 429 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 832 , 56 );
            this.panel4.TabIndex = 2;
            // 
            // btndel
            // 
            this.btndel.Location = new System.Drawing.Point( 4 , 6 );
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size( 88 , 24 );
            this.btndel.TabIndex = 7;
            this.btndel.Text = "删除(&D)";
            this.btndel.Click += new System.EventHandler( this.btndel_Click );
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point( 232 , 6 );
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size( 104 , 24 );
            this.butexcel.TabIndex = 6;
            this.butexcel.Text = "导出(&E)";
            this.butexcel.Click += new System.EventHandler( this.butexcel_Click );
            // 
            // butsh
            // 
            this.butsh.Location = new System.Drawing.Point( 526 , 6 );
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size( 88 , 24 );
            this.butsh.TabIndex = 2;
            this.butsh.Text = "查看(&H)";
            this.butsh.Click += new System.EventHandler( this.butsh_Click );
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point( 0 , 32 );
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange( new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2} );
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size( 832 , 24 );
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
            this.butnew.Location = new System.Drawing.Point( 434 , 6 );
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size( 88 , 24 );
            this.butnew.TabIndex = 0;
            this.butnew.Text = "新单据(&N)";
            this.butnew.Click += new System.EventHandler( this.butnew_Click );
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.panel2 );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0 , 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 832 , 72 );
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add( this.cmbck );
            this.panel2.Controls.Add( this.label3 );
            this.panel2.Controls.Add( this.txtdjh );
            this.panel2.Controls.Add( this.chkdjh );
            this.panel2.Controls.Add( this.txtshdh );
            this.panel2.Controls.Add( this.chkshdh );
            this.panel2.Controls.Add( this.txtfph );
            this.panel2.Controls.Add( this.chkfph );
            this.panel2.Controls.Add( this.dtp2 );
            this.panel2.Controls.Add( this.label1 );
            this.panel2.Controls.Add( this.dtp1 );
            this.panel2.Controls.Add( this.chkdjsj );
            this.panel2.Controls.Add( this.txtghdw );
            this.panel2.Controls.Add( this.chkghdw );
            this.panel2.Controls.Add( this.rdo2 );
            this.panel2.Controls.Add( this.rdo1 );
            this.panel2.Controls.Add( this.butref );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0 , 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 832 , 72 );
            this.panel2.TabIndex = 2;
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cmbck.Location = new System.Drawing.Point( 144 , 8 );
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size( 112 , 20 );
            this.cmbck.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 91 , 13 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 56 , 16 );
            this.label3.TabIndex = 19;
            this.label3.Text = "仓库名称";
            // 
            // txtdjh
            // 
            this.txtdjh.Enabled = false;
            this.txtdjh.Location = new System.Drawing.Point( 328 , 40 );
            this.txtdjh.Name = "txtdjh";
            this.txtdjh.Size = new System.Drawing.Size( 72 , 21 );
            this.txtdjh.TabIndex = 15;
            // 
            // chkdjh
            // 
            this.chkdjh.Location = new System.Drawing.Point( 272 , 40 );
            this.chkdjh.Name = "chkdjh";
            this.chkdjh.Size = new System.Drawing.Size( 64 , 22 );
            this.chkdjh.TabIndex = 16;
            this.chkdjh.Text = "单据号";
            this.chkdjh.CheckedChanged += new System.EventHandler( this.chk_CheckedChanged );
            // 
            // txtshdh
            // 
            this.txtshdh.Enabled = false;
            this.txtshdh.Location = new System.Drawing.Point( 168 , 40 );
            this.txtshdh.Name = "txtshdh";
            this.txtshdh.Size = new System.Drawing.Size( 88 , 21 );
            this.txtshdh.TabIndex = 2;
            // 
            // chkshdh
            // 
            this.chkshdh.Location = new System.Drawing.Point( 96 , 39 );
            this.chkshdh.Name = "chkshdh";
            this.chkshdh.Size = new System.Drawing.Size( 120 , 22 );
            this.chkshdh.TabIndex = 14;
            this.chkshdh.Text = "送货单号";
            this.chkshdh.CheckedChanged += new System.EventHandler( this.chk_CheckedChanged );
            // 
            // txtfph
            // 
            this.txtfph.Enabled = false;
            this.txtfph.Location = new System.Drawing.Point( 592 , 8 );
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size( 120 , 21 );
            this.txtfph.TabIndex = 1;
            // 
            // chkfph
            // 
            this.chkfph.Location = new System.Drawing.Point( 536 , 8 );
            this.chkfph.Name = "chkfph";
            this.chkfph.Size = new System.Drawing.Size( 64 , 22 );
            this.chkfph.TabIndex = 12;
            this.chkfph.Text = "发票号";
            this.chkfph.CheckedChanged += new System.EventHandler( this.chk_CheckedChanged );
            // 
            // dtp2
            // 
            this.dtp2.Enabled = false;
            this.dtp2.Location = new System.Drawing.Point( 608 , 40 );
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size( 110 , 21 );
            this.dtp2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 592 , 45 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 24 , 16 );
            this.label1.TabIndex = 10;
            this.label1.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Enabled = false;
            this.dtp1.Location = new System.Drawing.Point( 480 , 40 );
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size( 111 , 21 );
            this.dtp1.TabIndex = 3;
            // 
            // chkdjsj
            // 
            this.chkdjsj.Location = new System.Drawing.Point( 408 , 40 );
            this.chkdjsj.Name = "chkdjsj";
            this.chkdjsj.Size = new System.Drawing.Size( 80 , 22 );
            this.chkdjsj.TabIndex = 8;
            this.chkdjsj.Text = "登记时间";
            this.chkdjsj.CheckedChanged += new System.EventHandler( this.chk_CheckedChanged );
            // 
            // txtghdw
            // 
            this.txtghdw.Enabled = false;
            this.txtghdw.Location = new System.Drawing.Point( 344 , 8 );
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size( 184 , 21 );
            this.txtghdw.TabIndex = 0;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler( this.TextKeyUp );
            // 
            // chkghdw
            // 
            this.chkghdw.Location = new System.Drawing.Point( 272 , 8 );
            this.chkghdw.Name = "chkghdw";
            this.chkghdw.Size = new System.Drawing.Size( 88 , 22 );
            this.chkghdw.TabIndex = 2;
            this.chkghdw.Text = "供货单位";
            this.chkghdw.CheckedChanged += new System.EventHandler( this.chk_CheckedChanged );
            // 
            // rdo2
            // 
            this.rdo2.Location = new System.Drawing.Point( 16 , 32 );
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size( 72 , 22 );
            this.rdo2.TabIndex = 1;
            this.rdo2.Text = "已审核";
            this.rdo2.Click += new System.EventHandler( this.rdo2_CheckedChanged );
            // 
            // rdo1
            // 
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point( 16 , 8 );
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size( 64 , 22 );
            this.rdo1.TabIndex = 0;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "未审核";
            this.rdo1.Click += new System.EventHandler( this.rdo2_CheckedChanged );
            this.rdo1.CheckedChanged += new System.EventHandler( this.rdo1_CheckedChanged );
            // 
            // butref
            // 
            this.butref.Location = new System.Drawing.Point( 728 , 32 );
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size( 88 , 29 );
            this.butref.TabIndex = 4;
            this.butref.Text = "刷新(&R)";
            this.butref.Click += new System.EventHandler( this.butref_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 620 , 6 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 81 , 24 );
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&Q)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.butclose_Click );
            // 
            // Frmtitle_h
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.ClientSize = new System.Drawing.Size( 832 , 485 );
            this.Controls.Add( this.panel1 );
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "Frmtitle_h";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "药品入库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.Frmtitle_Load );
            this.Activated += new System.EventHandler( this.Frmtitle_Activated );
            this.panel1.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid1 ) ).EndInit();
            this.panel4.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel2 ) ).EndInit();
            this.panel3.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout();
            this.ResumeLayout( false );

		}
		#endregion

		/// <summary>
		/// 新单据按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void butnew_Click(object sender, System.EventArgs e)
		{
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            Frmyprk_h f = new Frmyprk_h(_menuTag, _chineseName, _mdiParent, tb);
            f.Show();
		}

	
		/// <summary>
		/// CHK控件值改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chk_CheckedChanged(object sender, System.EventArgs e)
		{
			this.txtghdw.Enabled=chkghdw.Checked==true?true:false;
			this.txtshdh.Enabled=chkshdh.Checked==true?true:false;
			this.txtfph.Enabled=chkfph.Checked==true?true:false;
			this.dtp1.Enabled=chkdjsj.Checked==true?true:false;
			this.dtp2.Enabled=chkdjsj.Checked==true?true:false;
			this.txtdjh.Enabled=chkdjh.Checked==true?true:false;
		}

	
		/// <summary>
		/// 窗体LOAD事件,初始化日期，和网格
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Frmtitle_Load(object sender, System.EventArgs e)
		{
			this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			
			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");
            Yp.AddcmbCk(true, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);

            if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_h")
            {
                //butnew.Enabled = false;
                butsh.Enabled = false;
            }

            #region
            //if ((_menuTag.Function_Name == "Fun_ts_yk_cgrk_yf" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_yf_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf_cx") && YpConfig.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == true)
            //{
            //    butnew.Enabled = false;
            //    butsh.Enabled = false;
            //}

            //if ((_menuTag.Function_Name == "Fun_ts_yk_cgrk" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_cx") && YpConfig.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == false)
            //{
            //    butnew.Enabled = false;
            //    butsh.Enabled = false;
            //}

            //if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_yf_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf_cx"
            //     || _menuTag.Function_Name == "Fun_ts_yk_cgrk_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_cx")
            //{
            //    butnew.Visible = false;
            //}
            #endregion

            YpConfig ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
            if (ss.采购入库单显示批发价和批发金额 == true)
            {
                dataGridTextBoxColumn19.Width = 60;
            }

		}

	
		/// <summary>
		/// 刷新按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void butref_Click(object sender, System.EventArgs e)
		{
			if (chkghdw.Checked==false && chkfph.Checked==false && chkshdh.Checked==false && chkdjsj.Checked==false && rdo2.Checked==true)
			{MessageBox.Show("查询的记录范围太大，请重新选择查询条件");return;}
			if (txtghdw.Text.Trim()=="" && txtghdw.Enabled==true){MessageBox.Show("请输入供货单位");return;}
			if (txtfph.Text.Trim()=="" && txtfph.Enabled==true){MessageBox.Show("请输入发票号");return;}
			if (txtshdh.Text.Trim()=="" && txtshdh.Enabled==true){MessageBox.Show("请输入送货单号");return;}

			try
			{
				ParameterEx[] parameters=new ParameterEx[11];
				parameters[0].Text="@ywlx";
				parameters[0].Value=_menuTag.FunctionTag.Trim();
				parameters[1].Text="@wldw";
				parameters[1].Value=this.chkghdw.Checked==true?Convert.ToInt32(this.txtghdw.Tag):0;
				parameters[2].Text="@dtp1";
				parameters[2].Value=chkdjsj.Checked==true?dtp1.Value.ToShortDateString():"";
				parameters[3].Text="@dtp2";
				parameters[3].Value=chkdjsj.Checked==true?dtp2.Value.ToShortDateString():"";
				parameters[4].Text="@djh";
				parameters[4].Value=chkdjh.Checked==true?Convert.ToInt64(Convertor.IsNull(txtdjh.Text,"0")):0;
				parameters[5].Text="@fph";
				parameters[5].Value=this.chkfph.Checked==true?txtfph.Text.Trim():"";
				parameters[6].Text="@shdh";
				parameters[6].Value=this.chkshdh.Checked==true?txtshdh.Text.Trim():"";
				parameters[7].Text="@shbz";
				parameters[7].Value=this.rdo1.Checked==true?0:1;
				parameters[8].Text="@deptid";
				parameters[8].Value=Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue,"0"));
				parameters[9].Text="@functionname";
				parameters[9].Value=_menuTag.Function_Name;
                parameters[10].Text = "@p_deptid";
                parameters[10].Value = InstanceForm.BCurrentDept.DeptId;

				string _proName="";
                if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_h" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th_h")
                    _proName = "sp_yk_selectDj";
                else
                {
                    MessageBox.Show("必须是药库！");
                }
				DataTable tb=InstanceForm.BDatabase.GetDataTable(_proName,parameters,30);

				tb.TableName="Tb";
				FunBase.AddRowtNo(tb);
				this.myDataGrid1.DataSource=tb;
				FunBase.myGridSelect(this.myDataGrid1,this.myDataGrid1.TableStyles[0].GridColumnStyles);

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}

	
		/// <summary>
		/// 退出事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
		/// <summary>
		/// 审核与未审核选项改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rdo2_CheckedChanged(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
			if (this.rdo1.Checked==true)
			{
				this.dataGridTableStyle1.ForeColor=System.Drawing.Color.Black ;
				this.chkdjsj.Checked=false;
				this.butref_Click(sender,e);
                btndel.Enabled = true;
			}
			else
			{
				this.dataGridTableStyle1.ForeColor=System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
				this.chkdjsj.Checked=true;
				this.butref_Click(sender,e);
                btndel.Enabled = false;
			}
		}

		
		/// <summary>
		/// 窗体重新获得焦点事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Frmtitle_Activated(object sender, System.EventArgs e)
		{
			if (rdo1.Checked==true)
			{
				this.butref_Click(sender,e);
			}
		}

		

		/// <summary>
		/// 弹出输入框，用于输入供货商
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" )
			{
				control.Text="";control.Tag="0";}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)==""))) {} 
			else {return;}

			try
			{
				Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
				switch(control.TabIndex)
				{
					case 0:
						if (nkey==13 && (control.Tag.ToString()!="" && control.Tag.ToString()!="0")) return;
                        Yp.frmShowCard(sender, ShowCardType.供货单位, 0, point, 0, InstanceForm.BDatabase);
						if (Convertor.IsNull(control.Tag,"0")!="0") this.SelectNextControl((Control)sender,true,false,true,true);
						break;
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}

		/// <summary>
		/// 网格单元格改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);

		}

		
		/// <summary>
		/// 网格双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			butsh_Click(e,e);
		}

		/// <summary>
		///查看按钮事件 用于查看单据明细
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void butsh_Click(object sender, System.EventArgs e)
		{
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow > tb.Rows.Count - 1) return;
                Frmyprk_h f = new Frmyprk_h(_menuTag, _chineseName, _mdiParent, tb);
                f.Show();
                f.FillDj(new Guid(tb.Rows[nrow]["id"].ToString()), this.rdo2.Checked);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
		}

		private void rdo1_CheckedChanged(object sender, System.EventArgs e)
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
                xlApp.ActiveCell.FormulaR1C1 = _chineseName +"一览表";
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

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除？", "删除单据", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow > tb.Rows.Count - 1) return;
                Guid djid = new Guid(tb.Rows[nrow]["id"].ToString());
                string ssql = string.Format(" delete yk_dj_temp where id='{0}'",djid);
                if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
                {
                    MessageBox.Show("删除单据失败！请刷新数据后重试！");
                    return;
                }
                ssql = string.Format(" delete yk_djmx_temp where djid='{0}'",djid);
                InstanceForm.BDatabase.DoCommand(ssql);
                butref_Click(0, e);
                MessageBox.Show("删除成功！");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

	}
}
