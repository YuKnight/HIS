using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;

namespace ts_mz_kgl
{
    public partial class FrmHkJk : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public SystemCfg _cfg1079 = new SystemCfg(1079); //Add By zp 2013-11-14 设置卡号费的执行科室（0按照之前方式 大于0表示卡费执行科室） 
        public FrmHkJk(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";

            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmHkJk_Load(object sender, EventArgs e)
        {
            GetJhkJl(Guid.Empty);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            //this.toolStripMenuItem3.Visible = false;
            //this.卡锁定ToolStripMenuItem.Visible = false;
            //this.解除冻结ToolStripMenuItem.Visible = false;
            //this.取消挂失ToolStripMenuItem.Visible = false;

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            if (txtkh.Text.Trim() == "" && txtxm.Text.Trim() == "" && chkcsrq.Checked == false &&
                txtjtdh.Text.Trim() == "" && txtjtdz.Text.Trim() == "" && txtsfzh.Text.Trim() == "" && txtgrlxfs.Text.Trim() == "" &&
                dtpDjsj1.Checked == false && dtpDjsj2.Checked == false)
            {
                MessageBox.Show("查询范围过大，至少需要输入一个查询条件", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                ParameterEx[] parameters = new ParameterEx[11];

                parameters[0].Text = "@klx";
                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));

                parameters[1].Text = "@kh";
                parameters[1].Value = txtkh.Text.Trim();

                parameters[2].Text = "@brxm";
                parameters[2].Value = txtxm.Text.Trim();

                parameters[3].Text = "@BRLXFS";
                parameters[3].Value = txtgrlxfs.Text.Trim();

                parameters[4].Text = "@jtdz";
                parameters[4].Value = txtjtdz.Text.Trim();

                parameters[5].Text = "@jtdh";
                parameters[5].Value = txtjtdh.Text.Trim();

                parameters[6].Text = "@CSRQ";
                parameters[6].Value = chkcsrq.Checked == true ? dtpcsrq.Value.ToShortDateString() : "";

                parameters[7].Text = "@sfzh";
                parameters[7].Value = txtsfzh.Text.Trim();

                int zt = 0;
                if (rdDJ.Checked)
                    zt = 1;
                if (rdGS.Checked)
                    zt = 2;
                if (rdozf.Checked)
                    zt = 9;
                parameters[8].Text = "@zt";
                parameters[8].Value = zt;

                parameters[9].Text = "@bdjsj";
                parameters[9].Value = dtpDjsj1.Checked == true ? dtpDjsj1.Value.ToString("yyyy-MM-dd") + " 00:00:00" : "";

                parameters[10].Text = "@edjsj";
                parameters[10].Value = dtpDjsj2.Checked == true ? dtpDjsj2.Value.ToString("yyyy-MM-dd") + " 23:59:59" : "";

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_JKHK", parameters, 30);

                Fun.AddRowtNo(tb);
                this.dataGridView2.DataSource = tb;

                GetJhkJl(Guid.Empty);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13) return;
            if (control.Name == "txtkh")
                txtkh.Text = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, InstanceForm.BDatabase);
            butcx_Click(sender, null);
        }

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetJhkJl(Guid brxxid)
        {
            string ssql = "select '' 序号,b.brxm 姓名,ykh 原卡号,xkh 现卡号,(case when yj=0 then '' else cast(yj as varchar(20)) end) 押金,hksj 还卡时间,dbo.fun_getempname(hkdjy) 操作员," +
                " a.djsj 登记时间,dbo.fun_getempname(a.djy) 登记员,(case when lx=1 then '借临时卡 '+bz else '换新卡 '+bz end)  备注,b.brxxid,jhkid,lx  " +
                " from YY_JHK a inner join YY_BRXX b on a.brxxid=b.brxxid  where a.brxxid is not null ";
            if (brxxid != Guid.Empty && brxxid != null)
                ssql = ssql + " and a.brxxid='" + brxxid + "'";
            else
                ssql = ssql + " and lx=1 and (hksj is null or hkdjy=0 )";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            Fun.AddRowtNo(tb);
            this.dataGridView1.DataSource = tb;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void 换新卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Jhk(0);
                butcx_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Jhk(int lx)
        {
            DataTable tb = (DataTable)this.dataGridView2.DataSource;
            if (this.dataGridView2.CurrentCell == null) return;
            int nrow = this.dataGridView2.CurrentCell.RowIndex;

            Guid brxxid = new Guid(Convertor.IsNull(tb.Rows[nrow]["brxxid"], Guid.Empty.ToString()));
            Guid kdjid = new Guid(Convertor.IsNull(tb.Rows[nrow]["kdjid"], Guid.Empty.ToString()));

            //实例化老卡
            ReadCard oldCard = new ReadCard(kdjid, InstanceForm.BDatabase);
            //Add By Zj 2013-01-10 不允许多次临时借卡 尤其是临时卡 再借临时卡
            string ssql = "select * from YY_jhk where XKH='" + oldCard.kh + "' and hksj is null and hkdjy=0 and lx=1" ; //add by wangzhi 2015-03-02,增加 lx=1的查询条件
            DataTable oldtb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (oldtb.Rows.Count > 0)
            {
                MessageBox.Show("卡号:" + oldCard.kh + " 属于临时借卡,请先还卡 才能借卡!");
                return;
            }
            Frmjhkqr f = new Frmjhkqr();
            if (oldCard.kdjid != Guid.Empty)
            {
                f.cmbklx.SelectedValue = oldCard.klx.ToString();
                f.cmbklx.Enabled = false;
            }
            f.lblykh.Text = tb.Rows[nrow]["卡号"].ToString();
            f.lblxm.Text = tb.Rows[nrow]["姓名"].ToString();
            f.lblxb.Text = tb.Rows[nrow]["性别"].ToString();

            if (lx == 0)
            {
                f.txtyj.Enabled = false;
                f.Text = "老卡换新卡";
                f.lbltitle.Text = "更新新卡";
            }
            if (lx == 1)
            {
                f.txtyj.Enabled = true;
                f.Text = "临时借卡";
                f.lbltitle.Text = "临时借卡";
            }
            if (lx == 2)
            {
                f.txtyj.Enabled = false;
                f.Text = "办理新卡";
                f.lbltitle.Text = "办理新卡";
                f.lblykh.Text = "无卡";
            }
            f.ShowDialog();
            f.txtxkh.Focus();
            if (f.Bok == false) return;

            string Newkh = f.txtxkh.Text;
            string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            decimal yj = Convert.ToDecimal(Convertor.IsNull(f.txtyj.Text, "0"));
            int klx = Convert.ToInt32(Convertor.IsNull(f.cmbklx.SelectedValue, "0"));



            //实例化新卡，看卡是否存在
            ReadCard newCard = new ReadCard(klx, Newkh, InstanceForm.BDatabase);
            if (newCard.kdjid != Guid.Empty)
            {
                MessageBox.Show(Newkh + "这个卡号已被别他用户使用,请您确认", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //自动读射频卡
            string kxym = "";
            try
            {
                if (newCard.kdjid == Guid.Empty)
                {
                    string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                    if (ReadCard != null)
                    {
                        kxym = ReadCard.CreateKxym();
                        bool bok = ReadCard.WriterCard(Newkh, kxym, "", kxym);
                        if (bok == false)
                            throw new Exception("写卡没有成功");
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            Guid NewJhkId = Guid.Empty;
            Guid NewKdjid = Guid.Empty;
            int err_code = 0;
            string err_text = "";
            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                if (lx == 0 || lx == 1)
                {
                    mz_kdj.SaveJkh(Guid.Empty, TrasenFrame.Forms.FrmMdiMain.Jgbm, brxxid, tb.Rows[nrow]["姓名"].ToString(), klx, tb.Rows[nrow]["卡号"].ToString(), Newkh, djsj,
                        InstanceForm.BCurrentUser.EmployeeId, lx, yj, f.txtbz.Text.Trim(), out NewJhkId,
                        out err_code, out err_text, kxym, "", oldCard.kxym, oldCard.kxlh, InstanceForm.BDatabase);
                    if (NewJhkId == Guid.Empty || err_code != 0) throw new Exception(err_text);
                }
                else
                {
                    mz_kdj.Kdj(Guid.Empty, brxxid, klx, Newkh, tb.Rows[nrow]["姓名"].ToString(), 0, 0, 0, 0, djsj, InstanceForm.BCurrentUser.EmployeeId, "", kxym, "", out NewKdjid, out err_code, out err_text, Fun.GetNewGrzhbh(InstanceForm.BDatabase), _menuTag.Function_Name, InstanceForm.BDatabase);
                    if (NewKdjid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                }
                InstanceForm.BDatabase.CommitTransaction();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            MessageBox.Show("操作成功");
            GetJhkJl(brxxid);
        }

        private void 临时借卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Jhk(1);
                butcx_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {

                Jhk(2);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 当前病人借换卡历史ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView2.DataSource;
                if (this.dataGridView2.CurrentCell == null) return;
                int nrow = this.dataGridView2.CurrentCell.RowIndex;
                GetJhkJl(new Guid(tb.Rows[nrow]["brxxid"].ToString()));
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgv in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(Convertor.IsNull(dgv.Cells["lx"].Value, "0")) == 0 || Convertor.IsNull(dgv.Cells["还卡时间"].Value, "") != "")
                    {
                        dgv.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        dgv.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }


            }
            catch (System.Exception err)
            {
            }
        }

        private void 病人还临时卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (this.dataGridView1.CurrentCell == null) return;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;

                int lx = Convert.ToInt32(tb.Rows[nrow]["lx"]);
                Guid jhkid = new Guid(tb.Rows[nrow]["jhkid"].ToString());
                Guid Brxxid = new Guid(tb.Rows[nrow]["brxxid"].ToString());
                string yj = Convert.ToString(tb.Rows[nrow]["押金"]);
                if (lx == 0)
                {
                    MessageBox.Show("只有借临时卡才需要还卡", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ss = "";
                if (yj != "") ss = "该病人有押金 " + yj.ToString() + " 元,";
                if (MessageBox.Show(this, ss + "您确定还卡吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    int err_code = -1;
                    string err_text = "";
                    mz_kdj.SaveJkh_HK(Brxxid, jhkid, InstanceForm.BCurrentUser.EmployeeId, out err_code, out err_text, InstanceForm.BDatabase);
                    if (err_code != 0) throw new Exception(err_text);
                    InstanceForm.BDatabase.CommitTransaction();
                    MessageBox.Show("还卡成功");
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                GetJhkJl(Guid.Empty);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 显示全部借卡未还记录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;
                GetJhkJl(Guid.Empty);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb == null) return;
            if (this.dataGridView1.CurrentCell == null) return;
            int nrow = this.dataGridView1.CurrentCell.RowIndex;

            if (tb.Rows.Count == 0 || dataGridView1.CurrentCell == null)
            {
                病人还临时卡ToolStripMenuItem.Enabled = false;
                return;
            }

            if (tb.Rows[this.dataGridView1.CurrentCell.RowIndex]["还卡时间"].ToString().Trim() != "" || tb.Rows[this.dataGridView1.CurrentCell.RowIndex]["lx"].ToString().Trim() == "0")
            {
                病人还临时卡ToolStripMenuItem.Enabled = false;
            }
            else
                病人还临时卡ToolStripMenuItem.Enabled = true;

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            DataTable tb = (DataTable)dataGridView2.DataSource;
            if (tb == null) return;
            if (tb.Rows.Count == 0 || dataGridView2.CurrentCell == null)
            {
                换新卡ToolStripMenuItem.Enabled = false;
                临时借卡ToolStripMenuItem.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                return;
            }
            int nrow = this.dataGridView2.CurrentCell.RowIndex;
            if (tb.Rows[nrow]["卡号"].ToString() == "")
            {
                换新卡ToolStripMenuItem.Enabled = false;
                临时借卡ToolStripMenuItem.Enabled = false;
                toolStripMenuItem2.Enabled = true;
            }
            if (tb.Rows[nrow]["卡号"].ToString() != "")
            {
                换新卡ToolStripMenuItem.Enabled = true;
                临时借卡ToolStripMenuItem.Enabled = true;
                toolStripMenuItem2.Enabled = false;
            }


            toolStripMenuItem3.Enabled = true;
            取消挂失ToolStripMenuItem.Enabled = false;
            卡锁定ToolStripMenuItem.Enabled = true;
            解除冻结ToolStripMenuItem.Enabled = false;
            toolStripMenuItem6.Enabled = true;
            toolStripMenuItem7.Enabled = false;

            if (rdDJ.Checked == true)
            {
                toolStripMenuItem3.Enabled = true;
                取消挂失ToolStripMenuItem.Enabled = false;
                卡锁定ToolStripMenuItem.Enabled = false;
                解除冻结ToolStripMenuItem.Enabled = true;
                toolStripMenuItem6.Enabled = true;
                toolStripMenuItem7.Enabled = false;
            }
            if (rdGS.Checked == true)
            {
                toolStripMenuItem3.Enabled = false;
                取消挂失ToolStripMenuItem.Enabled = true;
                卡锁定ToolStripMenuItem.Enabled = true;
                解除冻结ToolStripMenuItem.Enabled = false;
                toolStripMenuItem6.Enabled = true;
                toolStripMenuItem7.Enabled = false;
            }
            if (rdozf.Checked == true)
            {
                toolStripMenuItem3.Enabled = true;
                取消挂失ToolStripMenuItem.Enabled = false;
                卡锁定ToolStripMenuItem.Enabled = true;
                解除冻结ToolStripMenuItem.Enabled = false;
                toolStripMenuItem6.Enabled = false;
                toolStripMenuItem7.Enabled = true;
            }
            if (dataGridView2.CurrentRow.Cells["COL_KZT"].Value.ToString() == "作废")
            {
                toolStripMenuItem3.Enabled = false;
                取消挂失ToolStripMenuItem.Enabled = false;
                卡锁定ToolStripMenuItem.Enabled = false;
                解除冻结ToolStripMenuItem.Enabled = false;
                toolStripMenuItem6.Enabled = false;
                换新卡ToolStripMenuItem.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                临时借卡ToolStripMenuItem.Enabled = false;
            }
            if (dataGridView2.CurrentRow.Cells["COL_KZT"].Value.ToString() == "挂失")
            {

                toolStripMenuItem3.Enabled = false;
                取消挂失ToolStripMenuItem.Enabled = true;
                toolStripMenuItem2.Enabled = true;
            }
            if (dataGridView2.CurrentRow.Cells["COL_KZT"].Value.ToString() == "冻结")
            {
                卡锁定ToolStripMenuItem.Enabled = false;
                解除冻结ToolStripMenuItem.Enabled = true;
            }
        }

        private void 卡挂失ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
                return;
            if (dataGridView2.CurrentCell == null)
                return;

            Guid _kdjid = new Guid(dataGridView2[kdjid.Name, dataGridView2.CurrentCell.RowIndex].Value.ToString());
            DataRow drKxx = InstanceForm.BDatabase.GetDataRow("select * from yy_kdjb where kdjid='" + _kdjid.ToString() + "'");

            if (MessageBox.Show("确定要将该卡挂失吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            ts_mz_class.FrmPassWord fPassword = new FrmPassWord(InstanceForm._menuTag, "挂失密码验证", this, InstanceForm.BDatabase);
            //Add By Zj 2012-03-28 给密码框赋值
            fPassword.Kdjid = _kdjid;
            if (fPassword.ShowDialog() == DialogResult.OK)
            {
                FrmMdiMain.Database.BeginTransaction();
                try
                {
                    string sql = "update yy_kdjb set sdbz=2,zfbz=0 where kdjid='" + _kdjid.ToString() + "'";
                    int ret = InstanceForm.BDatabase.DoCommand(sql);
                    if (ret > 0)
                    {
                        string Contents = "卡号：" + drKxx["KH"].ToString().Trim() + ",卡登记ID：" + drKxx["KDJID"].ToString().Trim();
                        long OperatorID = FrmMdiMain.CurrentUser.EmployeeId;
                        string OperatorType = "卡挂失";
                        int ModuleID = FrmMdiMain.CurrentSystem.SystemId;
                        int ErrLevel = 0;
                        string WorkStation = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
                        int deptId = FrmMdiMain.CurrentDept.DeptId;

                        TrasenFrame.Classes.SystemLog log = new SystemLog(0, deptId, OperatorID, OperatorType, Contents, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database)
                        , ErrLevel, WorkStation, ModuleID);
                        log.Save();

                        #region 打印小票 add by pgj 20150120
                        object isPrint = InstanceForm.BDatabase.GetDataResult("select config from jc_config where id=1162");
                        if (isPrint != null)
                        {
                            if (Convert.ToInt32(isPrint) == 1)
                            {
                                Print(drKxx["KDJID"].ToString().Trim(), "卡挂失");
                            }
                        }
                        #endregion
                        FrmMdiMain.Database.CommitTransaction();
                        MessageBox.Show("卡挂失处理完成！");
                    }
                    else
                    {
                        throw new Exception("没有更新到数据");
                    }
                }
                catch (Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            butcx_Click(sender, e);

        }

        private void 卡锁定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
                return;
            if (dataGridView2.CurrentCell == null)
                return;

            Guid _kdjid = new Guid(dataGridView2[kdjid.Name, dataGridView2.CurrentCell.RowIndex].Value.ToString());
            DataRow drKxx = InstanceForm.BDatabase.GetDataRow("select * from yy_kdjb where kdjid='" + _kdjid.ToString() + "'");

            if (MessageBox.Show("确定要将该卡冻结吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (TrasenFrame.Classes.WorkStaticFun.CheckCurrentUserPassword() == true)
            {
                FrmMdiMain.Database.BeginTransaction();
                try
                {
                    string sql = "update yy_kdjb set sdbz=1,zfbz=0 where kdjid='" + _kdjid.ToString() + "'";
                    int ret = InstanceForm.BDatabase.DoCommand(sql);
                    if (ret == 0)
                        throw new Exception("");

                    string Contents = "卡号：" + drKxx["KH"].ToString().Trim() + ",卡登记ID：" + drKxx["KDJID"].ToString().Trim();
                    long OperatorID = FrmMdiMain.CurrentUser.EmployeeId;
                    string OperatorType = "卡冻结";
                    int ModuleID = FrmMdiMain.CurrentSystem.SystemId;
                    int ErrLevel = 0;
                    string WorkStation = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
                    int deptId = FrmMdiMain.CurrentDept.DeptId;

                    TrasenFrame.Classes.SystemLog log = new SystemLog(0, deptId, OperatorID, OperatorType, Contents, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database)
                        , ErrLevel, WorkStation, ModuleID);
                    log.Save();

                    #region 打印小票 add by pgj 20150120
                    object isPrint = InstanceForm.BDatabase.GetDataResult("select config from jc_config where id=1162");
                    if (isPrint != null)
                    {
                        if (Convert.ToInt32(isPrint) == 1)
                        {
                            Print(drKxx["KDJID"].ToString().Trim(), "卡冻结");
                        }
                    }
                    #endregion
                    FrmMdiMain.Database.CommitTransaction();
                    MessageBox.Show("卡冻结成功！");
                }
                catch (Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            butcx_Click(sender, e);
        }

        private void chkcsrq_CheckedChanged(object sender, EventArgs e)
        {
            dtpcsrq.Enabled = chkcsrq.Checked;
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
                return;
            if (dataGridView2.CurrentCell == null)
                return;

            //int sdbz = Convert.ToInt32( dataGridView2[COL_SDBZ.Name , dataGridView2.CurrentCell.RowIndex].Value );
            //this.toolStripMenuItem3.Visible = false;
            //this.卡锁定ToolStripMenuItem.Visible = false;
            //this.解除冻结ToolStripMenuItem.Visible = false;
            //this.取消挂失ToolStripMenuItem.Visible = false;
            //if ( sdbz == 1 )
            //{
            //    this.解除冻结ToolStripMenuItem.Visible = true;
            //}
            //else if ( sdbz == 2 )
            //{
            //    this.取消挂失ToolStripMenuItem.Visible = true;
            //}
            //else
            //{
            //    this.toolStripMenuItem3.Visible = true;
            //    this.卡锁定ToolStripMenuItem.Visible = true;
            //}
        }

        private void 取消挂失ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
                return;
            if (dataGridView2.CurrentCell == null)
                return;

            Guid _kdjid = new Guid(dataGridView2[kdjid.Name, dataGridView2.CurrentCell.RowIndex].Value.ToString());
            DataRow drKxx = InstanceForm.BDatabase.GetDataRow("select * from yy_kdjb where kdjid='" + _kdjid.ToString() + "'");

            if (MessageBox.Show("确定要将该卡取消挂失吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ts_mz_class.FrmPassWord fPassword = new FrmPassWord(InstanceForm._menuTag, "取消挂失密码验证", this, InstanceForm.BDatabase);
            //Add By Zj 2012-04-18 给密码框赋值
            fPassword.Kdjid = _kdjid;
            if (fPassword.ShowDialog() == DialogResult.OK)
            {
                FrmMdiMain.Database.BeginTransaction();
                try
                {
                    string sql = "update yy_kdjb set sdbz=0,zfbz=0 where kdjid='" + _kdjid.ToString() + "'";
                    int ret = InstanceForm.BDatabase.DoCommand(sql);
                    if (ret > 0)
                    {
                        string Contents = "卡号：" + drKxx["KH"].ToString().Trim() + ",卡登记ID：" + drKxx["KDJID"].ToString().Trim();
                        long OperatorID = FrmMdiMain.CurrentUser.EmployeeId;
                        string OperatorType = "卡取消挂失";
                        int ModuleID = FrmMdiMain.CurrentSystem.SystemId;
                        int ErrLevel = 0;
                        string WorkStation = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
                        int deptId = FrmMdiMain.CurrentDept.DeptId;

                        TrasenFrame.Classes.SystemLog log = new SystemLog(0, deptId, OperatorID, OperatorType, Contents, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database)
                        , ErrLevel, WorkStation, ModuleID);
                        log.Save();
                        FrmMdiMain.Database.CommitTransaction();
                        MessageBox.Show("卡挂取消失处理完成！");
                    }
                    else
                    {
                        throw new Exception("没有更新到数据");
                    }
                }
                catch (Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            butcx_Click(sender, e);
        }

        private void 解除冻结ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
                return;
            if (dataGridView2.CurrentCell == null)
                return;

            Guid _kdjid = new Guid(dataGridView2[kdjid.Name, dataGridView2.CurrentCell.RowIndex].Value.ToString());
            DataRow drKxx = InstanceForm.BDatabase.GetDataRow("select * from yy_kdjb where kdjid='" + _kdjid.ToString() + "'");

            if (MessageBox.Show("确定要将该卡取消冻结吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (TrasenFrame.Classes.WorkStaticFun.CheckCurrentUserPassword() == true)
            {
                FrmMdiMain.Database.BeginTransaction();
                try
                {
                    string sql = "update yy_kdjb set sdbz=0,zfbz=0 where kdjid='" + _kdjid.ToString() + "'";
                    int ret = InstanceForm.BDatabase.DoCommand(sql);
                    if (ret == 0)
                        throw new Exception("没有更新到记录");

                    string Contents = "卡号：" + drKxx["KH"].ToString().Trim() + ",卡登记ID：" + drKxx["KDJID"].ToString().Trim();
                    long OperatorID = FrmMdiMain.CurrentUser.EmployeeId;
                    string OperatorType = "卡取消冻结";
                    int ModuleID = FrmMdiMain.CurrentSystem.SystemId;
                    int ErrLevel = 0;
                    string WorkStation = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
                    int deptId = FrmMdiMain.CurrentDept.DeptId;

                    TrasenFrame.Classes.SystemLog log = new SystemLog(0, deptId, OperatorID, OperatorType, Contents, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database)
                        , ErrLevel, WorkStation, ModuleID);
                    log.Save();
                    FrmMdiMain.Database.CommitTransaction();
                    MessageBox.Show("卡取消冻结成功！");
                }
                catch (Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            butcx_Click(sender, e);
        }

        //作废卡
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
                return;
            if (dataGridView2.CurrentCell == null)
                return;

            Guid _kdjid = new Guid(Convertor.IsNull(dataGridView2[kdjid.Name, dataGridView2.CurrentCell.RowIndex].Value.ToString(), Guid.Empty.ToString()));
            if (_kdjid == Guid.Empty) return;
            DataRow drKxx = InstanceForm.BDatabase.GetDataRow("select * from yy_kdjb where kdjid='" + _kdjid.ToString() + "'");

            if (Convert.ToDecimal(drKxx["kye"]) != 0)
            {
                MessageBox.Show("这张卡还有余额,您不能作废", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("确定要 [作废] 这张卡吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            //150302 chencan add 1167卡作废时是否验证操作员身份,1是0否
            if (new SystemCfg(1167).Config == "1" && TrasenFrame.Classes.WorkStaticFun.CheckCurrentUserPassword() == false)
                return;

            string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            string tfje = "0";
            int sfxmid = Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select sfxmid from jc_klx where klx=" + drKxx["klx"]), "0"));
            DataTable cfmxtb = new DataTable();
            if (_menuTag.Function_Name == "Fun_ts_mz_kgl_jhk_tf")
            {
                cfmxtb = InstanceForm.BDatabase.GetDataTable("select * from JC_HSITEM where delete_bit=0 and item_id=" + sfxmid.ToString());
                if (cfmxtb.Rows.Count != 1)
                {
                    MessageBox.Show("收费项目错误,卡费用关联ID不止1个或者为空。", "提示");
                    return;
                }
                tfje = drKxx["bkje"].ToString();
                string Msg = "本次退费信息\n           退办卡金额:" + tfje + " 元 ";
                ts_mz_class.Frmtf f = new ts_mz_class.Frmtf(_menuTag, _chineseName, _mdiParent);
                f.lblbz.Text = Msg;
                f.ShowDialog();

                if (f.Bok == false)
                {
                    return;
                }
            }
            FrmMdiMain.Database.BeginTransaction();
            try
            {
                //Add By Zj 2012-12-26 产生退费记录
                if (_menuTag.Function_Name == "Fun_ts_mz_kgl_jhk_tf")
                {
                    #region
                    string ghsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                    Guid NewGhxxid = Guid.Empty;
                    int err_code = -1;
                    string err_text = "";
                    Guid brxxid = new Guid(Convertor.IsNull(drKxx["brxxid"], Guid.Empty.ToString()));
                    int ghlx = 1;
                    string mzh = Fun.GetNewMzh(InstanceForm.BDatabase);
                    int ghks = 0;
                    int ghys = 0;
                    int ghjb = 0;
                    string _ghck = "";
                    int _pdxh = 0;//排队序号
                    long Jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                    long _dnlsh = Convert.ToInt64(Fun.GetNewDnlsh(InstanceForm.BDatabase));
                    //挂号登记
                    mz_ghxx.GhxxDj(Guid.Empty, brxxid, ghlx, _kdjid, mzh, ghks, ghys, ghjb, 0, InstanceForm.BCurrentUser.EmployeeId, 1, _ghck, ref _pdxh, _dnlsh, "0", Jgbm, out NewGhxxid, out err_code, out err_text, 0, 0, 0, "", "", "", 0, "", "", ghsj, InstanceForm.BDatabase);
                    if (NewGhxxid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                    //产生退费处方
                    Guid NewCfid = Guid.Empty;
                    mz_cf.SaveCf(Guid.Empty, brxxid, NewGhxxid, mzh, _ghck, (-1) * Convert.ToDecimal(tfje), ghsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, _ghck, Guid.Empty, 0,
                                "", 0, "", 0, 0, "", 2, 0, 2, 0, (-1) * 1, Jgbm, out NewCfid, out err_code, out err_text, InstanceForm.BDatabase);
                    if (err_code != 0) throw new Exception(err_text);
                    //修改处方收费状态
                    int Nrows = 0;
                    mz_cf.UpdateCfsfzt(NewCfid, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, ghsj, "", _dnlsh, "0", out Nrows, out err_code, out err_text, InstanceForm.BDatabase);
                    if (Nrows != 1) throw new Exception("在更新退费处方的收费状态时,没有更新到处方头表,请和管理员联系");

                    string _pym = Convertor.IsNull(cfmxtb.Rows[0]["py_code"], "");
                    string _bm = "";
                    string _pm = Convertor.IsNull(cfmxtb.Rows[0]["item_name"], "");
                    string _spm = Convertor.IsNull(cfmxtb.Rows[0]["item_name"], "");
                    string _gg = "";
                    string _cj = "";
                    decimal _dj = Convert.ToDecimal(Convertor.IsNull(cfmxtb.Rows[0]["RETAIL_PRICE"], "0"));
                    decimal _sl = 1;
                    string _tjdxmdm = Convertor.IsNull(cfmxtb.Rows[0]["statitem_code"], "");
                    string _dw = Convertor.IsNull(cfmxtb.Rows[0]["item_unit"], "");
                    Guid _NewCfmxid = Guid.Empty;
                    //产生退费明细
                    mz_cf.SaveCfmx(Guid.Empty, NewCfid, _pym, _bm, _pm, _spm, _gg, _cj, _dj, (-1) * _sl, _dw, 0, 1, (-1) * Convert.ToDecimal(tfje), _tjdxmdm, sfxmid, Guid.Empty, _bm, 0, 0,
                                Guid.Empty, 0, "", "", 0, 0, "", 0, 0, Guid.Empty, 0, 0, 0, out _NewCfmxid, out err_code, out err_text, InstanceForm.BDatabase);
                    if ((_NewCfmxid == Guid.Empty) || err_code != 0) throw new Exception(err_text);
                    //保存收银信息
                    Guid NewJsid = Guid.Empty;
                    mz_sf.SaveJs(Guid.Empty, brxxid, NewGhxxid, ghsj, InstanceForm.BCurrentUser.EmployeeId, (-1) * (Convert.ToDecimal(tfje)), 0, 0, 0, 0, 0, 0, 0, (-1) * (Convert.ToDecimal(tfje)), 0, 0, 0, 0, 1, 1, TrasenFrame.Forms.FrmMdiMain.Jgbm, out NewJsid, out err_code, out err_text, InstanceForm.BDatabase);
                    if (NewJsid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                    //作废原发票
                    Guid NewFpid = Guid.Empty;
                    mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, dataGridView2.CurrentRow.Cells["name"].Value.ToString(), ghsj, InstanceForm.BCurrentUser.EmployeeId, "", _dnlsh, "0",
                        (-1) * Convert.ToDecimal(tfje), 0, 0, 0, 0, 0,
                        0, 0, (-1) * Convert.ToDecimal(tfje), 0, 0, Guid.Empty, "", NewJsid, 2, 0, 0, 0, 0,
                       0, "", 2, _kdjid, Jgbm, Guid.Empty, "", out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                    if (NewFpid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                    //产生发票明细退费
                    mz_sf.SaveFpmx(NewFpid, _tjdxmdm, "退诊疗卡费", (-1) * Convert.ToDecimal(tfje), 0, out err_code, out err_text, InstanceForm.BDatabase);
                    if (err_code != 0) throw new Exception(err_text);
                    //产生发票大项目退费
                    mz_sf.SaveFpdxmmx(NewFpid, _tjdxmdm, "退诊疗卡费", (-1) * Convert.ToDecimal(tfje), 0, out err_code, out err_text, InstanceForm.BDatabase);
                    if (err_code != 0) throw new Exception(err_text);
                    //取消挂号 并且修改发票

                    int i = InstanceForm.BDatabase.DoCommand("update mz_ghxx set byhbz=0,bqxghbz=1,qxghsj='" + ghsj + "',qxghczy=" + InstanceForm.BCurrentUser.EmployeeId + " where ghxxid='" + NewGhxxid + "' and bqxghbz=0 ");
                    if (i != 1) throw new Exception("执行 DelRegisterRecord 方法时出错");

                    i = InstanceForm.BDatabase.DoCommand("update mz_fpb set bghpbz=2 where ghxxid='" + NewGhxxid + "'  and bghpbz=2 ");
                    if (i != 1) throw new Exception("执行 DelRegisterRecord 方法时出错");
                    #endregion
                }
                string sql = "update yy_kdjb set sdbz=0,zfbz=1,zfsj='" + djsj + "',zfdjy=" + InstanceForm.BCurrentUser.EmployeeId + " where kdjid='" + _kdjid.ToString() + "' and kye=0 ";
                int ret = InstanceForm.BDatabase.DoCommand(sql);
                if (ret == 0)
                    throw new Exception("没有更新到和行");

                sql = "update yy_brxx set bscbz=1 where brxxid='" + drKxx["brxxid"].ToString() + "'";
                ret = InstanceForm.BDatabase.DoCommand(sql);
                if (ret == 0)
                    throw new Exception("没有更新到和行");

                string Contents = "卡号：" + drKxx["KH"].ToString().Trim() + ",卡登记ID：" + drKxx["KDJID"].ToString().Trim();
                long OperatorID = FrmMdiMain.CurrentUser.EmployeeId;
                string OperatorType = "作废卡";
                int ModuleID = FrmMdiMain.CurrentSystem.SystemId;
                int ErrLevel = 0;
                string WorkStation = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
                int deptId = FrmMdiMain.CurrentDept.DeptId;

                TrasenFrame.Classes.SystemLog log = new SystemLog(0, deptId, OperatorID, OperatorType, Contents, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database)
                    , ErrLevel, WorkStation, ModuleID);
                log.Save();
                #region 打印小票 add by pgj 20150120
                object isPrint = InstanceForm.BDatabase.GetDataResult("select config from jc_config where id=1162");
                if (isPrint != null)
                {
                    if (Convert.ToInt32(isPrint) == 1)
                    {
                        Print(drKxx["KDJID"].ToString().Trim(), "卡作废");
                    }
                }
                #endregion
                FrmMdiMain.Database.CommitTransaction();


                MessageBox.Show("卡作废成功！");
            }
            catch (Exception err)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            butcx_Click(sender, e);
        }

        //打印小票 add by pgj 20150120
        /// <summary>
        /// 打印小票
        /// </summary>
        /// <param name="kdjid"></param>
        /// <param name="action"></param>
        private void Print(string kdjid,string action)
        {
            string rptURL = "";
           
            ParameterEx[] parameters = null;
            try
            {
                string operateName = InstanceForm.BDatabase.GetDataResult("select Name from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + InstanceForm.BCurrentUser.EmployeeId).ToString();

                String sqll = "select a.*,b.Name ZFDJY,c.XB,c.BRLXFS DH,c.SFZH  from yy_KDJB a left join JC_EMPLOYEE_PROPERTY b on a.zfdjy=b.EMPloyee_ID left join yy_brxx c on a.brxxid=c.brxxid  where kdjid='" + kdjid + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(sqll);
                if (tb.Rows.Count != 0)
                {
                    DataSet1 Dset = new DataSet1();
                    DataRow myrow;

                    if (action == "卡作废")
                    {
                        myrow = Dset.作废卡.NewRow();

                        myrow["kh"] = tb.Rows[0]["KH"].ToString().Trim();
                        myrow["CKRXM"] = tb.Rows[0]["CKRXM"].ToString().Trim();
                        myrow["XB"] = tb.Rows[0]["XB"].ToString().Trim();
                        myrow["DH"] = tb.Rows[0]["DH"].ToString().Trim();
                        myrow["SFZH"] = tb.Rows[0]["SFZH"].ToString().Trim();
                        myrow["BKJE"] = tb.Rows[0]["BKJE"].ToString().Trim();
                        myrow["ZFDJY"] = tb.Rows[0]["ZFDJY"].ToString().Trim();
                        myrow["ZFSJ"] = tb.Rows[0]["ZFSJ"].ToString().Trim();
                        Dset.作废卡.Rows.Add(myrow);

                        parameters = new ParameterEx[1];
                        parameters[0].Text = "医院名称";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "作废卡凭证";

                        rptURL = Constant.ApplicationDirectory + "\\Report\\作废卡.rpt";
                    }
                    else if (action == "卡冻结")
                    {
                        myrow = Dset.冻结卡.NewRow();

                        myrow["KH"] = tb.Rows[0]["KH"].ToString().Trim();
                        myrow["CKRXM"] = tb.Rows[0]["CKRXM"].ToString().Trim();
                        myrow["XB"] = tb.Rows[0]["XB"].ToString().Trim();
                        myrow["DH"] = tb.Rows[0]["DH"].ToString().Trim();
                        myrow["SFZH"] = tb.Rows[0]["SFZH"].ToString().Trim();
                        myrow["KYE"] = tb.Rows[0]["KYE"].ToString().Trim();
                        myrow["DJDJY"] = operateName;
                        myrow["DJSJ"] = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                        Dset.冻结卡.Rows.Add(myrow);

                        parameters = new ParameterEx[1];
                        parameters[0].Text = "医院名称";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "冻结卡凭证";

                         rptURL = Constant.ApplicationDirectory + "\\Report\\冻结卡.rpt";
                     }
                     else if (action == "卡挂失")
                     {
                         myrow = Dset.挂失卡.NewRow();

                         myrow["KH"] = tb.Rows[0]["KH"].ToString().Trim();
                         myrow["CKRXM"] = tb.Rows[0]["CKRXM"].ToString().Trim();
                         myrow["XB"] = tb.Rows[0]["XB"].ToString().Trim();
                         myrow["DH"] = tb.Rows[0]["DH"].ToString().Trim();
                         myrow["SFZH"] = tb.Rows[0]["SFZH"].ToString().Trim();
                         myrow["KYE"] = tb.Rows[0]["KYE"].ToString().Trim();
                         myrow["GSDJY"] = operateName;
                         myrow["GSSJ"] = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                         Dset.挂失卡.Rows.Add(myrow);

                         parameters = new ParameterEx[1];
                         parameters[0].Text = "医院名称";
                         parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "挂失卡凭证";

                         rptURL = Constant.ApplicationDirectory + "\\Report\\挂失卡.rpt";
                     }

                    TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, rptURL, parameters);

                    string Bview = ApiFunction.GetIniString("划价收费", "发票预览", Constant.ApplicationDirectory + "//ClientWindow.ini");

                    if (Bview == "true")
                    {
                        if (f.LoadReportSuccess)
                            f.Show();
                        else
                            f.Dispose();
                    }
                    else
                    {
                        f = new TrasenFrame.Forms.FrmReportView(Dset, rptURL, parameters, true);
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //取消作废 Modify By zp 2013-11-14 如果办卡金额不为0 则需要收取办卡金额
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
                return;
            if (dataGridView2.CurrentCell == null)
                return;

            Guid _kdjid = new Guid(dataGridView2[kdjid.Name, dataGridView2.CurrentCell.RowIndex].Value.ToString());
            DataRow drKxx = InstanceForm.BDatabase.GetDataRow("select * from yy_kdjb where kdjid='" + _kdjid.ToString() + "'");
            DataTable cfmxtb = new DataTable();
            int sfxmid = 0;

            if (_menuTag.Function_Name == "Fun_ts_mz_kgl_jhk_tf")
            {
                sfxmid = Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select sfxmid from jc_klx where klx=" + drKxx["klx"]), "0"));
                cfmxtb = InstanceForm.BDatabase.GetDataTable("select * from JC_HSITEM where delete_bit=0 and item_id=" + sfxmid.ToString());
                if (cfmxtb.Rows.Count != 1)
                {
                    MessageBox.Show("收费项目错误,卡费用关联ID不止1个或者为空。", "提示");
                    return;
                }
         
                string Msg = "重新启用这张作废卡需要收取卡押金：" + Convert.ToDecimal(cfmxtb.Rows[0]["RETAIL_PRICE"]).ToString() + "元，确定要 [重新启用] 这张作废的卡吗?";
                ts_mz_class.Frmtf f = new ts_mz_class.Frmtf(_menuTag, _chineseName, _mdiParent);
                f.lblbz.Text = Msg;
                f.ShowDialog();

                if (f.Bok == false)
                    return;
            }
            else
            {
                if (MessageBox.Show("确定要 [重新启用] 这张作废的卡吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (TrasenFrame.Classes.WorkStaticFun.CheckCurrentUserPassword() == true)
            {
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                string bkje = "0";
                FrmMdiMain.Database.BeginTransaction();
                try
                {
                    #region//Add by zp 2013-11-14 作废时候把办卡金额退给病人,启用卡后却没有收取办卡金额
                    if (_menuTag.Function_Name == "Fun_ts_mz_kgl_jhk_tf")
                    {
                        #region
                        bkje = drKxx["bkje"].ToString();
                        string ghsj = djsj;
                        Guid NewGhxxid = Guid.Empty;
                        int err_code = -1;
                        string err_text = "";
                        Guid brxxid = new Guid(Convertor.IsNull(drKxx["brxxid"], Guid.Empty.ToString()));
                        int ghlx = 1;
                        string mzh = Fun.GetNewMzh(InstanceForm.BDatabase);
                        int ghks = 0;
                        int ghys = 0;
                        int ghjb = 0;
                        string _ghck = "";
                        int _pdxh = 0;//排队序号
                        long Jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                        long _dnlsh = Convert.ToInt64(Fun.GetNewDnlsh(InstanceForm.BDatabase));
                        int _zxksdm = Convert.ToInt32(_cfg1079.Config);
                        string _ksmc = _zxksdm != 0 ? Fun.SeekDeptName(_zxksdm, InstanceForm.BDatabase) : "";
                        //挂号登记
                        mz_ghxx.GhxxDj(Guid.Empty, brxxid, ghlx, _kdjid, mzh, ghks, ghys, ghjb, 0, InstanceForm.BCurrentUser.EmployeeId, 1, _ghck, ref _pdxh, _dnlsh, "0", Jgbm, out NewGhxxid, out err_code, out err_text, 0, 0, 0, "", "", "", 0, "", "", ghsj, InstanceForm.BDatabase);
                        if (NewGhxxid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                        //产生收费处方
                        Guid NewCfid = Guid.Empty;
                        mz_cf.SaveCf(Guid.Empty, brxxid, NewGhxxid, mzh, _ghck, Convert.ToDecimal(bkje), ghsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, _ghck, Guid.Empty, _zxksdm,
                                    _ksmc, 0, "", 0, _zxksdm, _ksmc, 2, 0, 2, 0, 1, Jgbm, out NewCfid, out err_code, out err_text, InstanceForm.BDatabase);
                        if (err_code != 0) throw new Exception(err_text);
            
                        //修改处方收费状态
                        int Nrows = 0;
                        mz_cf.UpdateCfsfzt(NewCfid, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, ghsj, "", _dnlsh, "0", out Nrows, out err_code, out err_text, InstanceForm.BDatabase);
                        if (Nrows != 1) throw new Exception("在更新处方的收费状态时,没有更新到处方头表,请和管理员联系");

                        string _pym = Convertor.IsNull(cfmxtb.Rows[0]["py_code"], "");
                        string _bm = "";
                        string _pm = Convertor.IsNull(cfmxtb.Rows[0]["item_name"], "");
                        string _spm = Convertor.IsNull(cfmxtb.Rows[0]["item_name"], "");
                        string _gg = "";
                        string _cj = "";
                        decimal _dj = Convert.ToDecimal(Convertor.IsNull(cfmxtb.Rows[0]["RETAIL_PRICE"], "0"));
                        decimal _sl = 1;
                        string _tjdxmdm = Convertor.IsNull(cfmxtb.Rows[0]["statitem_code"], "");
                        string _dw = Convertor.IsNull(cfmxtb.Rows[0]["item_unit"], "");
                       
                        Guid _NewCfmxid = Guid.Empty;
                        //产生处方明细
                        mz_cf.SaveCfmx(Guid.Empty, NewCfid, _pym, _bm, _pm, _spm, _gg, _cj, _dj, _sl, _dw, 0, 1, Convert.ToDecimal(bkje), _tjdxmdm, sfxmid, Guid.Empty, _bm, 0, 0,
                                    Guid.Empty, 0, "", "", 0, 0, "", 0, 0, Guid.Empty, 0, 0, 0, out _NewCfmxid, out err_code, out err_text, InstanceForm.BDatabase);
                        if ((_NewCfmxid == Guid.Empty) || err_code != 0) throw new Exception(err_text);
                        //保存收银信息
                        Guid NewJsid = Guid.Empty;
                        mz_sf.SaveJs(Guid.Empty, brxxid, NewGhxxid, ghsj, InstanceForm.BCurrentUser.EmployeeId, (Convert.ToDecimal(bkje)), 0, 0, 0, 0, 0, 0, 0, (Convert.ToDecimal(bkje)), 0, 0, 0, 0, 1, 0, TrasenFrame.Forms.FrmMdiMain.Jgbm, out NewJsid, out err_code, out err_text, InstanceForm.BDatabase);
                        if (NewJsid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                        //保存发票
                        Guid NewFpid = Guid.Empty;
                      
                        mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, dataGridView2.CurrentRow.Cells["name"].Value.ToString(), ghsj, InstanceForm.BCurrentUser.EmployeeId, "", _dnlsh, "0",
                            Convert.ToDecimal(bkje), 0, 0, 0, 0, 0, 0, 0, Convert.ToDecimal(bkje), 0, 0, Guid.Empty, "", NewJsid, 2, _zxksdm, 0, 0, _zxksdm, 0, "", 0, _kdjid, Jgbm, Guid.Empty, "", out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                        if (NewFpid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                        
                        //产生发票明细费
                        mz_sf.SaveFpmx(NewFpid, _tjdxmdm, _spm, Convert.ToDecimal(bkje), 0, out err_code, out err_text, InstanceForm.BDatabase);
                        if (err_code != 0) throw new Exception(err_text);
                        //产生发票大项目费
                        mz_sf.SaveFpdxmmx(NewFpid, _tjdxmdm, _spm, Convert.ToDecimal(bkje), 0, out err_code, out err_text, InstanceForm.BDatabase);
                        if (err_code != 0) throw new Exception(err_text);
                        //取消挂号 并且修改发票

                        int i = InstanceForm.BDatabase.DoCommand("update mz_ghxx set byhbz=0,bqxghbz=1,qxghsj='" + ghsj + "',qxghczy=" + InstanceForm.BCurrentUser.EmployeeId + " where ghxxid='" + NewGhxxid + "' and bqxghbz=0 ");
                        if (i != 1) throw new Exception("执行 DelRegisterRecord 方法时出错");

                        i = InstanceForm.BDatabase.DoCommand("update mz_fpb set bghpbz=2 where ghxxid='" + NewGhxxid + "'  and bghpbz=2 ");
                        if (i != 1) throw new Exception("执行 DelRegisterRecord 方法时出错");
                        #endregion
                    }
                    #endregion
                    string sql = "update yy_kdjb set sdbz=0,zfbz=0,zfsj=null,zfdjy=0 where klx=" + Convert.ToInt32(drKxx["klx"]) + "  and kh='" + Convertor.IsNull(drKxx["kh"], "") + "'   ";
                    int ret = InstanceForm.BDatabase.DoCommand(sql);
                    if (ret == 0)
                        throw new Exception("没有这张卡,请重新选择");
                    if (ret > 1)
                        throw new Exception("有" + ret.ToString() + "张卡号相同的有效卡存在,您不能重新启用");

                    sql = "update yy_brxx set bscbz=0 where brxxid='" + drKxx["brxxid"].ToString() + "'";
                    ret = InstanceForm.BDatabase.DoCommand(sql);
                    if (ret == 0)
                        throw new Exception("没有更新到和行");

                    string Contents = "卡号：" + drKxx["KH"].ToString().Trim() + ",卡登记ID：" + drKxx["KDJID"].ToString().Trim();
                    long OperatorID = FrmMdiMain.CurrentUser.EmployeeId;
                    string OperatorType = "重新启用作废卡";
                    int ModuleID = FrmMdiMain.CurrentSystem.SystemId;
                    int ErrLevel = 0;
                    string WorkStation = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
                    int deptId = FrmMdiMain.CurrentDept.DeptId;

                    TrasenFrame.Classes.SystemLog log = new SystemLog(0, deptId, OperatorID, OperatorType, Contents, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database)
                        , ErrLevel, WorkStation, ModuleID);
                    log.Save();
                    FrmMdiMain.Database.CommitTransaction();
                    MessageBox.Show("卡启用成功！");
                }
                catch (Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            butcx_Click(sender, e);
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView2.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["COL_KZT"].Value, "") == "作废")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Red;
                }
                if (Convertor.IsNull(dgv.Cells["COL_KZT"].Value, "") == "挂失")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.DimGray;
                }
                if (Convertor.IsNull(dgv.Cells["COL_KZT"].Value, "") == "冻结")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void Language_Off(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            control.ImeMode = ImeMode.KatakanaHalf;
            Fun.SetInputLanguageOff();

        }

        private void Language_On(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            control.ImeMode = ImeMode.KatakanaHalf;
            Fun.SetInputLanguageOn();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView2.DataSource == null)
                    return;
                if (dataGridView2.Rows.Count == 0)
                    return;

                this.Cursor = PubStaticFun.WaitCursor();
                this.btnExport.Enabled = false;
                ts_jc_log.ExcelOper.ExportData_ForDataTable(dataGridView2, "");

            }
            catch (System.Exception err)
            {

                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                this.btnExport.Enabled = true;
            }
        }


    }
}