using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_cfsh
{
    public partial class F_cfshqr : Form
    {
        private string _reason;
        public string Reason
        {
            get { return _reason; }
        }
        public F_cfshqr()
        {
            InitializeComponent();
        }
        public F_cfshqr(DataRow[] dr)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("医嘱内容", typeof(string));
            dt.Columns.Add("数量",typeof(string));
            for (int i = 0; i < dr.Length; i++)
            {
                if (dr[i]["医嘱内容"].ToString() != "")
                {
                    DataRow r = dt.NewRow();
                    r[0] = dr[i]["医嘱内容"].ToString();
                    r[1] = dr[i]["数量"].ToString();
                    dt.Rows.Add(r);
                }
            }
            dataGridView1.DataSource = dt;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            _reason = this.txt_reason.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void F_cfshqr_Load(object sender, EventArgs e)
        {

        }
    }
}