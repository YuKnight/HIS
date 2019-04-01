using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_zyhs_kqqr
{
    public partial class FrmWclXm : Form
    {
        public string inpatient_id = "";
        public string baby_id = "0";
        public FrmWclXm()
        {
            InitializeComponent(); 
        }

        private void FrmWclXm_Load(object sender, EventArgs e)
        {
            string sql = "SELECT  case when a.mngtype=0 then '长期医嘱' else '临时医嘱' end 医嘱类型  , a.ORDER_BDATE 医嘱日期  ,'药品' 分类,B.ITEM_NAME + ' ' + '【未发药】' 药品名称 ,CONVERT(CHAR,B.NUM) 数量,B.UNIT 单位,CONVERT(CHAR,B.ACVALUE) 金额,DBO.FUN_ZY_SEEKDEPTNAME(B.EXECDEPT_ID) 执行科室,DBO.FUN_ZY_SEEKDEPTNAME(B.DEPT_ID) 开单科室 "
                      + " FROM ZY_FEE_SPECI B  left join ZY_ORDERRECORD a on a.order_id=b.order_id "
                      + " WHERE ( B.STATITEM_CODE IN ('01','02','03') AND B.FY_BIT=0 and CHARGE_BIT=1 AND B.DELETE_BIT=0 AND B.INPATIENT_ID='"+inpatient_id+"'  AND B.BABY_ID="+ baby_id+") ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            this.dataGridView1.DataSource = tb;
            this.dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}