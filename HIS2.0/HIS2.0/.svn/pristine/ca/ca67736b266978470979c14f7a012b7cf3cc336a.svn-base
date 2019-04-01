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
    public partial class FrmDocGroupList : Form
    {
        public FrmDocGroupList()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            BingGroupList();
        }

        private void BingGroupList()
        {
            string strSql = string.Format(@"SELECT * FROM TS_GROUPMANAGE ");
            if (!string.IsNullOrEmpty(this.txtGroupName.Text))
                strSql += string.Format(" where GroupName like '{0}'", this.txtGroupName.Text);
            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql.ToString());
            this.dgvGroupList.DataSource = dt;
        }
        private void dgvGroupList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvGroupList.Rows)
            {
                if (row.Index != e.RowIndex)
                    row.Cells["clSelect"].Value = 0;
            }
            if (this.dgvGroupList.Rows[e.RowIndex].Cells["clSelect"].Value == null) this.dgvGroupList.Rows[e.RowIndex].Cells["clSelect"].Value = "1";

            if (this.dgvGroupList.Rows[e.RowIndex].Cells["clSelect"].Value.ToString() == "0")
                this.dgvGroupList.Rows[e.RowIndex].Cells["clSelect"].Value = "1";
            else
                this.dgvGroupList.Rows[e.RowIndex].Cells["clSelect"].Value = "0";
            string id = string.Empty;
            string strGroupName = string.Empty;
            string strSql = string.Format(@"SELECT  c.NAME AS DocName ,
                                                                        c.PY_CODE,
                                                                        c.WB_CODE
                                                           FROM    TS_DOCGROUPMANAGE a
                                                                        INNER JOIN dbo.JC_ROLE_DOCTOR b ON a.DocId = b.EMPLOYEE_ID
                                                                        INNER JOIN dbo.JC_EMPLOYEE_PROPERTY c ON b.EMPLOYEE_ID = c.EMPLOYEE_ID  
                                                          WHERE   a.GroupID ={0}", this.dgvGroupList.Rows[e.RowIndex].Cells["clID"].Value
);
            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql.ToString());
            this.dgvDocList.DataSource = dt;
        }


        private void FrmDocGroupList_Load(object sender, EventArgs e)
        {
            BingGroupList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = string.Empty;
            string strGroupName = string.Empty;
            foreach (DataGridViewRow row in this.dgvGroupList.Rows)
            {
                if (row.Cells["clSelect"].Value.ToString() == "1")
                {
                    id = row.Cells["clID"].Value.ToString();
                    strGroupName = row.Cells["clGroupName"].Value.ToString();
                }
            }
            if (string.IsNullOrEmpty(id)) return;
            FrmDocGroupListModify frmAction = new FrmDocGroupListModify(id, this, strGroupName);
            frmAction.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmDocGroupListModify frmAction = new FrmDocGroupListModify();
            frmAction.ShowDialog();

        }

    }
}