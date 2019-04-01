using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TszyHIS;

namespace ts_zyhs_basydy
{
    public partial class FrmBlsycx : Form
    {
        public FrmBlsycx()
        {
            InitializeComponent();
        }

        string zyh = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DateTime Date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(-7);
            DateTime Date_1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dateTimePicker1.Value = Date;
            this.dateTimePicker2.Value = Date_1;


            txtinpatientNo.InpatientNoLength = Convert.ToInt32(new SystemCfg(5026).Config);
            txtinpatientNo.Text = InpatientNo.GetEmptyZyh();
            zyh = InpatientNo.GetEmptyZyh();

            string sql = "";
            DataTable tbWard = new DataTable();
            sql = "select * from jc_ward where jgbm=" + FrmMdiMain.Jgbm + " order by ward_id";
            tbWard = FrmMdiMain.Database.GetDataTable(sql);
            DataRow dr = tbWard.NewRow();
            dr["ward_id"] = "-1";
            dr["ward_name"] = "全部";
            tbWard.Rows.Add(dr);
            cmbWard.ValueMember = "ward_id";
            cmbWard.DisplayMember = "ward_name";
            cmbWard.DataSource = tbWard;
            cmbWard.SelectedValue = "-1";

            BingData();
        }

        private void BingData()
        {
            string sdate = this.dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00");
            string edate = this.dateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59");
            string sSql = "";
            if (txtinpatientNo.Text == zyh)
            {
                 sSql = @" SELECT '0' AS SELECTED ,BED_NO AS 床号,INPATIENT_NO AS  住院号,NAME AS 姓名,WARD_NAME AS 病区,INPATIENT_ID,OUT_DATE as 出院时间" +
                        ",CASE FLAG WHEN 1 THEN '在院病人' WHEN 2 THEN '欠费病人' WHEN 3 THEN '在床病人' WHEN 4 THEN '定义出院没出区病人' WHEN 5 THEN '已经出区病人' WHEN 6 THEN '正常出院病人' ELSE '其他' END AS 病人状态" +
                           "   FROM vi_zy_vInpatient_All " +
                           "  WHERE (WARD_ID= '" + cmbWard.SelectedValue.ToString() + "' or -1 = '" + cmbWard.SelectedValue.ToString() + "' ) and flag in (2,4,5,6) " +
                           "  and (out_Date>='" + sdate + "'and out_Date<= '" + edate + "') ORDER BY out_Date desc,BED_NO asc";
            }
            else
            {
                sSql = @" SELECT '0' AS SELECTED ,BED_NO AS 床号,INPATIENT_NO AS  住院号,NAME AS 姓名,WARD_NAME AS 病区,INPATIENT_ID ,OUT_DATE as 出院时间" +
                              ",CASE FLAG WHEN 1 THEN '在院病人' WHEN 2 THEN '欠费病人' WHEN 3 THEN '在床病人' WHEN 4 THEN '定义出院没出区病人' WHEN 5 THEN '已经出区病人' WHEN 6 THEN '正常出院病人' ELSE '其他' END AS 病人状态" +
                              "   FROM vi_zy_vInpatient_All " +
                              "  WHERE INPATIENT_NO ='" + txtinpatientNo.Text + "'  and flag in (2,4,5,6) " +
                              "  and (out_Date>='" + sdate + "'and out_Date<= '" + edate + "') ORDER BY out_Date desc,BED_NO asc";
            }

           
            DataTable dt = InstanceForm.BDatabase.GetDataTable(sSql);

            if (dt.Rows.Count<1)
            {
                MessageBox.Show("没有查询到病人，该病人还在床！");
            }
            this.dataGridView1.DataSource = dt;
        }

        private void cmbWard_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            txtinpatientNo.Text = InpatientNo.GetEmptyZyh();

        }

    
        private void txtinpatientNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            
            cmbWard.SelectedValue = "-1";

            if (e.KeyChar == 13)
            {
                BingData();
            }
        }

        private void buttSerach_Click(object sender, EventArgs e)
        {
            BingData();
        }

        private void buttprit_Click(object sender, EventArgs e)
        {
            DataTable dt_old1 = (DataTable)dataGridView1.DataSource;
            DataTable newdt1 = new DataTable();
            newdt1 = dt_old1.Clone();
            DataRow[] dr1 = dt_old1.Select("SELECTED=1");
            for (int ii = 0; ii < dr1.Length; ii++)
            {
                newdt1.ImportRow((DataRow)dr1[ii]);
            }
            if (newdt1.Rows.Count > 1)
            {
                MessageBox.Show("病人信息只能打勾一条");
                return;
            }
            if (newdt1.Rows.Count == 1)
            {
                this.Cursor = Cursors.WaitCursor;
                #region  初始化录入病历首页
                PatientCaseCase.FrmNavigation frmNavigation = new PatientCaseCase.FrmNavigation(InstanceForm.BCurrentUser.Name);
                frmNavigation.Print(newdt1.Rows[0]["INPATIENT_ID"].ToString());
                this.Cursor = Cursors.Arrow;
                #endregion
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt_old1 = (DataTable)dataGridView1.DataSource;
            DataTable newdt1 = new DataTable();
            newdt1 = dt_old1.Clone();
            DataRow[] dr1 = dt_old1.Select("SELECTED=1");
            for (int ii = 0; ii < dr1.Length; ii++)
            {
                newdt1.ImportRow((DataRow)dr1[ii]);
            }
            if (newdt1.Rows.Count > 1)
            {
                MessageBox.Show("病人信息只能打勾一条");
                return;
            }
            if (newdt1.Rows.Count == 1)
            {
                this.Cursor = Cursors.WaitCursor;
                #region  初始化录入病历首页
                // PatientCaseCase.FrmNavigation frmNavigation = new PatientCaseCase.FrmNavigation(InstanceForm.BCurrentUser.Name);
                // frmNavigation.Print(newdt1.Rows[0]["INPATIENT_ID"].ToString());
                tb(newdt1.Rows[0]["INPATIENT_ID"].ToString());
                this.Cursor = Cursors.Arrow;
                #endregion
            }
        }


        private void tb(string inpatient_id)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = inpatient_id;
            parameters[0].Text = "@INPATIENT_ID";
            parameters[1].Value = "1";
            parameters[1].Text = "@flag";

            try
            {
                DataTable tb = InstanceForm.BDatabase.GetDataTable("sp_EmrSynchroFeeToBa", parameters, 60);
                if (tb.Rows.Count > 0)
                {
                    MessageBox.Show(tb.Rows[0][0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkcell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                checkcell.Value = 0;
            }
            DataGridViewCheckBoxCell ifcheck = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
            ifcheck.Value = 1; 
        }

      

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        int i = e.RowIndex;
        //        if (dataGridView1.Rows[i].Cells["SELECTED"].Value.ToString() == "1")
        //            for (int x = 0; x <= dataGridView1.Rows.Count; x++)
        //            {
        //                if (x != i)
        //                    dataGridView1.Rows[i].Cells["SELECTED"].Value = 0;

        //            }
        //    }
        //}

        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        int i = e.RowIndex;
        //        if (dataGridView1.Rows[i].Cells["SELECTED"].Value.ToString() == "True")
        //            for (int x = 0; x <= dataGridView1.Rows.Count; x++)
        //            {
        //                if(x!=i)
        //                dataGridView1.Rows[i].Cells["SELECTED"].Value = 0;

        //            }
        //    }
        //}



    }
}
