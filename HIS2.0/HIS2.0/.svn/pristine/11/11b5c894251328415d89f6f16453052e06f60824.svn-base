using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;

namespace ts_yf_mzkf
{
    public class ts_whzxyy_mzkf : IMzkf
    {       
        /// <summary>
        /// 2.3处方发药  sendMedToWillach
        /// </summary>
        /// <param name="tbInfo">处方号，处方日期，窗口号，操作员，操作员ID,ip地址</param>
        /// <param name="strWinid"></param>
        /// <param name="strManno"></param>
        /// <param name="strManname"></param>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public int SendMedicine(DataTable tbInfo, string strWinid, string strManno, string strManname, string strIP, int deptid, string str_HH_Flag)
        {
            if (tbInfo.Rows.Count <= 0)
            {
                ThrowTechError("MZYF.SelectMzcfk方法返回的数据为空", 1, new List<string>(), strWinid, WanIp, deptid);
                return 101;
            }
            StringBuilder strXml = new StringBuilder();
            strXml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            strXml.Append("<root>");
            strXml.Append("<winid>" + strWinid + "</winid>");
            strXml.Append("<manno>" + strManno + "</manno>");
            strXml.Append("<manname>" + strManname + "</manname>");
            strXml.Append("<opip>" + strIP + "</opip>");
            string _prescNo = "";
            bool param = false;
            List<string> cfdList = new List<string>();
            List<string> cache = new List<string>();
            for (int k = 0; k < tbInfo.Rows.Count; k++)
            {
                object cfid = tbInfo.Rows[k]["CFXH"];   //mz_cfb cfid
                object hjid = tbInfo.Rows[k]["处方号"]; //mz_cfb hjid
                if (cfid == null || cfid.ToString().Trim() == string.Empty)
                {
                    //ThrowTechError("tbInfo.Rows[k][CFXH]为空", 1, new List<string>(), strWinid, WanIp, deptid);
                    continue;
                }
                else
                {
                    //药房直连后，直接取数据2.0表的处方ID，不用通过WS取3.0的数据 Add By HYD 2017-11-22
                    string strIDDh = tbInfo.Rows[k]["CFXH"].ToString();

                    strXml.Append("<startSendMedicine>");
                    //strXml.Append("<presc_no>" + dt.Rows[0][0] + "</presc_no>");//原来
                    strXml.Append("<presc_no>" + strIDDh + "</presc_no>");
                    strXml.Append("<presc_date>" + tbInfo.Rows[k]["录入日期"] + "</presc_date>");
                    strXml.Append("</startSendMedicine>");
                    // cfdList.Add(dt.Rows[0][0].ToString());//原来
                    cfdList.Add(strIDDh);
                    cache.Add(tbInfo.Rows[k]["cfxh"].ToString());
                    _prescNo = tbInfo.Rows[k]["cfxh"] != null ? tbInfo.Rows[k]["cfxh"].ToString().Trim() : ""; //tbInfo.Rows[k]["处方号"].ToString().Trim();
                    param = true;

                }

                /*
                if (cache.Count == 0 || string.IsNullOrEmpty(cache.Find(delegate(string s) { return s == tbInfo.Rows[k]["cfxh"].ToString(); })))
                {
                    int num = 0;
                Label001:
                    {
                        string sql = string.Format("select dh,djhm from whzxyy_mz_cfb_zb where cfid = '{0}'", tbInfo.Rows[k]["cfxh"]);
                        DataTable dt = DataBase.GetDataTable(sql);

                       

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //*************************2017-01-06 HYD *********************************************
                            ts_yf_mzkf.TrasenWS.TrasenWS TsWs = new ts_yf_mzkf.TrasenWS.TrasenWS();
                            string strIDDh = string.Empty;
                            string strdjhm = dt.Rows[0]["dh"].ToString();
                            string PostString = "<root><djhm>" + dt.Rows[0]["djhm"].ToString() + "</djhm><dh>" + dt.Rows[0]["dh"].ToString() + "</dh></root>";

                            string strNewDh = TsWs.ExeWebService("GetKfPrescNoByDh", PostString);
                            if (strNewDh != "")
                            {
                                strIDDh = strNewDh;
                            }
                            else
                            {
                                strIDDh = strdjhm;
                            }
                            //**************************************************************************************

                            strXml.Append("<startSendMedicine>");
                            //strXml.Append("<presc_no>" + dt.Rows[0][0] + "</presc_no>");//原来
                            strXml.Append("<presc_no>" + strIDDh + "</presc_no>");
                            strXml.Append("<presc_date>" + tbInfo.Rows[k]["录入日期"] + "</presc_date>");
                            strXml.Append("</startSendMedicine>");
                           // cfdList.Add(dt.Rows[0][0].ToString());//原来
                            cfdList.Add(strIDDh);
                            cache.Add(tbInfo.Rows[k]["cfxh"].ToString());
                            _prescNo = tbInfo.Rows[k]["cfxh"] != null ? tbInfo.Rows[k]["cfxh"].ToString().Trim() : ""; //tbInfo.Rows[k]["处方号"].ToString().Trim();
                            param = true;
                        }
                        else if (num <= 3)
                        {
                            num++;
                            Thread.Sleep(2000);
                            goto Label001;
                        }
                        else
                        {
                            ThrowTechError("未找到处方", 1, new List<string>(), strWinid, WanIp, deptid);
                            return 102;
                        }
                    }
                }*/
            }
            strXml.Append("</root>");
            if (param == false)
                return 103;
            string result = string.Empty;
            try
            {
                MZKF.getHisInfoToWillach ws = new MZKF.getHisInfoToWillach();
                result = ws.sendMedToWillach(strXml.ToString());
                ThrowTechError(result, 1, cfdList, strWinid, WanIp, deptid);
                if (!string.IsNullOrEmpty(result) && result.IndexOf("排队人数") >= 0)
                {
                    return 200;
                }
                return 1;
            }
            catch (Exception err)
            {
                ThrowTechError(result + " " + err.Message, 1, cfdList, strWinid, WanIp, deptid);
                return 104;
            }
        }

