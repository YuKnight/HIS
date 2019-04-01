using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_ss_main
{
    public partial class Frmserch : Form
    {
        public string Tj = "";
        public Frmserch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkTime.Checked)
            {
                if (this.radioButton1.Checked)
                {
                    Tj = " sqdjrq<='" + this.dateTimePicker2.Value.ToString() + "' and sqdjrq>= '" + this.dateTimePicker1.Value.ToString() + "'";
                }
                else
                    if (this.radioButton2.Checked)
                    {
                        Tj = " ysssrq<='" + this.dateTimePicker2.Value.ToString() + "' and ysssrq>= '" + this.dateTimePicker1.Value.ToString() + "'";
                    }
                    else
                    {
                        Tj = " yxssrq<='" + this.dateTimePicker2.Value.ToString() + "' and yxssrq>= '" + this.dateTimePicker1.Value.ToString() + "'";
                    }
            }
            string zyh = txtZyh.Text.Trim();
            if (zyh != "")
            {
                Tj += (Tj.Trim() == "" ? "" : " and ") + " inpatient_no like '%" + zyh + "%' ";
            }
            this.Close();
        }

        private void btnQx_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmserch_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = Convert.ToDateTime(this.dateTimePicker1.Value.ToShortDateString() + " 00:00:01");
            dateTimePicker2.Value = Convert.ToDateTime(this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59");

            txtZyh.Focus();
        }

        private void txtZyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtZyh.Text.Trim() != "")
                {
                    button1_Click(sender, null);
                }
            }
        }
    }
}