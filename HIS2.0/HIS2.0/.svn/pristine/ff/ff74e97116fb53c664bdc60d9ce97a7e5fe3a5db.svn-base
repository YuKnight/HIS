using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace ts_yj_qf
{
    public class GetInpatientinfo
    {
        public static DataTable GetInpatientInfo_zyh(string zyh)
        {
            DataTable myTb = new DataTable();
            string sSql = "";
            zyh = "00" + zyh;
            sSql = string.Format(@"select  NAME,AGE,SEX_NAME,INPATIENT_NO,CUR_DEPT_NAME,INPATIENT_ID,BABY_ID,flag,BED_NO,YBLX_NAME,BRLX_NAME,JSFS_NAME,DEPT_ID  from  VI_ZY_VINPATIENT_ALL where INPATIENT_NO='{0}' and baby_id=0", zyh);
            try
            {
                myTb = InstanceForm._database.GetDataTable(sSql);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            //返回数据表对象
            return myTb;
        }

    }
}
