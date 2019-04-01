using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Data;
using ts_mzys_class;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SpeechLib;
using TrasenFrame.Classes;

namespace ts_mzys_class
{
    /// <summary>
    /// 服务端监听类 add by zp 2013-6-6
    /// </summary>
    public class ServerListen
    {
        public delegate string UpdateDisplayDelegate(object data, int zqid, RelationalDatabase db);

        private static object objLockHelper = new object();

        private static VoiceHelp _voice = new VoiceHelp();
        /// <summary>
        /// 语音朗诵对象
        /// </summary>
        public static SpeechLib.SpVoice speech = null;
        /// <summary>
        /// 呼叫次数
        /// </summary>
        public static int Hjcs;
        /// <summary>
        /// 已呼叫的病人列表
        /// </summary>
        private static List<ts_mzys_class.MZHS_FZJL> lstCalledPatient = new List<ts_mzys_class.MZHS_FZJL>(); //存储已呼叫的病人集合

        /// <summary>
        /// 刷新显示屏的委托
        /// </summary>
        /// <param name="displayData"></param>
        public delegate void RefreshScreenDisplayEventHandle(object displayData,object waitdata);

        /// <summary>
        /// 刷新显示屏的事件
        /// </summary>
        public static event RefreshScreenDisplayEventHandle refreshScreenDisplay; 

        /// <summary>
        /// 更新当前界面的显示 返回当前呼叫信息
        /// </summary>
        /// <param name="text"></param>
        public static string UpdateDisplay(object data, int zqid, RelationalDatabase _DataBase)
        {
            string values = "";
            try
            {
                //更新医生呼叫情况的显示DisplayAreaDoctorCallInfo();
                if (data !=null && data.GetType() == typeof(System.String))
                {
                    values = (data.ToString() + "\r\n");
                }
                if (data !=null && data.GetType() == typeof(ts_mzys_class.MZHS_FZJL))
                {
                    ts_mzys_class.MZHS_FZJL patient = (ts_mzys_class.MZHS_FZJL)data;
                    //设置呼叫列表
                    values = string.Format("{0}：请{1}号{2}到{3}{4}就诊", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        patient.Patdlxh, patient.patName, patient.patGHZKName, patient.roomName);
                    if(new  SystemCfg(3013).Config=="1")
                    {
                        values = string.Format("{0}：请{1}号{2}到{3}的{4}就诊", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                       patient.Pdxh, patient.patName, patient.patGHZKName, patient.roomName);
                    }
                }

                //重新获取未分诊的病人，并将列表送到显示屏
                if (refreshScreenDisplay != null)
                {
                    string rq1 = DateManager.ServerDateTimeByDBType(_DataBase).ToShortDateString() + " 00:00:00";
                    string rq2 = DateManager.ServerDateTimeByDBType(_DataBase).ToShortDateString() + " 23:59:59";
                    int klx = 0;
                    string kh = "";
                    string blh = "";

                    int sort = 0;
                    int hour = Convert.ToInt32(_DataBase.GetDataResult("select DATEPART(hh, GETDATE())"));
                   //从后台参数获取时间段进行判断 Modify By Zp 2014-02-11
         
                    //if (hour >= 8 && hour < 12)
                    //    sort = 1;
                    //else if (hour >= 12 && hour < 18)
                    //    sort = 2;
                    DataSet ds = MZHS_FZJL.Select_yfzpat(zqid, rq1, rq2, klx, kh, blh,sort, _DataBase); //包含两个内存表1个预约病人列表1个现场病人列表
                    List<MZHS_FZJL> _list=new List<MZHS_FZJL> ();
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        MZHS_FZJL fz_br=MZHS_FZJL.DataRowToFZjl(dr);
                        _list.Add(fz_br);
                    } 
                    refreshScreenDisplay(data,_list); //传给显示屏已分诊病人信息
                } 
            }
            catch (Exception ea)
            {
                throw new Exception("UpdateDisplay函数出现异常!原因:" + ea.Message);
            }
            return values;
        }


