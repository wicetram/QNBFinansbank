using System.Security.Cryptography;
using System.Text;

namespace QNBFinansbank.VirtualPos.Utilities
{
    public static class CryptoManager
    {
        /// <summary>
        /// SHA1 şifreleme algoritması
        /// </summary>
        /// <param name="key">Şifrelenecek içerik</param>
        /// <returns>Base64 string olarak şifrelenmiş veri</returns>
        public static string SHA1Encryption(string key)
        {
            string response = string.Empty;

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(key);
                byte[] hashingbytes = SHA1.HashData(bytes);
                response = Convert.ToBase64String(hashingbytes);
            }
            catch (Exception)
            {
            }

            return response;
        }
    }
}
