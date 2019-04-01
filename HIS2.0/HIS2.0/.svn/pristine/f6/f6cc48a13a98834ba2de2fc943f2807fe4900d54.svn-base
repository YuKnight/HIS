using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using YpClass;
using TrasenClasses.GeneralClasses;

namespace ts_yf_cx
{
    public partial class Frmkssdddtj_zy : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private DataTable Tbks;
        public Frmkssdddtj_zy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void Frmksszbtj_Load(object sender, EventArgs e)
        {
            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
            //this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;

            Tbks = Getks();

            if (_menuTag.Function_Name == "Fun_ts_yf_ksstjzb_zyyp_ks")
            {
                rdoks.Checked = true;
                rdoyp.Enabled = false;
                rdoys.Enabled = false;
                txtks.Text = InstanceForm.BCurrentDept.DeptName.Trim();
                txtks.Tag = InstanceForm.BCurrentDept.DeptId.ToString();
                txtks.Enabled = false;
            }
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
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Value = dtpBeginTime.Value.ToShortDateString() + "";
                parameters[1].Value = dtpEndTime.Value.ToShortDateString() + "";
                parameters[2].Value =tjlx;
                parameters[3].Value = Convertor.IsNull(txtks.Tag, "0");

                parameters[0].Text = "@rq1";
                parameters[1].Text = "@rq2";
                parameters[2].Text = "@tjlx";
                parameters[3].Text = "@ksdm";

                DataSet dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_YP_KSSZB_ZYDDD", parameters, dset, "kss", 30);

                dset.Tables[0].TableName = "Tb";
                myDataGrid1.DataSource = dset.Tables[0];

                txtDDD.Text = dset.Tables[1].Rows[0]["抗菌药物累计DDD"].ToString();
                txtoutPatient.Text = dset.Tables[1].Rows[0]["出院人数"].ToString();
                txtAvgOutpatient.Text = dset.Tables[1].Rows[0]["平均住院天数"].ToString();
                txtpatientCount.Text = dset.Tables[1].Rows[0]["同期收治忠者天数"].ToString();
                txtqiangdu.Text = dset.Tables[1].Rows[0]["抗菌药物使用强度"].ToString();
                txtksssyl.Text = dset.Tables[1].Rows[0]["抗生素使用率"].ToString();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                
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
                for (int i = 0; i <=tb.Columns.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[tb.Columns[i].ColumnName].Width > 0)
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
                bz = "抗菌药物累计DDD:" + txtDDD.Text +"  出院人数:" + txtoutPatient.Text +"  平均住院天数:" + txtAvgOutpatient.Text + "  同期收治忠者天数:" + txtpatientCount.Text + "  抗菌药物使用强度:"+txtqiangdu.Text;
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
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[tb.Columns[i].ColumnName].Width > 0)
                        objData[0, colIndex++] = myDataGrid1.TableStyles[0].GridColumnStyles[tb.Columns[i].ColumnName].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        if (myDataGrid1.TableStyles[0].GridColumnStyles[tb.Columns[j].ColumnName].Width > 0)
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

        private void ExportToExcel(myDataGrid.myDataGrid pmydatagrid)
        {
           
        }

        private void rdoyp_CheckedChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)myDataGrid1.DataSource;
            if (tb != null) tb.Rows.Clear();

            txtks.Visible = rdoks.Checked == true ? true : false;
            if (rdoks.Checked == true) txtks.Focus();
        }

        private void dtpBeginTime_ValueChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)myDataGrid1.DataSource;
            if (tb != null) tb.Rows.Clear();
        }


        public  DataTable Getks()
        {
            string ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where layer=3 and  jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code not in('001','002','003','009'))";
            return InstanceForm.BDatabase.GetDataTable(ssql);
        }

        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8)
            {
                txtks.Text = "";
                txtks.Tag = "0";
                return;
            }
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
                    btnSelect_Click(sender, e);

                    e.Handled = true;
                }
            }
            else
            {
                btnSelect.Focus();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtqiangdu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}