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
        public string? SubmerchantId { get; set; }

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
        /// Asseco parametresi (Ziraat Bankası).
        /// Bu parametre, Asseco ve Ziraat Bankası işlemlerinde kullanılmakta olan alt üye işyeri numarasını temsil eder.
        /// </summary>
        public string? SubMerchantNumber { get; set; }

        /// <summary>
        /// Asseco için kullanılan parametre.
        /// Yeni PF tanımı yapılana kadar, SubmerchantID parametresi bu alan ile doldurulacak.
        /// </summary>
        public string? SubMerchantBddkCode { get; set; }

        /// <summary>
        /// Asseco parametresi (MCC Kodu).
        /// Alt üye işyerinin Merchant Category Code (MCC) değerini belirtir.
        /// </summary>
        public string? SubMerchantMcc { get; set; }

        /// <summary>
        /// Asseco parametresi (TCKN/VKN).
        /// Alt üye işyerinin T.C. Kimlik Numarası (TCKN) veya Vergi Kimlik Numarası (VKN) değerini belirtir.
        /// </summary>
        public string? SubMerchantIn { get; set; }

        /// <summary>
        /// Asseco parametresi (MCC URL).
        /// Bu özellik, alt üye işyerinin Merchant Category Code (MCC) ile ilişkili web adresini belirtir.
        /// </summary>
        public string? SubMerchantUrl { get; set; }

        /// <summary>
        /// Asseco parametresi (Şehir).
        /// Bu özellik, alt üye işyerinin bulunduğu şehri belirtir.
        /// </summary>
        public string? SubMerchantCity { get; set; }

        /// <summary>
        /// Asseco parametresi (Posta Kodu).
        /// Bu özellik, alt üye işyerinin posta kodunu belirtir.
        /// </summary>
        public string? SubMerchantPostalCode { get; set; }

        /// <summary>
        /// Asseco parametresi (Ülke).
        /// Bu özellik, alt üye işyerinin bulunduğu ülkeyi belirtir. 
        /// Varsayılan değer "TÜRKİYE" olarak ayarlanmıştır.
        /// </summary>
        public string? SubMerchantCountry { get; set; } = "TÜRKİYE"; //792

        /// <summary>
        /// Asseco parametresi (Organizasyon Kimliği).
        /// Bu özellik, alt üye işyerinin organizasyon kimliğini belirtir.
        /// </summary>
        public string? SubMerchantOrganizationId { get; set; }

        /// <summary>
        /// Asseco parametresi (Facilicator ID).
        /// Bu özellik, Asseco ile yapılan işlemlerde kullanılan facilicator kimliğini belirtir.
        /// Varsayılan değer "10000005" olarak ayarlanmıştır.
        /// </summary>
        public string? SubMerchantFacilicatorId { get; set; } = "10000005";

        /// <summary>
        /// Vakıfbank parametresi (Terminal No).
        /// Bu özellik, Vakıfbank ile yapılan işlemlerde kullanılan alt üye işyeri terminal numarasını belirtir.
        /// </summary>
        public string? SubMerchantTerminalNo { get; set; }
    }
}
