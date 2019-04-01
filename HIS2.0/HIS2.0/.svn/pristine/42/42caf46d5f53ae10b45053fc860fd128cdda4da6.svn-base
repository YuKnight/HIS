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
    public partial class FrmYbbrsrtj : Form
    {
        private DataTable bzfxTb = new DataTable();
        //Modify By Kevin 2013-11-18 记录是否有修改过界面值
        public int isModify = 0;

        public FrmYbbrsrtj()
        {
            InitializeComponent();

        }


        private void butquit_Click(object sender, EventArgs e)
        {
            //Modify By Kevin 2013-11-18 退出提示
            if (isModify == 1)
            {
                if (MessageBox.Show("病种分型已改变，请保存！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    return;
            }
            this.Close();
        }

        private void FrmYbbrsrtj_Load(object sender, EventArgs e)
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
                cmbJslx.SelectedValue = 1;

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

                //病种分型
                tb = InstanceForm.BDatabase.GetDataTable("SELECT ID,NAME FROM JC_BZFX ORDER BY ID");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得病种分型信息！", "提示");
                    return;
                }
                bzfxTb = tb.Copy();
                DataRow rowFx = tb.NewRow();
                rowFx["ID"] = -1;
                rowFx["NAME"] = "全部";
                tb.Rows.Add(rowFx);
                cmbBzfx.DisplayMember = "NAME";
                cmbBzfx.ValueMember = "ID";
                cmbBzfx.DataSource = tb;
                cmbBzfx.SelectedValue = -1;



                //Add By Kevin 2013-04-16 医生
                tb = InstanceForm.BDatabase.GetDataTable(@"SELECT a.EMPLOYEE_ID AS ID,NAME AS NAME
								FROM VI_ZY_VDOCTOR as a left join (select Employee_id, code  from  pub_user) b
								on a.Employee_Id = b.Employee_Id order by b.code");//Modify By Tany 2011-11-23 按数字码排序);
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得医生信息！", "提示");
                }
                DataRow rowYs = tb.NewRow();
                rowYs["ID"] = -1;
                rowYs["NAME"] = "全部";
                tb.Rows.Add(rowYs);
                cmbGCYS.DisplayMember = "NAME";
                cmbGCYS.ValueMember = "ID";
                cmbGCYS.DataSource = tb;
                cmbGCYS.SelectedValue = -1;


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

                //通过参数是否自动勾选管床医生
                SystemCfg cfg5094 = new SystemCfg(5094);
                if (cfg5094.Config == "1")
                    cbGCYS.Checked = true;
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
            //dataGridView1.DataSource = null;
            //Modify By Kevin 2013-12-03
            if (this.dataGridView1.Rows.Count > 0)
            {
                DataTable dt = (DataTable)this.dataGridView1.DataSource;
                dt.Rows.Clear();
                this.dataGridView1.DataSource = dt;
            }
            //Modify By Kevin 2013-12-02
            //input_dw.Visible = false;
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanInfo();
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

        private void buttj_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = PubStaticFun.WaitCursor();
                //Add By Kevin 2013-12-02 绑定DataGridView中的病种分型
                DataTable tbRow = InstanceForm.BDatabase.GetDataTable("SELECT ID,NAME FROM JC_BZFX ORDER BY ID");
                if (tbRow == null)
                {
                    MessageBox.Show("错误，未能取得病种分型信息！", "提示");
                    return;
                }
                DataRow rowFxDgv = tbRow.NewRow();
                rowFxDgv["ID"] = 0;
                rowFxDgv["NAME"] = " ";
                tbRow.Rows.Add(rowFxDgv);
                DataGridViewComboBoxColumn dbc = (DataGridViewComboBoxColumn)this.dataGridView1.Columns[12];
                dbc.ValueMember = "ID";
                dbc.DisplayMember = "NAME";
                dbc.ReadOnly = false;
                dbc.DataSource = tbRow;

                //Modify by Kevin 2013-04-12
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
                else if (rbYbjs.Checked)
                    tj_type = 6;
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

                int GCYS = 0;
                // int GCBZ = 0;
                if (cbGCYS.Checked == true)
                {
                    //if (Convert.ToInt32(cmbGCYS.SelectedValue) > 0)
                    //{
                    //    GCYS = Convert.ToInt32(cmbGCYS.SelectedValue);
                    //    // GCBZ = 1;
                    //}

                    //Modify By Kevin 2013-08-07
                    GCYS = Convert.ToInt32(Convertor.IsNull(cmbGCYS.SelectedValue, "0"));
                }

                parameters[10].Text = "@GCYS";
                parameters[10].Value = GCYS;

                //parameters[10].Text = "@ISGCYS";
                //parameters[10].Value = cbGCYS.Checked ? 1 : 0;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_YBBRSRTJ", parameters, 180);

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

                ////Modify By Kevin 2013-11-18
                //if (this.dataGridView1.Columns.Contains("BZFX"))
                //{
                //    this.dataGridView1.Columns["BZFX"].Visible = false;
                //}
                if (!rbJsrq.Checked)
                {
                    //if (this.dataGridView1.Columns.Contains("出院诊断"))
                    //{
                    //    this.dataGridView1.Columns["出院诊断"].Visible = false;
                    //}
                    //if (this.dataGridView1.Columns.Contains("出院日期"))
                    //{
                    //    this.dataGridView1.Columns["出院日期"].Visible = false;
                    //}
                    if (this.dataGridView1.Columns.Contains("结算日期"))
                    {
                        this.dataGridView1.Columns["结算日期"].Visible = false;
                    }
                    //if (this.dataGridView1.Columns.Contains("天数"))
                    //{
                    //    this.dataGridView1.Columns["天数"].Visible = false;
                    //}
                    //if (this.dataGridView1.Columns.Contains("平均天数"))
                    //{
                    //    this.dataGridView1.Columns["平均天数"].Visible = false;
                    //}
                }
                //if (GCBZ == 1)
                //{
                //    if (this.dataGridView1.Columns.Contains("Column1"))
                //    {
                //        this.dataGridView1.Columns["Column1"].HeaderText = "管床医生";
                //    }
                //}

                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    //add by tck 2014-05-06
                    if (dataGridView1.Rows[i].Cells["Column2"].Value.ToString().Contains("小计") || dataGridView1.Rows[i].Cells["Column2"].Value.ToString().Contains("总计"))
                    {
                        this.dataGridView1.Rows[i].Cells[12].Value = 0;
                        this.dataGridView1.Rows[i].ReadOnly = true;

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

                //Modify By Kevin 2014-02-08
                //Excel.Application myExcel = new Excel.Application();

                //myExcel.Application.Workbooks.Add(true);

                //查询条件
                string type = "";
                //if (rbJg.Checked)
                //    type = "统计项目:" + rbJg.Text;
                //else if(rbKj.Checked)
                //    type = "统计项目:" + rbKj.Text;
                //else
                //    type = "统计项目:" + rbYb.Text;

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
                else if (rbYbjs.Checked)
                    tj_type = "    统计日期方式:" + rbYbjs.Text;

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

                string swhere = type + ks + brlx + bzfx + jslx + yblx + tj_type + rq;


                //Modify By Kevin 2014-02-08
                //写入行头

                /*
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
                            myExcel.Cells[6 + i, ncol] = tb.Rows[i][j].ToString().Trim();
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
                 * */

                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + this.label1.Text.ToString(), swhere, true, true, false, false);

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

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            //Modify By Kevin 2013-12-02
            /*
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                int ncol = dataGridView1.CurrentCell.ColumnIndex;

                if (nrow > dataGridView1.Rows.Count) return;
                
                if (this.dataGridView1.Columns[ncol].Name == "病种分型" && new Guid(Convertor.IsNull(tb.Rows[nrow]["inpatient_id"], Guid.Empty.ToString())) != Guid.Empty)
                {
                    input_dw.Visible = true;
                    input_dw.Show();
                    //Modify By Kevin 2013-11-18 增加病种分型绑定空值
                    //Modify By Kevin 2013-11-28 清空空值在绑定
                    RemoveIsNullOrEmpty(bzfxTb);
                    DataRow row = bzfxTb.NewRow();
                    row["id"] = 0;
                    row["name"] = "";
                    bzfxTb.Rows.Add(row);
                    input_dw.DisplayMember = "name";
                    input_dw.ValueMember = "id";
                    input_dw.DataSource = bzfxTb;
                    input_dw.SelectedValue = 0;

                    //if (tb.Rows[nrow]["病种分型"].ToString() != "")
                    //    input_dw.Text = tb.Rows[nrow]["病种分型"].ToString();

                    input_dw.Top = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Top + dataGridView1.Top;
                    input_dw.Left = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Left + dataGridView1.Left;
                    input_dw.Width = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Width;
                    input_dw.Focus();
                }
                else
                {
                    input_dw.Visible = false;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             * */
            isModify = 1;
        }

        //Modify By Kevin 2013-12-02
        /*
        private void input_dw_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Modify By Kevin 2013-11-18 修改界面值

            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            int nrow = dataGridView1.CurrentCell.RowIndex;
            int ncol = dataGridView1.CurrentCell.ColumnIndex;
            //Modify By Kevin 2013-11-28 如果为空就不绑定病种分型
            if (Convertor.IsNull(input_dw.SelectedValue.ToString(), "0") != "0")
            {
                this.dataGridView1.Rows[nrow].Cells["BZFX"].Value = input_dw.SelectedValue.ToString();
            }

            isModify = 1;

            
            //try
            //{
            //    DataTable tb = (DataTable)this.dataGridView1.DataSource;
            //    int nrow = dataGridView1.CurrentCell.RowIndex;
            //    int ncol = dataGridView1.CurrentCell.ColumnIndex;

            //    if (nrow > dataGridView1.Rows.Count)
            //        return;

            //    if (input_dw.SelectedIndex < 0)
            //        return;

            //    if (tb.Rows[nrow]["病种分型"].ToString().Trim() == input_dw.Text.Trim())
            //        return;

            //    tb.Rows[nrow]["病种分型"] = input_dw.Text;

            //    if (input_dw.Visible)
            //    {
            //        Guid _inpatientid = new Guid(Convertor.IsNull(tb.Rows[nrow]["inpatient_id"], Guid.Empty.ToString()));
            //        if (this.dataGridView1.Columns[ncol].Name == "病种分型" && _inpatientid != Guid.Empty)
            //        {
            //            FrmMdiMain.Database.DoCommand("update zy_inpatient set bzfx=" + input_dw.SelectedValue.ToString() + " where inpatient_id='" + _inpatientid + "'");
            //        }
            //        return;
            //    }
            //    input_dw.Visible = true;
            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
           
        }
        **/

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            //Modify By Kevin 2013-12-02
            //input_dw.Visible = false;
        }

        private void btUpdateBzfx_Click(object sender, EventArgs e)
        {
            if (bzfxTb == null || bzfxTb.Rows.Count == 0)
            {
                MessageBox.Show("没有找到病种分型信息！");
                return;
            }

            //Modify By Kevin 2013-11-18 修改过界面值
            isModify = 1;

            ContextMenuStrip cms = new ContextMenuStrip();
            for (int i = 0; i < bzfxTb.Rows.Count; i++)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = bzfxTb.Rows[i]["name"].ToString().Trim();
                tsmi.Tag = bzfxTb.Rows[i]["id"].ToString().Trim();
                tsmi.Click += new EventHandler(tsmi_Click);

                cms.Items.Add(tsmi);
            }

            Point pp = new Point(btUpdateBzfx.Location.X, btUpdateBzfx.Location.Y + btUpdateBzfx.Height);

            cms.Show(btUpdateBzfx.Parent, pp);
        }

        private void tsmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            if (tsmi.Tag == null)
            {
                return;
            }

            DataTable tb = (DataTable)this.dataGridView1.DataSource;

            if (tb == null || tb.Rows.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("是否将列表中的病人病种分型信息全部更新成【" + tsmi.Text.ToString().Trim() + "】", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    Guid _inpatientid = new Guid(Convertor.IsNull(tb.Rows[i]["inpatient_id"], Guid.Empty.ToString()));
                    if (_inpatientid != Guid.Empty)
                    {
                        FrmMdiMain.Database.DoCommand("update zy_inpatient set bzfx=" + tsmi.Tag.ToString() + " where inpatient_id='" + _inpatientid + "'");
                    }
                }

                MessageBox.Show("更新完成！");
                buttj_Click(null, null);
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

        private void cbGCYS_CheckedChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        //Modify By Kevin 2013-11-18 保存病种分型
        private void btSaveBzfx_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
                return;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Guid _inpatientid = new Guid(Convertor.IsNull(dataGridView1.Rows[i].Cells["inpatient_id"].Value.ToString(), Guid.Empty.ToString()));
                int _bzfx = Convert.ToInt32(Convertor.IsNull(dataGridView1.Rows[i].Cells[12].Value.ToString(), "0"));
                if (_inpatientid != Guid.Empty)
                {
                    FrmMdiMain.Database.DoCommand(String.Format("update zy_inpatient set bzfx={0} where inpatient_id='{1}'", _bzfx, _inpatientid));
                }
            }

            isModify = 2;

            MessageBox.Show("更新完成！");
            buttj_Click(null, null);
        }

        //Modify By Kevin 2013-11-28 循坏清空空行
        public void RemoveIsNullOrEmpty(DataTable tb)
        {
            List<DataRow> removeList = new List<DataRow>();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                bool rowIsNull = true;
                //for(int j=0; i< tb.Columns.Count -1;j++)
                //{
                //    if(tb.Rows[i][j].ToString().Trim() != "")
                //        rowIsNull = false;
                //}
                if (tb.Rows[i][1].ToString().Trim() != "")
                    rowIsNull = false;
                if (rowIsNull)
                {
                    removeList.Add(tb.Rows[i]);
                }
            }
            for (int i = 0; i < removeList.Count; i++)
            {
                tb.Rows.Remove(removeList[i]);
            }
        }

    }
}
