namespace QNBFinansbank.MoneyTransfer.Entity.Request
{
    /// <summary>
    /// Para transfer işlemlerinde gönderen bilgilerini temsil eden DTO sınıfıdır.
    /// Bu sınıf, gönderenin doğum yeri, doğum tarihi, adı soyadı, telefon numarası, kimlik numarası ve diğer bilgileri içerir.
    /// </summary>
    public class SenderDto : IDto
    {
        /// <summary>
        /// Gönderenin doğum yeri.
        /// </summary>
        public string? BirthPlace { get; set; }

        /// <summary>
        /// Gönderenin doğum tarihi.
        /// </summary>
        public string? Birthday { get; set; }

        /// <summary>
        /// Gönderenin adı ve soyadı.
        /// </summary>
        public string? NameSurname { get; set; }

        /// <summary>
        /// Gönderenin telefon numarası.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Gönderenin kimlik numarası.
        /// </summary>
        public string? CitizenNo { get; set; }

        /// <summary>
        /// Gönderenin pasaport numarası (varsa).
        /// </summary>
        public string? Passport { get; set; }

        /// <summary>
        /// Gönderenin adres bilgisi.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gönderenin bulunduğu ülke.
        /// </summary>
        public string? Country { get; set; }
    }

}
