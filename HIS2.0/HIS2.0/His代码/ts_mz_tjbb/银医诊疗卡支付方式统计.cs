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


namespace ts_mz_tjbb
{
    public partial class Frmzlkzffstj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmzlkzffstj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void Frmzlkzffstj_Load(object sender, EventArgs e)
        {
            startTjrq.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            //endTjrq.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            endTjrq.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString());
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@RQ1";
                parameters[0].Value = chkbkrq.Checked == true ? startTjrq.Value.ToShortDateString() + " 00:00:00" : "";

                parameters[1].Text = "@RQ2";
                //parameters[2].Value = chkbkrq.Checked == true ? endTjrq.Value.ToShortDateString() + " 00:00:00" : "";
                parameters[1].Value = chkbkrq.Checked == true ? endTjrq.Value.ToString() : "";

                parameters[2].Text = "@JGBM";
                parameters[2].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_YYZLK_ZFFS", parameters, dset, "zffs", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                this.dataGridView1.DataSource = dset.Tables[0];

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count < 1)
                {
                    return;
                }

                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butprint_pos.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件

                string swhere = "";

                swhere = "收费日期从:" + startTjrq.Value.ToString() + " 到:" + endTjrq.Value.ToString();

                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    SumColCount = SumColCount + 1;
                    myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        ncol = ncol + 1;
                        myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = Constant.HospitalName + label1.Text;
                myExcel.Cells[1, 1] = ss;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3, 1] = swhere.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //让Excel文件可见
                myExcel.Visible = true;
                this.butprint_pos.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butprint_pos.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butprint_pos_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;

            try
            {

                DataTable dtzf = (DataTable)dataGridView1.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= dtzf.Rows.Count - 1; i++)
                {
                    dr = dset.银医支付方式统计.NewRow();
                    int x = i + 1;
                    dr["序号"] = Convert.ToString(dtzf.Rows[i]["序号"]);
                    dr["卡号"] = Convert.ToString(dtzf.Rows[i]["卡号"]);
                    dr["卡类型"] = Convert.ToString(dtzf.Rows[i]["卡类型"]);
                    dr["病人姓名"] = Convert.ToString(dtzf.Rows[i]["病人姓名"]);
                    dr["身份证号"] = Convert.ToString(dtzf.Rows[i]["身份证号"]);
                    dr["预交金"] = Convert.ToDecimal(Convertor.IsNull(dtzf.Rows[i]["预交金"], "0"));
                    dr["现金支付"] = Convert.ToDecimal(Convertor.IsNull(dtzf.Rows[i]["现金支付"], "0"));
                    dr["银联支付"] = Convert.ToDecimal(Convertor.IsNull(dtzf.Rows[i]["银联支付"], "0"));
                    dr["财务记账"] = Convert.ToDecimal(Convertor.IsNull(dtzf.Rows[i]["财务记账"], "0"));
                    dr["医保支付"] = Convert.ToDecimal(Convertor.IsNull(dtzf.Rows[i]["医保支付"], "0"));
                    dset.银医支付方式统计.Rows.Add(dr);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "备注";
                parameters[2].Value = "收费日期:" + startTjrq.Value.ToString() + " 到 " + endTjrq.Value.ToString();

                parameters[3].Text = "统计人";
                parameters[3].Value = InstanceForm.BCurrentUser.Name;

                bool bprint = chkprint.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset, Constant.ApplicationDirectory + "\\Report\\MZ_银医诊疗卡支付方式统计.rpt", parameters, bprint);
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

        private void chkbkrq_CheckedChanged(object sender, EventArgs e)
        {
            startTjrq.Enabled = chkbkrq.Checked == true ? true : false;
            endTjrq.Enabled = chkbkrq.Checked == true ? true : false;
        }
    }
}