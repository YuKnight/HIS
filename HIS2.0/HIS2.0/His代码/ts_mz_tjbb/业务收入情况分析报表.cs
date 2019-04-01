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
    public partial class BusinessIncomeReport : Form
    {

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private long Nrow = 0;//统计时发票记录张数
        private long Jkid = 0;//交款ID
        private int _deptID;

        public BusinessIncomeReport(MenuTag menuTag, string chineseName, Form mdiParent,int nType)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            label1.Text = _chineseName;

            if (nType == 0)
            {
                this._deptID = 0;
            }
            else
            {
                this._deptID = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
            }

        }


        private void GetData()
        {
            try
            {
                try
                {
                    ParameterEx[] parameters = new ParameterEx[5];

                    parameters[0].Text = "@sourceType";  
                    parameters[0].Value = cmbSource.SelectedIndex;
                    parameters[1].Text = "@ksType";

                    int j = 0;
                    if (cmbGroup.SelectedIndex == 2)
                    {
                        j = 0;
                    }
                    else if (cmbGroup.SelectedIndex < 2)
                    {
                        j = cmbGroup.SelectedIndex + 1;
                    }
                    else
                    {
                        j= cmbGroup.SelectedIndex;
                    }
                    parameters[1].Value = j.ToString();

                    parameters[2].Text = "@rq1";
                    parameters[2].Value = dtpBjksj.Value.ToString();

                    parameters[3].Text = "@rq2";
                    parameters[3].Value = dtpEjksj.Value.ToString();

                    parameters[4].Text = "@deptID";
                    parameters[4].Value = this._deptID;
                   
                    DataSet dset = new DataSet();
        
                    TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("report_BusinessIncomeReport", parameters, dset, "sfmx", 30);
           
                    Fun.AddRowtNo(dset.Tables[0]);
                    this.dataGridView1.Columns.Clear();
                    this.dataGridView1.DataSource = dset.Tables[0];
                    for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                    {
                        this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                catch (System.Exception err)//如果没有8个参数，那么就条用7个的
                {
                    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BusinessIncomeReport_Load(object sender, EventArgs e)
        {


            //FunAddComboBox.AddOperator(true, cmbuser);
            this.WindowState = FormWindowState.Maximized;

            
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            if (this._deptID != 0)
            {
                this.label5.Visible = false;
                this.label2.Visible = false;
                this.cmbSource.Visible = false;
                this.cmbGroup.Visible = false;
            }



            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');


            //cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            //if (cmbuser.SelectedValue == null) cmbuser.SelectedValue = "0";
            //if (cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
            //    this.cmbuser.SelectedValue = "0";
            cmbFG.Items.Add("列宽适应网格内容");
            cmbFG.Items.Add("列宽仅适应有数据的区域");
            cmbFG.SelectedIndex = 0;
            //FullCmbSfDept(); 
            //FunAddComboBox.AddJgbm(true, cmbSource, InstanceForm.BDatabase);
            cmbSource.SelectedIndex = 0;
            cmbGroup.SelectedIndex = 0;

        }
        /// <summary>
        /// 填充收费科室下拉 add by zp 2013-05-23 株洲省直中医院需求
        /// </summary>
        //private void FullCmbSfDept()
        //{
        //    try
        //    {
        //        SystemCfg cfg1086 = new SystemCfg(1086);
        //        string sql = @"select dept_id,name from jc_dept_property where dept_id in (" + cfg1086.Config + ")";
        //        DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
        //        DataRow dr = dt.NewRow();
        //        dr["dept_id"] = "-1";
        //        dr["name"] = "所有收费科室";
        //        dt.Rows.InsertAt(dr, 0);
        //        //this.Cmb_SfDept.DataSource = dt;
        //        //this.Cmb_SfDept.DisplayMember = "name";
        //        //this.Cmb_SfDept.ValueMember = "dept_id";
        //        //this.Cmb_SfDept.SelectedIndex = 0;
        //    }
        //    catch (Exception ea)
        //    {
        //        MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
        //    }
        //}

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void buttj_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = null;
                string ss = "";
                tb = (DataTable)this.dataGridView1.DataSource;
                ss = "业务收入情况分析报表";



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
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
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

                parameters[2].Text = "数据源";
                parameters[2].Value = cmbSource.Text;
                       

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

        

    }
}