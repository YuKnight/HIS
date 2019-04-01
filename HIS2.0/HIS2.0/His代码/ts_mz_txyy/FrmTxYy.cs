using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Reflection;

namespace ts_mz_txyy
{
    public partial class FrmTxYy : Form
    {
        private long Jgbm = 0;//机构编码
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbks;//挂号科室数据
        private DataTable Tbys;//挂号医生数据
        private int Fplx;//发票类型 0 挂号票 1 收费票
        private DataTable tbk;//病人卡信息
        //门诊挂号输入医生时只检索对应科室的医生
        private SystemCfg cfg1058 = new SystemCfg(1058);
        private SystemCfg cfgpb = new SystemCfg(1051);
        private SystemCfg cfgnl = new SystemCfg(1050);
        private SystemCfg cfg_1093 = new SystemCfg(1093);//Add By zp 2013-09-22 挂号是否只允许刷卡消费 0否 1是 默认0
        private SystemCfg cfg1079 = new SystemCfg(1079);//*add by zch 2013-03-28 门诊小票打印是否打在一张上（只切纸一次）0=否 ，1=是 */
        private SystemCfg cfg1114 = new SystemCfg(1114);//add by jiangzf 2014-4-22 合同单位病人是否打印发票 1不打印 0打印 默认0
        private SystemCfg cfg1046 = new SystemCfg(1046);
        private SystemCfg cfg1060 = new SystemCfg(1060);//Add By Zj 2012-05-10 是否验证卡的英文字母
        private SystemCfg cfgpbys = new SystemCfg(1052);

        /// <summary>
        /// 本次操作是否创建了一张新卡
        /// </summary>
        //Add By Tany 2010-09-18 这里用于收费是否收卡费
        private bool _isCreateNewCard = false;

        private int _idTxyy = 5149;
        private string _nameTxyy = "碎片预约";

        private bool _zdJd = false;

        public FrmTxYy()
        {
            InitializeComponent();
        }

        private void FrmTxYy_Load(object sender, EventArgs e)
        {
            //添加卡类型
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            //添加挂号级别
            FunAddComboBox.AddGhjb(false, cmbghjb, InstanceForm.BDatabase);

            DataTable dtKlx = cmbklx.DataSource as DataTable;
            DataTable dtCard = dtKlx.Clone();

            for (int iCard = 0; iCard < dtKlx.Rows.Count; iCard++)
            {
                if (!dtKlx.Rows[iCard]["klx"].ToString().Equals("6"))
                {
                    dtCard.Rows.Add(dtKlx.Rows[iCard].ItemArray);
                }
            }
            dtCard.AcceptChanges();
            cmbklx.DataSource = dtCard;


            Jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
            //ADD BY CC Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            SystemCfg cfg1116 = new SystemCfg(1116);
            if (cfg1116.Config.ToString() == "0")
            {

                Tbks = GetGhks(false, true, InstanceForm.BDatabase);
            }
            else
            {
                Tbks = GetGhks_lyfy(false, InstanceForm.BDatabase, cfg1116.Config.Trim());
            }

            //Tbks

            //RefGhKsInfo(); //Add by zp 2013-12-14
            //Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);

            txtys.Text = InstanceForm.BCurrentUser.Name;
            txtys.Tag = InstanceForm.BCurrentUser.EmployeeId;
        }

        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {

            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = txtks;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString().Trim();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtks.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtks.Text = f.SelectDataRow["name"].ToString().Trim();
                    //GetXh(true);
                    if (cfg1058.Config == "0")
                        //Tbys = Fun.GetGhys(Convert.ToInt32(txtks.Tag), 0, InstanceForm.BDatabase);
                        SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtks.Text.Trim() == "")
                {
                    txtks.Focus();
                    return;
                }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtys_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;

                if ((int)e.KeyChar == 8)
                {
                    txtys.Tag = "0";
                    txtys.Text = "";
                    return;
                }

                if ((int)e.KeyChar == 13 && Convertor.IsNumeric(txtys.Text.Trim()) == true)
                {
                    DataRow[] rows = Tbys.Select("code='" + txtys.Text.Trim() + "'", "");
                    if (rows.Length == 1)
                    {
                        txtys.Tag = rows[0]["employee_id"].ToString();
                        txtys.Text = rows[0]["name"].ToString().Trim();
                        GetDoctorPbxx(rows[0]["employee_id"].ToString());
                        //Add By Zj 2012-02-16 输入医生编码显示预约限制信息
                        //GetXh(true);
                        SendKeys.Send("{TAB}");
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        txtys.Tag = "0";
                        txtys.Text = "";
                        return;
                    }
                }

                if ((int)e.KeyChar != 13 && Convertor.IsNumeric(e.KeyChar.ToString()) == false)
                {
                    string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                    string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                    string[] searchfields = new string[] { "ys_code", "code", "py_code", "wb_code" };
                    int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                    TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                    f.sourceDataTable = Tbys;
                    f.WorkForm = this;
                    f.srcControl = txtys;
                    f.Font = txtks.Font;
                    f.Width = 400;
                    f.ReciveString = e.KeyChar.ToString();
                    if (f.ShowDialog() == DialogResult.Cancel)
                    {
                        txtys.Focus();
                        e.Handled = true;
                    }
                    else
                    {
                        txtys.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                        txtys.Text = f.SelectDataRow["name"].ToString().Trim();
                        GetDoctorPbxx(txtys.Tag.ToString());
                        #region  屏蔽代码
                        ////////int yghs = 0; int xhs = 0; int swxhs = 0; int xwxhs = 0; int lsjh = 0;
                        ////////mz_ghxx.GetXhs(Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0")), out yghs, out xhs, out swxhs, out xwxhs, out lsjh, InstanceForm.BDatabase);
                        ////////if (xhs > 0) lblxh.Text = yghs.ToString().ToString() + "/" + Convert.ToString(xhs+lsjh); else lblxh.Text = "";
                        ////////if (swxhs > 0) lblxh.Text = lblxh.Text + " 上午:" + swxhs.ToString();//上午
                        ////////if (xwxhs > 0) lblxh.Text = lblxh.Text + " 下午:" + xwxhs.ToString();//下午
                        ////////if (lsjh > 0) lblxh.Text = lblxh.Text + " 加号:" + lsjh.ToString();
                        #endregion
                        //GetXh(true);
                        e.Handled = true;
                        SendKeys.Send("{TAB}");
                    }

                }
                if ((int)e.KeyChar == 13)
                {
                    //Add By Zj 2012-04-09 输入医生编码显示预约限制信息
                    GetDoctorPbxx(txtys.Tag.ToString());
                    //Add By Zj 2012-02-16 输入医生编码显示预约限制信息
                    //GetXh(true);
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            catch
            { }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butclear_Click(object sender, EventArgs e)
        {
            txtks.Text = "";
            txtks.Tag = "0";
            txtys.Text = "";
            txtys.Tag = "0";

            this.Tag = Guid.Empty; //加个清空

            //Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
        }

        public DataTable GetGhks_lyfy(bool jzks, RelationalDatabase _DataBase, string strNoteTemp)
        {
            string strNote = strNoteTemp;
            string strDept = InstanceForm.BCurrentDept.DeptId.ToString();
            string[] strDeptList = strNote.Split('|');
            int iCount = 0;
            for (int i = 0; i < strDeptList.Length; i++)
            {
                if (strDeptList[i].ToString().IndexOf(InstanceForm.BCurrentDept.DeptId.ToString()) >= 0)
                {
                    iCount = i;
                    break;
                }
            }
            string strDeptAll = strDeptList[iCount].ToString().Split('-')[1];

            //原代码

            string ssql = "";
            SystemCfg cfg = new SystemCfg(1057, _DataBase);
            if (jzks == false)
                ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where ISZJMZ=1 and layer=3 and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code in(" + cfg.Config + "))";
            else
                ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where ISZJMZ=1 and layer=3 and  jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code in('003'))";
            return _DataBase.GetDataTable(ssql + " and dept_id  in" + strDeptAll);
        }

