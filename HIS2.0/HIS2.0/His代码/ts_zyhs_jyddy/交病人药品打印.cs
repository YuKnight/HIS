using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.OleDb;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using System.Text;
using System.Security;

namespace ts_zyhs_jyddy
{
	/// <summary>
	/// 化验单打印 的摘要说明。
	/// </summary>
	public class frmJBRYPDY : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;
		private DataSet ds = new DataSet();
		private int nType=0; //0=检验单打印 1=交病人药打印

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cmbDept;
		private System.Windows.Forms.CheckBox chkBin;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.CheckBox chkDept;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel6;
		private DataGridEx myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.CheckBox cbPage;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPageE;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPageS;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton rbAll;
		private System.Windows.Forms.RadioButton rbWdy;
		private System.Windows.Forms.Panel panel4;


		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


		public frmJBRYPDY(string _formText,int _type)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.Text=_formText;
			nType=_type;
			
			myFunc=new BaseFunc();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.chkDept = new System.Windows.Forms.CheckBox();
            this.chkBin = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbWdy = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPageE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPageS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPage = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(50, 8);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.ShowUpDown = true;
            this.dtpBegin.Size = new System.Drawing.Size(136, 21);
            this.dtpBegin.TabIndex = 1;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(50, 32);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(136, 21);
            this.dtpEnd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "至";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(26, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 73;
            this.label5.Text = "从";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(4, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "时间";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbDept);
            this.groupBox2.Controls.Add(this.chkDept);
            this.groupBox2.Controls.Add(this.chkBin);
            this.groupBox2.Location = new System.Drawing.Point(194, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "类别";
            // 
            // cmbDept
            // 
            this.cmbDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Enabled = false;
            this.cmbDept.Location = new System.Drawing.Point(67, 29);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(77, 20);
            this.cmbDept.TabIndex = 2;
            // 
            // chkDept
            // 
            this.chkDept.Location = new System.Drawing.Point(8, 32);
            this.chkDept.Name = "chkDept";
            this.chkDept.Size = new System.Drawing.Size(64, 16);
            this.chkDept.TabIndex = 4;
            this.chkDept.Text = "按科室";
            this.chkDept.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDept.CheckedChanged += new System.EventHandler(this.chkDept_CheckedChanged);
            // 
            // chkBin
            // 
            this.chkBin.Location = new System.Drawing.Point(8, 16);
            this.chkBin.Name = "chkBin";
            this.chkBin.Size = new System.Drawing.Size(64, 16);
            this.chkBin.TabIndex = 3;
            this.chkBin.Text = "按病人";
            this.chkBin.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkBin.CheckedChanged += new System.EventHandler(this.chkBin_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(548, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 32);
            this.btnRefresh.TabIndex = 70;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(692, 16);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 32);
            this.btCancel.TabIndex = 68;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.Location = new System.Drawing.Point(620, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(64, 32);
            this.btnPrint.TabIndex = 67;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(540, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(224, 47);
            this.button3.TabIndex = 69;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(160, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 533);
            this.panel1.TabIndex = 71;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.crystalReportViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(768, 477);
            this.panel3.TabIndex = 73;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(768, 477);
            this.crystalReportViewer1.TabIndex = 71;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 56);
            this.panel2.TabIndex = 72;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rbWdy);
            this.groupBox4.Controls.Add(this.rbAll);
            this.groupBox4.Location = new System.Drawing.Point(462, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(74, 56);
            this.groupBox4.TabIndex = 72;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "状态";
            // 
            // rbWdy
            // 
            this.rbWdy.Location = new System.Drawing.Point(8, 32);
            this.rbWdy.Name = "rbWdy";
            this.rbWdy.Size = new System.Drawing.Size(64, 16);
            this.rbWdy.TabIndex = 1;
            this.rbWdy.Text = "未打印";
            this.rbWdy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rbAll
            // 
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(8, 14);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(64, 16);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部";
            this.rbAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtPageE);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtPageS);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbPage);
            this.groupBox3.Location = new System.Drawing.Point(348, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(112, 56);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(91, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "页";
            // 
            // txtPageE
            // 
            this.txtPageE.Enabled = false;
            this.txtPageE.Location = new System.Drawing.Point(64, 24);
            this.txtPageE.Name = "txtPageE";
            this.txtPageE.Size = new System.Drawing.Size(24, 21);
            this.txtPageE.TabIndex = 3;
            this.txtPageE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageE_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(48, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "到";
            // 
            // txtPageS
            // 
            this.txtPageS.Enabled = false;
            this.txtPageS.Location = new System.Drawing.Point(21, 24);
            this.txtPageS.Name = "txtPageS";
            this.txtPageS.Size = new System.Drawing.Size(24, 21);
            this.txtPageS.TabIndex = 1;
            this.txtPageS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageS_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "从";
            // 
            // cbPage
            // 
            this.cbPage.Location = new System.Drawing.Point(4, 0);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(48, 16);
            this.cbPage.TabIndex = 72;
            this.cbPage.Text = "页码";
            this.cbPage.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbPage.CheckedChanged += new System.EventHandler(this.cbPage_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.myDataGrid2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(160, 533);
            this.panel6.TabIndex = 73;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Black;
            this.myDataGrid2.CaptionText = "病人信息";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size(160, 533);
            this.myDataGrid2.TabIndex = 24;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(928, 533);
            this.panel4.TabIndex = 74;
            // 
            // frmJBRYPDY
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(928, 533);
            this.Controls.Add(this.panel4);
            this.Name = "frmJBRYPDY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "交病人药品打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHydprt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpBegin.Enabled=checkBox1.Checked;
			dtpEnd.Enabled=checkBox1.Checked;
		}

		private void chkDept_CheckedChanged(object sender, System.EventArgs e)
		{
			cmbDept.Enabled=chkDept.Checked;
			if(chkDept.Checked) chkBin.Checked=false;
		}

		private void chkBin_CheckedChanged(object sender, System.EventArgs e)
		{
//			myDataGrid2.Enabled=chkBin.Checked;
			if(chkBin.Checked) chkDept.Checked=false;
		}

		private void frmHydprt_Load(object sender, System.EventArgs e)
		{
			crystalReportViewer1.ShowExportButton=InstanceForm.BCurrentUser.IsAdministrator;
			
			dtpBegin.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()+" 00:00:00");
			dtpEnd.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()+" 23:59:59");

			//查出本病区的病人信息
            string sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +                                 
				"   FROM vi_zy_vInpatient_Bed "+                         
				"  WHERE WARD_ID= '"+InstanceForm.BCurrentDept.WardId +"' ORDER BY BED_NO,Baby_ID";
			string[] GrdMappingName1={"床号","姓名","INPATIENT_ID","Baby_ID","DEPT_ID","isMY"};
			int[]    GrdWidth1      ={     6,    12,0,0,0,0};
			int[]    Alignment1     ={     1,     0,0,0,0,0};
			myFunc.InitGridSQL(sSql,GrdMappingName1,GrdWidth1,Alignment1,this.myDataGrid2);

			//查出本病区的科室
			sSql=@"select a.dept_id DEPT_ID,a.name NAME from jc_DEPT_PROPERTY a,jc_WARDRDEPT b  WHERE WARD_ID= '"
				+InstanceForm.BCurrentDept.WardId +"' and a.dept_id=b.dept_id  order by a.dept_id";
			DataTable DeptTb=InstanceForm.BDatabase.GetDataTable(sSql);

//			for(int i=0;i<DeptTb.Rows.Count;i++)
//			{
//				cmbDept.Items.Add(DeptTb.Rows[i]["name"].ToString().Trim());
//			}
			cmbDept.DisplayMember="NAME";
			cmbDept.ValueMember="DEPT_ID";
			cmbDept.DataSource=DeptTb;
		}

		private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			int nrow=this.myDataGrid2.CurrentCell.RowNumber;						
			this.myDataGrid2.Select(nrow);
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			string sSql="";
			DataTable prtTb = new DataTable();
			DataTable binTb = (DataTable)myDataGrid2.DataSource;
			
			Cursor.Current=PubStaticFun.WaitCursor(); 

			ds.Tables.Clear();

			if(nType==0)
			{
				#region 检验单打印
				sSql=@"select distinct b.name,b.sex_name,b.age,c.name dept_name,d.ward_name,b.bed_no,b.inpatient_no,a.memo in_diagnosis,"
					+"ltrim(rtrim(convert(varchar,datepart(mm,getdate()))))+'月'+ltrim(rtrim(convert(varchar,datepart(dd,getdate()))))+'日'+substring(ltrim(rtrim(convert(varchar,datepart(mm,getdate())))),1,2)+'时' date,"
					+"a.group_id,a.order_context+'    '+case a.num when 1 then '' else ltrim(rtrim(convert(varchar,a.num)))+'次' end order_context,f.name exec_dept,e.name doc_name,e.ys_code,"
					+"dbo.fun_getdate(order_date) order_date,a.order_extension,a.num,a.fjsm,a.order_id"
					+" from zy_jy_print a inner join (select * from zy_fee_speci where charge_bit=0 and delete_bit=0) fee on a.order_id=fee.order_id,"//已经确费的不显示，但不包括血液中心的 Modify By Tany 2005-01-20
					+" vi_zy_vinpatient_bed b,jc_dept_property c,jc_ward d,jc_employee_property e,jc_dept_property f"
					+" where a.delete_bit=0 and a.finish_bit=1 and a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id and a.exec_dept=f.dept_id"
					+" and a.order_doc=e.employee_id and b.dept_id=c.dept_id and b.ward_id=d.ward_id and b.ward_id='"+InstanceForm.BCurrentDept.WardId+"'";
				if(checkBox1.Checked)
				{
					sSql+=" and a.order_date between '"+dtpBegin.Value+"' and '"+dtpEnd.Value+"'";
				}
				if(chkBin.Checked)
				{
					sSql+=" and a.inpatient_id="+Convert.ToDecimal(binTb.Rows[myDataGrid2.CurrentCell.RowNumber]["INPATIENT_ID"].ToString())+
						" and a.baby_id="+Convert.ToDecimal(binTb.Rows[myDataGrid2.CurrentCell.RowNumber]["BABY_ID"].ToString());
				}
				if(chkDept.Checked)
				{
					sSql+=" and c.name='"+cmbDept.Text.Trim()+"'";
				}
				//kind 8=检验单 9=交病人药
				if(rbWdy.Checked)
				{
					sSql+=" and a.order_id not in (select order_id from zy_printzxd where kind=8)";
				}
				sSql+=" order by b.bed_no,a.group_id";

				prtTb=InstanceForm.BDatabase.GetDataTable(sSql);
				prtTb.TableName="tabJydprt";
				ds.Tables.Add(prtTb);

				if (prtTb==null || prtTb.Rows.Count==0) 
				{
					Cursor.Current=Cursors.Default;
					crystalReportViewer1.ReportSource=null;
					return;
				}

				ReportDocument rp = new ReportDocument();
				rp.Load(Constant.ApplicationDirectory+"\\report\\ZYHS_检验单据打印.rpt");
				rp.SetDataSource(ds.Tables["tabJydprt"]);
                rp.SetParameterValue("报告人", InstanceForm.BCurrentUser.Name);
                rp.SetParameterValue("医院名称", (new SystemCfg(0002)).Config);

                //string sql = "select * from jc_reportpaper where reportname='ZYHS_检验单据打印'";
                //DataTable paperTb = InstanceForm.BDatabase.GetDataTable(sql);

                ////如果设置了纸张
                //if (paperTb.Rows.Count > 0)
                //{

                //    PrintDocument prtdoc = new PrintDocument();
                //    string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//获取默认打印机
                //    //string _printer=System.Drawing.Printing.PrinterSettings.InstalledPrinters[7].ToString();

                //    Microsoft.Win32.RegistryKey rk;
                //    if (!strDefaultPrinter.StartsWith(@"\\"))//本地打印机
                //    {
                //        rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Printers\\" + strDefaultPrinter + "\\DsDriver");
                //    }
                //    else                                //网络打印机
                //    {

                //        string[] p = strDefaultPrinter.Remove(0, 2).Split(new char[] { '\\' });
                //        string path = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\LanMan Print Services\\Servers\\" + p[0] + "\\Printers\\" + p[1] + "\\DsDriver";
                //        rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path);
                //    }

                //    string[] papers = (string[])(rk.GetValue("printMediaSupported"));
                //    int iPaper = 0;
                //    bool Exist = false;
                //    string PaperName = paperTb.Rows[0]["PAPERNAME"].ToString();

                //    for (int i = 0; i < papers.Length; i++)
                //    {
                //        if (papers[i].ToString().ToUpper() == PaperName)
                //        {
                //            iPaper = i;
                //            Exist = true;
                //            break;
                //        }
                //    }

                //    //如果没有这个纸张则添加
                //    if (!Exist)
                //    {
                //        const int PRINTER_ACCESS_USE = 0x00000008;
                //        const int PRINTER_ACCESS_ADMINISTER = 0x00000004;
                //        const int FORM_PRINTER = 0x00000002;

                //        structPrinterDefaults defaults = new structPrinterDefaults();
                //        defaults.pDatatype = null;
                //        defaults.pDevMode = IntPtr.Zero;
                //        defaults.DesiredAccess = PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE;

                //        IntPtr hPrinter = IntPtr.Zero;

                //        //打开打印机 
                //        if (OpenPrinter(strDefaultPrinter, out hPrinter, ref defaults))
                //        {
                //            try
                //            {
                //                float WidthInMm = Convert.ToSingle(paperTb.Rows[0]["PAPERWIDTH"]);
                //                float HeightInMm = Convert.ToSingle(paperTb.Rows[0]["PAPERHEIGHT"]);

                //                //创建并初始化FORM_INFO_1 
                //                FormInfo1 formInfo = new FormInfo1();
                //                formInfo.Flags = 0;
                //                formInfo.pName = PaperName;
                //                formInfo.Size.width = (int)(WidthInMm * 1000.0);
                //                formInfo.Size.height = (int)(HeightInMm * 1000.0);
                //                formInfo.ImageableArea.left = 0;
                //                formInfo.ImageableArea.right = formInfo.Size.width;
                //                formInfo.ImageableArea.top = 0;
                //                formInfo.ImageableArea.bottom = formInfo.Size.height;
                //                //AddForm(hPrinter, 1, ref formInfo);
                //                if (!AddForm(hPrinter, 1, ref formInfo))
                //                {
                //                    StringBuilder strBuilder = new StringBuilder();
                //                    strBuilder.AppendFormat("向打印机 {1} 添加自定义纸张 {0} 失败！错误代号：{2}",
                //                     PaperName, strDefaultPrinter, GetLastError());
                //                    throw new ApplicationException(strBuilder.ToString());
                //                }
                //                //重新读取信息
                //                if (!strDefaultPrinter.StartsWith(@"\\"))//本地打印机
                //                {
                //                    rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Printers\\" + strDefaultPrinter + "\\DsDriver");
                //                }
                //                else                                //网络打印机
                //                {

                //                    string[] p = strDefaultPrinter.Remove(0, 2).Split(new char[] { '\\' });
                //                    string path = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\LanMan Print Services\\Servers\\" + p[0] + "\\Printers\\" + p[1] + "\\DsDriver";
                //                    rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path);
                //                }
                //                papers = (string[])(rk.GetValue("printMediaSupported"));
                //                iPaper = 0;

                //                for (int i = 0; i < papers.Length; i++)
                //                {
                //                    if (papers[i].ToString().ToUpper() == PaperName)
                //                    {
                //                        iPaper = i;
                //                        break;
                //                    }
                //                }
                //            }
                //            catch (Exception err)
                //            {
                //                MessageBox.Show(err.Message);
                //            }
                //            finally
                //            {
                //                ClosePrinter(hPrinter);
                //            }
                //        }
                //    }

                //    int[] sizes = PaperSizeGetter.Get_PaperSizes(strDefaultPrinter);
                //    int paperSizeid = sizes[iPaper];

                //    rp.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)(paperSizeid);
                //}

				crystalReportViewer1.ReportSource=rp;

				//增加弹出窗口模式
				//Modify By Tany 2005-11-05
				//打印数据
				FrmReportView frmRptView=null;
				string _reportName="";
				ParameterEx[] _parameters=new ParameterEx[2];
	
				_reportName="ZYHS_检验单据打印.rpt";
	
				_parameters[0].Text="报告人";
				_parameters[0].Value=InstanceForm.BCurrentUser.Name;
				_parameters[1].Text="医院名称";
				_parameters[1].Value=(new SystemCfg(0002)).Config;

				frmRptView=new FrmReportView(prtTb,Constant.ApplicationDirectory+"\\report\\"+_reportName,_parameters);
				frmRptView.Show();
				#endregion
			}
			else if(nType==1)
			{
				#region 交病人药品打印
//				sSql=@"with TMP(cur_dept_name,bed_no,name,order_context,s_gg,num,unit,group_id,order_id) as (";
                sSql = @"select dbo.FUN_ZY_SEEKdeptname(c.dept_id) AS cur_dept_name, e.bed_no,c.name,a.order_context,d.s_ypgg s_gg,b.num,b.unit,a.group_id,a.order_id,rtrim(cast(a.num as varchar(30))) jl,a.FREQUENCY pc,a.UNIT jldw " + //add by zouchihua 2013-6-14 增加剂量和频次
					"from (select * from zy_orderrecord  "+
					"where mngtype=5 and delete_bit=0 and ntype in (1,2) and charindex('自服',order_context)=0) as a "+
					"inner join  "+
					"(select * from zy_fee_speci where charge_bit=1 and cz_flag=0 and "+
					"dept_br IN "+
                    "      (SELECT DEPT_ID "+
                    "       FROM jc_WARDRDEPT "+
                    "       WHERE WARD_ID ='"+InstanceForm.BCurrentDept.WardId+"')";
					if(checkBox1.Checked)
					{
						sSql+=" and charge_date between '"+dtpBegin.Value+"' and '"+dtpEnd.Value+"'";
					}
				sSql+=@") as b "+
					"on a.order_id=b.order_id "+
					"inner join "+
					"vi_zy_vINPATIENT c ON a.INPATIENT_ID = c.inpatient_id  "+
                    "INNER JOIN "+
                    "ZY_BEDDICTION e ON c.bed_id = e.bed_id "+
					"inner join  "+
					"YP_YPCJD as d  "+
					"on a.hoitem_id=d.cjid ";
				if(chkBin.Checked)
				{
                    sSql += " where a.inpatient_id='" + binTb.Rows[myDataGrid2.CurrentCell.RowNumber]["INPATIENT_ID"].ToString() + "'" +
						" and a.baby_id="+Convert.ToDecimal(binTb.Rows[myDataGrid2.CurrentCell.RowNumber]["BABY_ID"].ToString());
				}
				if(chkDept.Checked)
				{
					sSql+=" where c.dept_id="+cmbDept.SelectedValue.ToString();
				}
				//kind 8=检验单 9=交病人药
                if (rbWdy.Checked)
                {
                    sSql += " and a.order_id not in (select order_id from zy_printzxd where kind=9)";
                }
				sSql+=" union all";
                sSql += @" select dbo.FUN_ZY_SEEKdeptname(c.dept_id) AS cur_dept_name, e.bed_no,c.name,'中草药处方' order_context,'' s_gg,a.dosage num,'付' unit,a.group_id,DBO.FUN_GETEMPTYGUID() order_id ,null jl,null pc,null jldw " +
					"from (select * from zy_orderrecord "+
					"where mngtype=5 and delete_bit=0 and ntype=3) as a "+
					"inner join  "+
					"(select * from zy_fee_speci where charge_bit=1 and cz_flag=0 and "+
					"dept_br IN "+
                    "      (SELECT DEPT_ID "+
                    "       FROM jc_WARDRDEPT "+
                    "       WHERE WARD_ID ='"+InstanceForm.BCurrentDept.WardId+"')";
				if(checkBox1.Checked)
				{
					sSql+=" and charge_date between '"+dtpBegin.Value+"' and '"+dtpEnd.Value+"'";
				}
				sSql+=@") as b "+
					"on a.order_id=b.order_id "+
					"inner join "+
					"vi_zy_vINPATIENT c ON a.INPATIENT_ID = c.inpatient_id  "+
                    "INNER JOIN "+
                    "ZY_BEDDICTION e ON c.bed_id = e.bed_id ";
				if(chkBin.Checked)
				{
                    sSql += " where a.inpatient_id='" + binTb.Rows[myDataGrid2.CurrentCell.RowNumber]["INPATIENT_ID"].ToString() + "'" +
						" and a.baby_id="+Convert.ToDecimal(binTb.Rows[myDataGrid2.CurrentCell.RowNumber]["BABY_ID"].ToString());
				}
				if(chkDept.Checked)
				{
					sSql+=" where c.dept_id="+cmbDept.SelectedValue.ToString();
				}
				//kind 8=检验单 9=交病人药
                if (rbWdy.Checked)
                {
                    sSql += " and a.order_id not in (select order_id from zy_printzxd where kind=9)";
                }
				sSql+=" group by c.dept_id,e.bed_no,c.name,a.dosage,a.group_id";
				sSql+=" order by e.bed_no,c.name,a.group_id";
                //sSql+=" select * from TMP";
				//kind 8=检验单 9=交病人药
                //if(rbWdy.Checked)
                //{
                //    sSql+=" where order_id not in (select order_id from zy_printzxd where kind=9)";
                //}

				prtTb=InstanceForm.BDatabase.GetDataTable(sSql);
				prtTb.TableName="tabJbrMedprt";
				ds.Tables.Add(prtTb);

				if (prtTb==null || prtTb.Rows.Count==0) 
				{
					Cursor.Current=Cursors.Default;
					crystalReportViewer1.ReportSource=null;
					return;
				}

				ReportDocument rp = new ReportDocument();
				rp.Load(Constant.ApplicationDirectory+"\\report\\ZYHS_交病人药品查询.rpt");
				rp.SetDataSource(ds.Tables["tabJbrMedprt"]);
				crystalReportViewer1.ReportSource=rp;

				//增加弹出窗口模式
				//Modify By Tany 2005-11-05
				//打印数据
				FrmReportView frmRptView=null;
				string _reportName="";
	
				_reportName="ZYHS_交病人药品查询.rpt";

				frmRptView=new FrmReportView(prtTb,Constant.ApplicationDirectory+"\\report\\"+_reportName,null);
				frmRptView.Show();
				#endregion
			}

			Cursor.Current=Cursors.Default;

		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{

			ReportDocument rd = (ReportDocument)crystalReportViewer1.ReportSource;
			DataTable myTb = (DataTable)ds.Tables[0];
			int kind=0;//8=检验单 9=交病人药
			int pageS=0;
			int pageE=0;
			string sSql="";

			if(rd==null) return;
			if(cbPage.Checked)
			{
				if(txtPageS.Text.Trim() != "")
				{
					pageS=Convert.ToInt32(txtPageS.Text.Trim());
				}
				if(txtPageE.Text.Trim() != "")
				{
					pageE=Convert.ToInt32(txtPageE.Text.Trim());
				}
				//如果开始页码大于结束页码，则开始页码即结束页码
				if (pageE<pageS)
					pageE=pageS;
			}

			rd.PrintToPrinter(1,false,pageS,pageE);

			if(myTb.TableName=="tabJydprt")
				kind=8;
			else
				kind=9;

			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				//更新zy_printzxd
				sSql="select id from zy_printzxd where order_id='"+myTb.Rows[i]["order_id"].ToString()+"' and kind="+kind.ToString();
				DataTable tempTab=InstanceForm.BDatabase.GetDataTable(sSql);
				if  (tempTab.Rows.Count>0)	
				{
					//已经打印，update
					sSql="update zy_printzxd set PRINT_DATE=getdate() , print_user="+InstanceForm.BCurrentUser.EmployeeId+" where order_id='"+myTb.Rows[i]["order_id"].ToString()+"' and kind="+kind.ToString();
				}
				else
				{
					//没有打印，插入记录
                    sSql = "insert into  zy_printzxd(KIND,ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values (" +
                        kind.ToString() + ",'" +
                        myTb.Rows[i]["order_id"].ToString() + "'," +
                        "getdate()," +
                        "getdate()," +
                        InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";
				}
				InstanceForm.BDatabase.DoCommand(sSql);
			}
		}

