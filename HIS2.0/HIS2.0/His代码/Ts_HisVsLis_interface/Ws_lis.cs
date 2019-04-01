using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using TrasenHIS;
using TrasenClasses;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace Ts_HisVsLis_interface
{
    public struct LisInfo
    {
        /// <summary>
        /// 项目id
        /// </summary>
        public string itemid;
        /// <summary>
        ///  his中的单号
        /// </summary>
        public string hisid;
        public string itemName;
        public string deptid;
        public string deptname;
        public string employeeId;
        public string employeeName;
        public string crtDateTime;
        RelationalDatabase database;
        
        /// <summary>
        /// 住院号
        /// </summary>
        public string zyh;
        /// <summary>
        /// 诊断
        /// </summary>
        public string zd;
        /// <summary>
        /// 出生日期
        /// </summary>
        public string csrq;
        /// <summary>
        /// 性别
        /// </summary>
        public string xb;
        /// <summary>
        /// 床号
        /// </summary>
        public string ch;
        public string brxm;
        //Add By Tany 2015-08-04 增加标本名称
        /// <summary>
        /// 标本名称
        /// </summary>
        public string bbmc;
    }
    public class Ws_lis
    {
        public static DataTable LisServiceInput(LisInfo[] _lisinfo)
        {

            WebReference.lisService ls = new Ts_HisVsLis_interface.WebReference.lisService();
            string url = ApiFunction.GetIniString(TrasenFrame.Classes.Constant.HospitalName, "url", System.Windows.Forms.Application.StartupPath + "\\LisInterface.ini");
            ls.Url = url;//"http://192.168.0.81:8012/lisService.asmx";
            string xml = @"<message><call>
                                 <targetLogicService>LIS_INSERT_EXAMINITEMS_BYHIS</targetLogicService> 
                                 <targetLogicApp>LIS</targetLogicApp>
                                 </call> ";
            xml += "<body bodyId=\"LIS.BODY.1\"> ";
            xml += @"<examReqInfo><examReqType>2</examReqType>  ";
            for (int i = 0; i < _lisinfo.Length; i++)
            {
                xml += "<item>";
                xml += "<itemId>" + TrasenHIS.BLL.HisFunctions.GetOldHISXmYpBM("2", _lisinfo[i].itemid, TrasenFrame.Forms.FrmMdiMain.Database) + @"</itemId> ";
                xml += "<hisid>\"" + _lisinfo[i].hisid + "\"</hisid>  ";
                xml += "<itemName>" + _lisinfo[i].itemName + @"</itemName>";
                xml += "<bbmc>" + _lisinfo[i].bbmc + @"</bbmc>"; //Add By Tany 2015-08-04 增加标本名称
                //<EM>0 表示 常规，1表示急诊</EM>
                //Add By Tany 2015-08-17 增加急诊标记
                xml += "<EM>" + (_lisinfo[i].itemName.Contains("急") ? 1 : 0) + @"</EM>";
                xml += "</item>";
            }
            xml += @"<patientType>2</patientType><id>" + _lisinfo[0].zyh + @"</id>
                            <patientName>" + _lisinfo[0].brxm + @"</patientName>
                           <patientSex>" + _lisinfo[0].xb + @"</patientSex>
           <patientBirthday>" + _lisinfo[0].csrq + @"</patientBirthday>
           <patientBedNo>" + _lisinfo[0].ch + @"</patientBedNo>
           <Diagnose>" + _lisinfo[0].zd + @"</Diagnose><reqDept>
           <deptId>" + TrasenHIS.BLL.HisFunctions.ConvertNewhisidToOldHisid(TrasenHIS.BLL.HisFunctions.DataMapType.JC_DEPT_PROPERTY, _lisinfo[0].deptid, TrasenFrame.Forms.FrmMdiMain.Database) + @"</deptId>   
            <deptName>" + _lisinfo[0].deptname + @"</deptName> 
            </reqDept>
            <reqDoctor>
                     <employeeId>" + TrasenHIS.BLL.HisFunctions.ConvertNewhisidToOldHisid(TrasenHIS.BLL.HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, _lisinfo[0].employeeId, TrasenFrame.Forms.FrmMdiMain.Database) + "</employeeId><employeeName>" + _lisinfo[0].employeeName + @"</employeeName> 
           </reqDoctor>
           <crtDateTime>" + _lisinfo[0].crtDateTime + @"</crtDateTime>  
           <status>20</status>   
           </examReqInfo>
           </body>

           </message>";
            //System.Windows.Forms.MessageBox.Show(xml);
            string ss1 = ls.LisServiceInput(xml);

            return Converttb(ss1);
        }
        /// <summary>
        /// 删除申请单
        /// </summary>
        /// <param name="_lisinfo"></param>
        /// <returns></returns>
        public static void LisDelete(LisInfo _lisinfo)
        {
            WebReference.lisService ls = new Ts_HisVsLis_interface.WebReference.lisService();
            ls.Url = ApiFunction.GetIniString(TrasenFrame.Classes.Constant.HospitalName, "url", System.Windows.Forms.Application.StartupPath + "\\LisInterface.ini");//"http://192.168.0.81:8012/lisService.asmx";
            string xml = "<message msgType=\"call\" msgId=\"String\" timestampCreated=\"" + _lisinfo.crtDateTime + "\" version=\"1.15\">"
                                     + "           <call timestampCreated=\"" + _lisinfo.crtDateTime + "\" crfCallMode=\"neverRespond\"> "
                                     + " <targetLogicService>LIS_DELETE_EXAM</targetLogicService>  "
                                     + " <targetLogicApp>CIS</targetLogicApp> </call><body bodyId=\"1\" bodyType=\"single\">"
                                     + " <examReqInfo><examReqId>" + _lisinfo.hisid + "</examReqId> <status>-1</status> "
                                     + " </examReqInfo></body></message>";
            //Modify By Tany 2014-08-29 如果传入了itemid，则单独删除申请中的某条项目
            if (Convertor.IsNull(_lisinfo.itemid, "") != "")
            {
                xml = "<message msgType=\"call\" msgId=\"String\" timestampCreated=\"" + _lisinfo.crtDateTime + "\" version=\"1.15\">"
                                     + "           <call timestampCreated=\"" + _lisinfo.crtDateTime + "\" crfCallMode=\"neverRespond\"> "
                                     + " <targetLogicService>LIS_DELETE_EXAM_NEW</targetLogicService>  "
                                     + " <targetLogicApp>CIS</targetLogicApp> </call><body bodyId=\"1\" bodyType=\"single\">"
                                     + " <examReqInfo><examReqId>" + _lisinfo.hisid + "</examReqId>"
                                     + " <itemId>" + TrasenHIS.BLL.HisFunctions.GetOldHISXmYpBM("2", _lisinfo.itemid, TrasenFrame.Forms.FrmMdiMain.Database) + "</itemId><status>-1</status> "
                                     + " </examReqInfo></body></message>";
            }
            string ss = ls.LisServiceInput(xml);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ss);
            XmlNode root = xmlDoc.SelectSingleNode("/message/response");
            if (root == null)
            {
                throw new Exception("LIS系统未返回状态，请检查数据！");
            }
            else
            {
                if (root.ChildNodes[0].InnerText.ToString().Trim() != "0")
                {
                    throw new Exception("LIS系统返回错误：" + root.ChildNodes[1].InnerText.ToString().Trim());
                }
            }
        }
        public static DataTable Converttb(string strxml)
        {
            string sql = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";

            sql = sql + "<message msgId=\"1\" msgType=\"response\" timestampCreated=\"2014-04-29 14:16:38.375\" version=\"1\"> " +
                    "<body><Orders><Order OrderID=\"14042901495\"><TestItem>" +
                    "\"31afbb96-da5b-4996-bd65-a31c00eb0de4\"</TestItem>" +
                     @"</Order></Orders></body><response><code>0</code>
                     <description></description></response></message>";

            strxml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" + strxml;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(strxml);
            System.Data.DataTable tb = new DataTable();
            tb.Columns.Add("orderid", typeof(System.String));
            //tb.Columns.Add("hisid", typeof(System.String));
            tb.Columns.Add("TestItem", typeof(System.String));

            ////modify by jchl  申请单返回错误信息
            //tb.Columns.Add("code", typeof(System.String));
            //tb.Columns.Add("info", typeof(System.String));

            XmlNode root = xml.SelectSingleNode("/message/body/Orders");
            foreach (XmlNode xn in root.ChildNodes)
            {
                XmlElement xel = xn as XmlElement;
                for (int i = 0; i < xn.ChildNodes.Count; i++)
                {
                    System.Data.DataRow r = tb.NewRow();
                    r["orderid"] = xel.Attributes[0].Value;
                    r["TestItem"] = xn.ChildNodes[i].InnerText.Replace("\"", "");


                    //r["code"] = xml.SelectSingleNode("/message/response/code").InnerText.Replace("\"", "");
                    //r["info"] = xml.SelectSingleNode("/message/response/description").InnerText.Replace("\"", "");

                    tb.Rows.Add(r);
                }
            }
            return tb;
        }

        /// <summary>
        /// Modify by jchl 检验回填单号时候，传出lis的消息 --2017-11-08
        /// </summary>
        /// <param name="_lisinfo"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static DataTable LisServiceInput(LisInfo[] _lisinfo, out string strMsg)
        {
            
            strMsg = "";
            WebReference.lisService ls = new Ts_HisVsLis_interface.WebReference.lisService();
            string url = ApiFunction.GetIniString(TrasenFrame.Classes.Constant.HospitalName, "url", System.Windows.Forms.Application.StartupPath + "\\LisInterface.ini");
            ls.Url = url;//"http://192.168.0.81:8012/lisService.asmx";
            string xml = @"<message><call>
                                 <targetLogicService>LIS_INSERT_EXAMINITEMS_BYHIS</targetLogicService> 
                                 <targetLogicApp>LIS</targetLogicApp>
                                 </call> ";
            xml += "<body bodyId=\"LIS.BODY.1\"> ";
            xml += @"<examReqInfo><examReqType>2</examReqType>  ";
            for (int i = 0; i < _lisinfo.Length; i++)
            {
                xml += "<item>";
                xml += "<itemId>" + TrasenHIS.BLL.HisFunctions.GetOldHISXmYpBM("2", _lisinfo[i].itemid, TrasenFrame.Forms.FrmMdiMain.Database) + @"</itemId> ";
                xml += "<hisid>\"" + _lisinfo[i].hisid + "\"</hisid>  ";
                xml += "<itemName>" + _lisinfo[i].itemName + @"</itemName>";
                xml += "<bbmc>" + _lisinfo[i].bbmc + @"</bbmc>"; //Add By Tany 2015-08-04 增加标本名称
                //<EM>0 表示 常规，1表示急诊</EM>
                //Add By Tany 2015-08-17 增加急诊标记
                xml += "<EM>" + (_lisinfo[i].itemName.Contains("急") ? 1 : 0) + @"</EM>";
                xml += "</item>";
            }
            xml += @"<patientType>2</patientType><id>" + _lisinfo[0].zyh + @"</id>
                            <patientName>" + _lisinfo[0].brxm + @"</patientName>
                           <patientSex>" + _lisinfo[0].xb + @"</patientSex>
           <patientBirthday>" + _lisinfo[0].csrq + @"</patientBirthday>
           <patientBedNo>" + _lisinfo[0].ch + @"</patientBedNo>
           <Diagnose>" + _lisinfo[0].zd + @"</Diagnose><reqDept>
           <deptId>" + TrasenHIS.BLL.HisFunctions.ConvertNewhisidToOldHisid(TrasenHIS.BLL.HisFunctions.DataMapType.JC_DEPT_PROPERTY, _lisinfo[0].deptid, TrasenFrame.Forms.FrmMdiMain.Database) + @"</deptId>   
            <deptName>" + _lisinfo[0].deptname + @"</deptName> 
            </reqDept>
            <reqDoctor>
                     <employeeId>" + TrasenHIS.BLL.HisFunctions.ConvertNewhisidToOldHisid(TrasenHIS.BLL.HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, _lisinfo[0].employeeId, TrasenFrame.Forms.FrmMdiMain.Database) + "</employeeId><employeeName>" + _lisinfo[0].employeeName + @"</employeeName> 
           </reqDoctor>
           <crtDateTime>" + _lisinfo[0].crtDateTime + @"</crtDateTime>  
           <status>20</status>  
           </examReqInfo>
           </body>

           </message>";
            //System.Windows.Forms.MessageBox.Show(xml);
            string ss1 = ls.LisServiceInput(xml);

            try
            {
                System.Xml.XmlDocument documentGet = new System.Xml.XmlDocument();
                documentGet.LoadXml(ss1);
                //System.Xml.XmlNode ndCodeGet = documentGet.SelectSingleNode("code");
                //string RetCode = ndCodeGet.InnerText;

                System.Xml.XmlNode ndCodeGetText = documentGet.DocumentElement.SelectSingleNode("response/description");
                strMsg = ndCodeGetText.InnerText;
            }
            catch { }

            return Converttb(ss1);
        }


        public static DataTable LisServiceInput(LisInfo[] _lisinfo,DataTable dt_tz, out string strMsg)
        {

            strMsg = "";
            string vomiting = "";
            string paralyticileus = "";
            string Bowelsoundsweakened = "";
            string intestinalischemia = "";
            string diarrhea = "";
            string Ogilvie = "";
            string Gastroparesis = "";
            string Gastrointestinalbleeding = "";
            string Feedingintolerance = "";
            string Intraperitonealpressure = "";
            string brlx = "";
            //DataTable dt_tz = "select vomiting,paralyticileus,Bowelsoundsweakened,intestinalischemia,diarrhea,Ogilvie,Gastroparesis,Gastrointestinalbleeding,Feedingintolerance,Intraperitonealpressure from  zy_jy_brtz a  left jojn  zy_inpatient b on a.inpatient_id=b.inpatient_id where b.inpatient_no='00" + _lisinfo[0].zyh + "'";
            if (dt_tz != null && dt_tz.Rows.Count > 0)
            {
                vomiting = dt_tz.Rows[0]["vomiting"].ToString();
                paralyticileus = dt_tz.Rows[0]["paralyticileus"].ToString();
                Bowelsoundsweakened = dt_tz.Rows[0]["Bowelsoundsweakened"].ToString();
                intestinalischemia = dt_tz.Rows[0]["intestinalischemia"].ToString();
                diarrhea = dt_tz.Rows[0]["diarrhea"].ToString();
                Ogilvie = dt_tz.Rows[0]["Ogilvie"].ToString();
                Gastroparesis = dt_tz.Rows[0]["Gastroparesis"].ToString();
                Gastrointestinalbleeding = dt_tz.Rows[0]["Gastrointestinalbleeding"].ToString();
                Feedingintolerance = dt_tz.Rows[0]["Feedingintolerance"].ToString();
                Intraperitonealpressure = dt_tz.Rows[0]["Intraperitonealpressure"].ToString();
                brlx = dt_tz.Rows[0]["brlx"].ToString();

            }
            WebReference.lisService ls = new Ts_HisVsLis_interface.WebReference.lisService();
            string url = ApiFunction.GetIniString(TrasenFrame.Classes.Constant.HospitalName, "url", System.Windows.Forms.Application.StartupPath + "\\LisInterface.ini");
            ls.Url = url;//"http://192.168.0.81:8012/lisService.asmx";
            string xml = @"<message><call>
                                 <targetLogicService>LIS_INSERT_EXAMINITEMS_BYHIS</targetLogicService> 
                                 <targetLogicApp>LIS</targetLogicApp>
                                 </call> ";
            xml += "<body bodyId=\"LIS.BODY.1\"> ";
            xml += @"<examReqInfo><examReqType>2</examReqType>  ";
            for (int i = 0; i < _lisinfo.Length; i++)
            {
                xml += "<item>";
                xml += "<itemId>" + TrasenHIS.BLL.HisFunctions.GetOldHISXmYpBM("2", _lisinfo[i].itemid, TrasenFrame.Forms.FrmMdiMain.Database) + @"</itemId> ";
                xml += "<hisid>\"" + _lisinfo[i].hisid + "\"</hisid>  ";
                xml += "<itemName>" + _lisinfo[i].itemName + @"</itemName>";
                xml += "<bbmc>" + _lisinfo[i].bbmc + @"</bbmc>"; //Add By Tany 2015-08-04 增加标本名称
                //<EM>0 表示 常规，1表示急诊</EM>
                //Add By Tany 2015-08-17 增加急诊标记
                xml += "<EM>" + (_lisinfo[i].itemName.Contains("急") ? 1 : 0) + @"</EM>";
                xml += "</item>";
            }
            xml += @"<patientType>2</patientType><id>" + _lisinfo[0].zyh + @"</id>
                            <patientName>" + _lisinfo[0].brxm + @"</patientName>
                           <patientSex>" + _lisinfo[0].xb + @"</patientSex>
           <patientBirthday>" + _lisinfo[0].csrq + @"</patientBirthday>
           <patientBedNo>" + _lisinfo[0].ch + @"</patientBedNo>
           <Diagnose>" + _lisinfo[0].zd + @"</Diagnose><reqDept>
           <deptId>" + TrasenHIS.BLL.HisFunctions.ConvertNewhisidToOldHisid(TrasenHIS.BLL.HisFunctions.DataMapType.JC_DEPT_PROPERTY, _lisinfo[0].deptid, TrasenFrame.Forms.FrmMdiMain.Database) + @"</deptId>   
            <deptName>" + _lisinfo[0].deptname + @"</deptName> 
            </reqDept>
            <reqDoctor>
                     <employeeId>" + TrasenHIS.BLL.HisFunctions.ConvertNewhisidToOldHisid(TrasenHIS.BLL.HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, _lisinfo[0].employeeId, TrasenFrame.Forms.FrmMdiMain.Database) + "</employeeId><employeeName>" + _lisinfo[0].employeeName + @"</employeeName> 
           </reqDoctor>
           <crtDateTime>" + _lisinfo[0].crtDateTime + @"</crtDateTime>  
           <status>20</status>  
        <vomiting>" + vomiting + @"</vomiting> 
        <paralyticileus>" + paralyticileus + @"</paralyticileus>
        <Bowelsoundsweakened>" + Bowelsoundsweakened + @"</Bowelsoundsweakened>
        <intestinalischemia>" + intestinalischemia + @"</intestinalischemia>
        <diarrhea>" + diarrhea + @"</diarrhea>
        <Ogilvie>" + Ogilvie + @"</Ogilvie>
        <Gastroparesis>" + Gastroparesis + @"</Gastroparesis>
        <Gastrointestinalbleeding>" + Gastrointestinalbleeding + @"</Gastrointestinalbleeding>
        <Feedingintolerance>" + Feedingintolerance + @"</Feedingintolerance>
        <Intraperitonealpressure>" + Intraperitonealpressure + @"</Intraperitonealpressure> 
        <brlx>" + brlx + @"</brlx> 
           </examReqInfo>
           </body>

           </message>";
            //System.Windows.Forms.MessageBox.Show(xml);
            string ss1 = ls.LisServiceInput(xml);

            try
            {
                System.Xml.XmlDocument documentGet = new System.Xml.XmlDocument();
                documentGet.LoadXml(ss1);
                //System.Xml.XmlNode ndCodeGet = documentGet.SelectSingleNode("code");
                //string RetCode = ndCodeGet.InnerText;

                System.Xml.XmlNode ndCodeGetText = documentGet.DocumentElement.SelectSingleNode("response/description");
                strMsg = ndCodeGetText.InnerText;
            }
            catch { }

            return Converttb(ss1);
        }
    }
}
