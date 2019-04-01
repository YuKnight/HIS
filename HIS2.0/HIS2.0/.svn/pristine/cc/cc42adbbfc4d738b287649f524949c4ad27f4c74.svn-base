using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using YpClass;
using TrasenFrame.Forms;


namespace ts_yf_cx
{
    public partial class Frmjyfdy : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public Frmjyfdy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void Frmgqyptj_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable tbks = InstanceForm.BDatabase.GetDataTable( "select NAME 名称,PY_CODE 拼音码,WB_CODE 五笔码,a.dept_id as id from jc_dept_property a inner join JC_DEPT_TYPE_RELATION b on a.dept_id=b.dept_id where b.TYPE_CODE='004' and DELETED=0 ");
                txtks.ShowCardProperty[0].ShowCardDataSource = tbks;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Text = "@deptid";
                parameters[0].Value = InstanceForm.BCurrentDept.DeptId;

                parameters[1].Text = "@rq1";
                parameters[1].Value =dtp1.Value.ToShortDateString()+" 00:00:00";

                parameters[2].Text = "@rq2";
                parameters[2].Value = dtp2.Value.ToShortDateString() + " 23:59:59";

                parameters[3].Text = "@ksdm";
                parameters[3].Value = Convertor.IsNull(txtks.SelectedValue,"0");

                parameters[4].Text = "@bed_no";
                parameters[4].Value = txtcwh.Text.Trim();

                parameters[5].Text = "@inpatient_no";
                parameters[5].Value =txtzyh.Text.Trim();

                parameters[6].Text = "@bdybz";
                parameters[6].Value =rdoydy.Checked==true?1:0;


                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_CX_JYTMDY", parameters, 60);


                dgvgqyp.DataSource = tb;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
         
                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dgvgqyp, Constant.HospitalName + _menuTag.MenuName, "", false, false, false, false);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvgqyp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)dgvgqyp.DataSource;
            if (tb == null) return;
            if (e.RowIndex < 0) return;
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//登记时间

            if (Convertor.IsNumeric(txtsl.Text) == false)
            {
                MessageBox.Show("打印份数请输入数字", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tb.Columns[e.ColumnIndex].ColumnName == "打印")
            {
                Guid id = new Guid(tb.Rows[e.RowIndex]["id"].ToString());
                int sumsl = 0;

                int sl=Convert.ToInt32(txtsl.Text);
                int js=Convert.ToInt32(tb.Rows[e.RowIndex]["数量"]);

                sumsl = sl * js + 1;

                if (checkBox1.Checked == true)
                {
                    sumsl = 1;
                }
                
               
                print(tb.Rows[e.RowIndex],sumsl);

                string sql = " update ZY_DECOCT set bdybz=1 ,DYSJ='" + sDate + "' where id='" + id + "'";
                InstanceForm.BDatabase.DoCommand(sql);

                tb.Rows[e.RowIndex]["打印时间"] = sDate;
            }
        }


        private void print(DataRow row, int cs)
        {
            try
            {
                //ts_Yk_ReportView.Dataset1 Dset = new ts_Yk_ReportView.Dataset1();
                //DataRow myrow;
                //myrow = Dset.煎药标签.NewRow();
                //myrow["zyh"] = Convert.ToInt32(row["住院号"]);
                //myrow["name"] = Convert.ToString(row["姓名"]);
                //myrow["ksmc"] = Convert.ToString(row["开单科室"]);
                //myrow["bed_no"] = Convert.ToString(row["床号"]);
                //myrow["sl"] = Convert.ToString(row["数量"]);
                //myrow["dw"] = Convert.ToString(row["单位"]);
                //myrow["je"] = Convert.ToString(row["金额"]);
                //myrow["fyksrq"] = Convert.ToString(row["处方日期"]);
                //myrow["fyjsrq"] = Convert.ToDateTime(Convert.ToDateTime(row["处方日期"]).ToShortDateString()).AddDays(Convert.ToDouble(myrow["sl"])).ToShortDateString();

                //Dset.煎药标签.Rows.Add(myrow);

                //ParameterEx[] parameters = new ParameterEx[1];
                //parameters[0].Text = "yymc";
                //parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                //bool bprint = checkBox1.Checked == true ? false : true;

                //for (int i = 0; i <= cs - 1; i++)
                //{
                //    TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.煎药标签, Constant.ApplicationDirectory + "\\Report\\YF_煎药标签.rpt", parameters, bprint);
                //    if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                //}
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtzyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                Control txt=(Control)sender;
                if (txt.Name=="txtzyh")
                    txtzyh.Text = FunBase.returnZyh(txtzyh.Text);
                SendKeys.Send("{TAB}");
                this.btnTj_Click(sender, e);
            }

        }
       
    }
}