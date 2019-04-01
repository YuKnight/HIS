using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using System.Globalization;
using TrasenFrame.Classes;

namespace ts_zyhs_classes
{
    /// <summary>
    /// 医嘱执行信息类
    /// </summary>
    public class ClsOrderExecInfo
    {
        private RelationalDatabase _database;
        public ClsConfigList _cfgList;
        public List<OrderEntity> _orderList;
        public List<OrderExecEntity> _orderExecList;
        public DataTable _dtPat;
        public DataTable _dtFreq;
        public long EXEUSER;
        public Guid _Binid;
        public long _Babyid;
        public long _JGBM;
        private DateTime EXECDATE;//传入
        public long _Groupid;

        public int MNGTYPE;// --MNGTYPE=5使用
        public Guid ORDERID;
        public int? FRISTTIMES;
        public int? TERMINALTIMES;
        public string FREQUENCY;
        public long DEPTID;
        public long DEPTBR; //ADD BY TANY 2005-08-30 病人所在科室
        public long DEPTLY;//ADD BY TANY 2005-12-11 领药科室
        public string WARDID;
        public long EXEDEPT;
        public int NTYPE;
        public DateTime BEGINEXEDATE;
        public DateTime? STOPEXEDATE;
        public int STATUS_FLAG;
        public long HOITEMID;
        public string ITEMCODE;
        public int XMLY;// --1药品2项目3物资
        public int CYCLEDAY;// --循环天数
        public int CYCLELX;// --循环类型 1=周期执行2=星期执行
        public int ZXR;//--执行日 @CYCLELX=2 时 1=星期日2=星期一3=星期二4=星期三5=星期四6=星期五7=星期六
        public int MNGTYPE2;// --MNGTYPE=5使用
        public string ORDERUNIT;// --ADD BY TANY 2007-10-29 增加医嘱单位判断单位是不是改变
        public string NOWUNIT;//--当前单位
        public int ISKDKSLY;//--是否开单科室领药
        public long GCYS;// --Modify By Tany 2009-12-23 增加管床医生
        public int ZHBJ;
        public int PVSCHKBIT;
        public string ORDER_USAGE;
        public string EXECTIME;
        public int YBLX;
        public string BED_NO;
        public string PAT_NAME;
        public int TS;//--add by zouchihua 临时医嘱天数
        public int TEMPPL;// --add by zouchihua 临时医嘱频率

        public Guid EXECID;
        public long ADDFEEID;
        public DateTime EXECBOOKDATE;
        public int EXENUM0;
        public int EXENUM;

        public decimal CFH;//DECIMAL(21,6);
        public decimal NUM; //DECIMAL(18,3)
        public decimal RETAIL_PRICE;//DECIMAL(18,3);//---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
        public decimal RETAIL_PRICE1;//DECIMAL(18,3)  //---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用


        public int NUM_NEW;// ---add yaokx 2014-05-22 附加费用每日执行一次
        public int HDITEM_ID;// ---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
        public int NUM_FJ;//---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
        public int HDITEM_ID1;// ---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用

        public int NUM_FJ1;//---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
        public int GLXMID;// ---add yaokx 2014-05-29 
        public int JD;//---add yaokx 2014-05-29 
        public int XD;//---add yaokx 2014-05-29 
        public int cfg7198;//--add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
        public string cfg7199;// ---add yaokx 2014-05-29 
        public string cfg7200;//---add yaokx 2014-05-29

        public bool BSsmzOrder = false;

        public int EXECNUM;
        public int EXECNUMtmp;

        public Guid _BRXXID;//医技用

        public ClsOrderExecInfo(RelationalDatabase database)
        {
            _database = database;
        }

        #region"数据初始化"

        public void DoInit(ClsConfigList cfgList, List<OrderEntity> orderList, List<OrderExecEntity> orderExecList, DataTable dtPat, DataTable dtFreq, long thisExecUser,
            Guid Binid, long Babyid, long Groupid, long JGBM, DateTime thisEXECDATE, int _MNGTYPE, int _MNGTYPE2)
        {
            _cfgList = cfgList;
            _orderList = orderList;
            _orderExecList = orderExecList;
            EXEUSER = thisExecUser;
            _Binid = Binid;
            _Babyid = Babyid;
            _Groupid = Groupid;
            _JGBM = JGBM;
            EXECDATE = thisEXECDATE;
            MNGTYPE = _MNGTYPE;
            MNGTYPE2 = _MNGTYPE2;

            _dtPat = dtPat;

            if (orderList.Count <= 0)
                throw new Exception("初始化 执行详细信息 失败，未传入医嘱！");

            if (dtPat.Rows.Count <= 0)
                throw new Exception("初始化 执行详细信息 失败，未传入患者在床信息！");

            if (dtFreq.Rows.Count <= 0)
                throw new Exception("初始化 执行详细信息 失败，未传入频率基础信息！");

            OrderEntity order = _orderList[0];//执行科室从大到小处理（处理组中含有自备药）

            string freq = order.FREQUENCY.ToUpper();
            //如果有频率
            if (!string.IsNullOrEmpty(freq))
            {
                //获取该组频率信息
                _dtFreq = dtFreq.Clone();
                for (int i = 0; i < dtFreq.Rows.Count; i++)
                {
                    string jcFreq = dtFreq.Rows[i]["NAME"].ToString().ToUpper();

                    if (jcFreq.Equals(freq))
                    {
                        _dtFreq.Rows.Add(dtFreq.Rows[i].ItemArray);
                    }
                }
                _dtFreq.AcceptChanges();

                //if (_dtFreq.Rows.Count <= 0)
                //    throw new Exception(dtPat.Rows[0]["BED_NO"].ToString() + " 床病人 " + dtPat.Rows[0]["NAME"].ToString() + " 初始化执行详细信息err：医嘱频率：" + freq + " 未匹配到基础频率表中的数据！");
            }

            DoInitParamInfo(order, _dtPat, _dtFreq);
        }

        /// <summary>
        /// |取得医嘱的病人ID，婴儿ID,医嘱号，执行科室，医嘱分类，医嘱频率的执行次数，开始执行时间，医嘱状态，医嘱项目表ID，药品代码，
        /// |首日执行次数，频率,医嘱类别
        /// </summary>
        /// <param name="order"></param>
        /// <param name="dtPat"></param>
        /// <param name="dtFreqInfo"></param>
        public void DoInitParamInfo(OrderEntity order, DataTable dtPat, DataTable dtFreqInfo)
        {
            ORDERID = order.ORDER_ID;
            EXEDEPT = order.EXEC_DEPT;
            NTYPE = order.NTYPE;

            BEGINEXEDATE = order.ORDER_BDATE;
            STOPEXEDATE = order.ORDER_EDATE;
            STATUS_FLAG = order.STATUS_FLAG;
            HOITEMID = order.HOITEM_ID;

            ITEMCODE = order.ITEM_CODE;
            FREQUENCY = order.FREQUENCY;
            DEPTID = order.DEPT_ID;
            XMLY = order.XMLY;
            ISKDKSLY = order.ISKDKSLY;

            TS = int.Parse(Convertor.IsNull(order.ts, "1"));//(case  when ts is null then 1 else ts end);
            ZHBJ = int.Parse(Convertor.IsNull(order.ZHBJ, "0")); ;//isnull(zhbj,0) ;

            PVSCHKBIT = order.is_PvsChk;//is_PvsChk;//		--add by jchl

            ORDER_USAGE = order.ORDER_USAGE;// --Add By Tany 2015-04-20

            //频次初始化
            EXECNUM = 1;
            EXECNUMtmp = 1;
            CYCLEDAY = 1;
            CYCLELX = 1;
            ZXR = 1234567;
            string freq = order.FREQUENCY.ToUpper();
            if (string.IsNullOrEmpty(freq) || dtFreqInfo == null || dtFreqInfo.Rows.Count <= 0)
            {
                //非正规频率
                EXECNUM = 1;
                EXECNUMtmp = 1;
                CYCLEDAY = 1;
                CYCLELX = 1;
                ZXR = 1234567;
            }
            else
            {
                DataTable dtFreq = GetFreqByFreqName(dtFreqInfo);
                if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                {
                    EXECNUM = 1;
                }
                else
                {
                    EXECNUM = int.Parse(dtFreq.Rows[0]["EXECNUM"].ToString());
                }
                EXECNUMtmp = int.Parse(dtFreq.Rows[0]["EXECNUM"].ToString());

                CYCLEDAY = int.Parse(dtFreq.Rows[0]["CYCLEDAY"].ToString());
                CYCLELX = int.Parse(dtFreq.Rows[0]["LX"].ToString());
                ZXR = int.Parse(dtFreq.Rows[0]["ZXR"].ToString());
                EXECTIME = dtFreq.Rows[0]["EXECTIME"].ToString().Trim();
                TEMPPL = Convertor.IsNull(order.ts, "-1").Equals("-1") ? 1 : EXECNUMtmp;//(case  when ts is null then 1 else EXECNUMtmp end);//--临时医嘱执行次数

            }

            FRISTTIMES = order.FIRST_TIMES > EXECNUM ? 1 : order.FIRST_TIMES;
            TERMINALTIMES = order.TERMINAL_TIMES > EXECNUM ? 1 : order.TERMINAL_TIMES;

            GCYS = 0;//CASE WHEN ZY_DOC<=0 OR ZY_DOC IS NULL THEN ORDER_DOC ELSE ZY_DOC END;
            long iZyDoc = long.Parse(Convertor.IsNull(dtPat.Rows[0]["ZY_DOC"], "0"));
            GCYS = iZyDoc > 0 ? iZyDoc : order.ORDER_DOC;

            WARDID = dtPat.Rows[0]["WARD_ID"].ToString();
            DEPTBR = long.Parse(dtPat.Rows[0]["DEPT_ID"].ToString());
            BED_NO = dtPat.Rows[0]["BED_NO"].ToString();
            PAT_NAME = dtPat.Rows[0]["NAME"].ToString();
            YBLX = int.Parse(dtPat.Rows[0]["YBLX"].ToString()); // --Add By jchl 2016-12-27

            //开单科室是否手麻
            string ssql = string.Format(@"select * from SS_DEPT where DEPTID={0} ", order.DEPT_ID);
            DataTable dt = _database.GetDataTable(ssql);
            if (dt != null && dt.Rows.Count > 0)
            {
                BSsmzOrder = true;
            }

            if (NTYPE == 5)
            {
                ssql = string.Format(@"select A.PATIENT_ID from ZY_INPATIENT A where INPATIENT_ID='{0}' ", _Binid);

                string strBrxxid = _database.GetDataResult(ssql).ToString();

                _BRXXID = new Guid(strBrxxid);
            }
        }

        #endregion

        #region"执行准备调用方法"

        #region"医嘱是否能执行(0：继续  1：return  2：nextday完成处理)"

