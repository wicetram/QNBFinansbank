namespace QNBFinansbank.VirtualPos.Entity.Request.Refund
{
    public class RefundRequestDto : IDto
    {
        /// <summary>
        /// Banka hesap bilgilerinin yer aldığı obje
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Ödemeye ait bilgilerin yer aldığı obje
        /// </summary>
        public OrderDto? Order { get; set; }
    }
}
