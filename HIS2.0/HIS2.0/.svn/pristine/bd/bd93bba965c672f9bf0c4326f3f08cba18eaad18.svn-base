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
    public partial class FrmZykssrtj : Form
    {
        private DataTable deptTb = new DataTable();
        /// <summary>
        /// 统计类型0=普通 1=仅跨院
        /// </summary>
        private int tjlx = 0;
        //Modify by Kevin 2012-12-25
        private bool dqks = false;
        private string str = "";

        public FrmZykssrtj()
        {
            InitializeComponent();
        }

        public FrmZykssrtj(int _tjlx)
        {
            InitializeComponent();

            tjlx = _tjlx;
            label1.Text += "（仅跨院）";
        }

        //Modify by Kevin 2012-12-25
        public FrmZykssrtj(bool _dqks)
        {
            InitializeComponent();
            dqks = _dqks;
        }

        public FrmZykssrtj(string _str)
        {
            InitializeComponent();
            str = _str;
            label1.Text = "住院科室收入统计(药品分类)";
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmZykssrtj_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            try
            {
                //科室
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
                cmbDept.DataSource = deptTb;
                cmbDept.DisplayMember = "ITEMNAME";
                cmbDept.ValueMember = "ITEMCODE";
                //Modify by Kevin 2012-12-25
                if (dqks == true)
                {
                    cmbDept.SelectedValue = FrmMdiMain.CurrentDept.DeptId;
                    cmbDept.Enabled = false;
                }
                else
                {
                    cmbDept.SelectedValue = -1;
                }

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
                if (str != "")
                {
                    rbDqzy.Enabled = false;
                }



                DataTable tb = new DataTable();
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
                cmbJSLX.DisplayMember = "NAME";
                cmbJSLX.ValueMember = "ID";
                cmbJSLX.DataSource = tb;
                cmbJSLX.SelectedValue = -1;

                //医保类型
                tb = InstanceForm.BDatabase.GetDataTable("SELECT ID,NAME FROM JC_YBLX ORDER BY ID ASC");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得医保类型信息！", "提示");
                    return;
                }
                //DataRow rowyb = tb.NewRow();
                //rowyb["ID"] = -1;
                //rowyb["NAME"] = "全部";
                //tb.Rows.Add(rowyb);
                cmbYBLX.DisplayMember = "NAME";
                cmbYBLX.ValueMember = "ID";
                cmbYBLX.DataSource = tb;
                cmbYBLX.SelectedValue = -1;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {

                //Modify by Kevin 2012-12-25 显示病人所在科室只在显示病人明细时有效
                if (chkBrmx.Checked == false)
                {
                    if (chkBrks.Checked == true)
                    {
                        MessageBox.Show("显示病人所在科室只在选中显示病人明细时有效！");
                        return;
                    }
                }

                Cursor = PubStaticFun.WaitCursor();

                //Modify by Kevin 2012-12-25
                ParameterEx[] parameters = new ParameterEx[12];

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

                int dept_type = 0;
                if (rbKdks.Checked)
                    dept_type = 0;
                else if (rbBrks.Checked)
                    dept_type = 1;
                else if (rbZxks.Checked)
                    dept_type = 2;
                else if (rbJsks.Checked)//Add By Tany 2012-03-06
                    dept_type = 3;
                parameters[3].Text = "@DEPT_TYPE";
                parameters[3].Value = dept_type;

                int tj_type = 0;
                if (rbFsrq.Checked)
                    tj_type = 0;
                else if (rbJsrq.Checked)
                    tj_type = 1;
                else
                    tj_type = 2;
                parameters[4].Text = "@TJ_TYPE";
                parameters[4].Value = tj_type;

                parameters[5].Text = "@ISBRMX";
                parameters[5].Value = chkBrmx.Checked ? 1 : 0;

                parameters[6].Text = "@DEPT_ID";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbDept.SelectedValue, "0"));

                //Modify By Tany 2011-12-06 增加机构编码过滤
                parameters[7].Text = "@JGBM";
                parameters[7].Value = FrmMdiMain.Jgbm;

                //Modify By Tany 2012-05-07 统计类型0=普通 1=仅跨院
                parameters[8].Text = "@TJLX";
                parameters[8].Value = tjlx;

                parameters[9].Text = "@ISBRKS";
                parameters[9].Value = chkBrks.Checked ? 1 : 0;

                parameters[10].Text = "@NJSLX";
                parameters[10].Value = Convert.ToInt32(Convertor.IsNull(cmbJSLX.SelectedValue, "0"));

                parameters[11].Text = "@NYBLX";
                parameters[11].Value = Convert.ToInt32(Convertor.IsNull(cmbYBLX.SelectedValue, "0"));

                //parameters[10].Text = "@ISYB";
                //parameters[10].Value = Convert.ToInt32(Convertor.IsNull(cmbJSLX.SelectedValue, "0"));

                //if (Convert.ToInt32(Convertor.IsNull(cmbJSLX.SelectedValue, "0")) == 0)
                //{
                //    parameters[11].Text = "@ISYBLX";
                //    parameters[11].Value = 0;
                //}
                //else if (Convert.ToInt32(Convertor.IsNull(cmbJSLX.SelectedValue, "0")) == 1)
                //{
                //    parameters[11].Text = "@ISYBLX";
                //    parameters[11].Value = 1;
                //}
                //else
                //{
                //    if (Convert.ToInt32(Convertor.IsNull(cmbYBLX.SelectedValue, "-1")) == -1)
                //    {
                //        parameters[11].Text = "@ISYBLX";
                //        parameters[11].Value = 0;
                //    }
                //    else
                //    {
                //        parameters[11].Text = "@ISYBLX";
                //        parameters[11].Value = Convert.ToInt32(Convertor.IsNull(cmbYBLX.SelectedValue, "0"));
                //    }
                //}

                DataTable tb = null;

                if (str == "")
                {
                    tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_KSSRTJ", parameters, 180);
                }
                else
                {
                    tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_KSSRTJ_YPFL", parameters, 180);
                }

                AddRowtNo(tb);
                //if (tb.Columns.Contains("序号") && tb.Rows.Count > 0)
                //{
                //    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                //}
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

                string tj_type = "";
                if (rbFsrq.Checked)
                    tj_type = "    统计日期方式:" + rbFsrq.Text;
                else if (rbJsrq.Checked)
                    tj_type = "    统计日期方式:" + rbJsrq.Text;
                else
                    tj_type = "    统计日期方式:" + rbDqzy.Text;

                string rq = "    日期:" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                string swhere = type + dept_type + tj_type + rq;


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
            if (chkBrmx.Checked)
            {
                MessageBox.Show("暂未提供打印病人明细固定格式！");
                return;
            }

            FrmReportView rv;
            ParameterEx[] parameters;

            //查询条件
            string rq = "";
            if (rbFsrq.Checked)
            {
                rq = rbFsrq.Text + ":" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
            }
            else if (rbJsrq.Checked)
            {
                rq = rbJsrq.Text + ":" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
            }
            else
            {
                rq = rbDqzy.Text + ":" + this.dtp2.Value.ToString();
            }

            string ks = "";
            if (rbKdks.Checked)
            {
                ks = "统计科室类型:" + rbKdks.Text;
            }
            else if (rbBrks.Checked)
            {
                ks = "统计科室类型:" + rbBrks.Text;
            }
            else if (rbZxks.Checked)
            {
                ks = "统计科室类型:" + rbZxks.Text;
            }
            else if (rbJsks.Checked)//Add By Tany 2012-03-06
            {
                ks = "统计科室类型:" + rbJsks.Text;
            }

            string swhere = ks;

            DataTable jsbrTb = (DataTable)dataGridView1.DataSource;

            if (rbKj.Checked && !chkBrmx.Checked)
            {
                if (jsbrTb != null && jsbrTb.Rows.Count > 0)
                {
                    parameters = new ParameterEx[4];
                    parameters[0].Text = "报表标题";
                    parameters[0].Value = Constant.HospitalName + "住院科室收入统计报表（二）";
                    parameters[2].Text = "时间段";
                    parameters[2].Value = rq;
                    parameters[1].Text = "制表人";
                    parameters[1].Value = FrmMdiMain.CurrentUser.Name;
                    parameters[3].Text = "其他参数";
                    parameters[3].Value = swhere;

                    dsReport ds = new dsReport();
                    DataTable dsTb = ds.Tables["dtJzjsbrmx"];
                    DataTable xmTb = FrmMdiMain.Database.GetDataTable("select * from jc_zykj_xm order by sort_id");

                    string d = "";
                    string s = "";
                    for (int j = 0; j < jsbrTb.Rows.Count; j++)
                    {
                        DataRow dr = dsTb.NewRow();

                        dr["住院号"] = "";
                        dr["病人姓名"] = "";
                        dr["票据号"] = 0;
                        dr["冲帐标志"] = "";
                        dr["住院科室"] = jsbrTb.Rows[j]["科室"];
                        dr["结算时间"] = "";
                        dr["结算类型"] = "";
                        dr["操作员"] = "";
                        dr["合计"] = jsbrTb.Rows[j]["合计"];
                        for (int i = 0; i < xmTb.Rows.Count; i++)
                        {
                            d = "d" + Convert.ToString(i + 1);
                            s = "s" + Convert.ToString(i + 1);
                            dr[d] = jsbrTb.Rows[j][xmTb.Rows[i]["item_name"].ToString().Trim()];
                            dr[s] = xmTb.Rows[i]["item_name"].ToString().Trim();
                        }

                        dsTb.Rows.Add(dr);
                    }

                    rv = new FrmReportView(dsTb, Constant.ApplicationDirectory + "\\report\\ZYGL_科室收入统计.rpt", parameters, false);
                    rv.Show();
                }
            }
            else//Modify By Tany 2012-01-11 改成自由列
            {
                if (jsbrTb != null && jsbrTb.Rows.Count > 0)
                {
                    parameters = new ParameterEx[4];
                    parameters[0].Text = "报表标题";
                    parameters[0].Value = Constant.HospitalName + "住院科室收入统计";
                    parameters[2].Text = "时间段";
                    parameters[2].Value = rq;
                    parameters[1].Text = "制表人";
                    parameters[1].Value = FrmMdiMain.CurrentUser.Name;
                    parameters[3].Text = "其他参数";
                    parameters[3].Value = swhere;

                    dsReport ds = new dsReport();
                    DataTable dsTb = ds.Tables["dtJzjsbrmx"];
                    //DataTable xmTb = FrmMdiMain.Database.GetDataTable("select * from jc_zykj_xm order by sort_id");

                    string d = "";
                    string s = "";
                    for (int j = 0; j < jsbrTb.Rows.Count; j++)
                    {
                        for (int i = 2; i < jsbrTb.Columns.Count; i++)
                        {
                            DataRow dr = dsTb.NewRow();

                            dr["住院号"] = "";
                            dr["病人姓名"] = "";
                            dr["票据号"] = 0;
                            dr["冲帐标志"] = "";
                            dr["住院科室"] = jsbrTb.Rows[j]["科室"];
                            dr["结算时间"] = "";
                            dr["结算类型"] = "";
                            dr["操作员"] = "";
                            dr["合计"] = jsbrTb.Rows[j]["合计"];

                            d = "d1";
                            s = "s1";
                            //Modify By Tany 2012-03-08
                            if (chkPbxs.Checked && Convert.ToDecimal(Convertor.IsNull(jsbrTb.Rows[j][i], "0")) == 0)
                            {
                                continue;
                            }
                            dr[d] = jsbrTb.Rows[j][i];
                            dr[s] = jsbrTb.Columns[i].ToString().Trim();

                            dsTb.Rows.Add(dr);
                        }
                    }

                    rv = new FrmReportView(dsTb, Constant.ApplicationDirectory + "\\report\\ZYGL_科室收入统计动态.rpt", parameters, false);
                    rv.Show();
                }
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

        private void cmbDept_TextChanged(object sender, EventArgs e)
        {
            CleanInfo();

            try
            {
                if (cmbDept.Text.Trim() != "")
                {
                    DataTable tableTemp = deptTb.Clone();
                    string tj = cmbDept.Text.Trim().Replace("[", "[[]");
                    string sql = @"PY_CODE like '" + tj + "%'";
                    DataRow[] rows = deptTb.Select(sql, "");
                    foreach (DataRow row in rows)
                    {
                        tableTemp.Rows.Add(row.ItemArray);
                    }
                    cmbDept.DataSource = tableTemp;
                }
                else
                {
                    cmbDept.DataSource = deptTb;
                }


                //Modify by Kevin 2012-12-25
                //if (dqks == true && cmbDept.Text.Trim() != "")
                //{
                //    cmbDept.SelectedText = FrmMdiMain.CurrentDept.DeptName;
                //    cmbDept.SelectedValue = FrmMdiMain.CurrentDept.DeptId;
                //    cmbDept.Enabled = false;
                //}
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void cmbJSLX_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cmbJSLX.SelectedValue) == 1)
            {
                cmbYBLX.Enabled = true;
            }
            else
            {
                cmbYBLX.Enabled = false;
                cmbYBLX.SelectedValue = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                cmbJSLX.Enabled = true;
            }
            else
            {
                cmbJSLX.Enabled = false;
                cmbYBLX.Enabled = false;
                cmbJSLX.SelectedValue = -1;
                cmbYBLX.SelectedValue = 0;
            }
        }
    }
}