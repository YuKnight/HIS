using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ts_call
{
    public enum DmType
    {
        应收,
        实收,
        找零,
        姓名,
        欢迎,
        清除,
        发药,
        发药呼叫,
        卡充值,
        总费用
    }
    public struct CFMX
    {
        public string PM;
        public string GG;
        public decimal DJ;
        public decimal SL;
        public string DW;
        public decimal JE;
        public string fph;
        public string brxm;
        //public string blh;
        //public string fpid;
        //public string brxxid;
        public int deptid;
        public string fyck;
       
    }
    public interface Icall
    {
        Thread CurrentThread
        {
            get;
            set;
        }
        /// <summary>
        /// 报价显示
        /// </summary>
        /// <param name="dmtype">枚举类型</param>
        /// <param name="callstring">显示字符串</param>
        void Call(DmType dmtype, string callstring);
        /// <summary>
        /// 实收找零连续显示
        /// </summary>
        /// <param name="ss">实收</param>
        /// <param name="zl">找零</param>
        void Call(string ss, string zl);
        /// <summary>
        /// 报价显示
        /// </summary>
        /// <param name="dmtype">枚举类型</param>
        /// <param name="callstring">显示字符串</param>
        /// <param name="je">金额</param>
        void Call(DmType dmtype, string callstring, double je);
        void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX);

        
        /// <summary>
        /// 图片加载
        /// </summary>
        /// <param name="picturename"></param>
        void SetPicture(string picturename);
    }       
}
