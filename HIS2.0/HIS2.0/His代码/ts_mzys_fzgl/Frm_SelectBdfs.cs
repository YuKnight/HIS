using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_fzgl
{
    public partial class Frm_SelectBdfs : Form
    {
        public bool flag = false;

        public bool fz_type = false; //true 自动分诊 false手动分诊
        public Frm_SelectBdfs()
        {
            InitializeComponent();
        }

        private void But_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void But_Save_Click(object sender, EventArgs e)
        {
            flag = true;
            if (this.RdbAuto.Checked)
                fz_type = true;
            this.Close();
        }
    }
}
