namespace QNBFinansbank.MoneyTransfer.Entity.Request
{
    /// <summary>
    /// Para transfer işlemlerinde alıcı bilgilerini temsil eden DTO sınıfıdır.
    /// Bu sınıf, alıcının tam adı, IBAN numarası ve banka kodu gibi bilgileri içerir.
    /// </summary>
    public class ReceiverDto : IDto
    {
        /// <summary>
        /// Alıcının tam adı.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Alıcının IBAN numarası.
        /// </summary>
        public string? Iban { get; set; }

        /// <summary>
        /// Alıcının banka kodu.
        /// </summary>
        public string? ReceiverBankCode { get; set; }
    }

}
