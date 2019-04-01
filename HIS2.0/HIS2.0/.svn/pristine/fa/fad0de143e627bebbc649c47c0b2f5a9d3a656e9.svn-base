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


namespace ts_mz_tjbb
{
    public partial class Frmyytktyjtj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmyytktyjtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void Frmyytktyjtj_Load(object sender, EventArgs e)
        {
            //绑定收费员
            AddOperator(true, cbPerName);
            cbPerName.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            if (cbPerName.SelectedValue == null)
                cbPerName.SelectedValue = "0";

            startTjrq.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            //endTjrq.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59"); 
            endTjrq.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString());

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


        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@RQ1";
                parameters[0].Value = chkbkrq.Checked == true ? startTjrq.Value.ToShortDateString() + " 00:00:00" : "";

                parameters[1].Text = "@RQ2";
                //parameters[1].Value = chkbkrq.Checked == true ? endTjrq.Value.ToShortDateString() + " 00:00:00" : "";
                parameters[1].Value = chkbkrq.Checked == true ? endTjrq.Value.ToString() : "";

                parameters[2].Text = "@DJY";
                parameters[2].Value = Convert.ToInt32(Convertor.IsNull(cbPerName.SelectedValue, "0"));


                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_TYYJ", parameters, dset, "tyjj", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                this.dataGridView1.DataSource = dset.Tables[0];

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;

            try
            {
                if (this.dataGridView1.Rows.Count < 1)
                {
                    return;
                }

                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butprint_pos.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件

                string swhere = "";

                swhere = "退卡(预交)日期从:" + startTjrq.Value.ToString() + " 到:" + endTjrq.Value.ToString();

                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    SumColCount = SumColCount + 1;
                    myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        ncol = ncol + 1;
                        myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = Constant.HospitalName + label1.Text;
                myExcel.Cells[1, 1] = ss;
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
                this.butprint_pos.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butprint_pos.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butprint_pos_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {

                DataTable dttk = (DataTable)dataGridView1.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= dttk.Rows.Count - 1; i++)
                {
                    dr = dset.银医退卡明细.NewRow();
                    int x = i + 1;
                    dr["序号"] = Convert.ToString(dttk.Rows[i]["序号"]);
                    dr["卡号"] = Convert.ToString(dttk.Rows[i]["卡号"]);
                    dr["卡类型"] = Convert.ToString(dttk.Rows[i]["卡类型"]);
                    dr["病人姓名"] = Convert.ToString(dttk.Rows[i]["病人姓名"]);
                    dr["身份证号"] = Convert.ToString(dttk.Rows[i]["身份证号"]);
                    dr["退卡金额"] = Convert.ToString(Convertor.IsNull(dttk.Rows[i]["退卡金额"], "0"));
                    dr["日期"] = Convert.ToString(dttk.Rows[i]["日期"]);
                    dr["操作员"] = Convert.ToString(dttk.Rows[i]["操作员"]);
                    dset.银医退卡明细.Rows.Add(dr);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "备注";
                parameters[2].Value = "退卡(预交)日期:" + startTjrq.Value.ToString() + " 到 " + endTjrq.Value.ToString();

                parameters[3].Text = "统计人";
                parameters[3].Value = InstanceForm.BCurrentUser.Name;


                bool bprint = chkprint.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset, Constant.ApplicationDirectory + "\\Report\\MZ_银医退卡退预交金明细统计.rpt", parameters, bprint);
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

        private void chkbkrq_CheckedChanged(object sender, EventArgs e)
        {
            startTjrq.Enabled = chkbkrq.Checked == true ? true : false;
            endTjrq.Enabled = chkbkrq.Checked == true ? true : false;
        }
    }
}