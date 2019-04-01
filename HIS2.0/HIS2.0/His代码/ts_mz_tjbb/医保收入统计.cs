using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_mz_tjbb
{
    /// <summary>
    /// 门诊科室收入统计
    /// </summary>
    public partial class FrmYbsrtj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmYbsrtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            this.Text = chineseName;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            dtp1.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 0:00:00"));
            this.WindowState = FormWindowState.Maximized;
        }

        // 统计
        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtp1.Value > dtp2.Value)
                {
                    MessageBox.Show("开始日期不能大于结束日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@KSRQ";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@JSRQ";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@KSDM";
                parameters[2].Value = Convertor.IsNull(cmbksmc.SelectedValue, "");

                parameters[3].Text = "@YBLX";
                parameters[3].Value = Convertor.IsNull(cmbyblx.SelectedValue, "");

                parameters[4].Text = "@SFY";
                parameters[4].Value = Convertor.IsNull(cmbsfy.SelectedValue, "");

                DataSet dset = new DataSet();
                FrmMdiMain.Database.AdapterFillDataSet("SP_MZ_YBSRTJ", parameters, dset, "ybsrtj", 30);

                dgvData.Columns.Clear();
                DataTable dt = dset.Tables[0];

                #region 加入合计
                double tcze = 0;
                double ylzfy = 0;
                int brrs = 0;
                double cjfy = 0;
                double ypze = 0;
                double jcf = 0;
                double clf = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    tcze += dr["统筹总额"] is DBNull ? 0 : Convert.ToDouble(dr["统筹总额"]);
                    ylzfy += dr["医疗总费用"] is DBNull ? 0 : Convert.ToDouble(dr["医疗总费用"]);
                    //brrs += dr["病人人数"] is DBNull ? 0 : Convert.ToInt32(dr["病人人数"]);
                    cjfy += dr["次均费用"] is DBNull ? 0 : Convert.ToDouble(dr["次均费用"]);
                    ypze += dr["门诊人次药品总额"] is DBNull ? 0 : Convert.ToDouble(dr["门诊人次药品总额"]);
                    jcf += dr["检查费"] is DBNull ? 0 : Convert.ToDouble(dr["检查费"]);
                    clf += dr["材料费"] is DBNull ? 0 : Convert.ToDouble(dr["材料费"]);
                }
                dt.Rows.Add(new object[]
                {
                    DBNull.Value, "合计", "", tcze.ToString("#0.00"), ylzfy.ToString("#0.00"), cjfy.ToString("#0.00"), ypze.ToString("#0.00"), DBNull.Value, jcf.ToString("#0.00"), DBNull.Value, clf.ToString("#0.00"), DBNull.Value
                });
                #endregion

                dgvData.DataSource = dt;
                dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            }
            catch (Exception ex)
            {
                MessageBox.Show("统计时发生错误：" + Environment.NewLine + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // 关闭
        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 加载
        private void Frmjzlscx_Load(object sender, EventArgs e)
        {
            // 科室绑定
            FunAddComboBox.AddDept(true, 1, cmbksmc, InstanceForm.BDatabase);
            // 收费员绑定
            FunAddComboBox.AddOperator(true, cmbsfy, InstanceForm.BDatabase);
            // 医保类型绑定
            FunAddComboBox.AddYblx(true, 0, cmbyblx, InstanceForm.BDatabase);

            cmbksmc.SelectedIndex = 0;
            cmbsfy.SelectedIndex = 0;
            cmbyblx.SelectedIndex = 0;
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dgvData.DataSource == null )
                return;

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.btnExcel.Enabled = false;
                DataTable tb = dgvData.DataSource as DataTable;
                string swhere = string.Format("科室名称：{0}  医保类型：{1}  收费员：{2}  收费时间：{3} 到 {4}", cmbksmc.Text, cmbyblx.Text, cmbsfy.Text, dtp1.Text, dtp2.Text);
                ExportToExcel(tb, Constant.HospitalName + " " + this.Text, swhere);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("导出Excel时发生错误：" + Environment.NewLine + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.btnExcel.Enabled = true;
            }

        }

        private void butprinthz_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable tbmx = (DataTable)dataGridView1.DataSource;

            //    ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

            //    DataRow myrow = Dset.收费项目.NewRow();
            //    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
            //    {
            //        int x = i + 1;
            //        string nm = "T" + x.ToString();
            //        myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
            //    }
            //    Dset.收费项目.Rows.Add(myrow);

            //    for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
            //    {
            //        DataRow myrow1 = Dset.收费项目金额.NewRow();
            //        for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
            //        {
            //            int x = i + 1;
            //            string nm = "JE" + x.ToString();
            //            myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
            //        }
            //        Dset.收费项目金额.Rows.Add(myrow1);
            //    }


            //    ParameterEx[] parameters = new ParameterEx[5];

            //    parameters[0].Text = "医院名称";
            //    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

            //    parameters[1].Text = "填报日期";
            //    parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

            //    string ss = "部门:" + cmbjgbm.Text;
            //    if (Convertor.IsNull(cmbyblx.SelectedValue, "0") != "0") ss = ss + " 医保类型:" + cmbyblx.Text.Trim();
            //    if (Convertor.IsNull(cmbsfy.SelectedValue, "0") != "0") ss = ss + " 收费员:" + cmbsfy.Text.Trim();
            //    ss = ss + " 收费日期:" + dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString();

            //    parameters[2].Text = "备注";
            //    parameters[2].Value = ss;

            //    parameters[3].Text = "现金大写";
            //    parameters[3].Value = "";

            //    parameters[4].Text = "操作员";
            //    parameters[4].Value = InstanceForm.BCurrentUser.Name;

            //    TrasenFrame.Forms.FrmReportView f;
            //    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_医保结算统计(汇总).rpt", parameters);
            //    if (f.LoadReportSuccess)
            //        f.Show();
            //    else
            //        f.Dispose();
            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt = dgvData.DataSource as DataTable;
                //TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dt, Constant.ApplicationDirectory + "\\Report\\MZYBSRTJ.rpt", null);
                //if (f.LoadReportSuccess)
                //    f.Show();
                //else
                //    f.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 导出数据表到Excel
        /// </summary>
        /// <param name="table">数据表</param>
        /// <param name="title">标题</param>
        /// <param name="info">相关信息</param>
        private void ExportToExcel(DataTable table, string title, string info)
        {
            if (table == null)
                return;

            Excel.Application myExcel = new Excel.Application();
            myExcel.Application.Workbooks.Add(true);

            //写入行头
            int sumRowCount = table.Rows.Count;
            int sumColCount = 0;

            for (int j = 0; j < table.Columns.Count; j++)
            {
                sumColCount += 1;
                myExcel.Cells[5, sumColCount] = table.Columns[j].ColumnName;
            }
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, sumColCount]).Font.Bold = true;
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, sumColCount]).Font.Size = 10;

            //逐行写入数据
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int ncol = 0;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    ncol = ncol + 1;
                    myExcel.Cells[6 + i, ncol] = "'" + table.Rows[i][j].ToString().Trim();
                }
            }

            //设置报表表格为最适应宽度
            myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Columns.AutoFit();

            //加边框
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Borders.LineStyle = 1;

            //报表名称
            myExcel.Cells[1, 1] = title;
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Font.Bold = true;
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Font.Size = 16;
            //报表名称跨行居中
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

            //报表条件
            myExcel.Cells[3, 1] = info.Trim();
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, sumColCount]).Font.Size = 10;
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, sumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            //最后一行为黄色
            myExcel.get_Range(myExcel.Cells[5 + sumRowCount, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Interior.ColorIndex = 19;

            //让Excel文件可见
            myExcel.Visible = true;
        }

        private void FrmYbsrtj_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
                btnprint_Click(sender, e);
            else if (e.KeyCode == Keys.Q)
                this.Close();
            else if (e.KeyCode == Keys.E)
                butexcel_Click(sender, e);
            else if (e.KeyCode == Keys.T)
                butcx_Click(sender, e);
        }
    }
}