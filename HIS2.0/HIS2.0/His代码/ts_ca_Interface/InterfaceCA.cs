using System;
using System.Collections.Generic;
using System.Text;

namespace ts_ca_Interface
{
   public interface InterfaceCA
    {
        /// <summary>
        /// 验证设备
        /// </summary>
        /// <returns></returns>
        bool VerifyDevice(out string strmsg);
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="strUserId"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        bool VerifyLogin(string strUserId, string strPwd,out string strmsg);

       /// <summary>
       /// P1签名
       /// </summary>
       /// <param name="strContent"></param>
       /// <param name="strCerId"></param>
       /// <param name="strmsg"></param>
       bool SignOrderItemP1(string strContent, string strCerId,string strpwd,out string strmsg);

       /// <summary>
       /// P7签名
       /// </summary>
       /// <param name="strContent"></param>
       /// <param name="strCerId"></param>
       /// <param name="strpwd"></param>
       /// <param name="strmsg"></param>
       /// <returns></returns>
       bool SignOrderItemP7(string strContent, string strCerId,string strpwd ,out string strmsg);
       /// <summary>
       /// 签名与时间戳
       /// </summary>
       /// <param name="strContent"></param>
       /// <param name="strUserId"></param>
       /// <param name="strPwd"></param>
       /// <param name="strInDept"></param>
       /// <param name="strmsg"></param>
       bool OrderSign(string strContent, string strUserId, string strPwd, string strInDept, out string strmsg);


    }
}
