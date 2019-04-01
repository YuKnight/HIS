using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using YpClass;
using TrasenFrame.Forms;
using ts_HospData_Share;

namespace ts_mz_class
{
    public partial class Frmyssyk : Form
    {
        public string flag_fp;

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public bool Bok = false;//是否收银
        public string brxxid, ghxxid, mzh, kh;
        public DataTable tbcf = new DataTable();//处方头
        public DataTable tbxm = new DataTable();//处方明细
        public SystemCfg pssf = new SystemCfg(1019);//皮试是否允许收费
        public SystemCfg cfg1063 = new SystemCfg(1063);// 是否自动确费 Add By Zj 2012-07-02
        public SystemCfg cfg3058 = new SystemCfg(3058);//门诊医生站扣费设置收款员工号（请设置改工号为自助设备）
        /// <summary>
        /// //门诊医生站扣费是否只允许刷卡扣费 0否 1是 默认为0
        /// </summary>
        public SystemCfg cfg3513 = new SystemCfg(3513);
        private SystemCfg cfgsfy = new SystemCfg(3016);
        public SystemCfg cfg1096 = new SystemCfg(1096);
        public RelationalDatabase BDatabase;//数据库连接
        private string Bview = ApiFunction.GetIniString("划价收费", "发票预览", Constant.ApplicationDirectory + "//ClientWindow.ini");//发票预览

        public Frmyssyk(string _brxxid, string _ghxxid, string _mzh, string _kh, RelationalDatabase _BDatabase, MenuTag menuTag, string chineseName, Form mdiParent)
        {
            try
            {
                brxxid = _brxxid;
                ghxxid = _ghxxid;
                mzh = _mzh;
                kh = _kh;
                BDatabase = _BDatabase;
                _menuTag = menuTag;
                _chineseName = chineseName;
                _mdiParent = mdiParent;
                InitializeComponent();

            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message + " 1");
            }

        }

        private void butquit_Click(object sender, EventArgs e)
        {
            GetBrxx(ghxxid, mzh, kh);
        }

        private void GetBrxx(string ghxxid, string mzh, string _kh)
        {
            try
            {
                //                string sql = @"select b.BRXM 姓名,(select klxmc from JC_KLX where KLX=c.KLX) 卡类型,c.KLX,
                //                (select name from JC_BRLX where CODE=b.BRLX) 病人类型,b.BRLX, c.KH 卡号,c.KYE 卡余额,a.BLH 门诊号,
                //                 a.ghxxid,b.brxxid from MZ_GHXX a  
                //                 left join YY_BRXX b on a.BRXXID=b.BRXXID 
                //                 left join YY_KDJB c on a.KDJID=c.KDJID where";
                /*Modify By zp 2014-01-09 */
                string sql = @"select b.BRXM 姓名,d.KLXMC 卡类型,c.KLX,
                (select name from JC_BRLX where CODE=b.BRLX) 病人类型,b.BRLX, c.KH 卡号,c.KYE 卡余额,a.BLH 门诊号, a.ghxxid,b.brxxid 
                from MZ_GHXX a  
                left join YY_BRXX b on a.BRXXID=b.BRXXID 
                left join YY_KDJB c on a.KDJID=c.KDJID 
                inner join JC_KLX d on c.KLX=d.KLX where ";
                if (ghxxid != "")
                    sql += " a.ghxxid='" + ghxxid + "' and";
                if (mzh != "")
                    sql += " a.blh='" + mzh + "' and";
                if (_kh != "")
                    sql += " c.KH='" + _kh + "' and";
                sql = sql.Substring(0, sql.Length - 3);

                DataTable tbxx = BDatabase.GetDataTable(sql);
                DataRow row = null;
                if (tbxx.Rows.Count > 0)
                    row = tbxx.Rows[0];
                ShowPatientInfo(row);

                if (!string.IsNullOrEmpty(_kh))//如果卡号为空则不显示金额
                {
                    brxxid = row["brxxid"].ToString();
                    ghxxid = row["ghxxid"].ToString();
                    #region 添加未收费处方
                    DataTable tb = mz_sf.Select_Wsfcf(0, new Guid(brxxid), new Guid(ghxxid), 0, 0, Guid.Empty, BDatabase);
                    if (pssf.Config != "1")//如果启用参数 没标示阴阳性之前 只显示皮试液的钱
                    {
                        DataRow[] dr = tb.Select("(皮试标志=0 or 皮试标志=2) and 项目来源=1");
                        string str = "";
                        DataView dv = tb.DefaultView;
                        for (int i = 0; i < dr.Length; i++)
                        {
                            if (str != "") str += " and ";
                            str += "HJID<>'" + dr[i]["hjid"].ToString() + "'";
                        }
                        dv.RowFilter = str;
                        tbcf = dv.ToTable();
                    }
                    else //显示正常费用 
                        tbcf = tb;
                    //求发票分类明细汇总
                    string[] GroupbyField1 = { "HJID", "科室ID", "医生ID", "执行科室ID", "住院科室ID", "项目来源", "剂数", "划价日期", "hjy", "划价窗口", "审核状态", "执行科室", "开单科室", "划价员" };
                    string[] ComputeField1 = { "金额", "hjmxid" };
                    string[] CField1 = { "sum", "count" };
                    //控制医生只能够收自己的处方
                    string ss = "医生ID=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and 科室ID=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    xcset1.TsDataTable = tbcf;
                        tbxm = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, ss);
                    dataGridView1.DataSource = tbxm;
                    decimal zje = 0;
                    for (int i = 0; i < tbxm.Rows.Count; i++)
                    {
                        zje += Convert.ToDecimal(tbxm.Rows[i]["金额"]);
                    }
                    decimal dzje = System.Decimal.Round(zje, 2);
                    lblzje.Text = dzje.ToString();
                }
                    #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误!错误代码:J2 原因" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ShowPatientInfo(DataRow row)
        {
            txtmzh.Text = row["门诊号"].ToString();
            txtname.Text = row["姓名"].ToString();
            if (cfg3513.Config.Trim() == "0")
                txtkh.Text = row["卡号"].ToString();

            lblkye.Text = Convertor.IsNull(row["卡余额"], "0");
            cmbklx.SelectedValue = row["klx"].ToString();
        }

        private void Frmyssyk_Activated(object sender, EventArgs e)
        {
            //txtcwjz.Focus();
        }

        private void Frmyssyk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && butok.Enabled == true)
            {
                butok_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
                butquit_Click(sender, e);
        }