        /// <summary>
        /// 2.62.6	处方结束发药  endSendMedToWillach
        /// </summary>
        /// <param name="tbInfo"></param>
        /// <param name="strWinid"></param>
        /// <param name="strManno"></param>
        /// <param name="strManname"></param>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public string EndToMedicine(DataTable tbInfo, string strWinid, string strManno, string strManname, string strIP, int deptid, string str_HH_Flag)
        {
            if (tbInfo.Rows.Count <= 0)
            {
                ThrowTechError("DataTable的数据为空", 2, new List<string>(), strWinid, WanIp, deptid);
                return "101";
            }
            StringBuilder strXml = new StringBuilder();
            strXml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            strXml.Append("<root>");
            strXml.Append("<winid>" + strWinid + "</winid>");
            strXml.Append("<manno>" + strManno + "</manno>");
            strXml.Append("<manname>" + strManname + "</manname>");
            strXml.Append("<opip>" + strIP + "</opip>");            
            bool param = false;
            List<string> cfdList = new List<string>();
            List<string> cache = new List<string>();
            for (int k = 0; k < tbInfo.Rows.Count; k++)
            {
                object cfid = tbInfo.Rows[k]["CFXH"];   //mz_cfb cfid
                object hjid = tbInfo.Rows[k]["处方号"]; //mz_cfb hjid
                if (cfid == null || cfid.ToString().Trim() == string.Empty)
                {
                    continue;
                }
                else
                {
                    //药房直连后，直接取数据2.0表的处方ID，不用通过WS取3.0的数据 Add By HYD 2017-11-22
                    string strIDDh = tbInfo.Rows[k]["CFXH"].ToString();

                    strXml.Append("<endSendMedicine>");
                    //strXml.Append("<presc_no>" + dt.Rows[0][0] + "</presc_no>");
                    strXml.Append("<presc_no>" + strIDDh + "</presc_no>");
                    strXml.Append("<presc_date>" + tbInfo.Rows[k]["录入日期"] + "</presc_date>");
                    strXml.Append("</endSendMedicine>");
                    cache.Add(tbInfo.Rows[k]["CFXH"].ToString().Trim());
                    // cfdList.Add(dt.Rows[0][0].ToString()); 
                    cfdList.Add(strIDDh);
                    param = true;
                }
             
                /*
                if ((cache.Count == 0 || string.IsNullOrEmpty(cache.Find(delegate(string s) { return s == tbInfo.Rows[k]["CFXH"].ToString(); }))) &&
                    tbInfo.Rows[k]["序号"].ToString().Trim() != "小计")
                {
                    int num = 0;
                Label001:
                    {
                        string sql = string.Format("select dh,djhm from whzxyy_mz_cfb_zb where cfid = '{0}'", tbInfo.Rows[k]["CFXH"]);
                        DataTable dt = DataBase.GetDataTable(sql);
                        


                        if (dt != null && dt.Rows.Count > 0)
                        {

                            //*************************2017-01-06 HYD *********************************************
                            ts_yf_mzkf.TrasenWS.TrasenWS TsWs = new ts_yf_mzkf.TrasenWS.TrasenWS();
                            string strIDDh = string.Empty;
                            string strdjhm = dt.Rows[0]["dh"].ToString();
                            string PostString = "<root><djhm>" + dt.Rows[0]["djhm"].ToString() + "</djhm><dh>" + dt.Rows[0]["dh"].ToString() + "</dh></root>";

                            string strNewDh = TsWs.ExeWebService("GetKfPrescNoByDh", PostString);
                            if (strNewDh != "")
                            {
                                strIDDh = strNewDh;
                            }
                            else
                            {
                                strIDDh = strdjhm;
                            }
                            //**************************************************************************************

                            strXml.Append("<endSendMedicine>");                            
                            //strXml.Append("<presc_no>" + dt.Rows[0][0] + "</presc_no>");
                            strXml.Append("<presc_no>" + strIDDh + "</presc_no>");
                            strXml.Append("<presc_date>" + tbInfo.Rows[k]["录入日期"] + "</presc_date>");
                            strXml.Append("</endSendMedicine>");
                            cache.Add(tbInfo.Rows[k]["CFXH"].ToString().Trim());
                           // cfdList.Add(dt.Rows[0][0].ToString()); 
                            cfdList.Add(strIDDh); 
                            param = true;
                        }
                        else if (num <= 3)
                        {
                            num++;
                            Thread.Sleep(2000);
                            goto Label001;
                        }
                        else
                        {
                            ThrowTechError("未找到处方", 2, new List<string>(), strWinid, WanIp, deptid);
                            return "102";
                        }
                    }
                }*/
            }
            strXml.Append("</root>");
            if (param == false)
                return "103";
            string result = string.Empty;
            try
            {
                MZKF.getHisInfoToWillach ws = new MZKF.getHisInfoToWillach();
                result = ws.endSendMedToWillach(strXml.ToString());
                ThrowTechError(result, 2, cfdList, strWinid, WanIp, deptid);
                return result;
            }
            catch (Exception err)
            {
                ThrowTechError(result + " " + err.Message, 2, cfdList, strWinid, WanIp, deptid);
                return "104";
            }
        }
            
