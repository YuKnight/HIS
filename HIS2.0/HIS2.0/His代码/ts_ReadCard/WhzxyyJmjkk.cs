using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ts_ReadCard
{
    public class WhzxyyJmjkk : ICard
    {
        public WhzxyyJmjkk() { }
                 
        [DllImport("CardHisInterface.dll")]
        public static extern int _ReadCardNum(StringBuilder outCardNum, StringBuilder outXPXLH, StringBuilder outPatInfo);

        /// <summary>
        /// 读取武汉中心医院居民健康卡
        /// </summary>
        /// <param name="inPut"></param>
        /// <returns></returns>
        public object ReadCard(params object[] inPut)
        {
            //if (inPut == null || inPut.Length < 3)
            //    throw new Exception("调用ReadCardNum方法输入参数不能为空");
            StringBuilder sb_outCardNum = new StringBuilder(200);
            StringBuilder sb_outXPXLH = new StringBuilder(200);
            StringBuilder sb_outPatInfo = new StringBuilder(200);
            try
            {
                int resultValue = _ReadCardNum(sb_outCardNum, sb_outXPXLH, sb_outPatInfo);
                //object[] retObjInfo ={ outCardNum, outXPXLH, outPatInfo };
                //KeyValuePair<int, object[]> pair = new KeyValuePair<int, object[]>(resultValue, retObjInfo);
                return sb_outCardNum.ToString();
            }
            catch
            {
                return null;
            }
        }
        
    }
}
