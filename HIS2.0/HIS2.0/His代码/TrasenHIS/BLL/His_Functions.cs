using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace TrasenHIS.BLL
{
    public class HisFunctions
    {
        /// <summary>
        /// 将XML转换为dataset
        /// </summary>
        /// <param name="poststring"></param>
        /// <returns></returns>
        public static DataSet ConvertXmlToDataSet(string poststring)
        {
            string strHead = "<?xml version=\"1.0\" encoding=\"gb2312\" ?> ";
            string xml = strHead + poststring;
            DataSet ds = new DataSet();
            StringReader StrStream = null;
            XmlTextReader Xmlrdr = null;
            //读取文件中的字符流       
            StrStream = new StringReader(xml);
            //获取StrStream中的数据                     
            Xmlrdr = new XmlTextReader(StrStream);
            //ds获取Xmlrdr中的数据            
            ds.ReadXml(Xmlrdr);
            return ds;
        }

        public enum DataMapType
        {
            JC_EMPLOYEE_PROPERTY,
            JC_DEPT_PROPERTY,
            JC_HSITEM,
            JC_TC_T,
            YP_YPCJD,
            YP_GHDW,
            YP_SCCJ,
            YP_YPDW,
            YP_YPJX,
            JC_STAT_ITEM,
            ZY_BEDDICTION
        }
        /// <summary>
        /// 老ID转换成新HISID
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id">老的HIS编码</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string ConvertOldhisidToNewHisid(DataMapType type, string id, RelationalDatabase db)
        {
            string ssql = "select newid from datamap where  NEWTABLE='" + type.ToString() + "' and oldid='" + id + "'";
            DataTable tb = db.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return Convertor.IsNull(tb.Rows[0]["newid"], "");
            else
                return "";
        }
        /// <summary>
        /// 新ID转换成老HISID
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id">新的HIS编码</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string ConvertNewhisidToOldHisid(DataMapType type, string id, RelationalDatabase db)
        {
            string ssql = "select oldid from datamap where  NEWTABLE='" + type.ToString() + "' and newid='" + id + "'";
            DataTable tb = db.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return Convertor.IsNull(tb.Rows[0]["oldid"], "");
            else
                return "";
        }



        public static string GetResponseString(string funcName, string[] strlist)
        {
            StringBuilder sb = new StringBuilder();
            switch (funcName)
            {
                case "SaveInpatient":
                    #region SaveInpatient
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<PATIENTID>" + strlist[2] + "</PATIENTID>");
                    sb.Append("<INPATIENTID>" + strlist[3] + "</INPATIENTID>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "SaveDeposits":
                    #region SaveDeposits
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<HISWHY>" + strlist[2] + "</HISWHY>");
                    sb.Append("<YJJZE>" + strlist[3] + "</YJJZE>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "SaveOrder":
                    #region
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<OrderID> </OrderID>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "SaveKcph":
                case "SaveFee":
                case "SaveMzcf":
                case "SaveMztf":
                case "SaveMzFyzt":
                case "SaveMzQxFyzt":
                    #region SaveDeposits
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "SaveCyzt":
                    #region SaveCyzt
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<HISWHY>" + strlist[2] + "</HISWHY>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "OrderExec":
                    #region
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<OrderID>" + strlist[2] + "</OrderID>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "SaveOperationApplye":
                    #region
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<ApplyId>" + strlist[2] + "</ApplyId>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "ChangeBed":
                    #region
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<BedID>" + strlist[2] + "</BedID>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "TransDept":
                    #region
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<KSID>" + strlist[2] + "</KSID>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "StopOrder":
                case "CancelOrder":
                    #region
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<OrderID> </OrderID>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "ChangeGCYS":
                    #region
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<DocID>" + strlist[2] + "</DocID>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
                case "InpatientOut":
                    #region SaveInpatient
                    sb.Append("<Response>");
                    sb.Append("<HEAD>");
                    sb.Append("<ERRCODE>" + strlist[0] + "</ERRCODE>");
                    sb.Append("<ERRTEXT>" + strlist[1] + "</ERRTEXT>");
                    sb.Append("</HEAD>");
                    sb.Append("<DATA>");
                    sb.Append("<INPATIENTID> </INPATIENTID>");
                    sb.Append("</DATA>");
                    sb.Append("</Response>");
                    break;
                    #endregion
            }

            Logger.Instance().WriteLog("【Response:" + funcName + "】：" + sb.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// 获取频率每日次数
        /// </summary>
        /// <param name="plmc"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static decimal GetPLCS(string plmc, RelationalDatabase db)
        {
            string sql = "select * from JC_FREQUENCY where name='" + plmc + "'";
            DataTable tb = db.GetDataTable(sql);

            if (tb != null && tb.Rows.Count > 0)
            {
                decimal cs = Convert.ToDecimal(tb.Rows[0]["execnum"]);

                return cs;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 返回老HIS的医嘱类别
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="yznr">医嘱内容</param>
        /// <returns></returns>
        public static string GetOldHISYzlb(string ntype, string yznr)
        {
            //Z：中药M：西药X：项目O：其它0：未知5：会诊7：转科医嘱8：手术申请单9：出院
            string yzlb = "";
            #region
            switch (ntype)
            {
                case "1":
                    yzlb = "M";
                    break;
                case "2":
                    yzlb = "Z";//??
                    break;
                //case "3":
                //    yzlb = "0";
                //    break;
                case "4":
                case "5":
                case "6":
                case "8":
                case "9":
                    yzlb = "X";
                    break;
                case "0":
                    {
                        if (yznr.IndexOf("转") >= 0)
                        {
                            yzlb = "7";
                        }
                        else if (yznr.IndexOf("出院") >= 0 || yznr.IndexOf("死亡") >= 0)
                        {
                            yzlb = "9";
                        }
                        else
                        {
                            yzlb = "O";
                        }
                    }
                    break;
                default:
                    yzlb = "0";
                    break;
            #endregion
            }

            return yzlb;
        }

        /// <summary>
        /// 返回老HIS的医嘱类别名称
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="yznr"></param>
        /// <returns></returns>
        public static string GetOldHISYzlbmc(string ntype, string yznr)
        {
            //Z：中药M：西药X：项目O：其它0：未知5：会诊7：转科医嘱8：手术申请单9：出院
            string yzlbmc = "";
            #region
            switch (ntype)
            {
                case "1":
                    yzlbmc = "西药";
                    break;
                case "2":
                    yzlbmc = "中药";//??
                    break;
                //case "3":
                //    yzlb = "0";
                //    break;
                case "4":
                case "5":
                case "6":
                case "8":
                case "9":
                    yzlbmc = "项目";
                    break;
                case "0":
                    {
                        if (yznr.IndexOf("转") >= 0)
                        {
                            yzlbmc = "转科医嘱";
                        }
                        else if (yznr.IndexOf("出院") >= 0 || yznr.IndexOf("死亡") >= 0)
                        {
                            yzlbmc = "出院";
                        }
                        else
                        {
                            yzlbmc = "其它";
                        }
                    }
                    break;
                default:
                    yzlbmc = "未知";
                    break;
            #endregion
            }

            return yzlbmc;
        }

        /// <summary>
        /// 获取老HIS的项目药品编码
        /// </summary>
        /// <param name="xmly"></param>
        /// <param name="hoitemid"></param>
        /// <returns></returns>
        public static string GetOldHISXmYpBM(string xmly, string hoitemid, RelationalDatabase db)
        {
            string bm = "";

            if (xmly == "1")
            {
                bm = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.YP_YPCJD, hoitemid, db);
            }
            else
            {
                string sql = "select * from JC_HOI_HDI where HOITEM_ID=" + hoitemid;
                DataTable tb = db.GetDataTable(sql);

                if (tb.Rows[0]["tc_flag"].ToString() == "0")
                {
                    bm = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_HSITEM, tb.Rows[0]["hditem_id"].ToString(), db);
                }
                else
                {
                    bm = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_TC_T, tb.Rows[0]["tcid"].ToString(), db);
                }
            }

            return bm;
        }

        /// <summary>
        /// 获取老HIS的项目药品编码
        /// </summary>
        /// <param name="xmly"></param>
        /// <param name="hoitemid"></param>
        /// <returns></returns>
        public static string GetOldHISXmYpBM(string xmly, string hoitemid, out bool isKbxm, RelationalDatabase db)
        {
            string bm = "";
            isKbxm = false;

            if (xmly == "1")
            {
                bm = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.YP_YPCJD, hoitemid, db);
            }
            else
            {
                string sql = "select * from JC_HOI_HDI where HOITEM_ID=" + hoitemid;
                DataTable tb = db.GetDataTable(sql);

                if (tb.Rows[0]["tc_flag"].ToString() == "0")
                {
                    bm = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_HSITEM, tb.Rows[0]["hditem_id"].ToString(), db);
                }
                else
                {
                    bm = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_TC_T, tb.Rows[0]["tcid"].ToString(), db);
                    isKbxm = true;
                }
            }

            return bm;
        }

        /// <summary>
        /// 获取新系统价格信息
        /// </summary>
        /// <param name="xmly"></param>
        /// <param name="hoitemid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static decimal GetNewHISPrice(string xmly, string hoitemid, RelationalDatabase db)
        {
            decimal jg = 0;

            if (xmly == "1")
            {
                jg = Convert.ToDecimal(db.GetDataResult("select lsj from YP_YPCJD where cjid=" + hoitemid));
            }
            else
            {
                string sql = "select * from JC_HOI_HDI where HOITEM_ID=" + hoitemid;
                DataTable tb = db.GetDataTable(sql);

                if (tb.Rows.Count > 0)
                {
                    if (tb.Rows[0]["tc_flag"].ToString() == "0")
                    {
                        jg = Convert.ToDecimal(db.GetDataResult("select retail_price from jc_hsitemdiction where item_id=" + tb.Rows[0]["hditem_id"].ToString()));
                    }
                    else
                    {
                        jg = Convert.ToDecimal(db.GetDataResult("select PRICE from JC_TC where ITEM_ID=" + tb.Rows[0]["tcid"].ToString()));
                    }
                }
            }

            return jg;
        }

        /// <summary>
        /// 通过药品计算的存储过程获取药品计算信息
        /// </summary>
        /// <param name="dwlx"></param>
        /// <param name="num"></param>
        /// <param name="cjid"></param>
        /// <param name="zxks"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable SP_FUN_DW_NUM(string dwlx, decimal num, string cjid, string zxks, RelationalDatabase db)
        {
            DataTable tb = new DataTable();

            ParameterEx[] parameters = new ParameterEx[8];

            string sSql = "SP_FUN_DW_NUM";
            parameters[0].Value = dwlx;
            parameters[0].Text = "@dwtype";
            parameters[1].Value = num;
            parameters[1].Text = "@num";
            parameters[2].Value = 1;
            parameters[2].Text = "@zxcs";
            parameters[3].Value = 1;
            parameters[3].Text = "@jgts";
            parameters[4].Value = 1;
            parameters[4].Text = "@ts";
            parameters[5].Value = cjid;
            parameters[5].Text = "@CJID";
            parameters[6].Value = zxks;
            parameters[6].Text = "@DEPTID";
            parameters[7].Value = 0;
            parameters[7].Text = "@DWBL";

            tb = db.GetDataTable(sSql, parameters, 60);

            return tb;
        }

        public static List<String[]> GetInsertSql(string tablename, DataTable tbcol)
        {
            List<System.String[]> listInsert = new List<System.String[]>();

            foreach (DataRow row in tbcol.Rows)
            {
                string ssql = "insert into " + tablename + "(";
                for (int i = 0; i <= tbcol.Columns.Count - 1; i++)
                    ssql = ssql + tbcol.Columns[i].ColumnName + ",";
                ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                ssql = ssql + "values(";
                for (int i = 0; i <= tbcol.Columns.Count - 1; i++)
                {
                    if (tbcol.Columns[i].DataType.ToString() == "System.String")
                        ssql = ssql + "'" + TrasenHIS.DAL.BaseDal.GetEncodingString(Convertor.IsNull(row[i], "")) + "',";//TrasenHIS.DAL.BaseDal.GetEncodingStringToInforMix(parameters[i].Value.ToString())
                    else
                    {
                        if (row[i] == DBNull.Value)
                            ssql = ssql + "null,";
                        else
                            ssql = ssql + "'" + Convertor.IsNull(row[i], "") + "',";
                    }
                }
                ssql = ssql.Substring(0, ssql.Length - 1) + ")";

                //用于记录生成的SQL语句，医嘱主键，操作类型。。在一面的事务中一次性处理
                System.String[] str_insert = { ssql, "add" };
                listInsert.Add(str_insert);

            }
            return listInsert;
        }

        /// <summary>
        /// 获取EMR系统的诊断信息
        /// </summary>
        /// <param name="inpatientNo">住院号</param>
        /// <param name="inpatientBANo">病案号</param>
        /// <returns></returns>
        public static string[] GetEmrDiagnosois(string inpatientNo, string inpatientBANo)
        {
            try
            {
                string[] rtn = new string[2];
                TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                string strXml = "<message msgType=\"call\" msgId=\"1\" timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" version=\"1\">" +
                                "<call timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" crfCallMode=\"alwaysRespond\">" +
                                "<targetLogicService>CIS_GET_DIAGNOSIS</targetLogicService> " +
                                "<targetLogicApp>HIS</targetLogicApp>" +
                                "<bizid></bizid>" +
                                "</call>" +
                                "<body bodyId=\"1\">" +
                                "<inhospPatient>" +
                                "<inhospId>" + Convert.ToInt64(inpatientNo).ToString().Trim() + "</inhospId>" +
                                "<patientid>" + inpatientBANo + "</patientid>" +
                                "</inhospPatient>" +
                                "</body></message>";

                string returnXml = ws.ExeWebService("GetEmrDiagnosois", strXml);
                DataSet ds = HisFunctions.ConvertXmlToDataSet(returnXml);
                if (ds.Tables["response"].Rows[0]["code"].ToString() == "0")
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(returnXml);
                    System.Data.DataTable tb = new DataTable();
                    tb.Columns.Add("code", typeof(System.String));
                    tb.Columns.Add("name", typeof(System.String));
                    XmlNode root = xml.SelectSingleNode("/message/body/outhos");//查找<Employees> 
                    if (root.ChildNodes.Count == 0)
                    {
                        root = xml.SelectSingleNode("/message/body/inhos");
                        if (root.ChildNodes.Count > 0)
                        {
                            MessageBox.Show("未获取到出院诊断，但是获取到入院诊断！");
                        }
                    }
                    foreach (XmlNode xn in root.ChildNodes)
                    {
                        System.Data.DataRow r = tb.NewRow();
                        r["code"] = xn.ChildNodes[0].InnerText.Replace("\"", "");
                        r["name"] = xn.ChildNodes[1].InnerText.Replace("\"", "");
                        if (Convertor.IsNull(r["code"], "null").ToLower() == "null" || Convertor.IsNull(r["name"], "null").ToLower() == "null")
                        {
                            continue;
                        }
                        tb.Rows.Add(r);
                    }
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        Ts_zygl_ybgl.FrmDataGridView frmDv = new Ts_zygl_ybgl.FrmDataGridView();
                        frmDv.dgv.DataSource = tb;
                        frmDv.dgv.MultiSelect = false;
                        frmDv.ShowDialog();
                        if (frmDv.DialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (frmDv.dgv.SelectedRows.Count == 0)
                            {
                                throw new Exception("未选择诊断！");
                            }
                            else
                            {
                                rtn[0] = Convertor.IsNull(tb.Rows[frmDv.dgv.SelectedRows[0].Index]["code"], "");
                                rtn[1] = Convertor.IsNull(tb.Rows[frmDv.dgv.SelectedRows[0].Index]["name"], "");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("未获取到EMR诊断！");
                    }
                }
                else
                {
                    throw new Exception("获取EMR诊断时出错！错误代码【" + ds.Tables["response"].Rows[0]["code"].ToString() + "】错误描述【" + ds.Tables["response"].Rows[0]["description"].ToString() + "】");
                }
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string[] GetEmrDiagnosois_jc(string inpatientNo, string inpatientBANo)
        {
            try
            {
                string[] rtn = new string[2];
                TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                string strXml = "<message msgType=\"call\" msgId=\"1\" timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" version=\"1\">" +
                                "<call timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" crfCallMode=\"alwaysRespond\">" +
                                "<targetLogicService>CIS_GET_DIAGNOSIS</targetLogicService> " +
                                "<targetLogicApp>HIS</targetLogicApp>" +
                                "<bizid></bizid>" +
                                "</call>" +
                                "<body bodyId=\"1\">" +
                                "<inhospPatient>" +
                                "<inhospId>" + Convert.ToInt64(inpatientNo).ToString().Trim() + "</inhospId>" +
                                "<patientid>" + inpatientBANo + "</patientid>" +
                                "</inhospPatient>" +
                                "</body></message>";

                string returnXml = ws.ExeWebService("GetEmrDiagnosois", strXml);
                DataSet ds = HisFunctions.ConvertXmlToDataSet(returnXml);
                if (ds.Tables["response"].Rows[0]["code"].ToString() == "0")
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(returnXml);
                    System.Data.DataTable tb = new DataTable();
                    tb.Columns.Add("code", typeof(System.String));
                    tb.Columns.Add("name", typeof(System.String));
                    XmlNode root = xml.SelectSingleNode("/message/body/outhos");//查找<Employees> 
                    if (root.ChildNodes.Count == 0)
                    {
                        root = xml.SelectSingleNode("/message/body/inhos");
                        //if (root.ChildNodes.Count > 0)
                        //{
                        //    MessageBox.Show("未获取到出院诊断，但是获取到入院诊断！");
                        //}
                    }
                    foreach (XmlNode xn in root.ChildNodes)
                    {
                        System.Data.DataRow r = tb.NewRow();
                        r["code"] = xn.ChildNodes[0].InnerText.Replace("\"", "");
                        r["name"] = xn.ChildNodes[1].InnerText.Replace("\"", "");
                        if (Convertor.IsNull(r["code"], "null").ToLower() == "null" || Convertor.IsNull(r["name"], "null").ToLower() == "null")
                        {
                            continue;
                        }
                        tb.Rows.Add(r);
                    }
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            rtn[0] += Convertor.IsNull(tb.Rows[i]["code"], "")+",";
                            rtn[1] += Convertor.IsNull(tb.Rows[i]["name"], "")+",";
                        }
                        rtn[0] = rtn[0].TrimEnd(',');
                        rtn[1] = rtn[1].TrimEnd(',');
                    }
                    else
                    {
                        throw new Exception("未获取到EMR诊断！");
                    }
                }
                else
                {
                    throw new Exception("获取EMR诊断时出错！错误代码【" + ds.Tables["response"].Rows[0]["code"].ToString() + "】错误描述【" + ds.Tables["response"].Rows[0]["description"].ToString() + "】");
                }
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取EMR系统的诊断信息
        /// </summary>
        /// <param name="inpatientNo">住院号</param>
        /// <param name="inpatientBANo">病案号</param>
        /// <returns></returns>
        public static DataTable GetEmrDiagnosoisDataTable(string inpatientNo, string inpatientBANo)
        {
            try
            {
                System.Data.DataTable tb = new DataTable();
                TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                string strXml = "<message msgType=\"call\" msgId=\"1\" timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" version=\"1\">" +
                                "<call timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" crfCallMode=\"alwaysRespond\">" +
                                "<targetLogicService>CIS_GET_DIAGNOSIS</targetLogicService> " +
                                "<targetLogicApp>HIS</targetLogicApp>" +
                                "<bizid></bizid>" +
                                "</call>" +
                                "<body bodyId=\"1\">" +
                                "<inhospPatient>" +
                                "<inhospId>" + Convert.ToInt64(inpatientNo).ToString().Trim() + "</inhospId>" +
                                "<patientid>" + inpatientBANo + "</patientid>" +
                                "</inhospPatient>" +
                                "</body></message>";

                string returnXml = ws.ExeWebService("GetEmrDiagnosois", strXml);
                DataSet ds = HisFunctions.ConvertXmlToDataSet(returnXml);
                if (ds.Tables["response"].Rows[0]["code"].ToString() == "0")
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(returnXml);

                    tb.Columns.Add("code", typeof(System.String));
                    tb.Columns.Add("name", typeof(System.String));
                    XmlNode root = xml.SelectSingleNode("/message/body/outhos");//查找<Employees> 
                    if (root.ChildNodes.Count == 0)
                    {
                        root = xml.SelectSingleNode("/message/body/inhos");
                        if (root.ChildNodes.Count > 0)
                        {
                            MessageBox.Show("未获取到出院诊断，但是获取到入院诊断！");
                        }
                    }
                    foreach (XmlNode xn in root.ChildNodes)
                    {
                        System.Data.DataRow r = tb.NewRow();
                        r["code"] = xn.ChildNodes[0].InnerText.Replace("\"", "");
                        r["name"] = xn.ChildNodes[1].InnerText.Replace("\"", "");
                        if (Convertor.IsNull(r["code"], "null").ToLower() == "null" || Convertor.IsNull(r["name"], "null").ToLower() == "null")
                        {
                            continue;
                        }
                        tb.Rows.Add(r);
                    }
                }
                else
                {
                    throw new Exception("获取EMR诊断时出错！错误代码【" + ds.Tables["response"].Rows[0]["code"].ToString() + "】错误描述【" + ds.Tables["response"].Rows[0]["description"].ToString() + "】");
                }
                return tb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Add By Tany 2015-06-04
        /// <summary>
        /// 获取EMR简要病史
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="inpatientBANo"></param>
        /// <returns></returns>
        public static DataTable GetEmrInpatientSummary(string inpatientNo, string inpatientBANo)
        {
            try
            {
                System.Data.DataTable tb = new DataTable();
                EMRWS.WebSActionService ws = new EMRWS.WebSActionService();

                string returnXml = ws.manageWS("INPATIENTSUMMARY", Convert.ToInt64(inpatientNo).ToString());//
                returnXml = returnXml.Replace("<?xml version=\"1.0\" standalone=\"yes\"?>", "");
                DataSet ds = HisFunctions.ConvertXmlToDataSet(returnXml);
                if (ds.Tables["DocumentElement"].Rows[0]["ResultCode"].ToString() == "0")
                {
                    tb = ds.Tables["INPATIENTSUMMARY"];
                }
                else
                {
                    throw new Exception("获取EMR简要病史时出错！错误代码【" + ds.Tables["DocumentElement"].Rows[0]["ResultCode"].ToString() + "】错误描述【" + ds.Tables["DocumentElement"].Rows[0]["ResultContent"].ToString().Trim() + "】");
                }
                return tb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 是否未预约
        /// </summary>
        /// <param name="jcNo"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static bool HasNotBooked(string jcNo, out string strMsg)
        {
            strMsg = "";

            TrasenWS.TrasenWS ts = new TrasenHIS.TrasenWS.TrasenWS();
            string ret = ts.ExeWebService("NewCheckOrder.IsBooked", jcNo);

            //已预约或者预约失败
            if (!ret.Trim().Equals("false"))
            {
                strMsg = ret;
                return false;
            }

            //未预约
            return true;
        }

        public static bool GetEmrDiagnosis(string inpNo, out string strMsg)
        {
            strMsg = "";
            try
            {
                TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                ws.Url = "http://192.168.0.90:88/TrasenWS.asmx";
                strMsg = ws.GetXml("Emr.GetEmrDiagnosis", inpNo);

                if (strMsg.Trim().Equals(""))
                {
                    strMsg = "未获取到Emr入院诊断";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
            }
        }
    }
}
