using Newtonsoft.Json;
using QNBFinansbank.VirtualPos.Entity.Response;

namespace QNBFinansbank.VirtualPos.Utility.Serialization
{
    /// <summary>
    /// Serileştirme işlemleri için yardımcı yöntemler sağlar.
    /// Girdileri JSON formatına çevirir veya olduğu gibi döndürür.
    /// </summary>
    public static class SerializerHelper
    {
        /// <summary>
        /// Verilen başlık, istek ve yanıt verilerini alır ve bir <see cref="ApiLogDto"/> nesnesi oluşturur.
        /// </summary>
        /// <param name="title">İşlem başlığını temsil eden string.</param>
        /// <param name="request">Serileştirilecek veya string olarak saklanacak istek nesnesi.</param>
        /// <param name="response">Serileştirilecek veya string olarak saklanacak yanıt nesnesi.</param>
        /// <returns>Verilen başlık, istek ve yanıt verileri ile doldurulmuş bir <see cref="ApiLogDto"/> nesnesi.</returns>
        public static ApiLogDto ProcessData(string title, object? request, object? response)
        {
            return new ApiLogDto
            {
                Request = SerializeIfNotString(request),
                Response = SerializeIfNotString(response),
                Title = title
            };
        }

        /// <summary>
        /// Bir nesneyi string olarak serileştirir. Eğer nesne string ise olduğu gibi döner.
        /// </summary>
        /// <param name="data">Serileştirilecek nesne.</param>
        /// <returns>Serileştirilmiş string veya orijinal string. Eğer nesne null ise boş bir string döner.</returns>
        private static string? SerializeIfNotString(object? data)
        {
            if (data == null)
            {
                return string.Empty;
            }

            if (data is string)
            {
                return data.ToString();
            }
            else
            {
                return JsonConvert.SerializeObject(data);
            }
        }
    }
}