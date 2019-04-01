using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using System.Data;
using System.Windows.Forms;
namespace ts_yf_mzfy
{
    public class ts_mz_hlyy
    {
        public static void InitializationHLYY(string Employeeid, string dept_id, int Systemid, string mzh, int cs, string brxm, string xb, string csrq)
        {
            SystemCfg cfg3027 = new SystemCfg(3027);//挂号有效天数
            if (cfg3027.Config == "1")
            {
                try
                {
                    //0=用户 1=科室 2=模块 3=住院号 4=住院次数 5=病人姓名 6=性别 7=出生日期 8=体重  9=身高 10=出院日期
                    object[] _values = new object[11];
                    _values[0] = Employeeid;//用户
                    _values[1] = dept_id;//科室
                    _values[2] = Systemid; //系统str
                    _values[3] = mzh;
                    _values[4] = cs;//入院次数默认1 
                    _values[5] = brxm;
                    _values[6] = xb;
                    _values[7] = Convert.ToDateTime(csrq).ToString("yyyy-MM-dd");
                    _values[8] = "";
                    _values[9] = "";
                    _values[10] = "";
                    string hlyytype = ApiFunction.GetIniString("hlyy", "name", System.Windows.Forms.Application.StartupPath + "\\Hlyy.ini");
                    Ts_Hlyy_Interface.HlyyInterface hl = Ts_Hlyy_Interface.HlyyFactory.Hlyy(hlyytype);
                    hl.RegisterServer_fun(_values);
                    hl.Refresh();
                }
                catch (System.Exception err)
                {

                }
            }
        }
        public static string GetXml(int gh, string cfrq, string EmployeeName, int ksdm, string ksmc, string mzh, string birth, string brxm, string xb, DataTable tb, string icd)
        {
            string xml = "<safe>";
            xml += "<doctor_information job_number='" + gh.ToString() + "' date='" + cfrq + "'/>";
            xml += "<doctor_name>" + EmployeeName + "</doctor_name>";//医生名称
            xml += "<doctor_type></doctor_type>";//医生级别代码
            xml += "<department_code>" + ksdm.ToString() + "</department_code>";//科室代码
            xml += "<department_name>" + ksmc + "</department_name>";//科室名称
            xml += "<case_id>" + mzh + "</case_id>";//病历卡号
            xml += "<inhos_code>" + mzh + cfrq.Substring(4, 6) + "</inhos_code>";//门诊号
            xml += "<bed_no></bed_no>";//床号
            xml += "<patient_information weight='' height='' birth='" + birth + "' >";
            xml += "<patient_name>" + brxm + "</patient_name>";//病人姓名
            xml += "<patient_sex>" + xb + "</patient_sex>";//性别
            xml += "<physiological_statms></physiological_statms><boacterioscopy_effect></boacterioscopy_effect><bloodpressure></bloodpressure><liver_clean></liver_clean>";
            xml += "<allergic_history>";
            xml += "<case><case_code></case_code>";
            xml += "<case_name></case_name></case>";
            xml += "<case><case_code></case_code><case_name></case_name></case>";
            xml += "<case><case_code></case_code><case_name></case_name></case>";
            xml += "</allergic_history>";

            //string strzd = "select top 1 CODING from JC_DISEASE where NAME='" + icd + "'";
            //object zd = InstanceForm.BDatabase.GetDataResult(strzd);
            //string zdid = zd == null ? "" : zd.ToString();
            //icd = "I25.101";

            xml += "<diagnoses><diagnose>" + icd + "</diagnose><diagnose></diagnose><diagnose></diagnose>";
            xml += "<diagnose></diagnose><diagnose></diagnose><diagnose></diagnose>";
            xml += "</diagnoses></patient_information><prescriptions>";
            DataRow[] dr = tb.Select("ypID>0 ", "排序序号");
            int result = 0;
           
            for (int i = 0; i < dr.Length; i++)
            {
                YpClass.Ypcj cj = new YpClass.Ypcj(Convert.ToInt32(dr[i]["ypid"].ToString()),InstanceForm.BDatabase);
                xml += "<prescription  id='" + mzh + cfrq.Substring(4, 6) + "' type='mz' current='1'>";//单个处方开始
                xml += "<medicine suspension='false' judge='true'>";
                 
                if (Convert.ToInt32(dr[i]["组标志"]) == -1 || Convert.ToInt32(dr[i]["组标志"]) == 0)
                {
                    xml += "<group_number>" + result + "</group_number>";
                    result++;
                }
                else
                    xml += "<group_number>" + result + "</group_number>";
                
                xml += "<general_name>" + dr[i]["品名"].ToString() + "</general_name>";
                xml += "<license_number>" + cj.CJID.ToString() + "</license_number>";
                xml += "<medicine_name>" + dr[i]["商品名"].ToString() + "</medicine_name>";
                xml += "<single_dose coef='1'>" + dr[i]["剂量"].ToString() + "</single_dose>";
             
                string yfid =Convertor.IsNull( InstanceForm.BDatabase.GetDataResult("select id from JC_USAGEDICTION where NAME='" + dr[i]["用法"].ToString() + "'"),"").ToString();
                string pcid =Convertor.IsNull( InstanceForm.BDatabase.GetDataResult("select ID from jc_FREQUENCY where NAME='" + dr[i]["频次"].ToString() + "'"),"").ToString();
                
                xml += "<times>" + pcid + "</times>";
                xml += "<days>" + dr[i]["天数"].ToString() + "</days>";
                xml += "<unit>" + dr[i]["剂量单位"].ToString() + "</unit>";
                xml += "<administer_drugs>" + yfid + "</administer_drugs>";
                xml += "</medicine>";
                xml += "</prescription>";//单个处方结束
                 
            }
            xml += "</prescriptions>";//循环结束
            xml += "</safe>";//结束
            return xml;
        }

      

    }
}
