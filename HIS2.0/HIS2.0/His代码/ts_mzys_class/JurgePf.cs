using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;

namespace ts_mzys_class
{
    [Serializable]
    public class ReturnInfo
    {
        private int _returnCode;
        private string _value;
        private string _reurnShowInfo;

        /// <summary>
        /// 返回的code
        /// </summary>
        public int ReturnCode
        {
            get { return _returnCode; }
            set { _returnCode = value; }
        }

        /// <summary>
        /// 返回的值
        /// </summary>
        public string ReturnValue
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// 返回的提示信息
        /// </summary>
        public string ReurnShowInfo
        {
            get { return _reurnShowInfo; }
            set { _reurnShowInfo = value; }
        }
    }

    public class JurgePf : IJurgeLd
    {
        TrasenClasses.DatabaseAccess.RelationalDatabase _Database;
        ReturnInfo returninnfo = new ReturnInfo();

        string _ybjklx = "4444";

        public JurgePf()
        {
            _Database = TrasenFrame.Forms.FrmMdiMain.Database;
        }

        public JurgePf(TrasenClasses.DatabaseAccess.RelationalDatabase Database)
        {
            _Database = Database;
        }

        #region IJurgeLd 成员

        /// <summary>
        /// 保存前调用
        /// </summary>
        /// <param name="strMzh">门诊号</param>
        /// <param name="strYblx">医保类型</param>
        /// <param name="iZf">1：自费   0：公费</param>
        /// <param name="strMsg">输出</param>
        /// <returns>false则MessageBox.Show    true则判断iZf为1：自费   0：公费</returns>
        public bool CanPubFeeByInp(string strMzh, string strYblx, out int iZf, out string strMsg)
        {
            strMsg = "";
            iZf = 1;//1：自费   0：公费

            int ldNumM = 0;
            int ldNumD = 0;
            decimal ldNumJe = 0M;
            decimal ldNumJeM = 0M;

            #region"校验该病人是否公费类型"
            //校验该病人是否公费类型
            string strValideSql = string.Format("select ybjklx from jc_yblx where id='{0}'", strYblx);

            string strYbjklx = _Database.GetDataResult(strValideSql).ToString().Trim();

            if (!strYbjklx.Equals(_ybjklx))
            {
                strMsg = "非公费病人";
                return true;//非公费病人，不走以下判断，自费
                //throw new Exception("该病人不是公费病人，请到门诊重新挂号");
            }
            #endregion

            #region"校验该病人是否存在唯一的有效联单"
            DateTime dtNow = DateManager.ServerDateTimeByDBType(_Database);
            string year = dtNow.Year + "";
            string month = dtNow.Month < 10 ? "0" + dtNow.Month : dtNow.Month + "";
            string day = dtNow.Day < 10 ? "0" + dtNow.Day : dtNow.Day + "";

            //校验该病人是否存在唯一的有效联单
            strValideSql = string.Format("select COUNT(1) as Num from gf_ghdj c  where c.zymzh='{0}' and c.sf_year='{1}' and c.sf_Month='{2}' and c.sf_day='{3}' and c.del_bit=0 and c.jsbz=0  ", strMzh, year, month, day);

            int Num = Convert.ToInt32(_Database.GetDataResult(strValideSql).ToString().Trim());

            if (Num == 0)
            {
                strMsg = "该公费病人不存在可用的未结算联单，如果继续需要自费，或者到挂号处注册联单信息后再操作";
                return false;
            }
            else if (Num > 1)
            {
                throw new Exception("该公费病人存在多张可用的未结算联单，请联系收费处关闭已结算的联单后再进行操作");
                //return false;
            }
            #endregion

            //取病人医疗证号
            strValideSql = string.Format("select yblx,ylzh from gf_ghdj c  where c.zymzh='{0}' and c.sf_year='{1}' and c.sf_Month='{2}' and c.sf_day='{3}' and c.del_bit=0 and c.jsbz=0  ", strMzh, year, month, day);

            DataTable dtYlzh = _Database.GetDataTable(strValideSql);

            if (dtYlzh == null || dtYlzh.Rows.Count <= 0)
            {
                throw new Exception("查询医疗证号出错，请重新操作");
                //return false;
            }

            string ylzh = dtYlzh.Rows[0]["ylzh"].ToString().Trim();//医疗证号
            strValideSql = string.Format("select MZ_DEL,cfsl_xz,cfslM_xz,je_xz,yje_xz from jc_gf_patrec where ylzh='{0}' and gflx='{1}' and del_bit=0 ", ylzh, strYblx);

            #region"校验该病人医疗证号是否存在，并且还校验是否关闭了门诊收费功能"
            //校验该病人医疗证号是否存在，并且还校验是否关闭了门诊收费功能
            DataTable dt = _Database.GetDataTable(strValideSql);
            if (dt == null)
            {
                throw new Exception("查找病人信息出现错误，请重新操作");
            }

            if (dt.Rows.Count <= 0)
            {
                strMsg = "该公费病人的 医疗证号 不存在，或者已经关闭收费，请联系医保办处理，否则继续则按照自费处理";
                return false;
            }
            else if (dt.Rows.Count > 1)
            {
                throw new Exception("该公费病人的 医疗证号 重复存在，请联系医保办处理后操作");
            }

            string MZ_DEL = dt.Rows[0]["MZ_DEL"].ToString().Trim();//门诊收费功能是否关闭

            if (MZ_DEL.Equals("1"))
            {
                strMsg = "该公费病人不存在可用的未结算联单，如果继续需要自费，或者到挂号处注册联单信息后再操作";
                return false;
            }
            #endregion

            ldNumM = int.Parse(dt.Rows[0]["cfslM_xz"].ToString().Trim());
            ldNumD = int.Parse(dt.Rows[0]["cfsl_xz"].ToString().Trim());
            ldNumJe = decimal.Parse(dt.Rows[0]["je_xz"].ToString().Trim());
            ldNumJeM = decimal.Parse(dt.Rows[0]["yje_xz"].ToString().Trim());

            #region"校验日联单数量"

            strValideSql = string.Format("select COUNT(1) as Num from gf_ghdj c  where c.ylzh='{0}' and c.sf_year='{1}' and c.sf_Month='{2}' and c.sf_day='{3}' and c.yblx='{4}' and c.del_bit=0  ", ylzh, year, month, day, strYblx);
            Num = Convert.ToInt32(_Database.GetDataResult(strValideSql).ToString().Trim());

            if (Num > ldNumD)
            {
                strMsg = "该公费病人日联单数超过" + ldNumD + "，如果继续需要自费";
                return false;
            }

            #endregion

            #region"校验月联单数量"

            strValideSql = string.Format("select COUNT(1) as Num from gf_ghdj c  where c.ylzh='{0}' and c.sf_year='{1}' and c.sf_Month='{2}' and c.yblx='{3}' and c.del_bit=0  ", ylzh, year, month, strYblx);
            Num = Convert.ToInt32(_Database.GetDataResult(strValideSql).ToString().Trim());

            if (Num > ldNumM)
            {
                strMsg = "该公费病人日联单数超过" + ldNumM + "，如果继续需要自费";
                return false;
            }

            #endregion

            #region"校验月联单总金额"

            strValideSql = string.Format(@" select ISNULL(b.zje,0) ZJE from gf_ghdj a 
                                             inner join gf_ld_info b on a.id=b.ghdjid and b.del_bit=0
                                             where a.yblx='{0}' and  a.ylzh='{1}' and  a.sf_year='{2}' and  a.sf_Month='{3}'   and a.del_bit=0  "
                                        , strYblx, ylzh, year, month);

            decimal dAllMFee = Convert.ToDecimal(_Database.GetDataResult(strValideSql).ToString().Trim());

            if (dAllMFee > ldNumJeM)
            {
                strMsg = "该公费病人本月该联单累计金额：" + dAllMFee + "大于限额设置" + ldNumJeM + "，如果继续则自费处方";
                return false;
            }

            #endregion

            #region"校验联单金额"

            string strSql = string.Format("select sfdlb,name,xe from jc_gf_dsflb where del_bit=0 ");

            DataTable dtSfdlb = _Database.GetDataTable(strSql);

            //公费病人有且仅有一个再用的有效的联单号
            strSql = string.Format(@"select b.JE,b.TJDXMDM,b.XMID,a.XMLY,e.sfdlb
                                        from MZ_HJB a 
                                        inner join MZ_HJB_MX b on a.HJID=b.HJID 
                                        inner join gf_ghdj c  on a.BLH=c.zymzh and a.ldh=c.ldh and c.del_bit=0 and c.jsbz=0 and c.sf_year='{1}' and c.sf_Month='{2}' and c.sf_day='{3}' 
                                        inner join gf_ld_info d  on c.id=d.ghdjid and d.del_bit=0
                                        inner join 
                                        (
                                        select a.xmid,a.xmly,c.sfdlb from jc_gf_sflbmx a 
                                        inner join jc_gf_sflb b on a.sflb=b.sflb and b.del_bit=0
                                        inner join jc_gf_ppdsflb c on a.sflb=c.sflb and c.del_bit=0
                                        where a.del_bit=0
                                        )e on a.XMLY=e.xmly and b.XMID=e.xmid
                                        where a.BLH='{0}' and a.BSCBZ=0", strMzh, year, month, day);

            DataTable dtCfFee = _Database.GetDataTable(strSql);

            //单项金额校验
            if (!DoCheckSingleFee(dtSfdlb, dtCfFee, out strMsg))
            {
                return false;
            }

            //联单总金额校验
            if (!DoCheckAllFee(dtCfFee, ldNumJe, out strMsg))
            {
                return false;
            }

            #endregion

            //校验完毕，可以公费
            iZf = 0;//公费
            return true;
        }

        /// <summary>
        /// 开医嘱调用
        /// </summary>
        /// <param name="xmid"></param>
        /// <param name="xmly"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public bool CanYpXmPf(int xmid, int xmly, string strYblx, out string strMsg)
        {

            strMsg = "";

            #region"校验该病人是否公费类型"
            //校验该病人是否公费类型
            string strValideSql = string.Format("select ybjklx from jc_yblx where id='{0}'", strYblx);

            string strYbjklx = _Database.GetDataResult(strValideSql).ToString().Trim();

            if (!strYbjklx.Equals(_ybjklx))
            {
                strMsg = "非公费病人";
                return true;//非公费病人，不走以下判断，自费
                //throw new Exception("该病人不是公费病人，请到门诊重新挂号");
            }
            #endregion

            //校验该病人是否公费类型
            strValideSql = string.Format("select COUNT(1) as Num from jc_gf_blmx where xmid='{0}' and xmly='{1}' and del_bit=0", xmid, xmly);

            int iNum = Convert.ToInt32(_Database.GetDataResult(strValideSql).ToString().Trim());

            if (iNum == 0)
            {
                strMsg = "本" + (xmly == 1 ? "药品" : "项目") + "不报销，是否自费继续";
                return false;//非公费病人，不走以下判断，自费
            }
            else if (iNum > 1)
            {
                throw new Exception("该项目已多次匹配，请联系医保办");
            }

            return true;
        }

        #endregion

        public bool DoCheckSingleFee(DataTable dtDlb, DataTable dtFee, out string strMsg)
        {
            strMsg = "";

            foreach (DataRow drDlb in dtDlb.Rows)
            {
                string strDlb = drDlb["sfdlb"].ToString().Trim();//收费大类别
                string name = drDlb["name"].ToString().Trim();//姓名
                string strXe = drDlb["xe"].ToString().Trim();//限额
                decimal xe = decimal.Parse(strXe);

                decimal dxhj = 0M;

                foreach (DataRow drFee in dtFee.Rows)
                {
                    if (drFee["sfdlb"].ToString().Trim().Equals(strDlb))
                    {
                        string strJe = drFee["Je"].ToString().Trim();//金额
                        decimal dJe = decimal.Parse(strJe);
                        dxhj += dJe;
                    }
                }

                //单项合计超额
                if (dxhj > xe)
                {
                    strMsg = name + "类别的累计金额：" + dxhj + "大于限额设置" + xe + "，如果继续则自费处方";
                    return false;
                }
            }

            return true;
        }

        public bool DoCheckAllFee(DataTable dtFee, decimal xeAll, out string strMsg)
        {
            strMsg = "";
            decimal dxhj = 0M;

            foreach (DataRow drFee in dtFee.Rows)
            {
                string strJe = drFee["Je"].ToString().Trim();//金额
                decimal dJe = decimal.Parse(strJe);
                dxhj += dJe;
            }

            //单项合计超额
            if (dxhj > xeAll)
            {
                strMsg = "该联单累计金额：" + dxhj + "大于限额设置" + xeAll + "，如果继续则自费处方";
                return false;
            }

            return true;
        }

        public static IJurgeLd GetInstance( TrasenClasses.DatabaseAccess.RelationalDatabase Database )
        {
            bool usjurge = true;
            if( usjurge )
                return (IJurgeLd)( new JurgePf( Database ) );
            else
                return (IJurgeLd)( new JurgeEmpty( ) );
        }
    }

    public class JurgeEmpty : IJurgeLd
    {
        #region IJurgeLd 成员

        public bool CanPubFeeByInp( string strMzh , string strYblx , out int iZf , out string strMsg )
        {
            iZf = -1;
            strMsg = "";
            return true;
        }

        public bool CanYpXmPf( int xmid , int xmly , string strYblx , out string strMsg )
        {
            strMsg = "";
            return true;
        }

        #endregion
    }

    public interface IJurgeLd
    {
        /// <summary>
        /// 保存处方前校验：病人月联单总金额是否超额、月联单数是否超过、日总额限制、日联单数、日药费额度、日治疗额度、日检查额度的限制
        /// </summary>
        /// <param name="strMzh"></param>
        /// <returns></returns>
        bool CanPubFeeByInp(string strMzh, string strYblx, out int iZf, out string strMsg);

        /// <summary>
        /// 开医嘱校验
        /// </summary>
        /// <param name="xmid"></param>
        /// <param name="xmly"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        bool CanYpXmPf(int xmid, int xmly, string strYblx, out string strMsg);

    }
}
