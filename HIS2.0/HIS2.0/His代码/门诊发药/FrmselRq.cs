using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_yf_mzfy
{
    public partial class FrmselRq : Form
    {
        public bool bok = false;
        public DateTime rq;
        public FrmselRq()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            bok = true;
            rq = this.dateTimePicker1.Value;
        }
    }
}