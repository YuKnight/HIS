using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

namespace Ts_zyys_yzgl
{
    public partial class Frmksssh : Form
    {
        public Frmksssh()
        {
            InitializeComponent();
        }

        private void Frmksssh_Load(object sender, EventArgs e)
        {
            tbxKs.Text = InstanceForm._currentDept.DeptName;
            cbxShzt.Items.Add("已审核");
            cbxShzt.Items.Add("未审核");
            cbxShzt.SelectedIndex = 1;

            btnQuery_Click(null, null);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = string.Format(@"
                                select t1.ID,t1.ORDER_ID,t1.S_YPPM,t1.CJID,t1.CFJB as cfjbid,t1.YS_TYPEID as ysjbid,
                                case t1.CFJB when 1 then '主任医生' when 2 then '副主任医生' when 3 then '主治医生' when 4 then '经治医生' end as CFJB,
                                case t1.YS_TYPEID when 1 then '主任医生' when 2 then '副主任医生' when 3 then '主治医生' when 4 then '经治医生' end as YS_TYPEID,
                                t1.DEL_BIT,t1.DEPT_ID,t1.INPATIENT_ID,t1.shbz,
                                case when t1.shbz =0 or t1.shbz is null then '未审核' else '已审核' end as shbzmc,
                                t3.S_YPGG,t3.S_SCCJ,t3.S_YPJX,t3.S_YPDW, t2.INPATIENT_NO as zyh,t2.NAME as br,t1.SHR,t4.NAME as shrmc,t1.SHSJ,group_id 
                                from zy_kss_sh t1
                                left join ZY_INPATIENT t2 on t1.INPATIENT_ID = t2.INPATIENT_ID
                                left join YP_YPCJD t3 on t1.CJID = t3.CJID
                                left join JC_EMPLOYEE_PROPERTY t4 on t1.SHR =t4.EMPLOYEE_ID
                                where del_bit != 1 and t1.DEPT_ID = '{0}'", InstanceForm._currentDept.DeptId);

                if (!string.IsNullOrEmpty(cbxShzt.Text))
                {
                    sql += cbxShzt.Text == "未审核" ? " and (t1.shbz =0 or t1.shbz is null) " : " and t1.shbz = 1";
                }

                if (tbxZyh.Text.Trim() != string.Empty)
                    sql += string.Format(" and t2.INPATIENT_NO ='{0}' order by group_id", tbxZyh.Text.Trim());
                else
                    sql += " order by group_id";
                DataTable datalist = FrmMdiMain.Database.GetDataTable(sql);
                int rowNumber = 0;
                int orderNum = 1;
                dataGridView1.RowCount = 1;
                List<string> grouplist = new List<string>();
                foreach (DataRow row in datalist.Rows)
                {
                    string strGrp = row["INPATIENT_ID"].ToString().Trim() + "-" + row["group_id"].ToString().Trim();

                    if (string.IsNullOrEmpty(grouplist.Find(delegate(string s) { return s == strGrp; })))
                    {
                        DataRow[] groupRows = datalist.Select(string.Format("INPATIENT_ID='{1}' and group_id = {0}", row["group_id"], row["INPATIENT_ID"].ToString()));
                        if (groupRows != null && groupRows.Length > 0)
                        {
                            string newGrp = row["INPATIENT_ID"].ToString().Trim() + "-" + row["group_id"].ToString().Trim();
                            grouplist.Add(newGrp);

                            foreach (DataRow dr in groupRows)
                            {
                                dataGridView1.Rows.AddCopy(rowNumber);
                                DataGridViewRow dgvRow = dataGridView1.Rows[rowNumber];
                                dgvRow.Cells["xh"].Value = orderNum++;
                                dgvRow.Cells["zyh"].Value = dr["zyh"].ToString();
                                dgvRow.Cells["S_YPPM"].Value = dr["S_YPPM"].ToString();
                                dgvRow.Cells["ORDER_ID"].Value = dr["ORDER_ID"].ToString();
                                dgvRow.Cells["ID"].Value = dr["ID"].ToString();
                                dgvRow.Cells["CJID"].Value = dr["CJID"].ToString();
                                dgvRow.Cells["DEL_BIT"].Value = dr["DEL_BIT"].ToString();
                                dgvRow.Cells["DEPT_ID"].Value = dr["DEPT_ID"];
                                dgvRow.Cells["INPATIENT_ID"].Value = dr["INPATIENT_ID"];
                                dgvRow.Cells["S_YPGG"].Value = dr["S_YPGG"];
                                dgvRow.Cells["S_SCCJ"].Value = dr["S_SCCJ"];
                                dgvRow.Cells["S_YPJX"].Value = dr["S_YPJX"];
                                dgvRow.Cells["S_YPDW"].Value = dr["S_YPDW"];
                                dgvRow.Cells["br"].Value = dr["br"];
                                dgvRow.Cells["CFJB"].Value = dr["CFJB"];
                                dgvRow.Cells["YS_TYPEID"].Value = dr["YS_TYPEID"];
                                dgvRow.Cells["cfjbid"].Value = dr["cfjbid"];
                                dgvRow.Cells["ysjbid"].Value = dr["ysjbid"];
                                dgvRow.Cells["SHR"].Value = dr["SHR"];
                                dgvRow.Cells["shrmc"].Value = dr["shrmc"];
                                dgvRow.Cells["SHSJ"].Value = dr["SHSJ"];
                                dgvRow.Cells["shbz"].Value = dr["shbz"];
                                dgvRow.Cells["shbzmc"].Value = dr["shbzmc"];
                                dgvRow.Cells["group_id"].Value = dr["group_id"];
                                rowNumber++;
                            }
                            if (!(row["group_id"].ToString().Trim() == datalist.Rows[datalist.Rows.Count - 1]["group_id"].ToString().Trim() && row["INPATIENT_ID"].ToString().Trim() == datalist.Rows[datalist.Rows.Count - 1]["INPATIENT_ID"].ToString().Trim()))
                            {
                                dataGridView1.Rows.AddCopy(rowNumber);
                                //DataGridViewRow dgvRow = dataGridView1.Rows[rowNumber];
                                //dgvRow.Cells[0] = new DataGridViewTextBoxCell();
                                //dgvRow.DefaultCellStyle.BackColor = Color.White;
                                rowNumber++;
                            }
                        }
                    }
                }
                dataGridView1.Refresh();
            }
            catch { }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            //
            int iCfjb = int.Parse(dataGridView1.CurrentRow.Cells["cfjbid"].Value.ToString().Trim());
            Doctor doctor = new Doctor(InstanceForm._currentUser.EmployeeId, InstanceForm._database);
            if (doctor == null || (doctor.TypeID > iCfjb))
            {
                MessageBox.Show("医生：" + InstanceForm._currentUser.Name + " 的处方权限低于" + dataGridView1.CurrentRow.Cells["CFJB"].Value.ToString() + "！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string shbz = dataGridView1.CurrentRow.Cells["shbz"].Value != null ? dataGridView1.CurrentRow.Cells["shbz"].Value.ToString().Trim() : "";
            if (shbz == "1")
            {
                MessageBox.Show("单据已审核!", "提示");
                return;
            }

            DialogResult dr = MessageBox.Show("您确定要执行审核操作吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                string orderId = dataGridView1.CurrentRow.Cells["group_id"].Value.ToString();
                string inpid = dataGridView1.CurrentRow.Cells["INPATIENT_ID"].Value.ToString();
                string sql = string.Format("update zy_kss_sh set shr = {0},shsj = '{1}',shbz = 1 where INPATIENT_ID='{3}' and group_id = '{2}'",
                             InstanceForm._currentUser.EmployeeId, DateTime.Now.ToString("yyyy-MM-dd"), orderId, inpid);
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
            if (e.RowIndex > -1 && dataGridView1.Rows[e.RowIndex].Cells["shbzmc"].Value != null)
            {
                object printflag = dataGridView1.Rows[e.RowIndex].Cells["shbzmc"].Value;
                if (printflag != null && printflag.ToString().Trim() == "已审核")
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
                else
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}