using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_zyhs_yzgl
{
    public partial class FrmCzhz : Form
    {
        public FrmCzhz()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 冲正数据访问
        /// </summary>
        CzDataAccess czDataAccess = new CzDataAccess();
        /// <summary>
        /// 科室
        /// </summary>
        DataTable tbdept = new DataTable();

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncx_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                //查询条件
                int deptid = Convert.ToInt32(this.combdept.SelectedValue);
                string starttime = this.dateTimePicker1.Value.ToShortDateString();
                string endtime = this.dateTimePicker2.Value.ToShortDateString();
                bool showxtcz = false;
                if (this.checkBox1.Checked)
                {
                    showxtcz = true;
                }
                DataTable tb = czDataAccess.GetCZStatistics(deptid, starttime, endtime, showxtcz);
                this.dataGridView1.DataSource = tb;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                #region 简单打印
                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }
                Excel.Application myExcel = new Excel.ApplicationClass(); //new Excel.Application();
                //关闭时不显示提示
                //myExcel.DefaultFilePath = "";
                //myExcel.DisplayAlerts = false;
                //myExcel.SheetsInNewWorkbook = 1;
                Excel.Workbook xlBook = myExcel.Application.Workbooks.Add(true);

                //查询条件
                string rq = "日期:" + this.dateTimePicker1.Value.ToShortDateString() + " 到 " + this.dateTimePicker2.Value.ToShortDateString();
                string ks = "科室：" + combdept.Text;

                string swhere = rq;


                //写入行头

                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    if (this.dataGridView1.Columns[j].Visible)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = "" + this.dataGridView1.Columns[j].HeaderText;
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
                        if (this.dataGridView1.Columns[j].Visible)
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                            //if (tb.Columns[j].ColumnName.IndexOf("比例") >= 0)
                            //{
                            //    myExcel.Cells[6 + i, ncol] = "'" + Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i][j].ToString().Trim()) * 100).ToString("0.00") + "%";
                            //}
                        }
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();//6
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();//6

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = TrasenFrame.Classes.Constant.HospitalName + "冲正统计表";
                myExcel.Cells[1, 1] = ss;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[2, 1] = ks.Trim();
                myExcel.get_Range(myExcel.Cells[2, 1], myExcel.Cells[2, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[2, 1], myExcel.Cells[2, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[2, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                myExcel.Cells[3, 1] = swhere.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //xlBook.SaveCopyAs("d:\\yy.xls");
                //让Excel文件可见
                myExcel.Visible = true;
                //myExcel.Workbooks.Close();
                if (xlBook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                    xlBook = null;

                }
                if (myExcel != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel);
                    myExcel = null;
                    //xlApp.Quit(); 

                }
                GC.Collect();

                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                //this.btExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void combdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btncx_Click(null, null);
        }

        private void FrmCzhz_Load(object sender, EventArgs e)
        {
           combdept.SelectedIndexChanged-=new EventHandler(combdept_SelectedIndexChanged);  
            this.WindowState = FormWindowState.Maximized;
            tbdept = czDataAccess.GetDeptInfo("");
            this.combdept.DisplayMember = "name";
            this.combdept.ValueMember = "id";
            this.combdept.DataSource = tbdept;
            //判断是否存在科室
            if (czDataAccess.IsExistWardDept(FrmMdiMain.CurrentDept.DeptId.ToString()))
            {
                this.combdept.SelectedValue = FrmMdiMain.CurrentDept.DeptId;
                this.combdept.Enabled = false;
            }
            else
            {
                this.combdept.SelectedValue = -1;
            }
            combdept.SelectedIndexChanged -= new EventHandler(combdept_SelectedIndexChanged);  
        }
    }
}