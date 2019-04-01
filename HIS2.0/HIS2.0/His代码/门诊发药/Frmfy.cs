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
using PatientInfo;

namespace ts_yf_mzfy
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmmzfy : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private myDataGrid.myDataGrid myDataGrid2;
		private myDataGrid.myDataGrid myDataGrid3;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTextBoxColumn XH;
		private System.Windows.Forms.DataGridTextBoxColumn fph;
		private System.Windows.Forms.DataGridTextBoxColumn je;
		private System.Windows.Forms.DataGridTextBoxColumn xm;
		private System.Windows.Forms.DataGridTextBoxColumn brxm;
		private System.Windows.Forms.DataGridTextBoxColumn SFRQ;
		private System.Windows.Forms.DataGridTextBoxColumn sfy;
		private System.Windows.Forms.DataGridTextBoxColumn PYR;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbpyr;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.CheckBox chkfybz;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
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
		private System.Windows.Forms.Button butref;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
		private System.Windows.Forms.Button butfy;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn44;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn45;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn47;
		private string IPAddRess;
		private string _Fyckh;
		private System.Windows.Forms.DateTimePicker dtpfyrq;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn61;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn62;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn63;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn64;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn65;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn2;
		private System.Windows.Forms.CheckBox chkprint;
		private System.Windows.Forms.CheckBox chkprrintView;
		private System.Windows.Forms.CheckBox chkref;
		private System.Windows.Forms.CheckBox chkall;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn46;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn66;
		private System.Windows.Forms.CheckBox chkbk;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn67;
		private YpConfig s;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn68;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn69;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn70;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn71;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private PatientInfo.PatientInfo patientInfo1;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmmzfy(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName.Trim();

			//f
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
			this.chkbk = new System.Windows.Forms.CheckBox();
			this.chkall = new System.Windows.Forms.CheckBox();
			this.chkref = new System.Windows.Forms.CheckBox();
			this.chkfybz = new System.Windows.Forms.CheckBox();
			this.patientInfo1 = new PatientInfo.PatientInfo();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dtpfyrq = new System.Windows.Forms.DateTimePicker();
			this.butref = new System.Windows.Forms.Button();
			this.myDataGrid1 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn48 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn49 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn50 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn51 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn52 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.myDataGrid2 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn56 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn53 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn45 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn54 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn55 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn68 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn69 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn70 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn71 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.myDataGrid3 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn62 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn2 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn47 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn57 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn58 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn59 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn60 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn46 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn66 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn61 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn63 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn64 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn65 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn67 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.XH = new System.Windows.Forms.DataGridTextBoxColumn();
			this.fph = new System.Windows.Forms.DataGridTextBoxColumn();
			this.je = new System.Windows.Forms.DataGridTextBoxColumn();
			this.xm = new System.Windows.Forms.DataGridTextBoxColumn();
			this.brxm = new System.Windows.Forms.DataGridTextBoxColumn();
			this.SFRQ = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sfy = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PYR = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel3 = new System.Windows.Forms.Panel();
			this.chkprrintView = new System.Windows.Forms.CheckBox();
			this.chkprint = new System.Windows.Forms.CheckBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.butfy = new System.Windows.Forms.Button();
			this.cmbpyr = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.chkbk);
			this.panel1.Controls.Add(this.chkall);
			this.panel1.Controls.Add(this.chkref);
			this.panel1.Controls.Add(this.chkfybz);
			this.panel1.Controls.Add(this.patientInfo1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(920, 80);
			this.panel1.TabIndex = 0;
			// 
			// chkbk
			// 
			this.chkbk.ForeColor = System.Drawing.Color.Navy;
			this.chkbk.Location = new System.Drawing.Point(615, -1);
			this.chkbk.Name = "chkbk";
			this.chkbk.Size = new System.Drawing.Size(80, 24);
			this.chkbk.TabIndex = 12;
			this.chkbk.Text = "查备份库";
			// 
			// chkall
			// 
			this.chkall.ForeColor = System.Drawing.Color.Navy;
			this.chkall.Location = new System.Drawing.Point(458, -1);
			this.chkall.Name = "chkall";
			this.chkall.Size = new System.Drawing.Size(176, 24);
			this.chkall.TabIndex = 4;
			this.chkall.Text = "显示所以发药窗口的药品";
			// 
			// chkref
			// 
			this.chkref.ForeColor = System.Drawing.Color.Navy;
			this.chkref.Location = new System.Drawing.Point(288, -1);
			this.chkref.Name = "chkref";
			this.chkref.Size = new System.Drawing.Size(176, 24);
			this.chkref.TabIndex = 3;
			this.chkref.Text = "发药时刷新待发药处方列表";
			// 
			// chkfybz
			// 
			this.chkfybz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.chkfybz.ForeColor = System.Drawing.Color.Green;
			this.chkfybz.Location = new System.Drawing.Point(200, -1);
			this.chkfybz.Name = "chkfybz";
			this.chkfybz.TabIndex = 1;
			this.chkfybz.Text = "已发药处方";
			this.chkfybz.CheckedChanged += new System.EventHandler(this.chkfybz_CheckedChanged);
			// 
			// patientInfo1
			// 
			this.patientInfo1.AgeToolTip = "";
			this.patientInfo1.AnimalHeatVisible = false;
			this.patientInfo1.AvoirdupoisVisible = true;
			this.patientInfo1.CaseIDVisible = false;
			this.patientInfo1.DiagnoseEnabled = false;
			this.patientInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.patientInfo1.FeeTypeEnabled = false;
			this.patientInfo1.FilterPatientByDate = true;
			this.patientInfo1.ICIDVisible = false;
			this.patientInfo1.InvoiceIDVisible = true;
			this.patientInfo1.InvoiceSerialIDVisible = false;
			this.patientInfo1.LgbzVisible = false;
			this.patientInfo1.Location = new System.Drawing.Point(0, 0);
			this.patientInfo1.MagcardIDVisible = true;
			this.patientInfo1.Name = "patientInfo1";
			this.patientInfo1.NameSexEnabled = true;
			this.patientInfo1.NeedInputPrescDocDept = false;
			this.patientInfo1.PatientDiagnose = "";
			this.patientInfo1.PatientDiagnoseCode = "";
			this.patientInfo1.RegisterIDVisible = true;
			this.patientInfo1.SearchHistoryRecord = true;
			this.patientInfo1.SearchIDType = PatientInfo.IDType.InvoiceID;
			this.patientInfo1.Size = new System.Drawing.Size(918, 78);
			this.patientInfo1.TabIndex = 13;
			this.patientInfo1.IDTextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.patientInfo1_IDTextBoxKeyPress);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dtpfyrq);
			this.panel2.Controls.Add(this.butref);
			this.panel2.Controls.Add(this.myDataGrid1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 80);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(344, 477);
			this.panel2.TabIndex = 1;
			// 
			// dtpfyrq
			// 
			this.dtpfyrq.Location = new System.Drawing.Point(80, 1);
			this.dtpfyrq.Name = "dtpfyrq";
			this.dtpfyrq.Size = new System.Drawing.Size(109, 21);
			this.dtpfyrq.TabIndex = 3;
			// 
			// butref
			// 
			this.butref.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butref.ForeColor = System.Drawing.Color.Navy;
			this.butref.Location = new System.Drawing.Point(192, 0);
			this.butref.Name = "butref";
			this.butref.Size = new System.Drawing.Size(152, 24);
			this.butref.TabIndex = 2;
			this.butref.Text = "刷新(&F1)";
			this.butref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butref.Click += new System.EventHandler(this.butref_Click);
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.Silver;
			this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.myDataGrid1.CaptionText = "待发药处方";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.ReadOnly = true;
			this.myDataGrid1.RowHeadersVisible = false;
			this.myDataGrid1.Size = new System.Drawing.Size(344, 477);
			this.myDataGrid1.TabIndex = 1;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.myDataGrid1_Navigate);
			this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn48,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn49,
																												  this.dataGridTextBoxColumn50,
																												  this.dataGridTextBoxColumn51,
																												  this.dataGridTextBoxColumn52,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn43});
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
			this.dataGridTextBoxColumn1.Width = 30;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "发票号";
			this.dataGridTextBoxColumn2.MappingName = "";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 60;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "项目";
			this.dataGridTextBoxColumn3.MappingName = "";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.Width = 70;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "金额";
			this.dataGridTextBoxColumn4.MappingName = "";
			this.dataGridTextBoxColumn4.NullText = "";
			this.dataGridTextBoxColumn4.Width = 60;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "发票日期";
			this.dataGridTextBoxColumn6.MappingName = "";
			this.dataGridTextBoxColumn6.NullText = "";
			this.dataGridTextBoxColumn6.Width = 90;
			// 
			// dataGridTextBoxColumn48
			// 
			this.dataGridTextBoxColumn48.Format = "";
			this.dataGridTextBoxColumn48.FormatInfo = null;
			this.dataGridTextBoxColumn48.HeaderText = "病历号";
			this.dataGridTextBoxColumn48.MappingName = "";
			this.dataGridTextBoxColumn48.NullText = "";
			this.dataGridTextBoxColumn48.Width = 60;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "姓名";
			this.dataGridTextBoxColumn5.MappingName = "";
			this.dataGridTextBoxColumn5.NullText = "";
			this.dataGridTextBoxColumn5.Width = 60;
			// 
			// dataGridTextBoxColumn49
			// 
			this.dataGridTextBoxColumn49.Format = "";
			this.dataGridTextBoxColumn49.FormatInfo = null;
			this.dataGridTextBoxColumn49.HeaderText = "性别";
			this.dataGridTextBoxColumn49.MappingName = "";
			this.dataGridTextBoxColumn49.Width = 75;
			// 
			// dataGridTextBoxColumn50
			// 
			this.dataGridTextBoxColumn50.Format = "";
			this.dataGridTextBoxColumn50.FormatInfo = null;
			this.dataGridTextBoxColumn50.HeaderText = "年龄";
			this.dataGridTextBoxColumn50.MappingName = "";
			this.dataGridTextBoxColumn50.Width = 75;
			// 
			// dataGridTextBoxColumn51
			// 
			this.dataGridTextBoxColumn51.Format = "";
			this.dataGridTextBoxColumn51.FormatInfo = null;
			this.dataGridTextBoxColumn51.HeaderText = "科室";
			this.dataGridTextBoxColumn51.MappingName = "";
			this.dataGridTextBoxColumn51.Width = 75;
			// 
			// dataGridTextBoxColumn52
			// 
			this.dataGridTextBoxColumn52.Format = "";
			this.dataGridTextBoxColumn52.FormatInfo = null;
			this.dataGridTextBoxColumn52.HeaderText = "医生";
			this.dataGridTextBoxColumn52.MappingName = "";
			this.dataGridTextBoxColumn52.Width = 75;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "配药窗口";
			this.dataGridTextBoxColumn7.MappingName = "";
			this.dataGridTextBoxColumn7.NullText = "";
			this.dataGridTextBoxColumn7.ReadOnly = true;
			this.dataGridTextBoxColumn7.Width = 50;
			// 
			// dataGridTextBoxColumn43
			// 
			this.dataGridTextBoxColumn43.Format = "";
			this.dataGridTextBoxColumn43.FormatInfo = null;
			this.dataGridTextBoxColumn43.HeaderText = "patid";
			this.dataGridTextBoxColumn43.MappingName = "";
			this.dataGridTextBoxColumn43.Width = 0;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(344, 80);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 477);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.Silver;
			this.myDataGrid2.CaptionForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.myDataGrid2.CaptionText = "处方标头";
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.Size = new System.Drawing.Size(573, 192);
			this.myDataGrid2.TabIndex = 4;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			this.myDataGrid2.Navigate += new System.Windows.Forms.NavigateEventHandler(this.myDataGrid2_Navigate);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.AllowSorting = false;
			this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridBoolColumn1,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridTextBoxColumn56,
																												  this.dataGridTextBoxColumn53,
																												  this.dataGridTextBoxColumn45,
																												  this.dataGridTextBoxColumn54,
																												  this.dataGridTextBoxColumn55,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn68,
																												  this.dataGridTextBoxColumn69,
																												  this.dataGridTextBoxColumn70,
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn71,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn15,
																												  this.dataGridTextBoxColumn16,
																												  this.dataGridTextBoxColumn17,
																												  this.dataGridTextBoxColumn18,
																												  this.dataGridTextBoxColumn19,
																												  this.dataGridTextBoxColumn20,
																												  this.dataGridTextBoxColumn21,
																												  this.dataGridTextBoxColumn22,
																												  this.dataGridTextBoxColumn23,
																												  this.dataGridTextBoxColumn24,
																												  this.dataGridTextBoxColumn25,
																												  this.dataGridTextBoxColumn26,
																												  this.dataGridTextBoxColumn27,
																												  this.dataGridTextBoxColumn44});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "";
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "序号";
			this.dataGridTextBoxColumn8.MappingName = "";
			this.dataGridTextBoxColumn8.ReadOnly = true;
			this.dataGridTextBoxColumn8.Width = 30;
			// 
			// dataGridBoolColumn1
			// 
			this.dataGridBoolColumn1.AllowNull = false;
			this.dataGridBoolColumn1.FalseValue = ((short)(0));
			this.dataGridBoolColumn1.HeaderText = "发药";
			this.dataGridBoolColumn1.MappingName = "";
			this.dataGridBoolColumn1.NullText = "0";
			this.dataGridBoolColumn1.NullValue = ((short)(0));
			this.dataGridBoolColumn1.TrueValue = ((short)(1));
			this.dataGridBoolColumn1.Width = 30;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "发票号";
			this.dataGridTextBoxColumn9.MappingName = "";
			this.dataGridTextBoxColumn9.NullText = "";
			this.dataGridTextBoxColumn9.ReadOnly = true;
			this.dataGridTextBoxColumn9.Width = 60;
			// 
			// dataGridTextBoxColumn56
			// 
			this.dataGridTextBoxColumn56.Format = "";
			this.dataGridTextBoxColumn56.FormatInfo = null;
			this.dataGridTextBoxColumn56.HeaderText = "发票日期";
			this.dataGridTextBoxColumn56.MappingName = "";
			this.dataGridTextBoxColumn56.NullText = "";
			this.dataGridTextBoxColumn56.Width = 65;
			// 
			// dataGridTextBoxColumn53
			// 
			this.dataGridTextBoxColumn53.Format = "";
			this.dataGridTextBoxColumn53.FormatInfo = null;
			this.dataGridTextBoxColumn53.HeaderText = "病历号";
			this.dataGridTextBoxColumn53.MappingName = "";
			this.dataGridTextBoxColumn53.NullText = "";
			this.dataGridTextBoxColumn53.Width = 60;
			// 
			// dataGridTextBoxColumn45
			// 
			this.dataGridTextBoxColumn45.Format = "";
			this.dataGridTextBoxColumn45.FormatInfo = null;
			this.dataGridTextBoxColumn45.HeaderText = "姓名";
			this.dataGridTextBoxColumn45.MappingName = "";
			this.dataGridTextBoxColumn45.NullText = "";
			this.dataGridTextBoxColumn45.Width = 60;
			// 
			// dataGridTextBoxColumn54
			// 
			this.dataGridTextBoxColumn54.Format = "";
			this.dataGridTextBoxColumn54.FormatInfo = null;
			this.dataGridTextBoxColumn54.HeaderText = "性别";
			this.dataGridTextBoxColumn54.MappingName = "";
			this.dataGridTextBoxColumn54.NullText = "";
			this.dataGridTextBoxColumn54.Width = 40;
			// 
			// dataGridTextBoxColumn55
			// 
			this.dataGridTextBoxColumn55.Format = "";
			this.dataGridTextBoxColumn55.FormatInfo = null;
			this.dataGridTextBoxColumn55.HeaderText = "年龄";
			this.dataGridTextBoxColumn55.MappingName = "";
			this.dataGridTextBoxColumn55.NullText = "";
			this.dataGridTextBoxColumn55.Width = 40;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "项目";
			this.dataGridTextBoxColumn10.MappingName = "";
			this.dataGridTextBoxColumn10.NullText = "";
			this.dataGridTextBoxColumn10.ReadOnly = true;
			this.dataGridTextBoxColumn10.Width = 70;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "金额";
			this.dataGridTextBoxColumn11.MappingName = "";
			this.dataGridTextBoxColumn11.NullText = "";
			this.dataGridTextBoxColumn11.ReadOnly = true;
			this.dataGridTextBoxColumn11.Width = 60;
			// 
			// dataGridTextBoxColumn68
			// 
			this.dataGridTextBoxColumn68.Format = "";
			this.dataGridTextBoxColumn68.FormatInfo = null;
			this.dataGridTextBoxColumn68.HeaderText = "记帐金额";
			this.dataGridTextBoxColumn68.MappingName = "";
			this.dataGridTextBoxColumn68.Width = 0;
			// 
			// dataGridTextBoxColumn69
			// 
			this.dataGridTextBoxColumn69.Format = "";
			this.dataGridTextBoxColumn69.FormatInfo = null;
			this.dataGridTextBoxColumn69.HeaderText = "优惠金额";
			this.dataGridTextBoxColumn69.MappingName = "";
			this.dataGridTextBoxColumn69.Width = 0;
			// 
			// dataGridTextBoxColumn70
			// 
			this.dataGridTextBoxColumn70.Format = "";
			this.dataGridTextBoxColumn70.FormatInfo = null;
			this.dataGridTextBoxColumn70.HeaderText = "自付金额";
			this.dataGridTextBoxColumn70.MappingName = "";
			this.dataGridTextBoxColumn70.Width = 0;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "科室";
			this.dataGridTextBoxColumn12.MappingName = "";
			this.dataGridTextBoxColumn12.NullText = "";
			this.dataGridTextBoxColumn12.ReadOnly = true;
			this.dataGridTextBoxColumn12.Width = 75;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "医生";
			this.dataGridTextBoxColumn13.MappingName = "";
			this.dataGridTextBoxColumn13.NullText = "";
			this.dataGridTextBoxColumn13.ReadOnly = true;
			this.dataGridTextBoxColumn13.Width = 65;
			// 
			// dataGridTextBoxColumn71
			// 
			this.dataGridTextBoxColumn71.Format = "";
			this.dataGridTextBoxColumn71.FormatInfo = null;
			this.dataGridTextBoxColumn71.HeaderText = "医生签名";
			this.dataGridTextBoxColumn71.MappingName = "";
			this.dataGridTextBoxColumn71.NullText = "";
			this.dataGridTextBoxColumn71.Width = 70;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "剂数";
			this.dataGridTextBoxColumn14.MappingName = "";
			this.dataGridTextBoxColumn14.NullText = "";
			this.dataGridTextBoxColumn14.ReadOnly = true;
			this.dataGridTextBoxColumn14.Width = 30;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "收费日期";
			this.dataGridTextBoxColumn15.MappingName = "";
			this.dataGridTextBoxColumn15.NullText = "";
			this.dataGridTextBoxColumn15.ReadOnly = true;
			this.dataGridTextBoxColumn15.Width = 75;
			// 
			// dataGridTextBoxColumn16
			// 
			this.dataGridTextBoxColumn16.Format = "";
			this.dataGridTextBoxColumn16.FormatInfo = null;
			this.dataGridTextBoxColumn16.HeaderText = "收费员";
			this.dataGridTextBoxColumn16.MappingName = "";
			this.dataGridTextBoxColumn16.NullText = "";
			this.dataGridTextBoxColumn16.ReadOnly = true;
			this.dataGridTextBoxColumn16.Width = 50;
			// 
			// dataGridTextBoxColumn17
			// 
			this.dataGridTextBoxColumn17.Format = "";
			this.dataGridTextBoxColumn17.FormatInfo = null;
			this.dataGridTextBoxColumn17.HeaderText = "配药人";
			this.dataGridTextBoxColumn17.MappingName = "";
			this.dataGridTextBoxColumn17.NullText = "";
			this.dataGridTextBoxColumn17.ReadOnly = true;
			this.dataGridTextBoxColumn17.Width = 50;
			// 
			// dataGridTextBoxColumn18
			// 
			this.dataGridTextBoxColumn18.Format = "";
			this.dataGridTextBoxColumn18.FormatInfo = null;
			this.dataGridTextBoxColumn18.HeaderText = "配药窗口";
			this.dataGridTextBoxColumn18.MappingName = "";
			this.dataGridTextBoxColumn18.NullText = "";
			this.dataGridTextBoxColumn18.ReadOnly = true;
			this.dataGridTextBoxColumn18.Width = 60;
			// 
			// dataGridTextBoxColumn19
			// 
			this.dataGridTextBoxColumn19.Format = "";
			this.dataGridTextBoxColumn19.FormatInfo = null;
			this.dataGridTextBoxColumn19.HeaderText = "发药日期";
			this.dataGridTextBoxColumn19.MappingName = "";
			this.dataGridTextBoxColumn19.NullText = "";
			this.dataGridTextBoxColumn19.ReadOnly = true;
			this.dataGridTextBoxColumn19.Width = 75;
			// 
			// dataGridTextBoxColumn20
			// 
			this.dataGridTextBoxColumn20.Format = "";
			this.dataGridTextBoxColumn20.FormatInfo = null;
			this.dataGridTextBoxColumn20.HeaderText = "发药人";
			this.dataGridTextBoxColumn20.MappingName = "";
			this.dataGridTextBoxColumn20.NullText = "";
			this.dataGridTextBoxColumn20.ReadOnly = true;
			this.dataGridTextBoxColumn20.Width = 50;
			// 
			// dataGridTextBoxColumn21
			// 
			this.dataGridTextBoxColumn21.Format = "";
			this.dataGridTextBoxColumn21.FormatInfo = null;
			this.dataGridTextBoxColumn21.HeaderText = "jssjh";
			this.dataGridTextBoxColumn21.MappingName = "";
			this.dataGridTextBoxColumn21.NullText = "";
			this.dataGridTextBoxColumn21.ReadOnly = true;
			this.dataGridTextBoxColumn21.Width = 0;
			// 
			// dataGridTextBoxColumn22
			// 
			this.dataGridTextBoxColumn22.Format = "";
			this.dataGridTextBoxColumn22.FormatInfo = null;
			this.dataGridTextBoxColumn22.HeaderText = "xh";
			this.dataGridTextBoxColumn22.MappingName = "";
			this.dataGridTextBoxColumn22.NullText = "";
			this.dataGridTextBoxColumn22.Width = 0;
			// 
			// dataGridTextBoxColumn23
			// 
			this.dataGridTextBoxColumn23.Format = "";
			this.dataGridTextBoxColumn23.FormatInfo = null;
			this.dataGridTextBoxColumn23.HeaderText = "patid";
			this.dataGridTextBoxColumn23.MappingName = "";
			this.dataGridTextBoxColumn23.NullText = "";
			this.dataGridTextBoxColumn23.ReadOnly = true;
			this.dataGridTextBoxColumn23.Width = 0;
			// 
			// dataGridTextBoxColumn24
			// 
			this.dataGridTextBoxColumn24.Format = "";
			this.dataGridTextBoxColumn24.FormatInfo = null;
			this.dataGridTextBoxColumn24.HeaderText = "ysdm";
			this.dataGridTextBoxColumn24.MappingName = "";
			this.dataGridTextBoxColumn24.NullText = "";
			this.dataGridTextBoxColumn24.ReadOnly = true;
			this.dataGridTextBoxColumn24.Width = 0;
			// 
			// dataGridTextBoxColumn25
			// 
			this.dataGridTextBoxColumn25.Format = "";
			this.dataGridTextBoxColumn25.FormatInfo = null;
			this.dataGridTextBoxColumn25.HeaderText = "ksdm";
			this.dataGridTextBoxColumn25.MappingName = "";
			this.dataGridTextBoxColumn25.NullText = "";
			this.dataGridTextBoxColumn25.ReadOnly = true;
			this.dataGridTextBoxColumn25.Width = 0;
			// 
			// dataGridTextBoxColumn26
			// 
			this.dataGridTextBoxColumn26.Format = "";
			this.dataGridTextBoxColumn26.FormatInfo = null;
			this.dataGridTextBoxColumn26.HeaderText = "sky";
			this.dataGridTextBoxColumn26.MappingName = "";
			this.dataGridTextBoxColumn26.NullText = "";
			this.dataGridTextBoxColumn26.ReadOnly = true;
			this.dataGridTextBoxColumn26.Width = 0;
			// 
			// dataGridTextBoxColumn27
			// 
			this.dataGridTextBoxColumn27.Format = "";
			this.dataGridTextBoxColumn27.FormatInfo = null;
			this.dataGridTextBoxColumn27.HeaderText = "pyckh";
			this.dataGridTextBoxColumn27.MappingName = "";
			this.dataGridTextBoxColumn27.NullText = "";
			this.dataGridTextBoxColumn27.ReadOnly = true;
			this.dataGridTextBoxColumn27.Width = 0;
			// 
			// dataGridTextBoxColumn44
			// 
			this.dataGridTextBoxColumn44.Format = "";
			this.dataGridTextBoxColumn44.FormatInfo = null;
			this.dataGridTextBoxColumn44.HeaderText = "CFLX";
			this.dataGridTextBoxColumn44.MappingName = "";
			this.dataGridTextBoxColumn44.NullText = "";
			this.dataGridTextBoxColumn44.Width = 0;
			// 
			// myDataGrid3
			// 
			this.myDataGrid3.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid3.CaptionBackColor = System.Drawing.Color.Silver;
			this.myDataGrid3.CaptionForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.myDataGrid3.CaptionText = "处方明细";
			this.myDataGrid3.DataMember = "";
			this.myDataGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid3.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid3.Name = "myDataGrid3";
			this.myDataGrid3.Size = new System.Drawing.Size(573, 237);
			this.myDataGrid3.TabIndex = 0;
			this.myDataGrid3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle3});
			// 
			// dataGridTableStyle3
			// 
			this.dataGridTableStyle3.AllowSorting = false;
			this.dataGridTableStyle3.DataGrid = this.myDataGrid3;
			this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn28,
																												  this.dataGridTextBoxColumn62,
																												  this.dataGridBoolColumn2,
																												  this.dataGridTextBoxColumn41,
																												  this.dataGridTextBoxColumn29,
																												  this.dataGridTextBoxColumn30,
																												  this.dataGridTextBoxColumn31,
																												  this.dataGridTextBoxColumn33,
																												  this.dataGridTextBoxColumn34,
																												  this.dataGridTextBoxColumn47,
																												  this.dataGridTextBoxColumn35,
																												  this.dataGridTextBoxColumn37,
																												  this.dataGridTextBoxColumn57,
																												  this.dataGridTextBoxColumn58,
																												  this.dataGridTextBoxColumn59,
																												  this.dataGridTextBoxColumn60,
																												  this.dataGridTextBoxColumn46,
																												  this.dataGridTextBoxColumn66,
																												  this.dataGridTextBoxColumn61,
																												  this.dataGridTextBoxColumn63,
																												  this.dataGridTextBoxColumn38,
																												  this.dataGridTextBoxColumn39,
																												  this.dataGridTextBoxColumn40,
																												  this.dataGridTextBoxColumn42,
																												  this.dataGridTextBoxColumn64,
																												  this.dataGridTextBoxColumn65,
																												  this.dataGridTextBoxColumn32,
																												  this.dataGridTextBoxColumn36,
																												  this.dataGridTextBoxColumn67});
			this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle3.MappingName = "";
			// 
			// dataGridTextBoxColumn28
			// 
			this.dataGridTextBoxColumn28.Format = "";
			this.dataGridTextBoxColumn28.FormatInfo = null;
			this.dataGridTextBoxColumn28.HeaderText = "序号";
			this.dataGridTextBoxColumn28.MappingName = "";
			this.dataGridTextBoxColumn28.NullText = "";
			this.dataGridTextBoxColumn28.ReadOnly = true;
			this.dataGridTextBoxColumn28.Width = 30;
			// 
			// dataGridTextBoxColumn62
			// 
			this.dataGridTextBoxColumn62.Format = "";
			this.dataGridTextBoxColumn62.FormatInfo = null;
			this.dataGridTextBoxColumn62.HeaderText = "大输液";
			this.dataGridTextBoxColumn62.MappingName = "";
			this.dataGridTextBoxColumn62.NullText = "";
			this.dataGridTextBoxColumn62.ReadOnly = true;
			this.dataGridTextBoxColumn62.Width = 0;
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
			this.dataGridBoolColumn2.Width = 0;
			// 
			// dataGridTextBoxColumn41
			// 
			this.dataGridTextBoxColumn41.Format = "";
			this.dataGridTextBoxColumn41.FormatInfo = null;
			this.dataGridTextBoxColumn41.HeaderText = "发票号";
			this.dataGridTextBoxColumn41.MappingName = "";
			this.dataGridTextBoxColumn41.NullText = "";
			this.dataGridTextBoxColumn41.ReadOnly = true;
			this.dataGridTextBoxColumn41.Width = 60;
			// 
			// dataGridTextBoxColumn29
			// 
			this.dataGridTextBoxColumn29.Format = "";
			this.dataGridTextBoxColumn29.FormatInfo = null;
			this.dataGridTextBoxColumn29.HeaderText = "药品名称";
			this.dataGridTextBoxColumn29.MappingName = "";
			this.dataGridTextBoxColumn29.NullText = "";
			this.dataGridTextBoxColumn29.ReadOnly = true;
			this.dataGridTextBoxColumn29.Width = 75;
			// 
			// dataGridTextBoxColumn30
			// 
			this.dataGridTextBoxColumn30.Format = "";
			this.dataGridTextBoxColumn30.FormatInfo = null;
			this.dataGridTextBoxColumn30.HeaderText = "规格";
			this.dataGridTextBoxColumn30.MappingName = "";
			this.dataGridTextBoxColumn30.NullText = "";
			this.dataGridTextBoxColumn30.ReadOnly = true;
			this.dataGridTextBoxColumn30.Width = 70;
			// 
			// dataGridTextBoxColumn31
			// 
			this.dataGridTextBoxColumn31.Format = "";
			this.dataGridTextBoxColumn31.FormatInfo = null;
			this.dataGridTextBoxColumn31.HeaderText = "厂家";
			this.dataGridTextBoxColumn31.MappingName = "";
			this.dataGridTextBoxColumn31.NullText = "";
			this.dataGridTextBoxColumn31.ReadOnly = true;
			this.dataGridTextBoxColumn31.Width = 70;
			// 
			// dataGridTextBoxColumn33
			// 
			this.dataGridTextBoxColumn33.Format = "";
			this.dataGridTextBoxColumn33.FormatInfo = null;
			this.dataGridTextBoxColumn33.HeaderText = "零售价";
			this.dataGridTextBoxColumn33.MappingName = "";
			this.dataGridTextBoxColumn33.NullText = "";
			this.dataGridTextBoxColumn33.ReadOnly = true;
			this.dataGridTextBoxColumn33.Width = 60;
			// 
			// dataGridTextBoxColumn34
			// 
			this.dataGridTextBoxColumn34.Format = "";
			this.dataGridTextBoxColumn34.FormatInfo = null;
			this.dataGridTextBoxColumn34.HeaderText = "用量";
			this.dataGridTextBoxColumn34.MappingName = "";
			this.dataGridTextBoxColumn34.NullText = "";
			this.dataGridTextBoxColumn34.ReadOnly = true;
			this.dataGridTextBoxColumn34.Width = 55;
			// 
			// dataGridTextBoxColumn47
			// 
			this.dataGridTextBoxColumn47.Format = "";
			this.dataGridTextBoxColumn47.FormatInfo = null;
			this.dataGridTextBoxColumn47.HeaderText = "剂数";
			this.dataGridTextBoxColumn47.MappingName = "";
			this.dataGridTextBoxColumn47.NullText = "";
			this.dataGridTextBoxColumn47.ReadOnly = true;
			this.dataGridTextBoxColumn47.Width = 35;
			// 
			// dataGridTextBoxColumn35
			// 
			this.dataGridTextBoxColumn35.Format = "";
			this.dataGridTextBoxColumn35.FormatInfo = null;
			this.dataGridTextBoxColumn35.HeaderText = "单位";
			this.dataGridTextBoxColumn35.MappingName = "";
			this.dataGridTextBoxColumn35.NullText = "";
			this.dataGridTextBoxColumn35.ReadOnly = true;
			this.dataGridTextBoxColumn35.Width = 35;
			// 
			// dataGridTextBoxColumn37
			// 
			this.dataGridTextBoxColumn37.Format = "";
			this.dataGridTextBoxColumn37.FormatInfo = null;
			this.dataGridTextBoxColumn37.HeaderText = "零售金额";
			this.dataGridTextBoxColumn37.MappingName = "";
			this.dataGridTextBoxColumn37.NullText = "";
			this.dataGridTextBoxColumn37.ReadOnly = true;
			this.dataGridTextBoxColumn37.Width = 65;
			// 
			// dataGridTextBoxColumn57
			// 
			this.dataGridTextBoxColumn57.Format = "";
			this.dataGridTextBoxColumn57.FormatInfo = null;
			this.dataGridTextBoxColumn57.HeaderText = "用法";
			this.dataGridTextBoxColumn57.MappingName = "";
			this.dataGridTextBoxColumn57.NullText = "";
			this.dataGridTextBoxColumn57.ReadOnly = true;
			this.dataGridTextBoxColumn57.Width = 50;
			// 
			// dataGridTextBoxColumn58
			// 
			this.dataGridTextBoxColumn58.Format = "";
			this.dataGridTextBoxColumn58.FormatInfo = null;
			this.dataGridTextBoxColumn58.HeaderText = "频次";
			this.dataGridTextBoxColumn58.MappingName = "";
			this.dataGridTextBoxColumn58.NullText = "";
			this.dataGridTextBoxColumn58.ReadOnly = true;
			this.dataGridTextBoxColumn58.Width = 35;
			// 
			// dataGridTextBoxColumn59
			// 
			this.dataGridTextBoxColumn59.Format = "";
			this.dataGridTextBoxColumn59.FormatInfo = null;
			this.dataGridTextBoxColumn59.HeaderText = "天数";
			this.dataGridTextBoxColumn59.MappingName = "";
			this.dataGridTextBoxColumn59.NullText = "";
			this.dataGridTextBoxColumn59.ReadOnly = true;
			this.dataGridTextBoxColumn59.Width = 35;
			// 
			// dataGridTextBoxColumn60
			// 
			this.dataGridTextBoxColumn60.Format = "";
			this.dataGridTextBoxColumn60.FormatInfo = null;
			this.dataGridTextBoxColumn60.HeaderText = "皮试";
			this.dataGridTextBoxColumn60.MappingName = "";
			this.dataGridTextBoxColumn60.NullText = "";
			this.dataGridTextBoxColumn60.ReadOnly = true;
			this.dataGridTextBoxColumn60.Width = 35;
			// 
			// dataGridTextBoxColumn46
			// 
			this.dataGridTextBoxColumn46.Format = "";
			this.dataGridTextBoxColumn46.FormatInfo = null;
			this.dataGridTextBoxColumn46.HeaderText = "剂量";
			this.dataGridTextBoxColumn46.MappingName = "";
			this.dataGridTextBoxColumn46.Width = 40;
			// 
			// dataGridTextBoxColumn66
			// 
			this.dataGridTextBoxColumn66.Format = "";
			this.dataGridTextBoxColumn66.FormatInfo = null;
			this.dataGridTextBoxColumn66.HeaderText = "剂量单位";
			this.dataGridTextBoxColumn66.MappingName = "";
			this.dataGridTextBoxColumn66.NullText = "";
			this.dataGridTextBoxColumn66.Width = 60;
			// 
			// dataGridTextBoxColumn61
			// 
			this.dataGridTextBoxColumn61.Format = "";
			this.dataGridTextBoxColumn61.FormatInfo = null;
			this.dataGridTextBoxColumn61.HeaderText = "嘱托";
			this.dataGridTextBoxColumn61.MappingName = "";
			this.dataGridTextBoxColumn61.NullText = "";
			this.dataGridTextBoxColumn61.ReadOnly = true;
			this.dataGridTextBoxColumn61.Width = 60;
			// 
			// dataGridTextBoxColumn63
			// 
			this.dataGridTextBoxColumn63.Format = "";
			this.dataGridTextBoxColumn63.FormatInfo = null;
			this.dataGridTextBoxColumn63.HeaderText = "pcdm";
			this.dataGridTextBoxColumn63.MappingName = "";
			this.dataGridTextBoxColumn63.NullText = "";
			this.dataGridTextBoxColumn63.ReadOnly = true;
			this.dataGridTextBoxColumn63.Width = 0;
			// 
			// dataGridTextBoxColumn38
			// 
			this.dataGridTextBoxColumn38.Format = "";
			this.dataGridTextBoxColumn38.FormatInfo = null;
			this.dataGridTextBoxColumn38.HeaderText = "cfxh";
			this.dataGridTextBoxColumn38.MappingName = "";
			this.dataGridTextBoxColumn38.NullText = "";
			this.dataGridTextBoxColumn38.ReadOnly = true;
			this.dataGridTextBoxColumn38.Width = 0;
			// 
			// dataGridTextBoxColumn39
			// 
			this.dataGridTextBoxColumn39.Format = "";
			this.dataGridTextBoxColumn39.FormatInfo = null;
			this.dataGridTextBoxColumn39.HeaderText = "ypid";
			this.dataGridTextBoxColumn39.MappingName = "";
			this.dataGridTextBoxColumn39.NullText = "";
			this.dataGridTextBoxColumn39.ReadOnly = true;
			this.dataGridTextBoxColumn39.Width = 0;
			// 
			// dataGridTextBoxColumn40
			// 
			this.dataGridTextBoxColumn40.Format = "";
			this.dataGridTextBoxColumn40.FormatInfo = null;
			this.dataGridTextBoxColumn40.HeaderText = "ydwbl";
			this.dataGridTextBoxColumn40.MappingName = "";
			this.dataGridTextBoxColumn40.NullText = "";
			this.dataGridTextBoxColumn40.ReadOnly = true;
			this.dataGridTextBoxColumn40.Width = 0;
			// 
			// dataGridTextBoxColumn42
			// 
			this.dataGridTextBoxColumn42.Format = "";
			this.dataGridTextBoxColumn42.FormatInfo = null;
			this.dataGridTextBoxColumn42.HeaderText = "货号";
			this.dataGridTextBoxColumn42.MappingName = "";
			this.dataGridTextBoxColumn42.NullText = "";
			this.dataGridTextBoxColumn42.ReadOnly = true;
			this.dataGridTextBoxColumn42.Width = 60;
			// 
			// dataGridTextBoxColumn64
			// 
			this.dataGridTextBoxColumn64.Format = "";
			this.dataGridTextBoxColumn64.FormatInfo = null;
			this.dataGridTextBoxColumn64.HeaderText = "调价差额";
			this.dataGridTextBoxColumn64.MappingName = "";
			this.dataGridTextBoxColumn64.NullText = "";
			this.dataGridTextBoxColumn64.ReadOnly = true;
			this.dataGridTextBoxColumn64.Width = 0;
			// 
			// dataGridTextBoxColumn65
			// 
			this.dataGridTextBoxColumn65.Format = "";
			this.dataGridTextBoxColumn65.FormatInfo = null;
			this.dataGridTextBoxColumn65.HeaderText = "ID";
			this.dataGridTextBoxColumn65.MappingName = "";
			this.dataGridTextBoxColumn65.NullText = "";
			this.dataGridTextBoxColumn65.ReadOnly = true;
			this.dataGridTextBoxColumn65.Width = 0;
			// 
			// dataGridTextBoxColumn32
			// 
			this.dataGridTextBoxColumn32.Format = "";
			this.dataGridTextBoxColumn32.FormatInfo = null;
			this.dataGridTextBoxColumn32.HeaderText = "批发价";
			this.dataGridTextBoxColumn32.MappingName = "";
			this.dataGridTextBoxColumn32.NullText = "";
			this.dataGridTextBoxColumn32.ReadOnly = true;
			this.dataGridTextBoxColumn32.Width = 60;
			// 
			// dataGridTextBoxColumn36
			// 
			this.dataGridTextBoxColumn36.Format = "";
			this.dataGridTextBoxColumn36.FormatInfo = null;
			this.dataGridTextBoxColumn36.HeaderText = "批发金额";
			this.dataGridTextBoxColumn36.MappingName = "";
			this.dataGridTextBoxColumn36.NullText = "";
			this.dataGridTextBoxColumn36.ReadOnly = true;
			this.dataGridTextBoxColumn36.Width = 60;
			// 
			// dataGridTextBoxColumn67
			// 
			this.dataGridTextBoxColumn67.Format = "";
			this.dataGridTextBoxColumn67.FormatInfo = null;
			this.dataGridTextBoxColumn67.HeaderText = "使用频次";
			this.dataGridTextBoxColumn67.MappingName = "";
			this.dataGridTextBoxColumn67.NullText = "";
			this.dataGridTextBoxColumn67.Width = 75;
			// 
			// XH
			// 
			this.XH.Format = "";
			this.XH.FormatInfo = null;
			this.XH.HeaderText = "序号";
			this.XH.MappingName = "";
			this.XH.NullText = "";
			this.XH.ReadOnly = true;
			this.XH.Width = 50;
			// 
			// fph
			// 
			this.fph.Format = "";
			this.fph.FormatInfo = null;
			this.fph.HeaderText = "发票号";
			this.fph.MappingName = "";
			this.fph.NullText = "";
			this.fph.ReadOnly = true;
			this.fph.Width = 60;
			// 
			// je
			// 
			this.je.Format = "";
			this.je.FormatInfo = null;
			this.je.HeaderText = "金额";
			this.je.MappingName = "";
			this.je.NullText = "";
			this.je.ReadOnly = true;
			this.je.Width = 60;
			// 
			// xm
			// 
			this.xm.Format = "";
			this.xm.FormatInfo = null;
			this.xm.HeaderText = "项目";
			this.xm.MappingName = "";
			this.xm.NullText = "";
			this.xm.ReadOnly = true;
			this.xm.Width = 0;
			// 
			// brxm
			// 
			this.brxm.Format = "";
			this.brxm.FormatInfo = null;
			this.brxm.HeaderText = "姓名";
			this.brxm.MappingName = "";
			this.brxm.NullText = "";
			this.brxm.ReadOnly = true;
			this.brxm.Width = 60;
			// 
			// SFRQ
			// 
			this.SFRQ.Format = "";
			this.SFRQ.FormatInfo = null;
			this.SFRQ.HeaderText = "收费日期";
			this.SFRQ.MappingName = "";
			this.SFRQ.NullText = "";
			this.SFRQ.ReadOnly = true;
			this.SFRQ.Width = 70;
			// 
			// sfy
			// 
			this.sfy.Format = "";
			this.sfy.FormatInfo = null;
			this.sfy.HeaderText = "收费员";
			this.sfy.MappingName = "";
			this.sfy.NullText = "";
			this.sfy.ReadOnly = true;
			this.sfy.Width = 50;
			// 
			// PYR
			// 
			this.PYR.Format = "";
			this.PYR.FormatInfo = null;
			this.PYR.HeaderText = "配药人";
			this.PYR.MappingName = "";
			this.PYR.NullText = "";
			this.PYR.ReadOnly = true;
			this.PYR.Width = 50;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.chkprrintView);
			this.panel3.Controls.Add(this.chkprint);
			this.panel3.Controls.Add(this.button3);
			this.panel3.Controls.Add(this.button2);
			this.panel3.Controls.Add(this.butfy);
			this.panel3.Controls.Add(this.cmbpyr);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(347, 80);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(573, 48);
			this.panel3.TabIndex = 7;
			// 
			// chkprrintView
			// 
			this.chkprrintView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.chkprrintView.Location = new System.Drawing.Point(178, 24);
			this.chkprrintView.Name = "chkprrintView";
			this.chkprrintView.Size = new System.Drawing.Size(88, 21);
			this.chkprrintView.TabIndex = 6;
			this.chkprrintView.Text = "打印时预览";
			// 
			// chkprint
			// 
			this.chkprint.Checked = true;
			this.chkprint.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkprint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.chkprint.Location = new System.Drawing.Point(178, 7);
			this.chkprint.Name = "chkprint";
			this.chkprint.Size = new System.Drawing.Size(104, 21);
			this.chkprint.TabIndex = 5;
			this.chkprint.Text = "发药打印清单";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(445, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(67, 24);
			this.button3.TabIndex = 4;
			this.button3.Text = "退出(&Q)";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(371, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(69, 24);
			this.button2.TabIndex = 3;
			this.button2.Text = "打印(&P)";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// butfy
			// 
			this.butfy.BackColor = System.Drawing.SystemColors.Control;
			this.butfy.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.butfy.Location = new System.Drawing.Point(283, 8);
			this.butfy.Name = "butfy";
			this.butfy.Size = new System.Drawing.Size(85, 24);
			this.butfy.TabIndex = 2;
			this.butfy.Text = "发药确认(&O)";
			this.butfy.Click += new System.EventHandler(this.butfy_Click);
			// 
			// cmbpyr
			// 
			this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbpyr.Location = new System.Drawing.Point(49, 14);
			this.cmbpyr.Name = "cmbpyr";
			this.cmbpyr.Size = new System.Drawing.Size(119, 20);
			this.cmbpyr.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "配药人";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.myDataGrid2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(347, 128);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(573, 192);
			this.panel4.TabIndex = 8;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.myDataGrid3);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(347, 320);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(573, 237);
			this.panel5.TabIndex = 9;
			// 
			// Frmmzfy
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(920, 557);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.KeyPreview = true;
			this.Name = "Frmmzfy";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Frmmzfy_Closing);
			this.Load += new System.EventHandler(this.Frmmzfy_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frmmzfy_KeyUp);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void Frmmzfy_Load(object sender, System.EventArgs e)
		{

			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");
			
			//初始化已发药处方
			FunBase.CsDataGrid(this.myDataGrid2,this.myDataGrid2.TableStyles[0],"Tb2");

			FunBase.CsDataGrid(this.myDataGrid3,this.myDataGrid3.TableStyles[0],"myfp");


			//添加配药人
			Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId,this.cmbpyr);

			this.dtpfyrq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			
			//网址地址
			IPAddRess=PubStaticFun.GetMacAddress();
