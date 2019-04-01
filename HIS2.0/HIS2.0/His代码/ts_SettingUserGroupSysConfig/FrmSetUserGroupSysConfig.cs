using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using ts.SettingUserGroupSysConfig;


namespace ts_SettingUserGroupSysConfig
{
    public partial class FrmSetUserGroupSysConfig : Form
    {
        public FrmSetUserGroupSysConfig()
        {
            InitializeComponent();
        }

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public FrmSetUserGroupSysConfig(MenuTag menuTag, string chineseName, Form mdiParent)
            : this()
        {  
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void FrmSetUserGroupSysConfig_Load(object sender, EventArgs e)
        {
            DataTable dt = InstanceForm.BDatabase.GetDataTable("select Id,Name from Pub_Group where Delete_Bit = 0");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            FrmUserGroupConfigEdit frm = new FrmUserGroupConfigEdit(EditType.Add, dataGridView1.CurrentRow.Cells["groupId"].Value.ToString());
            DialogResult dr= frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dataGridView1_SelectionChanged(null, null);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            FrmUserGroupConfigEdit frm = new FrmUserGroupConfigEdit(EditType.Delete, dataGridView1.CurrentRow.Cells["groupId"].Value.ToString());
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dataGridView1_SelectionChanged(null, null);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            string sql = " select ID,CONFIG,NOTE from JC_CONFIG where ID in (select configid from Pub_UserGroupSysConfig where usergroupid = {0})";
            DataTable dt = InstanceForm.BDatabase.GetDataTable(string.Format(sql, dataGridView1.CurrentRow.Cells["groupId"].Value));
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt;
        }
    }
}