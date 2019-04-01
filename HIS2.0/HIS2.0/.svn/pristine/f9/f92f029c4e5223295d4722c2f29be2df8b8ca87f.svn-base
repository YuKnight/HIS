using System;
using System.Collections.Generic;
using System.Text;
using ICommon;

namespace RemoteObj
{
    public class LedShow : MarshalByRefObject, ILedShow
    {
        public static event LedShowEventHandler LedShowedEvent;

        #region 事件触发器
        public void SendMessage(string name, string winname,string wincode,string deptid)
        {
            if (LedShowedEvent != null)
            {
                LedShowedEvent(name, winname,wincode, deptid);
            }
        }
        #endregion

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