//////////			//发药窗口
//////////			_Fyckh=MZYF_FY.SeekFychk(IPAddRess);

			 s=new YpConfig(InstanceForm.BCurrentDept.DeptId);
			//配药模式下更新当前窗口的使用状态 
//////////			if (s.配药模式==true)  MZYF_FY.UpateCkSybz(IPAddRess,1);
//////////
//////////			if (s.配药模式==true ){chkall.Checked=false; chkall.Visible=true;} else {chkall.Checked=false;chkall.Visible=false;}


		}

		
		private void patientInfo1_IDTextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				if (Convert.ToInt32(e.KeyChar)==13)
				{
					if (this.patientInfo1.PatientRegisterID<=0) return;
					this.Cursor=PubStaticFun.WaitCursor();
					
					//挂号序号  和  发票号查询
					if (this.patientInfo1.SearchIDType==PatientInfo.IDType.RegisterID )
						SelectCf_Cfmx(Convert.ToInt64(Convertor.IsNull(0,"0")));
					else
					    SelectCf_Cfmx(Convert.ToInt64(Convertor.IsNull(this.patientInfo1.PatientInvoiceID,"0")));

					DataTable tb2=(DataTable)this.myDataGrid2.DataSource;
					
					if (tb2.Rows.Count!=0)
					{
						this.butfy.Focus();
						return;
					}
					else
					{

						if (chkfybz.Checked==true)
						{
							MessageBox.Show("没有找到处方!可能这张处方还没发药，请在未发药处方中查询！","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							return;
						}
						else
						{
							MessageBox.Show("没有找到处方!可能这张处方已经发药，请在已发药处方中查询！","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							return;
						}
					}
					
				}
			}
			catch(System.Exception err)
			{
				DataTable tb=(DataTable)this.myDataGrid2.DataSource;
				DataTable tb1=(DataTable)this.myDataGrid3.DataSource;
				tb.Rows.Clear();
				tb1.Rows.Clear();
				MessageBox.Show("发生错误"+err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}

		}

	
		private void SelectCf_Cfmx(long fph)
		{
			DataTable tbcfmx=(DataTable)this.myDataGrid2.DataSource;
			tbcfmx.Rows.Clear();
			DataTable tbcf=(DataTable)this.myDataGrid3.DataSource;
			tbcf.Rows.Clear();

			if (fph!=-1) 
			{
				DataTable tb=MZYF.SelectMzcfk(_menuTag.Function_Name,InstanceForm.BCurrentDept.DeptId,patientInfo1.PatientRegisterID,"",
					fph,0,
					"","",0,Convert.ToInt16(this.chkfybz.Checked),"","","",0,"","",0,0,"","","",0,0,Convert.ToInt32(this.chkbk.Checked));

				tb.TableName="Tb2";
				this.myDataGrid2.DataSource=tb;
				this.myDataGrid2.TableStyles[0].MappingName="Tb2";

				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					DataTable tb1=MZYF.SelectMzcfmxk(_menuTag.Function_Name,Convert.ToInt64(tb.Rows[i]["xh"]),Convert.ToInt64(tb.Rows[i]["发票号"]),Convert.ToInt32(this.chkbk.Checked));
					int nrow=0;
					decimal sumlsje=0;
					for(int j=0;j<=tb1.Rows.Count-1;j++)
					{
						sumlsje=sumlsje+Convert.ToDecimal(tb1.Rows[j]["零售金额"]);
					}

					
//					tb1.TableName="mzfp";
//					this.myDataGrid3.DataSource=tb1;
//					this.myDataGrid3.TableStyles[0].MappingName="mzfp";


					DataTable tbmx=(DataTable)this.myDataGrid3.DataSource;
					
					for(int x=0;x<=tb1.Rows.Count-1;x++)
						tbmx.ImportRow(tb1.Rows[x]);
					
					if (tb1.Rows.Count!=0)
					{
						DataRow sumrow=tbmx.NewRow();
						sumrow["序号"]="小计";
						sumrow["发药"]=(short)(0);
						sumrow["零售金额"]=sumlsje.ToString("0.00");
						tbmx.Rows.Add(sumrow);
					}

				}
			}
		}

	
		//刷新按钮
		private void butref_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				int pybz=0;string fyckdm="";string qrrq="";
				qrrq=dtpfyrq.Value.ToShortDateString();
				if (s.配药模式==true && chkall.Checked==false ){ pybz=1;fyckdm=_Fyckh;}
				if (s.配药模式==true && chkall.Checked==true ){ pybz=0;fyckdm="";}

				DataTable tb=MZYF.SelectMzcfk("Fun_ts_yf_mzfy_butref",InstanceForm.BCurrentDept.DeptId,0,"",
					0,0,
					qrrq,qrrq,0,Convert.ToInt16(this.chkfybz.Checked),fyckdm,"","",0,"","",0,pybz,"","","",0,0,Convert.ToInt32(this.chkbk.Checked));

				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
				this.myDataGrid1.TableStyles[0].MappingName="Tb";
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

	
		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (nrow>tb.Rows.Count-1) return;

				long values=0;
				if (this.patientInfo1.SearchIDType==PatientInfo.IDType.RegisterID )
				{
					values=this.patientInfo1.PatientRegisterID;
					this.patientInfo1.LoadPatient(values.ToString().Trim());
					SelectCf_Cfmx(0);
				}
				else
				{
					values=Convert.ToInt64(Convertor.IsNull(tb.Rows[nrow]["发票号"],"0"));
					this.patientInfo1.LoadPatient(values.ToString().Trim());
					SelectCf_Cfmx(values);
				}

				
