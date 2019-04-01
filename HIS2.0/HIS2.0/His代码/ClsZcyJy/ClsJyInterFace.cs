using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ClsZcyJy
{
    public class ClsJyInterFace
    {
        /*
         *  例子：RemarksStatus ：比如特殊药品特殊煎法的就写这里面：如 当归  ：“先煎20分钟”
             注意：药品明细中有的药会有先煎、后下、另包、包煎等字眼。
         */
        public static bool His_DrugInfo(string cfh, string hosCode, string hosName, string cjid, string yppm, string ypgg, string sccj, string num, string 单付计量, string 总实发数量, string jhdj, string jhje, string cydw, string memo, out string strMsg)
        {
            strMsg = "";
            try
            {
                WsZcyJy.Service1 ser = new ClsZcyJy.WsZcyJy.Service1();
                ser.Url = "http://192.168.144.240:8080/Service1.asmx";

                if (sccj.Length > 5)
                {
                    sccj = sccj.Substring(0, 5);
                }

                string inserDrug = ser.His_DrugInfo(cfh, hosCode, hosName, cjid, yppm, ypgg, sccj, num, 单付计量, 总实发数量, jhdj, jhje, cydw, memo);

                if (inserDrug == "true")
                {
                    return true;
                }
                else
                {
                    strMsg = inserDrug;
                    return false;
                }
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
            }
        }

        /*
            例子：RemarksStatus ：比如 膏汁的 需要加 蜂蜜加糖的就写这里面：如 “加糖加蜜”
            （一般 默认煎药方式是用 ‘2’ ）
            备注：1、原销售方式字段内容（sellmethod）改为科室，例如“神经科”
            2、门诊号（roomnum）字段格式为：“门诊（或住院）”+门诊号（数字）
            3、checktime、getmoneytime及workdate三个字段时间精确到分钟或秒钟
            4、代煎费（helpmoney）即为加工费。  
        */
        public static bool His_UserRecipe(string hosCode, string hosName, string inpName, string sex, string age, string addr, string tel, string cfh,
            string blh, string wardCode, string bedNo, string ts, string fs, string yyfs, string jybm, string weight, string packvolume,
            DateTime date, string docName, string checkTime, string buyUnit, string deptName, string je, string getMoneyTime, string jyfee, string remarksStatus,
            out string strMsg)
        {
            strMsg = "";
            try
            {
                WsZcyJy.Service1 ser = new ClsZcyJy.WsZcyJy.Service1();
                ser.Url = "http://192.168.144.240:8080/Service1.asmx";

                string inserDrug = ser.His_UserRecipe(hosCode, hosName, inpName, sex, age, "", tel, cfh, blh, wardCode, bedNo, ts, fs, yyfs, jybm,
                                                        packvolume, weight, 
                                                        date, docName, checkTime, buyUnit, deptName, je, getMoneyTime, jyfee, remarksStatus);

                if (inserDrug == "true")
                {
                    return true;
                }
                else
                {
                    strMsg = inserDrug;
                    return false;
                }
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
            }
        }

        public static bool DeletePres(string hosID, string emp_no, out string strMsg)
        {
            strMsg = "";
            try
            {
                //WsZcyJy.Service1 ser = new ClsZcyJy.WsZcyJy.Service1();
                WsZcyDel.Service1 ser = new ClsZcyJy.WsZcyDel.Service1();
                ser.Url = "http://192.168.144.240:8080/delete/delete.asmx";

                string inserDrug = ser.Service_deleteOldData(hosID, emp_no);

                if (inserDrug == "true")
                {
                    return true;
                }
                else
                {
                    strMsg = inserDrug;
                    return false;
                }
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
            }
        }


        public static string GetFreqExecNum(DataTable dtFre, string freq)
        {
            DataRow[] drs = dtFre.Select("name='" + freq.Trim() + "'");

            if (drs.Length > 0)
            {
                return drs[0]["EXECNUM"].ToString().Trim();
            }
            else
            {
                return "-1";
            }
        }
    }
}
