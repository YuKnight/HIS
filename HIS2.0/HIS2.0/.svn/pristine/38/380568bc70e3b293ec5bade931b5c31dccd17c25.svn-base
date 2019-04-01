using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using System.Collections;
namespace ts_zyhs_jyddy
{
    public partial class FrmJydYdyhz : Form
    {
        public FrmJydYdyhz()
        {
            InitializeComponent();
        }

        private void FrmJydYdyhz_Load(object sender, EventArgs e)
        {
           
        }

        private void btncx_Click(object sender, EventArgs e)
        {
            string sql = " select e.BRXM 病人姓名 ,c.BBMC 标本名称,SQNR 所作项目, OPER_CODE 接收人,SUBMISSION 送标本人 "
                    + "    from ZY_JY_PRINT a  join LS_AS_BARCODE b    "
                    + "   on cast(a.ORDER_ID as  varchar(36))=cast(b.ORDER_ID as varchar(36)) and [TYPE]=2  "
                    + "   join YJ_ZYSQ c on a.ORDER_ID=c.YZID  "
                    + "   join ZY_INPATIENT d on d.INPATIENT_ID=a.INPATIENT_ID   "
                    + "   join YY_BRXX  e on d.PATIENT_ID=e.BRXXID   "
                   + "   where c.BJLDYBZ=1  ";
           
            sql += " and  SQRQ >='" + this.dateTimePicker1.Value.ToShortDateString() + " 00:00:00'  and SQRQ<='" + this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59'";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            this.dataGridView1.DataSource = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTabletoExcel((DataTable)this.dataGridView1.DataSource, "d:\\dd.asv");
            return;
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
                string ks = "";

                string swhere = rq + ks;


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
                string ss = TrasenFrame.Classes.Constant.HospitalName + " 检验单汇总表";
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
        public Excel.Application m_xlApp = null;


        /// <summary>   
        /// 将DataTable数据导出到Excel表   
        /// </summary>   
        /// <param name="tmpDataTable">要导出的DataTable</param>   
        /// <param name="strFileName">Excel的保存路径及名称</param>   
        public void DataTabletoExcel(System.Data.DataTable tmpDataTable, string strFileName)
        {
            if (tmpDataTable == null)
            {
                return;
            }
            long rowNum = tmpDataTable.Rows.Count;//行数   
            int columnNum = tmpDataTable.Columns.Count;//列数   
            Excel.Application m_xlApp = new Excel.Application();
            m_xlApp.DisplayAlerts = true;//不显示更改提示   
            m_xlApp.Visible = true;//false;//

            Excel.Workbooks workbooks = m_xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1   
            //worksheet.SetBackgroundPicture("d:\\26.jpg");
            try
            {
                //查询条件
                string rq = "日期:" + this.dateTimePicker1.Value.ToShortDateString() + " 到 " + this.dateTimePicker2.Value.ToShortDateString();
                string ks = "";

                string swhere = rq + ks;
                int SumColCount = tmpDataTable.Columns.Count;

                //for (int j = 0; j < tmpDataTable.Columns.Count; j++)
                //{
                //    if (this.dataGridView1.Columns[j].Visible)
                //    {
                //        SumColCount = SumColCount + 1;
                //        m_xlApp.Cells[5, SumColCount] = "" + tmpDataTable.Columns[j].Caption;
                //    }
                //}

                //报表名称
                string ss = TrasenFrame.Classes.Constant.HospitalName + "已打印检验单表";
                m_xlApp.Cells[1, 1] = ss;
                m_xlApp.get_Range(m_xlApp.Cells[1, 1], m_xlApp.Cells[1, SumColCount]).Font.Bold = true;
                m_xlApp.get_Range(m_xlApp.Cells[1, 1], m_xlApp.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                m_xlApp.get_Range(m_xlApp.Cells[1, 1], m_xlApp.Cells[1, SumColCount]).Select();
                m_xlApp.get_Range(m_xlApp.Cells[1, 1], m_xlApp.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                m_xlApp.Cells[3, 1] = swhere.Trim();
                m_xlApp.get_Range(m_xlApp.Cells[3, 1], m_xlApp.Cells[3, SumColCount]).Font.Size = 10;
                m_xlApp.get_Range(m_xlApp.Cells[3, 1], m_xlApp.Cells[3, SumColCount]).Select();
                m_xlApp.get_Range(m_xlApp.Cells[3, 1], m_xlApp.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;




                if (rowNum > 65536)//单张Excel表格最大行数   
                {
                    long pageRows = 65535;//定义每页显示的行数,行数必须小于65536   
                    int scount = (int)(rowNum / pageRows);//导出数据生成的表单数   
                    if (scount * pageRows < rowNum)//当总行数不被pageRows整除时，经过四舍五入可能页数不准   
                    {
                        scount = scount + 1;
                    }
                    for (int sc = 1; sc <= scount; sc++)
                    {
                        if (sc > 1)
                        {
                            object missing = System.Reflection.Missing.Value;
                            worksheet = (Excel.Worksheet)workbook.Worksheets.Add(
                                        missing, missing, missing, missing);//添加一个sheet   
                        }
                        else
                        {
                            worksheet = (Excel.Worksheet)workbook.Worksheets[sc];//取得sheet1   
                        }
                        string[,] datas = new string[pageRows + 1, columnNum];

                        for (int i = 0; i < columnNum; i++) //写入字段   
                        {
                            datas[0, i] = tmpDataTable.Columns[i].Caption;//表头信息   
                        }
                        Excel.Range range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, columnNum]);
                        range.Interior.ColorIndex = 15;//15代表灰色   
                        range.Font.Bold = true;
                        range.Font.Size = 9;

                        int init = int.Parse(((sc - 1) * pageRows).ToString());
                        int r = 0;
                        int index = 0;
                        int result;
                        if (pageRows * sc >= rowNum)
                        {
                            result = (int)rowNum;
                        }
                        else
                        {
                            result = int.Parse((pageRows * sc).ToString());
                        }

                        for (r = init; r < result; r++)
                        {
                            index = index + 1;
                            for (int i = 0; i < columnNum; i++)
                            {
                                object obj = tmpDataTable.Rows[r][tmpDataTable.Columns[i].ToString()];
                                datas[index, i] = obj == null ? "" : "'" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式   
                            }
                            System.Windows.Forms.Application.DoEvents();
                            //添加进度条   
                        }

                        Excel.Range fchR = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[index + 5, columnNum]);
                        fchR.Value2 = datas;
                        worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。   
                        m_xlApp.WindowState = Excel.XlWindowState.xlMaximized;//Sheet表最大化   
                        range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[index + 5, columnNum]);
                        //range.Interior.ColorIndex = 15;//15代表灰色   
                        range.Font.Size = 9;
                        range.RowHeight = 14.25;
                        range.Borders.LineStyle = 1;
                        range.HorizontalAlignment = 1;
                    }
                }
                else
                {
                    string[,] datas = new string[rowNum + 1, columnNum];
                    for (int i = 0; i < columnNum; i++) //写入字段   
                    {
                        datas[0, i] = tmpDataTable.Columns[i].Caption;
                    }
                    Excel.Range range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, columnNum]);
                    range.Interior.ColorIndex = 15;//15代表灰色   
                    range.Font.Bold = true;
                    range.Font.Size = 9;

                    int r = 0;
                    for (r = 0; r < rowNum; r++)
                    {
                        for (int i = 0; i < columnNum; i++)
                        {
                            object obj = tmpDataTable.Rows[r][tmpDataTable.Columns[i].ToString()];
                            datas[r + 1, i] = obj == null ? "" : "'" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式   
                        }
                        System.Windows.Forms.Application.DoEvents();
                        //添加进度条   
                    }
                    Excel.Range fchR = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[rowNum + 5, columnNum]);
                    fchR.Value2 = datas;

                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。   
                    m_xlApp.WindowState = Excel.XlWindowState.xlMaximized;

