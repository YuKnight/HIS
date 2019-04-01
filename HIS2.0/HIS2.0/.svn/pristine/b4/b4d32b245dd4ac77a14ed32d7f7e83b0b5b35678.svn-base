using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Ts_Hlyy_Interface
{
  public  class HlyyFactory
    {
        //API函数申明
        [DllImport("kernel32")]
        public static extern bool PostMessage(int hWnd, int Msg, int wParam, int lParam);
        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }
        public static HlyyInterface Hlyy(string HlyyName)
        {
            HlyyInterface _hlyy=null;
            if (HlyyName == "大通新"&& GetIniString("hlyy", "verson", System.Windows.Forms.Application.StartupPath + "\\Hlyy.ini")=="2.0")
            {
                 HlyyName="大通2.0";
            }
            switch (HlyyName)
            {
                case "大通":
                    _hlyy = new DT_HlyyClass();
                    break;
                case "美康":
                    _hlyy = new MK_HlyyClass();
                    break;
                case "大通新":
                    //_hlyy = new DTnew_HlyyClass();
                    break;
                case "大通2.0":
                    _hlyy = new DT2_Hlyy();
                    break;
                default:
                    throw new Exception("没有这种合理用药接口类型");
            }

            return _hlyy;
        }

     
    }
}
