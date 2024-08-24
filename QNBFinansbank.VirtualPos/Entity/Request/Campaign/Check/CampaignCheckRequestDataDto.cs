using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.Campaign.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden kampanya kontrolü yapmak için kullanılan veri sınıfı.
    /// Bu sınıf, XML formatında gönderilecek kampanya kontrolü için gerekli olan tüm parametreleri içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest")]
    public class CampaignCheckRequestDataDto : IDto
    {
        /// <summary>
        /// Üye işyeri numarasını (MbrId) temsil eder.
        /// Bu değer, işlemin hangi üye işyeri tarafından yapıldığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri kodunu (MerchantId) temsil eder.
        /// Bu değer, kampanya kontrolü yapılacak üye işyeri kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "MerchantId")]
        public string? MerchantId { get; set; }

        /// <summary>
        /// Kullanıcı kodunu (UserCode) temsil eder.
        /// Bu değer, işlemi yapan kullanıcının kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Kullanıcı şifresini (UserPass) temsil eder.
        /// Bu değer, işlemi yapan kullanıcının şifresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        /// <summary>
        /// Güvenlik türünü (SecureType) temsil eder.
        /// Bu değer, işlemde kullanılacak güvenlik yöntemini belirtir (örn. 3D Secure).
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem türünü (TxnType) temsil eder.
        /// Bu değer, kampanya kontrolü işlemi türünü belirtir.
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// İşlem dilini (Lang) temsil eder.
        /// Bu değer, işlemin yapılacağı dili belirtir.
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }

        /// <summary>
        /// Sipariş numarasını (OrderId) temsil eder.
        /// Bu değer, kampanya kontrolü yapılacak siparişin numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        /// <summary>
        /// Alışveriş tutarını (PurchAmount) temsil eder.
        /// Bu değer, işlemin tutarını belirtir.
        /// </summary>
        [XmlElement(ElementName = "PurchAmount")]
        public string? PurchAmount { get; set; }

        /// <summary>
        /// Döviz kodunu (Currency) temsil eder.
        /// Bu değer, işlemin yapılacağı döviz cinsini belirtir.
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Taksit sayısını (InstallmentCount) temsil eder.
        /// Bu değer, işlemin kaç taksit üzerinden yapılacağını belirtir.
        /// </summary>
        [XmlElement(ElementName = "InstallmentCount")]
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// Kart numarasını (Pan) temsil eder.
        /// Bu değer, işlemin yapılacağı kartın numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "Pan")]
        public string? Pan { get; set; }

        /// <summary>
        /// Kartın son kullanma tarihini (Expiry) temsil eder.
        /// Bu değer, işlemin yapılacağı kartın son kullanma tarihini belirtir.
        /// </summary>
        [XmlElement(ElementName = "Expiry")]
        public string? Expiry { get; set; }

        /// <summary>
        /// Kartın güvenlik kodunu (Cvv2) temsil eder.
        /// Bu değer, işlemin yapılacağı kartın arka yüzündeki güvenlik kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "Cvv2")]
        public string? Cvv2 { get; set; }

        /// <summary>
        /// MOTO (Mail Order/Telephone Order) işlemi olup olmadığını belirten bayrağı temsil eder.
        /// Bu değer, işlemin MOTO olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "MOTO")]
        public string? MOTO { get; set; }
    }
}