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
    public partial class Frmsk_xmsrtj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private long Nrow = 0;//统计时发票记录张数
        private long Jkid = 0;//交款ID
        private string lgje = "";//离休老干优惠金额
        private string xtje = "";//职工血透优惠金额
        public Frmsk_xmsrtj(MenuTag menuTag, string chineseName, Form mdiParent)
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

            cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            if (cmbuser.SelectedValue == null) cmbuser.SelectedValue = "0";
            if (cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
                this.cmbuser.SelectedValue = "0";

            if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_mzjk_xmsrtj")
            {
                lbluser.Text = "缴款员";
                lblrq.Text = "缴款日期";
                cmbyblx.Visible = false;
                label4.Visible = false;
            }


            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            string ssql = "select '全部' name,'-1' code  union all select '自费' name,'0' code union all select name,id from jc_yblx where delete_bit=0";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            cmbyblx.ValueMember = "CODE";
            cmbyblx.DisplayMember = "NAME";
            cmbyblx.DataSource = tb;
        }

       

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@sky";
                parameters[2].Value =Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue,"0")) ;


                parameters[3].Text = "@jgbm";
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                parameters[4].Text = "@yblx";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0"));

                DataSet dset = new DataSet();
                if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_mzjk_xmsrtj")
                    TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_JK_xmsrtj", parameters, dset, "sfmx", 30);
                else
                    TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_SK_xmsrtj", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);

                this.dataGridView1.DataSource =dset.Tables[0] ;

                lblfpje.Text = "";
                lblzfje.Text = "";
                lblyxzs.Text = "";
                lblfpzs.Text = "";
                lblxjzf.Text = "";
                lblylkzf.Text = "";
                lblybzf.Text = "";
                lblcwjz.Text = "";
                lblyhje.Text = "";
                lblsrje.Text = "";
                lblqfgz.Text = "";
                lblzpzf.Text = "";
                lblyjj.Text = "";
                lgje = "";//离休老干优惠金额
                xtje = "";//职工血透优惠金额
                //add by zouchihua 2013-4-27 增加诊疗卡押金
                try
                {
                    //Mod by Hxy 20141114 湖南省直中医院的存储过程与其他医院不同，故此处要取第四个table……
                    string strSQL = "SELECT NAME FROM dbo.JC_DEPT_PROPERTY WHERE DEPT_ID = 1";
                    DataTable dt = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(strSQL);
                    string HospitalName = "";
                    if (dt.Rows.Count >= 1)
                    {
                        HospitalName = dt.Rows[0]["Name"].ToString();
                    }
                    if (HospitalName == "湖南省直中医院")
                    {
                        if (dset.Tables[3].Rows.Count != 0)
                        {
                            txtBkje.Text = dset.Tables[3].Compute("sum(je)", "").ToString();
                            if (txtBkje.Text.Trim() == "")
                                txtBkje.Text = "0.00";
                        }
                    }
                    else
                    {
                        if (dset.Tables[2].Rows.Count != 0)
                        {

                            txtBkje.Text = dset.Tables[2].Compute("sum(je)", "").ToString();
                            if (txtBkje.Text.Trim() == "")
                                txtBkje.Text = "0.00";
                        }
                    }
                }
                catch (Exception ex) {  }
                if (dset.Tables[1].Rows.Count != 0)
                {
                    lblfpje.Text = dset.Tables[1].Rows[0]["发票金额"].ToString();
                    lblzfje.Text = dset.Tables[1].Rows[0]["废票金额"].ToString();
                    lblyxzs.Text = dset.Tables[1].Rows[0]["有效张数"].ToString();
                    lblfpzs.Text = dset.Tables[1].Rows[0]["废票张数"].ToString();
                    lblxjzf.Text = dset.Tables[1].Rows[0]["现金支付"].ToString();
                    lblzpzf.Text = dset.Tables[1].Rows[0]["支票支付"].ToString();
                    lblylkzf.Text = dset.Tables[1].Rows[0]["银联支付"].ToString();
                    lblybzf.Text = dset.Tables[1].Rows[0]["医保支付"].ToString();
                    lblcwjz.Text = dset.Tables[1].Rows[0]["财务记账"].ToString();
                    lblyhje.Text = dset.Tables[1].Rows[0]["优惠金额"].ToString();
                    lblsrje.Text = dset.Tables[1].Rows[0]["舍入金额"].ToString();
                    lblqfgz.Text = dset.Tables[1].Rows[0]["欠费挂账"].ToString();
                    lblyjj.Text = dset.Tables[1].Rows[0]["预收款"].ToString();
                                         
                }
                //add by tck 2013-08-23
                if (dset.Tables.Count > 2)
                {
                    if (dset.Tables[2].Rows.Count != 0)
                    {
                        // add by tck 2013-08-22
                        if (dset.Tables[2].Columns.Contains("离休老干"))
                            lgje = dset.Tables[2].Rows[0]["离休老干"].ToString();
                        if (dset.Tables[2].Columns.Contains("职工血透"))
                            xtje = dset.Tables[2].Rows[0]["职工血透"].ToString();
                    }
                }          
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;
                Guid  jkid =new Guid (Convertor.IsNull(tb.Rows[nrow]["交款id"], Guid.Empty.ToString()));
                int sfy = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["sfy"], "0"));
                if (jkid == Guid.Empty) return;
                ts_mzsf_grjkb.Frmsk_jktj f = new ts_mzsf_grjkb.Frmsk_jktj(_menuTag, "交款历史查询", _mdiParent);
                f.MdiParent = _mdiParent;
                f.Jkid = jkid;
                f.cmbuser.SelectedValue = sfy.ToString();
                f.butjk.Visible = false;
                f.buttj.Enabled = false;
                f.Show();
            }
            catch (System.Exception err)
            {
               // MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
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

                this.butexcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string xm = "";
                xm = "   收费员:" + cmbuser.Text;
                string swhere = "日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + xm;


                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    if (checkBox1.Checked == true)
                    {
                        if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "姓名")
                        {
                            SumColCount = SumColCount + 1;
                            myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                        }
                    }
                    else
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
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
                        if (checkBox1.Checked == true)
                        {
                            if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "姓名" )
                            {
                                ncol = ncol + 1;
                                myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                            }
                        }
                        else
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                        }
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
            if (dataGridView1.DataSource == null || ((DataTable)dataGridView1.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("没有数据！");
                return;
            }
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
                try
                {
                    //add by zouchihua 2013-5-6 
                    myrow["T47"] = this.txtBkje.Text;
                }
                catch { };
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



                ParameterEx[] parameters = new ParameterEx[26];
                parameters[0].Text = "结帐起始时间";
                parameters[0].Value = "";

                parameters[1].Text = "医院名称";
                parameters[1].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[2].Text = "收费员";
                parameters[2].Value = cmbuser.Text;

                parameters[3].Text = "挂号退费数";
                parameters[3].Value = "";

                parameters[4].Text = "挂号退费金额";
                parameters[4].Value = "";

                parameters[5].Text = "收费退费数";
                parameters[5].Value = "";

                parameters[6].Text = "收费退费金额";
                parameters[6].Value = "";

                parameters[7].Text = "填报日期";
                parameters[7].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[8].Text = "现金";
                parameters[8].Value = lblxjzf.Text.Trim();

                parameters[9].Text = "银联";
                parameters[9].Value = lblylkzf.Text.Trim();

                parameters[10].Text = "医保";
                parameters[10].Value =lblybzf.Text.Trim();

                parameters[11].Text = "财务记账";
                parameters[11].Value = lblcwjz.Text.Trim();

                parameters[12].Text = "欠费";
                parameters[12].Value =lblqfgz.Text.Trim();

                parameters[13].Text = "优惠";
                parameters[13].Value = lblyhje.Text.Trim();

                parameters[14].Text = "舍入";
                parameters[14].Value = lblsrje.Text.Trim();

                parameters[15].Text = "有效张数";
                parameters[15].Value = lblyxzs.Text.Trim()+"张";

                parameters[16].Text = "废票张数";
                parameters[16].Value = lblfpzs.Text.Trim()+"张";

                parameters[17].Text = "发票金额";
                parameters[17].Value =lblfpje.Text.Trim();

                parameters[18].Text = "现金大写";
                parameters[18].Value = "";

                parameters[19].Text = "备注";
                parameters[19].Value =lblrq.Text+":"+ dtp1.Value.ToString()+" 到:"+dtp2.Value.ToString()+"   收费员:"+cmbuser.Text.Trim()+"   部门名称:"+cmbjgbm.Text;

                parameters[20].Text = "废票金额";
                parameters[20].Value = lblzfje.Text.Trim();

                parameters[21].Text = "废票号集合";
                parameters[21].Value = "";

                parameters[22].Text = "支票";
                parameters[22].Value = lblzpzf.Text;

                parameters[23].Text = "预收款";
                parameters[23].Value = lblyjj.Text;

                //add by tck  2013-08-22
                parameters[24].Text = "离休老干";
                parameters[24].Value = lgje.ToString();

                parameters[25].Text = "职工血透";
                parameters[25].Value = xtje.ToString();

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_门诊收费项目及收入统计.rpt", parameters);
 
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
            this.dataGridView1.DataSource = null;
        }

        


    }
}