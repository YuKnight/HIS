using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace TrasenClasses.GeneralClasses
{
    /// <summary>
    /// Crypto 的摘要说明。
    /// 采用Sington模式，系统中只能有一个副本
    /// </summary>
    public class Crypto
    {
        private static Crypto _instance = null;
        private SymmetricAlgorithm mobjCryptoService;
        private string r1, r2, r3, r4, r5;	//随机产生5个0-9的数字

        private Crypto()
        {
            mobjCryptoService = new RijndaelManaged();
            r1 = "";
            r2 = "";
            r3 = "";
            r4 = "";
            r5 = "";
        }
        /// <summary>
        /// 获取Crypto实例
        /// </summary>
        /// <returns></returns>
        public static Crypto Instance()
        {
            if (Crypto._instance == null)
            {
                Crypto._instance = new Crypto();
            }
            return Crypto._instance;
        }
        /// <summary>
        /// 对明文进行加密，返回加密后的密文 
        /// </summary>
        /// <param name="source">密码明文</param>
        /// <returns></returns>
        public string Cryp(string source)
        {
            int i, code = 2, odd = -1;
            string result = "";
            for (i = 0; i < source.Trim().Length; i++)
            {
                code *= odd;
                result += Convert.ToChar((int)Convert.ToChar(source.Trim().Substring(i, 1)) + code).ToString();
            }
            return result.Trim();
        }
        /// <summary>
        /// 对密文进行解密，返回明文
        /// </summary>
        /// <param name="cryptograph">密码密文</param>
        /// <returns></returns>
        public string UnCryp(string cryptograph)
        {
            int i, code = -2, odd = -1;
            string result = "";
            for (i = 0; i < cryptograph.Trim().Length; i++)
            {
                code *= odd;
                result += Convert.ToChar((int)Convert.ToChar(cryptograph.Trim().Substring(i, 1)) + code).ToString();
            }
            return result.Trim();
            //			return cryptograph;
        }
        /// <summary>
        /// 获得初始Key
        /// </summary>
        /// <returns></returns>
        private byte[] GetLegalKey()
        {
            string sTemp = "Guz(%" + r1 + "&h7H$y" + r2 + "04~FtT5&" + r3 + "]@" + r4 + "6*/[" + r5 + ")7*/";
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
            {
                sTemp = sTemp.Substring(0, KeyLength);
            }
            else if (sTemp.Length < KeyLength)
            {
                sTemp = sTemp.PadRight(KeyLength, ' ');
            }
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>
        /// 获得初始向量IV
        /// </summary>
        /// <returns>初试向量IV</returns>
        private byte[] GetLegalIV()
        {
            string sTemp = "E" + r1 + "r" + r2 + "%r" + r3 + "1$" + r4 + "U^#@" + r5 + "*";
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
            {
                sTemp = sTemp.Substring(0, IVLength);
            }
            else if (sTemp.Length < IVLength)
            {
                sTemp = sTemp.PadRight(IVLength, ' ');
            }
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        public string Encrypto(string Source)
        {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            MemoryStream ms = new MemoryStream();
            //随机产生5个0-9之间的数字，然后插入初始Key的固定部分
            r1 = Convert.ToString((int)((new Random()).NextDouble() * 10));
            r2 = Convert.ToString((int)((new Random()).NextDouble() * 10));
            r3 = Convert.ToString((int)((new Random()).NextDouble() * 10));
            r4 = Convert.ToString((int)((new Random()).NextDouble() * 10));
            r5 = Convert.ToString((int)((new Random()).NextDouble() * 10));
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut) + Cryp(r1 + r2 + r3 + r4 + r5);
        }
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="Source">待解密的串</param>
        /// <returns>经过解密的串</returns>
        public string Decrypto(string Source)
        {
            try
            {
                int len = Source.Length;
                if (len < 5)				//非Encrypto方法加密后的密文
                {
                    return "";
                }
                string rString = UnCryp(Source.Substring(len - 5, 5));
                r1 = rString.Substring(0, 1);
                r2 = rString.Substring(1, 1);
                r3 = rString.Substring(2, 1);
                r4 = rString.Substring(3, 1);
                r5 = rString.Substring(4, 1);
                byte[] bytIn = Convert.FromBase64String(Source.Substring(0, len - 5));
                MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
                mobjCryptoService.Key = GetLegalKey();
                mobjCryptoService.IV = GetLegalIV();
                ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch (Exception err)
            {
                MessageBox.Show("解密失败：密文【" + Source + "】非Encrypto方法加密而成\n" + err.Message, "错误");
                return "";
            }
        }

    }
}
