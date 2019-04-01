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
using TrasenClasses.DatabaseAccess;

namespace ts_mz_kgl
{
    public delegate void OnAfterRechargeSuccessHanld();
    public partial class Frmbrkcz : Form
    {
        public event OnAfterRechargeSuccessHanld AfterRechargeSuccess;

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private Guid Kdjid = Guid.Empty;
        private Guid Brxxid = Guid.Empty;
        /// <summary>
        /// 卡余额退款是否需要验证密码 0 不需要 1需要 默认0
        /// </summary>
        SystemCfg cfg1059 = new SystemCfg(1059);
        /// <summary>
        /// 门诊卡冲值是否只能刷卡 0=否 1=是
        /// </summary>
        SystemCfg cfg1085 = new SystemCfg(1085);

        SystemCfg cfg1111 = new SystemCfg(1111);

        private string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
        private string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public Frmbrkcz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.WindowState = FormWindowState.Maximized;

            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
        }

        public Frmbrkcz(RelationalDatabase _DataBase, User _User, Department _BCurrentDept,int klx,string kh)
        {
            InstanceForm.BDatabase = _DataBase;

            InstanceForm.BCurrentUser = _User;

            InstanceForm.BCurrentDept = _BCurrentDept;

            InitializeComponent();

            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            this.cmbklx.SelectedValue = klx;

            cmbklx.SelectedValue = klx.ToString();

            if (kh != "")
            {
                txtkh.Text = kh;
                txtkh_KeyPress(null, null);
            }


        }


