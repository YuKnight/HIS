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


    public partial class FrmBussinessReportOfItem : Form
    { 
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private long Nrow = 0;//统计时发票记录张数
        private long Jkid = 0;//交款ID
        private int _itemCode;
        private ClsParams _param;
        private List<string> _dt;
        public FrmBussinessReportOfItem(int itemcode ,MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            _itemCode = itemcode;

            this.Text = _chineseName;
            label1.Text = _chineseName;


        }

        /// <summary>
        /// 统计数据
        /// </summary>
        private void GetData()
        {
            try
            {

                    ParameterEx[] parameters = new ParameterEx[5];
                    this._param = new ClsParams();

                    parameters[0].Text = "@sourceType";  
                    parameters[0].Value = cmbSource.SelectedIndex;
                    this._param.sourceType = cmbSource.SelectedIndex;
                    parameters[1].Text = "@ksType";
                    parameters[1].Value = cmbGroup.SelectedIndex== 2 ? 0:(cmbGroup.SelectedIndex+1);
                    this._param.ksType = cmbGroup.SelectedIndex == 2 ? 0 : (cmbGroup.SelectedIndex + 1);
                    parameters[2].Text = "@rq1";
                    parameters[2].Value = dtpBjksj.Value.ToString();
                    this._param.rq1 = dtpBjksj.Value;
                    parameters[3].Text = "@rq2";                
                    parameters[3].Value = dtpEjksj.Value.ToString();
                    this._param.rq2 = dtpEjksj.Value;
                    parameters[4].Text = "@isZXKS";
                    parameters[4].Value = cmbDepartMentType.SelectedIndex;
                    this._param.isZXKS = cmbDepartMentType.SelectedIndex;
                    this._param.itemCode = this._itemCode;
                    


                   
                    DataSet dset = new DataSet();
                    if (this._itemCode == 0 || this._itemCode == 3 || this._itemCode == 4)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("report_BusinessIncomeReport_Drugs", parameters, dset, "sfmx", 60);
                    }
                    else if (this._itemCode == 1)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("ReportBuessinessOfMedicalTechnology", parameters, dset, "sfmx", 30);
                    }
                    else if (this._itemCode == 2)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("ReportBusinessOfMedicalService", parameters, dset, "sfmx", 30);
                    }

                    for (int i = 0; i < dset.Tables[0].Columns.Count; i++)
                    {
                        if (dset.Tables[0].Columns[i].ColumnName.ToLower() == "ksdm")
                        {
                            this._dt = new List<string>();
                            for (int j = 0; j < dset.Tables[0].Rows.Count; j++)
                            {
                                string ksdm = dset.Tables[0].Rows[j][i].ToString();
                                this._dt.Add(ksdm);
                            }
                        }
                    }

                    DataTable dt = dset.Tables[0];
                    #region 全部药品比例
                    if (this._itemCode == 0)
                    {
                        AddColumn(dt, "西药比例", dt.Columns["西药"].Ordinal);
                        AddColumn(dt, "中草药比例", dt.Columns["中草药"].Ordinal);
                        AddColumn(dt, "中成药比例", dt.Columns["中成药"].Ordinal);
                        AddColumn(dt, "自制药比例", dt.Columns["自制药"].Ordinal);
                        AddColumn(dt, "膏方比例", dt.Columns["膏方"].Ordinal);
                        AddColumn(dt, "其他比例", dt.Columns["其他"].Ordinal);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            decimal tmp = 0;
                            if (decimal.Parse(dt.Rows[i]["合计"].ToString()) != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["西药"].ToString()) / decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                                dt.Rows[i]["西药比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["西药比例"] = "/";
                            }

                            if (decimal.Parse(dt.Rows[i]["合计"].ToString()) != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["中草药"].ToString()) / decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                                dt.Rows[i]["中草药比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["中草药比例"] = "/";
                            }

                            if (decimal.Parse(dt.Rows[i]["合计"].ToString()) != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["中成药"].ToString()) / decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                                dt.Rows[i]["中成药比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["中成药比例"] = "/";
                            }

                            if (decimal.Parse(dt.Rows[i]["合计"].ToString()) != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["自制药"].ToString()) / decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                                dt.Rows[i]["自制药比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["自制药比例"] = "/";
                            }

                            if (decimal.Parse(dt.Rows[i]["合计"].ToString()) != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["膏方"].ToString()) / decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                                dt.Rows[i]["膏方比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["膏方比例"] = "/";
                            }

                            if (decimal.Parse(dt.Rows[i]["合计"].ToString()) != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["其他"].ToString()) / decimal.Parse(dt.Rows[i]["合计"].ToString()) * 100;
                                dt.Rows[i]["其他比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["其他比例"] = "/";
                            }
                        }
                    }
                    #endregion

                    #region 中草药自制药比例
                    if (this._itemCode == 3)
                    {
                  
                        AddColumn(dt, "中草药比例", dt.Columns["中草药"].Ordinal);
                        AddColumn(dt, "自制药比例", dt.Columns["自制药"].Ordinal);
                        AddColumn(dt, "膏方比例", dt.Columns["膏方"].Ordinal);
                        AddColumn(dt, "中/制/膏方比例", dt.Columns["膏方比例"].Ordinal);
           
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            decimal tmp = 0;
                            decimal sum= decimal.Parse(dt.Rows[i]["合计"].ToString())-decimal.Parse(dt.Rows[i]["膏方"].ToString()) ;

                            if (sum != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["中草药"].ToString()) /sum * 100;
                                dt.Rows[i]["中草药比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["中草药比例"] = "/";
                            }


                            if (sum != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["自制药"].ToString()) /sum * 100;
                                dt.Rows[i]["自制药比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["自制药比例"] = "/";
                            }

                            if (sum != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["膏方"].ToString()) / sum * 100;
                                dt.Rows[i]["膏方比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["膏方比例"] = "/";
                            }

                            if (sum != 0)
                            {
                                tmp = (decimal.Parse(dt.Rows[i]["膏方"].ToString()) + decimal.Parse(dt.Rows[i]["自制药"].ToString()) + decimal.Parse(dt.Rows[i]["中草药"].ToString())) / sum * 100;
                                dt.Rows[i]["中/制/膏方比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["中/制/膏方比例"] = "/";
                            }

                          
                        }
                    }
                    #endregion

                     #region 西药中成药比例
                    if (this._itemCode == 4)
                    {
                  
                        AddColumn(dt, "西药比例", dt.Columns["西药"].Ordinal);
                        AddColumn(dt, "中成药比例", dt.Columns["中成药"].Ordinal);
           
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            decimal tmp = 0;
                            decimal sum= decimal.Parse(dt.Rows[i]["西药"].ToString())+decimal.Parse(dt.Rows[i]["中成药"].ToString()) ;

                            if (sum != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["西药"].ToString()) / sum * 100;
                                dt.Rows[i]["西药比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["西药比例"] = "/";
                            }


                            if (sum != 0)
                            {
                                tmp = decimal.Parse(dt.Rows[i]["中成药"].ToString()) / sum * 100;
                                dt.Rows[i]["中成药比例"] = tmp.ToString("f2");
                            }
                            else
                            {
                                dt.Rows[i]["中成药比例"] = "/";
                            }

                          
                        }
                    }
                    #endregion

                    Fun.AddRowtNo(dt);
                    this.dataGridView1.Columns.Clear();
                    this.dataGridView1.DataSource = dt;
                    for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                    {
                        this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm" || this.dataGridView1.Columns[i].Name.ToLower() == "sort")
                        {
                           this.dataGridView1.Columns[i].Visible = false;
                        }
                        if(this._itemCode>2 && this.dataGridView1.Columns[i].Name.Substring(this.dataGridView1.Columns[i].Name.Length - 2) == "人次")
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


        /// <summary>
        /// 为DateTable增加列，并插入指定位置
        /// </summary>
        /// <param name="dt">表数据</param>
        /// <param name="ColumnName">列名</param>
        /// <param name="PreColIndex">插入位置前面列序号</param>
        /// <returns></returns>
        private DataTable AddColumn(DataTable dt,string ColumnName , int PreColIndex)
        {
            dt.Columns.Add(ColumnName);
            for (int i = dt.Columns.Count - 1; i > PreColIndex+1; i--)
            {
                
                dt.Columns[i].SetOrdinal(i-1);
            }
            return dt;
        }




        private void FrmBussinessReportOfItem_Load(object sender, EventArgs e)
        {

            //FunAddComboBox.AddOperator(true, cmbuser);
            this.WindowState = FormWindowState.Maximized;

            
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");



            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');


            //cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            //if (cmbuser.SelectedValue == null) cmbuser.SelectedValue = "0";
            //if (cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
            //    this.cmbuser.SelectedValue = "0";
            //FullCmbSfDept(); 
            //FunAddComboBox.AddJgbm(true, cmbSource, InstanceForm.BDatabase);
            cmbSource.SelectedIndex = 0;
            cmbGroup.SelectedIndex = 0;
            cmbDepartMentType.SelectedIndex = 0;
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
           

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


                ParameterEx[] parameters = new ParameterEx[5];

                parameters[0].Text = "类型";
                parameters[0].Value = this._chineseName;

                parameters[1].Text = "开始时间";
                parameters[1].Value = dtpBjksj.Value.ToString("yyyy-MM-dd");

                parameters[2].Text = "结束时间";
                parameters[2].Value = dtpBjksj.Value.ToString("yyyy-MM-dd");

                parameters[3].Text = "数据源";
                parameters[3].Value = cmbSource.SelectedText;

                parameters[4].Text = "科室类型";
                parameters[4].Value = cmbDepartMentType.Text;
                       

                TrasenFrame.Forms.FrmReportView f = null;

                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\单项收入报表(经管).rpt", parameters);
              
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

        private void FrmBussinessReportOfItem_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
            this.label1.Left = (this.Width - this.label1.Width) / 2;
        }

        private void buttj_Click_1(object sender, EventArgs e)
        {

        }

        private void butprint_Click_1(object sender, EventArgs e)
        {

        }

        private void butexcel_Click_1(object sender, EventArgs e)
        {

        }

        private void butquit_Click_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 单元格点击处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this._itemCode > 2) return;
            if (e.RowIndex < 0) return;
            if (this._itemCode == 0 && this.dataGridView1.Columns[e.ColumnIndex].Name.Substring(this.dataGridView1.Columns[e.ColumnIndex].Name.Length - 2) == "比例") return;
            if ( this.dataGridView1.Columns[e.ColumnIndex].Name.Substring(this.dataGridView1.Columns[e.ColumnIndex].Name.Length - 2) == "人次") return;

            if (e.ColumnIndex < 2 || this.dataGridView1.Columns[e.ColumnIndex].Name == "合计")
            {
                DataTable dt = (DataTable)this.dataGridView1.DataSource;
                string id = this._dt[e.RowIndex];
                if (!string.IsNullOrEmpty(id))
                {
                    this._param.departmentID = id;
                }
                this._param.itemStringOfCol = "";
                Frm_BussinessReportOfDoc fm = new Frm_BussinessReportOfDoc(this._param);
                fm.ShowDialog();
            }
            else
            {
                DataTable dt = (DataTable)this.dataGridView1.DataSource;
                string id = this._dt[e.RowIndex];
                if (!string.IsNullOrEmpty(id))
                {
                    this._param.departmentID = id;
                }
                this._param.itemStringOfCol = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                Frm_BussinessReportOfDoc fm = new Frm_BussinessReportOfDoc(this._param);
                fm.ShowDialog();
            }


            this._param.departmentID = "0";
            this._param.itemStringOfCol = "";
        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        /// <summary>
        /// 列头点击处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this._itemCode > 2) return;
            if (e.ColumnIndex < 2) return;
            if (this._itemCode == 0 && this.dataGridView1.Columns[e.ColumnIndex].Name.Substring(this.dataGridView1.Columns[e.ColumnIndex].Name.Length - 2) == "比例") return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name.Substring(this.dataGridView1.Columns[e.ColumnIndex].Name.Length - 2) == "人次") return;

            if (dataGridView1.Columns[e.ColumnIndex].HeaderText != "合计" )
            {
                this._param.itemStringOfCol = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                this._param.departmentID = "0";
                Frm_BussinessReportOfDoc fm = new Frm_BussinessReportOfDoc(this._param);
                fm.ShowDialog();
                this._param.departmentID = "0";
                this._param.itemStringOfCol = "";
            }
            else
            {
                this._param.departmentID = "0";
                this._param.itemStringOfCol = "";
                Frm_BussinessReportOfDoc fm = new Frm_BussinessReportOfDoc(this._param);
                fm.ShowDialog();
            }
        }

 


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        /// <summary>
        /// 行头点击处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this._itemCode > 2) return;
            if (e.RowIndex < 0) return;

            // if (this._itemCode == 0 && this.dataGridView1.Columns[e.ColumnIndex].Name.Substring(this.dataGridView1.Columns[e.ColumnIndex].Name.Length - 2) == "比例") return;


            DataTable dt = (DataTable)this.dataGridView1.DataSource;
            string id = this._dt[e.RowIndex];
            if (!string.IsNullOrEmpty(id))
            {
                this._param.departmentID = id;
            }
            this._param.itemStringOfCol = "";
            Frm_BussinessReportOfDoc fm = new Frm_BussinessReportOfDoc(this._param);
            fm.ShowDialog();
           
        }


                                                              







        

    }
}