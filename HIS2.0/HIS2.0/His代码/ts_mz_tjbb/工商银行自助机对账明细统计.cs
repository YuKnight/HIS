using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using System.IO;
using System.Net;


namespace ts_mz_tjbb
{
    public partial class FrmICBCRecMx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string ksrq;
        private string jsrq;

        public FrmICBCRecMx()
        {
            InitializeComponent();
        }

        public FrmICBCRecMx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;

        }

        public void ICBCMXTJ(string StartTime, string EndTime, Guid tjid)
        {
            try
            {
                ksrq = StartTime;
                jsrq = EndTime;

                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@StartTime";
                parameters[0].Value = Convert.ToDateTime(StartTime).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@EndTime";
                parameters[1].Value = Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "@TJID";
                parameters[2].Value = tjid;

                DataSet ds = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_ZZ_ICBC_TJMX", parameters, ds, "tjmx", 30);
                Fun.AddRowtNo(ds.Tables[0]);
                Fun.AddRowtNo(ds.Tables[1]);
                this.dataGridView1.DataSource = ds.Tables[0];
                this.dataGridView2.DataSource = ds.Tables[1];

                lblyhzs.Text = ds.Tables[0].Rows.Count.ToString();
                lblyhje.Text = ds.Tables[0].Compute("sum(金额)", "").ToString();

                lblyyzs.Text = ds.Tables[1].Rows.Count.ToString();
                lblyyje.Text = ds.Tables[1].Compute("sum(HIS_金额)", "").ToString();


                //lblyhzs.Text = ds.Tables[2].Rows[0]["yhsl"].ToString();
                //lblyhje.Text = ds.Tables[2].Rows[0]["yhje"].ToString();

                //lblyyzs.Text = ds.Tables[3].Rows[0]["yysl"].ToString();
                //lblyyje.Text = ds.Tables[3].Rows[0]["yyje"].ToString();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void excel(DataGridView dgv, string title)
        {

            string swhere = "";

            swhere = "对账日期从:" + ksrq.ToString() + " 到:" + jsrq.ToString();

            //ts_jc_log.ExcelOper.ExportData_ForDataTable(dgv, Constant.HospitalName + label3.Text + title, swhere, true, true, false, false);

            ts_jc_log.ExcelOper.ExportData_ForDataTable(dgv, Constant.HospitalName + label3.Text + title);
        }

        private void tsmt_excel1_Click(object sender, EventArgs e)
        {
            excel(dataGridView1, "(银行端)");
        }

        private void tsmt_excel2_Click(object sender, EventArgs e)
        {
            excel(dataGridView2, "(医院端)");
        }

        private void tsmt_print1_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)dataGridView1.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    dr = dset._工商银行自助机对账明细统计_银行端_.NewRow();
                    int x = i + 1;
                    dr["序号"] = Convert.ToString(tb.Rows[i]["序号"]);
                    dr["卡号"] = Convert.ToString(tb.Rows[i]["卡号"]);
                    dr["金额"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["金额"], "0"));
                    dr["银行流水号"] = Convert.ToString(tb.Rows[i]["银行流水号"]);
                    dr["交易日期"] = Convert.ToString(tb.Rows[i]["交易日期"]);
                    dr["时间"] = Convert.ToString(tb.Rows[i]["时间"]);
                    dr["银行终端"] = Convert.ToString(tb.Rows[i]["银行终端"]);
                    dset._工商银行自助机对账明细统计_银行端_.Rows.Add(dr);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "备注";
                parameters[2].Value = "统计日期:" + ksrq.ToString() + " 到 " + jsrq.ToString();

                parameters[3].Text = "统计人";
                parameters[3].Value = InstanceForm.BCurrentUser.Name;

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset, Constant.ApplicationDirectory + "\\Report\\MZ_工商银行自助机对账明细统计(银行端).rpt", parameters);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmt_print2_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)dataGridView2.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    dr = dset._工商银行自助机对账明细统计_医院端_.NewRow();
                    int x = i + 1;
                    dr["序号"] = Convert.ToString(tb.Rows[i]["序号"]);
                    dr["HIS_卡号"] = Convert.ToString(tb.Rows[i]["HIS_卡号"]);
                    dr["HIS_金额"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["HIS_金额"], "0"));
                    dr["银行流水号"] = Convert.ToString(tb.Rows[i]["银行流水号"]);
                    dr["HIS_交易日期"] = Convert.ToString(tb.Rows[i]["HIS_交易日期"]);
                    dr["HIS_时间"] = Convert.ToString(tb.Rows[i]["HIS_时间"]);
                    dr["银行终端"] = Convert.ToString(tb.Rows[i]["银行终端"]);
                    dset._工商银行自助机对账明细统计_医院端_.Rows.Add(dr);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "备注";
                parameters[2].Value = "统计日期:" + ksrq.ToString() + " 到 " + jsrq.ToString();

                parameters[3].Text = "统计人";
                parameters[3].Value = InstanceForm.BCurrentUser.Name;

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset, Constant.ApplicationDirectory + "\\Report\\MZ_工商银行自助机对账明细统计(医院端).rpt", parameters);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}