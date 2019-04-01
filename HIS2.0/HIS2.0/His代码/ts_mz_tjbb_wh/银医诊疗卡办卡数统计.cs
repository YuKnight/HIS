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
using Ts_zyys_public;
using TrasenFrame.Forms;

namespace ts_mz_tjbb
{
    public partial class Frmyyzlkbktj : Form
    {

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public DataSet dset = null;


        public Frmyyzlkbktj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            label1.Text = _chineseName;
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count < 1)
                {
                    return;
                }

                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                this.butprint_pos.Enabled = false;
                this.Cursor = PubStaticFun.WaitCursor();

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
                if (chkbkrq.Checked == true)
                    swhere = " 办卡日期从:" + this.startTjrq.Value.ToString() + "　到 " + this.endTjrq.Value.ToString();

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "银医诊疗卡办卡数统计";
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
                        //if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width>0)
                        //{
                        if (tb.Columns[j].Caption == "门诊号")
                            objData[i + 2, colIndex++] = "'" + tb.Rows[i][j].ToString();
                        else
                            objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                        //}
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
                this.butprint_pos.Enabled = true;
            }
            catch (System.Exception err)
            {
                this.butprint_pos.Enabled = true;
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }


        // CellMouseDoubleClick ，取参数 e.ColumnIndex


        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@rq1";
                parameters[0].Value = chkbkrq.Checked == true ? startTjrq.Value.ToShortDateString() + " 00:00:00" : "";

                parameters[1].Text = "@rq2";
                //parameters[1].Value = chkbkrq.Checked == true ? endTjrq.Value.ToShortDateString() + " 00:00:00" : "";
                parameters[1].Value = chkbkrq.Checked == true ? endTjrq.Value.ToString() : "";

                parameters[2].Text = "@djy";
                parameters[2].Value = Convert.ToInt32(Convertor.IsNull(cbPerName.SelectedValue, "0"));


                dset = new DataSet();
                if (_menuTag.Function_Name != "Fun_ts_mz_tjbb_yyzlkbk_all")
                    InstanceForm.BDatabase.AdapterFillDataSet("SP_MZSF_CX_ZLKBKTJ", parameters, dset, "bktj", 30);
                else
                    InstanceForm.BDatabase.AdapterFillDataSet("SP_MZSF_CX_ZLKBKTJ_ALL", parameters, dset, "bktj", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                this.dataGridView1.DataSource = dset.Tables[0];

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkbkrq_CheckedChanged(object sender, EventArgs e)
        {
            startTjrq.Enabled = chkbkrq.Checked == true ? true : false;
            endTjrq.Enabled = chkbkrq.Checked == true ? true : false;
        }

        private void Frmyyzlkbktj_Load(object sender, EventArgs e)
        {
            //绑定收费员
            AddOperator(true, cbPerName);
            cbPerName.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            if (cbPerName.SelectedValue == null)
                cbPerName.SelectedValue = "0";


            startTjrq.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            endTjrq.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString());
            startTjrq.Enabled = false;
            endTjrq.Enabled = false;
        }

        //Add by Kevin 2012-07-31
        private void AddOperator(bool all, System.Windows.Forms.ComboBox cmb)
        {
            string sql = @"select employee_id,name from jc_employee_property where rylx in (3,8)
                        and employee_id in(select employee_id from JC_EMP_DEPT_ROLE a ,jc_dept_property b 
                        where a.dept_id=b.dept_id and (b.jgbm is null or b.jgbm<=0  or b.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " ) and employee_id in (select djy from yy_kdjb where klx = 1) )";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["employee_id"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "name";
            cmb.ValueMember = "employee_id";
            cmb.DataSource = tb;
        }

        private void butprint_pos_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;

            try
            {

                DataTable dtbk = (DataTable)dataGridView1.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= dtbk.Rows.Count - 1; i++)
                {
                    dr = dset.银医办卡统计.NewRow();
                    int x = i + 1;
                    dr["卡类型"] = Convert.ToString(dtbk.Rows[i]["卡类型"]);
                    dr["办卡数"] = Convert.ToString(Convertor.IsNull(dtbk.Rows[i]["办卡数"], "0"));
                    dr["有效数"] = Convert.ToString(Convertor.IsNull(dtbk.Rows[i]["有效数"], "0"));
                    dr["退卡数"] = Convert.ToString(Convertor.IsNull(dtbk.Rows[i]["退卡数"], "0"));
                    dr["冻结数"] = Convert.ToString(Convertor.IsNull(dtbk.Rows[i]["冻结数"], "0"));
                    dr["挂失数"] = Convert.ToString(Convertor.IsNull(dtbk.Rows[i]["挂失数"], "0"));
                    dr["预交金"] = Convert.ToDecimal(Convertor.IsNull(dtbk.Rows[i]["预交金"], "0"));
                    dset.银医办卡统计.Rows.Add(dr);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "备注";
                parameters[2].Value = "办卡日期:" + startTjrq.Value.ToString() + " 到 " + endTjrq.Value.ToString();

                parameters[3].Text = "统计人";
                parameters[3].Value = InstanceForm.BCurrentUser.Name;

                bool bprint = chkprint.Checked == true ? false : true;

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset, Constant.ApplicationDirectory + "\\Report\\MZ_银医诊疗卡办卡统计.rpt", parameters, bprint);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    string starttime = chkbkrq.Checked == true ? startTjrq.Value.ToShortDateString() + " 00:00:00" : "";
                    string endtime = chkbkrq.Checked == true ? endTjrq.Value.ToString() : "";
                    int tjlx = e.ColumnIndex;  //列索引
                    int row = e.RowIndex;  //行索引
                    int djy = Convert.ToInt32(Convertor.IsNull(cbPerName.SelectedValue, "0"));
                    if (tjlx == 0 || tjlx == 1 || tjlx == 7)
                        return;

                    Frmyyzlkbktjmx frmbktjmx = new Frmyyzlkbktjmx(this._menuTag, this._chineseName, this._mdiParent);
                    frmbktjmx.MdiParent = this._mdiParent;
                    frmbktjmx.Show();

                    frmbktjmx.FillTj(starttime, endtime, tjlx, row, djy);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}