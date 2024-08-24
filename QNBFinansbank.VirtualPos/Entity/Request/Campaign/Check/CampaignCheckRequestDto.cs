namespace QNBFinansbank.VirtualPos.Entity.Request.Campaign.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden kampanya kontrolü yapmak için gerekli olan parametreleri içeren sınıf.
    /// Bu sınıf, kampanya kontrolü işlemi için gereken hesap, sipariş ve kart bilgilerini içerir.
    /// </summary>
    public class CampaignCheckRequestDto : IDto
    {
        /// <summary>
        /// Kampanya kontrolü işlemi için gerekli olan hesap bilgilerini içeren bir <see cref="AccountDto"/> nesnesi.
        /// Bu nesne, işlemde kullanılacak üye işyeri, kullanıcı ve güvenlik bilgilerini içerir.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Kampanya kontrolü işlemi için gerekli olan sipariş bilgilerini içeren bir <see cref="OrderDto"/> nesnesi.
        /// Bu nesne, işlemde kullanılacak sipariş numarası, dil ve diğer ilgili sipariş bilgilerini içerir.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// Kampanya kontrolü işlemi için gerekli olan kart bilgilerini içeren bir <see cref="CardDto"/> nesnesi.
        /// Bu nesne, işlemde kullanılacak kart numarası, son kullanma tarihi ve diğer ilgili kart bilgilerini içerir.
        /// </summary>
        public CardDto? Card { get; set; }
    }
}