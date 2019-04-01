using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using YpClass;


namespace ts_yf_cx
{
    public partial class Frmgqyptj : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public Frmgqyptj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void Frmgqyptj_Load(object sender, EventArgs e)
        {
            try
            {

                Yp.AddcmbYjks(cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);


                cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;

                if (cmbyjks.SelectedIndex < 0)
                    cmbyjks.Text = "全部";




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTj_Click(object sender, EventArgs e)
        {
            try
            {
                string strph = "select a.deptid,dbo.fun_jc_deptname(a.deptid) 药剂科室,a.shrq 入库日期,a.DJH 单据号,b.CJID,b.SHH 货号," +
                    "b.YPPM 品名,b.YPSPM 商品名,b.YPGG 规格,b.YPDW 单位,b.SCCJ 厂家, b.yppch 批次号,b.YPPH 批号,b.YPXQ 失效日期,cast(b.YPSL as float) 入库数量,b.LSJ 零售价," +
                    "cast((select KCL from Yf_KCMX where BDELETE=0 and DEPTID=a.DEPTID and CJID=b.CJID ) as float) 现有库存量   " +
                    "from YF_DJ a left join yf_djmx b on a.id=b.djid and a.DJH=b.DJH where a.YWLX='016' and b.YPPH<>'无批号' " +
                    " and SHRQ between '" + dtpshrqB.Value.ToString("yyyy-MM-dd") + "' and '" + dtpshrqE.Value.ToString("yyyy-MM-dd") + "'  "+
                    "and b.YPXQ<='" + dtpXQ.Value.ToString("yyyy-MM-dd") + "' and CJID in (select CJID from Yf_KCMX where BDELETE=0 and KCL>0 and DEPTID=a.DEPTID) ";

                strph += cmbyjks.Text != "全部" ? "and a.DEPTID=" + cmbyjks.SelectedValue.ToString() : "";
                strph += " order by 药剂科室,失效日期,单据号,cjid";

                DataTable dtrkmx = InstanceForm.BDatabase.GetDataTable(strph);
                this.dgvgqyp.DataSource = dtrkmx;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataTable tb = (DataTable)this.dgvgqyp.DataSource;

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
                for (int i = 0; i <= dgvgqyp.Columns.Count - 1; i++)
                {
                    if (dgvgqyp.Columns[i].Width > 0)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = this.Text;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                //查询条件
                string bz = "";
                bz = bz + "药剂科室:" + cmbyjks.Text.Trim() + "    入库日期：从" + dtpshrqB.Value.ToString("yyyy-MM-dd") + " 到 " + dtpshrqE.Value.ToString("yyyy-MM-dd");
                bz = bz + "    失效日期：" + dtpXQ.Value.ToString("yyyy-MM-dd");
                string swhere = "  " + bz;
                // 设置条件
                Excel.Range rangeT = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT = new object[1, 1];
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                objDataT[0, 0] = swhere;
                range.Value2 = objDataT;



                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= dgvgqyp.Columns.Count - 1; i++)
                {
                    if (dgvgqyp.Columns[i].Width > 0)
                        objData[0, colIndex++] = dgvgqyp.Columns[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= dgvgqyp.Columns.Count - 1; j++)
                    {
                        if (dgvgqyp.Columns[j].Width > 0)
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}