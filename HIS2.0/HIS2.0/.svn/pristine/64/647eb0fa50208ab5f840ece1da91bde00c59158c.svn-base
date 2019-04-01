using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_zyhs_gzrz
{
	public partial class FrmDeptVINPATIENTLog : Form {

		public FrmDeptVINPATIENTLog() {
			InitializeComponent();
		}

		private void btnCX_Click(object sender, EventArgs e) {
			BingDate();
		} 

		private void BingDate() {
			string strYear = this.dateTimePicker1.Value.Year.ToString();
			ParameterEx[] Parameters = new ParameterEx[2];
			Parameters[0].Value = FrmMdiMain.CurrentDept.DeptId;
			Parameters[0].Text = "@DEPTID";
			Parameters[1].Value = this.dateTimePicker1.Value;
			Parameters[1].Text = "@TJRQ";
			DataTable dt = FrmMdiMain.Database.GetDataTable("SP_ZY_INPATIENTLOG", Parameters);
			if (dt != null) {
				if (dt.Rows.Count >= 0) {
					this.dgvList.DataSource = dt;
				}
			}
		}

		/// <summary>
		/// 打印预览
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrint_Click(object sender, EventArgs e) {
			try {
				if (this.dgvList.Rows.Count <= -1) return;
				DataTable dt = (DataTable)this.dgvList.DataSource;
				Trasen.jqg.Print.Interface.IPrinter printer = new Trasen.jqg.Print.ReportPrinter();
				printer.ReportTemplateFile = Application.StartupPath + "\\科室住院病人日报表.grf";
				Trasen.jqg.Print.Interface.IParameter[] par = new Trasen.jqg.Print.Interface.IParameter[2];
				par[0] = new Trasen.jqg.Print.ReportParameter("日期", this.dateTimePicker1.Value.ToShortDateString());
				par[1] = new Trasen.jqg.Print.ReportParameter("科室", FrmMdiMain.CurrentDept.DeptName);
				printer.PrintDataSource = dt;
				printer.ReportParameters = par;
				
				printer.Preview();
			} 
			catch {
				MessageBox.Show("请确认是否安装的插件");
			}
		}

		private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
			if (dgvList != null) {
				dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
			} 
		}
	}
}