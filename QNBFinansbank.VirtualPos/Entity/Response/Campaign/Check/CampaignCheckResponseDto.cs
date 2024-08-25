namespace QNBFinansbank.VirtualPos.Entity.Response.Campaign.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden gerçekleştirilen kampanya kontrol işleminin sonucunu temsil eder.
    /// Bu sınıf, işlem sonucunu, kampanya kontrol verilerini ve işlemle ilgili log bilgilerini içerir.
    /// </summary>
    public class CampaignCheckResponseDto : IDto
    {
        /// <summary>
        /// Kampanya kontrol işleminin sonucunu ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, kampanya kontrol işleminin başarı durumunu, işlem sonucunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Kampanya kontrol verilerini içeren bir <see cref="CampaignCheckResponseDataDto"/> nesnesi.
        /// Bu nesne, kampanya kontrolü sonucunda dönen verileri içerir.
        /// </summary>
        public CampaignCheckResponseDataDto? CampaignCheck { get; set; }

        /// <summary>
        /// Kampanya kontrol işlemine ait istek ve cevap verilerini içerir.
        /// Bu alan, işleme ait request ve response bilgilerini içerir.
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}