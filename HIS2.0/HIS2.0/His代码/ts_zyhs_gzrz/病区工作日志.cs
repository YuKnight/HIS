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

namespace ts_zyhs_gzrz
{
	/// <summary>
	/// frmWardGzrz 的摘要说明。
	/// </summary>
	public class frmGZRZ : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;

		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBox1;
        private ComboBox cmbdept;
        private Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGZRZ(string _formText)
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmbdept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Location = new System.Drawing.Point(83, 82);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(112, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(116, 147);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(88, 28);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(12, 147);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(88, 28);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "确定";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(44, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "病区工作日志";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "选择日期：";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(121, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 24);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "查询历史记录(&H)";
            // 
            // cmbdept
            // 
            this.cmbdept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdept.FormattingEnabled = true;
            this.cmbdept.Location = new System.Drawing.Point(84, 116);
            this.cmbdept.Name = "cmbdept";
            this.cmbdept.Size = new System.Drawing.Size(111, 20);
            this.cmbdept.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "选择病区：";
            // 
            // frmGZRZ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(235, 189);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbdept);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGZRZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病区工作日志";
            this.Load += new System.EventHandler(this.frmGZRZ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmGZRZ_Load(object sender, System.EventArgs e)
		{
			dateTimePicker1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            if (InstanceForm.BCurrentDept.WardId.Trim() == "")
            {
                AddcmbWardDept(cmbdept, "");
            }
            else
            {
                AddcmbWardDept(cmbdept, InstanceForm.BCurrentDept.WardId);
                cmbdept.Enabled = false;
            }
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			Cursor.Current=PubStaticFun.WaitCursor(); 

			DataSet ds=new DataSet();
			string sSql="";
			DataTable GzrzTb = new DataTable();
			DataTable GzrzMxTb = new DataTable();

			if(checkBox1.Checked)
			{
				sSql="select dbo.fun_zy_seekdeptname(DEPT_ID) 科别,"+
					"sum(YY) 原有,"+
					"sum(OUTALL) 出院合计,"+
					"sum(OUTZY) 治愈,"+
					"sum(OUTHZ) 好转,"+
					"sum(OUTWY) 未愈,"+
					"sum(OUTSW) 死亡,"+
					"sum(TRANSOUT) 转出,"+
					"sum([IN]) 入院,"+
					"sum(TRANSIN) 转入,"+
					"sum(NOW) 现有,"+
					"sum(OPER) 手术,"+
					"sum(BIRTH) 分娩,"+
					"sum(BW) 病危,"+
					"sum(BZ) 病重,"+
					"sum(TJHL) 特护,"+
					"sum(YJHL) 一级护理,"+
					"sum(PH) 陪护 from zy_wardgzrz where book_date = '"+dateTimePicker1.Value.ToShortDateString()+"'";
				sSql+=" and dept_id in (select dept_id from jc_wardrdept where ward_id ='"+cmbdept.SelectedValue.ToString().Trim()+"')";	
				sSql+=" group by DEPT_ID";
			}
			else
			{
				sSql="exec SP_ZYHS_wardgzrz '"+cmbdept.SelectedValue.ToString().Trim()+"','"+dateTimePicker1.Value.ToShortDateString()+"','"+dateTimePicker1.Value.ToShortDateString()+"',0";
			}
			GzrzTb=InstanceForm.BDatabase.GetDataTable(sSql);
			GzrzTb.TableName="tabWardGzrz";
			if(checkBox1.Checked)
			{
				sSql="select case type when 1 then '出院' "+
					"when 2 then '转出' "+
					"when 3 then '死亡' "+
					"when 4 then '入院' "+
					"when 5 then '转入' "+
					"when 6 then '手术' "+
					"when 7 then '分娩' "+
					"when 8 then '病危' "+
					"when 9 then '病重' end 项目, INPATIENT_NO 住院号,"+
					"BED_NO 床号,"+
					"NAME 姓名,"+
                    "ZD 诊断,dbo.fun_getdeptname(dept_id) 科别,'' 备注 from zy_wardgzrz_mx where book_date = '" + dateTimePicker1.Value.ToShortDateString() +
					"' and dept_id in (select dept_id from jc_wardrdept where ward_id ='"+cmbdept.SelectedValue.ToString().Trim()+"')";	
			}
			else
			{
				sSql="exec SP_ZYHS_wardgzrz '"+cmbdept.SelectedValue.ToString().Trim()+"','"+dateTimePicker1.Value.ToShortDateString()+"','"+dateTimePicker1.Value.ToShortDateString()+"',1";
			}
			GzrzMxTb=InstanceForm.BDatabase.GetDataTable(sSql);
			GzrzMxTb.TableName="tabWardGzrzMx";
            //add by zouchihua 2012-9-11 转科前的科室

			ds.Tables.Add(GzrzTb);
			ds.Tables.Add(GzrzMxTb);

			FrmReportView frmRptView=null;
			ParameterEx[] _parameters=new ParameterEx[4];

			_parameters[0].Text="医院名称";
			_parameters[0].Value=(new SystemCfg(0002)).Config;
			_parameters[1].Text="病区";
			_parameters[1].Value=(InstanceForm.BCurrentDept.WardName==""?this.cmbdept.Text:InstanceForm.BCurrentDept.WardName);
			_parameters[2].Text="填报人";
			_parameters[2].Value=InstanceForm.BCurrentUser.Name;
			_parameters[3].Text="日期加星期";
			_parameters[3].Value=dateTimePicker1.Value.ToShortDateString()+" "+PubStaticFun.GetCHNWeekName(dateTimePicker1.Value.DayOfWeek.ToString());

			frmRptView=new FrmReportView(ds,Constant.ApplicationDirectory+"\\report\\ZYHS_病区工作日志.rpt",_parameters);
			frmRptView.Show();

			Cursor.Current=Cursors.Default; 
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


        public  void AddcmbWardDept(System.Windows.Forms.ComboBox cmb,string wardid)
        {
            string swhere = "";
            string ssql = swhere + " select ward_name name,ward_id from JC_WARD  ";
            if (wardid.Trim() != "") ssql = ssql + " where ward_id='" + wardid.Trim() + "'";
            ssql = ssql + "order by ward_id";
            DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(ssql);
            cmb.DataSource = tb;
            cmb.ValueMember = "ward_id";
            cmb.DisplayMember = "name";
        }
	}
}
