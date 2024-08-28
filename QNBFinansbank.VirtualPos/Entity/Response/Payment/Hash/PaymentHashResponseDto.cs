namespace QNBFinansbank.VirtualPos.Entity.Response.Payment.Hash
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde yapılan hash kontrol işleminin sonucunu içeren DTO sınıfı.
    /// Bu sınıf, işlem sonucunu, oluşturulan hash değerini ve bankadan gelen hash değerini içerir.
    /// </summary>
    public class PaymentHashResponseDto : IDto
    {
        /// <summary>
        /// İşlemin sonucunu ve başarı durumunu içeren <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, hash kontrol işleminin mevcut durumunu, başarı durumunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Uygulama tarafından oluşturulan hash değerini temsil eder.
        /// </summary>
        public string? CreatedHash { get; set; }

        /// <summary>
        /// Bankadan gelen hash değerini temsil eder.
        /// </summary>
        public string? BankHash { get; set; }
    }
}