        private void Frmbrkdj_Load(object sender, EventArgs e)
        {

            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            SystemCfg cfg1113 = new SystemCfg(1113);

            string str="SELECT NAME,CODE FROM JC_FKFS";
            if (cfg1113.Config != "")
                str += " where code not in(" + cfg1113.Config + ")";

            //付款方式字典
            DataTable tb = InstanceForm.BDatabase.GetDataTable(str);
            if (tb == null)
            {
                MessageBox.Show("错误，未能取得付款方式！");
                return;
            }
            cmbfkfs.DisplayMember = "NAME";
            cmbfkfs.ValueMember = "CODE";
            cmbfkfs.DataSource = tb;
            tb = null;
            cmbfkfs.SelectedIndex = 0;

            //银行基本信息
            tb = InstanceForm.BDatabase.GetDataTable("SELECT NAME,ID FROM JC_BANK");
            if (tb == null)
            {
                MessageBox.Show("警告，未能取得银行信息！", "提示");
                return;
            }
            cmbyh.DisplayMember = "NAME";
            cmbyh.ValueMember = "ID";
            cmbyh.DataSource = tb;
            cmbyh.SelectedIndex = -1;
            tb = null;

            #region 报价器代码 Add By tck
            try
            {
                string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true")
                {
                    string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    call.SetPicture(InstanceForm.BCurrentUser.EmployeeId.ToString());  //(txtxm.Text.Trim());
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("报价器出现异常!原因:" + ea.Message, "提示");
            }
            #endregion

            if ( !txtkh.ReadOnly )
            {
                //自动读射频卡
                string sbxh = ApiFunction.GetIniString( "医院健康卡" , "设备型号" , Constant.ApplicationDirectory + "//ClientWindow.ini" );
                ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall( sbxh );
                if ( ReadCard != null )
                    ReadCard.AutoReadCard( _menuTag.Function_Name , cmbklx , txtkh );
            }
            //门诊预交金是否要打印发票 如果是，则获取预交金发票号
            if (cfg1111.Config.Trim() == "1")
                getYjjFph();
          
        }

        DataTable tbfp = null;

        private void getYjjFph()
        {
            //获取预交金发票号  ADD BY jiangzf 2014-2-25
            int err_code;
            string err_text;
            tbfp = Fun.GetFph(InstanceForm.BCurrentUser.EmployeeId, 1, 3, out err_code, out err_text, InstanceForm.BDatabase);
            if (tbfp.Rows.Count == 0 || err_code != 0)
            {
                MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblfph.Text = Convertor.IsNull(tbfp.Rows[0]["QZ"], "") + tbfp.Rows[0]["fph"].ToString().Trim(); 
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e != null)
            {
                if ((int)e.KeyChar != 13)
                {
                    if (cfg1085.Config.Trim() == "1")
                        e.Handled = true;
                    return;
                }
            }
            Kdjid = Guid.Empty;
            Brxxid = Guid.Empty;
            int klx = Convert.ToInt32(cmbklx.SelectedValue);
            txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase);
            txtkh.Text = ToDBC(txtkh.Text);
            string ssql = "select *,dbo.fun_zy_age(csrq,3,getdate()) 年龄,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别 from YY_KDJB a inner join YY_BRXX b  on a.brxxid=b.brxxid and  klx=" + klx + " and kh='" + txtkh.Text.Trim() + "' and zfbz=0";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0) { MessageBox.Show("没有找到卡信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            Kdjid = new Guid(tb.Rows[0]["kdjid"].ToString());
            Brxxid = new Guid(tb.Rows[0]["brxxid"].ToString());

            lblbrxm.Text = Convertor.IsNull(tb.Rows[0]["brxm"], "");
            lblxb.Text = Convertor.IsNull(tb.Rows[0]["性别"], "");
            lblnl.Text = Convertor.IsNull(tb.Rows[0]["年龄"], "");
            lbllxfs.Text = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
            lblgzdw.Text = Convertor.IsNull(tb.Rows[0]["gzdw"], "");
            lbldwdh.Text = Convertor.IsNull(tb.Rows[0]["gzdwdh"], "");
            lbljtdz.Text = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
            lblsfzh.Text = Convertor.IsNull(tb.Rows[0]["sfzh"], "");//Add By Zj 2012-05-28 身份证号
            if (lbllxfs.Text == "") lbllxfs.Text = Convertor.IsNull(tb.Rows[0]["jtdh"], "");
            if (lbllxfs.Text == "") lbllxfs.Text = Convertor.IsNull(tb.Rows[0]["gzdwdh"], "");
            Fill(Kdjid);
    
            if (bqybjq == "true" && bjqxh == "上海通导语音报价器型号Ⅳ")
            {
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.姓名, lblbrxm.Text);
            }
            else if (bqybjq == "true" && bjqxh == "上海通导语音报价器邵阳第一人民医院")
            {
                //ADD BY TCK 2013-11-21
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.姓名, lblbrxm.Text);
            }
            txtje.Focus();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            SystemCfg cfg1121 = new SystemCfg(1121);
            if (cfg1121.Config == "1")
            {
                int out_code = 0;
                string out_text = "";
                Fun.Isjz(InstanceForm.BCurrentUser.EmployeeId, out out_code, out out_text, InstanceForm.BDatabase);
                if (out_code == -1)
                {
                    MessageBox.Show(out_text);
                    return;
                }
            }
            mz_card card;
            try
            {
                if (cfg1111.Config.Trim() == "1" && lblfph.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("没有可用发票段,不能收费!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                if (Kdjid == Guid.Empty) { MessageBox.Show("请输入卡信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                //提示存入金额
                card = new mz_card(Convert.ToInt32(cmbklx.SelectedValue), InstanceForm.BDatabase);
                if (txtkh.Text.Length != card.kcd)
                {
                    MessageBox.Show("卡位数必须符合系统设定长度", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReadCard readcard = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text.Trim(), InstanceForm.BDatabase);
                if (readcard.kdjid != Kdjid)
                {
                    MessageBox.Show("效验卡信息时出错,请重新读卡", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (card.bjebz == false)
                {
                    MessageBox.Show("此卡不能存入金额,请参见卡类型设置", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (readcard.sdbz == 1)
                {
                    MessageBox.Show("病人卡已冻结，暂不能消费。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (readcard.sdbz == 2)
                {
                    MessageBox.Show("病人卡已挂失，暂不能消费。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (Convertor.IsNumeric(txtje.Text.Trim()) == false || txtje.Text.Trim() == "0")
            {
                MessageBox.Show("金额请输入正数的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtje.SelectAll();
                txtje.Focus();
                return;
            }

            decimal Crje = Convert.ToDecimal(Convertor.IsNull(txtje.Text, "0"));

            string ssql = "select * from YY_KDJB where kdjid='" + Kdjid + "'";
            DataTable tbk = InstanceForm.BDatabase.GetDataTable(ssql);
            if (Convert.ToDecimal(tbk.Rows[0]["kye"]) + Crje < 0)
            {
                MessageBox.Show("存入此笔金额后,卡余额将为负数。请重新输入金额", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Crje < 0)
            {
                if (MessageBox.Show("您确定要退款" + Crje.ToString() + "吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                //Add By Zj 2012-04-19 退款增加密码验证
                if (cfg1059.Config == "1")
                {
                    ts_mz_class.FrmPassWord fPassword = new FrmPassWord(InstanceForm._menuTag, "退款密码验证", this, InstanceForm.BDatabase);
                    fPassword.Kdjid = Kdjid;
                    if (fPassword.ShowDialog() != DialogResult.OK)
                        return;
                }
            }

            string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            Guid _kjeid = Guid.Empty;
            int err_code = -1;
            string err_text = "";
            int fkfs = Convert.ToInt32(cmbfkfs.SelectedValue);

            if (fkfs == 2)
            {
                if (txtzph.Text.Trim() == "") { MessageBox.Show("请输入支票号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (txtdw.Text.Trim() == "") { MessageBox.Show("请输入开户单位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (cmbyh.Text.Trim() == "") { MessageBox.Show("请输入开户银行", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }


            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                //登记交款
                mz_kdj.Kdj_je(Guid.Empty, Kdjid, Brxxid, fkfs, lblfph.Text, Crje, InstanceForm.BCurrentUser.EmployeeId, djsj, txtbz.Text.Trim(), txtzph.Text.Trim(), txtdw.Text.Trim(), cmbyh.Text.Trim(), out _kjeid, out err_code, out err_text, InstanceForm.BDatabase);
                if (_kjeid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                //到帐
                if (checkBox1.Checked == true)
                    mz_kdj.Kdj_je_zpdz(_kjeid, Kdjid, Brxxid, fkfs, Crje, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);

                //更新预交金发票领用表的当前发票号码
                string Msg = "";
                if (cfg1111.Config.Trim() == "1")
                    mz_sf.UpdateDqfph(new Guid(tbfp.Rows[0]["fpid"].ToString()), tbfp.Rows[0]["fph"].ToString().Trim(), tbfp.Rows[tbfp.Rows.Count - 1]["fph"].ToString().Trim(), out Msg, InstanceForm.BDatabase);

                InstanceForm.BDatabase.CommitTransaction();

                Print(_kjeid);

                radioButton1.Checked = true;

                Fill(Kdjid);

                //提示发票段已经用完 --ADD jiangzf 2014-2-25
                if (Msg.Trim() != "")
                    MessageBox.Show(Msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtzph.Text = "";
                txtdw.Text = "";
                cmbyh.Text = "";
                txtje.Text = "";
                txtbz.Text = "";
                txtkh.SelectAll();
                txtkh.Focus();
                MessageBox.Show("成功", "提示");
                this.txtkh.Text = "";
                this.lblbrxm.Text = "";
                lblye.Text = "";
                lblgzdw.Text = "";
                lblsfzh.Text = "";
                lblxb.Text = "";
                lblnl.Text = "";

                //重新获取预交金发票号
                if (cfg1111.Config.Trim() == "1")
                    getYjjFph();
                
                //txtkh_KeyPress(null,new KeyPressEventArgs('\r'));

                if (bqybjq == "true" && bjqxh == "上海通导语音报价器型号Ⅳ")
                {
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    call.Call(ts_call.DmType.卡充值, Crje.ToString("0.00"));
                }
                else if (bqybjq == "true" && bjqxh == "上海通导语音报价器邵阳第一人民医院")
                {
                    //ADD BY TCK 2013-11-21
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    call.Call(ts_call.DmType.卡充值, Crje.ToString("0.00"));

                }
                if ( AfterRechargeSuccess != null )
                    AfterRechargeSuccess();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Print(Guid kjeid)
        {
            try
            {
                string ssql = "select dbo.FUN_ZY_SEEKFKFSNAME(a.fkfs) 支付方式,b.kye,a.* from yy_kdjb_je a inner join yy_kdjb b on a.kdjid=b.kdjid where a.kjeid='" + kjeid.ToString() + "' and a.bzfbz=0 and a.bdzbz=1";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count != 0)
                {
                    ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();
                    DataRow myrow;

                    myrow = Dset.预收款.NewRow();

                    myrow["类型"] = tb.Rows[0]["支付方式"].ToString();
                    myrow["票据号"] = tb.Rows[0]["pjh"].ToString();
                    myrow["金额"] = tb.Rows[0]["crje"].ToString();
                    myrow["收款日期"] = tb.Rows[0]["djsj"].ToString();
                    myrow["收款员"] = Fun.SeekEmpName(Convert.ToInt32(tb.Rows[0]["djy"]), InstanceForm.BDatabase);
                    myrow["大写金额"] = Money.NumToChn(tb.Rows[0]["crje"].ToString());
                    myrow["银行"] = tb.Rows[0]["khyh"].ToString();
                    myrow["单位"] = tb.Rows[0]["khdw"].ToString();
                    myrow["姓名"] = lblbrxm.Text;
                    myrow["支票号"] = tb.Rows[0]["zph"].ToString();
                    myrow["卡号"] = txtkh.Text;
                    myrow["年龄"] = lblnl.Text;
                    myrow["性别"] = lblxb.Text;
                    myrow["联系方式"] = lbllxfs.Text;
                    myrow["备注"] = tb.Rows[0]["bz"].ToString();
                    Dset.预收款.Rows.Add(myrow);

                    ParameterEx[] parameters = new ParameterEx[2];

                    parameters[0].Text = "医院名称";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "门诊预收款凭证";
                    //Add by zp 2014-01-07 新增卡余额参数
                    parameters[1].Text = "卡余额";
                    parameters[1].Value = tb.Rows[0]["kye"];

                    TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_预收款票据.rpt", parameters);

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
                        f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_预收款票据.rpt", parameters, true);
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Fill(Guid kdjid)
        {
            string ssql = "select '' 序号,dbo.FUN_ZY_SEEKFKFSNAME(fkfs) 支付方式,crje 金额,djsj 登记时间,dbo.fun_getempname(djy) 登记员,dzrq 到帐时间,dbo.fun_getempname(dzy) 到帐员,zph 支票号,khyh 银行,khdw 开户单位,bz 备注,kjeid,bdzbz,fkfs,kdjid as kid ,zfrq 作废日期 from YY_KDJB_je ";
            if (kdjid != Guid.Empty)
                ssql = ssql + " where kdjid='" + kdjid + "'";
            else
                ssql = ssql + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            Fun.AddRowtNo(tb);
            this.DateGridView1.DataSource = tb;

            if (kdjid == Guid.Empty) return;
            ssql = "select * from YY_KDJB where kdjid='" + kdjid + "'";
            DataTable tbk = InstanceForm.BDatabase.GetDataTable(ssql);
            lblye.Text = tbk.Rows[0]["kye"].ToString();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbfkfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fkfs = Convert.ToInt32(cmbfkfs.SelectedValue);
            //现金和Pos处理方式
            if (fkfs != 2)
            {
                txtzph.Text = "";
                txtdw.Text = "";
                cmbyh.SelectedIndex = -1;
                checkBox1.Checked = true;

                txtzph.Enabled = false;
                txtdw.Enabled = false;
                cmbyh.Enabled = false;
                checkBox1.Enabled = false;
            }
            //支票处理方式
            else
            {
                txtzph.Text = "";
                txtdw.Text = "";
                cmbyh.SelectedIndex = -1;
                checkBox1.Checked = false;

                txtzph.Enabled = true;
                txtdw.Enabled = true;
                cmbyh.Enabled = true;
                checkBox1.Enabled = true;
            }
            txtje.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Fill(Guid.Empty);
        }

        private void DateGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in DateGridView1.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["作废日期"].Value, "") != "")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Red;
                }

                if (Convertor.IsNull(dgv.Cells["fkfs"].Value, "") == "2" && Convertor.IsNull(dgv.Cells["到帐时间"].Value, "") == "" && Convertor.IsNull(dgv.Cells["作废日期"].Value, "") == "")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void mnudzqr_Click(object sender, EventArgs e)
        {
            try
            {
                int nrow = this.DateGridView1.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.DateGridView1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;
                Guid kid = new Guid(tb.Rows[nrow]["kid"].ToString());
                Guid kjeid = new Guid(tb.Rows[nrow]["kjeid"].ToString());
                int bdzbz = Convert.ToInt32(tb.Rows[nrow]["bdzbz"]);
                int fkfs = Convert.ToInt32(tb.Rows[nrow]["fkfs"]);
                decimal je = Convert.ToDecimal(tb.Rows[nrow]["金额"]);
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                if (bdzbz == 1) { MessageBox.Show("已到帐,不能再次确认", "", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                InstanceForm.BDatabase.BeginTransaction();

                mz_kdj.Kdj_je_zpdz(kjeid, kid, Brxxid, fkfs, je, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);

                InstanceForm.BDatabase.CommitTransaction();

                Print(kjeid);

                Fill(kid);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuzfjk_Click(object sender, EventArgs e)
        {
            try
            {

                int nrow = this.DateGridView1.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.DateGridView1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;


                if (MessageBox.Show("您确定作废当前预收款吗吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                if (tb.Rows[nrow]["登记员"].ToString().Trim() != InstanceForm.BCurrentUser.Name.Trim())
                {
                    MessageBox.Show("非本人登记的预收款,您无权作废"); return;
                }
                Guid kid = new Guid(tb.Rows[nrow]["kid"].ToString());
                Guid kjeid = new Guid(tb.Rows[nrow]["kjeid"].ToString());
                int bdzbz = Convert.ToInt32(tb.Rows[nrow]["bdzbz"]);
                int fkfs = Convert.ToInt32(tb.Rows[nrow]["fkfs"]);
                decimal je = Convert.ToDecimal(tb.Rows[nrow]["金额"]);
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                InstanceForm.BDatabase.BeginTransaction();
                mz_kdj.Kdj_je_zf(kid, kjeid, Brxxid, je, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                InstanceForm.BDatabase.CommitTransaction();
                Fill(kid);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                int nrow = this.DateGridView1.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.DateGridView1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;
                int bdzbz = Convert.ToInt32(tb.Rows[nrow]["bdzbz"]);
                int fkfs = Convert.ToInt32(tb.Rows[nrow]["fkfs"]);
                string zfrq = Convert.ToString(tb.Rows[nrow]["作废日期"]);

                if (bdzbz == 1)
                {
                    mnudzqr.Enabled = false;
                    mnuzfjk.Enabled = true;
                }
                if (zfrq.Trim() != "")
                    mnuzfjk.Enabled = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        private void txtkh_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((char)e.KeyData != '\r')
            //{
            //    e.Handled = true;
            //    return;
            //}
        }

        private void txtkh_KeyUp(object sender, KeyEventArgs e)
        {

            
        }

    }
}