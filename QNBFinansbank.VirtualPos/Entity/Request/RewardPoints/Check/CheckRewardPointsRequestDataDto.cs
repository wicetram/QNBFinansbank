namespace QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde ödül puanlarını kontrol etmek için gerekli olan parametreleri içeren DTO sınıfı.
    /// Bu sınıf, ödül puanlarının kontrolü için gereken hesap, sipariş ve kart bilgilerini taşır.
    /// </summary>
    public class CheckRewardPointsRequestDataDto : IDto
    {
        /// <summary>
        /// Hesap bilgilerini içeren DTO. 
        /// Bu nesne, işlemde kullanılacak olan hesapla ilgili detayları içerir.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Sipariş bilgilerini içeren DTO. 
        /// Bu nesne, işlemde kullanılacak olan siparişle ilgili detayları içerir.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// Kart bilgilerini içeren DTO.
        /// Bu nesne, işlemde kullanılacak olan kartla ilgili detayları içerir.
        /// </summary>
        public CardDto? Card { get; set; }
    }
}
