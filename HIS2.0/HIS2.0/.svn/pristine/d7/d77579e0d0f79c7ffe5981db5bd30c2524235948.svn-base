using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_blcflr
{
    public partial class frmzt : Form
    {
        public string returnValues = "";
        public bool bok = false;
        public string InputValue = ""; //Add By zp 2014-01-09 可以在医生站传入
        public frmzt()
        {
            InitializeComponent();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;

                TextBox coninput = new TextBox();
                coninput = txtdm;
                coninput.Focus();
                if (control.Text == "删除")
                {
                    if (coninput.Text.Trim().Length > 0)
                        coninput.Text = coninput.Text.Substring(0, coninput.Text.Trim().Length - 1);
                }
                if (control.Text != "删除" && control.Text != "清除")
                {
                    coninput.Text = coninput.Text + control.Text;
                }
                if (control.Text == "清除" || control.Text == "全部")
                {
                    coninput.Text = "";
                }
                coninput.Select(coninput.Text.Length, 0);
                coninput.Focus();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtdm_TextChanged(object sender, EventArgs e)
        {
            select(txtdm.Text.Trim());
        }

        private void select(string ss)
        {
            try
            {
                ss = ss.Replace("'", "");
                string ssql = "select '' 序号,0 选择,contents 嘱托内容,py_code 拼音码,wb_code 五笔码,d_code 助记码,'' 添加人,'' 添加时间 from JC_ENTRUST ";
                if (ss != "")
                {
                    ssql = ssql + " where contents like '%" + ss + "%' or py_code like '" + ss + "%' or wb_code like '" + ss + "%' ";
                }
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                dataGridView1.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;
                for(int i=0;i<=tb.Rows.Count;i++)
                    tb.Rows[e.RowIndex]["选择"] = "0";

 
                 tb.Rows[e.RowIndex]["选择"] = "1";


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;
            bok = true;
            returnValues = tb.Rows[dataGridView1.CurrentCell.RowIndex]["嘱托内容"].ToString().Trim();
            this.Close();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            bok = false;
            this.Close();
        }

        private void butadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmc.Text.Trim() == "")
                {
                    MessageBox.Show("请输入医嘱名称", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmc.Focus();
                    return;
                }
                if (txtpym.Text.Trim() == "")
                {
                    MessageBox.Show("请输入拼音码,方便检索", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpym.Focus();
                    return;
                }
                string ssql = "select * from JC_ENTRUST where contents='"+txtmc.Text.Trim()+"' and delete_bit=0 ";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                {
                    MessageBox.Show("该嘱托名称已存在,不能重复添加", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmc.Focus();
                    return;
                }

                ssql = "insert into JC_ENTRUST(contents,py_code,wb_code,d_code)values('"+txtmc.Text.Trim()+"','"+txtpym.Text.Trim()+"','"+txtwb.Text.Trim()+"','"+txtzy.Text.Trim()+"')";
                InstanceForm.BDatabase.DoCommand(ssql);

                MessageBox.Show("添加成功");

                txtdm.Text = txtmc.Text;
                txtdm_TextChanged(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmc_Leave(object sender, EventArgs e)
        {
            try
            {
                txtpym.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtmc.Text, 0);
                txtwb.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtmc.Text, 1);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            try
            {
                ToolStripTextBox control = (ToolStripTextBox)sender;
                if (e.KeyChar != 13) return;
                if (control.Name == "txtmc") { txtpym.Focus(); return; }
                if (control.Name == "txtpym") { txtwb.Focus(); return; }
                if (control.Name == "txtwb") { txtzy.Focus(); return; }
                if (control.Name == "txtzy") { butadd_Click(sender,e); return; }

            }
            catch (System.Exception err)
            {
                MessageBox.Show("" + err.Message);
            }
        }

        private void txtmc_TextChanged(object sender, EventArgs e)
        {
            select(txtmc.Text.Trim());
        }

        private void frmzt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void butok_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb.Rows.Count == 0) { MessageBox.Show("请选择嘱托","",MessageBoxButtons.OK,MessageBoxIcon.Information); return; };
                bok = true;
                DataRow[] rows = tb.Select("选择=true");
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    if (i==0)
                        returnValues = rows[i]["嘱托内容"].ToString().Trim();
                    else 
                        returnValues = returnValues + "," + rows[i]["嘱托内容"].ToString().Trim();
                }
                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("" + err.Message);
            }
        }

        private void txtdm_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Down)
                {
                    int i = dataGridView1.Rows.GetNextRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
                    dataGridView1.CurrentCell = dataGridView1[1, i]; //指针下移
                    dataGridView1.Rows[i].Selected = true; //选中整行

                }
                if (e.KeyData == Keys.Up)
                {
                    txtdm.Select(txtdm.Text.Trim().Length, 0);
                    int i = dataGridView1.Rows.GetPreviousRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
                    dataGridView1.CurrentCell = dataGridView1[1, i]; //指针上移
                    dataGridView1.Rows[i].Selected = true; //选中整行
                }



            }
            catch (System.Exception err)
            {
            }
        }

        private void txtdm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmzt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (dataGridView1.CurrentCell == null) return;
                if (dataGridView1.Rows.Count > 0)
                {
                    bok = true;
                    returnValues = tb.Rows[dataGridView1.CurrentCell.RowIndex]["嘱托内容"].ToString().Trim();
                    this.Close();
                }
                else
                    this.Close();

            }
        }

        private void frmzt_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InputValue))
                txtdm.Text = InputValue;

        }


    }
}