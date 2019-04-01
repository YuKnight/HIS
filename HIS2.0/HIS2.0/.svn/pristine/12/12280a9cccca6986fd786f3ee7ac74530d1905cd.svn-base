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

namespace ts_zyhs_kssr
{
	/// <summary>
	/// Form2 的摘要说明。
	/// </summary>
	public class FrmSrtj : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpBeginDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker DtpEndDate;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button bt统计;
		private System.Windows.Forms.Button bt打印;
		private System.Windows.Forms.Button bt退出;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbKind1;
		private System.Windows.Forms.RadioButton rbKind2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private DataGridEx myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private TheReportDateSet rds=new TheReportDateSet();
		private DataRow dr;
		private System.Windows.Forms.RadioButton rbKind3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmSrtj(string _formText)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.Text=_formText;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbKind3 = new System.Windows.Forms.RadioButton();
            this.rbKind1 = new System.Windows.Forms.RadioButton();
            this.rbKind2 = new System.Windows.Forms.RadioButton();
            this.bt退出 = new System.Windows.Forms.Button();
            this.bt打印 = new System.Windows.Forms.Button();
            this.bt统计 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 597);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 537);
            this.panel3.TabIndex = 2;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(1008, 537);
            this.myDataGrid1.TabIndex = 4;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 56);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1008, 4);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.bt退出);
            this.panel2.Controls.Add(this.bt打印);
            this.panel2.Controls.Add(this.bt统计);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 56);
            this.panel2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rbKind3);
            this.groupBox3.Controls.Add(this.rbKind1);
            this.groupBox3.Controls.Add(this.rbKind2);
            this.groupBox3.Location = new System.Drawing.Point(352, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 48);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "统计范围";
            // 
            // rbKind3
            // 
            this.rbKind3.Location = new System.Drawing.Point(280, 16);
            this.rbKind3.Name = "rbKind3";
            this.rbKind3.Size = new System.Drawing.Size(128, 24);
            this.rbKind3.TabIndex = 2;
            this.rbKind3.Text = "按本科室在外科室";
            // 
            // rbKind1
            // 
            this.rbKind1.Checked = true;
            this.rbKind1.Location = new System.Drawing.Point(8, 16);
            this.rbKind1.Name = "rbKind1";
            this.rbKind1.Size = new System.Drawing.Size(136, 24);
            this.rbKind1.TabIndex = 1;
            this.rbKind1.TabStop = true;
            this.rbKind1.Text = "按执行地点所属科室";
            // 
            // rbKind2
            // 
            this.rbKind2.Location = new System.Drawing.Point(156, 16);
            this.rbKind2.Name = "rbKind2";
            this.rbKind2.Size = new System.Drawing.Size(112, 24);
            this.rbKind2.TabIndex = 0;
            this.rbKind2.Text = "按病人所属科室";
            // 
            // bt退出
            // 
            this.bt退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt退出.ImageIndex = 4;
            this.bt退出.Location = new System.Drawing.Point(928, 16);
            this.bt退出.Name = "bt退出";
            this.bt退出.Size = new System.Drawing.Size(64, 24);
            this.bt退出.TabIndex = 52;
            this.bt退出.Text = "退出(&E)";
            this.bt退出.Click += new System.EventHandler(this.bt退出_Click);
            // 
            // bt打印
            // 
            this.bt打印.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt打印.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt打印.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt打印.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt打印.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt打印.ImageIndex = 4;
            this.bt打印.Location = new System.Drawing.Point(856, 16);
            this.bt打印.Name = "bt打印";
            this.bt打印.Size = new System.Drawing.Size(64, 24);
            this.bt打印.TabIndex = 51;
            this.bt打印.Text = "打印(&P)";
            this.bt打印.Click += new System.EventHandler(this.bt打印_Click);
            // 
            // bt统计
            // 
            this.bt统计.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt统计.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt统计.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt统计.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt统计.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt统计.ImageIndex = 4;
            this.bt统计.Location = new System.Drawing.Point(784, 16);
            this.bt统计.Name = "bt统计";
            this.bt统计.Size = new System.Drawing.Size(64, 24);
            this.bt统计.TabIndex = 50;
            this.bt统计.Text = "统计(&T)";
            this.bt统计.Click += new System.EventHandler(this.bt统计_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageIndex = 4;
            this.button4.Location = new System.Drawing.Point(776, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(224, 40);
            this.button4.TabIndex = 49;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpBeginDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtpEndDate);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计日期";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = " 从：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.CustomFormat = "";
            this.dtpBeginDate.Location = new System.Drawing.Point(48, 16);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(112, 21);
            this.dtpBeginDate.TabIndex = 0;
            this.dtpBeginDate.Value = new System.DateTime(2003, 9, 27, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(168, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "到：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpEndDate
            // 
            this.DtpEndDate.Location = new System.Drawing.Point(208, 16);
            this.DtpEndDate.Name = "DtpEndDate";
            this.DtpEndDate.Size = new System.Drawing.Size(112, 21);
            this.DtpEndDate.TabIndex = 1;
            this.DtpEndDate.Value = new System.DateTime(2003, 9, 27, 23, 59, 0, 0);
            // 
            // FrmSrtj
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1008, 597);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSrtj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收入统计报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSRTJ_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmSRTJ_Load(object sender, System.EventArgs e)
		{
			this.dtpBeginDate.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Year.ToString()+"-"+DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Month.ToString() +"-1 00:00:00");
			this.DtpEndDate.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

			string[] GrdMappingName1={"科室名称","床位费","药品费","检验费","治疗费","放射费","输血费","检查费","放疗费","手术费","其他费","挂号费","诊查费","护理费","特殊材料费","合计"};
			int[]    GrdWidth1      ={12,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10};
			int[]    Alignment1     ={ 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2};
			int[]	 ReadOnly1      ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
			myFunc.InitGrid(GrdMappingName1,GrdWidth1,Alignment1,ReadOnly1,this.myDataGrid1);	
		}

		private void bt统计_Click(object sender, System.EventArgs e)
		{
			string sSql="";
			if (this.DtpEndDate.Value<this.dtpBeginDate.Value)
			{
				MessageBox.Show(this,"对不起，结束日期不能小于开始日期！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);										
				return;
			}

			this.dtpBeginDate.Value=Convert.ToDateTime(this.dtpBeginDate.Value.ToShortDateString()+" 00:00:00");
			this.DtpEndDate.Value=Convert.ToDateTime(this.DtpEndDate.Value.ToShortDateString() + " 23:59:59");
			string ss=InstanceForm.BCurrentDept.WardName+"收入报表";
			ss+=this.rbKind1.Checked?"(按执行地点统计)":this.rbKind2.Checked?"(按病人所属科室统计)":"(按本科室在外科室)";			
			ss+="[日期从："+this.dtpBeginDate.Value.Year.ToString()+"-"+this.dtpBeginDate.Value.Month.ToString()+"-"+this.dtpBeginDate.Value.Day.ToString()+" 到 "+this.DtpEndDate.Value.Year.ToString()+"-"+this.DtpEndDate.Value.Month.ToString()+"-"+this.DtpEndDate.Value.Day.ToString()+"]";
			this.myDataGrid1.CaptionText=ss;

			Cursor.Current=PubStaticFun.WaitCursor(); 
			try
			{
//				OleDbConnection tempCon=new OleDbConnection();
//				tempCon.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Database Password=;Data Source=c:\winnt\db1.mdb;Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
//				tempCon.Open();
//
//				OleDbCommand myCmd=new OleDbCommand();
//				myCmd.Connection=tempCon;
//
//				//清空原有数据
//				myCmd.CommandText="delete from FeeHZD";	
//				myCmd.ExecuteNonQuery();
				rds.Tables["BRFeeHZD"].Clear();

				int j=this.rbKind1.Checked?0:this.rbKind2.Checked?1:2;
//				int id=0;
				DataTable myTb=myFunc.GetFeeTotal("",j,InstanceForm.BCurrentDept.WardId,this.dtpBeginDate.Value,this.DtpEndDate.Value);
				
				if	(myTb.Rows.Count>=1)
				{			
					//插入信息到临时数据库
					for(int i=0;i<=myTb.Rows.Count-1;i++)
					{
//						id+=1;
//						sSql=@"INSERT INTO FeeHZD(科室名称,床位费,药品费,检验费,治疗费,放射费,输血费,检查费,放疗费,手术费,其他费,挂号费,诊查费,护理费,特殊材料费,合计,ID)									
//									VALUES(" +
//							"'" + myTb.Rows[i]["科室名称"].ToString()+"',"+							
//							Convert.ToDouble(myTb.Rows[i]["床位费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["药品费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["检验费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["治疗费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["放射费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["输血费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["检查费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["放疗费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["手术费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["其他费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["挂号费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["诊查费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["护理费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["特殊材料费"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["合计"])+ "," +
//							id.ToString()+")";						
//						myCmd.CommandText=sSql;
//						myCmd.ExecuteNonQuery();
						dr=rds.Tables["BRFeeHZD"].NewRow();
						dr["科室名称"]=myTb.Rows[i]["科室名称"].ToString();
						dr["床位费"]=Convert.ToDouble(myTb.Rows[i]["床位费"]);
						dr["药品费"]=Convert.ToDouble(myTb.Rows[i]["药品费"]);
						dr["检验费"]=Convert.ToDouble(myTb.Rows[i]["检验费"]);
						dr["治疗费"]=Convert.ToDouble(myTb.Rows[i]["治疗费"]);
						dr["放射费"]=Convert.ToDouble(myTb.Rows[i]["放射费"]);
						dr["输血费"]=Convert.ToDouble(myTb.Rows[i]["输血费"]);
						dr["检查费"]=Convert.ToDouble(myTb.Rows[i]["检查费"]);
						dr["放疗费"]=Convert.ToDouble(myTb.Rows[i]["放疗费"]);
						dr["手术费"]=Convert.ToDouble(myTb.Rows[i]["手术费"]);
						dr["其他费"]=Convert.ToDouble(myTb.Rows[i]["其他费"]);
						dr["挂号费"]=Convert.ToDouble(myTb.Rows[i]["挂号费"]);
						dr["诊查费"]=Convert.ToDouble(myTb.Rows[i]["诊查费"]);
						dr["护理费"]=Convert.ToDouble(myTb.Rows[i]["护理费"]);
						dr["特殊材料费"]=Convert.ToDouble(myTb.Rows[i]["特殊材料费"]);
						dr["合计"]=Convert.ToDouble(myTb.Rows[i]["合计"]);
						dr["ID"]=i.ToString();
						rds.Tables["BRFeeHZD"].Rows.Add(dr);
					}
				}
				
				if (myTb.Rows.Count>1)
				{
//					sSql="INSERT INTO FeeHZD (科室名称,床位费,药品费,检验费,治疗费,放射费,输血费,检查费,放疗费,手术费,其他费,挂号费,诊查费,护理费,特殊材料费,合计,ID)"+
//						" select '总计', sum(床位费),sum(药品费),sum(检验费),sum(治疗费),sum(放射费),sum(输血费),sum(检查费),sum(放疗费),"+
//						"                sum(手术费),sum(其他费),sum(挂号费),sum(诊查费),sum(护理费),sum(特殊材料费),sum(合计),99"+
//						"   from feehzd ";
//					myCmd.CommandText=sSql;
//					myCmd.ExecuteNonQuery();
					dr=rds.Tables["BRFeeHZD"].NewRow();
					dr["科室名称"]="总计";
					dr["床位费"]=Convert.ToDouble(myTb.Compute("sum(床位费)","1=1"));
					dr["药品费"]=Convert.ToDouble(myTb.Compute("sum(药品费)","1=1"));
					dr["检验费"]=Convert.ToDouble(myTb.Compute("sum(检验费)","1=1"));
					dr["治疗费"]=Convert.ToDouble(myTb.Compute("sum(治疗费)","1=1"));
					dr["放射费"]=Convert.ToDouble(myTb.Compute("sum(放射费)","1=1"));
					dr["输血费"]=Convert.ToDouble(myTb.Compute("sum(输血费)","1=1"));
					dr["检查费"]=Convert.ToDouble(myTb.Compute("sum(检查费)","1=1"));
					dr["放疗费"]=Convert.ToDouble(myTb.Compute("sum(放疗费)","1=1"));
					dr["手术费"]=Convert.ToDouble(myTb.Compute("sum(手术费)","1=1"));
					dr["其他费"]=Convert.ToDouble(myTb.Compute("sum(其他费)","1=1"));
					dr["挂号费"]=Convert.ToDouble(myTb.Compute("sum(挂号费)","1=1"));
					dr["诊查费"]=Convert.ToDouble(myTb.Compute("sum(诊查费)","1=1"));
					dr["护理费"]=Convert.ToDouble(myTb.Compute("sum(护理费)","1=1"));
					dr["特殊材料费"]=Convert.ToDouble(myTb.Compute("sum(特殊材料费)","1=1"));
					dr["合计"]=Convert.ToDouble(myTb.Compute("sum(合计)","1=1"));
					dr["ID"]=99;
					rds.Tables["BRFeeHZD"].Rows.Add(dr);
				}				

//				sSql="select * from feehzd";
//				DataTable myTempTb=new DataTable();
//				myTempTb=myOpenAss(tempCon,sSql);
				DataTable myTempTb=rds.Tables["BRFeeHZD"];
				this.myDataGrid1.DataSource=myTempTb;
				this.myDataGrid1.TableStyles[0].RowHeaderWidth=5;			
//				tempCon.Close(); //关闭临时连接
			}								
			catch(System.Data.OleDb.OleDbException err)
			{
				//关闭临时连接
				MessageBox.Show(err.ToString());
			}
			Cursor.Current=Cursors.Default;	
		}

		private void bt打印_Click(object sender, System.EventArgs e)
		{
			DataTable prtTb = (DataTable)myDataGrid1.DataSource;

			if(prtTb==null || prtTb.Rows.Count==0) return;

			FrmReportView frmRptView=null;
			ParameterEx[] _parameters=new ParameterEx[2];

			_parameters[0].Text="表头";
			_parameters[0].Value=this.myDataGrid1.CaptionText;
			_parameters[1].Text="打印者";
			_parameters[1].Value="打印者："+ InstanceForm.BCurrentUser.Name;

			frmRptView=new FrmReportView(rds,Constant.ApplicationDirectory+"\\report\\ZYHS_科室收入报表.rpt",_parameters);
			frmRptView.Show();
		}

		private DataTable myOpenAss(OleDbConnection cCon,string sSql)
		{
			DataTable myTb=new DataTable();
			try
			{
				System.Data.OleDb.OleDbCommand mySelCmd=new OleDbCommand();
				mySelCmd.CommandText=sSql;			
				mySelCmd.Connection=cCon;
				mySelCmd.CommandType=System.Data.CommandType.Text ;
				System.Data.OleDb.OleDbDataAdapter myAdp=new OleDbDataAdapter();
				myAdp.SelectCommand=mySelCmd;
				myAdp.Fill(myTb);
			}
			catch(System.Data.OleDb.OleDbException err)
			{
				MessageBox.Show(err.ToString());
			}			
			return myTb;
		}

		private void bt退出_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
