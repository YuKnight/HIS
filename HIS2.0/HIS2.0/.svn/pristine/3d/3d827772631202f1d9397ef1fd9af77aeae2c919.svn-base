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
    public partial class Frmyjjmx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Guid Jkid = Guid.Empty;//交款ID
        public int yjjrow = 0;
        public int fpbrow = 0;
        public DataSet dset = new DataSet();

        public Frmyjjmx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            lbltitle.Text = _chineseName;

            dtpjsrq1.Enabled = true;
        }


        private void buttj_Click(object sender, EventArgs e)
        {

            try
            {

                ParameterEx[] parameters1 = new ParameterEx[3];

                parameters1[0].Text = "@KSRQ";
                parameters1[0].Value = dtpjsrq1.Value.ToString();

                parameters1[1].Text = "@JSRQ";
                parameters1[1].Value = dtpjsrq2.Value.ToString();

                parameters1[2].Text = "@sky";
                parameters1[2].Value = cmbsfy.SelectedValue;

                dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_MZSF_TJ_SK_TJ_YJJCX", parameters1, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);

                DataRow row = dset.Tables[0].NewRow();
                row["序号"] = "合计";
                row["金额"] = dset.Tables[0].Compute("sum(金额)", "");
                dset.Tables[0].Rows.Add(row);
                this.dataGridView1.DataSource = dset.Tables[0];

                return;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmyjjjk_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtpjsrq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpjsrq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            FunAddComboBox.AddOperator(true, cmbsfy, InstanceForm.BDatabase);

            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                dtpjsrq1.Value = Convert.ToDateTime(dtpjsrq1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtpjsrq2.Value = Convert.ToDateTime(dtpjsrq2.Value.ToShortDateString() + " " + s[1]);
            }

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



                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "填报人";
                parameters[2].Value = InstanceForm.BCurrentUser.Name;

                parameters[3].Text = "rq1";
                parameters[3].Value = dtpjsrq1.Value.ToString();

                parameters[4].Text = "rq2";
                parameters[4].Value = dtpjsrq2.Value.ToString();

                parameters[5].Text = "院区";
                parameters[5].Value = cmbjgbm.Text;

                bool bprint = chkprint.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_预交款收款明细表.rpt", parameters, bprint);

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
            if ( dataGridView1.DataSource == null )
                return;

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
                string swhere = " 日期从:" + dtpjsrq1.Value.ToString() + "　到 " + dtpjsrq2.Value.ToString();


                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "预交款明细查询";
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




    }
}