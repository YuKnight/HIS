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

namespace ts_zyhs_crtj
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmCRTJ : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button bt保存;
		private System.Windows.Forms.Button bt查询;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox2;
		private DataGridEx myDataGrid1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DateTimePicker DtpbeginDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button bt打印;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCRTJ(string _formText)
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
            this.btCancel = new System.Windows.Forms.Button();
            this.bt保存 = new System.Windows.Forms.Button();
            this.bt查询 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.bt打印 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(295, 240);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 61;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // bt保存
            // 
            this.bt保存.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt保存.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt保存.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt保存.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt保存.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt保存.ImageIndex = 0;
            this.bt保存.Location = new System.Drawing.Point(70, 240);
            this.bt保存.Name = "bt保存";
            this.bt保存.Size = new System.Drawing.Size(64, 24);
            this.bt保存.TabIndex = 60;
            this.bt保存.Text = "保存(&S)";
            this.bt保存.UseVisualStyleBackColor = false;
            this.bt保存.Visible = false;
            this.bt保存.Click += new System.EventHandler(this.bt保存_Click);
            // 
            // bt查询
            // 
            this.bt查询.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt查询.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt查询.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt查询.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt查询.ImageIndex = 0;
            this.bt查询.Location = new System.Drawing.Point(225, 240);
            this.bt查询.Name = "bt查询";
            this.bt查询.Size = new System.Drawing.Size(64, 24);
            this.bt查询.TabIndex = 59;
            this.bt查询.Text = "查询(&C)";
            this.bt查询.UseVisualStyleBackColor = false;
            this.bt查询.Click += new System.EventHandler(this.bt查询_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(216, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 40);
            this.button3.TabIndex = 62;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.DtpbeginDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 224);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 67;
            this.label3.Text = "日期：";
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd";
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(56, 16);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(104, 23);
            this.DtpbeginDate.TabIndex = 66;
            this.DtpbeginDate.Value = new System.DateTime(2003, 9, 20, 19, 22, 0, 0);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 40);
            this.label2.TabIndex = 65;
            this.label2.Text = "备注：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 168);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 48);
            this.textBox1.TabIndex = 59;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "病室床日报表";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(8, 48);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.RowHeadersVisible = false;
            this.myDataGrid1.Size = new System.Drawing.Size(344, 112);
            this.myDataGrid1.TabIndex = 58;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Tag = "";
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(176, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 64;
            this.label1.Text = "填报人：";
            // 
            // bt打印
            // 
            this.bt打印.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt打印.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt打印.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt打印.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt打印.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt打印.ImageIndex = 0;
            this.bt打印.Location = new System.Drawing.Point(0, 240);
            this.bt打印.Name = "bt打印";
            this.bt打印.Size = new System.Drawing.Size(64, 24);
            this.bt打印.TabIndex = 64;
            this.bt打印.Text = "打印(&P)";
            this.bt打印.UseVisualStyleBackColor = false;
            this.bt打印.Visible = false;
            this.bt打印.Click += new System.EventHandler(this.bt打印_Click);
            // 
            // frmCRTJ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(376, 277);
            this.Controls.Add(this.bt打印);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.bt保存);
            this.Controls.Add(this.bt查询);
            this.Controls.Add(this.button3);
            this.Name = "frmCRTJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "床日统计";
            this.Load += new System.EventHandler(this.frmCRTJ_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmCRTJ_Load(object sender, System.EventArgs e)
		{
			this.DtpbeginDate.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);   
			this.DtpbeginDate.MaxDate=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

			this.Show_Date();	

			string[] GrdMappingName1={"所属科室","占床数","空床数","总床数","使用率"};
			int[]    GrdWidth1      ={ 20,6,6,6,6};
			int[]    Alignment1     ={ 0,1,1,1,1};
			int[]	 ReadOnly1      ={ 0,0,0,0,0};
			myFunc.InitGrid(GrdMappingName1,GrdWidth1,Alignment1,ReadOnly1,this.myDataGrid1);

			this.label1.Text="填报人："+InstanceForm.BCurrentUser.Name;
		}

		private void Show_Date()
		{
            string sSql = "  select b.name 所属科室 ,sum(a.brs) 占床数 ,case when sum(b.cws)-sum(a.brs)<0 then 0 else sum(b.cws)-sum(a.brs) end 空床数,sum(b.cws) 总床数,convert(varchar,convert(decimal(10,2),((convert(decimal(10,2),sum(a.brs))/convert(decimal(10,2),sum(b.cws))*100))))+'%' 使用率" +
                        "  from (select dept_id,0 zcs,count(1) brs,0 kcs FROM vi_ZY_vInpatient where (flag = 3 or (flag in (2,4,5,6) and out_date>getdate())) group by dept_id) a,(select count(1) cws,dept_id,dbo.fun_getdeptname(dept_id) name from zy_beddiction where isinuse=0 and isplus=0 group by dept_id) b " +
                        "  where a.dept_id=b.dept_id "+
                        "        and a.dept_id in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"') "+
                        "  group by b.name";
			myFunc.ShowGrid(0,sSql,this.myDataGrid1);

            //string sSql = "with tmp(dept_id,zcs,brs,kcs) as( " +
            //                            " select dept_id,count(dept_id),0,0 from zy_beddiction where isplus=0 group by dept_id "+
            //                            " union  "+
            //                            " select inpatient_dept,0,count(inpatient_dept),0 from zy_beddiction where inpatient_dept is not null group by inpatient_dept "+
            //                            " union  "+
            //                            " select inpatient_dept,0,count(inpatient_dept),0 from zy_beddiction where inpatient_dept is null and isBF=1 group by inpatient_dept "+
            //                            " union "+
            //                            " select dept_id,0,0,count(dept_id) from zy_beddiction where isplus=0 and inpatient_dept is null and isBF=0  group by dept_id "+
            //                            " ) select b.name 所属科室 ,sum(a.brs) 占床数 ,sum(a.kcs) 空床数,sum(a.zcs) 总床数,CHGDECIMALTOCHAR(round(decimal(sum(a.brs))/decimal(sum(a.zcs))*100,2))||'%' 使用率"+
            //            "SELECT dept_id,0,count(1),0 FROM ZY_vInpatient where (flag = 3 or (flag in (2,4,5,6) and out_date>timestamp(char(current date)||' '||'23:59:59'))) group by dept_id" +
            //    Modify By Tany 2005-01-11 和病案统计一致
            //            " ) select b.name 所属科室 ,sum(a.brs) 占床数 ,case when sum(b.cws)-sum(a.brs)<0 then 0 else sum(b.cws)-sum(a.brs) end 空床数,sum(b.cws) 总床数,CHGDECIMALTOCHAR(round(decimal(sum(a.brs))/decimal(sum(b.cws))*100,2))||'%' 使用率" +
            //            "     from tmp a,base_dept_property b " +
            //            "    where a.dept_id=b.dept_id " +
            //            "          and a.dept_id in (select dept_id from base_wardrdept where ward_id='" + ClassStatic.Static_WardID + "') " +
            //            "    group by b.name";
		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			myFunc.SelRow(this.myDataGrid1);
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void bt保存_Click(object sender, System.EventArgs e)
		{
		
		}

		private void bt打印_Click(object sender, System.EventArgs e)
		{
		
		}

		private void bt查询_Click(object sender, System.EventArgs e)
		{
			Show_Date();
		}
	}
}
