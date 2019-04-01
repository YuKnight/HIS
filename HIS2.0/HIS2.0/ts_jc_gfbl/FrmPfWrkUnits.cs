using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using System.Runtime.InteropServices;

namespace ts_jc_gfbl
{
    public partial class FrmPfWrkUnits : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmGflb frmmain = null;

        bool _isAdd = false;
        DataTable _dtZone = new DataTable();

        DataTable _dtAll = new DataTable();

        string _strOptionKind = "4444";//jc_option_kind 表中的4444节点
        string _yjexz = "";//月金额限制
        string _jexz = "";//金额限制
        string _cfsl = "";//处方数量
        string _cfslM = "";//月处方数量
        string _rJcje = "";//日检查金额
        string _rZlje = "";//日治疗金额

        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }

        public FrmPfWrkUnits()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {

                InitInfo();
            }
            catch { }
        }

        public void InitInfo()
        {
            this.Load += new EventHandler(FrmPfWrkUnits_Load);

            btnQuery.Click += new EventHandler(btnQuery_Click);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnSave.Click += new EventHandler(btnSave_Click);

            btnClose.Click += new EventHandler(delegate(object s, EventArgs args)
            {
                this.Close();
            });

            treeView1.AfterSelect += new TreeViewEventHandler(delegate(object s, TreeViewEventArgs args)
            {
                if (_dtAll != null)
                {
                    DataTable dtAllInfo = _dtAll.Copy();
                    BindDataInfo(dtAllInfo);
                }
            });

            rbtAll.CheckedChanged += new EventHandler(delegate(object s, EventArgs args)
            {
                if (_dtAll != null)
                {
                    DataTable dtAllInfo = _dtAll.Copy();
                    BindDataInfo(dtAllInfo);
                }
            });

            rbtClose.CheckedChanged += new EventHandler(delegate(object s, EventArgs args)
            {
                if (_dtAll != null)
                {
                    DataTable dtAllInfo = _dtAll.Copy();
                    BindDataInfo(dtAllInfo);
                }
            });

            rbtOpen.CheckedChanged += new EventHandler(delegate(object s, EventArgs args)
            {
                if (_dtAll != null)
                {
                    DataTable dtAllInfo = _dtAll.Copy();
                    BindDataInfo(dtAllInfo);
                }
            });

            txtQuery.TextChanged += new EventHandler(delegate(object s, EventArgs args)
            {
                if (_dtAll != null)
                {
                    DataTable dtAllInfo = _dtAll.Copy();
                    BindDataInfo(dtAllInfo);
                }
            });

            dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
            dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);


            //cmbYblx.TextChanged
            txtWrkUnit.KeyPress += new KeyPressEventHandler(GotoNext);
            txtPym.KeyPress += new KeyPressEventHandler(GotoNext);
            txtWbm.KeyPress += new KeyPressEventHandler(GotoNext);
            cmbZone.KeyPress += new KeyPressEventHandler(GotoNext);
            txtFzr.KeyPress += new KeyPressEventHandler(GotoNext);
            txtKhyh.KeyPress += new KeyPressEventHandler(GotoNext);
            txtFkzh.KeyPress += new KeyPressEventHandler(GotoNext);
            txtTel.KeyPress += new KeyPressEventHandler(GotoNext);
            txtAddr.KeyPress += new KeyPressEventHandler(GotoNext);
            txtJexz.KeyPress += new KeyPressEventHandler(GotoNext);
            txtCfsl.KeyPress += new KeyPressEventHandler(GotoNext);
            txtCfslM.KeyPress += new KeyPressEventHandler(GotoNext);
            txtRJcje.KeyPress += new KeyPressEventHandler(GotoNext);
            txtRZlje.KeyPress += new KeyPressEventHandler(GotoNext);
        }

        void FrmPfWrkUnits_Load(object sender, EventArgs e)
        {
            try
            {
                DoSetPubfeeCfgInfo();

                DoQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void DoQuery()
        {
            try
            {
                _isAdd = false;

                txtWrkUnit.Enabled = false;
                cmbZone.Enabled = false;

                _dtZone = DoQueryZoneInfo(_strOptionKind);
                _dtAll = DoQueryPfWrkUnit();

                DataTable dtCmbZone = _dtZone.Copy();
                Addcmb(cmbZone, dtCmbZone, "OPTIONCODE", "OPTIONNAME");

                DataTable dtGrdZone = _dtZone.Copy();
                setTreeInfo(dtGrdZone);

                DataTable dtAllInfo = _dtAll.Copy();
                BindDataInfo(dtAllInfo);
            }
            catch { }
        }

        private DataTable DoQueryZoneInfo(string strOptionK)
        {
            try
            {
                string strSql = string.Format("select OPTIONID,OPTIONCODE,OPTIONNAME,OPTIONKIND,DEFAULTS,MEMO,PYM,WBM from jc_option_zy where OPTIONKIND='{0}' and basecode='{1}'", strOptionK, strOptionK);
                DataTable dt = InstanceForm._database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        /// <summary>
        /// 查询区域下的所有工作单位
        /// </summary>
        ///// <param name="wrkUnit">工作区域OptionCode</param>
        //private DataTable DoQueryPfWrkUnit(string wrkUnit)
        //{
        //    string strSql = string.Format("select id, name, pym, wbm, Wrk_Unit, fzr, bank, pay_id, tel_no, wrk_addr, del_bit, cfsl_xz, cfslM_xz, je_xz, jcje_xz, zlje_xz, memo, opr_date, opr_man, Mod_date, Mod_man from jc_gf_WrkUnit where Wrk_Unit='{0}' ", wrkUnit);

        //    DataTable dt = InstanceForm._database.GetDataTable(strSql);
        //    return dt;
        //}

        /// <summary>
        /// 查询区域下的所有工作单位
        /// </summary>
        /// <param name="wrkUnit">工作区域OptionCode</param>
        /// <param name="all">是否查询全部   0：查询全部</param>
        /// <returns></returns>
        private DataTable DoQueryPfWrkUnit()
        {
            string strSql = string.Format("select id, name, pym, wbm, Wrk_Unit, fzr, bank, pay_id, tel_no, wrk_addr, del_bit, cfsl_xz, cfslM_xz, je_xz, jcje_xz, zlje_xz, memo, opr_date, opr_man, Mod_date, Mod_man from jc_gf_WrkUnit where 1=1 order by Wrk_Unit desc,del_bit asc");

            DataTable dt = InstanceForm._database.GetDataTable(strSql);
            return dt;
        }

        #region"Event"

        void btnQuery_Click(object sender, EventArgs e)
        {
            DoQuery();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选择一个区域节点后再进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtWrkUnit.Enabled = true;
                cmbZone.Enabled = true;

                txtWrkUnit.Text = "";
                txtPym.Text = "";
                txtWbm.Text = "";
                txtFzr.Text = "";
                txtKhyh.Text = "";
                txtFkzh.Text = "";
                txtTel.Text = "";
                txtAddr.Text = "";

                txtJexz.Text = _jexz;
                txtCfsl.Text = _cfsl;
                txtCfslM.Text = _cfslM;
                txtRJcje.Text = _rJcje;
                txtRZlje.Text = _rZlje;

                txtMemo.Text = "";
                //cmbZone
                chkDel.Checked = false;

                if (treeView1.SelectedNode.Level == 0)
                {
                    cmbZone.SelectedIndex = 0;
                }
                else if (treeView1.SelectedNode.Level == 1)
                {
                    cmbZone.SelectedValue = treeView1.SelectedNode.Name;
                }

                txtWrkUnit.Select();

                _isAdd = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal d = 0M;
                if (!decimal.TryParse(txtJexz.Text.Trim(), out d))
                {
                    txtJexz.Focus();
                    MessageBox.Show("金额限制 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtCfsl.Text.Trim(), out d))
                {
                    txtCfsl.Focus();
                    MessageBox.Show("处方数量 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtCfslM.Text.Trim(), out d))
                {
                    txtCfslM.Focus();
                    MessageBox.Show("月处方数量 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtRJcje.Text.Trim(), out d))
                {
                    txtRJcje.Focus();
                    MessageBox.Show("日检查金额 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtRZlje.Text.Trim(), out d))
                {
                    txtRZlje.Focus();
                    MessageBox.Show("日治疗金额 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("确定操作吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    return;
                }

                FrmMdiMain.Database.BeginTransaction();
                string id = "";
                string strSql = "";
                int iReturn = 0;

                if (_isAdd)//新增
                {
                    //strSql = string.Format(@"select count(1) as NUM from  jc_gf_sflb where sflb='{0}'", txtCode.Text);

                    //DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    //if (dt == null || dt.Rows.Count <= 0)
                    //{
                    //    FrmMdiMain.Database.RollbackTransaction();
                    //    return;
                    //}

                    //if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    //{
                    //    FrmMdiMain.Database.RollbackTransaction();
                    //    MessageBox.Show(txtCode.Text + "的类别编码已存在，请重新命名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    txtCode.Focus();
                    //    return;
                    //}

                    //id = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                    strSql = string.Format(@"insert into jc_gf_WrkUnit( name, pym, wbm, Wrk_Unit, fzr, bank, pay_id, tel_no, wrk_addr, del_bit, cfsl_xz, cfslM_xz, je_xz, jcje_xz, zlje_xz, memo, opr_date, opr_man) 
                                                VALUES('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}','{13}',{14},'{15}','{16}','{17}')",
                                                txtWrkUnit.Text.Replace("'", ""),
                                                txtPym.Text.Replace("'", ""),
                                                txtWbm.Text.Replace("'", ""),
                                                cmbZone.SelectedValue.ToString(),
                                                txtFzr.Text.Replace("'", ""),
                                                txtKhyh.Text.Replace("'", ""),
                                                txtFkzh.Text.Replace("'", ""),
                                                txtTel.Text.Replace("'", ""),
                                                txtAddr.Text.Replace("'", ""),
                                                chkDel.Checked ? "1" : "0",
                                                txtCfsl.Text.Replace("'", ""),
                                                txtCfslM.Text.Replace("'", ""),
                                                txtJexz.Text.Replace("'", ""),
                                                txtRJcje.Text.Replace("'", ""),
                                                txtRZlje.Text.Replace("'", ""),
                                                txtMemo.Text.Replace("'", ""),
                                                DateManager.ServerDateTimeByDBType(InstanceForm._database),
                                                InstanceForm._currentUser.EmployeeId);
                    iReturn = FrmMdiMain.Database.DoCommand(strSql);
                }
                else//修改
                {
                    if (this.dataGridView1.CurrentRow == null)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }

                    id = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                    //strSql = string.Format(@"select count(1) as NUM from  jc_gf_sflb where sflb='{0}' and ID<>'{1}'", txtCode.Text, id);
                    //DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    //if (dt == null || dt.Rows.Count <= 0)
                    //{
                    //    FrmMdiMain.Database.RollbackTransaction();
                    //    return;
                    //}
                    //if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    //{
                    //    FrmMdiMain.Database.RollbackTransaction();
                    //    MessageBox.Show(txtCode.Text + "的类别编码已存在，请重新命名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    strSql = string.Format(@"update   [jc_gf_WrkUnit] set  
                                            [name] = '{0}',
                                            [pym] = '{1}',
                                            [wbm] = '{2}',
                                            [Wrk_Unit] = '{3}',
                                            [fzr] = '{4}',
                                            [bank] = '{5}',
                                            [pay_id] = '{6}',
                                            [tel_no] = '{7}',
                                            [wrk_addr] = '{8}',
                                            [del_bit] = '{9}',
                                            [cfsl_xz] = {10},
                                            [cfslM_xz] = '{11}',
                                            [je_xz] = '{12}' ,
                                            [jcje_xz] = '{13}' ,
                                            [zlje_xz] = '{14}'  ,
                                            [Mod_date] = '{15}' ,
                                            [Mod_man] = '{16}'  ,
                                            [memo] = '{17}' 
                                            where ID='{18}'",
                                            txtWrkUnit.Text.Replace("'", ""),
                                            txtPym.Text.Replace("'", ""),
                                            txtWbm.Text.Replace("'", ""),
                                            cmbZone.SelectedValue.ToString(),
                                            txtFzr.Text.Replace("'", ""),
                                            txtKhyh.Text.Replace("'", ""),
                                            txtFkzh.Text.Replace("'", ""),
                                            txtTel.Text.Replace("'", ""),
                                            txtAddr.Text.Replace("'", ""),
                                            chkDel.Checked ? "1" : "0",
                                            txtCfsl.Text.Replace("'", ""),
                                            txtCfslM.Text.Replace("'", ""),
                                            txtJexz.Text.Replace("'", ""),
                                            txtRJcje.Text.Replace("'", ""),
                                            txtRZlje.Text.Replace("'", ""),
                                            txtMemo.Text.Replace("'", ""),
                                            DateManager.ServerDateTimeByDBType(InstanceForm._database),
                                            InstanceForm._currentUser.EmployeeId,
                                            id);
                    iReturn = FrmMdiMain.Database.DoCommand(strSql);

                    if (!this.dataGridView1.CurrentRow.Cells["del_bit"].Value.ToString().Equals(chkDel.Checked ? "1" : "0"))
                    {
                        //删除状态变更写日志  信息科要求
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm._currentDept.DeptId, InstanceForm._currentUser.EmployeeId, "更新公费单位信息的删除状态", "将单位" + cmbZone.Text + "_" + txtWrkUnit.Text + " 的删除状态更新为 " + (chkDel.Checked ? "删除" : "正常") + " " + InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database), 1, "主机名：" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
                if (iReturn <= 0)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FrmMdiMain.Database.CommitTransaction();

                _isAdd = false;
                DoQuery();
                //DoGetFocus(txtCode.Text);
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null)
                    return;
                this.dataGridView1.EndEdit();


                txtWrkUnit.Text = this.dataGridView1.CurrentRow.Cells["name"].Value.ToString();
                txtPym.Text = this.dataGridView1.CurrentRow.Cells["pym"].Value.ToString();
                txtWbm.Text = this.dataGridView1.CurrentRow.Cells["wbm"].Value.ToString();
                txtFzr.Text = this.dataGridView1.CurrentRow.Cells["fzr"].Value.ToString();
                txtKhyh.Text = this.dataGridView1.CurrentRow.Cells["bank"].Value.ToString();
                txtFkzh.Text = this.dataGridView1.CurrentRow.Cells["pay_id"].Value.ToString();
                txtTel.Text = this.dataGridView1.CurrentRow.Cells["tel_no"].Value.ToString();
                txtAddr.Text = this.dataGridView1.CurrentRow.Cells["wrk_addr"].Value.ToString();

                txtJexz.Text = this.dataGridView1.CurrentRow.Cells["je_xz"].Value.ToString();
                txtCfsl.Text = this.dataGridView1.CurrentRow.Cells["cfsl_xz"].Value.ToString();
                txtCfslM.Text = this.dataGridView1.CurrentRow.Cells["cfslM_xz"].Value.ToString();
                txtRJcje.Text = this.dataGridView1.CurrentRow.Cells["jcje_xz"].Value.ToString();
                txtRZlje.Text = this.dataGridView1.CurrentRow.Cells["zlje_xz"].Value.ToString();

                txtMemo.Text = this.dataGridView1.CurrentRow.Cells["memo"].Value.ToString();
                //id, name, pym, wbm, Wrk_Unit, fzr, bank, pay_id, tel_no, wrk_addr, del_bit, cfsl_xz, cfslM_xz, je_xz, jcje_xz, zlje_xz, memo, opr_date, opr_man, Mod_date, Mod_man

                cmbZone.SelectedValue = this.dataGridView1.CurrentRow.Cells["Wrk_Unit"].Value.ToString();

                chkDel.Checked = this.dataGridView1.CurrentRow.Cells["del_bit"].Value.ToString().Equals("1");

                //txtName.Enabled = false;
                txtJexz.Select();
                _isAdd = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rect, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                //隔行换色
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                DoChangeColor();
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

        #endregion

        //private void DoGetFocus(string id)
        //{
        //    foreach (DataGridViewRow dr in dataGridView1.Rows)
        //    {
        //        if (dr.Cells["id"].Value.ToString().Equals(id))
        //        {
        //            dr.Selected = true;
        //        }
        //        else
        //        {
        //            dr.Selected = false;
        //        }
        //    }
        //}

        private void DoChangeColor()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["del_bit"].Value.ToString().Equals("1"))
                {
                    dr.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void setTreeInfo(DataTable dt)
        {
            try
            {
                treeView1.Nodes.Clear();

                TreeNode tn = new TreeNode();
                tn.Text = "显示全部";
                tn.Name = _strOptionKind;//OptionKind
                tn.Tag = "";

                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode tnCld = new TreeNode();
                    tnCld.Text = dr["OPTIONNAME"].ToString();
                    tnCld.Name = dr["OPTIONCODE"].ToString();//同根节点的OptionKind联查
                    tnCld.Tag = dr["OPTIONID"].ToString();

                    tn.Nodes.Add(tnCld);
                }

                treeView1.Nodes.Add(tn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void BindDataInfo(DataTable dtAllInfo)
        {
            try
            {
                TreeNode tn = treeView1.SelectedNode;
                if (tn != null)
                {
                    string strFil = "";
                    if (tn.Level == 0)
                    {
                        strFil = "1=1";
                        DoFilData(ref strFil);
                    }
                    else
                    {
                        string strWrkUnit = tn.Name;
                        strFil = "Wrk_Unit='" + strWrkUnit + "'";
                        DoFilData(ref strFil);
                    }
                    DoBindData(dtAllInfo, strFil);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void DoFilData(ref string strFil)
        {
            strFil += "and " + (rbtAll.Checked ? "'1'" : "del_bit") + "=" + (rbtAll.Checked ? "'1'" : rbtOpen.Checked ? "0" : "1");

            if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
            {
                strFil += " and (pym  like '%" + txtQuery.Text.Trim() + "%' or wbm like '%" + txtQuery.Text.Trim() + "%')";
            }
        }

        private void DoBindData(DataTable dtAllInfo, string strFil)
        {
            try
            {
                if (dataGridView1.DataSource != null)
                {
                    (dataGridView1.DataSource as DataTable).Clear();
                }

                DataTable dtBind = new DataTable();
                dtAllInfo.DefaultView.RowFilter = strFil;
                dtBind = dtAllInfo;

                if (dtBind != null && dtBind.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtBind;
                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        private void DoSetPubfeeCfgInfo()
        {
            _yjexz = GetIniString("ldxz", "YJEXZ", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _jexz = GetIniString("ldxz", "JEXZ", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _cfsl = GetIniString("ldxz", "CFSL", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _cfslM = GetIniString("ldxz", "CFSLM", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _rJcje = GetIniString("ldxz", "RJCJE", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _rZlje = GetIniString("ldxz", "RZLJE", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");

            _strOptionKind = GetIniString("optionkind", "kind", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
        }
    }
}