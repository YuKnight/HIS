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
    public partial class DrugCostStatistics : Form
    {

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public DrugCostStatistics(MenuTag menuTag, string chineseName, Form mdiParent, int nType)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            label1.Text = _chineseName;
            headerUnitView1.AutoGenerateColumns = false;                                    //不自动增加列
            headerUnitView1.RowHeadersVisible = false;                                      //行头不可见
            headerUnitView1.AllowUserToAddRows = false;
            headerUnitView1.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerUnitView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            headerUnitView1.ColumnDeep = 2;
            headerUnitView1.CellHeight = 25;
            headerUnitView1.ColumnHeadersHeight = 50;
            headerUnitView1.RefreshAtHscroll = true;
            TreeView tv = new TreeView();
            TreeNode tnBQ = new TreeNode("病区");
            tv.Nodes.Add(tnBQ);
            TreeNode tnKS = new TreeNode("科室");
            tv.Nodes.Add(tnKS);
            TreeNode tnYS = new TreeNode("医师");
            tv.Nodes.Add(tnYS);
            TreeNode tnZFY = new TreeNode("总费用");
            tv.Nodes.Add(tnZFY);
            TreeNode tnYPFY = new TreeNode("药品费用");
            tv.Nodes.Add(tnYPFY);
            TreeNode tnXY = new TreeNode("西药");
            tnYPFY.Nodes.Add(tnXY);
            TreeNode tnXYZB = new TreeNode("西药占药品比例");
            tnYPFY.Nodes.Add(tnXYZB);
            TreeNode tnZCY = new TreeNode("中成药");
            tnYPFY.Nodes.Add(tnZCY);
            TreeNode tnZCYZB = new TreeNode("中成药占药品比例");
            tnYPFY.Nodes.Add(tnZCYZB);
            TreeNode tnZCYc = new TreeNode("中草药");
            tnYPFY.Nodes.Add(tnZCYc);
            TreeNode tnZCYZBc = new TreeNode("中草药占药品比例");
            tnYPFY.Nodes.Add(tnZCYZBc);
            TreeNode tnXJ = new TreeNode("小计");
            tnYPFY.Nodes.Add(tnXJ);
            TreeNode tnYPZB = new TreeNode("药品占比");
            tnYPFY.Nodes.Add(tnYPZB);
            headerUnitView1.ColumnTreeView = new TreeView[] { tv };


        }

        private void GetData()
        {
            int tjks = 1;
            if (rdkd.Checked == true)
                tjks = 1;
            else
                tjks = 2;
            int tjlx = 1;
            if (rbzy.Checked == true)
            {
                tjlx = 1;
            }
            if(rbcy.Checked)
                tjlx = 2;
            if(rbzs.Checked)
                tjlx = 3;

            try
            {
                ParameterEx[] parameters = new ParameterEx[5];

                parameters[0].Text = "@TJFS";
                parameters[0].Value = cmbtjfs.SelectedIndex;

                parameters[1].Text = "@TJKS";
                parameters[1].Value = tjks;

                parameters[2].Text = "@TJLX";
                parameters[2].Value = tjlx;

                parameters[3].Text = "@RQ1";
                parameters[3].Value = dtpBjksj.Value.ToString();

                parameters[4].Text = "@RQ2";
                parameters[4].Value = dtpEjksj.Value.ToString();


                DataSet dset = new DataSet();

                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_DrugCostStatistics", parameters, dset, "sfmx", 30);

                Fun.AddRowtNo(dset.Tables[0]);
                //this.dataGridView1.Columns.Clear();
                //this.dataGridView1.DataSource = dset.Tables[0];
                this.headerUnitView1.DataSource = dset.Tables[0];
                headerUnitView1.MergeColumnNames.Add("病区");
                headerUnitView1.MergeColumnNames.Add("科室");
                for (int i = 0; i < this.headerUnitView1.Columns.Count; i++)
                {
                    this.headerUnitView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DrugCostStatistics_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;            
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            cmbFG.Items.Add("列宽适应网格内容");
            cmbFG.Items.Add("列宽仅适应有数据的区域");
            cmbFG.SelectedIndex = 0;
            cmbtjfs.SelectedIndex = 0;
  
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            GetData();
        }
       
        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = null;
                string ss = "";
                tb = (DataTable)this.headerUnitView1.DataSource;
                SystemCfg cfg2 = new SystemCfg(2);
                string hospitalName = cfg2.Config;
                ss = hospitalName+"药品费用统计";


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
                string tjfs = "";
                string tjks = "";
                string tjlx = "";
                tjfs = "统计方式:" + cmbtjfs.Text;
                if (cmbtjfs.SelectedIndex != 1)
                {
                    if (rdkd.Checked)
                        tjks = "统计科室：" + rdkd.Text;
                    else
                        tjks = "统计科室：" + rdgc.Text;
                    if (rbzy.Checked)
                        tjlx = "统计类型：" + rbzy.Text;
                    if(rbcy.Checked)
                        tjlx = "统计类型：" + rbcy.Text;
                    if(rbzs.Checked)
                        tjlx = "统计类型：" + rbzs.Text;
                }
                swhere = tjfs + " " + tjks + " " + tjlx +" "+ " 记费日期从:" + dtpBjksj.Value.ToString() + "　到 " + dtpEjksj.Value.ToString();


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

                Excel.Range range2 = xlSheet.get_Range(xlApp.Cells[3, 5], xlApp.Cells[3, colCount]);
                range2.MergeCells = true;
                range2.set_Value(Type.Missing, "药品费用");
                range2.HorizontalAlignment = Excel.Constants.xlCenter;

                // 创建缓存数据
                object[,] objData = new object[RowCount + 2, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (i >= 4)
                    {
                        objData[1, colIndex++] = "药品费用";
                    }
                    else
                    {
                        objData[1, colIndex++] = tb.Columns[i].Caption;
                    }
                }
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    objData[2, i] = tb.Columns[i].Caption;
                    if (i < 4)
                    {
                        Excel.Range range3 = xlSheet.get_Range(xlApp.Cells[3, i + 1], xlApp.Cells[4, i + 1]);
                        range3.MergeCells = true;
                        range3.HorizontalAlignment = Excel.Constants.xlCenter;
                    }
                }
                
                // 获取数据
                objData[0, 0] = swhere;
                string lastName1 = "";
                string lastName2 = "";
                int rowBegin = 5;
                int rowEnd = 4;
                int rowBegin1 = 5;
                int rowEnd1 = 4;

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        objData[i + 3, colIndex++] = "" + tb.Rows[i][j].ToString();

                        if (j == 0)
                        {
                            if (lastName1 != "" && !lastName1.Equals(tb.Rows[i][j].ToString()))
                            {
                               // Fun.DebugView(tb);
                                MergerCell(xlApp,xlSheet,rowBegin, rowEnd, 1);
                                rowBegin = rowEnd+1;
                                rowEnd = rowEnd + 1;
                                lastName1 = tb.Rows[i][j].ToString();
                            }
                            else
                            {
                                rowEnd = rowEnd + 1;
                            }
                        }
                        if (j == 1)
                        {
                            if (lastName2 != "" && !lastName2.Equals(tb.Rows[i][j].ToString()))
                            {
                                MergerCell(xlApp, xlSheet, rowBegin1, rowEnd1, 2);
                                rowBegin1 = rowEnd1+1;
                                rowEnd1 = rowEnd1 + 1;
                                lastName2 = tb.Rows[i][j].ToString();
                            }
                            else
                            {
                                rowEnd1 = rowEnd1 + 1;
                            }
                        }

                    }
                     
                    lastName1=tb.Rows[i][0].ToString();
                    lastName2 = tb.Rows[i][1].ToString();

                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 3, colCount]);
                range.Value2 = objData;

                //合并单元格

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 3, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 3, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 3, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="rowBeginIndex">行开始</param>
        /// <param name="rowEndIndex">行结束</param>
        /// <param name="columnIndex"></param>
        private void MergerCell(Excel.Application xlApp,Excel.Worksheet xlSheet,int rowBeginIndex, int rowEndIndex, int columnIndex)
        {
            Excel.Range range = xlSheet.get_Range(xlApp.Cells[rowBeginIndex, columnIndex], xlApp.Cells[rowEndIndex, columnIndex]);
            range.MergeCells = true;
            
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)dataGridView1.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                }
                Dset.收费项目.Rows.Add(myrow);

                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        int x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }


                ParameterEx[] parameters = new ParameterEx[3];
                
                parameters[0].Text = "开始日期";
                parameters[0].Value = dtpBjksj.Value.ToString("yyyy-MM-dd");

                parameters[1].Text = "结束日期";
                parameters[1].Value = dtpBjksj.Value.ToString("yyyy-MM-dd");

                parameters[2].Text = "统计方式";
                parameters[2].Value = cmbtjfs.Text;
                       

                TrasenFrame.Forms.FrmReportView f = null;  
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\业务收入报表.rpt", parameters);
    
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            

            if (e.ColumnIndex > 2)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
                      



            if ((e.ColumnIndex == 0 || e.ColumnIndex == 1)  && e.RowIndex != -1)
            {
                using
                       (
                       Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                       backColorBrush = new SolidBrush(e.CellStyle.BackColor)
                       )
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds); if (e.RowIndex < dataGridView1.Rows.Count - 1 &&
                         dataGridView1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() !=
                         e.Value.ToString())
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom); if (e.Value != null)
                        {
                            if (e.RowIndex > 0 &&
                               dataGridView1.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() ==
                               e.Value.ToString())
                            { }
                            else
                            {
                                //if (e.RowIndex == dataGridView1.Rows.Count - 1)
                                //{ }
                                //else
                                //{
                                try
                                {
                                    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                        Brushes.Black, e.CellBounds.X + 2,
                                        e.CellBounds.Y + 5, StringFormat.GenericDefault);
                                }
                                catch
                                {
                                    ;
                                }
                                //}
                            }
                        }
                        e.Handled = true;
                    }
                }


            }
        }

        private void cmbtjfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtjfs.SelectedIndex == 1)
            {
                groupBox2.Enabled = false;
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = true;
            }
        }        

    }
}