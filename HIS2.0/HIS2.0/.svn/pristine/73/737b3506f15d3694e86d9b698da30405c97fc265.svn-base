using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_zyhs_yzgl
{
    public partial class FrmReason : Form
    {
        public string ss = "";
        public FrmReason()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.Text.Trim() == "")
            {
                MessageBox.Show(this, "对不起，理由不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
            ss = this.richTextBox1.Text.Trim();
            this.DialogResult = DialogResult.Yes;
            this.Close();
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.button1.Focus();
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') 
            {
                this.button1_Click(null,null);
            }
        }
    }
}