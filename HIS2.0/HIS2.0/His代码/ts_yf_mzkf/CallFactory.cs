using System;
using System.Collections.Generic;
using System.Text;

namespace ts_yf_mzkf
{
    public class CallFactory
    {
        public static IMzkf NewMzkf(string jklx)
        {
            IMzkf _call = null;
            switch (jklx)
            {
                case "北院门诊快发":
                    _call = new ts_whzxyy_mzkf();
                    break;
                case "南院门诊快发":
                    _call = new ts_whzxyyNy_mzkf();
                    break;
                case "北院使用南院相同门诊快发":
                    _call = new ts_whzxyyNy_mzkf();
                    break;
            }
            return _call;
        }  

    }
}
