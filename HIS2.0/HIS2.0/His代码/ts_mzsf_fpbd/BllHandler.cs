using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

namespace ts_mzsf_fpbd
{
    public class BllHandler
    {
        public BllHandler()
        {
        }
        /// <summary>
        /// 查询需要补打的发票记录
        /// </summary>
        /// <param name="mzh"></param>
        /// <param name="kh"></param>
        /// <param name="dnlsh"></param>
        /// <param name="brxm"></param>
        /// <param name="sfrq1"></param>
        /// <param name="sfrq2"></param>
        /// <returns></returns>
        public DataTable SelectFPJL(int sjly, string mzh, int klx, string kh, string dnlsh, string brxm, string sfrq1, string sfrq2)
        {
            return SelectFPJL(sjly, mzh, klx, kh, dnlsh, brxm, sfrq1, sfrq2, 0, "", "");
        }
        /// <summary>
        /// 查询已补打的发票记录
        /// </summary>
        /// <param name="sjly">数据来源 0-当前表，1-历史表</param>
        /// <param name="mzh"></param>
        /// <param name="kh"></param>
        /// <param name="dnlsh"></param>
        /// <param name="brxm"></param>
        /// <param name="sfrq1"></param>
        /// <param name="sfrq2"></param>
        /// <param name="dyy"></param>
        /// <param name="dysj1"></param>
        /// <param name="dysj2"></param>
        /// <returns></returns>
        public DataTable SelectFPJL(int sjly, string mzh, int klx, string kh, string dnlsh, string brxm, string sfrq1, string sfrq2,
            int dyy, string dysj1, string dysj2)
        {
            ParameterEx[] parameters = new ParameterEx[12];
            parameters[0].Text = "@mzh";
            parameters[0].Value = mzh;

            parameters[1].Text = "@klx";
            parameters[1].Value = klx;

            parameters[2].Text = "@kh";
            parameters[2].Value = kh;

            parameters[3].Text = "@dnlsh";
            parameters[3].Value = dnlsh;

            parameters[4].Text = "@brxm";
            parameters[4].Value = brxm;

            parameters[5].Text = "@bsfrq";
            parameters[5].Value = sfrq1;

            parameters[6].Text = "@esfrq";
            parameters[6].Value = sfrq2;

            parameters[7].Text = "@dyy";
            parameters[7].Value = dyy;

            parameters[8].Text = "@bdysj";
            parameters[8].Value = dysj1;

            parameters[9].Text = "@edysj";
            parameters[9].Value = dysj2;

            parameters[10].Text = "@sjly";
            parameters[10].Value = sjly;

            parameters[11].Text = "@jgbm";
            parameters[11].Value = FrmMdiMain.Jgbm;

            DataTable dt = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_FPBDJL", parameters, 30);
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Czy"></param>
        /// <param name="Fpzs"></param>
        public EmptyFP GetFPH(int Czy)
        {
            int err_code;
            string err_text;
            int fplx = 0;//挂号票
            SystemCfg cfg1005 = new SystemCfg(1005);
            if (cfg1005.Config.Equals("0"))
            {
                fplx = 1;
            }
            else if (cfg1005.Config.Equals("1") && cfg1005.Config.Equals("2"))
            {
                fplx = 0;
            }
            DataTable tbfp = ts_mz_class.Fun.GetFph(Czy, 1, fplx, out err_code, out err_text, InstanceForm.BDatabase);
            if (err_code != 0 || tbfp.Rows.Count == 0)
            {
                throw new Exception(err_text);
            }
            EmptyFP fp = new EmptyFP(new Guid(tbfp.Rows[0]["fpid"].ToString()),
                                            tbfp.Rows[0]["fph"].ToString(),
                                            Convert.IsDBNull(tbfp.Rows[0]["qz"]) ? "" : tbfp.Rows[0]["qz"].ToString());
            return fp;
        }
        /// <summary>
        /// 打印单张发票
        /// </summary>
        /// <param name="drFpxx">收费发票记录</param>
        /// <param name="newfp">新发票</param>
        /// <param name="Dysj">打印时间</param>
        public void Print(DataRow drFpxx, EmptyFP newfp, string Dysj)
        {
            int err_code = -1;
            string err_text = "";
            SystemCfg cfgsfy = new SystemCfg(3016);
            string Bview = ApiFunction.GetIniString("划价收费", "发票预览", Constant.ApplicationDirectory + "//ClientWindow.ini");//发票预览
            Guid Fpid = new Guid(drFpxx["fpid"].ToString());
            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                //更新发票记录的发票号,打印人，打印时间
                mz_sf.UpdateFpdyxx(Fpid, newfp.Fph, newfp.Qz, InstanceForm.BCurrentUser.EmployeeId, Dysj, out err_text, InstanceForm.BDatabase);
                //更新领用表的当前发票号
                mz_sf.UpdateDqfph(newfp.FplyId, newfp.Fph, newfp.Fph, out err_text, InstanceForm.BDatabase);
                InstanceForm.BDatabase.CommitTransaction();
                drFpxx["发票号"] = newfp.Fph;
            }
            catch (Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                throw new Exception("更新发票号号到原纪录时发生错误：" + Environment.NewLine + err.Message);
            }

            //该段判断代码用途不明，暂时注释 wangzhi 2014-10-10
            //SystemCfg cfg1096 = new SystemCfg( 1096 );
            //if ( cfg1096.Config.Trim() == "1" )
            //{
            //    return;
            //}

            //add by wangzhi 2014-11-14
            string S_REPT_STRING = "补打";
            //门诊发票补打时，是否显示“补打”字样 1=显示,0=不显示' 默认1
            SystemCfg cfg1152 = new SystemCfg(1152, InstanceForm.BDatabase);
            if (cfg1152.Config == "0")
                S_REPT_STRING = "";

            #region 打印发票

            try
            {
                //桑达医保结算项目
                decimal BasFndPay = 0;//	基本医保统筹支付
                decimal AddFndPay = 0;//	补充医保统筹支付
                decimal MerFndPay = 0;//	商业医保统筹支付
                decimal SerFndPay = 0;//	大病互助统筹支付
                decimal PsnPay = 0;//	个人帐户支付
                decimal SelfPay = 0;//		个人自付	
                decimal SelfFee = 0;//		个人自费
                decimal BeginPay = 0;//　	起付金额
                decimal MaxPay = 0;//	超封顶线自付 
                decimal CashPay = 0;//		现金支付
                decimal ybkye = 0;
                int Sky = Convert.ToInt32(Convertor.IsNull(drFpxx["Sfy"], "0"));
                int jlzt = Convert.ToInt32(Convertor.IsNull(drFpxx["记录状态"], "0"));
                string hzxm = drFpxx["姓名"].ToString();
                string mzh = drFpxx["门诊号"].ToString();
                string sDate = drFpxx["收费日期"].ToString();
                string fph = drFpxx["发票号"].ToString();
                string yblx = drFpxx["医保类型"].ToString();
                string jzh = drFpxx["就医号"].ToString();
                string lx = drFpxx["类型"].ToString();
                string kh = drFpxx["卡号"].ToString();

                string _sDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString("yyyy-MM-dd HH:mm:ss");

                if (jlzt == 1)
                    throw new Exception("此发票已作废,不能补打");

                //医保类型
                Yblx yb = new Yblx(Convert.ToInt64(drFpxx["yblx"]), InstanceForm.BDatabase);
                //获取已收费的发票信息
                DataSet dset = mz_sf.GetFpResult("", 0, 0, 0, Fpid, Guid.Empty, TrasenFrame.Forms.FrmMdiMain.Jgbm, out err_code, out err_text, 0, InstanceForm.BDatabase);

                string sex = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(string.Format("select dbo.FUN_ZY_SEEKSEXNAME(xb) from yy_brxx where brxxid in ( select brxxid from mz_fpb where fpid = '{0}' )", Fpid)), "");

                for (int X = 0; X <= dset.Tables[0].Rows.Count - 1; X++)
                {

                    int ksdm = Convert.ToInt32(dset.Tables[0].Rows[X]["ksdm"]);
                    int ysdm = Convert.ToInt32(dset.Tables[0].Rows[X]["ysdm"]);
                    int zxks = Convert.ToInt32(dset.Tables[0].Rows[X]["zxks"]);

                    string ssql = "";
                    string ybkh = "";
                    string ybjzh = "";
                    DataTable ybTb = null;

                    switch (yb.ybjklx)
                    {
                        case 1:
                            break;
                        case 2:
                            #region 桑达医保

                            ssql = "select * from MZ_YBJSB_SDYB where fpid=" + Fpid.ToString();
                            ybTb = FrmMdiMain.Database.GetDataTable(ssql);

                            if (ybTb.Rows.Count > 0)
                            {
                                BasFndPay = Convert.ToDecimal(ybTb.Rows[0]["BasFndPay"]);//	基本医保统筹支付
                                AddFndPay = Convert.ToDecimal(ybTb.Rows[0]["AddFndPay"]);//	补充医保统筹支付
                                MerFndPay = Convert.ToDecimal(ybTb.Rows[0]["MerFndPay"]);//	商业医保统筹支付
                                SerFndPay = Convert.ToDecimal(ybTb.Rows[0]["SerFndPay"]);//	大病互助统筹支付
                                PsnPay = Convert.ToDecimal(ybTb.Rows[0]["PsnPay"]);//	个人帐户支付
                                SelfPay = Convert.ToDecimal(ybTb.Rows[0]["SelfPay"]);//		个人自付	
                                SelfFee = Convert.ToDecimal(ybTb.Rows[0]["SelfFee"]);//		个人自费
                                BeginPay = Convert.ToDecimal(ybTb.Rows[0]["BeginPay"]);//　	起付金额
                                MaxPay = Convert.ToDecimal(ybTb.Rows[0]["MaxPay"]);//	超封顶线自付 
                                CashPay = Convert.ToDecimal(ybTb.Rows[0]["CashPay"]);//		现金支付

                                ybkye = Convert.ToDecimal(Convertor.IsNull(ybTb.Rows[0]["ybkye"], "0"));

                                ybkh = ybTb.Rows[0]["ybkh"].ToString();
                                ybjzh = ybTb.Rows[0]["ybjzh"].ToString();
                            }

                            #endregion
                            break;
                        default:
                            break;
                    }

                    SystemCfg cfg1005 = new SystemCfg(1005);
                    //挂号是否使用收费发票
                    if (lx == "收费" || (lx == "挂号" && cfg1005.Config == "0"))
                    {
                        SystemCfg cfg1046 = new SystemCfg(1046);
                        SystemCfg cfg1096 = new SystemCfg(1096);//门诊收费发票是否打印水晶报表 0否 1是 默认0 Add by zp 2013-10-15

                        string str1046 = cfg1046.Config;

                        //add by zouchihua 2013-3-29
                        if (new SystemCfg(1078).Config.Trim() == "1")// 无条件打印发票
                            str1046 = "1";
                        else if (new SystemCfg(1115).Config.Trim() == "1")//add by jiangzf 当参数1078=0时，并且1115=1无条件打印发票
                            str1046 = "1";

                        if (str1046 == "1")
                        {
                            if (cfg1096.Config.Trim() == "0" || lx == "挂号")
                            {
                                #region 根据PrintInvoiceSetting.ini配置打印
                                SystemCfg cfg1123 = new SystemCfg(1123);
                                PrintClass.OPDInvoice invoice = PrintClass.PrintClass.GetOPDInvoiceInstance(cfg1123.Config);
                                #region 发票内容
                                invoice.OtherInfo = "";
                                invoice.HisName = Constant.HospitalName;
                                invoice.PatientName = hzxm.Trim();
                                invoice.OutPatientNo = mzh.Trim();
                                invoice.DepartmentName = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                                invoice.DoctorName = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);
                                invoice.InvoiceNo = "电脑票号：" + newfp.Fph; //打印新发票的发票号 modify by wangzhi 201-12-1
                                invoice.sex = sex;

                                invoice.sfck = "";
                                invoice.fyck = "";

                                string sql = "select a.pdxh,c.ghlxmc,d.type_name,e.name,byhbz,ybzhzf,ybjjzf,ybbzzf,htdwlx,htdwid,deptaddr,bghpbz,yhlxid,YYSD from vi_mz_ghxx a (nolock) inner join vi_mz_fpb b (nolock) on a.ghxxid=b.ghxxid left join JC_GHLX c on a.ghlb=c.ghlx left join JC_DOCTOR_TYPE d on a.ghjb=d.type_id left join jc_dept_property e on a.ghks=e.dept_id where b.fpid='" + Fpid + "'";
                                DataTable ghTb = FrmMdiMain.Database.GetDataTable(sql);
                                decimal ybzhzf = 0;
                                decimal ybjjzf = 0;
                                decimal ybbzzf = 0;
                                if (ghTb.Rows.Count == 1)
                                {
                                    ybzhzf = Convert.ToDecimal(ghTb.Rows[0]["Ybzhzf"]);
                                    ybjjzf = Convert.ToDecimal(ghTb.Rows[0]["Ybjjzf"]);
                                    ybbzzf = Convert.ToDecimal(ghTb.Rows[0]["Ybbzzf"]);

                                    invoice.htdwlx = Fun.SeekHtdwLx(Convert.ToInt32(ghTb.Rows[0]["htdwlx"]), InstanceForm.BDatabase);
                                    invoice.htdwmc = Fun.SeekHtdwMc(Convert.ToInt32(ghTb.Rows[0]["htdwid"]), InstanceForm.BDatabase);
                                    if (Convert.ToInt32(ghTb.Rows[0]["bghpbz"]) == 1)
                                    {
                                        if (Convert.ToInt32(ghTb.Rows[0]["pdxh"]) > 0)
                                            invoice.hzh = ghTb.Rows[0]["pdxh"].ToString();
                                        invoice.kswz = Convertor.IsNull(ghTb.Rows[0]["deptaddr"], "");
                                        invoice.yysj = Convertor.IsNull(ghTb.Rows[0]["yysd"], "");
                                        invoice.yysd = invoice.yysj;
                                    }
                                }

                                if (cfgsfy.Config == "1")
                                    invoice.Payee = InstanceForm.BCurrentUser.Name;
                                else
                                    invoice.Payee = FrmMdiMain.CurrentUser.LoginCode;

                                DateTime time = Convert.ToDateTime(sDate);
                                invoice.Year = time.Year;
                                invoice.Month = time.Month;
                                invoice.Day = time.Day;

                                bool bqedy = mz_sf.Bqedy(new Guid(Convertor.IsNull(ghTb.Rows[0]["yhlxid"], Guid.Empty.ToString())), InstanceForm.BDatabase);
                                if (bqedy == true && Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]) != 0)
                                {
                                    invoice.Yhje = 0;
                                    invoice.Qfgz = 0;
                                    invoice.Ybzhzf = 0;
                                    invoice.Ybjjzf = 0;
                                    invoice.Ybbzzf = 0;
                                    invoice.Cwjz = 0;
                                    invoice.Ylkje = 0;
                                    invoice.Srje = 0;
                                    invoice.Xjzf = 0;
                                    invoice.Zpzf = 0;
                                }
                                else
                                {

                                    invoice.Yhje = Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]);
                                    invoice.Qfgz = Convert.ToDecimal(dset.Tables[0].Rows[X]["qfgz"]);
                                    invoice.Ybzhzf = ybzhzf;
                                    invoice.Ybjjzf = ybjjzf;
                                    invoice.Ybbzzf = ybbzzf;
                                    invoice.Cwjz = Convert.ToDecimal(dset.Tables[0].Rows[X]["cwjz"]);
                                    invoice.Ylkje = Convert.ToDecimal(dset.Tables[0].Rows[X]["ylkzf"]);
                                    invoice.Srje = Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]);
                                    invoice.Xjzf = Convert.ToDecimal(dset.Tables[0].Rows[X]["xjzf"]);
                                    invoice.Zpzf = Convert.ToDecimal(dset.Tables[0].Rows[X]["zpzf"]);
                                }
                                //Add By chencan 2015-02-28 通过参数设置大小写金额是否取自付金额                        
                                decimal dxxje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                                if (new SystemCfg(1109).Config.Trim() == "1")
                                {
                                    dxxje = invoice.Yhje != 0 ? dxxje - invoice.Yhje : dxxje - (invoice.Ybzhzf + invoice.Ybjjzf + invoice.Ybbzzf);
                                }
                                invoice.TotalMoneyCN = Money.NumToChn(dxxje.ToString());//总金额（大写）
                                invoice.TotalMoneyNum = Convert.ToDecimal(dxxje);//总金额（小写）


                                invoice.Zxks = Fun.SeekDeptName(zxks, InstanceForm.BDatabase);
                                invoice.OtherInfo = Convert.ToDateTime(_sDate).ToString() + S_REPT_STRING;

                                invoice.Ybkye = ybkye;
                                invoice.Yblx = yblx.Trim();
                                invoice.Ybjydjh = jzh.Trim();
                                invoice.Ybkh = ybkh;

                                invoice.Klx = "";
                                invoice.kh = kh;
                                invoice.sfsj = Convert.ToDateTime(sDate).ToLongTimeString();



                                PrintClass.InvoiceItem[] item = null;
                                PrintClass.InvoiceItemDetail[] itemdetail = null; // 增加发票明细项目

                                DataRow[] rows = dset.Tables[1].Select("");
                                item = new PrintClass.InvoiceItem[rows.Length];
                                for (int m = 0; m <= rows.Length - 1; m++)
                                {
                                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//发票项目金额
                                }
                                invoice.Items = item;

                                // 增加发票明细项目
                                DataRow[] rowsdetail = dset.Tables[4].Select("");
                                itemdetail = new PrintClass.InvoiceItemDetail[rowsdetail.Length];
                                for (int m = 0; m <= rowsdetail.Length - 1; m++)
                                {
                                    itemdetail[m].ItemDetailName = rowsdetail[m]["PM"].ToString().Trim();
                                    itemdetail[m].ItemDW = rowsdetail[m]["DW"].ToString().Trim();
                                    itemdetail[m].ItemGG = rowsdetail[m]["GG"].ToString().Trim();
                                    itemdetail[m].ItemJS = Convert.ToDecimal(rowsdetail[m]["JS"]);
                                    itemdetail[m].ItemNum = Convert.ToDecimal(rowsdetail[m]["SL"]);
                                    itemdetail[m].ItemPrice = Convert.ToDecimal(rowsdetail[m]["DJ"]);
                                    itemdetail[m].ItemJE = Convert.ToDecimal(rowsdetail[m]["JE"]);
                                }
                                invoice.ItemDetail = itemdetail;

                                if (invoice is PrintClass.OPDInvoiceHeNan || invoice.GetType().IsSubclassOf(typeof(PrintClass.OPDInvoiceHeNan)))
                                {

                                    DataTable tbCF = InstanceForm.BDatabase.GetDataTable(string.Format("select * from mz_cfb where fpid='{0}'", Fpid));
                                    string sf_datetime = tbCF.Rows[0]["SFRQ"].ToString();
                                    DataTable tbcf1 = new DataTable();
                                    try
                                    {
                                        //这里还需要根据执行科室分组
                                        string[] GroupbyField1 = { "zxksmc", "ZXKS", "ysxm" };
                                        string[] ComputeField1 = { "ZJE" };
                                        string[] CField1 = { "sum" };
                                        //TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                                        //xcset1.TsDataTable = tbCF;
                                        // tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " ");
                                        tbcf1 = GroupByDataTable(tbCF, GroupbyField1, ComputeField1, CField1);
                                    }
                                    catch (Exception ex)
                                    {
                                        System.Windows.Forms.MessageBox.Show(ex.Message + "ddddd");
                                    }
                                    //
                                    int index = 0;
                                    foreach (DataRow r in tbcf1.Rows)
                                    {
                                        DataTable tbCfmx = InstanceForm.BDatabase.GetDataTable(string.Format("select SUM(a.JE ) je,d.ITEM_NAME pm from mz_cfb_mx  a join MZ_CFB b on a.CFID=b.CFID join JC_STAT_ITEM c on a.TJDXMDM=c.code  inner JOIN JC_MZFP_XM d on c.mzfp_code=d.code      where    b.zxks={0} and b.fpid='{1}'  group by d.ITEM_NAME,d.CODE", r["ZXKS"], Fpid));
                                        switch (index)
                                        {
                                            case 0:
                                                ((PrintClass.OPDInvoiceHeNan)invoice).CheckingParts1 = new PrintClass.CheckingPart();
                                                SetHeNanCheckingPartValue(((PrintClass.OPDInvoiceHeNan)invoice).CheckingParts1, invoice.HisName, Convertor.IsNull(r["zxksmc"], ""),
                                                    Convertor.IsNull(r["ysxm"], ""), invoice.PatientName, Convert.ToDecimal(Convertor.IsNull(r["zje"], "0.0")), tbCfmx, sf_datetime);
                                                break;
                                            case 1:
                                                ((PrintClass.OPDInvoiceHeNan)invoice).CheckingParts2 = new PrintClass.CheckingPart();
                                                SetHeNanCheckingPartValue(((PrintClass.OPDInvoiceHeNan)invoice).CheckingParts2, invoice.HisName, Convertor.IsNull(r["zxksmc"], ""),
                                                   Convertor.IsNull(r["ysxm"], ""), invoice.PatientName, Convert.ToDecimal(Convertor.IsNull(r["zje"], "0.0")), tbCfmx, sf_datetime);
                                                break;
                                            case 2:
                                                ((PrintClass.OPDInvoiceHeNan)invoice).CheckingParts3 = new PrintClass.CheckingPart();
                                                SetHeNanCheckingPartValue(((PrintClass.OPDInvoiceHeNan)invoice).CheckingParts3, invoice.HisName, Convertor.IsNull(r["zxksmc"], ""),
                                                   Convertor.IsNull(r["ysxm"], ""), invoice.PatientName, Convert.ToDecimal(Convertor.IsNull(r["zje"], "0.0")), tbCfmx, sf_datetime);
                                                break;
                                        }
                                        index++;
                                    }

                                    DataRow rowYBJS = InstanceForm.BDatabase.GetDataRow(string.Format("select * from MZ_YBJSB_NY_DRCJ where bjlzt = 0 and fpid='{0}'", Fpid));
                                    ((PrintClass.OPDInvoiceHeNan)invoice).Database = InstanceForm.BDatabase;
                                    ((PrintClass.OPDInvoiceHeNan)invoice).Fpid = Fpid;
                                    ((PrintClass.OPDInvoiceHeNan)invoice).InsureData = rowYBJS;
                                }

                                if (Bview != "true")
                                    invoice.Print();
                                else
                                    invoice.Preview();
                                #endregion
                                #endregion
                            }
                            else
                            {
                                #region 收费打印发票用水晶报表
                                string fyck = "";

                                ParameterEx[] paramters = new ParameterEx[35];
                                paramters[0].Text = "V_医院名称";
                                paramters[0].Value = Constant.HospitalName;

                                paramters[1].Text = "V_病人姓名";
                                paramters[1].Value = hzxm.Trim();

                                paramters[2].Text = "V_门诊号";
                                paramters[2].Value = mzh.Trim();

                                paramters[3].Text = "V_科室名称";
                                paramters[3].Value = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);

                                paramters[4].Text = "V_医生名称";
                                paramters[4].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                                paramters[5].Text = "V_电脑票号";
                                paramters[5].Value = "电脑票号：" + Convert.ToString(dset.Tables[0].Rows[X]["fph"]);

                                decimal ybzhzf = 0;
                                decimal ybjjzf = 0;
                                ;
                                decimal ybbzzf = 0;

                                paramters[6].Text = "V_大写总金额";
                                paramters[6].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                                paramters[7].Text = "V_小写总金额";
                                paramters[7].Value = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);

                                paramters[8].Text = "V_收款人";
                                if (cfgsfy.Config == "1") //显示收款人姓名还是代码
                                    paramters[8].Value = InstanceForm.BCurrentUser.Name;  //收款人
                                else
                                    paramters[8].Value = InstanceForm.BCurrentUser.LoginCode;

                                string sql = "select a.pdxh,c.ghlxmc,d.type_name,e.name,byhbz,ybzhzf,ybjjzf,ybbzzf,htdwlx,htdwid,deptaddr,bghpbz,yhlxid,yysd from vi_mz_ghxx a (nolock) inner join vi_mz_fpb b (nolock) on a.ghxxid=b.ghxxid left join JC_GHLX c on a.ghlb=c.ghlx left join JC_DOCTOR_TYPE d on a.ghjb=d.type_id left join jc_dept_property e on a.ghks=e.dept_id where b.fpid='" + Fpid + "'";
                                DataTable ghTb = FrmMdiMain.Database.GetDataTable(sql);

                                bool bqedy = mz_sf.Bqedy(new Guid(Convertor.IsNull(ghTb.Rows[0]["yhlxid"], Guid.Empty.ToString())), InstanceForm.BDatabase);
                                if (bqedy == true && Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]) != 0)
                                {
                                    paramters[9].Text = "V_优惠金额";
                                    paramters[9].Value = 0;

                                    paramters[10].Text = "V_欠费挂账";
                                    paramters[10].Value = 0;

                                    paramters[11].Text = "V_医保账户支付";
                                    paramters[11].Value = 0;

                                    paramters[12].Text = "V_医保基金支付";
                                    paramters[12].Value = 0;

                                    paramters[13].Text = "V_医保补助支付";
                                    paramters[13].Value = 0;

                                    paramters[14].Text = "V_财务记账";
                                    paramters[14].Value = 0;

                                    paramters[15].Text = "V_银联卡金额";
                                    paramters[15].Value = 0;

                                    paramters[16].Text = "V_舍入金额";
                                    paramters[16].Value = 0;

                                    paramters[17].Text = "V_现金支付";
                                    paramters[17].Value = 0;

                                    paramters[18].Text = "V_支票支付";
                                    paramters[18].Value = 0;
                                }
                                else
                                {
                                    paramters[9].Text = "V_优惠金额";
                                    paramters[9].Value = Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]);

                                    paramters[10].Text = "V_欠费挂账";
                                    paramters[10].Value = Convert.ToDecimal(dset.Tables[0].Rows[X]["qfgz"]);

                                    paramters[11].Text = "V_医保账户支付";
                                    paramters[11].Value = ybzhzf;

                                    paramters[12].Text = "V_医保基金支付";
                                    paramters[12].Value = ybjjzf;

                                    paramters[13].Text = "V_医保补助支付";
                                    paramters[13].Value = ybbzzf;

                                    paramters[14].Text = "V_财务记账";
                                    paramters[14].Value = Convert.ToDecimal(dset.Tables[0].Rows[X]["cwjz"]);

                                    paramters[15].Text = "V_银联卡金额";
                                    paramters[15].Value = Convert.ToDecimal(dset.Tables[0].Rows[X]["ylkzf"]);

                                    paramters[16].Text = "V_舍入金额";
                                    paramters[16].Value = Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]);

                                    paramters[17].Text = "V_现金支付";
                                    paramters[17].Value = Convert.ToDecimal(dset.Tables[0].Rows[X]["xjzf"]);

                                    paramters[18].Text = "V_支票支付";
                                    paramters[18].Value = Convert.ToDecimal(dset.Tables[0].Rows[X]["zpzf"]);
                                }


                                paramters[19].Text = "V_执行科室";
                                paramters[19].Value = Fun.SeekDeptName(zxks, InstanceForm.BDatabase);


                                paramters[20].Text = "V_卡余额";
                                paramters[20].Value = "";

                                decimal _ybkye = ybkye - ybzhzf;
                                paramters[21].Text = "V_医保卡余额";
                                paramters[21].Value = _ybkye;

                                if (_ybkye < 0)
                                    paramters[21].Value = 0;

                                paramters[22].Text = "V_医保卡号";
                                paramters[22].Value = ybkh;

                                paramters[23].Text = "V_医保类型";
                                paramters[23].Value = yblx.Trim();

                                paramters[24].Text = "V_结算单号";
                                paramters[24].Value = "";

                                paramters[25].Text = "V_卡类型";
                                paramters[25].Value = "";

                                paramters[26].Text = "V_收费窗口";
                                paramters[26].Value = "";

                                paramters[27].Text = "V_发药窗口";
                                paramters[27].Value = fyck;

                                paramters[28].Text = "V_合同单位类型";
                                paramters[28].Value = "";

                                paramters[29].Text = "V_合同单位名称";
                                paramters[29].Value = "";

                                paramters[30].Text = "V_卡号";
                                paramters[30].Value = kh;

                                paramters[31].Text = "V_收费时间";
                                paramters[31].Value = Convert.ToDateTime(sDate);

                                paramters[32].Text = "V_挂号级别";
                                paramters[32].Value = "";

                                paramters[33].Text = "V_备注";
                                paramters[33].Value = _sDate + S_REPT_STRING;

                                paramters[34].Text = "V_现金支付_大写";
                                paramters[34].Value = Money.NumToChn(Convert.ToDecimal(dset.Tables[0].Rows[X]["xjzf"]).ToString());

                                DataTable dt_fpmx = dset.Tables[1].Copy();//得到发票项目明细 
                                dt_fpmx.TableName = "发票明细";

                                DataTable dt_sfmx = dset.Tables[4].Copy();
                                dt_sfmx.TableName = "项目明细";

                                DataSet _dset = new DataSet();
                                _dset.Tables.Add(dt_fpmx);
                                _dset.Tables.Add(dt_sfmx);

                                string reportFile = Constant.ApplicationDirectory + "\\Report\\MZSF_正式发票.rpt";
                                //===begin 萍乡需求 社区发票与医院发票格式不一致，add by wangzhi 2014-10-08
                                string strValue = ApiFunction.GetIniString("门诊发票模板", "模板名称", System.Windows.Forms.Application.StartupPath + "\\ClientWindow.ini");
                                if (!string.IsNullOrEmpty(strValue))
                                    reportFile = Constant.ApplicationDirectory + "\\Report\\" + strValue;
                                //===end
                                bool isbview = true; //是否直接打印
                                if (Bview == "true")
                                    isbview = false;
                                FrmReportView fView = new FrmReportView(_dset, reportFile, paramters, isbview);

                                if (!isbview)
                                    fView.Show();
                                #endregion
                            }
                        }
                        else if (str1046 == "2")
                        {
                            #region 打印收费小票

                            //更新发药窗口 由于存在多执行科室不分票的情况 具体发药窗口输出请修改 sp_yf_MZSF_FYCK
                            string fyck = "";

                            ssql = "select * from mz_fpb  (nolock)  where fpid='" + new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()) + "'";
                            DataTable tbFp = InstanceForm.BDatabase.GetDataTable(ssql);

                            ParameterEx[] paramters = new ParameterEx[19];
                            paramters[0].Text = "V_医院名称";
                            paramters[0].Value = Constant.HospitalName;

                            paramters[1].Text = "V_收费日期";
                            paramters[1].Value = sDate;

                            paramters[2].Text = "V_收费员";
                            if (cfgsfy.Config == "1")
                                paramters[2].Value = InstanceForm.BCurrentUser.Name;
                            else
                                paramters[2].Value = InstanceForm.BCurrentUser.LoginCode;

                            paramters[3].Text = "V_病人姓名";
                            paramters[3].Value = hzxm;

                            paramters[4].Text = "V_门诊号";
                            paramters[4].Value = mzh;

                            paramters[5].Text = "V_卡号";
                            paramters[5].Value = kh;

                            paramters[6].Text = "V_电脑流水号";
                            paramters[6].Value = dset.Tables[0].Rows[X]["dnlsh"].ToString();

                            paramters[7].Text = "V_消费金额";
                            paramters[7].Value = dset.Tables[0].Rows[X]["zje"].ToString();


                            // ye = ye - Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);


                            paramters[8].Text = "V_卡余额";
                            paramters[8].Value = "";

                            paramters[9].Text = "V_医生";
                            paramters[9].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                            paramters[10].Text = "V_科室";
                            paramters[10].Value = Fun.SeekEmpName(ksdm, InstanceForm.BDatabase);

                            paramters[11].Text = "V_优惠金额";
                            paramters[11].Value = dset.Tables[0].Rows[X]["yhje"].ToString();

                            paramters[12].Text = "V_医保余额";
                            paramters[12].Value = "0";

                            paramters[13].Text = "V_个人帐户";
                            paramters[13].Value = "0";//直接获取收银窗口的值 医保支付

                            paramters[14].Text = "V_现金支付";
                            paramters[14].Value = "0";//直接获取收银窗口的值

                            paramters[15].Text = "V_银联支付";
                            paramters[15].Value = "0";

                            paramters[16].Text = "V_卡支付";
                            paramters[16].Value = "0";

                            paramters[17].Text = "V_位置";
                            paramters[17].Value = "";

                            paramters[18].Text = "V_支付前卡余额";
                            paramters[18].Value = "0";

                            string _sHjid = dset.Tables[1].Rows[X]["hjid"].ToString().Trim();
                            _sHjid = _sHjid.Replace("'", "''");


                            DataRow[] rows = dset.Tables[1].Select("hjid='" + _sHjid + "'");
                            DataTable dtFpxm = dset.Tables[1].Clone();
                            dtFpxm.TableName = "收费明细";
                            foreach (DataRow dr in rows)
                                dtFpxm.Rows.Add(dr.ItemArray);

                            DataRow[] rowsdetail = dset.Tables[4].Select("hjid='" + _sHjid + "'");
                            DataTable dtFpwjxm = dset.Tables[4].Clone();
                            dtFpwjxm.TableName = "收费物价明细";
                            foreach (DataRow dr in rowsdetail)
                                dtFpwjxm.Rows.Add(dr.ItemArray);
                            DataSet _dset = new DataSet();
                            _dset.Tables.Add(dtFpxm);
                            _dset.Tables.Add(dtFpwjxm);

                            string reportFile = Constant.ApplicationDirectory + "\\Report\\MZSF_小票.rpt";
                            TrasenFrame.Forms.FrmReportView fView = new FrmReportView(_dset, reportFile,
                                paramters, true);
                            //fView.Show();
                            #endregion
                        }
                    }
                    else
                    {
                        #region 打印挂号发票格式
                        int _pdxh = 0;
                        string _ghlx = "";
                        string _ysjb = "";
                        string _ghks = "";
                        string yysd = "";
                        string dnlsh = "";
                        string ghkh = "";
                        string sql = "select f.kh,a.dnlxh,a.pdxh,c.ghlxmc,d.type_name,e.name,ybzhzf,ybjjzf,ybbzzf,yhlxid,a.yysd from vi_mz_ghxx a (nolock) inner join vi_mz_fpb b (nolock) on a.ghxxid=b.ghxxid inner join yy_kdjb f on a.kdjid=f.kdjid left join JC_GHLX c on a.ghlb=c.ghlx left join JC_DOCTOR_TYPE d on a.ghjb=d.type_id left join jc_dept_property e on a.ghks=e.dept_id where b.fpid='" + Fpid + "'";
                        DataTable ghTb = FrmMdiMain.Database.GetDataTable(sql);
                        decimal ybzhzf = 0;
                        decimal ybjjzf = 0;
                        decimal ybbzzf = 0;
                        if (ghTb.Rows.Count > 0)
                        {
                            _pdxh = Convert.ToInt32(ghTb.Rows[0]["pdxh"]);
                            _ghlx = ghTb.Rows[0]["ghlxmc"].ToString().Trim();
                            _ysjb = ghTb.Rows[0]["type_name"].ToString().Trim();
                            _ghks = ghTb.Rows[0]["name"].ToString().Trim();
                            ybzhzf = Convert.ToDecimal(ghTb.Rows[0]["Ybzhzf"]);
                            ybjjzf = Convert.ToDecimal(ghTb.Rows[0]["Ybjjzf"]);
                            ybbzzf = Convert.ToDecimal(ghTb.Rows[0]["Ybbzzf"]);
                            yysd = Convertor.IsNull(ghTb.Rows[0]["yysd"], "");
                            dnlsh = Convertor.IsNull(ghTb.Rows[0]["dnlxh"], "");
                            ghkh = Convertor.IsNull(ghTb.Rows[0]["kh"], "");
                        }

                        //挂号票是否使用水晶报表
                        if ((new TrasenFrame.Classes.SystemCfg(1006)).Config == "0")
                        {
                            #region 打印
                            PrintClass.RegisterInvoice Rinvoice = PrintClass.PrintClass.GetRegisterInvoice(cfg1005.Config);
                            Rinvoice.yysd = yysd;
                            Rinvoice.DNLSH = dnlsh;
                            Rinvoice.kh = ghkh;
                            Rinvoice.OtherInfo = "";
                            Rinvoice.HisName = Constant.HospitalName;
                            Rinvoice.PatientName = hzxm;
                            Rinvoice.OutPatientNo = mzh.Trim();
                            Rinvoice.DepartmentName = _ghks;
                            Rinvoice.Pdxh = _pdxh;//排队序号 Modify by Tany 2008-12-26
                            Rinvoice.DoctorName = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);
                            Rinvoice.InvoiceNo = "电脑票号：" + fph.Trim();
                            Rinvoice.sex = sex;

                            //打印：自付金额=总金额-优惠金额
                            decimal dzfje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]) - Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]);
                            //Rinvoice.TotalMoneyCN = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());
                            //Rinvoice.TotalMoneyNum = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                            Rinvoice.TotalMoneyCN = Money.NumToChn(dzfje.ToString());
                            Rinvoice.TotalMoneyNum = dzfje;

                            if (cfgsfy.Config == "1")
                                Rinvoice.Payee = InstanceForm.BCurrentUser.Name;
                            else
                                Rinvoice.Payee = FrmMdiMain.CurrentUser.LoginCode;

                            DateTime time = Convert.ToDateTime(sDate);
                            Rinvoice.Year = time.Year;
                            Rinvoice.Month = time.Month;
                            Rinvoice.Day = time.Day;


                            bool bqedy = mz_sf.Bqedy(new Guid(Convertor.IsNull(ghTb.Rows[0]["yhlxid"], Guid.Empty.ToString())), InstanceForm.BDatabase);
                            if (bqedy == true && Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]) != 0)
                            {
                                Rinvoice.Yhje = Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]);
                                Rinvoice.Qfgz = Convert.ToDecimal(dset.Tables[0].Rows[X]["qfgz"]);
                                Rinvoice.Ybzhzf = ybzhzf;
                                Rinvoice.Ybjjzf = ybjjzf;
                                Rinvoice.Ybbzzf = ybbzzf;
                                Rinvoice.Cwjz = Convert.ToDecimal(dset.Tables[0].Rows[X]["cwjz"]);
                                Rinvoice.Ylkje = Convert.ToDecimal(dset.Tables[0].Rows[X]["ylkzf"]);
                                Rinvoice.Srje = Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]);
                                Rinvoice.Xjzf = Convert.ToDecimal(dset.Tables[0].Rows[X]["xjzf"]);
                            }
                            else
                            {
                                Rinvoice.Yhje = 0;
                                Rinvoice.Qfgz = 0;
                                Rinvoice.Ybzhzf = 0;
                                Rinvoice.Ybjjzf = 0;
                                Rinvoice.Ybbzzf = 0;
                                Rinvoice.Cwjz = 0;
                                Rinvoice.Ylkje = 0;
                                Rinvoice.Srje = 0;
                                //Rinvoice.Xjzf = 0;
                                Rinvoice.Xjzf = 0;
                            }

                            Rinvoice.Zxks = Fun.SeekDeptName(zxks, InstanceForm.BDatabase);
                            Rinvoice.Ybkye = 0;
                            Rinvoice.Yblx = yblx;
                            Rinvoice.Ybjydjh = ybjzh;
                            Rinvoice.RegisterType = _ysjb;
                            Rinvoice.Ybkh = ybkh;

                            PrintClass.InvoiceItem[] item = null;

                            DataRow[] rows = dset.Tables[1].Select();
                            item = new PrintClass.InvoiceItem[rows.Length];
                            for (int m = 0; m <= rows.Length - 1; m++)
                            {
                                //item[m].ItemCode = rows[m]["XMDM"].ToString().Trim();
                                item[m].ItemCode = rows[m]["code"].ToString().Trim();
                                item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//发票项目金额

                                //挂号专有项目 Modify By Tany 2008-12-22
                                if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                                {
                                    Rinvoice.RegisterFee = item[m].ItemMoney.ToString();
                                }
                                if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                                {
                                    Rinvoice.ExamineFee = item[m].ItemMoney.ToString();
                                }
                                if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                                {
                                    Rinvoice.JerqueFee = item[m].ItemMoney.ToString();
                                }
                                if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                                {
                                    Rinvoice.MaterialFee = item[m].ItemMoney.ToString();
                                }
                            }
                            Rinvoice.Items = item;
                            Rinvoice.Ghlx = _ghlx;

                            if (Bview != "true")
                                Rinvoice.Print();
                            else
                                Rinvoice.Preview();
                            #endregion
                        }
                        else
                        {
                            #region 水晶报表打印
                            ParameterEx[] parameters = new ParameterEx[25];
                            parameters[0].Text = "医院名称";
                            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                            parameters[1].Text = "发票号";
                            parameters[1].Value = fph.Trim();

                            DateTime time = Convert.ToDateTime(sDate);

                            parameters[2].Text = "年";
                            parameters[2].Value = time.Year;

                            parameters[3].Text = "月";
                            parameters[3].Value = time.Month;

                            parameters[4].Text = "日";
                            parameters[4].Value = time.Day;

                            parameters[5].Text = "挂号类型";
                            parameters[5].Value = _ghlx;

                            parameters[6].Text = "科室";
                            parameters[6].Value = _ghks;

                            parameters[7].Text = "医生";
                            parameters[7].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                            parameters[8].Text = "医生级别";
                            parameters[8].Value = _ysjb;

                            parameters[9].Text = "挂号序号";
                            parameters[9].Value = _pdxh;

                            PrintClass.InvoiceItem[] item = null;
                            DataRow[] rows = dset.Tables[1].Select();
                            string _ghf = "";
                            string _zcf = "";
                            string _jcf = "";
                            string _clf = "";
                            item = new PrintClass.InvoiceItem[rows.Length];
                            for (int m = 0; m <= rows.Length - 1; m++)
                            {
                                //item[m].ItemCode = rows[m]["XMDM"].ToString().Trim();
                                item[m].ItemCode = rows[m]["code"].ToString().Trim();
                                item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//发票项目金额

                                //挂号专有项目 Modify By Tany 2008-12-22
                                if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                                {
                                    _ghf = item[m].ItemMoney.ToString();
                                }
                                if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                                {
                                    _zcf = item[m].ItemMoney.ToString();
                                }
                                if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                                {
                                    _jcf = item[m].ItemMoney.ToString();
                                }
                                if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                                {
                                    _clf = item[m].ItemMoney.ToString();
                                }
                            }

                            parameters[10].Text = "挂号费";
                            parameters[10].Value = _ghf;

                            parameters[11].Text = "诊查费";
                            parameters[11].Value = _zcf;

                            parameters[12].Text = "检查费";
                            parameters[12].Value = _jcf;

                            parameters[13].Text = "材料费";
                            parameters[13].Value = _clf;

                            parameters[14].Text = "小写金额";
                            parameters[14].Value = dset.Tables[0].Rows[X]["zje"].ToString();

                            parameters[15].Text = "大写金额";
                            parameters[15].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                            parameters[16].Text = "收款员";

                            if (cfgsfy.Config == "1")
                                parameters[16].Value = FrmMdiMain.CurrentUser.Name;
                            else
                                parameters[16].Value = FrmMdiMain.CurrentUser.LoginCode;

                            parameters[17].Text = "病人姓名";
                            parameters[17].Value = hzxm;

                            parameters[18].Text = "门诊号";
                            parameters[18].Value = mzh.Trim();

                            parameters[19].Text = "类型";
                            parameters[19].Value = "";

                            parameters[20].Text = "医保卡号";
                            parameters[20].Value = ybjzh;

                            parameters[21].Text = "医保支付";
                            parameters[21].Value = Convert.ToString(Convert.ToDecimal(dset.Tables[0].Rows[X]["ybzf"]));

                            parameters[22].Text = "医保卡支付";
                            parameters[22].Value = Convert.ToString(PsnPay);

                            parameters[23].Text = "现金支付";
                            parameters[23].Value = dset.Tables[0].Rows[X]["xjzf"].ToString();

                            parameters[24].Text = "医保余额";
                            parameters[24].Value = Convert.ToString(ybkye);

                            TrasenFrame.Forms.FrmReportView fv;

                            if (Bview == "true")
                            {
                                fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号发票.rpt", parameters);
                                if (!fv.LoadReportSuccess)
                                {
                                    fv.Dispose();
                                }
                                else
                                {
                                    fv.Show();
                                }
                            }
                            else
                            {
                                fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号发票.rpt", parameters, true);
                            }
                            #endregion
                        }
                        #endregion
                    }
                }


            }
            catch (System.Exception err)
            {
                throw new Exception("输出到打印机打印的过程中发生错误：" + err.Message + Environment.NewLine + err.StackTrace);
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lx"></param>
        /// <param name="fph"></param>
        /// <param name="Fpid"></param>
        /// <param name="bak">1-查历史表</param>
        /// <returns></returns>
        public DataRow SelectFpxx(int lx, string fph, Guid Fpid, int bak)
        {
            ParameterEx[] parameters = new ParameterEx[15];
            parameters[0].Text = "@rq1";
            parameters[0].Value = "";

            parameters[1].Text = "@rq2";
            parameters[1].Value = "";

            parameters[2].Text = "@fph";
            parameters[2].Value = fph;

            //parameters[3].Text = "@blh";
            //parameters[3].Value = "";

            parameters[3].Text = "@dnlsh";
            parameters[3].Value = "";

            parameters[4].Text = "@brxm";
            parameters[4].Value = "";

            parameters[5].Text = "@sfy";
            parameters[5].Value = 0;

            parameters[6].Text = "@yblx";
            parameters[6].Value = "0";

            parameters[7].Text = "@bak";
            parameters[7].Value = bak;

            parameters[8].Text = "@lx";
            parameters[8].Value = lx;

            parameters[9].Text = "@kh";
            parameters[9].Value = "";

            parameters[10].Text = "@fph1";
            parameters[10].Value = "";

            parameters[11].Text = "@fph2";
            parameters[11].Value = "";

            parameters[12].Text = "@zffs";
            parameters[12].Value = "";

            parameters[13].Text = "@fpid";
            parameters[13].Value = Fpid.ToString();

            parameters[14].Text = "@klx";
            parameters[14].Value = 0;


            DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_FPCX", parameters, 30);
            if (tb.Rows.Count == 0)
                throw new Exception("没有找到发票记录");
            return tb.Rows[0];
        }

        /// <summary>
        /// 设置河南发票核算联内容
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="HospitalName"></param>
        /// <param name="DeptName"></param>
        /// <param name="DoctorName"></param>
        /// <param name="PatientName"></param>
        /// <param name="TotalMoney"></param>
        /// <param name="tbFpItem"></param>
        private void SetHeNanCheckingPartValue(PrintClass.CheckingPart cp, string HospitalName , string DeptName , string DoctorName , string PatientName , decimal TotalMoney , DataTable tbFpItem , string sf_datetime)
        {
            cp.HospitalName = HospitalName;
            cp.DeptName = DeptName;
            cp.DoctorName = DoctorName;
            cp.PatientName = PatientName;
            cp.TotalMoney = TotalMoney;
            cp.DateTime = sf_datetime;
            cp.Items = new PrintClass.InvoiceItem[tbFpItem.Rows.Count];
            decimal total_money = 0;
            for (int i = 0; i < tbFpItem.Rows.Count; i++)
            {
                cp.Items[i] = new PrintClass.InvoiceItem();
                cp.Items[i].ItemName = tbFpItem.Rows[i]["PM"].ToString().Trim();
                cp.Items[i].ItemMoney = Convert.ToDecimal(tbFpItem.Rows[i]["JE"]);
                total_money = total_money + cp.Items[i].ItemMoney;
            }
            cp.TotalMoney = total_money;
        }


        public static DataTable GroupByDataTable(DataTable tbtb, string[] GroupByField , string[] ComputeField , string[] Cfield)
        {
            DataTable tbCompute = new DataTable();
            if (tbtb.Rows.Count <= 0)
                return tbCompute;
            List<string> lstCol = new List<string>();
            List<string> lstHj = new List<string>();

            #region 数据验证
            for (int i = 0; i < tbtb.Columns.Count; i++)
            {
                lstCol.Add(tbtb.Columns[i].ColumnName.ToLower().Trim());
            }

            for (int i = 0; i < GroupByField.Length; i++)
            {
                if (!lstCol.Contains(GroupByField[i].ToLower().Trim()))
                {
                    throw new Exception(string.Format("分组发生错误:找不到GroupByField:{0}", GroupByField[i].Trim().ToLower()));
                }
            }

            for (int i = 0; i < ComputeField.Length; i++)
            {
                if (!lstCol.Contains(ComputeField[i].ToLower().Trim()))
                {
                    throw new Exception(string.Format("分组发生错误:找不到ComputeField:{0}", ComputeField[i].Trim().ToLower()));
                }
            }
            lstHj.Add("sum");
            lstHj.Add("max");
            lstHj.Add("min");
            lstHj.Add("count");
            for (int i = 0; i < Cfield.Length; i++)
            {
                if (!lstHj.Contains(Cfield[i].Trim().ToLower().Trim()))
                {
                    throw new Exception(string.Format("分组发生错误:不支持Cfield:{0}", Cfield[i]));
                }
            }

            if (ComputeField.Length != Cfield.Length)
            {
                throw new Exception("分组发生错误:ComputeField与Cfield数组长度不一致");
            }
            #endregion

            #region 添加列
            for (int i = 0; i <= GroupByField.Length - 1; i++)
                tbCompute.Columns.Add(GroupByField[i]);
            for (int i = 0; i <= ComputeField.Length - 1; i++)
                tbCompute.Columns.Add(ComputeField[i]);
            if (tbtb.Rows.Count <= 0)
                return tbCompute;
            #endregion

            #region 计算
            DataTable tb = tbtb.Copy();
            string strFilter = " 1=1 ";
            try
            {

                for (int i = 0; 0 < tb.Rows.Count; i++)
                {
                    DataRow insertRow = tbCompute.NewRow();
                    strFilter = " 1=1 ";
                    for (int j = 0; j < GroupByField.Length; j++)
                    {

                        if (tb.Rows[0][GroupByField[j]] is DBNull)
                        {
                            strFilter += string.Format(" and {0} is null ", GroupByField[j].ToString().Trim()
                            );
                        }
                        else
                        {
                            strFilter += string.Format(" and {0}='{1}'", GroupByField[j].ToString().Trim(),
                              tb.Rows[0][GroupByField[j]].ToString().Trim());
                        }

                        //分组列赋值
                        insertRow[GroupByField[j]] = tb.Rows[0][GroupByField[j]];
                    }

                    tb.DefaultView.RowFilter = strFilter;
                    DataTable tbTemp = tb.DefaultView.Table;

                    //求汇总
                    for (int mm = 0; mm < ComputeField.Length; mm++)
                    {
                        string strCompute = string.Format("{0}({1})", Cfield[mm], ComputeField[mm]);
                        insertRow[ComputeField[mm]] = tbTemp.Compute(strCompute, "").ToString();
                    }

                    tbCompute.Rows.Add(insertRow);
                    DataRow[] rows = tb.Select(strFilter);
                    if (rows.Length <= 0)
                    {
                        throw new Exception("分组发生错误,未成成功移除行:" + strFilter);
                    }
                    for (int w = 0; w < rows.Length; w++)
                    {
                        tb.Rows.Remove(rows[w]);
                    }

                }
            }
            catch (Exception err)
            {
                throw new Exception("分组发生错误" + strFilter + " " + err.Message);
            }
            #endregion

            return tbCompute;
        }
    }
}
