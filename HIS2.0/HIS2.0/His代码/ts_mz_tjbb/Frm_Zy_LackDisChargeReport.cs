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
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class Frm_Zy_LackDisChargeReport : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_Zy_LackDisChargeReport(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            label1.Text = _chineseName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Zy_LackDisChargeReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            AddInpatientType();

        }

        private void AddInpatientType()
        {
            comboBox1.Items.Add("全部类型");
            string sql = "select name from JC_BRLX";
            DataTable dt = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                    comboBox1.Items.Add(dt.Rows[i][0].ToString());
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        private void Frm_Zy_LackDisChargeReport_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
            this.dataGridView1.Height = this.Height - this.dataGridView1.Top - 40;
            this.label1.Left = (this.Width - this.label1.Width) / 2;
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            try
            {

                ParameterEx[] parameters = new ParameterEx[10];
                int ii = 0;



                parameters[ii].Text = "@rq1";
                parameters[ii].Value = dtpBjksj.Value.ToString();
                ++ii;

                parameters[ii].Text = "@rq2";
                parameters[ii].Value = dtpEjksj.Value.ToString();
                ++ii;

                parameters[ii].Text = "@userName";
                parameters[ii].Value = "";
                ++ii;

                parameters[ii].Text = "@dept";
                parameters[ii].Value = "";
                ++ii;

                parameters[ii].Text = "@inpatientType";
                parameters[ii].Value = comboBox1.Text;
                ++ii;

                parameters[ii].Text = "@ChargeType";
                parameters[ii].Value = 0;
                ++ii;

                parameters[ii].Text = "@BillNo";
                parameters[ii].Value = "";
                ++ii;

                parameters[ii].Text = "@LackNo";
                parameters[ii].Value =Decimal.Parse(textBox3.Text==""?"0":textBox3.Text);
                ++ii;

                parameters[ii].Text = "@zyh";
                parameters[ii].Value = textBox1.Text;
                ++ii;

                parameters[ii].Text = "@ReportType";
                parameters[ii].Value = 0;
                ++ii;

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("dbo_zy_LackDisChargeReport", parameters, dset, "sfmx", 60);


                Fun.AddRowtNo(dset.Tables[0]);
                DataTable dt = dset.Tables[0];

                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = dt;
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm" || this.dataGridView1.Columns[i].Name.ToLower() == "sort")
                    {
                        this.dataGridView1.Columns[i].Visible = false;
                    }
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetDataOfPrint()
        {
            try
            {

                ParameterEx[] parameters = new ParameterEx[10];
                int ii = 0;



                parameters[ii].Text = "@rq1";
                parameters[ii].Value = dtpBjksj.Value.ToString();
                ++ii;

                parameters[ii].Text = "@rq2";
                parameters[ii].Value = dtpEjksj.Value.ToString();
                ++ii;

                parameters[ii].Text = "@userName";
                parameters[ii].Value = "";
                ++ii;

                parameters[ii].Text = "@dept";
                parameters[ii].Value = "";
                ++ii;

                parameters[ii].Text = "@inpatientType";
                parameters[ii].Value = comboBox1.Text;
                ++ii;

                parameters[ii].Text = "@ChargeType";
                parameters[ii].Value = 0;
                ++ii;

                parameters[ii].Text = "@BillNo";
                parameters[ii].Value = "";
                ++ii;

                parameters[ii].Text = "@LackNo";
                parameters[ii].Value = Decimal.Parse(textBox3.Text == "" ? "0" : textBox3.Text);
                ++ii;

                parameters[ii].Text = "@zyh";
                parameters[ii].Value = textBox1.Text;
                ++ii;

                parameters[ii].Text = "@ReportType";
                parameters[ii].Value = 1;
                ++ii;

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("dbo_zy_LackDisChargeReport", parameters, dset, "sfmx", 60);


                Fun.AddRowtNo(dset.Tables[0]);
                DataTable dt = dset.Tables[0];
                return dt;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private void PrintReport()
        {
            try
            {
                DataTable tbmx = GetDataOfPrint();

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


                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "开始日期";
                parameters[0].Value = dtpBjksj.Value.ToString("yyyy-MM-dd");

                parameters[1].Text = "结束日期";
                parameters[1].Value = this.dtpEjksj.Value.ToString("yyyy-MM-dd");

                parameters[2].Text = "病人类型";
                parameters[2].Value = comboBox1.Text;


                TrasenFrame.Forms.FrmReportView f = null;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\住院欠费结算明细报表.rpt", parameters);

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

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = null;
                string ss = "";
                tb = (DataTable)this.dataGridView1.DataSource;
                ss = this._chineseName;



                // 创建Excel对象                   
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
                swhere = " 记费日期从:" + dtpBjksj.Value.ToString() + "　到 " + dtpEjksj.Value.ToString();


                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = ss;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 设置条件
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;

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
                        objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}