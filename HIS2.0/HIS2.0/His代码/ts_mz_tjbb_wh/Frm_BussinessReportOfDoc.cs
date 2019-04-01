using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using TrasenFrame.Classes;
//using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;


namespace ts_mz_tjbb
{
    public partial class Frm_BussinessReportOfDoc : Form
    {
        private ClsParams _param;
        public Frm_BussinessReportOfDoc(ClsParams param)
        {
            this._param = param;
            InitializeComponent();
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = null;
                string ss = "";
                tb = (DataTable)this.dataGridView1.DataSource;
                ss = "科室医生业务收入情况";



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
                swhere = " 记费日期从:" + this._param.rq1.ToString() + "　到 " + this._param.rq2.ToString();


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

        private void Frm_BussinessReportOfDoc_Load(object sender, EventArgs e)
        {
             
        }

        private void Frm_BussinessReportOfDoc_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.dataGridView1.Left = 20;
            this.dataGridView1.Height=this.Height-60-this.butexcel.Height;
            this.butexcel.Left = this.dataGridView1.Left + this.dataGridView1.Width - this.butexcel.Width;
            this.butexcel.Top = this.dataGridView1.Top + this.Height + 20;
        }

        private void Frm_BussinessReportOfDoc_Shown(object sender, EventArgs e)
        {
            ShowReportData();
        }

        private void ShowReportData()
        {
            try
            {

                if (string.IsNullOrEmpty(this._param.itemStringOfCol))
                {
                    ParameterEx[] parameters = new ParameterEx[6];


                    parameters[0].Text = "@sourceType";
                    parameters[0].Value = this._param.sourceType;

                    parameters[1].Text = "@ksType";
                    parameters[1].Value = this._param.ksType;

                    parameters[2].Text = "@rq1";
                    parameters[2].Value = this._param.rq1;

                    parameters[3].Text = "@rq2";
                    parameters[3].Value = this._param.rq2;

                    parameters[4].Text = "@isZXKS";
                    parameters[4].Value = this._param.isZXKS;

                    parameters[5].Text = "@departmentID";
                    parameters[5].Value = this._param.departmentID;


                    DataSet dset = new DataSet();
                    if (this._param.itemCode == 0)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("report_BusinessIncomeReport_Drugs_doc", parameters, dset, "sfmx", 30);
                    }
                    else if (this._param.itemCode == 1)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("ReportBuessinessOfMedicalTechnology_doc", parameters, dset, "sfmx", 30);
                    }
                    else if (this._param.itemCode == 2)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("ReportBuessinessOfMediaclServer_doc", parameters, dset, "sfmx", 30);
                    }
                    Fun.AddRowtNo(dset.Tables[0]);
                    this.dataGridView1.DataSource = dset.Tables[0];
                    for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                    {
                        this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm")
                        {
                            this.dataGridView1.Columns[i].Visible = false;
                        }
                    }
                }
                else
                {
                    ParameterEx[] parameters = new ParameterEx[7];


                    parameters[0].Text = "@sourceType";
                    parameters[0].Value = this._param.sourceType;

                    parameters[1].Text = "@ksType";
                    parameters[1].Value = this._param.ksType;

                    parameters[2].Text = "@rq1";
                    parameters[2].Value = this._param.rq1;

                    parameters[3].Text = "@rq2";
                    parameters[3].Value = this._param.rq2;

                    parameters[4].Text = "@isZXKS";
                    parameters[4].Value = this._param.isZXKS;

                    parameters[5].Text = "@departmentID";
                    parameters[5].Value = this._param.departmentID;

                    parameters[6].Text = "@itemCode";
                    parameters[6].Value = this._param.itemStringOfCol;


                    DataSet dset = new DataSet();
                    if (this._param.itemCode == 0)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("report_BusinessIncomeReport_DrugItem_doc", parameters, dset, "sfmx", 30);
                    }
                    else if (this._param.itemCode == 1)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("ReportBuessinessOfMedicalTechnology_item_doc", parameters, dset, "sfmx", 30);
                    }
                    else if (this._param.itemCode == 2)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("ReportBuessinessOfMediaclServer_item_doc", parameters, dset, "sfmx", 30);
                    }
                    Fun.AddRowtNo(dset.Tables[0]);
                    this.dataGridView1.DataSource = dset.Tables[0];
                    for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                    {
                        this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm")
                        {
                            this.dataGridView1.Columns[i].Visible = false;
                        }
                    }
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}