namespace QNBFinansbank.VirtualPos.Entity.Response.RecurringPayment.Payment
{
    /// <summary>
    /// Tekrarlı ödeme işleminin yanıt verilerini içeren DTO sınıfı.
    /// Bu sınıf, işlemin genel sonucunu, tekrarlı ödeme yanıtı verilerini ve API log bilgilerini içerir.
    /// </summary>
    public class RecurringPaymentResponseDto : IDto
    {
        /// <summary>
        /// İşlemin sonucunu ve başarı durumunu içeren <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, tekrarlı ödeme işleminin mevcut durumunu, başarı durumunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Tekrarlı ödeme işlemi sonucu elde edilen detaylı bilgileri içeren <see cref="RecurringPaymentResponseDataDto"/> nesnesi.
        /// Bu nesne, tekrarlı ödeme işlemi sonucunda dönen tüm verileri içerir.
        /// </summary>
        public RecurringPaymentResponseDataDto? RecurringPayment { get; set; }

        /// <summary>
        /// Tekrarlı ödeme işlemine ait istek ve cevabı içerir.
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir.
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
