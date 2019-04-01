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
using TrasenFrame.Forms;
using System.Collections.Generic;

namespace ts_mz_tjbb
{
    public partial class FrmMzysXmtj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbks;//挂号科室数据
        private DataTable Tbys;//挂号医生数据

        public FrmMzysXmtj()
        {
            InitializeComponent();
        }

        public FrmMzysXmtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            //this.user = user;
            //this.dept = dept;
            //this.ActiveControl = btnTj;
            
            if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_DeptSrbl")
            {
                this.txtDept.Tag = InstanceForm.BCurrentDept.DeptId.ToString();
                this.txtDept.Text = InstanceForm.BCurrentDept.DeptName;
                txtDept.Enabled = true;
                txtUser.Enabled = true;
                
            }
            if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_UserSrbl")
            {
                this.txtUser.Tag = InstanceForm.BCurrentUser.EmployeeId.ToString();
                this.txtUser.Text = InstanceForm.BCurrentUser.Name;
                this.txtUser.Enabled = false;
                this.txtDept.Enabled = true;
            }

            if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_DeptSrbl_ks")
            {
                this.txtDept.Tag = InstanceForm.BCurrentDept.DeptId.ToString();
                this.txtDept.Text = InstanceForm.BCurrentDept.DeptName;
                txtDept.Enabled = false;
                txtUser.Enabled = true;
            }
        }



        private void btnGb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您要关闭此窗体吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

   

        private void btnTj_Click(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            loadDataGridView();
            Cursor.Current = Cursors.Default;
        }

        private void loadDataGridView()
        {
            try
            {
                ParameterEx[] parameter = new ParameterEx[7];
                parameter[0].Text = "@RQ1";
                parameter[0].Value = dtpTjKs.Value.Date.ToString("yyyy-MM-dd") + " 00:00:00";
                parameter[1].Text = "@RQ2";
                parameter[1].Value = dtpTjJs.Value.Date.ToString("yyyy-MM-dd") + " 23:59:59";
                parameter[2].Text = "@KSDM";
                parameter[2].Value = txtDept.Tag == null ? 0 : txtDept.Tag;
                parameter[3].Text = "@YSDM";
                parameter[3].Value = txtUser.Tag == null ? 0 : txtUser.Tag;
                parameter[4].Text = "@jgbm";
                parameter[4].Value = cmbjgbm.SelectedValue.ToString();
                parameter[5].Text = "@ERR_CODE";
                parameter[5].Value = 0;
                parameter[6].Text = "@ERR_TEXT";
                parameter[6].Value = "";

                System.Data.DataTable dt = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_MZYS_SELECT_INFOTJ", parameter, 100);
                PubStaticFun.SetDataGridIncreaseRowNumber(dt, "序号");
                dataGridView1.DataSource = dt;
                //dataGridView1.Columns["NO"].HeaderText = "序号";
                //dataGridView1.Columns["序号"].Width = 35;
                //dataGridView1.Columns["医生"].Width = 55;
                if (dataGridView1.Columns.Contains("YSDM")==true)
                dataGridView1.Columns["ysdm"].Visible = false;
                //dataGridView1.Columns["医生"].HeaderText = "医生";
                //dataGridView1.Columns["医生"].Width = 55;
                //dataGridView1.Columns["ZJE"].HeaderText = "总金额";
                //dataGridView1.Columns["ZJE"].Width = 65;
                //dataGridView1.Columns["YPJE"].HeaderText = "药品金额";
                //dataGridView1.Columns["YPJE"].Width = 65;
                //dataGridView1.Columns["YPBFB"].HeaderText = "药品百分比";
                //dataGridView1.Columns["YPBFB"].Width = 65;
                //dataGridView1.Columns["ITEMJE"].HeaderText = "项目金额";
                //dataGridView1.Columns["ITEMJE"].Width = 65;
                //dataGridView1.Columns["XMBFB"].HeaderText = "项目百分比";
                //dataGridView1.Columns["XMBFB"].Width = 65;
                //dataGridView1.Columns["CFLS"].HeaderText = "处方流失(张)";
                //dataGridView1.Columns["CFLS"].Width = 65;
                //dataGridView1.Columns["CFLSJE"].HeaderText = "处方流失金额(元)";
                //dataGridView1.Columns["CFLSJE"].Width = 65;
                //dataGridView1.Columns["JZRC"].HeaderText = "接诊人次";
                //dataGridView1.Columns["JZRC"].Width = 55;
                //dataGridView1.Columns["ZYZ"].HeaderText = "住院证";
                //dataGridView1.Columns["ZYZ"].Width = 55;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDy_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource == null)
                {
                    MessageBox.Show("没有数据！");
                    return;
                }
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


                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                string bz = "";
                if (txtDept.Text.Trim() != "")
                    bz = bz + " 开单科室:" + txtDept.Text.Trim();
                if (txtUser.Text.Trim() != "")
                    bz = bz + " 开单医生:" + txtUser.Text.Trim();

                parameters[2].Text = "备注";
                parameters[2].Value = dtpTjKs.Value.ToString() + " 到 " + dtpTjJs.Value.ToString() + "  "+  "  部门名称:" + cmbjgbm.Text +"  "+bz;

                parameters[3].Text = "现金大写";
                parameters[3].Value = "";

                TrasenFrame.Forms.FrmReportView f;
                //if (rdJg.Checked == true)
                    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_医生收入情况统计.rpt", parameters);
                //else
                //    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_医生收入报表(会计).rpt", parameters);

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

        private void btnDc_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lst_HeaderText = new List<string>();//列标题
                if (dataGridView1.DataSource == null)
                {
                    MessageBox.Show("没有数据！");
                    return;
                }
                DataTable tb = ((DataTable)this.dataGridView1.DataSource).Copy();
                //去掉未显示的列
                for (int j = dataGridView1.ColumnCount - 1; j >= 0; j--)
                {
                    if (dataGridView1.Columns[j].Visible == false)
                    {
                        tb.Columns.Remove(tb.Columns[j]);
                    }
                    else
                    {
                        lst_HeaderText.Insert(0, dataGridView1.Columns[j].HeaderText);
                    }
                }
                //去掉空数据的列
                if (checkBox1.Checked)
                {
                    for (int i = tb.Columns.Count - 1; i >= 0; i--)
                    {
                        try
                        {
                            DataColumn dc = tb.Columns[i];
                            DataRow[] dr = tb.Select(dc + " is not null ");
                            if (dr.Length == 0)
                            {
                                tb.Columns.Remove(dc);
                                lst_HeaderText.RemoveAt(i);
                            }
                        }
                        catch { }
                    }
                    if (tb.Columns.Count == 0)
                    {
                        MessageBox.Show("没有数据！");
                        return;
                    }
                }

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
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
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
                if (txtDept.Text.Trim() != "")
                    bz = bz + "开单科室:" + txtDept.Text.Trim();
                if (txtUser.Text.Trim() != "")
                    bz = bz + "开单医生:" + txtUser.Text.Trim();
                //时间修改
                string swhere = "日期从:" + dtpTjKs.Value.ToString("yyyy-MM-dd 00:00:00") + " 到:" + dtpTjJs.Value.ToString("yyyy-MM-dd 23:59:59") + "  部门名称:" + cmbjgbm.Text + "  " + bz;
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
                for (int i = 0; i <=lst_HeaderText.Count - 1; i++)
                {
                    objData[0, colIndex++] = lst_HeaderText[i];
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= lst_HeaderText.Count - 1; j++)
                    {
                        if (lst_HeaderText[j] == "门诊号" || lst_HeaderText[j] == "身份证号" || lst_HeaderText[j] == "卡号")
                            objData[i + 1, colIndex++] = "'" + tb.Rows[i][j].ToString();
                        else
                            objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString();
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

        private void FrmMzysXmtj_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);

            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
        }

        private void txtDept_KeyPress(object sender, KeyPressEventArgs e)
        {

            Control control = (Control)sender;
            if ((int)e.KeyChar ==8)
            {
                txtDept.Tag = "0";
                txtDept.Text = "";
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
                f.srcControl = txtDept;
                f.Font = txtDept.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtDept.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtDept.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtDept.Text = f.SelectDataRow["name"].ToString().Trim();
                    txtDept.Focus();
                    e.Handled = true;
                }
            }
            else
            {
                if (txtDept.Text.Trim() == "")
                {
                    txtDept.Focus();
                    return;
                }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8)
            {
                txtUser.Tag = "0";
                txtUser.Text = "";
                return;
            }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtUser;
                f.Font = txtUser.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtUser.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtUser.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtUser.Text = f.SelectDataRow["name"].ToString().Trim();
                    txtUser.Focus();
                    e.Handled = true;
                }

            }
            else
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtDept_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Text.Trim() == "") control.Tag = "0";
        }
    }
}