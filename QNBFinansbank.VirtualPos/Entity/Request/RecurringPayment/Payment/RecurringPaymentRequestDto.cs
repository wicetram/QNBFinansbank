namespace QNBFinansbank.VirtualPos.Entity.Request.RecurringPayment.Payment
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde tekrarlı ödeme işlemi için gerekli verileri temsil eder.
    /// Bu sınıf, tekrarlı ödeme işlemi sırasında kullanılacak hesap, kart ve sipariş bilgilerini içerir.
    /// </summary>
    public class RecurringPaymentRequestDto : IDto
    {
        /// <summary>
        /// Tekrarlı ödeme işlemi için gerekli olan hesap bilgilerini temsil eder.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Ödeme işlemine ait sipariş bilgilerini temsil eder.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// Ödeme işleminde kullanılacak kart bilgilerini temsil eder.
        /// </summary>
        public CardDto? Card { get; set; }

        /// <summary>
        /// Tekrarlı ödemenin başlayacağı tarihi belirtir.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Ödemelerin hangi sıklıkla yapılacağını temsil eder. (Örn: 1: Günlük, 2: Haftalık, 3: Aylık, 4: Yıllık)
        /// </summary>
        public int IntervalType { get; set; }

        /// <summary>
        /// IntervalType ile belirtilen aralığın kaç birim süreceğini belirtir.
        /// </summary>
        public int IntervalDuration { get; set; }

        /// <summary>
        /// Tekrarlı ödeme işleminin kaç kez tekrarlanacağını belirtir.
        /// </summary>
        public int RepeatCount { get; set; }

        /// <summary>
        /// Tekrarlı ödeme işlemi için açıklamayı belirtir.
        /// </summary>
        public string? Description { get; set; }
    }
}
