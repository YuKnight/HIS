using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_yp_ypcd
{
    public enum cztype
    {
        add,
        edit,
    }

    public partial class Frmwbks : Form
    {
        cztype ct;
        int cjid = 0;
        public Frmwbks(cztype t, int cjid)
        {
            InitializeComponent();
            ct = t;
            this.cjid = cjid;
        }

        private void Frmwbks_Load(object sender, EventArgs e)
        {
            string sql = string.Empty;

            sql = string.Format(@"select
                  case when b.DEPTID Is null or b.deptid = '' then 0 else 1 end as flag, 
                  a.ID,a.KSMC,a.DEPTID,a.KSLX from YP_YJKS a 
                  left join (select DEPTID from yp_wbksyp where cjid ={0}) b on a.DEPTID = b.DEPTID 
                  where iswbks =1", cjid);
            DataTable tab = InstanceForm.BDatabase.GetDataTable(sql);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = tab;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (dataGridView1.RowCount > 0)
            {
                string sql = string.Empty;
                InstanceForm.BDatabase.BeginTransaction();
                try
                {
                    sql = string.Format("delete from yp_wbksyp where cjid = {0} ", cjid);
                    InstanceForm.BDatabase.DoCommand(sql);

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        object obj = dataGridView1.Rows[i].Cells["flag"].Value;
                        if (obj != null && (obj.ToString().Trim() == "1" || obj.ToString().Trim().ToUpper() == "TRUE"))
                        {
                            sql = string.Format("insert into yp_wbksyp(cjid,deptid) values({0},{1})", cjid, dataGridView1.Rows[i].Cells["DEPTID"].Value);
                            InstanceForm.BDatabase.DoCommand(sql);
                        }
                    }
                    InstanceForm.BDatabase.CommitTransaction();
                    MessageBox.Show("²Ù×÷³É¹¦!");
                    DialogResult = DialogResult.OK;
                }
                catch
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                }
            }
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        bool param = true;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["flag"].Value = param ? 1 : 0;
            }
            param = !param;
        }
    }
}