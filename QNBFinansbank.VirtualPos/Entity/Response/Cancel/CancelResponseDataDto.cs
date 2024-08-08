namespace QNBFinansbank.VirtualPos.Entity.Response.Cancel
{
    public class CancelResponseDataDto : IDto
    {
        /// <summary>
        /// İptal işleminin sonucunu ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, iptal işleminin başarı durumunu, işlem sonucunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }
    }
}
