using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.IO;
using System.Windows.Forms;

namespace ts_call
{
    /// <summary>
    /// 武汉门诊叫号
    /// </summary>
    public class ts_call_whzxyymz : Icall
    {
        public static readonly string strDrugWindow = ApiFunction.GetIniString("config", "wicketname", Constant.ApplicationDirectory + "//getdrug//getdrugconfig.txt");
        public static readonly string strMac = ApiFunction.GetIniString("config", "mac", Constant.ApplicationDirectory + "//getdrug//getdrugconfig.txt");
        public static readonly string strDistrictName = ApiFunction.GetIniString("config", "districtname", Constant.ApplicationDirectory + "//getdrug//getdrugconfig.txt");
        //public static readonly string strMac = PubStaticFun.GetMacAddress();

        private Thread currentThread;
        public System.Threading.Thread CurrentThread
        {
            get
            {
                return currentThread;
            }
            set
            {
                currentThread = value;
            }
        }

        public void Call(DmType dmtype, string callstring)
        {
            throw new NotImplementedException();
        }

        public void Call(string ss, string zl)
        {
            throw new NotImplementedException();
        }

        public void Call(DmType dmtype, string callstring, double je)
        {
            throw new NotImplementedException();
        }

        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            if (dmtype == DmType.发药呼叫)
            {
                StringBuilder strXml = new StringBuilder();
                /*
                strXml.Append("<config>");
                strXml.Append("<wicketname>" + strDrugWindow.Trim() + "</wicketname>");
                strXml.Append("<mac>" + strMac.Trim() + "</mac>");
                strXml.Append("<districtname>" + strDistrictName.Trim() + "</districtname>");
                strXml.Append("<patientname>" + callstring.Trim() + "</patientname>");
                strXml.Append("<patientid>" + InitDataBase(CFMX[0].fph) + "</patientid>");
                strXml.Append("</config>");
                */

                strXml.Append("<patient_info>");
                strXml.Append("<call_room>" + strDrugWindow.Trim() + "</call_room>");
                strXml.Append("<name>" + callstring.Trim() + "</name>");
                strXml.Append("<id>" + InitDataBase(CFMX[0].fph) + "</id>");
                strXml.Append("</patient_info>");

                // WriteLogToTxt(strXml.ToString());

                //MessageBox.Show("mac||" + strMac);

                if (strMac.Trim().Length > 0 && strDrugWindow.Trim().Length > 0)
                {
                    try
                    {
                        /*
                        WebReference.WHCentralhospital ws = new global::ts_call.WebReference.WHCentralhospital();
                        //Modify By Tany 2015-11-12 增加读取ini来获取地址
                        string url = ApiFunction.GetIniString(TrasenFrame.Classes.Constant.HospitalName, "url", System.Windows.Forms.Application.StartupPath + "\\WhzxyySouthCall.ini");
                        //MessageBox.Show("呼叫||" + url);
                        ws.Url = url;
                        ws.GetdrugInfo(strXml.ToString());
                         */


                        MzCallWs.WebServiceTerminalCall ser = new global::ts_call.MzCallWs.WebServiceTerminalCall();
                        string url = ApiFunction.GetIniString(TrasenFrame.Classes.Constant.HospitalName, "url", System.Windows.Forms.Application.StartupPath + "\\WhzxyySouthCall.ini");
                        ser.Url = url;// "http://192.168.0.141:81/WebServiceTerminalCall.asmx";

                        //string para = string.Format(@"<patient_info><call_room>{0}</call_room><name>{1}</name><id>{2}</id></patient_info>", strDrugWindow.Trim(), callstring.Trim(), InitDataBase(CFMX[0].fph));

                        string msg = ser.CallDrug(strXml.ToString(), strMac);

                        //MessageBox.Show("ret:" + msg + " par:" + strXml.ToString() + " mac:" + strMac);
                    }
                    catch (Exception err)
                    {
                        throw err;
                    }
                }
            }
            if (dmtype == DmType.发药)
            {
                StringBuilder strXml = new StringBuilder();
                strXml.Append("<config>");
                strXml.Append("<patientid>" + InitDataBase(CFMX[0].fph) + "</patientid>");
                strXml.Append("</config>");
                if (strMac.Trim().Length > 0 && strDrugWindow.Trim().Length > 0)
                {
                    try
                    {
                        WebReference.WHCentralhospital ws = new global::ts_call.WebReference.WHCentralhospital();
                        //Modify By Tany 2015-11-12 增加读取ini来获取地址
                        string url = ApiFunction.GetIniString(TrasenFrame.Classes.Constant.HospitalName, "url", System.Windows.Forms.Application.StartupPath + "\\WhzxyySouthCall.ini");
                        //MessageBox.Show("发药||" + url);
                        ws.Url = url;
                        ws.DeletedrugInfo(strXml.ToString());
                    }
                    catch (Exception err)
                    {
                        throw err;
                    }
                }
                //WriteLogToTxt(strXml.ToString());

            }
        }

        public void WriteLogToTxt(string erStr)
        {
            StreamWriter fs = new StreamWriter(Constant.ApplicationDirectory + "//log//" + DateTime.Now.ToShortDateString().Replace("/", "-") + "_log.txt", true);
            fs.WriteLine(erStr);
            fs.Flush();
            fs.Close();
        }
        private string InitDataBase(string strValue)
        {
            //Modify By Tany 2015-11-18 改变取值方式
            //string strSQL = "select kh from YY_KDJB where ZFBZ=0 and KLX=2 and BRXXID=(select BRXXID from MZ_FPB where FPH='" + strValue + "')";
            //string strSQL = "select kh from YY_KDJB where ZFBZ=0 and BRXXID in (select BRXXID from MZ_FPB where FPH='" + strValue + "')";
            //Modify By Tany 2015-11-24 其实是要取老系统ID
            string strSQL = "select id from whzxyy_mz_cfb_zb where djhm='" + strValue + "'";
            return Convertor.IsNull(FrmMdiMain.Database.GetDataResult(strSQL), "A001");
            //object obj = FrmMdiMain.Database.GetDataResult(strSQL);
            //if (obj != null || obj != System.DBNull.Value || obj.ToString().Trim().Length > 0)
            //{
            //    return obj.ToString();
            //}
            //else
            //{
            //    return "";
            //}



        }

        #region Icall 成员


        public void SetPicture(string picturename)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
