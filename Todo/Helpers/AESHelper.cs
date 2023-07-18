using Todo.Helpers;
using NeoSmart.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Helpers
{
    public class AESHelper
    {
        //private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        // 長度必須32
        private const string privateKey = "1234567890ABCDEFGHIJKL0987654321";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DataToEncrypt"></param>
        /// <returns>
        ///     LCMessage Object
        ///     Data回傳內容為MD5編碼的AES256加密字串    
        /// </returns>
        public LCMessage Encrypt(string _DataToEncrypt)
        {
            try
            {
                using (AesCryptoServiceProvider Aes = new AesCryptoServiceProvider())
                {
                    string encryptedString = "";
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                    byte[] Key = Encoding.UTF8.GetBytes(privateKey);
                    byte[] IV = md5.ComputeHash(Encoding.UTF8.GetBytes(privateKey));
                    byte[] dataByteArray = Encoding.UTF8.GetBytes(_DataToEncrypt);
                    Aes.Key = Key;
                    Aes.IV = IV;
                    Aes.Padding = PaddingMode.PKCS7;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, Aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(dataByteArray, 0, dataByteArray.Length);
                            cs.FlushFinalBlock();
                            encryptedString = UrlBase64.Encode(ms.ToArray());
                            // 2018-JAN-20 Onader.Wu iOS端說最後的==有少，解不出來，所以嘗試加上這個試試看
                            encryptedString = encryptedString.PadRight(encryptedString.Length + (4 - encryptedString.Length % 4) % 4, '=');
                        }
                    }

                    return new LCMessage() { StatusCode = LCStatusCode.OK, StatusDesc = "", Data = encryptedString };
                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex, ex.Message);
                return new LCMessage() { StatusCode = LCStatusCode.ERROR, StatusDesc = ex.Message, Data = null };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DataToDecrypt">欲解密字串</param>
        /// <returns>
        ///     LCMessage Object
        ///     Data為解密後字串
        /// </returns>
        public LCMessage Decrypt(string _DataToDecrypt)
        {
            try
            {
                string decryptedString = "";
                byte[] inputByteArray = UrlBase64.Decode(_DataToDecrypt);
                using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
                {
                    csp.Padding = PaddingMode.PKCS7;
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                    byte[] Key = Encoding.UTF8.GetBytes(privateKey);
                    byte[] IV = md5.ComputeHash(Encoding.UTF8.GetBytes(privateKey));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, csp.CreateDecryptor(Key, IV), CryptoStreamMode.Write))
                        {
                            cs.Write(inputByteArray, 0, inputByteArray.Length);
                            cs.FlushFinalBlock();
                            decryptedString = Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                    return new LCMessage() { StatusCode = LCStatusCode.OK, StatusDesc = "", Data = decryptedString };
                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex, ex.Message);
                return new LCMessage() { StatusCode = LCStatusCode.ERROR, StatusDesc = ex.Message, Data = null };
            }
        }

        private static String toHex(byte[] buf)
        {
            if (buf == null)
                return "";
            StringBuilder result = new StringBuilder(2 * buf.Length);
            for (int i = 0; i < buf.Length; i++)
            {
                appendHex(result, buf[i]);
            }
            return result.ToString();
        }

        private static String HEX = "0123456789ABCDEF";

        private static void appendHex(StringBuilder sb, byte b)
        {
            sb.Append(HEX[((b >> 4) & 0x0f)]).Append(HEX[(b & 0x0f)]);
        }
    }
}
