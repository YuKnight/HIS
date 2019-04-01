using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
namespace Ts_Clinicalpathway_Factory
{
    public partial class FrmCpTj : Form
    {
        DataTable pathinfotb = new DataTable();
        public FrmCpTj()
        {
            InitializeComponent();
            pathinfotb = PublicFunction.GetPathway("0", 0);
        }

        private void FrmCpTj_Load(object sender, EventArgs e)
        {
            
               // pathinfotb = PublicFunction.GetPathway(0);
               
                //this.Text = Iscp == 0 ? "引入路径" : "引入单病种";
                //groupBox1.Text = Iscp == 0 ? "可选路径" : "可选单病种";
                //this.btninto.Text = Iscp == 0 ? "进入路径" : "进入单病种";
                //this.dgvdisease.AutoGenerateColumns = false;
                //this.dgvRule.AutoGenerateColumns = false;
                //初始化dgv
                string[] Columname = new string[] { (0 == 0 ? "路径名称" : "单病种"), "版本", "费用", "天数", "版本说明", "创建日期", "修改日期" };
                string[] Values = new string[] { "fname", "VERSION", "fy", "ts", "VERSION_NOTE", "CREATE_DATE", "UPDATE_DATE" };
                int[] colwidth = new int[] { 180, 40, 80, 80, 80, 120, 120 };
                bool[] readonly1 = new bool[] { true, true, true, true, true, true };
                string[] Coltype = new string[]{PublicFunction.DgvColStype.GroupColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
            };
                PublicFunction.InitDgv(Columname, colwidth, Coltype, Values, this.Dgvpathinfo, 1);
                this.Dgvpathinfo.AutoGenerateColumns = false;
                this.Dgvpathinfo.DataSource = pathinfotb;
                PublicFunction.GruopShow(pathinfotb, "fname=bname", "Bname", this.Dgvpathinfo, "PATHWAY_NAME", this.Dgvpathinfo.groupColumIndex, this.Dgvpathinfo.Iszlfb);
                for (int i = 0; i < pathinfotb.Rows.Count; i++)
                {
                    if (pathinfotb.Rows[i]["PATHWAY_ID"].ToString().Trim() == "")
                    {
                        pathinfotb.Rows[i]["fname"] = (0 == 0 ? "路径：" : "单病种：") + pathinfotb.Rows[i]["bname"].ToString() + " 总共" + pathinfotb.Rows[i]["gs"].ToString() + "条";
                    }
                }

                if (Dgvpathinfo.RowCount > 0)
                {
                    DataGridViewGroupCell childcell1 = Dgvpathinfo.Rows[0].Cells[0] as DataGridViewGroupCell;
                    DataGridViewGroupCell childcell2 = Dgvpathinfo.Rows[1].Cells[0] as DataGridViewGroupCell;

                    childcell1.AddChildCell(childcell2);
                }
            //patientinfotb = FrmMdiMain.Database.GetDataTable("select * from VI_ZY_VINPATIENT_ALL where inpatient_id='" + _inpatient_id + "' and baby_id=0");
           // PublicFunction.GruopShow(pathinfotb, "fname=bname", "Bname", this.Dgvpathinfo, "PATHWAY_NAME", this.Dgvpathinfo.groupColumIndex, this.Dgvpathinfo.Iszlfb);
        }

        private void Dgvpathinfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             


            DataTable tb = (DataTable)this.Dgvpathinfo.DataSource;
            string sql = " select '' 路径名称,'' 使用人次,'' 均次费用,'' 标准费用,'' 变异率,'' 完成率 ";
            DataTable tbtemp = FrmMdiMain.Database.GetDataTable(sql);
            tbtemp.Rows.RemoveAt(0);
            if (tb.Rows[this.Dgvpathinfo.CurrentCell.RowIndex]["PATHWAY_ID"].ToString().Trim() != "")
            {
                DataRow r = tbtemp.NewRow();
                ParameterEx[] pa = new ParameterEx[3];
                pa[0].Text = "@kssj";
                pa[0].Value = this.dateTimePicker1.Value;
                pa[1].Text = "@jssj";
                pa[1].Value = this.dateTimePicker2.Value;
                pa[2].Text = "@pathway_id";
                pa[2].Value = new Guid(tb.Rows[this.Dgvpathinfo.CurrentCell.RowIndex]["PATHWAY_ID"].ToString().Trim());
                DataTable ttbb = FrmMdiMain.Database.GetDataTable("sp_cptj", pa);
                if (ttbb == null || ttbb.Rows.Count ==0)
                    return;
                r["路径名称"] = tb.Rows[this.Dgvpathinfo.CurrentCell.RowIndex]["fname"].ToString();
                r["标准费用"] = tb.Rows[this.Dgvpathinfo.CurrentCell.RowIndex]["fy"].ToString();
                r["使用人次"] = ttbb.Rows[0]["人次"].ToString();
                r["均次费用"] = ttbb.Rows[0]["平均费用"].ToString();
                r["变异率"] = ttbb.Rows[0]["变异率"].ToString();
                tbtemp.Rows.Add(r);
            }
           
            this.dataGridView1.DataSource = tbtemp;
           

        }

