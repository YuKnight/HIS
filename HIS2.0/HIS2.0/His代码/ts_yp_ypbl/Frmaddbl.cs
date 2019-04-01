using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_yp_ypbl
{
    public partial class Frmaddbl : Form
    {
        public bool bok = false;
        public Frmaddbl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bok = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bok = false;
            this.Close();
        }

        private void txtrq2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}