                    range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[rowNum + 5, columnNum]);
                    //range.Interior.ColorIndex = 15;//15代表灰色   
                    range.Font.Size = 9;
                    range.RowHeight = 14.25;
                    range.Borders.LineStyle = 1;
                    range.HorizontalAlignment = 1;
                }
                //workbook.Saved = true;
               // workbook.SaveCopyAs(strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出异常：" + ex.Message, "导出异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (workbook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    workbook = null;

                }
                if (m_xlApp != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp);
                    m_xlApp = null;
                    //xlApp.Quit(); 

                }
                GC.Collect();

                //EndReport();
            }
        }
        // <summary>   
        /// 退出报表时关闭Excel和清理垃圾Excel进程   
        /// </summary>   
        private void EndReport()
        {
            object missing = System.Reflection.Missing.Value;
            try
            {
                m_xlApp.Workbooks.Close();
                m_xlApp.Workbooks.Application.Quit();
                m_xlApp.Application.Quit();
                m_xlApp.Quit();
            }
            catch { }
            finally
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Workbooks);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Application);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp);
                    m_xlApp = null;
                }
                catch { }
                try
                {
                    //清理垃圾进程   
                    this.killProcessThread();
                }
                catch { }
                GC.Collect();
            }
        }
        /// <summary>   
        /// 杀掉不死进程   
        /// </summary>   
        private void killProcessThread()
        {
            ArrayList myProcess = new ArrayList();
            for (int i = 0; i < myProcess.Count; i++)
            {
                try
                {
                    System.Diagnostics.Process.GetProcessById(int.Parse((string)myProcess[i])).Kill();
                }
                catch { }
            }
        }
    }
}