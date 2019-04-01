using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_xtsz
{
    
    public partial class Frm_XgFpd : Form
    {
        public bool DlgResult;
        public string DlgValue;
        public string bz;
        public Frm_XgFpd(string fph)
        {
            InitializeComponent();
            this.txt_fph.Text = fph;
        }

        private void But_Close_Click(object sender, EventArgs e)
        {
            DlgResult = false;
            this.Close();
        }

        private void But_Ok_Click(object sender, EventArgs e)
        {
            DlgValue = this.txt_fph.Text.Trim();
            bz = this.richTextBox1.Text.Trim();
            DlgResult = true;
            this.Close();
        }
    }
}
