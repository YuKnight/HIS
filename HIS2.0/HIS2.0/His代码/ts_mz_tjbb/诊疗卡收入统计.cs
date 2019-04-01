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
using System.Drawing.Printing;
using System.Reflection;
namespace ts_mz_tjbb
{
    public partial class 诊疗卡收入统计 : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public 诊疗卡收入统计()
        {
            InitializeComponent();
        }
        public 诊疗卡收入统计(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            ParameterEx[] parameters1 = new ParameterEx[4];


            parameters1[0].Text = "@开始时间";
            parameters1[0].Value = dtpjsrq1.Value.ToString();

            parameters1[1].Text = "@结束时间";
            parameters1[1].Value = dtpjsrq2.Value.ToString();

            parameters1[2].Text = "@收费员";
            parameters1[2].Value = Convert.ToInt32(Convertor.IsNull(comboBox1.SelectedValue, "-1")) == 0 ? -1 : Convert.ToInt32(Convertor.IsNull(comboBox1.SelectedValue, "-1"));
            parameters1[3].Text = "@显示明细";
            parameters1[3].Value = this.checkBoxX1.Checked?1:0;
            
            DataSet dset = new DataSet();
            TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_ZDY_MZ_ZLKYJCX_ex", parameters1, dset, "tj", 60);
            Fun.AddRowtNo(dset.Tables[0]);
            //for (int i = 0; i < dset.Tables[0].Columns.Count; i++)
            //{
            //    dset.Tables[0].Columns[i].DataType = typeof(System.String);
            //}
            ParameterEx[] parameters2 = new ParameterEx[3];
            parameters2[0].Text = "@RQ1";
            parameters2[0].Value = dtpjsrq1.Value.ToString();

            parameters2[1].Text = "@RQ2";
            parameters2[1].Value = dtpjsrq2.Value.ToString();

            parameters2[2].Text = "@sky";
            parameters2[2].Value = Convert.ToInt32(Convertor.IsNull(comboBox1.SelectedValue, "-1")) == 0 ? -1 : Convert.ToInt32(Convertor.IsNull(comboBox1.SelectedValue, "-1"));
            DataTable yjxxtb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_ZDY_MZ_YJJCX_ry", parameters2, 60);
            DataRow r = dset.Tables[0].NewRow();
            if(!this.checkBoxX1.Checked&&yjxxtb.Rows.Count>0)
            {
                r["类型"] = "预收款：";
                r["收费员"] = yjxxtb.Rows[0]["预交金存入金额"].ToString();
                r["押金"] = "诊疗卡押金：";
                r["收押金卡张数"] = yjxxtb.Rows[0]["诊疗卡押金"].ToString();
                r["未收押金卡张数"] = "预交金消费金额：";
                r["总发卡张数"] = yjxxtb.Rows[0]["预交金消费金额"].ToString();
                dset.Tables[0].Rows.Add(r);
                r = dset.Tables[0].NewRow();
                r["类型"] = "预交金结存金额：";
                r["收费员"] = yjxxtb.Rows[0]["预交金结存金额"].ToString();
                r["押金"] = "现金：";
                r["收押金卡张数"] = yjxxtb.Rows[0]["现金"].ToString();
                r["未收押金卡张数"] = "银行转入：";
                r["总发卡张数"] = yjxxtb.Rows[0]["银行转入"].ToString();
                dset.Tables[0].Rows.Add(r);

            }

            this.dataGridViewX1.DataSource = dset.Tables[0];
        }

        private void 诊疗卡收入统计_Load(object sender, EventArgs e)
        {
            dtpjsrq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpjsrq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            FunAddComboBox.AddOperator(true, comboBox1, InstanceForm.BDatabase);
        }
        private void Save()
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                #region 简单打印
                DataTable tb = (DataTable)this.dataGridViewX1.DataSource;

                //if (tb == null || tb.Rows.Count == 0)
                //{
                //    return;
                //}



                Excel.Application myExcel = new Excel.ApplicationClass(); //new Excel.Application();
                //关闭时不显示提示
                //myExcel.DefaultFilePath = "";
                //myExcel.DisplayAlerts = false;
                //myExcel.SheetsInNewWorkbook = 1;
                Excel.Workbook xlBook = myExcel.Application.Workbooks.Add(true);

                //查询条件
                string rq = "日期从:" + dtpjsrq1.Value.ToString() + " 到:" + dtpjsrq2.Value.ToString() + "   收费员：" + this.comboBox1.Text;
                string ks = "";

                string swhere = rq + ks;


