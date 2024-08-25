namespace QNBFinansbank.VirtualPos.Entity.Response.Campaign.Usage
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden gerçekleştirilen kampanya kullanım işleminin yanıtını temsil eder.
    /// Bu sınıf, işlem sonucunu, kampanya kullanım verilerini ve işlemle ilgili log bilgilerini içerir.
    /// </summary>
    public class CampaignUsageResponseDto : IDto
    {
        /// <summary>
        /// İşlemin sonucunu ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, işlemin başarı durumunu, işlem sonucunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Kampanya kullanım verilerini içeren bir <see cref="CampaignUsageResponseDataDto"/> nesnesi.
        /// Bu nesne, kampanya kullanım işleminin detaylı verilerini içerir.
        /// </summary>
        public CampaignUsageResponseDataDto? CampaignUsage { get; set; }

        /// <summary>
        /// İşleme ait istek ve cevap verilerini içeren bir <see cref="ApiLogDto"/> nesnesi.
        /// Bu alan, işleme ait request ve response bilgilerini içerir.
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}