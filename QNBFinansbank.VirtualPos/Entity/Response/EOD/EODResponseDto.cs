namespace QNBFinansbank.VirtualPos.Entity.Response.EOD
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden gerçekleştirilen EOD (End of Day) işlemi sonucunu temsil eder.
    /// Bu sınıf, işlem sonucunu, EOD rapor verilerini ve işlemle ilgili log bilgilerini içerir.
    /// </summary>
    public class EODResponseDto : IDto
    {
        /// <summary>
        /// EOD işleminin sonucunu ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, EOD işleminin başarı durumunu, işlem sonucunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// EOD rapor verilerini içeren bir <see cref="EODResponseDataDto"/> nesnesi.
        /// Bu nesne, EOD ve VPO raporlarına ait veri listelerini içerir.
        /// </summary>
        public List<List<EODResponseDataDto>>? EOD { get; set; }

        /// <summary>
        /// EOD işlemine ait istek ve cevap verilerini içerir.
        /// Bu alan, işleme ait request ve response bilgilerini içerir.
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}