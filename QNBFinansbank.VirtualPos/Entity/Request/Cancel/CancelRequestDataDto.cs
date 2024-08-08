namespace QNBFinansbank.VirtualPos.Entity.Request.Cancel
{
    public class CancelRequestDataDto : IDto
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
