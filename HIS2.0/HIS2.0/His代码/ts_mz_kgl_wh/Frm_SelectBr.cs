using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_kgl
{
    public partial class Frm_SelectBr : Form
    {
        private Guid _brxxid=Guid.Empty;
        public Guid brxxid
        {
            get { return _brxxid; }
        }

        public Frm_SelectBr()
        {
            InitializeComponent();
        }
        public Frm_SelectBr(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            if (dgr == null) return;
            dgr.Selected = true;
            _brxxid = new Guid(dgr.Cells["≤°»Àid"].Value.ToString());
            this.Close();
        }
    }
}