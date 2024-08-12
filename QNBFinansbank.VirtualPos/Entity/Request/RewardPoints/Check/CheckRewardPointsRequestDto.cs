using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde para puan sorgulama işlemi için gerekli olan parametreleri içeren DTO sınıfı.
    /// Bu sınıf, para puan sorgulama işlemi sırasında gereken hesap, kart ve işlem bilgilerini içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest")]
    public class CheckRewardPointsRequestDto
    {
        /// <summary>
        /// Kurum kodu. (Banka tarafından verilir)
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası. (Bankadan temin edilir)
        /// </summary>
        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı kodu. (Bankadan temin edilir)
        /// </summary>
        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı şifresi. (Bankadan temin edilir)
        /// </summary>
        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        /// <summary>
        /// Üye işyeri tarafından üretilen işleme özgü bir numara.
        /// Eğer doldurulmazsa, sistem her işlem için otomatik olarak bir sipariş numarası üretir.
        /// </summary>
        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        /// <summary>
        /// İşlemin güvenlik türünü belirtir. (Örneğin, Inquiry)
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tipidir. (Örneğin, Para Puan Sorgulama: ParaPuanInquiry)
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Kur bilgisi. (Örneğin, TL:949, USD:840, EUR:978)
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Kart numarası.
        /// </summary>
        [XmlElement(ElementName = "Pan")]
        public string? Pan { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisi. (Örneğin, Türkçe: TR, İngilizce: EN)
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }
    }
}
