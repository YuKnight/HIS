using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_yj_class; 

namespace ts_yj_zyyj 
{
	public partial class FrmMessage : Form 
	{

		private Form _mdiParent;
		private MenuTag _menuTag;
		private string _chineseName;
		private string strYjsqId;
		DataTable TbOrderItem;
		public FrmMessage() 
		{
			InitializeComponent();
			this.dgvList.AutoGenerateColumns = false;
			this.dgvWJ.AutoGenerateColumns = false;
		} 

		private void FrmMaggege_Load(object sender, EventArgs e) {
			ts_mz_class.FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase); 
			cmbjgbm.SelectedValue = InstanceForm._menuTag.Jgbm;
			BingData();
			TbOrderItem = select.SelectOrderItem(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);
		}

		public FrmMessage(MenuTag menuTag, string chineseName, Form mdiParent) 
		{
			_mdiParent = mdiParent;
			_chineseName = chineseName;
			_menuTag = menuTag; 
			dgvList.AutoGenerateColumns = false;
			dgvWJ.AutoGenerateColumns = false;
		}

		private DataTable GetList(string strWhere) 
		{
			DataTable dt = new DataTable();
			string strSql = string.Format(@"select   0 as xz,
											vv.NAME,
											vv.PYM,
											vv.WBM,
											vv.INPATIENT_NO,
											dbo.FUN_ZY_GETBEDNO(vv.BED_ID) as bedNo,
											dbo.fun_getDeptname(aa.SQKS) as deptName,
											aa.SQKS,
											aa.SQRQ ,
											aa.YZXMID,
											dbo.fun_getEmpName(SQR) as SQR,
											aa.SQNR,
											aa.JE ,
											aa.YJSQID, 
											BB.QRKS,dbo.fun_getDeptname(BB.QRKS) as QRKSNAME,
											BB.QRR,dbo.fun_getEmpName(BB.QRR) AS QRRNAME,BB.QRSJ
									from     YJ_ZYSQ aa,
											VI_ZY_VINPATIENT vv,
										    YJ_ZYSQ_QRJL bb
									where    aa.INPATIENT_ID=vv.INPATIENT_ID and
											aa.YJSQID = bb.YJSQID and 
											aa.BJSBZ=1 and 
											aa.BSCBZ=0  and 
											aa.btfbz=0 and BB.QRKS={0} and 
											FLAG in (1,3,4) {1}", FrmMdiMain.CurrentDept.DeptId, strWhere);
			dt= InstanceForm.BDatabase.GetDataTable(strSql, 120); 
			return dt;
		}
		
		private string GetConditions() 
		{
			StringBuilder sbWhere = new StringBuilder();
			if (txtDeptName.Tag!=null&&txtDeptName.Text!="") 
			{
				sbWhere.AppendFormat(@" and SQKS={0}",txtDeptName.Tag);
			}
			if (!string.IsNullOrEmpty(txtPatient.Text)) 
			{
				sbWhere.AppendFormat(@" and (NAME like '%{0}%' or PYM LIKE '%{1}%' OR WBM LIKE '%{2}%')", txtPatient.Text, txtPatient.Text, txtPatient.Text);
			}
			if (txtItemName.Tag != null && txtItemName.Text!="") 
			{
				sbWhere.AppendFormat(@" and YZXMID='{0}'", txtItemName.Tag);
			} 
			sbWhere.AppendFormat(@" and SQRQ >='{0}' and SQRQ<'{1}'", this.dtpStare.Value.ToShortDateString() + " 00:00:00", this.dtpEnd.Value.AddDays(1).ToShortDateString() + " 00:00:00");
			return sbWhere.ToString();
		}

		private void BingData() 
		{
			DataTable dt = GetList(GetConditions());
			this.dgvList.DataSource = dt;
		}  

		private void btnQuery_Click(object sender, EventArgs e) 
		{
			BingData();
			this.dgvWJ.DataSource = null;
		}  

		private void btnAddInfo_Click(object sender, EventArgs e) 
		{
			for (int i = 0; i < dgvList.Rows.Count; i++) {
				if (dgvList.Rows[i].Cells["clXz"].Value.ToString() == "1") {
					strYjsqId = dgvList.Rows[i].Cells["clYjsqid"].Value.ToString();
					break;
				}
			}
			if (!string.IsNullOrEmpty(strYjsqId)) {
				FrmMessageInput FrmAvtion = new FrmMessageInput(strYjsqId);
				FrmAvtion.ShowDialog();
				if (FrmAvtion.DialogResult == DialogResult.OK) {
					DataRow[] row = ((DataTable)(dgvList.DataSource)).Select("YJSQID='" + strYjsqId+"'");
					if (row.Length > 0) {
						int index = ((DataTable)(dgvList.DataSource)).Rows.IndexOf(row[0]);
						this.dgvList.CurrentCell = this.dgvList.Rows[index].Cells[2];
						DataGridViewCellEventArgs celle = new DataGridViewCellEventArgs(this.dgvList.CurrentCell.ColumnIndex, this.dgvList.CurrentCell.RowIndex);
						dgvList_CellDoubleClick(sender, celle);
					} 
				}
			}
		} 

		/// <summary>
		/// 绑定消息
		/// </summary> 
		private void BingMegInfo(string yjsqId) 
		{
			string strSql = string.Format(@"select MASSEGEID,YJSQID,MASSEGEINFO,MASSEGEDOCTOR,MASEEGETIME,dbo.fun_getEmpName(MASSEGEDOCTOR) as MASSEGEDOCTORNAME,
									(case when MASSEGESTATE='0' then '草稿' when MASSEGESTATE='1' then '已发送' 
									when MASSEGESTATE='2' then '已查看' else '作废' end ) as MASSEGESTATE ,
									dbo.fun_getEmpName(CKMASSEGEDOCTOR) as CKMASSEGEDOCTOROCTORNAME,
									CKMASEEGETIME
									from JY_MASSEGE where YJSQID = '{0}'", yjsqId);
			DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql, 120);
			this.dgvWJ.DataSource = dt;
		}

		private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
			if (dgvList != null) {
				dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
			} 
		}

