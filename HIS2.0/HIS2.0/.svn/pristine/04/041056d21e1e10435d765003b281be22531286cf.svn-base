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
    public partial class FrmBrsrtj : Form
    {
        public FrmBrsrtj()
        {
            InitializeComponent();
        }

        private void FrmBrsrtj_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            try
            {
                //科室
                DataTable tb = InstanceForm.BDatabase.GetDataTable(@"SELECT DEPT_ID AS ITEMCODE,NAME AS ITEMNAME FROM JC_DEPT_PROPERTY WHERE ZY_FLAG = 1 and jgbm=" + FrmMdiMain.Jgbm
                               + " AND DELETED = 0 AND DEPT_ID in (select DEPT_ID from jc_dept_type_relation where type_code = '004') ORDER BY SORT_ID ASC");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得科室信息！", "提示");
                }
                DataRow rowKs = tb.NewRow();
                rowKs["ITEMCODE"] = -1;
                rowKs["ITEMNAME"] = "全部";
                tb.Rows.Add(rowKs);
                cmbDept.DataSource = tb;
                cmbDept.DisplayMember = "ITEMNAME";
                cmbDept.ValueMember = "ITEMCODE";
                cmbDept.SelectedValue = -1;

                //结算方式
                tb = InstanceForm.BDatabase.GetDataTable("SELECT CODE AS ID,NAME FROM JC_JSFS ORDER BY CODE");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得结算信息！", "提示");
                }
                DataRow rowJsfs = tb.NewRow();
                rowJsfs["ID"] = -1;
                rowJsfs["NAME"] = "全部";
                tb.Rows.Add(rowJsfs);
                cmbJslx.DisplayMember = "NAME";
                cmbJslx.ValueMember = "ID";
                cmbJslx.DataSource = tb;
                cmbJslx.SelectedValue = -1;

                //医保类型
                tb = InstanceForm.BDatabase.GetDataTable("SELECT ID,NAME FROM JC_YBLX ORDER BY ID ASC");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得病人类型信息！", "提示");
                    return;
                }
                DataRow rowyb = tb.NewRow();
                rowyb["ID"] = -1;
                rowyb["NAME"] = "全部";
                tb.Rows.Add(rowyb);
                cmbYblx.DisplayMember = "NAME";
                cmbYblx.ValueMember = "ID";
                cmbYblx.DataSource = tb;
                cmbYblx.SelectedValue = -1;

                //病人类型
                tb = InstanceForm.BDatabase.GetDataTable("SELECT CODE AS ID,NAME FROM JC_BRLX ORDER BY CODE");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得病人类型信息！", "提示");
                    return;
                }
                DataRow rowLx = tb.NewRow();
                rowLx["ID"] = -1;
                rowLx["NAME"] = "所有";
                tb.Rows.Add(rowLx);
                cmbBrlx.DisplayMember = "NAME";
                cmbBrlx.ValueMember = "ID";
                cmbBrlx.DataSource = tb;
                cmbBrlx.SelectedValue = -1;

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
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
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

                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@DEPTID";
                parameters[2].Value = Convert.ToInt32(Convertor.IsNull(cmbDept.SelectedValue, "0"));

                parameters[3].Text = "@TJ_TYPE";
                parameters[3].Value = rbJsrq.Checked ? 1 : 2;

                parameters[4].Text = "@SORT_TYPE";
                parameters[4].Value = rbSortByZyh.Checked ? 1 : 2;

                //Modify By Tany 2011-12-06 增加机构编码过滤
                parameters[5].Text = "@JGBM";
                parameters[5].Value = FrmMdiMain.Jgbm;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_BRSRTJ", parameters, 120);

                AddRowtNo(tb);
                if (tb.Columns.Contains("序号") && tb.Rows.Count > 0)
                {
                    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                }
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

        private void rbJsrq_CheckedChanged(object sender, EventArgs e)
        {
            CleanInfo();
            dtp1.Enabled = !rbDqzy.Checked;
            groupBox2.Enabled = rbDqzy.Checked;
        }

        private void CleanInfo()
        {
            dataGridView1.DataSource = null;
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanInfo();
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
                //string rq = (rbJsrq.Checked ? rbJsrq.Text : rbDqzy.Text) + ":" + (rbJsrq.Checked ? (this.dtp1.Value.ToString() + " 到 ") : "") + this.dtp2.Value.ToString();
                //string ks = "   科室:" + cmbDept.Text;
                //string swhere = rq + ks;


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

                //Modify By Kevin 2013-08-21 采用简工写的导出EXCEL

                string rq = (rbJsrq.Checked ? rbJsrq.Text : rbDqzy.Text) + ":" + (rbJsrq.Checked ? (this.dtp1.Value.ToString() + " 到 ") : "") + this.dtp2.Value.ToString();
                string ks = "   科室:" + cmbDept.Text;
                string swhere = rq + ks;

                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + this.label1.Text.ToString(), swhere, true, true, false, false);


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

        private void butdy_Click(object sender, EventArgs e)
        {
            if (rbDqzy.Checked)
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;

                if (tb != null && tb.Rows.Count > 0)
                {
                    //查询条件
                    string rq = rbDqzy.Text + ":" + this.dtp2.Value.ToString();
                    string swhere = "病人科室:" + cmbDept.Text;

                    ParameterEx[] parameters = new ParameterEx[4];
                    parameters[0].Text = "报表标题";
                    parameters[0].Value = Constant.HospitalName + "住院病人综合信息";
                    parameters[1].Text = "时间段";
                    parameters[1].Value = rq;
                    parameters[2].Text = "其他参数";
                    parameters[2].Value = swhere;
                    parameters[3].Text = "制表人";
                    parameters[3].Value = FrmMdiMain.CurrentUser.Name;

                    FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\ZYGL_在院病人信息.rpt", parameters, false);
                    rv.Show();
                }
            }
            else
            {
                MessageBox.Show("只能打印当前在院的病人数据！\r\n其他的暂未提供打印固定格式！");
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