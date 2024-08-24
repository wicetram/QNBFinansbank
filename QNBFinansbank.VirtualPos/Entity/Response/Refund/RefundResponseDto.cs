namespace QNBFinansbank.VirtualPos.Entity.Response.Refund
{
    public class RefundResponseDto : IDto
    {
        /// <summary>
        /// Geri ödeme işleminin sonucunu ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, geri ödeme işleminin başarı durumunu, işlem sonucunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Geri ödeme işlemi ile ilgili detayları içeren bir <see cref="RefundResponseDataDto"/> nesnesi.
        /// Bu nesne, geri ödeme işlemi hakkında spesifik bilgileri içerir, örneğin geri ödenen tutar ve diğer ilgili veriler.
        /// </summary>
        public RefundResponseDataDto? Response { get; set; }

        /// <summary>
        /// Geri ödeme işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
