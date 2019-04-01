using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class Frmkssrtj_mx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private Guid ghxxid = Guid.Empty;
        private Guid brxxid = Guid.Empty;
        public Frmkssrtj_mx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        public void btref_Click(object sender, EventArgs e)
        {
            try
            {

                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@execdept";
                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(txtks.Tag,"0")) ;

                parameters[1].Text = "@RQ1";
                parameters[1].Value = dtp1.Value.ToShortDateString()+" 00:00:00";

                parameters[2].Text = "@RQ2";
                parameters[2].Value = dtp2.Value.ToShortDateString() + " 23:59:59";


                parameters[3].Text = "@jgbm";
                parameters[3].Value = Convert.ToInt64(cmbjgbm.SelectedValue);

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_TJ_SK_kssrtj_mx", parameters, 30);
                ts_mz_class.Fun.AddRowtNo(tb);

                dataGridView1.DataSource = tb;


                    decimal je = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(金额)", ""), "0"));
                    this.toolStripStatusLabel1.Text = "确认金额: " + je.ToString();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void Frmyjqr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Cursor.Current = PubStaticFun.WaitCursor();
                btref_Click(sender, e);
                Cursor.Current = Cursors.Default;
            }

        }



        private void Frmyjqr_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            ts_mz_class.FunAddComboBox.AddJgbm(false, cmbjgbm,InstanceForm.BDatabase);

        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {

                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                // 创建Excel对象                    --LeeWenjie    2006-11-29
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
                for (int i = 0; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "未确认费用明细";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                        objData[0, colIndex++] = dataGridView1.Columns[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                    {
                        if (dataGridView1.Columns[j].Visible == true)
                        {
                            if (dataGridView1.Columns[j].HeaderText == "门诊号" || dataGridView1.Columns[j].HeaderText == "发票号" || dataGridView1.Columns[j].HeaderText == "卡号")
                                objData[i + 1, colIndex++] = "'" + tb.Rows[i][j].ToString();
                            else
                                objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
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


    }
}