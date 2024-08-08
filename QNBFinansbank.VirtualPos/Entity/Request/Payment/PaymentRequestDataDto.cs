namespace QNBFinansbank.VirtualPos.Entity.Request.Payment
{
    public class PaymentRequestDataDto : IDto
    {
        /// <summary>
        /// Banka hesap bilgilerinin yer aldığı obje
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Ödemeye ait bilgilerin yer aldığı obje
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// Ödemede kullanılacak kart bilgilerinin yer aldığı obje
        /// </summary>
        public CardDto? Card { get; set; }

        /// <summary>
        /// Alt üye işyeri bilgilerinin yer aldığı obje
        /// </summary>
        public SubmerchantDto? Submerchant { get; set; }
    }
}
