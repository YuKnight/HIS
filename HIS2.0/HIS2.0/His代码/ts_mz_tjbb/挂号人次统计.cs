using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 

namespace ts_mz_tjbb
{
    public partial class Frmghrctj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private DataSet dset;
        public Frmghrctj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void Frmsk_jktj_Load(object sender, EventArgs e)
        {
            if (TrasenFrame.Classes.Constant.HospitalName == "邵阳市第一人民医院")
            {
                checkBox2.Visible = true;
                checkBox2.Checked = true;
            } 

            //FunAddComboBox.AddOperator(true, cmbuser);
            this.WindowState = FormWindowState.Maximized;

            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");


            //cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            //if (cmbuser.SelectedValue == null) cmbuser.SelectedValue = "0";
            //if (cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
            //    this.cmbuser.SelectedValue = "0";
            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

        }

       

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                //Modify By Zj 2012-12-28 增加统计口径
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@jgbm";
                parameters[2].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                parameters[3].Text = "@tjlx";
                parameters[3].Value = radioButton1.Checked ? 0 : 1;
                if (TrasenFrame.Classes.Constant.HospitalName == "邵阳市第一人民医院")
                {
                    parameters[3].Value = checkBox2.Checked ? 1 : 0;//Modify by zouchihua 2013-5-22 邵阳这里是区分合并还是不合并
                }

                dset = new DataSet();
                //add by zouchihua 2013-4-2 增加医保人次统计 
                if(CHbYb.Checked==false)
                  TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_gh_ghrctj", parameters, dset, "sfmx", 30);
                else
                  TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_gh_ghrctj_YBLX", parameters, dset, "sfmx", 30);
                //DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_MZSF_TJ_gh_ghrctj", parameters, 30);

                for (int i = 0; i <= dset.Tables[2].Columns.Count - 1; i++)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = dset.Tables[2].Columns[i].ColumnName != "急诊小计" ? dset.Tables[2].Columns[i].ColumnName.Replace("急诊", "") : dset.Tables[2].Columns[i].ColumnName;
                    col.DataPropertyName = dset.Tables[2].Columns[i].ColumnName;
                    col.Name = dset.Tables[2].Columns[i].ColumnName;
                    switch (col.Name)
                    {
                        case "序号":
                            col.Width = 40;
                            break;
                        case "科室":
                            col.Width = 100;
                            break;
                        default:
                            col.Width=50;
                            break;
                    }
                   
                    if (dataGridView1.Columns.Contains(dset.Tables[2].Columns[i].ColumnName) == false)
                        dataGridView1.Columns.Add(col);
                }
                Fun.AddRowtNo(dset.Tables[2]);
                this.dataGridView1.DataSource = dset.Tables[2];

                //for (int i = 0; i <= tb.Columns.Count - 1; i++)
                //{
                //    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                //    col.HeaderText = tb.Columns[i].ColumnName.Replace("急诊", "");
                //    col.DataPropertyName = tb.Columns[i].ColumnName;
                //    col.Name = tb.Columns[i].ColumnName;
                //    if (dataGridView1.Columns.Contains(tb.Columns[i].ColumnName) == false)
                //        dataGridView1.Columns.Add(col);
                //}


                //Fun.AddRowtNo(tb);
                //this.dataGridView1.DataSource =tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void cmbFG_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbFG.SelectedIndex == 0)
            //{
            //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            //    dataGridView1.ColumnHeadersHeight = 30;
            //    dataGridView1.Refresh();
            //}
            //if (cmbFG.SelectedIndex == 1)
            //{
            //    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            //}
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if ( dataGridView1.DataSource == null )
                {
                    MessageBox.Show( "没有数据！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }

                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butexcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件

                string swhere = "日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() +"  部门名称:"+cmbjgbm.Text;;


                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    if (checkBox1.Checked == true)
                    {
                        if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "科室")
                        {
                            SumColCount = SumColCount + 1;
                            myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName+"  ";
                        }
                    }
                    else
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName+"  ";
                    }

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        if (checkBox1.Checked == true)
                        {
                            if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "科室")
                            {
                                ncol = ncol + 1;
                                myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                            }
                        }
                        else
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                        }
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = Constant.HospitalName+label1.Text;
                myExcel.Cells[1, 1] = ss ;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3, 1] = swhere.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;


                //让Excel文件可见
                myExcel.Visible = true;
                this.butexcel.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butexcel.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {
                if ( dataGridView1.DataSource == null )
                {
                    MessageBox.Show( "没有数据！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }
                DataTable tbmx = (DataTable)dataGridView1.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow  myrow = Dset.收费项目.NewRow();
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
                

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                string jsfs = "";


                string ssql = "";
                parameters[2].Text = "备注";
                parameters[2].Value = dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString() + "  " + ssql + " 部门名称:" + cmbjgbm.Text;

                parameters[3].Text = "现金大写";
                parameters[3].Value = "";

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_挂号人次统计.rpt", parameters);
               
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

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb!=null)
               tb.Rows.Clear();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dset == null) return;

            //for(int i=0;i<=dset.Tables[0].Columns.Count-1;i++)
            //{
            //    string[] sArray = dset.Tables[0].Rows[0][i].ToString().Split(new char[1] { ',' });
            //    Utility.exGridView d = new Utility.exGridView();
            //    List<string> list= new List<string>(sArray.Length);
            //    for (int j = 0; j <= sArray.Length - 1; j++)
            //        list.Add(sArray[j]);
            //    d.MergeHeader(sender, e, list, dset.Tables[0].Columns[i].ColumnName);
            //}

            for (int i = 0; i <= dset.Tables[1].Columns.Count - 1; i++)
            {
                if (dataGridView1.ColumnCount>=dset.Tables[1].Columns.Count)
                    dataGridView1.Columns[i].Width = Convert.ToInt32(dset.Tables[1].Rows[0][i]);
            }

        }



    }
}