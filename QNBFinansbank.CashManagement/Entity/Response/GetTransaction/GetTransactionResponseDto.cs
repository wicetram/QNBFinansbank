namespace QNBFinansbank.CashManagement.Entity.Response.GetTransaction
{
    /// <summary>
    /// Hesap hareketleri işlemi yanıtını temsil eden DTO sınıfı.
    /// Bu sınıf, işlem sonucunu ve yanıt verilerini kapsar.
    /// </summary>
    public class GetTransactionResponseDto : IDto
    {
        /// <summary>
        /// İşlemin durumunu ve başarı bilgisini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, hesap hareketleri işleminin mevcut durumunu, başarı durumunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Hesap hareketleri işlemi yanıt verilerini içeren nesne.
        /// Bu nesne, işlem sonucuna dair ayrıntılı yanıt verilerini kapsar.
        /// </summary>
        public GetTransactionResponseDataDto? Transaction { get; set; }

        /// <summary>
        /// Hesap hareketleri işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
