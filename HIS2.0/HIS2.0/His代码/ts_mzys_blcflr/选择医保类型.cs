using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_blcflr
{
    public partial class FrmSelYblx : Form
    {
        public bool bok = false;
        public FrmSelYblx()
        {
            InitializeComponent();
            ts_mz_class.FunAddComboBox.AddYblx(false, 0, cmbyblx, InstanceForm.BDatabase);
        }

        private void FrmSelYblx_Load(object sender, EventArgs e)
        {
           
        }

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butok_Click(object sender, EventArgs e)
        {
            bok = true;
            this.Close();
        }
    }
}