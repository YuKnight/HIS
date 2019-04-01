using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame;
using TrasenFrame.Forms;

namespace ts_zygl_tjbb
{
    public partial class FrmZysskstj : Form
    {
        public FrmZysskstj()
        {
            InitializeComponent();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                this.btExcel.Enabled = false;

                string tjXm = "统计项目:" + this.rbJg.Text.Trim();
                string tjRqFs = "    统计日期方式:" + this.rbFsrq.Text.Trim();
                string rq = "    日期:" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                string tjBrks = "    病人科室:" + this.cmbBrDept.Text.Trim();
                string tjKdks = "    开单科室:" + this.cmbKdDept.Text.Trim();
                string tjSssqks = "    手术申请科室:" + this.cmbSqDept.Text.Trim();

                string swhere = tjXm + tjRqFs + rq + tjBrks + tjKdks + tjSssqks;

                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + label1.Text.Trim(), swhere, true, true, false, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                this.btExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butdy_Click(object sender, EventArgs e)
        {

        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKdDept.Text.Contains("手术") == true)
                { }
                else
                {
                    MessageBox.Show("开单科室必须为手术室！", "提示");
                    return;
                }


                Cursor = PubStaticFun.WaitCursor();

                ParameterEx[] parameters = new ParameterEx[9];

                parameters[0].Text = "@TYPE";
                parameters[0].Value = 0;
                parameters[1].Text = "@TJ_TYPE";
                parameters[1].Value = 0;
                parameters[2].Text = "@RQ1";
                parameters[2].Value = dtp1.Value.ToString();
                parameters[3].Text = "@RQ2";
                parameters[3].Value = dtp2.Value.ToString();
                parameters[4].Text = "@DEPT_BR";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbBrDept.SelectedValue, "0"));
                parameters[5].Text = "@DEPT_ID";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(cmbKdDept.SelectedValue, "0"));
                parameters[6].Text = "@DEPT_SS";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbSqDept.SelectedValue, "0"));
                parameters[7].Text = "@ISBRMX";
                parameters[7].Value = chkBrmx.Checked ? 1 : 0;
                parameters[8].Text = "@JGBM";
                parameters[8].Value = FrmMdiMain.Jgbm;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_KSSRTJ_SSSQKS", parameters, 120);
                AddRowtNo(tb);
                if (tb.Columns.Contains("序号") && tb.Rows.Count > 0)
                {
                    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                }
                this.dataGridView1.DataSource = tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("序号") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;
            }
        }

        private void FrmZysskstj_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            DataTable tb = InstanceForm.BDatabase.GetDataTable(@"SELECT DEPT_ID AS ITEMCODE,NAME AS ITEMNAME,PY_CODE,WB_CODE FROM JC_DEPT_PROPERTY WHERE JGBM=" + FrmMdiMain.Jgbm
                               + " AND DELETED = 0 AND LAYER=3 ORDER BY SORT_ID ASC");
            if (tb == null)
            {
                MessageBox.Show("错误，未能取得科室信息！", "提示");
            }
            DataRow rowKs = tb.NewRow();
            rowKs["ITEMCODE"] = -1;
            rowKs["ITEMNAME"] = "全部";
            tb.Rows.Add(rowKs);
            cmbBrDept.DataSource = tb;
            cmbBrDept.DisplayMember = "ITEMNAME";
            cmbBrDept.ValueMember = "ITEMCODE";
            cmbBrDept.SelectedValue = -1;

            DataTable tb2 = tb.Copy();
            cmbKdDept.DataSource = tb2;
            cmbKdDept.DisplayMember = "ITEMNAME";
            cmbKdDept.ValueMember = "ITEMCODE";
            cmbKdDept.SelectedValue = -1;

            DataTable tb3 = tb.Copy();
            cmbSqDept.DataSource = tb3;
            cmbSqDept.DisplayMember = "ITEMNAME";
            cmbSqDept.ValueMember = "ITEMCODE";
            cmbSqDept.SelectedValue = -1;


            DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            if (Convert.ToInt32(new SystemCfg(5016).Config) == 1)
            {
                this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " " + Convert.ToDateTime(new SystemCfg(5017).Config.Trim()).AddSeconds(1).ToString(" HH:mm:ss"));
                this.dtp2.Value = Convert.ToDateTime(now.ToShortDateString() + " " + new SystemCfg(5017).Config.Trim());
            }
            else
            {
                this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 00:00:00");
                this.dtp2.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 23:59:59");
            }
            this.dtp2.MaxDate = now;
        }
    }
}