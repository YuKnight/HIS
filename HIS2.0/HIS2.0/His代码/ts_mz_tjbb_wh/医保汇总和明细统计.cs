using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_mz_tjbb
{
    public partial class Frmybhzmxtj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmybhzmxtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            this.Text = chineseName;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "@jgbm";
                parameters[0].Value = Convertor.IsNull(cmbjgbm.SelectedValue, "0");

                parameters[1].Text = "@yblx";
                parameters[1].Value = Convertor.IsNull(cmbyblx.SelectedValue, "0");

                parameters[2].Text = "@rq1";
                parameters[2].Value = dtp1.Value.ToString();

                parameters[3].Text = "@rq2";
                parameters[3].Value = dtp2.Value.ToString();

                parameters[4].Text = "@sfy";
                parameters[4].Value = Convertor.IsNull(cmbsfy.SelectedValue, "0");

                parameters[5].Text = "@brxm";
                parameters[5].Value = txtbrxm.Text.Trim();

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_YB_JSTJ", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                Fun.AddRowtNo(dset.Tables[1]);
                dataGridView1.DataSource = dset.Tables[0];
                dataGridView2.DataSource = dset.Tables[1];

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


        private void Frmjzlscx_Load(object sender, EventArgs e)
        {

            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            FunAddComboBox.AddOperator(true, cmbsfy, InstanceForm.BDatabase);
            FunAddComboBox.AddYblx(true, 0, cmbyblx, InstanceForm.BDatabase);
            cmbsfy.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            if (cmbsfy.SelectedValue == null)
                cmbsfy.SelectedValue = "0";
            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                dtp1.Value = Convert.ToDateTime(dtp1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtp2.Value = Convert.ToDateTime(dtp2.Value.ToShortDateString() + " " + s[1]);
            }
            this.WindowState = FormWindowState.Maximized;
            //Add By Zj 2012-11-06 新增打印方式
            string ssql = @"select  1 as dyfs ,'按汇总情况打印' as name
                            union 
                            select  2 as dyfs ,'按明细情况打印' as name
                            union 
                            select  3 as dyfs ,'打印明细不分页' as name
                            union 
                            select  4 as dyfs ,'按收费员汇总' as name";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            cmbdyfs.ValueMember = "dyfs";
            cmbdyfs.DisplayMember = "NAME";
            cmbdyfs.DataSource = tb;
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

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string xm = "";

                string swhere = "";

                xm = "    部门:" + cmbjgbm.Text + "  医保类型:" + cmbyblx.Text + " 收费员:" + cmbsfy.Text + " 收费日期:" + dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString();
                swhere = xm;

                //写入行头
                DataTable tb = null;
                if (tabControl1.SelectedTab == tabPage1)
                    tb = (DataTable)this.dataGridView1.DataSource;
                else
                    tb = (DataTable)this.dataGridView2.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    //if (checkBox1.Checked == true)
                    //{
                    //    if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "科室" )
                    //    {
                    //        SumColCount = SumColCount + 1;
                    //        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                    //    }
                    //}
                    //else
                    //{
                    SumColCount = SumColCount + 1;
                    myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                    //}

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        //if (checkBox1.Checked == true)
                        //{
                        //    if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "科室" && tb.Columns[j].ColumnName != "医生")
                        //    {
                        //        ncol = ncol + 1;
                        //        myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                        //    }
                        //}
                        //else
                        //{
                        ncol = ncol + 1;
                        myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                        //}
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = Constant.HospitalName + "医保结算统计";
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

        private void butprinthz_Click(object sender, EventArgs e)
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


                ParameterEx[] parameters = new ParameterEx[5];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                string ss = "部门:" + cmbjgbm.Text;
                if (Convertor.IsNull(cmbyblx.SelectedValue, "0") != "0") ss = ss + " 医保类型:" + cmbyblx.Text.Trim();
                if (Convertor.IsNull(cmbsfy.SelectedValue, "0") != "0") ss = ss + " 收费员:" + cmbsfy.Text.Trim();
                ss = ss + " 收费日期:" + dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString();

                parameters[2].Text = "备注";
                parameters[2].Value = ss;

                parameters[3].Text = "现金大写";
                parameters[3].Value = "";

                parameters[4].Text = "操作员";
                parameters[4].Value = InstanceForm.BCurrentUser.Name;

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_医保结算统计(汇总).rpt", parameters);
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

        private void butprintmx_Click(object sender, EventArgs e)
        {
            if ( dataGridView2.DataSource == null )
                return;
            try
            {
                DataTable tbmx = (DataTable)dataGridView2.DataSource;

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
                    if (tbmx.Rows[nrow]["医保类型"].ToString() != "总计")
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

                }


                ParameterEx[] parameters = new ParameterEx[5];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                string ss = "部门:" + cmbjgbm.Text;
                if (Convertor.IsNull(cmbyblx.SelectedValue, "0") != "0") ss = ss + " 医保类型:" + cmbyblx.Text.Trim();
                if (Convertor.IsNull(cmbsfy.SelectedValue, "0") != "0") ss = ss + " 收费员:" + cmbsfy.Text.Trim();
                ss = ss + " 收费日期:" + dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString();

                parameters[2].Text = "备注";
                parameters[2].Value = ss;

                parameters[3].Text = "现金大写";
                parameters[3].Value = "";

                parameters[4].Text = "操作员";
                parameters[4].Value = InstanceForm.BCurrentUser.Name;

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_医保结算统计(明细).rpt", parameters);
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

        private void btnprintmxbfy_Click(object sender, EventArgs e)
        {
            if ( dataGridView2.DataSource == null )
                return;
            try
            {
                DataTable tbmx = (DataTable)dataGridView2.DataSource;

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


                ParameterEx[] parameters = new ParameterEx[1];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_医保结算统计(明细不分页).rpt", parameters);
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            int dyfs = Convert.ToInt32(cmbdyfs.SelectedValue);
            switch (dyfs)
            {
                case 1:
                    butprinthz_Click(sender, e);
                    break;
                case 2:
                    butprintmx_Click(sender, e);
                    break;
                case 3:
                    btnprintmxbfy_Click(sender, e);
                    break;
                case 4:
                    btnsfyhz_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void btnsfyhz_Click(object sender, EventArgs e)
        {
            if ( dataGridView2.DataSource == null )
                return;
            DataTable tb = (DataTable)dataGridView2.DataSource;

            string[] GroupbyField1 ={ "医保类型", "结算员" };
            string[] ComputeField1 ={ "结算金额", "帐户支付", "统筹支付", "其它支付", "现金支付" };
            string[] CField1 ={ "sum", "sum", "sum", "sum", "sum" };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = tb;
            DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
            if (tbcf1.Rows.Count == 0) { return; }
            tbcf1.Columns.Remove("发票号");
            tbcf1.Columns.Remove("姓名");
            tbcf1.Columns.Remove("结算时间");
            try
            {
                DataTable tbmx = tbcf1;

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


                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "条件";
                parameters[1].Value = "收费日期:" + dtp1.Value.ToString("yyyy-MM-dd HH:mm:ss") + " 到 " + dtp2.Value.ToString("yyyy-MM-dd HH:mm:ss");

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_医保结算统计(按收费员汇总).rpt", parameters);
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

        private void Frmybhzmxtj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
                btnprint_Click(sender, e);
            if (e.KeyCode == Keys.Q)
                this.Close();
            if (e.KeyCode == Keys.E)
                butexcel_Click(sender, e);

        }

    }
}