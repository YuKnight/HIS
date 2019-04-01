using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_blcflr
{
    public partial class 诊断修改 : Form
    {
        public 诊断修改(string zdmc)
        {
            this._zdmc = zdmc;
            InitializeComponent();
        }
        public string newzdmc;
        private string _zdmc;

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确认将：" + _zdmc + "\n修改为：" + textBox1.Text.ToString().Trim() + "吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;

            }
            this.DialogResult = DialogResult.OK;
            newzdmc = textBox1.Text.ToString().Trim();
        }

        private void 诊断修改_Load(object sender, EventArgs e)
        {
            textBox1.Text = _zdmc.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                button1_Click(null, null);
            
            }
        }

    }
}