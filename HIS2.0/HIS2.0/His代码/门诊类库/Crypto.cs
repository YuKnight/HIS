using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace ts_mz_class
{
    public class Crypto
    {
        private static Crypto _instance = null;
        private SymmetricAlgorithm mobjCryptoService;
        private string r1, r2, r3, r4, r5;	//随机产生5个0-9的数字
        //		private int policy;
        public static string _key1;

        public static string _key2;
 

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
            //			return source;
        }
        /// <summary>
        /// 对密文进行解密，返回明文
        /// </summary>
        /// <param name="cryptograph">密码密文</param>
        /// <returns></returns>
        public string UnCryp(string cryptograph)
        {
            int num2 = -2;
            int num3 = -1;
            string str = "";
            for (int i = 0; i < cryptograph.Trim().Length; i++)
            {
                num2 *= num3;
                str = str + Convert.ToChar((int)(Convert.ToChar(cryptograph.Trim().Substring(i, 1)) + num2)).ToString();
            }
            return str.Trim();

            //			return cryptograph;
        }
        /// <summary>
        /// 获得初始Key
        /// </summary>
        /// <returns></returns>
        private byte[] GetLegalKey(string key)
        {
            string s = key;
            this.mobjCryptoService.GenerateKey();
            int length = this.mobjCryptoService.Key.Length;
            if (s.Length > length)
            {
                s = s.Substring(0, length);
            }
            else if (s.Length < length)
            {
                s = s.PadRight(length, ' ');
            }
            return Encoding.ASCII.GetBytes(s);
        }

 

 

        /// <summary>
        /// 获得初始向量IV
        /// </summary>
        /// <returns>初试向量IV</returns>
        private byte[] GetLegalIV(string iv)
        {
            string s = iv;
            this.mobjCryptoService.GenerateIV();
            int length = this.mobjCryptoService.IV.Length;
            if (s.Length > length)
            {
                s = s.Substring(0, length);
            }
            else if (s.Length < length)
            {
                s = s.PadRight(length, ' ');
            }
            return Encoding.ASCII.GetBytes(s);
        }

 

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        public string Encrypto(string Source, string Key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Source);
            MemoryStream stream = new MemoryStream();
            this.r1 = Convert.ToString((int)(new Random().NextDouble() * 10.0));
            this.r2 = Convert.ToString((int)(new Random().NextDouble() * 10.0));
            this.r3 = Convert.ToString((int)(new Random().NextDouble() * 10.0));
            this.r4 = Convert.ToString((int)(new Random().NextDouble() * 10.0));
            this.r5 = Convert.ToString((int)(new Random().NextDouble() * 10.0));
            string str = this.Cryp(this.r1 + this.r2 + this.r3 + this.r4 + this.r5);
            this.mobjCryptoService.Key = this.GetLegalKey(Key);
            this.mobjCryptoService.IV = this.GetLegalIV(this.r1 + this.r2 + this.r3 + this.r4 + this.r5);
            ICryptoTransform transform = this.mobjCryptoService.CreateEncryptor();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            stream.Close();
            string str2 = Convert.ToBase64String(stream.ToArray());
            string str3 = "";
            for (int i = 0; i < str.Length; i++)
            {
                str3 = str3 + str2.Substring(i, 1) + str.Substring(i, 1);
                if (i == (str.Length - 1))
                {
                    str3 = str3 + str2.Substring(i + 1, str2.Length - (i + 1));
                }
            }
            return str3;
        }

 

 

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="Source">待解密的串</param>
        /// <returns>经过解密的串</returns>
        public string Decrypto(string Source, string Key)
        {
            string str3;
            try
            {
                if (Source.Length < 10)
                {
                    return "";
                }
                string str = "";
                string cryptograph = "";
                for (int i = 0; i < 5; i++)
                {
                    str = str + Source.Substring(2 * i, 1);
                    cryptograph = cryptograph + Source.Substring((2 * i) + 1, 1);
                }
                byte[] buffer = Convert.FromBase64String(str + Source.Substring(10, Source.Length - 10));
                MemoryStream stream = new MemoryStream(buffer, 0, buffer.Length);
                this.mobjCryptoService.Key = this.GetLegalKey(Key);
                this.mobjCryptoService.IV = this.GetLegalIV(this.UnCryp(cryptograph));
                ICryptoTransform transform = this.mobjCryptoService.CreateDecryptor();
                CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
                str3 = new StreamReader(stream2).ReadToEnd();
            }
            catch (Exception exception)
            {
                throw new Exception("解密失败：密文【" + Source + "】不合法。\n" + exception.Message);
            }
            return str3;
        }

 


    }
}
