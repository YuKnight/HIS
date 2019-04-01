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

namespace ts_yk_fkqr
{
	/// <summary>
	/// Frmkccx 的摘要说明。
	/// </summary>
	public class Frmyedj_mx : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
        private Form _mdiParent;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private YpConfig s;
        private DataGridTextBoxColumn dataGridTextBoxColumn23;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label lblghdw;
        private Label label5;
        private Label lbldjy;
        private Label label9;
        private Label lbldjsj;
        private Label label7;
        private Button button2;
        private Button button1;
        private TextBox txtye;
        private Button button3;
        private DataGridTextBoxColumn dataGridTextBoxColumn9;
        private DataGridTextBoxColumn dataGridTextBoxColumn6;
        private DataGridTextBoxColumn dataGridTextBoxColumn7;
        private DataGridTextBoxColumn dataGridTextBoxColumn8;
        private DataGridTextBoxColumn dataGridTextBoxColumn10;
        private DataGridBoolColumn dataGridBoolColumn1;
        private CheckBox checkBox1;
        private ComboBox cmbywy;
        private string _Table;
        private RadioButton rdo1;
        private RadioButton rdo2;
        private DateTimePicker dtpdjsj2;
        private Label lbld;
        private DateTimePicker dtpdjsj1;
        private CheckBox chkdjsj;
        private Button butcx;
        private Label label2;
        private TextBox txtbz;
        private long _id;
        private Label lblwfk;
        private Label label4;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmyedj_mx(MenuTag menuTag,string chineseName,Form mdiParent)
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
			s=new YpConfig(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase);
            if (YpConfig.是否药库(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase) == true) _Table = "vi_yk_dj"; else _Table = "vi_yf_dj";

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
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.cmbywy = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtye = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbldjy = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbldjsj = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblghdw = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butcx = new System.Windows.Forms.Button();
            this.dtpdjsj2 = new System.Windows.Forms.DateTimePicker();
            this.lbld = new System.Windows.Forms.Label();
            this.dtpdjsj1 = new System.Windows.Forms.DateTimePicker();
            this.chkdjsj = new System.Windows.Forms.CheckBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.lblwfk = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(864, 423);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn10});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.Width = 35;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.FalseValue = ((short)(0));
            this.dataGridBoolColumn1.HeaderText = "选";
            this.dataGridBoolColumn1.NullText = "0";
            this.dataGridBoolColumn1.NullValue = ((short)(0));
            this.dataGridBoolColumn1.TrueValue = ((short)(1));
            this.dataGridBoolColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "供货单位";
            this.dataGridTextBoxColumn15.Width = 140;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "业务员";
            this.dataGridTextBoxColumn16.Width = 60;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "单据号";
            this.dataGridTextBoxColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "单据号X";
            this.dataGridTextBoxColumn9.Width = 70;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "单据日期";
            this.dataGridTextBoxColumn5.Width = 120;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "进货金额";
            this.dataGridTextBoxColumn23.Width = 80;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "送货单号";
            this.dataGridTextBoxColumn6.Width = 80;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "发票号";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "发票日期";
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "登记时间";
            this.dataGridTextBoxColumn3.Width = 120;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "登记员";
            this.dataGridTextBoxColumn4.Width = 60;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "id";
            this.dataGridTextBoxColumn10.Width = 0;
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
            this.statusBar1.Size = new System.Drawing.Size(864, 24);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.lblwfk);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtbz);
            this.panel1.Controls.Add(this.cmbywy);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.txtye);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbldjy);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lbldjsj);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblghdw);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 86);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 93;
            this.label2.Text = "备注";
            // 
            // txtbz
            // 
            this.txtbz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtbz.Location = new System.Drawing.Point(368, 46);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(158, 21);
            this.txtbz.TabIndex = 92;
            // 
            // cmbywy
            // 
            this.cmbywy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbywy.Enabled = false;
            this.cmbywy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cmbywy.FormattingEnabled = true;
            this.cmbywy.Location = new System.Drawing.Point(342, 16);
            this.cmbywy.Name = "cmbywy";
            this.cmbywy.Size = new System.Drawing.Size(84, 20);
            this.cmbywy.TabIndex = 91;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(601, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 32);
            this.button3.TabIndex = 89;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtye
            // 
            this.txtye.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtye.Location = new System.Drawing.Point(483, 16);
            this.txtye.Name = "txtye";
            this.txtye.Size = new System.Drawing.Size(81, 21);
            this.txtye.TabIndex = 88;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(669, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 32);
            this.button2.TabIndex = 87;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(532, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 32);
            this.button1.TabIndex = 86;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbldjy
            // 
            this.lbldjy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbldjy.Location = new System.Drawing.Point(260, 48);
            this.lbldjy.Name = "lbldjy";
            this.lbldjy.Size = new System.Drawing.Size(68, 20);
            this.lbldjy.TabIndex = 85;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 84;
            this.label9.Text = "登记员";
            // 
            // lbldjsj
            // 
            this.lbldjsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjsj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbldjsj.Location = new System.Drawing.Point(80, 48);
            this.lbldjsj.Name = "lbldjsj";
            this.lbldjsj.Size = new System.Drawing.Size(138, 20);
            this.lbldjsj.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 82;
            this.label7.Text = "登记时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 80;
            this.label5.Text = "结存金额";
            // 
            // lblghdw
            // 
            this.lblghdw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblghdw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblghdw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblghdw.Location = new System.Drawing.Point(80, 17);
            this.lblghdw.Name = "lblghdw";
            this.lblghdw.Size = new System.Drawing.Size(206, 20);
            this.lblghdw.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "供货单位";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(289, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 90;
            this.checkBox1.Text = "业务员";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpdjsj1);
            this.panel2.Controls.Add(this.chkdjsj);
            this.panel2.Controls.Add(this.butcx);
            this.panel2.Controls.Add(this.dtpdjsj2);
            this.panel2.Controls.Add(this.lbld);
            this.panel2.Controls.Add(this.rdo2);
            this.panel2.Controls.Add(this.rdo1);
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 423);
            this.panel2.TabIndex = 3;
            // 
            // butcx
            // 
            this.butcx.Location = new System.Drawing.Point(672, 1);
            this.butcx.Name = "butcx";
            this.butcx.Size = new System.Drawing.Size(65, 26);
            this.butcx.TabIndex = 45;
            this.butcx.Text = "查询";
            this.butcx.UseVisualStyleBackColor = true;
            this.butcx.Visible = false;
            this.butcx.Click += new System.EventHandler(this.butcx_Click);
            // 
            // dtpdjsj2
            // 
            this.dtpdjsj2.Enabled = false;
            this.dtpdjsj2.Location = new System.Drawing.Point(556, 6);
            this.dtpdjsj2.Name = "dtpdjsj2";
            this.dtpdjsj2.Size = new System.Drawing.Size(110, 21);
            this.dtpdjsj2.TabIndex = 43;
            this.dtpdjsj2.Visible = false;
            // 
            // lbld
            // 
            this.lbld.Location = new System.Drawing.Point(539, 10);
            this.lbld.Name = "lbld";
            this.lbld.Size = new System.Drawing.Size(24, 16);
            this.lbld.TabIndex = 44;
            this.lbld.Text = "到";
            this.lbld.Visible = false;
            // 
            // dtpdjsj1
            // 
            this.dtpdjsj1.Enabled = false;
            this.dtpdjsj1.Location = new System.Drawing.Point(428, 6);
            this.dtpdjsj1.Name = "dtpdjsj1";
            this.dtpdjsj1.Size = new System.Drawing.Size(111, 21);
            this.dtpdjsj1.TabIndex = 42;
            this.dtpdjsj1.Visible = false;
            // 
            // chkdjsj
            // 
            this.chkdjsj.Location = new System.Drawing.Point(360, 5);
            this.chkdjsj.Name = "chkdjsj";
            this.chkdjsj.Size = new System.Drawing.Size(80, 22);
            this.chkdjsj.TabIndex = 41;
            this.chkdjsj.Text = "登记日期";
            this.chkdjsj.Visible = false;
            this.chkdjsj.CheckedChanged += new System.EventHandler(this.chkdjsj_CheckedChanged);
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Location = new System.Drawing.Point(197, 7);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(131, 16);
            this.rdo2.TabIndex = 2;
            this.rdo2.Text = "查询并标记付款状态";
            this.rdo2.UseVisualStyleBackColor = true;
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(12, 7);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(179, 16);
            this.rdo1.TabIndex = 1;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "以下单据不计算在应付帐款内";
            this.rdo1.UseVisualStyleBackColor = true;
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // lblwfk
            // 
            this.lblwfk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblwfk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblwfk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblwfk.Location = new System.Drawing.Point(652, 17);
            this.lblwfk.Name = "lblwfk";
            this.lblwfk.Size = new System.Drawing.Size(68, 20);
            this.lblwfk.TabIndex = 95;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(565, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 94;
            this.label4.Text = "系统当前未付款";
            // 
            // Frmyedj_mx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(864, 533);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Name = "Frmyedj_mx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "应付款余额登记";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmkccx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


		private void Frmkccx_Load(object sender, System.EventArgs e)
		{
            //this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            //this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");
            
		}

        public void Filldj(int ghdw,int ywy,long id)
        {

            _id = id;
            string ssql="";
            lblghdw.Text = Yp.SeekGhdw(ghdw, InstanceForm.BDatabase);
            Yp.AddcmbYwy(ghdw, cmbywy, InstanceForm.BDatabase);

            //添加已付款的记录
            ssql = "select '0' 序号,cast(1 as smallint) 选,dbo.fun_yp_ghdw(wldw) 供货单位,dbo.fun_yp_ywy(jsr) 业务员,djh 单据号,sdjh 单据号X,rq 日期,sumjhje 进货金额,"+
                " shdh 送货单号,fph 发票号,fprq 发票日期,djrq 登记时间,dbo.fun_getempname(a.djy) 登记员,id from "+_Table+" a,YP_FKJL B where a.id=b.djid and b.bdelete=0 and jllx=1";
            if (id != 0)
                ssql = ssql + " and fid=" + id + "";
            else
            {
                ssql = ssql + " and a.wldw=" + ghdw + "";
                if (ywy != 0) ssql = ssql + " and jsr=" + ywy + " ";
            }
            ssql = ssql + " order by a.id";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            FunBase.AddRowtNo(tb);
            tb.TableName = "Tb";
            this.myDataGrid1.DataSource = tb;
            //初始化其它信息
            if (id != 0)
            {
                ssql = "select * from yp_fkqcjc where id=" + id + "";
                tb = InstanceForm.BDatabase.GetDataTable(ssql);
                lblghdw.Text = Yp.SeekGhdw(Convert.ToInt32(tb.Rows[0]["ghdw"]), InstanceForm.BDatabase);
                lblghdw.Tag = tb.Rows[0]["ghdw"].ToString();
                cmbywy.SelectedValue = tb.Rows[0]["ywy"].ToString();
                cmbywy.Enabled = false;
                checkBox1.Enabled = false;
                checkBox1.Checked=Convert.ToInt32(tb.Rows[0]["ywy"])>0?true:false;
                txtye.Text = tb.Rows[0]["qcye"].ToString();
                lbldjsj.Text = tb.Rows[0]["djsj"].ToString();
                lbldjy.Text = Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["djy"]), InstanceForm.BDatabase);
                txtbz.Text = tb.Rows[0]["bz"].ToString();
            }
            else
            {
                lblghdw.Text = Yp.SeekGhdw(ghdw, InstanceForm.BDatabase);
                lblghdw.Tag = ghdw.ToString();
                txtye.Text = "";
                lbldjsj.Text = "";
                lbldjy.Text = "";
                txtbz.Text = "";
            }
               

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cmbywy.Enabled = checkBox1.Checked == true ? true : false;
        }

        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkdjsj.Visible = rdo2.Checked == true ? true : false;
                dtpdjsj1.Visible = rdo2.Checked == true ? true : false;
                dtpdjsj2.Visible = rdo2.Checked == true ? true : false;
                lbld.Visible = rdo2.Checked == true ? true : false;
                butcx.Visible = rdo2.Checked == true ? true : false;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                tb.Rows.Clear();
                int ywy = 0;
                if (checkBox1.Checked == true) ywy = Convert.ToInt32(Convertor.IsNull(cmbywy.SelectedValue, "0"));

                if (rdo1.Checked == true)
                    Filldj(Convert.ToInt32(Convertor.IsNull(lblghdw.Tag,"0")), ywy, _id);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                string ssql = "";
                ssql = "select '0' 序号,cast(1 as smallint) 选,dbo.fun_yp_ghdw(wldw) 供货单位,dbo.fun_yp_ywy(jsr) 业务员,djh 单据号,sdjh 单据号X,rq 日期,sumjhje 进货金额," +
                 " shdh 送货单号,fph 发票号,fprq 发票日期,djrq 登记时间,dbo.fun_getempname(djy) 登记员,id from " + _Table +
                 " a where shbz=1 and id not in(select djid from yp_fkjl) and wldw=" + Convert.ToInt32(Convertor.IsNull(lblghdw.Tag, "0")) + "";
                if (chkdjsj.Checked == true)
                    ssql = ssql + " and djrq>='" + dtpdjsj1.Value.ToShortDateString() + " 00:00:00' and djrq<='" + dtpdjsj2.Value.ToShortDateString() + " 23:59:59'";
                if (checkBox1.Enabled == true && checkBox1.Checked == true)
                    ssql = ssql + " and jsr=" + Convert.ToInt32(Convertor.IsNull(cmbywy.SelectedValue, "0")) + "";
                ssql = ssql + " order by id";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                tb.TableName = "Tb";
                FunBase.AddRowtNo(tb);
                this.myDataGrid1.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tbmx = (DataTable)this.myDataGrid1.DataSource;
            //供货单位
            int ghdw = 0;
            ghdw = Convert.ToInt32(lblghdw.Tag);

            //业务员
            int ywy=0;
            if (checkBox1.Checked==true)
                ywy=Convert.ToInt32(cmbywy.SelectedValue);

            //余额
            if (Convertor.IsNumeric(txtye.Text.Trim()) == false)
            {
                MessageBox.Show("余额必需输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
            decimal ye=0;
            ye=Convert.ToDecimal(Convertor.IsNull(txtye.Text,"0"));

            //时间
            string sdate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            //判断是否存在同一户头
            string ssql = "";
            ssql = "select  * from yp_fkqcjc where ghdw=" + ghdw + " and ywy=" + ywy + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            
            //Fid
            long Fid = 0;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                if (_id == 0)
                {
                    string bz = this.checkBox1.Checked == true ? cmbywy.Text.Trim() : "";
                    DataTable tbid = null;
                    if (tb.Rows.Count == 0)
                    {
                        ssql = "insert into yp_fkqcjc(ghdw,ywy,qcye,djsj,djy,bz)values(" + Convert.ToInt32(lblghdw.Tag) +
                            "," + ywy + "," + ye + ",'" + sdate + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + txtbz.Text.Trim() + "')";
                        InstanceForm.BDatabase.DoCommand(ssql);

                        ssql = "select @@IDENTITY";
                        tbid = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tbid.Rows.Count == 0)
                            throw new Exception("在插入" + lblghdw.Text.Trim() + "  " + bz + " 这个户头时出错,请和管理员联系");
                        Fid = Convert.ToInt64(tbid.Rows[0][0]);
                        _id = Fid;
                    }
                    else
                    {
                        throw new Exception("在余额登记表中已" + lblghdw.Text.Trim() + "  " + bz + " 这个户头了,请重新确认");
                    }

                }
                else
                {
                    if (tb.Rows.Count != 0 && tb.Rows[0]["id"].ToString() != _id.ToString())
                    {
                        string bz = this.checkBox1.Checked == true ? cmbywy.Text.Trim() : "";
                        throw new Exception("在余额登记表中已" + lblghdw.Text.Trim() + "  " + bz + " 这个户头了,请重新确认");
                    }
                    ssql = "update yp_fkqcjc set ywy=" + ywy + ",qcye=" + ye + ",bz='" + txtbz.Text.Trim() + "' where id=" + _id + "";
                    InstanceForm.BDatabase.DoCommand(ssql);

                    Fid = _id;
                }


                //插入屏幕的记录
                for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt16(tbmx.Rows[i]["选"]) == 1)
                    {
                        ssql = "insert into yp_fkjl(Fid,djid,fkje,djsj,djy,bz,jllx)values(" + Fid +
                            "," + Convert.ToInt64(tbmx.Rows[i]["id"]) + "," + Convert.ToDecimal(tbmx.Rows[i]["进货金额"]) +
                            ",'" + sdate + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'',1)";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }
                }

                InstanceForm.BDatabase.CommitTransaction();
                butcx_Click(sender, e);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }

        private void myDataGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].HeaderText == "选" && rdo2.Checked == true)
                {
                    tb.Rows[nrow][ncol] = Convert.ToBoolean(tb.Rows[nrow][ncol]) == true ? 0 : 1;
                }

                if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].HeaderText == "选" && rdo1.Checked == true)
                {
                    if (MessageBox.Show("您确定要取消第" + Convert.ToString((nrow + 1)) + "行吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }

                    string ssql = " update yp_fkjl set bdelete=1 where djid=" + Convert.ToInt64(tb.Rows[nrow]["id"]) + "";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    int ywy = checkBox1.Checked == true ? Convert.ToInt32(cmbywy.SelectedValue) : 0;
                    Filldj(Convert.ToInt32(lblghdw.Tag), ywy, _id);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkdjsj_CheckedChanged(object sender, EventArgs e)
        {
            dtpdjsj1.Enabled = this.chkdjsj.Checked == true ? true : false;
            dtpdjsj2.Enabled = this.chkdjsj.Checked == true ? true : false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

	}
}