        private void Frmyssyk_Load(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.AutoGenerateColumns = false;
                //AddPresc(tbcf);
                #region 绑定卡类型
                FunAddComboBox.AddKlx(false, Convert.ToInt32(cmbklx.SelectedValue), cmbklx);
                cmbklx.DisplayMember = "KLXMC";
                cmbklx.ValueMember = "KLX";
                #endregion

                //Add By zp 2013-08-30
                string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (sbxh != "")
                {
                    ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                    if (ReadCard != null)
                        ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
                }
                if (cfg3513.Config.Trim() == "0")
                    GetBrxx(ghxxid, mzh, kh);
                else
                {
                    GetBrxx(ghxxid, mzh, "");
                    txtkh.Text = "";
                    lblkye.Text = "0";

                }
                txtkh.Focus(); //Add by zp 2013-12-31 默认为卡号文本框设置焦点
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message + " 2");
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Bok = false;
            this.Close();
        }
        /// <summary>
        /// 医生站扣费确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butok_Click(object sender, EventArgs e)
        {
            string dqcfzje = lblzje.Text;
            if (Convert.ToDecimal(dqcfzje) == 0 || Convert.ToDecimal(dqcfzje) <= 0)
            {
                MessageBox.Show("总金额为0元，请选择处方收费!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SystemCfg sss;
            try
            {
                //门诊处方收费时是否立即发药
                sss = new SystemCfg(8013);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb == null)
            {
                MessageBox.Show("未获取到需扣费的处方记录!", "提示");
                return;
            }
            DataRow[] dr = tb.Select("选择<>true");
            string where = "";
            for (int i = 0; i < dr.Length; i++)
            {
                if (where != "") where += " and ";
                where += "HJID<>'" + dr[i]["hjid"].ToString() + "'";
            }
            //求发票分类明细汇总
            string[] GroupbyField1 ={ "HJID", "科室ID", "医生ID", "执行科室ID", "住院科室ID", "项目来源", "剂数", "划价日期", "hjy", "划价窗口", "审核状态", "执行科室", "开单科室", "划价员" };
            string[] ComputeField1 ={ "金额", "hjmxid" };
            string[] CField1 ={ "sum", "count" };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = tbcf;
            tb = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, where);


            string ssql = "";
            //发票结果集
            DataSet dset = null;
            //要收费的处方字符串
            string shjid = "('";
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                shjid += Convert.ToString(tb.Rows[i]["hjid"]) + "','";
            shjid = shjid.Substring(0, shjid.Length - 2);
            shjid += ")";

            //收银金额
            decimal zje = 0;//总金额
            decimal yhje = 0;//优惠金额
            decimal srje = 0;//舍入金额
            decimal cwjz = 0;//财务记帐
            decimal qfgz = 0;//欠费挂帐
            int fpzs = 0;//发票张数
            Guid _hjid = Guid.Empty;
            int _xmly = 0;
            //时间
            string sDate = DateManager.ServerDateTimeByDBType(BDatabase).ToString();
            //卡属性
            int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
            string kh = txtkh.Text.Trim();
            mz_card card = new mz_card(klx, BDatabase);
            //返回变量
            int err_code = -1;
            string err_text = "";
            //读取病人卡余额
            ReadCard readcard = new ReadCard(klx, txtkh.Text.Trim(), BDatabase);
            decimal ye = readcard.kye;
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

            if (txtkh.Text.Trim() != "" && readcard.kdjid == Guid.Empty)
            {
                MessageBox.Show("没有找到卡信息，请确认卡是否输入正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region 处方审核
            try
            {
                //处方审核控制
                //医保病人处方需要审核
                SystemCfg syscfg1 = new SystemCfg(1042);
                if (syscfg1.Config == "1")
                {
                    DataRow[] rows = tb.Select(" 审核状态=0 or 审核状态=2");
                    if (rows.Length > 0)
                    {
                        MessageBox.Show("该病人有处方未通过审核,不能收费", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //所有病人的药品处方需要审核
                SystemCfg syscfg2 = new SystemCfg(1043);
                if (syscfg2.Config == "1")
                {
                    DataRow[] rows = tb.Select(" (审核状态=0 or 审核状态=2) and 项目来源=1");
                    if (rows.Length > 0)
                    {
                        MessageBox.Show("该病人有药品处方未通过审核,不能收费", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 验证是否更改处方
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                Guid yz_hjid = new Guid(Convertor.IsNull(tb.Rows[i]["hjid"], Guid.Empty.ToString()));
                decimal yz_cfje = Math.Round(Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["金额"], "0")), 2);
                ssql = "select * from mz_hjb where hjid='" + yz_hjid + "'";
                DataTable yz_tb = BDatabase.GetDataTable(ssql);
                if (yz_tb.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(yz_tb.Rows[0]["cfje"]) != yz_cfje)
                    {
                        MessageBox.Show("处方可能已更改,请重新刷新数据后重试！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (yz_tb.Rows[0]["bsfbz"].ToString() == "1")
                    {
                        MessageBox.Show("处方可能已收费,请重新刷新数据后重试！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("处方可能已删除,请刷新数据后重试！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            sDate = DateManager.ServerDateTimeByDBType(BDatabase).ToString();
            #region 获得发票结果集
            try
            {
                //返回发票相关信息
                dset = mz_sf.GetFpResult(shjid, 0, 0, 0, Guid.Empty, Guid.Empty, TrasenFrame.Forms.FrmMdiMain.Jgbm, out err_code, out err_text, 0, BDatabase);
                //填写流水号,一张发票对应一个流水号
                for (int iFp = 0; iFp < dset.Tables[0].Rows.Count; iFp++)
                    dset.Tables[0].Rows[iFp]["dnlsh"] = Fun.GetNewDnlsh(BDatabase); 
                if (err_code != 0)
                {
                    MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }

                zje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));
                yhje = Convert.ToDecimal(dset.Tables[0].Compute("sum(yhje)", ""));
                srje = Convert.ToDecimal(dset.Tables[0].Compute("sum(srje)", ""));
                cwjz = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));
                fpzs = dset.Tables[0].Rows.Count; 

                if (ye < zje)
                {
                    MessageBox.Show("卡余额不足！请充值以后再扣费!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            #endregion
            try
            {
                sDate = DateManager.ServerDateTimeByDBType(BDatabase).ToString();
                //开始事务
                BDatabase.BeginTransaction();

                //#region 保处到处方表
                //decimal cfje = 0;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    //插入处方头
                    Guid _NewCfid = Guid.Empty;
                    string _mzh = txtmzh.Text.Trim();
                    _hjid = new Guid(Convertor.IsNull(tb.Rows[i]["hjid"], Guid.Empty.ToString()));
                    int _ksdm = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["科室id"], "0"));
                    int _ysdm = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["医生id"], "0"));
                    int _zxksdm = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["执行科室id"], "0"));
                    int _zyksdm = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["住院科室id"], "0"));
                    _xmly = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["项目来源"], "0"));
                    int _js = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["剂数"], "0"));
                    string _cfrq = tb.Rows[i]["划价日期"].ToString();
                    int _hjyid = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["hjy"], "0"));
                    string _hjyxm = Fun.SeekEmpName(_hjyid, BDatabase);
                    string _hjck = tb.Rows[i]["划价窗口"].ToString();
                    decimal _cfje = Math.Round(Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["金额"], "0")), 2); 
                    DataRow[] rows = tbcf.Select("HJID='" + _hjid + "' and 项目id>0"); 
                    long rowcount = Convert.ToInt32(tb.Rows[i]["HJMXID"]);
                    if (rowcount != rows.Length)
                        throw new Exception("分组处方时有" + rowcount + "行,插入处方时有" + rows.Length + "行.请检查处方状态或刷新处方再试"); 
                    if (rows.Length == 0) throw new Exception("没有找到处方明细,请和管理员联系");
                    mz_cf.SaveCf(Guid.Empty, new Guid(brxxid), new Guid(ghxxid), _mzh, _hjck, _cfje, _cfrq, _hjyid, _hjyxm, _hjck, _hjid, _ksdm, Fun.SeekDeptName(_ksdm, BDatabase), _ysdm, Fun.SeekEmpName(_ysdm, BDatabase), _zyksdm, _zxksdm, Fun.SeekDeptName(_zxksdm, BDatabase), 0, 0, _xmly, 0, _js, TrasenFrame.Forms.FrmMdiMain.Jgbm, out _NewCfid, out err_code, out err_text, BDatabase);
                    if (_NewCfid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                    //插处方明细表
                    for (int j = 0; j <= rows.Length - 1; j++)
                    {
                        int _tcid = Convert.ToInt32(Convertor.IsNull(rows[j]["套餐id"], "0"));
                        //如果是套餐则分解保存
                        if (_tcid > 0)
                        {
                            #region 如果是套餐则分解保存
                            DataRow[] tcrow = tbcf.Select("HJID='" + _hjid + "' and  套餐id=" + _tcid + " ");
                            if (tcrow.Length == 0) throw new Exception("查找套餐次数时出错，没有找到匹配的行");
                            _js = Convert.ToInt32(Convertor.IsNull(tcrow[0]["数量"], "0"));
                            DataTable Tabtc = mz_sf.Select_Wsfcf(0, Guid.Empty, new Guid(ghxxid), _tcid, _js, _hjid, BDatabase);
                            DataRow[] rows_tc = Tabtc.Select();
                            if (rows_tc.Length == 0) throw new Exception("没有找到套餐的明细");
                            for (int xx = 0; xx <= rows_tc.Length - 1; xx++)
                            {
                                Guid _NewCfmxid = Guid.Empty;
                                Guid _hjmxid = new Guid(Convertor.IsNull(rows_tc[xx]["hjmxid"], Guid.Empty.ToString()));
                                string _pym = Convertor.IsNull(rows_tc[xx]["拼音码"], "");
                                string _bm = Convertor.IsNull(rows_tc[xx]["编码"], "");
                                string _pm = Convertor.IsNull(rows_tc[xx]["项目名称"], "");
                                string _spm = Convertor.IsNull(rows_tc[xx]["商品名"], "");
                                string _gg = Convertor.IsNull(rows_tc[xx]["规格"], "");
                                string _cj = Convertor.IsNull(rows_tc[xx]["厂家"], "");
                                decimal _dj = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["单价"], "0"));
                                decimal _sl = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["数量"], "0"));
                                string _dw = Convertor.IsNull(rows_tc[xx]["单位"], "");
                                int _ydwbl = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["ydwbl"], "0"));
                                decimal _je = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["金额"], "0"));
                                string _tjdxmdm = Convertor.IsNull(rows_tc[xx]["统计大项目"], "");
                                long _xmid = Convert.ToInt64(Convertor.IsNull(rows_tc[xx]["项目id"], "0"));
                                //int _bpsyybz = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["皮试用药"], "0"));
                                int _bpsbz = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["皮试标志"], "0"));
                                //int _bmsbz = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["免试标志"], "0"));
                                decimal _yl = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["剂量"], "0"));
                                string _yldw = Convertor.IsNull(rows_tc[xx]["剂量单位"], "");
                                int _yldwid = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["剂量单位id"], "0"));
                                int _dwlx = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["dwlx"], "0"));
                                int _yfid = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["用法id"], "0"));
                                string _yfmc = Convert.ToString(Convertor.IsNull(rows_tc[xx]["用法"], "0"));
                                int _pcid = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["频次id"], "0"));
                                string _pcmc = Convert.ToString(Convertor.IsNull(rows_tc[xx]["频次"], "0"));
                                decimal _ts = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["天数"], "0"));
                                string _zt = Convert.ToString(Convertor.IsNull(rows_tc[xx]["嘱托"], "0"));
                                int _fzxh = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["处方分组序号"], "0"));
                                int _pxxh = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["排序序号"], "0"));
                                decimal _pfj = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["批发价"], "0"));
                                decimal _pfje = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["批发金额"], "0"));
                                if (_js != Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["剂数"], "0"))) throw new Exception("处方可能已修改,请重新刷新");
                                mz_cf.SaveCfmx(Guid.Empty, _NewCfid, _pym, _bm, _pm, _spm, _gg, _cj, _dj, _sl, _dw, _ydwbl, _js, _je, _tjdxmdm, _xmid, _hjmxid, _bm, 0, _bpsbz,
                                    Guid.Empty, _yl, _yldw, _yfmc, _pcid, _ts, _zt, _fzxh, _pxxh, Guid.Empty, _pfj, _pfje, _tcid, out _NewCfmxid, out err_code, out err_text, BDatabase);
                                if (_NewCfmxid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                                #region 套餐确费
                                if (cfg1063.Config == "1" && Convert.ToInt32(Convertor.IsNull(rows[j]["执行科室ID"], "0")) != 0)
                                {
                                    ParameterEx[] parameters = new ParameterEx[10];
                                    parameters[0].Text = "@CFID";
                                    parameters[0].Value = _NewCfid;
                                    parameters[1].Text = "@CFMXID";
                                    parameters[1].Value = _NewCfmxid;
                                    parameters[2].Text = "@TCID";
                                    parameters[2].Value = _tcid;


                                    parameters[3].Text = "@BQRBZ";
                                    parameters[3].Value = 1;
                                    parameters[4].Text = "@QRKS";
                                    parameters[4].Value = Convert.ToInt32(Convertor.IsNull(rows[j]["执行科室ID"], "0"));
                                    parameters[5].Text = "@QRRQ";
                                    parameters[5].Value = sDate;

                                    parameters[6].Text = "@QRDJY";
                                    parameters[6].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;

                                    parameters[7].Text = "@err_code";
                                    parameters[7].ParaDirection = ParameterDirection.Output;
                                    parameters[7].DataType = System.Data.DbType.Int32;
                                    parameters[7].ParaSize = 100;

                                    parameters[8].Text = "@err_text";
                                    parameters[8].ParaDirection = ParameterDirection.Output;
                                    parameters[8].ParaSize = 100;

                                    parameters[9].Text = "@YQRKS";
                                    parameters[9].Value = 0;

                                    BDatabase.GetDataTable("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                                    err_code = Convert.ToInt32(parameters[7].Value);
                                    err_text = Convert.ToString(parameters[8].Value);
                                    if (err_code != 0) throw new Exception(err_text);
                                }
                                #endregion
                            }
                            #endregion 
                        }
                        else
                        {
                            #region 非套餐
                            Guid _NewCfmxid = Guid.Empty;
                            Guid _hjmxid = new Guid(Convertor.IsNull(rows[j]["hjmxid"], Guid.Empty.ToString()));
                            string _pym = Convertor.IsNull(rows[j]["拼音码"], "");
                            string _bm = Convertor.IsNull(rows[j]["编码"], "");
                            string _pm = Convertor.IsNull(rows[j]["项目名称"], "");
                            string _spm = Convertor.IsNull(rows[j]["商品名"], "");
                            string _gg = Convertor.IsNull(rows[j]["规格"], "");
                            string _cj = Convertor.IsNull(rows[j]["厂家"], "");
                            decimal _dj = Convert.ToDecimal(Convertor.IsNull(rows[j]["单价"], "0"));
                            decimal _sl = Convert.ToDecimal(Convertor.IsNull(rows[j]["数量"], "0"));
                            string _dw = Convertor.IsNull(rows[j]["单位"], "");
                            int _ydwbl = Convert.ToInt32(Convertor.IsNull(rows[j]["ydwbl"], "0"));
                            decimal _je = Convert.ToDecimal(Convertor.IsNull(rows[j]["金额"], "0"));
                            string _tjdxmdm = Convertor.IsNull(rows[j]["统计大项目"], "");
                            long _xmid = Convert.ToInt64(Convertor.IsNull(rows[j]["项目id"], "0"));
                            //int _bpsyybz = Convert.ToInt32(Convertor.IsNull(rows[j]["皮试用药"], "0"));
                            int _bpsbz = Convert.ToInt32(Convertor.IsNull(rows[j]["皮试标志"], "0"));
                            //int _bmsbz = Convert.ToInt32(Convertor.IsNull(rows[j]["免试标志"], "0"));
                            decimal _yl = Convert.ToDecimal(Convertor.IsNull(rows[j]["剂量"], "0"));
                            string _yldw = Convertor.IsNull(rows[j]["剂量单位"], "");
                            int _yldwid = Convert.ToInt32(Convertor.IsNull(rows[j]["剂量单位id"], "0"));
                            int _dwlx = Convert.ToInt32(Convertor.IsNull(rows[j]["dwlx"], "0"));
                            int _yfid = Convert.ToInt32(Convertor.IsNull(rows[j]["用法id"], "0"));
                            string _yfmc = Convert.ToString(Convertor.IsNull(rows[j]["用法"], "0"));
                            int _pcid = Convert.ToInt32(Convertor.IsNull(rows[j]["频次id"], "0"));
                            string _pcmc = Convert.ToString(Convertor.IsNull(rows[j]["频次"], "0"));
                            decimal _ts = Convert.ToDecimal(Convertor.IsNull(rows[j]["天数"], "0"));
                            string _zt = Convert.ToString(Convertor.IsNull(rows[j]["嘱托"], ""));
                            int _fzxh = Convert.ToInt32(Convertor.IsNull(rows[j]["处方分组序号"], "0"));
                            int _pxxh = Convert.ToInt32(Convertor.IsNull(rows[j]["排序序号"], "0"));
                            decimal _pfj = Convert.ToDecimal(Convertor.IsNull(rows[j]["批发价"], "0"));
                            decimal _pfje = Convert.ToDecimal(Convertor.IsNull(rows[j]["批发金额"], "0"));
                            Guid _pshjmxid = new Guid(Convertor.IsNull(rows[j]["pshjmxid"], Guid.Empty.ToString()));
                            mz_cf.SaveCfmx(Guid.Empty, _NewCfid, _pym, _bm, _pm, _spm, _gg, _cj, _dj, _sl, _dw, _ydwbl, _js, _je, _tjdxmdm, _xmid, _hjmxid, _bm, 0, _bpsbz,
                                _pshjmxid, _yl, _yldw, _yfmc, _pcid, _ts, _zt, _fzxh, _pxxh, Guid.Empty, _pfj, _pfje, 0, out _NewCfmxid, out err_code, out err_text, BDatabase);
                            if (_NewCfmxid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                            #endregion 非套餐
                            #region 非套餐确费
                            if (cfg1063.Config == "1" && Convert.ToInt32(Convertor.IsNull(rows[j]["执行科室ID"], "0")) != 0)
                            {
                                ParameterEx[] parameters = new ParameterEx[10];
                                parameters[0].Text = "@CFID";
                                parameters[0].Value = _NewCfid;
                                parameters[1].Text = "@CFMXID";
                                parameters[1].Value = _NewCfmxid;
                                parameters[2].Text = "@TCID";
                                parameters[2].Value = 0;


                                parameters[3].Text = "@BQRBZ";
                                parameters[3].Value = 1;
                                parameters[4].Text = "@QRKS";
                                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(rows[j]["执行科室ID"], "0"));
                                parameters[5].Text = "@QRRQ";
                                parameters[5].Value = sDate;

                                parameters[6].Text = "@QRDJY";
                                parameters[6].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;

                                parameters[7].Text = "@err_code";
                                parameters[7].ParaDirection = ParameterDirection.Output;
                                parameters[7].DataType = System.Data.DbType.Int32;
                                parameters[7].ParaSize = 100;

                                parameters[8].Text = "@err_text";
                                parameters[8].ParaDirection = ParameterDirection.Output;
                                parameters[8].ParaSize = 100;

                                parameters[9].Text = "@YQRKS";
                                parameters[9].Value = 0;

                                BDatabase.GetDataTable("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                                err_code = Convert.ToInt32(parameters[7].Value);
                                err_text = Convert.ToString(parameters[8].Value);
                                if (err_code != 0) throw new Exception(err_text);
                            }
                            #endregion
                        } 
                    } 
                }
                //#endregion
                //add by zouchihua 2013-5-6
                int sky = 0;
                try
                {
                    if (cfg3058.Config.Trim() == "" || cfg3058.Config.Trim() == "0")
                    {
                        sky = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                    }
                    else

                        sky = Convert.ToInt32(cfg3058.Config);
                }
                catch { }

                #region  保存收银信息
                Guid NewJsid = Guid.Empty;
                mz_sf.SaveJs(Guid.Empty, new Guid(brxxid), new Guid(ghxxid), sDate, sky, zje, 0, 0, 0, 0, yhje, cwjz, qfgz, 0, 0, srje, 0, 0, fpzs, 0, TrasenFrame.Forms.FrmMdiMain.Jgbm, out NewJsid, out err_code, out err_text, BDatabase);
                if (NewJsid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                #endregion 

                int UpdateCfs = 0;//更新处方头张数
                int UpdateHjs = 0;//更新划价头张数

                #region 保存发票信息 并更新处方状态
                for (int X = 0; X <= dset.Tables[0].Rows.Count - 1; X++)
                {
                    Guid NewFpid = Guid.Empty;
                    string fph = "0";//不打发票 赋值为0
                    int ksdm = Convert.ToInt32(dset.Tables[0].Rows[X]["ksdm"]);
                    int ysdm = Convert.ToInt32(dset.Tables[0].Rows[X]["ysdm"]);
                    int zyksdm = Convert.ToInt32(dset.Tables[0].Rows[X]["zyksdm"]);
                    int zxks = Convert.ToInt32(dset.Tables[0].Rows[X]["zxks"]);
                    Guid yhlxid = new Guid(dset.Tables[0].Rows[X]["yhlxid"].ToString());
                    string yhlxmc = ts_mz_class.Fun.SeekYhlxMc(yhlxid, BDatabase);
                    long dnlsh = Convert.ToInt64(dset.Tables[0].Rows[X]["dnlsh"]);
                    if (fpzs == 1)
                    {
                        mz_sf.SaveFp(Guid.Empty, new Guid(brxxid), new Guid(ghxxid), txtmzh.Text.Trim(), txtname.Text.Trim(), sDate, sky, "", dnlsh, fph, zje, 0, 0, 0, 0, yhje, cwjz, qfgz, 0, 0, srje, Guid.Empty, "", NewJsid, 0, ksdm, ysdm, zyksdm, zxks, 0, "", 0, readcard.kdjid, TrasenFrame.Forms.FrmMdiMain.Jgbm, yhlxid, yhlxmc, out NewFpid, out err_code, out err_text, BDatabase);
                    }
                    else
                    {
                        decimal fp_zfje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zfjeex"]);
                        decimal fp_zje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                        decimal fp_yhje = Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]);
                        decimal fp_srje = Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]);
                        decimal fp_ybzhzf = 0;
                        decimal fp_ybjjzf = 0;
                        decimal fp_ybbzzf = 0;
                        decimal fp_ylkzf = 0;
                        decimal fp_cwjz = cwjz > 0 ? fp_zfje : 0;
                        decimal fp_qfgz = qfgz > 0 ? fp_zfje : 0;
                        decimal fp_xjzf = 0;
                        decimal fp_zpzf = 0;
                        mz_sf.SaveFp(Guid.Empty, new Guid(brxxid), new Guid(ghxxid), txtmzh.Text.Trim(), txtname.Text.Trim(), sDate, sky, "", dnlsh, fph, fp_zje, fp_ybzhzf, fp_ybjjzf, fp_ybbzzf, fp_ylkzf, fp_yhje, fp_cwjz, fp_qfgz, fp_xjzf, fp_zpzf, fp_srje, Guid.Empty, "", NewJsid, 0, ksdm, ysdm, zyksdm, zxks, 0, "", 0, readcard.kdjid, TrasenFrame.Forms.FrmMdiMain.Jgbm, yhlxid, yhlxmc, out NewFpid, out err_code, out err_text, BDatabase);

                    }

                    dset.Tables[0].Rows[X]["fph"] = fph.ToString();
                    dset.Tables[0].Rows[X]["fpid"] = NewFpid;

                    if (err_code != 0 || NewFpid == Guid.Empty) throw new Exception(err_text);

                    string _sHjid = dset.Tables[0].Rows[X]["hjid"].ToString().Trim();
                    _sHjid = _sHjid.Replace("'", "''");

                    //发票明细
                    decimal fpje = 0;
                    DataRow[] rows = dset.Tables[1].Select(@"hjid = '" + _sHjid + "'");
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        mz_sf.SaveFpmx(NewFpid, Convertor.IsNull(rows[i]["code"], "0"), Convertor.IsNull(rows[i]["item_name"], "0"), Convert.ToDecimal(rows[i]["je"]), 0, out err_code, out err_text, BDatabase);
                        if (err_code != 0) throw new Exception(err_text);
                        fpje = fpje + Convert.ToDecimal(rows[i]["je"]);
                    }
                    if (fpje != Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]) - (Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]))) throw new Exception("插入发票明细时出错,金额不等于发票总额");

                    //发票统计大项目明细
                    decimal tjxmje = 0;
                    DataRow[] rows1 = dset.Tables[3].Select("hjid = '" + _sHjid + "'");
                    for (int i = 0; i <= rows1.Length - 1; i++)
                    {
                        mz_sf.SaveFpdxmmx(NewFpid, Convertor.IsNull(rows1[i]["code"], "0"), Convertor.IsNull(rows1[i]["item_name"], "0"), Convert.ToDecimal(rows1[i]["je"]), 0, out err_code, out err_text, BDatabase);
                        if (err_code != 0) throw new Exception(err_text);
                        tjxmje = tjxmje + Convert.ToDecimal(rows1[i]["je"]);
                    }
                    if (tjxmje != Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]) - (Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]))) throw new Exception("插入发票明细时出错,金额不等于发票总额");

                    //更新划方表状态  条件 hjid 和 收费标志
                    int Nrows = 0;
                    mz_cf.UpdateCfsfzt_E(dset.Tables[0].Rows[X]["hjid"].ToString().Trim(), sky, TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name, sDate, "", dnlsh, fph, NewFpid, out Nrows, out err_code, out err_text, BDatabase);
                    UpdateCfs = UpdateCfs + Nrows;
                    //更新价划处方表
                    mz_hj.UpdateCfsfzt(dset.Tables[0].Rows[X]["hjid"].ToString().Trim(), 1, 0, out Nrows, out err_code, out err_text, BDatabase);
                    UpdateHjs = UpdateHjs + Nrows;
                    //更新医技申请的收费状态
                    int iiii = UpdateSfbz(dset.Tables[0].Rows[X]["hjid"].ToString().Trim(), sDate, BDatabase);  
                    #region 门诊收费是否发药
                    if (sss.Config == "1")
                    {
                        Guid _Fyid = Guid.Empty;
                        Guid _Fymxid = Guid.Empty;
                        ssql = "select *,(select top 1 TJDXMDM from MZ_CFB_MX where CFID=mz_cfb.CFID) cflx from mz_cfb where fpid= '" + NewFpid + "' and bscbz=0 and xmly=1";
                        DataTable tbfy = BDatabase.GetDataTable(ssql);
                        for (int i = 0; i <= tbfy.Rows.Count - 1; i++)
                        { 
                            //不能为空处方类型
                            YpClass.MZYF.SaveFy(Convert.ToString(tbfy.Rows[0]["cflx"]), 0, Convert.ToInt64(fph), Convert.ToDecimal(tbfy.Rows[i]["zje"]), 0, 0, 0, Convert.ToInt32(tbfy.Rows[i]["cfjs"]), new Guid(tbfy.Rows[i]["cfid"].ToString()), new Guid(tbfy.Rows[i]["brxxid"].ToString()),
                                Convert.ToString(tbfy.Rows[i]["blh"]), txtname.Text.Trim(), ysdm, ksdm, sDate, sky, sDate, sky, sky, "", "", zxks, 0, "017", 0, "sp_yf_fy",
                                out _Fyid, out err_code, out err_text, TrasenFrame.Forms.FrmMdiMain.Jgbm, BDatabase);
                            if (_Fyid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                            ssql = "select *,coalesce(dbo.Fun_getFreqName(cast(coalesce(PCID,0) as smallint)),'''') pc from mz_cfb_mx a,yp_ypcjd b where a.xmid=b.cjid and cfid='" + new Guid(tbfy.Rows[i]["cfid"].ToString()) + "' and  bscbz=0";
                            DataTable tbfymx = BDatabase.GetDataTable(ssql);
                            for (int j = 0; j <= tbfymx.Rows.Count - 1; j++)
                            {
                                MZYF.SaveFymx(_Fyid, Convert.ToInt64(fph), new Guid(tbfymx.Rows[i]["cfid"].ToString()), Convert.ToInt32(tbfymx.Rows[j]["xmid"]), Convertor.IsNull(tbfymx.Rows[j]["shh"], ""), Convertor.IsNull(tbfymx.Rows[j]["pm"], ""),
                                    Convertor.IsNull(tbfymx.Rows[j]["spm"], ""), Convertor.IsNull(tbfymx.Rows[j]["gg"], ""), Convertor.IsNull(tbfymx.Rows[j]["cj"], ""), Convertor.IsNull(tbfymx.Rows[j]["dw"], ""),
                                    Convert.ToUInt32(tbfymx.Rows[j]["ydwbl"]), Convert.ToDecimal(tbfymx.Rows[j]["sl"]), Convert.ToInt32(tbfymx.Rows[j]["js"]), Convert.ToDecimal(tbfymx.Rows[j]["pfj"]),
                                    Convert.ToDecimal(tbfymx.Rows[j]["pfje"]), Convert.ToDecimal(tbfymx.Rows[j]["dj"]), Convert.ToDecimal(tbfymx.Rows[j]["je"]), 0, 0, zxks, Guid.Empty, "", Guid.Empty, new Guid(tbfymx.Rows[j]["cfmxid"].ToString()), "",
                                    "", "", Convertor.IsNull(tbfymx.Rows[j]["yfmc"], ""), Convertor.IsNull(tbfymx.Rows[j]["pc"], ""), Convertor.IsNull(tbfymx.Rows[j]["yl"], ""),
                                    Convertor.IsNull(tbfymx.Rows[j]["yldw"], ""), Convert.ToDecimal(tbfymx.Rows[j]["ts"]), Convert.ToInt32(tbfymx.Rows[j]["fzxh"]),
                                    Convert.ToInt32(tbfymx.Rows[j]["pxxh"]), "sp_YF_FYMX", out _Fymxid, out err_code, out err_text, BDatabase);
                                if (_Fymxid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                            }
                        }
                    }
                    #endregion  
                }
                //add by zouchihua 2013-4-11 同时更新无号标记为有号标记，已经mz_ghxx 金额。
                string sqlupdate = "update  MZ_GHXX   set byhbz=1 ,GHJE=b.CFJE from MZ_GHXX  a join MZ_HJB b "
                 + "  on a.GHXXID=b.GHXXID and b.ZYKSDM=99999 where  a.GHXXID='" + dset.Tables[0].Rows[0]["GHXXID"].ToString().Trim() + "' and byhbz=0";
                BDatabase.DoCommand(sqlupdate);
                //更新卡余额和累计消息金额
                if (cwjz > 0)
                    readcard.UpdateKye(cwjz, BDatabase);
                #endregion 

                #region 判断处方更新张数和实际分组张数是否一样
                if (UpdateCfs != tb.Rows.Count)
                    throw new Exception("更新处方表张数" + UpdateCfs + "张,分组处方张数" + tbxm.Rows.Count + "张.请检查处方状态或刷新处方再试");
                if (UpdateHjs != tb.Rows.Count)
                    throw new Exception("更新处方表张数" + UpdateHjs + "张,分组处方张数" + tbxm.Rows.Count + "张.请检查处方状态或刷新处方再试");
                #endregion

                //ADD BY CC 2014-11-12   //更新发药窗口 由于存在多执行科室不分票的情况 具体发药窗口输出请修改 sp_yf_MZSF_FYCK
                for (int X = 0; X <= dset.Tables[0].Rows.Count - 1; X++)//循环发票张数
                { 
                    string fyck = "";
                    mz_sf.UpdateFyck(new Guid(brxxid), new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()), out fyck, BDatabase);
                } 
                //END ADD 
                BDatabase.CommitTransaction();

                #region  add by zouchihua 2013-4-11 打印小票
                SystemCfg cfg3092 = new SystemCfg(3092); //收费完成后打印方式 0-不打印任何凭据，1-打印发票，2-打印小票

                if (cfg3092.Config.Trim() == "1")
                {
                    #region 打印收费小票
                    try
                    {
                        /*add by zch 2013-03-26 门诊小票打印是否打在一张上（只切纸一次）0=否 ，1=是 */
                        if (new SystemCfg(1078).Config.Trim() == "1" && dset.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtFpxm = dset.Tables[1].Clone();
                            dtFpxm.TableName = "收费明细";
                            DataTable dtFpwjxm = dset.Tables[4].Clone();
                            dtFpwjxm.TableName = "收费物价明细";
                            //复制一个表数据

                            DataTable tableXpmx = dset.Tables[5].Copy();
                            tableXpmx.TableName = "小票明细";
                            //Modify by zouchihua 2013-3-26 门诊小票打印
                            #region 只打一张小票

                            decimal cwjzhj = 0;
                            decimal _xhje = 0;//消费金额
                            decimal _yhje = 0;//优惠金额

                            // decimal _zje=0;//总金额
                            string zhdnlsh = "";//考虑到电脑流水号有多个

                            for (int X = 0; X <= dset.Tables[0].Rows.Count - 1; X++)
                            {
                                
                                _xhje += decimal.Parse(dset.Tables[0].Rows[X]["zje"].ToString());//消费金额
                                _yhje += decimal.Parse(dset.Tables[0].Rows[X]["yhje"].ToString());//优惠金额

                                //更新发药窗口 由于存在多执行科室不分票的情况 具体发药窗口输出请修改 sp_yf_MZSF_FYCK
                                string fyck = "";

                                // mz_sf.UpdateFyck(Dqcf.brxxid, new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()), out fyck, InstanceForm.BDatabase);

                                ssql = "select * from mz_fpb  (nolock)  where fpid='" + new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()) + "'";
                                DataTable tbFp = BDatabase.GetDataTable(ssql);

                                string _sHjid = dset.Tables[0].Rows[X]["hjid"].ToString().Trim();
                                _sHjid = _sHjid.Replace("'", "''");

                                DataRow[] rows = dset.Tables[1].Select("hjid='" + _sHjid + "'");
                                cwjzhj = cwjzhj + Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);
                                foreach (DataRow dr2 in rows)
                                    dtFpxm.Rows.Add(dr2.ItemArray);

                                DataRow[] rowsdetail = dset.Tables[4].Select("hjid='" + _sHjid + "'");
                                if (dset.Tables[0].Rows.Count - 1 == X)
                                    zhdnlsh = dset.Tables[0].Rows[X]["dnlsh"].ToString();

                                foreach (DataRow dr1 in rowsdetail)
                                    dtFpwjxm.Rows.Add(dr1.ItemArray);

                                zhdnlsh += dset.Tables[0].Rows[X]["dnlsh"].ToString() + "\r\n";//多个进行累加

                                //fView.Show();
                            }
                            ye = ye - cwjzhj;//放到这里计算
                            #region
                            //读取病人卡余额 重新获得卡 并且获余额
                            ReadCard readcard1 = new ReadCard(klx, txtkh.Text.Trim(), BDatabase);
                            ye = readcard1.kye;

                            ParameterEx[] paramters = new ParameterEx[16];
                            paramters[0].Text = "V_医院名称";
                            paramters[0].Value = Constant.HospitalName;

                            paramters[1].Text = "V_收费日期";
                            paramters[1].Value = sDate;

                            paramters[2].Text = "V_收费员";
                            //Modify by zouchihua 2013-05-12
                            if (cfg3058.Config.Trim() == "" || cfg3058.Config.Trim() == "0")
                                paramters[2].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;
                            else
                                paramters[2].Value = "医生站扣费";//写死

                            paramters[3].Text = "V_病人姓名";
                            paramters[3].Value = txtname.Text;

                            paramters[4].Text = "V_门诊号";
                            paramters[4].Value = dset.Tables[0].Rows[0]["blh"].ToString();

                            paramters[5].Text = "V_卡号";
                            paramters[5].Value = txtkh.Text;

                            paramters[6].Text = "V_电脑流水号";
                            paramters[6].Value = zhdnlsh;// +" -" + zhdnlsh;

                            paramters[7].Text = "V_消费金额";
                            paramters[7].Value = _xhje;
                            //  ye = ye - Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);
                            paramters[8].Text = "V_卡余额";
                            paramters[8].Value = ye;
                            paramters[9].Text = "V_医生";
                            paramters[9].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;//当前用户
                            paramters[10].Text = "V_科室";
                            paramters[10].Value = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;//当前科室

                            paramters[11].Text = "V_优惠金额";
                            paramters[11].Value = _yhje.ToString();
                            //add by zouchihua 2013-3-26
                            paramters[12].Text = "V_现金支付";
                            paramters[12].Value = "0";//直接获取收银窗口的值
                            //add by zouchihua 2013-3-26
                            paramters[13].Text = "V_医保支付";
                            paramters[13].Value = "0";//直接获取收银窗口的值
                            //add by zouchihua 2013-3-26
                            paramters[14].Text = "V_其它支付";
                            paramters[14].Value = Convert.ToString(_xhje - _yhje);//直接获取收银窗口的值 zje

                            //Add by zp 2013-08-30
                            paramters[15].Text = "V_医保余额";
                            paramters[15].Value = 0;

                            #endregion

                            DataSet _dset = new DataSet();
                            _dset.Tables.Add(dtFpxm);
                            _dset.Tables.Add(dtFpwjxm); 
                            _dset.Tables.Add(tableXpmx);
                            string reportFile = Constant.ApplicationDirectory + "\\Report\\MZSF_小票(只打一张).rpt";
                            TrasenFrame.Forms.FrmReportView fView = new TrasenFrame.Forms.FrmReportView(_dset, reportFile, paramters, true);
                            // TrasenFrame.Forms.FrmReportView fView1 = new TrasenFrame.Forms.FrmReportView(_dset, reportFile, paramters, true);//add by zouchihua 2013-3-27 打两份
                            #endregion

                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }  
                    #endregion
                }
                else
                {
                    #region 打印收费小票
                    try
                    {
                        /*add by zch 2013-03-26 门诊小票打印是否打在一张上（只切纸一次）0=否 ，1=是 */
                        //MessageBox.Show(dset.Tables[0].Rows.Count.ToString());
                        if (dset.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtFpxm = dset.Tables[1].Clone();
                            dtFpxm.TableName = "收费明细";
                            DataTable dtFpwjxm = dset.Tables[4].Clone();
                            dtFpwjxm.TableName = "收费物价明细";
                            //复制一个表数据

                            DataTable tableXpmx = dset.Tables[5].Copy();
                            tableXpmx.TableName = "小票明细";
                            //Modify by zouchihua 2013-3-26 门诊小票打印
                            #region 只打一张小票

                            decimal cwjzhj = 0;
                            decimal _xhje = 0;//消费金额
                            decimal _yhje = 0;//优惠金额

                            // decimal _zje=0;//总金额
                            string zhdnlsh = "";//考虑到电脑流水号有多个

                            for (int X = 0; X <= dset.Tables[0].Rows.Count - 1; X++)
                            {

                                _xhje += decimal.Parse(dset.Tables[0].Rows[X]["zje"].ToString());//消费金额
                                _yhje += decimal.Parse(dset.Tables[0].Rows[X]["yhje"].ToString());//优惠金额

                                //更新发药窗口 由于存在多执行科室不分票的情况 具体发药窗口输出请修改 sp_yf_MZSF_FYCK
                                string fyck = "";

                                // mz_sf.UpdateFyck(Dqcf.brxxid, new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()), out fyck, InstanceForm.BDatabase);

                                ssql = "select * from mz_fpb  (nolock)  where fpid='" + new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()) + "'";
                                DataTable tbFp = BDatabase.GetDataTable(ssql);

                                string _sHjid = dset.Tables[0].Rows[X]["hjid"].ToString().Trim();
                                _sHjid = _sHjid.Replace("'", "''");

                                DataRow[] rows = dset.Tables[1].Select("hjid='" + _sHjid + "'");
                                cwjzhj = cwjzhj + Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);
                                foreach (DataRow dr2 in rows)
                                    dtFpxm.Rows.Add(dr2.ItemArray);

                                DataRow[] rowsdetail = dset.Tables[4].Select("hjid='" + _sHjid + "'");
                                if (dset.Tables[0].Rows.Count - 1 == X)
                                    zhdnlsh = dset.Tables[0].Rows[X]["dnlsh"].ToString();

                                foreach (DataRow dr1 in rowsdetail)
                                    dtFpwjxm.Rows.Add(dr1.ItemArray);

                                zhdnlsh += dset.Tables[0].Rows[X]["dnlsh"].ToString() + "\r\n";//多个进行累加

                                //fView.Show();
                            }
                            ye = ye - cwjzhj;//放到这里计算
                            #region
                            //读取病人卡余额 重新获得卡 并且获余额
                            ReadCard readcard1 = new ReadCard(klx, txtkh.Text.Trim(), BDatabase);
                            ye = readcard1.kye;

                            ParameterEx[] paramters = new ParameterEx[16];
                            paramters[0].Text = "V_医院名称";
                            paramters[0].Value = Constant.HospitalName;

                            paramters[1].Text = "V_收费日期";
                            paramters[1].Value = sDate;

                            paramters[2].Text = "V_收费员";
                            //Modify by zouchihua 2013-05-12
                            if (cfg3058.Config.Trim() == "" || cfg3058.Config.Trim() == "0")
                                paramters[2].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;
                            else
                                paramters[2].Value = "医生站扣费";//写死

                            paramters[3].Text = "V_病人姓名";
                            paramters[3].Value = txtname.Text;

                            paramters[4].Text = "V_门诊号";
                            paramters[4].Value = dset.Tables[0].Rows[0]["blh"].ToString();

                            paramters[5].Text = "V_卡号";
                            paramters[5].Value = txtkh.Text;

                            paramters[6].Text = "V_电脑流水号";
                            paramters[6].Value = zhdnlsh;// +" -" + zhdnlsh;

                            paramters[7].Text = "V_消费金额";
                            paramters[7].Value = _xhje;
                            //  ye = ye - Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);
                            paramters[8].Text = "V_卡余额";
                            paramters[8].Value = ye;
                            paramters[9].Text = "V_医生";
                            paramters[9].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;//当前用户
                            paramters[10].Text = "V_科室";
                            paramters[10].Value = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;//当前科室

                            paramters[11].Text = "V_优惠金额";
                            paramters[11].Value = _yhje.ToString();
                            //add by zouchihua 2013-3-26
                            paramters[12].Text = "V_现金支付";
                            paramters[12].Value = "0";//直接获取收银窗口的值
                            //add by zouchihua 2013-3-26
                            paramters[13].Text = "V_医保支付";
                            paramters[13].Value = "0";//直接获取收银窗口的值
                            //add by zouchihua 2013-3-26
                            paramters[14].Text = "V_其它支付";
                            paramters[14].Value = Convert.ToString(_xhje - _yhje);//直接获取收银窗口的值 zje

                            //Add by zp 2013-08-30
                            paramters[15].Text = "V_医保余额";
                            paramters[15].Value = 0;

                            #endregion


                            DataSet _dset = new DataSet();
                            _dset.Tables.Add(dtFpxm);
                            _dset.Tables.Add(dtFpwjxm);
                            _dset.Tables.Add(tableXpmx);
                            string reportFile = Constant.ApplicationDirectory + "\\Report\\MZSF_小票(只打一张).rpt";
                            TrasenFrame.Forms.FrmReportView fView = new TrasenFrame.Forms.FrmReportView(_dset, reportFile, paramters, true);
                            // TrasenFrame.Forms.FrmReportView fView1 = new TrasenFrame.Forms.FrmReportView(_dset, reportFile, paramters, true);//add by zouchihua 2013-3-27 打两份
                            #endregion

                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    #endregion
                }

                #endregion

                MessageBox.Show("扣费成功!实扣金额为" + cwjz.ToString() + " 元!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bok = true;
                this.Close();
            }
            catch (System.Exception err)
            {
                BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// 修改医技申请收费标志
        /// </summary>
        /// <param name="hjid"></param>
        /// <param name="sdate"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static int UpdateSfbz(string hjid, string sdate, RelationalDatabase _DataBase)
        {
            string ssql = " update YJ_MZSQ set bsfbz=1,sfrq='" + sdate + "' where yzid in " + hjid + " and bsfbz=0 and bscbz=0 ";
            return _DataBase.DoCommand(ssql);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex != 0)
                    return;
                int index = dataGridView1.CurrentCell.RowIndex;
                DataTable dtb = (DataTable)dataGridView1.DataSource;
                if ((!Convert.ToBoolean(dataGridView1.Rows[index].Cells[0].EditedFormattedValue.ToString())))//"选择"
                {
                    decimal zje = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].EditedFormattedValue))//"选择"
                            zje += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
                    }
                    decimal dzje = System.Decimal.Round(zje, 2);
                    lblzje.Text = dzje.ToString();
                }
                else
                {
                    decimal zje = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].EditedFormattedValue))//"选择"
                            zje += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
                    }
                    decimal dzje = System.Decimal.Round(zje, 2);
                    lblzje.Text = dzje.ToString();
                }
            }
            catch (Exception ea)
            {

            }
        }

        private void txtmzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    txtmzh.Text = Fun.ToDBC(txtmzh.Text);
                    string mzh = txtmzh.Text;
                    string name = txtname.Text;
                    string cfje = lblzje.Text;
                    ClearFrom();
                    if (cfg3513.Config.Trim() == "1")
                    {
                        if (!string.IsNullOrEmpty(this.txtkh.Text.Trim()))
                            GetBrxx("", mzh, this.txtkh.Text.Trim());
                        else
                        {
                            txtmzh.Text = mzh;
                            txtname.Text = name;
                            lblzje.Text = cfje;
                            return;
                        }
                    }
                    else
                        GetBrxx("", mzh, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误!错误代码:J1 " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        ///清空窗体
        /// <summary>
        /// 清空窗体
        /// </summary>
        private void ClearFrom()
        {
            txtname.Text = "";
            txtmzh.Text = "";
            txtkh.Text = "";
            if (dataGridView1.DataSource != null)
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                tb.Clear();
            }
            lblkye.Text = "0";
            lblzje.Text = "0";
        }

        private void btncx_Click(object sender, EventArgs e)
        {
            if (txtmzh.Text == "")
            {
                MessageBox.Show("门诊号不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = @"SELECT a.sfrq 收费时间,a.zje 处方金额,dbo.fun_getDeptname(a.ksdm) 收费科室,dbo.fun_getEmpName(a.ysdm) 收费医生,
a.FPID,c.HJID
 FROM mz_fpb a INNER JOIN dbo.MZ_CFB b ON  a.FPID = b.FPID INNER JOIN dbo.MZ_HJB c ON b.HJID = c.HJID where a.blh='" + txtmzh.Text.Trim() + "' and a.sfrq>='" + dtpBegin.Value.ToString("yyyy-MM-dd")
                                             + " 00:00:00' and a.sfrq <='" + dtpEnd.Value.ToString("yyyy-MM-dd") + " 23:59:59' group by a.sfrq,a.zje,a.ksdm,a.ysdm,a.fpid,c.hjid";
            dataGridView2.DataSource = BDatabase.GetDataTable(sql);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            { }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message + "  4");
            }
        }



        private void txtkh_KeyPress(object sender, KeyPressEventArgs e) //add by zp 2013-08-30
        {

            if ((int)e.KeyChar != 13)
            {

                if (cfg3513.Config.Trim() == "1" && this.txtkh.Text.Trim().Length < 1)
                    e.Handled = true;
                return;
            }
            if ((int)e.KeyChar == 13)
            {
                if (this.cfg3513.Config.Trim() == "1" && this.txtkh.Text.Trim().Length > 0)
                    GetBrxx(ghxxid, mzh, txtkh.Text.Trim());
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
                return;
            if (dataGridView2.Rows[e.RowIndex].Cells["clXz"].Value == null)
                dataGridView2.Rows[e.RowIndex].Cells["clXz"].Value = "1";
            else
                if (dataGridView2.Rows[e.RowIndex].Cells["clXz"].Value.ToString() == "0")
                    dataGridView2.Rows[e.RowIndex].Cells["clXz"].Value = "1";
                else
                    dataGridView2.Rows[e.RowIndex].Cells["clXz"].Value = "0";

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if ( this.dataGridView2.DataSource == null )
                return;
            if ( ( (DataTable)this.dataGridView2.DataSource ).Rows.Count == 0 )
                return;

            DataTable dtTemp = (DataTable)this.dataGridView2.DataSource;
            DataTable dtCopy = dtTemp.Copy();
            dtCopy.Clear();
            int selectCount = 0;
            for ( int i = 0 ; i <= dataGridView2.Rows.Count - 1 ; i++ )
            {
                if ( dataGridView2.Rows[i].Cells["clXz"].Value == null )
                    continue;
                if ( dataGridView2.Rows[i].Cells["clXz"].Value.ToString() == "1" )
                {
                    dtCopy.Rows.Add( dtTemp.Rows[i].ItemArray );
                    selectCount++;
                }
            }
            if ( selectCount == 0 )
            {
                MessageBox.Show( "没有选择补打记录" , "" , MessageBoxButtons.OK , MessageBoxIcon.Stop );
                return;
            }
            string ssql = "";
            //发票结果集
            DataSet dset = null;
            //要收费的处方字符串
            string shjid = "('";
            for (int i = 0; i <= dtCopy.Rows.Count - 1; i++)
                shjid += Convert.ToString(dtCopy.Rows[i]["hjid"]) + "','";
            shjid = shjid.Substring(0, shjid.Length - 2);
            shjid += ")";

            //收银金额
            decimal zje = 0;//总金额
            decimal yhje = 0;//优惠金额
            decimal srje = 0;//舍入金额
            decimal cwjz = 0;//财务记帐
            decimal qfgz = 0;//欠费挂帐
            int fpzs = 0;//发票张数
            Guid _hjid = Guid.Empty;
            int _xmly = 0;
            //时间
            string sDate = DateManager.ServerDateTimeByDBType(BDatabase).ToString();
            //卡属性
            int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
            string kh = txtkh.Text.Trim();
            mz_card card = new mz_card(klx, BDatabase);
            //返回变量
            int err_code = -1;
            string err_text = "";
            sDate = DateManager.ServerDateTimeByDBType(BDatabase).ToString(); 
            try
            {
                //返回发票相关信息  
                dset = mz_sf.GetFpResult(shjid, 0, 0, 0, Guid.Empty, Guid.Empty, TrasenFrame.Forms.FrmMdiMain.Jgbm, out err_code, out err_text, 0, BDatabase);
                //填写流水号,一张发票对应一个流水号
                //for (int iFp = 0; iFp < dset.Tables[0].Rows.Count; iFp++)
                //    dset.Tables[0].Rows[iFp]["dnlsh"] = Fun.GetNewDnlsh(BDatabase); 
                zje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));
                yhje = Convert.ToDecimal(dset.Tables[0].Compute("sum(yhje)", ""));
                srje = Convert.ToDecimal(dset.Tables[0].Compute("sum(srje)", ""));
                cwjz = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));
                fpzs = dset.Tables[0].Rows.Count; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }  
            try
            {
               
                /*add by zch 2013-03-26 门诊小票打印是否打在一张上（只切纸一次）0=否 ，1=是 */
                //MessageBox.Show(dset.Tables[0].Rows.Count.ToString());
                if (dset.Tables[0].Rows.Count > 0)
                {
                    ReadCard readcard = new ReadCard(klx, txtkh.Text.Trim(), BDatabase);
                    decimal ye = readcard.kye;
                    DataTable dtFpxm = dset.Tables[1].Copy();
                        //.Clone();
                    dtFpxm.TableName = "收费明细";
                    DataTable dtFpwjxm = dset.Tables[4].Copy();
                    //.Clone();
                    dtFpwjxm.TableName = "收费物价明细";
                    //复制一个表数据

                    DataTable tableXpmx = dset.Tables[5].Copy();
                    //.Copy();
                    tableXpmx.TableName = "小票明细";
                    //Modify by zouchihua 2013-3-26 门诊小票打印 
                    //decimal cwjzhj = 0;
                    decimal _xhje = 0;//消费金额
                    decimal _yhje = 0;//优惠金额

                    // decimal _zje=0;//总金额
                    string zhdnlsh = "";//考虑到电脑流水号有多个
                    for (int X = 0; X <= dset.Tables[0].Rows.Count - 1; X++)
                    {
                        _xhje += decimal.Parse(dset.Tables[0].Rows[X]["zje"].ToString());//消费金额
                        _yhje += decimal.Parse(dset.Tables[0].Rows[X]["yhje"].ToString());//优惠金额
                        if (dset.Tables[0].Rows.Count - 1 == X)
                            zhdnlsh = dset.Tables[0].Rows[X]["dnlsh"].ToString();  
                        zhdnlsh += dset.Tables[0].Rows[X]["dnlsh"].ToString() + "\r\n";//多个进行累加
                    }
                  
                    ParameterEx[] paramters = new ParameterEx[16];
                    paramters[0].Text = "V_医院名称";
                    paramters[0].Value = Constant.HospitalName;

                    paramters[1].Text = "V_收费日期";
                    paramters[1].Value = sDate;

                    paramters[2].Text = "V_收费员";
                    //Modify by zouchihua 2013-05-12
                    if (cfg3058.Config.Trim() == "" || cfg3058.Config.Trim() == "0")
                        paramters[2].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;
                    else
                        paramters[2].Value = "医生站扣费";//写死

                    paramters[3].Text = "V_病人姓名";
                    paramters[3].Value = txtname.Text;

                    paramters[4].Text = "V_门诊号";
                    paramters[4].Value = dset.Tables[0].Rows[0]["blh"].ToString();

                    paramters[5].Text = "V_卡号";
                    paramters[5].Value = txtkh.Text;

                    paramters[6].Text = "V_电脑流水号";
                    paramters[6].Value = zhdnlsh;// +" -" + zhdnlsh;

                    paramters[7].Text = "V_消费金额";
                    paramters[7].Value = _xhje;
                    //  ye = ye - Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);
                    paramters[8].Text = "V_卡余额";
                    paramters[8].Value = ye;
                    paramters[9].Text = "V_医生";
                    paramters[9].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;//当前用户
                    paramters[10].Text = "V_科室";
                    paramters[10].Value = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;//当前科室

                    paramters[11].Text = "V_优惠金额";
                    paramters[11].Value = _yhje.ToString();
                    //add by zouchihua 2013-3-26
                    paramters[12].Text = "V_现金支付";
                    paramters[12].Value = Convert.ToString(_xhje - _yhje);//直接获取收银窗口的值
                    //add by zouchihua 2013-3-26
                    paramters[13].Text = "V_医保支付";
                    paramters[13].Value = "0";//直接获取收银窗口的值
                    //add by zouchihua 2013-3-26
                    paramters[14].Text = "V_其它支付";
                    paramters[14].Value ="0" ;//直接获取收银窗口的值 zje

                    //Add by zp 2013-08-30
                    paramters[15].Text = "V_医保余额";
                    paramters[15].Value = 0; 

                    DataSet _dset = new DataSet();
                    _dset.Tables.Add(dtFpxm);
                    _dset.Tables.Add(dtFpwjxm);
                    _dset.Tables.Add(tableXpmx);
                    string reportFile = Constant.ApplicationDirectory + "\\Report\\MZSF_小票(只打一张)补打.rpt";
                    TrasenFrame.Forms.FrmReportView fView = new TrasenFrame.Forms.FrmReportView(_dset, reportFile, paramters, true);
                    // TrasenFrame.Forms.FrmReportView fView1 = new TrasenFrame.Forms.FrmReportView(_dset, reportFile, paramters, true);//add by zouchihua 2013-3-27 打两份
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}