//				this.patientInfo1_IDTextBoxKeyPress(sender,new KeyPressEventArgs((char)13));
				
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}


		//发药确认
		private void butfy_Click(object sender, System.EventArgs e)
		{
			if (s.配药模式==true && this._Fyckh.Trim()==""){MessageBox.Show("系统当前处于配药模式，当前窗口必须设置！","发药",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return;};
			if (s.系统启用==false){MessageBox.Show("系统未启用"); return;}
			if (s.禁用系统==true){MessageBox.Show("系统被管理员禁用"); return;}

			string _pronamefy="";string _pronamefymx="";
			if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_mzfy")
			{
				_pronamefy="sp_yf_fy";
				_pronamefymx="sp_yf_fymx";
			}
			else
			{
				_pronamefy="sp_yk_fy";
				_pronamefymx="sp_yk_fymx";
			}

			if (cmbpyr.Text.Trim()==""){MessageBox.Show("请选择配药人！","发药",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return;}

			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();;
			long fyid=0;
			long fymxid=0;
			int err_code=-1;
			string err_text="";

			DataTable tb=(DataTable)this.myDataGrid2.DataSource;
			DataTable tbmx=(DataTable)this.myDataGrid3.DataSource;
			if (tbmx.Rows.Count==0){MessageBox.Show("没有可以发药的处方明细！","发药",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return;}

			this.Cursor=PubStaticFun.WaitCursor();
			
			try
			{
				this.butfy.Enabled=false;
				
				InstanceForm.BDatabase.BeginTransaction();

				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (Convert.ToInt16(tb.Rows[i]["发药"])==1)
					{
						//if (tb.Rows[i]["发费日期"].ToString().Trim().Length>1) throw new System.Exception("对不起,这个处方已发药不能再发");
					
						#region 插入发药头表
						MZYF.SaveFy(tb.Rows[i]["cflx"].ToString(),
							Convert.ToDecimal(tb.Rows[i]["jssjh"]),
							Convert.ToInt64(Convertor.IsNull(tb.Rows[i]["发票号"],"0")),
							Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["金额"],"0")),
							Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["记帐金额"],"0")),
							Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["优惠金额"],"0")),
							Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["自付金额"],"0")),
							Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["剂数"],"0")),
							Convert.ToInt64(tb.Rows[i]["xh"]),
							Convert.ToInt64(Convertor.IsNull(tb.Rows[i]["patid"],"0")),
							"",
							tb.Rows[i]["姓名"].ToString(),
							Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["ysdm"],"0")),
							Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["ksdm"],"0")),
							tb.Rows[i]["收费日期"].ToString(),
							Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["sky"],"0")),
							sDate,
							InstanceForm.BCurrentUser.EmployeeId,
							Convert.ToInt32(cmbpyr.SelectedValue),
							Convertor.IsNull(tb.Rows[i]["pyckh"],"0"),
							_Fyckh,
							InstanceForm.BCurrentDept.DeptId,0,_menuTag.FunctionTag,0,_pronamefy,out fyid,out err_code,out err_text);
						if (err_code!=0 || fyid==0){throw new System.Exception(err_text);}
						this.butfy.Tag=fyid.ToString();
						#endregion 

						#region 插入发药明细
						for (int j=0;j<=tbmx.Rows.Count-1;j++)
						{	
							if (Convert.ToInt64(Convertor.IsNull(tbmx.Rows[j]["cfxh"],"0"))==Convert.ToInt64(tb.Rows[i]["xh"]))
							{
								long xh=Convert.ToInt64(Convertor.IsNull(tb.Rows[i]["xh"],"0"));
								long cfxh=Convert.ToInt64(Convertor.IsNull(tbmx.Rows[j]["cfxh"],"0"));
								if (xh==cfxh && cfxh>0)
								{
									MZYF.SaveFymx(fyid,
										Convert.ToInt64(Convertor.IsNull(tb.Rows[i]["发票号"],"0")),
										xh,
										Convert.ToInt32(Convertor.IsNull(tbmx.Rows[j]["ypid"],"0")),
										tbmx.Rows[j]["货号"].ToString(),
										tbmx.Rows[j]["药品名称"].ToString(),
										tbmx.Rows[j]["药品名称"].ToString(),
										tbmx.Rows[j]["规格"].ToString(),
										tbmx.Rows[j]["厂家"].ToString(),
										tbmx.Rows[j]["单位"].ToString(),
										Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[j]["ydwbl"],"0")),
										Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[j]["用量"],"0")),
										Convert.ToInt32(Convertor.IsNull(tbmx.Rows[j]["剂数"],"0")),
										Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[j]["批发价"],"0")),
										Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[j]["批发金额"],"0")),
										Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[j]["零售价"],"0")),
										Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[j]["零售金额"],"0")),
										0,
										0,
										InstanceForm.BCurrentDept.DeptId,
										0,
										"",
										0,
										Convert.ToInt64(Convertor.IsNull(tbmx.Rows[j]["id"],"0")),
										_pronamefymx,
										out fymxid,
										out err_code,
										out err_text);
									if (err_code!=0){throw new System.Exception(err_text);}				
					  
													  
								}
							}
						}
						#endregion 

					}
				}

				//提交事务
				InstanceForm.BDatabase.CommitTransaction();

				MessageBox.Show("发药成功！","发药",MessageBoxButtons.OK,MessageBoxIcon.Information);
				
				//打印并清除网格
				if (chkprint.Checked==true) this.button2_Click(sender,e);
				DataTable tb2=(DataTable)this.myDataGrid2.DataSource;
				DataTable tb3=(DataTable)this.myDataGrid3.DataSource;
				tb2.Rows.Clear();
				tb3.Rows.Clear();
				this.butfy.Enabled=true;
				if (chkref.Checked==true) this.butref_Click(sender,e);
				this.patientInfo1.SetFocus();

			}
			catch(System.Exception err)
			{
				this.butfy.Enabled=true;
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}


		//窗体键盘事件 F1刷新
		private void Frmmzfy_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (Convert.ToInt32(e.KeyCode)==112)
			{
				this.butref_Click(sender,e);
			}
		}

		//退出
		private void button3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//发药选项框的改变事件
		private void chkfybz_CheckedChanged(object sender, System.EventArgs e)
		{
			this.butfy.Enabled=this.chkfybz.Checked==true?false:true;
			DataTable tb2=(DataTable)this.myDataGrid2.DataSource;
			tb2.Rows.Clear();
			DataTable tb3=(DataTable)this.myDataGrid3.DataSource;
			tb3.Rows.Clear();
			if (this.chkfybz.Checked==true) this.myDataGrid1.CaptionText="已发药处方列表"; else this.myDataGrid1.CaptionText="待发药处方列表";
			this.patientInfo1.SetFocus();
		}

		//关闭窗口事件//更新当前窗口的使用状态
		private void Frmmzfy_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if (s.配药模式==true)
				{
//////////////					MZYF_FY.UpateCkSybz(IPAddRess,0);
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}
	
		}

		//更新当前窗口的使用状态
		private void Frmmzfy_Activated(object sender, System.EventArgs e)
		{
			try
			{
				if (s.配药模式==true)
				{
//////////					MZYF_FY.UpateCkSybz(IPAddRess,0);
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}
		}

		//打印处方
		private void button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb2=(DataTable)this.myDataGrid2.DataSource;
				if (tb2.Rows.Count==0)  {MessageBox.Show("没有可以打印的处方");return;}
				DataTable tb3=(DataTable)this.myDataGrid3.DataSource;
				if (tb3.Rows.Count<=1) {MessageBox.Show("没有可以打印的处方明细");return;}

				for (int i=0;i<=tb2.Rows.Count-1;i++)
				{ 
					if (Convert.ToInt16(tb2.Rows[i]["发药"])==1)
					  PrintCf(tb2.Rows[i]);
				}
				
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		
		}

		//打印方法
		private void PrintCf(DataRow row)
		{
			DataTable tb2=(DataTable)this.myDataGrid3.DataSource;
			string cftsname="";
			cftsname=Convert.ToString(row["项目"]).Trim()=="中草药"?"中药付数":"";
			ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
			DataRow myrow;
			for(int i=0;i<=tb2.Rows.Count-1;i++)
			{
				if (tb2.Rows[i]["序号"].ToString().Trim()!="小计" && Convert.ToInt64(tb2.Rows[i]["cfxh"])==Convert.ToInt64(row["xh"]))
				{
					myrow=Dset.病人处方清单.NewRow();
					myrow["xh"]=Convert.ToInt32(tb2.Rows[i]["序号"]);
					myrow["ypmc"]=Convert.ToString(tb2.Rows[i]["药品名称"]);
					myrow["ypgg"]=Convert.ToString(tb2.Rows[i]["规格"]);
					myrow["sccj"]=Convert.ToString(tb2.Rows[i]["厂家"]);
					myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb2.Rows[i]["零售价"],"0"));
					myrow["ypsl"]=Convert.ToDecimal(Convertor.IsNull(tb2.Rows[i]["用量"],"0"));
					myrow["ypdw"]=Convert.ToString(tb2.Rows[i]["单位"]);
					myrow["cfts"]=Convert.ToString(row["项目"]).Trim()=="中草药"?tb2.Rows[i]["剂数"]+"剂":"";
					myrow["lsje"]=Convert.ToDecimal(Convertor.IsNull(tb2.Rows[i]["零售金额"],"0"));
					string UserEat="";
					UserEat=Convert.ToInt32(Convertor.IsNull(tb2.Rows[i]["PCDM"],"0"))<=0?"":Convert.ToDouble(tb2.Rows[i]["剂量"]).ToString()+tb2.Rows[i]["剂量单位"].ToString().Trim()+"/每次";
					myrow["yf"]=Convert.ToString(tb2.Rows[i]["用法"])+"  "+tb2.Rows[i]["使用频次"].ToString().Trim()+" "+UserEat;
					myrow["pc"]= tb2.Rows[i]["使用频次"].ToString().Trim();
					myrow["syjl"]="";
					myrow["zt"]=Convert.ToString(tb2.Rows[i]["嘱托"]);
					myrow["shh"]=Convert.ToString(tb2.Rows[i]["货号"]);
					myrow["ksname"]=Convert.ToString(row["科室"])+"  费别:"+this.patientInfo1.FeeTypeName;
					string ysqm="";
					if (Convert.ToString(row["医生签名"]).Trim()!="")  ysqm="   医生签名:"+Convert.ToString(row["医生签名"]);
					myrow["ysname"]=Convert.ToString(row["医生"])+ysqm;
					myrow["Pyck"]=tb2.Rows[i]["皮试"].ToString();
					myrow["fph"]=Convert.ToString(row["发票号"]);
					myrow["hzxm"]=Convert.ToString(row["姓名"]);
					myrow["sex"]=Convert.ToString(row["性别"]);
					myrow["age"]=Convert.ToString(row["年龄"]);
					myrow["blh"]=Convert.ToString(row["病历号"]);
					myrow["sfrq"]=Convert.ToString(row["发票日期"]);
					myrow["pyr"]=this.cmbpyr.Text.Trim();;
					myrow["fyr"]=InstanceForm.BCurrentUser.Name;
					Dset.病人处方清单.Rows.Add(myrow);
				}

			}

			ParameterEx[] parameters=new ParameterEx[4];
			parameters[0].Text="cfts";
			parameters[0].Value=cftsname;
			parameters[1].Text="zje";
			parameters[1].Value=Convert.ToDecimal(Convertor.IsNull(row["金额"],"0"));
			parameters[2].Text="TITLETEXT";
			parameters[2].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+"处方明细单";
			parameters[3].Text="text1";
			parameters[3].Value="发药单位:"+InstanceForm.BCurrentDept.DeptName+"    诊断:"+this.patientInfo1.PatientDiagnose;
			bool bview=this.chkprrintView.Checked==true?false:true;
			TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单,Constant.ApplicationDirectory+"\\Report\\YF_病人处方清单.rpt",parameters);
			if (f.LoadReportSuccess) f.Show();else  f.Dispose();

		}

		private void myDataGrid2_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

		private void myDataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}
	

		
	}
}
