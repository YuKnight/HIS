using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ts_zyys_jcsq;

namespace ts_mzys_yjsqd
{
    public partial class Muban : Form
    {


        private Frmjcsqd FrmP;
        private FrmJCSQ FrmJ;
        public int ksdm = 0;
        public Muban()
        {
            InitializeComponent();
            
        }

        public Muban(Frmjcsqd _FrmP)
        {
            FrmP = _FrmP;
            InitializeComponent();
            
        }

        public Muban(FrmJCSQ _FrmJ)
        {
            FrmJ = _FrmJ;
            InitializeComponent();
           
        }
        public void GetMuban()
        {
            try
            {
                string strSql = @" select id,name,context from dbo.Jc_Jybs_Jc where ISNULL( delete_bit,0)=0 and  (pym like'%" + txtname.Text + "%' or wmb like '%" + txtname.Text + "%') ";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);
                dataGridView2.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Muban_Load(object sender, EventArgs e)
        {
            dataGridView2.AutoGenerateColumns = false;
            GetMuban();
        }

        private void dataGridView2_CellDoubleClick(object sender, EventArgs e)
        {
            try
            {
                string context = string.Empty;
                DataTable tb = (DataTable)this.dataGridView2.DataSource;
                if (tb.Rows.Count == 0) return;
                int nrow = this.dataGridView2.CurrentCell.RowIndex;
                if (tb.Rows[nrow]["context"] != null)
                    context = tb.Rows[nrow]["context"].ToString();
                this.Close();
                if (FrmP != null)
                {
                    FrmP.txtbs.Text = context;
                }
                if (FrmJ != null)
                {
                    FrmJ.richRecord.Text += "\n" + context;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            GetMuban();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView2.SelectedRows.Count; i++)
            {
                string sql="update Jc_Jybs_Jc set delete_bit=1 where id="+this.dataGridView2.SelectedRows[i].Cells[0].Value.ToString()+"";
                InstanceForm.BDatabase.DoCommand(sql);
            }
            GetMuban();
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)(e.KeyChar) == 13)
            {
                DataGridViewRow row = dataGridView2.CurrentRow;
                if (row == null)
                {
                    MessageBox.Show("请选择要加载文本模板!");
                    return;
                }
                try
                {
                    string context = string.Empty;
                    if (row.Cells["context"] != null)
                        context = row.Cells["context"].ToString();
                    this.Close();
                    if (FrmP != null)
                    {
                        FrmP.txtbs.Text = context;
                    }
                    if (FrmJ != null)
                    {
                        FrmJ.richRecord.Text = context;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}