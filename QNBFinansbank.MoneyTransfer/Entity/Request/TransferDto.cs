namespace QNBFinansbank.MoneyTransfer.Entity.Request
{
    /// <summary>
    /// Para transfer işlemleri için gerekli olan transfer bilgilerini temsil eden DTO sınıfıdır.
    /// Bu sınıf, transfer talebinin kimliğini, miktarını ve açıklamasını içerir.
    /// </summary>
    public class TransferDto : IDto
    {
        /// <summary>
        /// Transfer talebinin benzersiz kimliği.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Transfer edilecek tutar.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Transfer için ek açıklama veya not.
        /// </summary>
        public string? Description { get; set; }
    }
}
