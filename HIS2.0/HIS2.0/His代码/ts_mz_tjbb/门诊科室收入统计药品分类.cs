using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class Frmkssrtjypfl : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frmkssrtjypfl(MenuTag menuTag, string chineseName, Form mdiParent)
        {

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            InitializeComponent();

        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@type";
                parameters[2].Value = rdJg.Checked == true ? 0 : 1;

                int _jsfs = 0;
                if (rbYb.Checked)
                {
                    _jsfs = 1;
                }
                else if (rbZf.Checked)
                {
                    _jsfs = 2;
                }
                else
                {
                    _jsfs = 0;
                }

                parameters[3].Text = "@jsfs";
                parameters[3].Value = _jsfs;

                parameters[4].Text = "@jgbm";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                parameters[5].Text = "@tjlx";
                parameters[5].Value = _menuTag.Function_Name == "Fun_ts_mz_tjbb_kssrtj" ? 0 : 1; ;

                parameters[6].Text = "@include_kdks";
                parameters[6].Value = chkKdks.Checked ? 1 : 0;


                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_SK_kssrtj_ypfl", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);


                this.dataGridView1.DataSource = dset.Tables[0];

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmkssrtjypfl_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            cmbFG.Items.Add("列宽适应网格内容");
            cmbFG.Items.Add("列宽仅适应有数据的区域");
            cmbFG.SelectedIndex = 0;
            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                dtp1.Value = Convert.ToDateTime(dtp1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtp2.Value = Convert.ToDateTime(dtp2.Value.ToShortDateString() + " " + s[1]);
            }
            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;
        }

        private void cmbFG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFG.SelectedIndex == 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 30;
                dataGridView1.Refresh();
            }
            if (cmbFG.SelectedIndex == 1)
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            }
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)dataGridView1.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                }
                Dset.收费项目.Rows.Add(myrow);

                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        int x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }


                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                string jsfs = "";
                if (rbAll.Checked == true) jsfs = rbAll.Text;
                if (rbYb.Checked == true) jsfs = rbYb.Text;
                if (rbZf.Checked == true) jsfs = rbZf.Text;

                string ssql = rdJg.Checked == true ? "统计:按经管项目分类" : "统计:按会计项目分类";
                parameters[2].Text = "备注";
                parameters[2].Value = dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString() + "  " + ssql + " 部门名称:" + cmbjgbm.Text + " 结算方式:" + jsfs;

                parameters[3].Text = "现金大写";
                parameters[3].Value = "";

                TrasenFrame.Forms.FrmReportView f;
                if (rdJg.Checked == true)
                    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_科室收入报表(经管).rpt", parameters);
                else
                    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_科室收入报表(会计).rpt", parameters);

                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butexcel.Enabled = false;

                //Excel.Application myExcel = new Excel.Application();

                //myExcel.Application.Workbooks.Add(true);
                //Excel._Worksheet ws = (Excel._Worksheet)myExcel.ActiveSheet;   
                //查询条件
                string xm = "";
                if (rdJg.Checked == true)
                    xm = "   统计分类:经管项目";
                else
                    xm = "   统计分类:会计项目";
                bool bol = checkBox1.Checked;
                string swhere = "日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + xm + "  部门名称:" + cmbjgbm.Text; ;
                ts_jc_log.ExcelOper.ExportData_ForDataTable(dataGridView1, Constant.HospitalName + label1.Text, swhere, true, true, bol, false);

                ////写入行头
                //DataTable tb = (DataTable)this.dataGridView1.DataSource;
                //int SumRowCount = tb.Rows.Count;
                //int SumColCount = 0;

                //for (int j = 0; j < tb.Columns.Count; j++)
                //{
                //    if (checkBox1.Checked == true)
                //    {
                //        if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "")
                //        {
                //            SumColCount = SumColCount + 1;
                //            myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName.Trim();
                //        }
                //    }
                //    else
                //    {
                //        SumColCount = SumColCount + 1;
                //        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName.Trim();

                //    }

                //}
                //myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                //myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 9;


                ////逐行写入数据，

                //for (int i = 0; i < tb.Rows.Count; i++)
                //{
                //    int ncol = 0;
                //    for (int j = 0; j < tb.Columns.Count; j++)
                //    {
                //        if (checkBox1.Checked == true)
                //        {
                //            if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "")
                //            {
                //                ncol = ncol + 1;
                //                myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                //            }
                //        }
                //        else
                //        {
                //            ncol = ncol + 1;
                //            myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                //        }
                //    }
                //}

                ////设置报表表格为最适应宽度
                //myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                //myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();
                //myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Font.Size = 9;

                ////加边框
                //myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                ////报表名称
                //string ss = Constant.HospitalName + label1.Text;
                //myExcel.Cells[1, 1] = ss;
                //myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                //myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                ////报表名称跨行居中
                //myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                //myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                ////报表条件
                //myExcel.Cells[3, 1] = swhere.Trim();
                //myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                //myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                //myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                ////最后一行为黄色
                //myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;


                ////让Excel文件可见
                //myExcel.Visible = true;
                this.butexcel.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butexcel.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
