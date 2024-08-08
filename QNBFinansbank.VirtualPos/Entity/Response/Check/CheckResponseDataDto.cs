namespace QNBFinansbank.VirtualPos.Entity.Response.Check
{
    public class CheckResponseDataDto : IDto
    {
        /// <summary>
        /// İşlemin durumunu ve başarı bilgisini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, ödeme işleminin mevcut durumunu, başarı durumunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }
    }
}
