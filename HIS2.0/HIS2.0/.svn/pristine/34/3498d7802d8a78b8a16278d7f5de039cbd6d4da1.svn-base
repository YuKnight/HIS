using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using YpClass;

namespace Ts_zyys_yzgl
{
    public partial class FrmSsYpWh : Form
    {
        EditType currentType;
        string[] orders;
        DataTable dataSouce;
        public FrmSsYpWh(EditType type, string[] orders)
        {
            InitializeComponent();
            this.currentType = type;
            this.orders = orders;
        }

        private void FrmSsYpWh_Load(object sender, EventArgs e)
        {          
            string sql = "select KSSDJID,KSSDJMC from YP_KSSDJ order by KSSDJID ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            DataRow dr = tb.NewRow();
            dr["KSSDJMC"] = "";
            tb.Rows.InsertAt(dr, 0);
            comboBox1.ValueMember = "KSSDJID";
            comboBox1.DisplayMember = "KSSDJMC";
            comboBox1.DataSource = tb;


            if (currentType == EditType.add)
            {
                sql = @" select GGID,YPSPM,YPGG,KSSDJID,PYM,WBM from YP_YPGGD  ";
            }
            else
            {
                sql = string.Format(@" select GGID,YPSPM,YPGG,KSSDJID,PYM,WBM from YP_YPGGD where
                     GGID in (select GGID from jc_SsYpGx where ORDER_ID = {0} )", orders[0]);
            }
            dataSouce = FrmMdiMain.Database.GetDataTable(sql);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dataSouce;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (dataGridView1.RowCount == 0)
                return;
            List<string> list = new List<string>();
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                object obj = dgvRow.Cells["checkBox"].Value;
                if (obj != null && obj.ToString().Trim() == "1")
                {
                    list.Add(dgvRow.Cells["GGID"].Value.ToString());
                }
            }
            if (list.Count == 0)
            {
                MessageBox.Show(string.Format("请勾选要{0}的药品！", currentType == EditType.add ? "添加" : "删除", "提示"));
                return;
            }
            if (currentType == EditType.add)
            {
                string sql = null;
                string insertSql = "insert into jc_SsYpGx(ID,ORDER_ID,GGID) values('{0}',{1},{2})";
                foreach (string orderid in orders)
                {
                    foreach (string ggid in list)
                    {
                        sql = String.Format("select ID from jc_SsYpGx where ORDER_ID = {0} and GGID = {1}", orderid, ggid);
                        DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            FrmMdiMain.Database.DoCommand(string.Format(insertSql, Guid.NewGuid().ToString(), orderid, ggid));
                        }
                    }
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in list)
                {
                    sb.Append(s + ",");
                }
                string ypRang = sb.Remove(sb.Length - 1, 1).ToString();
                foreach (string orderid in orders)
                {
                    string deleteSql = string.Format("delete from jc_SsYpGx where ORDER_ID = {0} and GGID in ({1})", orderid, ypRang);
                    FrmMdiMain.Database.DoCommand(deleteSql);
                }
            }
            MessageBox.Show("操作成功!", "提示");
            DialogResult = DialogResult.OK;
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dataSouce == null || dataSouce.Rows.Count == 0)
                    return;
                if (textBox1.Text.Trim() != string.Empty)
                {
                    DataTable currentTable = dataSouce.Copy();
                    DataRow[] resultRows = currentTable.Select(string.Format(" YPSPM like '%{0}%' or YPGG like '%{0}%' or PYM like '%{0}%' or WBM like '%{0}%'", textBox1.Text.Trim().Replace("'", "''")));
                    DataTable newTable = currentTable.Clone();
                    if (resultRows != null && resultRows.Length > 0)
                    {
                        foreach (DataRow tmpRow in resultRows)
                            newTable.Rows.Add(tmpRow.ItemArray);
                    }
                    dataGridView1.DataSource = newTable;
                }
                else
                {
                    DataTable newTable = dataSouce.Clone();
                    if (dataSouce != null && dataSouce.Rows.Count > 0)
                    {
                        foreach (DataRow tmpRow in dataSouce.Rows)
                            newTable.Rows.Add(tmpRow.ItemArray);
                    }
                    dataGridView1.DataSource = newTable;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataSouce == null || dataSouce.Rows.Count == 0)
                return;
            if (comboBox1.SelectedIndex != -1 && !string.IsNullOrEmpty(comboBox1.Text))
            {
                DataTable currentTable = dataSouce.Copy();
                DataRow[] resultRows = currentTable.Select(string.Format(" KSSDJID = {0}", comboBox1.SelectedValue.ToString()));
                DataTable newTable = currentTable.Clone();
                if (resultRows != null && resultRows.Length > 0)
                {
                    foreach (DataRow tmpRow in resultRows)
                        newTable.Rows.Add(tmpRow.ItemArray);
                }
                dataGridView1.DataSource = newTable;
            }
            else
            {
                DataTable newTable = dataSouce.Clone();
                if (dataSouce != null && dataSouce.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in dataSouce.Rows)
                        newTable.Rows.Add(tmpRow.ItemArray);
                }
                dataGridView1.DataSource = newTable;        
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        
    }
}