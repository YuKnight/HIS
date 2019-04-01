using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_jc_xtcssz
{
    public partial class frmXtcssz : Form
    {
        private DataTable tbConfig = null;

        public frmXtcssz()
        {
            InitializeComponent();
            this.Text += "【" + InstanceForm._menuTag.Jgbm + "】";
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            if (this.txtNote_tj.Text.Trim() != "")
            {
                strWhere = " where note like '%" + this.txtNote_tj.Text.Trim().Replace("*","%") +"%'";
            }
            LoadConfig(strWhere);
            cmbLx.SelectedValue = -1;
        }

        private void LoadConfig(string strWhere)
        {

            string sql = "select * from jc_config " + strWhere  + "  order by id";
            tbConfig = InstanceForm.BDatabase.GetDataTable(sql);

            dgvConfig.DataSource = tbConfig;

            DataTable tbLog = (DataTable)dgvLog.DataSource;
            if (tbLog != null)
            {
                tbLog.Clear();
            }
            dgvLog.DataSource = tbLog;
        }

        private void LoadModule()
        {
            string sql = "select -1 id,'全部' name union all select id,name from jc_module order by id";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);

            cmbLx.DisplayMember = "name";
            cmbLx.ValueMember = "id";
            cmbLx.DataSource = tb;

            cmbLx.SelectedValue = -1;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmXtcssz_Load(object sender, EventArgs e)
        {
            LoadModule();
            LoadConfig(string.Format(" where id in (select configid from Pub_UserGroupSysConfig where usergroupid in (select group_id from Pub_Group_User where user_id ={0}))", InstanceForm.BCurrentUser.UserID));

            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Checked = false;
        }

        private void dgvConfig_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dgvConfig.DataSource;
            if (tb == null || tb.Rows.Count == 0)
                return;

            if (dgvConfig.CurrentRow == null)
                return;

            int nrow = dgvConfig.CurrentRow.Index;

            txtId.Text = tb.Rows[nrow]["ID"].ToString().Trim();
            txtConfig.Text = tb.Rows[nrow]["CONFIG"].ToString().Trim();
            txtNote.Text = tb.Rows[nrow]["NOTE"].ToString().Trim();


        }

        private void cmbLx_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtConfig.Text = "";
            txtNote.Text = "";

            if (tbConfig == null || tbConfig.Rows.Count == 0)
                return;

            DataTable tb = tbConfig.Clone();
            DataRow[] dr = null;

            int _moduleid = -1;
            _moduleid = Convert.ToInt32(cmbLx.SelectedValue);

            if (_moduleid == -1)
            {
                dgvConfig.DataSource = tbConfig;
            }
            else
            {
                dr = tbConfig.Select("module_id=" + _moduleid, "id");

                if (dr == null)
                {
                    dgvConfig.DataSource = null;
                    return;
                }

                foreach (DataRow dtr in dr)
                {
                    tb.Rows.Add(dtr.ItemArray);
                }
                dgvConfig.DataSource = tb;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                frmInPassword frmpwd = new frmInPassword();
                frmpwd.ShowDialog(this);
                if (frmpwd.isLogin == false) return;
                if (txtId.Text.Trim() == "")
                    return;

                string[] sql = new string[2];
                //jianqg 2012-7-31 处理 有单引号的情况
                sql[0] = "insert into jc_config_log(CONFIG_ID, YCONFIG, XCONFIG, CZY, CZSJ) select ID, CONFIG, '" + txtConfig.Text.Trim().Replace("'", "''") + "', " + InstanceForm.BCurrentUser.EmployeeId + ", getdate() from jc_config where id=" + txtId.Text.Trim();
                sql[1] = "update jc_config set config='" + txtConfig.Text.Trim().Replace("'", "''") + "' where id=" + txtId.Text.Trim();

                InstanceForm.BDatabase.DoCommand(null, null, null, sql);

                MessageBox.Show("保存成功！");

                int idx = cmbLx.SelectedIndex;
                int curIndex = -1;
                if (dgvConfig.CurrentCell != null) curIndex = dgvConfig.CurrentCell.RowIndex;
                btRefresh_Click(null, null);
                cmbLx.SelectedIndex = idx;

                //定位
                if (curIndex > -1 && dgvConfig.RowCount > curIndex) dgvConfig.CurrentCell = dgvConfig.Rows[curIndex].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"错误提示");

            }
        }

        private void btLog_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
                return;

            string sql = "select ID, CONFIG_ID, YCONFIG, XCONFIG, dbo.fun_getempname(CZY) CZY, CZSJ from jc_config_log where 1=1 {0} order by CONFIG_ID, CZSJ";
            string strWhere ="";
            if (checkBox1.Checked ) strWhere +=" and CONFIG_ID=" + txtId.Text ;
            if (dateTimePicker1.Checked) strWhere += " and CZSJ>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
            if (dateTimePicker2.Checked) strWhere += " and CZSJ <'" + dateTimePicker2.Value.AddDays(1).ToString("yyyy-MM-dd 00:00:00") + "'";
            sql = string.Format(sql, strWhere);
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            
            //if (tb == null || tb.Rows.Count == 0)
            //    return;

            dgvLog.DataSource = tb;
        }
    }
}