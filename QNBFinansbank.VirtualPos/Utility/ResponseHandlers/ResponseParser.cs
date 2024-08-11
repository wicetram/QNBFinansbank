using System.Reflection;

namespace QNBFinansbank.VirtualPos.Utility.ResponseHandlers
{
    /// <summary>
    /// Bir yanıt string'ini Data Transfer Object (DTO) sınıfına dönüştürmek için yardımcı yöntemler sağlar.
    /// </summary>
    public static class ResponseParser
    {
        /// <summary>
        /// ";;" ile ayrılmış anahtar-değer çiftleri olarak formatlanmış bir yanıt string'ini belirli bir DTO'nun özelliklerine map eder.
        /// </summary>
        /// <typeparam name="T">Yanıtın parse edileceği DTO'nun türü. Parametresiz bir yapıcıya sahip olmalıdır.</typeparam>
        /// <param name="response">Anahtar-değer çiftlerini içeren yanıt string'i.</param>
        /// <returns>Yanıt string'inden parse edilen değerlerle doldurulmuş DTO'nun bir örneği.</returns>
        /// <remarks>
        /// Yanıt string'i "key=value" formatında anahtar-değer çiftlerine sahip olmalıdır ve bu çiftler ";;" ile ayrılmalıdır.
        /// Yöntem, anahtarları DTO'nun property (özellik) isimleri ile eşleştirmek için reflection kullanır, büyük/küçük harf duyarsızdır.
        /// Eğer bir anahtar hiçbir property ile eşleşmezse, görmezden gelinir.
        /// </remarks>
        public static T ParseResponseToDto<T>(string? response) where T : new()
        {
            var dto = new T();

            if (string.IsNullOrEmpty(response))
            {
                return dto;
            }

            var keyValuePairs = response.Split(new[] { ";;" }, StringSplitOptions.None);

            // DTO'nun tüm property'lerini alıyoruz
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var pair in keyValuePairs)
            {
                var keyValue = pair.Split(new[] { '=' }, 2);
                if (keyValue.Length != 2) continue;

                var key = keyValue[0];
                var value = keyValue[1];

                // Property'yi bul ve değeri ata
                var property = properties.FirstOrDefault(p => string.Equals(p.Name, key, StringComparison.OrdinalIgnoreCase));
                if (property != null && property.CanWrite)
                {
                    // Property türünü al ve uygun şekilde cast et
                    var convertedValue = Convert.ChangeType(value, property.PropertyType);
                    property.SetValue(dto, convertedValue);
                }
            }

            return dto;
        }
    }
}
