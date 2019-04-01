using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame;
using TrasenFrame.Forms;

namespace ts_mz_yspbsz
{
    public partial class Frm_yspb_ksflmx : Form
    {
        private SystemCfg cfg3035 = new SystemCfg(3035);//是否根据诊间来设置
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        private int mod = 0;     // 0 显示  1修改 
        private int _id = -1;

        public Frm_yspb_ksflmx()
        {
            InitializeComponent();
        }

        public Frm_yspb_ksflmx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }


        private DataTable getDT;
        private void Bangding()
        {
            string sql = "";
            if (cfg3035.Config == "0")
            {
                sql = @"select a.id,b.[name] as ksmc,c.mc as flmc,a.ksid,a.flid,a.pxxh,a.ZJID_QC,b.PY_CODE as pym
                            from JC_MZ_YSPB_KSFLMX a
                            left join JC_DEPT_PROPERTY b on a.ksid = b.dept_id
                            left join JC_MZ_YSPB_KSFL c on a.flid = c.id";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                this.dgvkssz.DataSource = dt;
                getDT = dt;
            }
            else
            {
                sql = @"select a.id,b.ZJMC_QC as ksmc,c.mc as flmc,a.ZJID_QC,a.flid,a.pxxh,a.ksid,b.PYM
                            from JC_MZ_YSPB_KSFLMX a
                            left join JC_ZJSZ_QC b on a.ZJID_QC = b.ZJID_QC 
                            left join JC_MZ_YSPB_KSFL c on a.flid = c.id
                            where a.ZJID_QC<>0 and b.deleted=0"; //不启用诊间排班的话 就查询科室表 启用的话就查诊间表
                DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                this.dgvkssz.DataSource = tb;
                getDT = tb;
            }
            if (this.dgvkssz.RowCount == 0)
                return;
            dgvkssz.AllowUserToAddRows = false;
            this.dgvkssz.ReadOnly = true;
        }

        //初始状态
        private void ThisStatus()
        {
            toolbtnAdd.Enabled = true;
            toolbtnMod.Enabled = true;
            toolbtnDel.Enabled = true;
            toolbtnSav.Enabled = false;
            toolbtnCal.Enabled = false;
            toolbtnRef.Enabled = true;
        }

        private void ReadTxt()
        {
            foreach (Control ctl in splitContainer1.Panel2.Controls)
            {
                if (!ctl.GetType().IsSubclassOf(typeof(System.Windows.Forms.Label)) && ctl.GetType() != typeof(System.Windows.Forms.Label))
                {
                    ctl.Enabled = false;
                }
            }
        }

        private void Frm_yspb_ksflmx_Load(object sender, EventArgs e)
        {
            ThisStatus();
            ReadTxt();
            Bangding();
        }

        private void dgvkssz_Click(object sender, EventArgs e)
        {
            ReadTxt();
            if (dgvkssz.RowCount > 0)
            {
                _id = Convert.ToInt32(this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["id"].Value.ToString());
                txtDept.Text = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["ksmc"].Value.ToString();
                txtDept.Tag = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["ksid"].Value.ToString();
                txtType.Text = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["flmc"].Value.ToString();
                txtType.Tag = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["flid"].Value.ToString();
                txtPXXH.Text = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["pxxh"].Value.ToString();
            }

            ThisStatus();
        }

        private void WriterTxt()
        {
            foreach (Control ctl in splitContainer1.Panel2.Controls)
            {
                if (!ctl.GetType().IsSubclassOf(typeof(System.Windows.Forms.Label)) && ctl.GetType() != typeof(System.Windows.Forms.Label))
                {
                    ctl.Enabled = true;
                }
            }
        }

        private void ClearTxt()
        {
            foreach (Control ctl in splitContainer1.Panel2.Controls)
            {
                if (ctl.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    ctl.Text = "";
                    ctl.Tag = "";
                }
            }
        }

        private void AddStatus()
        {
            toolbtnAdd.Enabled = false;
            toolbtnMod.Enabled = false;
            toolbtnDel.Enabled = false;
            toolbtnSav.Enabled = true;
            toolbtnCal.Enabled = true;
            toolbtnRef.Enabled = false;
            toolbtnClo.Enabled = true;
        }

        private void toolbtnAdd_Click(object sender, EventArgs e)
        {
            AddStatus();
            ClearTxt();
            mod = 0;
            _id = 0;
            WriterTxt();
            this.txtDept.Focus();
            this.dgvkssz.Enabled = false;
        }

