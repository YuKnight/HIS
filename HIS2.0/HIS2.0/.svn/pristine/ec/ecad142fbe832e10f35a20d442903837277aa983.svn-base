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
    public partial class Frm_MZ_HighAmountQuery : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_MZ_HighAmountQuery( MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
  

            this.Text = _chineseName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            int count = 10;
            if (!Int32.TryParse(comboBox1.Text,out count))
            {
                count = 10;
                comboBox1.Text = "10";
            }

            ParameterEx[] parameters = new ParameterEx[3];


            parameters[0].Text = "@rq1";
            parameters[0].Value = dtpBjksj.Value.ToString();

            parameters[1].Text = "@rq2";
            parameters[1].Value = dtpEjksj.Value.ToString();

            parameters[2].Text = "@Num";
            parameters[2].Value = count;



            DataSet dset = new DataSet();
            TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_MZ_QueryHighAmountCF", parameters, dset, "sfmx", 60);

            Fun.AddRowtNo(dset.Tables[0]);
            this.dataGridView1.DataSource = dset.Tables[0];
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm" || dset.Tables[0].Columns[i].ColumnName.ToLower() == "cfid")
                {
                    this.dataGridView1.Columns[i].Visible = false;
                }
            }
        }


        private void ToExcel(int type)
        {
            try
            {

                DataTable tb = null;
                string ss = "";
                if (type == 0)
                {
                    tb = (DataTable)this.dataGridView1.DataSource;
                }
                else
                {
                    tb = (DataTable)this.dataGridView2.DataSource;
                }
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


        private void GetList(string cfid)
        {
            string sql = "select pm 项目名称, gg 规格, sl 数量, dw 单位 , js 剂数 , ts 天数 , dj 单价, je 金额 from mz_cfb_mx where cfid='" + cfid + "' ";
            DataTable dt=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sql);

            Fun.AddRowtNo(dt);
            this.dataGridView2.DataSource = dt;
            for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
            {
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
        


        private void Frm_MZ_HighAmountQuery_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
        }

        private void Frm_MZ_HighAmountQuery_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.dataGridView2.Width = this.Width - 40;
            this.button2.Left = this.dataGridView1.Left + this.dataGridView1.Width - this.button2.Width;
            this.button3.Left = this.dataGridView2.Left + this.dataGridView2.Width - this.button3.Width;

            this.dataGridView1.Height = (this.Height - this.dataGridView1.Top-this.button2.Height*2 - 80) / 2;
            this.button2.Top = this.dataGridView1.Top + this.dataGridView1.Height + 10;
            this.dataGridView2.Top = this.button2.Top + this.button2.Height + 20;
            this.dataGridView2.Height = this.Height - this.button2.Top - this.button2.Height*2 - 80;
            this.button3.Top = this.dataGridView2.Top + this.dataGridView2.Height + 10;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = (DataTable)this.dataGridView1.DataSource;
            string id = dt.Rows[e.RowIndex]["cfid"].ToString();
            if (!string.IsNullOrEmpty(id))
            {
                GetList(id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToExcel(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count <= 0) return;
            ToExcel(1);
        }
    }
}