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
    public partial class FrmJybsSz : Form
    {
        public string context = "";
        public int Hylx=0;
        public FrmJybsSz()
        {
            InitializeComponent();
        }

        private void FrmJybsSz_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
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
            comboBox1.SelectedText = "全部";
            sSql = "select  name 名称,context 内容,djsj,pym,wmb,(select top 1  name from JC_JCCLASSDICTION  where id=jclxid) 项目分类,jclxid,id from Jc_Jybs_Jc ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sSql);
            this.dataGridView1.DataSource = tb;
            this.comboBox1.SelectedIndexChanged -= new EventHandler(comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedIndexChanged+=new EventHandler(comboBox1_SelectedIndexChanged);
           // this.comboBox1.SelectedIndex = 0;
            comboBox1_SelectedIndexChanged(null, null);
        }


        /// <summary>
        /// 解决选中一个诊断后，回车会选中下个诊断的漏洞  Modify by zouchihua 2013-7-2
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool IsdgvInput = false;
            if (this.ActiveControl == this.dataGridView1)
            {
                IsdgvInput = true;
            }
            else
            {
                if (this.ActiveControl is IDataGridViewEditingControl)
                {
                    if ((this.ActiveControl as IDataGridViewEditingControl).EditingControlDataGridView == this.dataGridView1)
                    {
                        IsdgvInput = true;
                    }

                }
            }

            if (IsdgvInput)
            {
                switch (keyData)
                {
                    case Keys.Enter:
                        dataGridView1_CellContentDoubleClick(null, null);
                        return false;
                    default:
                        return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            string filter =" 1=1 ";
            if(this.comboBox1.SelectedValue.ToString()!="-1")
                 filter+=" and   jclxid="+this.comboBox1.SelectedValue.ToString();
             if (textBox1.Text.Trim() != "")
                 filter += " and ( pym like '%" + textBox1.Text.Trim() + "%' or 名称 like '%" + textBox1.Text.Trim() + "%'  )";
             tb.DefaultView.RowFilter = filter;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (this.dataGridView1.Rows.Count== 0)
                return;
            try
            {
                context = tb.DefaultView[this.dataGridView1.CurrentCell.RowIndex]["内容"].ToString();
            }
            catch { }
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1_TextChanged(null, null);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                dataGridView1_CellContentDoubleClick(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (this.dataGridView1.Rows.Count == 0)
                return;
            try
            {
                string ss = "delete from Jc_Jybs_Jc where id='" + tb.DefaultView[dataGridView1.CurrentCell.RowIndex]["id"].ToString() + "'";
                FrmMdiMain.Database.DoCommand(ss);
                this.dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
            catch { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (this.dataGridView1.Rows.Count == 0)
                return;
            try
            {
                context = tb.DefaultView[this.dataGridView1.CurrentCell.RowIndex]["内容"].ToString();
            }
            catch { }
            this.Close();
        }
    }
}