        private void toolbtnMod_Click(object sender, EventArgs e)
        {
            AddStatus();
            WriterTxt();
            mod = 1;
            this.txtDept.Focus();
            this.dgvkssz.Enabled = false;
        }

        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除这条记录？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                InstanceForm.BDatabase.BeginTransaction();
                try
                {
                    ParameterEx[] parameters3 = new ParameterEx[7];
                    parameters3[0].Text = "@ID";
                    parameters3[0].Value = _id;
                    parameters3[1].Text = "@KSID";
                    parameters3[1].Value = txtDept.Tag.ToString();
                    parameters3[2].Text = "@FLID";
                    parameters3[2].Value = txtType.Tag.ToString();
                    parameters3[3].Text = "@PXXH";
                    parameters3[3].Value = txtPXXH.Text.Trim();
                    parameters3[4].Text = "@ZJID_QC";
                    parameters3[4].Value = 0;
                    parameters3[5].Text = "@i";
                    parameters3[5].Value = 3;
                    parameters3[6].Text = "@newid";
                    parameters3[6].ParaDirection = ParameterDirection.Output;
                    parameters3[6].DataType = System.Data.DbType.Int32;
                    parameters3[6].ParaSize = 100;
                    InstanceForm.BDatabase.DoCommand("SP_JC_MZPB_KSFLSZ", parameters3, 60);

                    //三院数据处理_____保存日志
                    string bz = "";
                    bz = "删除门诊排班科室分类设置:" + txtDept.Text.ToString().Trim();
                    Guid log_djid = Guid.Empty;
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "JC_MZ_YSPB_KSFLMX", "ID", _id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                    InstanceForm.BDatabase.CommitTransaction();

                    ClearTxt();
                    Bangding();

                    //三院数据处理___执行同步操作 
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, InstanceForm.BDatabase);
                    if (ty.Bzx == 1 && log_djid != Guid.Empty) //只有当立即执行标志为1时才执行
                    {
                        ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                        if (errtext != "") MessageBox.Show(errtext, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void toolbtnSav_Click(object sender, EventArgs e)
        {
            Guid log_djid = Guid.Empty;
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();

            if (txtDept.Text.Trim() == "")
            {
                MessageBox.Show("请输入科室名称", "提示");
                return;
            }
            if (txtType.Text.Trim() == "")
            {
                MessageBox.Show("请输入分类名称", "提示");
                return;
            }

            InstanceForm.BDatabase.BeginTransaction();
            try
            {
                string sql = "select * from JC_MZ_YSPB_KSFLMX where KSID='" + txtDept.Tag.ToString() + "' and FLID='" + txtType.Tag.ToString() + "'";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("【" + txtType.Text.Trim() + "】" + "已存在名称为" + "【" + txtDept.Text.Trim() + "】的科室", "提示");
                    return;
                }

                ParameterEx[] parameters3 = new ParameterEx[7];

                parameters3[0].Text = "@ID";
                parameters3[0].Value = _id;
                parameters3[1].Text = "@KSID";
                parameters3[1].Value = txtDept.Tag.ToString();
                parameters3[2].Text = "@FLID";
                parameters3[2].Value = txtType.Tag.ToString();
                parameters3[3].Text = "@PXXH";
                parameters3[3].Value = txtPXXH.Text.Trim();
                if (cfg3035.Config == "0")
                {
                    parameters3[4].Text = "@ZJID_QC";
                    parameters3[4].Value = 0;
                }
                else
                {
                    parameters3[4].Text = "@ZJID_QC";
                    parameters3[4].Value = txtDept.Tag.ToString();
                }
                parameters3[5].Text = "@i";
                int iii = 0;
                if (mod == 0) iii = 1;
                if (mod == 1) iii = 2;
                parameters3[5].Value = iii;
                parameters3[6].Text = "@newid";
                parameters3[6].ParaDirection = ParameterDirection.Output;
                parameters3[6].DataType = System.Data.DbType.Int32;
                parameters3[6].ParaSize = 100;
                InstanceForm.BDatabase.DoCommand("SP_JC_MZPB_KSFLSZ", parameters3, 60);
                if (mod == 0)
                {
                    //三院数据处理_____保存日志
                    string newid = Convertor.IsNull(parameters3[5].Value, "");
                    string bz = "";
                    bz = "保存门诊排班科室分类设置:" + txtDept.Text.ToString().Trim();
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "JC_MZ_YSPB_KSFLMX", "ID", newid, InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                }
                if (mod == 1)
                {

                    //三院数据处理_____保存日志
                    string bz = "";
                    bz = "更新门诊排班科室分类设置:" + txtDept.Text.ToString().Trim();
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "JC_MZ_YSPB_KSFLMX", "ID", _id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
                }

                InstanceForm.BDatabase.CommitTransaction();

                ThisStatus();
                this.dgvkssz.Enabled = true;
                Bangding();
                ReadTxt();

                //三院数据处理___执行同步操作 
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid != Guid.Empty) //只有当立即执行标志为1时才执行
                {
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                    if (errtext != "") MessageBox.Show(errtext, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvkssz_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dgvkssz.DataSource;

            if (tb == null || tb.Rows.Count == 0)
            {
                return;
            }

            int nrow = 0;
            if (dgvkssz.CurrentCell != null)
            {
                nrow = dgvkssz.CurrentCell.RowIndex;
            }

            _id = Convert.ToInt32(tb.Rows[nrow]["id"].ToString().Trim());
            txtDept.Text = tb.Rows[nrow]["ksmc"].ToString().Trim();
            txtDept.Tag = tb.Rows[nrow]["ksid"].ToString().Trim();
            txtType.Text = tb.Rows[nrow]["flmc"].ToString().Trim();
            txtType.Tag = tb.Rows[nrow]["flid"].ToString().Trim();
            txtPXXH.Text = tb.Rows[nrow]["pxxh"].ToString().Trim();
        }

        private void toolbtnCal_Click(object sender, EventArgs e)
        {
            ReadTxt();
            ThisStatus();
            mod = 0;
            dgvkssz_CurrentCellChanged(null, null);
            dgvkssz.Enabled = true;
        }

        private void caozuo()
        {
            if (mod == 0)
            {
                ReadTxt();
                dgvkssz.ReadOnly = true;
            }

            if (mod == 1)
            {
                dgvkssz.ReadOnly = true;
            }
        }

        private void toolbtnRef_Click(object sender, EventArgs e)
        {
            Bangding();
            mod = 0;
            caozuo();
        }

        private void toolbtnClo_Click(object sender, EventArgs e)
        {
            ReadTxt();
            if (MessageBox.Show("您确定要退出？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.None) == DialogResult.OK)
                this.Close();
        }

        private void txtDept_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                txtType.Focus();
            }
        }

        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                txtPXXH.Focus();
            }
        }

        private void txtPXXH_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                if (mod == 1)
                {
                    if (MessageBox.Show("您确定要修改这条记录？", "修改提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        toolbtnSav_Click(null, null);
                    }
                }
                else
                {
                    if (MessageBox.Show("您确定要添加这条记录？", "保存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        toolbtnSav_Click(null, null);
                    }
                }
            }
        }

        private void txtDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (cfg3035.Config == "0")
            {
                if ((int)e.KeyChar != 13)
                {
                    string[] headText = new string[] { "科室代码", "科室名称", "拼音码" };
                    string[] mappName = new string[] { "DEPT_ID", "NAME", "pym" };
                    int[] colWidth = new int[] { 90, 90, 40 };
                    string[] searchFields = new string[] { "pym", "NAME" };
                    TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard(searchFields, headText, mappName, colWidth);
                    selectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable("SELECT DEPT_ID ,[NAME],py_code pym FROM JC_DEPT_PROPERTY WHERE MZ_FLAG = 1 and jgbm=" + FrmMdiMain.Jgbm + " AND DELETED = 0 AND DEPT_ID in (select DEPT_ID from jc_dept_type_relation where type_code = '001') ORDER BY SORT_ID ASC");
                    selectCard.ReciveString = e.KeyChar.ToString();
                    e.Handled = true;
                    selectCard.Width = 300;
                    selectCard.srcControl = txtDept;
                    selectCard.WorkForm = this;
                    selectCard.ShowDialog();

                    if (selectCard.DialogResult == DialogResult.OK)
                    {
                        this.txtDept.Text = selectCard.SelectDataRow["NAME"].ToString().Trim();
                        this.txtDept.Tag = selectCard.SelectDataRow["DEPT_ID"].ToString().Trim();
                        txtType.Focus();
                    }
                }
            }
            else
            {
                if ((int)e.KeyChar != 13)
                {
                    string[] headText = new string[] { "诊间代码", "诊间名称", "拼音码" };
                    string[] mappName = new string[] { "ZJID_QC", "ZJMC_QC", "pym" };
                    int[] colWidth = new int[] { 90, 90, 40 };
                    string[] searchFields = new string[] { "pym", "ZJMC_QC" };
                    TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard(searchFields, headText, mappName, colWidth);
                    selectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable("SELECT ZJID_QC ,ZJMC_QC,PYM  FROM JC_ZJSZ_QC WHERE  DELETED = 0");
                    selectCard.ReciveString = e.KeyChar.ToString();
                    e.Handled = true;
                    selectCard.Width = 300;
                    selectCard.srcControl = txtDept;
                    selectCard.WorkForm = this;
                    selectCard.ShowDialog();

                    if (selectCard.DialogResult == DialogResult.OK)
                    {
                        this.txtDept.Text = selectCard.SelectDataRow["ZJMC_QC"].ToString().Trim();
                        this.txtDept.Tag = selectCard.SelectDataRow["ZJID_QC"].ToString().Trim();
                        txtType.Focus();
                    }
                }
            }
        }

