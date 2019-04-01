using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data;
using System.IO;
using System.Web;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;


namespace Ts_Bl_interface
{
    public class MqBl : IBl
    {
        //  private string _path = ApiFunction.GetIniString("HHPACS", "类型", Constant.ApplicationDirectory + "\\bl.ini");
        // private string _exeNmae = ApiFunction.GetIniString("HHPACS", "类型名称", Constant.ApplicationDirectory + "\\bl.ini");
        #region IBl 成员

        public bool ShowBlInfo(string sqh, PatientSource brly)
        {
            string sql = "";
            return true;
        }

        public bool ShowPatBlInfo(Guid brxxId, PatientSource brly)
        {
            string inpatient_no = "";
            if (brly == PatientSource.住院)
            {
                //string sql = "select yjsqid from YJ_MZSQ a  where yzid='" + str + "' and a.bscbz=0";
                string sql = "select INPATIENT_NO from ZY_INPATIENT where inpatient_id='" + brxxId + "'";
                inpatient_no = Convertor.IsNull(FrmMdiMain.Database.GetDataResult(sql), "");
            }
            string url = ApiFunction.GetIniString("MqBl", "应用程序路径", Constant.ApplicationDirectory + "\\bl.ini");
            inpatient_no = Convert.ToInt64(inpatient_no).ToString();
            FrmWeb fw = new FrmWeb("病理结果查询", url + inpatient_no);
            fw.ShowDialog();
            return true;
        }

        #endregion

        #region IBl 成员


        public IBl creat()
        {
            IBl ibl = new MqBl();
            return ibl;
        }

        #endregion
        private string GetSqh(string str, PatientSource brly)
        {
            string sqh = "";
            if (brly == PatientSource.住院)
            {
                // string sql = "select yjsqid from yj_zysq where yzid='" + str + "' and bscbz=0";
                string sql = " select top 1 YJSQID from YJ_ZYSQ aa left join dbo.ZY_ORDERRECORD AS rr ON aa.YZID = rr.ORDER_ID  "
                     + " inner join "
                     + "  dbo.ZY_JC_RECORD ww on rr.INPATIENT_ID=ww.INPATIENT_ID and ww.HOITEM_ID=rr.HOITEM_ID and ww.GROUP_ID=rr.GROUP_ID"
                    + "  where yzid='" + str + "' and bscbz=0 ";
                sqh = Convertor.IsNull(FrmMdiMain.Database.GetDataResult(sql), Guid.Empty.ToString());
            }
            if (brly == PatientSource.门诊)
            {
                //string sql = "select yjsqid from YJ_MZSQ a  where yzid='" + str + "' and a.bscbz=0";
                string sql = "select YJSQID from YJ_MZSQ a left join  MZ_HJB xx on a.YZID=xx.HJID left join MZ_HJB_MX yy on yy.HJID=xx.HJID where yy.HJMXID='" + str + "'  and a.bscbz=0";
                sqh = Convertor.IsNull(FrmMdiMain.Database.GetDataResult(sql), "");
            }
            return sqh;
        }

        #region IBl 成员


        public bool ShowBlSq(Guid brxxId, PatientSource brly)
        {
            throw new Exception("此方法无效");
        }

        public bool ShowBlSq(Guid brxxId, PatientSource brly,int dept_id)
        {
            DataTable patTb = new DataTable();
            if (brly == PatientSource.住院)
            {
                //string sql = "select yjsqid from YJ_MZSQ a  where yzid='" + str + "' and a.bscbz=0";
                string sql = "select * from vi_ZY_vINPATIENT_all where inpatient_id='" + brxxId + "'";
                patTb = FrmMdiMain.Database.GetDataTable(sql);
            }
            string url = ApiFunction.GetIniString("MqBl", "申请单路径", Constant.ApplicationDirectory + "\\bl.ini");

            if (url == "" || patTb == null || patTb.Rows.Count == 0)
            {
                return false;
            }
            DataRow dr=patTb.Rows[0];
            string inpatientNo = Convert.ToInt64(dr["inpatient_no"]).ToString();
            DateTime now =DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            if (brly == PatientSource.住院)
            {
                #region 入参
                /*
                HISID  HIS唯一识别号，用于标识某次病理检查  2014000001
                UNITS  送检单位  本院
                DEPT  送检科室  妇科
                BEDID  床号  042
                INREGION  病区  13
                SAMPLE  送检物  胸水
                CLINICALDIAG  临床诊断 
                OUTPATIENTID  门诊号 
                INPATIENTID  住院号 
                DOCTOR  送检医生  张三
                NAME  病人姓名 
                SEX  性别 
                AGE  年龄，可附带年龄单位  35岁/3月/25天
                MARRIAGE  婚姻状况(是/否)  是
                PHONE  联系电话 
                CONTACTINFO  联系信息 
                IDCARD  身份证号码 
                MEDICAREID  医保卡号 
                SURGERYSHOW  手术所见 
                SURGERYNAME  手术名称 
                SURGERYDOCTOR  手术医生 
                HISSUMMARY  病史摘要 
                PROJECT  检查项目  常规病检
                REMARKS  备注 
                MENSTRUAL_CYCLE  月经周期  30
                MENSTRUAL_DURATION  月经持续时间  7
                LAST_MENSTRUAL  上次月经时间  2014-05-05
                DEPTID  科室编号，用于数据回传 
                DOCTORID  送检医生编号，用于数据回传 
                REQUEST_ID  申请号 
                SUMMARY  临床说明
                 */
                #endregion
                url += "&HISID=" + inpatientNo + now.ToString("yyyyMMddHHmmss");//HIS唯一识别号，用于标识某次病理检查
                url += "&DEPT=" + HttpUtility.UrlEncode(dr["cur_dept_name"].ToString());//送检科室
                url += "&BEDID=" + HttpUtility.UrlEncode(dr["bed_no"].ToString());//床号
                url += "&INREGION=" + HttpUtility.UrlEncode(dr["ward_id"].ToString());//病区
                url += "&CLINICALDIAG=" + HttpUtility.UrlEncode(dr["ryzd"].ToString());//临床诊断
                url += "&INPATIENTID=" + HttpUtility.UrlEncode(inpatientNo);//住院号
                url += "&DOCTOR=" + HttpUtility.UrlEncode(FrmMdiMain.CurrentUser.Name);//送检医生
                url += "&NAME=" + HttpUtility.UrlEncode(dr["name"].ToString());//病人姓名
                url += "&SEX=" + HttpUtility.UrlEncode(dr["sex_name"].ToString());//性别
                url += "&AGE=" + HttpUtility.UrlEncode(dr["age"].ToString());//年龄，可附带年龄单位  35岁/3月/25天
                url += "&DEPTID=" + HttpUtility.UrlEncode(dept_id.ToString());//科室编号，用于数据回传dr["dept_id"].ToString()
                url += "&DOCTORID=" + HttpUtility.UrlEncode(FrmMdiMain.CurrentUser.EmployeeId.ToString());//送检医生编号，用于数据回传 
                url += "&REQUEST_ID=" + HttpUtility.UrlEncode(now.ToString("yyyyMMdd") + FrmMdiMain.CurrentUser.EmployeeId.ToString("0000") + now.ToString("HHmmss"));//Add By Tany 2015-12-31 增加传入参
            }
            FrmWeb fw = new FrmWeb("病理申请单", url);
            fw.ShowDialog();
            //System.Diagnostics.Process.Start(url);
            return true;
        }

        #endregion
    }
}
