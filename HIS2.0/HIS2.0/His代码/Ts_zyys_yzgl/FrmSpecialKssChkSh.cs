using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmSpecialKssChkSh : Form
    {
        public FrmSpecialKssChkSh()
        {
            InitializeComponent();

            DoInit();
        }

        public void DoInit()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AutoGenerateColumns = false;

            cmbBqBit.Enabled = cmbChkBit.Enabled = false;

            chkIsChk.Checked = cmbChkBit.Enabled = true;

            chkBqBz.CheckedChanged += new EventHandler(chkBqBz_CheckedChanged);
            chkIsChk.CheckedChanged += new EventHandler(chkIsChk_CheckedChanged);
        }

        void chkIsChk_CheckedChanged(object sender, EventArgs e)
        {
            cmbChkBit.Enabled = chkIsChk.Checked;
        }

        void chkBqBz_CheckedChanged(object sender, EventArgs e)
        {
            cmbBqBit.Enabled = chkBqBz.Checked;
        }

        private void FrmSpecialKssChkSh_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "0", "未审核" });
                dt.Rows.Add(new object[] { "1", "已审核" });

                Addcmb(cmbChkBit, dt, "id", "name");
            }
            catch { }

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "0", "待补审" });
                dt.Rows.Add(new object[] { "1", "已补审" });

                Addcmb(cmbBqBit, dt, "id", "name");
            }
            catch { }

            DoQuery();
        }

        public void DoQuery()
        {
            DataTable dt = DoQuery(dtpStart.Value.ToString("yyyy-MM-dd"),
                dtpEnd.Value.ToString("yyyy-MM-dd"),
                chkIsChk.Checked ? "shbz" : "1",
                chkIsChk.Checked ? cmbChkBit.SelectedValue.ToString() : "1",
                chkBqBz.Checked ? "bqbz" : "1",
                chkBqBz.Checked ? cmbBqBit.SelectedValue.ToString() : "1",
                InstanceForm._currentDept.DeptId.ToString()
                );

            dataGridView1.DataSource = dt;
        }

        public DataTable DoQuery(params string[] args)
        {
            try
            {
                string strSql = string.Format(@"select
                                                 a.order_id,
                                                 c.NAME,
                                                 c.BED_NO,
                                                 c.INPATIENT_NO,
                                                 dbo.fun_getDeptname(c.DEPT_ID) as dept_name ,
                                                 c.RYZD as zyzd,
                                                 b.HOITEM_ID as cjid,
                                                 b.ORDER_CONTEXT ,
                                                 case b.MNGTYPE when 0 then '长嘱' when 1 then '临嘱' end as YZ_TYPE,
                                                 b.order_bdate,
                                                 b.ORDER_SPEC,
                                                 dbo.fun_getEmpName(a.apply_man) as apply_man,
                                                 a.apply_time,
                                                 case a.yymd 
                                                    when '1' then '预防性用药' 
                                                    when '2' then '治疗性用药'
                                                    when '3' then '经验性用药'
                                                    when '4' then '目标性用药'
                                                    else '' end as yymd,
                                                 case a.yymd_xx 
                                                    when '1' then '内科高危人群' 
                                                    when '2' then 'I类清洁切口手术'
                                                    when '3' then 'II类清洁污染切口手术'
                                                    when '4' then '经验用药'
                                                    when '5' then '药敏依据'
                                                    when '6' then 'III类污染切口手术'
                                                    when '7' then 'IV类污秽感染切口'
                                                    else '' end as yymd_xx,
                                                 case a.yymd_memo when '-1' then '' else a.yymd_memo end as yymd_memo,--待修改
                                                 case a.yy_sx when '-1' then '' else a.yy_sx end as yy_sx,
                                                 a.yymd_bc,
                                                 a.ssitem_id,
                                                 case a.ssitem_id when '-1' then '' else isnull(dbo.FUN_ZY_SEEKITEMNAME(a.ssitem_id),'') end as ssitem_name,
                                                 case a.byjc_bit when '0' then '未送' when '1' then '已送' else '' end as byjc_bit,
                                                 a.byjc_memo,
                                                 case isnull(a.ymjg,'-1') when '0' then '没有' when '1' then '已有' else '' end as ymjg,
                                                 isnull(a.ymjg_memo,'') as ymjg_memo,
                                                 case isnull(a.byj_gm,'-1') when '0' then '不过敏' when '1' then '过敏' else '' end as byj_gm,
                                                 a.memo,
                                                 a.shbz,
                                                 case a.shbz when '0' then '待审核' when '1' then '已审核' end as shbz_name,
                                                 dbo.fun_getEmpName(a.shr) AS SHR ,a.shsj,
                                                 a.bqbz,
                                                 case a.bqbz when '0' then '待补签' when '1' then '' end as bqbz_name,
                                                 dbo.fun_getEmpName(a.bqr) AS bqr,a.bqsj
                                                from 
                                                zy_kss_sqb a
                                                inner join ZY_ORDERRECORD b on a.order_id=b.ORDER_ID and b.DELETE_BIT=0-- and t.DEL_BIT=0
                                                inner join VI_ZY_VINPATIENT_ALL c on b.INPATIENT_ID=c.INPATIENT_ID and b.BABY_ID=c.baby_id
                                                where DATEDIFF(DAY,'{0}',a.apply_time) >=0 
                                                and  DATEDIFF(DAY,'{1}',a.apply_time) <=0 
                                                and a.DEL_BIT=0 
                                                and {2}={3}
                                                and {4}={5}
                                                and a.dept_id='{6}'
                                                ", args);

                DataTable dt = InstanceForm._database.GetDataTable(strSql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DoQuery();
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChk_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    return;
                this.dataGridView1.EndEdit();

                string strSql = string.Format(@"select COUNT(1) as num from jc_kss_tsshr where employee_id='{0}' and dept_id='{1}' ", InstanceForm._currentUser.EmployeeId, InstanceForm._currentDept.DeptId);
                int iVal = int.Parse(InstanceForm._database.GetDataResult(strSql).ToString().Trim());
                if (iVal <= 0)
                {
                    MessageBox.Show("医生：" + InstanceForm._currentUser.Name + " 没有授予审核权限！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                string id = dgvr.Cells["order_id"].Value.ToString();

                if (MessageBox.Show("是否确认继续审核操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }

                string ssql = string.Format(@"select * from zy_kss_sqb where order_id='{0}' and del_bit=0 ", id);

                DataTable dt = InstanceForm._database.GetDataTable(ssql);

                if (dt != null && dt.Rows.Count >= 0)
                {
                    string strShbz = dt.Rows[0]["SHBZ"].ToString().Trim();

                    if (strShbz.Equals("0"))
                    {
                        //未审核医嘱
                        ssql = string.Format(@"update zy_kss_sqb set shbz='1',shr='{0}',shsj='{1}' where order_id='{2}' and del_bit=0 ", InstanceForm._currentUser.EmployeeId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id);

                        int iret = InstanceForm._database.DoCommand(ssql);

                        if (iret < 1)
                        {
                            MessageBox.Show("更新未成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        DoQuery();
                        MessageBox.Show("审核成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (strShbz.Equals("1"))
                    {
                        MessageBox.Show("该医嘱已经审核！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 补签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBq_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    return;
                this.dataGridView1.EndEdit();

                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                string id = dgvr.Cells["order_id"].Value.ToString();

                if (MessageBox.Show("是否确认进行补审操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }

                string ssql = string.Format(@"select * from zy_kss_sqb where order_id='{0}' and del_bit=0 ", id);

                DataTable dt = InstanceForm._database.GetDataTable(ssql);

                if (dt != null && dt.Rows.Count >= 0)
                {
                    string strBqbz = dt.Rows[0]["bqbz"].ToString().Trim();
                    string strShbz = dt.Rows[0]["shbz"].ToString().Trim();

                    if (strShbz.Equals("0"))
                    {
                        //未审核医嘱
                        MessageBox.Show("该医嘱未审核,不能补签！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (strShbz.Equals("1"))
                    {
                        ssql = string.Format(@"update zy_kss_sqb set shr='{0}',shsj='{1}',bqbz='1',bqr='{0}',bqsj='{1}' where order_id='{2}' and del_bit=0 ", InstanceForm._currentUser.EmployeeId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id);

                        int iret = InstanceForm._database.DoCommand(ssql);

                        if (iret < 1)
                        {
                            MessageBox.Show("补审未成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        DoQuery();
                        MessageBox.Show("补审成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }
    }
}