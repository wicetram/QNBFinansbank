using QNBFinansbank.VirtualPos.Entity.Request.Payment.PaymentFacilicator;
using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.Payment.NonSecure
{
    /// <summary>
    /// NonSecure satış işlemine gönderilen parametreleri temsil eden DTO.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest", Namespace = "")]
    public class NonSecurePaymentRequestDto : IDto
    {
        /// <summary>
        /// Kurum kodudur. 
        /// (Banka tarafından verilir)
        /// </summary>
        [XmlElement(ElementName = "MbrId", Namespace = "")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası. 
        /// (Bankadan temin edilir)
        /// </summary>
        [XmlElement(ElementName = "MerchantID", Namespace = "")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı kodu. 
        /// (Bankadan temin edilir)
        /// </summary>
        [XmlElement(ElementName = "UserCode", Namespace = "")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı şifresi. 
        /// (Bankadan temin edilir)
        /// </summary>
        [XmlElement(ElementName = "UserPass", Namespace = "")]
        public string? UserPass { get; set; }

        /// <summary>
        /// Üye işyeri tarafından üretilen işleme özgü bir numaradır. 
        /// Doldurulmaz ise sistem her işlem için kendisi de otomatik olarak bir sipariş numarası üretmektedir.
        /// </summary>
        [XmlElement(ElementName = "OrderId", Namespace = "")]
        public string? OrderId { get; set; }

        /// <summary>
        /// İşlemin güvenlik türünü belirtir. 
        /// (NonSecure)
        /// </summary>
        [XmlElement(ElementName = "SecureType", Namespace = "")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tipidir. 
        /// (Satış:Auth)
        /// </summary>
        [XmlElement(ElementName = "TxnType", Namespace = "")]
        public string? TxnType { get; set; }

        /// <summary>
        /// İşlem tutarıdır. 
        /// 99.50 ya da 99,50 şeklinde olmalıdır. 
        /// 2 karakter üzerinde gönderilen değerlerde(99,500) işlem vpos sistemi tarafından reddedilecektir.
        /// </summary>
        [XmlElement(ElementName = "PurchAmount", Namespace = "")]
        public string? PurchAmount { get; set; }

        /// <summary>
        /// Taksit sayısını ifade eder. 
        /// İşlem taksitli işlem olacaksa bu sayı 1'den büyük olmalıdır. 
        /// Eğer 1'den küçük veya numerik olmayan bir değer gönderilirse 0 kabul edilir.
        /// </summary>
        [XmlElement(ElementName = "InstallmentCount", Namespace = "")]
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// Kur bilgisi. 
        /// (TL:949, USD:840, EUR:978, GBP:826, JPY:392, RUB:643)
        /// </summary>
        [XmlElement(ElementName = "Currency", Namespace = "")]
        public string? Currency { get; set; }

        /// <summary>
        /// Kart numarası.
        /// </summary>
        [XmlElement(ElementName = "Pan", Namespace = "")]
        public string? Pan { get; set; }

        /// <summary>
        /// Kartın son kullanma tarihini belirtir. 
        /// MMYY formatında gönderilir. Örnek: Şubat 2015 için 0215
        /// </summary>
        [XmlElement(ElementName = "Expiry", Namespace = "")]
        public string? Expiry { get; set; }

        /// <summary>
        /// Güvenlik Kodu. 
        /// Kartın arkasında bulunan 3 basamaklı sayıdır.
        /// </summary>
        [XmlElement(ElementName = "Cvv2", Namespace = "")]
        public string? Cvv2 { get; set; }

        /// <summary>
        /// İşlem MOTO (Mail Order Telephone Order) olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "MOTO", Namespace = "")]
        public string? MOTO { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisi. 
        /// (Türkçe: TR, İngilizce: EN)
        /// </summary>
        [XmlElement(ElementName = "Lang", Namespace = "")]
        public string? Lang { get; set; }

        /// <summary>
        /// Bu sınıf, ödeme işlemlerinde kullanılacak olan Payment Facilitator verilerini tutar.
        /// </summary>
        public PaymentFacilicatorRequestDto? PaymentFacilicator { get; set; }
    }
}
