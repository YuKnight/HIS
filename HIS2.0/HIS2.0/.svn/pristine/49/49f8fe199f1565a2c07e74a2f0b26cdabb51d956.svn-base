using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_yf_tjbb
{
    public partial class frmData : Form
    {
        public frmData(string title, DataTable dt, string Function_Name)
        {
            InitializeComponent();
            this.Text = title;
            label1.Text = "¹²" + dt.Rows.Count;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.DataSource = dt;
            if (Function_Name == "Fun_ts_yf_tjbb_mzcftj_rq" )
            {

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ts_jc_log.ExcelOper.ExportData_ForDataTable(dataGridView1, this.Text);
            }
            catch
            {
                //
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}