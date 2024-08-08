namespace QNBFinansbank.VirtualPos.Entity.Response.Refund
{
    public class RefundResponseDataDto : IDto
    {
        /// <summary>
        /// Geri ödeme işleminin sonucunu ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, geri ödeme işleminin başarı durumunu, işlem sonucunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }
    }
}
