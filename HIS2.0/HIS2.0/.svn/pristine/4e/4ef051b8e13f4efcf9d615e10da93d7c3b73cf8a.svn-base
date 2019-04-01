using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using ts_mz_class;

namespace ts_yp_ksstj
{
    public partial class FrmzyksstjI : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbks;//挂号科室数据
        private DataTable Tbys;//挂号医生数据
        public FrmzyksstjI(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            if (_menuTag.Function_Name == "Fun_ts_yp_ksstj_zyyp_ks")
            {
                txtks.Tag = InstanceForm.BCurrentDept.DeptId;
                txtks.Text = InstanceForm.BCurrentDept.DeptName;
                txtks.Enabled = false;
            }

            this.WindowState = FormWindowState.Maximized;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                btnSelect.Enabled = false;

                int tjlx = 0;
                if (rdoks.Checked == true) tjlx = 1;
                if (rdoys.Checked == true) tjlx = 2;
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Value = dtp1.Value.ToShortDateString() + "";
                parameters[1].Value = dtp2.Value.ToShortDateString() + "";
                parameters[2].Value = Convertor.IsNull(txtks.Tag, "0");
                parameters[3].Value = Convertor.IsNull(txtys.Tag, "0");
                parameters[4].Value = tjlx;
                

                parameters[0].Text = "@rq1";
                parameters[1].Text = "@rq2";
                parameters[2].Text = "@ksdm";
                parameters[3].Text = "@ysdm";
                parameters[4].Text = "@tjlx";
               

                DataSet dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_YP_KSSZB_TJ_QBBR", parameters, dset, "kss", 300);

                dset.Tables[0].TableName = "Tb";
                this.dataGridView1.DataSource = dset.Tables[0];
                this.dataGridView2.DataSource = dset.Tables[1];
                this.dataGridView3.DataSource = dset.Tables[2];
                this.dataGridView4.DataSource = dset.Tables[3];

                label11.Text = dset.Tables[4].Rows[0][0].ToString();
                label22.Text = dset.Tables[4].Rows[0][1].ToString();
                label33.Text = dset.Tables[4].Rows[0][2].ToString();
                label44.Text = dset.Tables[4].Rows[0][3].ToString();


                DataRow rows=null;
                
                if (rdoks.Checked == true && dset.Tables[0].Rows.Count> 0) rows = dset.Tables[0].Rows[dset.Tables[0].Rows.Count-1];
                if (rdoys.Checked == true && dset.Tables[0].Rows.Count > 0) rows = dset.Tables[0].Rows[dset.Tables[0].Rows.Count - 1];

                btnSelect.Enabled = true;


            }
            catch (System.Exception err)
            {
                btnSelect.Enabled = true;
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        private void txtys_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;

            if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
            {
                txtys.Tag = "";
                txtys.Text = "";
                e.Handled = true;
                return;
            }

            if ((int)e.KeyChar != 13 && Convertor.IsNumeric(e.KeyChar.ToString()) == false)
            {

                //if (_menuTag.Function_Name == "Fun_ts_yp_ksstj_zyyp_ks")
                //    Tbys = Fun.GetGhys(Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0")),0, InstanceForm.BDatabase);

                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "py_code", "wb_code", "code" };//, "code" Modify By Tany 2008-12-19 不一定有工号
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtys;
                f.Font = txtys.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtys.Focus();
                }
                else
                {
                    txtys.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtys.Text = f.SelectDataRow["name"].ToString().Trim();
                    e.Handled = true;
                }

            }


        }

        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
            {
                txtks.Text = "";
                txtks.Tag = "";
                return;
            }

            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = txtks;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtks.Focus();
                    return;
                }
                else
                {
                    txtks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtks.Text = f.SelectDataRow["name"].ToString().Trim();
                    e.Handled = true;
                }
            }

        }

        private void Frmzydddtj_Load(object sender, EventArgs e)
        {
            Tbks = Getks();
            //if (_menuTag.Function_Name != "Fun_ts_yp_ksstj_zyyp_ks")
                Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
            //else
            //    Tbys = Fun.GetGhys(InstanceForm.BCurrentDept.DeptId,0, InstanceForm.BDatabase);

            this.WindowState = FormWindowState.Maximized;
            this.rdoks.Checked = true;
        }

        public DataTable Getks()
        {
            string ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where layer=3 and  jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code not in('001','002','003','009'))";
            return InstanceForm.BDatabase.GetDataTable(ssql);
        }

        private void rdoyp_CheckedChanged(object sender, EventArgs e)
        {
            DataTable tb1 = (DataTable)dataGridView1.DataSource;
            if (tb1 != null) tb1.Clear();

            DataTable tb2 = (DataTable)dataGridView2.DataSource;
            if (tb2 != null) tb2.Clear();

            DataTable tb3 = (DataTable)dataGridView3.DataSource;
            if (tb3 != null) tb3.Clear();

            DataTable tb4 = (DataTable)dataGridView4.DataSource;
            if (tb4 != null) tb4.Clear();

            txtks.Enabled = rdoks.Checked == true ? true : false;
            txtys.Enabled = rdoys.Checked == true ? true : false;

            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();
            dataGridView4.Columns.Clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = null;
                DataGridView dv=null;

                if (tabControl1.SelectedTab == this.tabPage1) { tb = (DataTable)this.dataGridView1.DataSource; dv = this.dataGridView1; }
                if (tabControl1.SelectedTab == this.tabPage2) {tb = (DataTable)this.dataGridView2.DataSource;dv = this.dataGridView2; }
                if (tabControl1.SelectedTab == this.tabPage3) {tb = (DataTable)this.dataGridView3.DataSource;dv = this.dataGridView3; }
                if (tabControl1.SelectedTab == this.tabPage4) { tb = (DataTable)this.dataGridView4.DataSource; dv = this.dataGridView4; }

                
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
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dv.Columns[tb.Columns[i].ColumnName].Width > 0)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = this.Text;
                xlApp.ActiveCell.Font.Size = 15;
                xlApp.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]).Columns.AutoFit();
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                //查询条件
                string bz = "";
                bz = "统计日期:" + dtp1.Value.ToShortDateString() + " 到:" + dtp2.Value.ToShortDateString() + "统计说明:(" + this.tabControl1.SelectedTab.Text + ")";
                string swhere = "";
                if (rdoks.Checked == true) swhere = txtks.Text.Trim() == "" ? "科室:全部 " : "科室:" + txtks.Text.Trim();
                if (rdoys.Checked == true) swhere = txtks.Text.Trim() == "" ? swhere+ "医生:全部 " : "医生:" + txtys.Text.Trim();
                // 设置条件
                Excel.Range rangeT = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT = new object[1, 1];
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                objDataT[0, 0] = bz;
                rangeT.Value2 = objDataT;

                rangeT = xlSheet.get_Range(xlApp.Cells[3, 1], xlApp.Cells[3, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT2 = new object[1, 1];
                objDataT2[0, 0] = swhere;
                rangeT.Value2 = objDataT2;




                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dv.Columns[tb.Columns[i].ColumnName].Width > 0)
                        objData[0, colIndex++] = dv.Columns[tb.Columns[i].ColumnName].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        if (dv.Columns[tb.Columns[j].ColumnName].Width > 0)
                        {
                            objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Font.Size = 9;

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtys_TextChanged(object sender, EventArgs e)
        {
            if (txtys.Text.Trim() == "")
            {
                txtys.Tag = "";
                txtys.Text = "";

            }
        }

        private void txtks_TextChanged(object sender, EventArgs e)
        {
            if (txtks.Text.Trim() == "")
            {
                txtks.Tag = "";
                txtks.Text = "";

            }
        }



    }



}