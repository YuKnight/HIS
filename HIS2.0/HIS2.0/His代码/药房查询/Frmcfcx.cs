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
	/// Frmcfcx 的摘要说明。
	/// </summary>
	public class Frmcfcx : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private PatientInfo.PatientInfo patientInfo1;
		private System.Windows.Forms.Splitter splitter1;
		private myDataGrid.myDataGrid myDataGrid1;
		private myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.ComboBox cmbuser;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butcx;
		private System.Windows.Forms.Button butquit1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.RadioButton rdofyrq;
		private System.Windows.Forms.RadioButton rdosfrq;
		private System.Windows.Forms.CheckBox chkuser;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txthzxm;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rdocfrq;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.ComboBox cmbyblx;
		private System.Windows.Forms.CheckBox chkyblx;
		private System.Windows.Forms.RadioButton rdowsfcf;
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
		private System.Data.OleDb.OleDbConnection MZ;
		private System.Windows.Forms.CheckBox chkbk;
		private System.Windows.Forms.CheckBox chkbk1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmcfcx(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;

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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.butquit1 = new System.Windows.Forms.Button();
			this.patientInfo1 = new PatientInfo.PatientInfo();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.rdowsfcf = new System.Windows.Forms.RadioButton();
			this.cmbyblx = new System.Windows.Forms.ComboBox();
			this.chkyblx = new System.Windows.Forms.CheckBox();
			this.butprint = new System.Windows.Forms.Button();
			this.rdocfrq = new System.Windows.Forms.RadioButton();
			this.txthzxm = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.rdofyrq = new System.Windows.Forms.RadioButton();
			this.rdosfrq = new System.Windows.Forms.RadioButton();
			this.butquit = new System.Windows.Forms.Button();
			this.butcx = new System.Windows.Forms.Button();
			this.cmbuser = new System.Windows.Forms.ComboBox();
			this.chkuser = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dtp2 = new System.Windows.Forms.DateTimePicker();
			this.dtp1 = new System.Windows.Forms.DateTimePicker();
			this.myDataGrid2 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn45 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn46 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn47 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.myDataGrid1 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridBoolColumn2 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.chkbk = new System.Windows.Forms.CheckBox();
			this.chkbk1 = new System.Windows.Forms.CheckBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(864, 104);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage1.Controls.Add(this.chkbk);
			this.tabPage1.Controls.Add(this.butquit1);
			this.tabPage1.Controls.Add(this.patientInfo1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(856, 79);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "按病人查询";
			// 
			// butquit1
			// 
			this.butquit1.Location = new System.Drawing.Point(355, 0);
			this.butquit1.Name = "butquit1";
			this.butquit1.Size = new System.Drawing.Size(80, 24);
			this.butquit1.TabIndex = 9;
			this.butquit1.Text = "退出";
			this.butquit1.Click += new System.EventHandler(this.butquit1_Click);
			// 
			// patientInfo1
			// 
			this.patientInfo1.AgeToolTip = "";
			this.patientInfo1.AnimalHeatVisible = false;
			this.patientInfo1.AvoirdupoisVisible = false;
			this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
			this.patientInfo1.CaseIDVisible = false;
			this.patientInfo1.CurrentDept = null;
			this.patientInfo1.CurrentUser = null;
			this.patientInfo1.DiagnoseEnabled = false;
			this.patientInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.patientInfo1.FeeTypeEnabled = false;
			this.patientInfo1.FilterPatientByDate = false;
			this.patientInfo1.ICIDVisible = false;
			this.patientInfo1.InvoiceIDVisible = false;
			this.patientInfo1.InvoiceSerialIDVisible = false;
			this.patientInfo1.LgbzVisible = false;
			this.patientInfo1.Location = new System.Drawing.Point(0, 0);
			this.patientInfo1.MagcardIDVisible = false;
			this.patientInfo1.Name = "patientInfo1";
			this.patientInfo1.NameSexEnabled = true;
			this.patientInfo1.NeedInputPrescDocDept = false;
			this.patientInfo1.PatientDiagnose = "";
			this.patientInfo1.PatientDiagnoseCode = "";
			this.patientInfo1.RegisterIDVisible = false;
			this.patientInfo1.SearchHistoryRecord = false;
			this.patientInfo1.SearchIDType = PatientInfo.IDType.InvoiceID;
			this.patientInfo1.Size = new System.Drawing.Size(854, 77);
			this.patientInfo1.TabIndex = 0;
			this.patientInfo1.IDTextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.patientInfo1_IDTextBoxKeyPress);
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage2.Controls.Add(this.chkbk1);
			this.tabPage2.Controls.Add(this.rdowsfcf);
			this.tabPage2.Controls.Add(this.cmbyblx);
			this.tabPage2.Controls.Add(this.chkyblx);
			this.tabPage2.Controls.Add(this.butprint);
			this.tabPage2.Controls.Add(this.rdocfrq);
			this.tabPage2.Controls.Add(this.txthzxm);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.rdofyrq);
			this.tabPage2.Controls.Add(this.rdosfrq);
			this.tabPage2.Controls.Add(this.butquit);
			this.tabPage2.Controls.Add(this.butcx);
			this.tabPage2.Controls.Add(this.cmbuser);
			this.tabPage2.Controls.Add(this.chkuser);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.dtp2);
			this.tabPage2.Controls.Add(this.dtp1);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(856, 79);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "其它条件查询";
			// 
			// rdowsfcf
			// 
			this.rdowsfcf.Checked = true;
			this.rdowsfcf.Location = new System.Drawing.Point(267, 11);
			this.rdowsfcf.Name = "rdowsfcf";
			this.rdowsfcf.Size = new System.Drawing.Size(93, 24);
			this.rdowsfcf.TabIndex = 17;
			this.rdowsfcf.TabStop = true;
			this.rdowsfcf.Text = "未收费处方";
			this.rdowsfcf.CheckedChanged += new System.EventHandler(this.rdofyrq_CheckedChanged);
			// 
			// cmbyblx
			// 
			this.cmbyblx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbyblx.Enabled = false;
			this.cmbyblx.Location = new System.Drawing.Point(704, 40);
			this.cmbyblx.Name = "cmbyblx";
			this.cmbyblx.Size = new System.Drawing.Size(112, 20);
			this.cmbyblx.TabIndex = 16;
			// 
			// chkyblx
			// 
			this.chkyblx.Location = new System.Drawing.Point(632, 40);
			this.chkyblx.Name = "chkyblx";
			this.chkyblx.Size = new System.Drawing.Size(112, 24);
			this.chkyblx.TabIndex = 15;
			this.chkyblx.Text = "医保类型";
			this.chkyblx.CheckedChanged += new System.EventHandler(this.chkuser_CheckedChanged);
			// 
			// butprint
			// 
			this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butprint.ForeColor = System.Drawing.Color.Navy;
			this.butprint.Location = new System.Drawing.Point(600, 4);
			this.butprint.Name = "butprint";
			this.butprint.Size = new System.Drawing.Size(80, 24);
			this.butprint.TabIndex = 14;
			this.butprint.Text = "打印(&P)";
			this.butprint.Click += new System.EventHandler(this.butprint_Click);
			// 
			// rdocfrq
			// 
			this.rdocfrq.Checked = true;
			this.rdocfrq.Location = new System.Drawing.Point(177, 11);
			this.rdocfrq.Name = "rdocfrq";
			this.rdocfrq.Size = new System.Drawing.Size(72, 24);
			this.rdocfrq.TabIndex = 13;
			this.rdocfrq.TabStop = true;
			this.rdocfrq.Text = "开方日期";
			this.rdocfrq.Click += new System.EventHandler(this.rdofyrq_CheckedChanged);
			// 
			// txthzxm
			// 
			this.txthzxm.Location = new System.Drawing.Point(522, 39);
			this.txthzxm.Name = "txthzxm";
			this.txthzxm.Size = new System.Drawing.Size(64, 21);
			this.txthzxm.TabIndex = 12;
			this.txthzxm.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(464, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "患者姓名";
			// 
			// rdofyrq
			// 
			this.rdofyrq.Location = new System.Drawing.Point(8, 12);
			this.rdofyrq.Name = "rdofyrq";
			this.rdofyrq.Size = new System.Drawing.Size(72, 24);
			this.rdofyrq.TabIndex = 10;
			this.rdofyrq.Text = "发药日期";
			this.rdofyrq.CheckedChanged += new System.EventHandler(this.rdofyrq_CheckedChanged);
			// 
			// rdosfrq
			// 
			this.rdosfrq.Location = new System.Drawing.Point(90, 12);
			this.rdosfrq.Name = "rdosfrq";
			this.rdosfrq.Size = new System.Drawing.Size(72, 24);
			this.rdosfrq.TabIndex = 9;
			this.rdosfrq.Text = "收费日期";
			this.rdosfrq.CheckedChanged += new System.EventHandler(this.rdofyrq_CheckedChanged);
			// 
			// butquit
			// 
			this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butquit.ForeColor = System.Drawing.Color.Navy;
			this.butquit.Location = new System.Drawing.Point(688, 4);
			this.butquit.Name = "butquit";
			this.butquit.Size = new System.Drawing.Size(80, 24);
			this.butquit.TabIndex = 8;
			this.butquit.Text = "退出";
			this.butquit.Click += new System.EventHandler(this.butquit_Click);
			// 
			// butcx
			// 
			this.butcx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butcx.ForeColor = System.Drawing.Color.Navy;
			this.butcx.Location = new System.Drawing.Point(512, 4);
			this.butcx.Name = "butcx";
			this.butcx.Size = new System.Drawing.Size(80, 24);
			this.butcx.TabIndex = 7;
			this.butcx.Text = "查询";
			this.butcx.Click += new System.EventHandler(this.butcx_Click);
			// 
			// cmbuser
			// 
			this.cmbuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbuser.Enabled = false;
			this.cmbuser.Location = new System.Drawing.Point(344, 40);
			this.cmbuser.Name = "cmbuser";
			this.cmbuser.Size = new System.Drawing.Size(112, 20);
			this.cmbuser.TabIndex = 6;
			// 
			// chkuser
			// 
			this.chkuser.Location = new System.Drawing.Point(288, 40);
			this.chkuser.Name = "chkuser";
			this.chkuser.Size = new System.Drawing.Size(112, 24);
			this.chkuser.TabIndex = 5;
			this.chkuser.Text = "划价员";
			this.chkuser.CheckedChanged += new System.EventHandler(this.chkuser_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(152, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "到";
			// 
			// dtp2
			// 
			this.dtp2.Location = new System.Drawing.Point(168, 40);
			this.dtp2.Name = "dtp2";
			this.dtp2.Size = new System.Drawing.Size(112, 21);
			this.dtp2.TabIndex = 3;
			// 
			// dtp1
			// 
			this.dtp1.Location = new System.Drawing.Point(40, 40);
			this.dtp1.Name = "dtp1";
			this.dtp1.Size = new System.Drawing.Size(112, 21);
			this.dtp1.TabIndex = 2;
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.myDataGrid2.CaptionForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.myDataGrid2.CaptionText = "处方明细";
			this.myDataGrid2.CaptionVisible = false;
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.myDataGrid2.HeaderBackColor = System.Drawing.Color.Silver;
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 365);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.Size = new System.Drawing.Size(864, 168);
			this.myDataGrid2.TabIndex = 0;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn19,
																												  this.dataGridTextBoxColumn20,
																												  this.dataGridTextBoxColumn21,
																												  this.dataGridTextBoxColumn22,
																												  this.dataGridTextBoxColumn23,
																												  this.dataGridTextBoxColumn25,
																												  this.dataGridTextBoxColumn26,
																												  this.dataGridTextBoxColumn27,
																												  this.dataGridTextBoxColumn28,
																												  this.dataGridTextBoxColumn29,
																												  this.dataGridTextBoxColumn24,
																												  this.dataGridTextBoxColumn39,
																												  this.dataGridTextBoxColumn40,
																												  this.dataGridTextBoxColumn43,
																												  this.dataGridTextBoxColumn41,
																												  this.dataGridTextBoxColumn42,
																												  this.dataGridTextBoxColumn44,
																												  this.dataGridTextBoxColumn45,
																												  this.dataGridTextBoxColumn46,
																												  this.dataGridTextBoxColumn47});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "";
			this.dataGridTableStyle2.ReadOnly = true;
			this.dataGridTableStyle2.RowHeadersVisible = false;
			// 
			// dataGridTextBoxColumn19
			// 
			this.dataGridTextBoxColumn19.Format = "";
			this.dataGridTextBoxColumn19.FormatInfo = null;
			this.dataGridTextBoxColumn19.HeaderText = "序号";
			this.dataGridTextBoxColumn19.MappingName = "";
			this.dataGridTextBoxColumn19.NullText = "";
			this.dataGridTextBoxColumn19.Width = 40;
			// 
			// dataGridTextBoxColumn20
			// 
			this.dataGridTextBoxColumn20.Format = "";
			this.dataGridTextBoxColumn20.FormatInfo = null;
			this.dataGridTextBoxColumn20.HeaderText = "发票号";
			this.dataGridTextBoxColumn20.MappingName = "";
			this.dataGridTextBoxColumn20.NullText = "";
			this.dataGridTextBoxColumn20.Width = 65;
			// 
			// dataGridTextBoxColumn21
			// 
			this.dataGridTextBoxColumn21.Format = "";
			this.dataGridTextBoxColumn21.FormatInfo = null;
			this.dataGridTextBoxColumn21.HeaderText = "药品名称";
			this.dataGridTextBoxColumn21.MappingName = "";
			this.dataGridTextBoxColumn21.NullText = "";
			this.dataGridTextBoxColumn21.Width = 140;
			// 
			// dataGridTextBoxColumn22
			// 
			this.dataGridTextBoxColumn22.Format = "";
			this.dataGridTextBoxColumn22.FormatInfo = null;
			this.dataGridTextBoxColumn22.HeaderText = "规格";
			this.dataGridTextBoxColumn22.MappingName = "";
			this.dataGridTextBoxColumn22.NullText = "";
			this.dataGridTextBoxColumn22.Width = 90;
			// 
			// dataGridTextBoxColumn23
			// 
			this.dataGridTextBoxColumn23.Format = "";
			this.dataGridTextBoxColumn23.FormatInfo = null;
			this.dataGridTextBoxColumn23.HeaderText = "厂家";
			this.dataGridTextBoxColumn23.MappingName = "";
			this.dataGridTextBoxColumn23.NullText = "";
			this.dataGridTextBoxColumn23.Width = 75;
			// 
			// dataGridTextBoxColumn25
			// 
			this.dataGridTextBoxColumn25.Format = "";
			this.dataGridTextBoxColumn25.FormatInfo = null;
			this.dataGridTextBoxColumn25.HeaderText = "零售价";
			this.dataGridTextBoxColumn25.MappingName = "";
			this.dataGridTextBoxColumn25.NullText = "";
			this.dataGridTextBoxColumn25.Width = 65;
			// 
			// dataGridTextBoxColumn26
			// 
			this.dataGridTextBoxColumn26.Format = "";
			this.dataGridTextBoxColumn26.FormatInfo = null;
			this.dataGridTextBoxColumn26.HeaderText = "用量";
			this.dataGridTextBoxColumn26.MappingName = "";
			this.dataGridTextBoxColumn26.NullText = "";
			this.dataGridTextBoxColumn26.Width = 60;
			// 
			// dataGridTextBoxColumn27
			// 
			this.dataGridTextBoxColumn27.Format = "";
			this.dataGridTextBoxColumn27.FormatInfo = null;
			this.dataGridTextBoxColumn27.HeaderText = "单位";
			this.dataGridTextBoxColumn27.MappingName = "";
			this.dataGridTextBoxColumn27.NullText = "";
			this.dataGridTextBoxColumn27.Width = 40;
			// 
			// dataGridTextBoxColumn28
			// 
			this.dataGridTextBoxColumn28.Format = "";
			this.dataGridTextBoxColumn28.FormatInfo = null;
			this.dataGridTextBoxColumn28.HeaderText = "剂数";
			this.dataGridTextBoxColumn28.MappingName = "";
			this.dataGridTextBoxColumn28.NullText = "";
			this.dataGridTextBoxColumn28.Width = 40;
			// 
			// dataGridTextBoxColumn29
			// 
			this.dataGridTextBoxColumn29.Format = "";
			this.dataGridTextBoxColumn29.FormatInfo = null;
			this.dataGridTextBoxColumn29.HeaderText = "金额";
			this.dataGridTextBoxColumn29.MappingName = "";
			this.dataGridTextBoxColumn29.NullText = "";
			this.dataGridTextBoxColumn29.Width = 70;
			// 
			// dataGridTextBoxColumn24
			// 
			this.dataGridTextBoxColumn24.Format = "";
			this.dataGridTextBoxColumn24.FormatInfo = null;
			this.dataGridTextBoxColumn24.HeaderText = "货号";
			this.dataGridTextBoxColumn24.MappingName = "";
			this.dataGridTextBoxColumn24.NullText = "";
			this.dataGridTextBoxColumn24.Width = 65;
			// 
			// dataGridTextBoxColumn39
			// 
			this.dataGridTextBoxColumn39.Format = "";
			this.dataGridTextBoxColumn39.FormatInfo = null;
			this.dataGridTextBoxColumn39.HeaderText = "用法";
			this.dataGridTextBoxColumn39.MappingName = "";
			this.dataGridTextBoxColumn39.Width = 60;
			// 
			// dataGridTextBoxColumn40
			// 
			this.dataGridTextBoxColumn40.Format = "";
			this.dataGridTextBoxColumn40.FormatInfo = null;
			this.dataGridTextBoxColumn40.HeaderText = "频次";
			this.dataGridTextBoxColumn40.MappingName = "";
			this.dataGridTextBoxColumn40.Width = 50;
			// 
			// dataGridTextBoxColumn43
			// 
			this.dataGridTextBoxColumn43.Format = "";
			this.dataGridTextBoxColumn43.FormatInfo = null;
			this.dataGridTextBoxColumn43.HeaderText = "天数";
			this.dataGridTextBoxColumn43.MappingName = "";
			this.dataGridTextBoxColumn43.Width = 50;
			// 
			// dataGridTextBoxColumn41
			// 
			this.dataGridTextBoxColumn41.Format = "";
			this.dataGridTextBoxColumn41.FormatInfo = null;
			this.dataGridTextBoxColumn41.HeaderText = "皮试";
			this.dataGridTextBoxColumn41.MappingName = "";
			this.dataGridTextBoxColumn41.Width = 50;
			// 
			// dataGridTextBoxColumn42
			// 
			this.dataGridTextBoxColumn42.Format = "";
			this.dataGridTextBoxColumn42.FormatInfo = null;
			this.dataGridTextBoxColumn42.HeaderText = "嘱托";
			this.dataGridTextBoxColumn42.MappingName = "";
			this.dataGridTextBoxColumn42.Width = 75;
			// 
			// dataGridTextBoxColumn44
			// 
			this.dataGridTextBoxColumn44.Format = "";
			this.dataGridTextBoxColumn44.FormatInfo = null;
			this.dataGridTextBoxColumn44.HeaderText = "剂量";
			this.dataGridTextBoxColumn44.MappingName = "";
			this.dataGridTextBoxColumn44.Width = 0;
			// 
			// dataGridTextBoxColumn45
			// 
			this.dataGridTextBoxColumn45.Format = "";
			this.dataGridTextBoxColumn45.FormatInfo = null;
			this.dataGridTextBoxColumn45.HeaderText = "剂量单位";
			this.dataGridTextBoxColumn45.MappingName = "";
			this.dataGridTextBoxColumn45.Width = 0;
			// 
			// dataGridTextBoxColumn46
			// 
			this.dataGridTextBoxColumn46.Format = "";
			this.dataGridTextBoxColumn46.FormatInfo = null;
			this.dataGridTextBoxColumn46.HeaderText = "pcdm";
			this.dataGridTextBoxColumn46.MappingName = "";
			this.dataGridTextBoxColumn46.Width = 0;
			// 
			// dataGridTextBoxColumn47
			// 
			this.dataGridTextBoxColumn47.Format = "";
			this.dataGridTextBoxColumn47.FormatInfo = null;
			this.dataGridTextBoxColumn47.HeaderText = "使用频次";
			this.dataGridTextBoxColumn47.MappingName = "";
			this.dataGridTextBoxColumn47.Width = 75;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 362);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(864, 3);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.myDataGrid1.CaptionText = "处方标头";
			this.myDataGrid1.CaptionVisible = false;
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.Size = new System.Drawing.Size(864, 258);
			this.myDataGrid1.TabIndex = 0;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.myDataGrid1_Navigate);
			this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridBoolColumn1,
																												  this.dataGridBoolColumn2,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn33,
																												  this.dataGridTextBoxColumn36,
																												  this.dataGridTextBoxColumn37,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn34,
																												  this.dataGridTextBoxColumn35,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn30,
																												  this.dataGridTextBoxColumn32,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn15,
																												  this.dataGridTextBoxColumn16,
																												  this.dataGridTextBoxColumn17,
																												  this.dataGridTextBoxColumn18,
																												  this.dataGridTextBoxColumn31,
																												  this.dataGridTextBoxColumn38});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "序号";
			this.dataGridTextBoxColumn1.MappingName = "";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.Width = 35;
			// 
			// dataGridBoolColumn1
			// 
			this.dataGridBoolColumn1.AllowNull = false;
			this.dataGridBoolColumn1.FalseValue = ((short)(0));
			this.dataGridBoolColumn1.HeaderText = "收费";
			this.dataGridBoolColumn1.MappingName = "";
			this.dataGridBoolColumn1.NullText = "0";
			this.dataGridBoolColumn1.NullValue = ((short)(0));
			this.dataGridBoolColumn1.ReadOnly = true;
			this.dataGridBoolColumn1.TrueValue = ((short)(1));
			this.dataGridBoolColumn1.Width = 40;
			// 
			// dataGridBoolColumn2
			// 
			this.dataGridBoolColumn2.AllowNull = false;
			this.dataGridBoolColumn2.FalseValue = ((short)(0));
			this.dataGridBoolColumn2.HeaderText = "发药";
			this.dataGridBoolColumn2.MappingName = "";
			this.dataGridBoolColumn2.NullText = "0";
			this.dataGridBoolColumn2.NullValue = ((short)(0));
			this.dataGridBoolColumn2.ReadOnly = true;
			this.dataGridBoolColumn2.TrueValue = ((short)(1));
			this.dataGridBoolColumn2.Width = 40;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "发票号";
			this.dataGridTextBoxColumn2.MappingName = "";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 65;
			// 
			// dataGridTextBoxColumn33
			// 
			this.dataGridTextBoxColumn33.Format = "";
			this.dataGridTextBoxColumn33.FormatInfo = null;
			this.dataGridTextBoxColumn33.HeaderText = "挂号序号";
			this.dataGridTextBoxColumn33.MappingName = "";
			this.dataGridTextBoxColumn33.NullText = "";
			this.dataGridTextBoxColumn33.ReadOnly = true;
			this.dataGridTextBoxColumn33.Width = 70;
			// 
			// dataGridTextBoxColumn36
			// 
			this.dataGridTextBoxColumn36.Format = "";
			this.dataGridTextBoxColumn36.FormatInfo = null;
			this.dataGridTextBoxColumn36.HeaderText = "病历号";
			this.dataGridTextBoxColumn36.MappingName = "";
			this.dataGridTextBoxColumn36.NullText = "";
			this.dataGridTextBoxColumn36.ReadOnly = true;
			this.dataGridTextBoxColumn36.Width = 60;
			// 
			// dataGridTextBoxColumn37
			// 
			this.dataGridTextBoxColumn37.Format = "";
			this.dataGridTextBoxColumn37.FormatInfo = null;
			this.dataGridTextBoxColumn37.HeaderText = "凭证号";
			this.dataGridTextBoxColumn37.MappingName = "";
			this.dataGridTextBoxColumn37.NullText = "";
			this.dataGridTextBoxColumn37.Width = 60;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "姓名";
			this.dataGridTextBoxColumn3.MappingName = "";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.Width = 65;
			// 
			// dataGridTextBoxColumn34
			// 
			this.dataGridTextBoxColumn34.Format = "";
			this.dataGridTextBoxColumn34.FormatInfo = null;
			this.dataGridTextBoxColumn34.HeaderText = "性别";
			this.dataGridTextBoxColumn34.MappingName = "";
			this.dataGridTextBoxColumn34.ReadOnly = true;
			this.dataGridTextBoxColumn34.Width = 40;
			// 
			// dataGridTextBoxColumn35
			// 
			this.dataGridTextBoxColumn35.Format = "";
			this.dataGridTextBoxColumn35.FormatInfo = null;
			this.dataGridTextBoxColumn35.HeaderText = "年龄";
			this.dataGridTextBoxColumn35.MappingName = "";
			this.dataGridTextBoxColumn35.ReadOnly = true;
			this.dataGridTextBoxColumn35.Width = 40;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "项目";
			this.dataGridTextBoxColumn4.MappingName = "";
			this.dataGridTextBoxColumn4.NullText = "";
			this.dataGridTextBoxColumn4.Width = 60;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "金额";
			this.dataGridTextBoxColumn5.MappingName = "";
			this.dataGridTextBoxColumn5.NullText = "";
			this.dataGridTextBoxColumn5.Width = 65;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "科室";
			this.dataGridTextBoxColumn6.MappingName = "";
			this.dataGridTextBoxColumn6.NullText = "";
			this.dataGridTextBoxColumn6.Width = 0;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "医生";
			this.dataGridTextBoxColumn7.MappingName = "";
			this.dataGridTextBoxColumn7.NullText = "";
			this.dataGridTextBoxColumn7.Width = 0;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "剂数";
			this.dataGridTextBoxColumn8.MappingName = "";
			this.dataGridTextBoxColumn8.NullText = "";
			this.dataGridTextBoxColumn8.Width = 35;
			// 
			// dataGridTextBoxColumn30
			// 
			this.dataGridTextBoxColumn30.Format = "";
			this.dataGridTextBoxColumn30.FormatInfo = null;
			this.dataGridTextBoxColumn30.HeaderText = "划价日期";
			this.dataGridTextBoxColumn30.MappingName = "";
			this.dataGridTextBoxColumn30.Width = 0;
			// 
			// dataGridTextBoxColumn32
			// 
			this.dataGridTextBoxColumn32.Format = "";
			this.dataGridTextBoxColumn32.FormatInfo = null;
			this.dataGridTextBoxColumn32.HeaderText = "划价员";
			this.dataGridTextBoxColumn32.MappingName = "";
			this.dataGridTextBoxColumn32.Width = 0;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "收费日期";
			this.dataGridTextBoxColumn9.MappingName = "";
			this.dataGridTextBoxColumn9.NullText = "";
			this.dataGridTextBoxColumn9.Width = 75;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "收费员";
			this.dataGridTextBoxColumn10.MappingName = "";
			this.dataGridTextBoxColumn10.NullText = "";
			this.dataGridTextBoxColumn10.Width = 60;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "收费窗口";
			this.dataGridTextBoxColumn11.MappingName = "";
			this.dataGridTextBoxColumn11.NullText = "";
			this.dataGridTextBoxColumn11.Width = 60;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "发药日期";
			this.dataGridTextBoxColumn12.MappingName = "";
			this.dataGridTextBoxColumn12.NullText = "";
			this.dataGridTextBoxColumn12.Width = 80;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "发药员";
			this.dataGridTextBoxColumn13.MappingName = "";
			this.dataGridTextBoxColumn13.NullText = "";
			this.dataGridTextBoxColumn13.Width = 65;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "发药窗口";
			this.dataGridTextBoxColumn14.MappingName = "";
			this.dataGridTextBoxColumn14.NullText = "";
			this.dataGridTextBoxColumn14.Width = 60;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "配药日期";
			this.dataGridTextBoxColumn15.MappingName = "";
			this.dataGridTextBoxColumn15.NullText = "";
			this.dataGridTextBoxColumn15.Width = 80;
			// 
			// dataGridTextBoxColumn16
			// 
			this.dataGridTextBoxColumn16.Format = "";
			this.dataGridTextBoxColumn16.FormatInfo = null;
			this.dataGridTextBoxColumn16.HeaderText = "配药员";
			this.dataGridTextBoxColumn16.MappingName = "";
			this.dataGridTextBoxColumn16.NullText = "";
			this.dataGridTextBoxColumn16.Width = 65;
			// 
			// dataGridTextBoxColumn17
			// 
			this.dataGridTextBoxColumn17.Format = "";
			this.dataGridTextBoxColumn17.FormatInfo = null;
			this.dataGridTextBoxColumn17.HeaderText = "配药窗口";
			this.dataGridTextBoxColumn17.MappingName = "";
			this.dataGridTextBoxColumn17.NullText = "";
			this.dataGridTextBoxColumn17.Width = 60;
			// 
			// dataGridTextBoxColumn18
			// 
			this.dataGridTextBoxColumn18.Format = "";
			this.dataGridTextBoxColumn18.FormatInfo = null;
			this.dataGridTextBoxColumn18.HeaderText = "备注";
			this.dataGridTextBoxColumn18.MappingName = "";
			this.dataGridTextBoxColumn18.NullText = "";
			this.dataGridTextBoxColumn18.Width = 75;
			// 
			// dataGridTextBoxColumn31
			// 
			this.dataGridTextBoxColumn31.Format = "";
			this.dataGridTextBoxColumn31.FormatInfo = null;
			this.dataGridTextBoxColumn31.HeaderText = "xh";
			this.dataGridTextBoxColumn31.MappingName = "";
			this.dataGridTextBoxColumn31.NullText = "";
			this.dataGridTextBoxColumn31.Width = 0;
			// 
			// dataGridTextBoxColumn38
			// 
			this.dataGridTextBoxColumn38.Format = "";
			this.dataGridTextBoxColumn38.FormatInfo = null;
			this.dataGridTextBoxColumn38.HeaderText = "诊断";
			this.dataGridTextBoxColumn38.MappingName = "";
			this.dataGridTextBoxColumn38.NullText = "";
			this.dataGridTextBoxColumn38.Width = 75;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.myDataGrid1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 104);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(864, 258);
			this.panel1.TabIndex = 3;
			// 
			// chkbk
			// 
			this.chkbk.Location = new System.Drawing.Point(224, 8);
			this.chkbk.Name = "chkbk";
			this.chkbk.Size = new System.Drawing.Size(72, 16);
			this.chkbk.TabIndex = 10;
			this.chkbk.Text = "备份库";
			// 
			// chkbk1
			// 
			this.chkbk1.Location = new System.Drawing.Point(391, 16);
			this.chkbk1.Name = "chkbk1";
			this.chkbk1.Size = new System.Drawing.Size(72, 16);
			this.chkbk1.TabIndex = 18;
			this.chkbk1.Text = "备份库";
			// 
			// Frmcfcx
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(864, 533);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.myDataGrid2);
			this.Name = "Frmcfcx";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "处方查询";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Frmkccx_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Frmkccx_Load(object sender, System.EventArgs e)
		{

			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

			FunBase.CsDataGrid(this.myDataGrid2,this.myDataGrid2.TableStyles[0],"Tb1");

			//添加医保类型 
			BaseFun.AddYblx(cmbyblx);

			dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			BaseFun.AddPyr(_deptID,cmbuser);
		}

		private void patientInfo1_IDTextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{

				if (Convert.ToInt32(e.KeyChar)==13)
				{
					DataTable tbcf=(DataTable)this.myDataGrid1.DataSource;
					DataTable tbcfmx=(DataTable)this.myDataGrid2.DataSource;
					tbcf.Rows.Clear();
					tbcfmx.Rows.Clear();

					if (this.patientInfo1.PatientID<=0) return;
					string RegisterID=this.patientInfo1.SearchIDType==PatientInfo.IDType.RegisterID?this.patientInfo1.PatientID.ToString():"0";
					string InvoiceID=this.patientInfo1.SearchIDType==PatientInfo.IDType.InvoiceID?this.patientInfo1.PatientInvoiceID:"0";
					string InvoiceSerialID=this.patientInfo1.SearchIDType==PatientInfo.IDType.InvoiceSerialID?this.patientInfo1.PatientInvoiceSerialID:"0";
					DataTable tb=YFFun.SelectMzcfk(_menuTag.Function_Name,_deptID,Convert.ToInt64(Convertor.IsNull(RegisterID,"0")),"",
						Convert.ToInt64(Convertor.IsNull(InvoiceID,"0")),Convert.ToDecimal(Convertor.IsNull(InvoiceSerialID,"0")),"","",
						0,0,"","","",0,"","",0,0,"","","",0,0,Convert.ToInt32(this.chkbk.Checked),MZ);
					tb.TableName="Tb";
					this.myDataGrid1.DataSource=tb;
					this.myDataGrid1.TableStyles[0].MappingName="Tb";
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			
			try
			{
				int bk=0;
				if (this.tabControl1.SelectedTab==this.tabPage1)
					bk=Convert.ToInt32(chkbk.Checked);
				else
					bk=Convert.ToInt32(chkbk1.Checked);
				DataTable tbcf=(DataTable)this.myDataGrid1.DataSource;
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				if (nrow>tbcf.Rows.Count-1) return;
				SelectCfmx(tbcf.Rows[nrow],bk);
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void SelectCfmx(DataRow cfrow,int bk)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			if (rdowsfcf.Checked!=true)
			{tb=YFFun.SelectMzcfmxk(_menuTag.Function_Name,Convert.ToInt64(Convertor.IsNull(cfrow["xh"],"0")),Convert.ToInt64(Convertor.IsNull(cfrow["发票号"],"0")),bk,MZ);}
			else
			{tb=YFFun.SelectMzcfmxk("Fun_ts_yf_cx_cfcx_hjcfk",Convert.ToInt64(Convertor.IsNull(cfrow["xh"],"0")),Convert.ToInt64(Convertor.IsNull(cfrow["发票号"],"0")),bk,MZ);}
			tb.TableName="Tb1";
			this.myDataGrid2.DataSource=tb;
			this.myDataGrid2.TableStyles[0].MappingName="Tb1";

			DataRow sumrow=tb.NewRow();
			sumrow["序号"]="小计";
			sumrow["金额"]=cfrow["金额"];
			tb.Rows.Add(sumrow);
		}

		private void butcx_Click(object sender, System.EventArgs e)
		{
			int yblx=this.chkyblx.Checked==true?Convert.ToInt32(cmbyblx.SelectedValue):0;
			try
			{
				DataTable tb2=(DataTable)this.myDataGrid2.DataSource;
				tb2.Rows.Clear();
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (this.rdofyrq.Checked==true)
				{
					long fyczy=this.chkuser.Checked==true?Convert.ToInt32(cmbuser.SelectedValue):0;
					tb=YFFun.SelectMzcfk(_menuTag.Function_Name,_deptID,0,txthzxm.Text.Trim(),
						0,0,dtp1.Value.ToShortDateString(),dtp2.Value.ToShortDateString(),
						fyczy,1,"","","",0,"","",0,0,"","","",0,yblx,Convert.ToInt32(chkbk1.Checked),MZ);
				}
				if (this.rdosfrq.Checked==true)
				{
					int fybz=this.chkuser.Checked==true?111:0;
					tb=YFFun.SelectMzcfk(_menuTag.Function_Name,_deptID,0,txthzxm.Text.Trim(),
						0,0,"","",
						0,fybz,"",dtp1.Value.ToShortDateString(),dtp2.Value.ToShortDateString(),0,"","",0,0,"","","",0,yblx,Convert.ToInt32(chkbk1.Checked),MZ);
				}

				if (this.rdocfrq.Checked==true)
				{
					long lrczy=this.chkuser.Checked==true?Convert.ToInt32(cmbuser.SelectedValue):0;
					tb=YFFun.SelectMzcfk(_menuTag.Function_Name,_deptID,0,txthzxm.Text.Trim(),
						0,0,"","",
						0,0,"","","",0,"","",0,0,"",dtp1.Value.ToShortDateString(),dtp2.Value.ToShortDateString(),lrczy,yblx,Convert.ToInt32(chkbk1.Checked),MZ);
				}

				if (this.rdowsfcf.Checked==true)
				{
					long lrczy=this.chkuser.Checked==true?Convert.ToInt32(cmbuser.SelectedValue):0;
					tb=YFFun.SelectMzcfk("Fun_ts_yf_cx_cfcx_hjcfk",_deptID,0,txthzxm.Text.Trim(),
						0,0,"","",
						0,0,"","","",0,"","",0,0,"",dtp1.Value.ToShortDateString(),dtp2.Value.ToShortDateString(),lrczy,yblx,Convert.ToInt32(chkbk1.Checked),MZ);
				}

				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
				this.myDataGrid1.TableStyles[0].MappingName="Tb";
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}

		private void rdofyrq_CheckedChanged(object sender, System.EventArgs e)
		{
			//chkuser.Visible=this.rdofyrq.Checked==true || this.rdocfrq.Checked==true?true:false;
			cmbuser.Visible=this.rdofyrq.Checked==true || this.rdocfrq.Checked==true? true:false;
			if (this.rdofyrq.Checked==true) chkuser.Text="发药人";
			if (this.rdocfrq.Checked==true) chkuser.Text="算价人";
			if (this.rdosfrq.Checked==true) chkuser.Text="未发药处方";
		}

		private void butquit1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//打印方法
		private void PrintCf()
		{
			int bk=0;
			if (this.tabControl1.SelectedTab==this.tabPage1)
				bk=Convert.ToInt32(chkbk.Checked);
			else
				bk=Convert.ToInt32(chkbk1.Checked);

			Xc_Yk_ReportView.Dataset2 Dset=new Xc_Yk_ReportView.Dataset2();
			DataTable tb=(DataTable)this.myDataGrid1.DataSource ;
			for(int nrow=0;nrow<=tb.Rows.Count-1;nrow++)
			{
				this.SelectCfmx(tb.Rows[nrow],bk);
				DataTable tb2=(DataTable)this.myDataGrid2.DataSource;
				string cftsname="";
				cftsname=Convert.ToString(tb.Rows[nrow]["项目"]).Trim()=="中草药"?"中药付数":"";
				DataRow myrow;
				for(int i=0;i<=tb2.Rows.Count-1;i++)
				{
					if (tb2.Rows[i]["序号"].ToString().Trim()!="小计")
					{
						myrow=Dset.病人处方清单.NewRow();
						myrow["xh"]=Convert.ToInt32(tb2.Rows[i]["序号"]);
						myrow["ypmc"]=Convert.ToString(tb2.Rows[i]["药品名称"]);
						myrow["ypgg"]=Convert.ToString(tb2.Rows[i]["规格"]);
						myrow["sccj"]=Convert.ToString(tb2.Rows[i]["厂家"]);
						myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb2.Rows[i]["零售价"],"0"));
						myrow["ypsl"]=Convert.ToDecimal(Convertor.IsNull(tb2.Rows[i]["用量"],"0"));
						myrow["ypdw"]=Convert.ToString(tb2.Rows[i]["单位"]);
						myrow["cfts"]=Convert.ToString(tb.Rows[nrow]["项目"]).Trim()=="中草药"?cftsname+tb.Rows[nrow]["剂数"]+"剂":"";
						myrow["lsje"]=Convert.ToDecimal(Convertor.IsNull(tb2.Rows[i]["金额"],"0"));
						myrow["shh"]=Convert.ToString(tb2.Rows[i]["货号"]);
						myrow["ksname"]=Convert.ToString(tb.Rows[nrow]["科室"]);
						myrow["ysname"]=Convert.ToString(tb.Rows[nrow]["医生"]);
						myrow["fph"]=Convert.ToString(tb.Rows[nrow]["发票号"]);
						myrow["hzxm"]=Convert.ToString(tb.Rows[nrow]["姓名"]);
						myrow["sex"]=Convert.ToString(tb.Rows[nrow]["性别"]);
						myrow["age"]=Convert.ToString(tb.Rows[nrow]["年龄"]);
						myrow["blh"]=Convert.ToString(tb.Rows[nrow]["病历号"]);
						myrow["sfrq"]=Convert.ToString(tb.Rows[nrow]["收费日期"]);
						myrow["zje"]=Convert.ToDecimal(tb.Rows[nrow]["金额"]);
						myrow["pzh"]=Convert.ToString(tb.Rows[nrow]["凭证号"]);
						myrow["zdmc"]="诊断:"+Convert.ToString(tb.Rows[nrow]["诊断"]);

						string UserEat="";
						UserEat=Convert.ToInt32(Convertor.IsNull(tb2.Rows[i]["PCDM"],"0"))<=0?"":Convert.ToDouble(tb2.Rows[i]["剂量"]).ToString()+tb2.Rows[i]["剂量单位"].ToString().Trim()+"/每次";
						myrow["yf"]=Convert.ToString(tb2.Rows[i]["用法"])+"  "+ tb2.Rows[i]["使用频次"].ToString().Trim()+" "+UserEat;

						Dset.病人处方清单.Rows.Add(myrow);
					}

				}

			}

			ParameterEx[] parameters=new ParameterEx[1];
			parameters[0].Text="TITLETEXT";
			parameters[0].Value="处方明细单";
			bool bview=false;
			
			TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单,Constant.ApplicationDirectory+"\\Report\\YF_病人处方清单列表.rpt",parameters);
			if (f.LoadReportSuccess) f.Show();else  f.Dispose();

		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.butprint.Enabled=false;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				DataRow cfrow=tb.Rows[this.myDataGrid1.CurrentCell.RowNumber];
				PrintCf();
				this.butprint.Enabled=true;
			}
			catch(System.Exception err)
			{
				this.butprint.Enabled=true;
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void chkuser_CheckedChanged(object sender, System.EventArgs e)
		{
			this.cmbuser.Enabled=this.chkuser.Checked==true?true:false;
			this.cmbyblx.Enabled=this.chkyblx.Checked==true?true:false;
		}

		private void myDataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}



	}
}
