using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
namespace ts_DocGroup
{
    public partial class FrmZffl : Form
    {
        public FrmZffl()
        {
            InitializeComponent();
        }
        private string strID = string.Empty;
        private void FrmZffl_Load(object sender, EventArgs e)
        {
            DataBing();
            this.textBox1.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnDelete.Enabled = false; 
        }

        private void DataBing()
        {
            string strSql = string.Format(@"select ZFFSID AS 编号,ZFFSNAME AS 支付方式名称 FROM JC_ZFFS");
           DataTable dt=  FrmMdiMain.Database.GetDataTable(strSql);
           this.dgvList.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.textBox1.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
           
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnDelete.Enabled = true;
            this.strID = dgvList.Rows[e.RowIndex].Cells["编号"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strSql = string.Format(@"DELETE JC_ZFFS WHERE ZFFSID={0}", strID);
            int i = FrmMdiMain.Database.DoCommand(strSql);
            if (i > 0)
                DataBing();
            this.btnDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请填写支付方式名称");
                this.textBox1.Focus();
                return;
            }
            string strSql = string.Format(@"INSERT INTO JC_ZFFS VALUES('{0}')", this.textBox1.Text);
            int i = FrmMdiMain.Database.DoCommand(strSql);
            if (i > 0)
                DataBing();

            this.btnCancel.Enabled = false;
            this.btnSave.Enabled = false;
            this.textBox1.Enabled = false;
            ClearData();
        }

        private void ClearData()
        {
            this.textBox1.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}