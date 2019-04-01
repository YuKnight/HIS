using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HBCADemo
{
	public partial class Form1 : Form
	{

		HBCA.USBKeyClient usbKey;
		HBCA.VSTKClient vstkClient;
		HBCA.SealClient sealClient;
		HBCA.TSSClient tssClient;
		public Form1()
		{
			InitializeComponent();
			
		}

		private void btn_login_Click(object sender, EventArgs e)
		{
			try
			{
				//服务器IP
				string IPAddr = tbox_IP.Text;
				//服务器端口
				int iPort = int.Parse(tbox_Port.Text);
				vstkClient = new HBCA.VSTKClient(IPAddr, iPort);

				string certId = cbox_certId.Text;
				string password = tbox_password.Text;
				//UKEY 密码验证
				int usbLogin = usbKey.Login(certId, password);
				//验证通过
				if (0 == usbLogin)
				{
					//证书BASE64串
					string certBase64 = usbKey.GetCertBase64(certId);
					tbox_certBase64.Text = certBase64;
					//获取随机码
					string random = usbKey.GetRandom();
					//对随机码进行P7签名
					string encryptData = usbKey.P7Sign(certId, random);
					if ("".Equals(encryptData))
					{
						MessageBox.Show("P7签名出错，错误码：" + usbKey.GetLastError());
						return;
					}
					int iRet;
					//服务端验证P7签名数据
					iRet = vstkClient.P7Verify(encryptData);

					if (iRet != 0)
					{
						MessageBox.Show("P7验签失败，返回值：" + usbKey.GetLastError());
						return;
					}
					//P7验证通过 进一步验证随机数是否正确
					string randomServer = vstkClient.GetDataInfoByP7(encryptData, 1);
					//随机数验证通过
					if (random.Equals(randomServer))
					{
						//验证通过，获取工号
						string userId = vstkClient.GetCertInfoByOId(certBase64, "2.4.16.11.7.3");
						System.Windows.Forms.MessageBox.Show("登陆成功！工号：" + userId);
						this.Text = "HBCA Demo（工号：" + userId + "）";
						tbox_sealImageId.Text = userId;//user id is the seal number
						return;
					}
					else if ("".Equals(randomServer))
					{
						MessageBox.Show("获取原文信息失败，返回值：" + usbKey.GetLastError());
						return;
						
					}
					else if (!random.Equals(randomServer))
					{
						MessageBox.Show("解析原文不一致，解析值：" + randomServer);
						return;
					}
					
					else
					{
						MessageBox.Show("未知错误，错误码：" + vstkClient.GetLastError());
						return;
					}
				}
				else
				{
					MessageBox.Show("错误码：" + usbKey.GetLastError());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				//初始化
				usbKey = new HBCA.USBKeyClient();
				sealClient = new HBCA.SealClient();
				//initUserList();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void initUserList()
		{
			//获取证书列表
			List<string> list = usbKey.GetUserList();
			cbox_certId.Items.Clear();
			if (list == null || list.Count == 0)
			{
				MessageBox.Show("请确认是否插入UKEY");
				return;
			}
			foreach (string user in list)
			{
				cbox_certId.Items.Add(user);
			}
		}

		

		private void cbox_certId_DropDown(object sender, EventArgs e)
		{
			try
			{
				//初始化证书列表
				initUserList();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

		}

		private void btn_certBase64_Click(object sender, EventArgs e)
		{
			try
			{
				//证书标识
				string certId = cbox_certId.Text;
				//证书BASE64串
				string certBase64 = usbKey.GetCertBase64(certId);
				tbox_certBase64.Text = certBase64;
				if ("".Equals(certBase64))
				{
					MessageBox.Show("错误码：" + usbKey.GetLastError());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_P1Sign_Click(object sender, EventArgs e)
		{
			try
			{
				//证书标识
				string certId = cbox_certId.Text;
				//原文
				string flatData = tbox_flatData.Text;
				//P1签名
				string encryptData = usbKey.P1Sign(certId, flatData);
				if ("".Equals(encryptData))
				{
					MessageBox.Show("错误码：" + usbKey.GetLastError());
					return;
				}
				tbox_result.Text = encryptData;
				MessageBox.Show("P1签名成功！");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_P7Sign_Click(object sender, EventArgs e)
		{
			try
			{
				//证书标识
				string certId = cbox_certId.Text;
				//原文
				string flatData = tbox_flatData.Text;
				//P7签名
				string encryptData = usbKey.P7Sign(certId, flatData);
				if ("".Equals(encryptData))
				{
					MessageBox.Show("错误码：" + usbKey.GetLastError());
					return;
				}
				tbox_result.Text = encryptData;
				MessageBox.Show("P7签名成功！");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_P1Verify_Click(object sender, EventArgs e)
		{
			try
			{
				//证书标识
				string certId = cbox_certId.Text;
				//证书BASE64串
				string certBase64 = tbox_certBase64.Text;
				string flatData = tbox_flatData.Text;
				string encryptData = tbox_result.Text;
				int iRet = -1;
				iRet = vstkClient.P1Verify(certBase64, flatData, encryptData);
				if (0 != iRet)
				{
					MessageBox.Show("P1验签失败，错误码：" + usbKey.GetLastError());
					return;
				}
				MessageBox.Show("P1验签成功！");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_P7Verify_Click(object sender, EventArgs e)
		{
			try
			{
				//证书标识
				string certId = cbox_certId.Text;
				//密文
				string encryptData = tbox_result.Text;
				int iRet = -1;
				//P7验签
				iRet = vstkClient.P7Verify(encryptData);
				if (0 != iRet)
				{
					MessageBox.Show("P7验签失败，错误码：" + usbKey.GetLastError());
					return;
				}
				string resolveData = vstkClient.GetDataInfoByP7(encryptData, 1);
				tbox_result.Text =resolveData;
				MessageBox.Show("P7验签成功！");

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_sealData_Click(object sender, EventArgs e)
		{
			try
			{
				//印章标识
				string sealId = tbox_sealImageId.Text;
				//证书标识
				string certId = cbox_certId.Text;
				//原文
				string flatData = tbox_flatData.Text;
				int iFlag = 0;
				//签章并获取签章结果唯一标识
				string sealResultId = sealClient.SignSealData(sealId, certId, flatData, iFlag);
				tbox_sealResultId.Text = sealResultId;
				//获取签章信息
				string sealInfo = sealClient.GetSealInfo(sealResultId, 0);
				tbox_result.Text = sealInfo;
				if ("".Equals(sealResultId))
				{
					MessageBox.Show("签章失败！");
				}
			}
			catch (Exception ex)
			{
				
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_verifySealData_Click(object sender, EventArgs e)
		{
			try
			{
				string sealResultId = tbox_sealResultId.Text;
				//印章标识
				string sealId = tbox_sealImageId.Text;
				//证书标识
				string certId = cbox_certId.Text;
				string flatData = tbox_flatData.Text;
				//获取签章信息
				string pcCertData = sealClient.GetSealInfo(sealResultId, 2);
				string pcSignData = sealClient.GetSealInfo(sealResultId, 1);
				string pcSealData = sealClient.GetSealInfo(sealResultId, 4);
				int iFlag = 0;
				int iRet = sealClient.VerifySealData(pcCertData, flatData, pcSignData, pcSealData, iFlag);
				if (iRet == 0)
				{
					StringBuilder sb = new StringBuilder();
					sb.AppendLine("签章结果编号：" + sealResultId);
					sb.AppendLine("签名值：" + sealClient.GetSealInfo(sealResultId, 1));
					sb.AppendLine("签名证书：" + sealClient.GetSealInfo(sealResultId, 2));
					sb.AppendLine("印章图片：" + sealClient.GetSealInfo(sealResultId, 3));
					sb.AppendLine("印章数据：" + sealClient.GetSealInfo(sealResultId, 4));
					sb.AppendLine("签名时间：" + sealClient.GetSealInfo(sealResultId, 5));
					sb.AppendLine("印章名称:" + sealClient.GetSealInfo(sealResultId, 6));
					sb.AppendLine("印章编号:" + sealClient.GetSealInfo(sealId, 7));
					tbox_result.Text = sb.ToString();
					MessageBox.Show("验签成功！");
				}
				MessageBox.Show(sealClient.GetSealInfo(sealResultId, 2));
				//int iret = vstkClient.P1Verify(param1, flatData, sealClient.GetSealInfo(sealResultId, 1));
				int iret = vstkClient.P1Verify(sealClient.GetSealInfo(sealResultId, 2), flatData, sealClient.GetSealInfo(sealResultId, 1));

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_sealImage_Click(object sender, EventArgs e)
		{
			try
			{
				//证书标识
				string certId = cbox_certId.Text;
				//印章标识
				string sealId = tbox_sealImageId.Text;
				//印章BASE64串
				string imageBase64 = sealClient.GetKeyPictureEx(certId, sealId);
				tbox_sealImageBase64.Text = imageBase64;
				if ("".Equals(imageBase64))
				{
					MessageBox.Show("获取图片信息失败！");
					return;
				}

				byte[] imgBytes = Convert.FromBase64String(imageBase64);
				using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"e:\NETSealImage.txt"))
				{
					for (int i = 0; i < imgBytes.Length; i++)
					{
						sw.Write((int)imgBytes[i]);
					}
					sw.Close();
				}
				System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(imgBytes);
				Image image = Image.FromStream(memoryStream);

				Form f1 = new Form();
				f1.StartPosition = FormStartPosition.CenterScreen;
				f1.Text = "签章图片";
				f1.Height = image.Height;
				f1.Width = image.Width;
				f1.MaximizeBox = false;
				f1.MinimizeBox = false;
				f1.FormBorderStyle = FormBorderStyle.FixedSingle;
				PictureBox picBox = new PictureBox();
				Panel p = new Panel();
				p.Controls.Add(picBox);
				p.Dock = DockStyle.Fill;
				picBox.Dock = DockStyle.Fill;
				
				picBox.Image = image;
				f1.Controls.Add(p);

				f1.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_sealVerifyFile_Click(object sender, EventArgs e)
		{
			try
			{
				string sealResultId = tbox_sealResultId.Text;
				//印章标识
				string sealId = tbox_sealImageId.Text;
				//证书标识
				string certId = cbox_certId.Text;
				//文件路径
				string filePath = tbox_sourceFile.Text;
				//获取签章信息
				string pcCertData = sealClient.GetSealInfo(sealResultId, 2);
				string pcSignData = sealClient.GetSealInfo(sealResultId, 1);
				string pcSealData = sealClient.GetSealInfo(sealResultId, 4);
				int iFlag = 0;
				//验证文件签章
				int iRet = sealClient.VerifySealFile(pcCertData, filePath, pcSignData, pcSealData, iFlag);
				//vstkClient.P7Verify
				if (iRet == 0)
				{
					StringBuilder sb = new StringBuilder();
					sb.AppendLine("签章结果编号：" + sealResultId);
					sb.AppendLine("签名值：" + sealClient.GetSealInfo(sealResultId, 1));
					sb.AppendLine("签名证书：" + sealClient.GetSealInfo(sealResultId, 2));
					sb.AppendLine("印章图片：" + sealClient.GetSealInfo(sealResultId, 3));
					sb.AppendLine("印章数据：" + sealClient.GetSealInfo(sealResultId, 4));
					sb.AppendLine("签名时间：" + sealClient.GetSealInfo(sealResultId, 5));
					sb.AppendLine("印章名称:" + sealClient.GetSealInfo(sealResultId, 6));
					sb.AppendLine("印章编号:" + sealClient.GetSealInfo(sealId, 7));
					tbox_result.Text = sb.ToString();
					MessageBox.Show("验签成功！");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_sealFile_Click(object sender, EventArgs e)
		{
			try
			{
				//印章标识
				string sealId = tbox_sealImageId.Text;
				//证书标识
				string certId = cbox_certId.Text;
				//文件路径
				string filePath = tbox_sourceFile.Text;
				int iFlag = 0;
				//文件签章
				string sealResultId = sealClient.SignSealFile(sealId, certId, filePath, iFlag);
				tbox_sealResultId.Text = sealResultId;
				string sealInfo = sealClient.GetSealInfo(sealResultId, 0);
				tbox_result.Text = sealInfo;
				if ("".Equals(sealResultId))
				{
					MessageBox.Show("签章失败！");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_TSS_Click(object sender, EventArgs e)
		{
			try
			{
				string serverIP = tbox_IP_TSS.Text;
				int iPort = Convert.ToInt32(tbox_Port_TSS.Text);
				string URI = tbox_URI_TSS.Text;
				tssClient = new HBCA.TSSClient(serverIP, iPort, URI, 30);
				string flatData = tbox_flatData.Text;
				string result = tssClient.CreateTSS(flatData);
				if (result == null || "".Equals(result))
				{
					MessageBox.Show("时间戳创建失败，" + tssClient.GetErrorMsg());
				}
				tbox_TSSId.Text = result;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_GetTSSInfo_Click(object sender, EventArgs e)
		{
			try
			{
				string tssId = tbox_TSSId.Text;
				string result = tssClient.GetTSSInfo(tssId);
				MessageBox.Show("时间戳：" + result);
				//if (result == null || "".Equals(result))
				//{
				//    MessageBox.Show("时间戳创建失败，" + tssClient.GetErrorMsg());
				//}
				//tbox_TSSId.Text = result;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_verifyTSS_Click(object sender, EventArgs e)
		{
			try
			{
				string tssId = tbox_TSSId.Text;
				string result = tssClient.VerifyTSS(tssId);
				if (result == null || "".Equals(result))
				{
					MessageBox.Show("时间戳验签失败，" + tssClient.GetErrorMsg());
				}
				else
				{
					MessageBox.Show("时间戳验签成功，" + result);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
