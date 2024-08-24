namespace QNBFinansbank.VirtualPos.Entity.Response.Report
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden gerçekleştirilen raporlama işlemi sonucunu temsil eder.
    /// Bu sınıf, işlem sonucunu ve raporlama işleminin detaylarını içerir.
    /// </summary>
    public class ReportResponseDto : IDto
    {
        /// <summary>
        /// Raporlama işleminin sonucunu ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, raporlama işleminin başarı durumunu, işlem sonucunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Raporlama işlemine ait detayları içerir.
        /// Bu alan, işlemle ilgili rapor verilerini ve diğer ilgili bilgileri içerir.
        /// </summary>
        public ReportResponseDataDto? Report { get; set; }

        /// <summary>
        /// Raporlama işlemine ait istek ve cevabı içerir.
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir.
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }

}
