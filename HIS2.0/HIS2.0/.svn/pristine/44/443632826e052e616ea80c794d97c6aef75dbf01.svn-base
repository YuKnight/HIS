using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using Ts_zyys_public;
using ts_mz_class;

namespace ts_yf_mzty
{
    public partial class FrmSel : Form
    {
        public  bool Bok = false;
        public Guid _brxxid = Guid.Empty;
        public string _mzh = "";
        public long _dnlsh = 0;
        public string _fph = "";
        public string _cfrq1 = "";
        public string _cfrq2 = "";
        public FrmSel(Guid brxxid,string cfrq1,string cfrq2,string mzh,long dnlsh,string fph)
        {
            InitializeComponent();

            string ssql = "select '' 序号,cast(0 as smallint) 选择,'' 门诊号,'' 发票号,'' 流水号,'' 姓名,'' 金额,'' 发药科室,'' 发药日期,'' ID where 1=2";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            dataGridView1.DataSource = tb;

            _brxxid = brxxid;
            _cfrq1 = cfrq1;
            _cfrq2 = cfrq2;
            _mzh = mzh;
            _dnlsh = dnlsh;
            _fph = fph;
        }

        private void FrmSel_Load(object sender, EventArgs e)
        {

        }

        private void butok_Click(object sender, EventArgs e)
        {
            Bok = true;
            this.Close();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkcfrq_CheckedChanged(object sender, EventArgs e)
        {
            dtprq1.Enabled = chkcfrq.Checked == true ? true : false;
            dtprq2.Enabled = chkcfrq.Checked == true ? true : false;
        }


        DataTable gridTable = null;
        public DataTable RetDataList 
        {
            get
            {
                return gridTable;
            }
            set
            {
                gridTable = value;
            }
        }
        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                string _cfrq1 = chkcfrq.Checked == true ? dtprq1.Value.ToShortDateString() + " 00:00:00" : "";
                string _cfrq2 = chkcfrq.Checked == true ? dtprq2.Value.ToShortDateString() + " 23:59:59" : "";
                DataTable tb = MZYF.Select_TY_Cf(InstanceForm.BCurrentDept.DeptId, _brxxid, _cfrq1, _cfrq2, _mzh, _dnlsh, _fph, Guid.Empty, InstanceForm.BDatabase);
                /*
                           * update code by pengy 7-31
                           */
                gridTable = tb;
                DataTable tbx = (DataTable)dataGridView1.DataSource;
                tbx.Rows.Clear();
                int x = 0;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    DataRow row = tbx.NewRow();
                    x = x + 1;
                    row["序号"] = x.ToString();
                    row["选择"] = (_fph != "0" || _dnlsh > 0) == true ? (short)1 : (short)0;
                    row["门诊号"] = tb.Rows[i]["病历号"];
                    row["发票号"] = tb.Rows[i]["发票号"];
                    row["流水号"] = tb.Rows[i]["jssjh"];
                    row["姓名"] = tb.Rows[i]["姓名"];
                    row["金额"] = tb.Rows[i]["金额"];
                    row["发药科室"] = tb.Rows[i]["发药科室"];
                    row["发药日期"] = tb.Rows[i]["发药日期"];
                    row["id"] = tb.Rows[i]["id"];
                    tbx.Rows.Add(row);
                }

                dataGridView1.DataSource = tbx;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb == null) return;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                int ncol = dataGridView1.CurrentCell.ColumnIndex;
                if (Convertor.IsNull(tb.Rows[nrow]["选择"], "0") == "0")
                    tb.Rows[nrow]["选择"] = (short)1;
                else
                    tb.Rows[nrow]["选择"] = (short)0;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}