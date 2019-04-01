using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;

namespace Ts_zyys_ssgl
{
    public partial class FrmSect : Form
    {
        public FrmSect()
        {
            InitializeComponent();
        }

        public decimal selectvaluebl = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                selectvaluebl = decimal.Parse(this.comboBox1.Text.ToString() == "" ? "0" : this.comboBox1.Text.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void FrmDel_Load(object sender, EventArgs e)
        {
            string str= (new SystemCfg(6096)).Config;
            if(str !="")
            {
                string[] value = str.Split(',');
                for (int i = 0; i < value.Length; i++)
                {
                    this.comboBox1.Items.Insert(i, value[i]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}