using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace TrasenHIS.BLL
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
    public class Judgeorder
    {
        TrasenClasses.DatabaseAccess.RelationalDatabase Database;
        public Judgeorder(TrasenClasses.DatabaseAccess.RelationalDatabase _Database)
        {
            Database = _Database;
        }
        public Judgeorder()
        {
            Database = TrasenFrame.Forms.FrmMdiMain.Database;
        }
        /// <summary>
        /// 获取病人比例
        /// </summary>
        /// <param name="zyh">住院号</param>
        /// <param name="xmly"></param>
        /// <param name="bm">hoitemid</param>
        /// <returns></returns>
        public ReturnInfo GetBl(string zyh, string xmly, string bm, string mc)
        {
            InstanceDb();
            string lb = GetLb(zyh);
            zyh = ConvertNo(zyh);
            int type = 0;
            if (lb != "" && lb != "自费")
            {

                if (lb.Contains("公费"))
                {
                    type = 1;
                    if (xmly == "1")
                    {
                        return gf_pu_getzyypsfbl(zyh, bm, mc);
                    }
                    else
                    {
                        return gf_pu_getzysfbl(zyh, bm, mc);
                    }
                }
                else
                {
                    type = 2;
                    int zfbl = 0;

                    // return ybnb_getbl(zyh, lb, bm, 0, ref zfbl, (xmly == "1" ? "YP" : "XM"));  原来代码

                    //新增加 农合病人的项目并入医保平台，药品目录不变 Add by HYD  2017-04-25
                    if (xmly.Equals("2") && lb.Contains("湖北省新农合转诊"))
                    {
                        return gf_pu_getzysfbl_SNH(zyh, bm, mc);
                    }
                    else
                    {
                        return ybnb_getbl(zyh, lb, bm, 0, ref zfbl, (xmly == "1" ? "YP" : "XM"));
                    }
                }
            }
            else
            {
                returninnfo.ReturnCode = 1;
                returninnfo.ReturnValue = "1";
                returninnfo.ReurnShowInfo = "";
            }
            returninnfo.ReturnCode = 1;
            returninnfo.ReturnValue = "1";
            returninnfo.ReurnShowInfo = "";
            return returninnfo;
        }

        /// <summary>
        /// 重新计算病人医嘱的自付比例
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool ReComputeRate(string inpatient_no)
        {
            try
            {
                string inpatient_id = "";
                DataTable tbinpatient = Database.GetDataTable("select * from zy_inpatient where inpatient_no='" + inpatient_no + "' and flag<>10");
                if (tbinpatient != null && tbinpatient.Rows.Count > 0)
                {
                    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                }
                else
                {
                    throw new Exception("未找到该住院号【" + inpatient_no + "】的病人信息！");
                }

                //查找所有有效的医嘱
                string sql = "select * from zy_orderrecord where inpatient_id='" + inpatient_id + "' and delete_bit=0 and ntype not in (0,7) and hoitem_id>0";//and status_flag<>5 Modify By Tany 2015-03-20 停了的也要转，因为冲账还会用到医嘱表比例
                DataTable orderTb = Database.GetDataTable(sql);

                if (orderTb == null || orderTb.Rows.Count == 0)
                    return true;

                string[] updateSql = new string[orderTb.Rows.Count];
                for (int i = 0; i < orderTb.Rows.Count; i++)
                {
                    ReturnInfo rInfo = new ReturnInfo();

                    rInfo = GetBl(inpatient_no, orderTb.Rows[i]["xmly"].ToString(), orderTb.Rows[i]["hoitem_id"].ToString(), orderTb.Rows[i]["order_context"].ToString());

                    if (Convert.ToInt16(rInfo.ReturnCode) <= 0)
                    {
                        //直接算作自费
                        rInfo.ReturnValue = "1";
                    }

                    double bl = Convert.ToDouble(rInfo.ReturnValue);

                    updateSql[i] = "update zy_orderrecord set zfbl=" + bl + " where order_id='" + orderTb.Rows[i]["order_id"].ToString() + "'";
                }

                Database.DoCommand(null, null, null, updateSql);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hrp扫描保存的医嘱发送时重新计算病人医嘱的自付比例  add by jchl 2016-09-07
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool ReComputeRate_HrpInfo(string inpatient_id, string inpatient_no)
        {
            try
            {
                //string inpatient_no = "";
                //DataTable tbinpatient = Database.GetDataTable("select * from zy_inpatient where inpatient_no='" + inpatient_no + "' and flag<>10");
                //if (tbinpatient != null && tbinpatient.Rows.Count > 0)
                //{
                //    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                //}
                //else
                //{
                //    throw new Exception("未找到该住院号【" + inpatient_no + "】的病人信息！");
                //}

                //查找所有有效的医嘱

                string sql = "select * from zy_orderrecord where inpatient_id='" + inpatient_id + "' and delete_bit=0 and ntype not in (0,7) and hoitem_id>0";//and status_flag<>5 Modify By Tany 2015-03-20 停了的也要转，因为冲账还会用到医嘱表比例

                sql = string.Format(@"select * from ZY_ORDERRECORD a  
                                        inner join zy_order_hrpInfo b on a.INPATIENT_ID=b.INPATIENT_ID and a.ORDER_ID=b.ORDER_ID
                                        where a.inpatient_id='{0}' and a.DELETE_BIT=0 and ntype not in (0,7) and hoitem_id>0 and a.STATUS_FLAG=0", inpatient_id);


                DataTable orderTb = Database.GetDataTable(sql);

                if (orderTb == null || orderTb.Rows.Count == 0)
                    return true;

                string[] updateSql = new string[orderTb.Rows.Count];
                for (int i = 0; i < orderTb.Rows.Count; i++)
                {
                    ReturnInfo rInfo = new ReturnInfo();

                    rInfo = GetBl(inpatient_no, orderTb.Rows[i]["xmly"].ToString(), orderTb.Rows[i]["hoitem_id"].ToString(), orderTb.Rows[i]["order_context"].ToString());

                    if (Convert.ToInt16(rInfo.ReturnCode) <= 0)
                    {
                        //直接算作自费
                        rInfo.ReturnValue = "1";
                    }

                    double bl = Convert.ToDouble(rInfo.ReturnValue);

                    updateSql[i] = "update zy_orderrecord set zfbl=" + bl + " where order_id='" + orderTb.Rows[i]["order_id"].ToString() + "'";
                }

                Database.DoCommand(null, null, null, updateSql);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static object lockob = new object();
        /// <summary>
        /// 单例化模式
        /// </summary>
        private static TrasenClasses.DatabaseAccess.RelationalDatabase InFomixDb;
        ReturnInfo returninnfo = new ReturnInfo();
        private static void InstanceDb()
        {
            if (InFomixDb == null)
            {
                lock (lockob)
                {
                    if (InFomixDb == null)
                        InFomixDb = TrasenHIS.DAL.BaseDal.GetDb_InFormix();
                }
            }

        }
        /// <summary>
        /// 获取公费类别
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        private ReturnInfo Getgflb(string zyh)
        {
            string str = @"select gflb  from zy_brjbxx where zyh='" + zyh + "'";
            object ob_gflb = InFomixDb.GetDataResult(str);
            if (ob_gflb == null)
            {
                returninnfo.ReturnCode = -2;
                returninnfo.ReurnShowInfo = "没有找到该病人的公费类别";

            }
            else
            {
                returninnfo.ReturnCode = 1;
                returninnfo.ReturnValue = ob_gflb.ToString();
            }
            return returninnfo;
        }
        /// <summary>
        /// 获得公费医疗药品比例
        /// </summary>
        /// <param name="zyh">住院号</param>
        /// <param name="ypbm">药品编码 cjid</param>
        /// <returns></returns>
        public ReturnInfo gf_pu_getzyypsfbl(string zyh, string ypbm, string mc)
        {
            //if (GetLb(zyh).Trim() == "自费")
            //{
            //    returninnfo.ReturnCode = -2;
            //    returninnfo.ReturnValue = "0";
            //    returninnfo.ReurnShowInfo = "返回";
            //    return returninnfo;
            //}
            InstanceDb();
            zyh = ConvertNo(zyh);
            bool isKbxm = false;
            ypbm = HisFunctions.GetOldHISXmYpBM("1", ypbm.ToString(), out isKbxm, Database);
            string ls_temp = "住院费用";
            string ls_gflb = "";
            string str = "";
            object ob_gflb;
            //获取公费类别
            returninnfo = Getgflb(zyh);
            if (returninnfo.ReturnCode <= 0)
                return returninnfo;
            else
                ob_gflb = returninnfo.ReturnValue;

            bool bSnh = ob_gflb.Equals("湖北省新农合转诊") || ob_gflb.Equals("待转农合(省新农合)");
            //Modify By Tany 2015-03-11 省医保额外判断
            //if (ob_gflb.ToString().Contains("省医保"))
            if (ob_gflb.ToString().Contains("省医保") || bSnh)
            {
                //Modify By Tany 2015-03-14 如果是捆绑项目，省医保的默认给1
                if (isKbxm)
                {
                    returninnfo.ReturnCode = 1;
                    returninnfo.ReturnValue = "1";//省医保的套餐默认给1 Modify By Tany 2015-02-04
                    returninnfo.ReurnShowInfo = "捆绑项目自付比例为0";
                    return returninnfo;
                }
                str = @"select * from sb_xmml where yybm='" + ypbm + "'";
                DataTable sybTb = InFomixDb.GetDataTable(str);
                if (sybTb == null || sybTb.Rows.Count <= 0)
                {
                    MessageBox.Show("该药品省医保没有做对应，不能使用！", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    returninnfo.ReturnCode = -1;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "";
                    return returninnfo;
                }
                else
                {
                    if (sybTb.Rows[0]["xmdj"].ToString().Trim() == "丙类")
                    {
                        if (MessageBox.Show("【" + ypbm + "|" + mc + "】该药品需要自费，是否确定使用？",
                           "特别提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                           == DialogResult.No)
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReturnValue = "-1";
                            returninnfo.ReurnShowInfo = "";
                            return returninnfo;
                        }
                    }
                }
                returninnfo.ReturnCode = 1;
                returninnfo.ReurnShowInfo = "获取数据成功！";
                returninnfo.ReturnValue = "1";
                return returninnfo;
            }

            //得到药品的收费比例
            object ob_bl;
            //str = "select bl from pu_gfbl where sflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_temp) + "' and gflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + "'";
            str = "select bl from pu_gfbl where sflb='" + ls_temp + "' and gflb='" + ob_gflb.ToString() + "'";
             
            ob_bl = InFomixDb.GetDataResult(str);

            //判断是否提示 Modify BY Tany 2015-10-30
            bool isTs = true;
            if (ls_temp == "住院费用" && Convert.ToDecimal(Convertor.IsNull(ob_bl, "0")) == 1)
            {
                isTs = false;
            }

            if (ob_bl == null)
            {
                returninnfo.ReturnCode = -2;
                returninnfo.ReurnShowInfo = "此公费类别没有收费比例可查！" + ls_temp + ";" + ob_gflb.ToString();
                return returninnfo;
            }
            else
            {
                //
                //                str = @"SELECT count(*)  FROM pu_yyfw_lbdzb,    pu_yyfw_ypdzb  
                //                   WHERE ( pu_yyfw_lbdzb.fwh = pu_yyfw_ypdzb.fwh ) and  
                //		           ( ( pu_yyfw_lbdzb.gflb ='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + @"' ) AND  
                //		            ( pu_yyfw_ypdzb.ypbm ='" + ypbm + @"' ) ) ";
                str = @"SELECT count(*)  FROM pu_yyfw_lbdzb,    pu_yyfw_ypdzb  
                   WHERE ( pu_yyfw_lbdzb.fwh = pu_yyfw_ypdzb.fwh ) and  
		           ( ( pu_yyfw_lbdzb.gflb ='" + ob_gflb.ToString() + @"' ) AND  
		            ( pu_yyfw_ypdzb.ypbm ='" + ypbm + @"' ) ) ";

                object ob_sfgf = InFomixDb.GetDataResult(str);

                if (ob_sfgf == null || decimal.Parse(ob_sfgf.ToString()) <= 0)
                {
                    returninnfo.ReturnCode = -2;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "该药品是自费药品或不在医保目录内，需经患者本人或家属签字同意！";//可以公费
                    return returninnfo;
                }
                else
                {
                    //if (TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString()) != "合约(长委)")
                    if (ob_gflb.ToString() != "合约(长委)")
                    {
                        returninnfo.ReturnCode = 1;
                        returninnfo.ReurnShowInfo = "获取数据成功！";
                        returninnfo.ReturnValue = ob_bl.ToString();
                    }
                    else
                    {
                        //如果是 合约(长委)，
                        if (decimal.Parse((ob_bl.ToString() == "" ? "1" : ob_bl.ToString())) == 1)
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReurnShowInfo = "该药品是自费药品或不在医保目录内，需经患者本人或家属签字同意！";
                            returninnfo.ReturnValue = ob_bl.ToString();
                        }
                        else
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReurnShowInfo = "获取数据成功！";
                            returninnfo.ReturnValue = ob_bl.ToString();
                        }
                    }

                    //ls_mshu = Trim(ls_mshu)
                    //SELECT fwh INTO :ls_fwh FROM pu_yyfw_lbdzb Where gflb = :is_gflb USING T_OLTP;
                    //SELECT bblb INTO :ls_bblb FROM pu_gflb Where gflb = :is_gflb USING T_OLTP;
                    //IF ls_fwh <> '' AND NOT IsNull(ls_fwh) And (ls_fwh = 'D' OR ls_fwh = 'E') THEN
                    //    IF pos(ls_mshu,'限') > 0 AND NOT IsNull(ls_mshu) and ls_mshu <> '△' AND ls_mshu <> '◇' THEN
                    //        li_zz = MessageBox("特别提示",ls_mshu+"~r~n该病人病情是否符合此范围?",Question!,YesNo!,1)
                    //        IF li_zz = 2 THEN
                    //            li_cc = MessageBox("补充提示","是否确认按自费使用", Question!, YesNo!,1)
                    //            IF li_cc = 1 THEN
                    //                zff = 1
                    //            ELSE
                    //                POST uf_reset(li_row)
                    //                dwc_dw.Reset()
                    //                RETURN 1
                    //            END IF
                    //        END IF
                    //    END IF
                    //END IF

                    //Add By Tany 2014-07-25 公费的要判断医保的限制
                    str = @" SELECT zfbl,sm,xzxz,mzxz  FROM yb_ybmlb  Where ybxmbm In (SELECT xmbm FROM yb_bmdzb Where yyxmbm ='" + ypbm + "')";
                    DataTable yb_ybmlb = InFomixDb.GetDataTable(str);
                    if (yb_ybmlb.Rows.Count <= 0)
                    {
                        //returninnfo.ReturnCode = -99;
                        //returninnfo.ReturnValue = "-1";
                        //returninnfo.ReurnShowInfo = "该药品或项目没有做对应，请联系医保办" + yb_ybmlb;
                        //return returninnfo;
                    }
                    else
                    {
                        string ls_sm = (yb_ybmlb.Rows[0]["sm"].ToString().Trim());
                        //string ls_xmss = TrasenHIS.DAL.BaseDal.GetEncodingString(yb_ybmlb.Rows[0]["sm"].ToString().Trim());
                        string ls_xmss = yb_ybmlb.Rows[0]["sm"].ToString().Trim();
                        //ls_mzxz = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(yb_ybmlb.Rows[0]["mzxz"].ToString().Trim());
                        string ls_mzxz = yb_ybmlb.Rows[0]["mzxz"].ToString().Trim();
                        //ls_xzxz = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(yb_ybmlb.Rows[0]["xzxz"].ToString().Trim());
                        string ls_xzxz = yb_ybmlb.Rows[0]["xzxz"].ToString().Trim();

                        decimal lr_xzfbl = decimal.Parse(yb_ybmlb.Rows[0]["zfbl"].ToString().Trim());

                        //if (as_fylb == "YP")
                        //{
                        #region
                        if (ls_xmss.IndexOf("限") >= 0
                              && ls_xmss.Trim() != ""
                              && ls_xmss != "△"
                              && ls_xmss != "◇ ")
                        {
                            //   if (MessageBox.Show(DAL.BaseDal.GetEncodingString(ls_sm) + "\r\n该病人病情是否符合此范围?",
                            //"特别提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            if (MessageBox.Show(ls_sm + "\r\n该病人病情是否符合此范围?",
                                 "特别提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                 == DialogResult.No)
                            {
                                if (MessageBox.Show("是否确认按自费使用",
                                   "补充提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                   == DialogResult.Yes)
                                {
                                    returninnfo.ReturnCode = 1;
                                    returninnfo.ReurnShowInfo = "获取数据成功！";
                                    returninnfo.ReturnValue = "1";
                                }
                                else
                                {
                                    returninnfo.ReturnCode = -1;
                                    returninnfo.ReturnValue = "-1";
                                    returninnfo.ReurnShowInfo = "";
                                    return returninnfo;
                                }
                            }
                        }
                        #endregion
                        //}
                    }
                    //return returninnfo;
                }
                double bl = Convert.ToDouble(ob_bl);
                //超过50%自费才提示 Modify By Tany 2014-07-25
                if (bl >= 0.5 && bl <= 1 && isTs)
                {
                    if (MessageBox.Show("【" + ypbm + "|" + mc + "】需要自付" + (bl * 100).ToString("#0.00") + "%,还需要吗?",
                       "自费提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                       == DialogResult.No)
                    {
                        returninnfo.ReturnCode = -1;
                        returninnfo.ReturnValue = "-1";
                        returninnfo.ReurnShowInfo = "";
                        return returninnfo;
                    }
                }
                return returninnfo;
            }
        }


        //public ReturnInfo Gf_ts(string zyh,string ypbm)
        //{
        //    object ob_gflb = null;
        //    //获取公费类别
        //    returninnfo = Getgflb(zyh);
        //    if (returninnfo.ReturnCode <= 0)
        //        return returninnfo;
        //    else
        //        ob_gflb = returninnfo.ReturnValue;
        //    if (TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString()) == "合约(长委)'")
        //    return returninnfo;
        //}

        /// <summary>
        /// 获取公费医疗项目比例
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="xmbm"></param>
        /// <returns></returns>
        public ReturnInfo gf_pu_getzysfbl(string zyh, string xmbm, string mc)
        {

            //if (GetLb(zyh).Trim() == "自费")
            //{
            //    returninnfo.ReturnCode = -2;
            //    returninnfo.ReturnValue = "0";
            //    returninnfo.ReurnShowInfo = "返回";
            //    return returninnfo;
            //}
            InstanceDb();
            zyh = ConvertNo(zyh);
            bool isKbxm = false;
            string hoitem_id = xmbm;
            xmbm = HisFunctions.GetOldHISXmYpBM("2", xmbm.ToString(), out isKbxm, Database);
            string sqlstr = "-1";
            string str = "";
            object ob_gflb;
            //获取公费类别
            returninnfo = Getgflb(zyh);
            if (returninnfo.ReturnCode < 0)
                return returninnfo;
            else
                ob_gflb = returninnfo.ReturnValue;

            //************* 捆绑项目拆分*************
            //Modify By Tany 2016-01-29
            if (isKbxm)
            {
                //Modify By Tany 2015-05-14 捆绑项目需要拆分来分析能不能报销，不能的话不允许用
                //Modify By Tany 2015-05-19 增加显示套餐子项目名称
                string tcSql = "select * from JC_TC_MX a inner join jc_hsitem c on a.SUBITEM_ID=c.ITEM_ID inner join JC_HOI_HDI b on a.MAINITEM_ID=b.HDITEM_ID and b.TC_FLAG>0 and b.hoitem_id=" + hoitem_id;
                DataTable tcTb = Database.GetDataTable(tcSql);
                for (int i = 0; i < tcTb.Rows.Count; i++)
                {
                    //又要从套餐拆分出的费用明细，转成任意一条医嘱ID
                    string tc_hoitemid = Convertor.IsNull((Database.GetDataResult("select hoitem_id from jc_hoi_hdi where tc_flag<=0 and hditem_id=" + tcTb.Rows[i]["SUBITEM_ID"].ToString())), "");
                    if (tc_hoitemid != "")
                    {
                        //调用本身，不会走
                        returninnfo = gf_pu_getzysfbl(zyh, tc_hoitemid, tcTb.Rows[i]["ITEM_NAME"].ToString().Trim());//(zyh, as_gflb, tc_hoitemid, as_zfbl, ref ad_zff, as_fylb, tcTb.Rows[i]["ITEM_NAME"].ToString().Trim()); //Modify By tany 2015-05-19 传入的名称为套餐内的子项目名称
                        if (returninnfo.ReturnCode == -99)
                        {
                            returninnfo.ReurnShowInfo = mc + "该套餐中有明细项目【" + tcTb.Rows[i]["ITEM_NAME"].ToString().Trim() + "】没有做对应，不能使用！请联系医保办做对应";
                            return returninnfo;
                        }
                        if (returninnfo.ReturnCode <= 0)
                        {
                            //returninnfo.ReturnCode = -99; Modify By Tany 2016-03-31 这里改成提醒，不拦截
                            returninnfo.ReurnShowInfo = mc + "该套餐中有明细项目【" + tcTb.Rows[i]["ITEM_NAME"].ToString().Trim() + "】需自费";
                            return returninnfo;
                        }
                    }
                    else
                    {
                        //如果拆开的项目没有做医嘱对应，不允许继续 Modify By Tany 2016-01-21
                        returninnfo.ReturnCode = -99;
                        returninnfo.ReturnValue = "-1";
                        returninnfo.ReurnShowInfo = mc + "该套餐中有明细项目【" + tcTb.Rows[i]["ITEM_NAME"].ToString().Trim() + "】没有做医嘱项目对应，不能使用！请将该收费项目做医嘱项目对应后再开立";
                        return returninnfo;
                    }
                }
            }
            //*************捆绑项目拆分*************

            bool bSnh = ob_gflb.Equals("湖北省新农合转诊") || ob_gflb.Equals("待转农合(省新农合)");
            //Modify By Tany 2015-03-11 省医保额外判断
            //string ybName=TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString());
            //if (ob_gflb.ToString().Contains("省医保"))
            if (ob_gflb.ToString().Contains("省医保") || bSnh)
            {
                //Modify By Tany 2015-03-14 如果是捆绑项目，省医保的默认给1
                if (isKbxm)
                {
                    returninnfo.ReturnCode = 1;
                    returninnfo.ReturnValue = "1";//省医保的套餐默认给1 Modify By Tany 2015-02-04
                    returninnfo.ReurnShowInfo = "捆绑项目自付比例为0";
                    return returninnfo;
                }
                str = @"select * from sb_xmml where yybm='" + xmbm + "'";
                DataTable sybTb = InFomixDb.GetDataTable(str);
                if (sybTb == null || sybTb.Rows.Count <= 0)
                {
                    MessageBox.Show("该项目省医保没有做对应，不能使用！", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    returninnfo.ReturnCode = -1;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "";
                    return returninnfo;
                }
                else
                {
                    if (sybTb.Rows[0]["xmdj"].ToString().Trim() == "丙类")
                    {
                        if (MessageBox.Show("【" + xmbm + "|" + mc + "】该项目需要自费，是否确定使用？",
                           "特别提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                           == DialogResult.No)
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReturnValue = "-1";
                            returninnfo.ReurnShowInfo = "";
                            return returninnfo;
                        }
                    }
                }
                returninnfo.ReturnCode = 1;
                returninnfo.ReurnShowInfo = "获取数据成功！";
                returninnfo.ReturnValue = "1";
                return returninnfo;
            }

            object ob_sfgf;

            // 一般的公费类别病人凡是开了特殊检查都要提示
            sqlstr = @"SELECT sflb,sfjg   FROM pu_sfxmzd WHERE xmbm ='" + xmbm + "'";
            DataTable tbsf1 = InFomixDb.GetDataTable(sqlstr);
            if (tbsf1.Rows.Count > 0)
            {
                string gflbstr = "特殊检查,安装人造器官,特殊材料";
                //公费类别=工伤，合作医疗，疑似公会桑，项目金额》=200时要提示

                //if (gflbstr.Contains(TrasenHIS.DAL.BaseDal.GetEncodingString(tbsf1.Rows[0]["sflb"].ToString())))
                if (tbsf1.Rows[0]["sflb"].ToString().Trim() != "" && gflbstr.Contains(tbsf1.Rows[0]["sflb"].ToString()))
                {
                    if (MessageBox.Show("【" + xmbm + "|" + mc + "】是否已经审批？",
                             "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                             == DialogResult.No)
                    {
                        returninnfo.ReturnCode = -1;
                        returninnfo.ReturnValue = "-1";
                        returninnfo.ReurnShowInfo = "";
                        return returninnfo;
                    }
                }
            }
            // 控制项目公费范围
            //if (TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString().Trim()) != "合约")
            if (ob_gflb.ToString().Trim() != "合约")
            {
                //                sqlstr = @"SELECT count(*)   FROM pu_xmfw_lbdzb, pu_xmfw_xmdzb WHERE (pu_xmfw_lbdzb.fwh = pu_xmfw_xmdzb.fwh ) 
                //               AND ((pu_xmfw_lbdzb.gflb ='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + @"') AND (pu_xmfw_xmdzb.xmbm ='" + xmbm + @"'))";
                sqlstr = @"SELECT count(*)   FROM pu_xmfw_lbdzb, pu_xmfw_xmdzb WHERE (pu_xmfw_lbdzb.fwh = pu_xmfw_xmdzb.fwh ) 
               AND ((pu_xmfw_lbdzb.gflb ='" + ob_gflb.ToString() + @"') AND (pu_xmfw_xmdzb.xmbm ='" + xmbm + @"'))";
                Logger.Instance().WriteLog(zyh + ":" + sqlstr);
                ob_sfgf = InFomixDb.GetDataResult(sqlstr);

                if (ob_sfgf == null || int.Parse(ob_sfgf.ToString()) <= 0)
                {
                    returninnfo.ReturnCode = -2;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "此项目不可以公费！";
                    return returninnfo;
                }
            }
            #region 特殊判断
            // if ((TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString().Trim()) == "合约(部分病种结算)"
            //|| TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString().Trim()) == "合约(长委)"))
            if ((ob_gflb.ToString().Trim() == "合约(部分病种结算)"
           || ob_gflb.ToString().Trim() == "合约(长委)"))
            {
                // 从项目收费字典中取出项目收费类别和收费价格.
                sqlstr = @"SELECT sflb,sfjg,xmmc   FROM pu_sfxmzd WHERE xmbm ='" + xmbm + "'";
                DataTable tbsf = InFomixDb.GetDataTable(sqlstr);
                if (!(tbsf.Rows.Count == 0 || tbsf.Rows[0]["sfjg"].ToString() != ""))
                {
                    string gflbstr = "特殊检查,安装人造器官,特殊材料";
                    //公费类别=工伤，合作医疗，疑似公会桑，项目金额》=200时要提示
                    if (decimal.Parse(tbsf.Rows[0]["sfjg"].ToString()) >= 200
                          &&
                          (
                        //gflbstr.Contains(TrasenHIS.DAL.BaseDal.GetEncodingString(tbsf.Rows[0]["sflb"].ToString()))
                            gflbstr.Contains(tbsf.Rows[0]["sflb"].ToString())
                          )
                        )
                    {

                        //if (MessageBox.Show(TrasenHIS.DAL.BaseDal.GetEncodingString(tbsf.Rows[0]["xmmc"].ToString()) + " 项目为大型项目检查，是否已经审批？",
                        //   "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        if (MessageBox.Show(tbsf.Rows[0]["xmmc"].ToString() + " 项目为大型项目检查，是否已经审批？",
                           "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                           == DialogResult.No)
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReturnValue = "-1";
                            returninnfo.ReurnShowInfo = "";
                            return returninnfo;
                        }
                        //returninnfo.ReturnCode = -1;
                        //returninnfo.ReturnValue = "";
                        //returninnfo.ReurnShowInfo = xmbm + "  项目为大型项目检查，是否已经审批？";
                        //return returninnfo;
                    }
                }
            }
            string gflbstring = "工伤,合作医疗,疑似工伤";
            //if (gflbstring.Contains(TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString().Trim())))
            if (gflbstring.Contains(ob_gflb.ToString().Trim()))
            {
                //--ybbmlx=3为公费
                string sqlgs = @" select zfbl,yyname from bmdyb where ybbmlx=3 and yycode ='" + xmbm + "'";
                DataTable bmdybtb = InFomixDb.GetDataTable(sqlgs);
                if (bmdybtb.Rows.Count > 0)
                {
                    if (double.Parse((bmdybtb.Rows[0]["zfbl"].ToString() == "" ? "-1" : bmdybtb.Rows[0]["zfbl"].ToString())) > 0.1)
                    {
                        //if (MessageBox.Show(TrasenHIS.DAL.BaseDal.GetEncodingString(bmdybtb.Rows[0]["yyname"].ToString()) + " 项目字付比例大于10%,是否经单位审批？",
                        //    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        if (MessageBox.Show(bmdybtb.Rows[0]["yyname"].ToString() + " 项目字付比例大于10%,是否经单位审批？",
                            "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.No)
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReturnValue = "-1";
                            returninnfo.ReurnShowInfo = "";
                            return returninnfo;
                        }

                    }
                }
            }
            #endregion
            #region 获取公费比例（项目）
            {
                string ls_sflb = "";
                decimal ld_sfjg;
                // 从项目收费字典中取出项目收费类别和收费价格.
                sqlstr = @"SELECT sflb,sfjg   FROM pu_sfxmzd WHERE xmbm ='" + xmbm + "'";
                DataTable tbsf = InFomixDb.GetDataTable(sqlstr);
                if (tbsf.Rows.Count <= 0)
                {
                    returninnfo.ReturnCode = -2;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "从项目收费字典中没有取到项目收费类别和收费价格.！";
                    return returninnfo;
                }
                else
                {
                    if (tbsf.Rows[0]["sflb"].ToString().Trim() == "")
                    {
                        //ls_sflb = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix("住院费用");
                        ls_sflb = "住院费用";
                    }
                    else
                    {
                        //ls_sflb = TrasenHIS.DAL.BaseDal.GetEncodingString(tbsf.Rows[0]["sflb"].ToString().Trim());
                        ls_sflb = tbsf.Rows[0]["sflb"].ToString().Trim();
                    }
                    ld_sfjg = decimal.Parse(tbsf.Rows[0]["sfjg"].ToString().Trim() == "" ? "" : tbsf.Rows[0]["sfjg"].ToString().Trim());
                }
                //sqlstr = " select * from pu_gfblbc where sflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_sflb) + "' and gflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + "'  order by jgxz desc";
                sqlstr = " select * from pu_gfblbc where sflb='" + ls_sflb + "' and gflb='" + ob_gflb.ToString() + "'  order by jgxz desc";
                DataTable gfblbc_tb = InFomixDb.GetDataTable(sqlstr);
                decimal ld_jgxz;
                decimal lr_sfbll;
                decimal lr_bl;
                for (int i = 0; i < gfblbc_tb.Rows.Count; i++)
                {
                    ld_jgxz = decimal.Parse(gfblbc_tb.Rows[i]["jgxz"].ToString() == "" ? "-1" : gfblbc_tb.Rows[i]["jgxz"].ToString());
                    lr_sfbll = decimal.Parse(gfblbc_tb.Rows[i]["bl"].ToString() == "" ? "-1" : gfblbc_tb.Rows[i]["bl"].ToString());
                    if (ld_jgxz == -1)
                    {
                    }
                    else
                    {
                        //如果有价格限制
                        if (ld_sfjg >= ld_jgxz)
                        {
                            decimal sfbl = Convert.ToDecimal(lr_sfbll.ToString());
                            if (sfbl > 0 && sfbl <= 1)
                            {
                                if (MessageBox.Show("【" + xmbm + "|" + mc + "】需要自付" + (sfbl * 100).ToString("#0.00") + "%,还需要吗?",
                                   "自费提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                   == DialogResult.No)
                                {
                                    returninnfo.ReturnCode = -1;
                                    returninnfo.ReturnValue = "-1";
                                    returninnfo.ReurnShowInfo = "";
                                    return returninnfo;
                                }
                            }
                            returninnfo.ReturnCode = 1;
                            returninnfo.ReturnValue = lr_sfbll.ToString();
                            returninnfo.ReurnShowInfo = "获取成功";
                            return returninnfo;
                        }

                    }
                }
                // 如果公费比例补充表有价格限制,但不满足条件则收取住院费用
                if (gfblbc_tb.Rows.Count > 0)
                {
                    ls_sflb = "住院费用";
                }
                #region//如果跳出了循环，说明没有找到价格限制
                //如果价格限制为空
                //sqlstr = "SELECT bl   FROM pu_gfbl WHERE sflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_sflb) + "' and gflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + "' ";
                sqlstr = "SELECT bl   FROM pu_gfbl WHERE sflb='" + ls_sflb + "' and gflb='" + ob_gflb.ToString() + "' ";
                DataTable gfbl_tb = InFomixDb.GetDataTable(sqlstr);
                Logger.Instance().WriteLog(zyh + ":" + sqlstr);
                if (gfbl_tb.Rows.Count <= 0)
                {
                    //如果没有公费限制
                    // 如果公费比例表没有价格限制,
                    // 且是个公费病人,则收取门诊费用.
                    //if (TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString()) != "自费" || ob_gflb.ToString() != "")
                    if (ob_gflb.ToString() != "自费" || ob_gflb.ToString() != "")
                    {
                        //ls_sflb = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix("住院费用");
                        ls_sflb = "住院费用";
                        //sqlstr = "SELECT bl   FROM pu_gfbl WHERE sflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_sflb) + "' and gflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + "' ";
                        sqlstr = "SELECT bl   FROM pu_gfbl WHERE sflb='" + ls_sflb + "' and gflb='" + ob_gflb.ToString() + "' ";
                        gfbl_tb = InFomixDb.GetDataTable(sqlstr);
                        if (gfbl_tb.Rows.Count <= 0 || gfbl_tb.Rows[0]["bl"].ToString() == "")
                        {
                            returninnfo.ReturnCode = 1;
                            returninnfo.ReturnValue = "1";
                        }
                        else
                        {
                            returninnfo.ReturnCode = 1;
                            returninnfo.ReturnValue = gfbl_tb.Rows[0]["bl"].ToString();
                        }
                    }
                    else
                    {
                        returninnfo.ReturnCode = 1;
                        returninnfo.ReturnValue = "1";
                    }

                }
                else
                {
                    returninnfo.ReturnCode = 1;
                    returninnfo.ReturnValue = gfbl_tb.Rows[0]["bl"].ToString();
                    returninnfo.ReurnShowInfo = "获取成功";
                    //return returninnfo;
                }
                #endregion
            }
            #endregion

            decimal bl = Convert.ToDecimal(returninnfo.ReturnValue);
            if (bl > 0 && bl <= 1)
            {
                if (MessageBox.Show("【" + xmbm + "|" + mc + "】需要自付" + (bl * 100).ToString("#0.00") + "%,还需要吗?",
                   "自费提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.No)
                {
                    returninnfo.ReturnCode = -1;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "";
                    return returninnfo;
                }
            }

            return returninnfo;
        }


        /// <summary>
        /// 获取公费医疗项目比例
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="xmbm"></param>
        /// <returns></returns>
        public ReturnInfo gf_pu_getzysfbl_SNH(string zyh, string xmbm, string mc)
        {

            //if (GetLb(zyh).Trim() == "自费")
            //{
            //    returninnfo.ReturnCode = -2;
            //    returninnfo.ReturnValue = "0";
            //    returninnfo.ReurnShowInfo = "返回";
            //    return returninnfo;
            //}
            InstanceDb();
            zyh = ConvertNo(zyh);
            bool isKbxm = false;
            string hoitem_id = xmbm;
            xmbm = HisFunctions.GetOldHISXmYpBM("2", xmbm.ToString(), out isKbxm, Database);
            string sqlstr = "-1";
            string str = "";
            object ob_gflb;

            //获取公费类别
            /*  returninnfo = Getgflb(zyh);
              if (returninnfo.ReturnCode < 0)
                  return returninnfo;
              else
                  ob_gflb = returninnfo.ReturnValue;
             */

            //写死类别
            returninnfo.ReturnCode = 1;
            returninnfo.ReturnValue = "省医保";
            ob_gflb = returninnfo.ReturnValue;

            //************* 捆绑项目拆分*************
            //Modify By Tany 2016-01-29
            if (isKbxm)
            {
                //Modify By Tany 2015-05-14 捆绑项目需要拆分来分析能不能报销，不能的话不允许用
                //Modify By Tany 2015-05-19 增加显示套餐子项目名称
                string tcSql = "select * from JC_TC_MX a inner join jc_hsitem c on a.SUBITEM_ID=c.ITEM_ID inner join JC_HOI_HDI b on a.MAINITEM_ID=b.HDITEM_ID and b.TC_FLAG>0 and b.hoitem_id=" + hoitem_id;
                DataTable tcTb = Database.GetDataTable(tcSql);
                for (int i = 0; i < tcTb.Rows.Count; i++)
                {
                    //又要从套餐拆分出的费用明细，转成任意一条医嘱ID
                    string tc_hoitemid = Convertor.IsNull((Database.GetDataResult("select hoitem_id from jc_hoi_hdi where tc_flag<=0 and hditem_id=" + tcTb.Rows[i]["SUBITEM_ID"].ToString())), "");
                    if (tc_hoitemid != "")
                    {
                        //调用本身，不会走
                        returninnfo = gf_pu_getzysfbl(zyh, tc_hoitemid, tcTb.Rows[i]["ITEM_NAME"].ToString().Trim());//(zyh, as_gflb, tc_hoitemid, as_zfbl, ref ad_zff, as_fylb, tcTb.Rows[i]["ITEM_NAME"].ToString().Trim()); //Modify By tany 2015-05-19 传入的名称为套餐内的子项目名称
                        if (returninnfo.ReturnCode == -99)
                        {
                            returninnfo.ReurnShowInfo = mc + "该套餐中有明细项目【" + tcTb.Rows[i]["ITEM_NAME"].ToString().Trim() + "】没有做对应，不能使用！请联系医保办做对应";
                            return returninnfo;
                        }
                        if (returninnfo.ReturnCode <= 0)
                        {
                            //returninnfo.ReturnCode = -99; Modify By Tany 2016-03-31 这里改成提醒，不拦截
                            returninnfo.ReurnShowInfo = mc + "该套餐中有明细项目【" + tcTb.Rows[i]["ITEM_NAME"].ToString().Trim() + "】需自费";
                            return returninnfo;
                        }
                    }
                    else
                    {
                        //如果拆开的项目没有做医嘱对应，不允许继续 Modify By Tany 2016-01-21
                        returninnfo.ReturnCode = -99;
                        returninnfo.ReturnValue = "-1";
                        returninnfo.ReurnShowInfo = mc + "该套餐中有明细项目【" + tcTb.Rows[i]["ITEM_NAME"].ToString().Trim() + "】没有做医嘱项目对应，不能使用！请将该收费项目做医嘱项目对应后再开立";
                        return returninnfo;
                    }
                }
            }
            //*************捆绑项目拆分*************

            //Modify By Tany 2015-03-11 省医保额外判断
            //string ybName=TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString());
            if (ob_gflb.ToString().Contains("省医保"))
            {
                //Modify By Tany 2015-03-14 如果是捆绑项目，省医保的默认给1
                if (isKbxm)
                {
                    returninnfo.ReturnCode = 1;
                    returninnfo.ReturnValue = "1";//省医保的套餐默认给1 Modify By Tany 2015-02-04
                    returninnfo.ReurnShowInfo = "捆绑项目自付比例为0";
                    return returninnfo;
                }
                str = @"select * from sb_xmml where yybm='" + xmbm + "'";
                DataTable sybTb = InFomixDb.GetDataTable(str);
                if (sybTb == null || sybTb.Rows.Count <= 0)
                {
                    MessageBox.Show("该项目省医保没有做对应，不能使用！", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    returninnfo.ReturnCode = -1;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "";
                    return returninnfo;
                }
                else
                {
                    if (sybTb.Rows[0]["xmdj"].ToString().Trim() == "丙类")
                    {
                        if (MessageBox.Show("【" + xmbm + "|" + mc + "】该项目需要自费，是否确定使用？",
                           "特别提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                           == DialogResult.No)
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReturnValue = "-1";
                            returninnfo.ReurnShowInfo = "";
                            return returninnfo;
                        }
                    }
                }
                returninnfo.ReturnCode = 1;
                returninnfo.ReurnShowInfo = "获取数据成功！";
                returninnfo.ReturnValue = "1";
                return returninnfo;
            }

            object ob_sfgf;

            // 一般的公费类别病人凡是开了特殊检查都要提示
            sqlstr = @"SELECT sflb,sfjg   FROM pu_sfxmzd WHERE xmbm ='" + xmbm + "'";
            DataTable tbsf1 = InFomixDb.GetDataTable(sqlstr);
            if (tbsf1.Rows.Count > 0)
            {
                string gflbstr = "特殊检查,安装人造器官,特殊材料";
                //公费类别=工伤，合作医疗，疑似公会桑，项目金额》=200时要提示

                //if (gflbstr.Contains(TrasenHIS.DAL.BaseDal.GetEncodingString(tbsf1.Rows[0]["sflb"].ToString())))
                if (tbsf1.Rows[0]["sflb"].ToString().Trim() != "" && gflbstr.Contains(tbsf1.Rows[0]["sflb"].ToString()))
                {
                    if (MessageBox.Show("【" + xmbm + "|" + mc + "】是否已经审批？",
                             "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                             == DialogResult.No)
                    {
                        returninnfo.ReturnCode = -1;
                        returninnfo.ReturnValue = "-1";
                        returninnfo.ReurnShowInfo = "";
                        return returninnfo;
                    }
                }
            }
            // 控制项目公费范围
            //if (TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString().Trim()) != "合约")
            if (ob_gflb.ToString().Trim() != "合约")
            {
                //                sqlstr = @"SELECT count(*)   FROM pu_xmfw_lbdzb, pu_xmfw_xmdzb WHERE (pu_xmfw_lbdzb.fwh = pu_xmfw_xmdzb.fwh ) 
                //               AND ((pu_xmfw_lbdzb.gflb ='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + @"') AND (pu_xmfw_xmdzb.xmbm ='" + xmbm + @"'))";
                sqlstr = @"SELECT count(*)   FROM pu_xmfw_lbdzb, pu_xmfw_xmdzb WHERE (pu_xmfw_lbdzb.fwh = pu_xmfw_xmdzb.fwh ) 
               AND ((pu_xmfw_lbdzb.gflb ='" + ob_gflb.ToString() + @"') AND (pu_xmfw_xmdzb.xmbm ='" + xmbm + @"'))";
                Logger.Instance().WriteLog(zyh + ":" + sqlstr);
                ob_sfgf = InFomixDb.GetDataResult(sqlstr);

                if (ob_sfgf == null || int.Parse(ob_sfgf.ToString()) <= 0)
                {
                    returninnfo.ReturnCode = -2;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "此项目不可以公费！";
                    return returninnfo;
                }
            }
            #region 特殊判断
            // if ((TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString().Trim()) == "合约(部分病种结算)"
            //|| TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString().Trim()) == "合约(长委)"))
            if ((ob_gflb.ToString().Trim() == "合约(部分病种结算)"
           || ob_gflb.ToString().Trim() == "合约(长委)"))
            {
                // 从项目收费字典中取出项目收费类别和收费价格.
                sqlstr = @"SELECT sflb,sfjg,xmmc   FROM pu_sfxmzd WHERE xmbm ='" + xmbm + "'";
                DataTable tbsf = InFomixDb.GetDataTable(sqlstr);
                if (!(tbsf.Rows.Count == 0 || tbsf.Rows[0]["sfjg"].ToString() != ""))
                {
                    string gflbstr = "特殊检查,安装人造器官,特殊材料";
                    //公费类别=工伤，合作医疗，疑似公会桑，项目金额》=200时要提示
                    if (decimal.Parse(tbsf.Rows[0]["sfjg"].ToString()) >= 200
                          &&
                          (
                        //gflbstr.Contains(TrasenHIS.DAL.BaseDal.GetEncodingString(tbsf.Rows[0]["sflb"].ToString()))
                            gflbstr.Contains(tbsf.Rows[0]["sflb"].ToString())
                          )
                        )
                    {

                        //if (MessageBox.Show(TrasenHIS.DAL.BaseDal.GetEncodingString(tbsf.Rows[0]["xmmc"].ToString()) + " 项目为大型项目检查，是否已经审批？",
                        //   "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        if (MessageBox.Show(tbsf.Rows[0]["xmmc"].ToString() + " 项目为大型项目检查，是否已经审批？",
                           "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                           == DialogResult.No)
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReturnValue = "-1";
                            returninnfo.ReurnShowInfo = "";
                            return returninnfo;
                        }
                        //returninnfo.ReturnCode = -1;
                        //returninnfo.ReturnValue = "";
                        //returninnfo.ReurnShowInfo = xmbm + "  项目为大型项目检查，是否已经审批？";
                        //return returninnfo;
                    }
                }
            }
            string gflbstring = "工伤,合作医疗,疑似工伤";
            //if (gflbstring.Contains(TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString().Trim())))
            if (gflbstring.Contains(ob_gflb.ToString().Trim()))
            {
                //--ybbmlx=3为公费
                string sqlgs = @" select zfbl,yyname from bmdyb where ybbmlx=3 and yycode ='" + xmbm + "'";
                DataTable bmdybtb = InFomixDb.GetDataTable(sqlgs);
                if (bmdybtb.Rows.Count > 0)
                {
                    if (double.Parse((bmdybtb.Rows[0]["zfbl"].ToString() == "" ? "-1" : bmdybtb.Rows[0]["zfbl"].ToString())) > 0.1)
                    {
                        //if (MessageBox.Show(TrasenHIS.DAL.BaseDal.GetEncodingString(bmdybtb.Rows[0]["yyname"].ToString()) + " 项目字付比例大于10%,是否经单位审批？",
                        //    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        if (MessageBox.Show(bmdybtb.Rows[0]["yyname"].ToString() + " 项目字付比例大于10%,是否经单位审批？",
                            "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.No)
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReturnValue = "-1";
                            returninnfo.ReurnShowInfo = "";
                            return returninnfo;
                        }

                    }
                }
            }
            #endregion
            #region 获取公费比例（项目）
            {
                string ls_sflb = "";
                decimal ld_sfjg;
                // 从项目收费字典中取出项目收费类别和收费价格.
                sqlstr = @"SELECT sflb,sfjg   FROM pu_sfxmzd WHERE xmbm ='" + xmbm + "'";
                DataTable tbsf = InFomixDb.GetDataTable(sqlstr);
                if (tbsf.Rows.Count <= 0)
                {
                    returninnfo.ReturnCode = -2;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "从项目收费字典中没有取到项目收费类别和收费价格.！";
                    return returninnfo;
                }
                else
                {
                    if (tbsf.Rows[0]["sflb"].ToString().Trim() == "")
                    {
                        //ls_sflb = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix("住院费用");
                        ls_sflb = "住院费用";
                    }
                    else
                    {
                        //ls_sflb = TrasenHIS.DAL.BaseDal.GetEncodingString(tbsf.Rows[0]["sflb"].ToString().Trim());
                        ls_sflb = tbsf.Rows[0]["sflb"].ToString().Trim();
                    }
                    ld_sfjg = decimal.Parse(tbsf.Rows[0]["sfjg"].ToString().Trim() == "" ? "" : tbsf.Rows[0]["sfjg"].ToString().Trim());
                }
                //sqlstr = " select * from pu_gfblbc where sflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_sflb) + "' and gflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + "'  order by jgxz desc";
                sqlstr = " select * from pu_gfblbc where sflb='" + ls_sflb + "' and gflb='" + ob_gflb.ToString() + "'  order by jgxz desc";
                DataTable gfblbc_tb = InFomixDb.GetDataTable(sqlstr);
                decimal ld_jgxz;
                decimal lr_sfbll;
                decimal lr_bl;
                for (int i = 0; i < gfblbc_tb.Rows.Count; i++)
                {
                    ld_jgxz = decimal.Parse(gfblbc_tb.Rows[i]["jgxz"].ToString() == "" ? "-1" : gfblbc_tb.Rows[i]["jgxz"].ToString());
                    lr_sfbll = decimal.Parse(gfblbc_tb.Rows[i]["bl"].ToString() == "" ? "-1" : gfblbc_tb.Rows[i]["bl"].ToString());
                    if (ld_jgxz == -1)
                    {
                    }
                    else
                    {
                        //如果有价格限制
                        if (ld_sfjg >= ld_jgxz)
                        {
                            decimal sfbl = Convert.ToDecimal(lr_sfbll.ToString());
                            if (sfbl > 0 && sfbl <= 1)
                            {
                                if (MessageBox.Show("【" + xmbm + "|" + mc + "】需要自付" + (sfbl * 100).ToString("#0.00") + "%,还需要吗?",
                                   "自费提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                   == DialogResult.No)
                                {
                                    returninnfo.ReturnCode = -1;
                                    returninnfo.ReturnValue = "-1";
                                    returninnfo.ReurnShowInfo = "";
                                    return returninnfo;
                                }
                            }
                            returninnfo.ReturnCode = 1;
                            returninnfo.ReturnValue = lr_sfbll.ToString();
                            returninnfo.ReurnShowInfo = "获取成功";
                            return returninnfo;
                        }

                    }
                }
                // 如果公费比例补充表有价格限制,但不满足条件则收取住院费用
                if (gfblbc_tb.Rows.Count > 0)
                {
                    ls_sflb = "住院费用";
                }
                #region//如果跳出了循环，说明没有找到价格限制
                //如果价格限制为空
                //sqlstr = "SELECT bl   FROM pu_gfbl WHERE sflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_sflb) + "' and gflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + "' ";
                sqlstr = "SELECT bl   FROM pu_gfbl WHERE sflb='" + ls_sflb + "' and gflb='" + ob_gflb.ToString() + "' ";
                DataTable gfbl_tb = InFomixDb.GetDataTable(sqlstr);
                Logger.Instance().WriteLog(zyh + ":" + sqlstr);
                if (gfbl_tb.Rows.Count <= 0)
                {
                    //如果没有公费限制
                    // 如果公费比例表没有价格限制,
                    // 且是个公费病人,则收取门诊费用.
                    //if (TrasenHIS.DAL.BaseDal.GetEncodingString(ob_gflb.ToString()) != "自费" || ob_gflb.ToString() != "")
                    if (ob_gflb.ToString() != "自费" || ob_gflb.ToString() != "")
                    {
                        //ls_sflb = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix("住院费用");
                        ls_sflb = "住院费用";
                        //sqlstr = "SELECT bl   FROM pu_gfbl WHERE sflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_sflb) + "' and gflb='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ob_gflb.ToString()) + "' ";
                        sqlstr = "SELECT bl   FROM pu_gfbl WHERE sflb='" + ls_sflb + "' and gflb='" + ob_gflb.ToString() + "' ";
                        gfbl_tb = InFomixDb.GetDataTable(sqlstr);
                        if (gfbl_tb.Rows.Count <= 0 || gfbl_tb.Rows[0]["bl"].ToString() == "")
                        {
                            returninnfo.ReturnCode = 1;
                            returninnfo.ReturnValue = "1";
                        }
                        else
                        {
                            returninnfo.ReturnCode = 1;
                            returninnfo.ReturnValue = gfbl_tb.Rows[0]["bl"].ToString();
                        }
                    }
                    else
                    {
                        returninnfo.ReturnCode = 1;
                        returninnfo.ReturnValue = "1";
                    }

                }
                else
                {
                    returninnfo.ReturnCode = 1;
                    returninnfo.ReturnValue = gfbl_tb.Rows[0]["bl"].ToString();
                    returninnfo.ReurnShowInfo = "获取成功";
                    //return returninnfo;
                }
                #endregion
            }
            #endregion

            decimal bl = Convert.ToDecimal(returninnfo.ReturnValue);
            if (bl > 0 && bl <= 1)
            {
                if (MessageBox.Show("【" + xmbm + "|" + mc + "】需要自付" + (bl * 100).ToString("#0.00") + "%,还需要吗?",
                   "自费提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.No)
                {
                    returninnfo.ReturnCode = -1;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "";
                    return returninnfo;
                }
            }

            return returninnfo;
        }


        /// <summary>
        /// 通过住院号获取收费类别
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        public string GetLb(string zyh)
        {
            string gflb = "";
            InstanceDb();
            DataTable tbinpatient = Database.GetDataTable("select ( select top 1  name from JC_YBZLX where YBLXID=b.id and code=a.xzlx) zlxname,b.NAME from ZY_INPATIENT  a join JC_YBLX b on a.YBLX=b.ID   where  a.INPATIENT_NO='" + zyh + "'");//a.FLAG in(1,3,4) and  
            if (tbinpatient.Rows.Count == 0)
                gflb = "自费";
            else
            {
                if (tbinpatient.Rows[0]["NAME"].ToString().Trim().Contains("公费"))//Modify By Tany 2016-08-31
                    gflb = tbinpatient.Rows[0]["NAME"].ToString().Trim();
                else
                {
                    gflb = tbinpatient.Rows[0]["zlxname"].ToString().Trim();
                }
            }

            return gflb;
        }
        /// <summary>
        /// 住院号去掉前面的0
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        private string ConvertNo(string zyh)
        {
            int leng = zyh.Length;
            for (int i = 0; i < leng; i++)
            {
                if (zyh.Substring(0, 1) == "0")
                {
                    zyh = zyh.Substring(1, zyh.Length - 1);
                }
                else
                    break;
            }
            return zyh;
        }
        /// <summary>
        /// 获得医保的险种类别
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        public string Getxzlb(string zyh)
        {
            InstanceDb();
            zyh = ConvertNo(zyh);
            string sql = "select dybm from yb_csxx a join yb_brxx b on b.jzlb=a.lxbm where xxlx='jzlb' and b.zyh='" + zyh + "'";
            DataTable tb = InFomixDb.GetDataTable(sql);
            if (tb.Rows.Count == 0)
            {
                return "";
            }
            else
                return tb.Rows[0]["dybm"].ToString();
        }
        /// <summary>
        /// 获取农保病人区域
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        public string GetNbqy(string zyh)
        {
            InstanceDb();
            zyh = ConvertNo(zyh);
            string sql = "select xzqybm from nb_brxx where zyh='" + zyh + "'";
            DataTable tb = InFomixDb.GetDataTable(sql);
            if (tb.Rows.Count == 0)
            {
                return "";
            }
            else
                return tb.Rows[0]["xzqybm"].ToString();
        }
        /// <summary>
        /// 医保、新农合、九江市医保取比例函数
        /// </summary>
        /// <param name="as_gflb">医保类别</param>
        /// <param name="as_ypxm">项目编码</param>
        /// <param name="as_zfbl"></param>
        /// <param name="ad_zff"></param>
        /// <param name="as_fylb">项目还是药品 YP ,XM</param>
        /// <returns></returns>
        public ReturnInfo ybnb_srxz(string zyh, string as_gflb, string as_ypxm, decimal as_zfbl, ref int ad_zff, string as_fylb, string mc)
        {
            InstanceDb();
            zyh = ConvertNo(zyh);
            int li_xybcc, li_ccc, li_rtn, li_xzbz;
            string ls_bm, ls_sm, ls_inkind, ls_itemcode;//1。xzlb怎样获取 2.新农合怎么获取比例
            decimal lr_xzfbl = -1;
            string ls_xzxz, ls_mzxz, ls_Err;
            string is_Errtext = "";//init instance 
            string is_xzlb = Getxzlb(zyh);
            string sqlstr = "";
            bool isKbxm = false;

            string hoitem_id = as_ypxm; //Modify By tany 2015-05-14 记录原来的医嘱项目ID

            if (as_fylb == "XM")
                as_ypxm = HisFunctions.GetOldHISXmYpBM("2", as_ypxm.ToString(), out isKbxm, Database);
            else
                as_ypxm = HisFunctions.GetOldHISXmYpBM("1", as_ypxm.ToString(), Database);

            //如果是医保 bmdyb中没有对应，不能使用
            #region 不明觉厉的代码，暂时不知道什么作用 -_-||| Modify By Tany 2014-05-22
            /*
            if (as_fylb == "XM" && !as_gflb.Contains("新医保"))
            {
                string sql = @"select * from bmdyb where ybbmlx=1 and yycode='" + as_ypxm + "'";
                DataTable tb = InFomixDb.GetDataTable(sql);
                if (tb.Rows.Count == 0)
                {
                    returninnfo.ReturnCode = -99;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "没有做医保对应，不能使用！";
                    return returninnfo;
                }
                else
                {
                    //提示自付比例
                    returninnfo.ReturnCode = 1;
                    returninnfo.ReturnValue = tb.Rows[0]["zfbl"].ToString();
                    returninnfo.ReurnShowInfo = "获取成功";
                    return returninnfo;
                }
            }
            if (as_fylb == "YP" && !as_gflb.Contains("新医保"))
            {
                //如果是药品 ,不是新医保
                string sql = @"select * from bmdyb where ybbmlx=1 and yycode='" + as_ypxm + "'";
                DataTable tb = InFomixDb.GetDataTable(sql);
                if (tb.Rows.Count == 0)
                {
                    returninnfo.ReturnCode = -99;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "没有做医保对应，不能使用！";
                    return returninnfo;
                }
                else
                {
                    if (TrasenHIS.DAL.BaseDal.GetEncodingString(tb.Rows[0]["mshu"].ToString()) == "◇")
                    {
                        returninnfo.ReturnCode = -99;
                        returninnfo.ReturnValue = "1";
                        returninnfo.ReurnShowInfo = "该药品只能在门诊使用";
                        return returninnfo;
                    }
                    if (tb.Rows[0]["mshu"].ToString() != "" && MessageBox.Show("是否符合 " + tb.Rows[0]["mshu"].ToString() + " ,否按照自费处理 ",
                              "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                              == DialogResult.Yes)
                    {
                        returninnfo.ReturnCode = 1;
                        returninnfo.ReturnValue = "1";
                        returninnfo.ReurnShowInfo = "";
                        return returninnfo;
                    }
                    else
                    {
                        returninnfo.ReturnCode = 1;
                        returninnfo.ReturnValue = "1";
                        returninnfo.ReurnShowInfo = tb.Rows[0]["zfbl"].ToString();
                        return returninnfo;
                    }
                }
            }
            */
            #endregion

            //
            if (isKbxm)
            {
                //Modify By Tany 2015-05-14 捆绑项目需要拆分来分析能不能报销，不能的话不允许用
                //Modify By Tany 2015-05-19 增加显示套餐子项目名称
                string tcSql = "select * from JC_TC_MX a inner join jc_hsitem c on a.SUBITEM_ID=c.ITEM_ID inner join JC_HOI_HDI b on a.MAINITEM_ID=b.HDITEM_ID and b.TC_FLAG>0 and b.hoitem_id=" + hoitem_id;
                DataTable tcTb = Database.GetDataTable(tcSql);
                for (int i = 0; i < tcTb.Rows.Count; i++)
                {
                    //又要从套餐拆分出的费用明细，转成任意一条医嘱ID
                    string tc_hoitemid = Convertor.IsNull((Database.GetDataResult("select hoitem_id from jc_hoi_hdi where tc_flag<=0 and hditem_id=" + tcTb.Rows[i]["SUBITEM_ID"].ToString())), "");
                    if (tc_hoitemid != "")
                    {
                        //调用本身，不会走
                        returninnfo = ybnb_srxz(zyh, as_gflb, tc_hoitemid, as_zfbl, ref ad_zff, as_fylb, tcTb.Rows[i]["ITEM_NAME"].ToString().Trim()); //Modify By tany 2015-05-19 传入的名称为套餐内的子项目名称
                        if (returninnfo.ReturnCode == -99)
                        {
                            returninnfo.ReurnShowInfo = mc + "该套餐中有明细项目【" + tcTb.Rows[i]["ITEM_NAME"].ToString().Trim() + "】没有做对应，不能使用！请联系医保办做对应";
                            return returninnfo;
                        }
                        if (returninnfo.ReturnCode <= 0)
                        {
                            returninnfo.ReturnCode = -99;
                            returninnfo.ReurnShowInfo = mc + "该套餐中有明细项目【" + tcTb.Rows[i]["ITEM_NAME"].ToString().Trim() + "】没有被确认，不能使用";
                            return returninnfo;
                        }
                    }
                    else
                    {
                        //如果拆开的项目没有做医嘱对应，不允许继续 Modify By Tany 2016-01-21
                        returninnfo.ReturnCode = -99;
                        returninnfo.ReturnValue = "-1";
                        returninnfo.ReurnShowInfo = mc + "该套餐中有明细项目【" + tcTb.Rows[i]["ITEM_NAME"].ToString().Trim() + "】没有做医嘱项目对应，不能使用！请将该收费项目做医嘱项目对应后再开立";
                        return returninnfo;
                    }
                }

                returninnfo.ReturnCode = 1;
                returninnfo.ReturnValue = as_gflb.Contains("新农合") ? "1" : "0";//如果是新农合，给1 Modify By Tany 2015-02-04
                returninnfo.ReurnShowInfo = "捆绑项目自付比例为0";
                return returninnfo;
            }

            if (as_gflb.Contains("新医保"))
            {
                #region
                if (is_xzlb == "")
                {
                    returninnfo.ReturnCode = -99;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "新医保病人的险种类别为空!";
                    return returninnfo;
                }
                ls_bm = as_ypxm.Trim();
                //sqlstr = @"SELECT count(*)  li_xybcc FROM yb_bmdzb Where yyxmbm ='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_bm) + "'";
                sqlstr = @"SELECT count(*)  li_xybcc FROM yb_bmdzb Where yyxmbm ='" + ls_bm + "'";
                DataTable tb = InFomixDb.GetDataTable(sqlstr);
                if (tb.Rows.Count <= 0 || tb.Rows[0]["li_xybcc"].ToString() == "")
                {
                    returninnfo.ReturnCode = -99;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = ls_bm + "该药品或项目没有做对应，请联系医保办";
                    return returninnfo;
                }
                else
                {
                    //sqlstr = @" SELECT zfbl,sm,xzxz,mzxz  FROM yb_ybmlb  Where ybxmbm In (SELECT xmbm FROM yb_bmdzb Where yyxmbm ='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_bm) + "')";
                    sqlstr = @" SELECT zfbl,sm,xzxz,mzxz  FROM yb_ybmlb  Where ybxmbm In (SELECT xmbm FROM yb_bmdzb Where yyxmbm ='" + ls_bm + "')";
                    DataTable yb_ybmlb = InFomixDb.GetDataTable(sqlstr);
                    if (yb_ybmlb.Rows.Count <= 0)
                    {
                        returninnfo.ReturnCode = -99;
                        returninnfo.ReturnValue = "-1";
                        returninnfo.ReurnShowInfo = "该药品或项目没有做对应，请联系医保办" + yb_ybmlb;
                        return returninnfo;
                    }
                    else
                    {
                        ls_sm = (yb_ybmlb.Rows[0]["sm"].ToString().Trim());
                        //string ls_xmss = TrasenHIS.DAL.BaseDal.GetEncodingString(yb_ybmlb.Rows[0]["sm"].ToString().Trim());
                        string ls_xmss = yb_ybmlb.Rows[0]["sm"].ToString().Trim();
                        //ls_mzxz = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(yb_ybmlb.Rows[0]["mzxz"].ToString().Trim());
                        ls_mzxz = yb_ybmlb.Rows[0]["mzxz"].ToString().Trim();
                        //ls_xzxz = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(yb_ybmlb.Rows[0]["xzxz"].ToString().Trim());
                        ls_xzxz = yb_ybmlb.Rows[0]["xzxz"].ToString().Trim();
                        li_xzbz = ls_xzxz.IndexOf(is_xzlb);
                        lr_xzfbl = decimal.Parse(yb_ybmlb.Rows[0]["zfbl"].ToString().Trim());
                        if (li_xzbz >= 0)
                        {
                            if (MessageBox.Show("【" + ls_bm + "|" + mc + "】该药品或项目不在险种范围内，需自费,还需要吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.No)
                            {
                                returninnfo.ReturnCode = -1;
                                returninnfo.ReturnValue = "-1";
                                returninnfo.ReurnShowInfo = "";
                                return returninnfo;
                            }
                            else
                            {
                                //自费提示后直接退出 Modify By Tany 2015-09-02
                                returninnfo.ReturnCode = 1;
                                returninnfo.ReturnValue = "1";
                                returninnfo.ReurnShowInfo = "成功";
                                return returninnfo;
                            }
                        }
                        else
                        {
                            //如果这个药品在险种范围内，才需要判断，如果不在险种范围内，没必要判断下列情况
                            //Modify By Tany 2015-09-02
                            if (as_fylb == "YP")
                            {
                                #region
                                if (ls_xmss.IndexOf("限") >= 0
                                      && ls_xmss.Trim() != ""
                                      && ls_xmss != "△"
                                      && ls_xmss != "◇ ")
                                {
                                    //   if (MessageBox.Show(DAL.BaseDal.GetEncodingString(ls_sm) + "\r\n该病人病情是否符合此范围?",
                                    //"特别提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    if (MessageBox.Show(ls_sm + "\r\n该病人病情是否符合此范围?",
                                 "特别提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                 == DialogResult.No)
                                    {
                                        if (MessageBox.Show("是否确认按自费使用",
                               "补充提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                               == DialogResult.Yes)
                                        {
                                            //Modify By Tany 2015-09-01 增加判断，如果选了自费，还要看这个药品是否有自费的匹配关系
                                            string dybm = "z" + ls_bm;
                                            string ssql = "select count(*) from yb_bmdzb,yb_ybmlb where yb_bmdzb.xmbm = yb_ybmlb.ybxmbm and yb_bmdzb.yyxmbm = '" + dybm + "'";
                                            DataTable dt = new DataTable();
                                            try
                                            {
                                                dt = InFomixDb.GetDataTable(ssql);
                                            }
                                            catch (Exception err)
                                            {
                                                throw new Exception(err.Message + "||err sql:" + ssql);
                                            }
                                            if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                                            {
                                            }
                                            else
                                            {
                                                MessageBox.Show("【" + ls_bm + "|" + mc + "】该药品没有做自费对应，不允许自费使用！\r\n\r\n如需自费使用请咨询医保办！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                returninnfo.ReturnCode = -1;
                                                returninnfo.ReturnValue = "-1";
                                                returninnfo.ReurnShowInfo = "";
                                                return returninnfo;
                                            }

                                            ad_zff = 1;

                                            //Add By Tany 2014-08-26 提示自费后就退出
                                            returninnfo.ReturnCode = 1;
                                            returninnfo.ReturnValue = "1";
                                            returninnfo.ReurnShowInfo = "成功";
                                            return returninnfo;
                                        }
                                        else
                                        {
                                            returninnfo.ReturnCode = -1;
                                            returninnfo.ReturnValue = "-1";
                                            returninnfo.ReurnShowInfo = "";
                                            return returninnfo;
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                        if (is_xzlb == "1" || is_xzlb == "5")
                        {
                            #region
                            if (as_fylb != "YP" && as_fylb != "XM")
                            {
                                returninnfo.ReturnCode = -99;
                                returninnfo.ReturnValue = "-1";
                                returninnfo.ReurnShowInfo = "参数错误, as_fylb的值不存在";
                                return returninnfo;
                            }
                            //药品
                            if (as_fylb == "YP")
                                if (ad_zff <= 1)
                                    if (lr_xzfbl > 0 && lr_xzfbl <= 1)
                                        if (MessageBox.Show("【" + ls_bm + "|" + mc + "】该药品或项目需自费" + (lr_xzfbl * 100).ToString("#0.00") + "%,还需要吗?",
                               "自费提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                               == DialogResult.No)
                                        {
                                            returninnfo.ReturnCode = -1;
                                            returninnfo.ReturnValue = "-1";
                                            returninnfo.ReurnShowInfo = "";
                                            return returninnfo;
                                        }
                            //项目
                            if (as_fylb == "XM")
                                if (lr_xzfbl > 0 && lr_xzfbl <= 1)
                                    if (MessageBox.Show("【" + ls_bm + "|" + mc + "】该药品或项目需自费" + (lr_xzfbl * 100).ToString("#0.00") + "%,还需要吗?",
                           "自费提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                           == DialogResult.No)
                                    {
                                        returninnfo.ReturnCode = -1;
                                        returninnfo.ReturnValue = "-1";
                                        returninnfo.ReurnShowInfo = "";
                                        return returninnfo;
                                    }
                            if (lr_xzfbl > 0 && lr_xzfbl < 1)
                            {
                                //如果医保的自费不是100%，则全部算成报销
                                lr_xzfbl = 0;
                            }
                            #endregion
                        }
                        else if (lr_xzfbl == 1)
                        {
                            if (MessageBox.Show("【" + ls_bm + "|" + mc + "】该药品或项目需自费" + (lr_xzfbl * 100).ToString("#0.00") + "%,还需要吗?",
                             "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                             == DialogResult.No)
                            {
                                returninnfo.ReturnCode = -1;
                                returninnfo.ReturnValue = "-1";
                                returninnfo.ReurnShowInfo = "";
                                return returninnfo;
                            }
                        }
                        else if (lr_xzfbl > 0 && lr_xzfbl < 1)
                        {
                            //如果医保的自费不是100%，则全部算成报销
                            lr_xzfbl = 0;
                        }
                    }
                }
                #endregion
            }
            else if (as_gflb.Contains("新农合"))
            {
                string is_qh = "";
                sqlstr = "select xzqybm from nb_brxx where zyh='" + zyh + "'";
                DataTable tb_nb_brxx = InFomixDb.GetDataTable(sqlstr);
                if (tb_nb_brxx.Rows.Count > 0)
                {
                    is_qh = tb_nb_brxx.Rows[0]["xzqybm"].ToString();
                }
                else
                {
                    //Modify Tany 2015-11-03 待转新农合先找公费类别表对应的区号，找不到的全部按照新农合市级转诊的区号
                    if (as_gflb.Contains("待转新农合"))
                    {
                        sqlstr = "select flm2 from pu_gflb where cxfl='新农合' and gflb='" + as_gflb.Replace("新农合", "农合") + "'";
                        DataTable tb_nbqh = InFomixDb.GetDataTable(sqlstr);
                        if (tb_nbqh.Rows.Count > 0)
                        {
                            is_qh = tb_nbqh.Rows[0]["flm2"].ToString();
                        }
                        if (is_qh == "")
                        {
                            is_qh = "420100";
                        }

                        //Modify by jchl 2017-02-24 非省农合全部进入市农合
                        if (!is_qh.Trim().Equals("420000"))//是否省农合
                        {
                            is_qh = "420100";//非省农合使用  市农合目录
                        }
                    }
                }
                #region
                ls_bm = as_ypxm.Trim();
                sqlstr = @"select incode ls_itemcode from y_bxxm where hoscode ='" + ls_bm + "' AND organid ='" + is_qh + "'";
                DataTable tb_y_bxxm = InFomixDb.GetDataTable(sqlstr);
                if (tb_y_bxxm.Rows.Count <= 0 || tb_y_bxxm.Rows[0]["ls_itemcode"].ToString() == "")
                {
                    returninnfo.ReturnCode = -99;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = ls_bm + "新农合目录该药品或项目没有对应(y_bxxm)，请联系医保办";
                    return returninnfo;
                }
                else
                {
                    ls_itemcode = tb_y_bxxm.Rows[0]["ls_itemcode"].ToString().Trim();
                    sqlstr = @"select feetypename  ls_Err from h_bxxm where itemcode ='" + ls_itemcode + "' and organid = '" + is_qh + "'";
                    DataTable tb_h_bxxm = InFomixDb.GetDataTable(sqlstr);
                    ls_Err = "";
                    if (tb_h_bxxm.Rows.Count > 0)
                    {
                        //ls_Err = TrasenHIS.DAL.BaseDal.GetEncodingString(tb_h_bxxm.Rows[0]["ls_Err"].ToString());
                        ls_Err = tb_h_bxxm.Rows[0]["ls_Err"].ToString();
                    }
                    if (ls_Err.IndexOf("不") >= 0)
                    {
                        if (MessageBox.Show("【" + mc + "】" + ls_Err + "，是否确定使用？",
                "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
                        {
                            returninnfo.ReturnCode = -1;
                            returninnfo.ReturnValue = "-1";
                            returninnfo.ReurnShowInfo = "";
                            return returninnfo;
                        }
                    }

                }

                //如果走完了，给农保的比例赋值1 Modify By Tany 2014-05-22
                lr_xzfbl = 1;
                #endregion
            }
            else if (as_gflb == "九江医保")
            {

                ls_bm = as_ypxm.Trim();
                //sqlstr = @"SELECT count(*)  li_xybcc FROM yb_bmdzb_jjyb Where yyxmbm ='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_bm) + "'";
                sqlstr = @"SELECT count(*)  li_xybcc FROM yb_bmdzb_jjyb Where yyxmbm ='" + ls_bm + "'";
                DataTable tb_yb_bmdzb_jjyb = InFomixDb.GetDataTable(sqlstr);
                if (tb_yb_bmdzb_jjyb.Rows.Count == 0)
                {
                    returninnfo.ReturnCode = -99;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = ls_bm + "该药品或项目九江医保没有做对应，请联系医保办";
                    return returninnfo;
                }
                else
                {
                    //TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix
                    //sqlstr = @"SELECT dldm  ls_sm FROM yb_jjml Where xmbm In (SELECT ybxmbm FROM yb_bmdzb_jjyb Where yyxmbm ='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_bm) + "')";
                    sqlstr = @"SELECT dldm  ls_sm FROM yb_jjml Where xmbm In (SELECT ybxmbm FROM yb_bmdzb_jjyb Where yyxmbm ='" + ls_bm + "')";
                    DataTable tb_yb_jjml = InFomixDb.GetDataTable(sqlstr);
                    if (tb_yb_jjml.Rows.Count > 0)
                    {
                        //ls_sm = TrasenHIS.DAL.BaseDal.GetEncodingString(tb_yb_jjml.Rows[0]["ls_sm"].ToString().Trim());
                        ls_sm = tb_yb_jjml.Rows[0]["ls_sm"].ToString().Trim();
                        if (ls_sm != "甲类" && ls_sm != "乙类" && ls_sm != "丙类")
                        {
                            if (MessageBox.Show("该药品或项目【" + ls_sm + "】，是否确定使用？",
                 "特别提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.No)
                            {
                                returninnfo.ReturnCode = -1;
                                returninnfo.ReturnValue = "-1";
                                returninnfo.ReurnShowInfo = "";
                                return returninnfo;
                            }
                        }
                    }
                }
                //暂时没有就先不写
                //returninnfo.ReturnCode = -1;
                //returninnfo.ReturnValue = "-1";
                //returninnfo.ReurnShowInfo = "程序暂时没有实现该部分的判断";
            }

            returninnfo.ReturnCode = 1;
            returninnfo.ReturnValue = lr_xzfbl.ToString();
            returninnfo.ReurnShowInfo = "成功";
            if (lr_xzfbl == -1)
            {
                returninnfo.ReturnCode = -1;
                returninnfo.ReturnValue = lr_xzfbl.ToString();
                returninnfo.ReurnShowInfo = "";
            }
            return returninnfo;
        }


        /// <summary>
        /// 医保、新农合、九江市医保取比例函数
        /// </summary>
        /// <param name="as_gflb">医保类别</param>
        /// <param name="as_ypxm">项目编码</param>
        /// <param name="as_zfbl"></param>
        /// <param name="ad_zff"></param>
        /// <param name="as_fylb">项目还是药品 YP ,XM</param>
        /// <returns></returns>
        public ReturnInfo ybnb_getbl(string zyh, string as_gflb, string as_ypxm, decimal as_zfbl, ref int ad_zff, string as_fylb)
        {
            InstanceDb();
            zyh = ConvertNo(zyh);
            int li_xybcc, li_ccc, li_rtn, li_xzbz;
            string ls_bm, ls_sm, ls_inkind, ls_itemcode;//1。xzlb怎样获取 2.新农合怎么获取比例
            decimal lr_xzfbl = -1;
            string ls_xzxz, ls_mzxz, ls_Err;
            string is_Errtext = "";//init instance 
            string is_xzlb = Getxzlb(zyh);
            string sqlstr = "";
            bool isKbxm = false;

            if (as_fylb == "XM")
                as_ypxm = HisFunctions.GetOldHISXmYpBM("2", as_ypxm.ToString(), out isKbxm, Database);
            else
                as_ypxm = HisFunctions.GetOldHISXmYpBM("1", as_ypxm.ToString(), Database);

            if (isKbxm)
            {
                returninnfo.ReturnCode = 1;
                returninnfo.ReturnValue = as_gflb.Contains("新农合") ? "1" : "0";//如果是新农合，给1 Modify By Tany 2015-02-04
                returninnfo.ReurnShowInfo = "捆绑项目自付比例为0";
                return returninnfo;
            }

            if (as_gflb == "新医保")
            {
                #region
                if (is_xzlb == "")
                {
                    returninnfo.ReturnCode = -1;
                    returninnfo.ReturnValue = "-1";
                    returninnfo.ReurnShowInfo = "新医保病人的险种类别为空!";
                    return returninnfo;
                }
                ls_bm = as_ypxm.Trim();
                //sqlstr = @"SELECT count(*)  li_xybcc FROM yb_bmdzb Where yyxmbm ='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_bm) + "'";
                sqlstr = @"SELECT count(*)  li_xybcc FROM yb_bmdzb Where yyxmbm ='" + ls_bm + "'";
                DataTable tb = InFomixDb.GetDataTable(sqlstr);
                if (tb.Rows.Count <= 0 || tb.Rows[0]["li_xybcc"].ToString() == "")
                {
                    returninnfo.ReturnCode = -1;
                    returninnfo.ReturnValue = "1";
                    returninnfo.ReurnShowInfo = ls_bm + "该药品或项目没有做对应，请联系医保办";
                    return returninnfo;
                }
                else
                {
                    //sqlstr = @" SELECT zfbl,sm,xzxz,mzxz  FROM yb_ybmlb  Where ybxmbm In (SELECT xmbm FROM yb_bmdzb Where yyxmbm ='" + TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(ls_bm) + "')";
                    sqlstr = @" SELECT zfbl,sm,xzxz,mzxz  FROM yb_ybmlb  Where ybxmbm In (SELECT xmbm FROM yb_bmdzb Where yyxmbm ='" + ls_bm + "')";
                    DataTable yb_ybmlb = InFomixDb.GetDataTable(sqlstr);
                    if (yb_ybmlb.Rows.Count <= 0)
                    {
                        returninnfo.ReturnCode = -1;
                        returninnfo.ReturnValue = "1";
                        returninnfo.ReurnShowInfo = "该药品或项目没有做对应，请联系医保办" + yb_ybmlb;
                        return returninnfo;
                    }
                    else
                    {
                        ls_sm = (yb_ybmlb.Rows[0]["sm"].ToString().Trim());
                        //string ls_xmss = TrasenHIS.DAL.BaseDal.GetEncodingString(yb_ybmlb.Rows[0]["sm"].ToString().Trim());
                        //ls_mzxz = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(yb_ybmlb.Rows[0]["mzxz"].ToString().Trim());
                        //ls_xzxz = TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(yb_ybmlb.Rows[0]["xzxz"].ToString().Trim());
                        string ls_xmss = yb_ybmlb.Rows[0]["sm"].ToString().Trim();
                        ls_mzxz = yb_ybmlb.Rows[0]["mzxz"].ToString().Trim();
                        ls_xzxz = yb_ybmlb.Rows[0]["xzxz"].ToString().Trim();
                        li_xzbz = ls_xzxz.IndexOf(is_xzlb);
                        lr_xzfbl = decimal.Parse(yb_ybmlb.Rows[0]["zfbl"].ToString().Trim());
                        if (li_xzbz > 0)
                        {

                            returninnfo.ReturnCode = 1;
                            returninnfo.ReturnValue = "1";
                            returninnfo.ReurnShowInfo = "";
                            return returninnfo;

                        }
                        if (as_fylb == "YP")
                        {
                            #region
                            if (ls_xmss.IndexOf("限") >= 0
                                  && ls_xmss.Trim() != ""
                                  && ls_xmss != "△"
                                  && ls_xmss != "◇ ")
                            {

                            }
                            #endregion
                        }
                        returninnfo.ReturnCode = 1;
                        returninnfo.ReturnValue = lr_xzfbl.ToString();
                        returninnfo.ReurnShowInfo = "";
                        return returninnfo;
                    }
                }
                #endregion
            }
            else
                if (as_gflb.Contains("新农合"))
                {
                    string is_qh = "";
                    sqlstr = "select xzqybm from nb_brxx where zyh='" + zyh + "'";
                    DataTable tb_nb_brxx = InFomixDb.GetDataTable(sqlstr);
                    if (tb_nb_brxx.Rows.Count > 0)
                        is_qh = tb_nb_brxx.Rows[0]["xzqybm"].ToString();

                    //Modify by jchl 2017-02-24 区农合目录合并使用市农合目录,省农合沿用省农合目录
                    if (is_qh.Trim().Equals("420100"))//是否省农合
                    {
                        is_qh = "421000";//非省农合使用  市农合目录
                    }

                    #region
                    ls_bm = as_ypxm.Trim();
                    sqlstr = @"select incode ls_itemcode from y_bxxm where hoscode ='" + ls_bm + "' AND organid ='" + is_qh + "'";
                    DataTable tb_y_bxxm = InFomixDb.GetDataTable(sqlstr);
                    if (tb_y_bxxm.Rows.Count <= 0 || tb_y_bxxm.Rows[0]["ls_itemcode"].ToString() == "")
                    {
                        returninnfo.ReturnCode = -1;
                        returninnfo.ReturnValue = "-1";
                        returninnfo.ReurnShowInfo = ls_bm + "新农合目录该药品或项目没有对应(y_bxxm)，请联系医保办";
                        return returninnfo;
                    }
                    else
                    {
                        ls_itemcode = tb_y_bxxm.Rows[0]["ls_itemcode"].ToString().Trim();
                        sqlstr = @"select feetypename  ls_Err from h_bxxm where itemcode ='" + ls_itemcode + "' and organid = '" + is_qh + "'";
                        DataTable tb_h_bxxm = InFomixDb.GetDataTable(sqlstr);
                        ls_Err = "";
                        if (tb_h_bxxm.Rows.Count > 0)
                        {
                            //ls_Err = TrasenHIS.DAL.BaseDal.GetEncodingString(tb_h_bxxm.Rows[0]["ls_Err"].ToString());
                            ls_Err = tb_h_bxxm.Rows[0]["ls_Err"].ToString();
                        }
                        returninnfo.ReturnCode = 1;
                        returninnfo.ReturnValue = "1";
                        returninnfo.ReurnShowInfo = "";
                        return returninnfo;

                    }
                    #endregion
                }
                else
                    if (as_gflb == "九江医保")
                    {



                        //暂时没有就先不写
                        //returninnfo.ReturnCode = -1;
                        //returninnfo.ReturnValue = "-1";
                        //returninnfo.ReurnShowInfo = "程序暂时没有实现该部分的判断";
                    }

            returninnfo.ReturnCode = 1;
            returninnfo.ReturnValue = lr_xzfbl.ToString();
            returninnfo.ReurnShowInfo = "成功";
            if (lr_xzfbl == -1)
            {
                returninnfo.ReturnCode = -1;
                returninnfo.ReturnValue = lr_xzfbl.ToString();
                returninnfo.ReurnShowInfo = "";
            }
            return returninnfo;
        }

        /// <summary>
        /// 医保大额提示
        /// </summary>
        /// <param name="zyh"></param>
        public void CheckYbde(string zyh)
        {
            try
            {
                string sql = "";
                DataTable tb = new DataTable();
                string ls_jzlb = "";
                string ls_xtjgdm = "";//Add By Tany 2015-03-30
                string ls_cslb = "";
                decimal lde_jbyb = 0;
                decimal lde_ndylfy = 0;
                decimal lde_jbylfdfy = 0;
                decimal lde_sbbt = 0;//商保赔付1 ..10W以上

                decimal lde_bcfyze = 0; //Add By Tany 2015-08-03

                InstanceDb();
                zyh = ConvertNo(zyh);

                sql = "select jzlb,ndylfy,xtjgdm from yb_brxx where zyh ='" + zyh + "'";
                tb = InFomixDb.GetDataTable(sql);
                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }
                ls_jzlb = tb.Rows[0]["jzlb"].ToString().Trim();
                lde_ndylfy = Convert.ToDecimal(tb.Rows[0]["ndylfy"]);
                ls_xtjgdm = tb.Rows[0]["xtjgdm"].ToString().Trim();

                //医保大额远程区才提示 Modify By Tany 2015-03-30
                sql = "select cslb from yb_csxx where xxlx='jgdm' and lxbm ='" + ls_xtjgdm + "'";
                tb = InFomixDb.GetDataTable(sql);
                if (tb == null || tb.Rows.Count == 0)
                {
                    ls_cslb = "";
                }
                else
                {
                    ls_cslb = Convertor.IsNull(tb.Rows[0]["cslb"], "");
                }
                //if (ls_cslb != "1" || ls_cslb.Trim() == "")
                //{
                //    return;
                //}

                //判断是否是居保或大学生医保
                sql = "select count(*) from yb_csxx where xxlx='jzlb' and lxbm='" + ls_jzlb + "' and dybm in ('8','5')";
                int li_c = Convert.ToInt32(Convertor.IsNull(InFomixDb.GetDataResult(sql), "0"));

                sql = "SELECT bcfyze,sbbt,jbylfdfy,bcfyze FROM yb_zyjs Where zyh ='" + zyh + "'";
                tb = InFomixDb.GetDataTable(sql);
                if (tb == null || tb.Rows.Count == 0)
                {
                    lde_jbyb = 0;
                    lde_sbbt = 0;
                    lde_jbylfdfy = 0;
                    lde_bcfyze = 0;
                }
                else
                {
                    lde_jbyb = Convert.ToDecimal(Convertor.IsNull(tb.Rows[0]["bcfyze"], "0"));
                    lde_sbbt = Convert.ToDecimal(Convertor.IsNull(tb.Rows[0]["sbbt"], "0"));
                    lde_jbylfdfy = Convert.ToDecimal(Convertor.IsNull(tb.Rows[0]["jbylfdfy"], "0"));
                    lde_bcfyze = Convert.ToDecimal(Convertor.IsNull(tb.Rows[0]["bcfyze"], "0")); //Add By Tany 2015-08-03
                }

                //Modify By Tany 2015-05-29 把lde_ndylfy + lde_jbylfdfy >= 100000的逻辑合并进来，避免提示两次
                //if (lde_sbbt > 0 || lde_ndylfy + lde_jbylfdfy >= 100000)
                //Modify By Tany 2015-08-03 根据刘工所说，改变判断条件
                if (lde_bcfyze > 0 || lde_ndylfy + lde_jbylfdfy >= 100000)
                {
                    if (li_c > 0)
                    {
                        if (lde_sbbt > 0)
                        {
                            MessageBox.Show("该病人已进入大病医保报销范围", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        //Modify By Tany 2015-04-29
                        if (ls_cslb == "1")
                        {
                            MessageBox.Show("该病人年度累计费用已到10万以上，请告知病人或家属在出院前将患者的\r\n'身份证、医保IC卡'复印件各交一份门诊医保办", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("该病人年度累计费用已到10万以上", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if (lde_ndylfy + lde_jbylfdfy >= 98000 && lde_ndylfy + lde_jbylfdfy < 100000)
                {
                    if (li_c > 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("该病人年度累计费用已超过9.8万(预留2000元预警)，即将到达10万", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //if (lde_ndylfy + lde_jbylfdfy >= 100000)
                //{
                //    if (li_c > 0)
                //    {
                //    }
                //    else
                //    {
                //        //Modify By Tany 2015-04-29
                //        if (ls_cslb == "1")
                //        {
                //            MessageBox.Show("该病人年度累计费用已到10万以上，请告知病人或家属在出院前将患者的\r\n'身份证、医保IC卡'复印件各交一份门诊医保办", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //        else
                //        {
                //            MessageBox.Show("该病人年度累计费用已到10万以上", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //    }
                //}
                if (lde_jbyb > 0)
                {
                    if (li_c > 0)
                    {
                    }
                    else
                    {
                        //Modify By Tany 2015-04-29
                        if (ls_cslb == "1")
                        {
                            MessageBox.Show("该病人已到大额，请告知病人或家属在出院前将患者的\r\n'身份证、医保IC卡'复印件各交一份门诊医保办", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("该病人已到大额", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //Add By Tany 2014-09-25
        /// <summary>
        /// 检查农和病人的自费药比例是否超过20%
        /// </summary>
        /// <param name="zyh">住院号</param>
        public void CheckXnhzfybl(string zyh)
        {
            string sql = "";
            string as_gm = "";
            string as_zyh2 = "";
            double lde_zf = 0;
            double lde_yp = 0;

            try
            {
                InstanceDb();
                zyh = ConvertNo(zyh);

                sql = @"select xzqybm from nb_brxx where zyh ='" + zyh + "'";
                as_gm = Convertor.IsNull(InFomixDb.GetDataResult(sql), "");
                if (as_gm == "")
                {
                    return;
                }

                as_zyh2 = "z" + zyh;

                sql = @"SELECT sum(yw_zyfymx.je) " +
                    "FROM yw_zyfymx,y_bxxm,h_bxxm " +
                    "WHERE ( yw_zyfymx.xmbm = y_bxxm.hoscode ) and " +
                    "( y_bxxm.incode = h_bxxm.itemcode ) and " +
                    "( y_bxxm.organid = h_bxxm.organid ) and " +
                    "( yw_zyfymx.zyh = '" + zyh + "' or yw_zyfymx.zyh = '" + as_zyh2 + "' ) AND " +
                    "( y_bxxm.organid = '" + as_gm + "' ) and " +
                    "( yw_zyfymx.dyfl in ('0310','0320','0330') ) and " +
                    "( h_bxxm.feetypename like '%不可报销%' ) ";

                lde_zf = Convert.ToDouble(Convertor.IsNull(InFomixDb.GetDataResult(sql), "0"));

                if (lde_zf == 0)
                {
                    return;
                }

                sql = @"select sum(je) from yw_zyfymx where zyh='" + zyh + "' and dyfl in ('0310','0320','0330')";

                lde_yp = Convert.ToDouble(Convertor.IsNull(InFomixDb.GetDataResult(sql), "0"));

                if (lde_yp == 0)
                {
                    return;
                }
                if ((lde_zf / lde_yp) > 0.2)
                {
                    MessageBox.Show("此病人自费药比已超20%，请病区注意控制，以免造成农合管理部门对药比超标的审减");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //Add By Tany 2015-03-18 病人信息提醒
        /// <summary>
        /// 检查病人信息备注
        /// </summary>
        /// <param name="zyh"></param>
        public void CheckBrxxBZ(string zyh)
        {
            try
            {
                string sql = "";
                DataTable tb = new DataTable();
                string bz = "";
                string lb = GetLb(zyh);

                if (!lb.Contains("新医保"))
                {
                    return;
                }

                InstanceDb();
                zyh = ConvertNo(zyh);

                sql = "select * from zy_zybrxx where zyh ='" + zyh + "'";
                tb = InFomixDb.GetDataTable(sql);
                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }
                else
                {
                    bz = Convertor.IsNull(tb.Rows[0]["bz"], "");
                }

                if (bz != "")
                {
                    MessageBox.Show(bz, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// 药品是否属于特殊药品
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public static bool CheckTsyp(string orderid)
        {

            bool isTsyp=false;
            //string ts = GetEncodingStringToInforMix("特殊");
            string ts = "特殊";
            string sql = "select  yyxmbm  from yb_bmdzb where dlbm ='" +ts+"'";
            DataTable dt = new DataTable();
            dt = InFomixDb.GetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["yyxmbm"].ToString() == orderid)
                {
                    isTsyp = true;
                }
            }
            return isTsyp;
        }
        /// <summary>
        /// 把informix码转成汉字
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string GetEncodingString(string srcString)
        {
            Encoding e8859Encode = Encoding.GetEncoding("iso-8859-1");
            Encoding srcEncode = Encoding.GetEncoding("gb2312");
            Encoding dstEncode = Encoding.Unicode;
            byte[] srcBytes = e8859Encode.GetBytes(srcString);//用iso-8859-1去转换源字符串
            byte[] dstBytes = Encoding.Convert(srcEncode, dstEncode, srcBytes);//但是，是从gb2312转到unicode的
            char[] dstChars = new char[dstEncode.GetCharCount(dstBytes, 0, dstBytes.Length)];
            dstEncode.GetChars(dstBytes, 0, dstBytes.Length, dstChars, 0);
            return new string(dstChars);

        }

        /// <summary>
        /// 将汉字转成informix 码
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string GetEncodingStringToInforMix(string srcString)
        {
            Encoding e8859Encode = Encoding.GetEncoding("iso-8859-1");
            Encoding srcEncode = Encoding.GetEncoding("gb2312");
            Encoding dstEncode = Encoding.Unicode;

            byte[] srcBytes = srcEncode.GetBytes(srcString);

            byte[] dstBytes = Encoding.Convert(e8859Encode, dstEncode, srcBytes);//但是，是从gb2312转到unicode的
            char[] dstChars = new char[dstEncode.GetCharCount(dstBytes, 0, dstBytes.Length)];
            dstEncode.GetChars(dstBytes, 0, dstBytes.Length, dstChars, 0);
            return new string(dstChars);
        }

        //Add By Tany 2015-12-28
        /// <summary>
        /// 检查老系统费用是否存在
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="fee_id"></param>
        /// <returns>false=在老系统没有找到对应的费用 true=费用已经传输给老系统</returns>
        public bool CheckFeeStatus(string zyh, string fee_id)
        {
            string sql = "";

            try
            {
                InstanceDb();
                zyh = ConvertNo(zyh);

                sql = @"select count(*) from yw_zyfymx where zyh='" + zyh + "' and yy='" + fee_id.ToLower() + "'";

                if (Convert.ToInt32(Convertor.IsNull(InFomixDb.GetDataResult(sql), "0")) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
