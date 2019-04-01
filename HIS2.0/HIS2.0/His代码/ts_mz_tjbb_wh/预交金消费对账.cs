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
    public partial class Frmyyjxfdz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public DataSet dset = new DataSet();

        public Frmyyjxfdz()
        {
            InitializeComponent();
        }

        public Frmyyjxfdz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttj_Click(object sender, EventArgs e)
        {

            try
            {

                ParameterEx[] parameters1 = new ParameterEx[3];


                parameters1[0].Text = "@RQ1";
                parameters1[0].Value = dtpjsrq1.Value.ToString();

                parameters1[1].Text = "@RQ2";
                parameters1[1].Value = dtpjsrq2.Value.ToString();

                parameters1[2].Text = "@SFY";
                parameters1[2].Value = Convert.ToInt32(Convertor.IsNull(comboBox1.SelectedValue, "0"));

                dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZ_YYJXFDZ", parameters1, dset, "sfmx", 60);
                Fun.AddRowtNo(dset.Tables[0]);

                this.dataGridView1.DataSource = dset.Tables[0];

                lblcrxj.Text = dset.Tables[0].Compute("sum(现金存入)", "").ToString();

                lblyhzz.Text = dset.Tables[0].Compute("sum(银行转账)", "").ToString();

                lblljxf.Text = dset.Tables[0].Compute("sum(支出)", "").ToString();

                lbljcje.Text = dset.Tables[0].Compute("sum(卡余额)", "").ToString();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {
                string swhere = "";

                swhere = "对账日期从:" + dtpjsrq1.Value.ToString() + " 到:" + dtpjsrq2.Value.ToString();

                ts_jc_log.ExcelOper.ExportData_ForDataTable(dataGridView1, Constant.HospitalName + "预交金消费对账", swhere, true, true, false, false);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void butprint_pos_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {


                DataTable tb = (DataTable)dataGridView1.DataSource;
                ts_mz_report.DataSet1 ds = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    dr = ds.门诊预交金消费对账.NewRow();
                    int x = i + 1;
                    dr["序号"] = Convert.ToString(Convertor.IsNull(tb.Rows[i]["序号"], ""));
                    dr["姓名"] = Convert.ToString(Convertor.IsNull(tb.Rows[i]["姓名"], ""));
                    dr["卡号"] = Convert.ToString(Convertor.IsNull(tb.Rows[i]["卡号"], ""));
                    dr["现金存入"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["现金存入"], "0"));
                    dr["发生日期1"] = Convert.ToString(Convertor.IsNull(tb.Rows[i]["现金日期"], ""));
                    dr["银行转账"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["银行转账"], "0"));
                    dr["发生日期2"] = Convert.ToString(Convertor.IsNull(tb.Rows[i]["转账日期"], ""));
                    dr["支出"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["支出"], "0"));
                    dr["发生日期3"] = Convert.ToString(Convertor.IsNull(tb.Rows[i]["支出日期"], ""));
                    dr["卡余额"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["卡余额"], "0"));
                    dr["收款员"] = Convert.ToString(Convertor.IsNull(tb.Rows[i]["收款员"], ""));

                    ds.门诊预交金消费对账.Rows.Add(dr);
                }





                ParameterEx[] parameters = new ParameterEx[9];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "填报人";
                parameters[2].Value = InstanceForm.BCurrentUser.Name;

                parameters[3].Text = "rq1";
                parameters[3].Value = dtpjsrq1.Value.ToString();

                parameters[4].Text = "rq2";
                parameters[4].Value = dtpjsrq2.Value.ToString();

                parameters[5].Text = "现金合计";
                parameters[5].Value = lblcrxj.Text.ToString();

                parameters[6].Text = "转账合计";
                parameters[6].Value = lblyhzz.Text.ToString();

                parameters[7].Text = "支出合计";
                parameters[7].Value = lblljxf.Text.ToString();

                parameters[8].Text = "余额合计";
                parameters[8].Value = lbljcje.Text.ToString();

                TrasenFrame.Forms.FrmReportView f;
                f = new FrmReportView(ds, Constant.ApplicationDirectory + "\\Report\\MZ_预交金消费对账.rpt", parameters);

                if (f.LoadReportSuccess)
                {
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void AddOperator(bool all, System.Windows.Forms.ComboBox cmb)
        {
            string sql = @"select employee_id,name from jc_employee_property where rylx in (3,8)
                        and employee_id in(select employee_id from JC_EMP_DEPT_ROLE a ,jc_dept_property b 
                        where a.dept_id=b.dept_id and (b.jgbm is null or b.jgbm<=0  or b.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " ) and employee_id in (select djy from yy_kdjb_je where fkfs = 1) ) order by employee_id asc";
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

            dtpjsrq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpjsrq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
        }

        private void Frmyyjxfdz_Load(object sender, EventArgs e)
        {
            AddOperator(true, comboBox1);
            comboBox1.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            if (comboBox1.SelectedValue == null)
                comboBox1.SelectedValue = "0";

            //FunAddComboBox.AddOperator(true, comboBox1, InstanceForm.BDatabase);
            //comboBox1.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            //if (comboBox1.SelectedValue == null)
            //    comboBox1.SelectedValue = "0";
        }
    }
}