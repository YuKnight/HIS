using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using Ts_Visit_Class;

namespace Ts_OrderRegist
{
    /// <summary>
    /// 调用预约平台webservice方法实现类 add by zp 2013-01-04
    /// </summary>
    public class Order_Web
    {
        /// <summary>
        /// 预约平台webservice连接类
        /// </summary>
       // TrasenWebService Ts_Order = new TrasenWebService();// TrasenWebService(0);
        Web_OrderClient Ts_Order = null; 
        /// <summary>
        /// 解析预约平台返回的xml对象
        /// </summary>
        Order_Parmanalyze Analy = new Order_Parmanalyze();
        SystemCfg cfg;

        private string HosptId = string.Empty;

        //private DataTable dt_time;


        public Order_Web(SystemCfg _cfg)
        {
            this.cfg = _cfg;
            SystemCfg cfg3063 = new SystemCfg(3063);
            Ts_Order = new Web_OrderClient(cfg3063.Config); ;
        }
        /// <summary>
        /// 预约登记
        /// </summary>
        /// <param name="cardno">卡号</param>
        /// <param name="name">预约姓名</param>
        /// <param name="sfzh">身份证号</param>
        /// <param name="sex">性别</param>
        /// <param name="birthday">出生年月日</param>
        /// <param name="phone">电话</param>
        /// <param name="address">地址</param>
        /// <param name="rowid">排班主键</param>
        /// <param name="czyh">操作员</param>
        /// <param name="klxid">卡类型id</param>
        /// <param name="msg">本函数返回的字符值 成功存储平台交易流水号 失败存储失败信息</param>
        /// <param name="qhpassword">取号密码</param>
        /// <param name="hisorderid">预约id</param>
        /// <param name="numberid">平台所需的主键</param>
        /// <param name="Bz">备注信息 Add by zp 2014-09-25</param>
        /// <returns></returns>
        public bool SaveOrder(string cardno,string name,string sfzh,string sex,
            string birthday,string phone,string address,string rowid,string czyh,int klxid,ref string msg,
            ref string qhpassword,ref string hisorderid,ref string numberid,string Bz)
        {
            bool save_value = false;
            try
            {
                if (string.IsNullOrEmpty(HosptId))
                {
                    HosptId = cfg.Config;
                }
               //string post = "<PAYMENT><HEAD><ResponseCode></ResponseCode><ResponseMsg></ResponseMsg><Date></Date><tsCliePw>-1</tsCliePw></HEAD><DATA><tsMediCardId>" + cardno + "</tsMediCardId><tsUserName>" + name + "</tsUserName><tsUserCardID>" + sfzh + "</tsUserCardID><tsUserSex>"+sex+"</tsUserSex><tsUserBD>" + birthday + "</tsUserBD><tsUserContNum>" + phone + "</tsUserContNum><tsUserContAdd>" + address + "</tsUserContAdd><tsRowID>" + rowid + "</tsRowID><tsReseTime></tsReseTime><NumberID>" + numberid + "</NumberID><tsInMemo></tsInMemo></DATA></PAYMENT>";
                string post = @"<PAYMENT>
                                  <HEAD>
                                     <ResponseCode></ResponseCode>
                                     <ResponseMsg></ResponseMsg>
                                     <Date></Date>
                                     <tsCliePw>" + czyh + @"</tsCliePw>
                                  </HEAD>
                                  <DATA>
                                     <tsMediCardId>" + cardno + @"</tsMediCardId>
                                     <tsUserName>" + name + @"</tsUserName>
                                     <tsUserCardID>" + sfzh + @"</tsUserCardID>
                                     <tsUserSex>" + sex + @"</tsUserSex>
                                     <tsUserBD>" + birthday + @"</tsUserBD>
                                     <tsUserContNum>" + phone + @"</tsUserContNum>
                                     <tsUserContAdd>" + address + @"</tsUserContAdd>
                                     <tsRowID>" + rowid + @"</tsRowID>
                                     <tsReseTime></tsReseTime>
                                     <NumberID>" + numberid + @"</NumberID>
                                     <tsInMemo>" + Bz + @"</tsInMemo>
                                     <tsCardType>" + klxid + @"</tsCardType>  
                                  </DATA>
                               </PAYMENT>";
                string values = Ts_Order.GetReseSubm(post);
                string record = "0";
                save_value = Analy.GetOrderSaveResult(values, ref record, ref msg, ref hisorderid);
                if (save_value == true) //如果预约成功回填平台交易号给消息变量
                {
                    qhpassword = msg;  //取号密码
                    msg = record.ToString(); //交易流水号
                }
            }
            catch (Exception ea)
            {
                msg = ea.ToString();
            }
            return save_value;
        }
        /// <summary>
        /// 获取平台的时段编号
        /// </summary>
        /// <param name="rowid"></param>
        /// <returns></returns>
        public string GetNumberId(string rowid,string czyh)//2012-11-5|12|14605|2|8.00|1
        {
            string value = string.Empty;
            try
            {
                string _xml = @"<PAYMENT>
                              <HEAD>
                                <ResponseCode></ResponseCode>
                                <ResponseMsg></ResponseMsg>
                                <Date></Date>
                                <tsCliePw>"+czyh+@"</tsCliePw>
                              </HEAD>
　                            <DATA>
　　                            <sRowID>" + rowid + @"</sRowID>
　　                            <tsInMemo></tsInMemo>
　                            </DATA>
                            </PAYMENT>";
                            value = Ts_Order.GetNumber(_xml);
                return value;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        /// <summary>
        /// 获取平台的排班主键(如果没有返回排班主键表示平台无当前医生的排班信息)
        /// </summary>
        /// <param name="bdate"></param>
        /// <param name="edate"></param>
        /// <param name="docid"></param>
        /// <param name="deptid"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
//        public string GetScheInfo(string bdate,string edate,string docid,string deptid, ref string msg)
//        {
//            string value = string.Empty;
//            try
//            {
//                string post = @"<PAYMENT>
//                                  <HEAD>
//                                    <ResponseCode></ResponseCode>
//                                    <ResponseMsg></ResponseMsg>
//                                    <Date></Date>
//                                    <tsCliePw>-1</tsCliePw>
//                                  </HEAD>
//                                  <DATA>
//                                    <tsQuerDate1></tsQuerDate1>
//                                    <tsQuerDate2></tsQuerDate2>
//                                    <DepId></DepId>
//                                    <tsIsNumber></tsIsNumber>
//                                    <tsInMemo></tsInMemo>
//                                  </DATA>
//                               </PAYMENT>";
//                value = Ts_Order.GetScheInfo(post);
//            }
//            catch (Exception ea)
//            {
//                msg += "获取平台的医生排班出错!原因:" + ea.ToString();
//            }
//            return value;
//        }

        /// <summary>
        /// 撤销预约
        /// </summary>
        /// <param name="post">入参xml</param>
        /// <param name="msg">执行后返回的信息</param>
        /// <returns></returns>
        public bool CancelOrder(string ptid,string qhpwd,string czyh, ref string msg)
        {
            bool cancel_value = false;
            try
            {
                string post = @"<PAYMENT>
                                  <HEAD>
                                    <ResponseCode></ResponseCode>
                                    <ResponseMsg></ResponseMsg>
                                    <Date></Date>
                                    <tsCliePw>" + czyh + @"</tsCliePw>
                                  </HEAD>
                                  <DATA>
                                    <tsReseID>" + ptid + @"</tsReseID>
                                    <tsResePw>" + qhpwd + @"</tsResePw>
                                    <tsInMemo></tsInMemo>
                                  </DATA>
                                </PAYMENT>";
                string value = Ts_Order.GetRevoSubm(post);
                cancel_value = Analy.GetRevoSubmResult(value, ref msg);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return cancel_value;
        }

        /// <summary>
        /// 释放预约资源
        /// </summary>
        /// <param name="_cfg3059"></param>
        /// <param name="_DataBase"></param>
        public static void UpdateYyResource(SystemCfg _cfg3059, RelationalDatabase _DataBase)
        {
            /*释放指定时间段内还未取号的预约资源,如当前时间为8点 8点半的号还未进行取号 如果参数设置为
             半个小时未取号就释放,则释放八点半的号源*/
            string sql = @"  SELECT convert(varchar(10),getdate(),120),
            convert(varchar(16),DATEADD(MINUTE,(SELECT CAST(CONFIG AS INT)
            FROM JC_CONFIG WHERE ID=1127),GETDATE()),120),
            SUBSTRING(convert(varchar(16),getdate(),120),11,16) ";
            DataTable dt_Date = _DataBase.GetDataTable(sql);
            string Date_Now = dt_Date.Rows[0][0].ToString();
            string Time_Now = dt_Date.Rows[0][1].ToString();
            string HourMinute = dt_Date.Rows[0][2].ToString();
            sql = @"SELECT *,substring(YYSD,1,5) AS KSSJ ,substring(YYSD,7,5) as JSSJ FROM MZ_YYGHLB 
            WHERE CONVERT(VARCHAR(10),YYRQ,120)='" + Date_Now + @"' AND substring('" + Time_Now + @"',12,len('" + Time_Now + @"')) >=
            substring(YYSD,7,5) AND BQHBZ=0 AND BSCBZ=0";
            //获取需要释放资源的预约记录
            DataTable dt_YYxx = _DataBase.GetDataTable(sql);
            Order_Web _orderMeans = new Order_Web(_cfg3059);
            for (int i = 0; i < dt_YYxx.Rows.Count; i++)
            {
                /*作废预约信息,但是要根据时间判断是否释放分时段信息,如果预约的分时段
                  结束时间小于当前时间则不需要释放
                 */
                try
                {
                    string ptid = Convertor.IsNull(dt_YYxx.Rows[i]["PTID"], "");
                    string qhyzm = dt_YYxx.Rows[i]["YZM"].ToString();
                    string czyh = dt_YYxx.Rows[i]["DJY"].ToString();
                    string msg = "";
                    _orderMeans.CancelOrder(ptid, qhyzm, czyh, ref msg);
                    //撤销预约后,需要对分时段资源进行处理
                    //获取资源id
                    int ghks = Convert.ToInt32(dt_YYxx.Rows[i]["GHKS"]);
                    int ghjb = Convert.ToInt32(dt_YYxx.Rows[i]["GHJB"]);
                    int ghys = Convert.ToInt32(dt_YYxx.Rows[i]["GHYS"]);
                    string yydate = dt_YYxx.Rows[i]["YYRQ"].ToString();
                    VisitResource _Resource = new VisitResource(ghks, ghjb, ghys, yydate, _DataBase);
                    if (_Resource.Resid <= 0) return;

                    string kssj = dt_YYxx.Rows[i]["KSSJ"].ToString().Trim();
                    string jssj = dt_YYxx.Rows[i]["JSSJ"].ToString().Trim();
                    FsdClass.UpdateFsdStatus(_Resource.Resid, kssj, jssj, yydate, _DataBase);
                }
                catch (Exception ea)
                {
                    throw ea;
                }
            }

        }

    }
}

