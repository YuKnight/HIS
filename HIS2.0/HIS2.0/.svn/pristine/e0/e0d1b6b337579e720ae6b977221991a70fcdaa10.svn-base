using System;
using System.Data;
using System.Collections.Generic;
using TrasenHIS.DAL;
using System.Text;
using System.Xml;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
namespace TrasenHIS.BLL
{
    public class trasen_HIS
    {
        private static string logpath = "";
        public static string LogPath
        {
            get
            {
                return logpath;
            }
            set
            {
                logpath = value;
            }
        }

        /// <summary>
        /// 向新HIS办理入院
        /// </summary>
        /// <returns></returns>
        public static string SaveInpatient(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 <message>  <zyh>1077600</zyh>  <patientid>200106280566</patientid>  <xm>晏友桂</xm>  <xb>男 </xb>  <csrq>19501201</csrq>  <jg></jg>  <mz></mz>  <hk></hk>  <zycs>1</zycs>  <zy></zy>  <csd></csd>  <blh></blh>  <gj>中国</gj>  <zjlx>1</zjlx>  <sfzh></sfzh>  <dwmc></dwmc>  <dwdz></dwdz>  <dwdh></dwdh>  <dwyzbm></dwyzbm>  <jtdz></jtdz>  <jtdh></jtdh>  <jtyzbm></jtyzbm>  <lxr></lxr>  <gx></gx>  <lxrdz></lxrdz>  <lxrdh></lxrdh>  <gfdwbm>00-010</gfdwbm>  <ylzh>00-010-1-0026</ylzh>  <gflbmc>在职保健</gflbmc>  <deptid>000191</deptid><szbq>泰康楼-16F</szbq><inhostime>2014-03-12 10:46:05.0</inhostime><outhostime></outhostime><ryzd></ryzd><bedno>40</bedno><zrys>002872</zrys> </message>
                */
                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveInpatient】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = patient.SaveInpatient(dset, db);
                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveInpatient", str);
                return outxml;
            }

