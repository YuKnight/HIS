using System;
using System.Collections.Generic;
using System.Text;

namespace ClsMzCall
{
    public class CallInp
    {
        /*
         *  例子：RemarksStatus ：比如特殊药品特殊煎法的就写这里面：如 当归  ：“先煎20分钟”
             注意：药品明细中有的药会有先煎、后下、另包、包煎等字眼。
         */
        public static void CallInpatient(string fyck, string name)
        {
            string mac="";//写死

            MzCallWs.WebServiceTerminalCall ser = new ClsMzCall.MzCallWs.WebServiceTerminalCall();
            ser.Url = "http://192.168.0.141:81/WebServiceTerminalCall.asmx";

            string para = string.Format(@"<patient_info><call_room>{0}</call_room><name>{1}</name></patient_info>", fyck,name);

            ser.CallDrug(para, mac);
        }
    }
}
