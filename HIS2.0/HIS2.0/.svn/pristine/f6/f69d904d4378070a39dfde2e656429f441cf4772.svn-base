using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using ts_mz_class;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_mz_cx
{
    /// <summary>
    /// 门诊日志统计 Add By zp 2013-07-31
    /// </summary>
    public partial class Frm_Mzrz : Form
    {
        private DataTable Tbks = null;
        private DataTable Tbys;//挂号医生数据
        public Frm_Mzrz()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取统计数据
        /// </summary>
        /// <param name="bdate">开始日期 格式yyyy-MM-dd HH:mm:ss</param>
        /// <param name="edate">结束日期 格式yyyy-MM-dd HH:mm:ss</param>
        /// <param name="dept_id">科室id</param>
        private void GetData(string bdate,string edate,string dept_id,string jzks,string jzys)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@date_begin";
                parameters[0].Value = bdate;

                parameters[1].Text = "@date_end";
                parameters[1].Value = edate;

                parameters[2].Text = "@dept_id";
                parameters[2].Value = dept_id;

                parameters[3].Text = "@jzks";
                parameters[3].Value = jzks;

                parameters[4].Text = "@jzys";
                parameters[4].Value = jzys;
                DataTable dt = InstanceForm.BDatabase.GetDataTable("SP_GetMzrzNew", parameters, 20);
                //this.Dgv_RzInfo.DataSource = null;
                this.Dgv_RzInfo.DataSource = dt;
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "错误");
            }
        }

        /// <summary>
        /// 获取统计数据
        /// </summary>
        /// <param name="bdate">开始日期 格式yyyy-MM-dd HH:mm:ss</param>
        /// <param name="edate">结束日期 格式yyyy-MM-dd HH:mm:ss</param>
        /// <param name="dept_id">科室id</param>
        private void GetData(string bdate, string edate, string dept_id)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@date_begin";
                parameters[0].Value = bdate;

                parameters[1].Text = "@date_end";
                parameters[1].Value = edate;

                parameters[2].Text = "@dept_id";
                parameters[2].Value = dept_id; 
                
                DataTable dt = InstanceForm.BDatabase.GetDataTable("SP_GetMzrz", parameters, 20);
                //this.Dgv_RzInfo.DataSource = null;
                this.Dgv_RzInfo.DataSource = dt;
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "错误");
            }
        }
        /// <summary>
        /// 统计按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttj_Click(object sender, EventArgs e)
        {
            string bdate= this.dtp1.Value.ToString("yyyy-MM-dd 00:00:00");
            string edate = this.dtp2.Value.ToString("yyyy-MM-dd 23:59:59");
             
            string dept_id = txtks.Text == "" ? "" : txtks.Tag.ToString();
            string jzks = txtJsks.Text == "" ? "" : txtJsks.Tag.ToString();
            string jzys = txtYs.Text == "" ? "" : txtYs.Tag.ToString();
            GetData(bdate, edate, dept_id, jzks, jzys);
        }
        /// <summary>
        /// 获得挂号科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtks.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtks.Text = f.SelectDataRow["name"].ToString().Trim();      
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtks.Text.Trim() == "")
                {
                    txtks.Focus();
                    return;
                }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void Frm_Mzrz_Load(object sender, EventArgs e)
        {
            Tbks = Fun.GetGhks(false, InstanceForm.BDatabase); 
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Dgv_RzInfo.Rows.Count < 1)
                {
                    MessageBox.Show("没有需要导出的数据!", "提示");
                    return;
                }
                this.Cursor = PubStaticFun.WaitCursor();
                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.Dgv_RzInfo, "门诊日志统计");
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        /// <summary>
        /// 打印门诊日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butprint_Click(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void PrintReport()
        {
            try
            {
                if (this.Dgv_RzInfo.Rows.Count < 1)
                {
                    MessageBox.Show("没有需要打印的数据!", "提示");
                    return;
                }
                Report.Ds_Mzrz Dset = new ts_mz_cx.Report.Ds_Mzrz();
                DataTable dt = (DataTable)this.Dgv_RzInfo.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow _dr = Dset.Tables[0].NewRow();
                    _dr["就诊日期"] = dr["就诊日期"];
                    _dr["门诊号"] = dr["门诊号"];
                    _dr["联系人"] = dr["联系人"];
                    _dr["姓名"] = dr["姓名"];
                    _dr["性别"] = dr["性别"];
                    _dr["职业"] = dr["职业"];
                    _dr["住址"] = dr["住址"];
                    _dr["联系电话"] = dr["联系电话"];
                    _dr["诊断"] = dr["诊断"];
                    _dr["发病日期"] = dr["发病日期"];
                    _dr["诊断时间"] = dr["诊断时间"];
                    _dr["初复诊"] = dr["初复诊"];
                    _dr["备注"] = dr["备注"];
                    Dset.Tables[0].Rows.Add(_dr);
                }
              
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "Title";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "门诊日志";

                parameters[1].Text = "Memo";
                parameters[1].Value = "日期:" + this.dtp1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "至" + this.dtp2.Value.ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "Date";
                parameters[2].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[3].Text = "Czy";
                parameters[3].Value = InstanceForm.BCurrentUser.Name.ToString();

                FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_门诊日志统计.rpt", parameters);

                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "错误");
            }
        }

        private void txtJsks_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                f.srcControl = txtJsks;
                f.Font = txtJsks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtJsks.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtJsks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtJsks.Text = f.SelectDataRow["name"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtJsks.Text.Trim() == "")
                {
                    txtJsks.Focus();
                    return;
                }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtYs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8) { control.Text = ""; control.Tag = "0"; return; }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtYs;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtYs.Focus();
                }
                else
                {
                    txtYs.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtYs.Text = f.SelectDataRow["name"].ToString().Trim();
                    //this.SelectNextControl(control, true, false, true, true);
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtYs.Text.Trim() == "") { txtYs.Focus(); return; }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}
