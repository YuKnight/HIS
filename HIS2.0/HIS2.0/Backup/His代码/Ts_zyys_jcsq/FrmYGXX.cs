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
    public partial class FrmYGXX : Form
    {
      

        public FrmYGXX()
        {
            InitializeComponent();
        }

      

        private void FrmYGXX_Load(object sender, EventArgs e)
        {
            string sql = "select  id,name,context,djsj,pym,wmb,(select top 1  name from JC_JCCLASSDICTION  where id=jclxid) 项目分类,jclxid from Jc_Jybs_Jc";
            DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
            this.dataGridView1.DataSource = dt; 
            
             string sSql = string.Format(@"select 0 id ,'全部' name union all   select	distinct A.jclxid ID,
                                                B.name NAME     
                                           from jc_jc_item A  left outer join      
                                                jc_jcclassdiction B 
                                                on A.jclxid=B.ID and B.class_type=0  ");
             DataTable tbflx = FrmMdiMain.Database.GetDataTable(sSql);
             comboBox1.ValueMember = "id";
             comboBox1.DisplayMember = "name";
             comboBox1.DataSource = tbflx;
             comboBox1.SelectedIndex = 0;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            
            string s1 = textBox2.Text;
            string s2 = textBox3.Text;
            string s3 = textBox4.Text;
            string s4 = textBox5.Text;
            string s5 = this.comboBox1.SelectedValue == null ? "0" : this.comboBox1.SelectedValue.ToString();
            string sql = string.Format("insert into Jc_Jybs_Jc (name,context,pym,wmb,jclxid ) values ('{0}','{1}','{2}','{3}',{4} )", s1, s2, s3, s4,s5);
            DataTable dt = FrmMdiMain.Database.GetDataTable(sql);

            //dataGridView1.DataSource = 0;
            string sql1 = "select  id,name,context,djsj,pym,wmb,(select top 1  name from JC_JCCLASSDICTION  where id=jclxid) 项目分类,jclxid from Jc_Jybs_Jc";
            DataTable dt1 = FrmMdiMain.Database.GetDataTable(sql1);
            this.dataGridView1.DataSource = dt1;

            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox2.Focus();
           
        }

       

        private void button2_Click(object sender, EventArgs e)
        {

           if (MessageBox.Show("是否确定要当前行？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
          {
              string sqls = "delete  from Jc_Jybs_Jc where id=" + textBox1.Text.Trim();
              DataTable dt = FrmMdiMain.Database.GetDataTable(sqls);

              //dataGridView1.DataSource = 0;

              string sqlss = "select id, name,context,djsj,pym,wmb,(select top 1  name from JC_JCCLASSDICTION  where id=jclxid) 项目分类,jclxid from Jc_Jybs_Jc";
              DataTable dts = FrmMdiMain.Database.GetDataTable(sqlss);
              this.dataGridView1.DataSource = dts;
              this.textBox2.Text = "";
              this.textBox3.Text = "";
              this.textBox4.Text = "";
              this.textBox5.Text = "";
              this.textBox2.Focus();
          }

          
           


            //this.Close();
            //FrmYGXX yg = new FrmYGXX();
            //yg.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
             
            string s1 = textBox2.Text.Trim();
            string s2 = textBox3.Text.Trim();
            string s3 = textBox4.Text.Trim();
            string s4 = textBox5.Text.Trim();
            string s5 = this.comboBox1.SelectedValue.ToString();
            string sql2 = "update Jc_Jybs_Jc set name='" + s1 + "',context='" + s2 + "',pym='" + s3 + "',wmb='" + s4 + "', jclxid="+s5+" where id =" + textBox1.Text.Trim();
            DataTable dt2 = FrmMdiMain.Database.GetDataTable(sql2);
            //dataGridView1.DataSource = 0;
            string sql3 = "select id, name,context,djsj,pym,wmb,(select top 1  name from JC_JCCLASSDICTION  where id=jclxid) 项目分类,jclxid from Jc_Jybs_Jc";
            DataTable dt3 = FrmMdiMain.Database.GetDataTable(sql3);
            this.dataGridView1.DataSource = dt3;

     


        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int n = dataGridView1.CurrentCell.RowIndex;
                //if (n < dataGridView1.RowCount - 1)
                {
                    textBox1.Text = dataGridView1[0, n].Value.ToString().Trim();
                    textBox2.Text = dataGridView1[1, n].Value.ToString().Trim();
                    textBox3.Text = dataGridView1[2, n].Value.ToString().Trim();
                    //textBox6.Text = dataGridView1[3, n].Value.ToString().Trim();
                    textBox4.Text = dataGridView1[4, n].Value.ToString().Trim();
                    textBox5.Text = dataGridView1[5, n].Value.ToString().Trim();
                    DataTable tb=(DataTable)this.dataGridView1.DataSource;

                    this.comboBox1.SelectedValue = tb.Rows[n]["jclxid"].ToString() == "" ? 0 : int.Parse(tb.Rows[n]["jclxid"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if ((sender as Control).Name == "textBox2")
                {
                    this.textBox4.Text = PubStaticFun.GetPYWBM(this.textBox2.Text,0);
                    this.textBox5.Text = PubStaticFun.GetPYWBM(this.textBox2.Text, 1);
                }
                this.SelectNextControl((sender as TextBox), true, false, false, true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox2.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                textBox4.Focus();
            }
        }

      

      

      
    }

    
    
}