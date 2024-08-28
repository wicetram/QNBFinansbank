namespace QNBFinansbank.VirtualPos.Entity.Request.RecurringPayment.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde tekrarlı ödeme işlemini kontrol etmek için kullanılan DTO sınıfı.
    /// Bu sınıf, tekrarlı ödeme işlemi için gerekli olan hesap, sipariş bilgilerini ve işlem rehberini içerir.
    /// </summary>
    public class CheckRecurringPaymentRequestDto : IDto
    {
        /// <summary>
        /// Tekrarlı ödeme işlemini kontrol etmek için gerekli olan hesap bilgilerini temsil eder.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Tekrarlı ödeme işlemi için ilgili sipariş bilgilerini temsil eder.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// Tekrarlı ödeme işlemi için benzersiz işlem rehberini (GUID) temsil eder.
        /// </summary>
        public string? InstOrderGuid { get; set; }
    }
}