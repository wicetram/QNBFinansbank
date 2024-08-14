namespace QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Usage
{
    /// <summary>
    /// Para puan kullanım işlemi için gerekli olan verileri içeren DTO sınıfı.
    /// Bu sınıf, para puanları kullanarak bir ödeme veya işlem yapılması için gerekli olan hesap, sipariş ve kart bilgilerini içerir.
    /// </summary>
    public class UseRewardPointsRequestDto : IDto
    {
        /// <summary>
        /// İşlemde kullanılacak hesap bilgilerini içeren <see cref="AccountDto"/> nesnesi.
        /// Bu nesne, üye işyeri numarası, kullanıcı kodu, güvenlik bilgileri gibi hesap detaylarını içerir.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// İşlemde kullanılacak sipariş bilgilerini içeren <see cref="OrderDto"/> nesnesi.
        /// Bu nesne, sipariş numarası, işlem tutarı, para birimi gibi sipariş detaylarını içerir.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// İşlemde kullanılacak kart bilgilerini içeren <see cref="CardDto"/> nesnesi.
        /// Bu nesne, kart numarası, son kullanma tarihi, güvenlik kodu gibi kart detaylarını içerir.
        /// </summary>
        public CardDto? Card { get; set; }
    }
}
