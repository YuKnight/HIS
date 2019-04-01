using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_jbjl
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmNEWJBJL : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;
		private string jobtime="";
		private string sqlStr;
		DataTable jbjlTb = new DataTable();
		DataTable brdtTb = new DataTable();

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.DateTimePicker DtpbeginDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button button3;
		private DataGridEx myDataGrid1;
		private DataGridEx myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private RichTextBoxEx rtbShow;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnClean;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblJobtime;
		private System.Windows.Forms.TextBox txtinput;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.IContainer components;

		public frmNEWJBJL(string _jobTime)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			jobtime=_jobTime;

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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rtbShow = new RichTextBoxEx(this.components);
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.panel5 = new System.Windows.Forms.Panel();
			this.myDataGrid2 = new DataGridEx();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.myDataGrid1 = new DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblJobtime = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnClean = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.txtinput = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.splitter2);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(864, 621);
			this.panel1.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.panel6);
			this.panel4.Controls.Add(this.splitter3);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 168);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(864, 453);
			this.panel4.TabIndex = 4;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.groupBox2);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(400, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(464, 453);
			this.panel6.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rtbShow);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.ForeColor = System.Drawing.Color.Blue;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(464, 453);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "特殊交班";
			// 
			// rtbShow
			// 
			this.rtbShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbShow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbShow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.rtbShow.LinkStyle = false;
			this.rtbShow.Location = new System.Drawing.Point(3, 17);
			this.rtbShow.Name = "rtbShow";
			this.rtbShow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.rtbShow.Size = new System.Drawing.Size(458, 433);
			this.rtbShow.TabIndex = 0;
			this.rtbShow.Text = "";
			// 
			// splitter3
			// 
			this.splitter3.Location = new System.Drawing.Point(392, 0);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(8, 453);
			this.splitter3.TabIndex = 1;
			this.splitter3.TabStop = false;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.myDataGrid2);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(392, 453);
			this.panel5.TabIndex = 3;
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.AllowSorting = false;
			this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid2.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid2.CaptionText = "病人动态";
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid2.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.ReadOnly = true;
			this.myDataGrid2.Size = new System.Drawing.Size(392, 453);
			this.myDataGrid2.TabIndex = 60;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			this.myDataGrid2.Tag = "";
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.AllowSorting = false;
			this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "";
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(0, 160);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(864, 8);
			this.splitter2.TabIndex = 3;
			this.splitter2.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.myDataGrid1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 60);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(864, 100);
			this.panel3.TabIndex = 2;
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.AllowSorting = false;
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid1.CaptionText = "交班记录";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid1.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.Size = new System.Drawing.Size(864, 100);
			this.myDataGrid1.TabIndex = 59;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid1.Tag = "";
			this.toolTip1.SetToolTip(this.myDataGrid1, "请手工输入“外出”人数，其他数字不能修改！");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 56);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(864, 4);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lblJobtime);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.btnClean);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Controls.Add(this.btCancel);
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.txtinput);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(864, 56);
			this.panel2.TabIndex = 3;
			// 
			// lblJobtime
			// 
			this.lblJobtime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblJobtime.Location = new System.Drawing.Point(80, 18);
			this.lblJobtime.Name = "lblJobtime";
			this.lblJobtime.Size = new System.Drawing.Size(96, 24);
			this.lblJobtime.TabIndex = 82;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(24, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 24);
			this.label2.TabIndex = 81;
			this.label2.Text = "班次：";
			// 
			// btnClean
			// 
			this.btnClean.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClean.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnClean.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnClean.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnClean.ImageIndex = 0;
			this.btnClean.Location = new System.Drawing.Point(624, 16);
			this.btnClean.Name = "btnClean";
			this.btnClean.Size = new System.Drawing.Size(72, 24);
			this.btnClean.TabIndex = 80;
			this.btnClean.Text = "清除(&C)";
			this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.DtpbeginDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(184, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 48);
			this.groupBox1.TabIndex = 78;
			this.groupBox1.TabStop = false;
			// 
			// DtpbeginDate
			// 
			this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
			this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm";
			this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DtpbeginDate.Location = new System.Drawing.Point(64, 16);
			this.DtpbeginDate.Name = "DtpbeginDate";
			this.DtpbeginDate.Size = new System.Drawing.Size(160, 23);
			this.DtpbeginDate.TabIndex = 71;
			this.DtpbeginDate.Value = new System.DateTime(2004, 8, 24, 0, 0, 0, 0);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 70;
			this.label1.Text = "日期：";
			// 
			// btCancel
			// 
			this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btCancel.ImageIndex = 0;
			this.btCancel.Location = new System.Drawing.Point(784, 16);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(64, 24);
			this.btCancel.TabIndex = 76;
			this.btCancel.Text = "退出(&E)";
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnSave.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnSave.ImageIndex = 0;
			this.btnSave.Location = new System.Drawing.Point(704, 16);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 75;
			this.btnSave.Text = "保存(&S)";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.button3.Enabled = false;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
			this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button3.ImageIndex = 0;
			this.button3.Location = new System.Drawing.Point(616, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(240, 40);
			this.button3.TabIndex = 77;
			// 
			// txtinput
			// 
			this.txtinput.AutoSize = false;
			this.txtinput.Location = new System.Drawing.Point(496, 16);
			this.txtinput.Name = "txtinput";
			this.txtinput.Size = new System.Drawing.Size(48, 16);
			this.txtinput.TabIndex = 83;
			this.txtinput.Text = "";
			this.txtinput.Visible = false;
			this.txtinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinput_KeyPress);
			this.txtinput.Validating += new System.ComponentModel.CancelEventHandler(this.txtinput_Validating);
			// 
			// frmNEWJBJL
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(864, 621);
			this.Controls.Add(this.panel1);
			this.MinimizeBox = false;
			this.Name = "frmNEWJBJL";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "新建交班记录";
			this.Load += new System.EventHandler(this.frmJBJL_Load);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmJBJL_Load(object sender, System.EventArgs e)
		{
			lblJobtime.Text=jobtime;

			Show_Data();

			string[] GrdMappingName1={"班次","原有","出院","转出","死亡","入院","转入","现有","手术","分娩","病危","病重","外出","特护","一级护理"};
			int[]    GrdWidth1      ={ 4,8,8,8,8,8,8,8,8,8,8,8,8,8,8};
			int[]    Alignment1     ={ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
			int[]	 ReadOnly1      ={ 0,0,0,0,0,0,0,0,0,0,0,0,1,0,0};
			myFunc.InitGrid(GrdMappingName1,GrdWidth1,Alignment1,ReadOnly1,this.myDataGrid1);

			string[] GrdMappingName2={"项目","床号","姓名","诊断","时间","type"};
			int[]    GrdWidth2      ={ 8,4,8,20,5,0};
			int[]    Alignment2     ={ 1,1,0,0,0,0};
			int[]	 ReadOnly2      ={ 0,0,0,0,0,0};
			myFunc.InitGrid(GrdMappingName2,GrdWidth2,Alignment2,ReadOnly2,this.myDataGrid2);

			rtbShow.Focus();
		}

		private void Show_Data()
		{
			try
			{
				sqlStr="exec sp_zyhs_seljbjl '"+InstanceForm.BCurrentDept.WardId+"','"+DtpbeginDate.Value+"','"+jobtime+"',0";
				jbjlTb=InstanceForm.BDatabase.GetDataTable(sqlStr);
				myDataGrid1.DataSource=jbjlTb;

				sqlStr="exec sp_zyhs_seljbjl '"+InstanceForm.BCurrentDept.WardId+"','"+DtpbeginDate.Value+"','"+jobtime+"',1";
				brdtTb=InstanceForm.BDatabase.GetDataTable(sqlStr);
				myDataGrid2.DataSource=brdtTb;
			}
			catch(Exception err)
			{
				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void txtinput_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			TextBox tb = (TextBox)sender;
			if (tb.Text.Trim()!="") jbjlTb.Rows[0]["外出"]=tb.Text;
			tb.Clear();
			tb.Visible=false;
		}

		private void txtinput_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar!=8 && e.KeyChar != 13 && e.KeyChar != 27)
			{
				e.Handled=true;
			}
			else if (e.KeyChar == 13)
			{
				txtinput.Visible=false;
				rtbShow.Focus();
			}
			else if (e.KeyChar == 27)
			{
				txtinput.Clear();
				txtinput.Visible=false;
				rtbShow.Focus();
			}
		}

		private void btnClean_Click(object sender, System.EventArgs e)
		{
			rtbShow.Clear();
			rtbShow.Focus();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{

			string msg;
			int i_jobtime=1;
			DataTable myTb = new DataTable();
			DataTable myTb1 = new DataTable();

			try
			{
				switch(lblJobtime.Text)
				{
					case "白班":
						i_jobtime=1;
						break;
					case "晚班":
						i_jobtime=2;
						break;
					case "夜班":
						i_jobtime=3;
						break;
				}
				if (rtbShow.Text.Trim()=="")
				{
					msg=MessageBox.Show(this,"特殊交班记录为空，是否继续？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString();
					if (msg.ToUpper()=="NO")
					{
						rtbShow.Focus();
						return;
					}
				}
				msg=MessageBox.Show(this,"交班记录一旦保存将不能修改，是否继续？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString();
				if (msg.ToUpper()=="NO")
				{
					rtbShow.Focus();
					return;
				}

				sqlStr="select 1 from zy_wardjbjl where jb_date='"+DtpbeginDate.Value.Date+"' and ward_id='"+InstanceForm.BCurrentDept.WardId+
					"' and jobtime="+i_jobtime;
				myTb1=InstanceForm.BDatabase.GetDataTable(sqlStr);
				if(myTb1.Rows.Count>0)
				{
					MessageBox.Show("该时段的交班报告已经存在，请核对！","提示",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					this.Close();
					return;
				}

                sqlStr = "INSERT INTO ZY_WARDJBJL(WARD_ID,JB_DATE,BOOK_USER,BOOK_DATE,JOBTIME,FORMERLY,GOOUT,TRANSOUT,DEATH," +
                    "COMEIN,TRANSIN,NOW,OPERATION,CHILDBIRTH,TERMINALLYILL,HEAVYILL,GOAWAY,SPECIALTEND,FIRSTTEND,JB_TEXT,jgbm) VALUES" +
                    "('" + InstanceForm.BCurrentDept.WardId + "','" + DtpbeginDate.Value.Date + "'," + InstanceForm.BCurrentUser.EmployeeId + ",getdate()," +
                    i_jobtime + "," + Convert.ToInt32(jbjlTb.Rows[0]["原有"].ToString()) + "," + Convert.ToInt32(jbjlTb.Rows[0]["出院"].ToString()) +
                    "," + Convert.ToInt32(jbjlTb.Rows[0]["转出"].ToString()) + "," + Convert.ToInt32(jbjlTb.Rows[0]["死亡"].ToString()) +
                    "," + Convert.ToInt32(jbjlTb.Rows[0]["入院"].ToString()) + "," + Convert.ToInt32(jbjlTb.Rows[0]["转入"].ToString()) +
                    "," + Convert.ToInt32(jbjlTb.Rows[0]["现有"].ToString()) + "," + Convert.ToInt32(jbjlTb.Rows[0]["手术"].ToString()) +
                    "," + Convert.ToInt32(jbjlTb.Rows[0]["分娩"].ToString()) + "," + Convert.ToInt32(jbjlTb.Rows[0]["病危"].ToString()) +
                    "," + Convert.ToInt32(jbjlTb.Rows[0]["病重"].ToString()) + "," + Convert.ToInt32(jbjlTb.Rows[0]["外出"].ToString()) +
                    "," + Convert.ToInt32(jbjlTb.Rows[0]["特护"].ToString()) + "," + Convert.ToInt32(jbjlTb.Rows[0]["一级护理"].ToString()) +
                    ",'" + rtbShow.Text + "'," + FrmMdiMain.Jgbm + ")";
				InstanceForm.BDatabase.DoCommand(sqlStr);

				sqlStr="select id from ZY_WARDJBJL where book_user="+InstanceForm.BCurrentUser.EmployeeId+" and JB_DATE='"+DtpbeginDate.Value.Date+"'"+
					" and jobtime="+i_jobtime+" and ward_id='"+InstanceForm.BCurrentDept.WardId+"'";
				myTb=InstanceForm.BDatabase.GetDataTable(sqlStr);

				for (int i=0;i<brdtTb.Rows.Count;i++)
				{
					sqlStr="INSERT INTO ZY_WARDJBJL_BRDT(JB_ID,ITEM,BED_NO,NAME,DIAGNOSES,TIME,jgbm) VALUES ("+Convert.ToInt32(myTb.Rows[0]["id"].ToString())+","+
						"'"+brdtTb.Rows[i]["项目"].ToString()+"','"+brdtTb.Rows[i]["床号"].ToString()+"','"+brdtTb.Rows[i]["姓名"].ToString()+"',"+
                        "'" + brdtTb.Rows[i]["诊断"].ToString() + "','" + brdtTb.Rows[i]["时间"].ToString() + "'," + FrmMdiMain.Jgbm + ")";
					InstanceForm.BDatabase.DoCommand(sqlStr);
				}

				MessageBox.Show(this,"保存成功！","保存",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.Close();
			}
			catch(Exception err)
			{
				//写错误日志 Add By Tany 2005-01-12
				SystemLog _systemErrLog=new SystemLog(-1,InstanceForm.BCurrentDept.DeptId,InstanceForm.BCurrentUser.EmployeeId,"程序错误","保存交班记录错误："+err.Message+"  Source："+err.Source,DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase),1,"主机名："+System.Environment.MachineName,39);
				_systemErrLog.Save();
				_systemErrLog=null;

				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

	}
}
