namespace QNBFinansbank.VirtualPos.Entity.Response.Check
{
    /// <summary>
    /// Kontrol işlemi yanıtını temsil eden DTO sınıfı.
    /// Bu sınıf, işlem sonucunu ve yanıt verilerini kapsar.
    /// </summary>
    public class CheckResponseDto : IDto
    {
        /// <summary>
        /// İşlemin durumunu ve başarı bilgisini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, ödeme işleminin mevcut durumunu, başarı durumunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Kontrol işlemi yanıt verilerini içeren nesne.
        /// Bu nesne, işlem sonucuna dair ayrıntılı yanıt verilerini kapsar.
        /// </summary>
        public CheckResponseDataDto? CheckResponse { get; set; }

        /// <summary>
        /// Kontrol işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}