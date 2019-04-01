using System;
using System.Collections.Generic;
using System.Text;

namespace HBCA
{
	public class USBKeyClient
	{
		JITUsbKeyComLib.MedicalTKClass medicalTK;
		public USBKeyClient() 
		{
			medicalTK = new JITUsbKeyComLib.MedicalTKClass();
		}
		/// <summary>
		/// 获取证书列表
		/// 卫生测试001||Haitai HaiKey HID 0#JIT#HBCAAPPLICATION_RSA#JIT#3BB9CDF1-4A07-4E72-AAFA-C5D22409B2A7
		/// </summary>
		/// <returns>证书用户信息List</returns>
		public List<string> GetUserList()
		{
			List<string> list = new List<string>();
			//获取USBKey用户
			string userArray = medicalTK.SOF_GetUserList();
			foreach (string user in userArray.Split(new char[] { '&', '&', '&' }))
			{
				if ("".Equals(user))
				{
					continue;
				}
				list.Add(user);
			}
			if (list.Count == 0) return null;
			
			return list;
		}
		/// <summary>
		/// 登陆
		/// </summary>
		/// <param name="certId">证书标识</param>
		/// <param name="password">USB KEY PIN密码</param>
		/// <returns>0 正确</returns>
		public int Login(string certId, string password)
		{
			return medicalTK.SOF_Login(certId, password);
		}
		/// <summary>
		/// 获取证书BASE64字符串
		/// </summary>
		/// <param name="certId">证书标识</param>
		/// <returns>证书BASE64字符串</returns>
		public string GetCertBase64(string certId)
		{
			return medicalTK.SOF_ExportUserCert(certId);
		}
		/// <summary>
		/// P1签名
		/// </summary>
		/// <param name="certId">证书标识</param>
		/// <param name="flatData">原文</param>
		/// <returns>P1签名值</returns>
		public string P1Sign(string certId, string flatData)
		{
			return medicalTK.SOF_SignData(certId, flatData);
		}
		/// <summary>
		/// P7签名
		/// </summary>
		/// <param name="certId">证书标识</param>
		/// <param name="flatData">原文</param>
		/// <returns>P7签名值</returns>
		public string P7Sign(string certId, string flatData)
		{
			return medicalTK.SOF_SignDataByP7(certId, flatData);
		}
		/// <summary>
		/// 获取8位随机数
		/// </summary>
		/// <returns>8位随机数</returns>
		public string GetRandom()
		{
			return medicalTK.SOF_GenRandom(8);
		}
		/// <summary>
		/// 获取最新错误码
		/// </summary>
		/// <returns>最新错误码</returns>
		public uint GetLastError()
		{
			return medicalTK.GetLastError();
		}
	}


	public class VSTKClient
	{
		JITClientCOMAPILib.JITVSTKClientProcClass vstkClientPro;
		public VSTKClient(string IPAddr,int iPort)
		{
			vstkClientPro = new JITClientCOMAPILib.JITVSTKClientProcClass();
			int iRet = -1;
			//设置参数
			iRet = vstkClientPro.SOF_InitServerConnectEx(IPAddr, iPort);
			if (iRet != 0)
			{
				System.Windows.Forms.MessageBox.Show("连接服务器失败，错误码：" + vstkClientPro.SOF_GetLastError());
			}
		}
		/// <summary>
		/// P1签名验证
		/// </summary>
		/// <param name="certBase64">证书BASE64串</param>
		/// <param name="flatData">原文</param>
		/// <param name="encryptData">密文</param>
		/// <returns>0 验证成功</returns>
		public int P1Verify(string certBase64, string flatData, string encryptData)
		{
			return vstkClientPro.SOF_VerifySignedData(certBase64, flatData, encryptData);
		}
		/// <summary>
		/// P7签名验证
		/// </summary>
		/// <param name="encryptData">密文</param>
		/// <returns>0 验证成功</returns>
		public int P7Verify(string encryptData)
		{
			return vstkClientPro.SOF_VerifySignedDataByP7(encryptData);
		}
		/// <summary>
		/// 获取P7签名信息
		/// </summary>
		/// <param name="encryptData">密文</param>
		/// <param name="iType">信息类别</param>
		/// <returns>iType锁对应的信息</returns>
		public string GetDataInfoByP7(string encryptData, int iType)
		{
			string strRet =  vstkClientPro.SOF_GetP7SignDataInfo(encryptData, iType);
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
		/// <summary>
		/// 获取最新错误码
		/// </summary>
		/// <returns>最新错误码</returns>
		public int GetLastError()
		{
			return vstkClientPro.SOF_GetLastError();
		}
	}