        private void txtType_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctrl = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headText = new string[] { "分类代码", "分类名称", "拼音码" };
                string[] mappName = new string[] { "ID", "MC", "pym" };
                int[] colWidth = new int[] { 90, 90, 40 };
                string[] searchFields = new string[] { "pym", "MC" };
                TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard(searchFields, headText, mappName, colWidth);
                selectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable("select ID,MC,dbo.getpywb(mc,0) pym from JC_MZ_YSPB_KSFL order by id asc");
                selectCard.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                selectCard.Width = 300;
                selectCard.srcControl = txtType;
                selectCard.WorkForm = this;
                selectCard.ShowDialog();

                if (selectCard.DialogResult == DialogResult.OK)
                {
                    this.txtType.Text = selectCard.SelectDataRow["MC"].ToString().Trim();
                    this.txtType.Tag = selectCard.SelectDataRow["ID"].ToString().Trim();
                    txtPXXH.Focus();
                }
            }
        }

        private void dgvkssz_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {

                Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,

                    Convert.ToInt32(e.RowBounds.Location.Y + (e.RowBounds.Height - dgvkssz.RowHeadersDefaultCellStyle.Font.Size) / 2),

                    dgvkssz.RowHeadersWidth - 4, e.RowBounds.Height);

                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),

                    dgvkssz.RowHeadersDefaultCellStyle.Font, rectangle, dgvkssz.RowHeadersDefaultCellStyle.ForeColor,

                    TextFormatFlags.Right);

            }
            catch (Exception ex)
            {

                Console.Write("dgvkssz_RowPostPaint：" + ex.Message);

            }
        }

        private void tooltextsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strVal = this.tooltextsearch.Text.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]");
                if (strVal != "")
                {
                    DataTable dt = (DataTable)dgvkssz.DataSource;
                    DataView dv = dt.DefaultView;
                    string strFilter1 = "ksmc like '" + strVal + "%' or flmc like '%" + strVal + "%'" + " or pym like '%" + strVal + "%'";
                    dv.RowFilter = strFilter1;
                }
                else
                {
                    Bangding();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("查询错误，包含非法字符" + err.Message);
            }
        }

        private void Frm_yspb_ksflmx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F3)
            {
                toolbtnAdd_Click(sender, e);
            }
            if (e.KeyData == Keys.F4)
            {
                toolbtnMod_Click(sender, e);
            }
            if (e.KeyData == Keys.F2)
            {
                toolbtnSav_Click(sender, e);
            }
        }


        private void dgvkssz_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (mod != 0)
            {
                if (dgvkssz.RowCount > 0)
                {
                    _id = Convert.ToInt32(this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["id"].Value.ToString());
                    txtDept.Text = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["ksmc"].Value.ToString();
                    txtDept.Tag = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["ksid"].Value.ToString();
                    txtType.Text = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["flmc"].Value.ToString();
                    txtType.Tag = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["flid"].Value.ToString();
                    txtPXXH.Text = this.dgvkssz.Rows[this.dgvkssz.CurrentCell.RowIndex].Cells["pxxh"].Value.ToString();
                }
                else
                {
                    ClearTxt();
                }
            }
            else { ClearTxt(); }

        }

    }
}
