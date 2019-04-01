using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using System.Data;

namespace ts_yf_zyfy
{
    public class ts_zy_hlyy
    {
        public static void InitializationHLYY(string Employeeid, string dept_id, int Systemid, string zyh, int cs, string brxm, string xb, string csrq)
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
                    _values[3] = zyh;
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gh">工号</param>
        /// <param name="cfrq">处方日期</param>
        /// <param name="EmployeeName">姓名</param>
        /// <param name="ksdm">科室代码</param>
        /// <param name="ksmc">科室名称</param>
        /// <param name="zyh">住院号</param>
        /// <param name="yzid">医嘱id</param>
        /// <param name="birth">病人出生日期</param>
        /// <param name="brxm">病人姓名</param>
        /// <param name="xb">性别</param>
        /// <param name="tb">处方明细</param>
        /// <param name="icd"></param>
        /// <returns></returns>
        public static string GetXml(int gh, string cfrq, string EmployeeName, int ksdm, string ksmc, string zyh, string birth, string brxm, string xb, DataTable tb, string icd)
        {
            string xml = "<safe>";
            xml += "<doctor_information job_number='" + gh.ToString() + "' date='" + cfrq + "'/>";//工号 系统日期
            xml += "<doctor_name>" + EmployeeName + "</doctor_name>";                               //医生名称
            xml += "<doctor_type></doctor_type>";                                                   //医生级别代码
            xml += "<department_code>" + ksdm.ToString() + "</department_code>";                    //科室代码
            xml += "<department_name>" + ksmc + "</department_name>";                               //科室名称
            xml += "<case_id>" + zyh + "</case_id>";                                                //病历卡号
            xml += "<inhos_code>" + zyh + cfrq.Substring(4, 6) + "</inhos_code>";                   //住院号
            xml += "<bed_no></bed_no>";                                                             //床号
            xml += "<patient_information weight='' height='' birth='" + birth + "' >";              //身高 体重 出生日期
            xml += "<patient_name>" + brxm + "</patient_name>";                                     //病人姓名
            xml += "<patient_sex>" + xb + "</patient_sex>";                                         //性别
            xml += "<physiological_statms></physiological_statms><boacterioscopy_effect></boacterioscopy_effect><bloodpressure></bloodpressure><liver_clean></liver_clean>";
            xml += "<allergic_history>";
            xml += "<case><case_code></case_code>";
            xml += "<case_name></case_name></case>";
            xml += "<case><case_code></case_code><case_name></case_name></case>";
            xml += "<case><case_code></case_code><case_name></case_name></case>";
            xml += "</allergic_history>";
            xml += "<diagnoses><diagnose>" + "type = '0',name='"+icd+"'"+ "</diagnose><diagnose></diagnose><diagnose></diagnose>"; //诊断
            xml += "<diagnose></diagnose><diagnose></diagnose><diagnose></diagnose>";
            xml += "</diagnoses></patient_information><prescriptions>";
            DataRow[] dr = tb.Select("cjid>0 ", "序号");
            int result = 0;
            for (int i = 0; i < dr.Length; i++)
            {
                YpClass.Ypcj cj = new YpClass.Ypcj(Convert.ToInt32(dr[i]["cjid"].ToString()),InstanceForm.BDatabase);
                xml += "<prescription  id='" + zyh + cfrq.Substring(4, 6) + "' type='T'>";//id 医嘱号 type 医嘱类型 ？
                xml += "<medicine suspension='false' judge='true'>";
                //if (Convert.ToInt32(dr[i]["组标志"]) == -1 || Convert.ToInt32(dr[i]["组标志"]) == 0)
                //{
                //    xml += "<group_number>" + result + "</group_number>";                               //组号
                //    result++;
                //}
                //else
                //    xml += "<group_number>" + result + "</group_number>";

             
                xml += "<group_number>" + result + "</group_number>";                               //组号
                result++; 

                xml += "<general_name>" + dr[i]["品名"].ToString() + "</general_name>";                 //通用名
                xml += "<license_number>" + cj.CJID.ToString() + "</license_number>";                   //大通是匹配的厂家id  //医院药品代码
                xml += "<medicine_name>" + dr[i]["商品名"].ToString() + "</medicine_name>";             //商品名
                xml += "<single_dose coef='1'>" + Convertor.IsNull(dr[i]["剂量"],"").ToString() + "</single_dose>";          //单次量

                string yfid =Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select ID from JC_USAGEDICTION where NAME='" + dr[i]["用法"].ToString() + "'").ToString(),"");
                string pcid =Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select ID from jc_FREQUENCY where NAME='" +Convertor.IsNull(dr[i]["频次"],"").ToString() + "'").ToString(),"");
                xml += "<frequency>" + pcid+"</frequency>";                                             //频次代码
                string cs = "";
                xml += "<times>" + cs + "</times>";                                                     //次数
                xml += "<unit>" +Convertor.IsNull(dr[i]["单位"],"").ToString() + "</unit>";                                            //单位（mg,g等）?
                xml += "<administer_drugs>" +yfid + "</administer_drugs>";  //用药途径?用法
                string ksyysj = cfrq;
                xml += "<begin_time>" + ksyysj + "</begin_time>";           //用药开始时间(YYYY-MM-DD HH:mm:SS)?
                string jsyysj = cfrq;
                xml += "<end_time>" + jsyysj + "</end_time>";               //用药结束时间(YYYY-MM-DD HH:mm:SS)?
                string yzsj = cfrq;
                xml += "<prescription_time>" + cfrq + "</prescription_time>";//医嘱时间(YYYY-MM-DD HH:mm:SS)?
                xml += "</medicine>";
                xml += "</prescription>";//单个处方结束

            }
            xml += "</prescriptions>";//循环结束
            xml += "</safe>";//结束
            return xml;
        }



    }
}
