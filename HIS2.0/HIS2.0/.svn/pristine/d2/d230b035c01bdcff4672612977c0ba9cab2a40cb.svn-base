using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using System.Data;

namespace ts_ca_OperatorClass
{
    public class CAServices
    {
        /// <summary>
        /// 获取证书
        /// </summary>
        private List<string> cerlst = new List<string>();
        /// <summary>
        /// Base64编码的证书字符串
        /// </summary>
        static string certBase64 = "";
        /// <summary>
        /// 客户端接口
        /// </summary>
        JITUsbKeyComLib.MedicalTKClass medicalTK = null;
        /// <summary>
        /// 签名接口
        /// </summary>
        JITClientCOMAPILib.JITVSTKClientProcClass vstkClientPro = null;

        /// <summary>
        /// 时间戳
        /// </summary>
        SVS_S_SDK_COMLib.CSVS_S_SDKClass svsClient;

        HBCA_SOFSEALLib.SealClass _seal = null;

        /// <summary>
        /// 验签服务器地址
        /// </summary>
        private static CAConnectionEntity _conEntity;
        private static CAConnectionEntity _conTimestampEntity;

        static string _userId;

        public CAServices()
        {
            _conEntity = new CAConnectionEntity();
            _conTimestampEntity = new CAConnectionEntity();

            _seal = new HBCA_SOFSEALLib.SealClass();
            InitConnectionEntity();
            InitTimesTampConnnectionEntity();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <param name="strcerId">证书ID</param>
        /// <param name="strpwd">密码</param>
        /// <returns></returns>
        public bool LoginUser(string userID, string strpwd, out string strmsg)
        {
            try
            {
                strmsg = "";
                if (!InitCa(out strmsg))
                    return false;
                InitCaConnection(out strmsg);
                if (!"".Equals(strmsg))
                {
                    return false;
                }
                //UKEY 密码验证
                int usbLogin = medicalTK.SOF_Login(cerlst[0], strpwd);
                //验证通过
                if (usbLogin == 0)
                {
                    ////获取Base64编码的证书字符串
                    //certBase64 = medicalTK.SOF_ExportUserCert(cerlst[0]);
                    //获取随机码
                    string random = GetRandom();
                    //对随机码进行P7签名
                    string encryptData = P7Sign(cerlst[0], random);
                    if ("".Equals(encryptData))
                    {
                        strmsg = "P7签名出错，错误码：" + medicalTK.GetLastError();
                        return false;

                    }
                    int iRet;
                    //服务端验证P7签名数据
                    iRet = vstkClientPro.SOF_VerifySignedDataByP7(encryptData);
                    if (iRet != 0)
                    {
                        strmsg = "P7验签失败，返回值：" + medicalTK.GetLastError();
                        return false;

                    }
                    //P7验证通过 进一步验证随机数是否正确
                    string randomServer = GetDataInfoByP7(encryptData, 1);
                    //随机数验证通过
                    if (random.Equals(randomServer))
                    {
                        //验证通过，获取工号
                        _userId = GetCertInfoByOId(certBase64, "2.4.16.11.7.3");

                        MessageBox.Show(_userId);
                    }
                    else if ("".Equals(randomServer))
                    {
                        strmsg = "获取原文信息失败，返回值：" + medicalTK.GetLastError();
                        return false;

                    }
                    else if (!random.Equals(randomServer))
                    {
                        strmsg = "解析原文不一致，解析值：" + randomServer;
                        return false;

                    }
                    else
                    {
                        strmsg = "未知错误，错误码：" + medicalTK.GetLastError();
                        return false;
                    }
                }
                else
                {
                    strmsg = "错误码：" + medicalTK.GetLastError();
                    return false;
                }
                return true;
            }
            catch (Exception err)
            {
                strmsg = err.Message;
                return false;
            }


        }

        public Image GetUserPicture(string strCertId, string strSealId)
        {
            //印章BASE64串
            string imageBase64 = _seal.SOF_GetKeyPicture("");
            if ("".Equals(imageBase64))
            {
                throw new Exception("获取图片信息失败！");

            }
            byte[] imgBytes = Convert.FromBase64String(imageBase64);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(imgBytes);
            Image image = Image.FromStream(memoryStream);
            return image;

        }

        #region 相关初始化
        internal bool InitCa(out string strmsg)
        {
            //是否插入启动设备
            strmsg = "";
            try
            {
                medicalTK = new JITUsbKeyComLib.MedicalTKClass();
            }
            catch (Exception err)
            {
                strmsg = "clientkey Error:" + err.Message;
                return false;
            }
            string strcer = medicalTK.SOF_GetUserList();
            if (strcer == "")
            {
                strmsg = "请确认你的Ukey是否插入！";
                return false;

            }
            else
            {
                string[] certarray = strcer.Split(new string[] { "&&&" }, StringSplitOptions.None);//strcer.Split(new char[3] { '&', '|', '=' });
                if (certarray.Length > 0)
                {
                    foreach (string i in certarray)
                    {
                        cerlst.Add(i);//获得用户列表
                    }
                    //不能同时插入两个KEY
                    if (cerlst.Count > 1)
                    {
                        strmsg = "终端不能同时使用多个key,请拔出一个";
                        cerlst.Clear();
                        return false;
                    }

                    //获取Base64编码的证书字符串
                    certBase64 = medicalTK.SOF_ExportUserCert(cerlst[0]);
                    if ("".Equals(certBase64))
                    {
                        strmsg = "获取Base64编码的证书字错误码：" + medicalTK.GetLastError();
                        return false;
                    }
                }
                else
                {
                    strmsg = "无法找到证书！";
                    return false;

                }
            }
            return true;
        }
        /// <summary>
        /// 初始化连接
        /// </summary>
        private void InitCaConnection(out string strmsg)
        {
            strmsg = "";
            vstkClientPro = new JITClientCOMAPILib.JITVSTKClientProcClass();
            int iRet = -1;
            //设置参数
            iRet = vstkClientPro.SOF_InitServerConnectEx(_conEntity.IP, _conEntity.Port);
            if (iRet != 0)
            {
                strmsg = "连接服务器失败，错误码：" + vstkClientPro.SOF_GetLastError();
            }
        }

        /// <summary>
        /// 初始化连接实体
        /// </summary>
        private void InitConnectionEntity()
        {
            string strCon = ConfigurationManager.AppSettings["CA"];
            string[] strArray = strCon.Split(';');
            if (strArray.Length > 0)
            {
                _conEntity.IP = strArray[0].ToString();
                _conEntity.Port = Convert.ToInt32(strArray[1]);
                _conEntity.Uri = strArray[2].ToString();
            }
            else
            {
                throw new Exception("初始化CA连接地址失败");
            }

        }
        private void InitTimesTampConnnectionEntity()
        {
            string strCon = ConfigurationManager.AppSettings["CATimesTamp"];
            string[] strArray = strCon.Split(';');
            if (strArray.Length > 0)
            {
                _conTimestampEntity.IP = strArray[0].ToString();
                _conTimestampEntity.Port = Convert.ToInt32(strArray[1]);
                _conTimestampEntity.Uri = strArray[2].ToString();
            }
            else
            {
                throw new Exception("初始化CA连接地址失败");
            }
        }
        #endregion

        #region 医嘱发送


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strContent">原文</param>
        /// <param name="strCerId">印章标识</param>

        public void SignOrderItem(string strContent, string strCerId, out string strmsg)
        {
            strmsg = "";
            if (!InitCa(out strmsg)) return;
            string sealResultId = "";
            //证书标示 cerlst[0]

            if (cerlst.Count > 0)
            {

                sealResultId = _seal.SOF_SignSealData(strCerId, cerlst[0], strContent, 0);
                if (sealResultId == "")
                {
                    strmsg = "产生签名值失败";
                }
                string strResult = _seal.SOF_GetSealInfo(sealResultId, 0);
                try
                {
                    //验证签名值
                    InitCaConnection(out strmsg);
                    //string strbase64=medicalTK.SOF_ExportUserCert(cerlst[0]);
                    int iRet = vstkClientPro.SOF_VerifySignedData(_seal.SOF_GetSealInfo(sealResultId, 2), strContent, _seal.SOF_GetSealInfo(sealResultId, 1));
                    //int iRet = _seal.SOF_VerifySealData(_seal.SOF_GetSealInfo(sealResultId, 2),
                    //                                   strContent,
                    //                                   _seal.SOF_GetSealInfo(sealResultId, 1),
                    //                                   _seal.SOF_GetSealInfo(sealResultId, 4), 0);
                    if (iRet == 0)
                    {
                        MessageBox.Show("验签成功！");
                    }
                    else
                    {
                        strmsg = "验失败！";
                    }
                }
                catch (Exception err)
                {
                    strmsg = err.Message + ";CA错误代码:" + vstkClientPro.SOF_GetLastError();
                }
            }

        }

        /// <summary>
        /// 医嘱P1签名
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="strCerId"></param>
        /// <param name="strmsg"></param>
        /// <returns></returns>
        public bool SignOrderItemP1(string strContent, string strCerId, string strpwd, out string strmsg)
        {
            strmsg = "";
            if (!InitCa(out strmsg)) return false;
            InitCaConnection(out strmsg);
            if (!"".Equals(strmsg))
            {
                return false;
            }
            //核对用户工号
            _userId=GetCertInfoByOId(certBase64, "2.4.16.11.7.3");
            if(!_userId.Equals(strCerId.ToString()))
            {
                strmsg = "系统用户ID与CA的keyID不一致！";
                return false;
            }
            int usbLogin = medicalTK.SOF_Login(cerlst[0], strpwd);
            if (usbLogin != 0)
            {
                strmsg = "密码错误：" + medicalTK.GetLastError();
                return false;
            }
          

            #region 签名值
            string encryptData = medicalTK.SOF_SignData(cerlst[0], strContent);
            if ("".Equals(encryptData))
            {
                strmsg = "P1签名错误码：" + medicalTK.GetLastError();
                return false;
            }
            #endregion

            #region 验证签名
            int iRet = vstkClientPro.SOF_VerifySignedData(certBase64, strContent, encryptData);
            if (iRet != 0)
            {
                strmsg = "P1验签失败，错误码：" + vstkClientPro.SOF_GetLastError().ToString();
                return false;
            }
            #endregion

            return true;

        }

        /// <summary>
        /// P7签名
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="strmsg"></param>
        /// <returns></returns>
        public bool SignOrderItemP7(string strContent, string strCerId, string strpwd, out string strmsg)
        {
            strmsg = "";
            if (!InitCa(out strmsg)) return false;
            InitCaConnection(out strmsg);
            if (!"".Equals(strmsg))
            {
                return false;
            }
            //核对用户工号
            _userId = GetCertInfoByOId(certBase64, "2.4.16.11.7.3");
            if (!_userId.Equals(strCerId.ToString()))
            {
                strmsg = "系统用户ID与CA的keyID不一致！";
                return false;
            }
            int usbLogin = medicalTK.SOF_Login(cerlst[0], strpwd);
            if (usbLogin != 0)
            {
                strmsg = "密码错误：" + medicalTK.GetLastError();
                return false;
            }
            #region 签名值

            string encryptData = medicalTK.SOF_SignDataByP7(cerlst[0], strContent);
            if ("".Equals(encryptData))
            {
                strmsg = "P7签名错误码：" + medicalTK.GetLastError();
                return false;
            }
            #endregion

            #region 验证签名
            int iRet = vstkClientPro.SOF_VerifySignedDataByP7(encryptData);
            if (iRet != 0)
            {
                strmsg = "P7验签失败，错误码：" + vstkClientPro.SOF_GetLastError().ToString();
                return false;
            }
            #endregion

            return true;

        }
        #endregion

        #region 签名与时间戳验证
        public bool OrderSign(string strContent, string strUserId,string strPwd,string strInDept,out string strmsg)
        {
            #region 验证用户登录
            strmsg = "";
            if (!LoginUser(strUserId, strPwd, out strmsg))
            {
                strmsg = "系统登录者与U-Key用户不一致!";
                return false;
            }
            #endregion

            #region 产生原文

            #endregion

            #region 签名值
            string encryptData = medicalTK.SOF_SignData(cerlst[0], strContent);
            if ("".Equals(encryptData))
            {
                strmsg = "P1签名错误码：" + medicalTK.GetLastError();
                return false;
            }
            #endregion

            #region 验证签名
            int iRet = vstkClientPro.SOF_VerifySignedData(certBase64, strContent, encryptData);
            if (iRet != 0)
            {
                strmsg = "P1验签失败，错误码：" + medicalTK.GetLastError();
                return false;
            }
            #endregion

            #region 时间戳验证
            string time = CheckTime(strContent, out strmsg);
            if ("".Equals(time))
            {
                strmsg = "时间戳核对失败！";
                return false;
            }
            #endregion

            #region 存储签名
            //保存格式:医嘱号：证书base64位，内容，签名值，时间戳id用户id
            try
            {
                //RelationalDatabase database = FrmMdiMain.Database;
                //ParameterEx[]  parameter=new ParameterEx[8];
                //parameter[0].Text = "@base64";
                //parameter[0].Value = certBase64;
                //parameter[1].Text = "@context";
                //parameter[1].Value = strContent;
                //parameter[2].Text = "@encryptData";
                //parameter[2].Value = encryptData;
                //parameter[3].Text = "@time";
                //parameter[3].Value = time;
                //parameter[4].Text = "@userid";
                //parameter[4].Value = strUserId;
                //parameter[5].Text = "@deptId";
                //parameter[5].Value = strInDept;
                //parameter[6].Text = "@errcode";
                //parameter[6].ParaSize = 50;
                //parameter[6].ParaDirection = ParameterDirection.Output;
                //parameter[7].Text = "@errtext";
                //parameter[7].ParaSize = 50;
                //parameter[7].ParaDirection = ParameterDirection.Output;
                //database.DoCommand("sp_saveOrderSign", parameter, 30);
                //strmsg = parameter[7].Value.ToString();
            }
            catch (Exception err)
            {
                strmsg = "存储签名错误:" + err.Message;
                return false;
            }
            #endregion
            return true;

        }

        /// <summary>
        /// 核对时间戳
        /// </summary>
        /// <param name="originData"></param>
        /// <param name="strmsg"></param>
        /// <returns></returns>
        public string CheckTime(string originData, out string strmsg)
        {
            string str_response = "";
            strmsg = "";
            try
            {
                svsClient = new SVS_S_SDK_COMLib.CSVS_S_SDKClass();
                int s = svsClient.SOF_SetServerInfo(_conTimestampEntity.IP, _conTimestampEntity.Port, _conTimestampEntity.Uri, 30);
            }
            catch (Exception err)
            {
                strmsg = "设置时间戳服务器配置失败：" + err.Message;
                return "";
            }
            try
            {
                //设置模式
                svsClient.SOF_SetTSASignMode(1);
            }
            catch (Exception err)
            {
                strmsg = "设置时间戳模式失败:" + err.Message;
                return "";

            }
            try
            {

                str_response = svsClient.SOF_CreateTimeStampResponse(originData);
                if (str_response == null || str_response.Equals(""))
                {
                    strmsg = "时间戳响应失败:" + svsClient.SOF_GetErrorMsg();
                    return "";
                }
            }
            catch (Exception err)
            {
                strmsg = "时间戳响应失败：" + err.Message;
                return "";
            }
            //string strResult = "";
            //try
            //{
            //    strResult = svsClient.SOF_VerifyTimeStamp(str_response);

            //}
            //catch (Exception err)
            //{
            //     strmsg="验证时间戳错误:"+err.Message;
            //     return "";
            //}
            return str_response;
        }

        #endregion

        #region  CA 函数相关操作
        /// <summary>
        /// P7签名
        /// </summary>
        /// <param name="certId">证书标识</param>
        /// <param name="flatData">原文</param>
        /// <returns>P7签名值</returns>
        private string P7Sign(string certId, string flatData)
        {
            return medicalTK.SOF_SignDataByP7(certId, flatData);
        }
        /// <summary>
        /// 获取8位随机数
        /// </summary>
        /// <returns>8位随机数</returns>
        private string GetRandom()
        {
            return medicalTK.SOF_GenRandom(8);
        }
        /// <summary>
        /// 获取P7签名信息
        /// </summary>
        /// <param name="encryptData">密文</param>
        /// <param name="iType">信息类别</param>
        /// <returns>iType锁对应的信息</returns>
        public string GetDataInfoByP7(string encryptData, int iType)
        {
            string strRet = vstkClientPro.SOF_GetP7SignDataInfo(encryptData, iType);
            byte[] outputb = Convert.FromBase64String(strRet);
            strRet = Encoding.Default.GetString(outputb);
            return strRet;
        }
        /// <summary>
        /// 获取扩展信息
        /// </summary>
        /// <param name="certIdBase64">证书BASE64串</param>
        /// <param name="oId">扩展信息标识</param>
        /// <returns>扩展信息内容</returns>
        public string GetCertInfoByOId(string certIdBase64, string oId)
        {
            string strRet = vstkClientPro.SOF_GetCertInfoByOid(certIdBase64, oId);
            byte[] outputb = Convert.FromBase64String(strRet);
            strRet = Encoding.Default.GetString(outputb);
            return strRet;
        }

        #endregion
    }
}
