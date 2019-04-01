using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using Ts_Visit_Class;
using MySql.Data.MySqlClient;
using ts_mzys_class;

namespace ts_mz_class
{
    /// <summary>
    /// 预约挂号类  add by zp 2013-04-16
    /// </summary>
    public class Mz_YYgh
    {

        /// <summary>
        /// 获取排班委托
        /// </summary>
        /// <param name="dt"></param>
        public delegate void Delegate_GetPbInfo(DataTable dt);

        /// <summary>
        /// 保存预约号
        /// </summary>
        /// <param name="yyid">预约id</param>
        /// <param name="yylx">预约类型</param>
        /// <param name="kh">卡号</param>
        /// <param name="brxm">病人姓名</param>
        /// <param name="xb">性别代码</param>
        /// <param name="csrq">出生日期</param>
        /// <param name="jtdz">家庭地址</param>
        /// <param name="lxdh">联系电话</param>
        /// <param name="sfzh">身份证号</param>
        /// <param name="yzm">验证码</param>
        /// <param name="ghks">挂号科室id</param>
        /// <param name="ghjb">挂号级别id</param>
        /// <param name="ghys">挂号医生id</param>
        /// <param name="pdxh">排队序号</param>
        /// <param name="djsj">登记时间</param>
        /// <param name="djy">登记员</param>
        /// <param name="yyrq">预约日期</param>
        /// <param name="yysd">预约时段</param>
        /// <param name="sxsj">失效时间</param>
        /// <param name="bscbz">删除标志 </param>
        /// <param name="yyqjd">预约区间段 1上午 2下午</param>
        /// <param name="cardflag">是否有卡 0无卡预约 1有卡预约 </param>
        /// <param name="paymoneyflag">支付标志 0未支付 1已支付</param>
        /// <param name="gh_fee">所需支付的挂号费用</param>
        /// <param name="newYzm"></param>
        /// <param name="newPdxh"></param>
        /// <param name="newYYid"></param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        public static void YYGH_save(Guid yyid, Mz_YYgh.YYgh_Sort yylx, string kh, string brxm, string xb, object csrq,
            string jtdz, string lxdh, string sfzh, string yzm, int ghks, int ghjb, int ghys, int pdxh,
            string djsj, int djy, object yyrq, string yysd, object sxsj, int bscbz, int yyqjd, int cardflag,
            int paymoneyflag, decimal gh_fee, int klx, out string newYzm, string ptid,
            out string newPdxh, out Guid newYYid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            _DataBase.BeginTransaction();
            try
            {
                ParameterEx[] parameters = new ParameterEx[31];
                parameters[0].Text = "@yyid";
                parameters[0].Value = yyid; //8b8d0fd1-b4da-49a4-a0c1-b20e6b207d1b

                parameters[1].Text = "@yylx";
                parameters[1].Value = (int)yylx;//1

                parameters[2].Text = "@kh";
                parameters[2].Value = kh;//000001

                parameters[3].Text = "@brxm";
                parameters[3].Value = brxm;

                parameters[4].Text = "@xb";
                parameters[4].Value = xb;//1

                parameters[5].Text = "@csrq";
                if (csrq == null || csrq.ToString() == "")
                {
                    parameters[5].Value = DBNull.Value;
                }
                else
                {
                    parameters[5].Value = csrq;
                }
                parameters[6].Text = "@jtdz";
                parameters[6].Value = jtdz;//''

                parameters[7].Text = "@lxdh";
                parameters[7].Value = lxdh;//''

                parameters[8].Text = "@sfzh";
                parameters[8].Value = sfzh;//''

                parameters[9].Text = "@yzm";
                parameters[9].Value = yzm;//177581

                parameters[10].Text = "@ghks";
                parameters[10].Value = ghks;//178

                parameters[11].Text = "@ghjb";
                parameters[11].Value = ghjb;//1

                parameters[12].Text = "@ghys";
                parameters[12].Value = ghys;//10

                parameters[13].Text = "@pdxh";
                parameters[13].Value = pdxh;//0

                parameters[14].Text = "@djsj";
                parameters[14].Value = djsj;//2013-4-17 9:37:14

                parameters[15].Text = "@djy";
                parameters[15].Value = djy;//1

                parameters[16].Text = "@yyrq";
                parameters[16].Value = yyrq;//2013-4-17 9:37:14

                parameters[17].Text = "@yysd";
                parameters[17].Value = yysd;//09:00:00

                parameters[18].Text = "@sxsj";
                if (sxsj == null || sxsj.ToString() == "")
                {
                    parameters[18].Value = DBNull.Value; //null
                }
                else
                {
                    parameters[18].Value = sxsj;
                }
                parameters[19].Text = "@bscbz";
                parameters[19].Value = bscbz; //0

                parameters[20].Text = "@YYQJD";
                parameters[20].Value = yyqjd;//1

                parameters[21].Text = "@CARDFLAG";
                parameters[21].Value = cardflag;

                parameters[22].Text = "@PAYMONEY_FLAG";
                parameters[22].Value = paymoneyflag;

                parameters[23].Text = "@GH_FEE";
                parameters[23].Value = gh_fee;

                parameters[24].Text = "@klx";
                parameters[24].Value = klx;

                parameters[25].Text = "@NEWYZM";
                parameters[25].ParaDirection = ParameterDirection.Output;
                parameters[25].ParaSize = 300;

                parameters[26].Text = "@NEWPDXH";
                parameters[26].ParaDirection = ParameterDirection.Output;
                parameters[26].ParaSize = 100;

                parameters[27].Text = "@Newyyid";
                parameters[27].ParaDirection = ParameterDirection.Output;
                parameters[27].DataType = System.Data.DbType.Guid;
                parameters[27].ParaSize = 100;

                parameters[28].Text = "@err_code";
                parameters[28].ParaDirection = ParameterDirection.Output;
                parameters[28].DataType = System.Data.DbType.Int32;
                parameters[28].ParaSize = 100;

                parameters[29].Text = "@err_text";
                parameters[29].ParaDirection = ParameterDirection.Output;
                parameters[29].ParaSize = 200;

                parameters[30].Text = "@ptid";
                parameters[30].Value = ptid;

                _DataBase.DoCommand("SP_MZSF_saveYYGH_pt", parameters, 31);

                newYzm = Convert.ToString(parameters[25].Value);
                newPdxh = Convert.ToString(parameters[26].Value);
                newYYid = new Guid(parameters[27].Value.ToString());
                err_code = Convert.ToInt32(parameters[28].Value);
                err_text = Convert.ToString(parameters[29].Value);
                if (err_code != 0) //Modify By zp 2014-05-21 如果过程返回错误 则直接return
                {
                    _DataBase.RollbackTransaction();
                    return;
                }/*预约成功后,获取分时段记录并更新分时段记录 Add by zp 2013-11-06 */
                if ((new SystemCfg(1099, _DataBase).Config.Trim() == "1")) //  Add by zp 门诊是否启用分时段挂号 0不启用 1启用 默认为0
                {
                    string msg = "";
                    FsdClass _Fsd = FsdClass.GetNowFsd(ghks, ghys, ghjb, yyrq.ToString(), yysd, ref msg, _DataBase);
                    if (_Fsd.FsdId <= 0)
                    {
                        DateTime date = Convert.ToDateTime(yyrq);
                        VisitResource _Vres = new VisitResource(ghks, ghjb, ghys, date.ToString("yyyy-MM-dd"), _DataBase);
                        if (_Vres.Resid > 0)
                        {
                            VisResDetails _VresDetails = new VisResDetails(yysd, "", _Vres.Resid, _DataBase);
                            _Fsd.FsdAdd(date.ToString(), _VresDetails, _DataBase);
                            _Fsd = new FsdClass(_VresDetails.Zymxid, Convert.ToDateTime(date).ToString("yyyy-MM-dd"), _DataBase);
                            _Fsd.UpdateFsdGhrc(ref _Fsd, _DataBase);
                        }
                    }
                    else
                    {
                        if (_Fsd.Jlzt == 1 || _Fsd.Xhrs <= _Fsd.Yghrc) //Modify By zp 2014-05-20 更新提示说明
                        {
                            throw new Exception("当前时段的号源数已满或未设置该医生的出诊时段信息,请预约其他时段的号源数");
                        }
                        _Fsd.UpdateFsdGhrc(ref _Fsd, _DataBase);
                    }
                }
                _DataBase.CommitTransaction();
            }
            catch (System.Exception err)
            {
                _DataBase.RollbackTransaction();
                throw new System.Exception("YYGH_save函数异常!" + err.Message);
            }



        }


