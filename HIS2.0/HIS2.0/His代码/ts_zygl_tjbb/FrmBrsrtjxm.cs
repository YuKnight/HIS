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
    public partial class FrmBrsrtjxm : Form
    {
        //Modify By tany 2011-12-07 是否显示全部科室
        private bool isAll = false;

        public FrmBrsrtjxm(bool _isAll)
        {
            InitializeComponent();

            isAll = _isAll;
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBrsrtjxm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            try
            {
                //收费员
                string sql = "";
                DataTable tb = new DataTable();

                //科室
                //Modify By Tany 2011-12-07 是否显示全部还是显示本病区的科室
                string tj = "";
                if (!isAll)
                {
                    tj = " and dept_id in (select dept_id from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "') ";
                }
                tb = InstanceForm.BDatabase.GetDataTable(@"SELECT DEPT_ID AS ITEMCODE,NAME AS ITEMNAME FROM JC_DEPT_PROPERTY WHERE ZY_FLAG = 1 and jgbm=" + FrmMdiMain.Jgbm
                               + " AND DELETED = 0 AND DEPT_ID in (select DEPT_ID from jc_dept_type_relation where type_code = '004') " + tj + " ORDER BY SORT_ID ASC");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得科室信息！", "提示");
                }
                if (isAll)
                {
                    DataRow rowKs = tb.NewRow();
                    rowKs["ITEMCODE"] = -1;
                    rowKs["ITEMNAME"] = "全部";
                    tb.Rows.Add(rowKs);
                }
                cmbDept.DataSource = tb;
                cmbDept.DisplayMember = "ITEMNAME";
                cmbDept.ValueMember = "ITEMCODE";
                if (isAll)
                {
                    cmbDept.SelectedValue = -1;
                }
                else
                {
                    cmbDept.SelectedIndex = 0;
                }

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
                    MessageBox.Show("错误，未能取得医保类型信息！", "提示");
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

                //病种分型
                tb = InstanceForm.BDatabase.GetDataTable("SELECT ID,NAME FROM JC_BZFX ORDER BY ID");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得病种分型信息！", "提示");
                    return;
                }
                DataRow rowFx = tb.NewRow();
                rowFx["ID"] = -1;
                rowFx["NAME"] = "全部";
                tb.Rows.Add(rowFx);
                cmbBzfx.DisplayMember = "NAME";
                cmbBzfx.ValueMember = "ID";
                cmbBzfx.DataSource = tb;
                cmbBzfx.SelectedValue = -1;

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

        private void cmbJslx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cmbJslx.SelectedValue) == 1)
            {
                cmbYblx.Enabled = true;
            }
            else
            {
                cmbYblx.Enabled = false;
            }
            CleanInfo();
        }

        private void CleanInfo()
        {
            dataGridView1.DataSource = null;
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void rbJg_CheckedChanged(object sender, EventArgs e)
        {
            CleanInfo();
            dtp1.Enabled = !rbDqzy.Checked;
            rbJsks.Enabled = rbJsrq.Checked;
            if (!rbJsrq.Checked && rbJsks.Checked)
            {
                rbKdks.Checked = true;
            }
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = PubStaticFun.WaitCursor();

                ParameterEx[] parameters = new ParameterEx[11];

                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                int type = 0;
                if (rbJg.Checked)
                    type = 0;
                else if ((rbKj.Checked))
                    type = 1;
                else
                    type = 2;
                parameters[2].Text = "@TYPE";
                parameters[2].Value = type;

                int tj_type = 0;
                if (rbFsrq.Checked)
                    tj_type = 0;
                else if (rbJsrq.Checked)
                    tj_type = 1;
                else if (rbDqzy.Checked)
                    tj_type = 2;
                else if (rbRyrq.Checked)
                    tj_type = 3;
                else if (rbCyrq.Checked)
                    tj_type = 4;
                parameters[3].Text = "@TJ_TYPE";
                parameters[3].Value = tj_type;

                parameters[4].Text = "@NKS";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbDept.SelectedValue, "0"));

                parameters[5].Text = "@NBRLX";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(cmbBrlx.SelectedValue, "0"));

                parameters[6].Text = "@NJSLX";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbJslx.SelectedValue, "0"));

                parameters[7].Text = "@NYBLX";
                parameters[7].Value = Convert.ToInt32(Convertor.IsNull(cmbYblx.SelectedValue, "0"));

                parameters[8].Text = "@BZFX";
                parameters[8].Value = Convert.ToInt32(Convertor.IsNull(cmbBzfx.SelectedValue, "0"));

                //Modify By Tany 2011-12-06 增加机构编码过滤
                parameters[9].Text = "@JGBM";
                parameters[9].Value = FrmMdiMain.Jgbm;

                //Modify By Tany 2012-03-07 增加科室类型选择
                int dept_type = 0;
                if (rbKdks.Checked)
                    dept_type = 0;
                else if (rbBrks.Checked)
                    dept_type = 1;
                else if (rbZxks.Checked)
                    dept_type = 2;
                else if (rbJsks.Checked)//Add By Tany 2012-03-07
                    dept_type = 3;
                parameters[10].Text = "@DEPT_TYPE";
                parameters[10].Value = dept_type;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_BRSRTJ_XM", parameters, 180);

                AddRowtNo(tb);
                if (tb.Columns.Contains("序号") && tb.Rows.Count > 0)
                {
                    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                }
                this.dataGridView1.DataSource = tb;

                //屏蔽显示
                if (this.dataGridView1.Columns.Contains("SORTA"))
                {
                    this.dataGridView1.Columns["SORTA"].Visible = false;
                }
                if (this.dataGridView1.Columns.Contains("SORTB"))
                {
                    this.dataGridView1.Columns["SORTB"].Visible = false;
                }
                if (this.dataGridView1.Columns.Contains("INPATIENT_ID"))
                {
                    this.dataGridView1.Columns["INPATIENT_ID"].Visible = false;
                }
                if (this.dataGridView1.Columns.Contains("DEPT_ID"))
                {
                    this.dataGridView1.Columns["DEPT_ID"].Visible = false;
                }
                if (this.dataGridView1.Columns.Contains("YBLX"))
                {
                    this.dataGridView1.Columns["YBLX"].Visible = false;
                }
                if (!rbJsrq.Checked && !rbCyrq.Checked)
                {
                    if (this.dataGridView1.Columns.Contains("出院诊断"))
                    {
                        this.dataGridView1.Columns["出院诊断"].Visible = false;
                    }
                    if (this.dataGridView1.Columns.Contains("出院日期"))
                    {
                        this.dataGridView1.Columns["出院日期"].Visible = false;
                    }
                    if (this.dataGridView1.Columns.Contains("结算日期"))
                    {
                        this.dataGridView1.Columns["结算日期"].Visible = false;
                    }
                    if (this.dataGridView1.Columns.Contains("天数"))
                    {
                        this.dataGridView1.Columns["天数"].Visible = false;
                    }
                    if (this.dataGridView1.Columns.Contains("平均天数"))
                    {
                        this.dataGridView1.Columns["平均天数"].Visible = false;
                    }
                }
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
                else if (rbKj.Checked)
                    type = "统计项目:" + rbKj.Text;
                else
                    type = "统计项目:" + rbYb.Text;

                string tj_type = "";
                if (rbFsrq.Checked)
                    tj_type = "    统计日期方式:" + rbFsrq.Text;
                else if (rbJsrq.Checked)
                    tj_type = "    统计日期方式:" + rbJsrq.Text;
                else if (rbDqzy.Checked)
                    tj_type = "    统计日期方式:" + rbDqzy.Text;
                else if (rbRyrq.Checked)
                    tj_type = "    统计日期方式:" + rbRyrq.Text;
                else if (rbCyrq.Checked)
                    tj_type = "    统计日期方式:" + rbCyrq.Text;

                //Add By Tany 2012-03-07
                string dept_type = "";
                if (rbKdks.Checked)
                {
                    dept_type = "    统计科室类型:" + rbKdks.Text;
                }
                else if (rbBrks.Checked)
                {
                    dept_type = "    统计科室类型:" + rbBrks.Text;
                }
                else if (rbZxks.Checked)
                {
                    dept_type = "    统计科室类型:" + rbZxks.Text;
                }
                else if (rbJsks.Checked)//Add By Tany 2012-03-06
                {
                    dept_type = "    统计科室类型:" + rbJsks.Text;
                }

                string rq = "    日期:" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();

                string ks = "   科室:" + cmbDept.Text;
                string brlx = "   病人类型:" + cmbBrlx.Text;
                string jslx = "   结算类型:" + cmbJslx.Text;
                string yblx = "";
                if (Convert.ToInt32(this.cmbJslx.SelectedValue) == 1)
                {
                    yblx = "   医保类型:" + cmbYblx.Text;
                }
                //Add By Tany 2010-10-09
                string bzfx = "   病种分型:" + cmbBzfx.Text;

                string swhere = type + dept_type + ks + brlx + bzfx + jslx + yblx + tj_type + rq;


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
                        if (this.dataGridView1.Columns[j].Visible)
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                        }
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