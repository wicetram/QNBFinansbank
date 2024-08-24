namespace QNBFinansbank.MoneyTransfer.Entity.Request.Transfer
{
    /// <summary>
    /// Para transfer işlemi için gereken tüm bilgileri kapsayan DTO sınıfıdır.
    /// Bu sınıf, transferi gerçekleştirecek hesap bilgilerini, alıcı ve gönderen bilgilerini ve transfer detaylarını içerir.
    /// </summary>
    public class TransferRequestDto : IDto
    {
        /// <summary>
        /// Para transfer işlemi için kullanılacak hesap bilgilerini temsil eder.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Para transfer işleminin alıcısına ait bilgileri temsil eder.
        /// </summary>
        public ReceiverDto? Receiver { get; set; }

        /// <summary>
        /// Para transfer işleminin göndericisine ait bilgileri temsil eder.
        /// </summary>
        public SenderDto? Sender { get; set; }

        /// <summary>
        /// Para transfer işleminin detaylarını temsil eder.
        /// </summary>
        public TransferDto? Transfer { get; set; }
    }
}