            return outxml;
        }
        /// <summary>
        /// 向新HIS办理预交款
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string SaveDeposits(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 <message>  <klx>0102</klx>  <kh>622202*********4287</kh>  <zyh>1077600</zyh>  <patientid></patientid>  <xm>晏友桂</xm>  <yjjlx>银行卡</yjjlx>  <yjj>800.00</yjj>  <djybm>    002107</djybm>      <JYLSH>7744455</JYLSH>      <DJSJ>2014-04-21 16:56:52</DJSJ>      <yhjylsh>011164</yhjylsh>      <yhkh>622202*********4287</yhkh>      <bz></bz></message>
                */
                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveDeposits】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = patient.SaveDeposits(dset, db);
                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.ToString(), "", "" };
                outxml = HisFunctions.GetResponseString("SaveDeposits", str);
                return outxml;
            }
            return outxml;
        }
        /// <summary>
        /// 向老HIS保存医嘱
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string SaveOrder(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 <message>  <klx>0102</klx>  <kh>622202*********4287</kh>  <zyh>1077600</zyh>  <patientid></patientid>  <xm>晏友桂</xm>  <yjjlx>银行卡</yjjlx>  <yjj>800.00</yjj>  <djybm>    002107</djybm>      <JYLSH>7744455</JYLSH>      <DJSJ>2014-04-21 16:56:52</DJSJ>      <yhjylsh>011164</yhjylsh>      <yhkh>622202*********4287</yhkh>      <bz></bz></message>
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveOrder】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //RelationalDatabase db_old = BaseDal.GetDb_InFormix();

                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);

                outxml = orders.SaveOrder(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveOrder", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 向老系统保存中草药处方
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string SaveZCYCF(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 <message>  <klx>0102</klx>  <kh>622202*********4287</kh>  <zyh>1077600</zyh>  <patientid></patientid>  <xm>晏友桂</xm>  <yjjlx>银行卡</yjjlx>  <yjj>800.00</yjj>  <djybm>    002107</djybm>      <JYLSH>7744455</JYLSH>      <DJSJ>2014-04-21 16:56:52</DJSJ>      <yhjylsh>011164</yhjylsh>      <yhkh>622202*********4287</yhkh>      <bz></bz></message>
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveZCYCF】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //RelationalDatabase db_old = BaseDal.GetDb_InFormix();

                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);

                outxml = orders.SaveZCYCF(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveOrder", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 同步和更新库存 到老HIS
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string SaveKcph(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 <message>  <klx>0102</klx>  <kh>622202*********4287</kh>  <zyh>1077600</zyh>  <patientid></patientid>  <xm>晏友桂</xm>  <yjjlx>银行卡</yjjlx>  <yjj>800.00</yjj>  <djybm>    002107</djybm>      <JYLSH>7744455</JYLSH>      <DJSJ>2014-04-21 16:56:52</DJSJ>      <yhjylsh>011164</yhjylsh>      <yhkh>622202*********4287</yhkh>      <bz></bz></message>
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveKcph】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = drug.SaveKcph(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveKcph", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 病人出区或出院
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string SaveCyzt(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveCyzt】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = patient.SaveCyzt(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveCyzt", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 病人出区
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string InpatientOut(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:InpatientOut】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);

                //保存病人信息
                outxml = patient.InpatientOut(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("InpatientOut", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 取消病人出院
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string CancelCy(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:CancelCy】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);

                //因为传过来的event=PatDischarge_C时jszt可能不等于4，强制转换 Modify By Tany 2014-05-07
                dset.Tables["message"].Rows[0]["jszt"] = 4;

                //保存病人信息
                outxml = patient.SaveCyzt(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveCyzt", str);
                return outxml;
            }
            return outxml;
        }

        public static string SaveFee(string PostString)
        {
            string outxml = "";
            try
            {
                #region 临时用,从老HIS的表直接生成XML

                //                RelationalDatabase olddb = BaseDal.GetDb_InFormix();
                //                string ssql = @"SELECT first 1
                //                    zyh,bz,je,xmbm,lb,yy,'2014-04-28 00:21:00' rq,lxks,djm,'' djh,zffs,qqje,jyje,sfjs,dyfl,'' pzr,zjzh,czy,sl,dh,'' xmpzr,sfyp,'SJH' sjh,'GG' czgg,'DW' dw,0 dj,11 id,1 czlx,
                //                    '2014-04-28 00:00:00' djsj
                //                      FROM  informix.yw_zyfymx";

                //                DataTable tbmx = olddb.GetDataTable(ssql);
                //                tbmx.TableName = "message";
                //                string ssss= ConvertToXML.DataTableToXml_informaxTonewHis(tbmx);
                //                PostString = ssss;
                #endregion
                /*
                 范例XML
                 <DocumentElement><message><zyh>001         </zyh><bz>r</bz><je>400.0000</je><xmbm>预收现金    </xmbm><lb>预收现金</lb><yy>住院中期付款</yy><rq>1999-07-03 00:08:00</rq><lxks>000031</lxks><djm>现金</djm><zffs>现金</zffs><qqje>0.0000</qqje><jyje>400.0000</jyje><sfjs>N</sfjs><dyfl>预收现金            </dyfl><zjzh>490414</zjzh><czy>000000</czy><sl>1.0000</sl><dh>1           </dh><sfyp>N</sfyp><id>11</id><czlx>1</czlx><djsj>2014-04-28 00:00:00</djsj></message></DocumentElement>
                */
                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveFee】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = zy_fee.SaveFee(dset, db);
                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveFee", str);
                return outxml;
            }
            return outxml;
        }

        public static string SaveFyzt(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveFyzt】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = drug.SaveFyzt(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveFyzt", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 分配床位
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string AssignBed(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:AssignBed】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = patient.AssignBed(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("AssignBed", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 转床
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string ChangeBed(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:AssignBed】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = patient.ChangeBed(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("ChangeBed", str);
                return outxml;
            }
            return outxml;
        }

        public static string TransDept(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:AssignBed】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = patient.TransDept(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("TransDept", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 向老HIS停止医嘱
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string StopOrder(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 <message>  <klx>0102</klx>  <kh>622202*********4287</kh>  <zyh>1077600</zyh>  <patientid></patientid>  <xm>晏友桂</xm>  <yjjlx>银行卡</yjjlx>  <yjj>800.00</yjj>  <djybm>    002107</djybm>      <JYLSH>7744455</JYLSH>      <DJSJ>2014-04-21 16:56:52</DJSJ>      <yhjylsh>011164</yhjylsh>      <yhkh>622202*********4287</yhkh>      <bz></bz></message>
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveOrder】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //RelationalDatabase db_old = BaseDal.GetDb_InFormix();

                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                //string ssql = "select b.inpatient_no,a.* from zy_orderrecord a inner join vi_zy_vinpatient_all b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id where a.order_id='" + PostString + "'";
                //DataTable tb = db.GetDataTable(ssql);

                //DataSet dset = new DataSet();
                //dset.Tables.Add(tb);
                outxml = orders.StopOrder(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("StopOrder", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 取消医嘱
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string CancelOrder(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 <message>  <klx>0102</klx>  <kh>622202*********4287</kh>  <zyh>1077600</zyh>  <patientid></patientid>  <xm>晏友桂</xm>  <yjjlx>银行卡</yjjlx>  <yjj>800.00</yjj>  <djybm>    002107</djybm>      <JYLSH>7744455</JYLSH>      <DJSJ>2014-04-21 16:56:52</DJSJ>      <yhjylsh>011164</yhjylsh>      <yhkh>622202*********4287</yhkh>      <bz></bz></message>
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:CancelOrder】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //RelationalDatabase db_old = BaseDal.GetDb_InFormix();

                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                //string ssql = "select b.inpatient_no,a.* from zy_orderrecord a inner join vi_zy_vinpatient_all b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id where a.order_id='" + PostString + "'";
                //DataTable tb = db.GetDataTable(ssql);

                //DataSet dset = new DataSet();
                //dset.Tables.Add(tb);
                outxml = orders.CancelOrder(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("CancelOrder", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 门诊收费及处方导入
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string SaveMzcf(string PostString)
        {
            string outxml = "";
            try
            {

                /*
                 范例XML
                    <message msgType="response" msgId="String" timestampCreated="2014-5-7 16:10:12" version="String"><response><code>0</code><description>成功</description></response><body bodyId="1"><inhospPatient><birthday>1981-1-5 00:00:00.00000</birthday><kind>自费</kind><native></native><paper><paperNo>420113197901071517</paperNo><paperType>1</paperType></paper><patientId>200109100702</patientId><patientName>鲁卫刚</patientName><sex>男 </sex></inhospPatient><examReqInfoType><crtDateTime>2014-5-7 16:11:27.00000</crtDateTime><examReqId>209200000019</examReqId><id>200109100702</id><item><itemId>1254</itemId><itemName>阿托品片</itemName><type>P</type><quantity>1</quantity><gg>(0.3mg)</gg><dw>片</dw><ypjl>0.300mg</ypjl><bzjl>0.300mg</bzjl><pc></pc><gyfs>po</gyfs><jxfl>片剂</jxfl><index>02220000002161-1</index><requested>011405071557310000000000000000000001</requested><doctorid>000222</doctorid><doctorname>何春枝</doctorname><deptid>000009</deptid><deptname>内科普通门诊</deptname><zd>1</zd></item><item><itemId>3497</itemId><itemName>戊酸雌二醇片</itemName><type>P</type><quantity>1</quantity><gg>(1mg)/片*21</gg><dw>盒</dw><ypjl>1.000mg</ypjl><bzjl>1.000mg</bzjl><pc></pc><gyfs>po</gyfs><jxfl>片剂</jxfl><index>02220000002163-3</index><requested>011405071610130000000000000000000001</requested><doctorid>000222</doctorid><doctorname>何春枝</doctorname><deptid>000009</deptid><deptname>内科普通门诊</deptname><zd>1</zd></item></examReqInfoType></body></message>
                */
                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveMzcf】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = mzpatient.SaveMzcf(dset, db);
                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveMzcf", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 门诊退费
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string SaveMztf(string PostString)
        {
            string outxml = "";
            try
            {

                /*
                 范例XML
                 <message msgType="response" msgId="String" timestampCreated="2014-5-7 16:13:39" version="String"><response><code>0</code><description>成功</description></response><body bodyId="1"><inhospPatient><birthday>1981-1-5 00:00:00.00000</birthday><kind>自费</kind><native></native><paper><paperNo>420113197901071517</paperNo><paperType>1</paperType></paper><patientId>200109100702</patientId><patientName>鲁卫刚</patientName><sex>男 </sex></inhospPatient><examReqInfoType><crtDateTime>2014-5-7 16:15:25.00000</crtDateTime><examReqId>209200000019</examReqId><id>200109100702</id></examReqInfoType></body></message>
                */
                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveMztf】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = mzpatient.SaveMztf(dset, db);
                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveMztf", str);
                return outxml;
            }
            return outxml;
        }


        public static string SaveMzFyzt(string PostString)
        {
            string outxml = "";
            try
            {

                /*
                 范例XML
                 <message msgType="response" msgId="String" timestampCreated="2014-5-7 16:13:39" version="String"><response><code>0</code><description>成功</description></response><body bodyId="1"><inhospPatient><birthday>1981-1-5 00:00:00.00000</birthday><kind>自费</kind><native></native><paper><paperNo>420113197901071517</paperNo><paperType>1</paperType></paper><patientId>200109100702</patientId><patientName>鲁卫刚</patientName><sex>男 </sex></inhospPatient><examReqInfoType><crtDateTime>2014-5-7 16:15:25.00000</crtDateTime><examReqId>209200000019</examReqId><id>200109100702</id></examReqInfoType></body></message>
                */
                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveMzFyzt】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = drug.SaveMzFyzt(dset, db);
                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveMzFyzt", str);
                return outxml;
            }
            return outxml;
        }

        public static string SaveMzQxFyzt(string PostString)
        {
            string outxml = "";
            try
            {

                /*
                 范例XML
                 <message msgType="response" msgId="String" timestampCreated="2014-5-7 16:13:39" version="String"><response><code>0</code><description>成功</description></response><body bodyId="1"><inhospPatient><birthday>1981-1-5 00:00:00.00000</birthday><kind>自费</kind><native></native><paper><paperNo>420113197901071517</paperNo><paperType>1</paperType></paper><patientId>200109100702</patientId><patientName>鲁卫刚</patientName><sex>男 </sex></inhospPatient><examReqInfoType><crtDateTime>2014-5-7 16:15:25.00000</crtDateTime><examReqId>209200000019</examReqId><id>200109100702</id></examReqInfoType></body></message>
                */
                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveMzQxFyzt】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = drug.SaveMzQxFyzt(dset, db);
                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveMzQxFyzt", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 更改管床医生
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string ChangeGCYS(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                 
                */

                //写Request日志
                Logger.Instance().WriteLog("【Request:AssignBed】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);
                //保存病人信息
                outxml = patient.ChangeGCYS(dset, db);

                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("ChangeGCYS", str);
                return outxml;
            }
            return outxml;
        }

        /// <summary>
        /// 执行WEB服务
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string ExeWebService(string PostType, string PostString, string MapPath)
        {
            StringBuilder sb = new StringBuilder();
            string returnString = "";


            switch (PostType)
            {
                case "SaveInpatient":
                    returnString = SaveInpatient(PostString);
                    break;
                case "SaveDeposits":
                    returnString = SaveDeposits(PostString);
                    break;
                case "SaveOrder":
                    returnString = SaveOrder(PostString);
                    break;
                case "SaveZCYCF":
                    returnString = SaveZCYCF(PostString);
                    break;
                case "SaveKcph":
                    returnString = SaveKcph(PostString);
                    break;
                case "SaveCyzt":
                    returnString = SaveCyzt(PostString);
                    break;
                case "SaveFee":
                    returnString = SaveFee(PostString);
                    break;
                case "SaveFyzt":
                    returnString = SaveFyzt(PostString);
                    break;
                case "SaveYBJS":
                    break;
                case "SaveZYJS":
                    break;
                case "AssignBed":
                    returnString = AssignBed(PostString);
                    break;
                case "ChangeBed":
                    returnString = ChangeBed(PostString);
                    break;
                case "TransDept":
                    returnString = TransDept(PostString);
                    break;
                case "SaveZYSS":
                    returnString = SaveOperationApplye(PostString);
                    break;
                case "StopOrder":
                    returnString = StopOrder(PostString);
                    break;
                case "CancelOrder":
                    returnString = CancelOrder(PostString);
                    break;
                case "ChangeGCYS":
                    returnString = ChangeGCYS(PostString);
                    break;
                case "CancelCy":
                    returnString = CancelCy(PostString);
                    break;
                case "SaveMzcf":
                    returnString = SaveMzcf(PostString);
                    break;
                case "SaveMztf":
                    returnString = SaveMztf(PostString);
                    break;
                case "SaveMzFyzt":
                    returnString = SaveMzFyzt(PostString);
                    break;
                case "SaveMzQxFyzt":
                    returnString = SaveMzQxFyzt(PostString);
                    break;
                case "InpatientOut":
                    returnString = InpatientOut(PostString);
                    break;
                default:
                    returnString = "执行XML时未找到对应的PostType";
                    break;
            }
            return returnString;
        }

        public static string GetXml(string PostType, string id)
        {
            if (PostType.Trim() == "" || id.Trim() == "")
            {
                throw new Exception("PostType或PostString不能为空值！");
            }

            StringBuilder sb = new StringBuilder();
            string returnString = "";
            string ssql = "";
            DataTable tb = new DataTable();
            //声明数据连接
            RelationalDatabase db = BaseDal.GetDb();
            DataSet dset = new DataSet();
            switch (PostType)
            {
                case "FYZT":
                    #region  更新老HIS住院发药状态的XML FYZT
                    ssql = "select top 1 a.id as BIZID,a.FY_DATE,a.FY_USER,a.PY_USER,b.ZYH,B.YZXH,B.YZZXH,A.NUM from zy_fee_speci a inner join whzxyy_yw_zyfymx b ON a.id=b.fymxid where a.id='" + id + "'";
                    tb = db.GetDataTable(ssql);
                    tb.TableName = "FYZT";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = ConvertToXML.DataTableToXml(tb);
                    }
                    else
                    {
                        returnString = "没有记录";
                    }
                    break;
                    #endregion
                case "MZFYZT":
                    #region  更新老HIS门诊发药状态的XML MZFYZT
                    ssql = "SELECT top 1 a.id as BIZID,dh,FYRQ as FY_DATE ,FYR as FY_USER,pyr as PY_USER,ZJE  FROM YF_FY a inner join whzxyy_mz_cfb_zb b on a.CFXH=b.cfid and a.CFXH='" + id + "'";
                    tb = db.GetDataTable(ssql);
                    tb.TableName = "MZFYZT";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = ConvertToXML.DataTableToXml(tb);
                    }
                    else
                    {
                        returnString = "没有记录";
                    }
                    break;
                case "MZFYZTTY":
                    #region  更新老HIS门诊发药状态的XML MZFYZT
                    ssql = "SELECT top 1 a.id as BIZID,dh,FYRQ as FY_DATE ,FYR as FY_USER,pyr as PY_USER,ZJE  FROM YF_FY a inner join whzxyy_mz_cfb_zb b on a.CFXH=b.cfid and TFBZ=1 and a.CFXH='" + id + "'";
                    tb = db.GetDataTable(ssql);
                    tb.TableName = "MZFYZTTY";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = ConvertToXML.DataTableToXml(tb);
                    }
                    else
                    {
                        returnString = "没有记录";
                    }
                    break;
                    #endregion
                    #endregion
                case "MZQXFYZT":
                    #region  更新老HIS门诊发药状态的XML MZQXFYZT  取消退药
                    ssql = "SELECT '" + id + "' as  BIZID,dh  FROM whzxyy_mz_cfb_zb  WHERE CFID='" + id + "'";
                    tb = db.GetDataTable(ssql);
                    tb.TableName = "MZQXFYZT";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = ConvertToXML.DataTableToXml(tb);
                    }
                    else
                    {
                        returnString = "没有记录";
                    }
                    break;
                    #endregion
                case "KCBH":
                    #region kcbh
                    ssql = @"select  a.ID,DEPTID,a.DJSJ,a.CJID,S_YPPM,S_YPGG,SCCJ,dbo.fun_yp_ypdw(zxdw) S_ZXDW,round(mrjj/dwbl,3) GRDJ, round(pfj/dwbl,3) PFJ,round(LSJ/dwbl,3) LSJ,YPXQ,KCL from YF_KCPH a inner join YP_YPCJD b on a.CJID=b.CJID  inner join EVENTLOG c on a.ID=c.BIZID and FINISH=0 and a.deptid in(select deptid from YP_YJKS where KSLX='药房') ";
                    if (id != "")
                        ssql = ssql + " and bizid='" + id + "'";

                    tb = db.GetDataTable(ssql);

                    //RelationalDatabase olddb = BaseDal.GetDb_InFormix();
                    //ssql = "select first 10 * from yw_zyfymx ";
                    //tb = olddb.GetDataTable(ssql);
                    //string ss = BaseDal.GetEncodingString(tb.Rows[4]["yy"].ToString());

                    tb.TableName = "YF_KCPH";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = ConvertToXML.DataTableToXml(tb);
                    }
                    else
                    {
                        returnString = "没有记录";
                    }
                    returnString.Replace("<DocumentElement>", "");
                    returnString.Replace("</DocumentElement>", "");
                    break;
                    #endregion
                case "NewCheckOrder.ECG":
                case "CancelNewCheckOrder.ECG":
                    #region NewCheckOrder.ECG
                    ssql = @"select c.INPATIENT_BANO PATIENT_ID,'' OUT_PATIENT_NO,convert(bigint,c.INPATIENT_NO) IN_PATIENT_NO,'' CASENO,
                            '住院' PATIENT_SOURCE,c.NAME,case c.SEXCODE when 1 then 'F' when 2 then 'M' else '' end SEX,
                            convert(varchar,c.BIRTHDAY,120) BIRTHDAY,c.AGE AGE,'岁' AGE_UNIT,c.HOME_STREET ADDRESS,c.HOME_TEL PHONE_NUMBER,
                            c.BED_NO BED_NO,c.WARD_NAME BINGQU,c.WARD_ID BINGQU_CODE,a.JC_NO NOTE_NO,
                            convert(varchar,b.DEPT_ID) CDEPT_CODE,dbo.fun_getDeptname(b.DEPT_ID) CDEPT_NAME,
                            convert(varchar,b.EXEC_DEPT) EXE_DEPT_CODE,dbo.fun_getDeptname(b.EXEC_DEPT) EXE_DEPT_NAME,
                            convert(varchar,b.ORDER_DOC) DOCT_CODE,dbo.fun_getEmpname(b.ORDER_DOC) DOCT_NAME,
                            '' OPER_CODE,convert(varchar,b.ORDER_BDATE,120) OPER_DTIME,'ECG' STUDY_CLASS,b.ORDER_CONTEXT STUDY_ITEM,
                            convert(varchar,b.HOITEM_ID) ITEM_CODE,'' CHARGE_TYPE,'' FACT_PRICE,a.IN_DIAGNOSIS DIAG_NAME,
                            case when a.delete_bit=0 then '' else 'CA' end WORK_STATUS,'MEDEX_ECG_REQ' targetLogicService
                            from ZY_JC_RECORD a 
                            inner join ZY_ORDERRECORD b on a.INPATIENT_ID=b.INPATIENT_ID and a.GROUP_ID=b.GROUP_ID and a.HOITEM_ID=b.HOITEM_ID
                            inner join VI_ZY_VINPATIENT_ALL c on b.INPATIENT_ID=c.INPATIENT_ID and b.BABY_ID=c.BABY_ID
                            where a.id='" + id + "'";

                    tb = db.GetDataTable(ssql);

                    //数据转换成老HIS
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        tb.Rows[i]["FACT_PRICE"] = HisFunctions.GetNewHISPrice("2", tb.Rows[i]["ITEM_CODE"].ToString(), db);

                        tb.Rows[i]["CDEPT_CODE"] = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, tb.Rows[i]["CDEPT_CODE"].ToString(), db);
                        tb.Rows[i]["EXE_DEPT_CODE"] = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, tb.Rows[i]["EXE_DEPT_CODE"].ToString(), db);
                        tb.Rows[i]["DOCT_CODE"] = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, tb.Rows[i]["DOCT_CODE"].ToString(), db);
                        tb.Rows[i]["ITEM_CODE"] = HisFunctions.GetOldHISXmYpBM("2", tb.Rows[i]["ITEM_CODE"].ToString(), db);
                    }

                    tb.TableName = "ROW";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = ConvertToXML.DataTableToXmlEx(tb, "ROW");

                        returnString = "<DATA>" + returnString + "</DATA>";
                    }
                    else
                    {
                        returnString = "没有记录";
                    }
                    //returnString.Replace("DocumentElement", "DATA");
                    //returnString.Replace("</DocumentElement>", "</DATA>");

                    break;
                    #endregion
                case "NewOrder.EMR":
                    #region NewOrder.EMR
                    ssql = @"select REPLACE(a.ORDER_ID,'-','') ADVICEID,case a.SERIAL_NO when 0 then 0 else 1 end ISASSEMBLE,
                            case a.SERIAL_NO when 0 then REPLACE(a.ORDER_ID,'-','') else (select REPLACE(ORDER_ID,'-','') from ZY_ORDERRECORD c where c.INPATIENT_ID=a.inpatient_id and c.baby_id=a.BABY_ID and c.GROUP_ID=a.GROUP_ID and c.SERIAL_NO=0) end ASSEMBLENUM,
                            b.INPATIENT_BANO MRID,CONVERT(varchar,a.ntype) ADVICETYPE,CONVERT(varchar,a.HOITEM_ID) ADVICECODE,
                            a.ORDER_CONTEXT ADVICECONTENT,a.FREQUENCY ADVICEFREQNUM,a.UNIT DOSAGEUNIT,
                            a.NUM DOSAGE,a.ORDER_USAGE PATHWAY,CONVERT(varchar,a.ORDER_BDATE,120) STARTTIME,
                            '' STOPTIME,case a.mngtype when 0 then 1 else 0 end LONGFLAG,0 STATUS,
                            convert(varchar,a.DEPT_BR) AREA,CONVERT(varchar,a.ORDER_DOC) WRITER,'' BEGINER,
                            CONVERT(varchar,a.BOOK_DATE,120) WRITETIME,'' BEGINTIME,'' MEMO,a.ORDER_SPEC SPEC,'' CHARGE,a.xmly
                            from ZY_ORDERRECORD a inner join VI_ZY_VINPATIENT_ALL b on a.INPATIENT_ID=b.INPATIENT_ID and a.BABY_ID=b.BABY_ID
                            where a.order_id='" + id + "'";

                    tb = db.GetDataTable(ssql);

                    //数据转换成老HIS
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        tb.Rows[i]["CHARGE"] = HisFunctions.GetNewHISPrice(tb.Rows[i]["xmly"].ToString(), tb.Rows[i]["ADVICECODE"].ToString(), db);
                        tb.Rows[i]["ADVICETYPE"] = HisFunctions.GetOldHISYzlb(tb.Rows[i]["ADVICETYPE"].ToString(), tb.Rows[i]["ADVICECONTENT"].ToString());

                        tb.Rows[i]["AREA"] = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, tb.Rows[i]["AREA"].ToString(), db);
                        tb.Rows[i]["WRITER"] = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, tb.Rows[i]["WRITER"].ToString(), db);

                        tb.Rows[i]["ADVICECODE"] = HisFunctions.GetOldHISXmYpBM(tb.Rows[i]["xmly"].ToString(), tb.Rows[i]["ADVICECODE"].ToString(), db);
                    }

                    tb.TableName = "CISAdvice";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = ConvertToXML.DataTableToXmlEx(tb, "CISAdvice");

                        returnString = "<message msgType=\"call\" msgId=\"1\" timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" version=\"1\">" +
                            "<call timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" crfCallMode=\"alwaysRespond\">" +
                            "<targetLogicService>CIS_INSERT_INADVICE_INFO</targetLogicService> " +
                            "<targetLogicApp>HIS</targetLogicApp>" +
                            "</call>" +
                            "<body bodyId=\"1\">" +
                            returnString +
                            "</body></message>";
                    }
                    else
                    {
                        returnString = "没有记录";
                    }

                    break;
                    #endregion
                case "CancelNewOrder.EMR":
                    #region CancelNewOrder.EMR
                    returnString = "<message msgType=\"call\" msgId=\"1\" timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" version=\"1\">" +
                            "<call timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" crfCallMode=\"alwaysRespond\">" +
                            "<targetLogicService>CIS_DELETE_INADVICE_INFO</targetLogicService> " +
                            "<targetLogicApp>HIS</targetLogicApp>" +
                            "</call>" +
                            "<body bodyId=\"1\">" +
                            "<advice>" +
                            "<adviceId>" + id.Replace("-", "") + "</adviceId>" +
                            "</advice>" +
                            "</body></message>";

                    break;
                    #endregion
                case "StopOrder.EMR":
                    #region StopOrder.EMR
                    ssql = @"select *,
                            convert(varchar,order_edoc) employeeId,dbo.fun_getempname(order_edoc) employeeName
                            from ZY_ORDERRECORD
                            where order_id='" + id + "'";

                    tb = db.GetDataTable(ssql);

                    //数据转换成老HIS
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        tb.Rows[i]["employeeId"] = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, tb.Rows[i]["employeeId"].ToString(), db);
                    }

                    tb.TableName = "advice";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = "<message msgType=\"call\" msgId=\"1\" timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" version=\"1\">" +
                            "<call timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" crfCallMode=\"alwaysRespond\">" +
                            "<targetLogicService>CIS_STOP_INADVICE_INFO</targetLogicService> " +
                            "<targetLogicApp>HIS</targetLogicApp>" +
                            "</call>" +
                            "<body bodyId=\"1\">" +
                            "<advice>" +
                            "<adviceId>" + id.Replace("-", "") + "</adviceId>" +
                            "<stopDoctor>" +
                            "<employeeId>" + tb.Rows[0]["employeeId"].ToString() + "</employeeId>" +
                            "<employeeName>" + tb.Rows[0]["employeeName"].ToString() + "</employeeName>" +
                            "</stopDoctor>" +
                            "</advice>" +
                            "</body></message>";
                    }
                    else
                    {
                        returnString = "没有记录";
                    }

                    break;
                    #endregion
                case "UNStopOrder.EMR":
                    #region UNStopOrder.EMR
                    returnString = "<message msgType=\"call\" msgId=\"1\" timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" version=\"1\">" +
                            "<call timestampCreated=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" crfCallMode=\"alwaysRespond\">" +
                            "<targetLogicService>CIS_UNSTOP_INADVICE_INFO</targetLogicService> " +
                            "<targetLogicApp>HIS</targetLogicApp>" +
                            "</call>" +
                            "<body bodyId=\"1\">" +
                            "<advice>" +
                            "<adviceId>" + id.Replace("-", "") + "</adviceId>" +
                            "</advice>" +
                            "</body></message>";
                    break;
                    #endregion
                case "NewOrder.HIS":
                case "StopOrder.HIS":
                case "CancelNewOrder.HIS":
                    #region NewOrder.HIS
                    ssql = @"select b.inpatient_no,a.* from zy_orderrecord a inner join vi_zy_vinpatient_all b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id where a.order_id='" + id + "'";

                    tb = db.GetDataTable(ssql);

                    tb.TableName = "zy_orderrecord";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = ConvertToXML.DataTableToXmlEx(tb, "zy_orderrecord");

                        //returnString = @"<message msgType=call msgId=1 timestampCreated=" + DateTime.Now.ToLongDateString() + " version=1>" +
                        //    "<call timestampCreated=" + DateTime.Now.ToLongDateString() + " crfCallMode=alwaysRespond>" +
                        //    "<targetLogicService>CIS_INSERT_INADVICE_INFO</targetLogicService> " +
                        //    "<targetLogicApp>HIS</targetLogicApp>" +
                        //    "</call>" +
                        //    "<body bodyId=1>" +
                        //    returnString +
                        //    "</body></message>";
                    }
                    else
                    {
                        returnString = "没有记录";
                    }

                    break;
                    #endregion
                case "NewOrder.HIS.ZCY":
                    #region NewOrder.HIS.ZCY
                    string[] str = id.Split('|');
                    ssql = @"select b.inpatient_no,a.* from zy_orderrecord a inner join vi_zy_vinpatient_all b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id where a.inpatient_id='" + str[0] + "' and a.group_id=" + str[1] + " order by a.SERIAL_NO";

                    tb = db.GetDataTable(ssql);

                    tb.TableName = "ZCYCF";
                    if (tb.Rows.Count > 0)
                    {
                        returnString = ConvertToXML.DataTableToXmlEx(tb, "ZCYMX");
                    }
                    else
                    {
                        returnString = "没有记录";
                    }

                    returnString = "<" + tb.TableName + ">" + returnString + "</" + tb.TableName + ">";

                    break;
                    #endregion
                default:
                    returnString = "获取XML时未找到对应的PostType";
                    break;
            }

            db.Close();
            db.Dispose();

            return returnString;
        }

        /// <summary>
        /// 保存手术申请
        /// </summary>
        /// <param name="PostString"></param>
        /// <returns></returns>
        public static string SaveOperationApplye(string PostString)
        {
            string outxml = "";
            try
            {
                /*
                 范例XML
                */
                //写Request日志
                Logger.Instance().WriteLog("【Request:SaveOperationApplye】：" + PostString);
                //声明数据连接
                RelationalDatabase db = BaseDal.GetDb();
                //XML转DataSet
                DataSet dset = HisFunctions.ConvertXmlToDataSet(PostString);

                //对手术申请集合进行处理
                DataTable tbOperation = new DataTable();
                //住院号
                DataColumn col1 = new DataColumn("zyh");
                //病人所在科室
                DataColumn col2 = new DataColumn("dqks");
                //手术申请单号
                DataColumn col3 = new DataColumn("sssqdh");
                //手术时间
                DataColumn col4 = new DataColumn("sssj");
                //手术名称
                DataColumn col5 = new DataColumn("ssmc");
                //手术状态 N－新申请手术G－手术麻醉系统已提取M－手术信息变化C－手术取消－手术结束
                DataColumn col6 = new DataColumn("sszt");
                //手术申请时间
                DataColumn col7 = new DataColumn("sssqsj");
                //手术申请者
                DataColumn col8 = new DataColumn("sssqz");
                //麻醉方法
                DataColumn col9 = new DataColumn("mzfs");
                tbOperation.Columns.AddRange(new DataColumn[] { col1, col2, col3, col4, col5, col6, col7, col8, col9 });

                DataRow row = tbOperation.NewRow();
                row["zyh"] = dset.Tables["PatientInfo"].Rows[0]["patientId"];
                //科室
                row["dqks"] = dset.Tables["PatientInfo"].Rows[0]["DeptStayed"];
                row["sssqdh"] = dset.Tables["PatientInfo"].Rows[0]["ScheduleId"];
                row["sssj"] = DateTime.ParseExact(dset.Tables["Operation_info"].Rows[0]["ScheduledDateTime"].ToString(), "yyyyMMddHHmmss", null);
                row["ssmc"] = TrasenClasses.GeneralClasses.Convertor.IsNull(dset.Tables["Operation_Detail"].Rows[0]["Operation"].ToString(), "");
                row["sszt"] = dset.Tables["Operation_info"].Rows[0]["OperStatus"].ToString();
                row["sssqsj"] = DateTime.ParseExact(dset.Tables["Operation_info"].Rows[0]["ReqDateTime"].ToString(), "yyyyMMddHHmmss", null);
                row["sssqz"] = TrasenClasses.GeneralClasses.Convertor.IsNull(dset.Tables["Operation_info"].Rows[0]["EnteredBy"], "");
                row["mzfs"] = TrasenClasses.GeneralClasses.Convertor.IsNull(dset.Tables["Operation_info"].Rows[0]["AnesthesiaMethod"], "");
                tbOperation.Rows.Add(row);

                //保存手术申请信息
                outxml = orders.OperationApply(tbOperation, db);
                //释放数据连接
                db.Close();
                db.Dispose();
            }
            catch (System.Exception err)
            {
                //错误返回
                System.String[] str = { "-1", "Request:" + PostString + " 错误:" + err.Message, "", "" };
                outxml = HisFunctions.GetResponseString("SaveOperationApplye", str);
                return outxml;
            }
            return outxml;

        }

    }
}
