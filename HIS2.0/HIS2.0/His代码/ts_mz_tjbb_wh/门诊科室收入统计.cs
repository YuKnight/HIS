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
    public partial class Frmkssrtj : Form  //Frmkssrtj
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private long Nrow = 0;//统计时发票记录张数
        private long Jkid = 0;//交款ID
        public Frmkssrtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            label1.Text = _chineseName;


        }

        private void Frmsk_jktj_Load(object sender, EventArgs e)
        {


            //FunAddComboBox.AddOperator(true, cmbuser);
            this.WindowState = FormWindowState.Maximized;

            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            chbSfrq.Checked = true;

            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                dtp1.Value = Convert.ToDateTime(dtp1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtp2.Value = Convert.ToDateTime(dtp2.Value.ToShortDateString() + " " + s[1]);
            }

            //cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            //if (cmbuser.SelectedValue == null) cmbuser.SelectedValue = "0";
            //if (cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
            //    this.cmbuser.SelectedValue = "0";
            cmbFG.Items.Add("列宽适应网格内容");
            cmbFG.Items.Add("列宽仅适应有数据的区域");
            cmbFG.SelectedIndex = 0;
            FullCmbSfDept(); 
            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            cbType.SelectedIndex = 0;// 默认选择经管项目
            cbJsfs.SelectedIndex = 0;
        }
        /// <summary>
        /// 填充收费科室下拉 add by zp 2013-05-23 株洲省直中医院需求
        /// </summary>
        private void FullCmbSfDept()
        {
            try
            {
                SystemCfg cfg1086 = new SystemCfg(1086);
                string sql = @"select dept_id,name from jc_dept_property where dept_id in (" + cfg1086.Config + ")";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                DataRow dr = dt.NewRow();
                dr["dept_id"] = "-1";
                dr["name"] = "所有收费科室";
                dt.Rows.InsertAt(dr, 0);
                this.Cmb_SfDept.DataSource = dt;
                this.Cmb_SfDept.DisplayMember = "name";
                this.Cmb_SfDept.ValueMember = "dept_id";
                this.Cmb_SfDept.SelectedIndex = 0;
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }
        }
        /// <summary>
        /// 统计   modify by zp  2013-05-24 存储过程新增入参 株洲省直中医院需求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ParameterEx[] parameters = new ParameterEx[8];
                    parameters[0].Text = "@rq1";
                    parameters[0].Value = dtp1.Value.ToString();

                    parameters[1].Text = "@rq2";
                    parameters[1].Value = dtp2.Value.ToString();

                    parameters[2].Text = "@type";
                    parameters[2].Value = cbType.SelectedIndex;//rdJg.Checked == true ? 0 : 1;

                    int _jsfs = cbJsfs.SelectedIndex;

                    parameters[3].Text = "@jsfs";
                    parameters[3].Value = _jsfs;

                    parameters[4].Text = "@jgbm";
                    parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                    parameters[5].Text = "@tjlx";
                    parameters[5].Value = _menuTag.Function_Name == "Fun_ts_mz_tjbb_kssrtj" ? 0 : 1; ;

                    parameters[6].Text = "@include_kdks";
                    parameters[6].Value = chkKdks.Checked ? 1 : 0;

                    parameters[7].Text = "@sfdeptid";
                    parameters[7].Value = this.Cmb_SfDept.SelectedValue.ToString().Trim() == "-1" ? "" : this.Cmb_SfDept.SelectedValue.ToString().Trim();
                    DataSet dset = new DataSet();
                    TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_SK_Kssrtj", parameters, dset, "sfmx", 30);
                    Fun.AddRowtNo(dset.Tables[0]);                 

                    this.dataGridView1.DataSource = dset.Tables[0];
                    
                }
                catch
                {
                    try
                    {
                        ParameterEx[] parameters = new ParameterEx[7];
                        parameters[0].Text = "@rq1";
                        parameters[0].Value = dtp1.Value.ToString();

                        parameters[1].Text = "@rq2";
                        parameters[1].Value = dtp2.Value.ToString();

                        parameters[2].Text = "@type";
                        parameters[2].Value = cbType.SelectedIndex;//rdJg.Checked == true ? 0 : 1;

                        int _jsfs = cbJsfs.SelectedIndex;

                        parameters[3].Text = "@jsfs";
                        parameters[3].Value = _jsfs;

                        parameters[4].Text = "@jgbm";
                        parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                        parameters[5].Text = "@tjlx";
                        parameters[5].Value = _menuTag.Function_Name == "Fun_ts_mz_tjbb_kssrtj" ? 0 : 1; ;

                        parameters[6].Text = "@include_kdks";
                        parameters[6].Value = chkKdks.Checked ? 1 : 0;

                        //parameters[7].Text = "@sfdeptid";
                        //parameters[7].Value = this.Cmb_SfDept.SelectedValue.ToString().Trim() == "-1" ? "" : this.Cmb_SfDept.SelectedValue.ToString().Trim();
                        DataSet dset = new DataSet();
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_SK_Kssrtj", parameters, dset, "sfmx", 30);
                        Fun.AddRowtNo(dset.Tables[0]);


                        this.dataGridView1.DataSource = dset.Tables[0];
                    }
                    catch
                    {

                        ParameterEx[] parameters = new ParameterEx[9];
                        parameters[0].Text = "@rq1";
                        parameters[0].Value = chbSfrq.Checked ? dtp1.Value.ToString() : "";

                        parameters[1].Text = "@rq2";
                        parameters[1].Value = chbSfrq.Checked ? dtp2.Value.ToString() : "";

                        parameters[2].Text = "@type";
                        parameters[2].Value = cbType.SelectedIndex;//rdJg.Checked == true ? 0 : 1;

                        int _jsfs = cbJsfs.SelectedIndex;

                        parameters[3].Text = "@jsfs";
                        parameters[3].Value = _jsfs;

                        parameters[4].Text = "@jgbm";
                        parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                        parameters[5].Text = "@tjlx";
                        parameters[5].Value = _menuTag.Function_Name == "Fun_ts_mz_tjbb_kssrtj" ? 0 : 1; ;

                        parameters[6].Text = "@include_kdks";
                        parameters[6].Value = chkKdks.Checked ? 1 : 0;

                        parameters[7].Text = "@jkrq1";
                        parameters[7].Value = ckbJkrq.Checked ? dtpBjksj.Value.ToString() : "";

                        parameters[8].Text = "@jkrq2";
                        parameters[8].Value = ckbJkrq.Checked ? dtpEjksj.Value.ToString() : "";

                        //parameters[7].Text = "@sfdeptid";
                        //parameters[7].Value = this.Cmb_SfDept.SelectedValue.ToString().Trim() == "-1" ? "" : this.Cmb_SfDept.SelectedValue.ToString().Trim();
                        DataSet dset = new DataSet();
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_SK_Kssrtj", parameters, dset, "sfmx", 30);
                        Fun.AddRowtNo(dset.Tables[0]);
                        this.dataGridView1.DataSource = dset.Tables[0];
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dataGridView1.Columns.Contains("排序码") == true)
                dataGridView1.Columns["排序码"].Visible = false;
            if (dataGridView1.Columns.Contains("科室代码") == true)
                dataGridView1.Columns["科室代码"].Visible = false;
            this.dataGridView1.Refresh();
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
                if (cbType.SelectedIndex == 0)
                    xm = "  统计分类:经管项目";
                else if (cbType.SelectedIndex == 1)
                    xm = "  统计分类:会计项目";
                else if (cbType.SelectedIndex == 2)
                    xm = "  统计分类:其他项目1";
                else if (cbType.SelectedIndex == 3)
                    xm = "  统计分类:其他项目2";
                bool bol = checkBox1.Checked;
                string swhere = "日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + xm + "  部门名称:" + cmbjgbm.Text; ;
                ts_jc_log.ExcelOper.cellValueAutoToString = false; //Add by zp 2013-11-04
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

        private void butprint_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
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

                string jsfs = cbJsfs.Text;

                //string ssql = rdJg.Checked == true ? "统计:按经管项目分类" : "统计:按会计项目分类";
                string xm = "";
                if (cbType.SelectedIndex == 0)
                    xm = "  统计分类:经管项目";
                else if (cbType.SelectedIndex == 1)
                    xm = "  统计分类:会计项目";
                else if (cbType.SelectedIndex == 2)
                    xm = "  统计分类:其他项目1";
                else if (cbType.SelectedIndex == 3)
                    xm = "  统计分类:其他项目2";
                parameters[2].Text = "备注";
                parameters[2].Value = dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString() + "  " + xm + " 部门名称:" + cmbjgbm.Text + " 结算方式:" + jsfs;

                parameters[3].Text = "现金大写";
                parameters[3].Value = "";

                TrasenFrame.Forms.FrmReportView f = null;
                if (cbType.SelectedIndex == 0)
                    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_科室收入报表(经管).rpt", parameters);
                else if (cbType.SelectedIndex == 1)
                    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_科室收入报表(会计).rpt", parameters);
                else
                    return;

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

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb != null)
                tb.Rows.Clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable tb = (DataTable)dataGridView1.DataSource;
            //    if (tb == null) return;
            //    if (dataGridView1.CurrentCell == null) return;

            //    int nrow = dataGridView1.CurrentCell.RowIndex;
            //    int ksdm = Convert.ToInt32(tb.Rows[nrow]["ksdm"]);
            //    ts_mz_tjbb.Frmkssrtj_mx frm = new Frmkssrtj_mx(_menuTag, _chineseName, _mdiParent);
            //    frm.dtp1.Value = dtp1.Value;
            //    frm.dtp2.Value = dtp2.Value;
            //    frm.cmbjgbm.SelectedValue = cmbjgbm.SelectedValue;
            //    frm.txtks.Text = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
            //    frm.txtks.Tag = ksdm.ToString();
            //    frm.btref_Click(sender, e);

            //    frm.txtks.Enabled = false;
            //    frm.cmbjgbm.Enabled = false;

            //    frm.ShowDialog();
            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

    }
}