        /// <summary>
        /// 获取专家挂号科室 
        /// </summary>
        /// <param name="jzks">专家挂号</param>
        /// <returns></returns>
        public DataTable GetGhks(bool jzks, bool zjks, RelationalDatabase _DataBase)
        {
            string ssql = "";
            SystemCfg cfg = new SystemCfg(1057, _DataBase);
            if (jzks == false)
                ssql = @"select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property a
                            inner join jc_mz_yspb c on a.DEPT_ID=c.PBKSID and c.BSCBZ=0
                            where c.YSID=" + InstanceForm.BCurrentUser.EmployeeId + " and a.ISZJMZ=1 and a.layer=3  and a.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and a.deleted=0  and a.dept_id in (select dept_id from jc_dept_type_relation b where b.TYPE_CODE in(" + cfg.Config + ")) group by DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code";
            else
                ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where ISZJMZ=1 and layer=3 and  jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code in('003'))";
            return _DataBase.GetDataTable(ssql);
        }

        //通过医生个人排班确定科室和级别
        private void GetDoctorPbxx(string ysid)
        {
            try
            {
                if (cfgpb.Config == "0") return;
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@ksid";
                parameters[0].Value = "0";

                parameters[1].Text = "@ysid";
                parameters[1].Value = ysid;

                DataSet dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_MZGH_GETPBXX", parameters, dset, "sfmx", 30);

                if (dset.Tables[0].Rows.Count > 0)
                {
                    string tag = Convertor.IsNull(dset.Tables[0].Rows[0]["xh"], "");
                    string[] s = tag.Split(new char[1] { '|' });
                    if (s.Length <= 1) return;
                    string ksdm = s[0];
                    string ysdm = s[1];
                    string ghjb = s[2];
                    string pplx = s[3];
                    if (txtks.Text.Trim() == "")//Add By Zj 2012-05-06 如果已经输入了科室 将不改变科室 修改原因是因为怀化三医院 输入科室再输入医生制空的话 会清空科室
                    {
                        txtks.Tag = ksdm;
                        txtks.Text = Fun.SeekDeptName(Convert.ToInt32(ksdm), InstanceForm.BDatabase);
                        cmbghjb.SelectedValue = ghjb;
                    }
                    txtys.Tag = ysdm;
                    txtys.Text = Fun.SeekEmpName(Convert.ToInt32(ysdm), InstanceForm.BDatabase);
                }
                else
                {
                    string ssql = @"select a.employee_id,d.type_id,a.dept_id,dbo.fun_getdeptname(a.dept_id) dept_name from JC_EMP_DEPT_ROLE a inner join jc_role_doctor b
                                        on a.employee_id=b.employee_id  inner join 
                                        JC_DEPT_TYPE_RELATION c on a.dept_id=c.dept_id and c.type_code='001'
                                        inner join jc_doctor_type d on  b.ys_typeid=d.zcjb where a.employee_id=" + ysid + "";

                    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb.Rows.Count > 0)
                    {
                        if (txtks.Text.Trim() == "")
                        {
                            txtks.Text = tb.Rows[0]["dept_name"].ToString();
                            txtks.Tag = tb.Rows[0]["dept_id"].ToString();
                            cmbghjb.SelectedValue = tb.Rows[0]["type_id"].ToString();
                        }
                        else //如果科室不为空 只改变医生默认的级别 2012-04-09
                        {
                            cmbghjb.SelectedValue = tb.Rows[0]["type_id"].ToString();
                        }
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            try
            {
                #region 变量付值
                string Msg = "";
                //long kdjid = 0;
                Guid brxxid = new Guid(Convertor.IsNull(this.Tag, Guid.Empty.ToString()));

                int ghlx = 1;//Convert.ToInt32(Convertor.IsNull(cmbghlx.SelectedValue, "0"));
                string _ghlx = "门诊";//Convertor.IsNull(cmbghlx.Text, "");

                int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                int _pdxh = 0;//排队序号
                string kh = txtkh.Text.Trim();
                string xm = txtxm.Text.Trim();

                decimal zje = 0;
                decimal yhje = 0;
                decimal srje = 0;
                decimal zfje = 0;
                decimal ybzf = 0;
                int fpzs = 0;//发票张数 Add By Zj 2012-12-13
                //Add By Tany 2010-06-30
                decimal ybzhzf = 0;//医保帐户支付
                decimal ybjjzf = 0;//医保基金支付
                decimal ybbzzf = 0;//医保补助支付

                decimal ybkye = 0M;//Convert.ToDecimal(Convertor.IsNull(lblYbye.Text, "0"));

                if (Convertor.IsNumeric(txtnl.Text) == false && txtnl.Text.Trim() != "")
                {
                    MessageBox.Show("年龄请输入数字");
                    return;
                }

                Guid NewFpid = Guid.Empty;

                string csrq = "1900-01-01 00:00:00";
                if (rdocsrq.Checked == true) csrq = dtpcsrq.Value.ToShortDateString();
                if (rdonl.Checked == true && txtnl.Text.Trim() != "") csrq = dtpcsrq.Value.ToShortDateString();
                if (cfgnl.Config == "1" && txtnl.Text.Trim() == "" && rdonl.Checked == true)
                {
                    MessageBox.Show("年龄必须输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtnl.Focus();
                    return;
                }

                int brlx = 0;// Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0"));

                string mzh = "";//lblmzh.Text.Trim();//wait

                string fph = "0";
                decimal ye = Convert.ToDecimal(Convertor.IsNull(lblkye.Text, "0"));
                int ghks = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                int ghjb = Convert.ToInt32(Convertor.IsNull(cmbghjb.SelectedValue, "0"));
                int ghys = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                int yblx = cmbklx.SelectedValue.ToString().Equals("4") ? 1 : 0; //Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0"));
                string ghsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");//Add By Zj 2013-03-19

                string jydjh = "";//lbljyh.Text.Trim();
                string cbkh = ""; //Convertor.IsNull(cmbyblx.Tag, "");

                string _message = "";

                #region add by wangzhi 2014-11-04 增加持卡人和当前病人是否一致的判断，防止先检索出信息后，再修改卡号后不回车直接点挂号而产生错误数据
                if (!mz_ghxx.ValidingPatInfoAndCardInfo(klx, kh, brxxid, InstanceForm.BDatabase, out  _message))
                {
                    MessageBox.Show(_message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                #endregion

                #region 住院欠费检查
                // add by wangzhi 2010-10-28
                if (CheckZyFee(brxxid, xm) == false)
                {
                    return;
                }
                // end add
                #endregion

                //获取参数设置的病历本类型，参数格式 1000,1001
                string blb = "";
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                //卡属性
                mz_card card = new mz_card(klx, InstanceForm.BDatabase);
                //读取病人卡余额
                ReadCard readcard = new ReadCard(klx, kh, InstanceForm.BDatabase);
                ye = readcard.kye;

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

                //if (kh.Trim() != "" && readcard.kdjid == Guid.Empty && New_Card != "true")
                if (kh.Trim() != "" && readcard.kdjid == Guid.Empty)
                {
                    MessageBox.Show("没有找到卡信息，请确认卡是否输入正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //医保类型
                Yblx yb = new Yblx(yblx, InstanceForm.BDatabase);

                //if (lblmzh.Text.Trim() == "")
                //{
                //    MessageBox.Show("门诊号为空，请检查");
                //    return;
                //}

                if (readcard.kdjid == Guid.Empty && kh == "")
                {
                    MessageBox.Show("必须输入卡号");
                    txtkh.Focus();
                    return;
                }

                if (xm == "")
                {
                    MessageBox.Show("请输入姓名");
                    txtxm.Focus();
                    return;
                }
                if (ghks == 0)
                {
                    MessageBox.Show("请输入挂号科室");
                    txtks.Focus();
                    return;
                }
                //if (ghys_ini != "true" && ghys == 0)
                //{
                //    MessageBox.Show("请输入挂号医生");
                //    txtys.Focus();
                //    return;
                //}

                #endregion

                int err_code = -1;
                string err_text = "";


                #region  通过挂号信息获得本次的收费联动明细项目

                //卡费的收取 如果传了卡类型就收卡费
                int _klx = 0;

                //if (New_Card == "true" && readcard.kdjid == Guid.Empty && txtkh.Text.Trim() != "")
                //Modify By Tany 2010-09-18 应该是卡登记ID不为空才能收卡费并且为本次创建的新卡
                //if (_isCreateNewCard && New_Card == "true" && readcard.kdjid != Guid.Empty && txtkh.Text.Trim() != "")
                //Modify By zp 2013-09-30 新卡办理后的卡登记id永远是空的  所以判断需要改变 以前是必须完全保存了病人信息和卡信息
                _klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));

                // add by wangzhi 2010-10-27 
                //当新病人信息卡信息不为Null时，说明是新办卡,设置_klx变量以便后台能够处理收取卡费
                //if (_klx > 0)
                //{
                //    if (_new_brxx_kxx != null)
                //    {
                //        _klx = _new_brxx_kxx.Kdjxx.Klx;
                //        //add by zouchihua 2013-4-17 如果是新卡，再判断一次看是否有挂号记录
                //        string ssstr = "select * from YY_KDJB where KH='" + txtkh.Text.Trim() + "'and ZFBZ=0  and KLX=" + _klx;
                //        DataTable tbtempxx = InstanceForm.BDatabase.GetDataTable(ssstr);
                //        if (tbtempxx.Rows.Count > 0)
                //        {
                //            MessageBox.Show("系统检查到该卡号已经存在有效的卡信息！\r\n 请重新刷卡再进行挂号操作！！");
                //            return;
                //        }
                //    }
                //}

                //end add
                Guid yhlx = Guid.Empty;//new Guid(Convertor.IsNull(cmbyhlx.SelectedValue, Guid.Empty.ToString()));
                DataSet dset = mz_ghxx.mzgh_get_sfmx(ghlx, brlx, yblx, ghks, ghjb, ghys, blb, ybzf, _klx, yhlx, Jgbm, out err_code, out err_text, Guid.Empty.ToString(), InstanceForm.BDatabase);

                if (err_code != 0)
                {
                    MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }

                //填写流水号,一张发票对应一个流水号
                for (int iFp = 0; iFp < dset.Tables[0].Rows.Count; iFp++)
                    dset.Tables[0].Rows[iFp]["dnlsh"] = Fun.GetNewDnlsh(_idTxyy, TrasenFrame.Forms.FrmMdiMain.Jgbm, InstanceForm.BDatabase);


                zje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));//计算结果集1表的总金额
                yhje = Convert.ToDecimal(dset.Tables[0].Compute("sum(yhje)", ""));//计算结果集1表的优惠金额
                srje = Convert.ToDecimal(dset.Tables[0].Compute("sum(srje)", ""));//计算结果集1表的舍入金额
                zfje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zfje)", ""));//计算结果集1表的自付金额
                fpzs = dset.Tables[0].Rows.Count;//Add By Zj 2012-12-13 将发票张数赋值

                //if (new SystemCfg(1068).Config == "0")//Add By Zj 2012-12-20 诊疗卡费用不打印  发票为1张
                //    fpzs = 1;
                //如果分票 注释这些
                //zje = Convert.ToDecimal(dset.Tables[0].Rows[0]["zje"]);
                //yhje = Convert.ToDecimal(dset.Tables[0].Rows[0]["yhje"]);
                //srje = Convert.ToDecimal(dset.Tables[0].Rows[0]["srje"]);
                //zfje = Convert.ToDecimal(dset.Tables[0].Rows[0]["zfje"]);



                #endregion

                #region 收银对象框

                Frmsf f = new Frmsf(_menuTag, _chineseName, _mdiParent, InstanceForm.BDatabase);

                f.txtybzf.ReadOnly = true;
                f.txtssxj.ReadOnly = true;

                f.lblks.Text = txtks.Text.Trim();
                f.lblxm.Text = txtxm.Text.Trim();
                f.lblfph.Text = "";//lblfph.Text.Trim();
                f.lblzje.Text = zje.ToString();
                f.lblklx.Text = cmbklx.Text.Trim();
                f.lblkye.Text = lblkye.Text.Trim();
                f.lblbrlx.Text = "";// cmbbrlx.Text.Trim();
                f.lblyhje.Text = yhje == 0 ? "" : yhje.ToString();
                f.lblsrje.Text = srje == 0 ? "" : srje.ToString();
                f.txtybzf.Text = ybzf == 0 ? "" : ybzf.ToString();
                f.lblfps.Text = fpzs + " 张";
                f.txtybzf.Enabled = true;
                f.klx = readcard.klx;
                f.kdjid = readcard.kdjid;
                f.fpzs = fpzs;

                for (int jeRow = 0; jeRow < dset.Tables[1].Rows.Count; jeRow++)
                {
                    dset.Tables[1].Rows[jeRow]["je"] = "0";
                }

                f.dataGridView1.DataSource = dset.Tables[1];
                //f.lblhtdwlx.Text = cmbdwlx.Text;
                //f.lblhtdw.Text = txthtdw.Text;


                //当选择了医保类型，但没有启用接口的情况下 医保输入框可用
                f.txtybzf.Enabled = false;
                if (yblx > 0 && jydjh.Trim() == "" && yb.isgh == false)
                    f.txtybzf.Enabled = true;

                if (yb.issf == true)
                    f.lblbz.Text = "帐户支付:" + ybzhzf.ToString() + " 统筹支付:" + ybjjzf.ToString() + " 其他支付:" + ybbzzf.ToString();

                //判断当前卡是否支持欠费挂帐 如果可以则欠费挂帐输入框可用

                //f.txtqfgz.Enabled = card.bqfgz;
                //f.txtcwjz.Enabled = card.bjebz == true && ye > 0 ? true : false;

                //判断当前卡是否支持欠费挂帐 如果可以则欠费挂帐输入框可用
                string ssqfgz = new SystemCfg(1025).Config == "0" ? "true" : "false";
                if (ssqfgz == "true") f.txtqfgz.Enabled = true; else f.txtqfgz.Enabled = false;
                if (card.klx > 0 && card.bqfgz == true)
                    f.txtqfgz.Enabled = card.bqfgz;
                if (new SystemCfg(1037).Config == "1") f.txtzpzf.Enabled = false;
                //if (new SystemCfg(1038).Config == "1" && cmbdwlx.Text.Trim() == "") f.txtqfgz.Enabled = false;
                f.txtqfgz.Enabled = false;

                //卡中有余额
                if (ye > 0)
                {
                    if (ye >= zfje)
                    {
                        f.txtcwjz.Text = zfje.ToString();
                        f.lblysxj.Text = "0";
                    }
                    else
                    {
                        f.txtcwjz.Text = ye.ToString();
                        f.lblysxj.Text = Convert.ToDecimal(zfje - ye).ToString();
                    }
                }
                else
                {
                    f.txtcwjz.Enabled = false;
                    f.txtcwjz.Text = "";
                    f.lblysxj.Text = zfje.ToString();
                }
                f.lblysxj.Text = "0";
                f.lblzje.Text = "0";
                //f.lblysxj.Text = "0";


                ////合同单位病人收银时,金额输入到挂帐一栏
                //if (new SystemCfg(1036).Config == "1" && cmbdwlx.Text.Trim() != "")
                //{
                //    f.txtqfgz.Text = zfje.ToString();
                //    f.lblysxj.Text = "0";
                //}


                f.txtssxj.Focus();
                f.ShowDialog();



                #endregion

                decimal ylkzf = 0;//银联卡支付
                decimal cwjz = 0;//财务记账
                decimal qfgz = 0;//欠费挂账
                decimal ssxj = 0;//实收金额
                decimal zlje = 0;//找零金额
                decimal xjzf = 0;//现金支付
                decimal zpzf = 0;//支票支付
                string _ghck = "";//挂号窗口

                ylkzf = Convert.ToDecimal(Convertor.IsNull(f.txtpos.Text, "0"));//银联
                cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));//财务记帐
                qfgz = Convert.ToDecimal(Convertor.IsNull(f.txtqfgz.Text, "0"));//欠费挂帐
                ssxj = 0M;//Convert.ToDecimal(Convertor.IsNull(f.txtssxj.Text, "0"));//实收现金
                zlje = Convert.ToDecimal(Convertor.IsNull(f.lblzl.Text, "0"));//找零金额
                xjzf = Convert.ToDecimal(Convertor.IsNull(f.lblysxj.Text, "0"));//现金自付
                zpzf = Convert.ToDecimal(Convertor.IsNull(f.txtzpzf.Text, "0"));//支票支付
                ybzf = 0M;//Convert.ToDecimal(Convertor.IsNull(f.txtybzf.Text, "0"));//医保支付
                _ghck = "";
                if (cwjz > 0)
                {
                    #region 敲入卡号

                    if (cfg_1093.Config.Trim() == "1") //Add By zp 如果是诊疗卡扣款则需要读卡验证 2013-09-22
                    {
                        string strMsg = "读卡失败，医院诊疗卡支付需要进行读卡确认!请将卡放置读卡器上!\r\n可能配置不正确，可能读卡设备有问题...";


                        string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                        if (sbxh != "")
                        {
                            //load 事件 中 将panel_yanzheng 的高度 设为0
                            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                            if (ReadCard != null)
                            {
                                //ts_Read_hospitalCard.CardFactory.ReadCard_for_yanzheng(ReadCard, _menuTag.Function_Name, cmbklx, txt_kh_yanzheng);
                                //if (string.IsNullOrEmpty(txt_kh_yanzheng.Text) || txt_kh_yanzheng.Text.Trim() != kh.Trim())
                                //{
                                //    string strRetry = "医院诊疗卡支付需要进行读卡确认！\r\n按<重试>将再读一次卡，按<重试>前请放好卡\r\n否则退出，本次挂号无效！";
                                //    string strRetryMsg = "";
                                //    if (string.IsNullOrEmpty(txt_kh_yanzheng.Text)) strRetryMsg = "读取卡失败！" + strRetry;
                                //    else
                                //    {
                                //        // (txt_kh_yanzheng.Text.Trim() != kh.Trim())
                                //        strRetryMsg = "读卡器读取卡信息与挂号窗口填写的卡信息不符！挂号失败！\r\n" + strRetry;
                                //    }
                                //    DialogResult dlg = MessageBox.Show(strRetryMsg, "提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                                //    ts_Read_hospitalCard.CardFactory.ReadCard_for_yanzheng(ReadCard, _menuTag.Function_Name, cmbklx, txt_kh_yanzheng);
                                //    if (string.IsNullOrEmpty(txt_kh_yanzheng.Text))
                                //    {
                                //        if (dlg == DialogResult.Retry) MessageBox.Show(string.Format("按<重试>后仍然读卡失败，挂号无效！"), "提示");
                                //        return;
                                //    }
                                //    else if (txt_kh_yanzheng.Text.Trim() != kh.Trim())
                                //    {
                                //        string str = txt_kh_yanzheng.Text;
                                //        if (dlg == DialogResult.Retry) MessageBox.Show(string.Format("按<重试>后仍然读卡卡信息与挂号窗口填写的卡信息不符，挂号无效！", "提示"));
                                //        return;
                                //    }
                                //}
                            }
                            else
                            {
                                MessageBox.Show(strMsg, "提示");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(strMsg, "提示");
                            return;
                        }
                    }
                    #endregion
                }

                #region  获得可用发票号集合
                DataTable tbfp = null;
                tbfp = Fun.GetFph(_idTxyy, new SystemCfg(1067).Config != "2" ? 1 : fpzs, Fplx, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0 || tbfp.Rows.Count == 0 || tbfp.Rows.Count != (new SystemCfg(1067).Config != "2" ? 1 : fpzs))
                {
                    if (cfg1046.Config == "1")//只有打发票时才判断 Modify by zouchihua 2013-4-23)
                    {
                        //if (Convertor.IsNull(txthtdw.Tag, "0") != "0" && txthtdw.Tag.ToString() != "" && cfg1114.Config == "0") { }//add by jiangzf 如果是合同单位病人，并且参数1114=1，则不需要获取发票号
                        //if (cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1") { }//add by jiangzf
                        //else
                        //{
                        //    MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                    }
                }

                if (!f.Bok)
                    return;

                #endregion

                Cursor = PubStaticFun.WaitCursor();
                InstanceForm.BDatabase.BeginTransaction();
                try
                {
                    #region //保存挂号信息、处方信息
                    Guid NewGhxxid = Guid.Empty;
                    string sCfid = "";
                    for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                    {
                        int ksdm = ghks;//科室代码
                        string ksmc = txtks.Text.Trim();//科室名称
                        int ysdm = ghys;//医生代码
                        string ysmc = txtys.Text.Trim();//医生名称
                        int zxks = ghks;//执行科室代码
                        string zxksmc = txtks.Text.Trim();//执行科室名称
                        int bghpbz = 0;//挂号票标志
                        decimal cfzje = Convert.ToDecimal(dset.Tables[0].Rows[i]["zje"]);//计算出挂号总金额 与 卡费分开
                        decimal ghje = 0M;
                        if (dset.Tables[0].Rows[i]["groupid"].ToString() == "挂号费" || dset.Tables[0].Rows[i]["groupid"].ToString() == "")
                        {
                            bghpbz = 1;//挂号票
                            if (cfg1046.Config == "1")//如果需要打发票。就获取发票号
                            {
                                //if (Convertor.IsNull(txthtdw.Tag, "0") != "0" && txthtdw.Tag.ToString() != "" && cfg1114.Config == "0") { }//add by jiangzf 如果是合同单位病人，并且参数1114=0，则不需要获取发票号
                                //if (cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1") { }
                                //else
                                fph = Convertor.IsNull(tbfp.Rows[i]["QZ"], "") + tbfp.Rows[i]["fph"].ToString().Trim();
                            }
                            long _dnlsh = Convert.ToInt64(dset.Tables[0].Rows[i]["dnlsh"]);
                            mzh = _dnlsh.ToString();
                            //挂号信息保存
                            //弹性预约金额为0
                            //cfzje = 0M;
                            //mz_ghxx.GhxxDj(Guid.Empty, brxxid, ghlx, readcard.kdjid, mzh, ghks, ghys, ghjb, cfzje, _idTxyy, 1, _ghck, ref _pdxh, _dnlsh, fph, Jgbm, out NewGhxxid, out err_code, out err_text, 0, 0, yblx, "", "", "", 0, "", "", ghsj, InstanceForm.BDatabase);
                            mz_ghxx.GhxxDj(Guid.Empty, brxxid, ghlx, readcard.kdjid, mzh, ghks, ghys, ghjb, ghje, _idTxyy, 1, _ghck, ref _pdxh, _dnlsh, fph, Jgbm, out NewGhxxid, out err_code, out err_text, 0, 0, yblx, "", "", "", 0, "", "", ghsj, InstanceForm.BDatabase);
                            if (NewGhxxid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                        }
                        else
                        {

                            ksdm = 0; ksmc = ""; ysdm = 0; ysmc = ""; zxks = 0; zxksmc = "";//卡费不属于任何医生和科室 只记录操作员
                            //add by zouchihua 2013-3-28 设置卡号费的执行科室（0按照之前方式 大于0表示卡费执行科室） 
                            if (cfg1079.Config.Trim() != "0")
                            {
                                zxks = Convert.ToInt32(cfg1079.Config);
                                ksdm = Convert.ToInt32(cfg1079.Config);
                            }
                        }
                        string groupid = dset.Tables[0].Rows[i]["groupid"].ToString();//用于分解数据行
                        //保存处方
                        Guid NewCfid = Guid.Empty;

                        //mz_cf.SaveCf(Guid.Empty, brxxid, NewGhxxid, "", _ghck, cfzje, djsj, _idTxyy, _nameTxyy, _ghck, Guid.Empty, ksdm,
                        //            ksmc, ysdm, ysmc, 0, zxks, zxksmc, bghpbz, 0, 2, 0, 1, Jgbm, out NewCfid, out err_code, out err_text, InstanceForm.BDatabase);
                        mz_cf.SaveCf(Guid.Empty, brxxid, NewGhxxid, "", _ghck, ghje, djsj, _idTxyy, _nameTxyy, _ghck, Guid.Empty, ksdm,
                                    ksmc, ysdm, ysmc, 0, zxks, zxksmc, bghpbz, 0, 2, 0, 1, Jgbm, out NewCfid, out err_code, out err_text, InstanceForm.BDatabase);
                        if (NewCfid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                        sCfid += NewCfid.ToString() + ",";//组成需要更新的CFID

                        DataRow[] rows = dset.Tables[4].Select("groupid='" + groupid + "'");//找到对应的分组处方

                        for (int j = 0; j <= rows.Length - 1; j++)
                        {
                            //保存处方明细
                            Guid NewCfmxid = Guid.Empty;
                            //mz_cf.SaveCfmx(Guid.Empty, NewCfid, rows[j]["PY_CODE"].ToString().Trim(), "", rows[j]["item_name"].ToString().Trim(),
                            //    rows[j]["item_name"].ToString().Trim(), "", "", Convert.ToDecimal(rows[j]["cost_price"]), Convert.ToDecimal(rows[j]["num"]),
                            //    rows[j]["item_unit"].ToString().Trim(), 1, 1,
                            //    Convert.ToDecimal(rows[j]["je"]),
                            //    rows[j]["statitem_code"].ToString().Trim(),
                            //    Convert.ToInt64(rows[j]["item_id"]), Guid.Empty, rows[j]["STD_CODE"].ToString().Trim(), 0, 0, Guid.Empty, 0, "", "", 0, 0, "",
                            //    0, 0, Guid.Empty, 0, 0, 0, out NewCfmxid, out err_code, out err_text, InstanceForm.BDatabase);
                            mz_cf.SaveCfmx(Guid.Empty, NewCfid, rows[j]["PY_CODE"].ToString().Trim(), "", rows[j]["item_name"].ToString().Trim(),
                                rows[j]["item_name"].ToString().Trim(), "", "", Convert.ToDecimal(rows[j]["cost_price"]), Convert.ToDecimal(rows[j]["num"]),
                                rows[j]["item_unit"].ToString().Trim(), 1, 1,
                                0M,//Convert.ToDecimal(rows[j]["je"]),
                                rows[j]["statitem_code"].ToString().Trim(),
                                Convert.ToInt64(rows[j]["item_id"]), Guid.Empty, rows[j]["STD_CODE"].ToString().Trim(), 0, 0, Guid.Empty, 0, "", "", 0, 0, "",
                                0, 0, Guid.Empty, 0, 0, 0, out NewCfmxid, out err_code, out err_text, InstanceForm.BDatabase);
                            /*Modify By zp 2013-12-13 因为创智医保需要先传输处方明细id,所以处方明细id从前面传来*/
                            //mz_cf.SaveCfmx(NewCfmxid, NewCfid, rows[j]["PY_CODE"].ToString().Trim(), "", rows[j]["item_name"].ToString().Trim(),
                            //    rows[j]["item_name"].ToString().Trim(), "", "", Convert.ToDecimal(rows[j]["cost_price"]), Convert.ToDecimal(rows[j]["num"]),
                            //    rows[j]["item_unit"].ToString().Trim(), 1, 1, Convert.ToDecimal(rows[j]["je"]), rows[j]["statitem_code"].ToString().Trim(),
                            //    Convert.ToInt64(rows[j]["item_id"]), Guid.Empty, rows[j]["STD_CODE"].ToString().Trim(), 0, 0, Guid.Empty, 0, "", "", 0, 0, "",
                            //    0, 0, Guid.Empty, 0, 0, 0, ref NewCfmxid, out err_code, out err_text, true, InstanceForm.BDatabase);
                            if (NewCfmxid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                        }
                    }
                    #endregion

                    #region //保存收银信息
                    Guid NewJsid = Guid.Empty;
                    mz_sf.SaveJs(Guid.Empty, brxxid, NewGhxxid, djsj, _idTxyy, zje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, ssxj, zlje, fpzs, 0, Jgbm, out NewJsid, out err_code, out err_text, InstanceForm.BDatabase);
                    if (NewJsid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                    int UpdateCfs = 0;//更新处方头张数
                    sCfid = sCfid.Substring(0, sCfid.Length - 1);//将结尾的,去掉
                    string[] ssCfid = sCfid.Split(',');//有几张发票就有几个CFID 分隔 用来 作为更新收费标志的条件

                    for (int X = 0; X < dset.Tables[0].Rows.Count; X++)
                    {
                        Guid yhlxid = new Guid(dset.Tables[0].Rows[X]["yhlxid"].ToString());//优惠
                        string yhlxmc = Fun.SeekYhlxMc(yhlxid, InstanceForm.BDatabase);
                        decimal cfzje = 0M;// Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);//计算出挂号总金额 与 卡费分开
                        string groupid = dset.Tables[0].Rows[X]["groupid"].ToString();//分组ID
                        int bghpbz = 0;//挂号票标志
                        long _dnlsh = Convert.ToInt64(dset.Tables[0].Rows[X]["dnlsh"]);//获取每张发票的电脑流水号


                        if (new SystemCfg(1067).Config == "1" && dset.Tables[0].Rows[X]["groupid"].ToString() != "挂号费" && dset.Tables[0].Rows[X]["groupid"].ToString() != "")//Add By Zj 2012-12-20 诊疗卡费用不打印  发票为1张
                            fph = "0";
                        // add by jiangzf 2014-07-26 诊疗卡费用与挂号费分开,但诊疗卡费只打小票
                        if (new SystemCfg(1067).Config == "3" && dset.Tables[0].Rows[X]["groupid"].ToString() != "挂号费" && dset.Tables[0].Rows[X]["groupid"].ToString() != "")
                            fph = "0";
                        if (cfg1046.Config == "1" && fph != "0")//如果需要打发票。就获取发票号
                            fph = Convertor.IsNull(tbfp.Rows[X]["QZ"], "") + tbfp.Rows[X]["fph"].ToString().Trim();
                        if (dset.Tables[0].Rows[X]["groupid"].ToString() == "挂号费" || dset.Tables[0].Rows[X]["groupid"].ToString() == "") //Modify By Zj 2012-12-28 免费挂号
                        {
                            bghpbz = 1;
                            //只有挂号费 才给医保就医登记号赋值
                            jydjh = "";// string.IsNullOrEmpty(jsxx.JSDH) ? "" : jsxx.JSDH;//add by wangzhi 2010-12-28
                        }
                        else//Add By Zj 2013-03-11 ghpbz=2 是诊疗卡 发票。用来统计诊疗卡发票.
                            bghpbz = 2;
                        if (dset.Tables[0].Rows.Count == 1)//Modify By Zj 2012-12-20 总记录数为1时 才保存一张发票.诊疗卡虽然不打发票 但是仍然要有记录
                        {
                            //add by zouchihua 2013-3-28 设置卡号费的执行科室（0按照之前方式 大于0表示卡费执行科室） 
                            if (bghpbz == 2)
                            {
                                //保存发票信息  //add by zouchihua 2013-5-9诊疗卡不属于任何科室和医生
                                mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, _idTxyy, _ghck, _dnlsh, fph, cfzje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, Guid.Empty, "", NewJsid, bghpbz, Convert.ToInt32(cfg1079.Config), 0, 0, Convert.ToInt32(cfg1079.Config), yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlx, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                            }
                            else
                                //保存发票信息
                                mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, _idTxyy, _ghck, _dnlsh, fph, cfzje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, Guid.Empty, "", NewJsid, bghpbz, ghks, ghys, 0, ghks, yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlx, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                        }
                        else
                        {
                            decimal fp_zfje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zfje"]);
                            //计算每张发票的支付金额
                            if (Convert.ToDecimal(dset.Tables[0].Rows[X]["ybzf"]) == 0)
                                fp_zfje = fp_zfje - (dset.Tables[0].Rows[X]["groupid"].ToString() == "挂号费" ? ybzf : 0);//Modify By Zj 2012-12-26 手工输入的医保支付 在存储过程里无法计算 所以这里的自付金额要减去医保支付

                            decimal fp_zje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                            decimal fp_yhje = Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]);
                            decimal fp_srje = Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]);
                            //decimal fp_ybzhzf = ybzhzf > 0 && ybjjzf == 0 && ybbzzf == 0 ? fp_zfje : 0;
                            //decimal fp_ybjjzf = ybjjzf > 0 && ybzhzf == 0 && ybbzzf == 0 ? fp_zfje : 0;
                            //decimal fp_ybbzzf = ybbzzf > 0 && ybzhzf == 0 && ybjjzf == 0 ? fp_zfje : 0;
                            decimal fp_ylkzf = ylkzf > 0 ? fp_zfje : 0;
                            decimal fp_cwjz = cwjz > 0 ? fp_zfje : 0;
                            decimal fp_qfgz = qfgz > 0 ? fp_zfje : 0;
                            decimal fp_ybzf = dset.Tables[0].Rows[X]["groupid"].ToString() == "挂号费" ? ybzf : 0;
                            decimal fp_xjzf = xjzf > 0 ? fp_zfje : 0;
                            decimal fp_zpzf = zpzf > 0 ? fp_zfje : 0;
                            //add by zouchihua 2013-3-28 设置卡号费的执行科室（0按照之前方式 大于0表示卡费执行科室） 
                            if (bghpbz == 2)
                            {
                                //add by zouchihua 2013-5-9诊疗卡不属于任何科室和医生
                                //保存发票信息
                                mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, _idTxyy, _ghck, _dnlsh, fph, fp_zje, fp_ybzf, 0, 0, fp_ylkzf, fp_yhje, fp_cwjz, fp_qfgz, fp_xjzf, fp_zpzf, fp_srje, Guid.Empty, "", NewJsid, bghpbz, Convert.ToInt32(cfg1079.Config), 0, 0, Convert.ToInt32(cfg1079.Config), yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlxid, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                            }
                            else
                                mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, _idTxyy, _ghck, _dnlsh, fph, fp_zje, fp_ybzf, 0, 0, fp_ylkzf, fp_yhje, fp_cwjz, fp_qfgz, fp_xjzf, fp_zpzf, fp_srje, Guid.Empty, "", NewJsid, bghpbz, ghks, ghys, 0, ghks, yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlxid, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                            if (err_code != 0) throw new Exception(err_text);

                        }

                        //发票明细
                        decimal fpje = 0;
                        DataRow[] rows = dset.Tables[1].Select("groupid = '" + groupid + "'");
                        //保存发票明细项目 Begin
                        for (int i = 0; i <= rows.Length - 1; i++)
                        {
                            mz_sf.SaveFpmx(NewFpid, Convertor.IsNull(rows[i]["code"], "0"), Convertor.IsNull(rows[i]["item_name"], "0"), Convert.ToDecimal(rows[i]["je"]), 0, out err_code, out err_text, InstanceForm.BDatabase);
                            if (err_code != 0) throw new Exception(err_text);
                            fpje = fpje + Convert.ToDecimal(rows[i]["je"]);
                        }
                        //Modify by jchl
                        dset.Tables[0].Rows[X]["zje"] = "0";
                        dset.Tables[0].Rows[X]["srje"] = "0";

                        if (fpje != Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]) - (Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]))) throw new Exception("插入发票明细时出错,金额不等于发票总额");
                        //保存发票明细项目 End

                        //保存发票统计大项目 Begin
                        decimal tjxmje = 0;
                        DataRow[] tjdxmrows = dset.Tables[3].Select("groupid = '" + groupid + "' ");
                        for (int i = 0; i <= tjdxmrows.Length - 1; i++)
                        {
                            //Modify by jchl
                            tjdxmrows[i]["je"] = "0";

                            mz_sf.SaveFpdxmmx(NewFpid, Convertor.IsNull(tjdxmrows[i]["code"], "0"), Convertor.IsNull(tjdxmrows[i]["item_name"], "0"), Convert.ToDecimal(tjdxmrows[i]["je"]), 0, out err_code, out err_text, InstanceForm.BDatabase);
                            if (err_code != 0) throw new Exception(err_text);
                            tjxmje = tjxmje + Convert.ToDecimal(tjdxmrows[i]["je"]);
                        }
                        if (tjxmje != Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]) - (Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]))) throw new Exception("插入发票明细时出错,金额不等于发票总额");
                        //保存发票统计大项目 End

                        //更新医保结算表的收费信息
                        //if (yb.isgh == true && groupid == "挂号费")
                        //{
                        //    ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yb.ybjklx);
                        //    bool bok = ybjk.UpdateJsmx(brxxid, NewGhxxid, 0, jsxx.HisJsdid, NewFpid, fph, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                        //    if (bok == false) throw new Exception("更新本地医保结算明细表时没有成功");
                        //}
                        dset.Tables[0].Rows[X]["fph"] = fph.ToString();
                        dset.Tables[0].Rows[X]["fpid"] = NewFpid;

                        //更新处方状态
                        int Nrows = 0;
                        mz_cf.UpdateCfsfzt("('" + ssCfid[X] + "')", _idTxyy, _nameTxyy, djsj, _ghck, _dnlsh, fph, NewFpid, out Nrows, out err_code, out err_text, InstanceForm.BDatabase);
                        if (Nrows != 1) throw new Exception(err_text);
                        UpdateCfs = UpdateCfs + Nrows;
                    }
                    #endregion

                    //判断处方更新张数和实际分组张数是否一样
                    if (UpdateCfs != dset.Tables[0].Rows.Count)
                        throw new Exception("更新处方表张数" + UpdateCfs + "张,分组处方张数" + dset.Tables[0].Rows.Count + "张.请检查处方状态或刷新处方再试");

                    //更新发票领用表的当前发票号码
                    if (cfg1046.Config == "1")
                    {
                        //if (Convertor.IsNull(txthtdw.Tag, "0") != "0" && txthtdw.Tag.ToString() != "" && cfg1114.Config == "0") { }//add by jiangzf 如果是合同单位病人，并且参数1114=0，则不需要获取发票号
                        //if (cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1") { }
                        //else
                        mz_sf.UpdateDqfph(new Guid(tbfp.Rows[0]["fpid"].ToString()), tbfp.Rows[0]["fph"].ToString().Trim(), tbfp.Rows[tbfp.Rows.Count - 1]["fph"].ToString().Trim(), out Msg, InstanceForm.BDatabase);
                    }

                    //更新卡余额和累计消息金额
                    if (cwjz > 0)
                        readcard.UpdateKye(cwjz, InstanceForm.BDatabase);

                    //string dd = Convertor.IsNull(butqh.Tag, "");
                    ////更新预约取号状态
                    //if (new Guid(Convertor.IsNull(butqh.Tag, Guid.Empty.ToString())) != Guid.Empty)
                    //    mz_ghxx.UpateYyghxx(new Guid(Convertor.IsNull(butqh.Tag, Guid.Empty.ToString())), NewGhxxid, djsj, InstanceForm.BDatabase);

                    InstanceForm.BDatabase.CommitTransaction();

                    //待优化【未同步成功直接抛出异常】
                    string ghxxid = NewGhxxid.ToString();
                    try
                    {
                        KeyValuePair<bool, string> ret = Register(ghxxid);
                        if (!ret.Key)
                        {
                            WriteSyncLog(ghxxid, "n2oBrGhxx.HIS", ret.Value);
                        }
                        if (ret.Key)   //Register
                        {
                            ret = EmrRegister(ghxxid.ToString());
                        }
                    }
                    catch
                    { }

                    //同步老系统划价表
                    try
                    {
                        KeyValuePair<bool, string> ret = SyncOldHisHjInfo(ghxxid);
                        if (!ret.Key)
                        {
                            MessageBox.Show("同步产生划价费用失败", "提示");
                            return;
                        }
                    }
                    catch { }

                    //_new_brxx_kxx = null;//挂号成功后将病人信息和新卡信息置为Null
                    this.Tag = Guid.Empty; //加个清空
                    MessageBox.Show("操作成功");
                    this.Close();//操作完成   关闭界面
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message);
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;

                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("挂号登记出现异常!" + ea.Message);
            }
            finally
            {
                txtkh.Focus();
                txtkh.SelectAll();
            }
        }

        public KeyValuePair<bool, string> EmrRegister(string ghxxid)
        {
            try
            {
                TrasenWs.TrasenWS ws = new ts_mz_txyy.TrasenWs.TrasenWS();

                ws.Url = "http://192.168.0.90:88/TrasenWS.asmx";
                //ws.Url = "http://192.168.0.90:89/TrasenWS.asmx";

                string outXml = ws.GetXml("GetMzGh.EMR", ghxxid);
                if (string.IsNullOrEmpty(outXml))
                    return new KeyValuePair<bool, string>(false, "GetXml方法没有返回值");
                string ret = ws.ExeWebService("GetMzGh.EMR", outXml);
                return new KeyValuePair<bool, string>(false, ret);
            }
            catch (Exception err)
            {
                return new KeyValuePair<bool, string>(false, err.ToString());
            }
        }

        /// <summary>
        /// 住院欠费检查
        /// </summary>
        /// <param name="brxxid"></param>
        /// <param name="xm"></param>
        private bool CheckZyFee(Guid brxxid, string xm)
        {
            //add by wangzhi 2010-10-05
            //增加判断病人是否曾经住院并且欠费出院，如果有，给出提示
            string ssq = "";
            SystemCfg cfg = new SystemCfg(1044);
            if (cfg.Config.Trim() == "1")
            {
                SystemCfg cfg1045 = new SystemCfg(1045);
                if (cfg1045.Config.Trim() == "1")
                {

                    ssq = @"select top 1 b.patient_id,lack_fee,discharge_bdate,discharge_edate
                    from zy_discharge a ,zy_inpatient b 
                    where a.inpatient_id=b.inpatient_id
                        and a.ntype=2 and a.cancel_bit=0 and lack_fee>0
                        and patient_id = '" + brxxid.ToString() + "' order by a.discharge_date desc";
                }
                else if (cfg1045.Config.Trim() == "2")
                {
                    ssq = @"select top 1 b.patient_id,lack_fee,discharge_bdate,discharge_edate
                    from zy_discharge a ,zy_inpatient b ,yy_brxx c
                    where a.inpatient_id=b.inpatient_id and b.patient_id=c.brxxid
                        and a.ntype=2 and a.cancel_bit=0 and lack_fee>0
                        and c.brxm = '" + xm + "' order by a.discharge_date desc";
                }
                DataRow drZyqf = InstanceForm.BDatabase.GetDataRow(ssq);
                if (drZyqf != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("该病人曾于");
                    sb.Append(Convert.ToDateTime(drZyqf["discharge_bdate"]).ToString("yyyy-MM-dd HH:mm;ss"));
                    sb.Append("～");
                    sb.Append(Convert.ToDateTime(drZyqf["discharge_edate"]).ToString("yyyy-MM-dd HH:mm;ss"));
                    sb.Append("在本院住院");
                    sb.Append(",并且以欠费出院方式出院（欠费：" + Convert.ToDecimal(drZyqf["lack_fee"]).ToString() + "元）");
                    sb.Append("\r\n");
                    sb.Append("是否继续挂号？");

                    if (MessageBox.Show(sb.ToString(), "欠费病人", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return false;
                    else
                        return true;
                }
            }
            return true;
            //end add
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 22)
            {
                txtkh.Text = "";
                e.Handled = true;
                return;

            }

            if ((int)e.KeyChar != 13)
            {
                _isCreateNewCard = false; //Add By tany2010-09-18
                return;
            }

            if (txtkh.Text.Trim() == "")
            {
                //Add By tany2010-09-18
                _isCreateNewCard = false;
                if (sender != null)
                {
                    SendKeys.Send("{TAB}");
                }
                return;
            }
            if (cfg1060.Config == "0")//当参数1060 等于0  不允许卡中包含英文字母的时候验证卡的数字型 Add By Zj 2012-05-10
            {
                if (!Convertor.IsNumeric(txtkh.Text.Trim()))
                {
                    MessageBox.Show("请输入正确的卡号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtkh.SelectAll();
                    return;
                }
            }


            int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
            txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase);

            txtkh.Text = ToDBC(txtkh.Text);
            txtxm.Text = "";
            cmbxb.Text = "";
            txtnl.Text = "";
            cmbDW.SelectedIndex = 0;
            txtgrlxfs.Text = "";
            txtjtdz.Text = "";

            //string klx = cmbklx.SelectedValue;

            this.Tag = Guid.Empty.ToString();
            //使用左连接。因为有些卡登记了但没有病人信息，只有持卡人信息
            string ssq = @"select *,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,brlx from YY_KDJB a inner join YY_BRXX b 
                            on a.brxxid=b.brxxid where a.klx=" + klx + " and a.kh='" + txtkh.Text + "'  and a.ZFBZ=0 ";
            tbk = InstanceForm.BDatabase.GetDataTable(ssq);
            //if (tbk.Rows.Count == 0) //没有找到病人信息和卡信息
            //{
            //    MessageBox.Show("没有找到卡信息，请确认卡号是否正确或卡没有作废");
            //    return;
            //}



            if (tbk.Rows.Count == 0) //没有找到病人信息和卡信息
            {
                if (klx != 2)
                {
                    MessageBox.Show(klx + "：请点击 无卡预约 进行建档操作！");
                    return;
                }

                if (!_zdJd)
                {
                    MessageBox.Show(klx + "：请点击 无卡预约 进行建档操作！");
                    return;
                }

                _zdJd = false;

                this.Tag = Guid.Empty.ToString();
                //if (!Isyy) //Add by zp  2014-03-26 如果是无卡预约的 则不需要再填写一次病人信息了
                //{
                //}
                _menuTag.Function_Name = "ys";

                //Modify by jchl
                //ts_mz_kgl.Frmbrkdj f = new ts_mz_kgl.Frmbrkdj(_menuTag, "病人信息登记", _mdiParent, Guid.Empty, Guid.Empty, InstanceForm.BDatabase);
                //f.txtkh.Text = txtkh.Text;
                //f.txtbrxm.Text = "未写名";
                //f.cmbklx.SelectedValue = cmbklx.SelectedValue;

                ////add by wangzhi 2010-10-27
                ////设置病人登记对话框为延时保存病人信息，在点击挂号后一并保存
                //f.DelaySave = false;
                //if (f.ShowDialog() == DialogResult.Cancel)
                //{
                //    return;
                //}

                ////建档后再查询新建档病人信息
                //ssq = string.Format(@"UPDATE YY_KDJB set lxtId='{0}' where KH='{1}' and KLX='{2}' ", txtkh.Text, txtkh.Text, klx);
                //int iUp = InstanceForm.BDatabase.DoCommand(ssq);

                //if (iUp <= 0)
                //{
                //    MessageBox.Show("未更新到本地His的lxtid", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}


                //Assembly assembly = Assembly.Load("Trasen.HospPatient");
                //Type type = assembly.GetType("Trasen.HospPatient.FrmAddPatient");
                //MethodInfo method = type.GetMethod("ShowDialog", new Type[0]);
                //object frm = type.Assembly.CreateInstance(type.FullName, true, BindingFlags.CreateInstance, null, new object[] { klx, txtkh.Text, true }, null, null); //Activator.CreateInstance(type); //
                //method.Invoke(frm, null);//弹框

                //int itype = -1;
                //FieldInfo fieidinfoCardType = type.GetField("_cardType", BindingFlags.Public | BindingFlags.Static);
                //object _cardType = fieidinfoCardType.GetValue(null);

                //string cardNo = "";
                //FieldInfo fieidinfoCardNo = type.GetField("_cardNo", BindingFlags.Public | BindingFlags.Static);
                //object _cardNo = fieidinfoCardNo.GetValue(null);

                //int iState = -1;
                //FieldInfo fieidinfoState = type.GetField("_state", BindingFlags.Public | BindingFlags.Static);
                //object _state = fieidinfoState.GetValue(null);

                //string iType = _state.ToString().Trim();

                //if (iType == "-1")
                //{
                //    //失败
                //    return;
                //}
                //else if (iType == "0")
                //{
                //    //成功
                //    txtkh.Text = _cardNo.ToString().Trim();
                //    cmbklx.SelectedValue = _cardType.ToString().Trim();
                //    klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                //}
                //else if (iType == "1")
                //{
                //    //v2出错    v3成功   重发代码处理
                //    return;
                //}
                FrmAddPat frm = new FrmAddPat();
                frm.ShowDialog();

                if (frm._bSuc)
                {
                    //成功
                    txtkh.Text = frm._CardNo;
                    cmbklx.SelectedValue = "2";
                    klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                }
                else
                {
                    return;
                }

                //同步老系统id卡的病人信息
                try
                {
                    KeyValuePair<bool, string> ret = syncOldPatInfo(txtkh.Text);
                    if (!ret.Key)
                    {
                        MessageBox.Show(txtkh.Text + "同步老系统id卡的病人信息失败", "提示");
                        return;
                    }
                }
                catch { }

                //建档后再查询新建档病人信息
                ssq = @"select *,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,brlx from YY_KDJB a inner join YY_BRXX b 
                            on a.brxxid=b.brxxid where a.klx=" + klx + " and a.kh='" + txtkh.Text + "'  and a.ZFBZ=0 ";
                tbk = InstanceForm.BDatabase.GetDataTable(ssq);

                if (tbk.Rows.Count == 0) //没有找到病人信息和卡信息
                {
                    MessageBox.Show("没有找到卡信息，请确认卡号是否正确或卡没有作废");
                    return;
                }

                string newBrxxid = Convertor.IsNull(tbk.Rows[0]["brxxid"], Guid.Empty.ToString());

                //ssq = string.Format(@"update YY_BRXX set DJY={0} where BRXXID='{1}' ", _idTxyy, newBrxxid);
                //iUp = InstanceForm.BDatabase.DoCommand(ssq);

                //ssq = string.Format(@"update YY_KDJB set DJY={0} where BRXXID='{1}' ", _idTxyy, newBrxxid);
                //iUp = InstanceForm.BDatabase.DoCommand(ssq);
            }

            txtxm.Enabled = false;
            cmbxb.Enabled = false;
            txtnl.Enabled = false;
            cmbDW.Enabled = false;
            txtgrlxfs.Enabled = false;
            txtjtdz.Enabled = false;

            if (tbk.Rows.Count > 1)
            {
                MessageBox.Show("找到多张同时有效的卡,请和系统管理员联系");
                return;
            }
            if (Convert.ToInt16(tbk.Rows[0]["sdbz"]) == 1)
            {
                MessageBox.Show("这张卡已被锁定,不能消费.请先激活", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Convertor.IsNull(tbk.Rows[0]["lxtId"], "").Trim()))
            {
                MessageBox.Show("该卡未生成老系统id,不能使用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //txtkh.Text = Convertor.IsNull(tbk.Rows[0]["lxtId"], "").Trim();
            //cmbklx.SelectedIndex = 1;

            lblkye.Text = tbk.Rows[0]["kye"].ToString();
            txtxm.Text = Convertor.IsNull(tbk.Rows[0]["brxm"], "");
            if (txtxm.Text.Trim() == "")
                txtxm.Text = Convertor.IsNull(tbk.Rows[0]["CKRXM"], "");
            txtgrlxfs.Text = Convertor.IsNull(tbk.Rows[0]["BRLXFS"], "");
            txtjtdz.Text = Convertor.IsNull(tbk.Rows[0]["JTDZ"], "");
            cmbxb.Text = Convertor.IsNull(tbk.Rows[0]["性别"], "");
            //lblgzdw.Text = Convertor.IsNull(tbk.Rows[0]["gzdw"], "");
            //cmbbrlx.SelectedValue = Convertor.IsNull(tbk.Rows[0]["brlx"], "");

            //添加优惠方案
            //AddYhlx();

            if (Convertor.IsNull(tbk.Rows[0]["csrq"], "") != "")
            {
                txtnl.Text = DateManager.DateToAge(Convert.ToDateTime(tbk.Rows[0]["csrq"]), InstanceForm.BDatabase).AgeNum.ToString();
                dtpcsrq.Value = Convert.ToDateTime(tbk.Rows[0]["csrq"]);
                //AutoSelectGhjb();
            }
            this.Tag = Convertor.IsNull(tbk.Rows[0]["brxxid"], Guid.Empty.ToString());

            if (Convert.ToInt16(tbk.Rows[0]["zbbz"]) == 1)
            {
                txtks.Text = Fun.SeekDeptName(Convert.ToInt32(tbk.Rows[0]["zbks"]), InstanceForm.BDatabase);
                txtks.Tag = tbk.Rows[0]["zbks"].ToString();
                cmbghjb.SelectedValue = tbk.Rows[0]["ZBJB"].ToString() == "0" ? "1" : tbk.Rows[0]["ZBJB"].ToString();
                txtys.Text = Fun.SeekEmpName(Convert.ToInt32(tbk.Rows[0]["ZBYS"]), InstanceForm.BDatabase);
                txtys.Tag = tbk.Rows[0]["ZBYS"].ToString();
            }

            txtks.Focus();
            txtks_KeyPress(txtks, new KeyPressEventArgs((char)(Keys.Space)));
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


        /// <summary>
        /// 回车跳至下一个文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                if (control.Name == "txtnl" && cfgnl.Config == "1" && control.Text.Trim() == "")
                {
                    return;
                }
                if (control.Name == "cmbDW")
                {
                    if (txtgrlxfs.Enabled == true) { txtgrlxfs.Focus(); return; }
                    if (txtjtdz.Enabled == true) { txtjtdz.Focus(); return; }
                    if (txtks.Enabled == true)
                    {
                        if (cfgpb.Config == "1" && cfgpbys.Config == "1" && txtys.Enabled == true)
                            txtys.Focus();
                        else
                            txtks.Focus();
                        return;
                    }
                }
                if (control.Name == "txtjtdz")
                {
                    if (txtks.Enabled == true) txtks.Focus(); return;
                }
                if (control.Name == "txtxm" && control.Text.Trim() == "")
                    return;

                SendKeys.Send("{TAB}");
                return;
            }
        }

        public KeyValuePair<bool, string> Register(string ghxxid)
        {
            try
            {
                TrasenWs.TrasenWS ws = new TrasenWs.TrasenWS();

                ws.Url = "http://192.168.0.90:88/TrasenWS.asmx";
                //ws.Url = "http://192.168.0.90:89/TrasenWS.asmx";

                string outXml = ws.GetXml("n2oBrGhxx.HIS", ghxxid);
                if (string.IsNullOrEmpty(outXml))
                    return new KeyValuePair<bool, string>(false, "GetXml方法没有返回值");
                string ret = ws.ExeWebService("n2oBrGhxx.HIS", outXml);
                if (string.IsNullOrEmpty(ret))
                    return new KeyValuePair<bool, string>(false, "ExeWebService方法没有返回值");
                else if (ret.ToString().IndexOf("保存成功") < 0)
                    return new KeyValuePair<bool, string>(false, ret.ToString());

                return new KeyValuePair<bool, string>(true, ret);
            }
            catch (Exception err)
            {
                return new KeyValuePair<bool, string>(false, err.ToString());
            }
        }

        /// <summary>
        /// 弹性预约
        /// </summary>
        /// <param name="ghxxid"></param>
        /// <returns></returns>
        public KeyValuePair<bool, string> SyncOldHisHjInfo(string ghxxid)
        {
            try
            {
                TrasenWs.TrasenWS ws = new TrasenWs.TrasenWS();

                ws.Url = "http://192.168.0.90:88/TrasenWS.asmx";
                //ws.Url = "http://192.168.0.90:89/TrasenWS.asmx";

                string outXml = ws.GetXml("syncHjInfo.HIS", ghxxid);
                if (string.IsNullOrEmpty(outXml))
                    return new KeyValuePair<bool, string>(false, "GetXml方法没有返回值");
                string ret = ws.ExeWebService("syncHjInfo.HIS", outXml);

                if (string.IsNullOrEmpty(ret))
                    return new KeyValuePair<bool, string>(false, "ExeWebService方法没有返回值");
                else if (ret.ToString().IndexOf("保存成功") < 0)
                    return new KeyValuePair<bool, string>(false, ret.ToString());

                return new KeyValuePair<bool, string>(true, ret);
            }
            catch (Exception err)
            {
                return new KeyValuePair<bool, string>(false, err.ToString());
            }
        }

        /// <summary>
        /// 弹性预约
        /// </summary>
        /// <param name="ghxxid"></param>
        /// <returns></returns>
        public KeyValuePair<bool, string> syncOldPatInfo(string kh)
        {
            try
            {
                TrasenWs.TrasenWS ws = new TrasenWs.TrasenWS();

                ws.Url = "http://192.168.0.90:88/TrasenWS.asmx";
                //ws.Url = "http://192.168.0.90:89/TrasenWS.asmx";

                string outXml = ws.GetXml("syncOldPatInfo.HIS", kh);
                if (string.IsNullOrEmpty(outXml))
                    return new KeyValuePair<bool, string>(false, "GetXml方法没有返回值");
                string ret = ws.ExeWebService("syncOldPatInfo.HIS", outXml);

                if (string.IsNullOrEmpty(ret))
                    return new KeyValuePair<bool, string>(false, "ExeWebService方法没有返回值");
                else if (ret.ToString().IndexOf("保存成功") < 0)
                    return new KeyValuePair<bool, string>(false, ret.ToString());

                return new KeyValuePair<bool, string>(true, ret);
            }
            catch (Exception err)
            {
                return new KeyValuePair<bool, string>(false, err.ToString());
            }
        }

        internal static DataTable GetHealthCardInfo(string RegisterRecordId)
        {
            DataTable tb = null;
            try
            {
                string sql = string.Format(@"select sgbh,lxtid,a.GHKS as syks,a.DJY as czy,a.GHJE,a.jkkh from MZ_GHXX a 
                                                left join YY_KDJB b on a.BRXXID = b.BRXXID and a.KDJID = b.KDJID 
                                                where GHXXID = '{0}'", RegisterRecordId);
                tb = InstanceForm.BDatabase.GetDataTable(sql);
            }
            catch
            {

            }
            return tb;
        }



        public static void WriteSyncLog(string ghxxid, string syncType, string errInfo)
        {
            try
            {
                string sql = @"insert into MZ_DATASYNCLOG(InputVal,syncType,errorInfo,createTime,state) 
            values('{0}','{1}','{2}','{3}',0)";
                object[] param = { ghxxid, syncType, errInfo, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
                InstanceForm.BDatabase.DoCommand(string.Format(sql, param));
            }
            catch
            {
            }
        }

        private void btnGetKh_Click(object sender, EventArgs e)
        {
            //TrasenWs.TrasenWS ws = new ts_mz_txyy.TrasenWs.TrasenWS();

            //ws.Url = "http://192.168.0.90:88/TrasenWS.asmx";
            ////ws.Url = "http://192.168.0.90:89/TrasenWS.asmx";

            //string outXml = ws.GetXml("syncDjh.HIS", "123").Trim();

            string outXml = "000000000000";

            long iret = 0;

            _zdJd = true;

            if (long.TryParse(outXml, out iret))
            {
                cmbklx.SelectedValue = "2";

                txtkh.Text = iret + "";

                txtkh_KeyPress(txtkh, new KeyPressEventArgs((char)13));
            }

        }

    }

    internal delegate string[] func(string ghxxid);
}