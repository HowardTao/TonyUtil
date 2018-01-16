using System;
using System.Security.Cryptography;
using System.Text;

namespace TonyUtil.Helpers
{

    /// <summary>
    /// TODO
    /// </summary>
   public static class Encrypt
    {
        #region Md5加密
        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static string Md5By16(string value)
        {
            return Md5By16(value, Encoding.UTF8);
        }

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static string Md5By16(string value,Encoding encoding)
        {
            return Md5(value, encoding, 4, 8);
        }

        /// <summary>
        /// Md5加密，返回32位结果
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static string Md5By32(string value)
        {
            return Md5By32(value, Encoding.UTF8);
        }

        /// <summary>
        /// Md5加密，返回32位结果
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static string Md5By32(string value, Encoding encoding)
        {
            return Md5(value, encoding, null, null);
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="value"></param>
        /// <param name="encoding"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string Md5(string value, Encoding encoding, int? startIndex, int? length)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            var md5 = new MD5CryptoServiceProvider();
            string result;
            try
            {
                var hash = md5.ComputeHash(encoding.GetBytes(value));
                result = startIndex == null
                    ? BitConverter.ToString(hash)
                    : BitConverter.ToString(hash, startIndex.SafeValue(), length.SafeValue());
            }
            finally
            {
                md5.Clear();
            }
            return result.Replace("-", "");
        }
        #endregion

        #region DES加密

        #endregion

        #region AES加密

        #endregion

        #region RSA签名

        #endregion
    }
}
