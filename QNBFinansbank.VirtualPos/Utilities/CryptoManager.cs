using System.Security.Cryptography;
using System.Text;

namespace QNBFinansbank.VirtualPos.Utilities
{
    public static class CryptoManager
    {
        /// <summary>
        /// Verilen metni SHA1 algoritması kullanarak şifreler ve Base64 formatında döndürür.
        /// Bu metod, giriş metnini SHA1 algoritması ile hash'ler ve sonucu Base64 string olarak döner.
        /// </summary>
        /// <param name="key">
        /// Şifrelenecek metin. Bu metin, SHA1 algoritması ile hash'lenir ve Base64 formatında döndürülür.
        /// </param>
        /// <returns>
        /// Base64 formatında şifrelenmiş veri. Şifreleme başarılı olursa, metnin SHA1 hash'i Base64 olarak döner. 
        /// Eğer bir hata oluşursa, boş bir dize dönebilir.
        /// </returns>
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
