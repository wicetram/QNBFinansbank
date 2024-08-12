using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.BatchClose
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde toplu kapama (batch close) işlemi için gerekli parametreleri temsil eder.
    /// Bu sınıf, toplu kapama işlemi sırasında kullanılacak hesap, güvenlik ve dil bilgilerini içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest")]
    public class BatchCloseRequestDto : IDto
    {
        /// <summary>
        /// Kurum kodu. Banka tarafından verilir.
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
        /// İşlemde kullanılacak para birimi (TL:949, USD:840, EUR:978, vb.).
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// İşlemin güvenlik türünü belirtir. Örneğin: "Secure", "NonSecure".
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tipi. Bu alan, işlem türünü belirtir. Örneğin: "BatchClose".
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisi. (Türkçe: TR, İngilizce: EN)
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }
    }
}
