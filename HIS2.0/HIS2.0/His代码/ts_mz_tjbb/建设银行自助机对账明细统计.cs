using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using ts_mz_class;
using System.IO;
using System.Net;

namespace ts_mz_tjbb
{
    public partial class FrmCCBRecMx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string bDateTime;
        private string eDateTime;
        //单元常量
        RelationalDatabase db = new MsSqlServer();
        private string fHospitalName;//医院名称
        private string fOperName;//操作员名
        private string fApplicationDir; //程序名

        public FrmCCBRecMx()
        {
            InitializeComponent();
        }

        public FrmCCBRecMx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;

            db = InstanceForm.BDatabase;
            fHospitalName = TrasenFrame.Classes.Constant.HospitalName;
            fOperName = InstanceForm.BCurrentUser.Name;
            fApplicationDir = Constant.ApplicationDirectory;
        }

        public FrmCCBRecMx(RelationalDatabase adb)
        {
            InitializeComponent();
            db = adb;
            fHospitalName = "";//直接传入db（调试模式），直接赋空。
            fOperName = "";
            fApplicationDir = @"D:\TS-HIS";
        }

        private void tsmt_excel1_Click(object sender, EventArgs e)
        {
            string swhere = "";

            swhere = "对账日期从:" + bDateTime.ToString() + " 到:" + eDateTime.ToString();
            ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + label3.Text + "(银行端)");
        }

        private void tsmt_excel2_Click(object sender, EventArgs e)
        {
            string swhere = "";

            swhere = "对账日期从:" + bDateTime.ToString() + " 到:" + eDateTime.ToString();
            ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + label3.Text + "(医院端)");
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CcbMxTj(string startTime, string endTime, Guid tjId)
        {
            try
            {
                bDateTime = startTime;
                eDateTime = endTime;

                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@StartTime";
                parameters[0].Value = Convert.ToDateTime(startTime).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@EndTime";
                parameters[1].Value = Convert.ToDateTime(endTime).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "@TJID";
                parameters[2].Value = tjId;

                DataSet ds = new DataSet();
                db.AdapterFillDataSet("SP_ZZ_CCB_TJMX", parameters, ds, "tjmx", 30);
                Fun.AddRowtNo(ds.Tables[0]);
                Fun.AddRowtNo(ds.Tables[1]);
                this.dataGridView1.DataSource = ds.Tables[0];
                this.dataGridView2.DataSource = ds.Tables[1];

                lblyhzs.Text = ds.Tables[0].Rows.Count.ToString();
                lblyhje.Text = ds.Tables[0].Compute("SUM(银行交易金额)", "").ToString();

                lblyyzs.Text = ds.Tables[1].Rows.Count.ToString();
                lblyyje.Text = ds.Tables[1].Compute("SUM(医院交易金额)", "").ToString();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //银行端打印
        private void tsmt_print1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    dr = dset._建行自助机对账明细统计_银行端_.NewRow();
                    int x = i + 1;
                    dr["序号"] = Convert.ToString(tb.Rows[i]["序号"]);
                    dr["银行交易代码"] = Convert.ToString(tb.Rows[i]["银行交易代码"]);
                    dr["银行交易日期"] = Convert.ToString(tb.Rows[i]["银行交易日期"]);
                    dr["银行交易金额"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["银行交易金额"], "0"));
                    dr["银行手续费"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["银行手续费"], "0"));
                    dr["银行商户号"] = Convert.ToString(tb.Rows[i]["银行商户号"]);
                    dr["银行设备编号"] = Convert.ToString(tb.Rows[i]["银行设备编号"]);
                    dr["银行设备流水号"] = Convert.ToString(tb.Rows[i]["银行设备流水号"]);
                    dset._建行自助机对账明细统计_银行端_.Rows.Add(dr);
                }
                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = fHospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(db).ToShortDateString();
                parameters[2].Text = "备注";
                parameters[2].Value = "统计日期:" + bDateTime.ToString() + " 到 " + eDateTime.ToString();

                parameters[3].Text = "统计人";
                parameters[3].Value = fOperName;

                string strReportDir = fApplicationDir + "\\Report\\MZ_建设银行自助机对账明细统计（银行端）.rpt";
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset._建行自助机对账明细统计_银行端_, strReportDir, parameters);
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
        //医院端打印
        private void tsmt_print2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView2.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    dr = dset._建行自助机对账明细统计_医院端_.NewRow();
                    int x = i + 1;
                    dr["序号"] = Convert.ToString(tb.Rows[i]["序号"]);
                    dr["医院交易代码"] = Convert.ToString(tb.Rows[i]["医院交易代码"]);
                    dr["医院交易日期"] = Convert.ToString(tb.Rows[i]["医院交易日期"]);
                    dr["医院交易金额"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["医院交易金额"], "0"));
                    dr["医院手续费"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["医院手续费"], "0"));
                    dr["平台流水号"] = Convert.ToString(tb.Rows[i]["平台流水号"]);
                    dr["自助终端号"] = Convert.ToString(tb.Rows[i]["自助终端号"]);
                    dset._建行自助机对账明细统计_医院端_.Rows.Add(dr);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = fHospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(db).ToShortDateString();
                parameters[2].Text = "备注";
                parameters[2].Value = "统计日期:" + bDateTime.ToString() + " 到 " + eDateTime.ToString();

                parameters[3].Text = "统计人";
                parameters[3].Value = fOperName;

                string strReportDir = fApplicationDir + "\\Report\\MZ_建设银行自助机对账明细统计（医院端）.rpt";
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset._建行自助机对账明细统计_医院端_, strReportDir, parameters);
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



