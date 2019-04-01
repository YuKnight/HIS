using System;
using System.Collections.Generic;
using System.Text;

namespace ClsMzCall
{
    public class ClsMzZcyCall
    {
        /// <summary>
        /// 
        //<patient_info>
        // <pat_name>患者姓名</pat_name>
        // <pat_id>患者id</pat_id>
        // <IPaddress>医生工作站IP</IPaddress>
        // <type>叫号状态 0：叫号未取药 1：叫号已取药</type>
        //</patient_info>
        /// </summary>
        /// <param name="fyck"></param>
        /// <param name="name"></param>
        public static void CallInpatient(string name, string inpid, string ipAddr, string type)
        {
            ipAddr = "192.168.131.12";//写死

            MzCallWs.WebServiceTerminalCall ser = new ClsMzCall.MzCallWs.WebServiceTerminalCall();
            ser.Url = "http://192.168.0.141:81/WebServiceTerminalCall.asmx";

            string para = string.Format(@"<patient_info><pat_name>{0}</pat_name><pat_id>{1}</pat_id><IPaddress>{2}</IPaddress><type>{3}</type></patient_info>", name, inpid, ipAddr, type);

            string ret = ser.Call(para);
        }
    }
}
