using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_zyhs_yzgl
{
    public partial class Frmserch : Form
    {
        public string INpatient_no = "";
        public string zyh = "";
        public int Zyhflag = 0;
        public string Name = "";

        public Frmserch()
        {
            InitializeComponent();
        }

        private void txtinpatientNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.txtinpatientNo.Text.Trim() == INpatient_no.Trim())
                {
                    this.textBox1.Focus();
                }
                else
                {
                    INpatient_no = this.txtinpatientNo.Text.Trim();
                    Zyhflag = 1;
                    this.Close();
                }
            }
            
        }

        private void Frmserch_Load(object sender, EventArgs e)
        {
            SystemCfg cfg5026 = new SystemCfg(5026);
            int leng =Int32.Parse( cfg5026.Config);
            for (int i = 0; i < leng; i++)
            {
                INpatient_no += "0";
            }
            this.txtinpatientNo.InpatientNoLength = leng;
            zyh = INpatient_no;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.textBox1.Text.Trim() == Name.Trim())
                {
                    this.button1.Focus();
                }
                else
                {
                    Name = this.textBox1.Text.Trim();
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (zyh!=this.txtinpatientNo.Text.Trim())
            {
                 INpatient_no = this.txtinpatientNo.Text.Trim();
                Zyhflag = 1;
            }
            Name = this.textBox1.Text.Trim();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}