		private void dgvWJ_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) 
		{
			if (dgvWJ != null) {
				dgvWJ.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
			} 
		}

		private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) 
		{
			if (e.RowIndex > -1) {
				strYjsqId = this.dgvList.CurrentRow.Cells["clYjsqid"].Value.ToString();
				if (!string.IsNullOrEmpty(strYjsqId)) {
					BingMegInfo(strYjsqId);
				}
			}
		}

		private void txtDeptName_KeyPress(object sender, KeyPressEventArgs e) {
			try {

				string sqlYS = @"select DEPT_ID AS ID,NAME,PY_CODE,WB_CODE from JC_DEPT_PROPERTY where P_DEPT_ID!=0 and DELETED=0 and P_DEPT_ID!=1";
				DataTable dtYLFL = InstanceForm.BDatabase.GetDataTable(sqlYS);
				if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46) {
					txtDeptName.Text = "";
					txtDeptName.Tag = "";
					return;
				}

				Control control = (Control)sender;
				if ((int)e.KeyChar != 13) {
					string[] headtext = new string[] { "编号", "科室名称", "拼音码", "五笔码" };
					string[] mappingname = new string[] { "ID", "NAME", "PY_CODE", "WB_CODE" };
					string[] searchfields = new string[] { "PY_CODE", "WB_CODE" };
					int[] colwidth = new int[] { 0, 250, 80, 70 };
					TrasenFrame.Forms.FrmSelectCard f = new TrasenFrame.Forms.FrmSelectCard(searchfields, headtext, mappingname, colwidth);
					f.sourceDataTable = dtYLFL;
					f.WorkForm = this;
					f.srcControl = txtDeptName;
					f.Font = txtDeptName.Font;
					f.Width = 400;
					f.ReciveString = e.KeyChar.ToString();
					e.Handled = true;
					if (f.ShowDialog() == DialogResult.Cancel) {
						txtDeptName.Focus();
						return;
					}
					else {
						txtDeptName.Text = f.SelectDataRow["NAME"].ToString().Trim();
						txtDeptName.Tag = f.SelectDataRow["ID"].ToString();
						e.Handled = true;
					}
				}
			}
			catch { txtDeptName.Focus(); }
		}

		private void txtItemName_KeyPress(object sender, KeyPressEventArgs e) {
			try {
				string sqlYS = string.Format(@" select rtrim(order_name) as item_name, rtrim(order_unit) as item_unit,jc_hoitemdiction.order_id as orderid, py_code, wb_code  
									from jc_hoitemdiction ,JC_HOI_DEPT   where jc_hoitemdiction.ORDER_ID=JC_HOI_DEPT.ORDER_ID and jc_hoitemdiction.delete_bit=0 
									and jc_hoitemdiction.order_type<>7 and JC_HOI_DEPT.EXEC_DEPT={0}", FrmMdiMain.CurrentDept.DeptId);
				DataTable dtYLFL = InstanceForm.BDatabase.GetDataTable(sqlYS);
				
				Control control = (Control)sender;
				if ((int)e.KeyChar == 13) {
					return;
				}
				if ((int)e.KeyChar == 8) {
					txtItemName.Text = "";
					txtItemName.Tag = "";
					return;
				} 
				string[] headtext = new string[] { "项目名称", "单位", "orderid", "拼音码", "五笔码" };
				string[] mappingname = new string[] { "item_name", "item_unit", "orderid", "py_code", "wb_code" };
				string[] searchfields = new string[] { "item_name", "py_code", "wb_code" };
				int[] colwidth = new int[] { 300, 80, 0, 100, 80 };
				TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
				f.sourceDataTable = dtYLFL;
				f.WorkForm = this;
				f.srcControl = control;
				f.Font = control.Font;
				f.Width = 600;
				f.ReciveString = e.KeyChar.ToString();
				e.Handled = true;
				if (f.ShowDialog() == DialogResult.Cancel) {
					control.Focus();
				}
				else {
					this.txtItemName.Text = f.SelectDataRow["item_name"].ToString().Trim();
					this.txtItemName.Tag = f.SelectDataRow["orderid"].ToString().Trim();
					
				}
			}
			catch (Exception err) {
				MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex > -1) {
				strYjsqId = this.dgvList.CurrentRow.Cells["clYjsqid"].Value.ToString();
				for (int i = 0; i < dgvList.Rows.Count; i++) {
					this.dgvList.Rows[i].Cells["clXz"].Value = 0;
				}
				this.dgvList.Rows[e.RowIndex].Cells["clXz"].Value = 1; 
				if (!string.IsNullOrEmpty(strYjsqId)) {
					BingMegInfo(strYjsqId);
				}
			}
		}

		private void dgvWJ_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex > -1) {
				strYjsqId = this.dgvWJ.Rows[e.RowIndex].Cells["CLWJYJSQID"].Value.ToString();
				string strMagId = this.dgvWJ.CurrentRow.Cells["CLMASSEGEID"].Value.ToString();
				if (this.dgvWJ.Rows[e.RowIndex].Cells["CLMASSEGESTATE"].Value.ToString() != "已查看") {
					FrmMessageInput frmAction = new FrmMessageInput(strYjsqId, strMagId);
					frmAction.ShowDialog();
					if (frmAction.DialogResult == DialogResult.OK) {
						DataRow[] row = ((DataTable)(dgvList.DataSource)).Select("YJSQID='" + strYjsqId + "'");
						if (row.Length > 0) {
							int index = ((DataTable)(dgvList.DataSource)).Rows.IndexOf(row[0]);
							this.dgvList.CurrentCell = this.dgvList.Rows[index].Cells[2];
							DataGridViewCellEventArgs celle = new DataGridViewCellEventArgs(this.dgvList.CurrentCell.ColumnIndex, this.dgvList.CurrentCell.RowIndex);
							dgvList_CellDoubleClick(sender, celle);
						}
					}
				}
			}
		}
	}
}