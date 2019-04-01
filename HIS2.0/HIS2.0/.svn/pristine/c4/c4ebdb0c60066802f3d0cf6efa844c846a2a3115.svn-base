using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using YpClass;
using ts_mz_class;
using TrasenFrame.Forms;

namespace ts_yf_cx
{
	/// <summary>
	/// Frmcffy 的摘要说明。
	/// </summary>
	public class Frmjytmdy : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
        private Form _mdiParent;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butcfcx;
		private System.Windows.Forms.DateTimePicker dtprq2;
		private System.Windows.Forms.DateTimePicker dtprq1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1;
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private YpConfig s;
        private string IPAddRess;
        public string _Fyckh;
        private TextBox _textBox;
        private Label label8;
        private TextBox txtxm;
        private Label label5;
        private TextBox txtjzks;
        private Label label11;
        private bool  _ClickQuit=false;
        private TextBox textBox1;
        private Label label1;
        private Panel panel5;
        private ButtonDataGridEx buttonDataGridEx1;
        private Panel panel4;
        private GroupBox groupBox2;
        private Splitter splitter3;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private int printRows = -1;

        public Frmjytmdy(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text =chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
			
			if (s.门诊发药和退药时默认打印小票==true)
				this.chkxp.Checked=true;
			else
				this.chkxp.Checked=false;
			//网址地址
			IPAddRess=PubStaticFun.GetMacAddress();
			
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
            this.components = new System.ComponentModel.Container();
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtjzks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtxm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.butcfcx = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDataGridEx1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDataGridEx1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtprq2
            // 
            this.dtprq2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtprq2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprq2.Location = new System.Drawing.Point(411, 46);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(148, 21);
            this.dtprq2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(389, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "到";
            // 
            // dtprq1
            // 
            this.dtprq1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtprq1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprq1.Location = new System.Drawing.Point(248, 46);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(138, 21);
            this.dtprq1.TabIndex = 7;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1150, 3);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.GridLineColor = System.Drawing.Color.SeaGreen;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myDataGrid1.Size = new System.Drawing.Size(553, 296);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.buttonDataGridEx1;
            this.dataGridTableStyle1.GridLineColor = System.Drawing.Color.Silver;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.button1);
            this.panel8.Controls.Add(this.groupBox3);
            this.panel8.Controls.Add(this.textBox1);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.txtjzks);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.txtxm);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.butcfcx);
            this.panel8.Controls.Add(this.dtprq1);
            this.panel8.Controls.Add(this.dtprq2);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.butquit);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1148, 84);
            this.panel8.TabIndex = 1;
            // 
            // txtjzks
            // 
            this.txtjzks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjzks.Location = new System.Drawing.Point(245, 15);
            this.txtjzks.Name = "txtjzks";
            this.txtjzks.Size = new System.Drawing.Size(141, 23);
            this.txtjzks.TabIndex = 190;
            this.txtjzks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtjzks_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(177, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 191;
            this.label11.Text = "开方科室";
            // 
            // txtxm
            // 
            this.txtxm.Enabled = false;
            this.txtxm.Location = new System.Drawing.Point(436, 16);
            this.txtxm.Name = "txtxm";
            this.txtxm.Size = new System.Drawing.Size(85, 21);
            this.txtxm.TabIndex = 39;
            this.txtxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(392, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "床号";
            // 
            // butcfcx
            // 
            this.butcfcx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butcfcx.ForeColor = System.Drawing.Color.Navy;
            this.butcfcx.Location = new System.Drawing.Point(722, 42);
            this.butcfcx.Name = "butcfcx";
            this.butcfcx.Size = new System.Drawing.Size(77, 24);
            this.butcfcx.TabIndex = 19;
            this.butcfcx.Text = "查询(&F)";
            this.butcfcx.Click += new System.EventHandler(this.butcfcx_Click);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Control;
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(885, 42);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(71, 24);
            this.butquit.TabIndex = 15;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(176, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "发药日期";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 424);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(2, 403);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1148, 24);
            this.statusBar1.TabIndex = 15;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 180;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 180;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 500;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1148, 400);
            this.panel2.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 400);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.splitter3);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1148, 316);
            this.panel3.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(617, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 21);
            this.textBox1.TabIndex = 193;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(566, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 192;
            this.label1.Text = "住院号";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(559, 316);
            this.panel5.TabIndex = 2;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(559, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(8, 316);
            this.splitter3.TabIndex = 3;
            this.splitter3.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(567, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(581, 316);
            this.panel4.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myDataGrid1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 316);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "煎药列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDataGridEx1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 316);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "处方明细";
            // 
            // buttonDataGridEx1
            // 
            this.buttonDataGridEx1.BackgroundColor = System.Drawing.Color.White;
            this.buttonDataGridEx1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDataGridEx1.CaptionVisible = false;
            this.buttonDataGridEx1.DataMember = "";
            this.buttonDataGridEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDataGridEx1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDataGridEx1.GridLineColor = System.Drawing.Color.SeaGreen;
            this.buttonDataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDataGridEx1.Location = new System.Drawing.Point(3, 17);
            this.buttonDataGridEx1.Name = "buttonDataGridEx1";
            this.buttonDataGridEx1.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonDataGridEx1.Size = new System.Drawing.Size(575, 296);
            this.buttonDataGridEx1.TabIndex = 1;
            this.buttonDataGridEx1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(10, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(154, 57);
            this.groupBox3.TabIndex = 194;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "打印状态";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "未打印";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(83, 23);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "已打印";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(804, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 24);
            this.button1.TabIndex = 195;
            this.button1.Text = "打印(&P)";
            // 
            // Frmjytmdy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1150, 427);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.splitter2);
            this.Name = "Frmjytmdy";
            this.Text = "煎药条码打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmcffy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonDataGridEx1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


		//加载窗口
		private void Frmcffy_Load(object sender, System.EventArgs e)
		{
            butcfcx.Enabled = true;
            txtxm.Enabled = true;
			CshMxGrid(this.myDataGrid1);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            Yp.AddcmbYjks_mz(true,cmbyjks, InstanceForm.BDatabase,_menuTag.Jgbm);

			this.dtprq1.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()+" 00:00:00");
            this.dtprq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
			
            IPAddRess = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();

			this.txtmzh.Focus();

            if ((new SystemCfg(8006)).Config == "0")
                this.myDataGrid1.TableStyles[0].GridColumnStyles["医生"].Width = 0;


            if (s.门诊发药时打印处方 == true) chkcf.Checked = true;
            if (s.门诊发药时打印清单 == true) chkqd.Checked = true;
            if (s.门诊发药时打印注射单 == true) chkzsd.Checked = true;

            if (s.门诊发药时默认打印处方 == true) chkprint.Checked = true;


            this.cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
            if (cmbyjks.SelectedIndex == -1)
                cmbyjks.SelectedIndex = 0;

		}

		
		private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx  xcjwDataGrid)
		{
			#region 添加明细的列
            //string[] HeaderText	={"序号","发药","皮试","发票号","项目","总金额","姓名","剂型","商品名","品名","用量","单位","规格","厂家","单价","库存","剂数","金额","门诊号","性别","年龄","诊断","科室","医生","煎药","用法","频次","剂量","剂量单位","天数","组标志","排序序号","录入日期","录入员","收费日期","记费员","发药日期","发药员","配药员","处方号","CFLX","JSSJH","CFXH","PATID","YSDM","KSDM","sfczy","qrczyh","pyczyh","配药窗口","发药窗口","记帐金额","优惠金额","自付金额","YPID","YDWBL","cfmxid","嘱托","批发价","批发金额","使用频次","货号"};
            //string[] MappingName={"序号","发药","皮试","发票号","项目","总金额","姓名","剂型","商品名","品名","用量","单位","规格","厂家","单价","库存","剂数","金额","门诊号","性别","年龄","诊断","科室","医生","煎药","用法","频次","剂量","剂量单位","天数","组标志","排序序号","录入日期","录入员","收费日期","记费员","发药日期","发药员","配药员","处方号","CFLX","JSSJH","CFXH","PATID","YSDM","KSDM","sfczy","qrczyh","pyczyh","配药窗口","发药窗口","记帐金额","优惠金额","自付金额","YPID","YDWBL","cfmxid","嘱托","批发价","批发金额","使用频次","货号"};
            //int	  [] ColWidth={40,30,30,60,0,0,60,0,110,110,50/*ypsl*/,40,90,90,60,0,40,65,0,0,0,0,0,50,0,0/*userage*/,0,0,0,0,0,0,90,60,90/*发费日期*/,0,90,60,60,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,90,0};
            //bool[] ColReadOnly={true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
            //bool[] ColBool={true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false};

            string[] HeaderText ={ "序号", "发药", "皮试", "发票号", "项目", "总金额", "姓名", "剂型", "商品名", "品名", "用量", "单位", "规格", "厂家", "单价", "库存", "剂数", "金额","使用方法", "门诊号", "性别", "年龄", "诊断", "科室", "医生", "煎药", "用法", "频次", "剂量", "剂量单位", "天数", "组标志", "排序序号", "录入日期", "录入员", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号", "单位规格" ,"zsyp"};
            string[] MappingName ={ "序号", "发药", "皮试", "发票号", "项目", "总金额", "姓名", "剂型", "商品名", "品名", "用量", "单位", "规格", "厂家", "单价", "库存", "剂数", "金额", "使用方法", "门诊号", "性别", "年龄", "诊断", "科室", "医生", "煎药", "用法", "频次", "剂量", "剂量单位", "天数", "组标志", "排序序号", "录入日期", "录入员", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号", "单位规格", "zsyp" };
            int[] ColWidth ={ 40, 30, 30, 60, 0, 0, 60, 0, 110, 110, 50/*ypsl*/, 40, 90, 90, 60, 0, 40, 65,120, 70, 40, 40, 70, 70, 50, 0, 0/*userage*/, 0, 0, 0, 0, 0, 0, 90, 60, 90/*发费日期*/, 0, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 80 };
            bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true,true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true,true };
            bool[] ColBool ={ true, false, false, false, false, false, false, false, true,false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,false };


			DataTable dtTmp=new DataTable();
			dtTmp.TableName="tbmx";

			for(int j=0;j<=HeaderText.Length-1;j++)
			{
				//DataGridEnableBoolColumn
				if (ColBool[j]==false)
				{
					DataGridEnableTextBoxColumn colText=new DataGridEnableTextBoxColumn(j);
					colText.HeaderText=HeaderText[j];
					colText.MappingName=MappingName[j];
					colText.Width=ColWidth[j];
					colText.NullText="";
					colText.ReadOnly=ColReadOnly[j];
					//colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
					colText.CheckCellEnabled+=new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
					
					xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
					DataColumn datacol;
					if (MappingName[j].Trim()=="ypsl" || MappingName[j]=="金额")
						datacol=new DataColumn(MappingName[j],Type.GetType("System.Decimal"));
					else
						datacol=new DataColumn(MappingName[j]);
					
					dtTmp.Columns.Add(datacol);
				}
				else
				{
					DataGridButtonColumn btnCol=new DataGridButtonColumn(j);
					btnCol.HeaderText=HeaderText[j];
					btnCol.MappingName=MappingName[j];
					btnCol.Width=ColWidth[j];
					btnCol.CellButtonClicked+=new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
					xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);

					this.myDataGrid1.MouseDown +=new MouseEventHandler(btnCol.HandleMouseDown);
					this.myDataGrid1.MouseUp +=new MouseEventHandler(btnCol.HandleMouseUp);
					
					DataColumn datacol;
					datacol=new DataColumn(MappingName[j]);
					dtTmp.Columns.Add(datacol);

				}
				
			}

			xcjwDataGrid.DataSource=dtTmp;
			xcjwDataGrid.TableStyles[0].MappingName ="tbmx";

			if (s.网络内容显示商品名==true)
				xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width=100;
			else
				xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width=0;
			#endregion

		}


		//列颜色改变事件
		private void myDataGrid1_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
		{
			try
			{
				e.BackColor=Color.White;
				DataTable tb;
				if (sender.GetType().ToString()=="TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
				{
					DataGridEnableBoolColumn column=(DataGridEnableBoolColumn)sender;
					tb=(DataTable)column.DataGridTableStyle.DataGrid.DataSource; 
				}
				else
				{
					DataGridEnableTextBoxColumn column=(DataGridEnableTextBoxColumn)sender;
					tb=(DataTable)column.DataGridTableStyle.DataGrid.DataSource; 
				}
				if (e.Row>tb.Rows.Count-1) return;
				//				if (tb.Rows[e.Row]["cjid"].ToString().Trim()=="")
				//					e.BackColor=Color.Azure;
				
				if (tb.Rows[e.Row]["发药"].ToString().Trim()=="◆")
					e.ForeColor=Color.Blue;
				if (tb.Rows[e.Row]["发药"].ToString().Trim()=="") 
					e.ForeColor=Color.Black;
				if (tb.Rows[e.Row]["发药"].ToString().Trim()=="√") 
					e.ForeColor=Color.Gray;

                #region 选中的行改变颜色 LQQ 2013-3-29
                if(printRows.ToString() == e.Row.ToString())             
                    e.BackColor= Color.Pink;
                #endregion


            }
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			//			
		}



		//查询处方按钮事件
		private void butcfcx_Click(object sender, System.EventArgs e)
		{
			this.Cursor=PubStaticFun.WaitCursor();

            string where = "";
            if (chkmzyp.Checked == true) where = where == "" ? " mzyp=1 " : where + " or mzyp=1 ";
            if (chkdjyp.Checked == true) where = where == "" ? " djyp=1 " : where + " or djyp=1 ";
            if (chkpsyp.Checked == true) where = where == "" ? " psyp=1 " : where + " or psyp=1 ";
            if (chkjsyp.Checked == true) where = where == "" ? " jsyp=1 " : where + " or jsyp=1 ";
            if (chkgzyp.Checked == true) where = where == "" ? " gzyp=1 " : where + " or gzyp=1 ";
            if (chkwyyp.Checked == true) where = where == "" ? " wyyp=1 " : where + " or wyyp=1 ";
            if (chkcfyp.Checked == true) where = where == "" ? " cfyp=1 " : where + " or cfyp=1 ";
            if (chkrsyp.Checked == true) where = where == "" ? " rsyp=1 " : where + " or rsyp=1 ";
            if (chkkss.Checked == true) where = where == "" ? " kssdjid>0 " : where + " or kssdjid=1 ";

			try
			{

                ParameterEx[] parameters = new ParameterEx[18];
                parameters[0].Text = "@functionname";
                parameters[0].Value = _menuTag.Function_Name;

                parameters[1].Text = "@deptid";
                parameters[1].Value = Convert.ToInt32(cmbyjks.SelectedValue) ;

                parameters[2].Text = "@blh";
                parameters[2].Value = txtmzh.Text.Trim();

                parameters[3].Text = "@hzxm";
                parameters[3].Value = txtxm.Text.Trim();

                parameters[4].Text = "@fph";
                parameters[4].Value = txtfph.Text.Trim();

                parameters[5].Text = "@klx";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue,"0"));

                parameters[6].Text = "@kh";
                parameters[6].Value = txttmk.Text.Trim();

                parameters[7].Text = "@zdmc";
                parameters[7].Value = txtzdmc.Text.Trim();

                parameters[8].Text = "@je1";
                parameters[8].Value = Convert.ToDecimal(Convertor.IsNull(txtje1.Text,"0"));

                parameters[9].Text = "@je2";
                parameters[9].Value = Convert.ToDecimal(Convertor.IsNull(txtje2.Text, "0"));

                parameters[10].Text = "@qrrq1";
                parameters[10].Value = dtprq1.Value.ToString();

                parameters[11].Text = "@qrrq2";
                parameters[11].Value = dtprq2.Value.ToString();

                parameters[12].Text = "@qrczyh";
                parameters[12].Value = 0;

                parameters[13].Text = "@fybz";
                parameters[13].Value = 1;

                parameters[14].Text = "@where";
                parameters[14].Value = where;

                parameters[15].Text = "@bk";
                parameters[15].Value = rdols.Checked==true?1:0;

                parameters[16].Text = "@ksdm";
                parameters[16].Value = Convertor.IsNull(txtjzks.Tag,"0");

                parameters[17].Text = "@ysdm";
                parameters[17].Value = Convertor.IsNull(txtjzys.Tag, "0");

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_SELECT_MZCF_CX", parameters, 60);



				this.AddPresc(tb);

				chkall.Checked=false;


                //分组处方
                string[] GroupbyField ={ "PATID"};
                string[] ComputeField ={ "金额" };
                string[] CField ={ "sum", "count" };
                TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                xcset.TsDataTable = tb;
                DataTable tbpat = xcset.GroupTable(GroupbyField, ComputeField, CField,"patid<>''");

                //分组处方
                string[] GroupbyField1 ={ "CFXH" };
                string[] ComputeField1 ={ "金额" };
                string[] CField1 ={ "sum", "count" };
                TrasenFrame.Classes.TsSet xcset2 = new TrasenFrame.Classes.TsSet();
                xcset2.TsDataTable = tb;
                DataTable tbcf = xcset2.GroupTable(GroupbyField1, ComputeField1, CField1,"patid<>''");

                statusBar1.Panels[0].Text = "处方人次:" + tbpat.Rows.Count.ToString();
                statusBar1.Panels[1].Text = "处方张数:" + tbcf.Rows.Count.ToString();
                string je=Convertor.IsNull(tbcf.Compute("sum(金额)",""),"");
                statusBar1.Panels[2].Text = "处方金额:" + je;


			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message );
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}


		//添加处方记录
		private void AddPresc(DataTable tbcf)
		{
			
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();

			if (tbcf.Rows.Count==0)return;
			string _prescNo=tbcf.Rows[0]["处方号"].ToString().Trim();
			int _PrescRowNo=0;
			decimal _PrescJe=0;

            //if (tbcf.Rows.Count > 0) cmbpyr.Text = tbcf.Rows[0]["配药员"].ToString().Trim();
			for (int i=0;i<=tbcf.Rows.Count-1;i++)
			{
				if(tbcf.Rows[i]["处方号"].ToString().Trim()!=_prescNo)
				{
					DataRow row=tb.NewRow();
					row["序号"]="小计";
					row["金额"]=_PrescJe.ToString("0.00");
					row["处方号"]=_prescNo;
					_prescNo=tbcf.Rows[i]["处方号"].ToString().Trim();
					_PrescRowNo=0;
					_PrescJe=0;
					tb.Rows.Add(row); 

					DataRow row1=tb.NewRow();
					tb.Rows.Add(row1);
				}

				if(tbcf.Rows[i]["处方号"].ToString().Trim()==_prescNo)
				{
					_PrescRowNo=_PrescRowNo+1;
					tbcf.Rows[i]["序号"]=_PrescRowNo.ToString();
					//					if (this.tabControl1.SelectedTab==this.tabPage2) tbcf.Rows[i]["发药"]="√";
					tb.ImportRow(tbcf.Rows[i]);
					_PrescJe=_PrescJe+Convert.ToDecimal(tbcf.Rows[i]["金额"]);
				}
				
				_prescNo=tbcf.Rows[i]["处方号"].ToString().Trim();
				
			}

			//添加最后一张处方的合计
			DataRow endrow=tb.NewRow();
			endrow["序号"]="小计";
			endrow["金额"]=_PrescJe.ToString("0.00");
			endrow["处方号"]=_prescNo;
			tb.Rows.Add(endrow);
		}

		
		#region 一般控制
	
		//明细列的按钮事件
		private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			//if (this.rdo2.Checked==true)return;
			for(
                int i=0;i<=tb.Rows.Count-1;i++)
			{
				if (tb.Rows[i]["处方号"].ToString().Trim()==tb.Rows[e.RowIndex]["处方号"].ToString().Trim() && tb.Rows[i]["处方号"].ToString().Trim()!="" && tb.Rows[i]["发药"].ToString().Trim()!="√" )
				{
					if (tb.Rows[i]["发药"].ToString().Trim()=="")
						tb.Rows[i]["发药"]="◆";
					else
						tb.Rows[i]["发药"]="";
				}
			}
            ////PrintRows_Current(e.RowIndex);

        }

        #region  每张处方增加打印功能 点击小计时增加打印功能 LQQ 2013-3-29
        private void PrintRows_Current(int currentRows)
        {
            ///////////////////每张处方增加打印功能 点击小计时增加打印功能 LQQ 2013-3-29
            //int currentRows = 0;
            try
            {
                if (currentRows >= 0)
                {
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    string xh_str = Convert.ToString(tb.Rows[currentRows]["序号"]).Trim();
                    if (xh_str != "")
                    {
                        if (xh_str == "小计")
                            currentRows = currentRows - 1;
                        //else
                        //    currentRows = currentRows;
                        string cfid_str = Convert.ToString(tb.Rows[currentRows]["处方号"]).Trim();
                        string fph_str = Convert.ToString(tb.Rows[currentRows]["发票号"]).Trim();

                        PrintFun_CF(cfid_str);
                        #region 处方与注射单
                        //if (e.RowIndex > 0)
                        //{
                        //处方
                        if (chkcf.Checked == true)
                            this.PrintCf(tb.Rows[currentRows], 1);
                        //注射单
                        if (chkzsd.Checked == true)
                            this.PrintCf(tb.Rows[currentRows], 2);
                        //发票号
                        if (chkqd.Checked == true)
                            this.PrintCf(fph_str);
                        //}
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("对不起,此行没有要打印的数据!");
                    }
                }
                ////////////////////////////
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        #endregion
        //全选
		private void chkall_CheckedChanged(object sender, System.EventArgs e)
		{
//			if (this.tabControl1.SelectedTab!=this.tabPage1) return;
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				if (tb.Rows[i]["处方号"].ToString().Trim()!="" && tb.Rows[i]["发药"].ToString().Trim()!="√")
				{
					if (chkall.Checked==true)
						tb.Rows[i]["发药"]="◆";
					else
						tb.Rows[i]["发药"]="";
				}
			}
		}

		
		#endregion


		
		private void butquit_Click(object sender, System.EventArgs e)
		{
            _ClickQuit = true;
			this.Close();
        }

        #region 增加每张处方打印功能
        /// <summary>
        /// 增加每张处方打印功能
        /// </summary>
        private void PrintFun_CF(string cfid_str)
        {
            #region //默认打印小票
            if (chkxp.Checked == true)//默认打印小票
            {
                string s_str = "( 发药='√' or 发药='◆')  and 用量<>'' and 处方号='"+cfid_str+"'";/////////LQQ
                this.PrintCfXP(s_str);
                return;
            }
            #endregion
        }

        #endregion

        private void butprint_Click(object sender, System.EventArgs e)
		{
            #region 点击打印处方按钮
            try
            {
                #region //默认打印小票
                if (chkxp.Checked == true)//默认打印小票
                {
                    string s_str = "( 发药='√' or 发药='◆')  and 用量<>''";/////////LQQ
                    this.PrintCfXP(s_str);
                    return;
                }
                #endregion

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                butprint.Enabled = false;

                //分组处方
                DataRow[] selrow = tb.Select("(发药='◆' or  发药='√') and ypid<>''");
                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);

                DataTable tbcf;
                //if (rdo1.Checked == true) //如果为未发药就取总金额，已发药则取求和值
                //{
                //    string[] GroupbyField ={ "cfxh", "发票号", "总金额", "诊断", "门诊号" };
                //    string[] ComputeField ={ };
                //    string[] CField ={  };
                //    tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                //}
                //else
                //{
                string[] GroupbyField ={ "cfxh", "发票号", "诊断", "门诊号" };
                string[] ComputeField ={ "金额" };
                string[] CField ={ "sum" };
                tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                //}


                //处方
                for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                {
                    if (chkcf.Checked == true)
                        this.PrintCf(tbcf.Rows[i], 1);
                }
                //注射单
                for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                {
                    if (chkzsd.Checked == true)
                        this.PrintCf(tbcf.Rows[i], 2);
                }

                //清单
                //分组处方
                if (chkqd.Checked == true)
                {
                    DataTable tbselqd = tb.Clone();
                    for (int w = 0; w <= selrow.Length - 1; w++)
                        tbselqd.ImportRow(selrow[w]);

                    DataTable tbcfqd;
                    string[] GroupbyFieldqd ={ "发票号" };
                    string[] ComputeFieldqd ={ };
                    string[] CFieldqd ={ };
                    tbcfqd = FunBase.GroupbyDataTable(tbselqd, GroupbyFieldqd, ComputeFieldqd, CFieldqd, null);
                    for (int i = 0; i <= tbcfqd.Rows.Count - 1; i++)
                    {
                        this.PrintCf(tbcfqd.Rows[i]["发票号"].ToString());
                    }
                }



                butprint.Enabled = true;
            }
            catch (System.Exception err)
            {
                butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
            #endregion
		}
        
        private void PrintCf(string fph)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows;

            string where = "(发药='◆' or  发药='√') and ypid<>''";
            if (fph != "") where = where + " and 发票号='"+fph+"'";
            rows = tb2.Select(where );
            if (rows.Length == 0) return;

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;

            for (int i = 0; i <= rows.Length - 1; i++)
            {

                #region  非中药处方格式
                myrow = Dset.病人处方清单.NewRow();
                myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                myrow["cfts"] = rows[i]["剂数"].ToString();
                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");
                myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                myrow["syjl"] = "";
                myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                myrow["PSZT"] = rows[i]["皮试"].ToString();
                myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                myrow["pyr"] = Convert.ToString(rows[i]["配药员"]);
                myrow["fyr"] = Convert.ToString(rows[i]["发药员"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["发药员"]);
                myrow["pyckdm"] = Convertor.IsNull(rows[i]["配药窗口"], "") == "" ? "" : Convertor.IsNull(rows[i]["配药窗口"], "");
                myrow["fyckdm"] = Convertor.IsNull(rows[i]["发药窗口"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["发药窗口"], "");
                myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");
                if (rows[i]["组标志"].ToString() == "1")
                {
                    yzzh = yzzh + 1;
                }
                myrow["yzzh"] = yzzh;
                myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                myrow["fzbz"] = rows[i]["组标志"].ToString();
                Dset.病人处方清单.Rows.Add(myrow);
                #endregion

            }

            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["剂数"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["总金额"], "0"));
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "";
            parameters[3].Text = "text1";
            parameters[3].Value = "发药单位:" + InstanceForm.BCurrentDept.DeptName + "    诊断:" + rows[0]["诊断"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]) != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkprintview.Checked == true) bview = false;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单.rpt", parameters, bview);
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();


        }

        private void PrintCf(DataRow row, int cfgs)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows;
            if (cfgs == 1)
                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");
            else
                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' and zsyp=1 ");
            if (rows.Length == 0) return;

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;

            for (int i = 0; i <= rows.Length - 1; i++)
            {

                #region  非中药处方格式
                myrow = Dset.病人处方清单.NewRow();
                myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                myrow["cfts"] = rows[i]["剂数"].ToString();
                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");
                myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                myrow["syjl"] = "";
                myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                myrow["PSZT"] = rows[i]["皮试"].ToString();
                myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                myrow["pyr"] = Convert.ToString(rows[i]["配药员"]);
                myrow["fyr"] = Convert.ToString(rows[i]["发药员"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["发药员"]);
                myrow["pyckdm"] = Convertor.IsNull(rows[i]["配药窗口"],"")==""?"":Convertor.IsNull(rows[i]["配药窗口"],"");
                myrow["fyckdm"] = Convertor.IsNull(rows[i]["发药窗口"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["发药窗口"], "");
                myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");

                if (rows[i]["组标志"].ToString() == "1")
                {
                    yzzh = yzzh + 1;
                }
                myrow["yzzh"] = yzzh;
                myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                myrow["fzbz"] = rows[i]["组标志"].ToString();
                Dset.病人处方清单.Rows.Add(myrow);
                #endregion

            }

            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["剂数"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["总金额"], "0"));
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "";
            parameters[3].Text = "text1";
            parameters[3].Value = "发药单位:" + InstanceForm.BCurrentDept.DeptName + "    诊断:" + rows[0]["诊断"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]) != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkprintview.Checked == true) bview = false;
            TrasenFrame.Forms.FrmReportView f;
            if (cfgs == 1)
            {
                if (Convert.ToString(rows[0]["cflx"]) == "03")
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单_中药处方.rpt", parameters, bview);

                else
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(处方格式).rpt", parameters, bview);
            }
            else
            {
                f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(注射单).rpt", parameters, bview);
            }
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();


        }


        #region 打印默认小票
        private void PrintCfXP(string selectStr)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;

			DataRow[] rows;
            rows = tb.Select(selectStr);//"( 发药='√' or 发药='◆')  and 用量<>''"
			if (rows.Length==0) return;
			string cftsname="";
			cftsname=Convert.ToString(rows[0]["项目"]).Trim()=="中草药"?"中药付数":"";
			ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
			DataRow myrow;
			for(int i=0;i<=rows.Length-1;i++)
			{
				myrow=Dset.病人处方清单.NewRow();
				//myrow["xh"]=Convert.ToInt32(rows[i]["序号"]);
				myrow["ypmc"]=Convert.ToString(rows[i]["品名"]);
				myrow["ypgg"]=Convert.ToString(rows[i]["规格"]);
				myrow["sccj"]=Convert.ToString(rows[i]["厂家"]);
				myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"],"0"));
				myrow["zje"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["总金额"],"0"));
				myrow["ypsl"]=Convertor.IsNull(rows[i]["用量"],"0");
				myrow["ypdw"]=Convert.ToString(rows[i]["单位"]);
				myrow["cfts"]=Convert.ToString(rows[i]["项目"]).Trim()=="中草药"?rows[i]["剂数"]+"剂":"";
				myrow["lsje"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"],"0"));
				string UserEat="";
				UserEat=rows[i]["频次"].ToString().Trim()==""?"":Convert.ToDouble(rows[i]["剂量"]).ToString()+rows[i]["剂量单位"].ToString().Trim()+"/每次";
				myrow["yf"]=Convert.ToString(rows[i]["用法"])+"  "+rows[i]["使用频次"].ToString().Trim()+" "+UserEat;
				myrow["pc"]= rows[i]["使用频次"].ToString().Trim();
				myrow["syjl"]="";
				myrow["zt"]=Convert.ToString(rows[i]["嘱托"]);
				myrow["shh"]=Convert.ToString(rows[i]["货号"]);
				myrow["ksname"]=Convert.ToString(rows[i]["科室"]);//+"  费别:"+this.patientInfo1.FeeTypeName;
				string ysqm="";
				//if (Convert.ToString(row["医生签名"]).Trim()!="")  ysqm="   医生签名:"+Convert.ToString(rows[i]["医生签名"]);
				myrow["ysname"]=Convert.ToString(rows[i]["医生"])+ysqm;
				myrow["Pyck"]=rows[i]["皮试"].ToString();
				myrow["fph"]=Convert.ToString(rows[i]["发票号"]);
				myrow["hzxm"]=Convert.ToString(rows[i]["姓名"]);
				myrow["sex"]=Convert.ToString(rows[i]["性别"]);
				myrow["age"]=Convert.ToString(rows[i]["年龄"]);
				myrow["blh"]=Convert.ToString(rows[i]["门诊号"]);
				myrow["sfrq"]=Convert.ToString(rows[i]["收费日期"]);
                myrow["pyr"] = Convert.ToString(rows[i]["配药员"]);
				myrow["fyr"]=InstanceForm.BCurrentUser.Name;
				Dset.病人处方清单.Rows.Add(myrow);
			}

			ParameterEx[] parameters=new ParameterEx[1];
			parameters[0].Text="TITLETEXT";
			parameters[0].Value=TrasenFrame.Classes.Constant.HospitalName+"处方明细单";
			bool bview=this.chkprintview.Checked==true?false:true;
			TrasenFrame.Forms.FrmReportView f;
			f=new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单,Constant.ApplicationDirectory+"\\Report\\YF_病人处方清单列表_小票.rpt",parameters,bview);
			if (f.LoadReportSuccess) f.Show();else  f.Dispose();

        }
        #endregion


        //查询病人
		private void txtghxh_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				int nkey=Convert.ToInt32(e.KeyChar);
				if (nkey==13)
				{
					DataTable mytb=(DataTable)this.myDataGrid1.DataSource;
					mytb.Rows.Clear();

					Control control=(Control)sender;
					ts_mz_brxx.MzGhxx ghxx=null;
					ts_mz_brxx.MzBrxx brxx=null;

					DataTable tb=null;

					if (control.Name=="txtmzh")
					{
                        this.txtmzh.Text = FunBase.returnMzh(this.txtmzh.Text, InstanceForm.BDatabase,InstanceForm._menuTag.Jgbm);
						DataTable tbghxx=ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty,Guid.Empty,txtmzh.Text.Trim(),0,Convert.ToInt16(this.rdols.Checked),InstanceForm.BDatabase);
						if (tbghxx.Rows.Count==0){MessageBox.Show("没有找到病人，请重新输入","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}
						this.txttmk.Text="";
						this.txtfph.Text="";
						_textBox=txtmzh;

					}
					if (control.Name=="txttmk")
					{
                        int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                        txttmk.Text = Fun.returnKh(klx, txttmk.Text, InstanceForm.BDatabase);
                        brxx = new ts_mz_brxx.MzBrxx(Guid.Empty, klx, txttmk.Text.Trim(), "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
						this.txtmzh.Text="";
						//this.txtghxh.Text="";
						this.txtfph.Text="";
						_textBox=txttmk;
					}

					if (control.Name=="txtfph")
					{
                        if (Convertor.IsNumeric(txtfph.Text) == false) { MessageBox.Show("发票号请输入数字，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
						this.txtmzh.Text="";
						this.txttmk.Text="";
						//this.txtghxh.Text="";
						_textBox=txtfph;
					}

                    butcfcx_Click(sender, e);
					this.chkall.Checked=false;

					

				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void txtmzh_Move(object sender, System.EventArgs e)
		{
			txtmzh.Focus();
			txtmzh.Select(0,txtmzh.Text.Length);
		}

		private void txtmzh_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Control control=(Control)sender;
			if (control.Name=="txtmzh")
			{
				txtmzh.Focus();
				txtmzh.Select(0,txtmzh.Text.Length);
			}
			if (control.Name=="txttmk")
			{
				txttmk.Focus();
				txttmk.Select(0,txttmk.Text.Length);
			}
			if (control.Name=="txtghxh")
			{
                //txtghxh.Focus();
                //txtghxh.Select(0,txtghxh.Text.Length);
			}
			if (control.Name=="txtfph")
			{
				txtfph.Focus();
				txtfph.Select(0,txtfph.Text.Length);
			}
		}

        private void txtxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                butcfcx_Click(sender, null);
        }

        private void butfy_Click(object sender, EventArgs e)
        {

        }

        private void txtjzks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            int nkey = (int)e.KeyChar;
            if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Fun.GetGhks(false, InstanceForm.BDatabase);
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                    return;
                }
                else
                {
                    control.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    control.Text = f.SelectDataRow["name"].ToString().Trim();
                }
            }
        }

        private void txtjzys_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            int nkey = (int)e.KeyChar;
            if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
            if ((int)e.KeyChar != 13)
            {

                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "py_code", "wb_code" };//, "code" Modify By Tany 2008-12-19 不一定有工号
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Fun.GetGhys(0, InstanceForm.BDatabase);
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    control.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    control.Text = f.SelectDataRow["name"].ToString().Trim();
                }
            }
        }

        private void btnCurrentPrint_Click(object sender, EventArgs e)
        {
            PrintRows_Current(printRows);
        }

        private void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            printRows = myDataGrid1.CurrentRowIndex;          
        }

	}
}
