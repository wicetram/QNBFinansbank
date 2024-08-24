namespace QNBFinansbank.MoneyTransfer.Entity.Request
{
    /// <summary>
    /// Para transfer işlemleri için gerekli olan hesap bilgilerini temsil eden DTO sınıfıdır.
    /// Bu sınıf, kullanıcının hesap bilgilerini ve işlem sırasında kullanılacak çeşitli parametreleri içerir.
    /// </summary>
    public class AccountDto : IDto
    {
        /// <summary>
        /// Kullanıcının kullanıcı adı bilgisi.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Kullanıcının şifre bilgisi.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Kullanıcının müşteri numarası.
        /// </summary>
        public string? CustomerNo { get; set; }

        /// <summary>
        /// Firmanın kodu.
        /// </summary>
        public string? FirmCode { get; set; }

        /// <summary>
        /// Hesap numarası.
        /// </summary>
        public string? AccountCode { get; set; }

        /// <summary>
        /// Banka kodu.
        /// </summary>
        public string? BankCode { get; set; }

        /// <summary>
        /// Şube kodu.
        /// </summary>
        public string? BranchCode { get; set; }

        /// <summary>
        /// Ek numara (suffix).
        /// </summary>
        public string? Suffix { get; set; }

        /// <summary>
        /// Hesabın para birimi.
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// Kullanıcının IP adresi.
        /// </summary>
        public string? IP { get; set; }

        /// <summary>
        /// İşlem yapılacak temel URL adresi.
        /// </summary>
        public string? BaseUrl { get; set; }

        /// <summary>
        /// Yapılacak işlemin türünü belirten aksiyon.
        /// </summary>
        public string? Action { get; set; }
    }
}
