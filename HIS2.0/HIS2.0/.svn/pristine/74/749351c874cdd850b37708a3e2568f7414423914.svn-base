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
    public partial class FrmJstj : Form
    {
        /// <summary>
        /// 统计类型0=普通 1=仅跨院
        /// </summary>
        private int tjlx = 0;

        public FrmJstj()
        {
            InitializeComponent();
        }

        public FrmJstj(int _tjlx)
        {
            InitializeComponent();

            tjlx = _tjlx;
            label1.Text += "（仅跨院）";
        }

        private void Init()
        {
            try
            {
                //收费员
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

                //科室
                tb = InstanceForm.BDatabase.GetDataTable(@"SELECT DEPT_ID AS ITEMCODE,NAME AS ITEMNAME FROM JC_DEPT_PROPERTY WHERE ZY_FLAG = 1 and jgbm=" + FrmMdiMain.Jgbm
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
                rowLx["NAME"] = "全部";
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

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = PubStaticFun.WaitCursor();

                ParameterEx[] parameters = new ParameterEx[15];
                parameters[0].Text = "@TYPE";
                parameters[0].Value = rbJsxx.Checked ? 0 : 1;

                parameters[1].Text = "@TJFS";
                if (rbJkrq.Checked)
                    parameters[1].Value = 0;
                else if (rbJsxx.Checked)
                    parameters[1].Value = 1;
                else
                    parameters[1].Value = 2;

                parameters[2].Text = "@rq1";
                parameters[2].Value = dtp1.Value.ToString();

                parameters[3].Text = "@rq2";
                parameters[3].Value = dtp2.Value.ToString();

                parameters[4].Text = "@jky";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue, "0"));

                parameters[5].Text = "@KS";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(cmbDept.SelectedValue, "0"));

                parameters[6].Text = "@BRLX";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbBrlx.SelectedValue, "0"));

                parameters[7].Text = "@JSLX";
                parameters[7].Value = Convert.ToInt32(Convertor.IsNull(cmbJslx.SelectedValue, "0"));

                parameters[8].Text = "@YBLX";
                parameters[8].Value = Convert.ToInt32(Convertor.IsNull(cmbYblx.SelectedValue, "0"));

                int jsfs = -1;//-1=全部0=中途结算1=正式结算2=欠费结算
                if (rbZcjs.Checked)
                {
                    jsfs = 1;
                }
                else if (rbZtjs.Checked)
                {
                    jsfs = 0;
                }
                else if (rbQfjs.Checked)
                {
                    jsfs = 2;
                }
                else
                {
                    jsfs = -1;
                }
                parameters[9].Text = "@JSFS";
                parameters[9].Value = jsfs;

                //Modify By Tany 2011-12-06 增加机构编码过滤
                parameters[10].Text = "@JGBM";
                parameters[10].Value = FrmMdiMain.Jgbm;

                //Modify By Tany 2011-12-06 是否将不同机构编码的数据分开多条显示0=不是 1=是
                parameters[11].Text = "@ISXSJGBM";
                parameters[11].Value = chkIsxsjgbm.Checked ? 1 : 0;

                //Modify By Tany 2012-05-07 统计类型0=普通 1=仅跨院
                parameters[12].Text = "@TJLX";
                parameters[12].Value = tjlx;

                //Modify By Kevin 2014-03-12
                //Begin
                parameters[13].Text = "@SBILLNO";
                parameters[13].Value = txtSBillNo.Text.Trim();

                parameters[14].Text = "@EBILLNO";
                parameters[14].Value = txtEBillNo.Text.Trim();
                //End

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_JSTJ", parameters, 180);

                AddRowtNo(tb);
                //if (tb.Columns.Contains("序号") && tb.Rows.Count > 0)
                //{
                //    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                //}
                this.dataGridView1.DataSource = tb;

                if (this.dataGridView1.Columns.Contains("INPATIENT_ID"))
                {
                    this.dataGridView1.Columns["INPATIENT_ID"].Visible = false;
                }
                if (this.dataGridView1.Columns.Contains("DISCHARGE_ID"))
                {
                    this.dataGridView1.Columns["DISCHARGE_ID"].Visible = false;
                }
                if (this.dataGridView1.Columns.Contains("DEPT_ID"))
                {
                    this.dataGridView1.Columns["DEPT_ID"].Visible = false;
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

        private void FrmJstj_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                //string rq = (rbJkrq.Checked ? rbJkrq.Text : rbSfrq.Text) + ":" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                //string sfy = "   收费员:" + cmbuser.Text;
                //string ks = "   科室:" + cmbDept.Text;
                //string brlx = "   病人类型:" + cmbBrlx.Text;
                //string jslx = "   结算类型:" + cmbJslx.Text;
                //string yblx = "";
                //if (Convert.ToInt32(this.cmbJslx.SelectedValue) == 1)
                //{
                //    yblx = "   医保类型:" + cmbYblx.Text;
                //}
                //string jsfs = "   结算方式:";//-1=全部0=中途结算1=正式结算2=欠费结算
                //if (rbZcjs.Checked)
                //{
                //    jsfs += rbZcjs.Text;
                //}
                //else if (rbZtjs.Checked)
                //{
                //    jsfs += rbZtjs.Text;
                //}
                //else if (rbQfjs.Checked)
                //{
                //    jsfs += rbQfjs.Text;
                //}
                //else
                //{
                //    jsfs += rbAll.Text;
                //}
                //string swhere = rq + sfy + ks + brlx + jslx + yblx + jsfs;


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

                string rq = (rbJkrq.Checked ? rbJkrq.Text : rbSfrq.Text) + ":" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                string sfy = "   收费员:" + cmbuser.Text;
                string ks = "   科室:" + cmbDept.Text;
                string brlx = "   病人类型:" + cmbBrlx.Text;
                string jslx = "   结算类型:" + cmbJslx.Text;
                string yblx = "";
                if (Convert.ToInt32(this.cmbJslx.SelectedValue) == 1)
                {
                    yblx = "   医保类型:" + cmbYblx.Text;
                }
                string jsfs = "   结算方式:";//-1=全部0=中途结算1=正式结算2=欠费结算
                if (rbZcjs.Checked)
                {
                    jsfs += rbZcjs.Text;
                }
                else if (rbZtjs.Checked)
                {
                    jsfs += rbZtjs.Text;
                }
                else if (rbQfjs.Checked)
                {
                    jsfs += rbQfjs.Text;
                }
                else
                {
                    jsfs += rbAll.Text;
                }
                string swhere = rq + sfy + ks + brlx + jslx + yblx + jsfs;
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

        private void CleanInfo()
        {
            dataGridView1.DataSource = null;
        }

        private void rbJkrq_CheckedChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void butdy_Click(object sender, EventArgs e)
        {
            FrmReportView rv;
            ParameterEx[] parameters;

            //Modify By Tany 2010-03-09 如果条件为全部，则不显示条件
            //查询条件
            string rq = (rbJkrq.Checked ? rbJkrq.Text : rbSfrq.Text) + ":" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
            string sfy = cmbuser.Text.Trim() == "全部" ? "" : ("收费员:" + cmbuser.Text.Trim());
            string ks = cmbDept.Text.Trim() == "全部" ? "" : ("科室:" + cmbDept.Text.Trim());
            string brlx = cmbBrlx.Text.Trim() == "全部" ? "" : ("病人类型:" + cmbBrlx.Text.Trim());
            string jslx = cmbJslx.Text.Trim() == "全部" ? "" : ("结算类型:" + cmbJslx.Text.Trim());
            string yblx = "";
            if (Convert.ToInt32(this.cmbJslx.SelectedValue) == 1)
            {
                yblx = cmbYblx.Text.Trim() == "全部" ? "" : ("医保类型:" + cmbYblx.Text.Trim());
            }
            string jsfs = "结算方式:";//-1=全部0=中途结算1=正式结算2=欠费结算
            if (rbZcjs.Checked)
            {
                jsfs += rbZcjs.Text;
            }
            else if (rbZtjs.Checked)
            {
                jsfs += rbZtjs.Text;
            }
            else if (rbQfjs.Checked)
            {
                jsfs += rbQfjs.Text;
            }
            else
            {
                jsfs = "";
            }
            string swhere = sfy + "   " + ks + "   " + brlx + "   " + jslx + "   " + yblx + "   " + jsfs;

            if (rbJsxx.Checked)
            {
                DataTable jsTb = (DataTable)dataGridView1.DataSource;

                if (jsTb != null && jsTb.Rows.Count > 0)
                {
                    parameters = new ParameterEx[4];
                    parameters[1].Text = "报表标题";
                    parameters[1].Value = Constant.HospitalName + "出纳交账报表（一）";
                    parameters[2].Text = "时间段";
                    parameters[2].Value = rq;
                    parameters[0].Text = "制表人";
                    parameters[0].Value = FrmMdiMain.CurrentUser.Name;
                    parameters[3].Text = "其他参数";
                    parameters[3].Value = swhere;

                    rv = new FrmReportView(jsTb, Constant.ApplicationDirectory + "\\report\\ZYGL_病人结算统计.rpt", parameters, false);
                    rv.Show();
                }
            }
            else
            {
                DataTable jsbrTb = (DataTable)dataGridView1.DataSource;

                if (jsbrTb != null && jsbrTb.Rows.Count > 0)
                {
                    parameters = new ParameterEx[4];
                    parameters[0].Text = "报表标题";
                    parameters[0].Value = Constant.HospitalName + "住院结算统计报表";
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

                        dr["住院号"] = jsbrTb.Rows[j]["住院号"];
                        dr["病人姓名"] = jsbrTb.Rows[j]["病人姓名"];
                        dr["票据号"] = jsbrTb.Rows[j]["票据号"];
                        dr["冲帐标志"] = jsbrTb.Rows[j]["冲帐标志"];
                        dr["住院科室"] = jsbrTb.Rows[j]["住院科室"];
                        dr["结算时间"] = jsbrTb.Rows[j]["结算时间"];
                        dr["结算类型"] = jsbrTb.Rows[j]["结算类型"];
                        dr["操作员"] = jsbrTb.Rows[j]["操作员"];
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

                    rv = new FrmReportView(dsTb, Constant.ApplicationDirectory + "\\report\\ZYGL_病人结算明细统计.rpt", parameters, false);
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
    }
}