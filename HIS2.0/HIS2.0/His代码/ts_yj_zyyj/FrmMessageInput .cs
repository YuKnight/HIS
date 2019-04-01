using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_yj_zyyj {
	public partial class FrmMessageInput : Form {

		string strYjsqId = string.Empty;
		string strMagId = string.Empty;
		public FrmMessageInput() {
			InitializeComponent();
		}
		public FrmMessageInput(string _strYjsqId) {
			InitializeComponent();
			strYjsqId = _strYjsqId;
		}
		public FrmMessageInput(string _strYjsqId,string _strMagId) {
			InitializeComponent();
			strYjsqId = _strYjsqId;
			strMagId = _strMagId;
		}
		private void btnEnsure_Click(object sender, EventArgs e) {
			if (Save()) { 
				this.DialogResult = DialogResult.OK;
			}
			else {
				MessageBox.Show("操作失败");
			}
		}

		private void InitPage() {
			string strSql;
			if (!string.IsNullOrEmpty(strYjsqId) && !string.IsNullOrEmpty(strMagId)) {
				strSql = string.Format(@" select MASSEGEID,YJSQID,MASSEGEINFO,MASSEGEDOCTOR , dbo.fun_getEmpName(MASSEGEDOCTOR) as MASSEGEDOCTORNAME,MASEEGETIME,
											(case when MASSEGESTATE='0' then '草稿' when MASSEGESTATE='1' then '已发送' 
											when MASSEGESTATE='2' then '已查看' else '作废' end ) as MASSEGESTATE 
											from JY_MASSEGE where MASSEGEID='{0}' ", strMagId);
				DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql, 120);
				if (dt == null) return;
				if (dt.Rows.Count <= 0) return;
				this.txtPerson.Text = dt.Rows[0]["MASSEGEDOCTORNAME"].ToString();
				this.txtPerson.Tag = dt.Rows[0]["MASSEGEDOCTOR"].ToString();
				this.txtDateTime.Text = dt.Rows[0]["MASEEGETIME"].ToString();
				this.txtInfo.Text = dt.Rows[0]["MASSEGEINFO"].ToString();
			}
			else {
				this.txtPerson.Text = FrmMdiMain.CurrentUser.Name;
				this.txtPerson.Tag = FrmMdiMain.CurrentUser.EmployeeId;
				this.txtDateTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
			}
		}

		private bool Save() {
			string strSql; 
			if (!string.IsNullOrEmpty(strYjsqId) && !string.IsNullOrEmpty(strMagId)) {
				strSql = string.Format(@" update JY_MASSEGE set  MASSEGEINFO='{0}',MASSEGEDOCTOR='{1}',MASEEGETIME='{2}' where MASSEGEID='{3}' ",
					this.txtInfo.Text, FrmMdiMain.CurrentUser.EmployeeId, System.DateTime.Now, strMagId);
			}
			else {
				strSql = string.Format(@" insert into JY_MASSEGE(MASSEGEID,YJSQID,MASSEGEINFO,MASSEGEDOCTOR,MASEEGETIME,MASSEGESTATE) values('{0}','{1}','{2}','{3}','{4}','{5}') ",
					Guid.NewGuid().ToString(), strYjsqId, this.txtInfo.Text, FrmMdiMain.CurrentUser.EmployeeId, System.DateTime.Now, 1);
			}
			int i= InstanceForm.BDatabase.DoCommand(strSql);
			if (i > 0) {
				return true;
			}
			else {
				return false;
			} 
		}

		private void Cancle() { 
			
		}
		protected override bool ProcessDialogKey(Keys keyData) {
			if (keyData == Keys.Enter)　　// 按下的是回车键
			{
				foreach (Control c in this.Controls) {
					keyData = Keys.Tab;
				}
				keyData = Keys.Tab;
			}
			return base.ProcessDialogKey(keyData);
		}

		private void btnCancle_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		private void FrmMessageInput_Load(object sender, EventArgs e) {
			InitPage();
		}
	}
}