        /// <summary>
        /// 监听端口 有数据传输则刷新显示屏以及语音朗诵
        /// </summary>
        /// <param name="port">端口号</param>
        public void SocketListen(int port, RelationalDatabase _DataBase, Fz_Zq zq, 
            Socket listener,VoiceHelp _voice, ref Socket socket)
        {
           
            string rq1 = DateManager.ServerDateTimeByDBType(_DataBase).ToShortDateString() + " 00:00:00";
            string rq2 = DateManager.ServerDateTimeByDBType(_DataBase).ToShortDateString() + " 23:59:59";
            Hjcs = int.Parse(zq.Zqhjcs);
            string msg="";

            _voice.InitializeVoiceLib();
            _voice.VoiceSpeak(zq.Zqname,ref msg);
            IPEndPoint address = new IPEndPoint(IPAddress.Any, port);
            try
            {
                while (true)
                {
                    if (new SystemCfg(3103).Config == "1")
                    {
                        UpdateDisplayDelegate callDisplay = new UpdateDisplayDelegate(UpdateDisplay);
                        callDisplay("正在等待呼叫。。。", zq.Zqid, _DataBase);
                    }
                    if (listener != null)
                    {
                        if (listener.LocalEndPoint == null)
                        {

                            listener.Bind(address);
                        }
                    }
                   
                    listener.Listen(0);
                    socket = listener.Accept();
                    Stream netStream = new NetworkStream(socket);
                   
                    StreamReader reader = new StreamReader(netStream);
                    string result = reader.ReadToEnd();//收到呼叫的信息
                    lock (objLockHelper)
                    {
                        ts_mzys_class.MZHS_FZJL p = new ts_mzys_class.MZHS_FZJL();
                        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                        bool valid = false;
                        try
                        {
                            doc.LoadXml(result);
                            valid = true;
                        }
                        catch
                        {
                            UpdateDisplayDelegate _callDisplay = new UpdateDisplayDelegate(UpdateDisplay);
                            _callDisplay("无效的呼叫信息!", zq.Zqid, _DataBase);
                        }
                        if (valid)
                        {
                            System.Xml.XmlNodeList nodes = doc.GetElementsByTagName("PATIENT")[0].ChildNodes;
                            /*反射生成病人对象*/
                            foreach (System.Xml.XmlNode node in nodes)
                            {
                                try
                                {
                                    System.Reflection.PropertyInfo pi = p.GetType().GetProperty(node.Name);//定义一个属性对象,并且设置类型(需要反射目的对象的某个属性名称)
                                    object objValue = Convert.ChangeType(node.InnerText, pi.PropertyType);//通过一个object对象获取属性的值与属性的类型
                                    p.GetType().GetProperty(node.Name).SetValue(p, objValue, null);//对反射对象进行赋值,第一个参数为反射对象,第二参数为反射对象所需的值与类型信息
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                            lstCalledPatient.Insert(0, p);
                            //将当前呼叫的病人发送到显示窗口
                            if (refreshScreenDisplay != null)
                            {
                                int sort = 0;
                                int hour = Convert.ToInt32(_DataBase.GetDataResult("select DATEPART(hh, GETDATE())"));
                                if (hour >= 8 && hour <= 12)
                                    sort = 1;
                                else if (hour > 12 && hour < 18)
                                    sort = 2;

                                DataSet ds = MZHS_FZJL.Select_yfzpat(zq.Zqid, rq1, rq2, 0, "", "",sort, _DataBase);//得到最新的候诊列表
                                List<MZHS_FZJL> _list = new List<MZHS_FZJL>();
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    _list.Add(MZHS_FZJL.DataRowToFZjl(dr));
                                }  
                                refreshScreenDisplay(p, _list);
                            }
                            CallPatient(lstCalledPatient); 
                        }
                    }
                }
            }
            catch(Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
        }

        /// <summary>
        /// 朗诵呼叫信息
        /// </summary>
        /// <param name="lstCalledPatient">呼叫病人列表</param>
        /// <param name="speech">语音呼叫对象</param>
        /// <param name="Hjcs">呼叫次数</param>
        public static void CallPatient(List<ts_mzys_class.MZHS_FZJL> lstCalledPatient)
        {
            try
            {
                if (lstCalledPatient != null && lstCalledPatient.Count > 0)
                {
                    lock (objLockHelper)
                    {
                        //取最后一个呼叫
                        MZHS_FZJL patient = lstCalledPatient[lstCalledPatient.Count - 1];
                        lstCalledPatient.Remove(patient);//从呼叫列表中移除
                        string zqname = string.Empty;

                        if ((!string.IsNullOrEmpty(patient.PatzqName)) && patient.PatzqName.Trim().Length > 0)
                            zqname = patient.PatzqName.Trim();
                        else
                            zqname = patient.patGHZKName;
                        /*此处需要进行动态配置，取Fz_WbeShow.INI文件中的值为呼叫次数*/
                        string msg = "";
                        string callString = "";
                        for (int i = 0; i < Hjcs; i++)//循环呼叫
                        {
                            if (new SystemCfg(3013).Config == "1")
                            {
                                if (!string.IsNullOrEmpty(patient.patName))
                                {
                                    callString += string.Format("请{0}到{1}就诊", patient.patName, patient.roomName);
                                }
                            }
                            else
                            {
                                callString += string.Format("请{0}到{1}{2}就诊", patient.patName, patient.patGHZKName, patient.roomName); 
                            }
                        }
                        _voice.VoiceSpeak(callString, ref msg);
                        if (!string.IsNullOrEmpty(msg))
                            throw new Exception("语音呼叫出现异常!原因:" + msg);
                    }
                }
            }
            catch (Exception ea)
            { 
            }
        }
    }
}
