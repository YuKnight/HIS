using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_mz_xtsz
{
    public partial class Frmmzyfglfy : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private int mod = 0;     //0 显示  1修改 
        private int _id = 0;
        public Frmmzyfglfy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.WindowState = FormWindowState.Maximized;
            this.Text = _chineseName;
        }

        private void Frmmzyfglfy_Load(object sender, EventArgs e)
        {
            ThisStatus();
            ReadTxt();
            Bind();
        }
        //数据绑定
        private void Bind()
        {
            string sql = @"select a.id,b.name as useage_name,a.num,
                           c.item_name as item ,a.USE_NAME,a.HSITEM_ID
                           from JC_USEAGE_FEE_MZ a 
                           left join jc_usagediction b on a.use_name =b.Name 
                           left join JC_HSITEM c on a.hsitem_id= c.item_id";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            dgvUseageFee.DataSource = tb;
            if (this.dgvUseageFee.RowCount == 0)
            {
                return;
            }
            dgvUseageFee.AllowUserToAddRows = false;
            dgvUseageFee.ReadOnly = true;
        }

        private void toolbtnClo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolbtnAdd_Click(object sender, EventArgs e)
        {
            AddStatus();//添加状态
            ClearTxt();//清空文本框
            mod = 0;
            _id = 0;
            WriterTxt();
            this.txtUse.Focus();
            this.dgvUseageFee.Enabled = false;
        }
        //编写状态
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
        //添加状态
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
        //清空文本框
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
        //文本框 读、清空、变色
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

        private void Frmmzyfglfy_KeyUp(object sender, KeyEventArgs e)
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

        private void toolbtnMod_Click(object sender, EventArgs e)
        {
            AddStatus();
            WriterTxt();
            mod = 1;
            this.txtUse.Focus();
            this.dgvUseageFee.Enabled = false;
        }

        private void toolbtnSav_Click(object sender, EventArgs e)
        {
            Guid log_djid = Guid.Empty;
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();

            #region 数据校验
            if (txtUse.Text.Trim() == "")
            {
                MessageBox.Show("请输入用法名称", "提示");
                return;
            }
            if (txtNum.Text.Trim() == "")
            {
                MessageBox.Show("请输入数量", "提示");
                return;
            }
            #endregion
            InstanceForm.BDatabase.BeginTransaction();
            try
            {
                ParameterEx[] parameters3 = new ParameterEx[6];
                parameters3[0].Text = "@USE_NAME";
                parameters3[0].Value = Convertor.IsNull(txtUse.Text.Trim(), "");
                parameters3[1].Text = "@NUM";
                parameters3[1].Value = Convert.ToInt32(this.txtNum.Text.Trim());
                parameters3[2].Text = "@HSITEM_ID";
                parameters3[2].Value = Convertor.IsNull(txtHsitem.Tag, "");
                parameters3[3].Text = "@id";
                parameters3[3].Value = _id;
                parameters3[4].Text = "@i";
                int iii = 0;
                if (mod == 0) iii = 1;
                if (mod == 1) iii = 2;
                parameters3[4].Value = iii;
                parameters3[5].Text = "@newid";
                parameters3[5].ParaDirection = ParameterDirection.Output;
                parameters3[5].DataType = System.Data.DbType.Int32;
                parameters3[5].ParaSize = 100;
                InstanceForm.BDatabase.DoCommand("SP_JC_USEAGE_FEE_MZ", parameters3, 60);
                if (mod == 0)
                {
                    //三院数据处理_____保存日志
                    string newid = Convertor.IsNull(parameters3[5].Value, "");
                    string bz = "";
                    bz = "保存门诊用法附加费用:" + txtUse.Text.ToString().Trim();
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "jc_useage_fee_mz", "id", newid, InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                }
                if (mod == 1)
                {

                    //三院数据处理_____保存日志
                    string bz = "";
                    bz = "更新门诊用法附加费用:" + txtUse.Text.ToString().Trim();
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "jc_useage_fee_mz", "id", _id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
                }

                InstanceForm.BDatabase.CommitTransaction();

                ThisStatus();
                dgvUseageFee.Enabled = true;
                Bind();
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

        private void dgvUseageFee_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dgvUseageFee.DataSource;

            if (tb == null || tb.Rows.Count == 0)
            {
                return;
            }

            int nrow = 0;
            if (dgvUseageFee.CurrentCell != null)
            {
                nrow = dgvUseageFee.CurrentCell.RowIndex;
            }

            _id = Convert.ToInt32(tb.Rows[nrow]["id"].ToString().Trim());
            txtUse.Text = tb.Rows[nrow]["useage_name"].ToString().Trim();
            txtUse.Tag = tb.Rows[nrow]["USE_NAME"].ToString().Trim();
            txtNum.Text = tb.Rows[nrow]["num"].ToString().Trim();
            txtHsitem.Text = tb.Rows[nrow]["item"].ToString().Trim();
            txtHsitem.Tag = tb.Rows[nrow]["HSITEM_ID"].ToString().Trim();
        }

        private void txtUse_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headText = new string[] { "编码", "名称", "拼音码", "五笔码", "数字码" };
                string[] mappName = new string[] { "id", "name", "py_code", "wb_code", "d_CODE" };
                int[] colWidth = new int[] { 75, 70, 75, 75, 75 };
                string[] searchFields = new string[] { "py_code", "wb_code", "d_code" };
                TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard(searchFields, headText, mappName, colWidth);
                selectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable("select id,name,py_code,wb_code,d_code from jc_usagediction order by id");
                selectCard.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                selectCard.Width = 300;
                selectCard.srcControl = txtUse;
                selectCard.WorkForm = this;
                selectCard.ShowDialog();
                if (selectCard.DialogResult == DialogResult.OK)
                {
                    this.txtUse.Text = selectCard.SelectDataRow["name"].ToString().Trim();
                    this.txtUse.Tag = selectCard.SelectDataRow["id"].ToString().Trim();
                    txtNum.Focus();
                }
            }
        }

        private void txtNum_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                txtHsitem.Focus();
            }
        }

        private void txtHsitem_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headText = new string[] { "编码", "名称", "拼音码", "五笔码" };
                string[] mappName = new string[] { "ITEM_ID", "ITEM_NAME", "py_code", "wb_code" };
                int[] colWidth = new int[] { 60, 90, 75, 75, 75 };
                string[] searchFields = new string[] { "py_code", "wb_code" };
                TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard(searchFields, headText, mappName, colWidth);
                selectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable("select ITEM_ID,ITEM_NAME,py_code,wb_code from JC_HSITEM where DELETE_BIT=0 order by ITEM_ID");
                selectCard.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                selectCard.Width = 300;
                selectCard.srcControl = txtHsitem;
                selectCard.WorkForm = this;
                selectCard.ShowDialog();
                if (selectCard.DialogResult == DialogResult.OK)
                {
                    this.txtHsitem.Text = selectCard.SelectDataRow["ITEM_NAME"].ToString().Trim();
                    this.txtHsitem.Tag = selectCard.SelectDataRow["ITEM_ID"].ToString().Trim();
                }
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

        private void toolbtnCal_Click(object sender, EventArgs e)
        {
            ReadTxt();
            ThisStatus();
            mod = 0;
            dgvUseageFee_CurrentCellChanged(null, null);
            dgvUseageFee.Enabled = true;
        }


        //判断是否为编辑状态
        private void caozuo()
        {
            if (mod == 0)
            {
                ReadTxt();
                dgvUseageFee.ReadOnly = true;
            }

            if (mod == 1)
            {
                dgvUseageFee.ReadOnly = true;
            }
        }

        private void toolbtnRef_Click(object sender, EventArgs e)
        {
            Bind();
            mod = 0;
            caozuo();
        }

        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除这条记录？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                InstanceForm.BDatabase.BeginTransaction();
                try
                {
                    ParameterEx[] parameters3 = new ParameterEx[6];
                    parameters3[0].Text = "@id";
                    parameters3[0].Value = _id;
                    parameters3[1].Text = "@USE_NAME";
                    parameters3[1].Value = Convertor.IsNull(txtUse.Text.Trim(), "");
                    parameters3[2].Text = "@NUM";
                    parameters3[2].Value = Convert.ToInt32(this.txtNum.Text.Trim());
                    parameters3[3].Text = "@HSITEM_ID";
                    parameters3[3].Value = Convertor.IsNull(txtHsitem.Tag, "");
                    parameters3[4].Text = "@i";
                    parameters3[4].Value = 3;
                    parameters3[5].Text = "@newid";
                    parameters3[5].ParaDirection = ParameterDirection.Output;
                    parameters3[5].DataType = System.Data.DbType.Int32;
                    parameters3[5].ParaSize = 100;
                    InstanceForm.BDatabase.DoCommand("SP_JC_USEAGE_FEE_MZ", parameters3, 60);
                    //三院数据处理_____保存日志
                    string bz = "";
                    bz = "删除门诊用法附加费用:" + txtUse.Text.ToString().Trim();
                    Guid log_djid = Guid.Empty;
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "jc_useage_fee_mz", "id", _id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                    InstanceForm.BDatabase.CommitTransaction();

                    ClearTxt();
                    Bind();

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

        private void tooltextsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strVal = this.tooltextsearch.Text.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]");
                if (strVal != "")
                {
                    DataTable dt = (DataTable)dgvUseageFee.DataSource;
                    DataView dv = dt.DefaultView;
                    string strFilter1 = "useage_name like '" + strVal + "%' or item like '%" + strVal + "%'";
                    dv.RowFilter = strFilter1;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("查询错误，包含非法字符" + err.Message);
            }
        }
    }
}