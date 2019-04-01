using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_blcflr
{
    public partial class 新建模板 : Form
    {
        public 新建模板()
        {
            InitializeComponent();
        }

        public string mbmc = "";
        public string bz = "";
        

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtMbmc.Text.Trim() == "")
            {
                MessageBox.Show("模板名称不能为空", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMbmc.Focus();
                return;
            }
            mbmc = txtMbmc.Text.Trim();
            bz = txtBz.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}