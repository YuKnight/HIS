using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Runtime.InteropServices;

namespace ts_ybznsh_interface
{

    public class BmiAuditClass
    {
        const string path = "Audit4Hospital.dll";

        //提交主单
        [DllImport(path, EntryPoint = "UploadClaimInfo", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string UploadClaimInfo(string InHasUpdate4Claim, string inAGENCIES_ID, string inClaimInfo);

        //批量上传明细信息
        [DllImport(path, EntryPoint = "UploadDetailInfo", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string UploadDetailInfo(string IsFirst, string IsLast, string inDeatilInfo);

        //审核接口初始化请求
        [DllImport(path, EntryPoint = "InitXML", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string InitXML();

        //删除主单
        [DllImport(path, EntryPoint = "ClaimDelete4Hospital", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string ClaimDelete4Hospital(string inClaimID, string inAGENCIES_ID);

        //审核信息提交
        [DllImport(path, EntryPoint = "AuditClaimInfo_N", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string AuditClaimInfo_N(string tmp_aa);

        //只审核，不保存
        [DllImport(path, EntryPoint = "AuditClaimInfo_Y", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string AuditClaimInfo_Y(string tmp_aa);

        //添加备案信息
        [DllImport(path, EntryPoint = "AddPutOnRecord4Hospital", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string AddPutOnRecord4Hospital(string inType, string inCode, string inName, string inPatient_IDStr, string inApprovalNumber, string inStartDT, string inEndDT, string inAGENCIES_ID);

        //删除备案信息
        [DllImport(path, EntryPoint = "DeletePutOnRecord4Hospital", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string DeletePutOnRecord4Hospital(string inType, string inCode, string inPatient_IDStr, string inAGENCIES_ID);

        //删除明细
        [DllImport(path, EntryPoint = "DeleteDetail4Hospital", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string DeleteDetail4Hospital(string inClaimID, string inDetailID, string inAGENCIES_ID);

        //审核信息提交-自动审核无界面提示
        [DllImport(path, EntryPoint = "AuditClaimInfo_S", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string AuditClaimInfo_S();

        //对已经保存的数据进行审核
        [DllImport(path, EntryPoint = "AuditCacheWithResult", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string AuditCacheWithResult(string inClaimID, string inAGENCIES_ID);

        //获取单据总额 对账使用
        [DllImport(path, EntryPoint = "AuditGetCostsResult", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string AuditGetCostsResult(string inClaimID, string inAGENCIES_ID);

        //更新主单
        [DllImport(path, EntryPoint = "UpDataClaimInfo", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string UpDataClaimInfo(string inAGENCIES_ID, string inClaimInfo);

        //更新住院状态
        [DllImport(path, EntryPoint = "UpDataHS_STATUS", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string UpDataHS_STATUS(string inClaimID, string inHS_STATUS, string inAGENCIES_ID);

        //获取错误
        [DllImport(path, EntryPoint = "GetErrorMessage", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string GetErrorMessage();

        //修改计费标记
        [DllImport(path, EntryPoint = "UpDataDetail_ZZZ_Flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string UpDataDetail_ZZZ_Flag(string inClaimID, string inDetailID, string inZZZ_Flag, string inAGENCIES_ID);




        public string l_error_message = "";
        //返回结果参数
        private string l_s = "";

        private string gs_auditflag;

        #region"重新审核已上传数据"

        public string ReCheckLoadInfo(string inpId, string inAGENCIES_ID)
        {
            string sRet = AuditCacheWithResult(inpId, inAGENCIES_ID);
            return sRet;
        }

        #endregion

        #region"删除调用"

        /// <summary>
        /// 删除主单
        /// </summary>
        /// <param name="inpId"></param>
        /// <param name="inAGENCIES_ID"></param>
        /// <returns></returns>
        public string deleteClaim4Hospital(string inpId, string inAGENCIES_ID)
        {
            string retInfo = ClaimDelete4Hospital(inpId, inAGENCIES_ID);
            return retInfo;
        }

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="inClaimID"></param>
        /// <param name="inDetailID"></param>
        /// <param name="inAGENCIES_ID"></param>
        /// <returns></returns>
        public string deleteDetail4Hospital(string inpId, string feeId, string inAGENCIES_ID)
        {
            string ret = DeleteDetail4Hospital(inpId, feeId, inAGENCIES_ID);
            return ret;
        }

        #endregion

        #region XML组装

        /// <summary>
        /// xml组装
        /// </summary>
        /// <param name="dt_bill"></param>
        /// <param name="dt_billdetail"></param>
        /// <param name="inHasUpdate4Claim"></param>
        /// <returns></returns>
        public string f_constructxml(DataTable inbill, DataTable inbilldetail)
        {
            //功能：上传数据
            // 入参：inbill主单信息，inbilldetail费用明细信息
            // 返回结果 1上传成功 0上传失败

            //返回结果参数
            //string l_s;
            //主单记录数
            int ii_billrowcount;
            //明细记录数
            int ii_billdetailrowcount;
            //获取主单记录数
            ii_billrowcount = inbill.Rows.Count;
            //获取明细记录数
            ii_billdetailrowcount = inbilldetail.Rows.Count;

            //定义审核失败返回参数 ，默认1，1成功 0失败
            //gs_auditflag = "1"
            // string l_error_message="";
            //校验主单记录集是否为空
            if (ii_billrowcount == 0)
            {
                l_error_message = "必须提供主单记录信息！";
                return "0";
            }
            if (ii_billrowcount > 1)
            {
                l_error_message = "一次只能传入一条主单记录信息！";
                return "0";
            }

            //上传数据初始化
            l_s = InitXML();
            if (!l_s.Equals("1"))
            {
                l_error_message = GetErrorMessage();
                return "0";
            }

            //经办保险机构类型ID
            //1市直医保 2省直医保,根据参保人实际类型确定，现在默认市直医保，程序员在修改时注意。
            string inAGENCIES_ID = inbill.Rows[0]["inAGENCIES_ID"].ToString();

            //如果是住院单据，如果已经调保存过单据，之后每天开的费用明细，如果没有诊断等信息更新，那么可以使用缓存的主单数据，
            //初始化主单信息是只需提供主单唯一ID即可，同时inHasUpdate4Claim字段需设置为True。否则设置为false。门诊单据一律为false
            //定义true为1，false为0，本标记状态需要HIS接口判断给定状态，

            //此接口状态需要HIS给定，需遵守上面规则
            //本demo默认状态是false及0，在实际接口中必须判断给定状态
            //取值为NULL时默认为0

            string inHasUpdate4Claim = inbill.Rows[0]["inHasUpdate4Claim"].ToString();
            if (string.IsNullOrEmpty(inHasUpdate4Claim))
            {
                inHasUpdate4Claim = "0";
            }

            //主单单据信息XML串
            //注意主单单据的组串顺序和字符串大小写，不能任意更改下列组串顺序
            string inClaimInfo = "";

            //人员类别id
            string BENEFIT_GROUP_ID = inbill.Rows[0]["BENEFIT_GROUP_ID"].ToString();
            if (string.IsNullOrEmpty(BENEFIT_GROUP_ID))
            {
                BENEFIT_GROUP_ID = "-1";
            }
            inClaimInfo = inClaimInfo + "<BENEFIT_GROUP_ID>" + BENEFIT_GROUP_ID + "</BENEFIT_GROUP_ID>";

            //参保类型id
            string BENEFIT_TYPE = inbill.Rows[0]["BENEFIT_TYPE"].ToString();
            if (string.IsNullOrEmpty(BENEFIT_TYPE))
            {
                BENEFIT_TYPE = "100";
            }
            inClaimInfo = inClaimInfo + "<BENEFIT_TYPE>" + BENEFIT_TYPE + "</BENEFIT_TYPE>";

            //医保内金额
            string BMI_CONVERED_AMOUNT = inbill.Rows[0]["BMI_CONVERED_AMOUNT"].ToString();
            if (string.IsNullOrEmpty(BMI_CONVERED_AMOUNT))
            {
                l_error_message = "医保内金额格式不规范，必须为数值型!";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<BMI_CONVERED_AMOUNT>" + BMI_CONVERED_AMOUNT + "</BMI_CONVERED_AMOUNT>";

            //待遇类型
            string CKC892 = inbill.Rows[0]["CKC892"].ToString();
            if (string.IsNullOrEmpty(CKC892))
            {
                CKC892 = "-99999";
            }
            inClaimInfo = inClaimInfo + "<CKC892>" + CKC892 + "</CKC892>";



            //入院诊断
            string DIAGNOSIS_IN = inbill.Rows[0]["DIAGNOSIS_IN"].ToString();
            if (string.IsNullOrEmpty(DIAGNOSIS_IN))
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_IN/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_IN>" + DIAGNOSIS_IN.Trim() + "</DIAGNOSIS_IN>";
            }


            //出院诊断
            string DIAGNOSIS_OUT = inbill.Rows[0]["DIAGNOSIS_OUT"].ToString();
            if (string.IsNullOrEmpty(DIAGNOSIS_OUT))
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_OUT/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_OUT>" + DIAGNOSIS_OUT.Trim() + "</DIAGNOSIS_OUT>";
            }


            //其他副诊断DIAGNOSIS_TOTHER
            string DIAGNOSIS_TOTHER = inbill.Rows[0]["DIAGNOSIS_TOTHER"].ToString();
            if (string.IsNullOrEmpty(DIAGNOSIS_TOTHER))
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_TOTHER/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_TOTHER>" + DIAGNOSIS_TOTHER.Trim() + "</DIAGNOSIS_TOTHER>";
            }


            //性别
            string GENDER = inbill.Rows[0]["GENDER"].ToString();
            if (string.IsNullOrEmpty(GENDER))
            {
                //默认未知
                GENDER = "-1";
            }
            inClaimInfo = inClaimInfo + "<GENDER>" + GENDER.Trim() + "</GENDER>";



            //医院id，从配置文件Audit4Hospital.ini获取,医院ID可以传入，也可以取配置文件
            string HOSPITAL_ID = inbill.Rows[0]["HOSPITAL_ID"].ToString();
            if (string.IsNullOrEmpty(HOSPITAL_ID))
            {
                inClaimInfo = inClaimInfo + "<HOSPITAL_ID/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HOSPITAL_ID>" + HOSPITAL_ID + "</HOSPITAL_ID>";
            }


            //医院等级，从配置文件Audit4Hospital.ini获取,医院ID可以传入，也可以取配置文件
            string HOSPITAL_LEVEL = inbill.Rows[0]["HOSPITAL_LEVEL"].ToString();
            if (string.IsNullOrEmpty(HOSPITAL_LEVEL))
            {
                inClaimInfo = inClaimInfo + "<HOSPITAL_LEVEL/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HOSPITAL_LEVEL>" + HOSPITAL_LEVEL + "</HOSPITAL_LEVEL>";
            }


            //医院病区
            string HS_AREA_CODE = inbill.Rows[0]["HS_AREA_CODE"].ToString();
            if (string.IsNullOrEmpty(HS_AREA_CODE))
            {
                inClaimInfo = inClaimInfo + "<HS_AREA_CODE/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_AREA_CODE>" + HS_AREA_CODE + "</HS_AREA_CODE>";
            }


            //入院诊断名称
            string HS_DIAGNOSIS_IN_NAME = inbill.Rows[0]["HS_DIAGNOSIS_IN_NAME"].ToString();
            if (string.IsNullOrEmpty(HS_DIAGNOSIS_IN_NAME))
            {
                inClaimInfo = inClaimInfo + "<HS_DIAGNOSIS_IN_NAME/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_DIAGNOSIS_IN_NAME>" + HS_DIAGNOSIS_IN_NAME + "</HS_DIAGNOSIS_IN_NAME>";
            }


            //出院诊断名称
            string HS_DIAGNOSIS_OUT_NAME = inbill.Rows[0]["HS_DIAGNOSIS_OUT_NAME"].ToString();
            if (string.IsNullOrEmpty(HS_DIAGNOSIS_OUT_NAME))
            {
                inClaimInfo = inClaimInfo + "<HS_DIAGNOSIS_OUT_NAME/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_DIAGNOSIS_OUT_NAME>" + HS_DIAGNOSIS_OUT_NAME + "</HS_DIAGNOSIS_OUT_NAME>";
            }


            //病案号（病人在医院看病的唯一登记号，只登记一次）
            string HS_IN_NUMBER = inbill.Rows[0]["HS_IN_NUMBER"].ToString();
            if (string.IsNullOrEmpty(HS_IN_NUMBER))
            {
                inClaimInfo = inClaimInfo + "<HS_IN_NUMBER/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_IN_NUMBER>" + HS_IN_NUMBER + "</HS_IN_NUMBER>";
            }


            //住院号门诊号
            string HS_NUMBER = inbill.Rows[0]["HS_NUMBER"].ToString();
            if (string.IsNullOrEmpty(HS_NUMBER))
            {
                inClaimInfo = inClaimInfo + "<HS_NUMBER/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_NUMBER>" + HS_NUMBER + "</HS_NUMBER>";
            }


            //参保人姓名
            string HS_PATIENT_NAME = inbill.Rows[0]["HS_PATIENT_NAME"].ToString();
            if (string.IsNullOrEmpty(HS_PATIENT_NAME))
            {
                inClaimInfo = inClaimInfo + "<HS_PATIENT_NAME/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_PATIENT_NAME>" + HS_PATIENT_NAME + "</HS_PATIENT_NAME>";
            }



            //住院状态（已结算1、未结算0，根据是否已经结算做判断）
            string HS_STATUS = inbill.Rows[0]["HS_STATUS"].ToString();
            if (string.IsNullOrEmpty(HS_STATUS))
            {
                //默认否
                HS_STATUS = "0";
            }
            inClaimInfo = inClaimInfo + "<HS_STATUS>" + HS_STATUS + "</HS_STATUS>";


            //定点机构类型，从配置文件Audit4Hospital.ini获取,医院ID可以传入，也可以取配置文件
            string HospitalType = inbill.Rows[0]["HospitalType"].ToString();
            if (string.IsNullOrEmpty(HospitalType))
            {
                inClaimInfo = inClaimInfo + "<HospitalType/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HospitalType>" + HospitalType + "</HospitalType>";
            }

            //唯一编码
            string ID = inbill.Rows[0]["ID"].ToString();
            if (string.IsNullOrEmpty(ID))
            {
                //id不能为空
                l_error_message = "主单id不能为空!";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<ID>" + ID + "</ID>";


            //入院日期
            string IN_DATE = inbill.Rows[0]["IN_DATE"].ToString();
            if (string.IsNullOrEmpty(IN_DATE) || IN_DATE.Equals("1900-01-01"))
            {
                l_error_message = "入院日期不能为空或1900-01-01！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<IN_DATE>" + IN_DATE + "</IN_DATE>";


            //是否哺乳期
            string IsLactation = inbill.Rows[0]["IsLactation"].ToString();
            if (string.IsNullOrEmpty(IsLactation))
            {
                //默认否
                IsLactation = "0";
            }
            inClaimInfo = inClaimInfo + "<IsLactation>" + IsLactation + "</IsLactation>";


            //是否孕期
            string IsPregnant = inbill.Rows[0]["IsPregnant"].ToString();
            if (string.IsNullOrEmpty(IsPregnant))
            {
                //默认否
                IsPregnant = "0";
            }
            inClaimInfo = inClaimInfo + "<IsPregnant>" + IsPregnant + "</IsPregnant>";


            //就医方式
            string MEDICAL_TYPE = inbill.Rows[0]["MEDICAL_TYPE"].ToString();
            if (string.IsNullOrEmpty(MEDICAL_TYPE))
            {
                l_error_message = "就医方式不能为空！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<MEDICAL_TYPE>" + MEDICAL_TYPE + "</MEDICAL_TYPE>";


            //出院日期
            string OUT_DATE = inbill.Rows[0]["OUT_DATE"].ToString();
            if (string.IsNullOrEmpty(OUT_DATE) || OUT_DATE.Equals("1900-01-01"))
            {
                l_error_message = "出院日期不能为空或1900-01-01！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<OUT_DATE>" + OUT_DATE + "</OUT_DATE>";


            //出生日期
            string PATIENT_BIRTH = inbill.Rows[0]["PATIENT_BIRTH"].ToString();
            if (string.IsNullOrEmpty(PATIENT_BIRTH) || PATIENT_BIRTH.Equals("1900-01-01"))
            {
                l_error_message = "出生日期不能为空或1900-01-01！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<PATIENT_BIRTH>" + PATIENT_BIRTH + "</PATIENT_BIRTH>";


            //特殊险种组编码，1生育2工伤-1其他
            string PatientBenefitGroupCode = inbill.Rows[0]["PatientBenefitGroupCode"].ToString();
            if (string.IsNullOrEmpty(PatientBenefitGroupCode))
            {
                //默认其他
                PatientBenefitGroupCode = "-1";
            }
            inClaimInfo = inClaimInfo + "<PatientBenefitGroupCode>" + PatientBenefitGroupCode + "</PatientBenefitGroupCode>";


            //参保人唯一编码
            string Patient_IDStr = inbill.Rows[0]["Patient_IDStr"].ToString();
            if (string.IsNullOrEmpty(Patient_IDStr))
            {
                l_error_message = "参保人编码不能为空！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<Patient_IDStr>" + Patient_IDStr + "</Patient_IDStr>";



            //单据结算日期
            string SETTLE_DATE = inbill.Rows[0]["SETTLE_DATE"].ToString();
            if (string.IsNullOrEmpty(SETTLE_DATE) || SETTLE_DATE.Equals("1900-01-01"))
            {
                l_error_message = "结算日期不能为空或1900-01-01！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<SETTLE_DATE>" + SETTLE_DATE + "</SETTLE_DATE>";


            //总费用
            string TOTAL_COST = inbill.Rows[0]["TOTAL_COST"].ToString();
            if (string.IsNullOrEmpty(TOTAL_COST))
            {
                //默认否
                TOTAL_COST = "0";
            }
            inClaimInfo = inClaimInfo + "<TOTAL_COST>" + TOTAL_COST + "</TOTAL_COST>";

            //异地就医
            string UNUSUAL_FLAG = inbill.Rows[0]["UNUSUAL_FLAG"].ToString();
            if (string.IsNullOrEmpty(UNUSUAL_FLAG))
            {
                //默认否
                UNUSUAL_FLAG = "0";
            }
            inClaimInfo = inClaimInfo + "<UNUSUAL_FLAG>" + UNUSUAL_FLAG + "</UNUSUAL_FLAG>";

            //一至六级残疾军人待核标志
            string Z_AACT007 = inbill.Rows[0]["Z_AACT007"].ToString();
            if (string.IsNullOrEmpty(Z_AACT007))
            {
                //默认否
                Z_AACT007 = "0";
            }
            inClaimInfo = inClaimInfo + "<Z_AACT007>" + Z_AACT007 + "</Z_AACT007>";

            //因战因公标志: 0和1
            string Z_AACT008 = inbill.Rows[0]["Z_AACT008"].ToString();
            if (string.IsNullOrEmpty(Z_AACT008))
            {
                //默认否
                Z_AACT008 = "0";
            }
            inClaimInfo = inClaimInfo + "<Z_AACT008>" + Z_AACT008 + "</Z_AACT008>";

            //保健类别
            string Z_BAC021 = inbill.Rows[0]["Z_BAC021"].ToString();
            if (string.IsNullOrEmpty(Z_BAC021))
            {
                //默认否
                Z_BAC021 = "0";
            }
            inClaimInfo = inClaimInfo + "<Z_BAC021>" + Z_BAC021 + "</Z_BAC021>";

            //主信息上传函数调用，返回结果1成功上传，0失败
            l_s = "";
            l_s = UploadClaimInfo(inHasUpdate4Claim, inAGENCIES_ID, inClaimInfo);

            //主单上传成功     1成功 0失败
            //上传明细信息组装
            if (l_s.Equals("1"))
            {
                for (int ll_row = 0; ll_row < ii_billdetailrowcount; ++ll_row)
                {
                    //费用明细ID		
                    string IDb;
                    IDb = inbilldetail.Rows[ll_row]["ID"].ToString();
                    if (IDb.Equals(""))
                    {
                        IDb = "";
                    }

                    //明细信息
                    //注意明细的组串顺序和字符串大小写，不能任意更改下列组串顺序
                    string inDeatilInfo = "";

                    //帖数
                    string AKF003 = inbilldetail.Rows[ll_row]["AKF003"].ToString();
                    if (string.IsNullOrEmpty(AKF003))
                    {
                        AKF003 = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<AKF003>" + AKF003 + "</AKF003>";

                    //出国带药标志
                    string AKF005 = inbilldetail.Rows[ll_row]["AKF005"].ToString();
                    if (string.IsNullOrEmpty(AKF005))
                    {
                        AKF005 = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<AKF005>" + AKF005 + "</AKF005>";

                    //备案审批号
                    string ApprovalNumber = inbilldetail.Rows[ll_row]["ApprovalNumber"].ToString();
                    if (string.IsNullOrEmpty(ApprovalNumber))
                    {
                        inDeatilInfo = inDeatilInfo + "<ApprovalNumber/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<ApprovalNumber>" + ApprovalNumber + "</ApprovalNumber>";
                    }


                    //因公因战
                    string BKA609 = inbilldetail.Rows[ll_row]["BKA609"].ToString();
                    if (string.IsNullOrEmpty(BKA609))
                    {
                        BKA609 = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<BKA609>" + BKA609 + "</BKA609>";

                    //外院费用标志
                    string BKC227 = inbilldetail.Rows[ll_row]["BKC227"].ToString();
                    if (string.IsNullOrEmpty(BKC227))
                    {
                        BKC227 = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<BKC227>" + BKC227 + "</BKC227>";

                    //明细金额
                    string COSTS = inbilldetail.Rows[ll_row]["COSTS"].ToString();
                    if (string.IsNullOrEmpty(COSTS))
                    {
                        COSTS = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<COSTS>" + COSTS + "</COSTS>";

                    //科室名称
                    string DEPTNAME = inbilldetail.Rows[ll_row]["DEPTNAME"].ToString();
                    if (string.IsNullOrEmpty(DEPTNAME))
                    {
                        inDeatilInfo = inDeatilInfo + "<DEPTNAME/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<DEPTNAME>" + DEPTNAME + "</DEPTNAME>";
                    }


                    //医保内金额
                    string ELIGIBLE_AMOUNT = inbilldetail.Rows[ll_row]["ELIGIBLE_AMOUNT"].ToString();
                    if (string.IsNullOrEmpty(ELIGIBLE_AMOUNT))
                    {
                        ELIGIBLE_AMOUNT = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<ELIGIBLE_AMOUNT>" + ELIGIBLE_AMOUNT + "</ELIGIBLE_AMOUNT>";



                    //使用频次
                    string FREQUENCY_INTERVAL = inbilldetail.Rows[ll_row]["FREQUENCY_INTERVAL"].ToString();
                    if (string.IsNullOrEmpty(FREQUENCY_INTERVAL))
                    {
                        inDeatilInfo = inDeatilInfo + "<FREQUENCY_INTERVAL/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<FREQUENCY_INTERVAL>" + FREQUENCY_INTERVAL + "</FREQUENCY_INTERVAL>";
                    }

                    //单据费用ID
                    inDeatilInfo = inDeatilInfo + "<ID>" + IDb + "</ID>";


                    //费用日期
                    string ITEM_DATE = inbilldetail.Rows[ll_row]["ITEM_DATE"].ToString();
                    if (string.IsNullOrEmpty(ITEM_DATE))
                    {
                        l_error_message = "费用日期不能为空！";
                        return "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<ITEM_DATE>" + ITEM_DATE + "</ITEM_DATE>";

                    //项目编码
                    string ITEM_ID = inbilldetail.Rows[ll_row]["ITEM_ID"].ToString();
                    if (string.IsNullOrEmpty(ITEM_ID))
                    {
                        inDeatilInfo = inDeatilInfo + "<ITEM_ID/>";
                    }
                    else
                    {
                        //转换成小写，项目编码都转换成小写
                        inDeatilInfo = inDeatilInfo + "<ITEM_ID>" + ITEM_ID.ToLower() + "</ITEM_ID>";
                    }

                    //项目名称
                    string ITEM_NAME = inbilldetail.Rows[ll_row]["ITEM_NAME"].ToString();
                    if (string.IsNullOrEmpty(ITEM_NAME))
                    {
                        inDeatilInfo = inDeatilInfo + "<ITEM_NAME/>";
                    }
                    else
                    {
                        //先转换成string
                        string _item_name = "";
                        _item_name = ITEM_NAME;
                        //查找字符串中存在＜

                        if (_item_name.IndexOf("<") > -1)
                        {
                            string p1 = "<";
                            string p2 = "《";
                            _item_name = _item_name.Replace(p1, p2);
                        }

                        if (_item_name.IndexOf(">") > -1)
                        {
                            string p1 = ">";
                            string p2 = "》";
                            _item_name = _item_name.Replace(p1, p2);
                        }
                        ITEM_NAME = _item_name;
                        inDeatilInfo = inDeatilInfo + "<ITEM_NAME>" + ITEM_NAME + "</ITEM_NAME>";
                    }

                    //项目类型
                    string ITEM_TYPE = inbilldetail.Rows[ll_row]["ITEM_TYPE"].ToString();
                    if (string.IsNullOrEmpty(ITEM_TYPE))
                    {
                        inDeatilInfo = inDeatilInfo + "<ITEM_TYPE/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<ITEM_TYPE>" + ITEM_TYPE + "</ITEM_TYPE>";
                    }

                    //数量
                    string NUMBERS = inbilldetail.Rows[ll_row]["NUMBERS"].ToString();
                    if (string.IsNullOrEmpty(NUMBERS))
                    {
                        NUMBERS = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<NUMBERS>" + NUMBERS + "</NUMBERS>";

                    //单价
                    string PRICE = inbilldetail.Rows[ll_row]["PRICE"].ToString();
                    if (string.IsNullOrEmpty(PRICE))
                    {
                        PRICE = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<PRICE>" + PRICE + "</PRICE>";

                    //医师级别
                    string PhysicianLevel = inbilldetail.Rows[ll_row]["PhysicianLevel"].ToString();
                    if (string.IsNullOrEmpty(PhysicianLevel))
                    {
                        inDeatilInfo = inDeatilInfo + "<PhysicianLevel/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<PhysicianLevel>" + PhysicianLevel + "</PhysicianLevel>";
                    }

                    //规格
                    string Specification = inbilldetail.Rows[ll_row]["Specification"].ToString();
                    if (string.IsNullOrEmpty(Specification))
                    {
                        inDeatilInfo = inDeatilInfo + "<Specification/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<Specification>" + Specification + "</Specification>";
                    }

                    //每次用量
                    string USAGE = inbilldetail.Rows[ll_row]["USAGE"].ToString();
                    if (string.IsNullOrEmpty(USAGE))
                    {
                        l_error_message = "每次用量必须为数值型，西药最多保留小数位2位！";
                        return "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<USAGE>" + USAGE + "</USAGE>";

                    //用药天数
                    string USAGE_DAYS = inbilldetail.Rows[ll_row]["USAGE_DAYS"].ToString();
                    if (string.IsNullOrEmpty(USAGE_DAYS))
                    {
                        USAGE_DAYS = "-1";
                    }
                    inDeatilInfo = inDeatilInfo + "<USAGE_DAYS>" + USAGE_DAYS + "</USAGE_DAYS>";

                    //包装单位
                    string USAGE_UNIT = inbilldetail.Rows[ll_row]["USAGE_UNIT"].ToString();
                    if (string.IsNullOrEmpty(USAGE_UNIT))
                    {
                        inDeatilInfo = inDeatilInfo + "<USAGE_UNIT/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<USAGE_UNIT>" + USAGE_UNIT + "</USAGE_UNIT>";
                    }

                    //计费标记 是否已计费 -1 未设置，0未计费，1计费
                    string ZZZ_Flag = inbilldetail.Rows[ll_row]["ZZZ_Flag"].ToString();
                    if (string.IsNullOrEmpty(ZZZ_Flag))
                    {
                        ZZZ_Flag = "-1";
                    }
                    inDeatilInfo = inDeatilInfo + "<ZZZ_Flag>" + ZZZ_Flag + "</ZZZ_Flag>";

                    //医师职务
                    string Z_PhysicianAP = inbilldetail.Rows[ll_row]["Z_PhysicianAP"].ToString();
                    if (string.IsNullOrEmpty(Z_PhysicianAP))
                    {
                        inDeatilInfo = inDeatilInfo + "<Z_PhysicianAP/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<Z_PhysicianAP>" + Z_PhysicianAP + "</Z_PhysicianAP>";
                    }


                    string l_IsFirst, l_IsLast;
                    //判断是否是一条记录
                    if (ii_billdetailrowcount == 1)
                    {
                        l_IsFirst = "1";
                        l_IsLast = "1";
                    }
                    else
                    {
                        //首行
                        if (ll_row == 0)
                        {
                            l_IsFirst = "1";
                            l_IsLast = "0";
                        }
                        //最后一行
                        else if (ll_row == ii_billdetailrowcount - 1)
                        {
                            l_IsFirst = "0";
                            l_IsLast = "1";
                        }
                        //不是首行且不是最后一行
                        else
                        {
                            l_IsFirst = "0";
                            l_IsLast = "0";
                        }
                    }
                    //调用上传明细函数，返回参数 l_S 1成功 0失败				
                    l_s = UploadDetailInfo(l_IsFirst, l_IsLast, inDeatilInfo);
                    if (l_s.Equals("0"))
                    {
                        l_error_message = GetErrorMessage();
                        return "0";
                    }
                    else if (l_s.Equals("2"))
                    {
                        l_error_message = "调用步骤出错";
                        return "0";
                    }
                }
            }
            else if (l_s.Equals("0"))
            {
                l_error_message = GetErrorMessage();
                return "0";
            }
            else
            {
                l_error_message = "调用步骤出错";
                return "0";
            }

            return "1";
        }

        /// <summary>
        /// xml组装
        /// </summary>
        /// <param name="dt_bill"></param>
        /// <param name="dt_billdetail"></param>
        /// <param name="inHasUpdate4Claim"></param>
        /// <returns></returns>
        public string f_constructxml1(DataTable inbill, DataTable inbilldetail)
        {
            //功能：上传数据
            // 入参：inbill主单信息，inbilldetail费用明细信息
            // 返回结果 1上传成功 0上传失败



            //返回结果参数
            //string l_s;
            //主单记录数
            int ii_billrowcount;
            //明细记录数
            int ii_billdetailrowcount;
            //获取主单记录数
            ii_billrowcount = inbill.Rows.Count;
            //获取明细记录数
            ii_billdetailrowcount = inbilldetail.Rows.Count;

            //定义审核失败返回参数 ，默认1，1成功 0失败
            //gs_auditflag = "1"
            // string l_error_message="";

            //校验主单记录集是否为空
            if (ii_billrowcount == 0)
            {
                l_error_message = "必须提供主单记录信息！";
                return "0";
            }
            if (ii_billrowcount > 1)
            {
                l_error_message = "一次只能传入一条主单记录信息！";
                return "0";
            }

            //校验主单记录集是否为空
            if (ii_billdetailrowcount <= 0)
            {
                l_error_message = "必须提供明细单记录信息！";
                return "0";
            }

            //上传数据初始化
            l_s = InitXML();
            if (!l_s.Equals("1"))
            {
                l_error_message = GetErrorMessage();
                return "0";
            }

            //经办保险机构类型ID
            //1市直医保 2省直医保,根据参保人实际类型确定，现在默认市直医保，程序员在修改时注意。
            //string inAGENCIES_ID = "1";//2省直医保  属于公费   //inbill.Rows[0]["inAGENCIES_ID"].ToString();
            string inAGENCIES_ID = inbill.Rows[0]["inAGENCIES_ID"].ToString(); ;//2省直医保  属于公费   //inbill.Rows[0]["inAGENCIES_ID"].ToString();
            //如果是住院单据，如果已经调保存过单据，之后每天开的费用明细，如果没有诊断等信息更新，那么可以使用缓存的主单数据，
            //初始化主单信息是只需提供主单唯一ID即可，同时inHasUpdate4Claim字段需设置为True。否则设置为false。门诊单据一律为false
            //定义true为1，false为0，本标记状态需要HIS接口判断给定状态，

            //此接口状态需要HIS给定，需遵守上面规则
            //本demo默认状态是false及0，在实际接口中必须判断给定状态
            //取值为NULL时默认为0
            //modify by jchl:增量处理   判断主单id的金额AuditGetCostsResult(string inClaimID,string inAGENCIES_ID)
            string inHasUpdate4Claim = inbill.Rows[0]["inHasUpdate4Claim"].ToString();
            if (string.IsNullOrEmpty(inHasUpdate4Claim))
            {
                inHasUpdate4Claim = "0";
                //唯一编码
                string inpId = inbill.Rows[0]["ID"].ToString();
                if (string.IsNullOrEmpty(inpId))
                {
                    //id不能为空
                    l_error_message = "主单id不能为空!";
                    return "0";
                }
                string allMoney = AuditGetCostsResult(inpId, inAGENCIES_ID);
                if (decimal.Parse(allMoney) > 0)
                {
                    inHasUpdate4Claim = "1";//增量
                }
                else
                {
                    inHasUpdate4Claim = "0";//非增量
                }
            }

            //主单单据信息XML串
            //注意主单单据的组串顺序和字符串大小写，不能任意更改下列组串顺序
            string inClaimInfo = "";

            //人员类别id
            string BENEFIT_GROUP_ID = inbill.Rows[0]["BENEFIT_GROUP_ID"].ToString();
            if (string.IsNullOrEmpty(BENEFIT_GROUP_ID))
            {
                BENEFIT_GROUP_ID = "-1";
                //BENEFIT_GROUP_ID = "11";
            }
            inClaimInfo = inClaimInfo + "<BENEFIT_GROUP_ID>" + BENEFIT_GROUP_ID + "</BENEFIT_GROUP_ID>";

            //参保类型id
            string BENEFIT_TYPE = inbill.Rows[0]["BENEFIT_TYPE"].ToString();
            if (string.IsNullOrEmpty(BENEFIT_TYPE))
            {
                BENEFIT_TYPE = "100";
            }
            inClaimInfo = inClaimInfo + "<BENEFIT_TYPE>" + BENEFIT_TYPE + "</BENEFIT_TYPE>";

            //医保内金额（明细总金额）
            string BMI_CONVERED_AMOUNT = inbill.Rows[0]["BMI_CONVERED_AMOUNT"].ToString();
            if (string.IsNullOrEmpty(BMI_CONVERED_AMOUNT))
            {
                l_error_message = "医保内金额格式不规范，必须为数值型!";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<BMI_CONVERED_AMOUNT>" + BMI_CONVERED_AMOUNT + "</BMI_CONVERED_AMOUNT>";

            //待遇类型（默认为""）
            string CKC892 = inbill.Rows[0]["CKC892"].ToString();
            if (string.IsNullOrEmpty(CKC892))
            {
                CKC892 = "-99999";
            }
            inClaimInfo = inClaimInfo + "<CKC892>" + CKC892 + "</CKC892>";



            //入院诊断
            string DIAGNOSIS_IN = inbill.Rows[0]["DIAGNOSIS_IN"].ToString();
            if (string.IsNullOrEmpty(DIAGNOSIS_IN))
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_IN/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_IN>" + DIAGNOSIS_IN.Trim() + "</DIAGNOSIS_IN>";
            }


            //出院诊断
            string DIAGNOSIS_OUT = inbill.Rows[0]["DIAGNOSIS_OUT"].ToString();
            if (string.IsNullOrEmpty(DIAGNOSIS_OUT))
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_OUT/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_OUT>" + DIAGNOSIS_OUT.Trim() + "</DIAGNOSIS_OUT>";
            }


            //其他副诊断DIAGNOSIS_TOTHER
            string DIAGNOSIS_TOTHER = inbill.Rows[0]["DIAGNOSIS_TOTHER"].ToString();
            if (string.IsNullOrEmpty(DIAGNOSIS_TOTHER))
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_TOTHER/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<DIAGNOSIS_TOTHER>" + DIAGNOSIS_TOTHER.Trim() + "</DIAGNOSIS_TOTHER>";
            }


            //性别
            string GENDER = inbill.Rows[0]["GENDER"].ToString();
            if (string.IsNullOrEmpty(GENDER))
            {
                //默认未知
                GENDER = "-1";
            }
            inClaimInfo = inClaimInfo + "<GENDER>" + GENDER.Trim() + "</GENDER>";



            //医院id，从配置文件Audit4Hospital.ini获取,医院ID可以传入，也可以取配置文件
            string HOSPITAL_ID = inbill.Rows[0]["HOSPITAL_ID"].ToString();
            if (string.IsNullOrEmpty(HOSPITAL_ID))
            {
                inClaimInfo = inClaimInfo + "<HOSPITAL_ID/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HOSPITAL_ID>" + HOSPITAL_ID + "</HOSPITAL_ID>";
            }


            //医院等级，从配置文件Audit4Hospital.ini获取,医院ID可以传入，也可以取配置文件
            string HOSPITAL_LEVEL = inbill.Rows[0]["HOSPITAL_LEVEL"].ToString();
            if (string.IsNullOrEmpty(HOSPITAL_LEVEL))
            {
                inClaimInfo = inClaimInfo + "<HOSPITAL_LEVEL/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HOSPITAL_LEVEL>" + HOSPITAL_LEVEL + "</HOSPITAL_LEVEL>";
            }


            //医院病区
            string HS_AREA_CODE = inbill.Rows[0]["HS_AREA_CODE"].ToString();
            if (string.IsNullOrEmpty(HS_AREA_CODE))
            {
                inClaimInfo = inClaimInfo + "<HS_AREA_CODE/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_AREA_CODE>" + HS_AREA_CODE + "</HS_AREA_CODE>";
            }


            //入院诊断名称
            string HS_DIAGNOSIS_IN_NAME = inbill.Rows[0]["HS_DIAGNOSIS_IN_NAME"].ToString();
            if (string.IsNullOrEmpty(HS_DIAGNOSIS_IN_NAME))
            {
                inClaimInfo = inClaimInfo + "<HS_DIAGNOSIS_IN_NAME/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_DIAGNOSIS_IN_NAME>" + HS_DIAGNOSIS_IN_NAME + "</HS_DIAGNOSIS_IN_NAME>";
            }


            //出院诊断名称
            string HS_DIAGNOSIS_OUT_NAME = inbill.Rows[0]["HS_DIAGNOSIS_OUT_NAME"].ToString();
            if (string.IsNullOrEmpty(HS_DIAGNOSIS_OUT_NAME))
            {
                inClaimInfo = inClaimInfo + "<HS_DIAGNOSIS_OUT_NAME/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_DIAGNOSIS_OUT_NAME>" + HS_DIAGNOSIS_OUT_NAME + "</HS_DIAGNOSIS_OUT_NAME>";
            }


            //病案号（病人在医院看病的唯一登记号，只登记一次）
            string HS_IN_NUMBER = inbill.Rows[0]["HS_IN_NUMBER"].ToString();
            if (string.IsNullOrEmpty(HS_IN_NUMBER))
            {
                inClaimInfo = inClaimInfo + "<HS_IN_NUMBER/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_IN_NUMBER>" + HS_IN_NUMBER + "</HS_IN_NUMBER>";
            }


            //住院号门诊号
            string HS_NUMBER = inbill.Rows[0]["HS_NUMBER"].ToString();
            if (string.IsNullOrEmpty(HS_NUMBER))
            {
                inClaimInfo = inClaimInfo + "<HS_NUMBER/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_NUMBER>" + HS_NUMBER + "</HS_NUMBER>";
            }


            //参保人姓名
            string HS_PATIENT_NAME = inbill.Rows[0]["HS_PATIENT_NAME"].ToString();
            if (string.IsNullOrEmpty(HS_PATIENT_NAME))
            {
                inClaimInfo = inClaimInfo + "<HS_PATIENT_NAME/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HS_PATIENT_NAME>" + HS_PATIENT_NAME + "</HS_PATIENT_NAME>";
            }



            //住院状态（已结算1、未结算0，根据是否已经结算做判断）
            string HS_STATUS = inbill.Rows[0]["HS_STATUS"].ToString();
            if (string.IsNullOrEmpty(HS_STATUS))
            {
                //默认否
                HS_STATUS = "0";
            }
            inClaimInfo = inClaimInfo + "<HS_STATUS>" + HS_STATUS + "</HS_STATUS>";


            //定点机构类型，从配置文件Audit4Hospital.ini获取,医院ID可以传入，也可以取配置文件
            string HospitalType = inbill.Rows[0]["HospitalType"].ToString();
            if (string.IsNullOrEmpty(HospitalType))
            {
                inClaimInfo = inClaimInfo + "<HospitalType/>";
            }
            else
            {
                inClaimInfo = inClaimInfo + "<HospitalType>" + HospitalType + "</HospitalType>";
            }



            //唯一编码
            string ID = inbill.Rows[0]["ID"].ToString();
            if (string.IsNullOrEmpty(ID))
            {
                //id不能为空
                l_error_message = "主单id不能为空!";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<ID>" + ID + "</ID>";


            //入院日期
            string IN_DATE = inbill.Rows[0]["IN_DATE"].ToString();
            if (string.IsNullOrEmpty(IN_DATE) || IN_DATE.Equals("1900-01-01"))
            {
                l_error_message = "入院日期不能为空或1900-01-01！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<IN_DATE>" + IN_DATE + "</IN_DATE>";


            //是否哺乳期
            string IsLactation = inbill.Rows[0]["IsLactation"].ToString();
            if (string.IsNullOrEmpty(IsLactation))
            {
                //默认否
                IsLactation = "0";
            }
            inClaimInfo = inClaimInfo + "<IsLactation>" + IsLactation + "</IsLactation>";


            //是否孕期
            string IsPregnant = inbill.Rows[0]["IsPregnant"].ToString();
            if (string.IsNullOrEmpty(IsPregnant))
            {
                //默认否
                IsPregnant = "0";
            }
            inClaimInfo = inClaimInfo + "<IsPregnant>" + IsPregnant + "</IsPregnant>";


            //就医方式
            string MEDICAL_TYPE = inbill.Rows[0]["MEDICAL_TYPE"].ToString();
            if (string.IsNullOrEmpty(MEDICAL_TYPE))
            {
                l_error_message = "就医方式不能为空！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<MEDICAL_TYPE>" + MEDICAL_TYPE + "</MEDICAL_TYPE>";
            //inClaimInfo = inClaimInfo + "<MEDICAL_TYPE>" + 22 + "</MEDICAL_TYPE>";//Modify by jchl 05-19 wait


            //出院日期
            string OUT_DATE = inbill.Rows[0]["OUT_DATE"].ToString();
            if (string.IsNullOrEmpty(OUT_DATE) || OUT_DATE.Equals("1900-01-01"))
            {
                l_error_message = "出院日期不能为空或1900-01-01！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<OUT_DATE>" + OUT_DATE + "</OUT_DATE>";


            //出生日期
            string PATIENT_BIRTH = inbill.Rows[0]["PATIENT_BIRTH"].ToString();
            if (string.IsNullOrEmpty(PATIENT_BIRTH) || PATIENT_BIRTH.Equals("1900-01-01"))
            {
                l_error_message = "出生日期不能为空或1900-01-01！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<PATIENT_BIRTH>" + PATIENT_BIRTH + "</PATIENT_BIRTH>";


            //特殊险种组编码，1生育2工伤-1其他
            string PatientBenefitGroupCode = inbill.Rows[0]["PatientBenefitGroupCode"].ToString();
            if (string.IsNullOrEmpty(PatientBenefitGroupCode))
            {
                //默认其他
                PatientBenefitGroupCode = "-1";
            }
            inClaimInfo = inClaimInfo + "<PatientBenefitGroupCode>" + PatientBenefitGroupCode + "</PatientBenefitGroupCode>";


            //参保人唯一编码
            string Patient_IDStr = inbill.Rows[0]["Patient_IDStr"].ToString();
            if (string.IsNullOrEmpty(Patient_IDStr))
            {
                l_error_message = "参保人编码不能为空！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<Patient_IDStr>" + Patient_IDStr + "</Patient_IDStr>";



            //单据结算日期
            string SETTLE_DATE = inbill.Rows[0]["SETTLE_DATE"].ToString();
            if (string.IsNullOrEmpty(SETTLE_DATE) || SETTLE_DATE.Equals("1900-01-01"))
            {
                l_error_message = "结算日期不能为空或1900-01-01！";
                return "0";
            }
            inClaimInfo = inClaimInfo + "<SETTLE_DATE>" + SETTLE_DATE + "</SETTLE_DATE>";


            //总费用
            string TOTAL_COST = inbill.Rows[0]["TOTAL_COST"].ToString();
            if (string.IsNullOrEmpty(TOTAL_COST))
            {
                //默认否
                TOTAL_COST = "0";
            }
            inClaimInfo = inClaimInfo + "<TOTAL_COST>" + TOTAL_COST + "</TOTAL_COST>";

            //异地就医
            string UNUSUAL_FLAG = inbill.Rows[0]["UNUSUAL_FLAG"].ToString();
            if (string.IsNullOrEmpty(UNUSUAL_FLAG))
            {
                //默认否
                UNUSUAL_FLAG = "0";
            }
            inClaimInfo = inClaimInfo + "<UNUSUAL_FLAG>" + UNUSUAL_FLAG + "</UNUSUAL_FLAG>";

            //一至六级残疾军人待核标志
            string Z_AACT007 = inbill.Rows[0]["Z_AACT007"].ToString();
            if (string.IsNullOrEmpty(Z_AACT007))
            {
                //默认否
                Z_AACT007 = "0";
            }
            inClaimInfo = inClaimInfo + "<Z_AACT007>" + Z_AACT007 + "</Z_AACT007>";

            //因战因公标志: 0和1
            string Z_AACT008 = inbill.Rows[0]["Z_AACT008"].ToString();
            if (string.IsNullOrEmpty(Z_AACT008))
            {
                //默认否
                Z_AACT008 = "0";
            }
            inClaimInfo = inClaimInfo + "<Z_AACT008>" + Z_AACT008 + "</Z_AACT008>";

            //保健类别
            string Z_BAC021 = inbill.Rows[0]["Z_BAC021"].ToString();
            if (string.IsNullOrEmpty(Z_BAC021))
            {
                //默认否
                Z_BAC021 = "0";
            }
            inClaimInfo = inClaimInfo + "<Z_BAC021>" + Z_BAC021 + "</Z_BAC021>";

            //主信息上传函数调用，返回结果1成功上传，0失败
            l_s = "";
            l_s = UploadClaimInfo(inHasUpdate4Claim, inAGENCIES_ID, inClaimInfo);

            //主单上传成功     1成功 0失败
            //上传明细信息组装
            if (l_s.Equals("1"))
            {
                for (int ll_row = 0; ll_row < ii_billdetailrowcount; ++ll_row)
                {
                    //费用明细ID		
                    string IDb;
                    IDb = inbilldetail.Rows[ll_row]["ID"].ToString();
                    if (IDb.Equals(""))
                    {
                        IDb = "";
                    }

                    //明细信息
                    //注意明细的组串顺序和字符串大小写，不能任意更改下列组串顺序
                    string inDeatilInfo = "";

                    //帖数
                    string AKF003 = inbilldetail.Rows[ll_row]["AKF003"].ToString();
                    if (string.IsNullOrEmpty(AKF003))
                    {
                        AKF003 = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<AKF003>" + AKF003 + "</AKF003>";

                    //出国带药标志
                    string AKF005 = inbilldetail.Rows[ll_row]["AKF005"].ToString();
                    if (string.IsNullOrEmpty(AKF005))
                    {
                        AKF005 = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<AKF005>" + AKF005 + "</AKF005>";

                    //备案审批号
                    string ApprovalNumber = inbilldetail.Rows[ll_row]["ApprovalNumber"].ToString();
                    if (string.IsNullOrEmpty(ApprovalNumber))
                    {
                        inDeatilInfo = inDeatilInfo + "<ApprovalNumber/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<ApprovalNumber>" + ApprovalNumber + "</ApprovalNumber>";
                    }


                    //因公因战
                    string BKA609 = inbilldetail.Rows[ll_row]["BKA609"].ToString();
                    if (string.IsNullOrEmpty(BKA609))
                    {
                        BKA609 = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<BKA609>" + BKA609 + "</BKA609>";

                    //外院费用标志
                    string BKC227 = inbilldetail.Rows[ll_row]["BKC227"].ToString();
                    if (string.IsNullOrEmpty(BKC227))
                    {
                        BKC227 = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<BKC227>" + BKC227 + "</BKC227>";

                    //明细金额
                    string COSTS = inbilldetail.Rows[ll_row]["COSTS"].ToString();
                    if (string.IsNullOrEmpty(COSTS))
                    {
                        COSTS = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<COSTS>" + COSTS + "</COSTS>";

                    //科室名称
                    string DEPTNAME = inbilldetail.Rows[ll_row]["DEPTNAME"].ToString();
                    if (string.IsNullOrEmpty(DEPTNAME))
                    {
                        inDeatilInfo = inDeatilInfo + "<DEPTNAME/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<DEPTNAME>" + DEPTNAME + "</DEPTNAME>";
                    }


                    //医保内金额
                    string ELIGIBLE_AMOUNT = inbilldetail.Rows[ll_row]["ELIGIBLE_AMOUNT"].ToString();
                    if (string.IsNullOrEmpty(ELIGIBLE_AMOUNT))
                    {
                        ELIGIBLE_AMOUNT = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<ELIGIBLE_AMOUNT>" + ELIGIBLE_AMOUNT + "</ELIGIBLE_AMOUNT>";



                    //使用频次
                    string FREQUENCY_INTERVAL = inbilldetail.Rows[ll_row]["FREQUENCY_INTERVAL"].ToString();
                    if (string.IsNullOrEmpty(FREQUENCY_INTERVAL))
                    {
                        inDeatilInfo = inDeatilInfo + "<FREQUENCY_INTERVAL/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<FREQUENCY_INTERVAL>" + FREQUENCY_INTERVAL + "</FREQUENCY_INTERVAL>";
                    }

                    //单据费用ID
                    inDeatilInfo = inDeatilInfo + "<ID>" + IDb + "</ID>";


                    //费用日期
                    string ITEM_DATE = inbilldetail.Rows[ll_row]["ITEM_DATE"].ToString();
                    if (string.IsNullOrEmpty(ITEM_DATE))
                    {
                        l_error_message = "费用日期不能为空！";
                        return "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<ITEM_DATE>" + ITEM_DATE + "</ITEM_DATE>";

                    //项目编码
                    string ITEM_ID = inbilldetail.Rows[ll_row]["ITEM_ID"].ToString();
                    if (string.IsNullOrEmpty(ITEM_ID))
                    {
                        inDeatilInfo = inDeatilInfo + "<ITEM_ID/>";
                    }
                    else
                    {
                        //转换成小写，项目编码都转换成小写
                        inDeatilInfo = inDeatilInfo + "<ITEM_ID>" + ITEM_ID.ToLower() + "</ITEM_ID>";
                    }

                    //项目名称
                    string ITEM_NAME = inbilldetail.Rows[ll_row]["ITEM_NAME"].ToString();
                    if (string.IsNullOrEmpty(ITEM_NAME))
                    {
                        inDeatilInfo = inDeatilInfo + "<ITEM_NAME/>";
                    }
                    else
                    {
                        //先转换成string
                        string _item_name = "";
                        _item_name = ITEM_NAME;
                        //查找字符串中存在＜

                        if (_item_name.IndexOf("<") > -1)
                        {
                            string p1 = "<";
                            string p2 = "《";
                            _item_name = _item_name.Replace(p1, p2);
                        }

                        if (_item_name.IndexOf(">") > -1)
                        {
                            string p1 = ">";
                            string p2 = "》";
                            _item_name = _item_name.Replace(p1, p2);
                        }
                        ITEM_NAME = _item_name;
                        inDeatilInfo = inDeatilInfo + "<ITEM_NAME>" + ITEM_NAME + "</ITEM_NAME>";
                    }

                    //项目类型
                    string ITEM_TYPE = inbilldetail.Rows[ll_row]["ITEM_TYPE"].ToString();
                    if (string.IsNullOrEmpty(ITEM_TYPE))
                    {
                        inDeatilInfo = inDeatilInfo + "<ITEM_TYPE/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<ITEM_TYPE>" + ITEM_TYPE + "</ITEM_TYPE>";
                    }

                    //数量
                    string NUMBERS = inbilldetail.Rows[ll_row]["NUMBERS"].ToString();
                    if (string.IsNullOrEmpty(NUMBERS))
                    {
                        NUMBERS = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<NUMBERS>" + NUMBERS + "</NUMBERS>";

                    //单价
                    string PRICE = inbilldetail.Rows[ll_row]["PRICE"].ToString();
                    if (string.IsNullOrEmpty(PRICE))
                    {
                        PRICE = "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<PRICE>" + PRICE + "</PRICE>";

                    //医师级别
                    string PhysicianLevel = inbilldetail.Rows[ll_row]["PhysicianLevel"].ToString();
                    if (string.IsNullOrEmpty(PhysicianLevel))
                    {
                        inDeatilInfo = inDeatilInfo + "<PhysicianLevel/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<PhysicianLevel>" + PhysicianLevel + "</PhysicianLevel>";
                    }

                    //规格
                    string Specification = inbilldetail.Rows[ll_row]["Specification"].ToString();
                    if (string.IsNullOrEmpty(Specification))
                    {
                        inDeatilInfo = inDeatilInfo + "<Specification/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<Specification>" + Specification + "</Specification>";
                    }

                    //每次用量
                    string USAGE = inbilldetail.Rows[ll_row]["USAGE"].ToString();
                    if (string.IsNullOrEmpty(USAGE))
                    {
                        l_error_message = "每次用量必须为数值型，西药最多保留小数位2位！";
                        return "0";
                    }
                    inDeatilInfo = inDeatilInfo + "<USAGE>" + USAGE + "</USAGE>";

                    //用药天数
                    string USAGE_DAYS = inbilldetail.Rows[ll_row]["USAGE_DAYS"].ToString();
                    if (string.IsNullOrEmpty(USAGE_DAYS))
                    {
                        USAGE_DAYS = "-1";
                    }
                    inDeatilInfo = inDeatilInfo + "<USAGE_DAYS>" + USAGE_DAYS + "</USAGE_DAYS>";

                    //包装单位
                    string USAGE_UNIT = inbilldetail.Rows[ll_row]["USAGE_UNIT"].ToString();
                    if (string.IsNullOrEmpty(USAGE_UNIT))
                    {
                        inDeatilInfo = inDeatilInfo + "<USAGE_UNIT/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<USAGE_UNIT>" + USAGE_UNIT + "</USAGE_UNIT>";
                    }

                    //计费标记 是否已计费 -1 未设置，0未计费，1计费
                    string ZZZ_Flag = inbilldetail.Rows[ll_row]["ZZZ_Flag"].ToString();
                    if (string.IsNullOrEmpty(ZZZ_Flag))
                    {
                        ZZZ_Flag = "-1";
                    }
                    inDeatilInfo = inDeatilInfo + "<ZZZ_Flag>" + ZZZ_Flag + "</ZZZ_Flag>";

                    //医师职务
                    string Z_PhysicianAP = inbilldetail.Rows[ll_row]["Z_PhysicianAP"].ToString();
                    if (string.IsNullOrEmpty(Z_PhysicianAP))
                    {
                        inDeatilInfo = inDeatilInfo + "<Z_PhysicianAP/>";
                    }
                    else
                    {
                        inDeatilInfo = inDeatilInfo + "<Z_PhysicianAP>" + Z_PhysicianAP + "</Z_PhysicianAP>";
                    }


                    string l_IsFirst, l_IsLast;
                    //判断是否是一条记录
                    if (ii_billdetailrowcount == 1)
                    {
                        l_IsFirst = "1";
                        l_IsLast = "1";
                    }
                    else
                    {
                        //首行
                        if (ll_row == 0)
                        {
                            l_IsFirst = "1";
                            l_IsLast = "0";
                        }
                        //最后一行
                        else if (ll_row == ii_billdetailrowcount - 1)
                        {
                            l_IsFirst = "0";
                            l_IsLast = "1";
                        }
                        //不是首行且不是最后一行
                        else
                        {
                            l_IsFirst = "0";
                            l_IsLast = "0";
                        }
                    }
                    //调用上传明细函数，返回参数 l_S 1成功 0失败				
                    l_s = UploadDetailInfo(l_IsFirst, l_IsLast, inDeatilInfo);
                    if (l_s.Equals("0"))
                    {
                        l_error_message = GetErrorMessage();
                        return "0";
                    }
                    else if (l_s.Equals("2"))
                    {
                        l_error_message = "调用步骤出错";
                        return "0";
                    }
                }
            }
            else if (l_s.Equals("0"))
            {
                l_error_message = GetErrorMessage();
                return "0";
            }
            else
            {
                l_error_message = "调用步骤出错";
                return "0";
            }

            return "1";
        }

        #endregion XML组装

        #region 审核

        public string ClaimAudit4Hospital_N(DataTable dt_bill, DataTable dt_billdetail)
        {
            l_s = "";
            gs_auditflag = "1";
            //l_s = f_constructxml(dt_bill, dt_billdetail);
            l_s = f_constructxml1(dt_bill, dt_billdetail);

            if (l_s.Equals("1"))
            {

                //审核提交函数
                l_s = AuditClaimInfo_N("");
                //l_s = AuditClaimInfo_S();
                //messagebox("提示",l_s)
                //审核结果日志
            }
            else
            {
                gs_auditflag = "0";
                return "0";
            }

            return l_s;

        }

        public string ClaimAudit4Hospital_Y(DataTable dt_bill, DataTable dt_billdetail)
        {
            l_s = "";
            gs_auditflag = "1";
            //l_s = f_constructxml(dt_bill, dt_billdetail);
            l_s = f_constructxml1(dt_bill, dt_billdetail);

            if (l_s.Equals("1"))
            {

                //审核提交函数
                l_s = AuditClaimInfo_Y("");
                //l_s = AuditClaimInfo_N("");
                //l_s = AuditClaimInfo_Y("");//wait jchl  AuditClaimInfo_Y
                //l_s = AuditClaimInfo_S();
                //messagebox("提示",l_s)
                //审核结果日志
            }
            else
            {
                gs_auditflag = "0";
                return "0";
            }

            return l_s;
        }

        public string ClaimAudit4Hospital_S(DataTable dt_bill, DataTable dt_billdetail)
        {
            l_s = "";
            gs_auditflag = "1";
            //l_s = f_constructxml(dt_bill, dt_billdetail);
            l_s = f_constructxml1(dt_bill, dt_billdetail);

            if (l_s.Equals("1"))
            {
                //审核提交函数
                l_s = AuditClaimInfo_S();
                //l_s = AuditClaimInfo_N("");
                //l_s = AuditClaimInfo_Y("");//wait jchl  AuditClaimInfo_Y
                //l_s = AuditClaimInfo_S();
                //messagebox("提示",l_s)
                //审核结果日志
            }
            else
            {
                gs_auditflag = "0";
                return "0";
            }

            return l_s;
        }

        #endregion 审核

        #region XmlStr转Data
        public DataSet StrToData(string str)
        {
            DataSet xmlds = new DataSet();
            if (str != "")
            {
                StringReader stream = null;
                XmlTextReader reader = null;
                try
                {
                    stream = new StringReader(str);
                    reader = new XmlTextReader(stream);
                    xmlds.ReadXml(reader);
                }
                catch (System.Exception e)
                {


                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }

                return xmlds;
            }
            else
            {
                xmlds = new DataSet();
                return xmlds;
            }
        }
        #endregion XmlStr转Data
    }
}
