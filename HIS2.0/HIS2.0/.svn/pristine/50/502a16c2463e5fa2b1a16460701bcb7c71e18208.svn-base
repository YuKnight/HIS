using System;
using System.Collections.Generic;
using System.Text;

namespace ts_ca_OperatorClass
{
   public class CAServicesEX:ts_ca_Interface.InterfaceCA
    {
       CAServices ca = new CAServices();

        #region InterfaceCA 成员

        bool ts_ca_Interface.InterfaceCA.VerifyDevice(out string strmsg)
        {
            return ca.InitCa(out strmsg);
        }

        bool ts_ca_Interface.InterfaceCA.VerifyLogin(string strUserId, string strPwd,out string strmsg)
        {
            return ca.LoginUser(strUserId, strPwd,out strmsg);
        }

        #endregion



        #region InterfaceCA 成员


        bool ts_ca_Interface.InterfaceCA.SignOrderItemP1(string strContent, string strCerId, string strpwd, out string strmsg)
        {
            return ca.SignOrderItemP1(strContent, strCerId, strpwd,out strmsg);
        }

       bool ts_ca_Interface.InterfaceCA.SignOrderItemP7(string strContent, string strCerId, string strpwd, out string strmsg)
        {
            return ca.SignOrderItemP7(strContent, strCerId, strpwd,out strmsg);
        }

        bool ts_ca_Interface.InterfaceCA.OrderSign(string strContent, string strUserId, string strPwd, string strInDept, out string strmsg)
        {
            return ca.OrderSign(strContent, strUserId, strPwd, strInDept, out strmsg);
        }

        #endregion
    }
}
