using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmDel : Form
    {
        public int beginrow=-1;
        public int endrow=-1;
        private int textstr;

        public int Textstr
        {
            get { return textstr; }
            set { textstr = value; }
        }
        public FrmDel()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{%Q}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            beginrow = -1;
            endrow = -1;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("%C");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                beginrow = Convert.ToInt32(this.textBox1.Text.Trim() == "" ? "0" : this.textBox1.Text.Trim());
                endrow = Convert.ToInt32(this.textBox2.Text.Trim() == "" ? "0" : this.textBox2.Text.Trim());
                if (beginrow <= 0 && endrow <= 0)
                {
                    MessageBox.Show("请输入起始行和结束行");
                    this.textBox1.Focus();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                this.textBox1.Focus();
                MessageBox.Show(ex.Message);
            }
            
        }

        private void FrmDel_Load(object sender, EventArgs e)
            {
            if (textstr == 0)
            {
                this.Text = "删除医嘱";
                this.label1.Text = "根据行号删除医嘱";
            }
            else
            {
                this.Text = "复制医嘱";
                this.label1.Text = "根据行号复制医嘱";
            }
        }
    }
}