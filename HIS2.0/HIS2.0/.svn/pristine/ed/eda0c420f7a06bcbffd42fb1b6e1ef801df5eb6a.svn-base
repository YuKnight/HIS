using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TszyHIS;

namespace ts_zy_czgl
{
    public partial class FrmCzgl : Form
    {
        private string _functionName = "";

        //Modify By Kevin 2013-07-23 
        //TrasenClasses.DatabaseAccess.RelationalDatabase dataBase = null; Modify By Tany 2015-05-12 这里不需要额外一个连接

        public FrmCzgl(string functionName, string chineseName)
        {
            InitializeComponent();

            _functionName = functionName;
            this.Text = chineseName;
            //dataBase = InstanceForm.BDatabase;//FrmMdiMain.Database.GetCopy(); Modify By Tany 2015-05-12 这里不需要额外一个连接
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCzrq_CheckedChanged(object sender, EventArgs e)
        {
            dtpCzrq1.Enabled = chkCzrq.Checked;
            dtpCzrq2.Enabled = chkCzrq.Checked;
        }

        private void chkJzrq_CheckedChanged(object sender, EventArgs e)
        {
            dtpJzrq1.Enabled = chkJzrq.Checked;
            dtpJzrq2.Enabled = chkJzrq.Checked;
        }

        private void rbWjz_CheckedChanged(object sender, EventArgs e)
        {
            btAffirm.Enabled = false;
            btRefuse.Enabled = false;

            if (rbWjz.Checked)
            {
                chkCzrq.Checked = true;
                chkJzrq.Checked = false;
                chkJzrq.Enabled = false;

                if (!(_functionName == "Fun_ts_zy_czgl_cx" || _functionName == "Fun_ts_zy_czgl_cx_all"))
                {
                    btAffirm.Enabled = true;
                    btRefuse.Enabled = true;
                }
            }
            else if (rbYjz.Checked)
            {
                chkCzrq.Checked = false;
                chkJzrq.Checked = true;
                chkJzrq.Enabled = true;
            }
            else
            {
                chkCzrq.Checked = true;
                chkJzrq.Checked = false;
                chkJzrq.Enabled = true;
            }

            DataTable tb = (DataTable)dgvData.DataSource;
            if (tb != null && tb.Rows.Count > 0)
            {
                tb.Clear();
            }
        }

        private void FrmCzgl_Load(object sender, EventArgs e)
        {
            //住院号长度
            txtinpatientNo.InpatientNoLength = Convert.ToInt32(new SystemCfg(5026).Config);
            txtinpatientNo.Text = InpatientNo.GetEmptyZyh();

            DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            dtpCzrq1.Value = now;
            dtpCzrq2.Value = now;
            dtpJzrq1.Value = now;
            dtpJzrq2.Value = now;

            //病区
            //DataTable tb = InstanceForm.BDatabase.GetDataTable(@"SELECT WARD_ID,WARD_NAME FROM JC_WARD WHERE JGBM=" + FrmMdiMain.Jgbm + " ORDER BY WARD_ID");
            //Modify By Kevin 2013-09-23 改成调用数据库操作类中的SQL执行方法
            System.Collections.ArrayList arrList = new System.Collections.ArrayList();
            arrList.Add(1);
            arrList.Add(FrmMdiMain.Jgbm);
            DataTable tb = Ts_Zygl_Classes.PublicDataBaseAccessClass.BindWard(arrList, InstanceForm.BDatabase); //TszyHIS.DataBaseAccess.BindWard(FrmMdiMain.Jgbm, dataBase);
            if (tb == null)
            {
                MessageBox.Show("错误，未能取得病区信息！", "提示");
            }
            DataRow row = tb.NewRow();
            row["WARD_ID"] = "-1";
            row["WARD_NAME"] = "全部";
            tb.Rows.Add(row);
            cmbWard.DataSource = tb;
            cmbWard.DisplayMember = "WARD_NAME";
            cmbWard.ValueMember = "WARD_ID";

            if (_functionName == "Fun_ts_zy_czgl_all" || _functionName == "Fun_ts_zy_czgl_cx_all" || _functionName == "Fun_ts_zy_czgl_sh_all")
            {
                cmbWard.SelectedValue = "-1";
            }
            else
            {
                cmbWard.SelectedValue = InstanceForm.BCurrentDept.WardId;
                cmbWard.Enabled = false;
            }

            if (_functionName == "Fun_ts_zy_czgl_cx" || _functionName == "Fun_ts_zy_czgl_cx_all")
            {
                btAffirm.Enabled = false;
                btRefuse.Enabled = false;
            }

            if (_functionName == "Fun_ts_zy_czgl_sh" || _functionName == "Fun_ts_zy_czgl_sh_all")
            {
                btAffirm.Text = "审核";
            }
        }

        private void btPat_Click(object sender, EventArgs e)
        {
            DlgInpatients dlgInpatients = new DlgInpatients();
            if (!(_functionName == "Fun_ts_zy_czgl_all" || _functionName == "Fun_ts_zy_czgl_cx_all" || _functionName == "Fun_ts_zy_czgl_sh_all"))
            {
                if (InstanceForm.BCurrentDept.WardId == "")
                {
                    return;
                }
                dlgInpatients = new DlgInpatients(InstanceForm.BCurrentDept.WardId);
            }
            dlgInpatients.ShowDialog();

            string inpatientNo = DlgInpatients.SelectedInpatientNO;
            Guid inpatientId = DlgInpatients.SelectedInpatientID;
            string name = DlgInpatients.SelectedInpatientName;
            if (inpatientNo != "" && inpatientId != Guid.Empty)
            {
                txtinpatientNo.Text = inpatientNo;
                txtinpatientNo.Tag = inpatientId;
                txtName.Text = name;

                chkCzrq.Checked = false;
                chkJzrq.Checked = false;
            }
        }

        private void txtinpatientNo_TextChanged(object sender, EventArgs e)
        {
            txtinpatientNo.Tag = null;
            txtName.Text = "";

            rbWjz_CheckedChanged(null, null);
        }

        private void txtinpatientNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtinpatientNo.Text != InpatientNo.GetEmptyZyh())
                {
                    if (txtinpatientNo.Tag == null)
                    {
                        DlgInpatients dlgInpatients = new DlgInpatients();
                        if (!(_functionName == "Fun_ts_zy_czgl_all" || _functionName == "Fun_ts_zy_czgl_cx_all" || _functionName == "Fun_ts_zy_czgl_sh_all"))
                        {
                            if (InstanceForm.BCurrentDept.WardId == "")
                            {
                                return;
                            }
                            dlgInpatients = new DlgInpatients(InstanceForm.BCurrentDept.WardId);
                        }
                        dlgInpatients.txtZyh.Text = txtinpatientNo.Text;
                        dlgInpatients.tabControl1.SelectedTab = dlgInpatients.tpZyh;
                        dlgInpatients.cmbDept.SelectedIndex = -1;
                        DlgInpatients.SelectedDeptID = -1;
                        dlgInpatients.rbAll.Enabled = true;
                        dlgInpatients.rbAll.Checked = true;
                        dlgInpatients.txtZyh_KeyPress(null, new KeyPressEventArgs((char)13));
                        dlgInpatients.ShowDialog();

                        string inpatientNo = DlgInpatients.SelectedInpatientNO;
                        Guid inpatientId = DlgInpatients.SelectedInpatientID;
                        string name = DlgInpatients.SelectedInpatientName;

                        if (inpatientNo != "" && inpatientId != Guid.Empty)
                        {
                            txtinpatientNo.Text = inpatientNo;
                            txtinpatientNo.Tag = inpatientId;
                            txtName.Text = name;

                            chkCzrq.Checked = false;
                            chkJzrq.Checked = false;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            if (!rbWjz.Checked && !chkCzrq.Checked && !chkJzrq.Checked)
            {
                MessageBox.Show("查询的数据量太大，请选择日期查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = PubStaticFun.WaitCursor();

                //ParameterEx[] parameters = new ParameterEx[10];
                //parameters[0].Text = "@INPATIENT_ID";
                //parameters[0].Value = new Guid(Convertor.IsNull(txtinpatientNo.Tag, Guid.Empty.ToString()));

                //parameters[1].Text = "@WARD_ID";
                //parameters[1].Value = Convertor.IsNull(cmbWard.SelectedValue, "");

                //parameters[2].Text = "@CZRQ_BIT";
                //parameters[2].Value = chkCzrq.Checked ? 1 : 0;

                //parameters[3].Text = "@CZRQ1";
                //parameters[3].Value = dtpCzrq1.Value;

                //parameters[4].Text = "@CZRQ2";
                //parameters[4].Value = dtpCzrq2.Value;

                //parameters[5].Text = "@JZRQ_BIT";
                //parameters[5].Value = chkJzrq.Checked ? 1 : 0;

                //parameters[6].Text = "@JZRQ1";
                //parameters[6].Value = dtpJzrq1.Value;

                //parameters[7].Text = "@JZRQ2";
                //parameters[7].Value = dtpJzrq2.Value;

                //parameters[8].Text = "@TYPE";
                //parameters[8].Value = rbWjz.Checked ? 0 : (rbYjz.Checked ? 1 : -1);

                //parameters[9].Text = "@ISCX";
                //parameters[9].Value = (_functionName == "Fun_ts_zy_czgl_cx" || _functionName == "Fun_ts_zy_czgl_cx_all") ? 1 : 0;

                //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_CZGL_SELECT", parameters, 60);

                //Modify By Kevin 2013-09-23 改成调用数据库操作类中的SQL执行方法
                //Begin
                SystemCfg cfg7076 = new SystemCfg(7076);
                SystemCfg cfg7077 = new SystemCfg(7077);
                Guid inpatient_ID = new Guid(Convertor.IsNull(txtinpatientNo.Tag, Guid.Empty.ToString()));
                string ward_ID = Convertor.IsNull(cmbWard.SelectedValue.ToString(), "");
                int czrq_BIT = chkCzrq.Checked ? 1 : 0;
                DateTime czrq_ONE = dtpCzrq1.Value;
                DateTime czrq_TWO = dtpCzrq2.Value;
                int jzrq_BIT = chkJzrq.Checked ? 1 : 0;
                DateTime jzrq_ONE = dtpJzrq1.Value;
                DateTime jzrq_TWO = dtpJzrq2.Value;
                int type = rbWjz.Checked ? 0 : (rbYjz.Checked ? 1 : -1);
                int iscx = (_functionName == "Fun_ts_zy_czgl_cx" || _functionName == "Fun_ts_zy_czgl_cx_all") ? 1 : 0;

                System.Collections.ArrayList arrList = new System.Collections.ArrayList();
                arrList.Add(inpatient_ID);
                arrList.Add(ward_ID);
                arrList.Add(czrq_BIT);
                arrList.Add(czrq_ONE);
                arrList.Add(czrq_TWO);
                arrList.Add(jzrq_BIT);
                arrList.Add(jzrq_ONE);
                arrList.Add(jzrq_TWO);
                arrList.Add(type);
                arrList.Add(iscx);
                arrList.Add(cfg7076.Config);
                arrList.Add(cfg7077.Config);

                DataTable tb = Ts_Zygl_Classes.ComManageDataBaseAccessClass.ZyInquiryAuditPatient(arrList, InstanceForm.BDatabase); //TszyHIS.DataBaseAccess.ZyInquiryAuditPatient(inpatient_ID, ward_ID, czrq_BIT, czrq_ONE, czrq_TWO, jzrq_BIT, jzrq_ONE, jzrq_TWO, type, iscx, cfg7076.Config, cfg7077.Config, dataBase);
                //End

                AddRowtNo(tb);

                this.dgvData.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("序号") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kind">0 全选 1反选  2全部不选</param>
        /// <param name="dvg"></param>
        private void SelectAll(int kind, DataGridView dgv)
        {
            DataTable tb = ((DataTable)dgv.DataSource);
            if (tb == null) return;
            if (tb.Rows.Count <= 0) return;

            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (kind == 0)
                {
                    tb.Rows[i]["选择"] = true;
                }
                else if (kind == 1)
                {
                    tb.Rows[i]["选择"] = tb.Rows[i]["选择"].ToString() == "1" ? false : true;
                }
                else
                {
                    tb.Rows[i]["选择"] = false;
                }
            }
            dgv.DataSource = tb;
        }

        private void btQx_Click(object sender, EventArgs e)
        {
            SelectAll(0, dgvData);
        }

        private void btFx_Click(object sender, EventArgs e)
        {
            SelectAll(1, dgvData);
        }

        private void btAffirm_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dgvData.DataSource;
            DataRow[] rows = tb.Select("选择=1");
            if (rows.Length == 0)
            {
                MessageBox.Show("请选择申请记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable newtb = tb.Clone();
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                newtb.ImportRow(rows[i]);
            }

            if (_functionName == "Fun_ts_zy_czgl_sh" || _functionName == "Fun_ts_zy_czgl_sh_all")
            {
                //审核
                try
                {
                    if (MessageBox.Show("是否要审核通过这些申请记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }

                    DlgInputBox Inputbox = new DlgInputBox("", "请输入审核通过申请的原因", "");
                    Inputbox.ShowDialog();
                    string _yy = Convertor.IsNull(DlgInputBox.DlgValue, "无");

                    try
                    {
                        InstanceForm.BDatabase.BeginTransaction();
                        System.Collections.ArrayList arrList = new System.Collections.ArrayList();
                        for (int i = 0; i <= newtb.Rows.Count - 1; i++)
                        {
                            Guid feeid = new Guid(newtb.Rows[i]["feeid"].ToString());
                            //InstanceForm.BDatabase.DoCommand("delete from zy_czsh where feeid='" + feeid + "'");
                            //InstanceForm.BDatabase.DoCommand("insert into zy_czsh(FEEID, SHBZ, SHR, SHRQ, BZ) values('" + feeid + "',1," + InstanceForm.BCurrentUser.EmployeeId + ",getdate(),'" + _yy + "')");

                            //Modify By Kevin 2013-09-23 改成调用数据库操作类中的SQL执行方法
                            arrList.Clear();
                            arrList.Add(feeid);
                            arrList.Add(InstanceForm.BCurrentUser.EmployeeId);
                            arrList.Add(_yy);
                            //TszyHIS.DataBaseAccess.ZyHedgeAudit(feeid, InstanceForm.BCurrentUser.EmployeeId, _yy, dataBase);
                            Ts_Zygl_Classes.ComManageDataBaseAccessClass.ZyHedgeAudit(arrList, InstanceForm.BDatabase, false);
                        }

                        InstanceForm.BDatabase.CommitTransaction();
                    }
                    catch (Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        throw err;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //确认
                try
                {
                    bool isSH = true;
                    string sql = "";
                    string tj = "";
                    //7079冲正额度管理是否需要审核后才能确认 0=不是 1=是
                    if (new SystemCfg(7079).Config == "0")
                    {
                        isSH = false;
                    }

                    if (MessageBox.Show("是否要确认这些申请记录？" + (isSH ? "\n\n注意：审核状态为 X 的项目将自动被忽略，不能被确认！" : ""), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }

                    System.Collections.ArrayList arrList = new System.Collections.ArrayList();

                    for (int i = 0; i <= newtb.Rows.Count - 1; i++)
                    {
                        Guid feeid = new Guid(newtb.Rows[i]["feeid"].ToString());
                        //if (isSH)
                        //{
                        //    tj = " inner join zy_czsh b on a.id=b.feeid and b.shbz=1 ";
                        //}
                        //else
                        //{
                        //    tj = "";
                        //}
                        //sql = "update a set a.charge_bit=1,a.charge_date=getdate(),a.charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " from zy_fee_speci a " + tj + " where a.id='" + feeid + "' and a.charge_bit=0 and a.delete_bit=0";
                        //InstanceForm.BDatabase.DoCommand(sql);

                        //Modify By Kevin 2013-09-23 改成调用数据库操作类中的SQL执行方法
                        arrList.Clear();
                        arrList.Add(feeid);
                        arrList.Add(InstanceForm.BCurrentUser.EmployeeId);
                        arrList.Add(isSH);

                        //TszyHIS.DataBaseAccess.ZyConfirmAudit(feeid, InstanceForm.BCurrentUser.EmployeeId, isSH, dataBase);
                        Ts_Zygl_Classes.ComManageDataBaseAccessClass.ZyConfirmAudit(arrList, InstanceForm.BDatabase);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            btRefresh_Click(null, null);
        }

        private void btRefuse_Click(object sender, EventArgs e)
        {
            if (!(_functionName == "Fun_ts_zy_czgl_sh" || _functionName == "Fun_ts_zy_czgl_sh_all"))
            {
                //7079冲正额度管理是否需要审核后才能确认 0=不是 1=是
                if (new SystemCfg(7079).Config == "1")
                {
                    MessageBox.Show("拒绝申请需要审核模块操作，当前模块不能使用该功能！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                DataTable tb = (DataTable)dgvData.DataSource;
                DataRow[] rows = tb.Select("选择=1");
                if (rows.Length == 0)
                {
                    MessageBox.Show("请选择申请记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable newtb = tb.Clone();
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    newtb.ImportRow(rows[i]);
                }

                if (MessageBox.Show("是否要拒绝这些申请记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                DlgInputBox Inputbox = new DlgInputBox("", "请输入拒绝申请的原因", "");
                Inputbox.ShowDialog();
                string _yy = Convertor.IsNull(DlgInputBox.DlgValue, "无");

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    System.Collections.ArrayList arrList = new System.Collections.ArrayList();
                    for (int i = 0; i <= newtb.Rows.Count - 1; i++)
                    {
                        Guid feeid = new Guid(newtb.Rows[i]["feeid"].ToString());
                        //InstanceForm.BDatabase.DoCommand("delete from zy_czsh where feeid='" + feeid + "'");
                        //InstanceForm.BDatabase.DoCommand("insert into zy_czsh(FEEID, SHBZ, SHR, SHRQ, BZ) values('" + feeid + "',0," + InstanceForm.BCurrentUser.EmployeeId + ",getdate(),'" + _yy + "')");
                        //InstanceForm.BDatabase.DoCommand("update zy_fee_speci set delete_bit=1,bz='申请被拒绝：" + _yy + "' where id='" + feeid + "' and charge_bit=0 and delete_bit=0");

                        //Modify By Kevin 2013-09-23 改成调用数据库操作类中的SQL执行方法
                        arrList.Clear();
                        arrList.Add(feeid);
                        arrList.Add(InstanceForm.BCurrentUser.EmployeeId);
                        arrList.Add(_yy);

                        //TszyHIS.DataBaseAccess.ZyRefuseAudit(feeid, InstanceForm.BCurrentUser.EmployeeId, _yy, dataBase);
                        Ts_Zygl_Classes.ComManageDataBaseAccessClass.ZyRefuseAudit(arrList, InstanceForm.BDatabase, false);
                    }

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    throw err;
                }

                btRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}