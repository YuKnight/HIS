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
    public partial class Frmsk_zffs : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmsk_zffs(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            
            
        }

        private void Frmxjsrtj_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
            this.WindowState = FormWindowState.Maximized;
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

            if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_mzjk_zffs")
            {
                label2.Text = "缴款日期";
                label4.Text = "缴款员";
                label1.Text = "门诊缴款(支付方式)分类统计";
            }
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@sky";
                parameters[2].Value =Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue,"0")) ;

                parameters[3].Text = "@jgbm";
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));


                //DataTable tb;
                //if (_menuTag.Function_Name=="Fun_ts_mz_tjbb_mzsk_zffs")
                //     tb=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_MZSF_TJ_SK_ZFFS", parameters, 30);
                //else
                //     tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_MZSF_TJ_JK_ZFFS", parameters, 30);
                //Fun.AddRowtNo(tb);
                //this.dataGridView1.DataSource = tb;


                DataSet dset = new DataSet();
                if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_mzsk_zffs")
                    TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_SK_ZFFS", parameters, dset, "sfmx", 30);
                else
                    TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_JK_ZFFS", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);

                this.dataGridView1.DataSource = dset.Tables[0];

                
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null || ((DataTable)dataGridView1.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("没有数据！");
                return;
            }
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butprint.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string xm = "";
                
                string swhere = "";

                xm = "    收费员:" + cmbuser.Text;
                swhere = "收费日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + xm;
                if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_mzjk_zffs")
                {
                    xm = "    缴款员:" + cmbuser.Text;
                    swhere = "缴款日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + xm;
                }

                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
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
                            myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                        //}
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = Constant.HospitalName + label1.Text;
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
                this.butprint.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null || ((DataTable)dataGridView1.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("没有数据！");
                return;
            }
            try
            {
                DataTable tbsk = (DataTable)dataGridView1.DataSource;
                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();
                DataRow myrow;
                for (int i = 0; i <= tbsk.Rows.Count - 1; i++)
                {

                    myrow = Dset.交款表.NewRow();
                    int x = i + 1;
                    myrow["序号"] = Convert.ToString(tbsk.Rows[i]["序号"]);
                    myrow["收费员"] = Convert.ToString(tbsk.Rows[i]["收费员"]);
                    //myrow["交款时间"] = Convert.ToString(tbsk.Rows[i]["缴款时间"]);
                    myrow["发票金额"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["发票金额"],"0")); 
                    myrow["有效张数"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["有效张数"],"0")); 
                    myrow["废票张数"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["废票张数"],"0")); 
                    myrow["现金支付"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["现金支付"],"0")); 
                    myrow["银联支付"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["银联支付"],"0"));
                    myrow["支票支付"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["支票支付"], "0")); 
                    myrow["医保支付"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["医保支付"],"0")); 
                    myrow["财务记账"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["财务记账"],"0")); 
                    myrow["欠费挂账"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["欠费挂账"],"0")); 
                    myrow["优惠金额"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["优惠金额"],"0"));
                    myrow["舍入金额"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["舍入金额"], "0")); 
                    if (tbsk.Columns.Contains("废票金额")==true)
                        myrow["作废金额"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["废票金额"], "0")); 
                    Dset.交款表.Rows.Add(myrow);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "备注";
                if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_mzjk_zffs")
                    parameters[2].Value ="缴款日期:"+ dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString() + "  缴款员:" + cmbuser.Text.Trim();
                else
                    parameters[2].Value = "收款日期:"+dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString() + "  收费员:" + cmbuser.Text.Trim();

                parameters[3].Text = "现金大写";
                parameters[3].Value = "";


                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_操作员收款汇总表.rpt", parameters);
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

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb!=null)
            tb.Rows.Clear();
        }

 
    }
}