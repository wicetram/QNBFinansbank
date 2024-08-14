namespace QNBFinansbank.CashManagement.Entity.Request
{
    /// <summary>
    /// Bir hesabın temel bilgilerini içeren veri transfer nesnesi (DTO).
    /// Bu sınıf, bir hesapla ilişkili kullanıcı adı, şifre, hesap numarası, IBAN ve diğer gerekli bilgileri tutar.
    /// Nakit yönetimi taleplerinde kullanılır.
    /// </summary>
    public class AccountDto : IDto
    {
        /// <summary>
        /// Kullanıcı adı. 
        /// Bu alan, ilgili hesabın kullanıcı adı bilgisini içerir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Şifre. 
        /// Bu alan, hesabın erişimi için kullanılan şifre bilgisini içerir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Hesap numarası. 
        /// Bu alan, ilgili hesabın hesap numarasını içerir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? AccountNo { get; set; }

        /// <summary>
        /// IBAN numarası. 
        /// Bu alan, hesabın IBAN (Uluslararası Banka Hesap Numarası) bilgisini içerir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? IBAN { get; set; }

        /// <summary>
        /// Temel URL. 
        /// Bu alan, isteklerin gönderileceği temel URL bilgisini içerir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? BaseUrl { get; set; }

        /// <summary>
        /// İşlem URL'si. 
        /// Bu alan, gerçekleştirilecek işlemin URL'sini belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? ActionUrl { get; set; }
    }
}
