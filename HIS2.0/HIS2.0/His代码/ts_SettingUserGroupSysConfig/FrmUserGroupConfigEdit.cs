using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ts_SettingUserGroupSysConfig
{
    public enum EditType { Add, Delete }
    internal delegate void SetProgress(int currentValue, int total);

    public partial class FrmUserGroupConfigEdit : Form
    {
        EditType editState; string userGroupId;
        Thread td;
        public FrmUserGroupConfigEdit(EditType editState, string userGroupId)
        {
            InitializeComponent();
            this.editState = editState;
            this.userGroupId = userGroupId;
        }

        private void FrmUserGroupConfigEdit_Load(object sender, EventArgs e)
        {
            string sql = null;
            DataTable dt = null;
            if (editState == EditType.Add)
            {
                sql = @" select ID,CONFIG,NOTE from JC_CONFIG where RWBZ =0 and ID not in (select configid from Pub_UserGroupSysConfig where usergroupid = {0})";
                dt = InstanceForm.BDatabase.GetDataTable(string.Format(sql, userGroupId));
            }
            else
            {
                sql = @"select ID,CONFIG,NOTE from JC_CONFIG where ID in (select configid from Pub_UserGroupSysConfig where usergroupid = {0})";
                dt = InstanceForm.BDatabase.GetDataTable(string.Format(sql, userGroupId));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (dataGridView1.RowCount == 0)
                return;
            List<int> configList = new List<int>();
            foreach (DataGridViewRow dgvrow in dataGridView1.Rows)
            {
                object obj = dgvrow.Cells["SelectItem"].Value;
                if (obj != null && (obj.ToString().Trim() == "1" || obj.ToString().ToUpper().Trim() == "TRUE"))
                {
                    configList.Add(int.Parse(dgvrow.Cells["ID"].Value.ToString()));
                }
            }
            if (configList.Count == 0)
            {
                MessageBox.Show("请勾选系统参数后保存");
                return;
            }
            progressBar1.Maximum = configList.Count;               
            td = new Thread(new ParameterizedThreadStart(Save));
            td.Start(configList);            
        }


        private void Save(object obj)
        {
            List<int> configList = obj as List<int>;
            string sql = null;
            if (editState == EditType.Add)
            {
                InstanceForm.BDatabase.BeginTransaction();
                sql = "insert into Pub_UserGroupSysConfig values('{0}',{1},{2})";
            }
            else
            {
                sql = "delete from Pub_UserGroupSysConfig where userGroupId = {0} and configId in ({1})";
            }
            object[] param = null;
            string configRang = null;
            for (int x = 0; x < configList.Count; x++)
            {
                if (editState == EditType.Add)
                {
                    param = new object[] 
                    {
                        Guid.NewGuid().ToString(),
                        userGroupId,
                        configList[x]
                    };
                    InstanceForm.BDatabase.DoCommand(string.Format(sql, param));
                }
                else
                {
                    configRang += string.Format("{0},", configList[x]);
                }
                SetValue(x, configList.Count);
                Application.DoEvents();
            }
            if (editState == EditType.Add)
                InstanceForm.BDatabase.CommitTransaction();
            else
            {
                configRang = configRang.Remove(configRang.Length - 1, 1);
                param = new object[] 
                    {                       
                        userGroupId,
                        configRang
                    };
                InstanceForm.BDatabase.DoCommand(string.Format(sql, param));
            }
            MessageBox.Show("操作成功");
            this.FormClosing -= FrmUserGroupConfigEdit_FormClosing;
            DialogResult = DialogResult.OK;
        }
       
        private void SetValue(int currentValue, int total)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new SetProgress(SetValue), new object[] { currentValue, total });
            }
            else
            {
                progressBar1.Maximum = total;
                progressBar1.Value = currentValue;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (td != null && td.IsAlive)
            {
                MessageBox.Show("数据正在提交,请稍后");
                return;
            }
            DialogResult = DialogResult.Cancel;
        }
        

        bool param = true;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["SelectItem"].Value = param ? 1 : 0;
            }
            param = !param;
        }

        private void FrmUserGroupConfigEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (td != null && td.IsAlive)
            {
                MessageBox.Show("数据正在提交,请稍后");
                e.Cancel = true;
            }
        }
    }
}