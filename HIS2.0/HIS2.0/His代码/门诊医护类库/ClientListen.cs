using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Data;
using ts_mzys_class;
using System.Net.Sockets;
using System.Net;

namespace ts_mzys_class
{
    /// <summary>
    /// 客户端连接类
    /// </summary>
    public class ClientListen
    {
        /// <summary>
        /// 呼叫病人(通过此方法链接目标机器)
        /// </summary>
        /// <param name="patient">被呼叫的病人对象</param>
        /// <param name="remoteIP">当前工作站所在的诊区的分诊台IP</param>
        public bool CallPatient(MZHS_FZJL patient, string remoteIP,int port, out string msg)
        {

            #region 将病人对象构造成xml字符串
            msg = "";
            string message = "";
            if (patient != null)
            {
                message = "<PATIENT>";
                System.Reflection.PropertyInfo[] ps = patient.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    object obj = p.GetValue(patient, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Public,
                        null, null, null);
                    string str = string.Format("<{0}>{1}</{0}>", p.Name, obj);
                    message += str;
                }
                message += "</PATIENT>";
            }
            // msg = message; //add by 2012-12-10 zp
            #endregion

            if (!string.IsNullOrEmpty(remoteIP))
            {
                string remoteHostIP = remoteIP.Trim(); //诊区的IP
                int remoteHostPort = port;    //端口号
                TcpClient tcpClient = new TcpClient();

                try
                {
                    try
                    {
                        tcpClient.Connect(IPAddress.Parse(remoteHostIP), remoteHostPort);//链接目标计算机(呼叫大厅)
                    }
                    catch (System.Net.Sockets.SocketException err_sock)
                    {
                        msg = "通讯出现异常!请检查诊区服务端机器是否已开启!网络异常信息:" + err_sock.Message;
                        return false;
                    }
          
                    NetworkStream ns = tcpClient.GetStream();
                    try
                    {
                       
                        if (ns.CanWrite)
                        {
                            Byte[] sendBytes = Encoding.UTF8.GetBytes(message);//UTF字节占用少
                            ns.Write(sendBytes, 0, sendBytes.Length);
                            return true;
                        }
                        else
                        {
                            //throw new Exception( "不能写入数据流" );
                            msg = "不能写入数据流";
                            return false;
                        }
                    }
                    catch (Exception err1)
                    {
                        msg = err1.Message;
                        throw new Exception(err1.ToString());
                        //return false;
                    }
                    finally
                    {
                        ns.Close();
                    }
                }
                catch (Exception err2)
                {
                    msg = err2.ToString();
                    //throw err2;
                    return false;
                }
                finally
                {

                    tcpClient.Close();
                }
            }
            return false;
        }


        
        //private void SendPort(String msg,RelationalDatabase _DataBase)
        //{
        //    if (msg != "")
        //    {
        //        //向端口发送数据
        //        string ssql = "select * from jc_zjsz where zjid=" + Dqcf.ZsID + "";
        //        DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
        //        if (tab.Rows.Count == 0)
        //        {
        //            return;
        //        }
        //        if (Convertor.IsNull(tab.Rows[0]["txip"], "") == "" || Convertor.IsNull(tab.Rows[0]["txdk"], "") == "")
        //        {
        //            return;
        //        }

        //        TcpClient client = new TcpClient(Convertor.IsNull(tab.Rows[0]["txip"], ""), Convert.ToInt32(Convertor.IsNull(tab.Rows[0]["txdk"], "")));
        //        NetworkStream sendStream = client.GetStream();

        //        Byte[] sendBytes = Encoding.Default.GetBytes(msg);
        //        sendStream.Write(sendBytes, 0, sendBytes.Length);
        //        sendStream.Close();
        //        client.Close();
        //    }
        //}
    }
}