                //写入行头

                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < this.dataGridViewX1.Columns.Count; j++)
                {
                    if (this.dataGridViewX1.Columns[j].Visible)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = "" + this.dataGridViewX1.Columns[j].HeaderText;
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
                        if (this.dataGridViewX1.Columns[j].Visible)
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
                string ss = TrasenFrame.Classes.Constant.HospitalName + "门诊预交金收支情况统计";
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

                xlBook.SaveCopyAs(Application.StartupPath + "\\门诊预交金收支情况统计.xls");
                //让Excel文件可见
                myExcel.Visible = false;

                //

                //打印



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
                MessageBox.Show(err.Message + "错误提示");
            }
            finally
            {
                //this.btExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }
        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridViewX1.DataSource == null )
                return;

            try
            {
                string swhere = "";

                swhere = "日期从:" + dtpjsrq1.Value.ToString() + " 到:" + dtpjsrq2.Value.ToString() +  "   收费员："+this.comboBox1.Text;

                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridViewX1, Constant.HospitalName + "门诊预交金收支情况统计", swhere, true, true, false, false);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butprint_pos_Click(object sender, EventArgs e)
        {
            Save();
            String ExcelFile = Application.StartupPath + "\\门诊预交金收支情况统计.xls";
            //Microsoft.Office.Interop.Excel.ApplicationClass xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            //xlApp.Visible = true;
            //object oMissing = System.Reflection.Missing.Value;
            //Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(ExcelFile, 0, true, 5, oMissing, oMissing, true, 1, oMissing, false, false, oMissing, false, oMissing, oMissing);
            //Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets[1];
            //xlWorksheet.PrintPreview(null);
            //xlApp.Visible = false;
            //xlWorksheet = null;
            //xlWorksheet.PrintOut(1, 1, 1, Missing.Value, Missing.Value, Missing.Value, Missing.Value,

            //                 Missing.Value);
            //return;


            Excel.Application xlsApp = new Excel.Application();
            //xlsApp.Visible = true; 
            Excel.Workbooks xlsWbs = xlsApp.Workbooks;
            Excel.Workbook xlsWb = xlsWbs.Open(

                                         ExcelFile, Missing.Value, true, Missing.Value, Missing.Value,

                                         Missing.Value, Missing.Value, Missing.Value, Missing.Value,

                                         Missing.Value, Missing.Value, Missing.Value, Missing.Value,

                                         Missing.Value, Missing.Value);
            Excel.Worksheet xlsWs = (Excel.Worksheet)xlsWb.Worksheets[1];
            //if (checkBox1.Checked)
            //    xlsWs.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;//页面方向横向
            //else
                xlsWs.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;//页面方向横向

            //objsheet.PageSetup.Zoom = 75;//打印时页面设置,缩放比例
            //objsheet.PageSetup.TopMargin = 0; //上边距为0
            //objsheet.PageSetup.BottomMargin = 0; //下边距为0
            //objsheet.PageSetup.LeftMargin = 0; //左边距为0
            //objsheet.PageSetup.RightMargin = 0; //右边距为0
            //objsheet.PageSetup.CenterHorizontally = true;//水平居中


            //PaperSize p = null;
            //PrintDialog pd = new PrintDialog();
            //foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
            //{
            //    if (ps.PaperName.Equals("A4 Plus"))
            //        p = ps;
            //}
            //xlsWs.PageSetup.PaperSize = (Excel.XlPaperSize)p.RawKind;
            //使excel可见
            xlsApp.Visible = true;
            //预览
            xlsWb.PrintPreview(false);

            //保存后退出，并释放资源
            xlsApp.DisplayAlerts = false;

            // xlsWb.Save();
            // xlsWb.SaveAs(ExcelFile, Missing.Value, Missing.Value, Missing.Value, Missing.Value,

            //                Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value,

            //               Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWs);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWb);
            xlsWs = null;
            xlsWb = null;

            xlsApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
            xlsApp = null;
            //xlsApp.Visible = true;
            //打印
            //xlsWb.PrintOut(1, 1, 1, Missing.Value, Missing.Value, Missing.Value, Missing.Value,

            //                 Missing.Value);
            //保存后退出，并释放资源
            // xlsApp.DisplayAlerts = false;
            // xlsWb.Save();
            //xlsWb.SaveAs(ExcelFile, Missing.Value, Missing.Value, Missing.Value, Missing.Value,

            //               Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value,

            //               Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlsWs = null;
            xlsWb = null;
            //xlsApp.Quit();
            xlsApp = null;
            GC.Collect();


        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}