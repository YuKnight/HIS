using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmKssDetailMemo : Form
    {
        public FrmKssDetailMemo()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AutoGenerateColumns = false;
        }

        public void DoQuery()
        {
            string strSql = string.Format(@"select id,context,dbo.fun_getEmpName(opr_man) as opr_man,opr_date,delete_bit from jc_kss_yymdMemo where delete_bit=0");

            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);

            dataGridView1.DataSource = dt;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DoQuery();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtXxDemo.Text.Trim()))
                {
                    MessageBox.Show("详细说明不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtXxDemo.Focus();
                    return;
                }

                if (MessageBox.Show("是否进行确认【新增】操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

                string strSql = string.Format(@"insert into jc_kss_yymdMemo(context,opr_man,opr_date,delete_bit)
                                                    values('{0}','{1}','{2}','{3}') ", txtXxDemo.Text, FrmMdiMain.CurrentUser.EmployeeId, DateTime.Now, 0);

                FrmMdiMain.Database.DoCommand(strSql);

                DoQuery();
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    return;
                this.dataGridView1.EndEdit();

                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                string id = dgvr.Cells["id"].Value.ToString();

                if (MessageBox.Show("是否进行【删除】操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

                string ssql = "";

                ssql = string.Format(@"select count(1) as Num from jc_kss_yymdMemo where id='{0}' and delete_bit=0", id);

                int iNum = int.Parse(InstanceForm._database.GetDataResult(ssql).ToString().Trim());

                if (iNum > 0)
                {
                    ssql = string.Format(@"update jc_kss_yymdMemo set delete_bit=1 where id='{0}' and delete_bit=0", id);

                    int iCnt = FrmMdiMain.Database.DoCommand(ssql);

                    if (iCnt <= 0)
                    {
                        MessageBox.Show("操作出错！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                }

                DoQuery();
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmKssDetailMemo_Load(object sender, EventArgs e)
        {
            DoQuery();
        }
    }
}