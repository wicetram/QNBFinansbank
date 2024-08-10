using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.Payment.PaymentFacilicator
{
    /// <summary>
    /// Payment Facilitator Request Data Transfer Object.
    /// Bu sınıf, ödeme işlemlerinde kullanılacak olan Payment Facilitator verilerini tutar.
    /// </summary>
    public class PaymentFacilicatorRequestDto : IDto
    {
        /// <summary>
        /// Payment Facilitator ID (PF numarası). Ana Bayi Numarasıdır. Zorunlu ve en fazla 11 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "PaymentFacilitatorId")]
        public string? PaymentFacilitatorId { get; set; }

        /// <summary>
        /// Alt bayi numarası. Ana Bayi tarafından tanımlanan değerdir. Zorunlu ve en fazla 15 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "SubMerchantCode")]
        public string? SubMerchantCode { get; set; }

        /// <summary>
        /// Independent Sales Organization ID (Satış organizasyon numarası). Zorunlu ve en fazla 15 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "IndSalesOrgId")]
        public string? IndSalesOrgId { get; set; }

        /// <summary>
        /// Merchant Category Code (MCC). Alt Bayi MCC kodudur. Zorunlu ve 4 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "SubmerchantMCC")]
        public string? SubmerchantMCC { get; set; }

        /// <summary>
        /// Card Acceptor Name/Location. Kart ekstresinde görüntülenecek PF adı veya Altbayi adı. Zorunlu ve en fazla 32 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorName")]
        public string? CardAcceptorName { get; set; }

        /// <summary>
        /// Card Acceptor Street Address. Alt Bayii adres bilgisidir. Zorunlu ve en fazla 32 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorStreet")]
        public string? CardAcceptorStreet { get; set; }

        /// <summary>
        /// Card Acceptor City. Alt Bayi şehir bilgisidir. Zorunlu ve en fazla 32 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorCity")]
        public string? CardAcceptorCity { get; set; }

        /// <summary>
        /// Card Acceptor Postal [ZIP] Code. Alt Bayi posta kodudur. Zorunlu ve en fazla 32 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorPostalCode")]
        public string? CardAcceptorPostalCode { get; set; }

        /// <summary>
        /// Card Acceptor State, Province, or Region Code. Alt Bayi adres bilgisi (bölge). Zorunlu ve en fazla 32 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorState")]
        public string? CardAcceptorState { get; set; }

        /// <summary>
        /// Card Acceptor Country Code. TL Country (Ülke kodu). Türkiye için 792 kodu kullanılır. Zorunlu ve en fazla 32 karakter uzunluğundadır.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorCountry")]
        public string? CardAcceptorCountry { get; set; } = "792";
    }
}
