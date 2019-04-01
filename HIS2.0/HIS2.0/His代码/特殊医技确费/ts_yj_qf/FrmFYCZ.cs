using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralControls;
using ts_zyhs_classes;


namespace ts_yj_qf
{
    public partial class FrmFYCZ : Form
    {
        public string orderid;
        public FrmFYCZ()
        {
            InitializeComponent();
        }

        private void getfycz(string order_id,DataGridView dv)
        {
            DataTable dt = new DataTable();
            string sql = string.Format(@"select  CZ_FLAG,CZ_ID,ORDER_ID,ID,ITEM_NAME,RETAIL_PRICE,NUM,CHARGE_DATE, dbo.fun_getEmpName(CHARGE_USER) as CHARGE_USER    from  ZY_FEE_SPECI where  order_id='{0}' union all select CZ_FLAG,CZ_ID,ORDER_ID,ID,ITEM_NAME,RETAIL_PRICE,NUM,CHARGE_DATE,dbo.fun_getEmpName(CHARGE_USER) as CHARGE_USER  from  ZY_FEE_SPECI_H  where  order_id='{0}'", order_id);
            dt = InstanceForm._database.GetDataTable(sql);
            dv.DataSource = dt;

        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            getfycz(orderid,dv_fyxx);
        }


    
    }
}