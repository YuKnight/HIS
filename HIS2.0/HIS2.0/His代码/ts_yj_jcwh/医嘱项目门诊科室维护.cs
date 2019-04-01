using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_yj_jcwh
{
    public partial class ts_yj_jcwhModify : Form
    {
        private int  orderid;
        public ts_yj_jcwhModify()
        {
            InitializeComponent();
           
        }

        public ts_yj_jcwhModify(int _orderid)
        {
            InitializeComponent();
            orderid = _orderid;
            this.dgvList.AutoGenerateColumns = false;
        }

        private void txtDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string sqlYS = @"select DEPT_ID AS ID,NAME,PY_CODE,WB_CODE from JC_DEPT_PROPERTY where   P_DEPT_ID!=0 and DELETED=0";
                DataTable dtYLFL = FrmMdiMain.Database.GetDataTable(sqlYS);
                if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
                {
                    txtDeptName.Text = "";
                    txtDeptName.Tag = "";
                    return;
                }

                Control control = (Control)sender;
                if ((int)e.KeyChar != 13)
                {
                    string[] headtext = new string[] { "编号", "科室名称", "拼音码", "五笔码" };
                    string[] mappingname = new string[] { "ID", "NAME", "PY_CODE", "WB_CODE" };
                    string[] searchfields = new string[] { "PY_CODE", "WB_CODE" };
                    int[] colwidth = new int[] { 0, 200, 80, 70 };
                    TrasenFrame.Forms.FrmSelectCard f = new TrasenFrame.Forms.FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                    f.sourceDataTable = dtYLFL;
                    f.WorkForm = this;
                    f.srcControl = txtDeptName;
                    f.Font = txtDeptName.Font;
                    f.Width = 350;
                    f.ReciveString = e.KeyChar.ToString();
                    e.Handled = true;
                    if (f.ShowDialog() == DialogResult.Cancel)
                    {
                        txtDeptName.Focus();
                        return;
                    }
                    else
                    {
                        txtDeptName.Text = f.SelectDataRow["NAME"].ToString().Trim();
                        txtDeptName.Tag = f.SelectDataRow["ID"].ToString();
                        e.Handled = true;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtDeptName.Text))
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch { txtDeptName.Focus(); }
        }

        private void ts_yj_jcwhModify_Load(object sender, EventArgs e)
        {
            this.dgvList.DataSource = GetOrderData(orderid);
        } 

        private DataTable GetOrderData(int orderid)
        {
            DataTable dt = new DataTable();
            string strSql = string.Format(@"SELECT (SELECT ORDER_NAME FROM jc_hoitemdiction WHERE ORDER_ID=a.order_id) AS ORDER_NAME,
a.deptid,                                                                
dbo.fun_getDeptname(a.deptid) AS deptname,
                                                                dbo.fun_getEmpName(a.czr) AS czr,
                                                                czsj,'删除' as 删除
                                                                 FROM jc_yj_orderitem_dept a WHERE bscbz=0 and ORDER_ID={0} ", orderid);
            dt = FrmMdiMain.Database.GetDataTable(strSql);
            return dt;
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgvList.Columns[dgvList.CurrentCell.ColumnIndex].Name.Trim() == "clsc")
                {
                    if (MessageBox.Show("确认删除？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Delete(Convert.ToInt32(orderid), Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["cldeptid"].Value)))
                        {
                            MessageBox.Show("删除成功", "提示");
                            this.txtDeptName.Focus();
                            this.dgvList.DataSource = GetOrderData(orderid);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("删除失败", "提示");
                            return;
                        }

                    }
                }
            }
        }

        private bool Delete(int orderid,int deptid)
        {
            int i = FrmMdiMain.Database.DoCommand("delete jc_yj_orderitem_dept where order_id=" + orderid + " and deptid=" + deptid);
           if (i > 0)
               return true;
           else
               return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string strSql = string.Format(@"INSERT INTO jc_yj_orderitem_dept 
            (
            id,order_id,deptid,bscbz,czsj,czr,usetype
            )
            VALUES( (SELECT ISNULL(MAX(id ),0)+1 FROM jc_yj_orderitem_dept WHERE usetype=1 ),{0},{1},0,getdate(),{2},1 ) 
            ", orderid, Convert.ToInt16(this.txtDeptName.Tag),FrmMdiMain.CurrentUser.EmployeeId);
            int i = FrmMdiMain.Database.DoCommand(strSql);
            if (i > 0)
            {
                this.dgvList.DataSource = GetOrderData(orderid);
                this.txtDeptName.Tag = "";
                this.txtDeptName.Text = "";
                this.txtDeptName.Focus();
            }
        }
    }
}