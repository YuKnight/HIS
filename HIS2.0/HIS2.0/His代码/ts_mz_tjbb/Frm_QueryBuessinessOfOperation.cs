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
    public partial class Frm_QueryBuessinessOfOperation : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_QueryBuessinessOfOperation(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            label1.Text = _chineseName;
        }

        private void Frm_QueryBuessinessOfOperation_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            cmbSource.SelectedIndex = 0;
        }

        private void Frm_QueryBuessinessOfOperation_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
            this.dataGridView1.Height = this.Height - this.dataGridView1.Top - 40;
            this.label1.Left = (this.Width - this.label1.Width) / 2;
        }

        private void butprint_Click(object sender, EventArgs e)
        {

        }

        private void buttj_Click(object sender, EventArgs e)
        {
            GetData();
        }



        private void GetData()
        {
            try
            {
                int i = 0;

                ParameterEx[] parameters = new ParameterEx[5];

                
                parameters[i].Text = "@rq1";
                parameters[i].Value = dtpBjksj.Value.ToString();
                ++i;

                parameters[i].Text = "@rq2";
                parameters[i].Value = dtpEjksj.Value.ToString();
                ++i;

                parameters[i].Text = "@sourceType";
                parameters[i].Value = cmbSource.SelectedIndex;
                ++i;

                parameters[i].Text = "@itemArr";
                parameters[i].Value = "'46','57','53','22','42','63','09','21','28','36','64','44'";
                ++i;

                parameters[i].Text = "@deptArr";
                parameters[i].Value = "23";

        

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_QueryBuessinessOfOperation", parameters, dset, "sfmx", 60);


                Fun.AddRowtNo(dset.Tables[0]);
                DataTable dt = dset.Tables[0];

                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = dt;
                for (i = 0; i < this.dataGridView1.Columns.Count; i++)
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