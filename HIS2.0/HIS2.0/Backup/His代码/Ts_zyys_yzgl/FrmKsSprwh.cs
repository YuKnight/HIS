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
    public enum EditType : int
    {
        add = 0, delete = 1
    }

    public partial class FrmKsSprwh : Form
    {
        public FrmKsSprwh()
        {
            InitializeComponent();
        }

        string deptId = null;
        DataTable shrTable = null;
        EditType pagetype = EditType.add;
        public FrmKsSprwh(string deptId, DataTable shrTable, EditType editType)
            : this()
        {
            this.deptId = deptId;
            this.shrTable = shrTable;
            this.pagetype = editType;
        }

        private void FrmKsSprwh_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            //if (shrTable.Rows.Count > 0)
            //{
            //DataTable dt = shrTable.Clone();
            //string sql = string.Format("select Employee_Id from JC_KSSHR where DEPT_ID = {0}", deptId);
            //DataTable deleteShr = FrmMdiMain.Database.GetDataTable(sql);
            //if (deleteShr != null && deleteShr.Rows.Count > 0)
            //{
            //    string deleteRang = string.Empty;
            //    foreach (DataRow row in deleteShr.Rows)
            //    {
            //        deleteRang += string.Format("{0},", row["Employee_Id"].ToString());
            //    }
            //    deleteRang = deleteRang.Remove(deleteRang.Length - 1, 1);
            //    DataRow[] datalist = null;
            //    if (pagetype == EditType.add)
            //        datalist = shrTable.Select(string.Format(" Employee_Id not in ({0}) ", deleteRang));
            //    else
            //        datalist = shrTable.Select(string.Format(" Employee_Id in ({0}) ", deleteRang));
            //    foreach (DataRow row in datalist)
            //    {
            //        dt.Rows.Add(row.ItemArray);
            //    }
            //    dataGridView1.DataSource = dt;
            //}
            //else
            //{
            //    dataGridView1.DataSource = shrTable;
            //}
            string sql = string.Empty;
            if (pagetype == EditType.add)
            {
                sql = string.Format(@"  select t1.Employee_Id,t1.Code,t3.NAME from Pub_User t1  
                    left join JC_ROLE_DOCTOR t2 on t1.Employee_Id=t2.EMPLOYEE_ID  
                    left join JC_EMPLOYEE_PROPERTY t3 on t1.Employee_Id = t3.Employee_Id and t3.RYLX=1 
                    where t3.DELETE_BIT = 0 and 
                    t1.Employee_Id not in (select Employee_Id from JC_KSSHR where DEPT_ID = {0})
                    and t1.Employee_Id in (select Employee_Id from JC_EMP_DEPT_ROLE where DEPT_ID = {0})", deptId);
            }
            else
            {
                sql = string.Format(@"  select t1.Employee_Id,t1.Code,t3.NAME from Pub_User t1  
                    left join JC_ROLE_DOCTOR t2 on t1.Employee_Id=t2.EMPLOYEE_ID  
                    left join JC_EMPLOYEE_PROPERTY t3 on t1.Employee_Id = t3.Employee_Id
                    where t1.Employee_Id in (select Employee_Id from JC_KSSHR where DEPT_ID = {0})", deptId);
            }
            DataTable retTable = FrmMdiMain.Database.GetDataTable(sql);
            dataGridView1.DataSource = retTable;
            //}
        }

        bool checkParam = true;
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                dgvRow.Cells["checkBox"].Value = checkParam ? 1 : 0;
            }
            checkParam = !checkParam;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (dataGridView1.RowCount == 0)
                return;
            List<string> employeeList = new List<string>();
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                object obj = dgvRow.Cells["checkBox"].Value;
                if (obj != null && obj.ToString().Trim() == "1")
                {
                    employeeList.Add(dgvRow.Cells["Employee_Id"].Value.ToString());
                }
            }
            if (employeeList.Count == 0)
            {
                MessageBox.Show(string.Format("请勾选要{0}的审核人！", pagetype == EditType.add ? "添加" : "删除", "提示"));                  
                return;
            }
            if (pagetype == EditType.add)
            {
                string insertSql = "insert into JC_KSSHR(ID,DEPT_ID,Employee_Id,createdate) values('{0}',{1},{2},'{3}')";
                foreach (string s in employeeList)
                {
                    FrmMdiMain.Database.DoCommand(string.Format(insertSql, Guid.NewGuid().ToString(), deptId, s, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in employeeList)
                {
                    sb.Append(s + ",");
                }
                string shrRang = sb.Remove(sb.Length - 1, 1).ToString();
                string deleteSql = string.Format("delete from JC_KSSHR where DEPT_ID = {0} and Employee_Id in ({1})", deptId, shrRang);
                FrmMdiMain.Database.DoCommand(deleteSql);
            }
            MessageBox.Show("操作成功!","提示");
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}