        private string WanIp
        {
            get
            {
                try
                {
                    System.Net.IPAddress addr;
                    addr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
                    return addr.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }      
        }
 
        #region IMzkf 成员
        private TrasenClasses.DatabaseAccess.RelationalDatabase _db;
        public TrasenClasses.DatabaseAccess.RelationalDatabase DataBase
        {
            get
            {
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        void ThrowTechError(string error, int type, List<string> cfList, string fyckh, string execIp, int deptid)
        {
            string remark = string.Empty;
            object[] param = null;
            try
            {
                string ErrPath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, "门诊快发日志");
                if (!Directory.Exists(ErrPath))
                {
                    Directory.CreateDirectory(ErrPath);
                }
                StreamWriter txtWriter = new StreamWriter(string.Format(@"{0}\{1}-log.txt", ErrPath, DateTime.Now.ToString("yyyy-MM-dd")), true);
                param = new object[] { Brxm ?? "",
                                   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                   type == 1 ? "开始发药" : "结束发药", 
                                   type == 1 ? "sendMedToWillach" : "endSendMedToWillach", 
                                   error };
                remark = string.Format("{0}在{1}{2},调用华润{3}接口返回:{4}", param);
                txtWriter.WriteLine(remark);
                if (cfList != null && cfList.Count > 0)
                {
                    foreach (string s in cfList)
                        txtWriter.WriteLine(s);
                }
                txtWriter.WriteLine();
                txtWriter.Close();
            }
            catch
            {
                MessageBox.Show("本地日志记录失败!", "提示");
            }

            try
            {
                param = new object[] { Guid.NewGuid().ToString(), Brxxid, Brxm, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), type, error, remark, execIp, string.IsNullOrEmpty(fyckh) ? "Null" : fyckh, deptid };
                string sql = string.Format(@"insert into mz_mzkflog(ID,BRXXID,BRXM,CREATEDATE,KFTYPE,EXECRESULT,REMARK,EXECIP,FYCKH,DEPTID) VALUES(
                               '{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}',{8},{9})", param);
                DataBase.DoCommand(sql);
            }
            catch (Exception err)
            {
                MessageBox.Show(string.Format("数据库日志记录失败!{0}", err.Message), "提示");
            }
        }
       
        private string _xm;
        public string Brxm
        {
            get
            {
                return _xm;
            }
            set
            {
                _xm = value;
            }
        }

        private string _brxxid;
        public string Brxxid
        {
            get
            {
                return _brxxid;
            }
            set
            {
                _brxxid = value;
            }
        }
        #endregion

 
    }
}
