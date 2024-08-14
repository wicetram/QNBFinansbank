using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.Check
{
    /// <summary>
    /// Sipariş Sorgulama (Order Inquiry) işlemine ait istek parametrelerini temsil eden DTO.
    /// Bu sınıf, sipariş sorgulama işlemi için gerekli olan tüm parametreleri içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest")]
    public class CheckRequestDataDto : IDto
    {
        /// <summary>
        /// Kurum kodudur. 
        /// Banka tarafından verilen ve 4 karakter uzunluğunda olan benzersiz kod.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası. 
        /// Bankadan temin edilen ve 15 karaktere kadar uzunlukta olabilen benzersiz numara.
        /// </summary>
        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı kodu. 
        /// Bankadan temin edilen ve maksimum 40 karakter uzunluğunda olan kullanıcı kodu.
        /// </summary>
        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı şifresi. 
        /// Bankadan temin edilen ve maksimum 20 karakter uzunluğunda olan kullanıcı şifresi.
        /// </summary>
        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        /// <summary>
        /// Sipariş Numarası. 
        /// İşleme özgü olarak üretilen, maksimum 36 karakter uzunluğunda benzersiz numara.
        /// </summary>
        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        /// <summary>
        /// İşlemin güvenlik türünü belirtir. 
        /// Inquiry gibi güvenlik tiplerini belirten maksimum 15 karakter uzunluğunda olan string.
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tipi. 
        /// Örneğin, sipariş sorgulama işlemi için "OrderInquiry" olarak kullanılır. Maksimum 20 karakter uzunluğunda.
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisi. 
        /// Maksimum 2 karakter uzunluğunda olup, Türkçe için "TR", İngilizce için "EN" değerlerini alabilir. Zorunlu değildir.
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }
    }
}
