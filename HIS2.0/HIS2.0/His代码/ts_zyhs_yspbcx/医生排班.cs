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

namespace ts_zyhs_yspbcx
{
	/// <summary>
	/// Form2 的摘要说明。
	/// </summary>
	public class frmYSPBCX : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;
		private System.DateTime Data1,Data7; //星期一 星期日
		private string ColName1="",ColName2="",ColName3="",ColName4="",ColName5="",ColName6="",ColName7="";

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.DateTimePicker DtpbeginDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bt查询;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btCancel;
		private DataGridEx myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmYSPBCX(string _formText)
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
			this.myDataGrid1 = new DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btCancel = new System.Windows.Forms.Button();
			this.bt查询 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
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
			this.panel1.Size = new System.Drawing.Size(824, 445);
			this.panel1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.myDataGrid1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 60);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(824, 385);
			this.panel3.TabIndex = 2;
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.AllowSorting = false;
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid1.CaptionText = "医生排班";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.ReadOnly = true;
			this.myDataGrid1.Size = new System.Drawing.Size(824, 385);
			this.myDataGrid1.TabIndex = 26;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
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
			this.splitter1.Size = new System.Drawing.Size(824, 4);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btCancel);
			this.panel2.Controls.Add(this.bt查询);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(824, 56);
			this.panel2.TabIndex = 0;
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btCancel.ImageIndex = 0;
			this.btCancel.Location = new System.Drawing.Point(736, 16);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(64, 24);
			this.btCancel.TabIndex = 60;
			this.btCancel.Text = "退出(&E)";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// bt查询
			// 
			this.bt查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt查询.BackColor = System.Drawing.SystemColors.ControlLight;
			this.bt查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt查询.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.bt查询.ForeColor = System.Drawing.SystemColors.Desktop;
			this.bt查询.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bt查询.ImageIndex = 0;
			this.bt查询.Location = new System.Drawing.Point(664, 16);
			this.bt查询.Name = "bt查询";
			this.bt查询.Size = new System.Drawing.Size(64, 24);
			this.bt查询.TabIndex = 59;
			this.bt查询.Text = "查询(&C)";
			this.bt查询.Click += new System.EventHandler(this.bt查询_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.button3.Enabled = false;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
			this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button3.ImageIndex = 0;
			this.button3.Location = new System.Drawing.Point(656, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(152, 40);
			this.button3.TabIndex = 58;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.DtpbeginDate);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(8, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(224, 48);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			// 
			// DtpbeginDate
			// 
			this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
			this.DtpbeginDate.CustomFormat = "yyyy-MM-dd";
			this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.DtpbeginDate.Location = new System.Drawing.Point(104, 16);
			this.DtpbeginDate.Name = "DtpbeginDate";
			this.DtpbeginDate.Size = new System.Drawing.Size(104, 23);
			this.DtpbeginDate.TabIndex = 0;
			this.DtpbeginDate.Value = new System.DateTime(2003, 9, 20, 19, 22, 0, 0);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "请选择日期：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmYSPBCX
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(824, 445);
			this.Controls.Add(this.panel1);
			this.Name = "frmYSPBCX";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "医生排班查询";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmYSPBCX_Load);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmYSPBCX_Load(object sender, System.EventArgs e)
		{
			//当前日期是服务器当前系统日期
			this.DtpbeginDate.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);                     
			//最大值是今天+7天
			this.DtpbeginDate.MaxDate=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(14).ToShortDateString() + " 23:59:59");	
			//最小日期是2002年8月1日
			//this.DtpbeginDate.MinDate=Convert.ToDateTime("2004-8-1 00:00:00");  
			this.DtpbeginDate.Focus();
		}

		private void GetData1()
		{
			System.DateTime Data0=Convert.ToDateTime(this.DtpbeginDate.Value.ToShortDateString()+" 00:00:00");
			int daynum=0;
			switch(Data0.DayOfWeek.ToString())
			{
				case "Monday":
					daynum=1;
					break;
				case "Tuesday":
					daynum=2;
					break;					
				case "Wednesday":
					daynum=3;
					break;					
				case "Thursday":
					daynum=4;
					break;
				case "Friday":
					daynum=5;
					break;
				case "Saturday":
					daynum=6;
					break;
				case "Sunday":
					daynum=7;
					break;				
			}
			System.TimeSpan diff = new System.TimeSpan(daynum-1, 0, 0, 0);  			
			this.Data1=Data0.Subtract(diff);
			this.Data7=Data1.AddDays(6);	  		
			this.DtpbeginDate.Value=this.Data1;		
			this.ColName1="("+this.Data1.Month.ToString()+"."+this.Data1.Day.ToString()+")";
			this.ColName2="("+this.Data1.AddDays(1).Month.ToString()+"."+this.Data1.AddDays(1).Day.ToString()+")";
			this.ColName3="("+this.Data1.AddDays(2).Month.ToString()+"."+this.Data1.AddDays(2).Day.ToString()+")";
			this.ColName4="("+this.Data1.AddDays(3).Month.ToString()+"."+this.Data1.AddDays(3).Day.ToString()+")";
			this.ColName5="("+this.Data1.AddDays(4).Month.ToString()+"."+this.Data1.AddDays(4).Day.ToString()+")";
			this.ColName6="("+this.Data1.AddDays(5).Month.ToString()+"."+this.Data1.AddDays(5).Day.ToString()+")";
			this.ColName7="("+this.Data1.AddDays(6).Month.ToString()+"."+this.Data1.AddDays(6).Day.ToString()+")";
		}

		private void Show_data(bool isRead)
		{
			string sSql="select 科室,姓名, "+
                "       (select name from jc_arrange where code=a1 and kind=0) as NAME1,"+
                "       (select name from jc_arrange where code=a2 and kind=0) as NAME2,"+
                "       (select name from jc_arrange where code=a3 and kind=0) as NAME3,"+
                "       (select name from jc_arrange where code=a4 and kind=0) as NAME4,"+
                "       (select name from jc_arrange where code=a5 and kind=0) as NAME5,"+
                "       (select name from jc_arrange where code=a6 and kind=0) as NAME6,"+
                "       (select name from jc_arrange where code=a7 and kind=0) as NAME7"+
                "  from (select 科室,姓名,sum(a1) a1,sum(a2) a2 ,sum(a3) a3 ,sum(a4) a4 ,sum(a5) a5,sum(a6) a6 ,sum(a7)  a7 from "+
                " (select dbo.FUN_ZY_SEEKDEPTNAME(DEPT_ID) 科室, dbo.FUN_ZY_SEEKEMPLOYEENAME(employee_id) 姓名,"+
				"               case when work_date='"+this.Data1.ToString()+"' then (select(code) from jc_arrange where name=time_slot and kind=0) else 0  end as a1,"+
				"               case when work_date='"+this.Data1.AddDays(1).ToString()+"' then (select(code) from jc_arrange where name=time_slot and kind=0) else 0  end as a2,"+
				"               case when work_date='"+this.Data1.AddDays(2).ToString()+"' then (select(code) from jc_arrange where name=time_slot and kind=0) else 0  end as a3,"+
				"               case when work_date='"+this.Data1.AddDays(3).ToString()+"' then (select(code) from jc_arrange where name=time_slot and kind=0) else 0  end as a4,"+
				"               case when work_date='"+this.Data1.AddDays(4).ToString()+"' then (select(code) from jc_arrange where name=time_slot and kind=0) else 0  end as a5,"+
				"               case when work_date='"+this.Data1.AddDays(5).ToString()+"' then (select(code) from jc_arrange where name=time_slot and kind=0) else 0  end as a6,"+
				"               case when work_date='"+this.Data1.AddDays(6).ToString()+"' then (select(code) from jc_arrange where name=time_slot and kind=0) else 0  end as a7"+				
				"  from zy_shift"+
				" where dept_id in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"')"+
                "       and work_date between '"+this.Data1.ToString()+"' and '"+this.Data7.ToShortDateString()+"') tmp"+
                " group by 科室,姓名) as b order by 科室,姓名";

			myFunc.ShowGrid(0,sSql,this.myDataGrid1);
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;

			this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
			string[] GrdMappingName={"科室","姓名","NAME1","NAME2","NAME3","NAME4","NAME5","NAME6","NAME7"};
			int[]    GrdWidth      ={18,10,12,12,12,12,12,12,12};
			int[]    Alignment     ={1, 1, 1, 1, 1, 1, 1, 1, 1};	
			int[] ReadOnly0        ={0, 0, 0, 0, 0, 0, 0, 0, 0};
			myFunc.InitGrid(GrdMappingName,GrdWidth,Alignment,ReadOnly0,this.myDataGrid1);
			
			this.myDataGrid1.TableStyles[0].GridColumnStyles[2].HeaderText="星期一"+this.ColName1;
			this.myDataGrid1.TableStyles[0].GridColumnStyles[3].HeaderText="星期二"+this.ColName2;
			this.myDataGrid1.TableStyles[0].GridColumnStyles[4].HeaderText="星期三"+this.ColName3;
			this.myDataGrid1.TableStyles[0].GridColumnStyles[5].HeaderText="星期四"+this.ColName4;
			this.myDataGrid1.TableStyles[0].GridColumnStyles[6].HeaderText="星期五"+this.ColName5;
			this.myDataGrid1.TableStyles[0].GridColumnStyles[7].HeaderText="星期六"+this.ColName6;
			this.myDataGrid1.TableStyles[0].GridColumnStyles[8].HeaderText="星期日"+this.ColName7;
		}


		private void bt查询_Click(object sender, System.EventArgs e)
		{
			this.GetData1();
			Cursor.Current=PubStaticFun.WaitCursor(); 
			this.Show_data(true);
			Cursor.Current=Cursors.Default;	
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


	}
}