	public class SealClient
	{
		HBCA_SOFSEALLib.SealClass seal;
		public SealClient()
		{
			seal = new HBCA_SOFSEALLib.SealClass();
		}
		/// <summary>
		/// 原文签章
		/// </summary>
		/// <param name="sealId">印章标识</param>
		/// <param name="certId">证书标识</param>
		/// <param name="flatData">原文</param>
		/// <param name="flag">签章模式 0</param>
		/// <returns>签章结果标识</returns>
		public string SignSealData(string sealId,string certId,string flatData,int flag)
		{
			return seal.SOF_SignSealData(sealId, certId, flatData, flag);
		}
		/// <summary>
		/// 验证原文签章
		/// </summary>
		/// <param name="pcCertData">签名证书-GetSealInfo类型2</param>
		/// <param name="pcInData">原文</param>
		/// <param name="pcSignData">签名值-GetSealInfo类型1</param>
		/// <param name="pcSealData">印章数据</param>
		/// <param name="flag">签章模式 0</param>
		/// <returns>0 验证成功</returns>
		public int VerifySealData(string pcCertData,string pcInData,string pcSignData,string pcSealData,int flag)
		{
			return seal.SOF_VerifySealData(pcCertData, pcInData, pcSignData, pcSealData, flag);
		}
		/// <summary>
		/// 文件签章
		/// </summary>
		/// <param name="sealId">印章标识</param>
		/// <param name="certId">证书标识</param>
		/// <param name="filePath">文件路径</param>
		/// <param name="flag">签章模式 0</param>
		/// <returns>签章结果标识</returns>
		public string SignSealFile(string sealId, string certId, string filePath, int flag)
		{
			return seal.SOF_SignSealFile(sealId, certId, filePath, flag);
		}
		/// <summary>
		/// 验证文件签章
		/// </summary>
		/// <param name="pcCertData">签名证书-GetSealInfo类型2</param>
		/// <param name="pcInFile">文件路径</param>
		/// <param name="pcSignData">签名值-GetSealInfo类型1</param>
		/// <param name="pcSealData">印章数据</param>
		/// <param name="flag">签章模式 0</param>
		/// <returns>0 验证成功</returns>
		public int VerifySealFile(string pcCertData, string pcInFile, string pcSignData, string pcSealData, int flag)
		{
			return seal.SOF_VerifySealFile(pcCertData, pcInFile, pcSignData, pcSealData, flag);
		}
		/// <summary>
		/// 获取签章结果数据
		/// </summary>
		/// <param name="sealId">签章结果标识</param>
		/// <param name="type">类型</param>
		/// <returns>类型锁对应的数据内容</returns>
		public string GetSealInfo(string sealId,int type)
		{
			return seal.SOF_GetSealInfo(sealId, type);
		}
		/// <summary>
		/// 获取印章图片
		/// </summary>
		/// <param name="sealId">印章标识</param>
		/// <returns>印章图片BASE64串</returns>
		public string GetKeyPicture(string sealId)
		{
			return seal.SOF_GetKeyPicture(sealId);
		}

		/// <summary>
		/// 获取印章图片Ex
		/// </summary>
		/// <param name="certId">证书标识</param>
		/// <param name="sealId">印章标识</param>
		/// <returns>印章图片BASE64串</returns>
		public string GetKeyPictureEx(string certId,string sealId)
		{
			return seal.SOF_GetKeyPictureEx(certId, sealId);
		}
	}

	public class TSSClient 
	{
		SVS_S_SDK_COMLib.CSVS_S_SDKClass svsClient;
		string serverIP;
		int iPort;
		string URI;
		int iTimeOut;
		public TSSClient(string serverIP,int iPort,string URI,int iTimeOut)
		{
			svsClient = new SVS_S_SDK_COMLib.CSVS_S_SDKClass();
			this.serverIP = serverIP;
			this.iPort = iPort;
			this.URI = URI;
			this.iTimeOut = iTimeOut;

		}
		public string CreateTSS(string data)
		{
			if (0 != svsClient.SOF_SetServerInfo(serverIP, iPort, URI, iTimeOut))
			{
				return "服务器连接失败";
			}
			svsClient.SOF_SetTSASignMode(1);
			string result = "";
			result = svsClient.SOF_CreateTimeStampResponse(data);
			return result;
		}
		public string VerifyTSS(string tssRecordId)
		{
			if (0 != svsClient.SOF_SetServerInfo(serverIP, iPort, URI, iTimeOut))
			{
				return "服务器连接失败";
			}
			svsClient.SOF_SetTSASignMode(1);
			string result = "";
			string data = svsClient.SOF_GetTimeStampData(tssRecordId);
			result = svsClient.SOF_VerifyTimeStamp(data);
			return result;
		}
		public string GetTSSInfo(string tssRecordId)
		{
			if (0 != svsClient.SOF_SetServerInfo(serverIP, iPort, URI, iTimeOut))
			{
				return "服务器连接失败";
			}
			svsClient.SOF_SetTSASignMode(1);
			string result = "";
			result = svsClient.SOF_GetTimeStampData(tssRecordId);
			return result;
		}
		public string GetErrorMsg()
		{
			return svsClient.SOF_GetErrorMsg();
		}
	}
}
