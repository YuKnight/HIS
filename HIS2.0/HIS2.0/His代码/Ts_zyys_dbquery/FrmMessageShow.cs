using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_zyys_public
{
    public partial class FrmMessageShow : Form
    {
        public FrmMessageShow()
        {
            InitializeComponent();
        }

        private void btnqd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnqx_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmMessageShow_Load(object sender, EventArgs e)
        {
            
        }
    }
}