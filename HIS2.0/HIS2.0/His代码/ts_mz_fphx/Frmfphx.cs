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
using System.Text;
namespace ts_mz_fphx
{
    public partial class Frmfphx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frmfphx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void Frmfphx_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
            this.WindowState = FormWindowState.Maximized;

            //dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            //dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            //SystemCfg cfg1054 = new SystemCfg(1054);
            //string[] s = cfg1054.Config.ToString().Split(',');
            //if (s.Length == 2)
            //{
            //    dtp1.Value = Convert.ToDateTime(dtp1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
            //    dtp2.Value = Convert.ToDateTime(dtp2.Value.ToShortDateString() + " " + s[1]);
            //}
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@pjlx";
                parameters[0].Value = rdogh.Checked == true ? 1 : 0;

                parameters[1].Text = "@ksh";
                parameters[1].Value = Convertor.IsNull(txtksh.Text,"0");

                parameters[2].Text = "@jsh";
                parameters[2].Value = Convertor.IsNull(txtjsh.Text, "0");

                parameters[3].Text = "@sfy";
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue, "0"));

                parameters[4].Text = "@type";
                parameters[4].Value = 0;

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_FPHXHZ", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);

                this.dataGridView1.DataSource = dset.Tables[0];

                DataTable tb2 = (DataTable)dataGridView2.DataSource;
                DataTable tb3 = (DataTable)dataGridView3.DataSource;
                DataTable tb4 = (DataTable)dataGridView5.DataSource;
                if (tb2 != null) tb2.Rows.Clear();
                if (tb3 != null) tb3.Rows.Clear();
                if (tb4 != null) tb4.Rows.Clear();

                SelectFp(Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue, "0")));


                dataGridView1_DoubleClick(sender, e);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb == null) return;
                if (tb.Rows.Count == 0) return;

                int nrow = dataGridView1.CurrentCell.RowIndex;
                int sfy = Convert.ToInt32(tb.Rows[nrow]["sfy"]);

                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@pjlx";
                parameters[0].Value = rdogh.Checked == true ? 1 : 0;

                parameters[1].Text = "@ksh";
                parameters[1].Value = Convertor.IsNull(txtksh.Text, "0");

                parameters[2].Text = "@jsh";
                parameters[2].Value = Convertor.IsNull(txtjsh.Text, "0");

                parameters[3].Text = "@sfy";
                parameters[3].Value = sfy;

                parameters[4].Text = "@type";
                parameters[4].Value = 1;


                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_FPHXHZ", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                Fun.AddRowtNo(dset.Tables[1]);
                Fun.AddRowtNo(dset.Tables[2]);


                DataTable tb2 = (DataTable)dataGridView2.DataSource;
                DataTable tb3 = (DataTable)dataGridView3.DataSource;
                DataTable tb4 = (DataTable)dataGridView4.DataSource;
                if (tb2 != null) tb2.Rows.Clear();
                if (tb3 != null) tb3.Rows.Clear();
                if (tb4 != null) tb4.Rows.Clear();

                this.dataGridView2.DataSource = dset.Tables[0];
                this.dataGridView3.DataSource = dset.Tables[1];
                this.dataGridView4.DataSource = dset.Tables[2];

                SelectFp(sfy);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView2.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["dataGridViewTextBoxColumn5"].Value, "") != "0")
                    dgv.DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            DataTable tb2 = (DataTable)dataGridView2.DataSource;
            DataTable tb3 = (DataTable)dataGridView3.DataSource;
            DataTable tb4 = (DataTable)dataGridView4.DataSource;
            if (tb2 != null) tb2.Rows.Clear();
            if (tb3 != null) tb3.Rows.Clear();
            if (tb4 != null) tb4.Rows.Clear();
        }

        private void dataGridView5_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView5.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["状态"].Value, "") == "用完")
                    dgv.DefaultCellStyle.ForeColor = Color.Gray;
                if (Convertor.IsNull(dgv.Cells["状态"].Value, "") == "在用")
                    dgv.DefaultCellStyle.ForeColor = Color.Blue;
                if (Convertor.IsNull(dgv.Cells["状态"].Value, "") == "删除")
                    dgv.DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void SelectFp(int sfy)
        {
            string ssql = "select '' 序号,(case when fplx=1 then '收费票' ELSE '挂号票' end) 发票类型," +
                    " qshm 开始号,jshm 结束号,cast(jshm as bigint)-cast(qshm as bigint)+1 总张数,(case when bzybz>0 then cast(dqhm as bigint)-cast(qshm as bigint) else null end) 已用张数," +
                    " (case when bwcbz=1 then '用完' when bzybz=1 then '在用' when bscbz=1 then '删除' else '未用'  end)  状态," +
                    " dqhm 当前使用号,dbo.fun_getempname(lyr) 领用人," +
                    " djsj 领用时间,lyr as sfy " +
                    "  from mz_fplyb ";
            if (sfy==0)
                 ssql=ssql+" where bzybz=1";
            else
                ssql=ssql+" where lyr=" + sfy + "";
            ssql=ssql+" order by lyr,djsj desc";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            dataGridView5.DataSource = tb;
        }

        private void cmbuser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbuser.SelectedValue == null) return;
            int sfy = Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue, "0"));
            SelectFp(sfy);
        }

        private void dataGridView5_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView5.CurrentCell == null) return;
                int nrow = this.dataGridView5.CurrentCell.RowIndex;
                DataTable tb=(DataTable)dataGridView5.DataSource;
                string ksh = tb.Rows[nrow]["开始号"].ToString();
                string jsh = tb.Rows[nrow]["结束号"].ToString();
                string fplx = tb.Rows[nrow]["发票类型"].ToString();
                string sfy = tb.Rows[nrow]["sfy"].ToString();
                txtjsh.Text = jsh;
                txtksh.Text = ksh;

                cmbuser.SelectedValue = sfy;
                if (fplx == "收费票")
                    rdosf.Checked = true;
                else
                    rdogh.Checked = true;

                DataTable tb1 = (DataTable)dataGridView1.DataSource;
                DataTable tb2 = (DataTable)dataGridView2.DataSource;
                DataTable tb3 = (DataTable)dataGridView3.DataSource;
                DataTable tb4 = (DataTable)dataGridView4.DataSource;
                if (tb1 != null) tb1.Rows.Clear();
                if (tb2 != null) tb2.Rows.Clear();
                if (tb3 != null) tb3.Rows.Clear();
                if (tb4 != null) tb4.Rows.Clear();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}