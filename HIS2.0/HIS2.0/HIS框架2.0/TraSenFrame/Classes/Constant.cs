using System;
using System.IO;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using System.Runtime.InteropServices;
using TrasenFrame.Classes;
using TrasenFrame.Forms;


namespace TrasenFrame.Classes
{
    //jianqg 2012-8-8 增加设置 FrmParaSetting 中，改为除外部身边外，其他按登陆账号设置，取值是，没有个人设置，取公共设置（不带账号）
    /// <summary>
    /// 常量
    /// </summary>
    public class Constant
    {
        /// <summary>
        /// 取得本机硬盘序列号
        /// </summary>
        /// <returns></returns>
        [DllImport("SerialEx.dll", EntryPoint = "fnSerial")]
        private static extern double GetSerialNumber();
        private static string _CustomDirectory = "";
        private Constant()
        {

        }
        /// <summary>
        /// 项目路径
        /// </summary>
        public static readonly string ApplicationDirectory = Application.StartupPath;
        /// <summary>
        /// 本机硬盘序列号
        /// </summary>
        public static string SerialNumber
        {
            get
            {
                return GetSerialNumber().ToString();
            }
        }
        /// <summary>
        /// 登陆用户工号id，加下划线，没有返回"",否则为"_"+UserID
        /// </summary>
        /// <returns></returns>
        public static string CurrentUserId
        {
            get
            {
                if (FrmMdiMain.CurrentUser == null) return "";
                else return "_" + FrmMdiMain.CurrentUser.LoginCode;//加下划线
            }

        }
        /// <summary>
        /// 用户自定义可改写路径
        /// </summary>
        public static string CustomDirectory
        {
            get
            {
                string strDir = "";
                try
                {
                    //					strDir = ApiFunction.GetIniString("CUSTOMDIRRECTORY","DIRECTORY",Constant.ApplicationDirectory+"\\ClientConfig.ini");
                    //					strDir = Crypto.Instance().Decrypto(strDir);
                   
                    if (_CustomDirectory == "")
                    {
                        //jianqg 2013-7-17 修改，为空就取，否则不取
                        strDir = (new SystemCfg(0001)).Config;
                       
                        if (strDir.Trim() == "")
                            strDir = @"C:\\TS-HIS";
                        _CustomDirectory = strDir;
                    }
                    else strDir = _CustomDirectory;
                    

                    if (!Directory.Exists(strDir))			//如果该路径不存在则建立该目录
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    if (!File.Exists(strDir + "\\ClientConfig.ini"))	//如果配置文件不存在则从安装目录拷贝
                    {
                        File.Copy(ApplicationDirectory + "\\ClientConfig.ini", strDir + "\\ClientConfig.ini", true);
                    }
                    return strDir;
                }
                catch (Exception err)
                {
                    MessageBox.Show("请正确设置系统配置文件路径参数！\r\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return ApplicationDirectory;
                }
            }

        }
        /// <summary>
        /// 输入法 
        /// </summary>
        public static string CustomImeMode
        {
            get
            {
                 
                //string svalue = Crypto.Instance().Decrypto(ApiFunction.GetIniString("CUSTOMSETTING" + CurrentUserId, "IMEMODE", CustomDirectory + "\\ClientConfig.ini"));
                string svalue = GetClientConfig("IMEMODE");//jianqg 2012-8-8 修改 按人处理
                return svalue;
            }
            set
            {
                string imeMode = value;
                //ApiFunction.WriteIniString("CUSTOMSETTING" + CurrentUserId, "IMEMODE", Crypto.Instance().Encrypto(imeMode), CustomDirectory + "\\ClientConfig.ini");
                SetClientConfig("IMEMODE", imeMode); //jianqg 2012-8-8 修改 按人处理
            }
        }
        /// <summary>
        /// 过滤方式
        /// </summary>
        public static SearchType CustomSearchType
        {
            get
            {
                //string svalue = Crypto.Instance().Decrypto(ApiFunction.GetIniString("CUSTOMSETTING", "SEARCHTYPE", CustomDirectory + "\\ClientConfig.ini"));
                string svalue = GetClientConfig("SEARCHTYPE");//jianqg 2012-8-8 修改 按人处理
                if (Convertor.IsNumeric(svalue))
                    return (SearchType)Convert.ToInt32(svalue);
                else
                    return SearchType.前导相似;
            }
            set
            {
                string searchType = ((int)value).ToString();
                //ApiFunction.WriteIniString("CUSTOMSETTING", "SEARCHTYPE", Crypto.Instance().Encrypto(searchType), CustomDirectory + "\\ClientConfig.ini");
                SetClientConfig("SEARCHTYPE", searchType);//jianqg 2012-8-8 修改 按人处理
            }
        }

        /// <summary>
        /// 过滤字段
        /// </summary>
        public static FilterType CustomFilterType
        {
            get
            {
                //string svalue = Crypto.Instance().Decrypto(ApiFunction.GetIniString("CUSTOMSETTING", "FILTERTYPE", CustomDirectory + "\\ClientConfig.ini"));
                string svalue = GetClientConfig("FILTERTYPE");//jianqg 2012-8-8 修改 按人处理
                if (Convertor.IsNumeric(svalue))
                    return (FilterType)Convert.ToInt32(svalue);
                else
                    return FilterType.智能;		//默认为智能
            }
            set
            {
                string filterType = ((int)value).ToString();
                //ApiFunction.WriteIniString("CUSTOMSETTING", "FILTERTYPE", Crypto.Instance().Encrypto(filterType), CustomDirectory + "\\ClientConfig.ini");
                SetClientConfig("FILTERTYPE", filterType);//jianqg 2012-8-8 修改 按人处理
            }
        }
        /// <summary>
        ///  背景图片路径
        /// </summary>
        public static string BackGroundPicturePath
        {
            get
            {
                //return Crypto.Instance().Decrypto(ApiFunction.GetIniString("CUSTOMSETTING", "BACKGROUNDPICTUREPATH", CustomDirectory + "\\ClientConfig.ini"));
                return GetClientConfig("BACKGROUNDPICTUREPATH");//jianqg 2012-8-8 修改 按人处理
            }
            set
            {
                //ApiFunction.WriteIniString("CUSTOMSETTING", "BACKGROUNDPICTUREPATH", Crypto.Instance().Encrypto(value), CustomDirectory + "\\ClientConfig.ini");
                SetClientConfig("BACKGROUNDPICTUREPATH", value);//jianqg 2012-8-8 修改 按人处理
            }
        }
        /// <summary>
        ///  报价器COM端口
        /// </summary>
        public static string ComPort
        {
            get
            {
                return Crypto.Instance().Decrypto(ApiFunction.GetIniString("CUSTOMSETTING", "COMPORT", CustomDirectory + "\\ClientConfig.ini"));
            }
            set
            {
                ApiFunction.WriteIniString("CUSTOMSETTING", "COMPORT", Crypto.Instance().Encrypto(value), CustomDirectory + "\\ClientConfig.ini");
            }
        }
        /// <summary>
        ///  发票打印机
        /// </summary>
        public static string CInvoicePrinterName
        {
            get
            {
                return Crypto.Instance().Decrypto(ApiFunction.GetIniString("CUSTOMSETTING", "INVOICEPRINTERNAME", CustomDirectory + "\\ClientConfig.ini"));
            }
            set
            {
                ApiFunction.WriteIniString("CUSTOMSETTING", "INVOICEPRINTERNAME", Crypto.Instance().Encrypto(value), CustomDirectory + "\\ClientConfig.ini");
            }
        }
        /// <summary>
        ///  报表打印机
        /// </summary>
        public static string CReportPrinterName
        {
            get
            {
                return Crypto.Instance().Decrypto(ApiFunction.GetIniString("CUSTOMSETTING", "REPORTPRINTERNAME", CustomDirectory + "\\ClientConfig.ini"));
            }
            set
            {
                ApiFunction.WriteIniString("CUSTOMSETTING", "REPORTPRINTERNAME", Crypto.Instance().Encrypto(value), CustomDirectory + "\\ClientConfig.ini");
            }
        }
        /// <summary>
        /// 软件注册码
        /// </summary>
        public static string RegisterCode
        {
            get
            {
                return ApiFunction.GetIniString("REGISTER", "REGISTERCODE", ApplicationDirectory + "\\ClientConfig.ini");
            }
            set
            {
                ApiFunction.WriteIniString("REGISTER", "REGISTERCODE", value, ApplicationDirectory + "\\ClientConfig.ini");
            }
        }
        /// <summary>
        /// 主窗体菜单字体大小
        /// </summary>
        public static string MenuFontSize
        {
            get
            {
                //return ApiFunction.GetIniString("MENUFONT", "SIZE", ApplicationDirectory + "\\ClientConfig.ini");
                string svalue = GetClientConfig("MENUFONT_SIZE");//jianqg 2012-8-8 修改 按人处理
                //没有找到 取原来的 公共设置
                if (svalue.Trim() == "") svalue = ApiFunction.GetIniString("MENUFONT", "SIZE", ApplicationDirectory + "\\ClientConfig.ini");
                return svalue;
            }
            set
            {
                //ApiFunction.WriteIniString("MENUFONT", "SIZE", value, ApplicationDirectory + "\\ClientConfig.ini");
                SetClientConfig("MENUFONT_SIZE", value);//jianqg 2012-8-8 修改 按人处理
            }
        }
        public static string BackImage
        {
            get
            {
                //return ApiFunction.GetIniString("BACKGROUNDIMAGE", "NAME", ApplicationDirectory + "\\ClientConfig.ini");
                string svalue = GetClientConfig("BACKGROUNDIMAGE_NAME");//jianqg 2012-8-8 修改 按人处理
                //没有找到 取原来的 公共设置
                if (svalue.Trim() == "") svalue = ApiFunction.GetIniString("BACKGROUNDIMAGE", "NAME", ApplicationDirectory + "\\ClientConfig.ini");
                return svalue;
            }
            set
            {
                //ApiFunction.WriteIniString("BACKGROUNDIMAGE", "NAME", value, ApplicationDirectory + "\\ClientConfig.ini");
                SetClientConfig("BACKGROUNDIMAGE_NAME", value);//jianqg 2012-8-8 修改 按人处理
            }
        }
        /// <summary>
        /// 是否能够选择链接登陆
        /// </summary>
        public static bool IsSelectConnect
        {
            get
            {
                return Convert.ToBoolean(Convertor.IsNull(ApiFunction.GetIniString("ISSELECTCONNECT", "NAME", ApplicationDirectory + "\\ClientConfig.ini"), "false"));
            }
            set
            {
                ApiFunction.WriteIniString("ISSELECTCONNECT", "NAME", value.ToString(), ApplicationDirectory + "\\ClientConfig.ini");
            }
        }
        /// <summary>
        /// 医院名称
        /// </summary>
        public static string HospitalName
        {
            get
            {
                return (new SystemCfg(0002).Config);
            }

        }
        #region  取配置值，写配置值 jianqg 2012-8-8 增加
        /// <summary>
        /// 取配置值 jianqg 2012-8-8 增加 处理 非外部设备等
        /// </summary>
        /// <param name="lpKeyName"></param>
        /// <returns></returns>
        public static string GetClientConfig(string lpKeyName)
        {
            string strValue =Crypto.Instance().Decrypto(ApiFunction.GetIniString("CUSTOMSETTING" + CurrentUserId, lpKeyName, CustomDirectory + "\\ClientConfig.ini"));
            //没有该账号的配置时，去公共的
            if (CurrentUserId != "" && (strValue == null || strValue == ""))
            {
                strValue = Crypto.Instance().Decrypto(ApiFunction.GetIniString("CUSTOMSETTING", lpKeyName, CustomDirectory + "\\ClientConfig.ini"));
            }
            return strValue;
        }
        /// <summary>
        /// 写配置值 jianqg 2012-8-8 增加 处理 非外部设备等
        /// </summary>
        /// <param name="lpKeyName"></param>
        /// <param name="lpString"></param>
        /// <returns></returns>
        public static void SetClientConfig(string lpKeyName,string lpString)
        {
            ApiFunction.WriteIniString("CUSTOMSETTING" + CurrentUserId, lpKeyName, Crypto.Instance().Encrypto(lpString), CustomDirectory + "\\ClientConfig.ini");

        }

        #endregion

    }

}
