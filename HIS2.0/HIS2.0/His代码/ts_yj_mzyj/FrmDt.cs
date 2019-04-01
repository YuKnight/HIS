using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_yj_mzyj
{
    public partial class FrmDt : Form
    {
        public string dt;
        public FrmDt()
        {
            InitializeComponent();
        }

        private void btConfitm_Click(object sender, EventArgs e)
        {
            this.dt = this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}