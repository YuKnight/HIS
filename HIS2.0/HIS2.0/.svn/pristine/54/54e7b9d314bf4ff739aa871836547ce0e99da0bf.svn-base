using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_mz_rizhi
{
    public partial class FrmPatientWaitingSituation : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public FrmPatientWaitingSituation(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            this.WindowState = FormWindowState.Maximized;

            DateTime datenow = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            DateTime bedate = datenow.AddMonths(-1);
            this.dtBegin.Value = new DateTime(bedate.Year, bedate.Month, bedate.Day, 00, 00, 00);
            this.dtEnd.Value = new DateTime(datenow.Year, datenow.Month, datenow.Day, 23, 59, 59);

            string strSqlks1 = @"select DEPT_ID AS CODE, NAME,PY_CODE as PY ,WB_CODE as WB from  JC_DEPT_PROPERTY  where LAYER=3";
            DataTable dtks1 = InstanceForm.BDatabase.GetDataTable(strSqlks1);
            this.lbt_dept.ShowCardProperty[0].ShowCardDataSource = dtks1;
            lbt_dept.DisplayMember = "NAME";
            lbt_dept.ValueMember = "CODE";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            M_SelData();
        }
        private void M_SelData()
        {
            try
            {
                StringBuilder sbr_sql = new StringBuilder();
                sbr_sql.Append(@"select g.BLH as 门诊号,y.BRXM as 病人姓名, 
convert(varchar,g.GHSJ,120) as 挂号时间, 
convert(varchar,f.FZSJ,120) as 分诊时间,
convert(varchar,j.JSSJ,120) as 接诊时间,
convert(varchar,DATEDIFF(MINUTE,f.FZSJ,j.JSSJ)) as 候诊时长,
(select p.NAME from JC_DEPT_PROPERTY p where p.DEPT_ID= j.JSKSDM) as 就诊科室,
(select e.NAME from JC_EMPLOYEE_PROPERTY e where e.EMPLOYEE_ID=j.JSYSDM) as 医生姓名,
convert(varchar,j.WCSJ,120) as 完成时间
from MZ_GHXX g
inner join MZHS_FZJL f on f.GHXXID=g.GHXXID
inner join MZYS_JZJL j on g.GHXXID=j.GHXXID
inner join YY_BRXX y on g.BRXXID=y.BRXXID where 1=1");
                if (!String.IsNullOrEmpty(tx_mzh.Text))
                {
                    sbr_sql.Append(" and g.blh='");
                    sbr_sql.Append(tx_mzh.Text.Trim());
                    sbr_sql.Append("' ");
                }
                if (!String.IsNullOrEmpty(this.tx_brxm.Text))
                {
                    sbr_sql.Append(" and y.brxm like '%");
                    sbr_sql.Append(tx_brxm.Text.Trim());
                    sbr_sql.Append("%' ");
                }
                if (this.lbt_dept.SelectedValue != null)
                {
                    sbr_sql.Append(" and  j.JSKSDM=");
                    sbr_sql.Append(this.lbt_dept.SelectedValue.ToString());
                }
                string col_name = "";
                switch (this.cmbDtType.Text.Trim())
                {
                    case "挂号时间":
                        col_name = "g.ghsj";
                        break;
                    case "接诊时间":
                        col_name = "j.jssj";
                        break;
                }
                if (col_name != "" && this.dtBegin.Text.Trim() != "" && this.dtEnd.Text.Trim() != "")
                {
                    sbr_sql.Append(string.Format(" and {0} >= '{1}'  and  {0} < '{2}'", col_name, this.dtBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtEnd.Value.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss")));
                }
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sbr_sql.ToString());

                int hour = 0;
                int minute = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr["候诊时长"] == null)
                        continue;
                    int sc = Int32.Parse(dr["候诊时长"].ToString());
                    if (sc >= 60)
                    {
                        hour = sc / 60;
                        minute = sc % 60;
                        dr["候诊时长"] = hour.ToString() + "小时";
                        if (minute > 0)
                            dr["候诊时长"] += minute.ToString() + "分钟";
                    }
                    else
                    {
                        dr["候诊时长"] = sc + "分钟";
                    }
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tx_mzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                M_SelData();
            }
        }

        private void tx_brxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                M_SelData();
            }
        }

        private void lbt_dept_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                M_SelData();
            }
        }
    }
}