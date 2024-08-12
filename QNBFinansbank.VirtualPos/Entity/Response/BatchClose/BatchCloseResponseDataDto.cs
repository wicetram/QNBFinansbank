namespace QNBFinansbank.VirtualPos.Entity.Response.BatchClose
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde gerçekleştirilen toplu kapama (batch close) işlemi sonucunu temsil eder.
    /// Bu sınıf, işlem sonucunu ve toplu kapama işleminin detaylarını içerir.
    /// </summary>
    public class BatchCloseResponseDataDto : IDto
    {
        /// <summary>
        /// Toplu kapatma işleminin sonucunu ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, toplu kapatma işleminin başarı durumunu, işlem sonucunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Toplu kapama işlemine ait detayları içerir.
        /// Bu alan, işlemle ilgili otorizasyon kodu, banka referans numarası gibi bilgileri içerir.
        /// </summary>
        public BatchCloseResponseDto? BatchClose { get; set; }
    }
}
