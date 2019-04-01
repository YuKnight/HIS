using System;
using System.Collections.Generic;
using System.Text;

namespace ts.WHZXYY.Portal
{
    public class Client
    {
        public static string GetRequestString( string portalsid )
        {
            string strTarget = null;
            string strMsg = "<message msgType=\"call\" msgId=\"1\" timestampCreated=\"" + DateTime.Now.ToString() + "\" version=\"1.15\"><call timestampCreated=\"" + DateTime.Now.ToString() + "\" crfCallMode=\"alwaysRespond\"><targetLogicService>PORTAL_GET_LOGIN_USER_INFO</targetLogicService><targetLogicApp>CIS</targetLogicApp></call><body bodyId=\"1\"><loginUserInfo><sessionId>" + portalsid + "</sessionId></loginUserInfo></body></message>";
            ts.WHZXYY.Portal.WebReference.XMLStreamService ws = new ts.WHZXYY.Portal.WebReference.XMLStreamService();
            string strRet = ws.ProcessInput( strMsg , 10000 , false, strTarget );
            ws.Dispose();
            return strRet;
        }
    }
}
