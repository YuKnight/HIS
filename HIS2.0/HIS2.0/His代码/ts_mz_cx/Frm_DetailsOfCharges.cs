using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_mz_cx
{
    public partial class Frm_DetailsOfCharges : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        private int sel_Index_sk = -1;
        private int sel_Index_fp = -1;

        public Frm_DetailsOfCharges()
        {
            InitializeComponent();
        }
        public Frm_DetailsOfCharges(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }


        private void Frm_DetailsOfCharges_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = _chineseName;
                this.WindowState = FormWindowState.Maximized;
                dgv_sk.AutoGenerateColumns = false;
                dgv_fp.AutoGenerateColumns = false;
                dgv_fpmx.AutoGenerateColumns = false;
                this.ckb_controldt.Checked = true;
                DateTime dt = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                dtpicker_beg.Format = DateTimePickerFormat.Short;
                dtpicker_end.Format = DateTimePickerFormat.Short;
                dtpicker_beg.Value = DateTime.Parse(dt.AddMonths(-1).ToShortDateString());
                dtpicker_end.Value = DateTime.Parse(dt.ToShortDateString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载出错: \n" + ex.Message);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sbr_sql = new StringBuilder();
                sbr_sql.Append(@"select s.JSID,kdj.KH as 卡号,br.BRXM as 病人姓名,gh.BLH as 门诊号,
s.SFRQ as 收费日期, (select name from JC_EMPLOYEE_PROPERTY where employee_id=s.SFY) as 收费员,
s.ZJE as 总金额,s.YBZHZF as 医保卡支付,s.YBJJZF as 医保基金支付,s.YBBZZF as 医保补助支付,
s.YLKZF as 银联卡支付,s.YHJE as 优惠金额,s.CWJZ as 财务记账,s.QFGZ as 欠费挂账,s.ZPZF as 支票支付,
s.XJZF as 现金支付,s.SKJE as 收款金额,s.ZLJE as 找零金额,s.FPZS as 发票张数,s.ZFZS as 作废张数
 from VI_MZ_SKJL s
 join VI_MZ_GHXX gh on gh.GHXXID=s.GHXXID
 join YY_KDJB kdj on kdj.KDJID=gh.KDJID
 join VI_YY_BRXX br on br.BRXXID=gh.BRXXID
where s.BSCBZ=0 ");
                //查询登录人收费记录
                sbr_sql.Append(" and  s.SFY= '");
                sbr_sql.Append(InstanceForm.BCurrentUser.EmployeeId);
                sbr_sql.Append("' ");
                if (!String.IsNullOrEmpty(txt_kh.Text))
                {
                    sbr_sql.Append(" and kdj.kh like '%");
                    sbr_sql.Append(txt_kh.Text.Trim());
                    sbr_sql.Append("' ");
                }
                if (!string.IsNullOrEmpty(txt_mzh.Text))
                {
                    sbr_sql.Append(" and gh.BLH like '%");
                    sbr_sql.Append(txt_mzh.Text.Trim());
                    sbr_sql.Append("' ");
                }
                if (!string.IsNullOrEmpty(txt_xm.Text))
                {
                    sbr_sql.Append(" and br.BRXM like '%");
                    sbr_sql.Append(txt_xm.Text.Trim());
                    sbr_sql.Append("%' ");
                }
                if (ckb_controldt.Checked)
                {
                    sbr_sql.Append(" and s.SFRQ between Convert(datetime,'");
                    sbr_sql.Append(dtpicker_beg.Value.ToShortDateString()+" 00:00:01");
                    sbr_sql.Append("') and Convert(datetime,'");
                    sbr_sql.Append(dtpicker_end.Value.ToShortDateString()+" 23:59:59");
                    sbr_sql.Append("') ");
                }
                sbr_sql.Append("  and s.JGBM=" + InstanceForm.BCurrentDept.Jgbm + "order by s.SFRQ desc ");

                DataTable dt = InstanceForm.BDatabase.GetDataTable(sbr_sql.ToString());
                dgv_sk.DataSource = dt;
                dgv_fp.DataSource = null;
                dgv_fpmx.DataSource = null;
                sel_Index_sk = -1;
                sel_Index_fp = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询收费信息出错: \n" + ex.Message);
            }
        }

        private void ckb_controldt_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                dtpicker_beg.Enabled = true;
                dtpicker_end.Enabled = true;
            }
            else
            {
                dtpicker_beg.Enabled = false;
                dtpicker_end.Enabled = false;
            }
        }

        private void dgv_sk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgr = dgv_sk.CurrentRow;
                dgr.Selected = true;
                if (dgr == null || dgr.Index == sel_Index_sk)
                {
                    return;
                }
                sel_Index_sk = dgr.Index;
                if (dgr.Cells["cljsid"].Value == null) return;
                string str_jsid = dgr.Cells["cljsid"].Value.ToString();
                string str_sql = @"select f.FPID,f.BLH as 门诊号,f.BRXM as 病人姓名,f.FPH as 发票号,f.ZJE as 总金额,f.YHJE as 优惠金额,
f.XJZF as 现金支付,f.YLKZF as 银联卡支付,f.YBZHZF as 医保卡支付,
f.YBJJZF as 医保基金支付, f.YBBZZF as 医保补助支付,f.QFGZ as 欠费挂账
 from VI_MZ_FPB f
where f.JLZT=0 and f.BSCBZ=0 and JSID='" + str_jsid + "'";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(str_sql);
                dgv_fp.DataSource = dt;
                dgv_fpmx.DataSource = null;
                sel_Index_fp = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询发票信息出错: \n" + ex.Message);
            }
        }

        private void dgv_fp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgr = dgv_fp.CurrentRow;
                dgr.Selected = true;
                if (dgr == null || dgr.Index == sel_Index_fp)
                {
                    return;
                }
                sel_Index_fp = dgr.Index;
                if (dgr.Cells["clfpid"].Value == null) return;
                string str_fpid = dgr.Cells["clfpid"].Value.ToString();
                string str_sql = @"select XMDM,XMMC,JE,SRJE from VI_MZ_FPB_MX where FPID='" + str_fpid + "'";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(str_sql);
                dgv_fpmx.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询发票明细出错: \n" + ex.Message);
            }
        }

        private void dgv_fpmx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgr = dgv_fpmx.CurrentRow;
            dgr.Selected = true;        
        }

        private void tiaozhuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_search.Focus();
                btn_search_Click(null, null);
            }
        }
    }
}