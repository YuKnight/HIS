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
    public partial class Frm_ReportBuessinessQuerybyDoc : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_ReportBuessinessQuerybyDoc( MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            label1.Text = _chineseName;


        }

        private void Frm_ReportBuessinessQuerybyDoc_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

        }

        private void Frm_ReportBuessinessQuerybyDoc_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
            this.dataGridView1.Height = this.Height - this.dataGridView1.Top - 40;
            this.label1.Left = (this.Width - this.label1.Width) / 2;
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            try
            {

                ParameterEx[] parameters = new ParameterEx[3];


                parameters[0].Text = "@rq1";
                parameters[0].Value = dtpBjksj.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtpEjksj.Value.ToString();

                parameters[2].Text = "@DocId";
                parameters[2].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_ReportBuessinessQuerybyDoc", parameters, dset, "sfmx", 60);


                Fun.AddRowtNo(dset.Tables[0]);
                DataTable dt= dset.Tables[0];
                dt.Columns.Add("药品总额",typeof(decimal));
                dt.Columns.Add("药品比例", typeof(decimal));
                dt.Columns.Add("西药比例", typeof(decimal));
                dt.Columns.Add("自制药比例", typeof(decimal));
                dt.Columns.Add("中成药比例", typeof(decimal));
                dt.Columns.Add("中草药比例", typeof(decimal));
                dt.Columns.Add("膏方比例", typeof(decimal));
                dt.Columns.Add("其他药品比例", typeof(decimal));
                if (dt.Rows.Count <= 1)
                {
                    dt.Rows[0]["药品总额"] = 0;
                    dt.Rows[0]["药品比例"] = 0;
                    dt.Rows[0]["西药比例"] = 0;
                    dt.Rows[0]["自制药比例"] = 0;
                    dt.Rows[0]["中成药比例"] = 0;
                    dt.Rows[0]["中草药比例"] = 0;
                    dt.Rows[0]["膏方比例"] = 0;
                    dt.Rows[0]["其他药品比例"] = 0;
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        decimal num = 0;
                        dt.Rows[i]["药品总额"] = Decimal.Parse(dt.Rows[i]["西药"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["自制药"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["中成药"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["中草药"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["膏方"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["其他药品"].ToString());
                        decimal total= Decimal.Parse(dt.Rows[i]["合计"].ToString());
                        if (total != 0)
                        {
                            num = Decimal.Parse(dt.Rows[i]["药品总额"].ToString()) / Decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                            dt.Rows[i]["药品比例"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["西药"].ToString()) / Decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                            dt.Rows[i]["西药比例"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["自制药"].ToString()) / Decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                            dt.Rows[i]["自制药比例"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["中成药"].ToString()) / Decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                            dt.Rows[i]["中成药比例"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["中草药"].ToString()) / Decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                            dt.Rows[i]["中草药比例"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["膏方"].ToString()) / Decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                            dt.Rows[i]["膏方比例"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["其他药品"].ToString()) / Decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                            dt.Rows[i]["其他药品比例"] = num.ToString("f2");
                        }
                        else
                        {
                            dt.Rows[i]["药品比例"] =0;
                            dt.Rows[i]["西药比例"] = 0;
                            dt.Rows[i]["自制药比例"] =0;
                            dt.Rows[i]["中成药比例"] = 0;
                            dt.Rows[i]["中草药比例"] =0;
                            dt.Rows[i]["膏方比例"] = 0;
                            dt.Rows[i]["其他药品比例"] = 0;
                        }
                       

                    }
                }
                int col = 4;
                dt.Columns["药品总额"].SetOrdinal(col); ++col;
                dt.Columns["药品比例"].SetOrdinal(col); ++col;
                dt.Columns["西药"].SetOrdinal(col); ++col;
                dt.Columns["西药比例"].SetOrdinal(col); ++col;
                dt.Columns["自制药"].SetOrdinal(col); ++col;
                dt.Columns["自制药比例"].SetOrdinal(col); ++col;
                dt.Columns["中成药"].SetOrdinal(col); ++col;
                dt.Columns["中成药比例"].SetOrdinal(col); ++col;
                dt.Columns["中草药"].SetOrdinal(col); ++col;
                dt.Columns["中草药比例"].SetOrdinal(col); ++col;
                dt.Columns["膏方"].SetOrdinal(col); ++col;
                dt.Columns["膏方比例"].SetOrdinal(col); ++col;
                dt.Columns["其他药品"].SetOrdinal(col); ++col;
                dt.Columns["其他药品比例"].SetOrdinal(col); ++col;

                this.dataGridView1.DataSource =dt;
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