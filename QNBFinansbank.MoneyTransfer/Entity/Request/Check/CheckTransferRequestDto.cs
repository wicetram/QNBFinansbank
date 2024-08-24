namespace QNBFinansbank.MoneyTransfer.Entity.Request.Check
{
    /// <summary>
    /// Para transfer kontrol işlemi için gerekli olan bilgileri içeren DTO sınıfıdır.
    /// Bu sınıf, kontrol edilecek transferlerin hesap bilgilerini, istek kimliğini, banka referans numarasını, muhasebe referansını ve tarih aralığını içerir.
    /// </summary>
    public class CheckTransferRequestDto : IDto
    {
        /// <summary>
        /// Kontrol işlemi için kullanılacak hesap bilgilerini temsil eder.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Kontrol edilecek transferin istek kimliği.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Banka tarafından verilen referans numarası.
        /// </summary>
        public string? BankReference { get; set; }

        /// <summary>
        /// Banka sorgu numarası.
        /// </summary>
        public string? BankQueryNumber { get; set; }

        /// <summary>
        /// Muhasebe referans numarası.
        /// </summary>
        public string? AccountingReference { get; set; }

        /// <summary>
        /// Kontrol edilecek transferlerin başlangıç tarihi.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Kontrol edilecek transferlerin bitiş tarihi.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
