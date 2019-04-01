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
//using System.Data.Linq;



namespace ts_mz_tjbb
{
    public partial class FrmBussinessReportOfOperation : Form
    {
        private string _deptId;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public FrmBussinessReportOfOperation(int itemcocde, MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            if (itemcocde == 0)
            {
                this._deptId = "23";
            }
            else
            {
                this._deptId = "39";
            }

            this.Text = _chineseName;
            label1.Text = _chineseName;

        }

        private void FrmBussinessReportOfOperation_Load(object sender, EventArgs e)
        {
            //FunAddComboBox.AddOperator(true, cmbuser);
            this.WindowState = FormWindowState.Maximized;


            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            this.label1.Left = (this.Width - this.label1.Width) / 2;
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            GetData(this._deptId);
        }

        private void GetData(string deptID)
        {
            try
            {

                ParameterEx[] parameters = new ParameterEx[3];
  

                  //@KSRQ DATETIME, 
                  //@JSRQ DATETIME, 
                  //@DEPTID BIGINT

                parameters[0].Text = "@KSRQ";
                parameters[0].Value = dtpBjksj.Value.ToString();

                parameters[1].Text = "@JSRQ";
                parameters[1].Value = dtpEjksj.Value.ToString();

                parameters[2].Text = "@DEPTID";
                parameters[2].Value = deptID;





                DataSet dset = new DataSet();

                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_ss_bb_zxkssrtj_Operate", parameters, dset, "sfmx", 60);

                //DataTable tmp =dset.Tables[0];
                DataTable tmp = ChangeRowToCol(dset.Tables[0]);
                tmp.Columns["合计"].SetOrdinal(tmp.Columns.Count - 1);
                Fun.AddRowtNo(tmp);
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = tmp;
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                //Fun.AddRowtNo(dset.Tables[0]);
                //this.dataGridView1.DataSource = dset.Tables[0];
                //for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                //{
                //    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //}

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ChangeRowToCol(DataTable dt)
        {

            bool flag = false;
            List<string> Cols = GetDistinctDataOfCol(dt, 1);
            List<string> Rows = GetDistinctDataOfCol(dt, 0);

            string[,] arr = new string[Rows.Count+1, Cols.Count+2];
            for (int i = 0; i <= Rows.Count; i++)
            {
                for (int j = 0; j <= Cols.Count+1; j++)
                {
                    if (j == 0)
                    {
                        if (i < Rows.Count)
                        {
                            arr[i, j] = Rows[i];
                        }
                        else
                        { 
                            arr[i,j]="合计";
                        }
                    }
                    else
                    {
                        arr[i, j] = "0.00";
                    }
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int row = 0;
                int col = 0;
                for (int r = 0; r < Rows.Count; r++)
                {
                    flag = false;
                    if (dt.Rows[i][0].ToString() == Rows[r])
                    {
                        row = r;
                        flag = true;
                        break;
                    }
                }

                if(flag)
                {
                    for (int c = 0; c < Rows.Count; c++)
                    {
                        flag = false;
                        if (dt.Rows[i][1].ToString() == Cols[c])
                        {
                            col = c+1;
                            flag = true;
                            break;
                        }
                    }
                }

                if (flag)
                {
                    arr[row,col] = dt.Rows[i][2].ToString();
                }
            }

            for (int j = 1; j <= Cols.Count; j++)
            {
                decimal sum=0;
                
                for (int i = 0; i <= Rows.Count; i++)
                {
                    if (i < Rows.Count)
                    {
                        sum +=decimal.Parse( arr[i, j]);
                    }
                    else
                    {
                        arr[i, j] = sum.ToString();
                    }
                }

            }

            for (int i = 0; i <= Rows.Count; i++)
            {
                decimal sum = 0;
                for (int j = 1; j <= Cols.Count+1; j++)
                {
                    if (j < Cols.Count + 1)
                    {
                        sum += decimal.Parse(arr[i, j]);
                    }
                    else
                    {
                        arr[i, j] = sum.ToString();
                    }
                }
                
            }


            DataTable t = ConvertToDataTable(Cols, arr);



                return t;
        }


        public static DataTable ConvertToDataTable(List<string> ColumnNames, string[,] Arrays)
        {
            DataTable dt = new DataTable();

            ColumnNames.Insert(0, "科室");
            ColumnNames.Add("合计");
            foreach (string ColumnName in ColumnNames)
            {
                dt.Columns.Add(ColumnName, typeof(string));
            }

            for (int i1 = 0; i1 < Arrays.GetLength(0); i1++)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < ColumnNames.Count; i++)
                {
                    dr[i] = Arrays[i1, i].ToString();
                }
                dt.Rows.Add(dr);
            }

            return dt;

        }  



        private List<string> GetDistinctDataOfCol(DataTable dt, int ColNo)
        {
            List<string> lst = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmpstr = dt.Rows[i][ColNo].ToString();
                if (!lst.Contains(tmpstr))
                {
                    lst.Add(tmpstr);
                }   
            }
            return lst;
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

        private void FrmBussinessReportOfOperation_Resize(object sender, EventArgs e)
        {
            this.label1.Left = (this.Width - this.label1.Width) / 2;
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
        }

    }
}