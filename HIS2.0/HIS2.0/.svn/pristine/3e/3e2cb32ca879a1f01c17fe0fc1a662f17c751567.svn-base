using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_class
{
    public partial class Frmjsq : Form
    {
        public decimal values = 0;
        public bool bok = false;
        public Frmjsq()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control control=(Control)sender;
            //if (txtvalue.Text.Trim()=="" && control.Text == "0") return;
            if (txtvalue.Text.Trim() == "" && control.Text == ".") return;
            txtvalue.Text =txtvalue.Text + control.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtvalue.Text = "";
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bok = false;
            this.Close();
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (txtvalue.Text.Trim() == "")
                values = 0;
            else
                values = Convert.ToDecimal(txtvalue.Text);
            bok = true;
            this.Close();
        }
    }
}