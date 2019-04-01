using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using ts_mz_class;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_tjbb
{
    public partial class frmHtdwjedz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private int selIndex = 0; //挂账列表选择行.
        private DataTable dt_htdw = new DataTable();

        public frmHtdwjedz()
        {
            InitializeComponent();
        }

        public frmHtdwjedz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            this.dgvList.AutoGenerateColumns = false;
            this.dgvInfoList.AutoGenerateColumns = false;
        }

        private void frmHtdwjedz_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime dt_now = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                dtpGzsjBeg.Value = dt_now.AddMonths(-1);
                dtpGzsjEnd.Value = dt_now;
                this.cmbZt.SelectedIndex = 0;
                FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
                FunAddComboBox.AddTypeOfContract(true, cmb_htlx, InstanceForm.BDatabase);
                M_Load_HTDW();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载页面出错:\n" + ex.Message);
            }
        }

        /// <summary>
        /// 加载时查询合同单位信息
        /// </summary>
        private void M_Load_HTDW()
        {
            try
            {
                //取得合同单位
                string sql = @"select DWMC as 单位名称,PYM as 拼音码,WBM as 五笔码 from JC_HTDW where BQYBZ='1'  order by ID ";
                dt_htdw = InstanceForm.BDatabase.GetDataTable(sql);
                labelTextBox1.ShowCardProperty[0].ShowCardDataSource = dt_htdw;   
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化合同单位出错: " + ex.Message);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            selIndex = 0;
            M_Bind();
        }
        private void M_Bind()
        {
            try
            {
                StringBuilder sbr_where = new StringBuilder();
                //合同单位名称
                if (!string.IsNullOrEmpty(this.labelTextBox1.Text.Trim()))
                {
                    sbr_where.Append(" and jh.DWMC = '" + this.labelTextBox1.Text.Trim() + "'");
                }
                //合同类型
                if (this.cmb_htlx.Text != "全部" && !String.IsNullOrEmpty(cmb_htlx.Text))
                {
                    sbr_where.Append(" and lx.ID =" + this.cmb_htlx.SelectedValue.ToString());
                }
                //挂号员
                if (this.cmbuser.Text != "全部" && !String.IsNullOrEmpty(cmbuser.Text))
                {
                    sbr_where.Append(" and mf.SFY =" + this.cmbuser.SelectedValue.ToString());
                }
                //挂账时间
                sbr_where.Append(" and mf.SFRQ between '" + this.dtpGzsjBeg.Value.ToShortDateString() + " 00:00:00" + "' and '" + this.dtpGzsjEnd.Value.ToShortDateString() + " 23:59:59" + "'");
                //状态
                if (this.cmbZt.Text.Trim() == "未核销")
                {
                    sbr_where.Append(" and  case when mf.ZJE - mf.SRJE - ISNULL(hd.DZJE, '0.00') > 0 then 0 else 1 end =0");
                }
                else if (this.cmbZt.Text.Trim() == "已核销")
                {
                    sbr_where.Append(" and  case when mf.ZJE - mf.SRJE - ISNULL(hd.DZJE, '0.00') > 0 then 0 else 1 end = 1");
                }
                //显示
                DataTable dt = GetData(sbr_where.ToString());
                decimal del_jzje = 0;
                decimal del_hsje = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dgvList.DataSource = dt;
                    DataGridViewRow dgvr = this.dgvList.Rows[selIndex];
                    dgvr.Selected = true;
                    this.dgvList.CurrentCell = dgvr.Cells[1];
                    //加载明细
                    if (dgvr.Cells["clFpid"] != null && !String.IsNullOrEmpty(dgvr.Cells["clFpid"].Value.ToString()))
                    {
                        GetDzListInfo(dgvr.Cells["clFpid"].Value.ToString());
                    }
                    //合计金额
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        del_jzje += dt.Rows[i]["金额"] == null ? 0 : decimal.Parse(dt.Rows[i]["金额"].ToString());
                        del_hsje += dt.Rows[i]["到账金额"] == null ? 0 : decimal.Parse(dt.Rows[i]["到账金额"].ToString());
                    }
                }
                else
                {
                    dgvList.DataSource = null;
                    dgvInfoList.DataSource = null;
                }
                lb_total.Text = "应核销金额: " + del_jzje.ToString() + " 元.   已核销金额: " + del_hsje.ToString() + " 元. ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询挂账信息出错: " + ex.Message);
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        private DataTable GetData(string strWhere)
        {
            DataTable dtTemp = new DataTable();
            string strSql = string.Format(@"SELECT ROW_NUMBER() OVER(ORDER BY jh.DWMC desc,mf.sfrq desc) AS 序号,
       mf.FPID                     AS 发票编号,
       mf.SFRQ                     AS 挂账时间,
       mf.SFY                      AS 挂账人员,
       dbo.fun_getEmpName(mf.SFY)  AS 挂账人员姓名,
       lx.LXMC                     AS 合同单位类型,
       jh.DWMC                     AS 合同单位名称,
       mf.ZJE                      AS 金额,
       mf.FPH                      AS 发票号,
       mf.BLH as 门诊号,
       br.BRXM as 病人姓名,
       ISNULL(hd.DZJE, '0.00')       AS 到账金额,
       case when mf.ZJE - ISNULL(hd.DZJE, '0.00') > 0 then '未核销' else '已核销' end AS 到账标识
FROM   MZ_FPB                      AS mf
       INNER JOIN MZ_GHXX          AS mg
            ON  mf.GHXXID = mg.GHXXID  and ISNULL(mg.BQXGHBZ,0)=0
       INNER JOIN YY_BRXX          AS br
            ON  br.BRXXID=mg.BRXXID
       LEFT JOIN JC_HTDWLX AS lx 
            ON mg.HTDWLX = lx.ID
       INNER JOIN JC_HTDW          AS jh
            ON  mg.HTDWID = jh.ID
       LEFT JOIN (select FPID,SUM(JE) as DZJE from MZ_HTDW_DZLOG WHERE BWCBZ='1' group by FPID) AS hd
            ON  mf.FPID = hd.FPID
WHERE mf.JGBM=" + InstanceForm.BCurrentDept.Jgbm + " and  mf.QFGZ>0  and ISNULL(mf.BSCBZ,0) =0  and JLZT=0 ");
            strSql += strWhere;
            dtTemp = InstanceForm.BDatabase.GetDataTable(strSql);
            return dtTemp;
        }

        /// <summary>
        /// 确认到账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQqdz_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null)
            {
                MessageBox.Show("请选择挂账信息后再核算费用!");
                return;
            }
            M_openPay();
        }
        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            M_openPay();
        }        

        /// <summary>
        /// 打开缴费页面
        /// </summary>
        private void M_openPay()
        {
            try
            {
                DataGridViewRow dgr = dgvList.CurrentRow;
                if (dgr == null) return;
                dgr.Selected = true;
                if (dgr.Cells["clDzbs"].Value.ToString().Equals("已核销"))
                {
                    MessageBox.Show("该挂账记录已核销!");
                    return;
                }
                decimal del_je = dgr.Cells["clJe"].Value == null ? 0 : decimal.Parse(dgr.Cells["clJe"].Value.ToString());
                decimal del_dzje = dgr.Cells["clDzje"].Value == null ? 0 : decimal.Parse(dgr.Cells["clDzje"].Value.ToString());
                string str_fpid = dgr.Cells["clFpid"].Value == null ? "" : dgr.Cells["clFpid"].Value.ToString();
                string str_fph = dgr.Cells["clFph"].Value == null ? "" : dgr.Cells["clFph"].Value.ToString();
                if (del_je - del_dzje <= 0)
                {
                    MessageBox.Show("该挂账记录已核销!");
                    return;
                }
                frmHtdwdzje f = new frmHtdwdzje();
                f.Je = del_je - del_dzje;
                f.fpid = str_fpid;
                f.fph = str_fph;
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    selIndex = dgr.Index;
                    M_Bind();
                    GetDzListInfo(str_fpid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现异常:\n_____________\n " + ex.Message);
            }
        }

        /// <summary>
        /// 单元格单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgr = dgvList.CurrentRow;
                if (dgr == null) return;
                dgr.Selected = true;
                if (dgr.Index == selIndex) return;
                selIndex = dgr.Index;
                if (dgr.Cells["clFpid"] != null && !String.IsNullOrEmpty(dgr.Cells["clFpid"].Value.ToString()))
                {
                    GetDzListInfo(dgr.Cells["clFpid"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 获取到账详细列表
        /// </summary>
        /// <param name="fpid"></param>
        /// <returns></returns>
        private void GetDzListInfo(string fpid)
        {
            try
            {
                string cmd = String.Format(@"select DZID,FPID,FPH,JE,QRRQ,QRRYXM,case when BWCBZ='1' then '到账' else '未到账' end as DZBS,BZ from MZ_HTDW_DZLOG where FPID='{0}' order by QRRQ desc ", fpid);
                dgvInfoList.DataSource = InstanceForm.BDatabase.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("取得到账详情出错: \n_____________\n" + ex.Message);
            }
        }

       
    }
}