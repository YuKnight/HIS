using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmFzyyMemo : Form
    {
        string _zd = "";
        string _order = "";

        public string _memo = "";

        public FrmFzyyMemo()
        {
            InitializeComponent();
        }

        public FrmFzyyMemo(string zd, string order)
        {
            InitializeComponent();

            _zd = zd;
            _order = order;
        }

        private void FrmFzyyMemo_Load(object sender, EventArgs e)
        {
            lblFzyy.Text = _order;
            lblZd.Text = _zd;

            txtMemo.Focus();
        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSure.Select();
                btnSure.Focus();
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            _memo = txtMemo.Text.Trim();

            if (_memo.Equals(""))
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}