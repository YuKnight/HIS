using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using System.Windows.Forms;

namespace Ts_Hlyy_Interface
{
    class DT_HlyyClass : HlyyInterface
    {
        /// <summary>
        /// 导入接口底层函数
        /// </summary>
        [DllImport("dtywzxUI.dll")]    //请注意不要使用unicode，大通使用ANSI（默认）
        public static extern int dtywzxUI(int i_code, int i_param, string s_buffer);


        #region HlyyInterface 成员

        public int RegisterServer_fun(object[] _values)
        {
            int  Rlt=dtywzxUI(0,0,"");
            return Rlt;
        }
        public void Refresh()
        {
            dtywzxUI(3, 0, "");
        }
        public void ShowPoint(StringBuilder sb)
        {
            dtywzxUI(12, 0, sb.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="ZyOrMz">0=住院 1=门诊</param>
        /// <returns></returns>
        public  int DrugAnalysis(StringBuilder sb,int ZyOrMz)
       {
           int Gnh = 28676;
           if(ZyOrMz==1)//门诊
               Gnh=4;
           //string xml = "<safe><doctor_information job_number='796' date='2011-12-29 11:38:09'/><doctor_name>Tany</doctor_name><doctor_type>1</doctor_type><department_code>226</department_code><department_name>呼吸内科</department_name><case_id>25451211</case_id><inhos_code>25451211</inhos_code><bed_no>02</bed_no><patient_information weight='' height='' birth='1946-12-27'><patient_name>黄甫站</patient_name><patient_sex>男</patient_sex><physiological_statms></physiological_statms><boacterioscopy_effect></boacterioscopy_effect><bloodpressure></bloodpressure><liver_clean></liver_clean><pregnant></pregnant><pdw></pdw><allergic_history><case><case_code></case_code><case_name></case_name></case> <case><case_code></case_code><case_name></case_name></case><case><case_code></case_code><case_name></case_name></case> </allergic_history><diagnoses><diagnose type ='0'  name =''></diagnose><diagnose type ='0'  name =''></diagnose><diagnose type ='0'  name =''></diagnose></diagnoses></patient_information><prescriptions><prescription  id='b362eb88-d0d5-474e-8ce8-9fbc0167a3db' type='L'><medicine suspension='false' judge='true'><group_number>1</group_number><general_name>咳必清片</general_name><license_number>4493</license_number><medicine_name>咳必清片</medicine_name><single_dose coef='1'>25</single_dose><frequency>Tid</frequency><times></times><unit>mg</unit><administer_drugs>口服</administer_drugs><begin_time>2011-11-26 11:15:42</begin_time><end_time></end_time><prescription_time>2011-11-26 11:15:42</prescription_time></medicine></prescription><prescription  id='2d011337-0301-49ac-bea7-9fc600a660db' type='L'><medicine suspension='false' judge='true'><group_number>2</group_number><general_name>0.9%氯化钠注射液＜pp瓶＞</general_name><license_number>3314</license_number><medicine_name>0.9%氯化钠注射液＜pp瓶＞</medicine_name><single_dose coef='1'>100</single_dose><frequency>Bid</frequency><times></times><unit>ml</unit><administer_drugs>静滴</administer_drugs><begin_time>2011-12-27 10:05:50</begin_time><end_time></end_time><prescription_time>2011-12-27 10:05:50</prescription_time></medicine></prescription><prescription  id='4a52e8b0-ae8f-46e4-907c-9fc600a660dc' type='L'><medicine suspension='false' judge='true'><group_number>3</group_number><general_name>葡萄糖氯化钠注射液(pp瓶)</general_name><license_number>3401</license_number><medicine_name>葡萄糖氯化钠注射液(pp瓶)</medicine_name><single_dose coef='1'>500</single_dose><frequency>Qd</frequency><times></times><unit>ml</unit><administer_drugs>续滴</administer_drugs><begin_time>2011-12-27 10:05:50</begin_time><end_time></end_time><prescription_time>2011-12-27 10:05:50</prescription_time></medicine></prescription><prescription  id='72a3d427-5217-4d12-9757-9fc800bc416e' type='L'><medicine suspension='false' judge='true'><group_number>4</group_number><general_name>维生素K1注射液</general_name><license_number>4506</license_number><medicine_name>维生素K1注射液</medicine_name><single_dose coef='1'>10</single_dose><frequency>Tid</frequency><times></times><unit>mg</unit><administer_drugs>静滴</administer_drugs><begin_time>2011-12-29 11:24:00</begin_time><end_time></end_time><prescription_time";
           int i = dtywzxUI(Gnh, 1, sb.ToString());
            return i;
       }
       public void UNRegisterServer()
       {
           dtywzxUI(1, 0, ""); 
       }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="ZyOrMz">0=住院 1=门诊</param>
        /// <returns></returns>
        public int SaveDrug(StringBuilder sb, int ZyOrMz)
       {
           //string xml = "<safe><doctor_information job_number='1' date='2011-12-28 23:08:38'/><doctor_name>管理员</doctor_name><doctor_type>3</doctor_type><department_code>42</department_code><department_name>内科</department_name><case_id>000142875</case_id><inhos_code>000142875</inhos_code><bed_no>01</bed_no><patient_information weight='' height='' birth='1991-12-28'><patient_name>测试</patient_name><patient_sex>男</patient_sex><physiological_statms></physiological_statms><boacterioscopy_effect></boacterioscopy_effect><bloodpressure></bloodpressure><liver_clean></liver_clean><pregnant></pregnant><pdw></pdw><allergic_history><case><case_code></case_code><case_name></case_name></case> <case><case_code></case_code><case_name></case_name></case><case><case_code></case_code><case_name></case_name></case> </allergic_history><diagnoses><diagnose type ='0'  name ='查因'>000000</diagnose><diagnose type ='0'  name =''></diagnose><diagnose type ='0'  name =''></diagnose></diagnoses></patient_information><prescriptions><prescription  id='f61d18e3-701f-43b1-8cf7-9fc7017ccad7' type='L'><medicine suspension='false' judge='true'><group_number>2</group_number><general_name>5%葡萄糖注射液(农合)医保</general_name><license_number>1349</license_number><medicine_name>5%葡萄糖注射液(农合)医保</medicine_name><single_dose coef='1'>250</single_dose><frequency>Tid</frequency><times></times><unit>ml</unit><administer_drugs>静滴</administer_drugs><begin_time>2011-12-28 23:05:00</begin_time><end_time></end_time><prescription_time>2011-12-28 23:05:00</prescription_time></medicine></prescription><prescription  id='7380730b-ce42-4c2b-b7d7-9fc7017d62ee' type='L'><medicine suspension='false' judge='true'><group_number>3</group_number><general_name>维生素C注射液(农合)医保</general_name><license_number>1615</license_number><medicine_name>维生素C注射液(农合)医保</medicine_name><single_dose coef='1'>0.5</single_dose><frequency>Tid</frequency><times></times><unit>g</unit><administer_drugs>静滴</administer_drugs><begin_time>2011-12-28 23:07:00</begin_time><end_time></end_time><prescription_time>2011-12-28 23:07:00</prescription_time></medicine></prescription><prescription  id='2f5e8c10-ba6c-4d92-917b-9fc7017d6300' type='L'><medicine suspension='false' judge='true'><group_number>3</group_number><general_name>氨茶碱片(农合)医保</general_name><license_number>4035</license_number><medicine_name>氨茶碱片(农合)医保</medicine_name><single_dose coef='1'>100</single_dose><frequency>Tid</frequency><times></times><unit>mg</unit><administer_drugs>静滴</administer_drugs><begin_time>2011-12-28 23:07:00</begin_time><end_time></end_time><prescription_time>2011-12-28 23:07:00</prescription_time></medicine></prescription><prescription  id='381c3cfe-2312-42b9-b9ab-9fc7017d630a' type='L'><medicine suspension='false' judge='true'><group_number>3</group_number><general_name>维生素K1注射液(农合)医保</general_name><license_number>1618</license_number><medicine_name>维生素K1注射液(农合)医保</medicine_name><single_dose coef='1'>10</single_dose><frequency>Tid</frequency><times></times><unit>mg</unit><administer_drugs>静滴</administer_drugs><begin_time>2011-12-28 23:07:00</begin_time><end_time></end_time><prescription_time>2011-12-28 23:07:00</prescription_time></medicine></prescription><prescription  id='ae1079db-6877-4893-956f-9fc7017d6313' type='L'><medicine suspension='false' judge='true'><group_number>3</group_number><general_name>水溶性维生素粉针10%</general_name><license_number>1622</license_number><medicine_name>水溶性维生素粉针10%</medicine_name><single_dose coef='1'>10</single_dose><frequency>Tid</frequency><times></times><unit>ml</unit><administer_drugs>静滴</administer_drugs><begin_time>2011-12-28 23:07:00</begin_time><end_time></end_time><prescription_time>2011-12-28 23:07:00</prescription_time></medicine></prescription><prescription  id='99b121b8-697a-42a1-a9d1-9fc7017d6321' type='L'><medicine suspension='false' judge='true'><group_number>3</group_number><general_name>青霉素钠粉针(农合)医保 「免试」</general_name><license_number>7</license_number><medicine_name>青霉素钠粉针(农合)医保 「免试」</medicine_name><single_dose coef='1'>80</single_dose><frequency>Tid</frequency><times></times><unit>万IU</unit><administer_drugs>静滴</administer_drugs><begin_time>2011-12-28 23:07:00</begin_time><end_time></end_time><prescription_time>2011-12-28 23:07:00</prescription_time></medicine></prescription></prescriptions></safe>";
           int Gnh = 28685;
           if(ZyOrMz==1)//门诊
               Gnh = 13;
          int i= dtywzxUI(Gnh, 1, sb.ToString());
          return i;
       }
        public void SaveXml(StringBuilder sb)
        {
            dtywzxUI(4109, 0, sb.ToString());
        }
        #endregion
        public int Gmsgl(object[] _valuues)
        {
            throw new Exception("没有提供该方法！！");
        }
        public void ClosePoint(StringBuilder sb)
        {
 
        }
        /// <summary>
        /// 药品警告信息
        /// </summary>
        /// <param name="mydatagrid"></param>
        public void GetYpjgxx(DataGridEx mydatagrid)
        {
 
        }
        public int recipe_check(int aitem, DataGridEx[] mydatagrid, DateTime dt, int type,ref CfInfo[] cfinfo, int curindex)
        {
            return -1;
        }
        public int Pub_function(int commmandno,string ss)
        {
            return 0;
        }
        public  int GetCszt(int commandno,string ss)
        {
            return 0;
        }
   }
}
