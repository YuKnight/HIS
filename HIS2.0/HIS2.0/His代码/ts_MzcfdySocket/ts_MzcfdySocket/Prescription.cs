using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ts_PrintProcess;

namespace ts_MzcfdySocket
{
    public partial class Prescription : UserControl
    {
        public Prescription()
        {
            InitializeComponent();
        }

        string winNum =null;
        private void Prescription_Load(object sender, EventArgs e)
        {
            winNum = Utility.ReadConfig("WinNum", "ts_MzcfdySocket.exe.config");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (tbxBrkh.Text.Trim() != string.Empty)
            {
                string sql = string.Format(@"  select b.BLH as 卡号门诊号, b.FPH as 发票号,c.BRXM 病人姓名,b.SFRQ 收费日期,
                              a.ID,a.FYCKH 发药窗口号,b.cfid from MZ_MZKF a 
                              left join mz_cfb b  on a.BRXXID = b.BRXXID and  a.DEPTID = b.ZXKS
                              left join YY_BRXX c on a.BRXXID = c.BRXXID  
                              where a.FYCKH = {0} and b.BFYBZ != 1 and a.DEPTID = {1}", winNum, 207);
                sql += string.Format(" and b.BLH = '{0}'", tbxBrkh.Text.Trim());
                DataTable dt = PrescriptionPrint.DB.GetDataTable(sql);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataRow currentRow = (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
                if (currentRow != null)
                {
                    ts_PrintProcess.PrescriptionPrint p = new ts_PrintProcess.PrescriptionPrint();
                    string resultMsg = string.Empty;
                    bool ret = p.Print(currentRow["卡号门诊号"].ToString(), 207, out resultMsg);
                    if (ret)
                    {
                        string sql = string.Format("update mz_mzkf set isprint = 1 where id = '{0}'", currentRow["ID"]);
                        PrescriptionPrint.DB.DoCommand(sql);
                    }
                }
            }
        }

        private void tbxBrkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnQuery_Click(null, null);
        }
    }
}
