using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using PatientCaseCase;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.DatabaseAccess;
using System.Data.SqlClient;
namespace ts_zyhs_basydy
{
    public partial class FrmBlsydy : Form
    {
        public FrmBlsydy()
        {
            InitializeComponent();
        }

        private void FrmBlsydy_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DateTime Date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(-7);
            DateTime Date_1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dateTimePicker1.Value = Date;
            this.dateTimePicker2.Value = Date_1;
            BingData();
        }

        private void BingData()
        {
            string sdate = this.dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00");
            string edate = this.dateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59");
            string sSql = @" SELECT '0' AS SELECTED ,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,flag " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and flag in (2,4,5,6) " +
                        "  and (out_Date>='" + sdate + "'and out_Date<= '" + edate + "') ORDER BY out_Date desc,BED_NO asc";
            DataTable dt = InstanceForm.BDatabase.GetDataTable(sSql);
            this.dataGridView1.DataSource = dt;
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
        private FrmNavigation frmNavigation = null;
        private void button2_Click(object sender, EventArgs e)
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
            Cursor = Cursors.WaitCursor;
            try
            {
                string s = @"select * from ZY_INPATIENT where INPATIENT_ID='" + newdt1.Rows[0]["INPATIENT_ID"].ToString() + "'";
                DataRow dr = FrmMdiMain.Database.GetDataRow(s);
                bool cyflag = false;
                string balubinid = "";
                string balubinno = "";
                int baluzycs = 0;
                if (frmNavigation == null)
                    frmNavigation = new PatientCaseCase.FrmNavigation("his");
                if (dr != null && frmNavigation != null)// && Convert.ToInt32(dr["FLAG"].ToString()) == 4 先去掉判断
                {
                    if (new SystemCfg(6098).Config == "1")
                    {
                        cyflag = true;
                        balubinid = dr["INPATIENT_ID"].ToString();
                        baluzycs = Convert.ToInt32(dr["INTIMES"] == null ? "0" : dr["INTIMES"].ToString());
                        balubinno = dr["INPATIENT_no"].ToString();
                    }
                    //同步病案信息
                    if (cyflag && new SystemCfg(6098).Config == "1" && balubinid != "" && baluzycs > 0 && balubinno != "")
                    {
                        
                        InstanceForm.BDatabase.DoCommand("sp_Emrsylr_zy '" + balubinid + "'," + baluzycs + ",'" + balubinno + "'");
                        //yaokx 2014-06-21 医生定义出院，是否调用病历首页录入数据,先初始化窗体，现在调用窗体
                        if (frmNavigation != null && getConnBA(balubinid, baluzycs))
                        {
                            
                            frmNavigation.AddPatientFromHIS(balubinno, baluzycs, balubinid);
                             
                        }
                    }

                    // frmNavigation.AddPatientFromHIS(dr["INPATIENT_NO"].ToString(), Convert.ToInt32(dr["INTIMES"].ToString()), dr["INPATIENT_ID"].ToString());
                }
            }
            catch(Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally { Cursor = Cursors.Default; }
        }
        //yaokx 2014-0621 填充病案录入窗体
        private bool getConnBA(string inpid, int count)
        {
            SqlConnection sqlcnn = null;

            try
            {
                string clientConfigFile = Constant.ApplicationDirectory + "\\PatientConfig\\ClientConfig.ini";
                string HOSTNAME = Crypto.Instance().Decrypto(TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SQLSERVER", "HOSTNAME", clientConfigFile));//("SQLSERVER3", "NAME", clientConfigFile);
                string DATASOURCE = Crypto.Instance().Decrypto(TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SQLSERVER", "DATASOURCE", clientConfigFile));//("SQLSERVER3", "NAME", clientConfigFile);
                string USER_ID = Crypto.Instance().Decrypto(TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SQLSERVER", "USER_ID", clientConfigFile));//("SQLSERVER3", "NAME", clientConfigFile);
                string PASSWORD = Crypto.Instance().Decrypto(TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SQLSERVER", "PASSWORD", clientConfigFile));//("SQLSERVER3", "NAME", clientConfigFile);
                if (HOSTNAME == "" || DATASOURCE == "" || USER_ID == "")
                {
                    System.Windows.Forms.MessageBox.Show("ClientConfig.ini没有设置连接病案首页数据库请配置", "错误");
                    return false;
                }
                string connectionString = "packet size=4096;user id=" + USER_ID + ";password=" + PASSWORD + ";data source=" + HOSTNAME + ";persist security info=True;initial catalog=" + DATASOURCE + "";
                sqlcnn = new SqlConnection(connectionString);
                sqlcnn.Open();
                SqlCommand sqlcmm = new SqlCommand();
                sqlcmm.Connection = sqlcnn;
                sqlcmm.CommandText = "select * from pat_interface where id='" + inpid + "'and visit_id=" + count + "";

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt == null)
                {
                    return false;
                }
                if (dt.Rows.Count <= 0)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                sqlcnn.Close();
            }
            return true;
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
    }
}