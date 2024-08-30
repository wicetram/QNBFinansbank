using System.Globalization;

namespace QNBFinansbank.VirtualPos.Utility.Extensions
{
    /// <summary>
    /// Tutar formatlama işlemleri için yardımcı metotlar sağlayan statik sınıf.
    /// Bu sınıf, QNB'nin gereksinimlerine uygun olarak tutarları istenen formata dönüştürmeye yardımcı olur.
    /// </summary>
    public static class AmountExtensions
    {
        /// <summary>
        /// Verilen string tutarı, QNB'nin istediği formata dönüştürmeye çalışır
        /// (örneğin, "1" -> "1.00", "1.5" -> "1.50", "10.000" -> "10.00").
        /// </summary>
        /// <param name="amount">Tutarı temsil eden string değer.</param>
        /// <param name="formattedAmount">İki ondalık basamağa sahip, formata uygun string tutar değeri.</param>
        /// <returns>Dönüşüm başarılı olursa true, aksi halde false döner.</returns>
        public static bool TryToQnbFormat(this string amount, out string formattedAmount)
        {
            formattedAmount = string.Empty;

            if (string.IsNullOrWhiteSpace(amount))
            {
                return false;
            }

            if (decimal.TryParse(amount, out decimal parsedAmount))
            {
                formattedAmount = parsedAmount.ToString("F2", CultureInfo.InvariantCulture);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verilen string tutarı, QNB'nin istediği formata dönüştürür (örneğin, "1" -> "1.00", "1.5" -> "1.50", "10.000" -> "10.00").
        /// </summary>
        /// <param name="amount">Tutarı temsil eden string değer.</param>
        /// <returns>İki ondalık basamağa sahip, formata uygun string tutar değeri.</returns>
        /// <exception cref="ArgumentException">Eğer tutar boş veya null ise fırlatılır.</exception>
        /// <exception cref="FormatException">Eğer tutar geçerli bir formatta değilse fırlatılır.</exception>
        public static string ToQnbFormat(this string amount)
        {
            if (string.IsNullOrWhiteSpace(amount) || string.IsNullOrEmpty(amount))
            {
                throw new ArgumentException("Tutar boş veya null olamaz", nameof(amount));
            }

            // String değeri bir ondalık sayıya çevirmeye çalışır
            if (decimal.TryParse(amount, out decimal parsedAmount))
            {
                // Ondalık sayıyı iki ondalık basamak ile formatlar
                return parsedAmount.ToString("F2", CultureInfo.InvariantCulture);
            }
            else
            {
                throw new FormatException("Tutar geçerli bir formatta değil");
            }
        }
    }
}