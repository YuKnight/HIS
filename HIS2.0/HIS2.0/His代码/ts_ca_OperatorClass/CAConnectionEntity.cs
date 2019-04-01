using System;
using System.Collections.Generic;
using System.Text;

namespace ts_ca_OperatorClass
{
    /// <summary>
    /// CA 连接信息
    /// </summary>
    public class CAConnectionEntity
    {
       string _strIp = "";
       int _iPort = 0;
       string _strUri = "";
       /// <summary>
       /// IP地址
       /// </summary>
       public string IP
       {
           get { return _strIp; }
           set { _strIp = value; }
       }
       /// <summary>
       /// 端口号
       /// </summary>
       public int Port
       {
           get { return _iPort; }
           set { _iPort = value; }
       }
       /// <summary>
       /// URI
       /// </summary>
       public string Uri
       {
           get { return _strUri; }
           set { _strUri = value; }
       }
    }
}