        /// <summary>
        /// 医嘱是否可以执行
        /// 1、没有转抄的医嘱或已经停止的医嘱不发送 
        /// 2、临时医嘱、账单：如果已经执行过则不再执行，不管状态如何
        /// </summary>
        /// <returns>1：执行  2：nextday 0：return</returns>
        public int CanOrderExec()
        {
            int iret = 0;
            try
            {
                // 1、没有转抄的医嘱或已经停止的医嘱不发送 
                if (STATUS_FLAG < 2 || STATUS_FLAG == 5)
                {
                    iret = 1;
                    return iret;//不发送
                }

                if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                {
                    if (_orderExecList != null && _orderExecList.Count > 0)
                    {
                        if (STATUS_FLAG == 2)
                        {
                            iret = 2;//nextday更新状态
                            return iret;
                        }
                        else
                        {
                            iret = 1;//完成
                            return iret;
                        }
                    }
                }

                iret = 0;//继续执行
                return iret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 医嘱是否可以执行
        /// 3、已经停转抄并且当前执行时间大于停日期
        /// </summary>
        /// <returns>1：执行  2：nextday 0：return</returns>
        public int CanOrderExecWhenStop()
        {
            int iret = 0;
            try
            {
                if (STATUS_FLAG == 4)
                {
                    if (!STOPEXEDATE.HasValue)
                    {
                        throw new Exception(_orderList[0].ORDER_CONTEXT + " 已经停嘱了,没有停嘱时间,请联系管理员！");
                    }

                    if (CUREXECDATE.Date > STOPEXEDATE.Value.Date && EXECDATE.Date >= STOPEXEDATE.Value.Date)
                    {
                        iret = 2;//nextday更新状态
                        return iret;
                    }
                }

                iret = 0;//继续执行
                return iret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region"处理当前执行时间CUREXECDATE、LASTEXECDATE、LASTVALIDEXECDATE、execNumEver"

        private DateTime CUREXECDATE;
        private DateTime? LASTEXECDATE;
        private DateTime? LASTVALIDEXECDATE;
        private int execNumEver = 0;//最大执行日期的：从前执行次数

        /// <summary>
        /// 获取当前执行时间
        /// </summary>
        /// <returns></returns>
        public void SetCurrExecDate()
        {
            CUREXECDATE = BEGINEXEDATE;//临嘱或未发送长期默认开时间
            try
            {
                execNumEver = 0;//重前执行次数
                if (MNGTYPE == 0 || MNGTYPE == 2)
                {
                    /*
                        IF (@LASTEXECDATE IS NOT NULL )  
                         begin
                             --执行次数小于频次,当前执行时间日期不变 Modify by zouchihua 2012-02-01
                             if @Cqyz_zxcs<@EXENUM0 and @BEGINEXEDATE!=@LASTEXECDATE                               --1
                               SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
                             --日期加一天 Modify by zouchihua 2012-02-01
                             ELSE
                               SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,1,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
                               --如果是出院医嘱等，就
                               IF @ntype=0
                                 SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
                          END 
                        ELSE
                            SET @CUREXECDATE=@BEGINEXEDATE
                     */

                    List<OrderExecEntity> myExeOrderList = new List<OrderExecEntity>();

                    //取出该orderid的所有执行记录
                    foreach (OrderExecEntity myExeOrder in _orderExecList)
                    {
                        if (myExeOrder.ORDER_ID == ORDERID)
                        {
                            myExeOrderList.Add(myExeOrder);
                        }
                    }

                    if (myExeOrderList.Count > 0)
                    {
                        myExeOrderList.Sort();//根据execDate从大到小排序

                        OrderExecEntity orderExecMax = myExeOrderList[0];//最大执行时间第一条

                        LASTEXECDATE = orderExecMax.EXECDATE;//LASTEXECDATE处理

                        //foreach (OrderExecEntity ordExe in myExeOrderList)
                        for (int i = 0; i < myExeOrderList.Count; i++)
                        {
                            OrderExecEntity ordExe = myExeOrderList[i];
                            int isAna = int.Parse(Convertor.IsNull(ordExe.ISANALYZED, "0"));
                            DateTime thisExeDate = ordExe.EXECDATE;

                            if (isAna > 0 && !LASTVALIDEXECDATE.HasValue)
                            {
                                LASTVALIDEXECDATE = ordExe.EXECDATE;//如果没有值，赋值当前执行时间
                            }

                            if (isAna > 0 && (LASTVALIDEXECDATE.HasValue && thisExeDate > LASTVALIDEXECDATE))
                            {
                                LASTVALIDEXECDATE = ordExe.EXECDATE;//LASTVALIDEXECDATE处理//最大执行日期倒叙取有效执行次数>0的记录
                            }

                            if (ordExe.EXECDATE.Date == LASTEXECDATE.Value.Date)
                            {
                                execNumEver += ordExe.ISANALYZED;
                            }
                        }

                        //throw new Exception();

                        //执行次数小于频次,当前执行时间日期不变 Modify by zouchihua 2012-02-01
                        if (execNumEver < EXECNUM && BEGINEXEDATE != LASTEXECDATE)
                        {
                            //执行次数小于频次,并且非首日执行（即：需要补足该日未执行完频次）
                            CUREXECDATE = Convert.ToDateTime(LASTEXECDATE.Value.Date.ToString("yyyy-MM-dd") + EXECDATE.ToString(" HH:mm:ss"));//(wait 优化：频率之间的时候当天医嘱会有两条执行记录 比如：20 日 q3d 首次1 【第一次发送至21日 接着第二次发送至22日 21日的执行记录会有两条0的】)
                        }
                        else
                        {
                            CUREXECDATE = Convert.ToDateTime(LASTEXECDATE.Value.AddDays(1).ToString("yyyy-MM-dd") + EXECDATE.ToString(" HH:mm:ss"));
                        }

                        if (NTYPE == 0)
                        {
                            CUREXECDATE = Convert.ToDateTime(LASTEXECDATE.Value.ToString("yyyy-MM-dd") + EXECDATE.ToString(" HH:mm:ss"));
                        }

                        ////如果是出院医嘱等，就
                        //IF @ntype=0
                        //  SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
                    }
                    else
                    {
                        CUREXECDATE = BEGINEXEDATE;//临嘱或未发送长期默认开时间
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取CUREXECDATE时err：" + ex.Message);
            }
        }

        #endregion

        #region"处理执行时间EXECDATE"

        /// <summary>
        /// 获取需要执行的时间（前台传入后，可能需要处理）
        /// </summary>
        /// <returns></returns>
        public void SetExecDate()
        {
            try
            {
                if (STATUS_FLAG == 4)
                {
                    if (!STOPEXEDATE.HasValue)
                    {
                        throw new Exception(_orderList[0].ORDER_CONTEXT + " 已经停嘱了,没有停嘱时间,请联系管理员！");
                    }

                    if (EXECDATE.Date < STOPEXEDATE.Value.Date)
                    {
                        EXECDATE = STOPEXEDATE.Value.Date;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取EXECDATE时err：" + ex.Message);
            }
        }

        #endregion

        #region"获得参数  科室药品是否直接记账"
        //获得参数  科室药品是否直接记账
        private int iMedCharge = -1;

        /// <summary>
        /// IF (SELECT CONFIG FROM JC_CONFIG WHERE ID=7018)='是'
        /// </summary>
        /// <returns></returns>
        public void IsMedCharge()
        {
            try
            {
                if (_cfgList.cfg7018.Config.Trim().Equals("是"))
                {
                    iMedCharge = 1;
                }
            }
            catch (Exception ex)
            {
                iMedCharge = 0;
                throw ex;
            }
        }

        #endregion

        #region"pivas处理（最终处理pvsbit、cfbit和执行科室@EXEDEPT=@pvsExeDept）"

        //pivas处理（最终处理pvsbit和执行科室@EXEDEPT=@pvsExeDept）
        private int pvsBit = 0;//是否pivas

        public int SetPivasBit(out long execDeptId, out int errCode, out string errMsg)
        {
            execDeptId = EXEDEPT;
            pvsBit = 0;
            errCode = 0;
            errMsg = "";
            try
            {
                long pvsDept = 0;
                bool isYp = XMLY == 1;
                bool isYpOth = NTYPE == 1 || NTYPE == 2;//西、中成
                //1、先判断该医嘱是否可以Pivas  （1、该领药科室是否进入pivas管理（JC_DEPT_DRUGSTORE） 2、频率配置了VI_pivas_Freq   3、用法配置了VI_pivas_Orderusage ）   
                bool CanPivas = IsCanPivas(FREQUENCY, ORDER_USAGE, DEPTBR, EXEDEPT, out pvsDept);//病人所在药房是否可以配置pivas

                if (isYp && isYpOth && CanPivas)
                {

                    //2、判断医嘱审方标记 
                    if (PVSCHKBIT == 2)
                    {
                        errCode = -1;
                        errMsg = "该医嘱pivas审方未通过，请通知医生停嘱!";
                        return pvsBit;
                    }

                    //3、判断pivas的审方内容（0长嘱、1临嘱、2长临嘱）7602
                    string pvsType = _cfgList.cfg7602.Config.ToString().Trim();
                    if ((pvsType.Equals("0") && MNGTYPE == 0) ||
                        (pvsType.Equals("1") && MNGTYPE == 1) ||
                        (pvsType.Equals("2") && (MNGTYPE == 0 || MNGTYPE == 1)))
                    {
                        //pivas配置规律
                        //1.组医嘱大于2条医嘱
                        int iOrdCnt = _orderList.Count;

                        //2.不配自备药
                        bool isZb = false;

                        foreach (OrderEntity myOrder in _orderList)
                        {
                            isZb = myOrder.HOITEM_ID <= 0 || myOrder.EXEC_DEPT <= 0;
                            if (isZb == true)
                                break;
                        }

                        if (iOrdCnt > 1 && (!isZb))
                        {
                            //pivas处理
                            foreach (OrderEntity order in _orderList)
                            {
                                string unit = "";
                                decimal kcl = 0;
                                decimal xnKcl = 0;
                                //获取pivas库存信息

                                GetYpKcmxInfo(order.DWLX, order.HOITEM_ID, order.XMLY, pvsDept, out unit, out kcl, out xnKcl);

                                if (string.IsNullOrEmpty(unit))
                                {
                                    pvsBit = 0;
                                    execDeptId = EXEDEPT;//原药房
                                    return pvsBit;
                                }

                                //case when @MNGTYPE in(1,5) then isnull(a.zsldw,a.unit) else A.UNIT end
                                string thisOrderUnit = "";
                                if (MNGTYPE == 1 || MNGTYPE == 5)
                                {
                                    thisOrderUnit = string.IsNullOrEmpty(Convertor.IsNull(order.zsldw, "")) ? order.UNIT : order.zsldw;
                                }
                                else
                                {
                                    thisOrderUnit = order.UNIT;
                                }

                                //药品字段单位是否重新配置
                                if (!thisOrderUnit.Trim().Equals(unit.Trim()))
                                {
                                    pvsBit = 0;
                                    execDeptId = EXEDEPT;//原药房
                                    return pvsBit;
                                }

                                if (kcl <= 0)
                                {
                                    pvsBit = 0;
                                    execDeptId = EXEDEPT;//原药房
                                    return pvsBit;
                                }
                            }

                            pvsBit = 1;
                            execDeptId = pvsDept;//pivas药房
                            return pvsBit;
                        }
                    }
                }
                pvsBit = 0;
                execDeptId = EXEDEPT;//原药房
                return pvsBit;
            }
            catch (Exception ex)
            {
                throw new Exception("获取Pivas标志err：" + ex.Message);
            }
        }

        public bool IsCanPivas(string freq, string orderUsage, long deptBr, long execDeptid, out long pvsExecDept)
        {
            pvsExecDept = execDeptid;
            try
            {

                string ssql = string.Format(@"SELECT count(1) as num from VI_pivas_Freq where name='{0}'", freq);

                int iCnt = int.Parse(Convertor.IsNull(_database.GetDataResult(ssql), "0"));

                bool isPvsFreq = iCnt > 0;

                if (!isPvsFreq)
                    return false;

                ssql = string.Format(@"SELECT count(1) as num from VI_pivas_Orderusage where name='{0}'", orderUsage);

                iCnt = int.Parse(Convertor.IsNull(_database.GetDataResult(ssql), "0"));

                bool isPvsOrderUsage = iCnt > 0;

                if (!isPvsOrderUsage)
                    return false;

                ssql = string.Format(@"SELECT *  from JC_DEPT_DRUGSTORE where DEPT_ID={0} and is_pvsrel=1 and  DELETE_BIT=0 ", deptBr);

                DataTable dt = _database.GetDataTable(ssql);

                bool isPvsDept = false;

                if (dt == null || dt.Rows.Count <= 0)
                    return isPvsDept;

                isPvsDept = true;

                pvsExecDept = long.Parse(dt.Rows[0]["DRUGSTORE_ID"].ToString());//默认取第一行病人科室对应的pivas药房

                return isPvsDept;
            }
            catch
            {
                return false;
            }
        }

        private int cfBit = 0;//是否拆分

        public int SetCfBit()
        {
            cfBit = 0;
            try
            {
                if (pvsBit == 1)
                {
                    cfBit = 1;
                }
            }
            catch
            {
                return cfBit;
            }
            return cfBit;
        }

        #endregion

        #region"dept_br、dept_ly处理"

        /// <summary>
        /// 手术麻醉 更改dept_br(普通医嘱取的是vi_zy_beddiction里的dept_id)
        /// </summary>
        /// <returns></returns>
        public void SetDeptBr(long orderDeptBr)
        {
            try
            {
                //手术室录入医嘱：转科病人记账是否记在转科前的科室费用上 0=否，1=是
                if (_cfgList.cfg9010.Config.ToString().Trim().Equals("1"))
                {
                    if (BSsmzOrder)
                    {
                        //医嘱开单科室是手术麻醉,取该医嘱表的deptbr
                        DEPTBR = orderDeptBr;
                    }
                }
                //DEPTBR
            }
            catch (Exception ex)
            {
                throw new Exception("获取DeptBr时err：" + ex.Message);
            }
        }

        /// <summary>
        /// dept_ly处理
        /// </summary>
        /// <returns></returns>
        public void SetDeptLyInfo(string orderDeptid)
        {
            try
            {
                if (BSsmzOrder || ISKDKSLY == 1)
                {
                    //如果开单科室是手术麻醉，则把病区改成手术麻醉
                    string ssql = string.Format(@"SELECT WARD_ID FROM JC_WARDRDEPT WHERE DEPT_ID={0} ", orderDeptid);

                    DataTable dt = _database.GetDataTable(ssql);

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        throw new Exception("未找到开单科室：" + orderDeptid + " 对应的病区信息");
                    }

                    WARDID = dt.Rows[0]["WARD_ID"].ToString();//手麻开单科室领药  病区修改为手麻对应病区

                    ssql = string.Format(@"SELECT DEPT_ID FROM JC_WARD WHERE WARD_ID={0}", WARDID);

                    dt = _database.GetDataTable(ssql);

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        throw new Exception("未找到：" + WARDID + " 该病区对应科室信息");
                    }

                    DEPTLY = long.Parse(dt.Rows[0]["DEPT_ID"].ToString());
                }
                else
                {
                    //或者如果是领药科室领药
                    string ssql = string.Format(@"SELECT DEPT_ID FROM JC_WARD WHERE WARD_ID={0}", WARDID);

                    DataTable dt = _database.GetDataTable(ssql);

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        throw new Exception("未找到：" + WARDID + " 该病区对应科室信息");
                    }

                    DEPTLY = long.Parse(dt.Rows[0]["DEPT_ID"].ToString());

                    //如果该病人所在科室是单独领药，也需要独立出来
                    ssql = string.Format(@"SELECT count(1) as num FROM JC_DEPT_TYPE_RELATION WHERE DEPT_ID={0} AND TYPE_CODE='009'", DEPTBR);
                    int iCnt = int.Parse(Convertor.IsNull(_database.GetDataResult(ssql), "0"));
                    if (iCnt > 0)
                    {
                        DEPTLY = DEPTBR;
                    }
                }

                if (DEPTLY <= 0)
                {
                    if (ISKDKSLY == 1)
                    {
                        DEPTLY = DEPTID;
                    }
                    else
                    {
                        DEPTLY = DEPTBR;
                    }
                }

                //如果@ISKDKSLY=-1 有些特殊治疗科室不需要领药
                if (ISKDKSLY == -1)
                {
                    DEPTLY = -1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("获取DEPTLY时err：" + ex.Message);
            }
        }

        #endregion

        #region"预领药处理【@YLCS、@ISYL、@EXECTIME、@EXECDATE】"

        public int ISYL = 0;//是否预领
        public int YLCS = 0;//预领次数

        /// <summary>
        /// 预领药处理
        /// </summary>
        /// <returns></returns>
        public void SetYlyInfo(out int iExecDateAdd)
        {
            iExecDateAdd = 0;
            try
            {
                string lsyl = _cfgList.cfg7052.Config.ToString().Trim();

                if (lsyl.Equals("1"))
                {
                    //需要预领药
                    //循环开始前先看看是否需要预领药，如果需要，那么执行时间+1天
                    //如果是药品，并且是长嘱
                    if (XMLY == 1 && MNGTYPE == 0)
                    {
                        //长期药品医嘱才校验
                        GetYlInfo(HOITEMID, EXECTIME, out ISYL, out YLCS);
                    }
                }

                if (ISYL == 1)
                {
                    iExecDateAdd = 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("处理预领药时err：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="cjid">药品id</param>
        /// <param name="execTimes">执行次数</param>
        /// <param name="iIsYl"></param>
        /// <param name="iYlcs"></param>
        public void GetYlInfo(long cjid, string execTimes, out int iIsYl, out int iYlcs)
        {
            iIsYl = 0;
            iYlcs = 0;
            try
            {
                string ypTlfl = GetYpTlfl(cjid);

                string kfylConfif = _cfgList.cfg7048.Config.ToString().Trim();
                bool isKf = kfylConfif.Contains(ypTlfl);

                if ((!string.IsNullOrEmpty(kfylConfif)) && isKf)
                {
                    string kfylTime = _cfgList.cfg7049.Config.ToString().Trim();
                    GetYlInfo(execTimes, kfylTime, out  iIsYl, out  iYlcs);
                }
                else
                {
                    string zsyYlConfif = _cfgList.cfg7050.Config.ToString().Trim();
                    bool isZsy = zsyYlConfif.Contains(ypTlfl);

                    if ((!string.IsNullOrEmpty(zsyYlConfif)) && isZsy)
                    {
                        string zsyYlTime = _cfgList.cfg7051.Config.ToString().Trim();
                        GetYlInfo(execTimes, zsyYlTime, out  iIsYl, out  iYlcs);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取预领药信息时err：" + ex.Message);
            }
            //SET @TLFL = (SELECT LTRIM(RTRIM(ISNULL(TLFL,'00'))) FROM VI_YP_YPCD A WHERE A.CJID=@HOITEMID)
            //SET @KFCS = (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7048) --口服参数
        }

        private void GetYlInfo(string execTimes, string ylTimes, out int iIsYl, out int iYlcs)
        {
            iIsYl = 0;
            iYlcs = 0;
            try
            {
                string thisTimes = "";
                if (!string.IsNullOrEmpty(execTimes))
                {
                    string varSplit = @"/";
                    if (execTimes.Contains(varSplit))
                    {
                        char charSplit = varSplit.ToCharArray()[0];
                        string[] times = execTimes.Split(charSplit);

                        for (int i = 0; i < times.Length; i++)
                        {
                            thisTimes = times[i];
                            if (thisTimes.Equals("24:00"))
                            {
                                thisTimes = "23:59";
                            }

                            DateTime ylDate = Convert.ToDateTime(ylTimes);
                            DateTime thisDate = Convert.ToDateTime(thisTimes);

                            if (ylDate >= thisDate)
                            {
                                iIsYl = 1;
                                iYlcs++;
                            }
                        }
                    }
                    else
                    {
                        thisTimes = execTimes;
                        if (thisTimes.Equals("24:00"))
                        {
                            thisTimes = "23:59";
                        }

                        DateTime ylDate = Convert.ToDateTime(ylTimes);
                        DateTime thisDate = Convert.ToDateTime(thisTimes);

                        if (ylDate >= thisDate)
                        {
                            iIsYl = 1;
                            iYlcs++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取预领药信息时err：" + ex.Message);
            }
        }

        private string GetYpTlfl(long cjid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT LTRIM(RTRIM(ISNULL(TLFL,'00'))) FROM VI_YP_YPCD A WHERE A.CJID={0}", cjid);

                string tlfl = Convertor.IsNull(_database.GetDataResult(ssql), "00");

                return tlfl;
            }
            catch
            {
                return "00";
            }
        }

        #endregion

        public void GetYpKcmxInfo(int dwlx, long cjid, int xmly, long ExecDept, out string unit, out decimal kcl, out decimal xnkcl)
        {
            unit = "";
            kcl = 0;
            string ssql = "";
            try
            {
                if (xmly != 1)
                    throw new Exception("非药品没有库存信息");

                if (dwlx == 1)
                {
                    //hldw
                    ssql = string.Format(@"SELECT B.DWMC,A.KCL,A.xnKCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.HLDW=B.ID WHERE CJID={0} AND DEPTID={1} ", cjid, ExecDept);

                }
                else if (dwlx == 2)
                {
                    //bzdw
                    ssql = string.Format(@"SELECT B.DWMC,A.KCL,A.xnKCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.BZDW=B.ID WHERE CJID={0} AND DEPTID={1} ", cjid, ExecDept);
                }
                else if (dwlx == 3)
                {
                    //ykdw
                    ssql = string.Format(@"SELECT B.DWMC,A.KCL,A.xnKCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.YPDW=B.ID WHERE CJID={0} AND DEPTID={1} ", cjid, ExecDept);
                }
                else if (dwlx == 4)
                {
                    //yfdw 
                    ssql = string.Format(@"SELECT B.DWMC,A.KCL,A.xnKCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.ZXDW=B.ID WHERE CJID={0} AND DEPTID={1} ", cjid, ExecDept);
                }

                DataTable dt = _database.GetDataTable(ssql);

                if (dt == null || dt.Rows.Count <= 0)
                {
                    //没有库存信息
                    //throw new Exception("\r\n获取药品库存信息出错：" + cjid + " 药房：" + ExecDept + " 单位类型：" + dwlx);
                    unit = "";
                    kcl = 0;
                    xnkcl = 0;
                    return;
                }

                unit = dt.Rows[0]["DWMC"].ToString();
                kcl = decimal.Parse(dt.Rows[0]["KCL"].ToString());
                xnkcl = decimal.Parse(Convertor.IsNull(dt.Rows[0]["xnKCL"], "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取频次
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable GetFreqByFreqName(DataTable dtFreq)
        {
            try
            {
                string fil = string.Format(@"NAME='{0}'", FREQUENCY.ToString().Trim());
                DataRow[] drs = dtFreq.Select(fil);

                DataTable dt = dtFreq.Clone();

                for (int i = 0; i < drs.Length; i++)
                {
                    dt.Rows.Add(drs[i].ItemArray);
                }

                dt.AcceptChanges();

                if (dt == null || dt.Rows.Count <= 0)
                    throw new Exception(FREQUENCY + " 该医嘱频率在基础表中不存在");

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetExecNums(DateTime execNow, DateTime execEnd)
        {
            try
            {
                int iExecNum = EXECNUM;//默认为医嘱执行次数
                if (MNGTYPE == 0 || MNGTYPE == 2)
                {
                    //长期医嘱频次处理
                    if (STATUS_FLAG == 4)
                    {
                        if (!STOPEXEDATE.HasValue)
                        {
                            throw new Exception(_orderList[0].ORDER_CONTEXT + " 已经停嘱了,没有停嘱时间,请联系管理员！");
                        }
                    }

                    //执行次数获取顺序：
                    //1：先判断末次，如果当天开当天停判断末次
                    //2：首次判断
                    //3：预执行逻辑
                    if (STOPEXEDATE.HasValue && execNow.Date == STOPEXEDATE.Value.Date && STATUS_FLAG == 4)
                    {
                        if (LASTEXECDATE.HasValue && LASTEXECDATE.Value == STOPEXEDATE.Value)
                        {
                            iExecNum = TERMINALTIMES.Value - execNumEver;//本次执行末次=医嘱末次-从前预执行次数
                        }
                        else
                        {
                            iExecNum = TERMINALTIMES.Value;
                        }

                        if (iExecNum < 0)
                        {
                            iExecNum = 0;
                        }
                    }
                    else if (execNow.Date == BEGINEXEDATE.Date)
                    {
                        iExecNum = FRISTTIMES.Value;
                    }
                    else if (ISYL == 1)
                    {
                        //如果需要预执行
                        bool isExec = LASTEXECDATE.HasValue;

                        //上次执行日期等于当前日期 ,且不等于循环最后一天 本来执行次数-上次执行的次数
                        if (isExec && execNow.Date == LASTEXECDATE.Value.Date && execNow.Date != execEnd.Date)
                        {
                            iExecNum = EXECNUM - execNumEver;//本次执行末次=医嘱末次-从前预执行次数
                        }
                        else
                        {
                            //执行到最后一天，需判断预领药
                            if (execNow.Date == execEnd.Date)
                            {
                                if (isExec && execNow.Date == LASTEXECDATE.Value.Date && execNumEver > 0)
                                {
                                    iExecNum = 0;//已存在执行记录   不预领
                                }
                                else
                                {
                                    iExecNum = YLCS;//预领
                                }
                            }
                            else
                            {
                                iExecNum = EXECNUM;//非最后一次，总执行次数为：频率次数
                            }
                        }
                    }
                    else if (STOPEXEDATE.HasValue && STOPEXEDATE.Value.Date > STOPEXEDATE.Value.Date && STATUS_FLAG == 4)
                    {
                        iExecNum = 0;//？？？抄的过程里面的
                    }



                    //--判断是否跳过执行放在这里
                    //--Modify By Tany 2015-04-22 长嘱和长期账单的参数分开
                    //IF ((SELECT CONFIG FROM JC_CONFIG WHERE ID=7070)='1' AND @MNGTYPE=0)
                    //    OR ((SELECT CONFIG FROM JC_CONFIG WHERE ID=7804)='1' AND @MNGTYPE=2)
                    //BEGIN
                    //    --如果当天小于应当执行的日期并且小于今天，那么当天执行等于无效
                    //    IF CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))<CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE))
                    //        AND CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))<CONVERT(DATETIME,DBO.FUN_GETDATE(GETDATE()))
                    //    BEGIN
                    //        SET @EXENUM=0
                    //    END
                    //END

                    if ((MNGTYPE == 0 && _cfgList.cfg7070.Config.ToString().Equals("1"))
                        || (MNGTYPE == 2 && _cfgList.cfg7804.Config.ToString().Equals("1")))
                    {
                        DateTime now = DateManager.ServerDateTimeByDBType(_database);

                        if (execNow.Date < EXECDATE.Date && execNow.Date < now.Date)
                        {
                            iExecNum = 0;
                        }
                    }
                }

                if (CYCLELX == 1)
                {
                    //如果循环天数大于1并且上次有效执行过（也就是说第一次肯定是执行的）并且是长嘱
                    if (CYCLEDAY > 1 && LASTVALIDEXECDATE.HasValue && (MNGTYPE == 0 || MNGTYPE == 2))
                    {
                        DateTime valideExecDate = LASTVALIDEXECDATE.Value.Date;

                        TimeSpan tp1 = execNow.Date.Subtract(valideExecDate);
                        int iDiff = tp1.Days;

                        if (iDiff != CYCLEDAY)
                        {
                            iExecNum = 0;
                        }
                    }
                }
                else if (CYCLELX == 2 && (MNGTYPE == 0 || MNGTYPE == 2))
                {
                    //IF (CHARINDEX(CONVERT(VARCHAR,DATEPART(WEEKDAY,@CUREXECDATE)),CONVERT(VARCHAR,@ZXR))=0)
                    //BEGIN
                    //    SET @EXENUM=0
                    //END
                    DayOfWeek dw = execNow.DayOfWeek;

                    int iDw = (int)dw;//0：星期天 1：星期1 6：星期6  etc...
                    int thisDw = iDw + 1;//和基础数据维护的执行日不同  单日：1246  双日：357（需+1）

                    if (!ZXR.ToString().Contains(thisDw.ToString()))
                    {
                        iExecNum = 0;
                    }
                }

                return iExecNum;
            }
            catch (Exception ex)
            {
                throw new Exception("获取执行次数时时err：" + ex.Message);
            }
        }

        public string GetPrescNo()
        {
            try
            {
                string ssql = string.Format(@"select CONVERT(DECIMAL(21,6),CONVERT(VARCHAR,GETDATE(),112)+CONVERT(VARCHAR,DATEPART(HH,GETDATE()))+CONVERT(VARCHAR,DATEPART(MI,GETDATE()))+CONVERT(VARCHAR,DATEPART(SS,GETDATE()))+'.'+CONVERT(VARCHAR,DATEPART(MS,GETDATE())))");

                string ret = _database.GetDataResult(ssql).ToString();

                //decimal dRet = decimal.Parse(ret);

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("获取cfh时时err：" + ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// 循环执行医嘱前准备数据
        /// </summary>
        /// <returns>0：继续执行  1：return  2：nextday </returns>
        public int DoPrepareExecOrderFirst()
        {
            int iret = 0;
            try
            {
                //1：第一步校验医嘱是否能够执行
                iret = CanOrderExec();
                if (iret == 1 || iret == 2)
                {
                    //不要正常执行  跳出数据准备
                    return iret;
                }

                //2：第二步 处理当前执行时间CUREXECDATE、LASTEXECDATE、LASTVALIDEXECDATE
                SetCurrExecDate();

                //3：第三步 已停转抄并且执行时间小于停时间 处理执行时间EXECDATE
                SetExecDate();

                //4：第四步
                iret = CanOrderExecWhenStop();
                if (iret == 1 || iret == 2)
                {
                    //不要正常执行  跳出数据准备
                    return iret;
                }

                //5：第5步pivas处理
                int iErr = -1;
                string strMsg = "";
                pvsBit = SetPivasBit(out EXEDEPT, out iErr, out strMsg);
                if (iErr == -1)
                {
                    iret = 1;
                    return iret;
                }

                //6：第6步拆分处理
                cfBit = SetCfBit();


                //7：第7步dept_br处理
                OrderEntity order = _orderList[0];//执行科室从大到小处理（处理组中含有自备药）
                SetDeptBr(order.DEPT_BR);

                //8：第8步dept_ly处理
                SetDeptLyInfo(order.DEPT_ID.ToString().Trim());

                //9：第9步预领药处理
                int iAddExecDate = 0;
                SetYlyInfo(out iAddExecDate);
                if (iAddExecDate > 0)
                {
                    //预领药需要预执行处理EXECDATE
                    EXECDATE = EXECDATE.AddDays(iAddExecDate);
                }

                return iret;

            }
            catch (Exception ex)
            {
                //throw new Exception("循环执行医嘱前准备数据err：" + ex.Message);
                throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 循环执行医嘱前准备数据err：" + ex.Message);
            }
        }

        /// <summary>
        /// 执行调用
        /// </summary>
        /// <returns>医嘱是否能执行(0：继续  1：return  2：nextday完成处理)</returns>
        public void DoExcuteFee(int iOut, out int iret, out string strMsg)
        {
            iret = -1;
            strMsg = "";
            try
            {
                DateTime execStart = CUREXECDATE.Date;
                DateTime execEnd = EXECDATE.Date;

                //如果是临时性执行类
                if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                {
                    execEnd = CUREXECDATE.Date;//临时只执行当天
                }

                //如果长期医嘱停止
                if (MNGTYPE == 0 || MNGTYPE == 2)
                {
                    //已经停转抄
                    if (STOPEXEDATE.HasValue && STATUS_FLAG == 4)
                    {
                        if (execEnd.Date > STOPEXEDATE.Value.Date)
                        {
                            //执行时间>大于停日期
                            execEnd = STOPEXEDATE.Value.Date;//执行到停日期即可
                        }
                    }
                }

                TimeSpan tp = execEnd.Subtract(execStart);
                int iExecDays = tp.Days;

                int iExecNum = EXECNUM;//执行次数

                bool isAddFeeOrNextDay = true;//是产生正费用   或者  自动冲正  wait
                if (iExecDays < 0)
                {
                    //已执行时间>发送时间[执行一次冲正]
                    isAddFeeOrNextDay = false;
                    iExecDays = 0;
                }
                //正执行需要实体容器
                Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderLists
                    = new Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>>();//待执行记录
                List<OrderEntity> updateLastInfo = new List<OrderEntity>();
                List<XnKclEntity> xnKcLists = new List<XnKclEntity>();
                List<OrderPrescEntity> fjPrescLists = new List<OrderPrescEntity>();
                List<OrderFeeEntity> fjFeeLists = new List<OrderFeeEntity>();
                List<YjZySqEntity> yjsqLists = new List<YjZySqEntity>();
                List<YjZySqEntity> yjqrLists = new List<YjZySqEntity>();
                //转成list
                List<OrderExecEntity> ordExeLists = new List<OrderExecEntity>();
                List<OrderPrescEntity> ordPrescLists = new List<OrderPrescEntity>();
                List<OrderFeeEntity> ordFeeLists = new List<OrderFeeEntity>();

                //自动冲正需要实体容器
                List<OrderEntity> cz_updateOrderInfo = new List<OrderEntity>();
                List<OrderFeeEntity> cz_FeeLists = new List<OrderFeeEntity>();
                List<XnKclEntity> cz_xnKcLists = new List<XnKclEntity>();
                List<YjZySqEntity> cz_upDatetYjsqLists = new List<YjZySqEntity>();
                List<string> cz_updateFeeFlagLists = new List<string>();
                List<OrderFeeEntity> cz_delFeeLists = new List<OrderFeeEntity>();

                //注意天数（应该用<=）从execStart开始  执行到execEnd，天数：差集+1
                for (int i = 0; i <= iExecDays; i++)
                {
                    orderLists.Clear();
                    updateLastInfo.Clear();
                    xnKcLists.Clear();
                    fjPrescLists.Clear();
                    fjFeeLists.Clear();
                    yjsqLists.Clear();
                    yjqrLists.Clear();

                    ordExeLists.Clear();
                    ordPrescLists.Clear();
                    ordFeeLists.Clear();

                    cz_updateOrderInfo.Clear();
                    cz_FeeLists.Clear();
                    cz_xnKcLists.Clear();
                    cz_upDatetYjsqLists.Clear();
                    cz_updateFeeFlagLists.Clear();
                    cz_delFeeLists.Clear();

                    //执行准备参数：execNow/iExecNum
                    DateTime execNow = CUREXECDATE.AddDays(i);//本次执行日期
                    EXECBOOKDATE = DateManager.ServerDateTimeByDBType(_database);


                    if (isAddFeeOrNextDay)
                    {
                        //拼接实体
                        int iOutPut = DoExcuteAddFee(execNow, execEnd, iExecNum,
                            orderLists, updateLastInfo, xnKcLists,
                            fjPrescLists, fjFeeLists, yjsqLists,
                            yjqrLists, out  iret, out  strMsg);

                        if (iOutPut == 2)
                        {
                            //拼接实体
                            DoExcuteNextDay(execNow, cz_updateOrderInfo, cz_FeeLists, cz_xnKcLists, cz_upDatetYjsqLists, cz_updateFeeFlagLists, cz_delFeeLists, out iret, out strMsg);//NextDay 并且继续for循环
                        }
                        else if (iOutPut == 1)
                        {
                            return;//停止执行
                        }
                        else if (iOutPut == 0)
                        {
                            _orderExecList.Sort();
                            if (_orderExecList.Count > 0)
                            {
                                for (int iOrderExe = 0; iOrderExe < _orderExecList.Count; iOrderExe++)
                                {
                                    OrderExecEntity ordExe = _orderExecList[iOrderExe];
                                    int isAna = int.Parse(Convertor.IsNull(ordExe.ISANALYZED, "0"));

                                    DateTime thisExeDate = ordExe.EXECDATE;

                                    if (isAna > 0 && !LASTVALIDEXECDATE.HasValue)
                                    {
                                        LASTVALIDEXECDATE = ordExe.EXECDATE;//如果没有值，赋值当前执行时间
                                    }

                                    //if (isAna > 0)
                                    if (isAna > 0 && (LASTVALIDEXECDATE.HasValue && thisExeDate > LASTVALIDEXECDATE))
                                    {
                                        //NextDay之前 重赋值最大有效时间
                                        LASTVALIDEXECDATE = ordExe.EXECDATE;//LASTVALIDEXECDATE处理//最大执行日期倒叙取有效执行次数>0的记录
                                    }
                                }
                            }

                            //拼接实体
                            DoExcuteNextDay(execNow, cz_updateOrderInfo, cz_FeeLists, cz_xnKcLists, cz_upDatetYjsqLists, cz_updateFeeFlagLists, cz_delFeeLists, out iret, out strMsg);//NextDay 并且继续for循环
                        }
                    }
                    else
                    {
                        //拼接实体
                        DoExcuteNextDay(execNow, cz_updateOrderInfo, cz_FeeLists, cz_xnKcLists, cz_upDatetYjsqLists, cz_updateFeeFlagLists, cz_delFeeLists, out iret, out strMsg);//NextDay 并且继续for循环
                    }

                    if (orderLists.Count > 0)
                    {
                        //GetExecEntity(orderLists, out ordExeLists, out ordPrescLists, out ordFeeLists);
                        GetExecEntity(execNow, orderLists, out ordExeLists, out ordPrescLists, out ordFeeLists);//校验双倍医嘱版本
                    }

                    ////执行事务之前在查询一次execNow是否存在执行记录，不存在则insert[作废：有预领药和冲正及完成]
                    //string strSql = string.Format(@"select count(1) as Num from  ZY_ORDEREXEC where  ORDER_ID='{0}' and  CONVERT(DATETIME,DBO.FUN_GETDATE(EXECDATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}'))", ORDERID.ToString(), execNow);

                    //int iCnt = int.Parse(Convertor.IsNull(_database.GetDataResult(strSql), "0"));

                    //if (iCnt <= 0)
                    //{
                    //开始业务（事务执行）wait
                    ExecCommit(ordExeLists, ordPrescLists, ordFeeLists,
                        updateLastInfo, xnKcLists,
                        fjPrescLists, fjFeeLists,
                        yjsqLists, yjqrLists,
                        cz_FeeLists, cz_xnKcLists,
                        cz_upDatetYjsqLists,
                        cz_updateFeeFlagLists, cz_delFeeLists,
                        cz_updateOrderInfo,
                        out iret, out strMsg);
                    //}
                }

                iret = 0;
                strMsg = "";
            }
            catch (Exception ex)
            {
                throw new Exception("执行医嘱时err：" + ex.Message);
            }
        }

        /// <summary>
        /// 事务执行
        /// </summary>
        /// <returns>医嘱是否能执行(0：继续  1：return  2：nextday完成处理)</returns>
        public int ExecCommit(
            //执行用
            List<OrderExecEntity> ordExeLists, List<OrderPrescEntity> ordPrescLists, List<OrderFeeEntity> ordFeeLists,
            List<OrderEntity> updateLastInfo, List<XnKclEntity> xnKcLists,
            List<OrderPrescEntity> fjPrescLists, List<OrderFeeEntity> fjFeeLists,
            List<YjZySqEntity> yjsqLists, List<YjZySqEntity> yjqrLists,
            //冲正完成用
            List<OrderFeeEntity> cz_FeeLists, List<XnKclEntity> cz_xnKcLists,
            List<YjZySqEntity> cz_upDatetYjsqLists,
            List<string> cz_updateFeeFlagLists, List<OrderFeeEntity> cz_delFeeLists,
            List<OrderEntity> cz_updateOrderInfo,//完成用
            out int iret, out string strMsg)
        {
            iret = 0;
            strMsg = "";
            int iOutPut = -1;

            if (ordExeLists.Count <= 0 && updateLastInfo.Count <= 0 && cz_FeeLists.Count <= 0 && cz_updateOrderInfo.Count <= 0)
            {
                iret = 0;
                strMsg = "";
                iOutPut = 0;
                return iOutPut;
            }

            bool CanExecFee = true;//是否执行正记录
            if (ordExeLists.Count <= 0)
            {
                //频次校验未通过
                CanExecFee = false;
            }

            _database.BeginTransaction();
            try
            {
                string ssql = "";

                if (CanExecFee && ordExeLists.Count > 0)
                {
                    foreach (OrderExecEntity ettOrdExe in ordExeLists)
                    {
                        ssql = ettOrdExe.AddExecInfo();

                        iret = _database.DoCommand(ssql);
                        if (iret <= 0)
                        {
                            throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 插入医嘱执行表没有数据，请检查！");
                        }
                    }
                }
                if (CanExecFee && updateLastInfo.Count > 0)
                {
                    foreach (OrderEntity ettOrd in updateLastInfo)
                    {
                        ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET LASTEXECDATE='{0}',LASTEXECUSER='{1}' 
                                           WHERE INPATIENT_ID='{2}' AND BABY_ID='{3}' AND GROUP_ID='{4}' 
                                            AND (MNGTYPE='{5}' OR MNGTYPE='{6}') AND DELETE_BIT=0 ",
                                            ettOrd.LASTEXECDATE, ettOrd.LASTEXECUSER,
                                            _Binid, _Babyid, _Groupid,
                                            MNGTYPE, MNGTYPE2);

                        iret = _database.DoCommand(ssql);
                    }
                }
                if (CanExecFee && xnKcLists.Count > 0)
                {
                    if (XMLY == 1)
                    {
                        foreach (XnKclEntity ettXnKcl in xnKcLists)
                        {
                            string TMP_CJID = ettXnKcl.cjid;
                            string ypsl = ettXnKcl.num;
                            string TMED_DWLX = ettXnKcl.dwbl;
                            string TMED_EXEC_DEPT = ettXnKcl.execDeptId;

                            UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//失败不回滚
                        }
                    }
                }
                if (CanExecFee && ordPrescLists.Count > 0)
                {

                    foreach (OrderPrescEntity ettOrdPresc in ordPrescLists)
                    {
                        ssql = ettOrdPresc.AddPrescInfo(XMLY);

                        iret = _database.DoCommand(ssql);
                        if (iret <= 0)
                        {
                            throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 插入处方表药品信息没有数据，请检查！");
                        }
                    }
                }
                if (CanExecFee && ordFeeLists.Count > 0)
                {
                    foreach (OrderFeeEntity ettOrdFee in ordFeeLists)
                    {
                        int iType = 0;
                        ssql = ettOrdFee.AddFeeInfo(XMLY, iType);

                        iret = _database.DoCommand(ssql);
                        if (iret <= 0)
                        {
                            throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 插入费用表" + (XMLY == 1 ? "药品" : "项目") + "信息出错！");
                        }
                    }
                }
                if (CanExecFee && yjsqLists.Count > 0)
                {
                    foreach (YjZySqEntity ettYjSq in yjsqLists)
                    {
                        ssql = string.Format(@"INSERT INTO YJ_ZYSQ 
			                                    ( 
				                                    YJSQID, JGBM, BRXXID, INPATIENT_ID, 
				                                    SQRQ, SQR, SQKS, SQNR, 
				                                    JE, LCZD, ZXKS, BSJC, 
				                                    BBMC, ZYSX, BJJBZ, YZID, YZXMID,
				                                    ZXR, ZXSJ, ZXID, DJLX
			                                    )
                                            values('{0}','{1}','{2}','{3}',
                                                    '{4}','{5}','{6}','{7}',
                                                    '{8}','{9}','{10}','{11}',
                                                    '{12}','{13}','{14}','{15}','{16}',
                                                    '{17}','{18}','{19}','{20}'
                                                    )",
                                                   ettYjSq.YJSQID, ettYjSq.JGBM, ettYjSq.BRXXID, ettYjSq.INPATIENT_ID,
                                                   ettYjSq.SQRQ, ettYjSq.SQR, ettYjSq.SQKS, ettYjSq.SQNR,
                                                   ettYjSq.JE, ettYjSq.LCZD, ettYjSq.ZXKS, ettYjSq.BSJC,
                                                   ettYjSq.BBMC, ettYjSq.ZYSX, ettYjSq.BJJBZ, ettYjSq.YZID, ettYjSq.YZXMID,
                                                   ettYjSq.ZXR, ettYjSq.ZXSJ, ettYjSq.ZXID, ettYjSq.DJLX);

                        iret = _database.DoCommand(ssql);
                        if (iret <= 0)
                        {
                            throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 插入医技申请表没有数据，请检查！");
                        }
                    }
                }
                if (CanExecFee && yjqrLists.Count > 0)
                {
                    foreach (YjZySqEntity ettYjqr in yjsqLists)
                    {
                        Guid YJ_EXEC_ID = ettYjqr.ZXID;
                        Guid YJ_APP_ID = ettYjqr.YJSQID;
                        Guid YJ_ORDER_ID = ettYjqr.YZID;
                        decimal YJ_JE = ettYjqr.JE;

                        Guid NEWYJSQID = Guid.Empty;
                        int iSqRet = -1;
                        string strSqMsg = "";

                        string qrsj = EXECBOOKDATE.ToString("yyyy-MM-dd HH:mm:ss");
                        int iDept = Convert.ToInt32(DEPTID);
                        int iExeUser = Convert.ToInt32(EXEUSER);

                        yj_zysq_qrjl(YJ_ORDER_ID, YJ_EXEC_ID, YJ_APP_ID, YJ_JE, iDept, qrsj, iExeUser, 1, qrsj, 0, "", out NEWYJSQID, out iSqRet, out strSqMsg, 0);
                        if (iSqRet != 0)
                        {
                            throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 医技确费出错" + strSqMsg);
                        }
                    }
                }
                ////wait
                //if (CanExecFee && fjPrescLists.Count > 0)
                //{
                //}
                //if (CanExecFee && fjFeeLists.Count > 0)
                //{
                //}

                //自动冲正
                if (cz_FeeLists.Count > 0)
                {
                    foreach (OrderFeeEntity ettOrdFee in cz_FeeLists)
                    {
                        int iType = 1;
                        ssql = ettOrdFee.AddFeeInfo(XMLY, iType);

                        iret = _database.DoCommand(ssql);
                    }
                }
                if (cz_upDatetYjsqLists.Count > 0)
                {
                    foreach (YjZySqEntity ettYjqr in cz_upDatetYjsqLists)
                    {
                        ssql = string.Format(@"update yj_zysq set btfbz=1,tfje=TFJE-{2} where yzid='{0}' and zxid='{1}'", ettYjqr.YZID, ettYjqr.ZXID, ettYjqr.TFJE);

                        iret = _database.DoCommand(ssql);
                    }
                }
                if (cz_xnKcLists.Count > 0)
                {
                    if (XMLY == 1)
                    {
                        foreach (XnKclEntity ettXnKcl in cz_xnKcLists)
                        {
                            string TMP_CJID = ettXnKcl.cjid;
                            string ypsl = ettXnKcl.num;
                            string TMED_DWLX = ettXnKcl.dwbl;
                            string TMED_EXEC_DEPT = ettXnKcl.execDeptId;

                            UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//失败不回滚
                        }
                    }
                }
                if (cz_updateFeeFlagLists.Count > 0)
                {
                    foreach (string feeid in cz_updateFeeFlagLists)
                    {
                        ssql = string.Format(@"UPDATE ZY_FEE_SPECI SET CZ_FLAG=1 WHERE ID='{0}'", feeid);

                        iret = _database.DoCommand(ssql);
                    }
                }

                if (cz_delFeeLists.Count > 0)
                {
                    foreach (OrderFeeEntity ettOrdFee in cz_delFeeLists)
                    {
                        ssql = string.Format(@"UPDATE ZY_FEE_SPECI SET DELETE_BIT=1,BZ=ISNULL(BZ,'')+'自动冲账删除' WHERE FY_BIT=0 AND SCBZ=0 AND (ID='{0}' OR CZ_ID='{0}')  ", ettOrdFee.ID);

                        iret = _database.DoCommand(ssql);
                    }
                }

                //完成
                if (cz_updateOrderInfo.Count > 0)
                {
                    foreach (OrderEntity ettOrd in cz_updateOrderInfo)
                    {
                        if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                        {

                            ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET STATUS_FLAG='{0}',ORDER_EDATE='{1}'
                                                WHERE INPATIENT_ID='{2}' AND BABY_ID='{3}' AND GROUP_ID='{4}' AND STATUS_FLAG =2 AND DELETE_BIT=0 
                                                    AND ((MNGTYPE='{5}' OR MNGTYPE='{6}') or ({5} in (1,5) and MNGTYPE in (1,5))) ",
                                                    5, ettOrd.ORDER_EDATE.Value, _Binid, _Babyid, _Groupid, MNGTYPE, MNGTYPE2
                                                 );
                        }

                        if (MNGTYPE == 0 || MNGTYPE == 2)
                        {
                            if (NTYPE == 0)
                            {
                                if (ettOrd.ORDER_EDATE.HasValue)
                                {
                                    ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET STATUS_FLAG=5,ORDER_EDATE='{0}',ORDER_EDOC='{1}',LASTEXECDATE=GETDATE()
                                                        WHERE INPATIENT_ID='{2}' AND BABY_ID='{3}' AND GROUP_ID='{4}' 
                                                        AND (MNGTYPE=0 OR MNGTYPE=2) AND NTYPE = 0 ",
                                                            ettOrd.ORDER_EDATE.Value, ettOrd.ORDER_EDOC.Value, _Binid, _Babyid, _Groupid
                                                         );
                                }
                                else
                                {
                                    ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET STATUS_FLAG=5,ORDER_EDATE=null,ORDER_EDOC=null 
                                                         WHERE INPATIENT_ID='{0}' AND BABY_ID='{1}' AND GROUP_ID='{2}' 
                                                         AND (MNGTYPE=0 OR MNGTYPE=2) AND NTYPE = 0 ",
                                                         _Binid, _Babyid, _Groupid
                                                         );
                                }
                            }
                            else
                            {
                                ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET STATUS_FLAG='{0}',LASTEXECDATE='{1}'
                                                        WHERE INPATIENT_ID='{2}' AND BABY_ID='{3}' AND GROUP_ID='{4}' 
                                                        AND (STATUS_FLAG=4 OR (STATUS_FLAG=2 AND NTYPE=0)) AND (MNGTYPE=0 OR MNGTYPE=2) ",
                                                        5, ettOrd.LASTEXECDATE.Value, _Binid, _Babyid, _Groupid
                                                     );
                            }
                        }

                        iret = _database.DoCommand(ssql);
                    }
                }

                _database.CommitTransaction();

                iret = 0;
                strMsg = "";
                iOutPut = 0;
            }
            catch (Exception ex)
            {
                _database.RollbackTransaction();
                throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 组号：" + _Groupid + " 事务执行医嘱时err：" + ex.Message);

                //iOutPut = 1;//return
                //iret = -1;
                //return iOutPut;
            }
            return iOutPut;
        }

        /// <summary>
        /// 日执行费用
        /// </summary>
        /// <param name="execNow"></param>
        /// <param name="iret"></param>
        /// <param name="strMsg"></param>
        /// <returns>医嘱是否能执行(0：继续  1：return  2：nextday完成处理)</returns>
        public int DoExcuteAddFee(DateTime execNow, DateTime execEnd, int iExecNum,
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderLists,
             List<OrderEntity> updateLastInfo, List<XnKclEntity> xnKcLists,
            List<OrderPrescEntity> fjPrescLists, List<OrderFeeEntity> fjFeeLists,
            List<YjZySqEntity> yjsqLists, List<YjZySqEntity> yjqrLists, out int iret, out string strMsg)
        {
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderInfo
                = new Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>>();

            iret = 0;
            strMsg = "";
            int iOutPut = 0;
            try
            {
                //开始执行时间和停止时间的判断
                if (execNow.Date < BEGINEXEDATE.Date)
                {
                    //Goto NextDay 
                    iOutPut = 2;
                    return iOutPut;
                }

                //ExecNum
                iExecNum = GetExecNums(execNow, execEnd);//真正本日执行次数【注意】

                string dCfh = GetPrescNo();

                #region"1：插入执行表  2:回填set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER"

                //1：插入执行表
                foreach (OrderEntity ettOrd in _orderList)
                {
                    int iCfExecCnt = iExecNum;
                    bool bCf = false;
                    if (cfBit == 1 && XMLY == 1 && iExecNum > 0)
                    {
                        //需要拆分
                        iCfExecCnt = 1;
                        bCf = true;
                    }

                    Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo
                        = new Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>();

                    while (iCfExecCnt <= iExecNum)
                    {
                        OrderExecEntity ettOrdExec = new OrderExecEntity();

                        /*
                         * 
                        INSERT INTO #ZY_ORDEREXEC (ID,BOOK_DATE,ORDER_ID,EXEUSER,EXECDATE,ISANALYZED,PRESCRIPTION_ID,INPATIENT_ID,BABY_ID,JGBM,pvs_xh)--Modify by jchl （频率拆分序号逻辑加入）
                        SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@EXECBOOKDATE, ORDER_ID,@EXEUSER,@CUREXECDATE,(case when @cfbz=1 and @XMLY=1 and @EXENUM>0 then 1 else @EXENUM end),@CFH,@INPATIENTID,@BABYID,@JGBM,(case when @cfbz=1 and @XMLY=1 and @EXENUM>0 then @cfcs else -1 end)  --Modify by jchl （频率拆分序号逻辑加入）
                         */

                        ettOrdExec.ID = PubStaticFun.NewGuid();
                        ettOrdExec.BOOK_DATE = EXECBOOKDATE;
                        ettOrdExec.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdExec.EXEUSER = EXEUSER;
                        ettOrdExec.EXECDATE = execNow;

                        ettOrdExec.ISANALYZED = bCf ? 1 : iExecNum;
                        ettOrdExec.PRESCRIPTION_ID = dCfh;
                        ettOrdExec.INPATIENT_ID = _Binid;
                        ettOrdExec.BABY_ID = _Babyid;
                        ettOrdExec.JGBM = _JGBM;

                        ettOrdExec.PVS_XH = bCf ? iCfExecCnt : -1;

                        //1：插入执行表
                        execListsInfo.Add(ettOrdExec, new Dictionary<OrderPrescEntity, List<OrderFeeEntity>>());//待插入执行表：事务
                        _orderExecList.Add(ettOrdExec);//插入中间表

                        ettOrd.LASTEXECDATE = execNow;//待插入执行表：事务
                        ettOrd.LASTEXECUSER = EXEUSER;//待插入执行表：事务

                        iCfExecCnt++;
                    }

                    orderInfo.Add(ettOrd, execListsInfo);
                }

                #endregion

                //wait
                //2:回填set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER
                OrderEntity updateLastOrder = new OrderEntity();
                updateLastOrder.LASTEXECDATE = execNow;
                updateLastOrder.LASTEXECUSER = EXEUSER;
                updateLastInfo.Add(updateLastOrder);

                //如果是大于停止时间或在执行的周期之间，则只写ZY_ORDEREXEC，但次数为空。
                if (iExecNum == 0)
                {
                    //如果是大于停止时间或在执行的周期之间，则只写ZY_ORDEREXEC，但次数为空。

                    foreach (KeyValuePair<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> kvOrdList in orderInfo)
                    {
                        OrderEntity ettOrd = kvOrdList.Key;

                        Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo = kvOrdList.Value;

                        orderLists.Add(ettOrd, execListsInfo);
                    }

                    // goto next 
                    iOutPut = 2;
                    return iOutPut;
                }

                #region"插入处方表、费用表etc"

                foreach (KeyValuePair<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> kvOrdList in orderInfo)
                {
                    OrderEntity ettOrd = kvOrdList.Key;

                    Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo = kvOrdList.Value;

                    Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execLists
                        = new Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>();

                    orderLists.Add(ettOrd, execLists);

                    foreach (KeyValuePair<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> kvOrdExecList in execListsInfo)
                    //foreach (OrderExecEntity ettOrdExec in execLists)
                    {
                        OrderExecEntity ettOrdExec = kvOrdExecList.Key;
                        Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescListsInfo = kvOrdExecList.Value;

                        Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescLists = new Dictionary<OrderPrescEntity, List<OrderFeeEntity>>();
                        //执行对应处方
                        execLists.Add(ettOrdExec, prescLists);

                        #region"药品处方表处理ZY_PRESCRIPTION"

                        string TMED_ID = "";
                        string TMED_ORDER_ID = "";
                        string TMED_DEPT_ID = "";
                        string TMED_DEPT_BR = "";
                        string TMED_EXEC_DEPT = "";
                        string TMED_ORDER_DOC = "";
                        string TMED_NUM = "";
                        string TMED_HOITEM_ID = "";
                        string TMED_ITEM_CODE = "";
                        string TMED_XMLY = "";
                        string TMED_DWLX = "";
                        string ORDERUNIT = "";
                        string TMED_ORDER_SPEC = "";
                        string TMED_DOSAGE = "";
                        string TMED_MNGTYPE = "";
                        string TMED_JZ_FLAG = "";
                        string TMED_ORDER_CONTEXT = "";
                        string TMED_NTYPE = "";
                        string TMED_STATCODE = "";
                        string TEMD_TLFL = "";

                        //--|已时间戳为索引，遍厉医嘱执行表，得到要插入的处方表的记录
                        //--|药需要循环算数量和价格 MODIFY BY TANY 2005-09-11
                        //IF @NTYPE<=3 AND @NTYPE<>0 AND @XMLY=1 AND @HOITEMID>0
                        if (NTYPE <= 3 && NTYPE > 0 && XMLY == 1 && HOITEMID > 0)
                        {

                            //不处理自备药
                            if (ettOrd.HOITEM_ID <= 0 || ettOrd.EXEC_DEPT <= 0)
                                continue;

                            TMED_ID = ettOrdExec.ID.ToString();
                            TMED_ORDER_ID = ettOrd.ORDER_ID.ToString();
                            TMED_DEPT_ID = ettOrd.DEPT_ID.ToString();
                            TMED_DEPT_BR = ettOrd.DEPT_BR.ToString();
                            TMED_EXEC_DEPT = ettOrd.EXEC_DEPT.ToString();
                            if (pvsBit == 1)
                            {
                                //pvs处理
                                TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                                int iDiff2 = tm2.Days;
                                if (iDiff2 >= 1)
                                {
                                    //pivas第一天药不配置（wait to封装）
                                    TMED_EXEC_DEPT = EXEDEPT.ToString();
                                }
                            }
                            TMED_ORDER_DOC = ettOrd.ORDER_DOC.ToString();
                            TMED_NUM = ettOrd.NUM.ToString();
                            if (MNGTYPE == 1 || MNGTYPE == 5)
                            {
                                TMED_NUM = Convertor.IsNull(ettOrd.zsl, "-1").Equals("-1") ? ettOrd.NUM.ToString() : ettOrd.zsl.ToString();
                            }
                            TMED_HOITEM_ID = ettOrd.HOITEM_ID.ToString();
                            TMED_ITEM_CODE = ettOrd.ITEM_CODE.ToString();
                            TMED_XMLY = ettOrd.XMLY.ToString();
                            TMED_DWLX = ettOrd.DWLX.ToString();
                            ORDERUNIT = ettOrd.UNIT;
                            if (MNGTYPE == 1 || MNGTYPE == 5)
                            {
                                ORDERUNIT = string.IsNullOrEmpty(Convertor.IsNull(ettOrd.zsldw, "")) ? ettOrd.UNIT : ettOrd.zsldw;
                            }

                            TMED_ORDER_SPEC = ettOrd.ORDER_SPEC.ToString();
                            TMED_DOSAGE = ettOrd.DOSAGE.ToString();
                            TMED_MNGTYPE = ettOrd.MNGTYPE.ToString();
                            TMED_JZ_FLAG = ettOrd.JZ_FLAG.ToString();
                            TMED_ORDER_CONTEXT = ettOrd.ORDER_CONTEXT.ToString();
                            TMED_NTYPE = ettOrd.NTYPE.ToString();

                            if (ettOrd.XMLY == 1)
                            {
                                DataTable dtYp = GetYpInfo(ettOrd.HOITEM_ID);

                                if (dtYp == null || dtYp.Rows.Count <= 0)
                                {
                                    throw new Exception(ettOrd.HOITEM_ID + " 药品厂家典中未找到该药品信息");
                                }

                                TMED_STATCODE = dtYp.Rows[0]["STATITEM_CODE"].ToString();
                                TEMD_TLFL = dtYp.Rows[0]["TLFL"].ToString();
                            }

                            string unit = "";
                            decimal kcl = 0;
                            decimal xnKcl = 0;
                            long thisExecDept = long.Parse(TMED_EXEC_DEPT);
                            //获取pivas库存信息
                            GetYpKcmxInfo(ettOrd.DWLX, ettOrd.HOITEM_ID, ettOrd.XMLY, thisExecDept, out unit, out kcl, out xnKcl);

                            if (string.IsNullOrEmpty(unit))
                            {
                                iOutPut = 1;//return
                                iret = -1;
                                strMsg = BED_NO + " 床病人 " + PAT_NAME + " 该种药品:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")在【" + TMED_EXEC_DEPT + "】没有找到库存信息，请重新开立医嘱！";
                                return iOutPut;
                            }

                            string thisOrderUnit = "";
                            if (MNGTYPE == 1 || MNGTYPE == 5)
                            {
                                thisOrderUnit = string.IsNullOrEmpty(Convertor.IsNull(ettOrd.zsldw, "")) ? ettOrd.UNIT : ettOrd.zsldw;
                            }
                            else
                            {
                                thisOrderUnit = ettOrd.UNIT;
                            }

                            if (unit.Trim().ToUpper() != thisOrderUnit.Trim().ToUpper())
                            {
                                iOutPut = 1;//return
                                iret = -1;
                                strMsg = BED_NO + " 床病人 " + PAT_NAME + " 该种药品:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")的单位(" + unit + ")与医嘱的单位(" + ettOrd.UNIT + ")不同，请重新开立医嘱！";
                                return iOutPut;
                            }

                            decimal _num = decimal.Parse(TMED_NUM);
                            int _cjid = int.Parse(TMED_HOITEM_ID);
                            int _execDeptid = int.Parse(TMED_EXEC_DEPT);

                            DataTable dtYpDw = GetYpkcmxInfo(ettOrd.DWLX, _num, _cjid, _execDeptid);

                            if (dtYpDw == null || dtYpDw.Rows.Count <= 0)
                            {
                                throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 该种药品:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + "药品计算信息出错");
                            }

                            string TMP_GGID = dtYpDw.Rows[0]["GGID"].ToString();
                            string TMP_CJID = dtYpDw.Rows[0]["CJID"].ToString();
                            string TMP_YL = dtYpDw.Rows[0]["YL"].ToString();
                            string TMP_UNIT = dtYpDw.Rows[0]["UNIT"].ToString();
                            string TMP_PRICE = dtYpDw.Rows[0]["PRICE"].ToString();
                            string TMP_SDVALUE = dtYpDw.Rows[0]["SDVALUE"].ToString();
                            string TMP_YDWBL = dtYpDw.Rows[0]["YDWBL"].ToString();
                            string TMP_ZXKSID = dtYpDw.Rows[0]["ZXKSID"].ToString();
                            string TMP_BDELETE = dtYpDw.Rows[0]["BDELETE"].ToString();
                            string TMP_KCL = Convertor.IsNull(dtYpDw.Rows[0]["KCL"], "0");//Add By Tany 2011-03-22 Modify By Tany 2015-04-20 如果为null则为0
                            string TMP_YLKC = Convertor.IsNull(dtYpDw.Rows[0]["YLKC"], "0");//Add By Tany 2011-03-22 Modify By Tany 2015-04-20 如果为null则为0

                            //add by zouchihua  虚拟库存的判断 2012-02-21
                            //参数开启 并且开医嘱时间不等于当前执行的时间
                            if (_cfgList.cfg6035.Config.ToString().Equals("1"))
                            {
                                if (execNow.Date != BEGINEXEDATE.Date)
                                {
                                    decimal dTMP_YL = decimal.Parse(TMP_YL);
                                    decimal dTMED_DOSAGE = decimal.Parse(TMED_DOSAGE);
                                    decimal ypsl = -1 * dTMP_YL * ettOrdExec.ISANALYZED * dTMED_DOSAGE;

                                    XnKclEntity xn = new XnKclEntity();
                                    xn.cjid = TMP_CJID;
                                    xn.num = ypsl.ToString();
                                    xn.dwbl = TMED_DWLX;
                                    xn.execDeptId = TMED_EXEC_DEPT;
                                    //UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//失败不处理
                                    xnKcLists.Add(xn);
                                }
                            }

                            //Modify By Tany 2009-12-22  医嘱执行时是否限制库存量不足的药品不能发送 0=不是 1=是
                            if (_cfgList.cfg7059.Config.ToString().Equals("1"))
                            {
                                decimal ylKcl = decimal.Parse(TMP_KCL);
                                decimal dTMP_YL = decimal.Parse(TMP_YL);
                                decimal dTMED_DOSAGE = decimal.Parse(TMED_DOSAGE);
                                decimal thisYl = dTMP_YL * ettOrdExec.ISANALYZED * dTMED_DOSAGE;
                                if (thisYl > ylKcl)
                                {
                                    //医嘱执行药品库存量不足时是否自动替换同规格不同厂家有库存的药品 0=不是 1=是
                                    if (_cfgList.cfg7060.Config.ToString().Equals("1"))
                                    {
                                        iOutPut = 1;//return
                                        iret = -1;
                                        strMsg = BED_NO + " 床病人 " + PAT_NAME + " 该种药品:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")的库存量为(" + ylKcl + ") 本次执行数量为(" + thisYl + ")，数量不够，不能执行！";
                                        return iOutPut;
                                    }
                                    else
                                    {
                                        //wait 换药逻辑
                                    }
                                }
                            }

                            //如果是本科室的药，判断是否直接记账
                            int TMP_CHARGE_BIT = GetMedChargeBit(TMED_EXEC_DEPT, TMED_MNGTYPE, TMED_JZ_FLAG);

                            OrderPrescEntity ettOrdPresc = new OrderPrescEntity();
                            ettOrdPresc.ID = PubStaticFun.NewGuid();
                            ettOrdPresc.INPATIENT_ID = _Binid;
                            ettOrdPresc.BABY_ID = _Babyid;
                            ettOrdPresc.BOOK_DATE = EXECBOOKDATE;
                            ettOrdPresc.BOOK_USER = EXEUSER;
                            ettOrdPresc.PRESC_NO = dCfh;//decimal(21,6)
                            ettOrdPresc.PRESC_DATE = execNow;
                            ettOrdPresc.SOURCE_ID = ettOrdExec.ID;
                            ettOrdPresc.ORDER_ID = ettOrd.ORDER_ID;
                            ettOrdPresc.TYPE = 1;//type=1：普通   type=2：附加费用
                            ettOrdPresc.DEPT_ID = long.Parse(TMED_DEPT_BR);
                            ettOrdPresc.EXECDEPT_ID = long.Parse(TMED_EXEC_DEPT);
                            ettOrdPresc.PRESC_DOC = long.Parse(TMED_ORDER_DOC);
                            ettOrdPresc.HDITEM_ID = long.Parse(TMED_HOITEM_ID);
                            ettOrdPresc.XMLY = int.Parse(TMED_XMLY);
                            ettOrdPresc.STATITEM_CODE = TMED_STATCODE;
                            ettOrdPresc.SUBCODE = TMED_ITEM_CODE;
                            ettOrdPresc.STANDARD = "";
                            ettOrdPresc.DOSAGE = int.Parse(TMED_DOSAGE);
                            ettOrdPresc.UNIT = TMP_UNIT;
                            ettOrdPresc.UNITRATE = int.Parse(TMP_YDWBL);
                            ettOrdPresc.PRICE = decimal.Parse(TMP_PRICE);
                            ettOrdPresc.AGIO = 1;
                            ettOrdPresc.NUM = decimal.Parse(TMP_YL) * ettOrdExec.ISANALYZED;
                            ettOrdPresc.CHARGE_BIT = TMP_CHARGE_BIT;
                            ettOrdPresc.JGBM = _JGBM;

                            //prescLists.Add(ettOrdPresc, FeeLists);
                            prescListsInfo.Add(ettOrdPresc, new List<OrderFeeEntity>());
                        }

                        #endregion

                        #region"项目处方表ZY_PRESCRIPTION"

                        if ((NTYPE > 3 || XMLY == 2) && HOITEMID > 0)
                        {
                            //出院转科、手术、说明不判断是否有记录插入
                            if (ettOrd.HOITEM_ID <= 0 || ettOrd.EXEC_DEPT <= 0)
                                continue;

                            OrderPrescEntity ettOrdPresc = new OrderPrescEntity();

                            DataTable dtExeDept = GetDeptJzInfo(ettOrd.EXEC_DEPT);

                            if (dtExeDept == null || dtExeDept.Rows.Count <= 0)
                            {
                                throw new Exception("未找到：" + ettOrd.EXEC_DEPT + " 该执行科室对应的科室信息");
                            }

                            string deptJzFlag = dtExeDept.Rows[0]["ISJZ"].ToString().Trim();
                            long ExecDeptJgbm = long.Parse(dtExeDept.Rows[0]["JGBM"].ToString().Trim());

                            DataTable dtXm = GetItemInfo(ettOrd.HOITEM_ID, ettOrd.EXEC_DEPT, ettOrd.JGBM, ExecDeptJgbm);

                            if (dtXm == null || dtXm.Rows.Count <= 0)
                            {
                                if (NTYPE == 0 || NTYPE == 7 || NTYPE == 10)
                                {
                                    //execLists.Add(ettOrdExec, prescLists);
                                    continue;
                                }

                                //计费医嘱未对应收费项目
                                throw new Exception("未找到：" + ettOrd.HOITEM_ID + " 该HOITEM_ID对应的费用信息");
                            }

                            ettOrdPresc.ID = PubStaticFun.NewGuid();
                            ettOrdPresc.SOURCE_ID = ettOrdExec.ID;
                            ettOrdPresc.INPATIENT_ID = _Binid;
                            ettOrdPresc.PRESC_NO = dCfh;//decimal(21,6)

                            ettOrdPresc.DEPT_ID = ettOrd.DEPT_BR;
                            ettOrdPresc.EXECDEPT_ID = ettOrd.EXEC_DEPT;

                            ettOrdPresc.HDITEM_ID = long.Parse(dtXm.Rows[0]["HDITEM_ID"].ToString().Trim());
                            ettOrdPresc.XMLY = ettOrd.XMLY;

                            ettOrdPresc.STATITEM_CODE = dtXm.Rows[0]["BIGITEMCODE"].ToString().Trim();

                            ettOrdPresc.TCID = long.Parse(dtXm.Rows[0]["TCID"].ToString().Trim());
                            ettOrdPresc.TC_FLAG = int.Parse(dtXm.Rows[0]["TC_FLAG"].ToString().Trim());

                            ettOrdPresc.PRESC_DATE = execNow;
                            ettOrdPresc.PRESC_DOC = ettOrd.ORDER_DOC;
                            ettOrdPresc.STANDARD = ettOrd.ORDER_SPEC;

                            ettOrdPresc.UNIT = dtXm.Rows[0]["UNIT"].ToString().Trim();
                            ettOrdPresc.UNITRATE = 1;

                            if (decimal.Parse(Convertor.IsNull(ettOrd.PRICE, "0")) == 0)
                            {
                                ettOrdPresc.PRICE = decimal.Parse(dtXm.Rows[0]["PRICE"].ToString().Trim());//为0则使用项目价格
                            }
                            else
                            {
                                ettOrdPresc.PRICE = ettOrd.PRICE;//医嘱价格不为0，使用医嘱价格
                            }
                            ettOrdPresc.AGIO = 1;

                            string thisNum = ettOrd.NUM.ToString();
                            if (MNGTYPE == 1 || MNGTYPE == 5)
                            {
                                thisNum = Convertor.IsNull(ettOrd.zsl, "-1").Equals("-1") ? ettOrd.NUM.ToString() : ettOrd.zsl.ToString();
                            }
                            decimal dNum = decimal.Parse(thisNum);
                            decimal xmNum = decimal.Parse(dtXm.Rows[0]["NUM"].ToString().Trim());
                            ettOrdPresc.NUM = xmNum * dNum * ettOrdExec.ISANALYZED;//项目数量*开单数量*执行频次
                            ettOrdPresc.DOSAGE = ettOrd.DOSAGE;
                            ettOrdPresc.BABY_ID = _Babyid;

                            ettOrdPresc.SUBCODE = ettOrd.ITEM_CODE;

                            //直接记账：1.本科记账  2.他科记账及他科jz_flag=1  3.医嘱Jz_flag 4.ntype<>5
                            ettOrdPresc.CHARGE_BIT = 0;
                            if (ettOrd.DEPT_ID == ettOrd.EXEC_DEPT || (ettOrd.DEPT_ID != ettOrd.EXEC_DEPT && deptJzFlag.Equals("1")) || ettOrd.JZ_FLAG == 1 || ettOrd.NTYPE != 5)
                            {
                                ettOrdPresc.CHARGE_BIT = 1;
                            }

                            ettOrdPresc.BOOK_DATE = EXECBOOKDATE;
                            ettOrdPresc.BOOK_USER = EXEUSER;
                            ettOrdPresc.ORDER_ID = ettOrd.ORDER_ID;
                            ettOrdPresc.TYPE = 1;//type=1：普通   type=2：附加费用
                            ettOrdPresc.JGBM = _JGBM;


                            prescListsInfo.Add(ettOrdPresc, new List<OrderFeeEntity>());
                        }

                        #endregion

                        foreach (KeyValuePair<OrderPrescEntity, List<OrderFeeEntity>> kvOrdPresLists in prescListsInfo)
                        //foreach (OrderPrescEntity ettOrdPresc in prescLists)
                        {
                            OrderPrescEntity ettOrdPresc = kvOrdPresLists.Key;

                            List<OrderFeeEntity> FeeLists = new List<OrderFeeEntity>();
                            //处方对应费用
                            prescLists.Add(ettOrdPresc, FeeLists);

                            if (ettOrdPresc.TYPE != 1)
                            {
                                continue;
                            }

                            #region"药品费用处理[药品：费用条数同处方条数和执行条数]"

                            //wait  参数7605的控制
                            if (NTYPE <= 3 && NTYPE > 0 && XMLY == 1 && HOITEMID > 0 && EXEDEPT > 0)
                            {
                                #region"药品的ZY_FEE_SPECI"

                                OrderFeeEntity ettOrdFee = new OrderFeeEntity();
                                ettOrdFee.ID = PubStaticFun.NewGuid();
                                ettOrdFee.INPATIENT_ID = _Binid;
                                ettOrdFee.BABY_ID = _Babyid;

                                ettOrdFee.ORDER_ID = ettOrd.ORDER_ID;
                                ettOrdFee.ORDEREXEC_ID = ettOrdPresc.SOURCE_ID;
                                ettOrdFee.PRESCRIPTION_ID = ettOrdPresc.ID;

                                ettOrdFee.PRESC_NO = ettOrdPresc.PRESC_NO;//decimal(21,6)
                                ettOrdFee.PRESC_DATE = ettOrdPresc.PRESC_DATE;
                                ettOrdFee.BOOK_DATE = ettOrdPresc.BOOK_DATE;
                                ettOrdFee.BOOK_USER = ettOrdPresc.BOOK_USER;
                                ettOrdFee.STATITEM_CODE = ettOrdPresc.STATITEM_CODE;
                                ettOrdFee.XMID = ettOrdPresc.HDITEM_ID;
                                ettOrdFee.XMLY = ettOrdPresc.XMLY;

                                ettOrdFee.ITEM_NAME = ettOrd.ORDER_CONTEXT;
                                ettOrdFee.SUBCODE = ettOrdPresc.SUBCODE;
                                ettOrdFee.UNIT = ettOrdPresc.UNIT;
                                ettOrdFee.UNITRATE = ettOrdPresc.UNITRATE;

                                ettOrdFee.COST_PRICE = ettOrdPresc.PRICE;
                                ettOrdFee.RETAIL_PRICE = ettOrdPresc.PRICE;
                                ettOrdFee.NUM = ettOrdPresc.NUM;
                                ettOrdFee.DOSAGE = ettOrdPresc.DOSAGE;

                                //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                decimal dMoney = ettOrdPresc.PRICE * ettOrdPresc.NUM * ettOrdPresc.DOSAGE / ettOrdExec.ISANALYZED;
                                string strMoney = dMoney.ToString("0.00");
                                dMoney = decimal.Parse(strMoney);
                                ettOrdFee.SDVALUE = dMoney * ettOrdExec.ISANALYZED;
                                ettOrdFee.ACVALUE = ettOrdFee.SDVALUE;

                                ettOrdFee.AGIO = ettOrdPresc.AGIO;

                                ettOrdFee.CHARGE_BIT = ettOrdPresc.CHARGE_BIT;
                                ettOrdFee.CHARGE_DATE = null;
                                ettOrdFee.CHARGE_USER = null;
                                if (pvsBit == 1)
                                {
                                    //pvs处理
                                    TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                                    int iDiff2 = tm2.Days;
                                    if (iDiff2 >= 1)
                                    {
                                        ettOrdFee.CHARGE_BIT = 0;
                                    }
                                }
                                if (ettOrdFee.CHARGE_BIT == 1)
                                {
                                    //pvs处理
                                    TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                                    int iDiff2 = tm2.Days;

                                    if (pvsBit == 0 || iDiff2 <= 0)
                                    {
                                        ettOrdFee.CHARGE_DATE = ettOrdPresc.BOOK_DATE;
                                        ettOrdFee.CHARGE_USER = ettOrdPresc.BOOK_USER;
                                    }
                                }

                                ettOrdFee.DELETE_BIT = 0;
                                ettOrdFee.CZ_FLAG = 0;
                                ettOrdFee.DISCHARGE_BIT = 0;

                                ettOrdFee.DOC_ID = ettOrdPresc.PRESC_DOC;
                                ettOrdFee.DEPT_ID = DEPTID;
                                ettOrdFee.DEPT_BR = DEPTBR;
                                ettOrdFee.EXECDEPT_ID = ettOrdPresc.EXECDEPT_ID;//--Modify by Tany 2015-04-20 执行科室还是跟随处方表，在处方表确定在哪个执行科室领药


                                DataTable dtYp = GetYpInfo(ettOrd.HOITEM_ID);

                                if (dtYp == null || dtYp.Rows.Count <= 0)
                                {
                                    throw new Exception(ettOrd.HOITEM_ID + " 药品厂家典中未找到该药品信息");
                                }
                                ettOrdFee.TLFS = GetTlflInfo(ettOrd, ettOrdPresc, dtYp);

                                ettOrdFee.DEPT_LY = DEPTLY;
                                ettOrdFee.JGBM = _JGBM;
                                ettOrdFee.GG = dtYp.Rows[0]["S_YPGG"].ToString();
                                ettOrdFee.CJ = dtYp.Rows[0]["S_SCCJ"].ToString();

                                ettOrdFee.GCYS = GCYS;
                                ettOrdFee.ZFBL = decimal.Parse(Convertor.IsNull(ettOrd.zfbl, "1")).ToString();

                                ettOrdFee.FY_BIT = GetFyBit(ettOrdPresc);
                                ettOrdFee.pvs_xh = ettOrdExec.PVS_XH;

                                //FeeListsInfo.Add(ettOrdFee);
                                FeeLists.Add(ettOrdFee);

                                #endregion
                            }

                            #endregion

                            #region"诊疗费用及附加医技逻辑处理[项目：费用条数已处方条数为基础处理套餐]"

                            if ((NTYPE > 3 || XMLY == 2) && HOITEMID > 0)
                            {
                                #region"项目的ZY_FEE_SPECI"

                                //本次执行的收费项目
                                DataTable dtXm = GetItemInfoToFee(ettOrd, ettOrdPresc);
                                if (dtXm == null || dtXm.Rows.Count <= 0)
                                {
                                    throw new Exception(" 未获取到本次要执行的项目信息！ ");
                                }

                                string xmSTATITEM_CODE = "";
                                string xmITEM_NAME = "";
                                string xmSTD_CODE = "";
                                string xmITEM_UNIT = "";
                                string xmCOST_PRICE = "";
                                string xmRETAIL_PRICE = "";
                                string xmSUBITEM_ID = "";
                                string xmNUM = "";

                                decimal dSumAcVal = 0;
                                bool bCharged = false;

                                for (int iXm = 0; iXm < dtXm.Rows.Count; iXm++)
                                {
                                    #region"ZY_FEE_SPECI"

                                    OrderFeeEntity ettOrdFee = new OrderFeeEntity();

                                    if (ettOrdPresc.TC_FLAG == 0 && ettOrdPresc.TCID < 0)
                                    {
                                        //非套餐单项收费信息
                                        xmSTATITEM_CODE = dtXm.Rows[iXm]["STATITEM_CODE"].ToString();
                                        xmITEM_NAME = dtXm.Rows[iXm]["ITEM_NAME"].ToString();
                                        xmSTD_CODE = dtXm.Rows[iXm]["STD_CODE"].ToString();
                                        xmITEM_UNIT = dtXm.Rows[iXm]["ITEM_UNIT"].ToString();


                                        ettOrdFee.XMID = ettOrdPresc.HDITEM_ID;
                                        ettOrdFee.COST_PRICE = ettOrdPresc.PRICE;
                                        ettOrdFee.RETAIL_PRICE = ettOrdPresc.PRICE;
                                        ettOrdFee.NUM = ettOrdPresc.NUM;

                                        //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                        decimal dMoney = ettOrdPresc.PRICE * ettOrdPresc.NUM / ettOrdExec.ISANALYZED;
                                        string strMoney = dMoney.ToString("0.00");
                                        dMoney = decimal.Parse(strMoney);
                                        ettOrdFee.SDVALUE = dMoney * ettOrdExec.ISANALYZED;
                                        ettOrdFee.ACVALUE = ettOrdFee.SDVALUE;
                                    }
                                    else if (ettOrdPresc.TC_FLAG == 1 && ettOrdPresc.TCID >= 0)
                                    {
                                        //套餐拆分后单项收费信息
                                        xmSTATITEM_CODE = dtXm.Rows[iXm]["STATITEM_CODE"].ToString();
                                        xmITEM_NAME = dtXm.Rows[iXm]["ITEM_NAME"].ToString();
                                        xmSTD_CODE = dtXm.Rows[iXm]["STD_CODE"].ToString();
                                        xmITEM_UNIT = dtXm.Rows[iXm]["ITEM_UNIT"].ToString();
                                        xmCOST_PRICE = dtXm.Rows[iXm]["COST_PRICE"].ToString();
                                        xmRETAIL_PRICE = dtXm.Rows[iXm]["RETAIL_PRICE"].ToString();
                                        xmSUBITEM_ID = dtXm.Rows[iXm]["SUBITEM_ID"].ToString();
                                        xmNUM = dtXm.Rows[iXm]["NUM"].ToString();

                                        decimal dXmNum = decimal.Parse(xmNUM);
                                        decimal dXmCOST_PRICE = decimal.Parse(xmCOST_PRICE);
                                        decimal dXmRETAIL_PRICE = decimal.Parse(xmRETAIL_PRICE);

                                        ettOrdFee.XMID = long.Parse(xmSUBITEM_ID);
                                        ettOrdFee.COST_PRICE = dXmCOST_PRICE;
                                        ettOrdFee.RETAIL_PRICE = dXmRETAIL_PRICE;
                                        ettOrdFee.NUM = ettOrdPresc.NUM * dXmNum;

                                        //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                        ettOrdFee.SDVALUE = dXmCOST_PRICE * ettOrdPresc.NUM * dXmNum;
                                        ettOrdFee.ACVALUE = dXmRETAIL_PRICE * ettOrdPresc.NUM * dXmNum;
                                    }

                                    ettOrdFee.ID = PubStaticFun.NewGuid();
                                    ettOrdFee.INPATIENT_ID = _Binid;
                                    ettOrdFee.BABY_ID = _Babyid;
                                    ettOrdFee.ORDER_ID = ettOrd.ORDER_ID;
                                    ettOrdFee.ORDEREXEC_ID = ettOrdPresc.SOURCE_ID;
                                    ettOrdFee.PRESCRIPTION_ID = ettOrdPresc.ID;
                                    ettOrdFee.PRESC_NO = ettOrdPresc.PRESC_NO;//decimal(21,6)
                                    ettOrdFee.PRESC_DATE = ettOrdPresc.PRESC_DATE;
                                    ettOrdFee.BOOK_DATE = ettOrdPresc.BOOK_DATE;
                                    ettOrdFee.BOOK_USER = ettOrdPresc.BOOK_USER;

                                    ettOrdFee.STATITEM_CODE = xmSTATITEM_CODE;
                                    ettOrdFee.XMLY = ettOrdPresc.XMLY;
                                    ettOrdFee.TCID = ettOrdPresc.TCID;
                                    ettOrdFee.TC_FLAG = ettOrdPresc.TC_FLAG;

                                    ettOrdFee.ITEM_NAME = xmITEM_NAME;
                                    ettOrdFee.SUBCODE = xmSTD_CODE;
                                    ettOrdFee.UNIT = xmITEM_UNIT;
                                    ettOrdFee.UNITRATE = ettOrdPresc.UNITRATE;

                                    ettOrdFee.DOSAGE = ettOrdPresc.DOSAGE;


                                    ettOrdFee.AGIO = ettOrdPresc.AGIO;

                                    bool bYjqr = false;
                                    ettOrdFee.CHARGE_BIT = ettOrdPresc.CHARGE_BIT;
                                    ettOrdFee.CHARGE_DATE = null;
                                    ettOrdFee.CHARGE_USER = null;
                                    if (ettOrdFee.CHARGE_BIT == 1)
                                    {
                                        ettOrdFee.CHARGE_DATE = ettOrdPresc.BOOK_DATE;
                                        ettOrdFee.CHARGE_USER = ettOrdPresc.BOOK_USER;
                                        bYjqr = true;

                                        bCharged = true;
                                    }

                                    ettOrdFee.DELETE_BIT = 0;
                                    ettOrdFee.CZ_FLAG = 0;
                                    ettOrdFee.DISCHARGE_BIT = 0;

                                    ettOrdFee.DOC_ID = ettOrdPresc.PRESC_DOC;
                                    ettOrdFee.DEPT_ID = DEPTID;
                                    ettOrdFee.DEPT_BR = DEPTBR;
                                    ettOrdFee.EXECDEPT_ID = ettOrdPresc.EXECDEPT_ID;//--Modify by Tany 2015-04-20 执行科室还是跟随处方表，在处方表确定在哪个执行科室领药

                                    ettOrdFee.DEPT_LY = DEPTLY;
                                    ettOrdFee.JGBM = _JGBM;

                                    ettOrdFee.GCYS = GCYS;
                                    ettOrdFee.ZFBL = decimal.Parse(Convertor.IsNull(ettOrd.zfbl, "1")).ToString();

                                    FeeLists.Add(ettOrdFee);

                                    #endregion

                                    dSumAcVal += ettOrdFee.ACVALUE;
                                }

                                //医技处理同处方数（套餐不需要拆分生成记录）
                                if (NTYPE == 5)
                                {
                                    #region"医技申请"

                                    //医技处理
                                    YjZySqEntity yjsq = new YjZySqEntity();

                                    yjsq.YJSQID = PubStaticFun.NewGuid();
                                    yjsq.JGBM = _JGBM;
                                    yjsq.BRXXID = _BRXXID;
                                    yjsq.INPATIENT_ID = ettOrdExec.INPATIENT_ID;
                                    yjsq.SQRQ = ettOrdPresc.PRESC_DATE;
                                    yjsq.SQR = ettOrd.ORDER_DOC;
                                    yjsq.SQKS = ettOrd.DEPT_ID;

                                    yjsq.SQNR = ettOrd.ORDER_CONTEXT;
                                    if (ettOrd.UNIT.ToUpper().Equals("U") || ettOrd.UNIT.ToUpper().Equals("ML"))
                                    {
                                        string charInfo = Get_ZY_CHGDECIMALTOCHAR(ettOrd.NUM);
                                        yjsq.SQNR = ettOrd.ORDER_CONTEXT.Trim() + " " + charInfo + " " + ettOrd.UNIT;
                                    }

                                    yjsq.JE = dSumAcVal;
                                    yjsq.LCZD = Convertor.IsNull(ettOrd.MEMO1, "");
                                    yjsq.ZXKS = ettOrd.EXEC_DEPT;
                                    yjsq.BSJC = "";
                                    yjsq.BBMC = GetSampName(ettOrd.DWLX);
                                    yjsq.ZYSX = "";
                                    yjsq.BJJBZ = 0;
                                    yjsq.YZID = ettOrd.ORDER_ID;
                                    yjsq.YZXMID = ettOrd.HOITEM_ID;
                                    yjsq.ZXR = EXEUSER;
                                    yjsq.ZXSJ = DateManager.ServerDateTimeByDBType(_database);
                                    yjsq.ZXID = ettOrdExec.ID;
                                    yjsq.DJLX = GetDjly(ettOrd.HOITEM_ID);

                                    yjsqLists.Add(yjsq);

                                    #endregion

                                    #region"医技确认"

                                    if (bCharged)
                                    {
                                        YjZySqEntity yjqr = new YjZySqEntity();

                                        yjqr.YJSQID = yjsq.YJSQID;
                                        yjqr.ZXID = ettOrdExec.ID;
                                        yjqr.YZID = ettOrd.ORDER_ID;
                                        yjqr.JE = dSumAcVal;

                                        yjqrLists.Add(yjqr);
                                        //Guid YJ_EXEC_ID = ettOrdExec.ID;
                                        //Guid YJ_APP_ID = yjsq.YJSQID;
                                        //Guid YJ_ORDER_ID = ettOrd.ORDER_ID;
                                        //decimal YJ_JE = yjsq.JE;

                                        //Guid NEWYJSQID = Guid.Empty;
                                        //int iSqRet = -1;
                                        //string strSqMsg = "";
                                        //yj_zysq_qrjl(YJ_ORDER_ID, YJ_EXEC_ID, YJ_APP_ID, YJ_JE, DEPTID, EXECBOOKDATE, EXEUSER, 1, EXECBOOKDATE, 0, "", out NEWYJSQID, out iSqRet, out strSqMsg, 0);
                                        //if (iSqRet != 0)
                                        //{
                                        //    iOutPut = 1;//return
                                        //    iret = -1;
                                        //    strMsg = BED_NO + " 床病人 " + PAT_NAME + " 医技确费出错:" + strSqMsg;
                                        //    return iOutPut;
                                        //}
                                    }

                                    #endregion
                                }

                                #endregion
                            }

                            #endregion

                            ////处方对应费用
                            //prescLists.Add(ettOrdPresc, FeeLists);
                        }

                        //执行对应处方
                        //execLists.Add(ettOrdExec, prescLists);

                        #region"医嘱附加费用 wait"
                        #endregion
                    }

                    //orderLists.Add(ettOrd, execLists);
                }

                #endregion

                return iOutPut;
            }
            catch (Exception ex)
            {
                throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 组号：" + _Groupid + " 医嘱日期：" + execNow.ToString("yyyy-MM-dd") + " DoExcuteAddFee时err：" + ex.Message);
            }
        }

        /// <summary>
        /// NextDay（暂存药7191  、虚拟库存6035、   医技自动冲正  wait ）
        /// </summary>
        /// <returns>医嘱是否能执行(0：继续  1：return  2：nextday完成处理)</returns>
        public int DoExcuteNextDay(DateTime execNow, List<OrderEntity> updateOrderInfo,
            List<OrderFeeEntity> czFeeLists, List<XnKclEntity> xnKcLists, List<YjZySqEntity> upDatetYjsqLists,
            List<string> updateFeeFlagLists, List<OrderFeeEntity> delFeeLists,
            out int iret, out string strMsg)
        {
            iret = 0;
            strMsg = "";
            int iOutPut = -1;
            try
            {
                if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                {
                    #region"停临时类医嘱"

                    //临时是否存在有执行记录，医嘱状态为2的记录
                    //直连数据库【担心并发，不使用内存记录】
                    int iStatus = GetTmpOrder();
                    if (iStatus == 1)//需要停临时
                    {
                        OrderEntity ettOrd = new OrderEntity();
                        ettOrd.STATUS_FLAG = 5;
                        ettOrd.ORDER_EDATE = EXECBOOKDATE;

                        updateOrderInfo.Add(ettOrd);//加入事务列表

                        //更新缓存记录
                        foreach (OrderEntity thisOrd in _orderList)
                        {
                            thisOrd.STATUS_FLAG = 5;
                            thisOrd.ORDER_EDATE = EXECBOOKDATE;
                        }
                    }

                    #endregion
                }
                else
                {
                    //长期整盒逻辑（处理时参考周期cycles）
                    if (ZHBJ == 1)
                    {
                        //暂时触发器里面处理  wait
                        iret = 0;
                        strMsg = "";
                        iOutPut = 0;
                        return iOutPut;
                    }

                    DateTime now = DateManager.ServerDateTimeByDBType(_database);

                    //有停日期，并且当前执行时间>=停时间：自动冲正逻辑
                    if (STOPEXEDATE.HasValue && execNow.Date >= STOPEXEDATE.Value.Date)
                    {
                        string isCz = _cfgList.cfg7055.Config.Trim();
                        if (STATUS_FLAG == 4 && isCz.Equals("1"))
                        {
                            int iCzCharge = GetCzChargeBit();

                            string cfg7142 = _cfgList.cfg7142.Config.ToString().Trim();
                            foreach (OrderEntity ettOrd in _orderList)
                            {
                                if (cfg7142.Equals("0") && ettOrd.NTYPE == 5)
                                {
                                    //医技wait测试
                                    //开关配置医技项目不冲正
                                    continue;
                                }

                                DateTime? maxPresDate = GetMaxPrescDate(ettOrd.ORDER_ID);
                                if (!maxPresDate.HasValue)
                                {
                                    continue;//没有执行记录，无须冲正（ntype=0、7 或者 未执行直接停嘱的收费医嘱）
                                }

                                DateTime MAXEXECDATE = maxPresDate.Value;
                                TimeSpan tp = MAXEXECDATE.Date.Subtract(STOPEXEDATE.Value.Date);
                                int iDiff = tp.Days;
                                while (MAXEXECDATE.Date >= STOPEXEDATE.Value.Date)
                                {
                                    DataTable dtCz = GetCzFeeInfo(ettOrd.ORDER_ID, MAXEXECDATE.Date.ToString("yyyy-MM-dd"));

                                    if (dtCz != null && dtCz.Rows.Count > 0)
                                    {
                                        int iDayOrderCz = 0;//（由于冲正记录缓存延时提交，部分冲正时，需要记录该日医嘱缓存区冲正数量）该日该医嘱缓存冲正量

                                        for (int iCz = 0; iCz < dtCz.Rows.Count; iCz++)
                                        {
                                            DataRow drFee = dtCz.Rows[iCz];//逐个费用冲正（套餐）

                                            string kfTlfl = _cfgList.cfg7048.Config.Trim();
                                            string isClYpCz = _cfgList.cfg7054.Config.Trim();
                                            //如果是口服药，并且拆零，并且不允许退拆零口服药，跳出去执行下一条
                                            //拆零口服药判断原来是@CFG_ISCLYPCZ=0，现在改为不等于1，用于参数可以设置住院号来单独开启冲减 Modify By Tany 2015-06-04

                                            bool bKfTlFl = string.IsNullOrEmpty(kfTlfl);
                                            bool bClYpCz = isClYpCz.Equals("1");
                                            int iUnitRate = int.Parse(Convertor.IsNull(drFee["UNITRATE"], "0"));
                                            bool bKf = kfTlfl.Contains(drFee["TLFL"].ToString());

                                            if ((!bKfTlFl) && (!bClYpCz) && iUnitRate > 1 && bKf)
                                            {
                                                //拆零口服药不自动冲正
                                                continue;
                                            }

                                            string cfg7603 = _cfgList.cfg7603.Config.Trim();
                                            string pvsScan = Convertor.IsNull(drFee["is_PvsScn"], "0");
                                            if (cfg7603.Equals("0") && pvsScan.Equals("1"))
                                            {
                                                //如果是pivas已经进仓扫描并且7603（pivas以扫描药品是否允许冲减 0否 1是）为0，跳出去执行下一条
                                                continue;
                                            }

                                            Guid feeid = new Guid(drFee["id"].ToString());
                                            DataTable dtCzNum = GetCzNum(feeid);
                                            if (dtCzNum != null && dtCzNum.Rows.Count > 0)
                                            {

                                                string strCzzNum = Convertor.IsNull(dtCzNum.Rows[0]["CZZNUM"], "0").Trim();
                                                string strCzzMoney = Convertor.IsNull(dtCzNum.Rows[0]["CZZJE"], "0").Trim();
                                                decimal dCzzNum = Convert.ToDecimal(strCzzNum);//可冲金额
                                                int iCzNum = (int)dCzzNum;//可冲数量
                                                decimal dCzMoney = Convert.ToDecimal(strCzzMoney);//可冲金额

                                                string disChargeBit = drFee["DISCHARGE_BIT"].ToString().Trim();

                                                if (iCzNum > 0 && disChargeBit.Equals("0"))
                                                {
                                                    int iNeedCzNum = iCzNum;//有效数

                                                    //有可冲正费用
                                                    int iCzAll = 1;//0部分冲正   1全冲
                                                    if (MAXEXECDATE.Date > STOPEXEDATE.Value.Date)
                                                    {
                                                        iCzAll = 1;

                                                        //全部冲正
                                                        DoExexCzFee(execNow, czFeeLists, xnKcLists, upDatetYjsqLists, updateFeeFlagLists, delFeeLists,
                                                            drFee, iNeedCzNum, dCzMoney, iCzCharge, iCzAll, out  iret, out  strMsg);
                                                    }
                                                    else
                                                    {
                                                        if (!TERMINALTIMES.HasValue)
                                                            throw new Exception("TERMINALTIMES为null，不可以冲正");

                                                        if (TERMINALTIMES.Value == 0)
                                                        {
                                                            iCzAll = 1;

                                                            //全部冲正
                                                            DoExexCzFee(execNow, czFeeLists, xnKcLists, upDatetYjsqLists, updateFeeFlagLists, delFeeLists,
                                                                drFee, iNeedCzNum, dCzMoney, iCzCharge, iCzAll, out  iret, out  strMsg);
                                                        }
                                                        else
                                                        {
                                                            //部分冲正
                                                            //2017-09-22 通过order_id、xmid、xmly 确定日有效医嘱数量
                                                            string thisXmid = drFee["cjid"].ToString().Trim();//即xmid
                                                            string thisXmly = drFee["xmly"].ToString().Trim();
                                                            DataTable dtCzNumOrder = GetCzNumByOrder(ettOrd.ORDER_ID, thisXmid, thisXmly, MAXEXECDATE.Date.ToString("yyyy-MM-dd"));
                                                            //该医嘱有执行部分才需要自动冲正
                                                            if (dtCzNumOrder != null && dtCzNumOrder.Rows.Count > 0)
                                                            {
                                                                //string strCzzNumOrd = Convertor.IsNull(dtCzNumOrder.Rows[0]["CZZNUM"], "0").Trim();
                                                                //decimal dCzzNumOrd = Convert.ToDecimal(strCzzNum);//可冲数量
                                                                //int iOrderNum = (int)dCzzNumOrd;//医嘱的可冲数量//医嘱日有效次数
                                                                string strCzzNumOrd = Convertor.IsNull(dtCzNumOrder.Rows[0]["CZZNUM"], "0").Trim();
                                                                decimal dCzzNumOrd = Convert.ToDecimal(strCzzNumOrd);//可冲数量
                                                                int iOrderNum = (int)dCzzNumOrd;//医嘱的可冲数量//医嘱日有效次数

                                                                //int iOrderNum = int.Parse(Convertor.IsNull(dtCzNumOrder.Rows[0]["CZZNUM"], "0"));//医嘱的可冲数量
                                                                //2017-09-22
                                                                decimal dOrderMoney = decimal.Parse(Convertor.IsNull(dtCzNumOrder.Rows[0]["CZZJE"], "0"));//医嘱的可冲金额

                                                                Guid execId = new Guid(drFee["ORDEREXEC_ID"].ToString());
                                                                OrderExecEntity ettOrdExec = GetISANALYZED(execId, _orderExecList);

                                                                int zxcs = ettOrdExec.ISANALYZED;
                                                                decimal FeeNum = decimal.Parse(drFee["Num"].ToString());
                                                                iNeedCzNum = iCzNum;//该费用有效数量
                                                                decimal terNums = TERMINALTIMES.Value * FeeNum / zxcs;//末次数量
                                                                //取整terNums
                                                                int iTerNums = Convert.ToInt32(terNums);
                                                                int iFeeNums = Convert.ToInt32(FeeNum);

                                                                iDayOrderCz = GetCzFeeNumByCzList(czFeeLists, ettOrd.ORDER_ID, drFee);

                                                                int iWaitCzNum = iOrderNum - iDayOrderCz - iTerNums;//医嘱日有效次数-缓存区冲正数量-末次数量=需要冲正次数
                                                                if (iWaitCzNum <= 0)
                                                                {
                                                                    //需要冲正数量小于0
                                                                    continue;
                                                                }

                                                                //费用有效数量>需要冲正数量
                                                                if (iNeedCzNum > iWaitCzNum)
                                                                {
                                                                    iCzAll = 0;

                                                                    //够冲正
                                                                    int realCzNum = iWaitCzNum;
                                                                    decimal realCzMoney = (dCzMoney / iNeedCzNum) * realCzNum;
                                                                    DoExexCzFee(execNow, czFeeLists, xnKcLists, upDatetYjsqLists, updateFeeFlagLists, delFeeLists,
                                                                        drFee, realCzNum, realCzMoney, iCzCharge, iCzAll, out  iret, out  strMsg);

                                                                    //iDayOrderCz += realCzNum;
                                                                    //iDayXmid = thisXmid;
                                                                    //iDayXmly = thisXmly;
                                                                }
                                                                else
                                                                {
                                                                    iCzAll = 1;

                                                                    //不够冲正(全冲)
                                                                    int realCzNum = iNeedCzNum;
                                                                    DoExexCzFee(execNow, czFeeLists, xnKcLists, upDatetYjsqLists, updateFeeFlagLists, delFeeLists,
                                                                        drFee, realCzNum, dCzMoney, iCzCharge, iCzAll, out  iret, out  strMsg);

                                                                    //iDayOrderCz += realCzNum;
                                                                    //iDayXmid = thisXmid;
                                                                    //iDayXmly = thisXmly;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }


                                    MAXEXECDATE = MAXEXECDATE.AddDays(-1);
                                }
                            }
                        }

                        #region"长期类医嘱完成"

                        OrderEntity ettOrdFinish = new OrderEntity();
                        ettOrdFinish.STATUS_FLAG = 5;
                        ettOrdFinish.LASTEXECDATE = now;

                        updateOrderInfo.Add(ettOrdFinish);//加入事务列表

                        //更新缓存记录
                        foreach (OrderEntity thisOrd in _orderList)
                        {
                            thisOrd.STATUS_FLAG = 5;
                            thisOrd.LASTEXECDATE = now;
                        }

                        #endregion
                    }
                    else
                    {
                        #region"停Ntype=0的长期类医嘱"

                        //IF (LTRIM(RTRIM(@FREQUENCY))='1') AND (CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) >= CONVERT(DATETIME,DBO.FUN_GETDATE(@BEGINEXEDATE)))
                        //当前执行日期大于等于开单日期
                        if (FREQUENCY.Equals("1") && execNow.Date >= BEGINEXEDATE.Date)
                        {
                            //只处理长期Ntype=0的医嘱 停
                            if ((MNGTYPE == 0 || MNGTYPE == 2) && NTYPE == 0)
                            {
                                OrderEntity ettOrd = new OrderEntity();
                                ettOrd.STATUS_FLAG = 5;
                                ettOrd.ORDER_EDATE = EXECBOOKDATE;
                                ettOrd.ORDER_EDOC = _orderList[0].ORDER_DOC;
                                ettOrd.LASTEXECDATE = now;


                                OrderEntity order = _orderList[0];//执行科室从大到小处理（处理组中含有自备药）
                                if (_orderList[0].ORDER_CONTEXT.Contains("转"))
                                {
                                    ettOrd.ORDER_EDATE = null;
                                    ettOrd.ORDER_EDOC = null;
                                }

                                updateOrderInfo.Add(ettOrd);//加入事务列表

                                //更新缓存记录
                                foreach (OrderEntity thisOrd in _orderList)
                                {
                                    thisOrd.STATUS_FLAG = 5;
                                    thisOrd.ORDER_EDATE = EXECBOOKDATE;
                                    thisOrd.ORDER_EDOC = _orderList[0].ORDER_DOC;
                                    thisOrd.LASTEXECDATE = now;
                                    if (thisOrd.ORDER_CONTEXT.Contains("转"))
                                    {
                                        thisOrd.ORDER_EDATE = null;
                                        thisOrd.ORDER_EDOC = null;
                                    }
                                }
                            }
                        }

                        #endregion
                    }
                }

                iOutPut = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 组号：" + _Groupid + "  医嘱日期：" + execNow.ToString("yyyy-MM-dd") + " 执行NextDay时err：" + ex.Message);
            }
            return iOutPut;
        }

        public int GetCzFeeNumByCzList(List<OrderFeeEntity> czFeeLists, Guid orderid, DataRow drFee)
        {
            decimal dNowCzNum = 0;

            long xmid = long.Parse(drFee["XMID"].ToString());
            int xmly = int.Parse(drFee["XMLY"].ToString());
            string presDate = DateTime.Parse(drFee["PRESC_DATE"].ToString()).ToString("yyyy-MM-dd");

            foreach (OrderFeeEntity ettOrdFee in czFeeLists)
            {
                string ettPreDate = ettOrdFee.PRESC_DATE.ToString("yyyy-MM-dd");

                if (ettOrdFee.ORDER_ID == orderid && ettOrdFee.XMID == xmid && ettOrdFee.XMLY == xmly && ettPreDate.Equals(presDate))
                {
                    dNowCzNum += Math.Abs(ettOrdFee.NUM);
                }
            }

            int iNowCzNum = (int)dNowCzNum;

            return iNowCzNum;
        }

        /// <summary>
        /// 冲正封装
        /// </summary>
        /// <returns>医嘱是否能执行(0：继续  1：return  2：nextday完成处理)</returns>
        public int DoExexCzFee(DateTime execNow, List<OrderFeeEntity> czFeeLists,
            List<XnKclEntity> xnKcLists, List<YjZySqEntity> upDatetYjsqLists,
            List<string> updateFeeFlagLists, List<OrderFeeEntity> delFeeLists,
            DataRow drFee, int iNeedCzNum, decimal dCzMoney, int iCzCharge, int iCzAll, out int iret, out string strMsg)
        {
            iret = 0;
            strMsg = "";
            int iOutPut = -1;
            try
            {
                DateTime now = DateManager.ServerDateTimeByDBType(_database);
                Guid feeid = new Guid(drFee["id"].ToString());

                #region"冲正iCzAll= 1：全  0：部分 "

                #region"CzFee"

                //全冲
                OrderFeeEntity ettOrdFee = new OrderFeeEntity();

                ettOrdFee.ID = PubStaticFun.NewGuid();
                ettOrdFee.ORDER_ID = new Guid(drFee["ORDER_ID"].ToString());
                ettOrdFee.PRESCRIPTION_ID = new Guid(drFee["PRESCRIPTION_ID"].ToString());
                ettOrdFee.ORDEREXEC_ID = new Guid(drFee["ORDEREXEC_ID"].ToString());
                ettOrdFee.PRESC_DATE = DateTime.Parse(drFee["PRESC_DATE"].ToString());
                ettOrdFee.BOOK_DATE = now;
                ettOrdFee.BOOK_USER = EXEUSER;
                ettOrdFee.PRESC_NO = drFee["PRESC_NO"].ToString();

                ettOrdFee.STATITEM_CODE = Convertor.IsNull(drFee["STATITEM_CODE"], "00");
                ettOrdFee.XMID = long.Parse(drFee["XMID"].ToString());
                ettOrdFee.TCID = long.Parse(drFee["TCID"].ToString());
                ettOrdFee.TC_FLAG = int.Parse(drFee["TC_FLAG"].ToString());
                ettOrdFee.INPATIENT_ID = new Guid(drFee["INPATIENT_ID"].ToString());

                ettOrdFee.BABY_ID = long.Parse(drFee["BABY_ID"].ToString());
                ettOrdFee.ITEM_NAME = drFee["ITEM_NAME"].ToString();
                ettOrdFee.SUBCODE = drFee["SUBCODE"].ToString();
                ettOrdFee.XMLY = int.Parse(drFee["XMLY"].ToString());
                ettOrdFee.UNIT = drFee["UNIT"].ToString();

                ettOrdFee.UNITRATE = int.Parse(drFee["UNITRATE"].ToString());
                ettOrdFee.DOSAGE = int.Parse(drFee["DOSAGE"].ToString());
                ettOrdFee.COST_PRICE = decimal.Parse(drFee["COST_PRICE"].ToString());
                ettOrdFee.RETAIL_PRICE = decimal.Parse(drFee["RETAIL_PRICE"].ToString());
                ettOrdFee.AGIO = (int)Convert.ToDecimal(drFee["AGIO"].ToString());
                ettOrdFee.EXECDEPT_ID = long.Parse(drFee["EXECDEPT_ID"].ToString());

                ettOrdFee.DEPT_ID = long.Parse(drFee["DEPT_ID"].ToString());
                ettOrdFee.DEPT_BR = long.Parse(drFee["DEPT_BR"].ToString());
                ettOrdFee.DEPT_LY = long.Parse(drFee["DEPT_LY"].ToString());
                ettOrdFee.DOC_ID = long.Parse(drFee["DOC_ID"].ToString());

                ettOrdFee.CZ_FLAG = 2;
                ettOrdFee.CZ_ID = new Guid(drFee["ID"].ToString());
                ettOrdFee.DELETE_BIT = 0;
                ettOrdFee.DISCHARGE_BIT = 0;
                ettOrdFee.NUM = -1 * iNeedCzNum;
                ettOrdFee.SDVALUE = -1 * dCzMoney;
                ettOrdFee.ACVALUE = -1 * dCzMoney;
                ettOrdFee.TYPE = int.Parse(drFee["TYPE"].ToString());
                ettOrdFee.TLFS = int.Parse(drFee["TLFS"].ToString());

                ettOrdFee.CHARGE_BIT = 0;
                ettOrdFee.CHARGE_USER = null;
                ettOrdFee.CHARGE_DATE = null;
                if (isDsyYf(ettOrdFee.EXECDEPT_ID) || iCzCharge == 1 || (XMLY == 2 && iCzCharge != 2))
                {
                    ettOrdFee.CHARGE_BIT = 1;
                    ettOrdFee.CHARGE_USER = EXEUSER;
                    ettOrdFee.CHARGE_DATE = now;
                }

                ettOrdFee.BZ = "【系统自动冲正】";
                ettOrdFee.JGBM = _JGBM;
                ettOrdFee.GG = drFee["GG"].ToString();
                ettOrdFee.CJ = drFee["CJ"].ToString();
                ettOrdFee.GCYS = long.Parse(drFee["GCYS"].ToString());

                ettOrdFee.FY_BIT = 0;//wait
                if (isDsyYf(ettOrdFee.EXECDEPT_ID))
                {
                    ettOrdFee.FY_BIT = 5;
                }

                ettOrdFee.pvs_xh = int.Parse(drFee["pvs_xh"].ToString());
                ettOrdFee.ZFBL = drFee["ZFBL"].ToString();

                czFeeLists.Add(ettOrdFee);

                #endregion

                if (NTYPE == 5 && XMLY == 2)
                {
                    YjZySqEntity yjsq = new YjZySqEntity();
                    yjsq.BTFBZ = 1;
                    yjsq.TFJE = 1 * dCzMoney;
                    yjsq.YZID = ettOrdFee.ORDER_ID;
                    yjsq.ZXID = ettOrdFee.ORDEREXEC_ID;
                    upDatetYjsqLists.Add(yjsq);
                }

                string cfg6035 = _cfgList.cfg6035.Config.Trim();
                if (cfg6035.Equals("1") && XMLY == 1)
                {
                    //冲正虚拟库存新增
                    XnKclEntity xn = new XnKclEntity();
                    xn.cjid = drFee["cjid"].ToString();
                    xn.num = iNeedCzNum.ToString();
                    xn.dwbl = drFee["UNITRATE"].ToString();
                    xn.execDeptId = drFee["EXECDEPT_ID"].ToString();
                    //UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//失败不处理
                    xnKcLists.Add(xn);
                }

                updateFeeFlagLists.Add(feeid.ToString());//cz_flag=1

                //冲正自动删除
                string cfg7026 = _cfgList.cfg7026.Config.Trim();
                if (cfg7026.Equals("是"))
                {
                    string fyBit = Convertor.IsNull(drFee["FY_BIT"], "0");
                    string scbz = Convertor.IsNull(drFee["scbz"], "0");
                    string CHARGE_BIT = Convertor.IsNull(drFee["CHARGE_BIT"], "0");
                    string DISCHARGE_BIT = Convertor.IsNull(drFee["DISCHARGE_BIT"], "0");

                    if (fyBit.Equals("0") && scbz.Equals("0") && CHARGE_BIT.Equals("0") && DISCHARGE_BIT.Equals("0"))
                    {
                        //未上传、未发药、未记账 、未医保结算
                        //wait 
                        //IF NOT EXISTS(SELECT 1 FROM ZY_FEE_SPECI WHERE  ((@zcy_zdsc=1 and TLFS=9) or (@zcy_zdsc=0  ))   and (FY_BIT=1 OR SCBZ=1) AND DELETE_BIT=0 AND (CZ_ID=@O2_ID ))
                        //暂存药自动冲正删除待处理7191参数
                        //校验在事务中
                        if (iCzAll == 1)
                        {
                            //全冲正才删除冲正费用
                            OrderFeeEntity delFee = new OrderFeeEntity();
                            delFee.ID = feeid;
                            delFee.DELETE_BIT = 1;

                            delFeeLists.Add(delFee);
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 组号：" + _Groupid + " 医嘱日期：" + execNow.ToString("yyyy-MM-dd") + " 执行NextDay时err：" + ex.Message);
            }
            return iOutPut;
        }

        /// <summary>
        /// 医嘱执行容器拆分成list(实体)
        /// </summary>
        public void GetExecEntity(
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderInfo,
            out List<OrderExecEntity> ordExeLists, out List<OrderPrescEntity> ordPrescLists, out List<OrderFeeEntity> ordFeeLists
            )
        {
            ordExeLists = new List<OrderExecEntity>();
            ordPrescLists = new List<OrderPrescEntity>();
            ordFeeLists = new List<OrderFeeEntity>();



            #region"插入处方表、费用表etc"

            foreach (KeyValuePair<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> kvOrdList in orderInfo)
            {
                OrderEntity ettOrd = kvOrdList.Key;

                Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo = kvOrdList.Value;

                foreach (KeyValuePair<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> kvOrdExecList in execListsInfo)
                {
                    OrderExecEntity ettOrdExec = kvOrdExecList.Key;
                    Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescListsInfo = kvOrdExecList.Value;

                    Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescLists = new Dictionary<OrderPrescEntity, List<OrderFeeEntity>>();

                    foreach (KeyValuePair<OrderPrescEntity, List<OrderFeeEntity>> kvOrdPresLists in prescListsInfo)
                    {
                        OrderPrescEntity ettOrdPresc = kvOrdPresLists.Key;

                        List<OrderFeeEntity> FeeLists = kvOrdPresLists.Value;
                        ordFeeLists.AddRange(FeeLists);//费用

                        ordPrescLists.Add(ettOrdPresc);//处方
                    }

                    ordExeLists.Add(ettOrdExec);//执行记录
                }
            }

            #endregion
        }

        /// <summary>
        /// 医嘱执行容器拆分成list(实体)【校验版本】
        /// </summary>
        public void GetExecEntity(DateTime execNow,
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderInfo,
            out List<OrderExecEntity> ordExeLists, out List<OrderPrescEntity> ordPrescLists, out List<OrderFeeEntity> ordFeeLists
            )
        {
            ordExeLists = new List<OrderExecEntity>();
            ordPrescLists = new List<OrderPrescEntity>();
            ordFeeLists = new List<OrderFeeEntity>();

            int iNowExecNum = 0;

            #region"插入处方表、费用表etc"

            foreach (KeyValuePair<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> kvOrdList in orderInfo)
            {
                OrderEntity ettOrd = kvOrdList.Key;

                Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo = kvOrdList.Value;

                foreach (KeyValuePair<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> kvOrdExecList in execListsInfo)
                {
                    OrderExecEntity ettOrdExec = kvOrdExecList.Key;
                    Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescListsInfo = kvOrdExecList.Value;

                    Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescLists = new Dictionary<OrderPrescEntity, List<OrderFeeEntity>>();

                    foreach (KeyValuePair<OrderPrescEntity, List<OrderFeeEntity>> kvOrdPresLists in prescListsInfo)
                    {
                        OrderPrescEntity ettOrdPresc = kvOrdPresLists.Key;

                        List<OrderFeeEntity> FeeLists = kvOrdPresLists.Value;
                        ordFeeLists.AddRange(FeeLists);//费用

                        ordPrescLists.Add(ettOrdPresc);//处方
                    }

                    if (ettOrd.ORDER_ID == ORDERID)
                    {
                        iNowExecNum += ettOrdExec.ISANALYZED;
                    }
                    ordExeLists.Add(ettOrdExec);//执行记录
                }
            }

            #endregion

            #region"费用校验"

            //该医嘱本日有费用记录（只校验有费用的医嘱）
            if (ordFeeLists.Count > 0)
            {
                ////执行事务之前校验：本次执行次数+以前执行次数<=频次次数（防止双倍数据）
                string strSql = string.Format(@"select SUM(ISANALYZED) as Num from  ZY_ORDEREXEC where  ORDER_ID='{0}' and  CONVERT(DATETIME,DBO.FUN_GETDATE(EXECDATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}'))", ORDERID.ToString(), execNow);

                int iEverNum = int.Parse(Convertor.IsNull(_database.GetDataResult(strSql), "0"));

                int iTodayNum = iNowExecNum + iEverNum;

                if (iTodayNum > EXECNUM)
                {
                    //今天执行次数 大于 频次
                    ordExeLists = new List<OrderExecEntity>();
                    ordPrescLists = new List<OrderPrescEntity>();
                    ordFeeLists = new List<OrderFeeEntity>();
                }
            }

            #endregion
        }

        private DataTable GetYpInfo(long cjid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT LTRIM(RTRIM(ISNULL(TLFL,'00'))) TLFL,STATITEM_CODE,S_YPGG,S_SCCJ,DJYP,MZYP,JSYP,GZYP,RSYP FROM VI_YP_YPCD A WHERE A.CJID={0}", cjid);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 处方项目信息[获得：套餐或单项]
        /// </summary>
        /// <param name="Hoitemid"></param>
        /// <param name="OrdExecDeptid"></param>
        /// <param name="OrdJgbm"></param>
        /// <param name="ExecDeptJgbm"></param>
        /// <returns></returns>
        private DataTable GetItemInfo(long Hoitemid, long OrdExecDeptid, long OrdJgbm, long ExecDeptJgbm)
        {
            try
            {
                string ssql = "";
                //                ssql = string.Format(@"select R.HDITEM_ID,H.BIGITEMCODE,R.TCID,R.TC_FLAG,H.UNIT,H.PRICE,R.NUM from JC_HOI_HDI R 
                //                                        INNER JOIN
                //                                        VI_JC_ITEMS H
                //                                        ON H.ITEMID=R.HDITEM_ID AND H.TCID=R.TCID 
                //                                        AND CASE WHEN A.EXEC_DEPT<=0 THEN A.JGBM ELSE DBO.FUN_GETDEPTJGBM(A.EXEC_DEPT) END=H.JGBM
                //                                        where R.HOITEM_ID={0}", cjid);

                long thisJgbm = OrdJgbm;
                if (OrdExecDeptid <= 0)
                {
                    thisJgbm = OrdJgbm;
                }
                else
                {
                    thisJgbm = ExecDeptJgbm;
                }

                ssql = string.Format(@"select R.HDITEM_ID,H.BIGITEMCODE,R.TCID,R.TC_FLAG,H.UNIT,H.PRICE,R.NUM from JC_HOI_HDI R 
                                        INNER JOIN
                                        VI_JC_ITEMS H
                                        ON H.ITEMID=R.HDITEM_ID AND H.TCID=R.TCID 
                                        AND H.JGBM={1}
                                        where R.HOITEM_ID={0}", Hoitemid, thisJgbm);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        private DataTable GetDeptJzInfo(long OrdExecDeptid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT * FROM JC_DEPT_PROPERTY A WHERE A.DEPT_ID={0}", OrdExecDeptid);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        private DataTable GetYpkcmxInfo(int dwlx, decimal num, int cjid, int execdept)
        {
            try
            {
                string sSql = "EXEC SP_FUN_DW_NUM " + dwlx + "," + num + ",1,1,1," + cjid + "," + execdept + ",0";
                DataTable myTb = _database.GetDataTable(sSql);

                return myTb;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 费用项目信息（套餐拆分）
        /// </summary>
        /// <param name="Hoitemid"></param>
        /// <param name="OrdExecDeptid"></param>
        /// <param name="OrdJgbm"></param>
        /// <param name="ExecDeptJgbm"></param>
        /// <returns></returns>
        private DataTable GetItemInfoToFee(OrderEntity ettOrd, OrderPrescEntity ettOrdPresc)
        {
            try
            {
                string ssql = "";

                if (ettOrdPresc.TC_FLAG == 0 && ettOrdPresc.TCID < 0)
                {

                    ssql = string.Format(@"select R.STATITEM_CODE,R.ITEM_NAME,R.STD_CODE,R.ITEM_UNIT from JC_HSITEMDICTION R
                                        where R.ITEM_ID={0} and R.JGBM={1}", ettOrdPresc.HDITEM_ID, ettOrdPresc.JGBM);
                }
                else if (ettOrdPresc.TC_FLAG == 1 && ettOrdPresc.TCID >= 0)
                {
                    long thisJgbm = ettOrd.JGBM;
                    if (ettOrd.EXEC_DEPT <= 0)
                    {
                        thisJgbm = ettOrd.JGBM;
                    }
                    else
                    {
                        DataTable dtExeDept = GetDeptJzInfo(ettOrd.EXEC_DEPT);

                        if (dtExeDept == null || dtExeDept.Rows.Count <= 0)
                        {
                            throw new Exception("未找到：" + ettOrd.EXEC_DEPT + " 该执行科室对应的科室信息");
                        }

                        string deptJzFlag = dtExeDept.Rows[0]["ISJZ"].ToString().Trim();
                        long ExecDeptJgbm = long.Parse(dtExeDept.Rows[0]["JGBM"].ToString().Trim());
                        thisJgbm = ExecDeptJgbm;
                    }

                    ssql = string.Format(@"select R.STATITEM_CODE,R.ITEM_NAME,R.STD_CODE,R.ITEM_UNIT,R.COST_PRICE,R.RETAIL_PRICE,T.SUBITEM_ID,T.NUM
                                        from JC_TC_MX T
                                        INNER JOIN JC_HSITEMDICTION R ON T.SUBITEM_ID=R.ITEM_ID AND R.JGBM={1}
                                        where T.MAINITEM_ID={0} ", ettOrdPresc.TCID, thisJgbm);
                }
                else
                {
                    throw new Exception("TC_FLAG:" + ettOrdPresc.TC_FLAG + " TCID:" + ettOrdPresc.TCID + " 非套餐且非单项收费项目,处理失败,请联系管理员检查ZY_PRESCRIPTION记录！");
                }

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateXnKc(string cjid, string num, string dwbl, string execDeptId)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@cjid";
                parameters[0].Value = Convert.ToInt32(cjid);
                parameters[1].Text = "@ypsl";
                parameters[1].Value = Convert.ToInt32(num);
                parameters[2].Text = "@ydwbl";
                parameters[2].Value = Convert.ToInt32(dwbl);
                parameters[3].Text = "@deptid ";
                parameters[3].Value = Convert.ToInt32(execDeptId);
                parameters[4].Text = "@err_code";
                parameters[4].ParaSize = 100;
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[5].Text = "@Err_Text";
                parameters[5].ParaSize = 100;
                parameters[5].ParaDirection = ParameterDirection.Output;
                _database.DoCommand("sp_yf_updatekcmx_xnkcl", parameters, 60);
                string rtnStr = "";
                rtnStr = parameters[5].Value.ToString().Trim();
                string outcode = "0";
                outcode = parameters[5].Value.ToString().Trim();

                if (outcode == "-1" || rtnStr != "保存成功")
                    throw new Exception(rtnStr.Trim());
            }
            catch { }
        }

        public int GetMedChargeBit(string TMED_EXEC_DEPT, string TMED_MNGTYPE, string TMED_JZ_FLAG)
        {
            int TMP_CHARGE_BIT = iMedCharge;
            try
            {
                //如果是本科室的药，判断是否直接记账
                if (TMED_EXEC_DEPT.Trim().Equals(DEPTLY.ToString().Trim()))
                {
                    TMP_CHARGE_BIT = iMedCharge;
                }
                else
                {
                    TMP_CHARGE_BIT = 0;
                }

                //如果是手术麻醉开的药，直接记账(不需要重新查询开单科室)
                if (BSsmzOrder)
                {
                    TMP_CHARGE_BIT = 1;
                }

                //如果是出院带药，则直接记账
                if (TMED_MNGTYPE.Equals("5") && TMED_JZ_FLAG.Equals("1"))
                {
                    TMP_CHARGE_BIT = 1;
                }

                //参数控制是否直接记帐 MODIFY BY TANY 2007-08-29
                if (_cfgList.cfg7031.Config.ToString().Equals("是"))
                {
                    TMP_CHARGE_BIT = 1;
                }

                //如果是大输液，直接记账,武汉中心医院项目 Modify By Tany 2014-11-24
                //插入处方表的时候处理收费标志 wait to Modify (大输液药房的药品直接记账，而不是大输液统领分类的直接记账)
                bool bDsy = isDsyYf(long.Parse(TMED_EXEC_DEPT));
                if (bDsy)
                {
                    TMP_CHARGE_BIT = 1;
                }
            }
            catch
            {
                TMP_CHARGE_BIT = 0;
            }
            return TMP_CHARGE_BIT;
        }

        public int GetTlflInfo(OrderEntity ettOrd, OrderPrescEntity ettOrdPresc, DataTable dtYp)
        {
            /*
            CASE WHEN C.MNGTYPE=5 AND C.JZ_FLAG=1 THEN 3
			WHEN
			  isnull((SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7206),0)='0'
			 and
			 (
			 C.NTYPE=3 OR D.DJYP=1 OR  ( D.MZYP=1 and (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7101)='0' )--
			OR (D.MZYP=1 and (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7101)='1' and not EXISTS (SELECT 1 FROM SS_DEPT WHERE DEPTID=@DEPTLY) ) --Modify by zouchihua 2012-01-31 麻醉药品且7101参数开启且是手术麻醉 手术麻醉的麻醉药品是否统领
			OR D.JSYP=1 OR D.GZYP=1 OR D.RSYP=1 OR (C.MNGTYPE=5 AND (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7091)='1') 
			OR a.STATITEM_CODE in (@tjdxm_cf)  ) THEN 5 --Modify By Tany 2011-06-19 7091所有临时药品医嘱是否处方领药 0=不是 1=是
			when  (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7206)='1' and ( D.MZYP=1  OR C.NTYPE=3 )  then 5 ---yaokx 2014-06-24 住院处方发药里医院是否只要麻醉药品
			ELSE 0 END,--出院带药TLFS=3 --处方药TLFS=5 毒麻精贵草妊娠
             */
            int iret = 0;
            SystemCfg cfg7206 = _cfgList.cfg7206;
            SystemCfg cfg7101 = _cfgList.cfg7101;
            SystemCfg cfg7091 = _cfgList.cfg7091;
            SystemCfg cfg7132 = _cfgList.cfg7132;

            bool bDjyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["djyp"], "false"));
            bool bMzyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["mzyp"], "false"));
            bool bJsyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["jsyp"], "false"));
            bool bGzyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["gzyp"], "false"));

            string djyp = bDjyp ? "1" : "0";
            string mzyp = bMzyp ? "1" : "0";
            string jsyp = bJsyp ? "1" : "0";
            string gzyp = bGzyp ? "1" : "0";
            string rsyp = (Convertor.IsNull(dtYp.Rows[0]["rsyp"], "0"));

            //bool rsyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["rsyp"], "false"));

            if (ettOrd.MNGTYPE == 5 && ettOrd.JZ_FLAG == 1)
            {
                iret = 3;
            }
            else if (cfg7206.Config.ToString().Trim().Equals("0"))
            {
                if (ettOrd.NTYPE == 3
                        || djyp.Equals("1") || jsyp.Equals("1") || gzyp.Equals("1") || rsyp.Equals("1")
                        || (mzyp.Equals("1") && cfg7101.Config.ToString().Trim().Equals("0"))
                        || (ettOrd.MNGTYPE == 5 && cfg7091.Config.ToString().Trim().Equals("1"))
                        || cfg7132.Config.ToString().Trim().Contains(ettOrdPresc.STATITEM_CODE)
                   )
                {
                    iret = 5;
                }

                if (mzyp.Equals("1") && cfg7101.Config.ToString().Trim().Equals("1"))
                {
                    //开单科室是否手麻
                    string ssql = string.Format(@"select * from SS_DEPT where DEPTID={0} ", DEPTLY);
                    DataTable dt = _database.GetDataTable(ssql);
                    if (dt != null && dt.Rows.Count == 0)
                    {
                        iret = 5;//非手麻科室领药的麻醉药品
                    }
                }
            }
            else if (cfg7206.Config.ToString().Trim().Equals("1") && (ettOrd.NTYPE == 3 || djyp.Equals("1")))
            {
                iret = 5;
            }
            else
            {
                iret = 0;
            }

            return iret;
        }

        /// <summary>
        /// 获取费用发药标志（武汉）
        /// </summary>
        /// <returns></returns>
        public int GetFyBit(OrderPrescEntity ettOrdPresc)
        {
            /*
             * case when A.EXECDEPT_ID in (566,672,783) and C.DEPT_ID not in (SELECT DEPTID FROM SS_DEPT) then 5 else 0 end,
             */
            int iret = 0;

            //非手麻开单  并且 执行科室为大输液药房
            bool bDsy = isDsyYf(ettOrdPresc.EXECDEPT_ID);
            if (bDsy && !BSsmzOrder)
            {
                iret = 5;
            }

            return iret;
        }

        public string Get_ZY_CHGDECIMALTOCHAR(decimal NUM)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT DBO.FUN_ZY_CHGDECIMALTOCHAR({0})", NUM);

                string charInfo = _database.GetDataResult(ssql).ToString();

                return charInfo;
            }
            catch
            {
                return "";
            }
        }

        public string GetSampName(int DWLX)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT SAMP_NAME from LS_AS_SAMPLE where SAMP_CODE={0}", DWLX);

                string charInfo = _database.GetDataResult(ssql).ToString();

                return charInfo;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取登记类型（1化验2检查）
        /// </summary>
        /// <param name="DWLX"></param>
        /// <returns>1化验2检查0其他</returns>
        public int GetDjly(long yzid)
        {
            int iret = 0;
            try
            {
                string ssql = "";

                ssql = string.Format(@"SELECT j.class_type from JC_JC_ITEM h
                                        left join JC_JCCLASSDICTION j on h.jclxid=j.id
                                        where h.YZID={0}", yzid);

                DataTable dt = _database.GetDataTable(ssql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    iret = int.Parse(dt.Rows[0]["class_type"].ToString());

                    if (iret == 0)
                    {
                        //检查
                        iret = 2;
                    }
                    else if (iret == 1)
                    {
                        //化验
                        iret = 1;
                    }

                    return iret;
                }

                ssql = string.Format(@"SELECT i.class_type from JC_ASSAY g
                                        left join JC_JCCLASSDICTION i on g.hylxid=i.id
                                        where g.YZID={0}", yzid);

                dt = _database.GetDataTable(ssql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    iret = int.Parse(dt.Rows[0]["class_type"].ToString());

                    if (iret == 0)
                    {
                        //检查
                        iret = 2;
                    }
                    else if (iret == 1)
                    {
                        //化验
                        iret = 1;
                    }

                    return iret;
                }

                iret = 0;
            }
            catch
            {
                iret = 0;
            }

            return iret;
        }

        /// <summary>
        /// 获取临时医嘱是否能够直接完成
        /// </summary>
        /// <param name="DWLX"></param>
        /// <returns></returns>
        public int GetTmpOrder()
        {
            int iret = 0;

            if (STATUS_FLAG == 2 && _orderExecList.Count > 0)
            {
                iret = 1;//有执行记录并且STATUS_FLAG = 2
            }

            return iret;
        }

        /// <summary>
        /// 获取自动冲正费用是否要记账：charge_bit
        /// </summary>
        /// <param name="DWLX"></param>
        /// <returns></returns>
        public int GetCzChargeBit()
        {
            int iCharge = 1;

            //如果是药品,并且冲正药品不直接记账
            string cfg7025 = _cfgList.cfg7025.Config.ToString().Trim();
            if (NTYPE <= 3 && NTYPE != 0 && XMLY == 1 && cfg7025.Equals("否"))
            {
                iCharge = 0;//有执行记录并且STATUS_FLAG = 2
            }

            string cfg7212 = _cfgList.cfg7212.Config.ToString().Trim();
            //他科室是否不允许冲正
            if (XMLY == 2)
            {
                if (cfg7212.Equals("1"))
                {
                    foreach (OrderEntity ettOrd in _orderList)
                    {
                        DataTable dt = GetHoitemInfo(ettOrd.HOITEM_ID);

                        if (dt == null || dt.Rows.Count <= 0)
                        {
                            throw new Exception("未找到基础Hoitem信息：" + ettOrd.HOITEM_ID);
                        }

                        string isbks = Convertor.IsNull(dt.Rows[0]["isbks"], "");
                        string isryks = Convertor.IsNull(dt.Rows[0]["isbks"], "");
                        if (isbks.Equals("1") || isryks.Equals("1"))
                        {
                            iCharge = 0;
                        }
                    }
                }
            }

            string cfg7053 = _cfgList.cfg7053.Config.ToString().Trim();
            if (NTYPE == 5 && XMLY == 2 && cfg7053.Equals("1"))
            {
                iCharge = 2;
            }

            return iCharge;
        }

        private DataTable GetHoitemInfo(long Hoitemid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT * FROM JC_HOITEMDICTION where ORDER_ID={0}", Hoitemid);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取费用表最大执行时间
        /// </summary>
        /// <param name="DWLX"></param>
        /// <returns></returns>
        public DateTime? GetMaxPrescDate(Guid orderid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT MAX(PRESC_DATE) PRESC_DATE FROM ZY_FEE_SPECI WHERE ORDER_ID='{0}'", orderid);

                DataTable dt = _database.GetDataTable(ssql);

                if (dt == null || dt.Rows.Count <= 0)
                {
                    throw new Exception("未找到费用表中最大PRESC_DATE，order_id：" + orderid);
                }

                if (string.IsNullOrEmpty(Convertor.IsNull(dt.Rows[0]["PRESC_DATE"], "")))
                {
                    return null;
                }

                DateTime datePres = DateTime.Parse(dt.Rows[0]["PRESC_DATE"].ToString());
                return datePres;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private DataTable GetCzFeeInfo(Guid orderid, string strMaxPresDate)
        {
            string cfg7198 = _cfgList.cfg7198.Config.ToString().Trim();
            string cfg7199 = _cfgList.cfg7199.Config.ToString().Trim();
            string cfg7200 = _cfgList.cfg7200.Config.ToString().Trim();
            try
            {
                string ssql = "";

                if (cfg7198.Equals("1"))
                {
                    ssql = string.Format(@"SELECT A.ID,A.ORDEREXEC_ID,A.NUM,A.UNITRATE,ISNULL(B.TLFL,'') TLFL,A.EXECDEPT_ID,XMID as cjid,xmly,A.is_PvsScn,ISNULL(A.CHARGE_DATE,GETDATE()) CHARGE_DATE
                                            ,A.ORDER_ID,A.PRESCRIPTION_ID,A.PRESC_DATE,
                                            A.PRESC_NO,A.STATITEM_CODE,A.XMID,A.TCID,A.TC_FLAG,A.INPATIENT_ID,A.BABY_ID,
                                            A.ITEM_NAME,A.SUBCODE,A.UNIT,A.DOSAGE,A.COST_PRICE, A.RETAIL_PRICE, 
                                            A.AGIO,A.DEPT_ID,A.DEPT_BR,A.DEPT_LY,A.DOC_ID,
                                            A.TYPE,A.TLFS,A.EXECDEPT_ID,A.GG,A.CJ,A.GCYS,A.pvs_xh,A.ZFBL,A.DISCHARGE_BIT,A.FY_BIT,A.SCBZ,A.CHARGE_BIT
	                                        FROM ZY_FEE_SPECI A  
	                                        LEFT JOIN VI_YP_YPCD B ON A.XMID=B.CJID AND A.XMLY=1
	                                        WHERE ORDER_ID='{0}' AND CZ_FLAG<>2 
	                                        AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}'))
		                                        and isnull(YBJS_BIT,0)=0 
		                                        and isnull(A.is_PvsScn,0)=0
		                                        order by xmly,(case when xmly=2 
		                                        and 
		                                        (charindex(','+cast(xmid as varchar(20))+',',','+'{2}'+',')>0 
		                                        or charindex(','+cast(xmid as varchar(20))+',',','+'{3}'+',')>0 )
		                                        then num else a.xmid END),num desc", orderid, strMaxPresDate, cfg7199, cfg7200);
                }
                else
                {
                    ssql = string.Format(@"SELECT A.ID,A.ORDEREXEC_ID,A.NUM,A.UNITRATE,ISNULL(B.TLFL,'') TLFL,A.EXECDEPT_ID,XMID AS cjid,xmly,A.is_PvsScn,ISNULL(A.BOOK_DATE,GETDATE()) CHARGE_DATE
                                            ,A.ORDER_ID,A.PRESCRIPTION_ID,A.PRESC_DATE,
                                            A.PRESC_NO,A.STATITEM_CODE,A.XMID,A.TCID,A.TC_FLAG,A.INPATIENT_ID,A.BABY_ID,
                                            A.ITEM_NAME,A.SUBCODE,A.UNIT,A.DOSAGE,A.COST_PRICE, A.RETAIL_PRICE, 
                                            A.AGIO,A.DEPT_ID,A.DEPT_BR,A.DEPT_LY,A.DOC_ID,
                                            A.TYPE,A.TLFS,A.EXECDEPT_ID,A.GG,A.CJ,A.GCYS,A.pvs_xh,A.ZFBL,A.DISCHARGE_BIT,A.FY_BIT,A.SCBZ,A.CHARGE_BIT
						                    FROM ZY_FEE_SPECI A  
						                    LEFT JOIN VI_YP_YPCD B ON A.XMID=B.CJID AND A.XMLY=1
						                    WHERE ORDER_ID='{0}' AND CZ_FLAG<>2 
                                            AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}'))
						                      AND ISNULL(YBJS_BIT,0)=0 
						                      AND ISNULL(A.is_PvsScn,0)=0
						                      ORDER BY xmly,xmid, num,pvs_xh DESC", orderid, strMaxPresDate);
                }

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        //暂时不用
        private OrderExecEntity GetISANALYZED(Guid execid, List<OrderExecEntity> execLists)
        {
            try
            {
                foreach (OrderExecEntity ettOrdExec in execLists)
                {
                    if (ettOrdExec.ID == execid)
                    {
                        return ettOrdExec;
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        //暂时不用
        private DataTable GetCzNumByOrder(Guid orderid, string xmid, string xmly, string strMaxPresDate)
        {
            try
            {
                string ssql = "";

                //                ssql = string.Format(@"SELECT SUM(NUM) CZZNUM,SUM(ACVALUE) CZZJE FROM ZY_FEE_SPECI WHERE  ORDER_ID='{0}' 
                //                                                AND CZ_FLAG<>2 
                //                                            AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}')) and DELETE_BIT=0 ", orderid, strMaxPresDate, xmid, xmly);


                ssql = string.Format(@"SELECT SUM(NUM) CZZNUM,SUM(ACVALUE) CZZJE FROM ZY_FEE_SPECI WHERE  ORDER_ID='{0}' 
                                            and xmid='{2}' and xmly='{3}'
                                            AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}')) and DELETE_BIT=0 ", orderid, strMaxPresDate, xmid, xmly);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        private DataTable GetCzNum(Guid feeid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT SUM(NUM) CZZNUM,SUM(ACVALUE) CZZJE FROM ZY_FEE_SPECI WHERE DELETE_BIT=0 AND (ID='{0}' OR CZ_ID='{0}')", feeid);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 是否大输液药房
        /// </summary>
        /// <param name="execDept"></param>
        /// <returns></returns>
        public bool isDsyYf(long execDept)
        {
            bool bDsy = false;

            if (execDept == 566 || execDept == 672 || execDept == 783)
            {
                bDsy = true;
            }

            return bDsy;
        }

        /// <summary>
        /// 医技确认
        /// </summary>
        /// <param name="orderid">医嘱ID</param>
        /// <param name="yjsqid">医技申请id</param>
        /// <param name="je">确认金额</param>
        /// <param name="qrks">申请科室</param>
        /// <param name="qrsj">申请时间</param>
        /// <param name="qrr">申请人</param>
        /// <param name="bscqrbz">首次确认标志</param>
        /// <param name="jcrq">检查日期</param>
        /// <param name="jcys">检查医生</param>
        /// <param name="jgwz">结果位置或描述</param>
        /// <param name="NewYjqrid">确认id</param>
        /// <param name="err_code">错误号 0 成功</param>
        /// <param name="err_text">错误文件</param>
        public void yj_zysq_qrjl(Guid orderid, Guid orderexecid, Guid yjsqid, decimal je, long qrks, string qrsj,
            int qrr, int bscqrbz, string jcrq, int jcys, string jgwz, out Guid NewYjqrid, out int err_code,
            out string err_text, int bjlzt)
        {
            ParameterEx[] parameters = new ParameterEx[15];
            parameters[0].Text = "@ORDERID";
            parameters[0].Value = orderid;
            parameters[1].Text = "@yjsqid";
            parameters[1].Value = yjsqid;
            parameters[2].Text = "@JE";
            parameters[2].Value = je;
            parameters[3].Text = "@QRKS";
            parameters[3].Value = qrks;
            parameters[4].Text = "@QRSJ";
            parameters[4].Value = qrsj;
            parameters[5].Text = "@QRR";
            parameters[5].Value = qrr;

            parameters[6].Text = "@BSCQRBZ";
            parameters[6].Value = bscqrbz;
            parameters[7].Text = "@jcrq";
            parameters[7].Value = jcrq;
            parameters[8].Text = "@jcys";
            parameters[8].Value = jcys;
            parameters[9].Text = "@JGWZ";
            parameters[9].Value = jgwz;

            parameters[10].Text = "@NewYjqrid";
            parameters[10].ParaDirection = ParameterDirection.Output;
            parameters[10].ParaSize = 100;

            parameters[11].Text = "@err_code";
            parameters[11].ParaDirection = ParameterDirection.Output;
            parameters[11].DataType = System.Data.DbType.Int32;
            parameters[11].ParaSize = 100;

            parameters[12].Text = "@err_text";
            parameters[12].ParaDirection = ParameterDirection.Output;
            parameters[12].ParaSize = 100;

            parameters[13].Text = "@orderexecid";
            parameters[13].Value = orderexecid;

            parameters[14].Text = "@bjlzt";
            parameters[14].Value = bjlzt;

            _database.GetDataTable("SP_YJ_SAVE_QRJL", parameters, 60);
            NewYjqrid = new Guid(parameters[10].Value.ToString());
            err_code = Convert.ToInt32(parameters[11].Value);
            err_text = Convert.ToString(parameters[12].Value);
        }
    }

    public class XnKclEntity
    {
        public string cjid;
        public string num;
        public string dwbl;
        public string execDeptId;
    }

    public class YjZySqEntity
    {
        public Guid YJSQID;
        public long JGBM;
        public Guid BRXXID;
        public Guid INPATIENT_ID;
        public DateTime SQRQ;
        public long SQR;
        public long SQKS;
        public string SQNR;
        public decimal JE;
        public string LCZD;
        public long ZXKS;
        public string BSJC;
        public string BBMC;
        public string ZYSX;
        public int BJJBZ;
        public Guid YZID;
        public long YZXMID;
        public long ZXR;
        public DateTime ZXSJ;
        public Guid ZXID;
        public int DJLX;
        public int BTFBZ;
        public decimal TFJE;
    }

    #region"作废"

    /*
        /// <summary>
        /// 日执行费用
        /// </summary>
        /// <param name="execNow"></param>
        /// <param name="iret"></param>
        /// <param name="strMsg"></param>
        /// <returns>医嘱是否能执行(0：继续  1：return  2：nextday完成处理)</returns>
        public int ZF_DoExcuteAddFee(DateTime execNow, DateTime execEnd, int iExecNum,
            List<OrderExecEntity> execLists, List<XnKclEntity> xnKcLists,
            List<OrderPrescEntity> prescLists, List<OrderFeeEntity> FeeLists,
            List<OrderPrescEntity> fjPrescLists, List<OrderFeeEntity> fjFeeLists,
            List<YjZySqEntity> yjsqLists, List<YjZySqEntity> yjqrLists,
            out int iret, out string strMsg)
        {
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderInfo
                = new Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>>();

            iret = 0;
            strMsg = "";
            int iOutPut = 0;
            try
            {
                //开始执行时间和停止时间的判断
                if (execNow.Date < BEGINEXEDATE.Date)
                {
                    //Goto NextDay 
                    iOutPut = 2;
                    return iOutPut;
                }

                //ExecNum
                iExecNum = GetExecNums(execNow, execEnd);//真正本日执行次数【注意】

                string dCfh = GetPrescNo();

                int iCfExecCnt = iExecNum;
                bool bCf = false;
                if (cfBit == 1 && XMLY == 1 && iExecNum > 0)
                {
                    //需要拆分
                    iCfExecCnt = 1;
                    bCf = true;
                }

                #region"1：插入执行表  2:回填set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER"

                //1：插入执行表
                //2:回填set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER
                while (iCfExecCnt <= iExecNum)
                {
                    foreach (OrderEntity ettOrd in _orderList)
                    {
                        OrderExecEntity ettOrdExec = new OrderExecEntity();

                        ettOrdExec.ID = PubStaticFun.NewGuid();
                        ettOrdExec.BOOK_DATE = EXECBOOKDATE;
                        ettOrdExec.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdExec.EXEUSER = EXEUSER;
                        ettOrdExec.EXECDATE = execNow;

                        ettOrdExec.ISANALYZED = bCf ? 1 : iExecNum;
                        ettOrdExec.PRESCRIPTION_ID = dCfh;
                        ettOrdExec.INPATIENT_ID = _Binid;
                        ettOrdExec.BABY_ID = _Babyid;
                        ettOrdExec.JGBM = _JGBM;

                        ettOrdExec.PVS_XH = bCf ? iCfExecCnt : -1;

                        //1：插入执行表
                        execLists.Add(ettOrdExec);//待插入执行表：事务
                        _orderExecList.Add(ettOrdExec);//插入中间表

                        //2:回填set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER
                        ettOrd.LASTEXECDATE = execNow;//待插入执行表：事务
                        ettOrd.LASTEXECUSER = EXEUSER;//待插入执行表：事务
                    }

                    iCfExecCnt++;
                }

                #endregion

                if (iExecNum == 0)
                {
                    // goto next 
                    iOutPut = 2;
                    return iOutPut;
                }

                #region"药品处方表处理ZY_PRESCRIPTION"

                string TMED_ID = "";
                string TMED_ORDER_ID = "";
                string TMED_DEPT_ID = "";
                string TMED_DEPT_BR = "";
                string TMED_EXEC_DEPT = "";
                string TMED_ORDER_DOC = "";
                string TMED_NUM = "";
                string TMED_HOITEM_ID = "";
                string TMED_ITEM_CODE = "";
                string TMED_XMLY = "";
                string TMED_DWLX = "";
                string ORDERUNIT = "";
                string TMED_ORDER_SPEC = "";
                string TMED_DOSAGE = "";
                string TMED_MNGTYPE = "";
                string TMED_JZ_FLAG = "";
                string TMED_ORDER_CONTEXT = "";
                string TMED_NTYPE = "";
                string TMED_STATCODE = "";
                string TEMD_TLFL = "";

                //--|已时间戳为索引，遍厉医嘱执行表，得到要插入的处方表的记录
                //--|药需要循环算数量和价格 MODIFY BY TANY 2005-09-11
                //IF @NTYPE<=3 AND @NTYPE<>0 AND @XMLY=1 AND @HOITEMID>0
                if (NTYPE <= 3 && NTYPE > 0 && XMLY == 1 && HOITEMID > 0)
                {
                    foreach (OrderExecEntity ettOrdExec in execLists)
                    {
                        OrderEntity ettOrd = new OrderEntity();
                        bool bHasOrd = false;
                        foreach (OrderEntity thisOrder in _orderList)
                        {
                            if (ettOrdExec.ORDER_ID == thisOrder.ORDER_ID)
                            {
                                ettOrd = thisOrder;
                                bHasOrd = true;
                                break;
                            }
                        }

                        if (!bHasOrd)
                            throw new Exception("执行记录未找到对应的医嘱信息");

                        //不处理自备药
                        if (ettOrd.HOITEM_ID <= 0)
                            continue;

                        TMED_ID = ettOrdExec.ID.ToString();
                        TMED_ORDER_ID = ettOrd.ORDER_ID.ToString();
                        TMED_DEPT_ID = ettOrd.DEPT_ID.ToString();
                        TMED_DEPT_BR = ettOrd.DEPT_BR.ToString();
                        TMED_EXEC_DEPT = ettOrd.EXEC_DEPT.ToString();
                        if (pvsBit == 1)
                        {
                            //pvs处理
                            TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                            int iDiff2 = tm2.Days;
                            if (iDiff2 >= 1)
                            {
                                //pivas第一天药不配置（wait to封装）
                                TMED_EXEC_DEPT = EXEDEPT.ToString();
                            }
                        }
                        TMED_ORDER_DOC = ettOrd.ORDER_DOC.ToString();
                        TMED_NUM = ettOrd.NUM.ToString();
                        if (MNGTYPE == 1 || MNGTYPE == 5)
                        {
                            TMED_NUM = Convertor.IsNull(ettOrd.zsl, "-1").Equals("-1") ? ettOrd.NUM.ToString() : ettOrd.zsl.ToString();
                        }
                        TMED_HOITEM_ID = ettOrd.HOITEM_ID.ToString();
                        TMED_ITEM_CODE = ettOrd.ITEM_CODE.ToString();
                        TMED_XMLY = ettOrd.XMLY.ToString();
                        TMED_DWLX = ettOrd.DWLX.ToString();
                        ORDERUNIT = ettOrd.UNIT;
                        if (MNGTYPE == 1 || MNGTYPE == 5)
                        {
                            ORDERUNIT = string.IsNullOrEmpty(Convertor.IsNull(ettOrd.zsldw, "")) ? ettOrd.UNIT : ettOrd.zsldw;
                        }

                        TMED_ORDER_SPEC = ettOrd.ORDER_SPEC.ToString();
                        TMED_DOSAGE = ettOrd.DOSAGE.ToString();
                        TMED_MNGTYPE = ettOrd.MNGTYPE.ToString();
                        TMED_JZ_FLAG = ettOrd.JZ_FLAG.ToString();
                        TMED_ORDER_CONTEXT = ettOrd.ORDER_CONTEXT.ToString();
                        TMED_NTYPE = ettOrd.NTYPE.ToString();

                        if (ettOrd.XMLY == 1)
                        {
                            DataTable dtYp = GetYpInfo(ettOrd.HOITEM_ID);

                            if (dtYp == null || dtYp.Rows.Count <= 0)
                            {
                                throw new Exception(ettOrd.HOITEM_ID + " 药品厂家典中未找到该药品信息");
                            }

                            TMED_STATCODE = dtYp.Rows[0]["STATITEM_CODE"].ToString();
                            TEMD_TLFL = dtYp.Rows[0]["TLFL"].ToString();
                        }

                        string unit = "";
                        decimal kcl = 0;
                        decimal xnKcl = 0;
                        long thisExecDept = long.Parse(TMED_EXEC_DEPT);
                        //获取pivas库存信息
                        GetYpKcmxInfo(ettOrd.DWLX, ettOrd.HOITEM_ID, ettOrd.XMLY, thisExecDept, out unit, out kcl, out xnKcl);

                        if (string.IsNullOrEmpty(unit))
                        {
                            iOutPut = 1;//return
                            iret = -1;
                            strMsg = BED_NO + " 床病人 " + PAT_NAME + " 该种药品:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")在【" + TMED_EXEC_DEPT + "】没有找到库存信息，请重新开立医嘱！";
                            return iOutPut;
                        }

                        string thisOrderUnit = "";
                        if (MNGTYPE == 1 || MNGTYPE == 5)
                        {
                            thisOrderUnit = string.IsNullOrEmpty(Convertor.IsNull(ettOrd.zsldw, "")) ? ettOrd.UNIT : ettOrd.zsldw;
                        }
                        else
                        {
                            thisOrderUnit = ettOrd.UNIT;
                        }

                        if (unit.Trim().ToUpper() != thisOrderUnit.Trim().ToUpper())
                        {
                            iOutPut = 1;//return
                            iret = -1;
                            strMsg = BED_NO + " 床病人 " + PAT_NAME + " 该种药品:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")的单位(" + unit + ")与医嘱的单位(" + ettOrd.UNIT + ")不同，请重新开立医嘱！";
                            return iOutPut;
                        }

                        decimal _num = decimal.Parse(TMED_NUM);
                        int _cjid = int.Parse(TMED_HOITEM_ID);
                        int _execDeptid = int.Parse(TMED_EXEC_DEPT);

                        DataTable dtYpDw = GetYpkcmxInfo(ettOrd.DWLX, _num, _cjid, _execDeptid);

                        if (dtYpDw == null || dtYpDw.Rows.Count <= 0)
                        {
                            throw new Exception(BED_NO + " 床病人 " + PAT_NAME + " 该种药品:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + "药品计算信息出错");
                        }

                        string TMP_GGID = dtYpDw.Rows[0]["GGID"].ToString();
                        string TMP_CJID = dtYpDw.Rows[0]["CJID"].ToString();
                        string TMP_YL = dtYpDw.Rows[0]["YL"].ToString();
                        string TMP_UNIT = dtYpDw.Rows[0]["UNIT"].ToString();
                        string TMP_PRICE = dtYpDw.Rows[0]["PRICE"].ToString();
                        string TMP_SDVALUE = dtYpDw.Rows[0]["SDVALUE"].ToString();
                        string TMP_YDWBL = dtYpDw.Rows[0]["YDWBL"].ToString();
                        string TMP_ZXKSID = dtYpDw.Rows[0]["ZXKSID"].ToString();
                        string TMP_BDELETE = dtYpDw.Rows[0]["BDELETE"].ToString();
                        string TMP_KCL = Convertor.IsNull(dtYpDw.Rows[0]["KCL"], "0");//Add By Tany 2011-03-22 Modify By Tany 2015-04-20 如果为null则为0
                        string TMP_YLKC = Convertor.IsNull(dtYpDw.Rows[0]["YLKC"], "0");//Add By Tany 2011-03-22 Modify By Tany 2015-04-20 如果为null则为0

                        //add by zouchihua  虚拟库存的判断 2012-02-21
                        //参数开启 并且开医嘱时间不等于当前执行的时间
                        if (_cfgList.cfg6035.Config.ToString().Equals("1"))
                        {
                            if (execNow.Date != BEGINEXEDATE.Date)
                            {
                                decimal dTMP_YL = decimal.Parse(TMP_YL);
                                decimal dTMED_DOSAGE = decimal.Parse(TMED_DOSAGE);
                                decimal ypsl = -1 * dTMP_YL * ettOrdExec.ISANALYZED * dTMED_DOSAGE;

                                XnKclEntity xn = new XnKclEntity();
                                xn.cjid = TMP_CJID;
                                xn.num = ypsl.ToString();
                                xn.dwbl = TMED_DWLX;
                                xn.execDeptId = TMED_EXEC_DEPT;
                                //UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//失败不处理
                                xnKcLists.Add(xn);
                            }
                        }

                        //Modify By Tany 2009-12-22  医嘱执行时是否限制库存量不足的药品不能发送 0=不是 1=是
                        if (_cfgList.cfg7059.Config.ToString().Equals("1"))
                        {
                            decimal ylKcl = decimal.Parse(TMP_KCL);
                            decimal dTMP_YL = decimal.Parse(TMP_YL);
                            decimal dTMED_DOSAGE = decimal.Parse(TMED_DOSAGE);
                            decimal thisYl = dTMP_YL * ettOrdExec.ISANALYZED * dTMED_DOSAGE;
                            if (thisYl > ylKcl)
                            {
                                //医嘱执行药品库存量不足时是否自动替换同规格不同厂家有库存的药品 0=不是 1=是
                                if (_cfgList.cfg7060.Config.ToString().Equals("1"))
                                {
                                    iOutPut = 1;//return
                                    iret = -1;
                                    strMsg = BED_NO + " 床病人 " + PAT_NAME + " 该种药品:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")的库存量为(" + ylKcl + ") 本次执行数量为(" + thisYl + ")，数量不够，不能执行！";
                                    return iOutPut;
                                }
                                else
                                {
                                    //wait 换药逻辑
                                }
                            }
                        }

                        //如果是本科室的药，判断是否直接记账
                        int TMP_CHARGE_BIT = GetMedChargeBit(TMED_EXEC_DEPT, TMED_MNGTYPE, TMED_JZ_FLAG);

                        OrderPrescEntity ettOrdPresc = new OrderPrescEntity();
                        ettOrdPresc.ID = PubStaticFun.NewGuid();
                        ettOrdPresc.INPATIENT_ID = _Binid;
                        ettOrdPresc.BABY_ID = _Babyid;
                        ettOrdPresc.BOOK_DATE = EXECBOOKDATE;
                        ettOrdPresc.BOOK_USER = EXEUSER;
                        ettOrdPresc.PRESC_NO = dCfh;//decimal(21,6)
                        ettOrdPresc.PRESC_DATE = execNow;
                        ettOrdPresc.SOURCE_ID = ettOrdExec.ID;
                        ettOrdPresc.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdPresc.TYPE = 1;//type=1：普通   type=2：附加费用
                        ettOrdPresc.DEPT_ID = long.Parse(TMED_DEPT_BR);
                        ettOrdPresc.EXECDEPT_ID = long.Parse(TMED_EXEC_DEPT);
                        ettOrdPresc.PRESC_DOC = long.Parse(TMED_ORDER_DOC);
                        ettOrdPresc.HDITEM_ID = long.Parse(TMED_HOITEM_ID);
                        ettOrdPresc.XMLY = int.Parse(TMED_XMLY);
                        ettOrdPresc.STATITEM_CODE = TMED_STATCODE;
                        ettOrdPresc.SUBCODE = TMED_ITEM_CODE;
                        ettOrdPresc.STANDARD = "";
                        ettOrdPresc.DOSAGE = int.Parse(TMED_DOSAGE);
                        ettOrdPresc.UNIT = TMP_UNIT;
                        ettOrdPresc.UNITRATE = int.Parse(TMP_YDWBL);
                        ettOrdPresc.PRICE = decimal.Parse(TMP_PRICE);
                        ettOrdPresc.AGIO = 1;
                        ettOrdPresc.NUM = decimal.Parse(TMP_YL) * ettOrdExec.ISANALYZED;
                        ettOrdPresc.CHARGE_BIT = TMP_CHARGE_BIT;
                        ettOrdPresc.JGBM = _JGBM;

                        prescLists.Add(ettOrdPresc);
                    }
                }

                #endregion

                #region"项目处方表ZY_PRESCRIPTION"

                if ((NTYPE > 3 || XMLY == 2) && HOITEMID > 0)
                {
                    foreach (OrderExecEntity ettOrdExec in execLists)
                    {
                        OrderEntity ettOrd = new OrderEntity();
                        bool bHasOrd = false;

                        foreach (OrderEntity thisOrder in _orderList)
                        {
                            if (ettOrdExec.ORDER_ID == thisOrder.ORDER_ID)
                            {
                                ettOrd = thisOrder;
                                bHasOrd = true;
                                break;
                            }
                        }

                        if (!bHasOrd)
                            throw new Exception("执行记录未找到对应的医嘱信息");

                        //出院转科、手术、说明不判断是否有记录插入
                        if (ettOrd.HOITEM_ID <= 0 || ettOrd.EXEC_DEPT <= 0)
                            continue;

                        OrderPrescEntity ettOrdPresc = new OrderPrescEntity();

                        DataTable dtExeDept = GetDeptJzInfo(ettOrd.EXEC_DEPT);

                        if (dtExeDept == null || dtExeDept.Rows.Count <= 0)
                        {

                            throw new Exception("未找到：" + ettOrd.EXEC_DEPT + " 该执行科室对应的科室信息");
                        }

                        string deptJzFlag = dtExeDept.Rows[0]["ISJZ"].ToString().Trim();
                        long ExecDeptJgbm = long.Parse(dtExeDept.Rows[0]["JGBM"].ToString().Trim());

                        DataTable dtXm = GetItemInfo(ettOrd.HOITEM_ID, ettOrd.EXEC_DEPT, ettOrd.JGBM, ExecDeptJgbm);

                        if (dtXm == null || dtXm.Rows.Count <= 0)
                        {
                            if (NTYPE == 0 || NTYPE == 7)
                            {
                                continue;
                            }

                            //计费医嘱未对应收费项目
                            throw new Exception("未找到：" + ettOrd.HOITEM_ID + " 该HOITEM_ID对应的费用信息");
                        }

                        ettOrdPresc.ID = PubStaticFun.NewGuid();
                        ettOrdPresc.SOURCE_ID = ettOrdExec.ID;
                        ettOrdPresc.INPATIENT_ID = _Binid;
                        ettOrdPresc.PRESC_NO = dCfh;//decimal(21,6)

                        ettOrdPresc.DEPT_ID = ettOrd.DEPT_BR;
                        ettOrdPresc.EXECDEPT_ID = ettOrd.EXEC_DEPT;

                        ettOrdPresc.HDITEM_ID = long.Parse(dtXm.Rows[0]["HDITEM_ID"].ToString().Trim());
                        ettOrdPresc.XMLY = ettOrd.XMLY;

                        ettOrdPresc.STATITEM_CODE = dtXm.Rows[0]["BIGITEMCODE"].ToString().Trim();

                        ettOrdPresc.TCID = long.Parse(dtXm.Rows[0]["TCID"].ToString().Trim());
                        ettOrdPresc.TC_FLAG = int.Parse(dtXm.Rows[0]["TC_FLAG"].ToString().Trim());

                        ettOrdPresc.PRESC_DATE = execNow;
                        ettOrdPresc.PRESC_DOC = ettOrd.ORDER_DOC;
                        ettOrdPresc.STANDARD = ettOrd.ORDER_SPEC;

                        ettOrdPresc.UNIT = dtXm.Rows[0]["UNIT"].ToString().Trim();
                        ettOrdPresc.UNITRATE = 1;

                        if (decimal.Parse(Convertor.IsNull(ettOrd.PRICE, "0")) == 0)
                        {
                            ettOrdPresc.PRICE = decimal.Parse(dtXm.Rows[0]["PRICE"].ToString().Trim());//为0则使用项目价格
                        }
                        else
                        {
                            ettOrdPresc.PRICE = ettOrd.PRICE;//医嘱价格不为0，使用医嘱价格
                        }
                        ettOrdPresc.AGIO = 1;

                        string thisNum = ettOrd.NUM.ToString();
                        if (MNGTYPE == 1 || MNGTYPE == 5)
                        {
                            thisNum = Convertor.IsNull(ettOrd.zsl, "-1").Equals("-1") ? ettOrd.NUM.ToString() : ettOrd.zsl.ToString();
                        }
                        decimal dNum = decimal.Parse(thisNum);
                        decimal xmNum = decimal.Parse(dtXm.Rows[0]["NUM"].ToString().Trim());
                        ettOrdPresc.NUM = xmNum * dNum * ettOrdExec.ISANALYZED;//项目数量*开单数量*执行频次
                        ettOrdPresc.DOSAGE = ettOrd.DOSAGE;
                        ettOrdPresc.BABY_ID = _Babyid;

                        ettOrdPresc.SUBCODE = ettOrd.ITEM_CODE;

                        //直接记账：1.本科记账  2.他科记账及他科jz_flag=1  3.医嘱Jz_flag 4.ntype<>5
                        ettOrdPresc.CHARGE_BIT = 0;
                        if (ettOrd.DEPT_ID == ettOrd.EXEC_DEPT || (ettOrd.DEPT_ID != ettOrd.EXEC_DEPT && deptJzFlag.Equals("1")) || ettOrd.JZ_FLAG == 1 || ettOrd.NTYPE != 5)
                        {
                            ettOrdPresc.CHARGE_BIT = 1;
                        }

                        ettOrdPresc.BOOK_DATE = EXECBOOKDATE;
                        ettOrdPresc.BOOK_USER = EXEUSER;
                        ettOrdPresc.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdPresc.TYPE = 1;//type=1：普通   type=2：附加费用
                        ettOrdPresc.JGBM = _JGBM;

                        prescLists.Add(ettOrdPresc);
                    }
                }

                #endregion

                #region"医嘱附加费用 wait"
                #endregion

                #region"药品费用处理[药品：费用条数同处方条数和执行条数]"

                //wait  参数7605的控制
                if (NTYPE <= 3 && NTYPE > 0 && XMLY == 1 && HOITEMID > 0 && EXEDEPT > 0)
                {
                    #region"药品的ZY_FEE_SPECI"

                    foreach (OrderPrescEntity ettOrdPresc in prescLists)
                    {
                        //普通费用 非附加费
                        if (ettOrdPresc.TYPE != 1)
                        {
                            continue;
                        }

                        //wait 
                        OrderEntity ettOrd = new OrderEntity();//待封装获取对应医嘱
                        OrderExecEntity ettOrdExec = new OrderExecEntity();//待封装获取对应执行记录

                        OrderFeeEntity ettOrdFee = new OrderFeeEntity();
                        ettOrdFee.ID = PubStaticFun.NewGuid();
                        ettOrdFee.INPATIENT_ID = _Binid;
                        ettOrdFee.BABY_ID = _Babyid;

                        ettOrdFee.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdFee.ORDEREXEC_ID = ettOrdPresc.SOURCE_ID;
                        ettOrdFee.PRESCRIPTION_ID = ettOrdPresc.ID;

                        ettOrdFee.PRESC_NO = ettOrdPresc.PRESC_NO;//decimal(21,6)
                        ettOrdFee.PRESC_DATE = ettOrdPresc.PRESC_DATE;
                        ettOrdFee.BOOK_DATE = ettOrdPresc.BOOK_DATE;
                        ettOrdFee.BOOK_USER = ettOrdPresc.BOOK_USER;
                        ettOrdFee.STATITEM_CODE = ettOrdPresc.STATITEM_CODE;
                        ettOrdFee.XMID = ettOrdPresc.HDITEM_ID;
                        ettOrdFee.XMLY = ettOrdPresc.XMLY;

                        ettOrdFee.ITEM_NAME = ettOrd.ORDER_CONTEXT;
                        ettOrdFee.SUBCODE = ettOrdPresc.SUBCODE;
                        ettOrdFee.UNIT = ettOrdPresc.UNIT;
                        ettOrdFee.UNITRATE = ettOrdPresc.UNITRATE;

                        ettOrdFee.COST_PRICE = ettOrdPresc.PRICE;
                        ettOrdFee.RETAIL_PRICE = ettOrdPresc.PRICE;
                        ettOrdFee.NUM = ettOrdPresc.NUM;
                        ettOrdFee.DOSAGE = ettOrdPresc.DOSAGE;

                        //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                        decimal dMoney = ettOrdPresc.PRICE * ettOrdPresc.NUM * ettOrdPresc.DOSAGE / ettOrdExec.ISANALYZED;
                        string strMoney = dMoney.ToString("0.00");
                        dMoney = decimal.Parse(strMoney);
                        ettOrdFee.SDVALUE = dMoney * ettOrdExec.ISANALYZED;
                        ettOrdFee.ACVALUE = ettOrdFee.SDVALUE;

                        ettOrdFee.AGIO = ettOrdPresc.AGIO;

                        ettOrdFee.CHARGE_BIT = ettOrdPresc.CHARGE_BIT;
                        ettOrdFee.CHARGE_DATE = null;
                        ettOrdFee.CHARGE_USER = null;
                        if (pvsBit == 1)
                        {
                            //pvs处理
                            TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                            int iDiff2 = tm2.Days;
                            if (iDiff2 >= 1)
                            {
                                ettOrdFee.CHARGE_BIT = 1;
                            }
                        }
                        if (ettOrdFee.CHARGE_BIT == 1)
                        {
                            //pvs处理
                            TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                            int iDiff2 = tm2.Days;

                            if (pvsBit == 0 || iDiff2 <= 0)
                            {
                                ettOrdFee.CHARGE_DATE = ettOrdPresc.BOOK_DATE;
                                ettOrdFee.CHARGE_USER = ettOrdPresc.BOOK_USER;
                            }
                        }

                        ettOrdFee.DELETE_BIT = 0;
                        ettOrdFee.CZ_FLAG = 0;
                        ettOrdFee.DISCHARGE_BIT = 0;

                        ettOrdFee.DOC_ID = ettOrdPresc.PRESC_DOC;
                        ettOrdFee.DEPT_ID = DEPTID;
                        ettOrdFee.DEPT_BR = DEPTBR;
                        ettOrdFee.EXECDEPT_ID = ettOrdPresc.EXECDEPT_ID;//--Modify by Tany 2015-04-20 执行科室还是跟随处方表，在处方表确定在哪个执行科室领药


                        DataTable dtYp = GetYpInfo(ettOrd.HOITEM_ID);

                        if (dtYp == null || dtYp.Rows.Count <= 0)
                        {
                            throw new Exception(ettOrd.HOITEM_ID + " 药品厂家典中未找到该药品信息");
                        }
                        ettOrdFee.TLFS = GetTlflInfo(ettOrd, ettOrdPresc, dtYp);

                        ettOrdFee.DEPT_LY = DEPTLY;
                        ettOrdFee.JGBM = _JGBM;
                        ettOrdFee.GG = dtYp.Rows[0]["S_YPGG"].ToString();
                        ettOrdFee.CJ = dtYp.Rows[0]["S_SCCJ"].ToString();

                        ettOrdFee.GCYS = GCYS;
                        ettOrdFee.ZFBL = decimal.Parse(Convertor.IsNull(ettOrd.zfbl, "1")).ToString();

                        ettOrdFee.FY_BIT = GetFyBit(ettOrdPresc);
                        ettOrdFee.pvs_xh = ettOrdExec.PVS_XH;

                        FeeLists.Add(ettOrdFee);

                    }

                    #endregion
                }

                #endregion

                #region"诊疗费用及附加医技逻辑处理[项目：费用条数已处方条数为基础处理套餐]"

                if ((NTYPE > 3 || XMLY == 2) && HOITEMID > 0)
                {
                    #region"项目的ZY_FEE_SPECI"

                    foreach (OrderPrescEntity ettOrdPresc in prescLists)
                    {
                        //普通费用 非附加费
                        if (ettOrdPresc.TYPE != 1)
                        {
                            continue;
                        }

                        //wait 
                        OrderEntity ettOrd = new OrderEntity();//待封装获取对应医嘱
                        OrderExecEntity ettOrdExec = new OrderExecEntity();//待封装获取对应执行记录

                        //本次执行的收费项目
                        DataTable dtXm = GetItemInfoToFee(ettOrd, ettOrdPresc);
                        if (dtXm == null || dtXm.Rows.Count <= 0)
                        {
                            throw new Exception(" 未获取到本次要执行的项目信息！ ");
                        }

                        string xmSTATITEM_CODE = "";
                        string xmITEM_NAME = "";
                        string xmSTD_CODE = "";
                        string xmITEM_UNIT = "";
                        string xmCOST_PRICE = "";
                        string xmRETAIL_PRICE = "";
                        string xmSUBITEM_ID = "";
                        string xmNUM = "";

                        decimal dSumAcVal = 0;
                        bool bCharged = false;

                        for (int iXm = 0; iXm < dtXm.Rows.Count; iXm++)
                        {
                            #region"ZY_FEE_SPECI"

                            OrderFeeEntity ettOrdFee = new OrderFeeEntity();

                            if (ettOrdPresc.TC_FLAG == 0 && ettOrdPresc.TCID < 0)
                            {
                                //非套餐单项收费信息
                                xmSTATITEM_CODE = dtXm.Rows[iXm]["STATITEM_CODE"].ToString();
                                xmITEM_NAME = dtXm.Rows[iXm]["ITEM_NAME"].ToString();
                                xmSTD_CODE = dtXm.Rows[iXm]["STD_CODE"].ToString();
                                xmITEM_UNIT = dtXm.Rows[iXm]["ITEM_UNIT"].ToString();


                                ettOrdFee.XMID = ettOrdPresc.HDITEM_ID;
                                ettOrdFee.COST_PRICE = ettOrdPresc.PRICE;
                                ettOrdFee.RETAIL_PRICE = ettOrdPresc.PRICE;
                                ettOrdFee.NUM = ettOrdPresc.NUM;

                                //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                decimal dMoney = ettOrdPresc.PRICE * ettOrdPresc.NUM / ettOrdExec.ISANALYZED;
                                string strMoney = dMoney.ToString("0.00");
                                dMoney = decimal.Parse(strMoney);
                                ettOrdFee.SDVALUE = dMoney * ettOrdExec.ISANALYZED;
                                ettOrdFee.ACVALUE = ettOrdFee.SDVALUE;
                            }
                            else if (ettOrdPresc.TC_FLAG == 1 && ettOrdPresc.TCID >= 0)
                            {
                                //套餐拆分后单项收费信息
                                xmSTATITEM_CODE = dtXm.Rows[iXm]["STATITEM_CODE"].ToString();
                                xmITEM_NAME = dtXm.Rows[iXm]["ITEM_NAME"].ToString();
                                xmSTD_CODE = dtXm.Rows[iXm]["STD_CODE"].ToString();
                                xmITEM_UNIT = dtXm.Rows[iXm]["ITEM_UNIT"].ToString();
                                xmCOST_PRICE = dtXm.Rows[iXm]["COST_PRICE"].ToString();
                                xmRETAIL_PRICE = dtXm.Rows[iXm]["RETAIL_PRICE"].ToString();
                                xmSUBITEM_ID = dtXm.Rows[iXm]["SUBITEM_ID"].ToString();
                                xmNUM = dtXm.Rows[iXm]["NUM"].ToString();

                                decimal dXmNum = decimal.Parse(xmNUM);
                                decimal dXmCOST_PRICE = decimal.Parse(xmCOST_PRICE);
                                decimal dXmRETAIL_PRICE = decimal.Parse(xmRETAIL_PRICE);

                                ettOrdFee.XMID = long.Parse(xmSUBITEM_ID);
                                ettOrdFee.COST_PRICE = dXmCOST_PRICE;
                                ettOrdFee.RETAIL_PRICE = dXmRETAIL_PRICE;
                                ettOrdFee.NUM = ettOrdPresc.NUM * dXmNum;

                                //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                ettOrdFee.SDVALUE = dXmCOST_PRICE * ettOrdPresc.NUM * dXmNum;
                                ettOrdFee.ACVALUE = dXmRETAIL_PRICE * ettOrdPresc.NUM * dXmNum;
                            }

                            ettOrdFee.ID = PubStaticFun.NewGuid();
                            ettOrdFee.INPATIENT_ID = _Binid;
                            ettOrdFee.BABY_ID = _Babyid;
                            ettOrdFee.ORDER_ID = ettOrd.ORDER_ID;
                            ettOrdFee.ORDEREXEC_ID = ettOrdPresc.SOURCE_ID;
                            ettOrdFee.PRESCRIPTION_ID = ettOrdPresc.ID;
                            ettOrdFee.PRESC_NO = ettOrdPresc.PRESC_NO;//decimal(21,6)
                            ettOrdFee.PRESC_DATE = ettOrdPresc.PRESC_DATE;
                            ettOrdFee.BOOK_DATE = ettOrdPresc.BOOK_DATE;
                            ettOrdFee.BOOK_USER = ettOrdPresc.BOOK_USER;

                            ettOrdFee.STATITEM_CODE = xmSTATITEM_CODE;
                            ettOrdFee.XMLY = ettOrdPresc.XMLY;
                            ettOrdFee.TCID = ettOrdPresc.TCID;
                            ettOrdFee.TC_FLAG = ettOrdPresc.TC_FLAG;

                            ettOrdFee.ITEM_NAME = xmITEM_NAME;
                            ettOrdFee.SUBCODE = xmSTD_CODE;
                            ettOrdFee.UNIT = xmITEM_UNIT;
                            ettOrdFee.UNITRATE = ettOrdPresc.UNITRATE;

                            ettOrdFee.DOSAGE = ettOrdPresc.DOSAGE;


                            ettOrdFee.AGIO = ettOrdPresc.AGIO;

                            bool bYjqr = false;
                            ettOrdFee.CHARGE_BIT = ettOrdPresc.CHARGE_BIT;
                            ettOrdFee.CHARGE_DATE = null;
                            ettOrdFee.CHARGE_USER = null;
                            if (ettOrdFee.CHARGE_BIT == 1)
                            {
                                ettOrdFee.CHARGE_DATE = ettOrdPresc.BOOK_DATE;
                                ettOrdFee.CHARGE_USER = ettOrdPresc.BOOK_USER;
                                bYjqr = true;

                                bCharged = true;
                            }

                            ettOrdFee.DELETE_BIT = 0;
                            ettOrdFee.CZ_FLAG = 0;
                            ettOrdFee.DISCHARGE_BIT = 0;

                            ettOrdFee.DOC_ID = ettOrdPresc.PRESC_DOC;
                            ettOrdFee.DEPT_ID = DEPTID;
                            ettOrdFee.DEPT_BR = DEPTBR;
                            ettOrdFee.EXECDEPT_ID = ettOrdPresc.EXECDEPT_ID;//--Modify by Tany 2015-04-20 执行科室还是跟随处方表，在处方表确定在哪个执行科室领药

                            ettOrdFee.DEPT_LY = DEPTLY;
                            ettOrdFee.JGBM = _JGBM;

                            ettOrdFee.GCYS = GCYS;
                            ettOrdFee.ZFBL = decimal.Parse(Convertor.IsNull(ettOrd.zfbl, "1")).ToString();

                            FeeLists.Add(ettOrdFee);

                            #endregion

                            dSumAcVal += ettOrdFee.ACVALUE;
                        }

                        //医技处理同处方数（套餐不需要拆分生成记录）
                        if (NTYPE == 5)
                        {
                            #region"医技申请"

                            //医技处理
                            YjZySqEntity yjsq = new YjZySqEntity();

                            yjsq.YJSQID = PubStaticFun.NewGuid();
                            yjsq.JGBM = _JGBM;
                            yjsq.BRXXID = new Guid(_dtPat.Rows[0]["patient_id"].ToString());//wait
                            yjsq.INPATIENT_ID = ettOrdExec.INPATIENT_ID;
                            yjsq.SQRQ = ettOrdPresc.PRESC_DATE;
                            yjsq.SQR = ettOrd.ORDER_DOC;
                            yjsq.SQKS = ettOrd.DEPT_ID;

                            yjsq.SQNR = ettOrd.ORDER_CONTEXT;
                            if (ettOrd.UNIT.ToUpper().Equals("U") || ettOrd.UNIT.ToUpper().Equals("ML"))
                            {
                                string charInfo = Get_ZY_CHGDECIMALTOCHAR(ettOrd.NUM);
                                yjsq.SQNR = ettOrd.ORDER_CONTEXT.Trim() + " " + charInfo + " " + ettOrd.UNIT;
                            }

                            yjsq.JE = dSumAcVal;
                            yjsq.LCZD = Convertor.IsNull(ettOrd.MEMO1, "");
                            yjsq.ZXKS = ettOrd.EXEC_DEPT;
                            yjsq.BSJC = "";
                            yjsq.BBMC = GetSampName(ettOrd.DWLX);
                            yjsq.ZYSX = "";
                            yjsq.BJJBZ = 0;
                            yjsq.YZID = ettOrd.ORDER_ID;
                            yjsq.YZXMID = ettOrd.HOITEM_ID;
                            yjsq.ZXR = EXEUSER;
                            yjsq.ZXSJ = DateManager.ServerDateTimeByDBType(_database);
                            yjsq.ZXID = ettOrdExec.ID;
                            yjsq.DJLX = GetDjly(ettOrd.HOITEM_ID);

                            yjsqLists.Add(yjsq);

                            #endregion

                            #region"医技确认"

                            if (bCharged)
                            {
                                YjZySqEntity yjqr = new YjZySqEntity();

                                yjqr.YJSQID = yjsq.YJSQID;
                                yjqr.ZXID = ettOrdExec.ID;
                                yjqr.YZID = ettOrd.ORDER_ID;
                                yjqr.JE = dSumAcVal;

                                yjqrLists.Add(yjqr);
                                //Guid YJ_EXEC_ID = ettOrdExec.ID;
                                //Guid YJ_APP_ID = yjsq.YJSQID;
                                //Guid YJ_ORDER_ID = ettOrd.ORDER_ID;
                                //decimal YJ_JE = yjsq.JE;

                                //Guid NEWYJSQID = Guid.Empty;
                                //int iSqRet = -1;
                                //string strSqMsg = "";
                                //yj_zysq_qrjl(YJ_ORDER_ID, YJ_EXEC_ID, YJ_APP_ID, YJ_JE, DEPTID, EXECBOOKDATE, EXEUSER, 1, EXECBOOKDATE, 0, "", out NEWYJSQID, out iSqRet, out strSqMsg, 0);
                                //if (iSqRet != 0)
                                //{
                                //    iOutPut = 1;//return
                                //    iret = -1;
                                //    strMsg = BED_NO + " 床病人 " + PAT_NAME + " 医技确费出错:" + strSqMsg;
                                //    return iOutPut;
                                //}
                            }

                            #endregion
                        }
                    }

                    #endregion
                }

                #endregion

                return iOutPut;
            }
            catch (Exception ex)
            {
                throw new Exception(execNow.ToString("yyyy-MM-dd") + " 执行该日医嘱时err：" + ex.Message);
            }
        }
     */

    #endregion
}
