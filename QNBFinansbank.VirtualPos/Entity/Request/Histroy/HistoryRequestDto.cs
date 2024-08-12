using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.History
{
    /// <summary>
    /// İşlem geçmişi sorgulama talebini temsil eden DTO.
    /// Bu sınıf, işlem geçmişi sorgulaması yapmak için gerekli olan tüm parametreleri içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest")]
    public class HistoryRequestDto : IDto
    {
        /// <summary>
        /// Kurum kodunu temsil eder. Banka tarafından sağlanır.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarasını temsil eder. Bankadan temin edilir.
        /// </summary>
        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı kodunu temsil eder. Bankadan temin edilir.
        /// </summary>
        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı şifresini temsil eder. Bankadan temin edilir.
        /// </summary>
        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        /// <summary>
        /// Detayları sorgulanacak işlemin ID'sini temsil eder. Bu alan opsiyoneldir.
        /// </summary>
        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        /// <summary>
        /// Gün sonu detayı sorgulanacak işlem tarihidir (YYYYMMDD formatında).
        /// </summary>
        [XmlElement(ElementName = "ReqDate")]
        public string? ReqDate { get; set; }

        /// <summary>
        /// İşlem geçmişi sorgulanacak epoch değeri. Bu değer belirli bir zaman diliminde yapılan işlemleri sorgulamak için kullanılır.
        /// </summary>
        [XmlElement(ElementName = "RequestStartDatetime")]
        public string? RequestStartDatetime { get; set; }

        /// <summary>
        /// İşlemin güvenlik türünü belirtir (Ör: "Report").
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tipini belirtir (Ör: İşlem Geçmişi: "TxnHistory").
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Kur bilgisi. (Ör: TL:949, USD:840, EUR:978, vb.)
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisini belirtir (Ör: Türkçe: "TR", İngilizce: "EN").
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }
    }
}
