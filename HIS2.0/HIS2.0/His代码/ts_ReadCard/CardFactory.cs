using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ts_ReadCard
{
    public class CardFactory
    {
        #region  卡类型枚举
        /// <summary>
        /// 卡类型
        /// </summary>
        public enum CardKind
        {
            /// <summary>
            /// 新中新
            /// </summary>
            XingZhongXing,
            /// <summary>
            /// 神思
            /// </summary>
            ShenSi,
            /// <summary>
            /// 新中新2合1
            /// </summary>
            XinZhongXin2to1,
            /// <summary>
            /// 新中新DKQ-A16D(版本号HF)
            /// 2014-7-30 jianqg 增加新中新DKQ-A16D usb类型(版本号HF)
            /// </summary>
            XinZhongXin_DKQ_A16D_HF,
            /// <summary>
            /// 精伦电子iDR210
            /// 2014-8-20 jianqg 增加 精伦电子iDR210
            /// </summary>
            JingLun_iDR210,
            /// <summary>
            /// 上海普天CP IDM02/TG
            /// </summary>
            ShangHaiPuTian_CP_IDMR02_TG

        }
        #endregion
        public static Icard NewCard(string cardKindString)
        {
            CardKind cardKind = new CardKind();
            switch (cardKindString)
            {
                case "神思":
                    cardKind = CardKind.ShenSi;
                    break;
                case "新中新二合一":
                    cardKind = CardKind.XinZhongXin2to1;
                    break;
                case "新中新DKQ_A16D_HF":
                    cardKind = CardKind.XinZhongXin_DKQ_A16D_HF;
                    break;
                case "精伦电子iDR210":
                    cardKind = CardKind.JingLun_iDR210;
                    break;
                case "上海普天CP_IDM02/GT":
                    cardKind = CardKind.ShangHaiPuTian_CP_IDMR02_TG;
                    break;
                case "新中新":
                default:
                    cardKind = CardKind.XingZhongXing;
                    break;

            }
            return NewCard(cardKind);
        }
        public static Icard NewCard(CardKind cardKind)
        {
            Icard _card = null;
            string mode = GetIniString("身份证扫描器", "调用模式", AppDomain.CurrentDomain.BaseDirectory + "ClientWindow.ini");

            if (string.IsNullOrEmpty(mode) || mode.ToUpper() == "DLL")
            {
                switch (cardKind)
                {
                    case CardKind.XingZhongXing:
                        _card = new ts_card_xzx();
                        break;
                    case CardKind.ShenSi:
                        _card = new ts_card_ShenSi();
                        break;
                    case CardKind.XinZhongXin2to1:
                        _card = new ts_card_iDR210();
                        break;
                    case CardKind.XinZhongXin_DKQ_A16D_HF:
                        _card = new ts_card_xzx_DKQ_A16D_HF();
                        break;
                    case CardKind.JingLun_iDR210:
                        //jianqg 2014-8-20 经测试可以使用老类库，即就可以使用老的读卡程序
                        _card = new ts_card_iDR210();
                        break;
                    case CardKind.ShangHaiPuTian_CP_IDMR02_TG:
                        _card = new ts_card_shpt_cp_idmr02_tg();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _card = new VirtualReader();
            }
            return _card;
        }

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault,
            StringBuilder lpReturnedString, int nSize, string lpFileName);

        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }

        static public ICard CreateInstance(CardType type, params object[] InParams)
        {
            string codeAddress = GetInstanceAddress(type);
            if (string.IsNullOrEmpty(codeAddress))
            {
                throw new Exception("无法获取业务代码地址");
            }
            Assembly ass = Assembly.GetExecutingAssembly();
            object obj = ass.CreateInstance(codeAddress, true, BindingFlags.CreateInstance, null, InParams, null, null);
            if (obj != null)
            {
                return obj as ICard;
            }
            else
                return null;
        }

        static string GetInstanceAddress(CardType type)
        {
            switch (type)
            {
                case CardType.武汉中心医院居民健康卡:
                    return "ts_ReadCard.WhzxyyJmjkk";
            }
            return null;
        }
    }

    public enum CardType : int
    {
        武汉中心医院居民健康卡 = 1
    }   


}
