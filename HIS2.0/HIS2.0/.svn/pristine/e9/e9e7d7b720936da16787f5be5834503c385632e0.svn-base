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

namespace ts_zyhs_kqtj
{
	/// <summary>
	/// 排班工作量统计 的摘要说明。
	/// </summary>
	public class frmKQTJ : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;
		DataTable myTb = new DataTable();
		string sqlStr="";
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKQTJ(string _formText)
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
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dtpBegin = new System.Windows.Forms.DateTimePicker();
			this.dtpEnd = new System.Windows.Forms.DateTimePicker();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.AllowSorting = false;
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 112);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.PreferredColumnWidth = 60;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(640, 320);
			this.dataGrid1.TabIndex = 0;
			// 
			// dtpBegin
			// 
			this.dtpBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpBegin.Location = new System.Drawing.Point(80, 72);
			this.dtpBegin.Name = "dtpBegin";
			this.dtpBegin.Size = new System.Drawing.Size(128, 23);
			this.dtpBegin.TabIndex = 1;
			// 
			// dtpEnd
			// 
			this.dtpEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpEnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpEnd.Location = new System.Drawing.Point(280, 72);
			this.dtpEnd.Name = "dtpEnd";
			this.dtpEnd.Size = new System.Drawing.Size(128, 23);
			this.dtpEnd.TabIndex = 2;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnRefresh.ImageIndex = 0;
			this.btnRefresh.Location = new System.Drawing.Point(432, 72);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(64, 24);
			this.btnRefresh.TabIndex = 70;
			this.btnRefresh.Text = "刷新(&R)";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
			this.btCancel.Location = new System.Drawing.Point(576, 72);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(64, 24);
			this.btCancel.TabIndex = 68;
			this.btCancel.Text = "退出(&E)";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnPrint.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnPrint.ImageIndex = 0;
			this.btnPrint.Location = new System.Drawing.Point(504, 72);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(64, 24);
			this.btnPrint.TabIndex = 67;
			this.btnPrint.Text = "打印(&P)";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
			this.button3.Location = new System.Drawing.Point(424, 64);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(224, 40);
			this.button3.TabIndex = 69;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(632, 32);
			this.label1.TabIndex = 71;
			this.label1.Text = "病区考勤统计";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 24);
			this.label2.TabIndex = 72;
			this.label2.Text = "开始日期";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(216, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 24);
			this.label3.TabIndex = 73;
			this.label3.Text = "结束日期";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmKQTJ
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(656, 437);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.dtpEnd);
			this.Controls.Add(this.dtpBegin);
			this.Controls.Add(this.dataGrid1);
			this.Name = "frmKQTJ";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "病区考勤统计";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmKQTJ_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ShowData()
		{
			sqlStr="exec SP_ZYHS_selpbgzl '"+InstanceForm.BCurrentDept.WardId+"','"+dtpBegin.Value.ToShortDateString()+"','"+dtpEnd.Value.ToShortDateString()+"'";
			myTb=InstanceForm.BDatabase.GetDataTable(sqlStr);
			dataGrid1.DataSource=myTb;
		}

		private void frmKQTJ_Load(object sender, System.EventArgs e)
		{
			dtpBegin.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			dtpEnd.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			ShowData();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet ds = new DataSet();
				DataTable dt = new DataTable();
			
				dt=((DataTable)dataGrid1.DataSource).Copy();
				dt.TableName="tabPbgzl";
				ds.Tables.Add(dt);

				FrmReportView frmRptView=null;
				ParameterEx[] _parameters=new ParameterEx[4];

				_parameters[0].Text="医院名称";
				_parameters[0].Value=(new SystemCfg(0002)).Config;
				_parameters[1].Text="病区名称";
				_parameters[1].Value=InstanceForm.BCurrentDept.WardName;
				_parameters[2].Text="开始日期";
				_parameters[2].Value=dtpBegin.Value.ToShortDateString();
				_parameters[3].Text="结束日期";
				_parameters[3].Value=dtpEnd.Value.ToShortDateString();

				frmRptView=new FrmReportView(ds,Constant.ApplicationDirectory+"\\report\\ZYHS_排班工作量统计.rpt",_parameters);
				frmRptView.Show();
			}
			catch(Exception err)
			{
				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
