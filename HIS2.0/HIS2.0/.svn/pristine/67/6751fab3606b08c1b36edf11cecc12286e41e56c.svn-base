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
    public partial class FrmOrderItemMzks : Form
    {
        bool isFirst = true;
        public FrmOrderItemMzks()
        {
            InitializeComponent();
            dgvOrderItemList.AutoGenerateColumns = false;
            dgvDeptList.AutoGenerateColumns = false;

        }

        private void InitPage()
        {
            string strSql = string.Format(@"SELECT 0 as CODE ,'' as NAME
                                                            UNION ALL
                                                            SELECT CODE,NAME FROM jc_ordertype");
            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
            cmbOrderType.Items.Clear();
            cmbOrderType.DataSource = dt;
            cmbOrderType.DisplayMember = "NAME";
            cmbOrderType.ValueMember = "CODE";
            cmbOrderType.SelectedIndex = 0;

            cmbState.Items.Add("   ");
            cmbState.Items.Add("已维护");
            cmbState.Items.Add("未维护");
            cmbOrderType.SelectedIndex = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.dgvOrderItemList.DataSource = GetOrderMzDeptData();
        }

        private DataTable GetOrderData(int orderid)
        {
            DataTable dt = new DataTable();
            string strSql = string.Format(@"SELECT (SELECT ORDER_NAME FROM jc_hoitemdiction WHERE ORDER_ID=a.order_id) AS ORDER_NAME,
                                                                dbo.fun_getDeptname(a.deptid) AS deptname,
                                                                dbo.fun_getEmpName(a.czr) AS czr,
                                                                czsj
                                                                 FROM jc_yj_orderitem_dept a WHERE bscbz=0 and ORDER_ID={0} ", orderid);
            dt = FrmMdiMain.Database.GetDataTable(strSql);
            return dt;
        }

        private DataTable GetOrderMzDeptData()
        {
            DataTable dt = new DataTable();

            string strSql = string.Format(@"SELECT DISTINCT * , dbo.fun_OrderItemdept(a.order_id) as deptnameall FROM 
                                                                ( 
                                                                select  order_id,order_name,bz,py_code,wb_code,order_unit,      
                                                                dbo.fun_getDeptname(default_dept) as exec_dept_name,b.code,b.name as order_type,      
                                                                default_usage,a.delete_bit,c.std_code,c.item_id,c.item_name,convert(decimal(8,2),c.price ) as price,c.num,convert(decimal(8,2),c.price*c.num,2) as total      
                                                                from jc_hoitemdiction a       
                                                                left join jc_ordertype b on a.order_type=b.code      
                                                                left join       
                                                                (select a.hoitem_id,b.item_id,b.item_name,std_code,price,a.num,b.DELETE_BIT from jc_hoi_hdi a       
                                                                left join       
                                                                (      
                                                                select aa.item_id,item_name,bb.price,1 as tc_flag ,'' as std_code,bb.DELETE_BIT      
                                                                from jc_tc_t aa       
                                                                inner join       
                                                                (      
                                                                select a.mainitem_id,sum(a.num*b.retail_price ) as price , b.DELETE_BIT    
                                                                from jc_tc_mx a       
                                                                left join jc_hsitem b on a.subitem_id=b.item_id     
                                                                group by mainitem_id,b.DELETE_BIT      
                                                                ) bb on aa.item_id=bb.mainitem_id     
                                                                union all       
                                                                select item_id,item_name ,retail_price as price,0 as tc_flag ,std_code,DELETE_BIT        
                                                                from jc_hsitem      
                                                                ) b on a.hditem_id=b.item_id and a.tc_flag = b.tc_flag      
                                                                ) c on a.order_id=c.hoitem_id and c.DELETE_BIT=0    
                                                                ) a WHERE a.DELETE_BIT =0");
            if (!string.IsNullOrEmpty(cmbOrderType.Text))
                strSql += " and order_type ='" + cmbOrderType.Text + "'";
            if (!string.IsNullOrEmpty(txtOrderName.Text))
                strSql += " AND  order_name LIKE '%" + txtOrderName.Text.Trim() + "%' OR py_code LIKE '%" + txtOrderName.Text.Trim() + "%' OR wb_code LIKE '%" + txtOrderName.Text.Trim() + "%' ";
            if (!string.IsNullOrEmpty(cmbState.Text.Trim()))
            {
                if (cmbState.Text.Trim() == "已维护")
                    strSql += " and dbo.fun_OrderItemdept(a.order_id) !=''";
                else
                    strSql += " and dbo.fun_OrderItemdept(a.order_id) =''";
            }
            dt = FrmMdiMain.Database.GetDataTable(strSql);
            return dt;
        }

        private void dgvOrderItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ts_yj_jcwhModify frmAction = new ts_yj_jcwhModify(Convert.ToInt32(dgvOrderItemList.Rows[e.RowIndex].Cells["clorderid"].Value));
                frmAction.Show();
            }
        }

        private void dgvOrderItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int orderid = Convert.ToInt32(dgvOrderItemList.Rows[e.RowIndex].Cells["clorderid"].Value);

                this.dgvDeptList.DataSource = GetOrderData(orderid);
            }
        }

        private void FrmOrderItemMzks_Load(object sender, EventArgs e)
        {
            InitPage(); 
        }

        private void cmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.dgvOrderItemList.DataSource = GetOrderMzDeptData();
        }

        private void txtOrderName_TextChanged(object sender, EventArgs e)
        {

            this.dgvOrderItemList.DataSource = GetOrderMzDeptData();
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvOrderItemList.DataSource = GetOrderMzDeptData();
        }
    }
}