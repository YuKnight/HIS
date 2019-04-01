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
    public partial class FrmSsYp : Form
    {
        public FrmSsYp()
        {
            InitializeComponent();
        }

        private void FrmSsYp_Load(object sender, EventArgs e)
        {
            string sql = "select ORDER_ID,ORDER_NAME,ORDER_UNIT,PY_CODE,WB_CODE,D_CODE from JC_HOITEMDICTION where ORDER_TYPE=6";
            DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            string ORDER_ID = dataGridView1.CurrentRow.Cells["ORDER_ID"].Value != null ? dataGridView1.CurrentRow.Cells["ORDER_ID"].Value.ToString() : "";
            string sql = string.Format(@"select a.ID,a.ORDER_ID,a.GGID,
                            b.YPSPM,b.YPGG from jc_SsYpGx a
                            inner join YP_YPGGD b on a.GGID = b.GGID
                            where a.ORDER_ID = {0}", ORDER_ID);
            DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt;
        }

        private string[] GetSelectItems()
        {
            dataGridView1.EndEdit();
            if (dataGridView1.RowCount == 0)
                return null;
            List<string> list = new List<string>();
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                object obj = dgvRow.Cells["checkbox"].Value;
                if (obj != null && obj.ToString().Trim() == "1")
                {
                    list.Add(dgvRow.Cells["ORDER_ID"].Value.ToString());
                }
            }
            return list.ToArray();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            string[] orders = GetSelectItems();
            if (orders == null || orders.Length == 0)
                return;            
            FrmSsYpWh frm = new FrmSsYpWh(EditType.add, orders);
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dataGridView1_SelectionChanged(null, null);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //string[] orders = GetSelectItems();
            //if (orders == null || orders.Length == 0)
            //    return;
            if (dataGridView1.CurrentRow == null)
                return;
            string ORDER_ID = dataGridView1.CurrentRow.Cells["ORDER_ID"].Value != null ? dataGridView1.CurrentRow.Cells["ORDER_ID"].Value.ToString() : "";
            FrmSsYpWh frm = new FrmSsYpWh(EditType.delete, new string[] { ORDER_ID });
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dataGridView1_SelectionChanged(null, null);
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                toolStripButton1_Click(null, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0 && toolStripTextBox1.Text.Trim() != string.Empty)
            {
                BindingManagerBase bm = this.BindingContext[dataGridView1.DataSource];
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string ORDER_NAME = dataGridView1.Rows[i].Cells["ORDER_NAME"].Value != null ? dataGridView1.Rows[i].Cells["ORDER_NAME"].Value.ToString().Trim() : "";
                    string PY_CODE = dataGridView1.Rows[i].Cells["PY_CODE"].Value != null ? dataGridView1.Rows[i].Cells["PY_CODE"].Value.ToString().Trim() : "";
                    string WB_CODE = dataGridView1.Rows[i].Cells["WB_CODE"].Value != null ? dataGridView1.Rows[i].Cells["WB_CODE"].Value.ToString().Trim() : "";
                    string D_CODE = dataGridView1.Rows[i].Cells["D_CODE"].Value != null ? dataGridView1.Rows[i].Cells["D_CODE"].Value.ToString().Trim() : "";
                    if (ORDER_NAME.Contains(toolStripTextBox1.Text.Trim()) ||
                        PY_CODE.Contains(toolStripTextBox1.Text.Trim()) ||
                        WB_CODE.Contains(toolStripTextBox1.Text.Trim()) ||
                        D_CODE.Contains(toolStripTextBox1.Text.Trim()))
                    {
                        bm.Position = i;
                        return;
                    }
                }
            }
        }
    }
}