        private void Dgvpathinfo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                int X = e.CellBounds.X;
                int Y = e.CellBounds.Y;
                int W = e.CellBounds.Width;
                int H = e.CellBounds.Height;

                Pen blackPen = new Pen(Color.FromArgb(195, 195, 195));//边框颜色
                //Image image = this.imageList1.Images[2];//2
                //TextureBrush tBrush = new TextureBrush(image);
                //e.Graphics.DrawImage(image, e.CellBounds, new Rectangle(0, 0, image.Size.Width, image.Size.Height), GraphicsUnit.Pixel);
                //e.Graphics.FillRectangle(tBrush, new Rectangle(X, Y, W, H));
                Image dtim = this.imageList1.Images[2];
                Bitmap map = new Bitmap(W, H);
                Graphics g = Graphics.FromImage(map);
                g.DrawImage(dtim, new Rectangle(0, 0, W + 30, H), new Rectangle(0, 0, dtim.Width - 5, dtim.Height), GraphicsUnit.Pixel);
                dtim = Image.FromHbitmap(map.GetHbitmap());

                TextureBrush tBrush = new TextureBrush(dtim, new Rectangle(0, 0, W, H));//, WrapMode., 
                e.Graphics.DrawImage(dtim, e.CellBounds, new Rectangle(0, 0, dtim.Size.Width, dtim.Size.Height), GraphicsUnit.Pixel);


                if (e.ColumnIndex == 0)
                    e.Graphics.DrawRectangle(blackPen, new Rectangle(X, Y + 1, W - 1, H - 2));
                else
                    e.Graphics.DrawRectangle(blackPen, new Rectangle(X - 1, Y + 1, W, H - 2));

                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
             
            //if ((sender as DataGridView).Name == this.Dgvpathinfo.Name)
            //    return;
            if (e.RowIndex >= 0 && ((DataTable)this.Dgvpathinfo.DataSource).Rows[e.RowIndex]["PATHWAY_ID"].ToString().Trim() != "")
            {
                if (e.ColumnIndex > 0)
                    e.CellStyle.BackColor = System.Drawing.Color.LightCyan;
            }
            else
            {

                e.CellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                if (e.RowIndex >= 0 && e.ColumnIndex >0)
                {
                    e.Graphics.FillRectangle(Brushes.White, new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width + 1, e.CellBounds.Height));
                    Pen p = new Pen(this.Dgvpathinfo.GridColor);
                    e.Graphics.DrawLine(p, e.CellBounds.X - 1, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X - 1 + e.CellBounds.Width, e.CellBounds.Y + e.CellBounds.Height - 1);
                    e.Handled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tb=(DataTable)this.Dgvpathinfo.DataSource;
            string sql = " select '' 路径名称,'' 使用人次,'' 均次费用,'' 标准费用,'' 变异率,'' 完成率 ,'' 正在使用率";
            DataTable tbtemp = FrmMdiMain.Database.GetDataTable(sql);
            tbtemp.Rows.RemoveAt(0);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
               
                if (tb.Rows[i]["PATHWAY_ID"].ToString().Trim() != "")
                {
                    DataRow r = tbtemp.NewRow();
                    ParameterEx[] pa=new ParameterEx[3];
                    pa[0].Text="@kssj";
                    pa[0].Value=this.dateTimePicker1.Value;
                    pa[1].Text="@jssj";
                    pa[1].Value=this.dateTimePicker2.Value;
                    pa[2].Text="@pathway_id";
                    pa[2].Value = new Guid(tb.Rows[i]["PATHWAY_ID"].ToString().Trim());
                    DataTable  ttbb = FrmMdiMain.Database.GetDataTable("sp_cptj", pa);
                    if (ttbb == null||ttbb.Rows.Count==0)
                        continue;
                    r["路径名称"] = tb.Rows[i]["fname"].ToString();
                    r["标准费用"] = tb.Rows[i]["fy"].ToString();
                    r["使用人次"] = ttbb.Rows[0]["人次"].ToString();
                    r["均次费用"] = ttbb.Rows[0]["平均费用"].ToString();
                    r["变异率"] = ttbb.Rows[0]["变异率"].ToString();
                    r["完成率"] = ttbb.Rows[0]["完成率"].ToString();

                    r["正在使用率"] = ttbb.Rows[0]["正在使用率"].ToString();
                    tbtemp.Rows.Add(r);
                }
            }
            this.dataGridView1.DataSource = tbtemp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTabletoExcel((DataTable)this.dataGridView1.DataSource, "d:\\dd.asv");
        }
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
                string ss = TrasenFrame.Classes.Constant.HospitalName + "临床路径统计";
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

                 //ss = TrasenFrame.Classes.Constant.HospitalName + "临床路径统计";
                
                //m_xlApp.get_Range(m_xlApp.Cells[2, 1], m_xlApp.Cells[3, 1]).Font.Bold = true;
                //m_xlApp.get_Range(m_xlApp.Cells[2, 1], m_xlApp.Cells[3, 1]).Cells.Merge(null) ;//合并单元格
                ////报表名称跨行居中
                //m_xlApp.get_Range(m_xlApp.Cells[2, 1], m_xlApp.Cells[3, 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;


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
    }
}