namespace QNBFinansbank.VirtualPos.Entity.Request
{
    /// <summary>
    /// Alt üye işyeri bilgilerini temsil eden DTO sınıfı.
    /// Bu sınıf, alt üye işyeri numarası, adı, web sitesi, TCKN/VKN, MCC kodu gibi alt üye işyeriyle ilgili çeşitli bilgileri içerir.
    /// Ayrıca, Asseco ve Vakıfbank gibi bankalarla yapılan işlemler için gerekli olan özel parametreleri de içerir.
    /// </summary>
    public class SubmerchantDto : IDto
    {
        /// <summary>
        /// Alt üye işyeri numarası. 
        /// Bu özellik, alt üye işyerinin benzersiz tanımlayıcısını belirtir. 
        /// Örneğin, her alt üye işyerine özgü olan "12345678" gibi değerler alabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubmerchantIdCode { get; set; }

        /// <summary>
        /// Alt üye işyeri ismi. 
        /// Bu özellik, alt üye işyerinin adını belirtir. 
        /// Örneğin, "ABC Ltd." gibi değerler alabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubmerchantName { get; set; }

        /// <summary>
        /// Alt üye işyeri websitesi. 
        /// Bu özellik, alt üye işyerinin web sitesinin URL'sini belirtir. 
        /// Örneğin, "https://www.abc.com" gibi değerler alabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubmerchantIn { get; set; }

        /// <summary>
        /// Bu parametre, Asseco ve Ziraat Bankası işlemlerinde kullanılmakta olan alt üye işyeri numarasını temsil eder.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubMerchantNumber { get; set; }

        /// <summary>
        /// Yeni PF tanımı yapılana kadar, SubmerchantID parametresi bu alan ile doldurulacak.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubMerchantBddkCode { get; set; }

        /// <summary>
        /// Alt üye işyerinin Merchant Category Code (MCC) değerini belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubMerchantMcc { get; set; }

        /// <summary>
        /// Alt üye işyerinin T.C. Kimlik Numarası (TCKN) veya Vergi Kimlik Numarası (VKN) değerini belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubMerchantIn { get; set; }

        /// <summary>
        /// Bu özellik, alt üye işyerinin Merchant Category Code (MCC) ile ilişkili web adresini belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubMerchantUrl { get; set; }

        /// <summary>
        /// Bu özellik, alt üye işyerinin bulunduğu şehri belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubMerchantCity { get; set; }

        /// <summary>
        /// Bu özellik, alt üye işyerinin posta kodunu belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubMerchantPostalCode { get; set; }

        /// <summary>
        /// Bu özellik, alt üye işyerinin bulunduğu ülkeyi belirtir. 
        /// Varsayılan değer "TÜRKİYE" olarak ayarlanmıştır.
        /// </summary>
        public string? SubMerchantCountry { get; set; } = "TÜRKİYE"; //792

        /// <summary>
        /// Bu özellik, alt üye işyerinin organizasyon kimliğini belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubMerchantOrganizationId { get; set; }

        /// <summary>
        /// Bu özellik, Asseco ile yapılan işlemlerde kullanılan facilicator kimliğini belirtir.
        /// Varsayılan değer "10000005" olarak ayarlanmıştır.
        /// </summary>
        public string? SubMerchantFacilicatorId { get; set; } = "10000005";

        /// <summary>
        /// Bu özellik, Vakıfbank ile yapılan işlemlerde kullanılan alt üye işyeri terminal numarasını belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubMerchantTerminalNo { get; set; }
    }
}
