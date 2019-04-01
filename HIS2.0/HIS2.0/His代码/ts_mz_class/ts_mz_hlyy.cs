using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using System.Data;

namespace ts_mz_class
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
            xml += "<diagnoses><diagnose>" + icd + "</diagnose><diagnose></diagnose><diagnose></diagnose>";
            xml += "<diagnose></diagnose><diagnose></diagnose><diagnose></diagnose>";
            xml += "</diagnoses></patient_information><prescriptions>";
            DataRow[] dr = tb.Select("项目ID>0 and 项目来源=1 and 修改=1", "排序序号");
            int result = 0;
            for (int i = 0; i < dr.Length; i++)
            {
                xml += "<prescription  id='" + mzh + cfrq.Substring(4, 6) + "' type='mz' current='1'>";//单个处方开始
                xml += "<medicine suspension='false' judge='true'>";
                if (Convert.ToInt32(dr[i]["处方分组序号"]) == -1 || Convert.ToInt32(dr[i]["处方分组序号"]) == 0)
                {
                    xml += "<group_number>" + result + "</group_number>";
                    result++;
                }
                else
                    xml += "<group_number>" + result + "</group_number>";

                xml += "<general_name>" + dr[i]["项目名称"].ToString() + "</general_name>";
                xml += "<license_number>" + dr[i]["项目ID"].ToString() + "</license_number>";
                xml += "<medicine_name>" + dr[i]["商品名"].ToString() + "</medicine_name>";
                xml += "<single_dose coef='1'>" + dr[i]["剂量"].ToString() + "</single_dose>";
                xml += "<times>" + dr[i]["频次ID"].ToString() + "</times>";
                xml += "<days>" + dr[i]["天数"].ToString() + "</days>";
                xml += "<unit>" + dr[i]["剂量单位"].ToString() + "</unit>";
                xml += "<administer_drugs>" + dr[i]["用法ID"].ToString() + "</administer_drugs>";
                xml += "</medicine>";
                xml += "</prescription>";//单个处方结束

            }
            xml += "</prescriptions>";//循环结束
            xml += "</safe>";//结束            
            return xml;
        }
        //大通新合理用药XML的拼接 Add By zp 2014-02-13
        public static string GetXml_Dtx(DataTable dt_UnLoop,DataTable dt_Loop_Zd,DataTable dt_Loop_DrugItem)
        {
            string post = @"<details_xml >
		                <his_time>" + dt_UnLoop.Rows[0]["HIS系统时间"] + @"</his_time>
		                <hosp_flag>" + dt_UnLoop.Rows[0]["门诊住院标识"]+@"</hosp_flag>
		                <treat_type>"+dt_UnLoop.Rows[0]["就诊类型"]+@"</treat_type>
		                <treat_code>"+dt_UnLoop.Rows[0]["就诊号"]+@"</treat_code>
		                <bed_no>"+dt_UnLoop.Rows[0]["床位号"]+@"</bed_no>
		                <patient>
			                <name>"+dt_UnLoop.Rows[0]["姓名"]+@"</name>
		                    <birth>"+dt_UnLoop.Rows[0]["出生日期"]+@"</birth>
		                    <sex>"+dt_UnLoop.Rows[0]["性别"]+@"</sex>
		                    <weight>" + Convertor.IsNull(dt_UnLoop.Rows[0]["体重"],"") + @"</weight>
		                    <height>"+Convertor.IsNull( dt_UnLoop.Rows[0]["身高"],"")+@"</height>
		                    <id_card>"+Convertor.IsNull( dt_UnLoop.Rows[0]["身份证号"],"")+@"</id_card>
		                    <medical_record>"+Convertor.IsNull( dt_UnLoop.Rows[0]["病历卡号"],"")+@"</medical_record>
		                    <card_type>"+Convertor.IsNull( dt_UnLoop.Rows[0]["卡类型"],"")+@"</card_type>
		                    <card_code>"+Convertor.IsNull( dt_UnLoop.Rows[0]["卡号"],"")+@"</card_code>
		                    <pregnant_unit>"+Convertor.IsNull(dt_UnLoop.Rows[0]["时间单位"],"")+@"</pregnant_unit>
		                    <pregnant >"+Convertor.IsNull( dt_UnLoop.Rows[0]["怀孕时间"],"")+@"</pregnant>
		                    <allergic_data>
			                    <allergic>
                                  <type></type>
				                  <name></name>
				                  <code></code>
			                </allergic>
		                    </allergic_data>
		                    <diagnose_data>
			                    <diagnose>";
                                    for (int k = 0; k < dt_Loop_Zd.Rows.Count; k++)
                                    {
                                        post += @"<type>" + Convertor.IsNull(dt_Loop_Zd.Rows[k]["诊断类型"], "") + @"</type>
				                                  <name>" + Convertor.IsNull(dt_Loop_Zd.Rows[k]["诊断名称"], "") + @"</name>
				                                  <code>" + Convertor.IsNull(dt_Loop_Zd.Rows[k]["诊断代码"], "") + @"</code>";
                                    }
			            post+=@"</diagnose>
                            </diagnose_data >
	                    </patient>
	                    <prescription_data>
		                  <prescription>
		                    <id>"+dt_UnLoop.Rows[0]["处方号"]+@"</id>
		                    <reason>"+dt_UnLoop.Rows[0]["处方理由"]+@"</reason>
		                    <is_current>"+dt_UnLoop.Rows[0]["是否当前处方"]+@"</is_current>
		                    <pres_type>"+dt_UnLoop.Rows[0]["长期医嘱L/临时医嘱T"]+@"</pres_type>
		                    <pres_time>"+dt_UnLoop.Rows[0]["处方时间"]+@"</pres_time>
		                    <medicine_data>
				                ";
                        int result = 0;
                        for (int i = 0; i < dt_Loop_DrugItem.Rows.Count;i++ )
                        {
                           

                            post += @"<medicine><name>" + dt_Loop_DrugItem.Rows[i]["商品名"] + @"</name>
		                                <his_code>" + dt_Loop_DrugItem.Rows[i]["医院药品代码"] + @"</his_code>
		                                <insur_code>" + Convertor.IsNull(dt_Loop_DrugItem.Rows[i]["医保代码"], "") + @"</insur_code>
		                                <approval>" + Convertor.IsNull(dt_Loop_DrugItem.Rows[i]["批准文号"], "") + @"</approval>
		                                <spec>" + Convertor.IsNull(dt_Loop_DrugItem.Rows[i]["规格"], "") + @"</spec>
		                                <group>" + result + @"</group>
		                                <reason>" + Convertor.IsNull(dt_Loop_DrugItem.Rows[i]["用药理由"], "") + @"</reason>
					                    <dose_unit>" + Convertor.IsNull(dt_Loop_DrugItem.Rows[i]["单次量单位"], "") + @"</dose_unit>
					                    <dose>" + dt_Loop_DrugItem.Rows[i]["单次量"] + @"</dose>
					                    <freq>" + dt_Loop_DrugItem.Rows[i]["频次代码"] + @"</freq>
					                    <administer>" + dt_Loop_DrugItem.Rows[i]["给药途径代码"] + @"</administer>
                                        <begin_time>" + dt_Loop_DrugItem.Rows[i]["用药开始时间"] + @"</begin_time>
                                        <end_time>" + dt_Loop_DrugItem.Rows[i]["用药结束时间"] + @"</end_time>
                                        <days>" + dt_Loop_DrugItem.Rows[i]["服药天数"] + @"</days></medicine> ";
                            if (Convert.ToInt32(dt_Loop_DrugItem.Rows[i]["处方分组序号"]) == -1 || Convert.ToInt32(dt_Loop_DrugItem.Rows[i]["处方分组序号"]) == 0)
                            {
                                result++;
                            }
                            else
                            {
                                //if (Convert.ToInt32(dr[i]["处方分组序号"]) == 1)
                                //    result++;
                            }
                         }
				            post+=@"
                               </medicine_data>
                             </prescription>
                          </prescription_data>
                       </details_xml>";
            return post;
        }
    }
}
