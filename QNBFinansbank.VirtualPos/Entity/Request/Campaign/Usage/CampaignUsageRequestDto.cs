namespace QNBFinansbank.VirtualPos.Entity.Request.Campaign.Usage
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden kampanya kullanımı işlemi yapmak için gerekli olan parametreleri temsil eder.
    /// Bu sınıf, hesap, sipariş, kart bilgileri ve opsiyonel kampanya parametrelerini içerir.
    /// </summary>
    public class CampaignUsageRequestDto : IDto
    {
        /// <summary>
        /// Hesap bilgilerini temsil eder. Bu alan, kampanya işlemi için gerekli olan hesap detaylarını içerir.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Sipariş bilgilerini temsil eder. Bu alan, kampanya işlemi için gerekli olan sipariş detaylarını içerir.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// Kart bilgilerini temsil eder. Bu alan, kampanya işlemi için gerekli olan kart detaylarını içerir.
        /// </summary>
        public CardDto? Card { get; set; }

        /// <summary>
        /// Opsiyonel kampanyayı temsil eder. Bu alan, opsiyonel kampanyanın etkin olup olmadığını belirtir.
        /// </summary>
        public string? OptionalCampaign { get; set; }

        /// <summary>
        /// Seçmeli kampanya durumunu temsil eder. Bu alan, seçmeli kampanyanın etkin olup olmadığını belirtir.
        /// </summary>
        public string? SelectiveCampaignStatus { get; set; }

        /// <summary>
        /// Öteleme kampanya kodunu temsil eder. Bu alan, öteleme kampanyası için belirlenen kodu içerir.
        /// </summary>
        public string? DeferralCampaignCode { get; set; }

        /// <summary>
        /// Öteleme sayısını temsil eder. Bu alan, öteleme kampanyası için belirlenen sayıyı içerir.
        /// </summary>
        public string? DeferralCount { get; set; }

        /// <summary>
        /// Artı taksit kampanya kodunu temsil eder. Bu alan, artı taksit kampanyası için belirlenen kodu içerir.
        /// </summary>
        public string? ExtraInstallmentCampaignCode { get; set; }

        /// <summary>
        /// Artı taksit sayısını temsil eder. Bu alan, artı taksit kampanyası için belirlenen sayıyı içerir.
        /// </summary>
        public string? ExtraInstallmentCount { get; set; }
    }
}
