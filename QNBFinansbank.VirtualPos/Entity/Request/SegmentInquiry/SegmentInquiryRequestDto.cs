using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.SegmentInquiry
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden segment sorgulama işlemi için gerekli olan parametreleri temsil eder.
    /// Bu sınıf, hesap, üye işyeri, kullanıcı, kart ve işlem bilgilerini içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest")]
    public class SegmentInquiryRequestDto : IDto
    {
        /// <summary>
        /// Kurum kodudur. Banka tarafından verilir.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası. Bankadan temin edilir.
        /// </summary>
        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı kodu. Bankadan temin edilir.
        /// </summary>
        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı şifresi. Bankadan temin edilir.
        /// </summary>
        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        /// <summary>
        /// Kart numarası. İşlem yapılacak kredi kartının numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "Pan")]
        public string? Pan { get; set; }

        /// <summary>
        /// Kartın son kullanma tarihini belirtir. MMYY formatında gönderilir. 
        /// Örneğin, Şubat 2015 için 0215 şeklinde belirtilmelidir.
        /// </summary>
        [XmlElement(ElementName = "Expiry")]
        public string? Expiry { get; set; }

        /// <summary>
        /// İşlemin güvenlik türünü belirtir. Segment sorgulama işlemi için "Inquiry" değeri kullanılır.
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tipidir. Segment sorgulama işlemi için "SegmentInquiry" değeri kullanılır.
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisini belirtir. Türkçe için "TR", İngilizce için "EN" kullanılır.
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }
    }
}
