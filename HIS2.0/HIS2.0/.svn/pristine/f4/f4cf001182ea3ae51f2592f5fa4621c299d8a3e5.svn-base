using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;

namespace ts_mz_cfsh
{
    public partial class Frmjcsz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmjcsz()
        {
            InitializeComponent();
        }
        public Frmjcsz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Frmjcsz_Load(object sender, EventArgs e)
        {
            //是否启用处方审核
            DataTable dt = new DataTable();
            dt.Columns.Add("id", Type.GetType("System.String"));
            dt.Columns.Add("name", Type.GetType("System.String"));
            DataRow dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "不审核";
            dt.Rows.Add(dr);
            DataRow dr2 = dt.NewRow();
            dr2[0] = "1";
            dr2[1] = "只审核药品";
            dt.Rows.Add(dr2);
            DataRow dr3 = dt.NewRow();
            dr3[0] = "2";
            dr3[1] = "只审核项目";
            dt.Rows.Add(dr3);
            DataRow dr4 = dt.NewRow();
            dr4[0] = "3";
            dr4[1] = "都审核";
            dt.Rows.Add(dr4);
            cmb_sz.DataSource = dt;
            cmb_sz.DisplayMember = "name";
            cmb_sz.ValueMember = "id";

            SystemCfg cfg1043 = new SystemCfg(1043);
            if (String.IsNullOrEmpty(cfg1043.Config))
                cmb_sz.SelectedValue = "0";
            else
                cmb_sz.SelectedValue = cfg1043.Config;
        }

        private void btn_save1_Click(object sender, EventArgs e)
        {
            string sql = string.Format(@"update jc_config set config='{0}' where id=1043 ", cmb_sz.SelectedValue.ToString());
            int num=InstanceForm.BDatabase.DoCommand(sql);
            if (num == 0)
            {
                MessageBox.Show("参数1043不存在，无法保存设置！");
            }
            else
            {
                MessageBox.Show("设置成功！");
            }
        }
    }
}