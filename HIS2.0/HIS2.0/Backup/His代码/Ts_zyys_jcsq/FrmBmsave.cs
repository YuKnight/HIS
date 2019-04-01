using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
namespace Ts_zyys_jcsq
{
    public partial class FrmBmsave : Form
    {
        public int Hylx = 0;
        public string nr = "";
        public FrmBmsave()
        {
            InitializeComponent();
        }

        private void FrmBmsave_Load(object sender, EventArgs e)
        {
            string sSql = string.Format(@"select -1 id ,'全部' name union all   select	distinct A.jclxid ID,
                                                B.name NAME     
                                           from jc_jc_item A  left outer join      
                                                jc_jcclassdiction B 
                                                on A.jclxid=B.ID and B.class_type=0  ");
            DataTable tbflx = FrmMdiMain.Database.GetDataTable(sSql);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = tbflx;
             
            comboBox1.SelectedValue = Hylx;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("名称不能为空");
                return;
            }
            string s1 = this.textBox1.Text.Trim();
            string s2 = nr;
            string s3 =  PubStaticFun.GetPYWBM(this.textBox1.Text,0);
            string s4 = PubStaticFun.GetPYWBM(this.textBox1.Text, 1);
            string s5 = this.comboBox1.SelectedValue.ToString();
            try
            {
                string sql = string.Format("insert into Jc_Jybs_Jc (name,context,pym,wmb,jclxid ) values ('{0}','{1}','{2}','{3}',{4} )", s1, s2, s3, s4, s5);
                FrmMdiMain.Database.DoCommand(sql);
            }
            catch { MessageBox.Show("对不起，只能保存500个汉字，请您修改后重新保存！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.comboBox1.Focus();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.button1.Focus();
            }
        }
    }
}