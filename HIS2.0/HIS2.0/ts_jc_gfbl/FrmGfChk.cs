using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_jc_gfbl
{
    public partial class FrmGfChk : Form
    {
        private bool _bAdd = false;

        public FrmGfChk()
        {
            InitializeComponent();
        }

        private void FrmGfChk_Load(object sender, EventArgs e)
        {
            cmbYblx.Enabled = false;
            txtYlzh.Enabled = false;
            txtLdh.Enabled = false;

            dtpStart.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            dtpEnd.Value = DateTime.Now.AddMonths(1).AddDays(0 - DateTime.Now.Day);

            try
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                this.dataGridView1.AutoGenerateColumns = false;
            }
            catch
            { }

            try
            {
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.AllowUserToDeleteRows = false;
                dataGridView2.ReadOnly = true;
                this.dataGridView2.AutoGenerateColumns = false;
            }
            catch
            { }

            try
            {
                string ssql = string.Format(@"select ID,NAME from JC_YBLX where ybjklx='4444' and DELETE_BIT=0");

                DataTable dt = FrmMdiMain.Database.GetDataTable(ssql);

                cmbYblx.ValueMember = "ID";
                cmbYblx.DisplayMember = "NAME";
                cmbYblx.DataSource = dt;
            }
            catch
            { }

            DoQuery();
        }

        private void DoQuery()
        {
            DoQueryJsLd();
            DoQueryLdChk();
        }

        private void DoQueryJsLd()
        {
            string ylzh = txtYlzhQuery.Text.Trim();

            if (string.IsNullOrEmpty(ylzh))
                return;

            DataTable dt = DoQueryJsLd(dtpStart.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"), ylzh);

            dataGridView1.DataSource = dt;
        }

        private void DoQueryLdChk()
        {
            string ylzh = txtYlzhQuery.Text.Trim();

            if (string.IsNullOrEmpty(ylzh))
                return;

            DataTable dt = DoQueryLdChk(dtpStart.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"), ylzh);

            dataGridView2.DataSource = dt;
        }

        private DataTable DoQueryJsLd(params object[] args)
        {
            try
            {
                string ssql = string.Format(@"
                                            select a.yblx,a.ylzh,a.ldh,b.zje,b.zfje,b.bxje,b.sf_date 
                                            --,c.chk_bit 
                                            from gf_lddj a 
                                            inner join 
                                            (select b.ylzh,b.yblx,b.ldh,b.sf_date,SUM(zje) as zje,SUM(zfje) as zfje,SUM(bxje) as bxje from gf_ld_info b where b.del_bit=0 and b.cz_flag=0 group by ylzh,yblx,ldh,sf_date )b
                                            on a.yblx=b.yblx and a.ylzh=b.ylzh and a.ldh=b.ldh
                                            --left join gf_ld_mzsh c on a.yblx=c.yblx and a.ylzh=c.ylzh and a.ldh=c.ldh and c.del_bit=0
                                            where a.del_bit=0 and a.sf_date>='{0}' and a.sf_date<='{1}' and a.ylzh='{2}'", args);

                DataTable dt = FrmMdiMain.Database.GetDataTable(ssql);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        private DataTable DoQueryLdChk(params object[] args)
        {
            try
            {
                string ssql = string.Format(@"
                                                select a.yblx,a.ylzh,a.ldh
                                                ,case c.chk_bit when '0' then '未审核' else '已审核' end as chk_bit,
                                                c.yf_xe,c.qt_xe,c.memo,c.sh_man,c.sh_date,c.Mod_man,c.Mod_date
                                                from gf_lddj a 
                                                inner join gf_ld_mzsh c on a.yblx=c.yblx and a.ylzh=c.ylzh and a.ldh=c.ldh and c.del_bit=0
                                                where a.del_bit=0 and a.sf_date>='{0}' and a.sf_date<='{1}' and a.ylzh='{2}'", args);

                DataTable dt = FrmMdiMain.Database.GetDataTable(ssql);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 回车跳至下一个文本事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                switch (control.Name)
                {
                    default:
                        this.SelectNextControl(control, true, false, true, true);
                        break;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _bAdd = true;

            cmbYblx.Enabled = true;
            txtYlzh.Enabled = true;
            txtLdh.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYlzh.Text.Trim()))
            {
                MessageBox.Show("医疗证号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYlzh.Focus();
                txtYlzh.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtLdh.Text.Trim()))
            {
                MessageBox.Show("联单号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLdh.Focus();
                txtLdh.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtYfXe.Text.Trim()))
            {
                MessageBox.Show("药费限额 不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYfXe.Focus();
                txtYfXe.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtQtXe.Text.Trim()))
            {
                MessageBox.Show("其他限额 不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtXe.Focus();
                txtQtXe.Select();
                return;
            }

            decimal dOut = 0M;

            if (!decimal.TryParse(txtYfXe.Text.Trim(), out dOut))
            {
                MessageBox.Show("药费限额 必须为数值格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYfXe.Focus();
                txtYfXe.Select();
                return;
            }

            if (!decimal.TryParse(txtQtXe.Text.Trim(), out dOut))
            {
                MessageBox.Show("其他限额 必须为数值格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtXe.Focus();
                txtQtXe.Select();
                return;
            }

            if (MessageBox.Show("是否确认操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            string yblx = cmbYblx.SelectedValue.ToString();
            string ylzh = txtYlzh.Text;
            string ldh = txtLdh.Text;

            string ssql = "";
            try
            {
                ssql = string.Format(@"select count(1) as Num from  gf_ld_mzsh where yblx='{0}' and ylzh='{1}' and ldh='{2}' and del_bit=0", yblx, ylzh, ldh);

                int iNum = Convert.ToInt32(FrmMdiMain.Database.GetDataResult(ssql).ToString());

                if (_bAdd)
                {
                    if (iNum > 0)
                    {
                        throw new Exception("医疗证号：" + ylzh + " 联单号：" + ldh + " 已存在授权信息,请直接修改原授权记录！");
                    }

                    ssql = string.Format(@"insert into gf_ld_mzsh (id,yblx,ylzh,ldh,yf_xe,qt_xe,apply_date,memo)
                                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                        PubStaticFun.NewGuid(), yblx, ylzh, ldh, txtYfXe.Text.Trim(), txtQtXe.Text.Trim(), DateTime.Now, txtMemo.Text);

                    FrmMdiMain.Database.DoCommand(ssql);
                }
                else
                {
                    if (iNum <= 0)
                    {
                        throw new Exception("医疗证号：" + ylzh + " 联单号：" + ldh + " 不存在授权记录,请先新增授权记录！");
                    }

                    ssql = string.Format(@"update gf_ld_mzsh set 
                                            yf_xe='{3}',
                                            qt_xe='{4}',
                                            Mod_man='{5}',
                                            Mod_date='{6}'
                                            where yblx='{0}' and ylzh='{1}' and ldh='{2}' and del_bit=0   "
                        , yblx, ylzh, ldh, txtYfXe.Text.Trim(), txtQtXe.Text.Trim(), FrmMdiMain.CurrentUser.EmployeeId, DateTime.Now);

                    FrmMdiMain.Database.DoCommand(ssql);
                }

                DoQueryLdChk();
                MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存出错" + "\r\r" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            DataTable dtSrc = dataGridView2.DataSource as DataTable;

            if (dtSrc == null || dtSrc.Rows.Count <= 0)
                return;

            DataGridViewRow dgvr = dataGridView2.CurrentRow;

            if (dgvr == null)
                return;

            string strYfxe = dgvr.Cells["yf_xe"].Value.ToString().Trim();
            string strQtxe = dgvr.Cells["qt_xe"].Value.ToString().Trim();

            if (string.IsNullOrEmpty(strYfxe))
            {
                MessageBox.Show("药费限额 不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYfXe.Focus();
                txtYfXe.Select();
                return;
            }

            if (string.IsNullOrEmpty(strQtxe))
            {
                MessageBox.Show("其他限额 不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtXe.Focus();
                txtQtXe.Select();
                return;
            }

            decimal dOut = 0M;

            if (!decimal.TryParse(strYfxe, out dOut))
            {
                MessageBox.Show("药费限额 必须为数值格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYfXe.Focus();
                txtYfXe.Select();
                return;
            }

            if (!decimal.TryParse(strQtxe, out dOut))
            {
                MessageBox.Show("其他限额 必须为数值格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtXe.Focus();
                txtQtXe.Select();
                return;
            }

            if (MessageBox.Show("是否确认操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            try
            {
                string ldh = dgvr.Cells["ldh"].Value.ToString();
                string ylzh = dgvr.Cells["ylzh"].Value.ToString();
                string yblx = dgvr.Cells["yblx"].Value.ToString();

                string ssql = string.Format(@"select chk_bit from  gf_ld_mzsh where yblx='{0}' and ylzh='{1}' and ldh='{2}' and del_bit=0", yblx, ylzh, ldh);

                try
                {
                    string chkBit = FrmMdiMain.Database.GetDataResult(ssql).ToString();

                    if (chkBit.Trim().Equals("1"))
                    {
                        MessageBox.Show("该病人已经授权,如要加大授权额度直接修改限额进行保存", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch
                {
                    throw new Exception("医疗证号：" + ylzh + " 联单号：" + ldh + " 没有待审核信息，请新增该病人的授权信息！");
                }

                string strSql = string.Format(@"update gf_ld_mzsh set chk_bit=1,sh_man='{3}',sh_date='{4}' 
                                                where yblx='{0}' and ylzh='{1}' and ldh='{2}' and del_bit=0 and chk_bit=0 ",
                                            yblx, ylzh, ldh, FrmMdiMain.CurrentUser.EmployeeId, DateTime.Now);

                int iCnt = FrmMdiMain.Database.DoCommand(strSql);

                if (iCnt <= 0)
                {
                    MessageBox.Show("医疗证号：" + ylzh + " 联单号：" + ldh + " 未授权成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DoQueryLdChk();
                MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("授权出错" + "\r\r" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            _bAdd = false;

            cmbYblx.Enabled = false;
            txtYlzh.Enabled = false;
            txtLdh.Enabled = false;

            DataTable dtSrc = dataGridView2.DataSource as DataTable;

            if (dtSrc == null || dtSrc.Rows.Count <= 0)
                return;

            DataGridViewRow dgvr = dataGridView2.CurrentRow;

            if (dgvr == null)
                return;

            cmbYblx.SelectedValue = dgvr.Cells["yblx"].Value.ToString();
            txtYlzh.Text = dgvr.Cells["ylzh"].Value.ToString();
            txtLdh.Text = dgvr.Cells["ldh"].Value.ToString();

            txtYfXe.Text = dgvr.Cells["yf_xe"].Value.ToString();
            txtQtXe.Text = dgvr.Cells["qt_xe"].Value.ToString();
            txtMemo.Text = dgvr.Cells["memo"].Value.ToString();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DoQuery();
        }
    }
}