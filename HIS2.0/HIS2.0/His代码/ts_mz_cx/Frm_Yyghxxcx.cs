using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

namespace ts_mz_cx
{
    public partial class Frm_Yyghxxcx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_Yyghxxcx(MenuTag menuTag, string chineseName, Form mdiParent)
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
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
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
                    txtKs.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
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
        private void Frm_Yyghxxcx_Load(object sender, EventArgs e)
        {
            Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

             string queryString = @"select (case when yylx=1 then '院内预约' when yylx=2 then '网上预约' when yylx=3 then '电话预约' end) 来源,
                                    kh 卡号,brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,  dbo.fun_zy_age(csrq,3,getdate()) 年龄,jtdz 家庭地址,
                                    lxdh 联系方式, dbo.fun_getdeptname(ghks) 挂号科室,dbo.fun_getghjb(ghjb) 挂号级别,
                                    dbo.fun_getempname(ghys) 挂号医生,yyrq 预约日期,yysd 预约时点,SXSJ 失效时间,
                                    csrq 出生日期 from mz_yyghlb ";

             string where_sql = " where BSCBZ = 0 and YYRQ >= '" + dtpBegin.Value.ToShortDateString() + "' and YYRQ <= '" + dtpEnd.Value.ToShortDateString() + "'";

            if (txtKs.Tag != null && txtKs.Tag.ToString() != "0")
                where_sql += " and GHKS = "+txtKs.Tag.ToString();
            if (txtYs.Tag != null && txtYs.Tag.ToString() != "0")
                where_sql += " and GHYS = " + txtYs.Tag.ToString();

            dgvYyghxx.DataSource = InstanceForm.BDatabase.GetDataTable(queryString+where_sql);
        }
    }
}