namespace QNBFinansbank.MoneyTransfer.Constant
{
    /// <summary>
    /// Para transfer işlemleri için kullanılan metot adlarını tutan sabitler sınıfıdır.
    /// </summary>
    public static class MethodNames
    {
        /// <summary>
        /// Para transfer kontrol işlemi metot adı.
        /// </summary>
        public const string Check = "Check";

        /// <summary>
        /// Kredi kartı kullanarak para transferi işlemi metot adı.
        /// </summary>
        public const string CreditCardMoneyTransfer = "Credit Card MoneyTransfer";

        /// <summary>
        /// IBAN kullanarak para transferi işlemi metot adı.
        /// </summary>
        public const string IBANMoneyTransfer = "IBAN Money Transfer";
    }
}
