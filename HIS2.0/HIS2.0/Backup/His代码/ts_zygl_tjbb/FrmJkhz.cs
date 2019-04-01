using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame;
using TrasenFrame.Forms;

namespace ts_zygl_tjbb
{
    public partial class FrmJkhz : Form
    {
        public FrmJkhz()
        {
            InitializeComponent();
        }

        private void FrmJkhz_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = PubStaticFun.WaitCursor();

                //Modify By Kevin 2013-06-18
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@jky";
                parameters[2].Value = Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue, "0"));

                //Modify By Tany 2012-01-05
                int type = 0;
                if (rbJkczrq.Checked)
                {
                    type = 2;
                }
                else if (rbSfrq.Checked)
                {
                    type = 1;
                }
                parameters[3].Text = "@TYPE";
                parameters[3].Value = type;

                //Add By Kevin 2013-06-18 增加机构编码
                parameters[4].Text = "@JGBM";
                parameters[4].Value = FrmMdiMain.Jgbm;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_JKHZTJ", parameters, 120);

                AddRowtNo(tb);
                if (tb.Rows.Count > 0)
                    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                this.dataGridView1.DataSource = tb;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("序号") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;
            }
        }

        private void Init()
        {
            try
            {
                string sql = "select employee_id,name from jc_employee_property where rylx=3";
                DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sql);
                DataRow row = tb.NewRow();

                row["employee_id"] = "-1";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);

                cmbuser.DisplayMember = "name";
                cmbuser.ValueMember = "employee_id";
                cmbuser.DataSource = tb;

                cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId;
                if (cmbuser.SelectedValue == null || cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
                {
                    cmbuser.SelectedValue = "-1";
                }
                //交账模式0=全班1=个人 Add by Tany 2010-09-08
                int _jzms = Convert.ToInt32(new SystemCfg(5006).Config);
                if (_jzms == 0)
                    this.cmbuser.SelectedValue = "-1";

                //日期
                DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                //检查系统是否控制了交帐时间 Modify By Tany 2012-01-11
                if (Convert.ToInt32(new SystemCfg(5016).Config) == 1)
                {
                    this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " " + Convert.ToDateTime(new SystemCfg(5017).Config.Trim()).AddSeconds(1).ToString(" HH:mm:ss"));
                    this.dtp2.Value = Convert.ToDateTime(now.ToShortDateString() + " " + new SystemCfg(5017).Config.Trim());
                }
                else
                {
                    this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 00:00:00");
                    this.dtp2.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 23:59:59");
                }
                this.dtp2.MaxDate = now;

                //Add By Tany 2010-11-26 增加判断，如果不交账，那么默认统计方式为收费时间
                if (Convert.ToInt32(new SystemCfg(5019).Config) == 0)
                {
                    rbSfrq.Checked = true;
                }
                else
                {
                    rbJkrq.Checked = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                #region 简单打印
                //DataTable tb = (DataTable)this.dataGridView1.DataSource;

                //if (tb == null || tb.Rows.Count == 0)
                //{
                //    return;
                //}

                //this.btExcel.Enabled = false;

                //Excel.Application myExcel = new Excel.Application();

                //myExcel.Application.Workbooks.Add(true);

                ////查询条件
                //string sType = "交款时间:";
                //if (rbJkczrq.Checked)
                //{
                //    sType = "交款操作时间:";
                //}
                //else if (rbSfrq.Checked)
                //{
                //    sType = "收费时间:";
                //}
                //string rq = sType + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                //string sfy = "   收费员:" + cmbuser.Text;
                //string swhere = rq + sfy;


                ////写入行头

                //int SumRowCount = tb.Rows.Count;
                //int SumColCount = 0;

                //for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                //{
                //    if (this.dataGridView1.Columns[j].Visible)
                //    {
                //        SumColCount = SumColCount + 1;
                //        myExcel.Cells[5, SumColCount] = "" + this.dataGridView1.Columns[j].HeaderText;
                //    }
                //}
                //myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                //myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                ////逐行写入数据，

                //for (int i = 0; i < tb.Rows.Count; i++)
                //{
                //    int ncol = 0;
                //    for (int j = 0; j < tb.Columns.Count; j++)
                //    {
                //        ncol = ncol + 1;
                //        myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                //    }
                //}

                ////设置报表表格为最适应宽度
                //myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                //myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                ////加边框
                //myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                ////报表名称
                //string ss = TrasenFrame.Classes.Constant.HospitalName + this.label1.Text;
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

                #endregion

                //Modify By Kevin 2013-09-11 采用简工写的导出EXCEL
                //Begin
                //查询条件
                string sType = "交款时间:";
                if (rbJkczrq.Checked)
                {
                    sType = "交款操作时间:";
                }
                else if (rbSfrq.Checked)
                {
                    sType = "收费时间:";
                }
                string rq = String.Format("{0}{1} 到 {2}", sType, this.dtp1.Value, this.dtp2.Value);
                string sfy = "   收费员:" + cmbuser.Text;
                string swhere = rq + sfy;
                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, String.Format("{0}{1}", Constant.HospitalName, this.label1.Text), swhere, true, true, false, false);
                //End
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.btExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void CleanInfo()
        {
            dataGridView1.DataSource = null;
        }

        private void rbJkrq_CheckedChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void butdy_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;

            if (tb != null && tb.Rows.Count > 0)
            {
                //查询条件
                string sType = "交款时间:";
                if (rbJkczrq.Checked)
                {
                    sType = "交款操作时间:";
                }
                else if (rbSfrq.Checked)
                {
                    sType = "收费时间:";
                }
                string rq = sType + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                string sfy = "收费员:" + cmbuser.Text.Trim();
                string swhere = sfy;

                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "报表标题";
                parameters[0].Value = Constant.HospitalName + "住院收款统计报表";
                parameters[1].Text = "制表人";
                parameters[1].Value = FrmMdiMain.CurrentUser.Name;
                parameters[2].Text = "时间段";
                parameters[2].Value = rq;
                parameters[3].Text = "其他参数";
                parameters[3].Value = swhere;

                FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\ZYGL_住院收款汇总统计.rpt", parameters, false);
                rv.Show();
            }
        }

        //Add By tany 2011-04-13
        private void 冻结当前列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int ncol = dataGridView1.CurrentCell.ColumnIndex;

                    if (dataGridView1.Columns[ncol].Frozen)
                    {
                        for (int i = 0; i < ncol; i++)
                        {
                            dataGridView1.Columns[i].Frozen = false;
                        }
                    }
                    else
                    {
                        dataGridView1.Columns[ncol].Frozen = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int ncol = dataGridView1.CurrentCell.ColumnIndex;

                    if (dataGridView1.Columns[ncol].Frozen)
                    {
                        冻结当前列ToolStripMenuItem.Text = "解冻当前列";
                    }
                    else
                    {
                        冻结当前列ToolStripMenuItem.Text = "冻结当前列";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}