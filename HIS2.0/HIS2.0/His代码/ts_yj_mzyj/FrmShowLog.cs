using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_yj_mzyj
{
    public partial class FrmShowLog : Form
    {
        private string cfid ;
        private string cfmxid;
        private int tcid;

        public FrmShowLog()
        {
            InitializeComponent();
        }

        public FrmShowLog(string _cfid,string _cfmxid,int _tcid)
        {
            InitializeComponent();
            cfid = _cfid;
            cfmxid = _cfmxid;
            tcid = _tcid;
        }

        private void BingData()
        {
            string strSql = string.Format(@"SELECT CASE WHEN CZLX=1 THEN '确认' ELSE '取消确认' END 操作类型,
                                    dbo.fun_getEmpName(CZR) 操作人,CZSJ 操作时间
                                     FROM dbo.YJ_MZSQ_LOG  
                                    WHERE CFID='{0}' AND   
                                    (  
                                      ( '{1}'=dbo.FUN_GETEMPTYGUID() and tcid={2} )     
                                      or    
                                         cfmxid='{3}'    
                                    ) order by CZSJ desc  ", cfid, cfmxid, tcid, cfmxid);
          DataTable dt =   InstanceForm.BDatabase.GetDataTable( strSql);
          this.dgvList.DataSource = dt;
        }

        private void FrmShowLog_Load(object sender, EventArgs e)
        {
            BingData();
        }
    }
}