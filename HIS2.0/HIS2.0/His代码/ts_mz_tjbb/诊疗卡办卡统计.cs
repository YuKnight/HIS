using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using ts_mz_class;
using TrasenClasses.GeneralClasses;

namespace ts_mz_tjbb
{
    public partial class Frmzlktj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public DataSet dset = null;
        public Frmzlktj()
        {
            InitializeComponent();
        }
        public Frmzlktj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }
        private void Frmzlktj_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
        }

        private void btnesc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dtp1.Enabled = true;
                dtp2.Enabled = true;
            }
            else
            {
                dtp1.Enabled = false;
                dtp2.Enabled = false;
            }
        }

        private void btntj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@rq1";
                parameters[0].Value = checkBox1.Checked == true ? dtp1.Value.ToString() : "";

                parameters[1].Text = "@rq2";

                parameters[1].Value = checkBox1.Checked == true ? dtp2.Value.ToString() : "";

                parameters[2].Text = "@djy";
                parameters[2].Value = Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue, "0"));


                dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_MZSF_CX_ZLKBKTJ_ALL", parameters, dset, "bktj", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                this.dataGridView1.DataSource = dset.Tables[0];



                ParameterEx[] parameters1 = new ParameterEx[5];

                parameters1[0].Text = "@rq1";
                parameters1[0].Value = checkBox1.Checked == true ? dtp1.Value.ToString() : "";

                parameters1[1].Text = "@rq2";
                parameters1[1].Value = checkBox1.Checked == true ? dtp2.Value.ToString() : "";

                parameters1[2].Text = "@tjlx";
                parameters1[2].Value = 2;

                parameters1[3].Text = "@row";
                parameters1[3].Value = 0;

                parameters1[4].Text = "@djy";
                parameters1[4].Value = Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue, "0")); ;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_ZLKBKTJMX_ALL", parameters1, 30);
                Fun.AddRowtNo(tb);
                this.dataGridView2.DataSource = tb;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    //string starttime = checkBox1.Checked == true ? dtp1.Value.ToString() : "";
                    //string endtime = checkBox1.Checked == true ? dtp2.Value.ToString() : "";
                    int tjlx = e.ColumnIndex;  //列索引
                    int row = e.RowIndex;  //行索引
                    int djy = Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue, "0"));
                    if (tjlx == 0 || tjlx == 1 || tjlx == 7)
                        return;
                    ParameterEx[] parameters1 = new ParameterEx[5];

                    parameters1[0].Text = "@rq1";
                    parameters1[0].Value = checkBox1.Checked == true ? dtp1.Value.ToString() : "";

                    parameters1[1].Text = "@rq2";
                    parameters1[1].Value = checkBox1.Checked == true ? dtp2.Value.ToString() : "";

                    parameters1[2].Text = "@tjlx";
                    parameters1[2].Value = tjlx;

                    parameters1[3].Text = "@row";
                    parameters1[3].Value = row;

                    parameters1[4].Text = "@djy";
                    parameters1[4].Value = djy;

                    DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_ZLKBKTJMX_ALL", parameters1, 30);
                    Fun.AddRowtNo(tb);
                    this.dataGridView2.DataSource = tb;

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            if ( dataGridView2.DataSource == null )
                return;

            DataTable hztb = (DataTable)dataGridView1.DataSource;
            DataTable mxtb = (DataTable)dataGridView2.DataSource;
            ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();
            DataRow myrow;
            for (int i = 0; i <= hztb.Rows.Count - 1; i++)
            {
                myrow = Dset.银医办卡统计.NewRow();
                myrow["序号"] = Convert.ToString(hztb.Rows[i]["序号"]);
                myrow["卡类型"] = Convert.ToString(hztb.Rows[i]["卡类型"]);
                myrow["办卡数"] = Convert.ToString(hztb.Rows[i]["办卡数"]);
                myrow["有效数"] = Convert.ToString(hztb.Rows[i]["有效数"]);
                myrow["退卡数"] = Convert.ToString(hztb.Rows[i]["退卡数"]);
                myrow["冻结数"] = Convert.ToString(hztb.Rows[i]["冻结数"]);
                myrow["挂失数"] = Convert.ToString(hztb.Rows[i]["挂失数"]);
                //myrow["预交金"] = Convert.ToString(hztb.Rows[i]["预交金"]);
                myrow["办卡金额"] = Convert.ToString(hztb.Rows[i]["办卡金额"]);
                myrow["退办卡金额"] = Convert.ToString(hztb.Rows[i]["退办卡金额"]);
                Dset.银医办卡统计.Rows.Add(myrow);

            }
            DataRow mymxrow;
            for (int i = 0; i <= mxtb.Rows.Count - 1; i++)
            {
                mymxrow = Dset.诊疗卡办卡明细.NewRow();
                mymxrow["序号"] = Convert.ToString(mxtb.Rows[i]["序号"]);
                mymxrow["姓名"] = Convert.ToString(mxtb.Rows[i]["姓名"]);
                mymxrow["卡号"] = Convert.ToString(mxtb.Rows[i]["卡号"]);
                //mymxrow["预交金"] = Convert.ToString(mxtb.Rows[i]["预交金"]);
                mymxrow["身份证号"] = Convert.ToString(mxtb.Rows[i]["身份证"]);

                mymxrow["办卡金额"] = Convert.ToString(mxtb.Rows[i]["办卡金额"]);
                mymxrow["退卡金额"] = Convert.ToString(mxtb.Rows[i]["退办卡金额"]);
                mymxrow["办卡操作员"] = Convert.ToString(mxtb.Rows[i]["办卡操作员"]);
                mymxrow["退卡操作员"] = Convert.ToString(mxtb.Rows[i]["退卡操作员"]);
                Dset.诊疗卡办卡明细.Rows.Add(mymxrow);
            }
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Text = "日期";
            parameters[0].Value = dtp1.Value.ToString() + " - " + dtp2.Value.ToString();

            parameters[1].Text = "打印人";
            parameters[1].Value = InstanceForm.BCurrentUser.Name;

            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_诊疗卡办卡数统计.rpt", parameters, false);

            if (f.LoadReportSuccess)
            {
                f.Show();
            }
            else
                f.Dispose();
        }
    }
}