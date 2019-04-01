using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmKsSpr : Form
    {
        public FrmKsSpr()
        {
            InitializeComponent();
        }

        DataTable ksTable = null;
        DataTable shrTable = null;
        IAsyncResult iasy_shr = null;
        private void FrmKsSpr_Load(object sender, EventArgs e)
        {
            string sql = string.Empty;
            if (InstanceForm._currentDept.Zy_Flag == 1)
            {
                sql = string.Format(@"select a.*,parentKs.NAME as sjks  from JC_DEPT_PROPERTY a 
                left join JC_DEPT_PROPERTY parentKs on a.P_DEPT_ID = parentKs.DEPT_ID
                where   a.ZY_FLAG = 1 and a.deleted=0 and a.DEPT_ID = {0}  order by a.P_DEPT_ID ", InstanceForm._currentDept.DeptId);
            }
            else
            {
                sql = @"select a.*,parentKs.NAME as sjks  from JC_DEPT_PROPERTY a 
                left join JC_DEPT_PROPERTY parentKs on a.P_DEPT_ID = parentKs.DEPT_ID
                where   a.ZY_FLAG = 1 and a.deleted=0  order by a.P_DEPT_ID ";
            }
            ksTable = FrmMdiMain.Database.GetDataTable(sql);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ksTable;

            iasy_shr = this.BeginInvoke(new MethodInvoker(delegate()
              {
                  sql = @"   select t1.Employee_Id,t1.Code,t3.NAME from Pub_User t1  
            left join JC_ROLE_DOCTOR t2 on t1.Employee_Id=t2.EMPLOYEE_ID  
            left join JC_EMPLOYEE_PROPERTY t3 on t1.Employee_Id = t3.Employee_Id
            where t3.DELETE_BIT = 0";
                  shrTable = FrmMdiMain.Database.GetDataTable(sql);
              }));
        }

        Dictionary<string, DataTable> cache = new Dictionary<string, DataTable>();
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            string deptid = dataGridView1.CurrentRow.Cells["DEPT_ID"].Value != null ? dataGridView1.CurrentRow.Cells["DEPT_ID"].Value.ToString() : "";
            if (deptid != string.Empty)
            {
                if (cache.ContainsKey(deptid))
                {
                    DataTable dt = cache[deptid];
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    string sql = string.Format(@"   select t1.Employee_Id,t1.Code,t3.NAME from Pub_User t1  
                            left join JC_ROLE_DOCTOR t2 on t1.Employee_Id=t2.EMPLOYEE_ID  
                            left join JC_EMPLOYEE_PROPERTY t3 on t1.Employee_Id = t3.Employee_Id
                            where t3.DELETE_BIT = 0 and t1.Employee_Id in (select Employee_Id from JC_KSSHR where DEPT_ID = {0}) ", deptid);
                    DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        cache.Remove(deptid);
                        cache.Add(deptid, dt);                       
                    }
                    dataGridView2.DataSource = dt;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0 && toolStripTextBox1.Text.Trim() != string.Empty)
            {
                BindingManagerBase bm = this.BindingContext[dataGridView1.DataSource];
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string pym = dataGridView1.Rows[i].Cells["PY_CODE"].Value != null ? dataGridView1.Rows[i].Cells["PY_CODE"].Value.ToString().Trim() : "";
                    string dept = dataGridView1.Rows[i].Cells["NAME"].Value != null ? dataGridView1.Rows[i].Cells["NAME"].Value.ToString().Trim() : "";
                    string wbm = dataGridView1.Rows[i].Cells["WB_CODE"].Value != null ? dataGridView1.Rows[i].Cells["WB_CODE"].Value.ToString().Trim() : "";
                    if (pym.Contains(toolStripTextBox1.Text.Trim()) || dept.Contains(toolStripTextBox1.Text.Trim()) || wbm.Contains(toolStripTextBox1.Text.Trim()))
                    {
                        bm.Position = i;
                        return;
                    }
                }
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                toolStripButton1_Click(null, null);
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            string deptid = dataGridView1.CurrentRow.Cells["DEPT_ID"].Value != null ? dataGridView1.CurrentRow.Cells["DEPT_ID"].Value.ToString() : "";
            if (iasy_shr.IsCompleted == false)
            {
                MethodInvoker mi = (MethodInvoker)iasy_shr.AsyncState;
                mi.EndInvoke(iasy_shr);
            }
            FrmKsSprwh fm = new FrmKsSprwh(deptid, shrTable, EditType.add);
            DialogResult ret = fm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                cache.Remove(deptid);
                BindingManagerBase bm = this.BindingContext[dataGridView1.DataSource];
                int currentIndex = dataGridView1.CurrentRow.Index;
                dataGridView1_SelectionChanged(null, null);
                bm.Position = currentIndex;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            string deptid = dataGridView1.CurrentRow.Cells["DEPT_ID"].Value != null ? dataGridView1.CurrentRow.Cells["DEPT_ID"].Value.ToString() : "";
            if (iasy_shr.IsCompleted == false)
            {
                MethodInvoker mi = (MethodInvoker)iasy_shr.AsyncState;
                mi.EndInvoke(iasy_shr);
            }
            FrmKsSprwh fm = new FrmKsSprwh(deptid, shrTable, EditType.delete);
            DialogResult ret = fm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                cache.Remove(deptid);
                BindingManagerBase bm = this.BindingContext[dataGridView1.DataSource];
                int currentIndex = dataGridView1.CurrentRow.Index;
                dataGridView1_SelectionChanged(null, null);
                bm.Position = currentIndex;
            }
        }

        bool checkParam = true;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dataGridView2.Rows)
            {
                dgvRow.Cells["checkBox"].Value = checkParam ? true : false;
            }
            checkParam = !checkParam;
        }
    }
}