using System;
using System.Collections.Generic;
using System.Text;

namespace ts_call
{
    public class CallFactory
    {
        public static Icall NewCall(string jklx)
        {
            Icall _call = null;
            switch (jklx)
            {
                case "SHL-1语音收费报价器":
                    _call = new ts_call();
                    break;
                case "led显示屏":
                    _call = new ts_call_led();
                    break;
                case "SYC-Q9语音显示器":
                    _call = new ts_call_led_shyc();
                    break;
                case "VFD8C语音显示器":
                    _call = new ts_call_led_VFD8C();
                    break;
                case "湖南光通显示器":
                    _call = new ts_call_led_HNGT();
                    break;
                case "AxCL2005_16W":
                    _call = new ts_call_AxCL2005_16W();
                    break;
                case "武汉北院叫号":  //戴月文开发的 实际上是武汉中心医院南院叫号，类型名称写错了
                    _call = new ts_call_whzxyymz();
                    break;
                case "武汉中心医院北院叫号":
                    _call = new ts_call_whzxyybymz();
                    break;

                
                case "上海通导语音报价器型号I":
                    _call = new ts_call_vfd_TDKJ_BJ_I();
                    break;
                case "上海通导语音报价器型号Ⅳ"://与1型基本通用
                    ts_call_vfd_TDKJ_BJ_I.kind = 4;
                    _call = new ts_call_vfd_TDKJ_BJ_I();
                    break;
                case "FGC01":
                    _call = new ts_call_FGC01A();
                    break;
                case "双屏LED":
                    _call = new ts_call_led_cz();
                    break;
                case "上海通导语音报价器邵阳第一人民医院":
                    ts_call_vfd_TDKJ_BJ_SYRY.kind = 4;
                    _call = new ts_call_vfd_TDKJ_BJ_SYRY();
                    break;
                case "株洲中医院LED显示屏":
                    _call = new ts_call_led_yx();
                    break;
                case "ts_call_led_cnfy"://常宁妇幼
                    _call = new ts_call_led_cnfy();
                    break;
            }

            return _call;
        }


        //报价器找零
        public static void Bjq_ZlCall(string bjqxh, Icall call, string msg)
        {
            if (bjqxh.Trim() == "上海通导语音报价器型号Ⅳ" && cwjz > 0)
            {
                string par = ",,,," + ssje.ToString("0.00") + "元";
                call.Call(DmType.实收, par);
            }
            else if (bjqxh.Trim() == "上海通导语音报价器邵阳第一人民医院" && cwjz > 0 && ssje == 0)
            {
                //Add by tck 2013-11
                string par = cwjz.ToString("0.00") + "元" + "," + (zlkye - cwjz) + "元";
                call.Call(DmType.实收, par);
            }
            else
                call.Call(ssje.ToString("0.00"), zlje.ToString("0.00"));
        }
        //报价器应收 Add by zp 2013-12-04 
        public static void Bjq_YsCall(string bjqxh, Icall call, string msg)
        {
            if (zlkye > ysje && bjqxh == "上海通导语音报价器型号Ⅳ")
            {
                call.Call(DmType.应收, msg);
            }
            else if (zlkye > zje && bjqxh == "上海通导语音报价器邵阳第一人民医院")
            {
                call.Call(DmType.姓名, msg);
                call.Call(DmType.总费用, zje.ToString("0.00") + "元");
            }
            else
            {
                call.Call(DmType.姓名, msg);
                call.Call(DmType.应收, ysje.ToString("0.00"));
            }
        }

        public static decimal ssje; //Add by zp 2013-12-04 
        public static decimal cwjz; //Add by zp 2013-12-04
        public static decimal zlje; //Add by zp 2013-12-04
        public static decimal zlkye; //Add by zp 2013-12-04
        public static decimal ysje; //Add by zp 2013-12-04
        public static decimal zje; //Add by zp 2013-12-04
        public static string brxm; //Add by zp 2013-12-04
    }


}
