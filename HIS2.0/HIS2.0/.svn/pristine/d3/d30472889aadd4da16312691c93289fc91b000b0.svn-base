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
    public partial class FrmDocGroup : Form
    {
        public FrmDocGroup()
        {
            InitializeComponent();
        }

        private void FrmDocGroup_Load(object sender, EventArgs e)
        {
            GetData(); 
        }

        public void  GetData()
        {  
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from TS_GROUPMANAGE where 1=1");
            if (!string.IsNullOrEmpty(txtDocGroup.Text))
                strSql.AppendFormat(" and GroupName like '{0}'", this.txtDocGroup.Text);
            DataTable dt= FrmMdiMain.Database.GetDataTable(strSql.ToString());
            if (dt != null) this.dgvList.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmDocGoupMidify frmAction = new FrmDocGoupMidify();
            frmAction.ShowDialog();
            if (this.DialogResult == DialogResult.OK)
            {
                GetData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("您真的要删除吗？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string id = string.Empty;
                    foreach (DataGridViewRow row in this.dgvList.Rows)
                     {
                         if (row.Cells["clSelect"].Value.ToString() == "1")
                         {
                             id = row.Cells["clID"].Value.ToString();
                         }
                     }
                     string strSql = string.Format(@"DELETE TS_GROUPMANAGE WHERE GroupID={0}", id);
                    FrmMdiMain.Database.DoCommand(strSql.ToString());
                    GetData();
                }
            }
            catch
            {
                MessageBox.Show("删除失败");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = string.Empty;
            foreach (DataGridViewRow row in this.dgvList.Rows)
            {
                if (row.Cells["clSelect"].Value.ToString() == "1")
                {
                    id = row.Cells["clID"].Value.ToString();
                }
            }
            FrmDocGoupMidify frmAction = new FrmDocGoupMidify(id,this);
            frmAction.ShowDialog();
           
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvList.Rows)
            {
                if (row.Index != e.RowIndex)
                    row.Cells["clSelect"].Value = 0;
            }
            if (this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value == null) this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value = "1";

            if (this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value.ToString() == "0")
                this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value = "1";
            else
                this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value = "0";
        }
      
    }
}