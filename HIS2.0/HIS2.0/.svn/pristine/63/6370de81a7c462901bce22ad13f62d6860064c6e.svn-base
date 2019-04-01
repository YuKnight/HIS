using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Classes;

namespace ts_mz_cx
{
    public partial class Frm_mzyspbqkcx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frm_mzyspbqkcx()
        {
            InitializeComponent();
        }
        public Frm_mzyspbqkcx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private DataTable Tbks;//挂号科室数据
        private DataTable Tbys;//挂号医生数据

        private void txtKs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "五笔码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "wb_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = txtKs;
                f.Font = txtKs.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtKs.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtKs.Tag = f.SelectDataRow["dept_id"];
                    txtKs.Text = f.SelectDataRow["name"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtYs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13 && Convertor.IsNumeric(e.KeyChar.ToString()) == false)
            {
                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtYs;
                f.Font = txtKs.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtYs.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtYs.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtYs.Text = f.SelectDataRow["name"].ToString().Trim();
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }

            }
            else
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void Frm_mzyspbqkcx_Load(object sender, EventArgs e)
        {
            Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string queryString = @"select dbo.fun_getDeptname(PBKSID) PBKS,PBSJ,YSXM,ZZJB,dbo.fun_getEmpName(CZY) CZY,convert(varchar(20),CZSJ,120) CZSJ,
                                    (SELECT ZJMC_QC FROM JC_ZJSZ_QC WHERE jc_mz_yspb.ZJID_QC = ZJID_QC) ZJMC,
                                    case pblx when '1' then '上午' when '2' then '下午' else '晚上' end pblx
                                    from jc_mz_yspb ";

            string where_sql = " where BSCBZ = 0 and  pbsj >= '" + dtpBegin.Value.ToShortDateString() + "' and pbsj <= '" + dtpEnd.Value.ToShortDateString() + "'";

            if (txtKs.Tag != null && txtKs.Tag.ToString() != "0")
                where_sql += " and pbksid = "+txtKs.Tag.ToString();
            if (txtYs.Tag != null && txtYs.Tag.ToString() != "0")
                where_sql += " and ysid = " + txtYs.Tag.ToString();
            
            dgvMzyspbqkcx.DataSource = InstanceForm.BDatabase.GetDataTable(queryString + where_sql);
        }
    }
}