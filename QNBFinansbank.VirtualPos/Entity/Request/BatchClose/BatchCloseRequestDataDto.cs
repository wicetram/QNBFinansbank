namespace QNBFinansbank.VirtualPos.Entity.Request.BatchClose
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde toplu kapama (batch close) işlemi için gerekli verileri temsil eder.
    /// Bu sınıf, toplu kapama işlemi sırasında kullanılacak hesap bilgilerini içerir.
    /// </summary>
    public class BatchCloseRequestDataDto : IDto
    {
        /// <summary>
        /// Toplu kapama işlemi için gerekli olan hesap bilgilerini temsil eder.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Ödemeye ait bilgilerin yer aldığı obje
        /// </summary>
        public OrderDto? Order { get; set; }
    }
}
