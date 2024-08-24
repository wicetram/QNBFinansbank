using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.EOD
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde EOD (End of Day) rapor isteği için gerekli olan parametreleri temsil eder.
    /// Bu sınıf, EOD raporu oluşturmak için gerekli olan üye işyeri, kullanıcı ve tarih bilgilerini içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest")]
    public class EODRequestDataDto : IDto
    {
        /// <summary>
        /// Üye işyeri numarasını temsil eder.
        /// Bu alan, rapor isteğinde hangi üye işyerinin kullanıldığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri Merchant ID'sini temsil eder.
        /// Bu alan, rapor isteğinde kullanılan üye işyeri Merchant ID'sini belirtir.
        /// </summary>
        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// Kullanıcı kodunu temsil eder.
        /// Bu alan, rapor isteğinde kullanılan kullanıcı kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Kullanıcı şifresini temsil eder.
        /// Bu alan, rapor isteğinde kullanılan kullanıcı şifresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        /// <summary>
        /// İsteğin yapılacağı tarihi temsil eder.
        /// Bu alan, rapor isteğinde kullanılacak tarihi "yyyyMMdd" formatında belirtir.
        /// </summary>
        [XmlElement(ElementName = "ReqDate")]
        public string? ReqDate { get; set; }

        /// <summary>
        /// İsteğin bitiş tarihini temsil eder.
        /// Bu alan, rapor isteğinde kullanılacak bitiş tarihini belirtir.
        /// </summary>
        [XmlElement(ElementName = "EndDate")]
        public string? EndDate { get; set; }

        /// <summary>
        /// Güvenlik tipini temsil eder.
        /// Bu alan, rapor isteğinde kullanılacak güvenlik tipini belirtir.
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tipini temsil eder.
        /// Bu alan, rapor isteğinde kullanılacak işlem tipini belirtir.
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Döviz cinsini temsil eder.
        /// Bu alan, rapor isteğinde kullanılacak döviz cinsini belirtir.
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// İsteğin dilini temsil eder.
        /// Bu alan, rapor isteğinde kullanılacak dili belirtir.
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }
    }
}
