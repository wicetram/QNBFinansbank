namespace QNBFinansbank.VirtualPos.Entity.Request.Payment.Hash
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde ödeme işlemi sırasında hash kontrolü yapmak için kullanılan DTO sınıfı.
    /// Bu sınıf, hash kontrolü için gerekli olan işlem bilgilerini içerir.
    /// </summary>
    public class PaymentHashControlRequestDto : IDto
    {
        /// <summary>
        /// Satıcı (merchant) kimliğini temsil eder.
        /// </summary>
        public string? MerchantId { get; set; }

        /// <summary>
        /// Satıcı (merchant) şifresini temsil eder.
        /// </summary>
        public string? MerchantPass { get; set; }

        /// <summary>
        /// İşleme ait benzersiz sipariş kimliğini temsil eder.
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        /// İşlem onay kodunu temsil eder.
        /// </summary>
        public string? AuthCode { get; set; }

        /// <summary>
        /// İşlem sonucu geri dönüş kodunu temsil eder.
        /// </summary>
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// 3D Secure işlem durumunu temsil eder.
        /// </summary>
        public string? ThreeDStatus { get; set; }

        /// <summary>
        /// Ödeme işlemi sırasında oluşturulan rastgele değeri (random) temsil eder.
        /// </summary>
        public string? ResponseRandom { get; set; }

        /// <summary>
        /// Kullanıcının kimliğini veya kullanıcı adını temsil eder.
        /// </summary>
        public string? UserCode { get; set; }

        /// <summary>
        /// Bankanın işlem ile birlikte yarattığı hash değeri
        /// </summary>
        public string? BankHash { get; set; }
    }
}