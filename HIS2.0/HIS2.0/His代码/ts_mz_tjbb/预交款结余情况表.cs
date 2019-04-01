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
using Ts_zyys_public;
using TrasenFrame.Forms;
namespace ts_mz_tjbb
{
    public partial class Frmyjjjyqkb : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Guid Jkid = Guid.Empty;//交款ID
        public int yjjrow = 0;
        public int fpbrow = 0;
        public DataSet dset = new DataSet();

        public Frmyjjjyqkb(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.Text = _chineseName;


        }


        private void buttj_Click(object sender, EventArgs e)
        {

            try
            {
                if (chkbkrq.Checked == false
                    && chkye.Checked == false && chkdj.Checked == false && chkgs.Checked == false &&
                        txtjtdz.Text.Trim() == "" && txtgzdw.Text.Trim() == ""
              )
                {
                    MessageBox.Show("检索的范围太大,请选择条件", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ParameterEx[] parameters = new ParameterEx[21];

                parameters[0].Text = "@klx";
                parameters[0].Value = 0;

                parameters[1].Text = "@kh";
                parameters[1].Value = "";

                parameters[2].Text = "@brxm";
                parameters[2].Value = "";

                parameters[3].Text = "@BRLXFS";
                parameters[3].Value = "";

                parameters[4].Text = "@BRLX";
                parameters[4].Value = 0; ;

                parameters[5].Text = "@gj";
                parameters[5].Value = "";

                parameters[6].Text = "@mz";
                parameters[6].Value = "";

                parameters[7].Text = "@sfzh";
                parameters[7].Value = "";

                parameters[8].Text = "@cblx";
                parameters[8].Value = 0;

                parameters[9].Text = "@zy";
                parameters[9].Value = "";

                parameters[10].Text = "@csdz";
                parameters[10].Value = "";

                parameters[11].Text = "@jtdz";
                parameters[11].Value = txtjtdz.Text.Trim();

                parameters[12].Text = "@gzdw";
                parameters[12].Value = txtgzdw.Text.Trim();

                parameters[13].Text = "@DJSJ1";
                parameters[13].Value = chkbkrq.Checked == true ? dtpjsrq1.Value.ToString() : "";

                parameters[14].Text = "@DJSJ2";
                parameters[14].Value = chkbkrq.Checked == true ? dtpjsrq2.Value.ToString() : "";

                parameters[15].Text = "@CSRQ1";
                parameters[15].Value = "";

                parameters[16].Text = "@CSRQ2";
                parameters[16].Value = "";

                parameters[17].Text = "@djy";
                parameters[17].Value = 0;

                parameters[18].Text = "@BYE";
                parameters[18].Value = chkye.Checked == true ? 1 : 0;

                parameters[19].Text = "@BDJ";
                parameters[19].Value = chkdj.Checked == true ? 1 : 0;

                parameters[20].Text = "@BGS";
                parameters[20].Value = chkgs.Checked == true ? 1 : 0;

                dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_MZSF_CX_BRXX_JCQK", parameters, dset, "sfmx", 30);

                Fun.AddRowtNo(dset.Tables[0]);
                this.dataGridView1.DataSource = dset.Tables[0];

                lblbkzs.Text = dset.Tables[0].Rows.Count.ToString();
                lblljcr.Text = dset.Tables[0].Compute("sum(累计存入)", "").ToString();
                lblljxf.Text = dset.Tables[0].Compute("sum(累计消费)", "").ToString();
                lbljcje.Text = dset.Tables[0].Compute("sum(卡余额)", "").ToString();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmyjjjk_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;


            //Add By Zj 2012-10-26
            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                dtpjsrq1.Value = Convert.ToDateTime(dtpjsrq1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtpjsrq2.Value = Convert.ToDateTime(dtpjsrq2.Value.ToShortDateString() + " " + s[1]);
            }

            //dtpjsrq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            //dtpjsrq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            dtpjsrq1.Enabled = false;//Add By Zj 2012-04-19 
            dtpjsrq2.Enabled = false;
        }


        private void butprint_pos_Click(object sender, EventArgs e)
        {

            try
            {

                DataTable tbmx = dset.Tables[0];

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                int x = 0;
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    //if (dataGridView1.Columns[i].Visible == true)
                    //{
                    x = x + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                    //}
                }
                Dset.收费项目.Rows.Add(myrow);

                x = 0;
                for (int nrow = 0; nrow <= tbmx.Rows.Count - 2; nrow++)
                {
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        //if (dataGridView1.Columns[i].Visible == true)
                        //{
                        x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                        //}
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }



                ParameterEx[] parameters = new ParameterEx[12];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "填报人";
                parameters[2].Value = InstanceForm.BCurrentUser.Name;

                parameters[3].Text = "rq1";
                parameters[3].Value = chkbkrq.Checked == true ? dtpjsrq1.Value.ToString() : "";

                parameters[4].Text = "rq2";
                parameters[4].Value = chkbkrq.Checked == true ? dtpjsrq2.Value.ToString() : "";

                parameters[5].Text = "工作单位";
                parameters[5].Value = txtgzdw.Text;

                parameters[6].Text = "家庭地址";
                parameters[6].Value = txtjtdz.Text;

                string zt = "";
                if (chkye.Checked == true) zt = "有余额";
                if (chkdj.Checked == true) zt = zt + " 已冻结";
                if (chkgs.Checked == true) zt = zt + " 已挂失";
                parameters[7].Text = "其它";
                parameters[7].Value = "状态: " + zt;

                parameters[8].Text = "办卡张数";
                parameters[8].Value = lblbkzs.Text;

                parameters[9].Text = "累计存入";
                parameters[9].Value = lblljcr.Text;

                parameters[10].Text = "累计消费";
                parameters[10].Value = lblljxf.Text;

                parameters[11].Text = "结余金额";
                parameters[11].Value = lbljcje.Text;

                bool bprint = chkprint.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_预交款结余情况表.rpt", parameters, bprint);

                if (f.LoadReportSuccess)
                {
                    f.Show();
                }
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                // 创建Excel对象                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count + 1;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    colCount = colCount + 1;
                }


                //查询条件
                string swhere = "";
                if (chkbkrq.Checked == true)
                    swhere = " 办卡日期从:" + dtpjsrq1.Value.ToString() + "　到 " + dtpjsrq2.Value.ToString();
                if (txtgzdw.Text.Trim() != "")
                    swhere = swhere + " 工作单位:" + txtgzdw.Text.Trim();
                if (txtjtdz.Text.Trim() != "")
                    swhere = swhere + " 家庭地址:" + txtjtdz.Text.Trim();

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "预交款结余表";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 设置条件
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;
                //xlApp.ActiveCell.FormulaR1C1 = swhere;
                //xlApp.ActiveCell.Font.Size = 20;
                //xlApp.ActiveCell.Font.Bold = true;
                //xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    objData[1, colIndex++] = tb.Columns[i].Caption;
                }
                // 获取数据
                objData[0, 0] = swhere;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        //if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width>0)
                        //{
                        if (tb.Columns[j].Caption == "门诊号")
                            objData[i + 2, colIndex++] = "'" + tb.Rows[i][j].ToString();
                        else
                            objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                        //}
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkbkrq_CheckedChanged(object sender, EventArgs e)
        {
            dtpjsrq1.Enabled = chkbkrq.Checked == true ? true : false;
            dtpjsrq2.Enabled = chkbkrq.Checked == true ? true : false;
        }




    }
}