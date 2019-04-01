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
    public partial class FrmZykssrtjEx : Form
    {
        private DataTable deptTb = new DataTable();
        private DataTable deptTb1 = new DataTable();
        public FrmZykssrtjEx()
        {
            InitializeComponent();
        }

        private void FrmZykssrtjEx_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            try
            {
                //执行科室和开单科室
                deptTb = InstanceForm.BDatabase.GetDataTable(@"SELECT DEPT_ID AS ITEMCODE,NAME AS ITEMNAME,py_code,wb_code FROM JC_DEPT_PROPERTY WHERE jgbm=" + FrmMdiMain.Jgbm
                               + " AND DELETED = 0 AND LAYER=3 ORDER BY SORT_ID ASC");
                if (deptTb == null)
                {
                    MessageBox.Show("错误，未能取得科室信息！", "提示");
                }
                DataRow rowKs = deptTb.NewRow();
                rowKs["ITEMCODE"] = -1;
                rowKs["ITEMNAME"] = "全部";
                deptTb.Rows.Add(rowKs);
                cmbZxDept.DataSource = deptTb;
                cmbZxDept.DisplayMember = "ITEMNAME";
                cmbZxDept.ValueMember = "ITEMCODE";
                cmbZxDept.SelectedValue = -1;

                deptTb1 = deptTb.Copy();
                cmbKdDept.DataSource = deptTb1;
                cmbKdDept.DisplayMember = "ITEMNAME";
                cmbKdDept.ValueMember = "ITEMCODE";
                cmbKdDept.SelectedValue = -1;

                //病人所在科室
                DataTable tb = InstanceForm.BDatabase.GetDataTable(@"SELECT DEPT_ID AS ITEMCODE,NAME AS ITEMNAME FROM JC_DEPT_PROPERTY WHERE ZY_FLAG = 1 and jgbm=" + FrmMdiMain.Jgbm
                               + " AND DELETED = 0 AND DEPT_ID in (select DEPT_ID from jc_dept_type_relation where type_code = '004') ORDER BY SORT_ID ASC");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得科室信息！", "提示");
                }
                rowKs = tb.NewRow();
                rowKs["ITEMCODE"] = -1;
                rowKs["ITEMNAME"] = "全部";
                tb.Rows.Add(rowKs);
                cmbBrDept.DataSource = tb;
                cmbBrDept.DisplayMember = "ITEMNAME";
                cmbBrDept.ValueMember = "ITEMCODE";
                cmbBrDept.SelectedValue = -1;

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

                ParameterEx[] parameters = new ParameterEx[9];

                parameters[0].Text = "@RQ1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@RQ2";
                parameters[1].Value = dtp2.Value.ToString();

                int type = 0;
                if (rbJg.Checked)
                    type = 0;
                else
                    type = 1;
                parameters[2].Text = "@TYPE";
                parameters[2].Value = type;

                int tj_type = 0;
                if (rbFsrq.Checked)
                    tj_type = 0;
                else if (rbJsrq.Checked)
                    tj_type = 1;
                else
                    tj_type = 2;
                parameters[3].Text = "@TJ_TYPE";
                parameters[3].Value = tj_type;

                parameters[4].Text = "@DEPT_BR";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbBrDept.SelectedValue, "0"));

                parameters[5].Text = "@DEPT_ID";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(cmbKdDept.SelectedValue, "0"));

                parameters[6].Text = "@EXECDEPT_ID";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbZxDept.SelectedValue, "0"));

                parameters[7].Text = "@ISBRMX";
                parameters[7].Value = chkBrmx.Checked ? 1 : 0;

                //Modify By Tany 2011-12-06 增加机构编码过滤
                parameters[8].Text = "@JGBM";
                parameters[8].Value = FrmMdiMain.Jgbm;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_KSSRTJ_EX", parameters, 120);

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

        private void CleanInfo()
        {
            dataGridView1.DataSource = null;
        }

        private void rbJg_CheckedChanged(object sender, EventArgs e)
        {
            CleanInfo();
            dtp1.Enabled = !rbDqzy.Checked;
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
                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                this.btExcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string type = "";
                if (rbJg.Checked)
                    type = "统计项目:" + rbJg.Text;
                else
                    type = "统计项目:" + rbKj.Text;

                string tj_type = "";
                if (rbFsrq.Checked)
                    tj_type = "    统计日期方式:" + rbFsrq.Text;
                else if (rbJsrq.Checked)
                    tj_type = "    统计日期方式:" + rbJsrq.Text;
                else
                    tj_type = "    统计日期方式:" + rbDqzy.Text;

                string brks = "    病人科室:" + cmbBrDept.Text;
                string kdks = "    开单科室:" + cmbKdDept.Text;
                string zxks = "    执行科室:" + cmbZxDept.Text;

                string rq = "    日期:" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                string swhere = type + tj_type + brks + kdks + zxks + rq;


                //写入行头

                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    if (this.dataGridView1.Columns[j].Visible)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = "" + this.dataGridView1.Columns[j].HeaderText;
                    }
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
                        myExcel.Cells[6 + i, ncol] = tb.Rows[i][j].ToString().Trim();//"'" + 
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = TrasenFrame.Classes.Constant.HospitalName + this.label1.Text;
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

                #endregion
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
            MessageBox.Show("暂未提供打印固定格式！");
        }

        private void cmbZxDept_TextChanged(object sender, EventArgs e)
        {
            CleanInfo();

            try
            {
                if (cmbZxDept.Text.Trim() != "")
                {
                    DataTable tableTemp = deptTb.Clone();
                    //Modify By tany 2011-05-23
                    string tj = cmbZxDept.Text.Trim().Replace("[", "[[]");
                    string sql = @"PY_CODE like '" + tj + "%'";
                    //string sql = "PY_CODE like '" + cmbZxDept.Text.Trim() + "%'";
                    DataRow[] rows = deptTb.Select(sql, "");
                    foreach (DataRow row in rows)
                    {
                        tableTemp.Rows.Add(row.ItemArray);
                    }
                    cmbZxDept.DataSource = tableTemp;
                }
                else
                {
                    cmbZxDept.DataSource = deptTb;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cmbKdDept_TextChanged(object sender, EventArgs e)
        {
            CleanInfo();

            try
            {
                if (cmbKdDept.Text.Trim() != "")
                {
                    DataTable tableTemp = deptTb1.Clone();
                    //Modify By tany 2011-05-23
                    string tj = cmbKdDept.Text.Trim().Replace("[", "[[]");
                    string sql = @"PY_CODE like '" + tj + "%'";
                    //string sql = "PY_CODE like '" + cmbKdDept.Text.Trim() + "%'";
                    DataRow[] rows = deptTb1.Select(sql, "");
                    foreach (DataRow row in rows)
                    {
                        tableTemp.Rows.Add(row.ItemArray);
                    }
                    cmbKdDept.DataSource = tableTemp;
                }
                else
                {
                    cmbKdDept.DataSource = deptTb1;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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