        /// <summary>
        /// 保存预约号
        /// </summary>
        /// <param name="yyid">预约id</param>
        /// <param name="yylx">预约类型</param>
        /// <param name="kh">卡号</param>
        /// <param name="brxm">病人姓名</param>
        /// <param name="xb">性别代码</param>
        /// <param name="csrq">出生日期</param>
        /// <param name="jtdz">家庭地址</param>
        /// <param name="lxdh">联系电话</param>
        /// <param name="sfzh">身份证号</param>
        /// <param name="yzm">验证码</param>
        /// <param name="ghks">挂号科室id</param>
        /// <param name="ghjb">挂号级别id</param>
        /// <param name="ghys">挂号医生id</param>
        /// <param name="pdxh">排队序号</param>
        /// <param name="djsj">登记时间</param>
        /// <param name="djy">登记员</param>
        /// <param name="yyrq">预约日期</param>
        /// <param name="yysd">预约时段</param>
        /// <param name="sxsj">失效时间</param>
        /// <param name="bscbz">删除标志 </param>
        /// <param name="yyqjd">预约区间段 1上午 2下午</param>
        /// <param name="cardflag">是否有卡 0无卡预约 1有卡预约 </param>
        /// <param name="paymoneyflag">支付标志 0未支付 1已支付</param>
        /// <param name="gh_fee">所需支付的挂号费用</param>
        /// <param name="newYzm"></param>
        /// <param name="newPdxh"></param>
        /// <param name="newYYid"></param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        public static void YYGH_save(Guid yyid, Mz_YYgh.YYgh_Sort yylx, string kh, string brxm, string xb, object csrq,
            string jtdz, string lxdh, string sfzh, string yzm, int ghks, int ghjb, int ghys, int pdxh,
            string djsj, int djy, object yyrq, string yysd, object sxsj, int bscbz, int yyqjd, int cardflag,
            int paymoneyflag, decimal gh_fee, int klx, out string newYzm,
            out string newPdxh, out Guid newYYid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            _DataBase.BeginTransaction();
            try
            {
                ParameterEx[] parameters = new ParameterEx[31];
                parameters[0].Text = "@yyid";
                parameters[0].Value = yyid; //8b8d0fd1-b4da-49a4-a0c1-b20e6b207d1b

                parameters[1].Text = "@yylx";
                parameters[1].Value = (int)yylx;//1

                parameters[2].Text = "@kh";
                parameters[2].Value = kh;//000001

                parameters[3].Text = "@brxm";
                parameters[3].Value = brxm;

                parameters[4].Text = "@xb";
                parameters[4].Value = xb;//1

                parameters[5].Text = "@csrq";
                if (csrq == null || csrq.ToString() == "")
                {
                    parameters[5].Value = DBNull.Value;
                }
                else
                {
                    parameters[5].Value = csrq;
                }
                parameters[6].Text = "@jtdz";
                parameters[6].Value = jtdz;//''

                parameters[7].Text = "@lxdh";
                parameters[7].Value = lxdh;//''

                parameters[8].Text = "@sfzh";
                parameters[8].Value = sfzh;//''

                parameters[9].Text = "@yzm";
                parameters[9].Value = yzm;//177581

                parameters[10].Text = "@ghks";
                parameters[10].Value = ghks;//178

                parameters[11].Text = "@ghjb";
                parameters[11].Value = ghjb;//1

                parameters[12].Text = "@ghys";
                parameters[12].Value = ghys;//10

                parameters[13].Text = "@pdxh";
                parameters[13].Value = pdxh;//0

                parameters[14].Text = "@djsj";
                parameters[14].Value = djsj;//2013-4-17 9:37:14

                parameters[15].Text = "@djy";
                parameters[15].Value = djy;//1

                parameters[16].Text = "@yyrq";
                parameters[16].Value = yyrq;//2013-4-17 9:37:14

                parameters[17].Text = "@yysd";
                parameters[17].Value = yysd;//09:00:00

                parameters[18].Text = "@sxsj";
                if (sxsj == null || sxsj.ToString() == "")
                {
                    parameters[18].Value = DBNull.Value; //null
                }
                else
                {
                    parameters[18].Value = sxsj;
                }
                parameters[19].Text = "@bscbz";
                parameters[19].Value = bscbz; //0

                parameters[20].Text = "@YYQJD";
                parameters[20].Value = yyqjd;//1

                parameters[21].Text = "@CARDFLAG";
                parameters[21].Value = cardflag;

                parameters[22].Text = "@PAYMONEY_FLAG";
                parameters[22].Value = paymoneyflag;

                parameters[23].Text = "@GH_FEE";
                parameters[23].Value = gh_fee;

                parameters[24].Text = "@klx";
                parameters[24].Value = klx;

                parameters[25].Text = "@NEWYZM";
                parameters[25].ParaDirection = ParameterDirection.Output;
                parameters[25].ParaSize = 300;

                parameters[26].Text = "@NEWPDXH";
                parameters[26].ParaDirection = ParameterDirection.Output;
                parameters[26].ParaSize = 100;

                parameters[27].Text = "@Newyyid";
                parameters[27].ParaDirection = ParameterDirection.Output;
                parameters[27].DataType = System.Data.DbType.Guid;
                parameters[27].ParaSize = 100;

                parameters[28].Text = "@err_code";
                parameters[28].ParaDirection = ParameterDirection.Output;
                parameters[28].DataType = System.Data.DbType.Int32;
                parameters[28].ParaSize = 100;

                parameters[29].Text = "@err_text";
                parameters[29].ParaDirection = ParameterDirection.Output;
                parameters[29].ParaSize = 200;

                parameters[30].Text = "@ptid";
                parameters[30].Value = "";
                _DataBase.DoCommand("SP_MZSF_saveYYGH_pt", parameters, 31);

                newYzm = Convert.ToString(parameters[25].Value);
                newPdxh = Convert.ToString(parameters[26].Value);
                newYYid = new Guid(parameters[27].Value.ToString());
                err_code = Convert.ToInt32(parameters[28].Value);
                err_text = Convert.ToString(parameters[29].Value);
                if (err_code != 0) //Modify By zp 2014-05-21 如果过程返回错误 则直接return
                {
                    _DataBase.RollbackTransaction();
                    return;
                }/*预约成功后,获取分时段记录并更新分时段记录 Add by zp 2013-11-06 */
                if ((new SystemCfg(1099, _DataBase).Config.Trim() == "1")) //  Add by zp 门诊是否启用分时段挂号 0不启用 1启用 默认为0
                {
                    string msg = "";
                    FsdClass _Fsd = FsdClass.GetNowFsd(ghks, ghys, ghjb, yyrq.ToString(), yysd, ref msg, _DataBase);
                    if (_Fsd.FsdId <= 0)
                    {
                        DateTime date = Convert.ToDateTime(yyrq);
                        VisitResource _Vres = new VisitResource(ghks, ghjb, ghys, date.ToString("yyyy-MM-dd"), _DataBase);
                        if (_Vres.Resid > 0)
                        {
                            VisResDetails _VresDetails = new VisResDetails(yysd, "", _Vres.Resid, _DataBase);
                            _Fsd.FsdAdd(date.ToString(), _VresDetails, _DataBase);
                            _Fsd = new FsdClass(_VresDetails.Zymxid, Convert.ToDateTime(date).ToString("yyyy-MM-dd"), _DataBase);
                            _Fsd.UpdateFsdGhrc(ref _Fsd, _DataBase);
                        }
                    }
                    else
                    {
                        if (_Fsd.Jlzt == 1 || _Fsd.Xhrs <= _Fsd.Yghrc) //Modify By zp 2014-05-20 更新提示说明
                        {
                            throw new Exception("当前时段的号源数已满或未设置该医生的出诊时段信息,请预约其他时段的号源数");
                        }
                        _Fsd.UpdateFsdGhrc(ref _Fsd, _DataBase);
                    }
                }
                _DataBase.CommitTransaction();
            }
            catch (System.Exception err)
            {
                _DataBase.RollbackTransaction();
                throw new System.Exception("YYGH_save函数异常!" + err.Message);
            }



        }


        /// <summary>
        /// 预约取号
        /// </summary>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="_DataBase"></param>
        //public static DataTable YYQH(string sfzh, string kh, string brxm, string yzm, string lxdh,
        //    out int err_code, out string err_text, RelationalDatabase _DataBase)
        //{
        //    try
        //    {
        //        err_code = -1;
        //        err_text = "";
        //        try
        //        {
        //            ParameterEx[] parameters = new ParameterEx[8];

        //            parameters[0].Text = "@YYID";
        //            parameters[0].Value = Guid.Empty;

        //            parameters[1].Text = "@YZM";
        //            parameters[1].Value = yzm;

        //            parameters[2].Text = "@sfzh";
        //            parameters[2].Value = sfzh;

        //            parameters[3].Text = "@kh";
        //            parameters[3].Value = kh;

        //            parameters[4].Text = "@brxm";
        //            parameters[4].Value = brxm;

        //            parameters[5].Text = "@sort";
        //            parameters[5].Value = 3; //未作废未取号

        //            parameters[5].Text = "@err_code";
        //            parameters[5].ParaDirection = ParameterDirection.Output;
        //            parameters[5].DataType = System.Data.DbType.Int32;
        //            parameters[5].ParaSize = 100;

        //            parameters[6].Text = "@err_text";
        //            parameters[6].ParaDirection = ParameterDirection.Output;
        //            parameters[6].ParaSize = 100;

        //            DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_MZSF_GetYYGH", parameters, 30);

        //            err_code = Convert.ToInt32(parameters[5].Value);
        //            err_text = Convert.ToString(parameters[6].Value);
        //            if (err_code != 0) throw new Exception(err_text);

        //            return tb;

        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new System.Exception(err.Message);
        //        }

        //    }
        //    catch (System.Exception err)
        //    {
        //        throw new System.Exception(err.Message);
        //    }
        //}

        //更新预约取号状态
        public static void UpateYyghxx(Guid YYID, Guid ghxxid, string sdate, RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Text = "@YYID";
            parameters[0].Value = YYID;

            parameters[1].Text = "@qhsj";
            parameters[1].Value = sdate;

            parameters[2].Text = "@ghxxid";
            parameters[2].Value = ghxxid;

            parameters[3].Text = "@err_code";
            parameters[3].ParaDirection = ParameterDirection.Output;
            parameters[3].DataType = System.Data.DbType.Int32;
            parameters[3].ParaSize = 100;

            parameters[4].Text = "@err_text";
            parameters[4].ParaDirection = ParameterDirection.Output;
            parameters[4].ParaSize = 100;

            _DataBase.DoCommand("SP_MZGH_Update_Yyxx", parameters, 30);
            if (Convert.ToInt32(parameters[3].Value) != 0)
                throw new Exception(parameters[4].Value.ToString());

        }

        /// <summary>
        /// 获取预约挂号列表
        /// </summary>
        /// <param name="sfzh">身份证号</param>
        /// <param name="kh">卡号</param>
        /// <param name="brxm">病人姓名</param>
        /// <param name="yzm">验证码</param>
        /// <param name="lxdh">联系电话</param>
        /// <param name="status">状态0全部(包含作废) 1未作废 2已作废  3未作废未取号 4未作废已取号</param>
        /// <param name="bdate">开始日期 格式:yyyy-MM-dd 为空表示不限制日期</param>
        /// <param name="edate">结束日期 格式:yyyy-MM-dd 为空表示不限制日期</param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetYYghInfo(string yyid, string sfzh, string kh, string yzm,
           YYgh_Status status, string bdate, string edate, int klx, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {

            err_code = -1;
            err_text = "";
            try
            {
                ParameterEx[] parameters = new ParameterEx[10];

                parameters[0].Text = "@YYID";
                parameters[0].Value = yyid;

                parameters[1].Text = "@YZM";
                parameters[1].Value = yzm;

                parameters[2].Text = "@sfzh";
                parameters[2].Value = sfzh;

                parameters[3].Text = "@kh";
                parameters[3].Value = kh;

                parameters[4].Text = "@sort";
                parameters[4].Value = (int)status; //未作废未取号0

                parameters[5].Text = "@bdate";
                parameters[5].Value = bdate;

                parameters[6].Text = "@edate";
                parameters[6].Value = edate;

                parameters[7].Text = "@klx";
                parameters[7].Value = klx;
                parameters[7].DataType = System.Data.DbType.Int32;


                parameters[8].Text = "@err_code";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].DataType = System.Data.DbType.Int32;
                parameters[8].ParaSize = 100;

                parameters[9].Text = "@err_text";
                parameters[9].ParaDirection = ParameterDirection.Output;
                parameters[9].ParaSize = 2000;

                DataTable tb = _DataBase.GetDataTable("SP_MZSF_GetYYGH_Pt", parameters, 30);

                err_code = Convert.ToInt32(parameters[8].Value);
                err_text = Convert.ToString(parameters[9].Value);
                if (err_code != 0) throw new Exception(err_text);

                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }


        }
        /// <summary>
        /// 获取医生排班  add by zp 2013-4-11
        /// </summary>
        /// <param name="bdate">开始日期 格式 yyyy-MM-dd</param>
        /// <param name="edate">结束日期 格式 yyyy-MM-dd</param>
        /// <param name="pblx">排班类型 1上午 2下午 0标示获取所有</param>
        /// <param name="dept_id">科室id 大于0标示获取指定科室的排班</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetDoctorPbInfo(string bdate, string edate, int pblx,
            int dept_id, int emp_id, RelationalDatabase _DataBase)
        {
            DataTable dt = null;
            try
            {
                string ssql = @" select ID,PBKSID,PBKS,case when PBLX=1 then '上午' when PBLX=2 then '下午' else '晚上' end as 排班类型,
                pblx,PBSJ,YSID,YSXM,ZZJB,ZZJBID,JJRBZ,JZ,ZJID_QC 
                from JC_MZ_YSPB where BSCBZ=0 AND PBSJ>='" + bdate + "' and PBSJ<='" + edate + @"'";
                if (dept_id > 0)
                {
                    ssql += " and pbksid=" + dept_id;
                }
                if (pblx > 0)
                {
                    ssql += " and pblx=" + pblx;
                }
                if (emp_id > 0)
                {
                    ssql += " and YSID=" + emp_id;
                }
                dt = _DataBase.GetDataTable(ssql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }

        /// <summary>
        /// 获取取号验证码  add by zp 2013-04-14
        /// </summary>
        /// <param name="bdate">开始日期 格式 yyyy-MM-dd</param>
        /// <param name="edate">结束日期 格式 yyyy-MM-dd</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static string GetCheckNo(string bdate, string edate, RelationalDatabase _DataBase)
        {
            string checkNo = "";
            try
            {
                Random rand = new Random();
                int ran = rand.Next(9999);
                string sql = @"select day(getdate())";
                //这样会不会有重复
                int n = Convert.ToInt32(_DataBase.GetDataResult(sql));
                checkNo = n.ToString() + ran.ToString();
                if (string.IsNullOrEmpty(bdate) || string.IsNullOrEmpty(edate))
                {
                    bdate = "getdate()";
                    edate = "DATEADD(day,1,getdate())";
                }
                sql = @"select YZM from mz_yyghlb where YZM='" + checkNo + @"'and yyrq>=" + bdate + @" and YYRQ<" + edate + @"";
                if (_DataBase.GetDataResult(sql) != null)
                {
                    return GetCheckNo(bdate, edate, _DataBase);
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return checkNo;
        }

        /// <summary>
        /// 取消预约挂号(未进行相关业务判断 直接执行Update语句)
        /// </summary>
        /// <param name="YYID">预约id</param>
        /// <param name="brxm">病人姓名</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static bool CanCelYYGH(Guid YYID, string brxm, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"update MZ_YYGHLB set BSCBZ=1 where YYID='" + YYID + "' and BRXM='" + brxm + "' and BQHBZ=0";
                if (_DataBase.DoCommand(sql) > 0)
                {
                    //Modify by zp 2013-11-07 注销预约挂号则释放出诊资源
                    if ((new SystemCfg(1099, _DataBase)).Config.Trim() == "1")//  Add by zp 门诊是否启用分时段挂号 0不启用 1启用 默认为0
                    {
                        sql = @"SELECT * FROM MZ_YYGHLB WHERE YYID='" + YYID + "'";
                        DataTable dt = _DataBase.GetDataTable(sql);
                        string sjnc = dt.Rows[0]["YYSD"].ToString();
                        string yyrq = dt.Rows[0]["YYRQ"].ToString();
                        VisitResource _VisRes = new VisitResource(Convert.ToInt32(dt.Rows[0]["GHKS"]), Convert.ToInt32(dt.Rows[0]["GHJB"]), Convert.ToInt32(dt.Rows[0]["GHYS"]), Convert.ToDateTime(dt.Rows[0]["YYRQ"]).ToString("yyyy-MM-dd"), _DataBase);
                        if (_VisRes.Resid > 0)
                        {
                            Ts_Visit_Class.FsdClass _Fsd = new FsdClass(sjnc, Convert.ToDateTime(yyrq).ToString("yyyy-MM-dd"), _VisRes.Resid, _DataBase);
                            if (_Fsd.FsdId > 0)
                                _Fsd.Save(ref _Fsd, true, _DataBase); //回收挂号资源 Add by zp 2013-10-31
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        /// <summary>
        /// 获取优惠方案
        /// </summary>
        /// <param name="klx"></param>
        /// <param name="kdjid"></param>
        /// <param name="brlx"></param>
        /// <param name="yblx"></param>
        /// <param name="htdwlx"></param>
        /// <param name="funname"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetYhlx(int klx, Guid kdjid, int brlx, int yblx, int htdwlx, string funname, RelationalDatabase _DataBase)
        {
            DataTable tb = null;
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@klx";
                parameters[0].Value = klx;

                parameters[1].Text = "@kdjid";
                parameters[1].Value = kdjid;

                parameters[2].Text = "@brlx";
                parameters[2].Value = brlx;

                parameters[3].Text = "@yblx";
                parameters[3].Value = yblx;

                parameters[4].Text = "@htdwlx";
                parameters[4].Value = htdwlx;

                parameters[5].Text = "@funname";
                parameters[5].Value = funname;

                tb = _DataBase.GetDataTable("SP_MZSF_GETYHLX", parameters, 30);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return tb;
        }


        public static string GetNewDnlsh(RelationalDatabase _DataBase, long jgbm)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@JGBM";
                parameters[0].Value = jgbm;

                parameters[1].Text = "@DNLSH";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].ParaSize = 100;

                _DataBase.DoCommand("SP_MZ_NEW_DNLSH", parameters, 30);

                string dnlsh = Convert.ToString(parameters[1].Value);
                return dnlsh;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        public static string GetNewMzh(RelationalDatabase _DataBase, long jgbm)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@JGBM";
                parameters[0].Value = jgbm;

                parameters[1].Text = "@MZH";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].ParaSize = 100;

                _DataBase.DoCommand("SP_MZGH_NEWMZH", parameters, 30);

                string mzh = Convert.ToString(parameters[1].Value);
                return mzh;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        public static bool YYGH_Qh(Guid YYID, string cardno, string brxm, int czyh, int ghlx, string isblb, int payflag,
            long jgbm, RelationalDatabase _DataBase, out int err_code, out string err_text, out DataTable dt_ghxx)
        {

            /*分两种取号 一种是已支付的取号模式 二种是未支付的取号模式  此处只负责有卡预约的取号*/
            err_code = 0;
            err_text = "";
            dt_ghxx = null;
            try
            {
                string sql = @"SELECT A.GHKS,A.GHJB,A.GHYS,A.YYRQ,A.YYQJD,A.PAYMONEY_FLAG,A.GH_FEE,B.KLX,B.KDJID,C.BRLX,C.BRXXID,C.BRXM,A.YYLX,
                C.YBLX,A.GH_FEE,B.KYE,B.ZFBZ,B.SDBZ,A.YYSD,dbo.fun_getdeptname(A.ghks) 挂号科室,dbo.fun_getempname(ghys) 挂号医生 FROM MZ_YYGHLB AS A 
                INNER JOIN YY_KDJB AS B ON A.KH=B.KH
                INNER JOIN YY_BRXX AS C ON B.BRXXID=C.BRXXID
                WHERE A.YYID='" + YYID.ToString() + "'AND A.BSCBZ=0 AND A.BQHBZ=0 ";
                if (!string.IsNullOrEmpty(brxm))
                {
                    sql += " AND A.BRXM='" + brxm + @"' ";
                }
                if (!string.IsNullOrEmpty(cardno))
                {
                    sql += " AND A.KH='" + cardno + @"'";
                }
                DataTable dt_yyinfo = _DataBase.GetDataTable(sql);
                if (dt_yyinfo.Rows.Count < 1)
                {
                    err_code = 1;
                    err_text = "通过预约id和卡号、病人姓名未获取到预约挂号记录!请确认输入的信息是否正确!";
                    return false;
                }
                if (dt_yyinfo.Rows[0]["ZFBZ"].ToString().Trim() != "0")
                {
                    err_code = 2;
                    err_text = "输入的卡号查询出该诊疗卡状态已作废!不能进行预约取号操作!";
                    return false;
                }
                if (dt_yyinfo.Rows[0]["SDBZ"].ToString().Trim() != "0")
                {
                    err_code = 3;
                    err_text = "输入的卡号查询出该诊疗卡状态已锁定!不能进行预约取号操作!";
                    return false;
                }
                #region  通过挂号信息获得本次的收费联动明细项目

                //卡费的收取 如果传了卡类型就收卡费
                int _klx = Convert.ToInt32(Convertor.IsNull(dt_yyinfo.Rows[0]["KLX"], "0"));
                Guid _kdjid = new Guid(Convertor.IsNull(dt_yyinfo.Rows[0]["KDJID"], ""));
                int _brlx = Convert.ToInt32(Convertor.IsNull(dt_yyinfo.Rows[0]["BRLX"], "0"));
                int _yblx = Convert.ToInt32(Convertor.IsNull(dt_yyinfo.Rows[0]["YBLX"], "0"));
                int _ghks = Convert.ToInt32(Convertor.IsNull(dt_yyinfo.Rows[0]["GHKS"], "0"));
                int _ghjb = Convert.ToInt32(Convertor.IsNull(dt_yyinfo.Rows[0]["GHJB"], "0"));
                int _ghys = Convert.ToInt32(Convertor.IsNull(dt_yyinfo.Rows[0]["GHYS"], "0"));
                Guid _brxxid = new Guid(Convertor.IsNull(dt_yyinfo.Rows[0]["BRXXID"], ""));
                string _yysd = Convertor.IsNull(dt_yyinfo.Rows[0]["YYSD"], "");//预约时段  保存挂号信息处用
                string _ghsj = Convertor.IsNull(dt_yyinfo.Rows[0]["YYRQ"], "");//挂号时间
                string _ksmc = Convertor.IsNull(dt_yyinfo.Rows[0]["挂号科室"], "");
                string _ysmc = Convertor.IsNull(dt_yyinfo.Rows[0]["挂号医生"], "");
                int _yylx = Convert.ToInt32(Convertor.IsNull(dt_yyinfo.Rows[0]["YYLX"], "0"));
                brxm = dt_yyinfo.Rows[0]["BRXM"].ToString();
                decimal _ybzf = 0;
                //DataTable dt_yhlx = GetYhlx(_klx, _kdjid, _brlx, _yblx, 0, "",_DataBase);
                Guid yhlx = Guid.Empty; //获取挂号费用 不收取卡费

                DataSet dset = mz_ghxx.mzgh_get_sfmx(ghlx, _brlx, _yblx, _ghks, _ghjb, _ghys, isblb, _ybzf, 0, yhlx, jgbm, out err_code, out err_text, "", _DataBase);

                //  DataSet dset = mz_ghxx.mzgh_get_sfmx(1, 0, 0, ghks, ghjb,
                //     ghys, "", 0, 0, yhlx, TrasenFrame.Forms.FrmMdiMain.Jgbm, out err_code, out err_text, _menuTag.Function_Name, InstanceForm.BDatabase);
                if (err_code != 0)
                {
                    throw new Exception(err_text);
                }

                long dnlsh = Convert.ToInt64(GetNewDnlsh(_DataBase, jgbm));//生成一个电脑流水号  
                decimal zje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));//计算结果集1表的总金额
                decimal yhje = Convert.ToDecimal(dset.Tables[0].Compute("sum(yhje)", ""));//计算结果集1表的优惠金额
                decimal srje = Convert.ToDecimal(dset.Tables[0].Compute("sum(srje)", ""));//计算结果集1表的舍入金额
                decimal zfje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zfje)", ""));//计算结果集1表的自付金额
                yhlx = new Guid(dset.Tables[0].Rows[0]["yhlxid"].ToString());//得到优惠类型id
                string yhlxmc = Fun.SeekYhlxMc(yhlx, _DataBase);//获取优惠类型名称
                string mzh = GetNewMzh(_DataBase, jgbm); //ts_mz_class.Fun.GetNewMzh(_DataBase); //得到门诊号
                string fph = "0"; //默认设置发票号为9
                string isghf = dset.Tables[0].Rows[0]["groupid"].ToString().Trim();//得到组id(费用名称)
                /*如果诊疗卡内的余额大于挂号的金额 则用诊疗卡支付 否则返回 因诊疗卡余额不足取号失败*/
                decimal kyy = Convert.ToDecimal(Convertor.IsNull(dt_yyinfo.Rows[0]["KYE"], "0"));//获取到诊疗卡余额


                decimal ylkzf = 0;//银联
                decimal cwjz = zje;//财务记帐 默认诊疗卡支付
                decimal qfgz = 0;//欠费挂帐
                decimal ssxj = 0;//实收现金
                decimal zlje = 0;//找零金额
                decimal xjzf = 0;//现金自付
                decimal zpzf = 0;//支票支付
                decimal ybzf = 0;//医保支付
                int _pdxh = 0;  //排队序号
                int htdwlx = 0; //合同单位类型
                int htdwId = 0; //合同单位ID
                int yb_lx = 0;
                string yb_dylx = "";
                string _ghck = "";
                string yb_dylxmc = "";
                string yb_bzxx = "";

                string jydjh = ""; //医保交易单据号
                if (payflag == 2) //银行卡支付
                {
                    ylkzf = zje;
                    cwjz = 0;
                }
                Guid Ghxxid = Guid.Empty;

                string ssql = "select * from mz_yyghlb where yyid='" + YYID + "'";
                DataTable tb = _DataBase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                    _pdxh = Convert.ToInt32(tb.Rows[0]["pdxh"]);


                #region//分时段挂号处理 Add by zp 2013-10-30 存储数据到后台前先获取当前分时段信息
                string _msg = ""; //cfg1099
                FsdClass _fsd = null;

                if (new SystemCfg(1099, _DataBase).Config.Trim() == "1")
                {
                    try
                    {
                        _fsd = FsdClass.GetNowFsd(_ghks, _ghys, _ghjb, _ghsj, _yysd, ref _msg, _DataBase);
                        if (_fsd == null)//为空表示当前时段未找到分时段资源,但该医生又设置了资源限号
                        {
                            throw new Exception("His提示:" + _msg);
                        }
                        //没分时段的资源给予固定的时段昵称 Modify by zp 2013-11-05
                        if (_fsd.FsdId <= 0)
                        {
                            DateTime _date = DateManager.ServerDateTimeByDBType(_DataBase);
                            if (_date.Hour < 12 && _date.Hour > 6)
                            {
                                _fsd.Btime = "08:00";
                                _fsd.Etime = "12:00";
                                _fsd.Sdbm = "08:00-12:00";
                            }
                            else
                            {
                                _fsd.Btime = "14:00";
                                _fsd.Etime = "17:00";
                                _fsd.Sdbm = "14:00-17:00";
                            }
                        }
                    }
                    catch (Exception ea)
                    {

                        throw new Exception("His获取分时段异常!原因:" + ea.Message);
                    }

                }

                #endregion

                //保存挂号信息
                mz_ghxx.GhxxDj(Guid.Empty, _brxxid, ghlx, _kdjid, mzh, _ghks, _ghys, _ghjb, zje, czyh, 1, _ghck, ref _pdxh, dnlsh, fph, jgbm,
                    out Ghxxid, out err_code, out err_text, htdwlx, htdwId, yb_lx, yb_dylx, yb_dylxmc, yb_bzxx, _yylx, _yysd, "", _ghsj, _DataBase);
                if (Ghxxid == Guid.Empty || err_code != 0) { throw new Exception(err_text); }
                //保存处方信息 int bghpbz = 1;
                Guid NewCfid = Guid.Empty;
                sql = @"select dbo.fun_getempname(" + czyh + ")";
                string empname = Convertor.IsNull(_DataBase.GetDataResult(sql), "");
                mz_cf.SaveCf(Guid.Empty, _brxxid, Ghxxid, mzh, _ghck, zje, _ghsj, czyh, empname, _ghck, Guid.Empty, _ghks,
                    _ksmc, _ghys, _ysmc, 0, _ghks, _ksmc, 1, 0, 2, 0, 1, jgbm, out NewCfid, out err_code, out err_text, _DataBase);
                if (NewCfid == Guid.Empty || err_code != 0) { throw new Exception(err_text); }
                //保存处方明细
                Guid NewCfmxid = Guid.Empty;
                for (int i = 0; i <= dset.Tables[4].Rows.Count - 1; i++)
                {
                    mz_cf.SaveCfmx(Guid.Empty, NewCfid, dset.Tables[4].Rows[i]["PY_CODE"].ToString().Trim(), "", dset.Tables[4].Rows[i]["item_name"].ToString().Trim(),
                        dset.Tables[4].Rows[i]["item_name"].ToString().Trim(), "", "", Convert.ToDecimal(dset.Tables[4].Rows[i]["cost_price"]), Convert.ToDecimal(dset.Tables[4].Rows[i]["num"]),
                        dset.Tables[4].Rows[i]["item_unit"].ToString().Trim(), 1, 1, Convert.ToDecimal(dset.Tables[4].Rows[i]["je"]), dset.Tables[4].Rows[i]["statitem_code"].ToString().Trim(),
                        Convert.ToInt64(dset.Tables[4].Rows[i]["item_id"]), Guid.Empty, dset.Tables[4].Rows[i]["STD_CODE"].ToString().Trim(), 0, 0,
                        Guid.Empty, 0, "", "", 0, 0, "", 0, 0, Guid.Empty, 0, 0, 0, out NewCfmxid, out err_code, out err_text, _DataBase);
                    if (NewCfmxid == Guid.Empty || err_code != 0)
                        throw new Exception(err_text);
                }
                //保存收银信息
                Guid NewJsid = Guid.Empty;
                mz_sf.SaveJs(Guid.Empty, _brxxid, Ghxxid, _ghsj, czyh, zje, ybzf, 0, 0,
                    ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, ssxj, zlje, 0, 0, jgbm, out NewJsid, out err_code, out err_text, _DataBase);
                if (NewJsid == Guid.Empty || err_code != 0) { throw new Exception(err_text); }

                Guid NewFpid = Guid.Empty;
                //保存发票信息
                mz_sf.SaveFp(Guid.Empty, _brxxid, Ghxxid, mzh, brxm, _ghsj, czyh, _ghck, dnlsh,
                    fph, zje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, Guid.Empty, "", NewJsid,
                    1, _ghks, _ghys, 0, _ghks, _yblx, jydjh, 0, _kdjid, jgbm, yhlx, yhlxmc, out NewFpid, out err_code, out err_text, _DataBase);
                if (err_code != 0) { throw new Exception(err_text); }
                for (int i = 0; i <= dset.Tables[1].Rows.Count - 1; i++)
                {
                    mz_sf.SaveFpmx(NewFpid, Convertor.IsNull(dset.Tables[1].Rows[i]["code"], "0"), Convertor.IsNull(dset.Tables[1].Rows[i]["item_name"], "0"), Convert.ToDecimal(dset.Tables[1].Rows[i]["je"]), 0, out err_code, out err_text, _DataBase);
                    if (err_code != 0)
                        throw new Exception(err_text);
                }

                //保存发票统计大项目
                for (int i = 0; i <= dset.Tables[3].Rows.Count - 1; i++)
                {
                    mz_sf.SaveFpdxmmx(NewFpid, Convertor.IsNull(dset.Tables[3].Rows[i]["code"], "0"), Convertor.IsNull(dset.Tables[3].Rows[i]["item_name"], "0"), Convert.ToDecimal(dset.Tables[3].Rows[i]["je"]), 0, out err_code, out err_text, _DataBase);
                    if (err_code != 0)
                        throw new Exception(err_text);
                }

                int Nrows = 0;
                mz_cf.UpdateCfsfzt("('" + NewCfid + "')", czyh, empname, _ghsj, _ghck, dnlsh, fph, NewFpid, out Nrows, out err_code, out err_text, _DataBase);
                if (Nrows != 1) { throw new Exception(err_text); }

                //更新卡余额
                //Modify by Kevin 2012-06-12
                if (cwjz > 0)
                {
                    try
                    {
                        ReadCard readcard = new ReadCard(_klx, cardno, _DataBase);
                        readcard.UpdateKye(cwjz, _DataBase);
                    }
                    catch (Exception ea)
                    {
                        throw new Exception("更新卡余额异常!" + ea.Message);
                    }
                }
                #region  //modify by zp 2013-06  是否自动报道  启用了新分诊系统、有诊区并且当前诊区为自动报道
                Fz_Zq _fzzq = new Fz_Zq(_DataBase, _ghks, _ghjb);
                Guid NewFzid = Guid.Empty;
                string fsd_btime = "";
                string fsd_etime = "";
                string fsd_sdbm = "";
                if (_fsd != null)
                {
                    fsd_btime = Convertor.IsNull(_fsd.Btime, "");
                    fsd_etime = Convertor.IsNull(_fsd.Etime, "");
                    fsd_sdbm = Convertor.IsNull(_fsd.Sdbm, "");
                }
                if (_fzzq.Zqid > 0)//Zqid默认为0 大于0表示有诊区记录
                {
                    if (_fzzq.Zqbdfs <= 0) //手动报道 _fsd
                    {
                        ts_mzys_class.MZHS_FZJL.AddHz(jgbm, Ghxxid, _ghks, ts_mzys_class.MZHS_FZJL.FzStatus.未分诊, out NewFzid, out err_code, out err_text, fsd_btime, fsd_etime, fsd_sdbm, _fzzq.Zqid, _DataBase);
                        if (err_code != 0)
                            throw new Exception("分诊手动报道出现异常!原因:" + err_text);
                    }
                    else
                    {
                        ts_mzys_class.MZHS_FZJL.AddHz(jgbm, Ghxxid, _ghks, ts_mzys_class.MZHS_FZJL.FzStatus.已分诊, out NewFzid, out err_code, out err_text, fsd_btime, fsd_etime, fsd_sdbm, _fzzq.Zqid, _DataBase);
                        if (err_code != 0)
                            throw new Exception("分诊自动报道出现异常!原因:" + err_text);
                    }
                }
                else //未设置诊区的也插入记录到分诊表
                {
                    ts_mzys_class.MZHS_FZJL.AddHz(jgbm, Ghxxid, _ghks, ts_mzys_class.MZHS_FZJL.FzStatus.已分诊, out NewFzid, out err_code, out err_text, fsd_btime, fsd_etime, fsd_sdbm, 0, _DataBase);
                    if (err_code != 0)
                        throw new Exception("分诊自动报道出现异常!原因:" + err_text);
                }
                //if (_fsd != null && _fsd.FsdId > 0 && (string.IsNullOrEmpty(_yysd)))
                //    _fsd.UpdateFsdGhrc(ref _fsd, _DataBase); //更新挂号人数

                #endregion
                //回填挂号信息
                UpateYyghxx(YYID, Ghxxid, _ghsj, _DataBase);
                sql = @" select a.GHXXID as 挂号信息id,dbo.fun_getDeptname(a.GHKS) as 科室名称,a.GHDJSJ as 挂号登记时间,ISNULL( b.TYPE_NAME,'') as 医生级别名称,
                  case when a.YYLX=1 then '院内预约' when a.YYLX=2 then '网上预约' when a.YYLX=3 then '电话预约' else '非预约' end as 预约类型,
                  a.PDXH as 候诊号,dbo.fun_getEmpName(a.GHYS) as 挂号医生名称,GHJE as 挂号金额,'' as 诊室位置,a.GHSJ 挂号日期
                  from MZ_GHXX as a left join jc_doctor_type as b on a.GHJB=b.TYPE_ID where a.ghxxid='" + Ghxxid.ToString() + "'";
                dt_ghxx = _DataBase.GetDataTable(sql);

                #endregion
            }
            catch (Exception ea)
            {
                throw new Exception(ea.Message);
            }
            return true;
        }
        /// <summary>
        /// 更新预约挂号表的支付标志为已支付(更新支付标志为已支付PAYMONEY_FLAG=1 支付方式为第三方商户端支付 ZFSORT=1)
        /// </summary>
        /// <param name="YYID">预约id</param>
        /// <param name="brxm">病人姓名</param>
        /// <param name="ghrq">预约日期</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static bool UpdateMoneyFlag(Guid YYID, string brxm, string ghrq, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"UPDATE MZ_YYGHLB SET PAYMONEY_FLAG=1,ZFSORT=1  WHERE YYID='" + YYID + @"' AND BRXM='" + brxm + @"' 
           AND CONVERT(varchar(10),YYRQ,120)=CONVERT(varchar(12),'" + ghrq + "',120)";
                if (_DataBase.DoCommand(sql) > 0)
                    return true;
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return false;
        }

        /// <summary>
        /// 取消已取号未就诊的预约挂号记录(针对用诊疗卡内的金额缴费取号后。通过该方法退号)
        /// </summary>
        /// <param name="YYID">预约id</param>
        /// <param name="cardno">卡号</param>
        /// <param name="brxm">病人姓名</param>
        /// <param name="ghrq">挂号日期</param>
        /// <param name="czyh">操作员号</param>
        /// <returns></returns>
        public static bool CancelYQH_YYGH(Guid YYID, string cardno, string brxm, string ghrq, int czyh,
            out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            err_code = -1;
            err_text = "";
            try
            {
                /*先查询挂号表有无此预约挂号的记录,无则返回逻辑错误,有则进行与挂号动态库一样的方法，进行退号*/
                string sql = @"select GHXXID from MZ_YYGHLB WHERE YYID='" + YYID + @"' AND KH='" + cardno + @"' AND BRXM='" + brxm + @"' 
               AND CONVERT(VARCHAR(10), YYRQ,120)=CONVERT(VARCHAR(12),'" + ghrq + @"',120) ";
                object result = _DataBase.GetDataResult(sql);
                if (result == null)
                {
                    err_code = 1;
                    err_text = "该预约记录还未进行取号操作!需要退号请用CanCelYYGH函数进行撤销预约!";
                    return false;
                }

                Guid _ghxxid = new Guid(result.ToString()); //获取挂号信息id 
                sql = @"select a.*,b.brxm from mz_ghxx A inner join YY_BRXX b on A.BRXXID=B.BRXXID 
                 where a.ghxxid='" + _ghxxid.ToString() + "'"; //查询挂号表的信息
                DataTable dt_ghxx = _DataBase.GetDataTable(sql);
                if (dt_ghxx.Rows.Count == 0)
                {
                    err_code = 1;
                    err_text = "通过预约表的挂号id未查询到病人的挂号记录!请联系管理员!";
                }
                Guid _brxxid = new Guid(dt_ghxx.Rows[0]["brxxid"].ToString());
                string _sDate = DateManager.ServerDateTimeByDBType(_DataBase).ToString();
                long dnlsh = Convert.ToInt64(Convertor.IsNull(dt_ghxx.Rows[0]["dnlxh"], "0"));
                string fph = Convertor.IsNull(dt_ghxx.Rows[0]["fph"], "0");
                DataTable TbFp = mz_sf.SelectFp(_ghxxid, dnlsh, fph, 1, _DataBase);

                _DataBase.BeginTransaction(); //开始事务

                string _sfck = "";
                int _NRows = 0;
                int _err_code = -1;
                string _err_text = "";
                //取消挂号记录
                mz_ghxx.CancelGh(_ghxxid, _sDate, czyh, out _NRows, out _err_code, out _err_text, _DataBase);
                if (_NRows == 0 || _err_code != 0) throw new Exception("数据已转移到历史库,不能办理退费,请咨询管理员！");

                #region//产生结算记录
                Guid NewJsid = Guid.Empty;
                decimal yhje = Convert.ToDecimal(TbFp.Rows[0]["YHJE"]);
                decimal zje = Convert.ToDecimal(TbFp.Rows[0]["zje"]);
                decimal srje = Convert.ToDecimal(TbFp.Rows[0]["srje"]);
                decimal ybzhzf = Convert.ToDecimal(TbFp.Rows[0]["ybzhzf"]);
                decimal ybjjzf = Convert.ToDecimal(TbFp.Rows[0]["ybjjzf"]);
                decimal ybbzzf = Convert.ToDecimal(TbFp.Rows[0]["ybbzzf"]);
                decimal qfgz = Convert.ToDecimal(TbFp.Rows[0]["qfgz"]);
                decimal cwjz = Convert.ToDecimal(TbFp.Rows[0]["cwjz"]);
                decimal ylkzf = Convert.ToDecimal(TbFp.Rows[0]["ylkzf"]);
                decimal xjzf = Convert.ToDecimal(TbFp.Rows[0]["xjzf"]);
                mz_sf.SaveJs(Guid.Empty, _brxxid, _ghxxid, _sDate, czyh, (-1) * zje, (-1) * ybzhzf, (-1) * ybjjzf, (-1) * ybbzzf, (-1) * ylkzf, (-1) * yhje, (-1) * cwjz, (-1) * qfgz, (-1) * xjzf, 0, (-1) * srje, 0, 0, 0, 1, TrasenFrame.Forms.FrmMdiMain.Jgbm, out NewJsid, out _err_code, out _err_text, _DataBase);
                if (NewJsid == Guid.Empty || _err_code != 0) throw new Exception(_err_text);
                #endregion
                //如果是用诊疗卡消费则更新卡余额和累计消息金额
                if (cwjz > 0)
                {
                    Guid kdjid = new Guid(Convertor.IsNull(dt_ghxx.Rows[0]["kdjid"], Guid.Empty.ToString()));
                    ReadCard readcard = new ReadCard(kdjid, _DataBase);
                    readcard.UpdateKye((-1) * cwjz, _DataBase);
                }
                //预约退号 暂时不进行退卡操作   退卡 add by zouchihua  收过卡钱就退卡  
                //if (Convertor.IsNull(lbltk.Tag, "") == "999")
                //{
                //    mz_kdj.CancelCard(readcard.kdjid, readcard.kh, InstanceForm.BCurrentUser.EmployeeId, "病人退挂号签", _brxxid, out _err_code, out _err_text, InstanceForm.BDatabase);
                //    if (_err_code != 0) throw new Exception(_err_text);
                //}

                #region 作废原发票
                Guid NewFpid = Guid.Empty;

                mz_sf.SaveFp(Guid.Empty, _brxxid, _ghxxid, TbFp.Rows[0]["BLH"].ToString(), TbFp.Rows[0]["BRXM"].ToString(), _sDate, czyh, _sfck, 0, TbFp.Rows[0]["fph"].ToString(),
                    (-1) * zje, (-1) * ybzhzf, (-1) * ybjjzf,
                    (-1) * ybbzzf, (-1) * ylkzf, (-1) * yhje,
                    (-1) * cwjz, (-1) * qfgz, (-1) * xjzf, 0,
                    (-1) * srje, new Guid(TbFp.Rows[0]["FPID"].ToString()), "", NewJsid, 1, Convert.ToInt32(TbFp.Rows[0]["ksdm"]),
                    Convert.ToInt32(TbFp.Rows[0]["ysdm"]), Convert.ToInt32(TbFp.Rows[0]["zyksdm"]), Convert.ToInt32(TbFp.Rows[0]["zxks"]),
                    Convert.ToInt32(TbFp.Rows[0]["yblx"]), Convert.ToString(TbFp.Rows[0]["ybjydjh"]), 2, new Guid(Convertor.IsNull(TbFp.Rows[0]["kdjid"], Guid.Empty.ToString())),
                    Convert.ToInt64(TbFp.Rows[0]["jgbm"]), new Guid(Convertor.IsNull(TbFp.Rows[0]["yhlxid"], Guid.Empty.ToString())), Convertor.IsNull(TbFp.Rows[0]["yhlxmc"], ""), out NewFpid, out _err_code, out _err_text, _DataBase);
                if (NewFpid == Guid.Empty || _err_code != 0) throw new Exception(_err_text);

                //更新医保结算表的收费信息
                //if (yblx.isgh == true)
                //{
                //    ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yblx.ybjklx);
                //    bool bok = ybjk.UpdateJsmx(_brxxid, _ghxxid, jsxx.HisJsid_Old, jsxx.HisJsdid, new Guid(TbFp.Rows[0]["FPID"].ToString()), TbFp.Rows[0]["fph"].ToString(), _sDate, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                //    if (bok == false) throw new Exception("更新本地医保结算表时没有成功");
                //}
                //处理发票
                DataTable tb_fpmx = mz_sf.SelectFp_mx(new Guid(TbFp.Rows[0]["fpid"].ToString()), _DataBase);
                for (int i = 0; i <= tb_fpmx.Rows.Count - 1; i++)
                {
                    mz_sf.SaveFpmx(NewFpid, Convertor.IsNull(tb_fpmx.Rows[i]["xmdm"], "0"), Convertor.IsNull(tb_fpmx.Rows[i]["xmmc"], "0"), (-1) * Convert.ToDecimal(tb_fpmx.Rows[i]["je"]), 0, out _err_code, out _err_text, _DataBase);
                    if (_err_code != 0)
                    {
                        _DataBase.RollbackTransaction();
                        throw new Exception(_err_text);
                    }
                }
                //处理发票明细
                DataTable tb_fpdxmmx = mz_sf.SelectFp_dxmmx(new Guid(TbFp.Rows[0]["fpid"].ToString()), _DataBase);
                for (int i = 0; i <= tb_fpdxmmx.Rows.Count - 1; i++)
                {
                    mz_sf.SaveFpdxmmx(NewFpid, Convertor.IsNull(tb_fpdxmmx.Rows[i]["xmdm"], "0"), Convertor.IsNull(tb_fpdxmmx.Rows[i]["xmmc"], "0"), (-1) * Convert.ToDecimal(tb_fpdxmmx.Rows[i]["je"]), 0, out _err_code, out _err_text, _DataBase);
                    if (_err_code != 0)
                    {
                        _DataBase.RollbackTransaction();
                        throw new Exception(_err_text);
                    }
                }
                //处理发票状态
                int Nrows = 0;
                mz_sf.UpdateFpjlzt(new Guid(TbFp.Rows[0]["fpid"].ToString()), out Nrows, _DataBase);
                if (Nrows != 1)
                {
                    _DataBase.RollbackTransaction();
                    throw new Exception("更新原发票记录状态时出错,没有更新到行");
                }

                #endregion
                if (zje > 0) //所收金额大于0 
                {
                    mz_cf.Tghp(_ghxxid, fph, _sfck, _sDate, NewFpid, out _err_code, out _err_text, _DataBase);
                    if (_err_code != 0)
                    {
                        _DataBase.RollbackTransaction();
                        throw new Exception(_err_text);
                    }
                }



                _DataBase.CommitTransaction();
                err_text = "挂号退签成功";
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return false;
        }

        /// <summary>
        /// 获取预约限号信息
        /// </summary>
        /// <param name="ksdm">科室代码</param>
        /// <param name="ysdm">医生代码</param>
        /// <param name="ysjb">医生级别</param>
        /// <param name="is_show">是否显示 1显示</param>
        /// <param name="sd">时间段 1上午 2下午</param>
        /// <param name="yydate">预约日期</param>
        /// <param name="memo">备注 出参</param>
        /// <param name="err_code">错误代码 出参</param>
        /// <param name="err_text">错误信息 出参</param>
        public static void GetOrderXhInfo(int ksdm, int ysdm, int ysjb, int is_show, int sd, string yydate,
            out string memo, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parment = new ParameterEx[9];
                parment[0].Text = "@GHKS";
                parment[0].Value = ksdm;

                parment[1].Text = "@GHJB";
                parment[1].Value = ysjb;

                parment[2].Text = "@GHYS";
                parment[2].Value = ysdm;

                parment[3].Text = "@bxs";
                parment[3].Value = is_show;

                parment[4].Text = "@sd";
                parment[4].Value = sd;

                parment[5].Text = "@yydate";
                parment[5].Value = yydate;

                parment[6].Text = "@OUTBZ";
                parment[6].Value = "";
                parment[6].ParaDirection = ParameterDirection.Output;
                parment[6].ParaSize = 200;

                parment[7].Text = "@ERR_CODE";
                parment[7].Value = "0";
                parment[7].ParaDirection = ParameterDirection.Output;
                parment[7].DataType = System.Data.DbType.Int32;

                parment[8].Text = "@ERR_TEXT";
                parment[8].Value = "";
                parment[8].ParaDirection = ParameterDirection.Output;
                parment[8].ParaSize = 200;

                _DataBase.DoCommand("SP_MZSF_MZXH_ORDER", parment, 30);
                memo = parment[6].Value.ToString();
                err_code = Convert.ToInt32(parment[7].Value);
                err_text = parment[8].Value.ToString();
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        /// <summary>
        /// 通过排班绑定医生级别 
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="ysdm">医生代码</param>
        /// <param name="pblx">排班类型1上午2下午</param>
        /// <param name="ksid">科室id</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable BindDocLevelByPb(string date, int ysdm, int pblx, int ksid, RelationalDatabase _DataBase)
        {
            string ssql = @"select ZZJBID,ZZJB from  JC_MZ_YSPB where CONVERT(varchar(10), PBSJ,120)=CONVERT(varchar(10),'" + date + @"',120) 
            and YSID=" + ysdm + " and PBLX=" + pblx + " and PBKSID=" + ksid + " and BSCBZ=0";
            DataTable tb = _DataBase.GetDataTable(ssql);
            return tb;
        }

        /// <summary>
        /// 预约挂号记录状态 add by zp 2013-4-15
        /// </summary>
        public enum YYgh_Status : int
        {
            所有记录 = 0,
            未作废记录 = 1,
            已作废记录 = 2,
            未作废未取号记录 = 3,
            未作废已取号记录 = 4,
            /// <summary>
            /// 包含作废 和未作废记录  Add by zp 2014-07-30
            /// </summary>
            未取号记录 = 5
        }
        /// <summary>
        /// 预约挂号类型 add by zp 2013-4-16
        /// </summary>
        public enum YYgh_Sort : int
        {
            院内预约 = 1,
            网上预约 = 2,
            电话预约 = 3,
            医生站预约 = 4
        }
        //发送短信到指定手机 Add by zp 2013-12-26  _brxxid可以传空,不影响发送短信
        public static string SetMobilePhoneMsg(string _brxxid, string phone_number, string msg, SystemCfg _cfg1102, SystemCfg _cfg1104, RelationalDatabase _DataBase)
        {
            string result = "";
            try
            {
                if (string.IsNullOrEmpty(_cfg1104.Config)) return result;
                OrderMessageService _OrderMsgService = new OrderMessageService(_cfg1104.Config);
                Guid _sismsid = Guid.NewGuid();

                if (string.IsNullOrEmpty(_cfg1102.Config)) return result;
                string parm = _cfg1102.Config.Trim();
                string[] _par = parm.Split('-');
                if (_par.Length < 4) return result;
                string server = _par[0];
                string db = _par[1];
                string userid = _par[2];
                string pwd = _par[3];
                StringBuilder post = new StringBuilder();
                post.Append(@"<PAYMENT>
                          <HEAD>
                            <DevNo></DevNo>
                            <TranNo></TranNo>
                            <TranCode></TranCode>
                            <ResponseCode></ResponseCode>
                            <ResponseMsg></ResponseMsg>
                            <HisNo></HisNo>
                            <Date></Date>
                            <Time></Time>
                          </HEAD>
                          <DATA>
                             <Demo>" + msg + @"</Demo>
                             <DOB>" + db + @"</DOB>
                             <IDNo>" + userid + @"</IDNo>
                             <QhPassWord>" + pwd + @"</QhPassWord>    
                             <Address>" + server + @"</Address>
                             <Tel>" + phone_number + @"</Tel>
                             <RowID>" + _brxxid + @"ID</RowID>
                          </DATA>
                       </PAYMENT>");
                result = _OrderMsgService.SetMesg(post.ToString());
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return result;
        }



    }
}
