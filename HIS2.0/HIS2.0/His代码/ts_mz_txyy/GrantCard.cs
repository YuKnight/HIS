using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;



namespace ts_mz_txyy
{
    public partial class GrantCard : Form
    {
        public GrantCard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ksid = comboBox1.SelectedValue.ToString();
            string starttime = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endtime = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            GrantCardDAL.GrantCard(ksid,starttime,endtime,dataGridView1);

        }

        private void GrantCard_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.AutoGenerateColumns = false;
            GrantCardDAL.BindGHS(comboBox1);
        }

        public void DataToExcel(DataGridView m_DataView)
        {
            DataTable dt = m_DataView.DataSource as DataTable;
            try
            {
                if (dt == null || dt.Rows.Count <= 0)
                {
                    return;
                }

                this.Cursor = PubStaticFun.WaitCursor();
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
                int colCount = dt.Columns.Count;
                int RowCount = dt.Rows.Count;

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = comboBox1.Text+"挂号室发卡量统计";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount];
                // 获取列标题
                for (int i = 0; i <= colCount - 1; i++)
                {
                    objData[0, colIndex++] = dt.Columns[i].Caption;
                }
                // 获取数据

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= colCount - 1; j++)
                    {
                        objData[i + 1, colIndex++] = "" + dt.Rows[i][j].ToString().Trim();
                    }
                    Application.DoEvents();
                }

                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

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
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataToExcel(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
                return;

            DataTable dt = dataGridView1.DataSource as DataTable;
            ts_mz_txyy.DataSet1 Dset = new ts_mz_txyy.DataSet1();
            DataRow myrow;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                myrow = Dset.挂号室发卡量统计.NewRow();
                myrow["登记员"] = Convert.ToString(dt.Rows[i]["登记员"]);
                myrow["发卡量"] = Convert.ToString(dt.Rows[i]["发卡量"]);
                Dset.挂号室发卡量统计.Rows.Add(myrow);

            }
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Text = "yq";
            parameters[0].Value = comboBox1.Text;
            parameters[1].Text = "kssj";
            parameters[1].Value = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            parameters[2].Text = "jssj";
            parameters[2].Value = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            parameters[3].Text = "dyr";
            parameters[3].Value = InstanceForm.BCurrentUser.Name;

            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\挂号室发卡量统计.rpt", parameters, true);

            if (f.LoadReportSuccess)
            {
                f.Show();
            }
            else
                f.Dispose();
        }



    }
}