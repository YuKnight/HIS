using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace ts_yf_mzfy
{
    public class YongTai
    {
        [DllImport("pjq.dll")]
        public static extern int Opinion_Init(int aiCOM);
        [DllImport("pjq.dll")]
        public static extern int Opinion_PlzOpinion(out int aiValue, int aiTimeout);

        public void PlzOpinion()
        {
            //Func<bool> SetPlzOpinion = () =>
            //{
            //    Opinion_Init(1);
            //    //1.再调用新的评价器的dll进行评价
            //    int aiValue = -1;
            //    Opinion_PlzOpinion(out aiValue, 30);

            //    //2.回传评价结果
            //    WebPjq ws = new WebPjq(GetPjqWebServiceURL());
            //    string str = ws.GetInfo(xph, xm, aiValue, DateTime.Now);
            //    return true;
            //};
            //SetPlzOpinion.BeginInvoke(new AsyncCallback((async) => SetPlzOpinion.EndInvoke(async)), null);
            Thread thread = new Thread(OpinionPlzOpinion);
            thread.Start();
        }

        public void OpinionPlzOpinion()
        {
            //1.再调用新的评价器的dll进行评价
            int aiValue = -1;
            Opinion_PlzOpinion(out aiValue, 30);

            //2.回传评价结果
            PjqService.WebPjq pjq = new PjqService.WebPjq();
            string str = pjq.GetInfo(InstanceForm.BCurrentUser.LoginCode, InstanceForm.BCurrentUser.Name, aiValue, DateTime.Now);           
        }

        /// <summary>
        /// 初始化评价器端口
        /// </summary>
        /// <param name="aiCom"></param>
        /// <returns></returns>
        public int OpinionInit(int aiCom)
        {
            return Opinion_Init(aiCom);
        }


    }
}
