using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;

namespace ts_yf_cx
{
    public partial class Frmkjywzbtj : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        public Frmkjywzbtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            this.WindowState = FormWindowState.Maximized;
        }
        private void Frmkjywzbtj_Load(object sender, EventArgs e)
        {
            //FunBase.CsDataGrid(this.myDataGrid4, this.myDataGrid4.TableStyles[0], "Tb");
            //FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
            ////FunBase.CsDataGrid(this.myDataGrid2, this.myDataGrid2.TableStyles[0], "Tb");
            //FunBase.CsDataGrid(this.myDataGrid3, this.myDataGrid3.TableStyles[0], "Tb");
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                btnStat.Enabled = false;
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Value = dtpBeginTime.Value.ToShortDateString() + " 00:00:00";
                parameters[1].Value = dtpEndTime.Value.ToShortDateString() + " 23:59:59";
                parameters[2].Value = 0;

                parameters[3].Text = "@bz";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].ParaSize = 200;

                parameters[0].Text = "@rq1";
                parameters[1].Text = "@rq2";
                parameters[2].Text = "@tjlx";

                DataSet dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_YP_KSSZB_TJ", parameters,dset,"kss", 30);
                string err_text = Convert.ToString(parameters[3].Value);
                FunBase.AddRowtNo(dset.Tables[0]);
                FunBase.AddRowtNo(dset.Tables[1]);
                FunBase.AddRowtNo(dset.Tables[2]);
                FunBase.AddRowtNo(dset.Tables[3]);
                this.dataGridView1.DataSource = dset.Tables[0] ;
                this.dataGridView2.DataSource = dset.Tables[1];
                this.dataGridView3.DataSource = dset.Tables[2];
                this.dataGridView4.DataSource = dset.Tables[3];
                btnStat.Enabled = true;

                if (Convertor.IsNull(dset.Tables[4].Rows[0][0],"")!="")
                    throw new Exception(Convertor.IsNull(dset.Tables[4].Rows[0][0], ""));
            }
            catch (System.Exception err)
            {
                btnStat.Enabled = true;
                MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ShowData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
            ExportToExcel(dataGridView2);
            ExportToExcel(dataGridView3);
            ExportToExcel(dataGridView4);
        }

        private void ExportToExcel(DataGridView pmydatagrid)
        {
            try
            {

                DataTable tb = (DataTable)pmydatagrid.DataSource;

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
                int RowCount = tb.Rows.Count;
                for (int i = 0; i <= pmydatagrid.ColumnCount - 1; i++)
                {
                    if (pmydatagrid.Columns[i].Width > 0)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = pmydatagrid.Tag.ToString();
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= pmydatagrid.ColumnCount - 1; i++)
                {
                    if (pmydatagrid.Columns[i].Width > 0)
                        objData[0, colIndex++] = pmydatagrid.Columns[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= pmydatagrid.ColumnCount - 1; j++)
                    {
                        if (pmydatagrid.Columns[j].Width > 0)
                        {
                            objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Font.Size = 9;

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

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpBeginTime_ValueChanged(object sender, EventArgs e)
        {
            DataTable tb1 = (DataTable)dataGridView1.DataSource;
            DataTable tb2 = (DataTable)dataGridView2.DataSource;
            DataTable tb3 = (DataTable)dataGridView3.DataSource;
            DataTable tb4 = (DataTable)dataGridView4.DataSource;
            if (tb1 != null) tb1.Rows.Clear();
            if (tb2 != null) tb2.Rows.Clear();
            if (tb3 != null) tb3.Rows.Clear();
            if (tb4 != null) tb4.Rows.Clear();
        }
    }
}