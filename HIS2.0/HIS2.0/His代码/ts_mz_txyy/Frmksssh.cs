using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame;
using TrasenFrame.Forms;
using System.IO;


namespace ts_mz_txyy
{
    public partial class Frmksssh : Form
    {

        bool _isys = false;
        public Frmksssh()
        {
          
            InitializeComponent();
        }

        public Frmksssh(string isys)
        {
            
            InitializeComponent();
            _isys = true;
        }

        
        private DataTable DoQueryData(params object[] args)   //datatable获取数据
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"    select  ID, A.ORDER_ID,A.INPATIENT_ID,A.GROUP_ID,CJID,A.DEPT_ID,S_YPPM,EMPLOYEE_ID,YS_TYPEID,DBO.FUN_GETEMPNAME(SHR) as SHR,SHSJ,case when SHBZ=1 then '已审核' when SHBZ=0 then'未审核' end as SHBZ,
			                                        B.WARD_ID,WARD_NAME,INPATIENT_NO,NAME,ZYDOC_NAME,
				                                    C.ORDER_CONTEXT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,HOITEM_ID ,zd,reason,DBO.FUN_GETEMPNAME(C.ORDER_DOC) as  kdysmc from ZY_FZYY_SH A
                                                    inner join VI_ZY_VINPATIENT_ALL B ON A.INPATIENT_ID=B.INPATIENT_ID
		                                            INNER JOIN VI_ZY_ORDERRECORD C ON A.INPATIENT_ID=C.INPATIENT_ID AND A.GROUP_ID=C.GROUP_ID
		                                            WHERE A.DEL_BIT=0 and (A.shbz =0 or A.shbz is null) AND C.DELETE_BIT=0 and A.DEPT_ID = '{0}'", FrmMdiMain.CurrentDept.DeptId);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private void dv1binddata()
        {
            try
            {
                DataTable dt = DoQueryData();
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;

                }
            }
            catch { }
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                string strFromTime = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string strEndTime = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                if (_isys)
                {
                     sql = string.Format(@" select  ID, A.ORDER_ID,A.INPATIENT_ID,A.GROUP_ID,CJID,A.DEPT_ID,S_YPPM,EMPLOYEE_ID,YS_TYPEID,DBO.FUN_GETEMPNAME(SHR) as SHR,SHSJ,case when SHBZ=1 then '已审核' when SHBZ=0 then'未审核' end as SHBZ,
			                                        B.WARD_ID,WARD_NAME,INPATIENT_NO,NAME,ZYDOC_NAME,
				                                    C.ORDER_CONTEXT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,HOITEM_ID ,zd,reason,DBO.FUN_GETEMPNAME(C.ORDER_DOC) as  kdysmc from ZY_FZYY_SH A
                                                    inner join VI_ZY_VINPATIENT_ALL B ON A.INPATIENT_ID=B.INPATIENT_ID
		                                            INNER JOIN VI_ZY_ORDERRECORD C ON A.INPATIENT_ID=C.INPATIENT_ID AND A.GROUP_ID=C.GROUP_ID
		                                            WHERE A.DEL_BIT=0 AND C.DELETE_BIT=0 and C.ORDER_BDATE between '{0}' and '{1}'", strFromTime, strEndTime);

                }
                else
                {
                     sql = string.Format(@" select  ID, A.ORDER_ID,A.INPATIENT_ID,A.GROUP_ID,CJID,A.DEPT_ID,S_YPPM,EMPLOYEE_ID,YS_TYPEID,DBO.FUN_GETEMPNAME(SHR) as SHR,SHSJ,case when SHBZ=1 then '已审核' when SHBZ=0 then'未审核' end as SHBZ,
			                                        B.WARD_ID,WARD_NAME,INPATIENT_NO,NAME,ZYDOC_NAME,
				                                    C.ORDER_CONTEXT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,HOITEM_ID ,zd,reason,DBO.FUN_GETEMPNAME(C.ORDER_DOC) as  kdysmc from ZY_FZYY_SH A
                                                    inner join VI_ZY_VINPATIENT_ALL B ON A.INPATIENT_ID=B.INPATIENT_ID
		                                            INNER JOIN VI_ZY_ORDERRECORD C ON A.INPATIENT_ID=C.INPATIENT_ID AND A.GROUP_ID=C.GROUP_ID
		                                            WHERE A.DEL_BIT=0 AND C.DELETE_BIT=0 and A.DEPT_ID = '{0}'", FrmMdiMain.CurrentDept.DeptId);
                }

                if (!string.IsNullOrEmpty(cbxShzt.Text))
                {
                    sql += cbxShzt.Text == "未审核" ? " and (A.shbz =0 or A.shbz is null) " : " and A.shbz = 1";
                }

                if (tbxZyh.Text.Trim() != string.Empty)
                    sql += string.Format(" and B.INPATIENT_NO ='{0}' order by group_id", tbxZyh.Text.Trim());
                else
                    sql += " order by group_id";
                DataTable datalist = FrmMdiMain.Database.GetDataTable(sql);
                this.dataGridView1.DataSource = datalist;
                //int rowNumber = 0;
                //int orderNum = 1;
                //dataGridView1.RowCount = 1;
                //List<string> grouplist = new List<string>();
                //foreach (DataRow row in datalist.Rows)
                //{
                //    string strGrp = row["INPATIENT_ID"].ToString().Trim() + "-" + row["group_id"].ToString().Trim();

                //    if (string.IsNullOrEmpty(grouplist.Find(delegate(string s) { return s == strGrp; })))
                //    {
                //        DataRow[] groupRows = datalist.Select(string.Format("INPATIENT_ID='{1}' and group_id = {0}", row["group_id"], row["INPATIENT_ID"].ToString()));
                //        if (groupRows != null && groupRows.Length > 0)
                //        {
                //            string newGrp = row["INPATIENT_ID"].ToString().Trim() + "-" + row["group_id"].ToString().Trim();
                //            grouplist.Add(newGrp);

                //            foreach (DataRow dr in groupRows)
                //            {
                //                dataGridView1.Rows.AddCopy(rowNumber);
                //                DataGridViewRow dgvRow = dataGridView1.Rows[rowNumber];
                //                dgvRow.Cells["xh"].Value = orderNum++;
                //                dgvRow.Cells["zyh"].Value = dr["zyh"].ToString();
                //                dgvRow.Cells["S_YPPM"].Value = dr["S_YPPM"].ToString();
                //                dgvRow.Cells["ORDER_ID"].Value = dr["ORDER_ID"].ToString();
                //                dgvRow.Cells["ID"].Value = dr["ID"].ToString();
                //                dgvRow.Cells["CJID"].Value = dr["CJID"].ToString();
                //                dgvRow.Cells["DEL_BIT"].Value = dr["DEL_BIT"].ToString();
                //                dgvRow.Cells["DEPT_ID"].Value = dr["DEPT_ID"];
                //                dgvRow.Cells["INPATIENT_ID"].Value = dr["INPATIENT_ID"];
                //                dgvRow.Cells["S_YPGG"].Value = dr["S_YPGG"];
                //                dgvRow.Cells["S_SCCJ"].Value = dr["S_SCCJ"];
                //                dgvRow.Cells["S_YPJX"].Value = dr["S_YPJX"];
                //                dgvRow.Cells["S_YPDW"].Value = dr["S_YPDW"];
                //                dgvRow.Cells["br"].Value = dr["br"];
                //                dgvRow.Cells["CFJB"].Value = dr["CFJB"];
                //                dgvRow.Cells["YS_TYPEID"].Value = dr["YS_TYPEID"];
                //                dgvRow.Cells["cfjbid"].Value = dr["cfjbid"];
                //                dgvRow.Cells["ysjbid"].Value = dr["ysjbid"];
                //                dgvRow.Cells["SHR"].Value = dr["SHR"];
                //                dgvRow.Cells["shrmc"].Value = dr["shrmc"];
                //                dgvRow.Cells["SHSJ"].Value = dr["SHSJ"];
                //                dgvRow.Cells["shbz"].Value = dr["shbz"];
                //                dgvRow.Cells["shbzmc"].Value = dr["shbzmc"];
                //                dgvRow.Cells["group_id"].Value = dr["group_id"];
                //                rowNumber++;
                //            }
                //            if (!(row["group_id"].ToString().Trim() == datalist.Rows[datalist.Rows.Count - 1]["group_id"].ToString().Trim() && row["INPATIENT_ID"].ToString().Trim() == datalist.Rows[datalist.Rows.Count - 1]["INPATIENT_ID"].ToString().Trim()))
                //            {
                //                dataGridView1.Rows.AddCopy(rowNumber);
                //                //DataGridViewRow dgvRow = dataGridView1.Rows[rowNumber];
                //                //dgvRow.Cells[0] = new DataGridViewTextBoxCell();
                //                //dgvRow.DefaultCellStyle.BackColor = Color.White;
                //                rowNumber++;
                //            }
                //        }
                //    }
                //}
                dataGridView1.Refresh();

            }
            catch { }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        
        {
            if (dataGridView1.CurrentRow == null)
                return;

           // //
           // //int iCfjb = int.Parse(dataGridView1.CurrentRow.Cells["cfjbid"].Value.ToString().Trim());
           //// Doctor doctor = new Doctor(InstanceForm._currentUser.EmployeeId, InstanceForm._database);
           // if (doctor == null || (doctor.TypeID > iCfjb))
           // {
           //     MessageBox.Show("医生：" + InstanceForm._currentUser.Name + " 的处方权限低于" + dataGridView1.CurrentRow.Cells["CFJB"].Value.ToString() + "！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           //     return;
           // }
            int deptID= FrmMdiMain.CurrentDept.DeptId;
            long employeeId = FrmMdiMain.CurrentUser.UserID;
            string strSql = string.Format(@"select count(1) as NUM from  [jc_kss_tsshr]  where dept_id ='{0}' and employee_id='{1}'", deptID, employeeId);
            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageBox.Show("该医生没有审核权限!", "提示");
                return;
            }

            string shbz = dataGridView1.CurrentRow.Cells["shbz"].Value != null ? dataGridView1.CurrentRow.Cells["shbz"].Value.ToString().Trim() : "";
            if (shbz == "已审核")
            {
                MessageBox.Show("单据已审核!", "提示");
                return;
            }

            DialogResult dr = MessageBox.Show("您确定要执行审核操作吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                string orderId = dataGridView1.CurrentRow.Cells["group_id"].Value.ToString();
                string inpid = dataGridView1.CurrentRow.Cells["INPATIENT_ID"].Value.ToString();
                string sql = string.Format("update ZY_FZYY_SH set shr = {0},shsj = '{1}',shbz = 1 where INPATIENT_ID='{3}' and group_id = '{2}'",
                              FrmMdiMain.CurrentUser.EmployeeId, DateTime.Now.ToString("yyyy-MM-dd"), orderId, inpid);
                int ret = FrmMdiMain.Database.DoCommand(sql);
                if (ret > 0)
                {
                    MessageBox.Show("审核成功!");
                    //foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
                    //{
                    //    object obj = dgvRow.Cells["group_id"].Value;
                    //    if (obj == null)
                    //        continue;
                    //    if (dgvRow.Cells["group_id"].Value.ToString().Trim() == orderId)
                    //    {
                    //        dgvRow.Cells["shbzmc"].Value = "已审核";
                    //        dgvRow.Cells["shbz"].Value = "1";
                    //    }
                    //}
                    btnQuery_Click(null, null);
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex > -1 && dataGridView1.Rows[e.RowIndex].Cells["shbz"].Value != null)
            {
                object printflag = dataGridView1.Rows[e.RowIndex].Cells["shbz"].Value;
                if (printflag != null && printflag.ToString().Trim() == "已审核")
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
                else
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void Frmksssh_Load(object sender, EventArgs e)
        {
            if (_isys)
            {
                //label1.Visible = false;
                //tbxKs.Visible = false;
                btnAudit.Visible = false;
                label3.Visible = false;
                tbxZyh.Visible = false;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                btnToExcel.Visible = false;
            }
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
            tbxKs.Text = FrmMdiMain.CurrentDept.DeptName;
            cbxShzt.Items.Add("已审核");
            cbxShzt.Items.Add("未审核");
            cbxShzt.SelectedIndex = 1;
            dv1binddata();
            
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            DataToExcel(dataGridView1);
        }

        public void DataToExcel(DataGridView m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName ;
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }

                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        
    }
}