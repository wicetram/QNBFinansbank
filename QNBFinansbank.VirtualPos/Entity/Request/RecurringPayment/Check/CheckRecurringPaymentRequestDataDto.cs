using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.RecurringPayment.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde tekrarlı ödeme işlemini kontrol etmek için kullanılan verileri temsil eden DTO sınıfı.
    /// Bu sınıf, XML formatında gönderilecek olan tekrarlı ödeme kontrol talebini oluşturur.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest")]
    public class CheckRecurringPaymentRequestDataDto : IDto
    {
        /// <summary>
        /// Üye işyeri kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// İşlemi gerçekleştiren satıcının kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MerchantId")]
        public string? MerchantId { get; set; }

        /// <summary>
        /// Kullanıcının kimliğini veya kullanıcı adını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Kullanıcının şifresini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        /// <summary>
        /// İşlem türünü belirtir. Bu durumda, tekrarlı ödeme kontrolü için kullanılan `RequestType` belirlenir.
        /// </summary>
        [XmlElement(ElementName = "RequestType")]
        public string? RequestType { get; set; }

        /// <summary>
        /// Tekrarlı ödeme işlemi için satıcının atadığı benzersiz sipariş kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MrcOrderId")]
        public string? MrcOrderId { get; set; }

        /// <summary>
        /// Tekrarlı ödeme işlemi için benzersiz işlem rehberini (GUID) temsil eder.
        /// </summary>
        [XmlElement(ElementName = "InstOrderGuid")]
        public string? InstOrderGuid { get; set; }
    }
}