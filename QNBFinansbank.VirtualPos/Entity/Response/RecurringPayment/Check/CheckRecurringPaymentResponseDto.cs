namespace QNBFinansbank.VirtualPos.Entity.Response.RecurringPayment.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde tekrarlı ödeme kontrol işlemi sonucunda dönen yanıt verilerini içeren DTO sınıfı.
    /// Bu sınıf, işlemin genel sonucunu, tekrarlı ödeme kontrolüne ait yanıt verilerini ve API log bilgilerini içerir.
    /// </summary>
    public class CheckRecurringPaymentResponseDto : IDto
    {
        /// <summary>
        /// İşlemin sonucunu ve başarı durumunu içeren <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, tekrarlı ödeme kontrol işleminin mevcut durumunu, başarı durumunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Tekrarlı ödeme kontrol işlemi sonucu elde edilen detaylı bilgileri içeren <see cref="CheckRecurringPaymentResponseDataDto"/> nesnesi.
        /// Bu nesne, tekrarlı ödeme kontrol işlemi sonucunda dönen tüm verileri içerir.
        /// </summary>
        public CheckRecurringPaymentResponseDataDto? CheckRecurringPayment { get; set; }

        /// <summary>
        /// Tekrarlı ödeme kontrol işlemine ait istek ve cevabı içeren API log bilgilerini temsil eder.
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir.
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}