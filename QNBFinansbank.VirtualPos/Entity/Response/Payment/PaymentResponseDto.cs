namespace QNBFinansbank.VirtualPos.Entity.Response.Payment
{
    public class PaymentResponseDto : IDto
    {
        /// <summary>
        /// Ödeme işleminin sonuç ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, ödeme işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Ödeme işlemine ait detaylı bilgileri içeren bir <see cref="PaymentData"/> nesnesi.
        /// Bu nesne, ödeme ile ilgili önemli verileri, örneğin sipariş ID'si ve ödeme URL'sini içerir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public PaymentData? Payment { get; set; }

        /// <summary>
        /// Ödeme işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