		private void cbPage_CheckedChanged(object sender, System.EventArgs e)
		{
			txtPageS.Enabled=cbPage.Checked;
			txtPageE.Enabled=cbPage.Checked;
			if(cbPage.Checked)
				txtPageS.Focus();
		}

		private void txtPageS_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				txtPageE.Focus();

			if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar!=8)
			{
				e.Handled=true;
			}
		}

		private void txtPageE_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				btnPrint.Focus();

			if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar!=8)
			{
				e.Handled=true;
			}
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        //--------------------------------------------------------------
        public class PaperSizeGetter
        {
            public static string OutputPort = String.Empty;

            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int DeviceCapabilities(string pDevice, string pPort, short fwCapabilities, IntPtr pOutput, IntPtr pDevMode);

            public static int[] Get_PaperSizes(string printer)
            {
                string text1 = printer;
                int num1 = FastDeviceCapabilities(0x10, IntPtr.Zero, -1, text1);
                if (num1 == -1)
                {
                    return new int[0];
                }
                int num2 = Marshal.SystemDefaultCharSize * 0x40;
                IntPtr ptr1 = Marshal.AllocCoTaskMem(num2 * num1);
                FastDeviceCapabilities(0x10, ptr1, -1, text1);
                IntPtr ptr2 = Marshal.AllocCoTaskMem(2 * num1);
                FastDeviceCapabilities(2, ptr2, -1, text1);
                IntPtr ptr3 = Marshal.AllocCoTaskMem(8 * num1);
                FastDeviceCapabilities(3, ptr3, -1, text1);
                int[] sizeArray1 = new int[num1];
                for (int num3 = 0; num3 < num1; num3++)
                {
                    string text2 = Marshal.PtrToStringAuto((IntPtr)(((long)ptr1) + (num2 * num3)), 0x40);
                    int num4 = text2.IndexOf('\0');
                    if (num4 > -1)
                    {
                        text2 = text2.Substring(0, num4);
                    }
                    short num5 = Marshal.ReadInt16((IntPtr)(((long)ptr2) + (num3 * 2)));
                    int num6 = Marshal.ReadInt32((IntPtr)(((long)ptr3) + (num3 * 8)));
                    int num7 = Marshal.ReadInt32((IntPtr)((((long)ptr3) + (num3 * 8)) + 4));
                    sizeArray1[num3] = System.Convert.ToInt32(num5);
                }
                Marshal.FreeCoTaskMem(ptr1);
                Marshal.FreeCoTaskMem(ptr2);
                Marshal.FreeCoTaskMem(ptr3);
                return sizeArray1;
            }

            private static int FastDeviceCapabilities(short capability, IntPtr pointerToBuffer, int defaultValue, string printerName)
            {
                int num1 = DeviceCapabilities(printerName, OutputPort, capability, pointerToBuffer, IntPtr.Zero);
                if (num1 == -1)
                {
                    return defaultValue;
                }
                return num1;
            }
        }
        //--------------------------------------------------------------
	}
}
